<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.master" AutoEventWireup="true" CodeBehind="songs.aspx.cs" Inherits="Crossroads.songs" %>

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
                <div class="songContentHeader">Song Listing</div>
                <div id="songContentActions" runat="server" class="songContentActions">
                    <asp:HyperLink ID="addSong" runat="server" NavigateUrl="songDetails.aspx" Visible="false">Add New Song</asp:HyperLink>
                </div>
                <div style="clear: both; border-top: solid 2px #555;">
                    This song listing below contains all of the songs performed by the Crossroads Praise Team. Within the song listing you will see:
                    <ol>
                        <li>The Title of the song</li>
                        <li>The Artist who performed it, or at least the rendition we are going to immulate</li>
                        <li>The Date the last time the song was performed</li>
                        <li>The Date the song is scheduled to be performed again.</li>
                        <li>If there is an MP3, or PDF, or track supporting the song, you will see.</li>
                        <ol type="a">
                            <li>The MP3 ( Play ) to listen to (if available)</li>
                            <li>The PDF ( View ) sheet music to study and practice (if available)</li>
                            <li>The Accompaniment track ( Play ) to listen to (if available)</li>
                        </ol>
                        <li>If there are notes associated with the song you can see them underneath the title of the song.</li>
                    </ol>
                    <div class="text-center" style="clear: both; padding: 10px 0px; font-size: 1.5em; border-top: solid 2px #555;">
                        &nbsp;|&nbsp;<a href="#A" style="padding-top: 5px">A</a>&nbsp;|&nbsp;<a href="#B">B</a>&nbsp;|&nbsp;<a href="#C">C</a>&nbsp;|&nbsp;<a href="#D">D</a>&nbsp;|&nbsp;<a href="#E">E</a>&nbsp;|&nbsp;<a href="#F">F</a>&nbsp;|&nbsp;<a href="#G">G</a>&nbsp;|&nbsp;<a href="#H">H</a>&nbsp;|&nbsp;<a href="#I">I</a>&nbsp;|&nbsp;<a href="#J">J</a>&nbsp;|&nbsp;<a href="#K">K</a>&nbsp;|&nbsp;<a href="#L">L</a>&nbsp;|&nbsp;<a href="#M">M</a>&nbsp;|&nbsp;<a href="#N">N</a>&nbsp;|&nbsp;<a href="#O">O</a>&nbsp;|&nbsp;<a href="#P">P</a>&nbsp;|&nbsp;<a href="#Q">Q</a>&nbsp;|&nbsp;<a href="#R">R</a>&nbsp;|&nbsp;<a href="#S">S</a>&nbsp;|&nbsp;<a href="#T">T</a>&nbsp;|&nbsp;<a href="#U">U</a>&nbsp;|&nbsp;<a href="#V">V</a>&nbsp;|&nbsp;<a href="#W">W</a>&nbsp;|&nbsp;<a href="#X">X</a>&nbsp;|&nbsp;<a href="#Y">Y</a>&nbsp;|&nbsp;<a href="#Z">Z</a>&nbsp;|&nbsp;
                    </div>
                    <div>
                        <asp:Literal ID="ltlSongs" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
