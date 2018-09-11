Public Class FormInputProductInfo

    'オーダー管理テーブル
    Private TableOrder As New DataTable

    '個人別の日別実績・計画データ
    Private TablePrivatePlanActual As New DataTable


    '生産情報構造体
    Public ProductInfo As New ProductionInfomation
    '図面情報データテーブル
    Public DtDrawing As New DataTable

    '個人の日毎の計画・実績データ新規作成フラグ
    Private IsNewPrivatePlan As Boolean = True


    Private DefPpaDb As DefineProductionPlanActualDb = New DefineProductionPlanActualDb
    Private CtrlPpaDb As ControlDbProductionPlanActual = New ControlDbProductionPlanActual(DefPpaDb)


    Private Const ProductionStartMessage As String = "ＥＮＴＥＲ又は、ＯＫボタンを押して生産を開始してください。"
    Private Const ProductionAlreadyCompleteMessage As String = "入力したオーダーは、本日予定数の生産が完了しています。"

    Private Enum InputItem
        'オーダー
        Order
        '基板名称
        BoardName
        '製作枚数
        QuantityPlanTotal
        '製作実績数
        QuantityActualTotal
        '製作計画数(日毎)
        QuantityPlanDaily
        '製作実績数(日毎)
        QuantityActualDaily
    End Enum
    Private Const InputItemNum As Integer = 6
    Private InputResult As New List(Of Boolean)
    Public Sub New(ByVal systemDbPath As String)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        CtrlPpaDb.DefPpaDb.DbPath = systemDbPath
    End Sub
    Private Sub FormInputProductInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProductInfo.Initialize()
        ProductInfo.ProductionDate = Now.Date
        ProductInfo.WorkerManNumber = SysLoginUserInfo.ManNumber

        LabelInputMessege.Text = "オーダーを入力してください。"

        For i As Integer = 0 To InputItemNum - 1
            InputResult.Add(False)
        Next

        ActiveControl = TextBoxOrder
    End Sub
    Private Sub ClearInputResult()
        For i As Integer = 0 To InputItemNum - 1
            InputResult(i) = False
        Next

    End Sub
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        If IsOkInputData() = True Then
            '作業者の日毎の計画・実績データ登録
            Dim insertId As Integer
            If IsNewPrivatePlan = True Then
                insertId = CtrlPpaDb.InsertProductionPlanActualDataAndReturnId(TablePrivatePlanActual.Rows(0))
                If 0 < insertId Then
                    ProductInfo.ProductionPlanActualId = insertId
                Else

                    Dim mess As New System.Text.StringBuilder
                    mess.AppendLine("製作予定データの登録ができませんでした。")
                    mess.AppendLine("しばらく時間をおいてから、ＯＫボタンを押してください。")
                    mess.AppendLine("再度試しても、登録できない場合は、管理者に連絡してください。")
                    MessageBox.Show(mess.ToString, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub ClearProductInfo()
        ProductInfo.Order = ""
        ProductInfo.BoardName = ""
        ProductInfo.DrawingId = -1
        ProductInfo.ProductionPlanActualId = -1
        ProductInfo.Quantity(QuantityItem.DailyPlan) = 0
        ProductInfo.Quantity(QuantityItem.DailyActual) = 0
        ProductInfo.Quantity(QuantityItem.OrderTotalPlan) = 0
        ProductInfo.Quantity(QuantityItem.OrderTotalActual) = 0

    End Sub


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub


    Private Function IsOkInputData() As Boolean
        Dim result As Boolean = True
        For i As Integer = 0 To InputItemNum - 1
            If IsNewPrivatePlan = True Then
                If i = InputItem.QuantityActualDaily Then
                    Continue For
                End If
            End If
            If InputResult(i) = False Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function
    ''' <summary>
    ''' 入力されたオーダーが正しいか確認する。
    ''' </summary>
    ''' <returns>
    ''' True:該当オーダーあり　False:該当オーダー無し
    ''' </returns>
    Private Function IsOkOrder() As Boolean

        Dim isOk As Boolean = True
        Dim order As String = ConvetStrUpperNarrow(TextBoxOrder.Text)
        ClearInputResult()
        ClearProductInfo()
        ClearProductionInfoTextBox()
        ResetErrorProvider()
        If IsOrderString(order) = False Then
            ErrorProviderInput.SetError(TextBoxOrder, order & "未入力又は、使用禁止文字が含まれてるか、桁数(14-20)が間違っています。")
            TextBoxOrder.BackColor = Color.Yellow
            InputResult(InputItem.Order) = False
            isOk = False
        End If
        If isOk = True Then
            TableOrder = ControlOrderDb.GetOrderOneDataFromTable(order)
            If 0 < TableOrder.Rows.Count Then
                '該当オーダーあり
                ProductInfo.Order = TableOrder.Rows(0)(OMTColumnName(OMTColumn.Order))
                ProductInfo.BuId = TableOrder.Rows(0)(OMTColumnName(OMTColumn.BuId))
                ProductInfo.BoardName = TableOrder.Rows(0)(OMTColumnName(OMTColumn.BoardName))
                ProductInfo.Quantity(QuantityItem.OrderTotalPlan) = TableOrder.Rows(0)(OMTColumnName(OMTColumn.ProductionCount))

                TextBoxOrder.Text = ProductInfo.Order
                TextBoxBoardName.Text = ProductInfo.BoardName
                TextBoxQuantityPlanTotal.Text = ProductInfo.Quantity(QuantityItem.OrderTotalPlan).ToString("#,0")

                ErrorProviderInput.SetError(TextBoxOrder, "")
                TextBoxOrder.BackColor = SystemColors.Window
                InputResult(InputItem.Order) = True
                InputResult(InputItem.QuantityPlanTotal) = True

                isOk = True
            Else
                '該当オーダー無し
                ProductInfo.Order = Nothing
                ProductInfo.BuId = -1
                ProductInfo.BoardName = Nothing
                ProductInfo.Quantity(QuantityItem.OrderTotalPlan) = 0

                ErrorProviderInput.SetError(TextBoxOrder, "オーダー未登録！！")
                TextBoxOrder.BackColor = Color.Yellow
                InputResult(InputItem.Order) = False
                InputResult(InputItem.QuantityPlanTotal) = False
                isOk = False
            End If
        End If
        Return isOk

    End Function
    ''' <summary>
    ''' 生産計画データを取得する。取得した情報は、ProductInfo構造体に格納する。
    ''' </summary>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    Private Function GetDailyPlanAndActualData() As Boolean
        Dim isOk As Boolean = True

        '図面情報取得
        '旧図面データへの対応は別途検討の事
        DtDrawing = ControlDrawingMasterDb.GetDrawingDatasByBoardName(ProductInfo.BoardName, False)

        If DtDrawing.Rows.Count <= 0 Then
            InputResult(InputItem.BoardName) = False
            ErrorProviderInput.SetError(TextBoxBoardName, ProductInfo.BoardName & "のデータは登録されていません")
            Return False
        End If
        InputResult(InputItem.BoardName) = True

        ProductInfo.DrawingId = DtDrawing.Rows(0)(DITColumnName(DITColmun.Id))
        TablePrivatePlanActual = CtrlPpaDb.GetProductionPlanActual(ProductInfo)

        If 0 < TablePrivatePlanActual.Rows.Count Then
            '作業者の日毎の生産計画データがある場合
            isOk = True
            IsNewPrivatePlan = False
            InputResult(InputItem.QuantityActualDaily) = True
            InputResult(InputItem.QuantityPlanDaily) = True

            ProductInfo.ProductionPlanActualId = TablePrivatePlanActual.Rows(0)(PPATColumnName(PPATColumn.ID))
            ProductInfo.Quantity(QuantityItem.DailyPlan) = TablePrivatePlanActual.Rows(0)(PPATColumnName(PPATColumn.ProductionPlan))
            ProductInfo.Quantity(QuantityItem.DailyActual) = TablePrivatePlanActual.Rows(0)(PPATColumnName(PPATColumn.ProductionActural))

            TextBoxQuantityActualDaily.Text = ProductInfo.Quantity(QuantityItem.DailyActual).ToString("#,0")
            TextBoxQuantityPlanDaily.Text = ProductInfo.Quantity(QuantityItem.DailyPlan).ToString("#,0")

            LabelPrivateActual.Visible = True
            TextBoxQuantityActualDaily.Visible = True
            LabelPrivateActualUnit.Visible = True

        Else
            '作業者の日毎の生産計画データがない場合
            ProductInfo.Quantity(QuantityItem.DailyPlan) = 0
            ProductInfo.Quantity(QuantityItem.DailyActual) = 0


            Dim nrow As DataRow = TablePrivatePlanActual.NewRow
            nrow(PPATColumnName(PPATColumn.Order)) = ProductInfo.Order
            If ProductInfo.BuId = -1 Then
                nrow(PPATColumnName(PPATColumn.BuId)) = DBNull.Value
            Else
                nrow(PPATColumnName(PPATColumn.BuId)) = ProductInfo.BuId
            End If
            nrow(PPATColumnName(PPATColumn.BoardName)) = ProductInfo.BoardName

            nrow(PPATColumnName(PPATColumn.DrawingId)) = ProductInfo.DrawingId
            nrow(PPATColumnName(PPATColumn.ProductDate)) = ProductInfo.ProductionDate

            nrow(PPATColumnName(PPATColumn.ProductionPlan)) = ProductInfo.Quantity(QuantityItem.DailyPlan)
            nrow(PPATColumnName(PPATColumn.ProductionActural)) = ProductInfo.Quantity(QuantityItem.DailyActual)

            nrow(PPATColumnName(PPATColumn.WorkerManNumber)) = ProductInfo.WorkerManNumber
            TablePrivatePlanActual.Rows.Add(nrow)

            InputResult(InputItem.QuantityActualDaily) = False
            InputResult(InputItem.QuantityPlanDaily) = False

            TextBoxQuantityActualDaily.Text = ProductInfo.Quantity(QuantityItem.DailyActual).ToString("#,0")
            '作業者の日毎の生産計画データがない場合は、実績がないので非表示
            LabelPrivateActual.Visible = False
            TextBoxQuantityActualDaily.Visible = False
            LabelPrivateActualUnit.Visible = False

            IsNewPrivatePlan = True
        End If

        '該当オーダーの総実績数取得
        Dim totalActual As Integer = CtrlPpaDb.GetTotalOrderActual(ProductInfo.Order)
        If 0 <= totalActual Then
            TextBoxQuantityActualTotal.Text = totalActual.ToString("#,0")
            InputResult(InputItem.QuantityActualTotal) = True
            ProductInfo.Quantity(QuantityItem.OrderTotalActual) = totalActual

        Else
            InputResult(InputItem.QuantityActualTotal) = False
            TextBoxQuantityActualTotal.Text = ""
            ErrorProviderInput.SetError(TextBoxQuantityActualTotal, "実績が取得できませんでした。")
        End If


        Return isOk
    End Function


    Private Sub ClearProductionInfoTextBox()
        TextBoxBoardName.Text = ""
        TextBoxQuantityPlanTotal.Text = ""
        TextBoxQuantityActualTotal.Text = ""
        TextBoxQuantityActualDaily.Text = ""
        TextBoxQuantityPlanDaily.Text = ""

    End Sub
    Private Sub ResetErrorProvider()
        ErrorProviderInput.SetError(TextBoxOrder, "")
        ErrorProviderInput.SetError(TextBoxBoardName, "")
        ErrorProviderInput.SetError(TextBoxQuantityPlanTotal, "")
        ErrorProviderInput.SetError(TextBoxQuantityPlanTotal, "")
        ErrorProviderInput.SetError(TextBoxQuantityActualTotal, "")
        ErrorProviderInput.SetError(TextBoxQuantityActualDaily, "")
        ErrorProviderInput.SetError(TextBoxQuantityPlanDaily, "")
    End Sub

    Private Function IsOkQuantity() As Boolean
        Dim isOk As Boolean = False
        Dim qt As String = ConvetStrUpperNarrow(TextBoxQuantityPlanDaily.Text)
        Dim quantity As Integer

        If Integer.TryParse(qt, quantity) = True Then
            If 0 < quantity Then
                Dim diff As Integer
                diff = ProductInfo.Quantity(QuantityItem.OrderTotalPlan) - ProductInfo.Quantity(QuantityItem.OrderTotalActual)
                If quantity <= diff Then
                    ProductInfo.Quantity(QuantityItem.DailyPlan) = quantity
                    TablePrivatePlanActual.Rows(0)(PPATColumnName(PPATColumn.ProductionPlan)) = quantity
                    TextBoxQuantityPlanDaily.Text = quantity.ToString("#,0")
                    isOk = True
                Else
                    ErrorProviderInput.SetError(TextBoxQuantityPlanDaily, "予定数は、(総生産計画-実績:" & diff.ToString & ")以下を入力してください。")
                    isOk = False
                End If
            Else
                ErrorProviderInput.SetError(TextBoxQuantityPlanDaily, "０より大きな整数を入力してください。")
                isOk = False
            End If
        Else
            isOk = False
        End If

        Return isOk
    End Function

    Private Sub TextBoxProductInfo_Enter(sender As Object, e As EventArgs) Handles TextBoxOrder.Enter, TextBoxQuantityPlanDaily.Enter

        '子コントロールも含め探す場合
        Dim cs As Control() = Me.Controls.Find(sender.name, True)
        If 0 < cs.Length Then
            CType(cs(0), TextBox).BackColor = Color.Yellow
        End If


    End Sub

    Private Sub TextBoxProductInfo_Leave(sender As Object, e As EventArgs) Handles TextBoxOrder.Leave, TextBoxQuantityPlanDaily.Leave

        '子コントロールも含め探す場合
        Dim cs As Control() = Me.Controls.Find(sender.name, True)
        If 0 < cs.Length Then
            CType(cs(0), TextBox).BackColor = SystemColors.Window
        End If

    End Sub

    Private Sub TextBoxOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxOrder.KeyDown
        If e.KeyCode = Keys.Enter Then
            '入力された内容は、TextBoxOrder.Validatingで確認
            ActiveControl = TextBoxQuantityPlanDaily
        End If
    End Sub


    Private Sub TextBoxQuantityPlanDaily_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxQuantityPlanDaily.KeyDown
        If e.KeyCode = Keys.Enter Then
            '入力された内容の検証は、TextBoxQuantityPlanDaily.Validatingで行う
            ActiveControl = ButtonOK
        End If
    End Sub

    Private Sub ButtonOK_Enter(sender As Object, e As EventArgs) Handles ButtonOK.Enter
        ButtonOK.BackColor = Color.LimeGreen
    End Sub

    Private Sub ButtonOK_Leave(sender As Object, e As EventArgs) Handles ButtonOK.Leave
        ButtonOK.BackColor = SystemColors.Control

    End Sub

    Private Sub ButtonCancel_Enter(sender As Object, e As EventArgs) Handles ButtonCancel.Enter
        ButtonCancel.BackColor = Color.Red
    End Sub

    Private Sub ButtonCancel_Leave(sender As Object, e As EventArgs) Handles ButtonCancel.Leave
        ButtonCancel.BackColor = SystemColors.Control

    End Sub

    Private Sub TextBoxQuantityPlanDaily_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxQuantityPlanDaily.Validating
        If (IsOkQuantity() = False) AndAlso (ActiveControl IsNot TextBoxQuantityPlanDaily) Then
            InputResult(InputItem.QuantityPlanDaily) = False
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBoxQuantityPlanDaily_Validated(sender As Object, e As EventArgs) Handles TextBoxQuantityPlanDaily.Validated
        ErrorProviderInput.SetError(TextBoxQuantityPlanDaily, "")
        InputResult(InputItem.QuantityPlanDaily) = True
        LabelInputMessege.Text = ProductionStartMessage
        ActiveControl = ButtonOK
    End Sub

    Private Sub TextBoxOrder_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxOrder.Validating
        If ActiveControl IsNot TextBoxOrder Then
            If IsOkOrder() = False Then
                e.Cancel = True
            Else
                Dim result As Boolean = GetDailyPlanAndActualData()
                If result = False Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub TextBoxOrder_Validated(sender As Object, e As EventArgs) Handles TextBoxOrder.Validated
        ErrorProviderInput.SetError(TextBoxOrder, "")
        ChangeActiveControlAfterOrderInput()
    End Sub
    Private Sub ChangeActiveControlAfterOrderInput()
        If 0 < ProductInfo.Quantity(QuantityItem.DailyPlan) Then
            If ProductInfo.Quantity(QuantityItem.DailyActual) < ProductInfo.Quantity(QuantityItem.DailyPlan) Then
                ButtonOK.Enabled = True
                LabelInputMessege.Text = ProductionStartMessage
                ActiveControl = ButtonOK
            Else
                ButtonOK.Enabled = False
                LabelInputMessege.Text = ProductionAlreadyCompleteMessage
                ActiveControl = TextBoxOrder
            End If
        Else
            LabelInputMessege.Text = "生産計画枚数を入力してください。"
            ActiveControl = TextBoxQuantityPlanDaily
        End If
    End Sub
End Class