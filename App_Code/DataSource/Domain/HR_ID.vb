Imports Microsoft.VisualBasic
Imports System.Data
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class HR_ID
        Inherits AbsKeyValueSource

        Public Sub New(ByVal conName As String)
            MyBase.New(conName, "EMP", "HR_ID", "NAME")
        End Sub

    End Class

End Namespace
