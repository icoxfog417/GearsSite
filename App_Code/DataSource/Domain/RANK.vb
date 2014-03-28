Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class RANK
        Inherits GearsDataSource

        Public Sub New(ByVal conName As String)
            MyBase.New(conName, SqlBuilder.DS("EMP"))
        End Sub

        Public Overrides Function makeSqlBuilder(ByVal data As GearsDTO) As SqlBuilder
            Dim sqlb As SqlBuilder = MyBase.makeSqlBuilder(data)
            sqlb.addSelection(SqlBuilder.S("RANK").inGroup.ASC)
            sqlb.addSelection(SqlBuilder.S("RANK").asName("RANK_TXT").inGroup)

            Return sqlb

        End Function

    End Class

End Namespace
