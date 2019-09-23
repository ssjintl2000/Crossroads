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
            <div class="wishlistContent padding-20" style="height: 550px">
                <div class="wishlistContentHeader padding-bottom-10">Wish List</div>
                <div style="clear: both; border-top: solid 2px black;">
                    <br />
                    <asp:Panel ID="pnlForm" runat="server" CssClass="padding-top-10">
                        <div class="col-lg-offset-3 col-lg-6 wishlistForm padding-top-10">
                            <div class="col-sm-12">
                                <div class="form-group col-xs-6">
                                    <input type="text" class="form-control" id="inputTitle" runat="server" required="required" placeholder="Song Title">
                                </div>
                                <div class="form-group col-xs-6">
                                    <input type="text" class="form-control" id="inputArtist" runat="server" required="required" placeholder="Song Artist">
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-xs-3">
                                    <select class="form-control" id="inputSongType" runat="server">
                                        <option value="G">Group</option>
                                        <option value="M">Male</option>
                                        <option value="F">Female</option>
                                    </select>
                                </div>
                                <div class="form-group col-xs-9">
                                    <input type="text" class="form-control" id="inputURL" runat="server" required="required" placeholder="Song URL">
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-xs-12">
                                    <textarea class="form-control" id="inputNotes" cols="50" rows="4" runat="server" placeholder="Notes"></textarea>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group col-xs-12">
                                    <select class="form-control" id="inputStatus" runat="server">
                                        <option value="I">Inactive</option>
                                        <option value="A">Active</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-9">
                                <div class="form-group col-xs-12 text-right">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Request" CssClass="btn btn-success" UseSubmitBehavior="true" />
                                </div>
                            </div>
                            <div class="form-group col-xs-12 text-center">
                                <a href="Javascript:window.history.go(-1)" style="font-size: small">Return to Previous</a>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponse" runat="server">
                        <div class="text-center margin-50">
                            <asp:Label ID="lblResponse" runat="server" style="font-size: 1.25em"></asp:Label>
                        </div>
                        <script>setTimeout("window.location.href='wishlist.aspx'", 3000);</script>
                    </asp:Panel>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
