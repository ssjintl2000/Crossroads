using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class wishlistdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] == null && Convert.ToInt32(Session["seclevel"]) < 2) { Response.Redirect("/default.aspx"); }

            lblResponse.Text = "";
            pnlForm.Visible = false;
            pnlResponse.Visible = false;

            maintitle.InnerText = Session["ptname"].ToString();
            churchname.InnerText = Session["churchname"].ToString();

            var cdc = new crossroadsDataContext();

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    // Load Existing
                    var item = cdc.SongsWishLists.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    inputTitle.Value = item.Title;
                    inputArtist.Value = item.Artist;
                    switch (item.PType)
                    {
                        case "F":
                            inputSongType.SelectedIndex = 2;
                            break;
                        case "M":
                            inputSongType.SelectedIndex = 1;
                            break;
                        default:
                            inputSongType.SelectedIndex = 0;
                            break;
                    }
                    switch (item.Status)
                    {
                        case "A":
                            inputStatus.SelectedIndex = 1;
                            break;
                        default:
                            inputStatus.SelectedIndex = 0;
                            break;
                    }
                    inputURL.Value = item.Link;
                    inputNotes.Value = item.Notes;
                }

                pnlForm.Visible = true;
                inputTitle.Focus();
            }
            else
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    // Update
                    var item = cdc.SongsWishLists.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));

                    item.Title = inputTitle.Value;
                    item.Artist = inputArtist.Value;
                    item.PType = inputSongType.Value;
                    item.Link = inputURL.Value;
                    item.Notes = inputNotes.Value;
                    item.Status = inputStatus.Value;
                    
                    cdc.SubmitChanges();
                    lblResponse.Text = "Item Updated";
                }
                else
                {
                    // Add New

                    var newItem = new SongsWishList();
                    newItem.Title = inputTitle.Value;
                    newItem.Artist = inputArtist.Value;
                    newItem.PType = inputSongType.Value;
                    newItem.Link = inputURL.Value;
                    newItem.Notes = inputNotes.Value;
                    newItem.Status = inputStatus.Value;
                    newItem.DateRequested = DateTime.Now;
                    newItem.ChurchId = Convert.ToInt32(Session["churchid"]);
                    newItem.Requestor = Session["fullname"].ToString();

                    cdc.SongsWishLists.InsertOnSubmit(newItem);
                    cdc.SubmitChanges();

                    lblResponse.Text = "Item Added";
                }

                pnlResponse.Visible = true;
            }
        }

    }
}