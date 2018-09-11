Public Class FormMessage
    Implements IDisposable

    'キャンセルボタンがクリックされたか
    Private _canceled As Boolean = False
    Private ReadOnly canceledSyncObject = New Object
    Private Property cancel() As Boolean
        Get
            SyncLock (canceledSyncObject)
                Return Me._canceled
            End SyncLock
        End Get
        Set(ByVal Value As Boolean)
            SyncLock (canceledSyncObject)
                Me._canceled = Value
            End SyncLock
        End Set
    End Property
    'ダイアログフォーム
    Private form As FormMessage
    'フォームが表示されるまで待機するための待機ハンドル
    Private startEvent As System.Threading.ManualResetEvent
    'フォームが一度表示されたか
    Private showed As Boolean = False
    'フォームをコードで閉じているか
    Private closing_flag As Boolean = False
    'オーナーフォーム
    Private ownerForm As Form

    '別処理をするためのスレッド
    Private thread As System.Threading.Thread

    'フォームのタイトル
    Private _title As String = "進行状況"
    'ProgressBarの最小、最大、現在の値
    Private _minimum As Integer = 0
    Private _maximum As Integer = 100
    Private _value As Integer = 0
    '表示するメッセージ
    Private _message As String = ""

    ''' <summary>
    ''' ダイアログのタイトルバーに表示する文字列
    ''' </summary>
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
            If Not (form Is Nothing) Then
                form.Invoke(New MethodInvoker(AddressOf SetTitle))
            End If
        End Set
    End Property

    ''' <summary>
    ''' プログレスバーの最小値
    ''' </summary>
    Public Property Minimum() As Integer
        Get
            Return _minimum
        End Get
        Set(ByVal Value As Integer)
            _minimum = Value
            If Not (form Is Nothing) Then
                form.Invoke(New MethodInvoker( _
                    AddressOf SetProgressMinimum))
            End If
        End Set
    End Property

    ''' <summary>
    ''' プログレスバーの最大値
    ''' </summary>
    Public Property Maximum() As Integer
        Get
            Return _maximum
        End Get
        Set(ByVal Value As Integer)
            _maximum = Value
            If Not (form Is Nothing) Then
                form.Invoke(New MethodInvoker( _
                    AddressOf SetProgressMaximun))
            End If
        End Set
    End Property

    ''' <summary>
    ''' プログレスバーの値
    ''' </summary>
    Public Property Value() As Integer
        Get
            Return _value
        End Get
        Set(ByVal Value As Integer)
            _value = Value
            If Not (form Is Nothing) Then
                form.Invoke(New MethodInvoker( _
                    AddressOf SetProgressValue))
            End If
        End Set
    End Property

    ''' <summary>
    ''' ダイアログに表示するメッセージ
    ''' </summary>
    Public Property Message() As String
        Get
            Return _message
        End Get
        Set(ByVal Value As String)
            _message = Value
            If Not (form Is Nothing) Then
                form.Invoke(New MethodInvoker(AddressOf SetMessage))
            End If
        End Set
    End Property

    ''' <summary>
    ''' キャンセルされたか
    ''' </summary>
    Public ReadOnly Property Canceled() As Boolean
        Get
            Return _canceled
        End Get
    End Property

    ''' <summary>
    ''' ダイアログを表示する
    ''' </summary>
    ''' <param name="owner">
    ''' ownerの中央にダイアログが表示される
    ''' </param>
    ''' <remarks>
    ''' このメソッドは一回しか呼び出せません。
    ''' </remarks>
    Public Overloads Sub Show(ByVal owner As Form)
        If showed Then
            Throw New Exception("ダイアログは一度表示されています。")
        End If
        showed = True

        _canceled = False
        startEvent = New System.Threading.ManualResetEvent(False)
        ownerForm = owner

        'スレッドを作成
        thread = New System.Threading.Thread( _
            New System.Threading.ThreadStart(AddressOf Run))
        thread.IsBackground = True
        'Me.thread.ApartmentState = System.Threading.ApartmentState.STA
        Me.thread.SetApartmentState(System.Threading.ApartmentState.STA)
        thread.Start()

        'フォームが表示されるまで待機する
        startEvent.WaitOne()
    End Sub

    Public Overloads Sub Show()
        Show(Nothing)
    End Sub

    '別スレッドで処理するメソッド
    Private Sub Run()
        'フォームの設定
        form = New FormMessage
        form.Text = _title
        AddHandler form.Button1.Click, AddressOf Button1_Click
        AddHandler form.closing, AddressOf form_Closing
        AddHandler form.Activated, AddressOf form_Activated
        form.ProgressBar1.Minimum = _minimum
        form.ProgressBar1.Maximum = _maximum
        form.ProgressBar1.Value = _value
        'フォームの表示位置をオーナーの中央へ
        If Not (ownerForm Is Nothing) Then
            form.StartPosition = FormStartPosition.Manual
            form.Left = _
                ownerForm.Left + (ownerForm.Width - form.Width) \ 2
            form.Top = _
                ownerForm.Top + (ownerForm.Height - form.Height) \ 2
        End If
        'フォームの表示
        form.ShowDialog()

        form.Dispose()
    End Sub

    ''' <summary>
    ''' ダイアログを閉じる
    ''' </summary>
    Public Sub CloseWindow()
        closing_flag = True
        form.Invoke(New MethodInvoker(AddressOf form.Close))
    End Sub 'Close

    'Public Sub DisposeWindow() Implements System.IDisposable.Dispose
    Public Sub DisposeWindow()
        form.Invoke(New MethodInvoker(AddressOf form.Dispose))
    End Sub

    Private Sub SetProgressValue()
        If Not (form Is Nothing) And Not form.IsDisposed Then
            form.ProgressBar1.Value = _value
        End If
    End Sub

    Private Sub SetMessage()
        If Not (form Is Nothing) And Not form.IsDisposed Then
            form.Label1.Text = _message
        End If
    End Sub

    Private Sub SetTitle()
        If Not (form Is Nothing) And Not form.IsDisposed Then
            form.Text = _title
        End If
    End Sub

    Private Sub SetProgressMaximun()
        If Not (form Is Nothing) And Not form.IsDisposed Then
            form.ProgressBar1.Maximum = _maximum
        End If
    End Sub

    Private Sub SetProgressMinimum()
        If Not (form Is Nothing) And Not form.IsDisposed Then
            form.ProgressBar1.Minimum = _minimum
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs)
        _canceled = True
    End Sub

    Private Sub form_Closing(ByVal sender As Object, _
        ByVal e As System.ComponentModel.CancelEventArgs)
        If Not closing_flag Then
            e.Cancel = True
            _canceled = True
        End If
    End Sub

    Private Sub form_Activated(ByVal sender As Object, _
        ByVal e As EventArgs)
        RemoveHandler form.Activated, AddressOf form_Activated
        startEvent.Set()
    End Sub

End Class