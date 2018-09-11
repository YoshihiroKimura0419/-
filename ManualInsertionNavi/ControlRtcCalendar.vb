Imports System
Public Class ControlRtcCalendar
    Implements ICloneable
    '日情報列数（３１日分）
    Public Property DbDaysColumnCount As Integer = 31
    '日情報列の前にあるYear,Monthの合計列数
    Public Property DbCalenderHeaderCount As Integer = 2

    ' ICloneable.Cloneの実装
    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function


    ''' <summary>
    ''' Timesサーバーから菱テクカレンダーデータを取得する
    ''' </summary>
    ''' <param name="table">
    ''' カレンダー情報格納テーブルオブジェクト
    ''' </param>
    ''' <returns>
    ''' True:取得成功　False:取得失敗
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetTimesServerRtcCalenderTable(ByRef table As DataTable) As Boolean
        Dim Cn As New System.Data.SqlClient.SqlConnection
        Dim sqlCommand As New System.Data.SqlClient.SqlCommand
        Dim serverName As String = "chons620"  'サーバー名(またはIPアドレス)
        Dim userID As String = "seikan" 'ユーザーID
        Dim password As String = "sie-itkn@_n" 'パスワード
        Dim databaseName As String = "times" 'データベース
        Dim sts As Boolean = False

        Dim sbConnectString As New System.Text.StringBuilder

        sbConnectString.Append("Server=" & serverName & ";")

        sbConnectString.Append("User ID=" & userID & ";")
        sbConnectString.Append("Password=" & GetTimesAnagram(password) & ";")
        sbConnectString.Append("Initial Catalog=" & databaseName)

        Cn.ConnectionString = sbConnectString.ToString
        sqlCommand.Connection = Cn

        Dim sbSql As New System.Text.StringBuilder
        'SQL文作成
        sbSql.Append("SELECT * FROM CSM0016M ")
        sbSql.Append("ORDER BY YEAR, MONTH ")

        sqlCommand.CommandText = sbSql.ToString
        Dim adapter As New System.Data.SqlClient.SqlDataAdapter
        'Dim table As New DataTable
        adapter.SelectCommand = sqlCommand
        table.Clear()

        Try
            adapter.Fill(table)
            sts = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sts = False
        Finally
            Cn.Close()
            sqlCommand.Dispose()
            Cn.Dispose()
        End Try

        Return sts
    End Function
    '接続文字列を取得する
    ''' <summary>
    ''' Timesサーバーへの接続文字列を取得する。
    ''' </summary>
    ''' <returns>
    ''' 接続文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetTimesConnectString() As String

        Dim timesConnectString As String
        Dim timesDbSever As String
        Dim timesDbName As String
        Dim timesLoginIdString As String
        Dim timesDbPassword As String

        timesDbSever = "chons620"
        timesDbName = "times"
        timesLoginIdString = "seikan"
        timesDbPassword = "sie-itkn@_n"

        '接続文字列
        timesConnectString = "Provider=Sqloledb;Data Source=" & timesDbSever _
                    & ";Initial Catalog=" & timesDbName _
                    & ";Connect Timeout=5" _
                    & ";user id=" & timesLoginIdString _
                    & ";password=" & GetTimesAnagram(timesDbPassword) _
                    & ""

        Return timesConnectString
    End Function
    ''' <summary>
    ''' パスワード用アナグラムを取得する
    ''' </summary>
    ''' <param name="sourceString">
    ''' アナグラム作成用文字列
    ''' </param>
    ''' <returns>
    ''' アナグラム文字列
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetTimesAnagram(ByVal sourceString As String) As String
        Dim anagramString As String
        Dim counter As Integer

        anagramString = ""

        For counter = 1 To Len(sourceString)
            If counter Mod 2 = 1 Then
                anagramString = anagramString & Mid(sourceString, counter, 1)
            End If
        Next

        Return anagramString

    End Function
    ''' <summary>
    ''' dayOfWeekに対応した曜日を表す文字列取得する
    ''' </summary>
    ''' <param name="dayOfWeek">
    ''' dayOfWeek数値（0～6）
    ''' </param>
    ''' <returns>
    ''' dayOfWeekに対応した曜日文字列
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetDayOfWeekString(ByVal dayOfWeek As Integer) As String
        Select Case dayOfWeek
            Case 0
                Return "日"
            Case 1
                Return "月"
            Case 2
                Return "火"
            Case 3
                Return "水"
            Case 4
                Return "木"
            Case 5
                Return "金"
            Case 6
                Return "土"
        End Select
        Return ""
    End Function
    Public Function IsHoriday(ByVal tbCaleder As DataTable, ByVal check_date As Date) As Boolean
        Dim month As Integer = check_date.Month
        Dim year As Integer = check_date.Year
        Dim day As Integer = check_date.Day

        Dim value As Integer
        For i As Integer = 0 To tbCaleder.Rows.Count - 1
            Dim cl_year As Integer = tbCaleder.Rows(i)("YEAR")
            Dim cl_month As Integer = tbCaleder.Rows(i)("MONTH")
            If (cl_year = year) And (cl_month = month) Then
                value = tbCaleder.Rows(i)(day - 1 + 2)
                Exit For
            End If
        Next
        Dim flag As Boolean
        Select Case value
            Case 0  '休日
                flag = True
            Case 1  '稼働日
                flag = False
            Case Else
                flag = False
        End Select
        Return flag
    End Function
End Class
