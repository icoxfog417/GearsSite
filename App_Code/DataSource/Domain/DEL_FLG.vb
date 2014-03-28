Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class DEL_FLG
        Inherits AbsKeyValues

        Public Sub New(ByVal conName As String)
            MyBase.New(conName)
            TableId = "CM090"
        End Sub
    End Class

End Namespace
