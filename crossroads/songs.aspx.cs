using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class songs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] == null)
            {
                Response.Redirect("/default.aspx");
            }

            maintitle.InnerText = Session["ptname"].ToString();
            churchname.InnerText = Session["churchname"].ToString();

            var cdc = new crossroadsDataContext();
            if (Session["seclevel"] != null && Convert.ToInt32(Session["seclevel"]) > 1)
            {
                addSong.Visible = true;
            }

            var futureSongs = cdc.ServiceSongs.Where(a => a.ServiceId >= Convert.ToInt32(Session["curserviceid"])).ToList();
            var pastSongs = cdc.ServiceSongs.Where(a => a.ServiceId < Convert.ToInt32(Session["curserviceid"])).ToList();
            var songs = cdc.Songs.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).OrderBy(a => a.Title).ToList();

            var sbs = new StringBuilder();
            sbs.AppendLine("<table class='table table-condensed table-bordered songListing'>");
            sbs.AppendLine("<thead>");
            sbs.AppendLine("  <tr>");
            sbs.AppendLine("    <td></td>");
            sbs.AppendLine("    <td class='text-center'>Title</td>");
            sbs.AppendLine("    <td class='text-center'>Artist</td>");
            sbs.AppendLine("    <td class='text-center'>MP3</td>");
            sbs.AppendLine("    <td class='text-center'>PDF</td>");
            sbs.AppendLine("    <td class='text-center'>Track</td>");
            sbs.AppendLine("    <td class='text-center'>Last</td>");
            sbs.AppendLine("    <td class='text-center'>Next</td>");
            sbs.AppendLine("  </tr>");
            sbs.AppendLine("</thead>");
            sbs.AppendLine("<tbody>");

            var songLetter = "";
            foreach (var song in songs)
            {
                if (song.Title.Substring(0, 1) != "[" && song.Title.Substring(0, 1) != "1")
                {
                    if (songLetter != song.Title.Substring(0, 1))
                    {
                        sbs.AppendLine("<tr class='songGoBack'><td colspan='8'><a href='Javascript:history.go(-1)'>Go Back</a></td></tr>");
                        sbs.AppendLine("<tr class='songLetter'><th class='text-center'><a name='" + song.Title.Substring(0, 1) + "'>" + song.Title.Substring(0, 1) + "</a></th><td colspan='7'>&nbsp;</td></tr>");
                        songLetter = song.Title.Substring(0, 1);
                    }
                }

                DateTime dtServ;

                var dNDate = string.Empty;
                var ssn = futureSongs.Find(a => a.SongId == song.Id);
                if (ssn != null)
                {
                    dtServ = cdc.Services.FirstOrDefault(a => a.Id == ssn.ServiceId).ServiceDate;
                    if (dtServ != null)
                    {
                        dNDate = dtServ.ToShortDateString();
                    }
                }

                var dLDate = string.Empty;
                var ssl = pastSongs.Find(a => a.SongId == song.Id);
                if (ssl != null)
                {
                    dtServ = cdc.Services.FirstOrDefault(a => a.Id == ssl.ServiceId).ServiceDate;
                    if (dtServ != null)
                    {
                        dLDate = dtServ.ToShortDateString();
                    }
                }

                sbs.AppendLine("<tr>");
                sbs.AppendLine("<td class='text-center'>");
                if (Session["seclevel"] != null & Convert.ToInt32(Session["seclevel"]) > 1)
                {
                    sbs.AppendLine("<a href='songDetails.aspx?id=" + song.Id + "'>Edit</a>");
                }
                else
                {
                    sbs.AppendLine("&nbsp;");
                }

                sbs.AppendLine("</td>");
                sbs.AppendLine("<td>");
                sbs.AppendLine("" + song.Title + "");
                if (song.Notes != "")
                {
                    sbs.AppendLine("<div class='note'>" + song.Notes + "</div>");
                }

                sbs.AppendLine("</td>");
                sbs.AppendLine("<td>" + song.Artist + "</td>");
                sbs.AppendLine("<td class='text-center'>");
                if (song.MP3 != null & song.MP3 != "")
                {
                    sbs.AppendLine("<a href=Javascript:winOpen('/content/songs/mp3s/" + song.MP3 + "','MP3',300,150,0,0,0)>Play</a>");
                }
                else
                {
                    sbs.AppendLine("&nbsp;");
                }

                sbs.AppendLine("</td>");
                sbs.AppendLine("<td class='text-center'>");
                if (song.PDF != null & song.PDF != "")
                {
                    sbs.AppendLine("<a href=Javascript:winOpen('/content/songs/pdfs/" + song.PDF + "','PDF',800,600,1,1,1)>View</a>");
                }
                else
                {
                    sbs.AppendLine("&nbsp;");
                }

                sbs.AppendLine("</td>");
                sbs.AppendLine("<td class='text-center'>");
                if (song.Track != null & song.Track != "")
                {
                    sbs.AppendLine("<a href=Javascript:winOpen('/content/songs/tracks/" + song.Track + "','TRACK',400,150,0,0,0)>Play</a>");
                }
                else
                {
                    sbs.AppendLine("&nbsp;");
                }

                sbs.AppendLine("</td>");
                sbs.AppendLine("<td class='text-center'>" + dLDate + "</td>");
                sbs.AppendLine("<td class='text-center'>" + dNDate + "</td>");
                sbs.AppendLine("</tr>");
            }

            sbs.AppendLine("</tbody>");
            sbs.AppendLine("</table>");

            ltlSongs.Text = sbs.ToString();
        }
    }
}