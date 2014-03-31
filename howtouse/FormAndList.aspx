<%@ Page Language="VB" MasterPageFile="~/gearsMaster.master" AutoEventWireup="false" CodeFile="~/howtouse/FormAndList.aspx.vb" Inherits="_howtouse_ListAndForm" %>
<%@ Register src="~/parts/Gears/UnitItem.ascx" tagname="unitItem" tagprefix="ui" %>
<%@ MasterType VirtualPath="~/gearsMaster.master" %>

<asp:Content id="clientHead" ContentPlaceHolderID="headerPart" Runat="Server" >
    <title>Form and Listk</title>
    <script type="text/javascript">
        $(function () {
            //JSVariableのAttributeをつけたプロパティは、JavaScript側で使用可能

            var formOpen = $("#pnlGFORM").hasClass("in");
            var filter   = $("#pnlGFilter").hasClass("in");

            if (gears.v.isFormPartOpen) {
                if (!formOpen) { $("#pnlGFORM").collapse("show"); }
                if (filter) { $("#pnlGFilter").collapse("hide"); }
            } else {
                if (formOpen) { $("#pnlGFORM").collapse("hide"); }
                if (!filter) { $("#pnlGFilter").collapse("show"); }
            }
            $('#pnlGFilter').on('show.bs.collapse', function () {
                $("#pnlGFORM").collapse("hide");
            })
        })
    </script>
</asp:Content>

<asp:Content id="pageBody" ContentPlaceHolderID="contentBody" Runat="Server" >
    <div class="page-header">
        <h1>Form and List</h1>
    </div>
    <p >
        一覧から選択しフォームでメンテナンスする、マスタメンテナンスなどで使用される一般的なスタイルです。
    </p>

    <asp:Panel ID="pnlFormArea" runat="server" CssClass="panel panel-default" >
        <asp:Panel ID="pnlFormTitle" runat="server" CssClass="panel-heading" data-toggle="collapse" data-target="#pnlGFORM">
            編集フォーム
        </asp:Panel>

        <asp:Panel id="pnlGFORM" runat="server" CssClass="panel-body collapse in">

            <ui:unitItem ID="HR_ID__KEY" ControlKind="TXT" runat="server" LabelText="※従業員番号" CssClass="gears-GRequired gears-GNumeric gears-GByteLength_Length_4 " IsHorizontal="True"/>
            <ui:unitItem ID="NAME" ControlKind="TXT" runat="server" LabelText="※名前" CssClass="gears-GRequired" IsHorizontal="True"/>
            <ui:unitItem ID="GENDER" ControlKind="RBL" runat="server" LabelText="性別" IsHorizontal="True" RepeatLayout="Flow"/>
            <ui:unitItem ID="HIRE_DATE" ControlKind="TXT" runat="server" LabelText="入社日" CssClass="gears-GDate_Format_yyyy-MM-dd_DoCast_True" IsHorizontal="True"/>
            <ui:unitItem ID="RANK" ControlKind="DDL" runat="server" LabelText="職位" IsHorizontal="True"/>

            <br style="clear:both"/>

            <asp:UpdatePanel id="updForm" runat="server" UpdateMode=Conditional>
              <ContentTemplate>
                <ui:unitItem ID="DEPT" ControlKind="DDL" runat="server" AutoPostBack=True LabelText="部門" />
                <ui:unitItem ID="GROUP" ControlKind="DDL" runat="server" LabelText="グループ" />
              </ContentTemplate>
            </asp:UpdatePanel>      
            <br style="clear:both"/>
            <br/>
            <ui:unitItem ID="DEL_FLG" ControlKind="CHB" runat="server" LabelText="退職フラグ" IsHorizontal="True"/>
            <br/>
            <br/>
            <asp:Button ID="btnUpdate" runat="server" Text="更新" />
            <asp:Button ID="btnDelete" runat="server" Text="削除" />
            <br/><br/>
            <asp:Label id="lblMsg" runat="server" Text="" ></asp:Label>

        </asp:Panel>

        <asp:Panel ID="pnlListTitle" runat="server" CssClass="panel-heading" data-toggle="collapse" data-target="#pnlGFilter">
            検索
        </asp:Panel>
        <asp:Panel id="pnlGFilter" runat="server" CssClass="panel-body collapse" >
            <ui:unitItem ID="NAME__FILTER" ControlKind="TXT" runat="server" LabelText="名前(部分検索)" Operator="LIKE" />
            <asp:UpdatePanel id="udpFilter" runat="server" UpdateMode=Conditional>
                <ContentTemplate>
                    <ui:unitItem ID="DEPT__FILTER" ControlKind="DDL" runat="server" LabelText="部門" IsNeedAll=True AutoPostBack=True />
                    <ui:unitItem ID="GROUP__FILTER" ControlKind="DDL" runat="server" LabelText="グループ" IsNeedAll=True />
                </ContentTemplate>
            </asp:UpdatePanel>

            <br style="clear:both"/>
            <br/>

            <asp:Button id="btnSearch" runat="server" Text=" 検索実行 " />

        </asp:Panel>

    </asp:Panel>
    
    <br/>
    <asp:Panel id="pnlListArea" runat="server"  >
            <asp:GridView id="grvEMP" runat="server" DsNamespace ="DataSource"
                AutoGenerateSelectButton=True　AutoGenerateColumns=False
                CssClass="table" SelectedRowStyle-CssClass="success" GridLines="None"
                DataKeyNames=HR_ID>
                <Columns>
                    <asp:BoundField DataField="HR_ID" HeaderText="従業員番号">
                    </asp:BoundField>
                    <asp:BoundField DataField="DEPT_TXT" HeaderText="販売組織">
                    </asp:BoundField>
                    <asp:BoundField DataField="GROUP_TXT" HeaderText="営業Ｇ">
                    </asp:BoundField>
                    <asp:BoundField DataField="NAME" HeaderText="名前" HeaderStyle-Width="150px">
                    </asp:BoundField>
                    <asp:BoundField DataField="RANK" HeaderText="職位">
                    </asp:BoundField>
                    <asp:BoundField DataField="DEL_FLG" HeaderText="退職フラグ">
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    <br/>
    <br/>

 </asp:Content>