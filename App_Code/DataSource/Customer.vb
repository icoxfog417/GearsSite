Imports Microsoft.VisualBasic

Imports Gears
Imports Gears.DataSource

Namespace DataSource

    Public Class Customer
        Inherits GearsDataSource

        Public Sub New(ByVal conName As String)
            MyBase.New(conName, "得意先マスタ")

            'マルチバイト設定
            IsMultiByte = True

            '変換ルールを設定(多いようであれば、データベース側に変換テーブルを作成し読み込むなどする)
            Mapper.addRule("CUSTOMER_ID", "顧客コード")
            Mapper.addRule("CUSTOMER_TXT", "顧客名")
            Mapper.addRule("ADDRESS", "住所")

        End Sub

    End Class

End Namespace

