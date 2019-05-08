<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="wishlistdetails.aspx.cs" Inherits="Crossroads.wishlistdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/wishlist.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headercontent" runat="server">
    <a href="main.aspx">
        <div id="maintitle" class="maintitle" runat="server"></div>
        <div id="churchname" class="tagline" runat="server"></div>
    </a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container-fluid">
        <div class="xs-col-12 margin-top-30">
            <div class="wishlistContent padding-20">
                <asp:Panel ID="pnlForm" runat="server" CssClass="padding-top-10">
                </asp:Panel>
                <asp:Panel ID="pnlResponse" runat="server">
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
