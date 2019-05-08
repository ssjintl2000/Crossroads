using Crossroads.database;

using System;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace Crossroads
{
    public partial class songDetails : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                pnlForm.Visible = true;
                pnlRedirect.Visible = false;
                pnlResponse.Visible = false;

                if (Request.QueryString["id"] == null | Request.QueryString["id"] == "")
                {
                    // Add New
                    inputTitle.Value = "";
                    inputArtist.Value = "";
                    inputNotes.Value = "";
                    inputLyrics.Value = "";
                    lblPageTitle.Text = "Add New Song";
                    lnkMP3.Visible = false;
                    lnkPDF.Visible = false;
                    lnkTrack.Visible = false;

                    iconMP3.Visible = true;
                    iconPDF.Visible = true;
                    iconTrack.Visible = true;

                    btnUpdate.Text = "Add New Song";
                    btnDelete.Visible = false;
                }
                else
                {
                    // Edit Existing
                    var song = cdc.Songs.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    inputTitle.Value = song.Title;
                    inputArtist.Value = song.Artist;
                    inputNotes.Value = song.Notes;
                    inputLyrics.Value = song.Lyrics;
                    lblPageTitle.Text = "Edit Song: " + song.Title;

                    lnkMP3.Visible = false;
                    lnkPDF.Visible = false;
                    lnkTrack.Visible = false;

                    iconMP3.Visible = false;
                    iconPDF.Visible = false;
                    iconTrack.Visible = false;

                    if (song.MP3 != null & song.MP3 != "")
                    {
                        lnkMP3.NavigateUrl = "/content/songs/mp3s/" + song.MP3;
                        lnkMP3.Visible = true;
                    }
                    else
                    {
                        iconMP3.Visible = true;
                    }

                    if (song.PDF != null & song.PDF != "")
                    {
                        lnkPDF.NavigateUrl = "/content/songs/pdfs/" + song.PDF;
                        lnkPDF.Visible = true;
                    }
                    else
                    {
                        iconPDF.Visible = true;
                    }

                    if (song.Track != null & song.Track != "")
                    {
                        lnkTrack.NavigateUrl = "/content/songs/tracks/" + song.Track;
                        lnkTrack.Visible = true;
                    }
                    else
                    {
                        iconTrack.Visible = true;
                    }

                    btnUpdate.Text = "Update Song";
                }
            }
            else
            {
                pnlForm.Visible = false;
                pnlResponse.Visible = true;
                pnlRedirect.Visible = false;

                var bValid = true;
                var sMsg = string.Empty;
                var sMP3msg = string.Empty;
                var sPDFmsg = string.Empty;
                var sTRKmsg = string.Empty;

                lblResponse.Text = "";

                if (Request["fAction"] == "D")
                {
                    var song = cdc.Songs.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    if (song != null)
                    {
                        if (song.MP3 != null & song.MP3 != "")
                        {
                            var sMP3 = Server.MapPath("/content/songs/mp3s/") + song.MP3;
                            if (File.Exists(sMP3))
                            {
                                File.Delete(sMP3);
                            }
                        }

                        if (song.PDF != null & song.PDF != "")
                        {
                            var sPDF = Server.MapPath("/content/songs/pdfs/") + song.PDF;
                            if (File.Exists(sPDF))
                            {
                                File.Delete(sPDF);
                            }
                        }

                        if (song.Track != null & song.Track != "")
                        {
                            var sTrack = Server.MapPath("/content/songs/tracks/") + song.Track;
                            if (File.Exists(sTrack))
                            {
                                File.Delete(sTrack);
                            }
                        }

                        cdc.Songs.DeleteOnSubmit(song);
                        cdc.SubmitChanges();
                        sMsg = "Removed";
                    }
                }
                else
                {
                    #region MP3

                    if (inputMP3.HasFile)
                    {
                        try
                        {
                            var sMP3 = Path.GetFileName(inputMP3.FileName).Replace(" ", "_");
                            inputMP3.SaveAs(Server.MapPath("/content/songs/mp3s/") + sMP3);
                            sMP3msg = "Audio File Added";
                        }
                        catch (Exception ex)
                        {
                            lblResponse.Text += "The Audio File could not be uploaded. The following error occured: " + ex.Message;
                            bValid = false;
                        }
                    }

                    #endregion MP3
                    #region PDF

                    if (inputPDF.HasFile)
                    {
                        try
                        {
                            var sPDF = Path.GetFileName(inputPDF.FileName).Replace(" ", "_");
                            inputPDF.SaveAs(Server.MapPath("/content/songs/pdfs/") + sPDF);
                            sPDFmsg = "Sheet Music Added";
                        }
                        catch (Exception ex)
                        {
                            lblResponse.Text += "The Sheet Music could not be uploaded. The following error occured: " + ex.Message;
                            bValid = false;
                        }
                    }

                    #endregion PDF
                    #region Track

                    if (inputTrack.HasFile)
                    {
                        try
                        {
                            var sTrack = Path.GetFileName(inputTrack.FileName).Replace(" ", "_");
                            inputTrack.SaveAs(Server.MapPath("/content/songs/tracks/") + sTrack);
                            sTRKmsg = "Accompaniment Track Added";
                        }
                        catch (Exception ex)
                        {
                            lblResponse.Text += "The Accompaniment Track could not be uploaded. The following error occured: " + ex.Message;
                            bValid = false;
                        }
                    }

                    #endregion Track

                    if (Request.QueryString["id"] == null | Request.QueryString["id"] == "")
                    {
                        var xsong = cdc.Songs.FirstOrDefault(a => a.Title.ToLower() == inputTitle.Value.ToLower() && a.Artist.ToLower() == inputArtist.Value.ToLower());
                        if (xsong != null)
                        {
                            cdc.Songs.DeleteOnSubmit(xsong);
                            cdc.SubmitChanges();
                        }

                        var song = new Song();
                        song.Title = inputTitle.Value;
                        song.Artist = inputArtist.Value;
                        song.Notes = inputNotes.Value;
                        if (inputMP3.HasFile) { song.MP3 = inputMP3.FileName.Replace(" ", "_"); }
                        if (inputPDF.HasFile) { song.PDF = inputPDF.FileName.Replace(" ", "_"); }
                        if (inputTrack.HasFile) { song.Track = inputTrack.FileName.Replace(" ", "_"); }
                        song.Lyrics = inputLyrics.Value;
                        song.ChurchId = Convert.ToInt32(Session["ChurchId"]);
                        cdc.Songs.InsertOnSubmit(song);
                        cdc.SubmitChanges();

                        sMsg = "Added";
                    }
                    else
                    {
                        var song = cdc.Songs.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                        song.Title = inputTitle.Value;
                        song.Artist = inputArtist.Value;
                        song.Notes = inputNotes.Value;
                        if (inputMP3.HasFile) { song.MP3 = inputMP3.FileName.Replace(" ", "_"); }
                        if (inputPDF.HasFile) { song.PDF = inputPDF.FileName.Replace(" ", "_"); }
                        if (inputTrack.HasFile) { song.Track = inputTrack.FileName.Replace(" ", "_"); }
                        song.Lyrics = inputLyrics.Value;
                        song.ChurchId = Convert.ToInt32(Session["ChurchId"]);
                        cdc.SubmitChanges();

                        sMsg = "Updated";
                    }
                }

                if (bValid)
                {
                    var sResp = "<strong>The song " + inputTitle.Value + " has been " + sMsg + "</strong>";
                    if (sMP3msg != "") { sResp += "<br />" + sMP3msg; }
                    if (sPDFmsg != "") { sResp += "<br />" + sPDFmsg; }
                    if (sTRKmsg != "") { sResp += "<br />" + sTRKmsg; }

                    lblResponse.Text = sResp + "<br />";
                    pnlRedirect.Visible = true;
                }
            }
        }
    }
}