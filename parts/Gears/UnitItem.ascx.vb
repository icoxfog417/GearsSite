Imports Gears
Imports Gears.Util
Imports System.ComponentModel

Partial Class _Gears_UnitItem
    Inherits System.Web.UI.UserControl
    Implements IFormItem

    Private _controlId As String = ""
    Public ReadOnly Property ControlId() As String Implements IFormItem.ControlId
        Get
            Return _controlId
        End Get
    End Property

    Public Property ControlKind() As String Implements IFormItem.ControlKind
    Public Property LabelText() As String Implements IFormItem.LabelText

    Private _isEditable As Boolean = True
    Public Property IsEditable() As Boolean Implements IFormItem.IsEditable
        Get
            Return _isEditable
        End Get
        Set(ByVal value As Boolean)
            _isEditable = value
            enableChange(getControl(), _isEditable)
        End Set
    End Property

    Public Property IsNeedAll() As Boolean = false

    Public Property AllText() As String= "(すべて)"

    Public Property IsReload() As Boolean= False

    Private _width As Integer = -1
    Public Property Width() As Integer Implements IFormItem.Width
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property

    Private _height As Integer = -1
    Public Property Height() As Integer Implements IFormItem.Height
        Get
            Return _height
        End Get
        Set(ByVal value As Integer)
            _height = value
        End Set
    End Property

    Public Property CssClass() As String Implements IFormItem.CssClass

    Public Property SearchAction() As String

    Private _defaultCheckIndex As Integer = -1
    Public Property DefaultCheckIndex() As String
        Get
            Return _defaultCheckIndex
        End Get
        Set(ByVal value As String)
            _defaultCheckIndex = value
        End Set
    End Property

    Public Property IsHorizontal() As Boolean = false

    Public Property ConnectionName As String Implements IFormItem.ConnectionName
    Public Property DsNamespace As String Implements IFormItem.DsNamespace

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If _ControlKind <> "" Then
            Dim kind As String = ControlKind.ToUpper
            Dim mainPart As String = Me.ID

            If ClientIDMode = UI.ClientIDMode.AutoID Then
                '意図して設定したIDを先頭に持ってくる
                mainPart = Me.ID + "__" + Me.ClientID.Replace("_" + Me.ID, "")
            End If

            _controlId = ControlKind.ToLower + mainPart

            Select Case kind
                Case "TXT"
                    Dim con As New TextBox()
                    setDefaultState(ControlId, con)
                    pnlCtlFolder.Controls.Add(con)

                Case "TXTA"
                    Dim con As New TextBox()
                    con.TextMode = TextBoxMode.MultiLine
                    _controlId = "txt" + Me.ID
                    setDefaultState(ControlId, con)
                    pnlCtlFolder.Controls.Add(con)

                Case "DDL"
                    Dim con As New DropDownList()
                    setDefaultState(ControlId, con)
                    pnlCtlFolder.Controls.Add(con)
                    setAllSelect(con)

                Case "RBL"
                    Dim con As New RadioButtonList()
                    setDefaultState(ControlId, con)
                    con.RepeatDirection = RepeatDirection.Horizontal
                    pnlCtlFolder.Controls.Add(con)
                    setAllSelect(con)

                Case "CBL"
                    Dim con As New CheckBoxList()
                    setDefaultState(ControlId, con)
                    con.RepeatDirection = RepeatDirection.Horizontal
                    pnlCtlFolder.Controls.Add(con)
                    setAllSelect(con)

                Case "CHB"
                    Dim con As New CheckBox()
                    setDefaultState(ControlId, con)
                    pnlCtlFolder.Controls.Add(con)

                Case "LBL"
                    Dim con As New Label()
                    setDefaultState(ControlId, con)
                    pnlCtlFolder.Controls.Add(con)
            End Select

        End If

        labelItem.ID = labelItem.ID + Me.ID
        labelItem.AssociatedControlID = ControlId

    End Sub

    Protected Function TableStyle() As String
        Dim classes As New List(Of String)
        Dim style As String = ""
        Dim result As String = ""

        classes.Add("gs-layout-frame")
        If Not String.IsNullOrEmpty(_cssClass) And String.IsNullOrEmpty(_controlKind) Then classes.Add(_cssClass)
        If IsHorizontal Then
            classes.Add("gs-frame-horizon")
        End If

        If Not IsHorizontal Then
            If _width > 0 Then style += "width:" + (_width + 25).ToString + "px;" '完全に合わせてしまうと狭くなるので、少し調整
            If _height > 0 Then style += "height:" + (_height + 5).ToString + "px;"
        End If

        If classes.Count > 0 Then result += "class=""" + String.Join(" ", classes) + """"
        If Not String.IsNullOrEmpty(style) Then result += " style=""" + style + """"

        Return result

    End Function

    Public Shared Function closing() As String
        Return "</td></tr></table>"

    End Function

    Public Function getControl() As WebControl Implements IFormItem.getControl
        Return pnlCtlFolder.FindControl(ControlId)
    End Function
    Public Function getControl(Of T As WebControl)() As T
        Return CType(pnlCtlFolder.FindControl(ControlId), T)
    End Function
    Public Sub setValue(ByVal value As String) Implements IFormItem.setValue
        Dim control As WebControl = getControl()

        If TypeOf control Is ITextControl Then
            CType(control, ITextControl).Text = value
        ElseIf TypeOf control Is ListControl Then
            CType(control, ListControl).SelectedValue = value
        ElseIf TypeOf control Is ICheckBoxControl Then
            Select Case value
                Case "1"
                    CType(control, ICheckBoxControl).Checked = True
                Case Else
                    CType(control, ICheckBoxControl).Checked = False
            End Select
        End If

    End Sub
    Public Function getValue() As String Implements IFormItem.getValue
        Dim control As WebControl = getControl()

        If TypeOf control Is ITextControl Then
            Return CType(control, ITextControl).Text
        ElseIf TypeOf control Is ListControl Then
            Return CType(control, ListControl).SelectedValue
        ElseIf TypeOf control Is ICheckBoxControl Then
            If CType(control, ICheckBoxControl).Checked Then
                Return "1"
            Else
                Return "0"
            End If
        Else
            Return ""
        End If
    End Function


    Private Sub setDefaultState(ByVal id As String, ByRef con As WebControl)
        Dim defaultCss As String = "gs-layout-ctrl"
        con.ID = id
        con.ClientIDMode = ClientIDMode.Static

        '属性設定
        If Me.Attributes.Count > 0 Then
            Dim keys As IEnumerator = Me.Attributes.Keys.GetEnumerator()
            While keys.MoveNext
                Dim key As String = CType(keys.Current, String)

                'Attributeに設定されたものと同名のプロパティが存在した場合、そちらにセットする
                Dim conDef As Type = con.GetType
                Dim conProperty As System.Reflection.PropertyInfo = conDef.GetProperty(key)
                If Not conProperty Is Nothing Then
                    If conProperty.PropertyType.IsEnum Then
                        conProperty.SetValue(con, [Enum].Parse(conProperty.PropertyType, Me.Attributes(key)), Nothing)
                    ElseIf conProperty.PropertyType = GetType(Boolean) Then
                        conProperty.SetValue(con, Boolean.Parse(Me.Attributes(key)), Nothing)
                    Else 'これ以外の型で必要なものがあれば順次追加する必要有り
                        Try '一応例外処理(ホントは例外を発生させてCast対象を明確にした方がいいが・・・)
                            conProperty.SetValue(con, Me.Attributes(key), Nothing)
                        Catch ex As Exception
                            con.Attributes.Add(key, Me.Attributes(key))
                        End Try
                    End If
                Else
                    con.Attributes.Add(key, Me.Attributes(key))
                End If

            End While
        End If

        'リロード設定
        If _isReload Then
            con.EnableViewState = False
        End If

        '読み取り専用設定
        enableChange(con, _isEditable)

        '高さ＋幅
        Dim style As String = ""
        If _width > 0 Then
            con.Width = _width
        End If
        If _height > 0 Then
            con.Height = _height
        End If

        'css
        If SearchAction <> "" Then
            defaultCss = "gs-for-search-text"
        End If

        If _cssClass <> "" Then
            con.CssClass = defaultCss + " " + _cssClass

        Else
            con.CssClass = defaultCss
        End If

        '接続文字列/名称空間
        If Not String.IsNullOrEmpty(ConnectionName) Then con.Attributes.Add("ConnectionName", ConnectionName)
        If Not String.IsNullOrEmpty(DsNamespace) Then con.Attributes.Add("DsNamespace", DsNamespace)

    End Sub

    Private Sub enableChange(ByRef control As WebControl, ByVal bool As Boolean)
        '読み取り専用設定
        If Not control Is Nothing Then
            If TypeOf control Is TextBox Then
                CType(control, TextBox).ReadOnly = Not _isEditable
            ElseIf TypeOf control Is Label Then
                '何もしない
            Else
                control.Enabled = _isEditable
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myControl As WebControl = getControl()

        'コントロールのVisibleを自身に反映
        If Not myControl Is Nothing Then
            If myControl.Visible = False Then
                Me.Visible = False
            Else
                Me.Visible = True
            End If
        End If

        If Not IsPostBack Then
            'デフォルト選択値を設定
            If _defaultCheckIndex > -1 Then
                If TypeOf myControl Is ListControl Then
                    Dim myListControl As ListControl = CType(myControl, ListControl)
                    If _defaultCheckIndex < myListControl.Items.Count Then
                        myListControl.Items(_defaultCheckIndex).Selected = True
                    End If

                ElseIf TypeOf myControl Is CheckBox Then
                    If _defaultCheckIndex = 0 Then
                        CType(myControl, CheckBox).Checked = True
                    ElseIf _defaultCheckIndex = 1 Then
                        CType(myControl, CheckBox).Checked = False
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub setAllSelect(ByRef con As ListControl)
        If _isNeedAll Then
            Dim allSelect As New ListItem(_allText, "")
            allSelect.Attributes.Add("Default", "True")
            allSelect.Attributes.Add("Position", "F")
            con.Items.Add(allSelect)
        End If

    End Sub

End Class
