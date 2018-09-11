Module DefineAnalysisEnum
    Public Enum AnalisysStatus
        Ok = 0

        ''' <summary>
        ''' AnalisysSetting.Csv読込エラー
        ''' </summary>
        ErrReadSettingCsv = 100
        ''' <summary>
        ''' AnalisysSetting.Csv書き込みエラー
        ''' </summary>
        ErrWriteSettingCsv = 101

        ''' <summary>
        ''' 
        ''' </summary>
        ErrInvalidSettinCsvFile = 102

        ''' <summary>
        ''' AnalisysSetting.Csvに記載されたSystemDataPathが存在しない。
        ''' </summary>
        ErrNoExistNaviSytemDataPath = 103

    End Enum
    ''' <summary>
    ''' 
    ''' </summary>
    Public Enum TallyDataFomMode
        ''' <summary>
        ''' 計画実績集計モード
        ''' </summary>
        PlanActual
        ''' <summary>
        ''' 作業時間集計モード
        ''' </summary>
        WorkTime
    End Enum
End Module
