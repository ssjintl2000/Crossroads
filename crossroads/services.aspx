<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="Crossroads.services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/services.css" rel="stylesheet" />
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
            <div class="serviceContent padding-20">
                <div class="serviceContentHeader">Service Listing</div>
                <div id="serviceContentActions" class="serviceContentActions">
                    <asp:HyperLink ID="addService" runat="server" NavigateUrl="serviceDetails.aspx" Visible="false">Add New Service</asp:HyperLink>
                </div>
                <div style="clear: both; border-top: solid 2px #555;">
                    This service listing below contains all of the upcoming services performed by the Crossroads Praise Team.
                    <div style="padding-top: 15px;">
                        <asp:Literal ID="ltlServices" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
