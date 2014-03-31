<%@ Page Title="" Language="VB" MasterPageFile="~/gearsMaster.master" AutoEventWireup="false" CodeFile="MultibyteTableName.aspx.vb" Inherits="howtouse_MultibyteTableName" %>
<%@ Register src="~/parts/Gears/UnitItem.ascx" tagname="unitItem" tagprefix="ui" %>
<%@ MasterType VirtualPath="~/gearsMaster.master" %>

<asp:Content ID="pageHeader" ContentPlaceHolderID="headerPart" Runat="Server">
    <title>Multibyte Table Name</title>
</asp:Content>

<asp:Content ID="pageBody" ContentPlaceHolderID="contentBody" Runat="Server">
    <div class="page-header">
        <h1>Multibyte Table Name</h1>
    </div>
    <p >
        日本語のテーブルやカラム名などをラップして使用する例です。データソースとしてはObjectDataSourceを使用しています。
    </p>

    <asp:Panel runat="server" CssClass="panel panel-default" >
        <div class="panel-heading">
           得意先検索
        </div>
        <asp:Panel id="pnlGFilter" runat="server" CssClass="panel-body" >
            <ui:unitItem ID="CUSTOMER_TXT" ControlKind="TXT" runat="server" LabelText="顧客名(部分検索)" Operator="LIKE" />
            <br style="clear:both"/>
            <br/>

            <asp:Button id="btnSearch" runat="server" Text=" 検索実行 " />
        </asp:Panel>
    </asp:Panel>

    <asp:GridView id="grvCustomer" runat="server" DsNamespace ="DataSource" AutoGenerateColumns="False" DataSourceID="odsData"
        CssClass="table" GridLines="None" DataKeyNames=CUSTOMER_ID>
        <Columns>
            <asp:BoundField DataField="CUSTOMER_ID" HeaderText="顧客ID">
            </asp:BoundField>
            <asp:BoundField DataField="CUSTOMER_TXT" HeaderText="顧客名">
            </asp:BoundField>
            <asp:BoundField DataField="ADDRESS" HeaderText="住所">
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource id="odsData" runat="server" SelectMethod="gSelectPageBy" SelectCountMethod="gSelectCount" typename="DataSource.Customer" EnablePaging=True >
    </asp:ObjectDataSource>

</asp:Content>


