Imports Gears
Imports DataSource

Partial Class _guide_Validation
    Inherits GearsPage

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim emp As New DataSource.EMP(Master.ConnectionName)

        GAdd(pnlEMP_SAL__GFORM, emp)
        GAdd(pnlEMPAttr, emp)

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblVResult1.Text = ""

        GRule(ddlEMPNO__KEY).Relate(pnlEMPAttr)

    End Sub

    Protected Sub btnValidation1_Click(sender As Object, e As System.EventArgs) Handles btnValidation1.Click
        Dim result As Boolean = True
        result = GIsValid(pnlValidation1)
        If Not result AndAlso GLog.Count > 0 Then
            lblVResult1.Text = GLog.FirstLog.Message
            lblVResult1.CssClass = "ppp-msg error"
        Else
            lblVResult1.Text = "バリデーションＯＫ"
            lblVResult1.CssClass = "ppp-msg success"
        End If

    End Sub

    Protected Sub ddlEMPNO_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlEMPNO__KEY.SelectedIndexChanged
        GFilterBy(ddlEMPNO__KEY)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        LogToLabel(GSave(pnlEMP_SAL__GFORM), lblMsgModelValid)
    End Sub

End Class
