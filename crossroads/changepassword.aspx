<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Crossroads.changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/changepassword.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headercontent" runat="server">
    <a href="main.aspx">
        <div id="maintitle" class="maintitle" runat="server"></div>
        <div id="churchname" class="tagline" runat="server"></div>
    </a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="logincontent" runat="server">
    <div class="cpTitle">Change Password</div>
    <div id="frmInput" runat="server" style="margin: 20px">
        <div class="cpUser">
            <asp:Label ID="lblUName" runat="server" Style="vertical-align: text-bottom"></asp:Label></div>
        <div style="clear: both"></div>
        <div class="cpInput">Current Password:&nbsp;</div>
        <div>
            <asp:TextBox ID="txtCPWD" runat="server" MaxLength="20" Width="125" TextMode="Password"></asp:TextBox></div>
        <div style="clear: both"></div>
        <div class="cpInput">New Password:&nbsp;</div>
        <div>
            <asp:TextBox ID="txtNPWD" runat="server" MaxLength="20" Width="125" TextMode="Password"></asp:TextBox></div>
        <div class="cpError">
            <asp:Label ID="cpError" runat="server" Visible="false" /></div>
    </div>
    <div id="frmButton" runat="server" style="border-top: 2px solid black">
        <div class="cpButton" style="float: left">
            <br />
        </div>
        <div style="margin: 15px">
            <asp:Button ID="btnSubmit" runat="server" Width="80" Text="Submit"></asp:Button></div>
    </div>
    <div id="pnlResponse" runat="server" style="margin: 40px 0px; text-align: center" visible="false">
        <asp:Label ID="lblResponse" runat="server"></asp:Label>
        <script>
            setTimeout("window.location.href='main.aspx'", 2500);
        </script>
    </div>
</asp:Content>
