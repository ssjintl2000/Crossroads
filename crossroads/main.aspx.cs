using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] == null)
            {
                Response.Redirect("/default.aspx");
            }

            // =====[ Service Listing ]=====//

            #region Service Listing

            var service = new Service();
            var cdc = new crossroadsDataContext();
            var church = cdc.Churches.FirstOrDefault(a => a.Id == Convert.ToInt32(Session["churchid"]));

            maintitle.InnerText = church.PTName;
            churchname.InnerText = church.CName;
            imgLogo.AlternateText = church.CName;
            imgLogo.ImageUrl = "content/images/" + church.Logo;

            var curId = Request.QueryString["serviceid"];
            if (curId == null)
            {
                var newService = cdc.Services.FirstOrDefault(a => a.ChurchId == Convert.ToInt32(Session["churchid"]) && a.ServiceDate > DateTime.Now);
                if (service != null)
                {
                    curId = newService.Id.ToString();
                }
                else
                {
                    curId = "1";
                }
            }

            Session["curserviceid"] = Convert.ToInt32(curId);

            var curService = cdc.Services.FirstOrDefault(a => a.Id == Convert.ToInt32(curId));
            lblServiceDate.Text = curService.ServiceDate.ToString("MMMM dd, yyyy @ hh:mm tt");
            lblServiceTitle.Text = curService.ServiceTitle;
            lblServiceScripture.Text = "<a href='https://biblegateway.com/passage/?search=" + Server.UrlEncode(curService.ServiceScripture) + "&version=NIV' target='_blank'>" + curService.ServiceScripture + "</a>";

            if (curService.ServiceNotes != null & curService.ServiceNotes != "")
            {
                lblServiceNotes.Text = curService.ServiceNotes;
                servicenotescontainer.Visible = true;
            }

            if (curService.ServicePDF != null & curService.ServicePDF != "")
            {
                lnkBulletin.NavigateUrl = "/content/bulletins/" + curService.ServicePDF;
                lnkBulletin.Target = "_blank";
                servicepdfcontainer.Visible = true;
            }

            if (curService.Baptism || curService.Communion || curService.Rehearsal)
            {
                lblBaptism.Visible = curService.Baptism;
                lblCommunion.Visible = curService.Communion;
                lblRehearsal.Visible = curService.Rehearsal;
                serviceactivitiescontainer.Visible = true;
            }

            var prvService = cdc.Services.OrderByDescending(a => a.ServiceDate).FirstOrDefault(a => a.ChurchId == Convert.ToInt32(Session["churchid"]) && a.ServiceDate < curService.ServiceDate);
            var prvId = string.Empty;
            if (prvService != null)
            {
                prvId = prvService.Id.ToString();
                lnkPrevService.NavigateUrl = "/main.aspx?serviceid=" + prvId;
                lnkPrevService.Visible = true;
            }

            var nxtService = cdc.Services.OrderBy(a => a.ServiceDate).FirstOrDefault(a => a.ChurchId == Convert.ToInt32(Session["churchid"]) && a.ServiceDate > curService.ServiceDate);
            var nxtId = string.Empty;
            if (nxtService != null)
            {
                nxtId = nxtService.Id.ToString();
                lnkNextService.NavigateUrl = "/main.aspx?serviceid=" + nxtId;
                lnkNextService.Visible = true;
            }

            datedivider.Visible = lnkPrevService.Visible && lnkNextService.Visible;

            #endregion Service Listing

            // =====[ Songs Listing ]=====//

            #region Song Listing

            var sbsongs = new StringBuilder();
            sbsongs.AppendLine("<table class='table servicesongstable'>");
            sbsongs.AppendLine("<thead>");
            sbsongs.AppendLine("<tr>");
            sbsongs.AppendLine("<th>Title (Lead)</th>");
            sbsongs.AppendLine("<th class='text-center'>MP3</th>");
            sbsongs.AppendLine("<th class='text-center'>PDF</th>");
            sbsongs.AppendLine("<th class='text-center'>Track</th>");
            sbsongs.AppendLine("</tr>");
            sbsongs.AppendLine("</thead>");
            sbsongs.AppendLine("<tbody>");
            var songs = cdc.ServiceSongs.Where(a => a.ServiceId == Convert.ToInt32(curId)).ToList();
            foreach (var song in songs)
            {
                var songdetails = cdc.Songs.FirstOrDefault(a => a.Id == song.SongId);

                var user = new User();
                var lead = string.Empty;
                if (song.SongLeadUser != 0)
                {
                    user = cdc.Users.FirstOrDefault(a => a.Id == Convert.ToInt32(song.SongLeadUser));
                    lead = user.FName + " " + user.LName;
                }
                else
                {
                    lead = "Everyone";
                }

                sbsongs.AppendLine("<tr>");
                sbsongs.AppendLine("    <td>");
                sbsongs.AppendLine(songdetails.Title + " - (" + lead + " Lead)");
                if (!string.IsNullOrEmpty(songdetails.Notes))
                {
                    sbsongs.AppendLine("<br /><strong>Notes: </strong><em>" + songdetails.Notes + "</em>");
                }

                sbsongs.AppendLine("</td>");
                sbsongs.AppendLine("    <td class='songsMP3 text-center'>");
                if (!string.IsNullOrEmpty(songdetails.MP3))
                {
                    sbsongs.Append("<a href=Javascript:winOpen('/content/songs/mp3s/" + songdetails.MP3 + "','SONG',400,200,1,0,0) target='_blank'>Play</a>");
                }

                sbsongs.AppendLine("    </td>");
                sbsongs.AppendLine("    <td class='songsPDF text-center'>");
                if (!string.IsNullOrEmpty(songdetails.PDF))
                {
                    sbsongs.Append("<a href=Javascript:winOpen('/content/songs/pdfs/" + songdetails.PDF + "','SHEET',0,0,1,1,0) target='_blank'>View</a>");
                }

                sbsongs.AppendLine("    </td>");
                sbsongs.AppendLine("    <td class='songsTRACK text-center'>");
                if (!string.IsNullOrEmpty(songdetails.Track))
                {
                    sbsongs.Append("<a href=Javascript:winOpen('/content/songs/tracks/" + songdetails.Track + "','TRACK',400,200,1,0,0) target='_blank'>Play</a>");
                }

                sbsongs.AppendLine("    </td>");
                sbsongs.AppendLine("</tr>");
            }

            sbsongs.AppendLine("</tbody>");
            sbsongs.AppendLine("</table>");
            ltlServiceSongs.Text = sbsongs.ToString();

            #endregion Song Listing

            // =====[ Performer Listing ]=====//

            #region Performer Listing

            var sbavocals = new StringBuilder();
            var sbamusicians = new StringBuilder();
            var sbatech = new StringBuilder();
            var aperformers = cdc.ServiceUsers.Where(a => a.ServiceId == Convert.ToInt32(curId)).ToList();
            foreach (var amember in aperformers)
            {
                var user = cdc.Users.FirstOrDefault(a => a.Id == amember.UserId);
                switch (user.UType)
                {
                    case "V":
                        sbavocals.AppendLine("<div style='float: left'>" + user.FName + " " + user.LName + "</div>");
                        sbavocals.AppendLine("<div style='float: right'>" + user.UPosition + "</div>");
                        sbavocals.AppendLine("<div style='clear: both'></div>");
                        break;

                    case "M":
                        sbamusicians.AppendLine("<div style='float: left'>" + user.FName + " " + user.LName + "</div>");
                        sbamusicians.AppendLine("<div style='float: right'>" + user.UPosition + "</div>");
                        sbamusicians.AppendLine("<div style='clear: both'></div>");
                        break;

                    case "T":
                        sbatech.AppendLine("<div style='float: left'>" + user.FName + " " + user.LName + "</div>");
                        sbatech.AppendLine("<div style='float: right'>" + user.UPosition + "</div>");
                        sbatech.AppendLine("<div style='clear: both'></div>");
                        break;
                }
            }

            ltlServiceVocalists.Text = sbavocals.ToString();
            ltlServiceMusicians.Text = sbamusicians.ToString();
            ltlServiceTechnicians.Text = sbatech.ToString();

            var sbuvocals = new StringBuilder();
            var sbumusicians = new StringBuilder();
            var sbutech = new StringBuilder();
            var uperformers = cdc.ServiceUnavailables.Where(a => a.ServiceId == Convert.ToInt32(curId)).ToList();
            foreach (var umember in uperformers)
            {
                var user = cdc.Users.FirstOrDefault(a => a.Id == umember.UserId);
                switch (user.UType)
                {
                    case "V":
                        sbuvocals.AppendLine("<div style='float: left'>" + user.FName + " " + user.LName + "</div>");
                        sbuvocals.AppendLine("<div style='float: right'>" + user.UPosition + "</div>");
                        sbuvocals.AppendLine("<div style='clear: both'></div>");
                        break;

                    case "M":
                        sbumusicians.AppendLine("<div style='float: left'>" + user.FName + " " + user.LName + "</div>");
                        sbumusicians.AppendLine("<div style='float: right'>" + user.UPosition + "</div>");
                        sbumusicians.AppendLine("<div style='clear: both'></div>");
                        break;

                    case "T":
                        sbutech.AppendLine("<div style='float: left'>" + user.FName + " " + user.LName + "</div>");
                        sbutech.AppendLine("<div style='float: right'>" + user.UPosition + "</div>");
                        sbutech.AppendLine("<div style='clear: both'></div>");
                        break;
                }
            }

            ltlUnavailableVocalists.Text = sbuvocals.ToString();
            ltlUnavailableMusicians.Text = sbumusicians.ToString();
            ltlUnavailableTechnicians.Text = sbutech.ToString();

            unavailablevocalistscontainer.Visible = !string.IsNullOrEmpty(sbuvocals.ToString());
            unavailablemusicianscontainer.Visible = !string.IsNullOrEmpty(sbumusicians.ToString());
            unavailabletechnicianscontainer.Visible = !string.IsNullOrEmpty(sbutech.ToString());

            #endregion Performer Listing

            // =====[ Member Listing ]=====//

            #region Member Listing

            var sbmembers = new StringBuilder();
            sbmembers.Append("<table class='table table-hover' style='margin-bottom: 0'>");
            foreach (var member in cdc.Users.Where(a => a.UType != "S").Where(a => a.UType != "W").Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).OrderBy(a => a.FName).ThenBy(a => a.LName).ToList())
            {
                sbmembers.Append("<tr>");
                sbmembers.Append(" <td align='left'><a href='Javascript:chkUser(" + member.Id + ")'><strong>" + member.FName + " " + member.LName + "</strong></a></td>");
                if (member.Phone != null && member.Phone != "")
                {
                    sbmembers.Append(" <td align='right' nowrap>(" + member.Phone.Substring(0, 3) + ") " + member.Phone.Substring(3, 3) + " - " + member.Phone.Substring(6) + "</td>");
                }
                else
                {
                    sbmembers.Append(" <td align='right' nowrap>No Phone Number</td>");
                }

                sbmembers.Append("</tr>");
                sbmembers.Append("<tr id='" + member.Id + "' class='memberDetails' style='display:none'>");
                sbmembers.Append(" <td colspan='2'>");
                switch (member.UType)
                {
                    case "V":
                        sbmembers.Append("<strong>Vocalist</strong> (" + member.UPosition + ")");
                        break;

                    case "M":
                        sbmembers.Append("<strong>Musician</strong> (" + member.UPosition + ")");
                        break;

                    case "T":
                        sbmembers.Append("<strong>Technician</strong>");
                        break;
                }

                sbmembers.Append("     <div style='border-top: 1px solid black; margin: 5px'>" + member.Address + "<br />" + member.City + ", " + member.State + " " + member.ZipCode + "</div>");
                sbmembers.Append("     <div style='border-top: 1px solid black; margin: 5px'><a href='mailto: " + member.Email + "?subject=Crossroads Website'>" + member.Email + "</a></div>");
                sbmembers.Append(" </td>");
                sbmembers.Append("</tr>");
            }

            sbmembers.Append("</table>");
            sbmembers.Append("<div class='memberEmail'>");
            sbmembers.Append("<div style='clear: both'>");
            sbmembers.Append("<a href='mailto:crossroadsteam@fumc-cs.org'>Crossroads Team</a>&nbsp;/&nbsp;<a href='mailto:crossroadstech@fumc-cs.org'>Crossroads Tech</a>");
            sbmembers.Append("</div>");
            sbmembers.Append("</div>");
            ltlMembers.Text = sbmembers.ToString();

            #endregion Member Listing
        }
    }
}