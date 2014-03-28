Imports Microsoft.VisualBasic
Imports Gears.DataSource


Namespace DataSource.Domain

    Public Class GENDER
        Inherits AbsKeyValues

        Public Sub New(ByVal conName As String)
            MyBase.New(conName)
            TableId = "CM003"
            KeyColumn.DESC() '男性/女性の順で表示
        End Sub

    End Class

End Namespace
