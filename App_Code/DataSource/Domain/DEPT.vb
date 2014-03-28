Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class DEPT
        Inherits AbsKeyValues

        Public Sub New(ByVal conName As String)
            MyBase.New(conName)
            TableId = "CM001"
        End Sub

    End Class

End Namespace
