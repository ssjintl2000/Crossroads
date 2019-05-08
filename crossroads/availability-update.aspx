<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="availability-update.aspx.cs" Inherits="Crossroads.availabilityupdate" %>

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
        <div class="availabilityUpdateContainer margin-20 padding-20">
            <div class="availabilityUpdateContent">
                <div class="availabilityUpdateHeader padding-bottom-10">Update Availability</div>
                <div id="availabilityUpdateText" class="padding-top-10 availabilityUpdateText" runat="server">
                    This is where you go to submit your availability updates. 
                    If you are listed as unavailable for a particular service it will be highlighted. 
                    If you ever want to change your availability for any upcoming service, or services, just click the checkbox(es) next to the service date, and then click the &quot;Submit Updates&quot; button. 
                    This will update the database with your availability, as well as notify all the members of Crossroads.<br />
                </div>
                <div id="availabilityUpdateListing" class="availabilityUpdateListing" runat="server">
                    <asp:Literal ID="ltlAvailabilityUpdate" runat="server"></asp:Literal>
                    <div class="availabilityUpdateButton padding-top-20 text-right">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-default" Text="Submit Update" />
                    </div>
                </div>
                <asp:Panel ID="pnlResponse" runat="server">
                    <div class="text-center margin-50">
                        <div style="font-size: 1.25em">Records Updated</div>
                        <div>The other team members have been notified</div>
                    </div>
                    <script>setTimeout("window.location.href='availability.aspx'", 3000);</script>
                </asp:Panel>
                <asp:Panel ID="pnlError" runat="server">
                    <div class="text-center margin-50 availabilityUpdateError">
                        <div class="availabilityUpdateErrorHeader margin-bottom-15">ERROR SENDING THE MESSAGE</div>
                        <div id="availabilityUpdateErrorContent" runat="server">
                            There seems to have been an error while notifying the other members of the team<br />
                            You can email <%=ConfigurationManager.AppSettings["adminName"]%> at the following email <a href="mailto:<%=ConfigurationManager.AppSettings["adminEmail"]%>"><%=ConfigurationManager.AppSettings["adminEmail"]%></a>,<br />
                            or call <%=ConfigurationManager.AppSettings["adminGender"]%> at <a href="tel:<%=ConfigurationManager.AppSettings["adminPhone"]%>"><%=ConfigurationManager.AppSettings["adminFormattedPhone"]%></a>, if you feel it's necessary.
                            <asp:Literal ID="ltlError" runat="server"></asp:Literal>
                        </div>
                        <div id="availabilityUpdateError" runat="server" style="text-align: left; clear: both">
                            <br />
                        </div>
                        <a href="/main.aspx">Click here to return to the Main Page</a>.
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
