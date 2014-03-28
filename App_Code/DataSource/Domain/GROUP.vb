Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class GROUP
        Inherits AbsKeyValues

        Public Sub New(ByVal conName As String)
            MyBase.New(conName)
            TableId = "CM002"
            Mapper.addRule("DEPT", "KEY2")
        End Sub

    End Class

End Namespace
