using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class services : System.Web.UI.Page
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
            if (Session["seclevel"] != null && Convert.ToInt32(Session["SecLevel"]) > 1)
            {
                addService.Visible = true;
            }

            var futureServices = cdc.Services.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).Where(a => a.ServiceDate >= DateTime.Now).ToList();

            var sbs = new StringBuilder();
            sbs.AppendLine("<table class='table table-bordered serviceListing'>");
            sbs.AppendLine("<thead>");
            sbs.AppendLine("  <tr>");
            sbs.AppendLine("    <td></td>");
            sbs.AppendLine("    <td width='20%' class='text-center'>Sermon/Scripture</td>");
            sbs.AppendLine("    <td class='text-center'>Details</td>");
            sbs.AppendLine("  </tr>");
            sbs.AppendLine("</thead>");
            sbs.AppendLine("<tbody>");

            foreach (var service in futureServices.OrderBy(a => a.ServiceDate))
            {
                sbs.AppendLine("<tr>");
                sbs.AppendLine("<td class='text-center'>");
                if (Session["seclevel"] != null & Convert.ToInt32(Session["seclevel"]) > 1)
                {
                    sbs.Append("<a href='serviceDetails.aspx?id=" + service.Id + "'>Edit</a>");
                }
                else
                {
                    sbs.Append("&nbsp;");
                }

                sbs.AppendLine("</td>");
                sbs.AppendLine("<td>" + service.ServiceTitle + "<br />" + service.ServiceScripture + "</td>");
                sbs.AppendLine("<td>");
                sbs.Append("" + service.ServiceDate + "");
                if (!string.IsNullOrEmpty(service.ServicePDF))
                {
                    sbs.Append(" - <a href=Javascript:winOpen('/content/bulletins/" + service.ServicePDF + "','SHEET',0,0,1,1,0) target='_blank'>Bulletin</a>");
                }

                if (!string.IsNullOrEmpty(service.ServiceNotes))
                {
                    sbs.Append("<div class='note'>" + service.ServiceNotes + "</div>");
                }

                sbs.Append("<div>");
                if (service.Baptism)
                {
                    sbs.Append("<span class='label label-success'>Baptism</span>&nbsp;");
                }

                if (service.Communion)
                {
                    sbs.Append("<span class='label label-info'>Communion</span>&nbsp;");
                }

                if (service.Rehearsal)
                {
                    sbs.Append("<span class='label label-danger'>Rehearsal</span>&nbsp;");
                }

                sbs.Append("</div>");

                sbs.AppendLine("</td>");
                sbs.AppendLine("</tr>");
            }

            sbs.AppendLine("</tbody>");
            sbs.AppendLine("</table>");

            ltlServices.Text = sbs.ToString();
        }
    }
}