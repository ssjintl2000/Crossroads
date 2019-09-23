using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class wishlist : System.Web.UI.Page
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
                addWishListItem.Visible = true;
            }

            var wishlistitems = cdc.SongsWishLists.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).OrderByDescending(a => a.DateRequested).ToList();

            var sbs = new StringBuilder();
            sbs.AppendLine("<table class='table table-condensed table-bordered wishlistitemListing'>");
            sbs.AppendLine("<thead>");
            sbs.AppendLine("  <tr>");
            sbs.AppendLine("    <td>&nbsp;</td>");
            sbs.AppendLine("    <td class='text-center' nowrap>&nbsp;Date Requested&nbsp;</td>");
            sbs.AppendLine("    <td class='text-center' nowrap>Status</td>");
            sbs.AppendLine("    <td class='text-center' nowrap>Title</td>");
            sbs.AppendLine("    <td class='text-center' nowrap>Artist</td>");
            sbs.AppendLine("    <td class='text-center' nowrap>Type</td>");
            sbs.AppendLine("    <td class='text-left' nowrap>Notes</td>");
            sbs.AppendLine("  </tr>");
            sbs.AppendLine("</thead>");
            sbs.AppendLine("<tbody>");

            foreach (var item in wishlistitems)
            {
                sbs.AppendLine("  <tr>");
                sbs.AppendLine("    <td class='text-center'><a href='wishlistdetails.aspx?id=" + item.Id + "'>Edit</a></td>");
                sbs.AppendLine("    <td class='text-center' nowrap>" + item.DateRequested.ToShortDateString() + "</td>");
                sbs.AppendLine("    <td class='text-center' nowrap>&nbsp;" + ((item.Status.ToString() == "A") ? "<span style='color:#900'>Active</span>" : "<span style='color:#777'>Inactive</span>") + "&nbsp;</td>");
                sbs.AppendLine("    <td class='text-left' nowrap><a href='" + item.Link + "' target='_blank'>" + item.Title + "</a></td>");
                sbs.AppendLine("    <td class='text-left' nowrap>" + item.Artist + "</td>");
                sbs.AppendLine("    <td class='text-center " + item.PType + "'>" + item.PType + "</td>");
                sbs.AppendLine("    <td class='text-left'>" + item.Notes + "</td>");
                sbs.AppendLine("  </tr>");
            }

            sbs.AppendLine("</tbody>");
            sbs.AppendLine("</table>");

            ltlWishList.Text = sbs.ToString();
        }
    }
}