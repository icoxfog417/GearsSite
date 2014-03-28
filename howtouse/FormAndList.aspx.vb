Imports System.Data.Common
Imports System.Reflection
Imports Gears
Imports Gears.JS
Imports DataSource

Partial Class _howtouse_ListAndForm
    Inherits GearsPage

    ''' <summary>WebPage上で、この変数を使用する</summary>
    <JSVariable()>
    Public Property isFormPartOpen As Boolean = False

    ''' <summary>
    ''' ページ初期化処理<br/>
    ''' 自動でなく、手動で登録しておきたいコントロールがある場合はこの段階で登録をしておく
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        '手動で登録(IDをpnlEMP__GFORMとし名称から推定できるようにしておけばこの作業は不要)
        GAdd(pnlGFORM, New EMP(Master.ConnectionName))

        'イベントハンドラ登録
        AddHandler DEPT.getControl(Of DropDownList).SelectedIndexChanged, AddressOf Me.ddlDEPT_SelectedIndexChanged
        AddHandler DEPT__FILTER.getControl(Of DropDownList).SelectedIndexChanged, AddressOf Me.ddlDEPT__FILTER_SelectedIndexChanged

        '非同期更新設定
        Dim srmOnPage As ScriptManager = ScriptManager.GetCurrent(Me)

        srmOnPage.RegisterAsyncPostBackControl(DEPT.getControl(Of DropDownList))
        srmOnPage.RegisterAsyncPostBackControl(DEPT__FILTER.getControl(Of DropDownList))

    End Sub


    ''' <summary>
    ''' ページロード処理<br/>
    ''' コントロール間の関連などを提起する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'メッセージを初期化
        lblMsg.Text = ""
        isFormPartOpen = False

        '部門→グループの関連登録
        GRule(DEPT).Relate(GROUP)
        GRule(DEPT__FILTER).Relate(GROUP__FILTER)

        '選択パネル→一覧
        GRule(pnlGFilter).Relate(grvEMP)

        '一覧での選択→フォーム用パネル
        GRule(grvEMP).Relate(pnlGFORM)

        If Not IsPostBack Then
            '初回のフィルタ
            GFilterBy(DEPT)
        End If

    End Sub

    Protected Sub ddlDEPT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GFilterBy(DEPT) '部門でフィルタをかける
        updForm.Update()
    End Sub

    Protected Sub ddlDEPT__FILTER_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GFilterBy(DEPT__FILTER)
        udpFilter.Update()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GFilterBy(pnlGFilter) '検索パネルに入力された値で検索
    End Sub

    Protected Sub grvEMP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvEMP.SelectedIndexChanged
        GFilterBy(grvEMP) '選択された行をフォームに反映
        isFormPartOpen = True
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        LogToLabel(GSave(pnlGFORM), lblMsg)
        GFilterBy(pnlGFilter) '一覧を更新
        isFormPartOpen = True
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        LogToLabel(GDelete(pnlGFORM), lblMsg)
        GFilterBy(pnlGFilter) '一覧を更新
        isFormPartOpen = True
    End Sub

End Class
