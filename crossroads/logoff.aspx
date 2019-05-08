<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="logoff.aspx.cs" Inherits="Crossroads.logoff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/logoff.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headercontent" runat="server">
    <a href="main.aspx">
        <div id="maintitle" class="maintitle" runat="server"></div>
        <div id="churchname" class="tagline" runat="server"></div>
    </a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="logincontent" runat="server">
    <div class="logoffContent">
        Please wait while we<br />
        log you off the system
    </div>
    <script>
        setTimeout("window.location.href='default.aspx'", 2500);
    </script>
</asp:Content>
