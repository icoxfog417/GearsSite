Imports Microsoft.VisualBasic
Imports Gears
Imports Gears.DataSource

Namespace DataSource.Domain

    Public Class AbsKeyValues
        Inherits AbsKeyValueSource

        Public Property TableId As String

        Public Sub New(ByVal conName As String)
            MyBase.New(conName, "KEY_VALUES", "KEY1", "TEXT1")
            KeyColumn.ASC() 'デフォルトキー順にする
        End Sub

        Public Overrides Function makeSqlBuilder(ByVal data As Gears.GearsDTO) As SqlBuilder
            Dim sqlb As SqlBuilder = MyBase.makeSqlBuilder(data)

            If String.IsNullOrEmpty(TableId) Then Throw New GearsException("キー/バリュー型のデータソースにテーブルIDが設定されていません")

            sqlb.addFilter(SqlBuilder.F("TABLE_ID").eq(TableId))

            Return sqlb

        End Function

    End Class

End Namespace
