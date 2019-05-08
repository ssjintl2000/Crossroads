<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Crossroads.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headercontent" runat="server">
    <a href="main.aspx">
        <div id="maintitle" class="maintitle" runat="server"></div>
        <div id="churchname" class="tagline" runat="server"></div>
    </a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <br />
    <div class="container-fluid">
        <div class="col-xs-8 col-lg-9">
            <div class="servicecontent col-xs-12">
                <div class="col-xs-12 col-sm-6 servicecontentHeader">Service Information</div>
                <div class="col-xs-12 col-sm-6 text-right">
                    <asp:HyperLink ID="lnkPrevService" runat="server" Text="Previous Service" Visible="false"></asp:HyperLink>
                    <span id="datedivider" runat="server">&nbsp;|&nbsp;</span>
                    <asp:HyperLink ID="lnkNextService" runat="server" Text="Next Service" Visible="false"></asp:HyperLink>
                </div>
                <div style="clear: both"></div>
                <div style="background-color: rgba(0,0,0,0.15); padding: 5px; margin: 1px 0px;" class="col-xs-4 col-lg-2 text-right"><strong>Date:</strong></div>
                <div style="background-color: rgba(255,255,255,0.55); padding: 5px; margin: 1px 0px;" class="col-xs-8 col-lg-10">
                    <asp:Label ID="lblServiceDate" runat="server" />
                </div>
                <div style="clear: both"></div>
                <div style="background-color: rgba(0,0,0,0.15); padding: 5px; margin: 1px 0px;" class="col-xs-4 col-lg-2 text-right"><strong>Title:</strong></div>
                <div style="background-color: rgba(255,255,255,0.55); padding: 5px; margin: 1px 0px;" class="col-xs-8 col-lg-10">
                    <asp:Label ID="lblServiceTitle" runat="server" />
                </div>
                <div style="clear: both"></div>
                <div style="background-color: rgba(0,0,0,0.15); padding: 5px; margin: 1px 0px;" class="col-xs-4 col-lg-2 text-right"><strong>Scripture:</strong></div>
                <div style="background-color: rgba(255,255,255,0.55); padding: 5px; margin: 1px 0px;" class="col-xs-8 col-lg-10">
                    <asp:Label ID="lblServiceScripture" runat="server" />
                </div>
                <div style="clear: both"></div>

                <div id="servicenotescontainer" runat="server" visible="false">
                    <div style="background-color: rgba(0,0,0,0.15); padding: 5px; margin: 1px 0px;" class="col-xs-4 col-lg-2 text-right"><strong>Notes:</strong></div>
                    <div style="background-color: rgba(255,255,255,0.55); padding: 5px; margin: 1px 0px" class="col-xs-8 col-lg-10">
                        <asp:Label ID="lblServiceNotes" runat="server" />
                    </div>
                    <div style="clear: both"></div>
                </div>

                <div id="servicepdfcontainer" runat="server" visible="false">
                    <div style="background-color: rgba(0,0,0,0.15); padding: 5px; margin: 1px 0px;" class="col-xs-4 col-lg-2 text-right"><strong>Bulletin:</strong></div>
                    <div style="background-color: rgba(255,255,255,0.55); padding: 5px; margin: 1px 0px;" class="col-xs-8 col-lg-10">
                        <asp:HyperLink ID="lnkBulletin" runat="server" Text="Service Bulletin" />
                    </div>
                    <div style="clear: both"></div>
                </div>

                <div id="serviceactivitiescontainer" runat="server" visible="false">
                    <div style="background-color: rgba(0,0,0,0.15); padding: 5px; margin: 1px 0px;" class="col-xs-4 col-lg-2 text-right"><strong>Activities:</strong></div>
                    <div style="background-color: rgba(255,255,255,0.55); padding: 5px; margin: 1px 0px;" class="col-xs-8 col-lg-10">
                        <asp:Label ID="lblCommunion" runat="server" CssClass="label label-info" Visible="false" Text="Communion" />
                        <asp:Label ID="lblBaptism" runat="server" CssClass="label label-success" Visible="false" Text="Baptism" />
                        <asp:Label ID="lblRehearsal" runat="server" CssClass="label label-danger" Visible="false" Text="Rehearsal" />
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>
            <div class="servicesongs col-xs-12">
                <div class="col-xs-12 servicesongsHeader">Songs Information</div>
                <asp:Literal ID="ltlServiceSongs" runat="server"></asp:Literal>
                <div style="clear: both"></div>
            </div>
            <div class="servicemembers col-xs-12">
                <div class="col-xs-12 servicemembersHeader">Service Members</div>
                <div class="col-xs-12 servicemembersListing">
                    <div class="col-xs-12 col-lg-4 servicemembersVocalists">
                        <asp:Label ID="Vocalists" runat="server"><strong>Vocalists</strong></asp:Label><br />
                        <asp:Literal ID="ltlServiceVocalists" runat="server"></asp:Literal>
                        <div id="unavailablevocalistscontainer" class="unavailablevocalistscontainer" runat="server">
                            <asp:Label ID="UnavailableVocalists" runat="server"><br /><strong>Unavailable Vocalists</strong></asp:Label><br />
                            <asp:Literal ID="ltlUnavailableVocalists" runat="server"></asp:Literal>
                        </div>
                        <div class="clear: both">
                            <br />
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-4 servicemembersMusicians">
                        <br class="visible-md" />
                        <asp:Label ID="Musicians" runat="server"><strong>Musicians</strong></asp:Label><br />
                        <asp:Literal ID="ltlServiceMusicians" runat="server"></asp:Literal>
                        <div id="unavailablemusicianscontainer" class="unavailablemusicianscontainer" runat="server">
                            <asp:Label ID="UnavailableMusicians" runat="server"><br /><strong>Unavailable Musicians</strong></asp:Label><br />
                            <asp:Literal ID="ltlUnavailableMusicians" runat="server"></asp:Literal>
                        </div>
                        <div class="clear: both">
                            <br />
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-4 servicemembersTechnicians">
                        <br class="visible-md" />
                        <asp:Label ID="Technicians" runat="server"><strong>Technicians</strong></asp:Label><br />
                        <asp:Literal ID="ltlServiceTechnicians" runat="server"></asp:Literal>
                        <div id="unavailabletechnicianscontainer" class="unavailabletechnicianscontainer" runat="server">
                            <asp:Label ID="UnavailableTechnicians" runat="server"><br /><strong>UnavailableTechnicians</strong></asp:Label><br />
                            <asp:Literal ID="ltlUnavailableTechnicians" runat="server"></asp:Literal>
                        </div>
                        <div class="clear: both">
                            <br />
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                    <br />
                </div>
            </div>
        </div>
        <div class="col-xs-4 col-lg-3">
            <div class="availabilitycontent">
                <a href="availability-update.aspx">Update Availability</a>
            </div>
            <div class="membercontent">
                <div style="vertical-align: text-bottom;" class="col-xs-12 col-md-6 membersHeader">Contact Information</div>
                <div style="vertical-align: text-bottom;" class="col-xs-12 col-md-6 text-center membersMoreInfo"><em>Click contact for more info</em></div>
                <div style="margin: 5px;">
                    <asp:Literal ID="ltlMembers" runat="server"></asp:Literal>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="crossroadsimage">
                <asp:Image ID="imgLogo" runat="server" CssClass="img-responsive center-block" />
                <br />
                <br />
            </div>
        </div>
    </div>

    <script>
        function chkUser(id) {
            var userdiv = document.getElementById(id);
            if (userdiv.style.display == 'none') {
                userdiv.style.display = '';
            } else {
                userdiv.style.display = 'none';
            }
        }
    </script>
</asp:Content>
