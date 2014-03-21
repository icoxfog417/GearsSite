Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class JOB
        Inherits GearsDataSource
        Public Sub New(ByVal conName As String)
            MyBase.New(conName, SqlBuilder.DS("EMP"))

        End Sub

        Public Overrides Function makeSqlBuilder(ByVal data As Gears.GearsDTO) As SqlBuilder
            Dim sqlb As SqlBuilder = MyBase.makeSqlBuilder(data)
            sqlb.addSelection(SqlBuilder.S("JOB").inGroup.ASC)
            sqlb.addSelection(SqlBuilder.S("JOB").asName("JOB_TXT").inGroup)

            Return sqlb

        End Function


    End Class

End Namespace
