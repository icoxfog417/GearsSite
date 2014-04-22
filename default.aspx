<%@ Page Language="VB" MasterPageFile="~/gearsMaster.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_400_kakaku_menu" %>

<asp:Content id="pageHead" ContentPlaceHolderID="headerPart" Runat="Server" >
    <title>Gears Framework</title>
    <style>
        .top-header {
            padding-top: 20px;
            padding-bottom: 20px;
        }
        .top-title {
            margin-bottom: 0;
            font-size: 60px;
            font-weight: normal;
        }
        .top-description {
            font-size: 20px;
            color: #999;
        }
        .description {
        }
        .news {
            margin-bottom: 60px;
        }
        .news-title {
            margin-bottom: 5px;
            font-size: 40px;
        }
        .news-info {
            margin-bottom: 20px;
            color: #999;
        }
    </style>
</asp:Content>

<asp:Content id="pageBody" ContentPlaceHolderID="contentBody" Runat="Server" >
  <div class="top-header">
    <h1 class="top-title">Gears Framework</h1>
    <p class="lead top-description">ASP.NET WebForm Framework for Developing Business System Quickly.</p>
    <div class="description">
        Gears Frameworkは、<a target="_blank" href="http://www.asp.net/web-forms">ASP.NET WebForm</a>で、業務システムを素早く開発するためのフレームワークです。<br/>
        本フレームワークの特徴は、以下の通りです。<br/>
        <ul>
            <li>ASP.NET WebFormの「コントロールを配置して開発する」という特色をつきつめ、簡易かつ素早い開発が可能になっています。
                <ul>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/1.GearsConvention">規約に基づくデータバインド</a></li>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/2.Relation">関連定義によるデータ連動</a></li>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/3.DatabaseAccess">コントロールを使用したデータベース処理</a></li>
                </ul>
            </li>
            <li>業務システム開発での利用を考慮し、よく利用される汎用機能、また既存データベース上に構築するための機能を実装しています。
                <ul>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/4.Validation">バリデーション実装</a></li>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/5.Authorization">権限制御</a></li>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/MultiByte-Table-Name">日本語名テーブル対応</a></li>
                </ul>
            </li>
            <li>Ajax/JavaScript Frameworkを利用した開発をサポートするための機能を実装しています。
                <ul>
                    <li><a target="_blank" href="https://github.com/icoxfog417/Gears/wiki/6.JavaScriptCollaboration">JavaScript連携のための機能</a></li>
                </ul>
            </li>
        </ul>
    </div>
  </div>
   <hr/>
  <div class="row">

    <div class="col-sm-8">
      <div class="news">
        <h2 class="news-title">Gears 2.0 Release</h2>
        <p class="news-info">2014/3/31 by <a target="_blank" href="https://github.com/icoxfog417" >icoxfog417</a></p>
        <p>
            Gears Framework 2.0 をリリースしました。<br/>
            大幅な書き直しを行っており、1.0と互換性がありません。Sampleなどは2.0ベースですべて書き直しを行っています。<br/>
            (ベースとなるJavaScript/CSSも、jQuery UIからBoootstrapへ切り替えています)。<br/><br/>
            1.0を参照したい場合は、tagから参照可能です。<br/>
            <a target="_blank" href="https://github.com/icoxfog417/Gears/tree/1.0">Gears 1.0</a><br/>
            <a target="_blank" href="https://github.com/icoxfog417/GearsSite/tree/1.0" >Gears 1.0 Demo site</a><br/>
        </p>
      </div>
      <div class="news">
        <h2 class="news-title">Gears 1.0 Release</h2>
        <p class="news-info">2014/3/7 by <a target="_blank" href="https://github.com/icoxfog417" >icoxfog417</a></p>
        <p>
            Gears Framework 1.0をリリースしました。
        </p>
      </div>

    </div><!-- /.blog-main -->

    <div class="col-sm-3 col-sm-offset-1 page-sidemenu">
      <div class="sidebar-module">
        <h4>Samples</h4>
            <ol class="list-unstyled">
              <li><a target="_blank" href="./howtouse/FormAndList.aspx">Form and List</a></li>
              <li><a target="_blank" href="./howtouse/MultibyteTableName.aspx">Multibyte Table Name</a></li>
              <li><a target="_blank" href="./howtouse/WithJavaScriptFramework.aspx">With JavaScript Framework</a></li>
              <li><div style="width:100px;border-bottom:1px solid silver;padding-top:5px;margin-bottom:5px"></div></li>
              <li><a target="_blank" href="https://github.com/icoxfog417/GearsSite/tree/master/howtouse">Source Code</a></li>
            </ol>
      </div>
      <div class="sidebar-module">
        <h4>Documents</h4>
            <ol class="list-unstyled">
              <li><a target="_blank" href="./document/Help/Index.aspx">API Document</a></li>
              <li><a target="_blank" href="https://github.com/icoxfog417/Gears/tree/develop">GitHub</a></li>
            </ol>
      </div>
    </div>
  </div>
</asp:Content>
