
Partial Class gearsMaster
    Inherits System.Web.UI.MasterPage

    Private _connectionName As String = "DefaultConnection"
    ''' <summary>
    ''' Gears用デフォルト接続文字列<br/>
    ''' defaultConnection="Master.ConnectionName"の設定をしておくと参照される
    ''' </summary>
    Public Property ConnectionName() As String
        Get
            Return _connectionName
        End Get
        Set(ByVal value As String)
            _connectionName = value
        End Set
    End Property

    Private _dsNamespace As String = "DataSource.Domain"
    ''' <summary>
    ''' Gears用デフォルトデータソースクラスの名称空間<br/>
    ''' defaultNamespace="Master.DsNamespace"の設定をしておくと参照される
    ''' </summary>
    Public Property DsNamespace() As String
        Get
            Return _dsNamespace
        End Get
        Set(ByVal value As String)
            _dsNamespace = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        headMaster.DataBind()

    End Sub

End Class

