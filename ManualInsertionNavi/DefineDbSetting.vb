Public Class DefineDbSetting
    'アクセス(accdb)接続時のプロバイダ名
    Public ReadOnly Provider As String = "Microsoft.ACE.OLEDB.12.0"
    '接続文字列作成時のパスワード文字列
    Public ReadOnly Property ConnectPassword As String = ";Jet OLEDB:Database Password=nagasaki;"
    'SQL作成時のパスワード文字列
    Public ReadOnly Property SqlPassword As String = ";pwd=nagasaki"

    'Accessデータベースファイルの拡張子定義
    Public ReadOnly Property DbExtention As String = ".accdb"

    '接続時のパスワード使用有無定義
    'パスワードを使用有無
    Public Property EnableConnectPassword As Boolean = True

    'システムデータベースパス
    Public Property DbPath As String = Nothing



End Class
