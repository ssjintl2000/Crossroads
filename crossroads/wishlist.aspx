<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="Crossroads.wishlist" %>

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
        <div class="xs-col-12 margin-top-20">
            <div class="wishlistContent padding-20">
                <div class="wishlistContentHeader">Wish List</div>
                <div id="wishlistContentActions" runat="server" class="wishlistContentActions">
                    <asp:HyperLink ID="addWishListItem" runat="server" NavigateUrl="wishlistDetails.aspx" Visible="false">Add Wish List Item</asp:HyperLink>
                </div>
                <div style="clear: both; border-top: solid 2px #555;">
                    These are a few of the songs that users and congregation members have requested Crossroads perform at upcoming Sunday services.
                    <div style="padding-top: 15px;">
                        <asp:Literal ID="ltlWishList" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
