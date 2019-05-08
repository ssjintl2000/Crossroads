using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class availability : System.Web.UI.Page
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
            var sb = new StringBuilder();

            var services = cdc.Services.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).Where(a => a.ServiceDate > DateTime.Now).OrderBy(a => a.ServiceDate).ToList();
            foreach (var service in services)
            {
                sb.AppendLine("<div class='availabilityServiceDate'>" + Convert.ToDateTime(service.ServiceDate).ToString("MMMM dd, yyyy") + "</div>");
                sb.AppendLine("<table class='table availabilityServiceUsers'>");
                sb.AppendLine("<tbody>");

                var users = cdc.ServiceUnavailables.Where(a => a.ServiceId == service.Id).OrderBy(a => a.UserId).ToList();
                foreach (var user in users)
                {
                    var userDetails = cdc.Users.FirstOrDefault(a => a.Id == user.UserId);
                    var sType = string.Empty;
                    switch (userDetails.UType)
                    {
                        case "V":
                            sType = "Vocalist";
                            break;

                        case "M":
                            sType = "Musician";
                            break;

                        case "S":
                            sType = "Staff";
                            break;

                        case "T":
                            sType = "Technical";
                            break;
                    }

                    sb.AppendLine("  <tr>");
                    sb.AppendLine("    <td width='20%' nowrap><a href='mailto:" + userDetails.Email + "'>" + userDetails.FName + " " + userDetails.LName + "</a></td>");
                    sb.AppendLine("    <td width='20%' nowrap>" + sType + " / " + userDetails.UPosition + "</td>");
                    sb.AppendLine("    <td>" + user.Notes + "</td>");
                    sb.AppendLine("    <td width='15%' nowrap class='text-right'><a href='tel:" + userDetails.Phone + "'>(" + userDetails.Phone.Substring(0, 3) + ") " + userDetails.Phone.Substring(3, 3) + "-" + userDetails.Phone.Substring(6) + "</a></td>");
                    sb.AppendLine("  </tr>");
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
            }

            ltlAvailability.Text = sb.ToString();
        }
    }
}