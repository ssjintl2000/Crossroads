<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="availability.aspx.cs" Inherits="Crossroads.availability" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/availability.css" rel="stylesheet" />
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
            <div class="availabilityContent padding-20">
                <div class="availabilityContentHeader">Availability Calendar</div>
                <div class="text-right">
                    <asp:HyperLink ID="lnkAvailability" CssClass="availabilityHeaderLink" runat="server" NavigateUrl="/availability-update.aspx" Text="Update Availability" />
                </div>
                <div class="padding-top-10" style="clear: both; border-top: solid 2px #555;">
                    <br />
                </div>
                <div>
                    <asp:Literal ID="ltlAvailability" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
