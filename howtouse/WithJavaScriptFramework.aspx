﻿<%@ Page Title="" Language="VB" MasterPageFile="~/gearsMaster.master" AutoEventWireup="false" CodeFile="WithJavaScriptFramework.aspx.vb" Inherits="howtouse_WithJavascriptFramework" %>
<%@ MasterType VirtualPath="~/gearsMaster.master" %>

<asp:Content ID="pageHeader" ContentPlaceHolderID="headerPart" Runat="Server">
    <title>With JavaScript Framework</title>
    <!-- JavaScript Frameworkの一例として、knockout.jsを使用します -->
    <script src="../js/knockout-3.1.0.js"></script>
    <style>
        .selected {
            background-color:whitesmoke;
        }
    </style>

</asp:Content>

<asp:Content ID="pageBody" ContentPlaceHolderID="contentBody" Runat="Server">
    <div class="page-header">
        <h1>With JavaScript Framework</h1>
    </div>
    <p >
        PostBackでなくJsonでデータの送受信をするサンプルです。このページではデモとして<a href="http://knockoutjs.com/index.html" target="_blank">knockout.js</a>を使用しています。<br/>
        RadioButtonList/CheckBoxListなど、標準のレンダリングがJavaScript/CSSフレンドリーではないものについては
        <a href="https://github.com/icoxfog417/Gears/blob/master/Gears/Code/Util/ButtonListAdapter.vb">ButtonListAdapter</a>にて出力HTMLのカスタマイズを行っています。
    </p>

    <asp:Panel ID="pnlList" runat="server" CssClass="panel panel-default col-sm-4" style="padding:7px" Height="470">
        <div class="form-inline" >
            <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" data-bind="value:searchText,valueUpdate:['input', 'afterkeydown']" placeholder="従業員検索"></asp:TextBox>
        </div>

        <div data-bind="template: { name: 'emp-template', foreach: emps }" style="margin-top:10px;">
        </div>
        
    </asp:Panel>

    <asp:Panel ID="pnlEMP__GFORM" runat="server" CssClass="panel panel-default col-sm-4  col-sm-offset-1" Height="470" DsNamespace="DataSource">
        <table class="table" data-bind="with: selectedEmp">
            <tr><td>人事ID</td><td>
                <asp:Label   ID="lblHR_ID" runat="server" data-bind="text:HR_ID" ></asp:Label>
                <asp:TextBox ID="txtHR_ID__KEY" runat="server" data-bind="value:HR_ID,visible:false" ></asp:TextBox>
            </td></tr>
            <tr><td>名前</td><td ><asp:TextBox ID="txtNAME" runat="server" data-bind="value:NAME"></asp:TextBox></td></tr>
            <tr><td>役職</td><td ><asp:DropDownList runat="server" ID="ddlRANK" data-bind="value:RANK" ></asp:DropDownList></td></tr>
            <tr><td>性別</td><td ><asp:RadioButtonList runat="server" ID="rblGENDER" data-bind-ginput="checked: GENDER" RepeatDirection="Horizontal" ></asp:RadioButtonList></td></tr>
        </table>
        <asp:UpdatePanel id="updForm" runat="server" UpdateMode=Conditional>
          <ContentTemplate>
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" />
          </ContentTemplate>
        </asp:UpdatePanel> 
    </asp:Panel>

</asp:Content>

<asp:Content ID="pageBodyScriptBlock" ContentPlaceHolderID="bodyScriptBlock" Runat="Server">
    <script>
        function EmpViewModel() {
            var self = this;
            self.searchText = ko.observable("");
            self.searchTextDelay = ko.computed(self.searchText).extend({ rateLimit: { method: "notifyWhenChangesStop", timeout: 400 } });

            self.emps = ko.observableArray([]);
            self.selectedEmp = ko.observable();

            self.searchEmp = function (val) {
                var result = [];
                var send = JSON.stringify({ text: val });

                $.ajax({
                    type: "POST",
                    url: "WithJavaScriptFramework.aspx/GetEmps",
                    data: send,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: false
                }).done(function (data) {
                    self.emps.removeAll();
                    ko.utils.arrayForEach(data.d, function (item) {
                        self.emps.push(item);
                    });
                    if (self.emps().length > 0) {
                        self.selectedEmp(self.emps()[0]);
                    }
                })

            }
            self.searchTextDelay.subscribe(self.searchEmp);

            self.selectEmp = function(){
                self.selectedEmp(this);
            }

        }

        var vm = new EmpViewModel()
        ko.applyBindings(vm);

        function pageLoad() {
            //ページのロード/更新が行われた場合、データを再取得
            var val = $("#txtSearch").val() === undefined ? "" : $("#txtSearch").val();
            vm.searchEmp(val);
        }

    </script>

    <script type="text/html" id="emp-template">
        <div style="padding-top:3px;padding-bottom:3px;border-bottom:1px solid gainsboro;width:100%" 
            data-bind="click: $parent.selectEmp, css: {selected : $parent.selectedEmp() !== undefined ? $parent.selectedEmp().HR_ID == HR_ID : false}">
            <span data-bind="text: HR_ID"></span>：
            <span data-bind="text: NAME"></span>
        </div>
    </script>


</asp:Content>

