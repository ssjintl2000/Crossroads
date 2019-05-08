<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="Crossroads.members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/members.css" rel="stylesheet" />
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
            <div class="memberContent padding-20">
                <div class="memberContentHeader">Member Listing</div>
                <div id="memberContentActions" runat="server" class="memberContentActions" visible="false">
                    <asp:HyperLink ID="addMember" runat="server" NavigateUrl="memberDetails.aspx">Add New Member</asp:HyperLink>
                </div>
                <div class="padding-top-10" style="clear: both; border-top: solid 2px #555">
                    If the member is on a row with a Green tint, this is member is considered an active member.
                    If the member is on a row with a red tint, this is member is considered an inactive member.<br />
                    <br />
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="tableHeader">Vocalists</div>
                    <asp:Literal ID="ltlVocalists" runat="server" />
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="tableHeader">Musicians</div>
                    <asp:Literal ID="ltlMusicians" runat="server" />
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="tableHeader">Technicians</div>
                    <asp:Literal ID="ltlTechnicians" runat="server" />
                </div>
                <div style="clear: both">
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
