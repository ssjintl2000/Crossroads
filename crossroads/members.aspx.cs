using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] == null)
            {
                Response.Redirect("/default.aspx");
            }

            var sSecLevel = Session["seclevel"].ToString();
            var sUName = Session["uname"].ToString().ToLower();

            maintitle.InnerText = Session["ptname"].ToString();
            churchname.InnerText = Session["churchname"].ToString();

            var cdc = new crossroadsDataContext();
            if (sSecLevel != "5")
            {
                Response.Redirect("/memberdetails.aspx?id=" + Session["uid"].ToString());
            }

            #region Vocalists

            var vocalists = cdc.Users.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).Where(a => a.UType == "V").OrderBy(a => a.UStatus).ThenBy(a => a.FName).ThenBy(a => a.LName).ToList();

            var sbv = new StringBuilder();
            sbv.AppendLine("<table class='table memberListing'>");
            sbv.AppendLine("<thead>");
            sbv.AppendLine("  <tr>");
            sbv.AppendLine("    <td></td>");
            sbv.AppendLine("    <td>Name</td>");
            sbv.AppendLine("    <td>Position</td>");
            sbv.AppendLine("  </tr>");
            sbv.AppendLine("</thead>");
            sbv.AppendLine("<tbody>");
            foreach (User user in vocalists)
            {
                var lDate = cdc.UserLogins.FirstOrDefault(a => a.UName == user.UName);
                sbv.AppendLine("<tr class='" + ((user.UStatus == "A") ? "uActive" : "uInActive") + "'>");
                sbv.AppendLine("  <td>" + ((user.UPrimary) ? "**" : "") + "</td>");
                if (lDate != null)
                {
                    sbv.AppendLine("  <td title='Last Login: " + Convert.ToDateTime(lDate.LastLogin).ToString("f") + "'>");
                }
                else
                {
                    sbv.AppendLine("  <td>");
                }
                sbv.AppendLine("    <a href='memberdetails.aspx?id=" + user.Id + "'>" + user.FName + " " + user.LName + "</a>");
                sbv.AppendLine("  </td>");
                sbv.AppendLine("  <td>" + user.UPosition + "</td>");
                sbv.AppendLine("</tr>");
            }

            sbv.AppendLine("<tr><td colspan='3' class='note'>** Denotes this members as a Primary Member</td></tr>");
            sbv.AppendLine("</tbody>");
            sbv.AppendLine("</table>");

            ltlVocalists.Text = sbv.ToString();

            #endregion Vocalists

            #region Musicians

            var musicians = cdc.Users.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).Where(a => a.UType == "M").OrderBy(a => a.UStatus).ThenBy(a => a.FName).ThenBy(a => a.LName).ToList();

            var sbm = new StringBuilder();
            sbm.AppendLine("<table class='table memberListing'>");
            sbm.AppendLine("<thead>");
            sbm.AppendLine("  <tr>");
            sbm.AppendLine("    <td></td>");
            sbm.AppendLine("    <td>Name</td>");
            sbm.AppendLine("    <td>Position</td>");
            sbm.AppendLine("  </tr>");
            sbm.AppendLine("</thead>");
            sbm.AppendLine("<tbody>");
            foreach (User user in musicians)
            {
                var lDate = cdc.UserLogins.FirstOrDefault(a => a.UName == user.UName);
                sbm.AppendLine("<tr class='" + ((user.UStatus == "A") ? "uActive" : "uInActive") + "'>");
                sbm.AppendLine("  <td>" + ((user.UPrimary) ? "**" : "") + "</td>");
                if (lDate != null)
                {
                    sbm.AppendLine("  <td title='Last Login: " + Convert.ToDateTime(lDate.LastLogin).ToString("f") + "'>");
                }
                else
                {
                    sbm.AppendLine("  <td>");
                }
                sbm.AppendLine("    <a href='memberdetails.aspx?id=" + user.Id + "'>" + user.FName + " " + user.LName + "</a>");
                sbm.AppendLine("  </td>");
                sbm.AppendLine("  <td>" + user.UPosition + "</td>");
                sbm.AppendLine("</tr>");
            }

            sbm.AppendLine("<tr><td colspan='3' class='note'>** Denotes this members as a Primary Member</td></tr>");
            sbm.AppendLine("</tbody>");
            sbm.AppendLine("</table>");

            ltlMusicians.Text = sbm.ToString();

            #endregion Musicians

            #region Technical

            var technicians = cdc.Users.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).Where(a => a.UType == "T").OrderBy(a => a.UStatus).ThenBy(a => a.FName).ThenBy(a => a.LName).ToList();

            var sbt = new StringBuilder();
            sbt.AppendLine("<table class='table memberListing'>");
            sbt.AppendLine("<thead>");
            sbt.AppendLine("  <tr>");
            sbt.AppendLine("    <td></td>");
            sbt.AppendLine("    <td>Name</td>");
            sbt.AppendLine("    <td>Position</td>");
            sbt.AppendLine("  </tr>");
            sbt.AppendLine("</thead>");
            sbt.AppendLine("<tbody>");
            foreach (User user in technicians)
            {
                var lDate = cdc.UserLogins.FirstOrDefault(a => a.UName == user.UName);
                sbt.AppendLine("<tr class='" + ((user.UStatus == "A") ? "uActive" : "uInActive") + "'>");
                sbt.AppendLine("  <td>" + ((user.UPrimary) ? "**" : "") + "</td>");
                if (lDate != null)
                {
                    sbt.AppendLine("  <td title='Last Login: " + Convert.ToDateTime(lDate.LastLogin).ToString("f") + "'>");
                }
                else
                {
                    sbt.AppendLine("  <td>");
                }
                sbt.AppendLine("    <a href='memberdetails.aspx?id=" + user.Id + "'>" + user.FName + " " + user.LName + "</a>");
                sbt.AppendLine("  </td>");
                sbt.AppendLine("  <td>" + user.UPosition + "</td>");
                sbt.AppendLine("</tr>");
            }

            sbt.AppendLine("<tr><td colspan='3' class='note'>** Denotes this members as a Primary Member</td></tr>");
            sbt.AppendLine("</tbody>");
            sbt.AppendLine("</table>");

            ltlTechnicians.Text = sbt.ToString();

            #endregion Technical

            if (Session["seclevel"] != null & Convert.ToInt32(Session["seclevel"]) > 1)
            {
                memberContentActions.Visible = true;
            }
        }
    }
}