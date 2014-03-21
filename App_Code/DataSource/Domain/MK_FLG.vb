Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class MK_FLG
        Inherits GearsDataSource
        Public Sub New(ByVal conName As String)
            MyBase.New(conName, SqlBuilder.DS("CMN_M_HANYO"))

        End Sub

        Public Overrides Function makeSqlBuilder(ByVal data As Gears.GearsDTO) As SqlBuilder
            Dim sqlb As SqlBuilder = MyBase.makeSqlBuilder(data)
            sqlb.addSelection(SqlBuilder.S("HYMST1_KEY"))
            sqlb.addSelection(SqlBuilder.S("HYMST1_TXT"))
            sqlb.addFilter(SqlBuilder.F("HYMST_ID").eq("CM053"))

            Dim convertor As New NameExchangerTemplate
            convertor.addRule("MK_FLG", "HYMST1_KEY")
            sqlb.ItemColExchanger = convertor

            Return sqlb

        End Function
    End Class

End Namespace
