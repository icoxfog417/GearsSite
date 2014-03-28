﻿<%@ Page Language="VB"  MasterPageFile="~/gearsMaster.master" AutoEventWireup="false" CodeFile="Log.aspx.vb" Inherits="_guide_Log" %>
<%@ Register src="~/parts/Gears/UnitItem.ascx" tagname="unitItem" tagprefix="ui" %>
<%@ MasterType VirtualPath="~/gearsMaster.master" %>

<asp:Content id="clientHead" ContentPlaceHolderID="headerPart" Runat="Server" ClientIDMode=Static>
    <title>Logging And Exception handling on GearsFramework</title>

</asp:Content>

<asp:Content id="clientPageTitle" ContentPlaceHolderID="pppPageTitle" Runat="Server" ClientIDMode=Static>
    GFWのログ/例外処理機能
</asp:Content>

<asp:Content id="clientOptionMenu" ContentPlaceHolderID="pppOptionMenu" Runat="Server" ClientIDMode=Static>
            <ul class="ppp-menu-links">
                <li class="ppp-menu-links"><a href="default.aspx" class="ppp-link-item">Gearsトップ</a></li>
            </ul>
</asp:Content>

<asp:Content id="clientCenter" ContentPlaceHolderID="contentBody" Runat="Server" ClientIDMode=Static>
<div class="document-body">

<i>GFW</i>の中では様々な処理が行われています。<br/>
この際、フレームワーク内でどのような処理が行われたのか、ログを出力することで確認できます。
具体的には、以下のコマンドでトレースを行います。<br/>
<br/>
・ログ取得の開始
<div class="ppp-indent">
    <b><i>GearsLogStack.traceOn()</i></b>
</div>

・ログへの書き込み
<div class="ppp-indent">
    <b><i>GearsLogStack.setLog(文字列・例外などをセット可能)</i></b>
</div>

・ログ取得の終了
<div class="ppp-indent">
    <b><i>GearsLogStack.traceEnd()</i></b>
</div>
<br/>
※ログ取得を終了するとトレース内容はクリアされるため、トレースを終了する前にLabel等のコントロールに書き込んでおく必要があります。<br/>
(GearsLogStack.makeDisplayStringを使用するとテーブル形式に加工されて表示されます)<br/>
<br/>
<br/>
実際にトレースを行うと以下のように表示されます。表示されるテーブルの書式はcssで設定されているため、カスタマイズすることも可能です。<br/>
<br/>
<div class="ppp-indent" style="width:800px">
    <div class="ppp-box even">
    <b>ログの参照</b>
        <asp:UpdatePanel id="udpLTest1" runat="server" UpdateMode=Conditional>
            <ContentTemplate>
                <asp:Panel ID="pnlGFILTER__L1" runat="server">                
                    <ui:unitItem ID="COMP_UNIT__L1" ControlKind="DDL" runat="server" LabelText="販売組織" />
                    <ui:unitItem ID="ENAME__L1" ControlKind="TXT" runat="server" LabelText="名前" Operator="LIKE" />
		            <br style="clear:both"/>

                    <asp:Button ID="btnClick__L1" runat="server" Text="検索実行(トレース実行)" />
                </asp:Panel>
                <br/>
                <asp:GridView id="grvData__L1" runat="server" 
                    AutoGenerateDeleteButton=False 
                    AutoGenerateEditButton=False 
                    AutoGenerateSelectButton=False
                    AutoGenerateColumns=False
                    CssClass=ppp-table 
                    HeaderStyle-CssClass=ppp-table-head EnableViewState=True RowStyle-CssClass=ppp-table-odd AlternatingRowStyle-CssClass=ppp-table-even>
                    <Columns>
                        <asp:BoundField DataField="COMP_UNIT" HeaderText="組織1">
                        </asp:BoundField>
                        <asp:BoundField DataField="COMP_GRP" HeaderText="組織2">
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPNO" HeaderText="従業員番号">
                        </asp:BoundField>
                        <asp:BoundField DataField="ENAME" HeaderText="名前" HeaderStyle-Width="150px">
                        </asp:BoundField>
                        <asp:BoundField DataField="JOB" HeaderText="職位">
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <br/>
                <br/>
                <asp:Label id="lblLog" runat="server" Text="" CssClass="ppp-msg"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClick__L1" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>

</div>
</asp:Content>

