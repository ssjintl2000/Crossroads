<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="memberdetails.aspx.cs" Inherits="Crossroads.memberdetails" %>

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
                <div class="memberContentHeader padding-bottom-10">Member Details</div>
                <div style="clear: both; border-top: solid 2px black;">
                    <br />
                </div>
                <asp:Panel ID="pnlForm" runat="server" CssClass="padding-top-10">
                    <div class="col-lg-offset-2 col-lg-8 memberForm">
                        <div class="col-xs-12 memberFormHeader">
                            <div class="col-xs-6 text-left" id="memberFormHeader" runat="server"></div>
                            <div class="col-xs-6 text-right">
                                <asp:HyperLink ID="lnkChangePassword" runat="server" NavigateUrl="changepassword.aspx" Text="Change Password" Visible="false" />
                            </div>
                        </div>
                        <div class="clear: both">
                            <br />
                        </div>
                        <div class="col-sm-6" style="float: left">
                            <div class="form-group col-xs-12 col-sm-6">
                                <input type="text" class="form-control" id="inputFName" runat="server" required="required" placeholder="First Name">
                            </div>
                            <div class="form-group col-xs-12 col-sm-6">
                                <input type="text" class="form-control" id="inputLName" runat="server" required="required" placeholder="Last Name">
                            </div>
                            <div class="form-group col-xs-12">
                                <input type="text" class="form-control" id="inputAddress" runat="server" placeholder="Street Address">
                            </div>
                            <div class="form-group col-xs-12 col-sm-8 col-md-5 col-lg-6">
                                <input type="text" class="form-control" id="inputCity" runat="server" placeholder="City">
                            </div>
                            <div class="form-group col-xs-12 col-sm-4 col-md-3 col-lg-3">
                                <select class="form-control" id="selectState" runat="server">
                                </select>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <input type="number" class="form-control" id="inputZipCode" runat="server" placeholder="ZipCode">
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-12 col-lg-6">
                                <input type="number" class="form-control" id="inputPhone" runat="server" placeholder="Phone Number">
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-12 col-lg-6">
                                <input type="email" class="form-control" id="inputEmail" runat="server" required="required" placeholder="Email Address">
                            </div>
                        </div>
                        <div class="hidden-sm hidden-md hidden-lg" style="clear: both; margin-top: 10px; border-top: 2px solid black;">
                            <br />
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group col-xs-12 col-md-6">
                                <select class="form-control" id="selectStatus" runat="server">
                                    <option value="A">Active</option>
                                    <option value="I">InActive</option>
                                </select>
                            </div>
                            <div class="form-group col-xs-12 col-md-6">
                                <select class="form-control" id="selectGender" runat="server">
                                    <option value="M">Gender (Male)</option>
                                    <option value="F">Gender (Female)</option>
                                </select>
                            </div>
                            <div class="form-group col-xs-12 col-md-6">
                                <select class="form-control" id="selectPrimary" runat="server">
                                    <option value="Y">Primary (Yes)</option>
                                    <option value="N">Primary (No)</option>
                                </select>
                            </div>
                            <div class="form-group col-xs-12 col-md-6">
                                <select class="form-control" id="selectType" required="required" runat="server">
                                    <option value="" selected>Select Type</option>
                                    <option value="V">Vocalist</option>
                                    <option value="M">Musician</option>
                                    <option value="T">Technician</option>
                                    <option value="S">Staff</option>
                                    <option value="W">Website Guest</option>
                                </select>
                            </div>
                            <div class="form-group col-xs-12 col-md-6">
                                <select class="form-control" id="selectVocalist" runat="server">
                                    <option value="N">Vocalist (No)</option>
                                    <option value="Y">Vocalist (Yes)</option>
                                </select>
                            </div>
                            <div class="form-group col-xs-12 col-md-6">
                                <select class="form-control" id="selectSecurity" runat="server" disabled>
                                    <option value="1">General User</option>
                                    <option value="0">Guest</option>
                                    <option value="5">Administrator</option>
                                </select>
                            </div>
                            <div class="form-group col-xs-12">
                                <input type="text" class="form-control" id="inputPosition" required="required" placeholder="Position" runat="server">
                            </div>
                        </div>
                        <div style="clear: both"></div>
                        <div class="form-group col-xs-12 btnContainer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update User" CssClass="btn btn-success updateButton" UseSubmitBehavior="true" />
                            <asp:Label ID="lblError" runat="server" CssClass="formError"></asp:Label>
                        </div>
                        <div style="clear: both"></div>
                    </div>
                    <div style="clear: both">
                        <br />
                    </div>
                    <div style="clear: both">
                        <br />
                    </div>
                    <div style="clear: both">
                        <br />
                    </div>
                    <div style="clear: both">
                        <br />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlResponse" runat="server">
                    <div class="text-center margin-50">
                        <div style="font-size: 1.25em">Records Updated</div>
                    </div>
                    <script>setTimeout("window.location.href='members.aspx'", 3000);</script>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
