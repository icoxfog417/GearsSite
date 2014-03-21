Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class EMPNO
        Inherits GearsDataSource
        Public Sub New(ByVal conName As String)
            MyBase.New(conName, SqlBuilder.DS("EMP"))

        End Sub

        Public Overrides Function makeSqlBuilder(ByVal data As Gears.GearsDTO) As SqlBuilder
            Dim sqlb As SqlBuilder = MyBase.makeSqlBuilder(data)
            'sqlb.addSelection(SqlBuilder.S("SAMPLE_EMPNO").inGroup().ASC)
            'sqlb.addSelection(SqlBuilder.S("MAX(ENAME)").asName("ENAME"))
            sqlb.addSelection(SqlBuilder.S("EMPNO"))
            sqlb.addSelection(SqlBuilder.S("ENAME"))

            Return sqlb

        End Function


    End Class

End Namespace
