Imports System.Data
Imports DataSource
Imports Gears
Imports Gears.DataSource
Imports Gears.Util
Imports System.Web.Services

Partial Class howtouse_WithJavascriptFramework
    Inherits GearsPage

    Private Shared ConnectionName As String = "DefaultConnection"

    <WebMethod(EnableSession:=False)>
    Public Shared Function GetEmps(ByVal text As String) As List(Of Dictionary(Of String, Object))

        Dim likeText As String = "%" + text + "%"
        Dim result As DataTable = New EMP(ConnectionName).gSelect() _
                                 .Where(SqlFilterGroup.Ors(SqlBuilder.F("HR_ID").likes(likeText), SqlBuilder.F("NAME").likes(likeText)))

        Return result.ToListOfDictionary

    End Function

End Class
