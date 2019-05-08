<%@ Page Title="" Language="C#" MasterPageFile="~/master/first.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Crossroads._default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="logincontent" runat="server">
    <div class="logintitle">Login</div>
    <div class="margin-20">
        <div class="loginInput">Username:</div>
        <div style="margin: 5px;">
            <asp:TextBox ID="txtUName" runat="server" MaxLength="50" Width="125" TextMode="SingleLine" Style="border-radius: 7px; padding: 2px 5px;"></asp:TextBox>
        </div>
        <div style="clear: both"></div>
        <div class="loginInput">Password:</div>
        <div style="margin: 5px;">
            <asp:TextBox ID="txtPWD" runat="server" MaxLength="50" Width="125" TextMode="Password" Style="border-radius: 7px; padding: 2px 5px;"></asp:TextBox>
        </div>
        <div class="loginerror">
            <asp:Label ID="loginerror" runat="server" Visible="false" />
            <asp:Label ID="hdnPassword" runat="server" Visible="false" />
        </div>
    </div>
    <div style="border-top: 2px solid black">
        <div class="loginButton" style="float: left">
            <br />
        </div>
        <div style="margin: 15px">
            <asp:Button ID="btnLogin" runat="server" Width="80" Text="Login"></asp:Button>
        </div>
    </div>
    <script>
        setTimeout("document.getElementById('<%=txtUName.ClientID%>').focus()", 1000);
    </script>
</asp:Content>