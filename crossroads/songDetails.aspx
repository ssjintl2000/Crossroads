<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="songDetails.aspx.cs" Inherits="Crossroads.songDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/css/songs.css" rel="stylesheet" />
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
            <div class="songContent padding-20">
                <div class="songContentHeader">Song Details</div>
                <div style="clear: both; border-top: solid 2px #555;">
                    <br />
                </div>
                <asp:Panel ID="pnlForm" runat="server">
                    <div class="col-lg-offset-4 col-lg-4 songForm">
                        <input type="hidden" name="fAction" id="fAction" value="" />
                        <div id="songFormHeader" runat="server" class="songFormHeader">
                            <asp:Label ID="lblPageTitle" runat="server" />
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="input-group-addon" style="text-align: right">&nbsp;&nbsp;&nbsp;Song Title:</div>
                                    <input type="text" class="form-control" id="inputTitle" runat="server" required>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="input-group-addon" style="text-align: right">Artist Name:</div>
                                    <input type="text" class="form-control" id="inputArtist" runat="server" required>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="input-group-addon" style="text-align: right">Song Notes:</div>
                                    <textarea rows="2" maxlength="1000" class="form-control" id="inputNotes" runat="server"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-xs-12">
                            <div class="form-group col-xs-offset-1 col-xs-10">
                                <br />
                                <div class="input-group has-warning">
                                    <div class="input-group-addon" style="width: 32%; text-align: right">Audio File:</div>
                                    <asp:FileUpload ID="inputMP3" runat="server" CssClass="form-control" />
                                    <div class="input-group-addon" style="width: 10%; text-align: center">
                                        <asp:HyperLink ID="lnkMP3" runat="server" Target="_blank" Style="margin-right: 0px">
                                            <span class="glyphicon glyphicon-music" aria-hidden="true"></span>
                                        </asp:HyperLink>
                                        <div id="iconMP3" runat="server">
                                            <span class="glyphicon glyphicon-music" aria-hidden="true"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="input-group has-warning">
                                    <div class="input-group-addon" style="width: 32%; text-align: right">Sheet Music:</div>
                                    <asp:FileUpload ID="inputPDF" runat="server" CssClass="form-control" />
                                    <div class="input-group-addon" style="width: 10%; text-align: center">
                                        <asp:HyperLink ID="lnkPDF" runat="server" Target="_blank" Style="margin-right: 0px">
                                            <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>
                                        </asp:HyperLink>
                                        <div id="iconPDF" runat="server">
                                            <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="input-group has-warning">
                                    <div class="input-group-addon" style="width: 32%; text-align: right">Accompaniment:</div>
                                    <asp:FileUpload ID="inputTrack" runat="server" CssClass="form-control" />
                                    <div class="input-group-addon" style="width: 10%; text-align: center">
                                        <asp:HyperLink ID="lnkTrack" runat="server" Target="_blank" Style="margin-right: 0px">
                                            <span class="glyphicon glyphicon-cd" aria-hidden="true"></span>
                                        </asp:HyperLink>
                                        <div id="iconTrack" runat="server">
                                            <span class="glyphicon glyphicon-cd" aria-hidden="true"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <div class="input-group-addon" style="text-align: right">Song Lyrics:</div>
                                    <textarea rows="4" maxlength="2500" class="form-control" id="inputLyrics" runat="server" wrap="soft"></textarea>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both">
                            <br />
                        </div>
                        <div class="form-group col-xs-12 btnContainer">
                            <div style="float: left">
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" UseSubmitBehavior="true" Text="Remove Song" OnClientClick="return delSong()" />
                            </div>
                            <div style="float: right">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" UseSubmitBehavior="true" />
                            </div>
                        </div>
                        <div style="clear: both"></div>
                    </div>
                    <script>
                        function delSong() {
                            if (confirm("You have chosen to remove this record, please confirm this choice.")) {
                                document.getElementById("fAction").value = "D";
                                return true;
                            } else {
                                return false;
                            }
                        }
                    </script>
                </asp:Panel>
                <div style="clear: both">
                    <br />
                </div>
                <asp:Panel ID="pnlResponse" runat="server" Visible="false">
                    <div class="text-center margin-25 response">
                        <asp:Label ID="lblResponse" runat="server"></asp:Label>
                    </div>
                    <div id="pnlRedirect" runat="server">
                        <script>setTimeout("window.location.href='songs.aspx'", 3500);</script>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
