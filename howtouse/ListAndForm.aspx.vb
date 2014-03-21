Imports Gears
Imports System.Data.Common
Imports DataSource

Partial Class _howtouse_ListAndForm
    Inherits GearsPage

    'ページ初期化イベント
    'ここで手動での登録が必要なコントロール(例：PanelやGridViewなど)の登録を行う
    '
    'ページ上のコントロールを、データソースクラスとのペアにして登録する処理はOnpreloadで実行される。
    'このため、コントロール登録前に行っておきたいような処理はPageInitに記述すること
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'ハンドラ登録
        AddHandler COMP_UNIT__FIL.getControl(Of RadioButtonList).SelectedIndexChanged, AddressOf Me.rblCOMP_UNIT_SelectedIndexChanged

        'データソースを設定
        GAdd(pnlGFORM, New EMP(Master.ConnectionName))

        '非同期更新設定
        Dim srmOnPage As ScriptManager = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Me)
        srmOnPage.RegisterAsyncPostBackControl(COMP_UNIT__FIL.getControl(Of RadioButtonList))

    End Sub


    'ページロードイベント
    'ここでは主にコントロール間の関連を登録しておく
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '変数初期化
        lblLog.Text = ""
        lblMsg.Text = ""
        hdnMode.Value = "S"

        '関連を定義
        '事業部→部門の関連登録
        GRule(COMP_UNIT__FIL.getControl).Relate(COMP_GRP__FIL)
        GRule(hdnCOMP_UNIT).Relate(COMP_GRP__FORM)

        '選択パネル→一覧
        GRule(pnlGFilter).Relate(grvEMP)

        '一覧での選択→フォーム用パネル
        GRule(grvEMP).Relate(pnlGFORM)

        If IsPostBack Then
            'ポストバック時、ログ記録を開始する。
            GearsLogStack.traceOn()
            GearsLogStack.setLog("リクエストされた処理のトレースを開始します。。。")
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            'ポストバック時、ログ記録を終了する。開始～終了までの間に実行された処理のログを出力する
            GearsLogStack.setLog("ログトレースを終了します")
            lblLog.Text = GearsLogStack.makeDisplayString 'ログの出力
            GearsLogStack.traceEnd()
        End If
    End Sub

    'コントロールイベント
    '事業部のラジオボタン選択
    Protected Sub rblCOMP_UNIT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GFilterBy(COMP_UNIT__FIL)
        udpArea.Update()
    End Sub
    '検索処理の実行
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GFilterBy(pnlGFilter)
    End Sub
    '一覧の中の行選択
    Protected Sub grvData_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvEMP.SelectedIndexChanged
        '選択行の値を使用し、データ更新を実行
        GFilterBy(grvEMP)
        hdnMode.Value = "U"

    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'フォームに入力された値でテーブルを更新
        '更新方法を、ActionType.SAVE(キーがあればUPDATE/なければINSERT)で指定
        LogToLabel(GSave(pnlGFORM), lblMsg)

        'GearsLogStack.setLog("更新後のデータを表示します")
        'GFilterBy(pnlGFilter)
        hdnMode.Value = "U"
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        LogToLabel(GDelete(pnlGFORM), lblMsg)

        'GearsLogStack.setLog("削除後のデータを表示します")
        'GFilterby(pnlGFilter)
        hdnMode.Value = "U"
    End Sub

End Class
