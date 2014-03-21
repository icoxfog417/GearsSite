Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource

    Public Class EMP
        Inherits GearsDataSource

        Public Sub New(ByVal conName As String)
            MyBase.New(conName, SqlBuilder.DS("V_EMP"), SqlBuilder.DS("EMP"))

            '楽観ロックチェック用のカラムを定義
            setLockCheckColumn("UPD_YMD", LockType.UDATESTR)
            setLockCheckColumn("UPD_HMS", LockType.UTIMESTR)

            'モデル検証のためのバリデータをセット
            ModelValidator = New EMPValidator(conName)

        End Sub

    End Class

End Namespace
