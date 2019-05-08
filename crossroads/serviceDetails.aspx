<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="serviceDetails.aspx.cs" Inherits="Crossroads.serviceDetails" %>

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
            <div class="serviceContent">
                <asp:Panel ID="pnlForm" runat="server">
                    <asp:HiddenField ID="hdnAction" runat="server" Value="" />
                    <div class="col-sm-12 col-md-6">
                        <div class="col-sm-12 serviceContentHeader padding-top-10 margin-bottom-20">
                            Service Details<hr />
                        </div>
                        <div class="col-sm-3 col-md-5 col-lg-2 text-right">
                            <asp:Label ID="lblDate" runat="server">Service Date/Time:</asp:Label>
                        </div>
                        <div class="col-sm-9 col-md-7 col-lg-10">
                            <asp:TextBox ID="svcDate" runat="server" MaxLength="10" TextMode="Date" ToolTip="Enter the date of this service" />
                            <asp:TextBox ID="svcTime" runat="server" MaxLength="10" TextMode="Time" ToolTip="Enter the time of this service" />
                        </div>
                        <div class="col-sm-3 col-md-5 col-lg-2 text-right">
                            <asp:Label ID="lblTitle" runat="server">Service Title:</asp:Label>
                        </div>
                        <div class="col-sm-9 col-md-7 col-lg-10">
                            <asp:TextBox ID="svcTitle" runat="server" MaxLength="100" TextMode="SingleLine" Style="width: 100%" ToolTip="Enter the scripture title related to this service" />
                        </div>
                        <div class="col-sm-3 col-md-5 col-lg-2 text-right">
                            <asp:Label ID="lblScripture" runat="server">Scripture Reading:</asp:Label>
                        </div>
                        <div class="col-sm-9 col-md-7 col-lg-10">
                            <asp:TextBox ID="svcScripture" runat="server" MaxLength="100" TextMode="SingleLine" Style="width: 100%" ToolTip="Enter the scripture verse related to this service" />
                        </div>
                        <div class="col-sm-3 col-md-5 col-lg-2 text-right">
                            <asp:Label ID="lblNotes" runat="server">Service Notes:</asp:Label>
                        </div>
                        <div class="col-sm-9 col-md-7 col-lg-10">
                            <asp:TextBox ID="svcNotes" runat="server" MaxLength="1000" Rows="3" TextMode="MultiLine" Style="width: 100%" ToolTip="Enter any service notes for this service" />
                        </div>
                        <div class="col-sm-3 col-md-5 col-lg-2 text-right">
                            <asp:Label ID="lblBulletin" runat="server">Service Bulletin:</asp:Label>
                        </div>
                        <div class="col-sm-9 col-md-7 col-lg-10">
                            <asp:FileUpload ID="fileBulletin" runat="server" AllowMultiple="false" Style="width: 100%" ToolTip="This is where you upload the bulletin for this service" />
                        </div>
                        <div class="col-sm-3 col-md-5 col-lg-2 text-right">
                            <asp:Label ID="lblActivities" runat="server">Service Activities:</asp:Label>
                        </div>
                        <div class="col-sm-9 col-md-7 col-lg-10 serviceServices">
                            <div class="col-sm-4">
                                <asp:Label ID="lblBaptism" runat="server">Baptism:&nbsp;</asp:Label>
                                <asp:RadioButton ID="radYBaptism" runat="server" GroupName="Baptism" Text="&nbsp;Yes" TextAlign="Right" />&nbsp;&nbsp;
                                <asp:RadioButton ID="radNBaptism" runat="server" GroupName="Baptism" Text="&nbsp;No" Checked TextAlign="Right" />
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblCommunion" runat="server">Communion:&nbsp;</asp:Label>
                                <asp:RadioButton ID="radYCommunion" runat="server" GroupName="Communion" Text="&nbsp;Yes" Checked TextAlign="Right" />&nbsp;&nbsp;
                                <asp:RadioButton ID="radNCommunion" runat="server" GroupName="Communion" Text="&nbsp;No" TextAlign="Right" />
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblRehearsal" runat="server">Rehearsal:&nbsp;</asp:Label>
                                <asp:RadioButton ID="radYRehearsal" runat="server" GroupName="Rehearsal" Text="&nbsp;Yes" TextAlign="Right" />&nbsp;&nbsp;
                                <asp:RadioButton ID="radNRehearsal" runat="server" GroupName="Rehearsal" Text="&nbsp;No" Checked TextAlign="Right" />
                            </div>
                        </div>

                        <div class="col-sm-12 serviceContentHeader padding-top-10 margin-bottom-20 margin-top-20">
                            Service Songs<hr />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongOne" Width="45%" runat="server" />
                            <asp:FileUpload ID="songOne" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongOnePosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongOneLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongTwo" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongTwo" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongTwoPosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongTwoLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongThree" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongThree" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongThreePosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongThreeLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongFour" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongFour" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongFourPosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongFourLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongFive" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongFive" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongFivePosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongFiveLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongSix" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongSix" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongSixPosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongSixLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongSeven" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongSeven" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongSevenPosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongSevenLead" Width="23%" runat="server" />
                        </div>
                        <div class="col-sm-12 serviceSong">
                            Song:&nbsp;
                            <asp:DropDownList ID="ddlSongEight" Width="45%" runat="server" />
                            <asp:FileUpload ID="SongEight" runat="server" Width="45%" AllowMultiple="false" Visible="false" />
                            <asp:DropDownList ID="ddlSongEightPosition" Width="25%" runat="server" />
                            <asp:DropDownList ID="ddlSongEightLead" Width="23%" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <div class="col-sm-12 serviceContentHeader padding-top-10 margin-bottom-20">
                            Service Vocalist<hr />
                        </div>
                        <div class="col-sm-12">
                            <asp:CheckBoxList ID="chkVocalists" runat="server" RepeatColumns="2" RepeatDirection="Vertical" CssClass="serviceVocalists col-xs-6">
                            </asp:CheckBoxList>
                        </div>
                        <div class="col-sm-12 serviceContentHeader padding-top-10 margin-bottom-20">
                            Service Musicians<hr />
                        </div>
                        <div class="col-sm-12">
                            <asp:CheckBoxList ID="chkMusicians" runat="server" RepeatColumns="2" RepeatDirection="Vertical" CssClass="serviceMusicians col-xs-6">
                            </asp:CheckBoxList>
                        </div>
                        <div class="col-sm-12 serviceContentHeader padding-top-10 margin-bottom-20 margin-top-20">
                            Service Technicians<hr />
                        </div>
                        <div class="col-sm-12">
                            <asp:CheckBoxList ID="chkTechnicians" runat="server" RepeatColumns="2" RepeatDirection="Vertical" CssClass="serviceTechnicians col-xs-6">
                            </asp:CheckBoxList>
                        </div>
                        <div class="col-xs-12">
                            <hr />
                            <div class="col-xs-10">
                                <asp:Button ID="btnReset" runat="server" CssClass="col-xs-2 btn btn-danger margin-10" OnClientClick="return resetForm()" Text="Reset" />
                                <asp:Button ID="btnSave" runat="server" CssClass="col-xs-2 btn btn-primary margin-10" OnClientClick="return validateForm()" Text="Save" />
                            </div>
                            <div class="col-xs-2">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="col-xs-12 btn btn-success margin-10" OnClientClick="return submitForm()" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div style="clear: both">
                    <br />
                </div>
                <asp:Panel ID="pnlResponse" runat="server" Visible="false">
                    <div class="text-center margin-25 response">
                        <asp:Label ID="lblResponse" runat="server"></asp:Label>
                    </div>
                    <div id="pnlRedirect" runat="server" style="margin: 10px 50px">
                        <a href="services.aspx">Return to Services</a>
                        <%--<script>setTimeout("window.location.href='services.aspx'", 3500);</script>--%>
                        <br />
                        <br />
                    </div>
                </asp:Panel>
            </div>
        </div>
        <br />
    </div>

    <script>
        function submitForm() {
            document.getElementById('<%=hdnAction.ClientID%>').value = 'submit';
            return true;
        }

        function validateForm() {
            document.getElementById('<%=hdnAction.ClientID%>').value = '';
            return true;
        }

        function resetForm() {
            document.getElementById('<%=hdnAction.ClientID%>').value = '';

            document.getElementById('<%=svcDate.ClientID%>').value = '';
            document.getElementById('<%=svcTime.ClientID%>').value = '';
            document.getElementById('<%=svcTitle.ClientID%>').value = '';
            document.getElementById('<%=svcScripture.ClientID%>').value = '';
            document.getElementById('<%=svcNotes.ClientID%>').value = '';
            document.getElementById('<%=fileBulletin.ClientID%>').value = '';

            document.getElementById('<%=radYBaptism.ClientID%>').checked = false;
            document.getElementById('<%=radNBaptism.ClientID%>').checked = true;

            document.getElementById('<%=radYCommunion.ClientID%>').checked = true;
            document.getElementById('<%=radNCommunion.ClientID%>').checked = false;

            document.getElementById('<%=radYRehearsal.ClientID%>').checked = false;
            document.getElementById('<%=radNRehearsal.ClientID%>').checked = true;

            document.getElementById('<%=ddlSongOne.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongOnePosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongOneLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongTwo.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongTwoPosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongTwoLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongThree.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongThreePosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongThreeLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongFour.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongFourPosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongFourLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongFive.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongFivePosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongFiveLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongSix.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongSixPosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongSixLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongSeven.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongSevenPosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongSevenLead.ClientID%>').selectedIndex = 1;

            document.getElementById('<%=ddlSongEight.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSongEightPosition.ClientID%>').selectedIndex = 1;
            document.getElementById('<%=ddlSongEightLead.ClientID%>').selectedIndex = 1;

            var chkVocalist = document.getElementById('<%=chkVocalists.ClientID%>');
            var checkboxes = chkVocalist.getElementsByTagName('input');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = false;
            }

            var chkMusicians = document.getElementById('<%=chkMusicians.ClientID%>');
            checkboxes = chkMusicians.getElementsByTagName('input');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = false;
            }

            var chkTechniciains = document.getElementById('<%=chkTechnicians.ClientID%>');
            checkboxes = chkTechniciains.getElementsByTagName('input');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = false;
            }

            return false;
        }
    </script>
</asp:Content>
