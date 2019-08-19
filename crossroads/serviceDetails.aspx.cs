using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class serviceDetails : System.Web.UI.Page
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

                Service svc = null;
                List<ServiceSong> serviceSongs = new List<ServiceSong>();
                List<ListItem> songList, vocalistList, musicianList, techList, positionList;
                SetupElements(Convert.ToInt32(Session["churchid"]), cdc, out songList, out vocalistList, out musicianList, out techList, out positionList);

                if (Request.QueryString["id"] != null)
                {
                    var serviceId = Convert.ToInt32(Request.QueryString["id"]);
                    serviceSongs = cdc.ServiceSongs.Where(a => a.ServiceId == serviceId).ToList();

                    svc = cdc.Services.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    svcDate.Text = svc.ServiceDate.ToString("yyyy-MM-dd");
                    svcTime.Text = svc.ServiceDate.ToString("HH:mm");
                    svcTitle.Text = svc.ServiceTitle.ToString();
                    svcScripture.Text = svc.ServiceScripture.ToString();
                    if (svc.ServiceNotes != null)
                    {
                        svcNotes.Text = svc.ServiceNotes == "" ? "" : svc.ServiceNotes.ToString();
                    }

                    radYBaptism.Checked = svc.Baptism;
                    radNBaptism.Checked = !svc.Baptism;
                    radYCommunion.Checked = svc.Communion;
                    radNCommunion.Checked = !svc.Communion;
                    radYRehearsal.Checked = svc.Rehearsal;
                    radNRehearsal.Checked = !svc.Rehearsal;
                }

                #region SongOne

                List<ListItem> songList1 = new List<ListItem>();
                List<ListItem> positionList1 = new List<ListItem>();
                List<ListItem> vocalistList1 = new List<ListItem>();

                foreach (var item in songList) songList1.Add(new ListItem { Text = item.Text, Value = item.Value });
                foreach (var item in positionList) { positionList1.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList1.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song1 = 0;
                var position1 = 0;
                var vocalist1 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 0 && serviceSongs[0] != null))
                {
                    song1 = songList.FindIndex(a => a.Value == serviceSongs[0].SongId.ToString());
                    position1 = positionList.FindIndex(a => a.Value == serviceSongs[0].SongPosition.ToString());
                    vocalist1 = vocalistList.FindIndex(a => a.Value == serviceSongs[0].SongLeadUser.ToString());
                }

                ddlSongOne.DataSource = songList1;
                ddlSongOne.DataTextField = "Text";
                ddlSongOne.DataValueField = "Value";
                ddlSongOne.SelectedIndex = song1;
                ddlSongOne.DataBind();

                ddlSongOnePosition.DataSource = positionList1;
                ddlSongOnePosition.DataTextField = "Text";
                ddlSongOnePosition.DataValueField = "Value";
                ddlSongOnePosition.SelectedIndex = position1;
                ddlSongOnePosition.DataBind();

                ddlSongOneLead.DataSource = vocalistList1;
                ddlSongOneLead.DataTextField = "Text";
                ddlSongOneLead.DataValueField = "Value";
                ddlSongOneLead.SelectedIndex = vocalist1;
                ddlSongOneLead.DataBind();

                #endregion SongOne
                #region SongTwo

                List<ListItem> songList2 = new List<ListItem>();
                List<ListItem> positionList2 = new List<ListItem>();
                List<ListItem> vocalistList2 = new List<ListItem>();

                foreach (var item in songList) songList2.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList2.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList2.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song2 = 0;
                var position2 = 0;
                var vocalist2 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 1 && serviceSongs[1] != null))
                {
                    song2 = songList.FindIndex(a => a.Value == serviceSongs[1].SongId.ToString());
                    position2 = positionList.FindIndex(a => a.Value == serviceSongs[1].SongPosition.ToString());
                    vocalist2 = vocalistList.FindIndex(a => a.Value == serviceSongs[1].SongLeadUser.ToString());
                }

                ddlSongTwo.DataSource = songList2;
                ddlSongTwo.DataTextField = "Text";
                ddlSongTwo.DataValueField = "Value";
                ddlSongTwo.SelectedIndex = song2;
                ddlSongTwo.DataBind();

                ddlSongTwoPosition.DataSource = positionList2;
                ddlSongTwoPosition.DataTextField = "Text";
                ddlSongTwoPosition.DataValueField = "Value";
                ddlSongTwoPosition.SelectedIndex = position2;
                ddlSongTwoPosition.DataBind();

                ddlSongTwoLead.DataSource = vocalistList2;
                ddlSongTwoLead.DataTextField = "Text";
                ddlSongTwoLead.DataValueField = "Value";
                ddlSongTwoLead.SelectedIndex = vocalist2;
                ddlSongTwoLead.DataBind();

                #endregion SongTwo
                #region SongThree

                List<ListItem> songList3 = new List<ListItem>();
                List<ListItem> positionList3 = new List<ListItem>();
                List<ListItem> vocalistList3 = new List<ListItem>();

                foreach (var item in songList) songList3.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList3.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList3.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song3 = 0;
                var position3 = 0;
                var vocalist3 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 2 && serviceSongs[2] != null))
                {
                    song3 = songList.FindIndex(a => a.Value == serviceSongs[2].SongId.ToString());
                    position3 = positionList.FindIndex(a => a.Value == serviceSongs[2].SongPosition.ToString());
                    vocalist3 = vocalistList.FindIndex(a => a.Value == serviceSongs[2].SongLeadUser.ToString());
                }

                ddlSongThree.DataSource = songList3;
                ddlSongThree.DataTextField = "Text";
                ddlSongThree.DataValueField = "Value";
                ddlSongThree.SelectedIndex = song3;
                ddlSongThree.DataBind();

                ddlSongThreePosition.DataSource = positionList3;
                ddlSongThreePosition.DataTextField = "Text";
                ddlSongThreePosition.DataValueField = "Value";
                ddlSongThreePosition.SelectedIndex = position3;
                ddlSongThreePosition.DataBind();

                ddlSongThreeLead.DataSource = vocalistList3;
                ddlSongThreeLead.DataTextField = "Text";
                ddlSongThreeLead.DataValueField = "Value";
                ddlSongThreeLead.SelectedIndex = vocalist3;
                ddlSongThreeLead.DataBind();

                #endregion SongThree
                #region SongFour

                List<ListItem> songList4 = new List<ListItem>();
                List<ListItem> positionList4 = new List<ListItem>();
                List<ListItem> vocalistList4 = new List<ListItem>();

                foreach (var item in songList) songList4.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList4.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList4.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song4 = 0;
                var position4 = 0;
                var vocalist4 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 3 && serviceSongs[3] != null))
                {
                    song4 = songList.FindIndex(a => a.Value == serviceSongs[3].SongId.ToString());
                    position4 = positionList.FindIndex(a => a.Value == serviceSongs[3].SongPosition.ToString());
                    vocalist4 = vocalistList.FindIndex(a => a.Value == serviceSongs[3].SongLeadUser.ToString());
                }

                ddlSongFour.DataSource = songList4;
                ddlSongFour.DataTextField = "Text";
                ddlSongFour.DataValueField = "Value";
                ddlSongFour.SelectedIndex = song4;
                ddlSongFour.DataBind();

                ddlSongFourPosition.DataSource = positionList4;
                ddlSongFourPosition.DataTextField = "Text";
                ddlSongFourPosition.DataValueField = "Value";
                ddlSongFourPosition.SelectedIndex = position4;
                ddlSongFourPosition.DataBind();

                ddlSongFourLead.DataSource = vocalistList4;
                ddlSongFourLead.DataTextField = "Text";
                ddlSongFourLead.DataValueField = "Value";
                ddlSongFourLead.SelectedIndex = vocalist4;
                ddlSongFourLead.DataBind();

                #endregion SongFour
                #region SongFive

                List<ListItem> songList5 = new List<ListItem>();
                List<ListItem> positionList5 = new List<ListItem>();
                List<ListItem> vocalistList5 = new List<ListItem>();

                foreach (var item in songList) songList5.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList5.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList5.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song5 = 0;
                var position5 = 0;
                var vocalist5 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 4 && serviceSongs[4] != null))
                {
                    song5 = songList.FindIndex(a => a.Value == serviceSongs[4].SongId.ToString());
                    position5 = positionList.FindIndex(a => a.Value == serviceSongs[4].SongPosition.ToString());
                    vocalist5 = vocalistList.FindIndex(a => a.Value == serviceSongs[4].SongLeadUser.ToString());
                }

                ddlSongFive.DataSource = songList5;
                ddlSongFive.DataTextField = "Text";
                ddlSongFive.DataValueField = "Value";
                ddlSongFive.SelectedIndex = song5;
                ddlSongFive.DataBind();

                ddlSongFivePosition.DataSource = positionList5;
                ddlSongFivePosition.DataTextField = "Text";
                ddlSongFivePosition.DataValueField = "Value";
                ddlSongFivePosition.SelectedIndex = position5;
                ddlSongFivePosition.DataBind();

                ddlSongFiveLead.DataSource = vocalistList5;
                ddlSongFiveLead.DataTextField = "Text";
                ddlSongFiveLead.DataValueField = "Value";
                ddlSongFiveLead.SelectedIndex = vocalist5;
                ddlSongFiveLead.DataBind();

                #endregion SongFive
                #region SongSix

                List<ListItem> songList6 = new List<ListItem>();
                List<ListItem> positionList6 = new List<ListItem>();
                List<ListItem> vocalistList6 = new List<ListItem>();

                foreach (var item in songList) songList6.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList6.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList6.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song6 = 0;
                var position6 = 0;
                var vocalist6 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 5 && serviceSongs[5] != null))
                {
                    song6 = songList.FindIndex(a => a.Value == serviceSongs[5].SongId.ToString());
                    position6 = positionList.FindIndex(a => a.Value == serviceSongs[5].SongPosition.ToString());
                    vocalist6 = vocalistList.FindIndex(a => a.Value == serviceSongs[5].SongLeadUser.ToString());
                }

                ddlSongSix.DataSource = songList6;
                ddlSongSix.DataTextField = "Text";
                ddlSongSix.DataValueField = "Value";
                ddlSongSix.SelectedIndex = song6;
                ddlSongSix.DataBind();

                ddlSongSixPosition.DataSource = positionList6;
                ddlSongSixPosition.DataTextField = "Text";
                ddlSongSixPosition.DataValueField = "Value";
                ddlSongSixPosition.SelectedIndex = position6;
                ddlSongSixPosition.DataBind();

                ddlSongSixLead.DataSource = vocalistList6;
                ddlSongSixLead.DataTextField = "Text";
                ddlSongSixLead.DataValueField = "Value";
                ddlSongSixLead.SelectedIndex = vocalist6;
                ddlSongSixLead.DataBind();

                #endregion SongSix
                #region SongSeven

                List<ListItem> songList7 = new List<ListItem>();
                List<ListItem> positionList7 = new List<ListItem>();
                List<ListItem> vocalistList7 = new List<ListItem>();

                foreach (var item in songList) songList7.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList7.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList7.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song7 = 0;
                var position7 = 0;
                var vocalist7 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 6 && serviceSongs[6] != null))
                {
                    song7 = songList.FindIndex(a => a.Value == serviceSongs[6].SongId.ToString());
                    position7 = positionList.FindIndex(a => a.Value == serviceSongs[6].SongPosition.ToString());
                    vocalist7 = vocalistList.FindIndex(a => a.Value == serviceSongs[6].SongLeadUser.ToString());
                }

                ddlSongSeven.DataSource = songList7;
                ddlSongSeven.DataTextField = "Text";
                ddlSongSeven.DataValueField = "Value";
                ddlSongSeven.SelectedIndex = song7;
                ddlSongSeven.DataBind();

                ddlSongSevenPosition.DataSource = positionList7;
                ddlSongSevenPosition.DataTextField = "Text";
                ddlSongSevenPosition.DataValueField = "Value";
                ddlSongSevenPosition.SelectedIndex = position7;
                ddlSongSevenPosition.DataBind();

                ddlSongSevenLead.DataSource = vocalistList7;
                ddlSongSevenLead.DataTextField = "Text";
                ddlSongSevenLead.DataValueField = "Value";
                ddlSongSevenLead.SelectedIndex = vocalist7;
                ddlSongSevenLead.DataBind();

                #endregion SongSeven
                #region SongEight

                List<ListItem> songList8 = new List<ListItem>();
                List<ListItem> positionList8 = new List<ListItem>();
                List<ListItem> vocalistList8 = new List<ListItem>();

                foreach (var item in songList) songList8.Add(new ListItem { Text = item.Text, Value = item.Value });

                foreach (var item in positionList) { positionList8.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }
                foreach (var item in vocalistList) { vocalistList8.Add(new ListItem { Text = item.Text, Value = item.Value, Selected = false }); }

                var song8 = 0;
                var position8 = 0;
                var vocalist8 = 0;

                if (serviceSongs != null & (serviceSongs.Count > 7 && serviceSongs[7] != null))
                {
                    song8 = songList.FindIndex(a => a.Value == serviceSongs[7].SongId.ToString());
                    position8 = positionList.FindIndex(a => a.Value == serviceSongs[7].SongPosition.ToString());
                    vocalist8 = vocalistList.FindIndex(a => a.Value == serviceSongs[7].SongLeadUser.ToString());
                }

                ddlSongEight.DataSource = songList8;
                ddlSongEight.DataTextField = "Text";
                ddlSongEight.DataValueField = "Value";
                ddlSongEight.SelectedIndex = song8;
                ddlSongEight.DataBind();

                ddlSongEightPosition.DataSource = positionList8;
                ddlSongEightPosition.DataTextField = "Text";
                ddlSongEightPosition.DataValueField = "Value";
                ddlSongEightPosition.SelectedIndex = position8;
                ddlSongEightPosition.DataBind();

                ddlSongEightLead.DataSource = vocalistList8;
                ddlSongEightLead.DataTextField = "Text";
                ddlSongEightLead.DataValueField = "Value";
                ddlSongEightLead.SelectedIndex = vocalist8;
                ddlSongEightLead.DataBind();

                #endregion SongEight

                #region Vocalists

                for (int i = 3; i < vocalistList.Count; i++)
                {
                    var v = cdc.Users.FirstOrDefault(a => a.Id == Convert.ToInt32(vocalistList[i].Value));
                    if (Request.QueryString["id"] != null)
                    {
                        if (cdc.ServiceUnavailables.FirstOrDefault(a => a.ServiceId == svc.Id && a.UserId == Convert.ToInt32(vocalistList[i].Value)) != null)
                        {
                            chkVocalists.Items.Add(new ListItem() { Text = vocalistList[i].Text, Value = vocalistList[i].Value, Selected = false, Enabled = false });
                        }
                        else
                        {
                            var su = cdc.ServiceUsers.FirstOrDefault(a => a.ServiceId == Convert.ToInt32(Request.QueryString["id"]) && a.UserId == Convert.ToInt32(vocalistList[i].Value));
                            chkVocalists.Items.Add(new ListItem() { Text = vocalistList[i].Text, Value = vocalistList[i].Value, Selected = (su != null || v.UPrimary), Enabled = true });
                        }
                    }
                    else
                    {
                        chkVocalists.Items.Add(new ListItem() { Text = vocalistList[i].Text, Value = vocalistList[i].Value, Selected = v.UPrimary, Enabled = true });
                    }
                }

                #endregion Vocalists
                #region Musicians

                for (int i = 0; i < musicianList.Count; i++)
                {
                    var m = cdc.Users.FirstOrDefault(a => a.Id == Convert.ToInt32(musicianList[i].Value));
                    if (Request.QueryString["id"] != null)
                    {
                        if (cdc.ServiceUnavailables.FirstOrDefault(a => a.ServiceId == svc.Id && a.UserId == Convert.ToInt32(musicianList[i].Value)) != null)
                        {
                            chkMusicians.Items.Add(new ListItem() { Text = musicianList[i].Text, Value = musicianList[i].Value, Selected = false, Enabled = false });
                        }
                        else
                        {
                            var su = cdc.ServiceUsers.FirstOrDefault(a => a.ServiceId == Convert.ToInt32(Request.QueryString["id"]) && a.UserId == Convert.ToInt32(musicianList[i].Value));
                            chkMusicians.Items.Add(new ListItem() { Text = musicianList[i].Text, Value = musicianList[i].Value, Selected = (su != null || m.UPrimary), Enabled = true });
                        }
                    }
                    else
                    {
                        chkMusicians.Items.Add(new ListItem() { Text = musicianList[i].Text, Value = musicianList[i].Value, Selected = m.UPrimary, Enabled = true });
                    }
                }

                #endregion Musicians
                #region Technicians

                for (int i = 0; i < techList.Count; i++)
                {
                    var t = cdc.Users.FirstOrDefault(a => a.Id == Convert.ToInt32(techList[i].Value));
                    if (Request.QueryString["id"] != null)
                    {
                        if (cdc.ServiceUnavailables.FirstOrDefault(a => a.ServiceId == svc.Id && a.UserId == Convert.ToInt32(techList[i].Value)) != null)
                        {
                            chkTechnicians.Items.Add(new ListItem() { Text = techList[i].Text, Value = techList[i].Value, Selected = false, Enabled = false });
                        }
                        else
                        {
                            var su = cdc.ServiceUsers.FirstOrDefault(a => a.ServiceId == Convert.ToInt32(Request.QueryString["id"]) && a.UserId == Convert.ToInt32(techList[i].Value));
                            chkTechnicians.Items.Add(new ListItem() { Text = techList[i].Text, Value = techList[i].Value, Selected = (su != null || t.UPrimary), Enabled = true });
                        }
                    }
                    else
                    {
                        chkTechnicians.Items.Add(new ListItem() { Text = techList[i].Text, Value = techList[i].Value, Selected = t.UPrimary, Enabled = true });
                    }
                }

                #endregion Technicians
            }
            else
            {
                pnlForm.Visible = false;
                pnlResponse.Visible = true;
                pnlRedirect.Visible = false;

                var bValid = true;
                var sMsg = string.Empty;
                var sInfo = string.Empty;

                #region Service

                var s = new Service();
                if (Request.QueryString["id"] != null)
                {
                    s = cdc.Services.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    sMsg = "Updated";
                }
                else
                {
                    cdc.Services.InsertOnSubmit(s);
                    sMsg = "Added";
                }

                s.ServiceDate = Convert.ToDateTime(svcDate.Text + " " + svcTime.Text);
                s.ServiceTitle = svcTitle.Text;
                s.ServiceScripture = svcScripture.Text;
                if (fileBulletin.HasFile)
                {
                    try
                    {
                        var sBulletin = Path.GetFileName(fileBulletin.FileName).Replace(" ", "_");
                        fileBulletin.SaveAs(Server.MapPath("/content/bulletins/") + sBulletin);
                        s.ServicePDF = sBulletin;
                    }
                    catch (Exception ex)
                    {
                        lblResponse.Text += "The Bulletin could not be uploaded. The following error occured: " + ex.Message;
                        bValid = false;
                    }
                }

                s.ServiceNotes = svcNotes.Text;
                s.Baptism = radYBaptism.Checked;
                s.Communion = radYCommunion.Checked;
                s.Rehearsal = radYRehearsal.Checked;
                s.ChurchId = Convert.ToInt32(Session["churchid"]);
                cdc.SubmitChanges();

                var nServ = cdc.Services.FirstOrDefault(a => a.ServiceDate == Convert.ToDateTime(svcDate.Text + " " + svcTime.Text));
                var nServId = nServ.Id;

                #endregion Service
                #region Songs
                List<ServiceSong> ServiceSongs = new List<ServiceSong>();

                var ssList = cdc.ServiceSongs.Where(a => a.ServiceId == nServId);
                cdc.ServiceSongs.DeleteAllOnSubmit(ssList);
                cdc.SubmitChanges();

                #region SongOne
                for (var i = 0; i < ddlSongOne.Items.Count; i++)
                {
                    if (ddlSongOne.Items[i].Value != "0" && ddlSongOne.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongOne.Items[i].Value);
                        for (var p = 0; p < ddlSongOnePosition.Items.Count; p++)
                        {
                            if (ddlSongOnePosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongOnePosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongOneLead.Items.Count; l++)
                        {
                            if (ddlSongOneLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongOneLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongTwo
                for (var i = 0; i < ddlSongTwo.Items.Count; i++)
                {
                    if (ddlSongTwo.Items[i].Value != "0" && ddlSongTwo.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongTwo.Items[i].Value);
                        for (var p = 0; p < ddlSongTwoPosition.Items.Count; p++)
                        {
                            if (ddlSongTwoPosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongTwoPosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongTwoLead.Items.Count; l++)
                        {
                            if (ddlSongTwoLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongTwoLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongThree
                for (var i = 0; i < ddlSongThree.Items.Count; i++)
                {
                    if (ddlSongThree.Items[i].Value != "0" && ddlSongThree.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongThree.Items[i].Value);
                        for (var p = 0; p < ddlSongThreePosition.Items.Count; p++)
                        {
                            if (ddlSongThreePosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongThreePosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongThreeLead.Items.Count; l++)
                        {
                            if (ddlSongThreeLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongThreeLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongFour
                for (var i = 0; i < ddlSongFour.Items.Count; i++)
                {
                    if (ddlSongFour.Items[i].Value != "0" && ddlSongFour.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongFour.Items[i].Value);
                        for (var p = 0; p < ddlSongFourPosition.Items.Count; p++)
                        {
                            if (ddlSongFourPosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongFourPosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongFourLead.Items.Count; l++)
                        {
                            if (ddlSongFourLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongFourLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongFive
                for (var i = 0; i < ddlSongFive.Items.Count; i++)
                {
                    if (ddlSongFive.Items[i].Value != "0" && ddlSongFive.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongFive.Items[i].Value);
                        for (var p = 0; p < ddlSongFivePosition.Items.Count; p++)
                        {
                            if (ddlSongFivePosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongFivePosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongFiveLead.Items.Count; l++)
                        {
                            if (ddlSongFiveLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongFiveLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongSix
                for (var i = 0; i < ddlSongSix.Items.Count; i++)
                {
                    if (ddlSongSix.Items[i].Value != "0" && ddlSongSix.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongSix.Items[i].Value);
                        for (var p = 0; p < ddlSongSixPosition.Items.Count; p++)
                        {
                            if (ddlSongSixPosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongSixPosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongSixLead.Items.Count; l++)
                        {
                            if (ddlSongSixLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongSixLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongSeven
                for (var i = 0; i < ddlSongSeven.Items.Count; i++)
                {
                    if (ddlSongSeven.Items[i].Value != "0" && ddlSongSeven.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongSeven.Items[i].Value);
                        for (var p = 0; p < ddlSongSevenPosition.Items.Count; p++)
                        {
                            if (ddlSongSevenPosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongSevenPosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongSevenLead.Items.Count; l++)
                        {
                            if (ddlSongSevenLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongSevenLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion
                #region SongEight
                for (var i = 0; i < ddlSongEight.Items.Count; i++)
                {
                    if (ddlSongEight.Items[i].Value != "0" && ddlSongEight.Items[i].Selected)
                    {
                        var ss = new ServiceSong();
                        ss.ServiceId = nServId;
                        ss.SongId = Convert.ToInt32(ddlSongEight.Items[i].Value);
                        for (var p = 0; p < ddlSongEightPosition.Items.Count; p++)
                        {
                            if (ddlSongEightPosition.Items[p].Selected)
                            {
                                ss.SongPosition = ddlSongEightPosition.Items[p].Text;
                            }
                        }

                        for (var l = 0; l < ddlSongEightLead.Items.Count; l++)
                        {
                            if (ddlSongEightLead.Items[l].Selected)
                            {
                                ss.SongLeadUser = Convert.ToInt32(ddlSongEightLead.Items[l].Value);
                            }
                        }

                        ServiceSongs.Add(ss);
                    }
                }
                #endregion

                foreach (ServiceSong ss in ServiceSongs)
                {
                    cdc.ServiceSongs.InsertOnSubmit(ss);
                    cdc.SubmitChanges();
                }

                #endregion Songs
                #region Users

                var suList = cdc.ServiceUsers.Where(a => a.ServiceId == nServId);
                cdc.ServiceUsers.DeleteAllOnSubmit(suList);
                cdc.SubmitChanges();

                #region Vocalists

                for (var i = 0; i < chkVocalists.Items.Count; i++)
                {
                    if (chkVocalists.Items[i].Selected)
                    {
                        var snUser = new ServiceUser();
                        snUser.ServiceId = nServId;
                        snUser.UserId = Convert.ToInt32(chkVocalists.Items[i].Value);
                        cdc.ServiceUsers.InsertOnSubmit(snUser);
                        cdc.SubmitChanges();
                    }
                }

                #endregion Vocalists
                #region Musicians

                for (var i = 0; i < chkMusicians.Items.Count; i++)
                {
                    if (chkMusicians.Items[i].Selected)
                    {
                        var snUser = new ServiceUser();
                        snUser.ServiceId = nServId;
                        snUser.UserId = Convert.ToInt32(chkMusicians.Items[i].Value);
                        cdc.ServiceUsers.InsertOnSubmit(snUser);
                        cdc.SubmitChanges();
                    }
                }

                #endregion Musicians
                #region Technicians

                for (var i = 0; i < chkTechnicians.Items.Count; i++)
                {
                    if (chkTechnicians.Items[i].Selected)
                    {
                        var snUser = new ServiceUser();
                        snUser.ServiceId = nServId;
                        snUser.UserId = Convert.ToInt32(chkTechnicians.Items[i].Value);
                        cdc.ServiceUsers.InsertOnSubmit(snUser);
                        cdc.SubmitChanges();
                    }
                }

                #endregion Technicians

                var sueList = cdc.ServiceUsers.Where(a => a.ServiceId == nServId).Select(a => a.UserId).ToList();
                sueList.Add(16);
                sueList.Add(22);
                sueList.Add(27);

                #endregion Users

                if (bValid)
                {
                    var sResp = "<strong>" + svcTitle.Text + " has been " + sMsg + "</strong>";

                    #region Submission

                    if (hdnAction.Value.ToLower() == "submit")
                    {
                        sResp += "<div>The service has been sent as well</div>";

                        List<string> emailList = new List<string>();
                        foreach (var mem in sueList)
                        {
                            User u = cdc.Users.FirstOrDefault(a => a.Id == mem);
                            if (u != null && !string.IsNullOrEmpty(u.Email))
                            {
                                emailList.Add(u.Email + "|" + u.FName + " " + u.LName);
                            }
                        }

                        sInfo += "<table style='width: 100%'>";
                        sInfo += "<tr>";
                        sInfo += "  <td valign='top'><img src='http://crossroads.ssjhost.com/content/images/umc-logo.gif' width='75' hspace='20'></td>";
                        sInfo += "  <td valign='top'>";
                        sInfo += "    <p class='messageTitle'>Website Submission</p>";
                        sInfo += "    <strong>Service Date: </strong> " + Convert.ToDateTime(svcDate.Text + " " + svcTime.Text) + "<br />";
                        sInfo += "    <strong>Service Title: </strong> " + svcTitle.Text + "<br />";
                        sInfo += "    <strong>Service Scripture: </strong> " + svcScripture.Text + "<br />";
                        if (svcNotes != null & svcNotes.Text != "")
                        {
                            sInfo += "<strong>Service Notes: </strong><i>" + svcNotes.Text + "</i><br />";
                        }
                        sInfo += "  </td>";
                        sInfo += "</tr>";
                        sInfo += "</table>";
                        sInfo += "<br />";
                        sInfo += "<table style='width: 100%'>";
                        sInfo += "<tr style='background-color: #CCC'>";
                        sInfo += "  <th style='width: 30%'>Song Position</th>";
                        sInfo += "  <th style='width: 30%'>Song Title</th>";
                        sInfo += "  <th style='width: 10%'>Song Lead</th>";
                        sInfo += "  <th style='width: 10%'>Mp3</th>";
                        sInfo += "  <th style='width: 10%'>Sheet</th>";
                        sInfo += "  <th style='width: 10%'>Track</th>";
                        sInfo += "<tr>";

                        User lead;
                        Song song;
                        foreach (ServiceSong ss in ServiceSongs)
                        {
                            song = cdc.Songs.FirstOrDefault(a => a.Id == ss.SongId);
                            lead = cdc.Users.FirstOrDefault(a => a.Id == ss.SongLeadUser);

                            sInfo += "<tr>";
                            sInfo += "  <td style='width: 30%'>" + ss.SongPosition + "</td>";
                            sInfo += "  <td style='width: 30%'>" + song.Title + "</td>";
                            sInfo += "  <td style='width: 10%'>" + ((ss.SongLeadUser != null && ss.SongLeadUser != 0) ? lead.FName + " " + lead.LName : "Everyone") + "</td>";
                            sInfo += "  <td style='width: 10%; text-align: center'>" + ((song.MP3 != null) ? "<a href='http://crossroads.ssjhost.com/content/songs/mp3s/" + song.MP3 + "'>Play</a>" : "&nbsp;") + "</td>";
                            sInfo += "  <td style='width: 10%; text-align: center'>" + ((song.PDF != null) ? "<a href='http://crossroads.ssjhost.com/content/songs/pdfs/" + song.PDF + "'>View</a>" : "&nbsp;") + "</td>";
                            sInfo += "  <td style='width: 10%; text-align: center'>" + ((song.Track != null) ? "<a href='http://crossroads.ssjhost.com/content/songs/tracks/" + song.Track + "'>Play</a>" : "&nbsp;") + "</td>";
                            sInfo += "</tr>";
                            if (song.Notes != null)
                            {
                                sInfo += "<tr><td colspan='5'><i>" + song.Notes + "</i><br /><br /></td></tr>";
                            }
                        }

                        sInfo += "</table>";

                        sResp += "<div style='font-weight: bolder; margin: 20px 0px 2px'>Recipients</div>";
                        foreach (var em in emailList)
                        {
                            sResp += "<div style='margin: 0px 10px'>" + em.Substring(em.IndexOf("|") + 1) + "</div>";
                            ssjutils.SendEmail(ConfigurationManager.AppSettings["adminEmail"], em.Substring(0, em.IndexOf("|")), "Upcoming Service Lineup: " + Convert.ToDateTime(svcDate.Text + " " + svcTime.Text), sInfo);
                        }
                    }

                    #endregion Submission

                    lblResponse.Text = sResp;
                    pnlRedirect.Visible = true;
                }
            }
        }

        static void SetupElements(int cid, crossroadsDataContext cdc,
            out List<ListItem> songList,
            out List<ListItem> vocalistList,
            out List<ListItem> musicianList,
            out List<ListItem> techList,
            out List<ListItem> positionList)
        {
            songList = cdc.Songs
                .Where(a => a.ChurchId == cid)
                .OrderBy(a => a.Title)
                .Select(a => new ListItem { Text = a.Title + (a.Artist != null ? " - " + a.Artist : ""), Value = a.Id.ToString() })
                .ToList();
            songList.Insert(0, new ListItem { Text = "Choose a Song", Value = "0" });

            vocalistList = cdc.Users
                .Where(a => a.ChurchId == cid)
                .Where(a => a.UType == "V")
                .Where(a => a.UStatus == "A")
                .OrderByDescending(a => a.UPrimary)
                .ThenBy(a => a.FName)
                .ThenBy(a => a.LName)
                .Select(a => new ListItem { Text = a.FName + " " + a.LName, Value = a.Id.ToString() })
                .ToList();
            vocalistList.Insert(0, new ListItem { Text = "Everyone", Value = "0" });
            vocalistList.Insert(1, new ListItem { Text = "Donny Arcuri", Value = "3" });
            vocalistList.Insert(2, new ListItem { Text = "Helen Collins", Value = "6" });

            musicianList = cdc.Users
                .Where(a => a.ChurchId == cid)
                .Where(a => a.UType == "M")
                .Where(a => a.UStatus == "A")
                .OrderByDescending(a => a.UPrimary)
                .ThenBy(a => a.FName)
                .ThenBy(a => a.LName)
                .Select(a => new ListItem { Text = a.FName + " " + a.LName, Value = a.Id.ToString() })
                .ToList();

            techList = cdc.Users
                .Where(a => a.ChurchId == cid)
                .Where(a => a.UType == "T")
                .Where(a => a.UStatus == "A")
                .OrderByDescending(a => a.UPrimary)
                .ThenBy(a => a.FName)
                .ThenBy(a => a.LName)
                .Select(a => new ListItem { Text = a.FName + " " + a.LName, Value = a.Id.ToString() })
                .ToList();

            positionList = new List<ListItem>();
            positionList.Add(new ListItem { Text = "Opening Song", Value = "Opening Song" });
            positionList.Add(new ListItem { Text = "Singing Together", Value = "Singing Together" });
            positionList.Add(new ListItem { Text = "Offertory Song", Value = "Offertory Song" });
            positionList.Add(new ListItem { Text = "Communion Song", Value = "Communion Song" });
            positionList.Add(new ListItem { Text = "Closing Song", Value = "Closing Song" });
            positionList.Add(new ListItem { Text = "Special Music", Value = "Special Music" });
        }
    }
}