Imports Gears
Imports Gears.DataSource

Partial Class _guide_Relation
    Inherits GearsPage

    'テスト用テーブルからデータを取得するデータソース
    Private tableName As SqlDataSource = SqlBuilder.DS("EMP")

    'Pageイベントハンドラ
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim dataSource As New GearsDataSource(Master.ConnectionName, tableName)

        'テスト３：フォーム用パネルの使用→関連に使用するコントロールを登録
        GAdd(pnlTest3__GFORM, dataSource)

        'テスト４：選択項目用パネルの使用→関連に使用するコントロールを登録
        GAdd(pnlTest4__GFILTER, dataSource)
        GAdd(grvData4, dataSource)

        'テスト５：収集した情報の確認
        GAdd(pnlTest5__1__GFILTER)
        GAdd(pnlTest5__1__GFORM)

        'ラジオボタン初期選択
        rblTest5SEX__1.SelectedIndex = 0
        rblTest5SEX__2.SelectedIndex = 0

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'コントロール初期化
        lblMsg.Text = ""

        'テスト２：関連登録
        GRule(ddlCOMP_UNIT).Relate(ddlCOMP_GRP)

        'テスト３：関連登録
        GRule(ddlEMPNO).Relate(pnlTest3__GFORM)
        GRule(rblCOMP_UNIT__3).Relate(ddlCOMP_GRP__3)

        'テスト４：関連登録
        GRule(ddlCOMP_UNIT__2).Relate(ddlCOMP_GRP__2)
        GRule(pnlTest4__GFILTER).Relate(grvData4)


    End Sub

    'テスト２
    Protected Sub ddlCOMP_UNIT_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCOMP_UNIT.SelectedIndexChanged
        '自分の関連先に変更情報を通知
        GFilterBy(ddlCOMP_UNIT)
    End Sub

    'テスト３
    Protected Sub ddlEMPNO_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlEMPNO.SelectedIndexChanged
        GFilterBy(ddlEMPNO)
    End Sub

    'テスト４
    Protected Sub ddlCOMP_UNIT__2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCOMP_UNIT__2.SelectedIndexChanged
        GFilterBy(ddlCOMP_UNIT__2)
    End Sub

    Protected Sub btnClick__4_Click(sender As Object, e As System.EventArgs) Handles btnClick__4.Click
        GFilterBy(pnlTest4__GFILTER)
    End Sub

    'テスト５
    Protected Sub btnClick__5__1_Click(sender As Object, e As System.EventArgs) Handles btnClick__5__1.Click
        lblDTO__1__1.Text = GPack(ddlEMPNO__5__1).ToString.Replace(vbCrLf, "<br/>")

        Dim dto As GearsDTO = getSQLTypeSetDTO(ddlTest5SQLType.SelectedValue)
        lblDTO__1__2.Text = GPack(ddlEMPNO__5__1, dto).ToString.Replace(vbCrLf, "<br/>")
    End Sub
    Protected Sub btnClick__5__2_Click(sender As Object, e As System.EventArgs) Handles btnClick__5__2.Click
        '不要なコントロールを登録
        GRule(pnlTest5__1__GFILTER).Except(txtTest5TEXT)

        lblDTO__2__1.Text = GPack(pnlTest5__1__GFILTER).ToString.Replace(vbCrLf, "<br/>")

        Dim dto As GearsDTO = getSQLTypeSetDTO(ddlTest5SQLType.SelectedValue)
        lblDTO__2__2.Text = GPack(pnlTest5__1__GFILTER, dto).ToString.Replace(vbCrLf, "<br/>")
    End Sub
    Protected Sub btnClick__5__3_Click(sender As Object, e As System.EventArgs) Handles btnClick__5__3.Click
        '更新時のキー項目を設定
        GGet(ddlEMPNO__5__3).asKey()

        lblDTO__3__1.Text = GPack(pnlTest5__1__GFORM).ToString.Replace(vbCrLf, "<br/>")

        Dim dto As GearsDTO = getSQLTypeSetDTO(ddlTest5SQLType.SelectedValue)
        lblDTO__3__2.Text = GPack(pnlTest5__1__GFORM, dto).ToString.Replace(vbCrLf, "<br/>")
    End Sub

    Private Function getSQLTypeSetDTO(type As String) As GearsDTO
        Dim dto As GearsDTO = New GearsDTO(ActionType.NONE)
        Select Case type
            Case "SELECT"
                dto.Action = ActionType.SEL
            Case "UPDATE"
                dto.Action = ActionType.UPD
            Case "INSERT"
                dto.Action = ActionType.INS
            Case "DELETE"
                dto.Action = ActionType.DEL
        End Select

        Return dto

    End Function

End Class
