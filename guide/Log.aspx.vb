Imports Gears
Imports DataSource

Partial Class _guide_Log
    Inherits GearsPage

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        'データソースの作成
        Dim dataSource As New EMP(Master.ConnectionName)

        'コントロール/データソースのペアの登録
        GAdd(grvData__L1, dataSource)
        GAdd(pnlGFILTER__L1)

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblLog.Text = ""

        '関連の定義
        GRule(pnlGFILTER__L1).Relate(grvData__L1)

    End Sub

    Protected Sub btnClick__L1_Click(sender As Object, e As System.EventArgs) Handles btnClick__L1.Click
        'トレースの開始
        GearsLogStack.traceOn()

        GearsLogStack.setLog("ログトレースを開始します", "ボタンクリック処理を追跡します・・・")
        '本処理
        GFilterBy(pnlGFILTER__L1)

        'トレースの終了
        lblLog.Text = GearsLogStack.makeDisplayString 'ログの書き込み
        GearsLogStack.traceEnd()

    End Sub
End Class
