Public Module ModuleDefineStructureExcel
    ''' <summary>
    ''' エクセルシート追加情報構造体の宣言
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure ExcelAddSheetStatus
        '選択したシート名
        Public Property SheetName As String
        '新規シート追加選択状態
        Public Property IsAddSheet As Boolean
        'シート選択状態
        Public Property IsSelect As Boolean
        Public Sub InitializeParam()
            SheetName = Nothing
            IsAddSheet = False
            IsSelect = True
        End Sub

    End Structure

    ''' <summary>
    ''' エクセルシート追加情報構造体の宣言
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure ExcelInsertImageStatus
        '画像ファイル名（フルパス）
        Public Property ImageFileName As String
        '画像サイズ（幅）
        Public Property ImageWidth As Integer
        '画像サイズ（高さ）
        Public Property ImageHeight As Integer
        'オフセット値（X）
        Public Property OffsetX As Double
        'オフセット値（Y）
        Public Property OffsetY As Double
        '各パラメータ初期化
        Public Sub InitializeParam()
            ImageFileName = Nothing
            ImageWidth = 0
            ImageHeight = 0
            OffsetX = 0
            OffsetY = 0
        End Sub
    End Structure

End Module
