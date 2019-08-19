using Crossroads.database;
using Crossroads.utilities;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class availabilityupdate : System.Web.UI.Page
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
            pnlResponse.Visible = false;
            pnlError.Visible = false;

            var Services = cdc.Services.Where(a => a.ChurchId == Convert.ToInt32(Session["churchid"])).Where(a => a.ServiceDate > DateTime.Now).OrderBy(a => a.ServiceDate).ToList();
            if (!Page.IsPostBack)
            {
                sb.AppendLine("<table class='availabilitUpdateTable' rules='rows'>");
                sb.AppendLine("<thead class='availabilitUpdateTableHeader'>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <th class='col-xs-3 col-sm-2 col-md-2 col-lg-2 text-center'>Available</th>");
                sb.AppendLine("    <th class='col-xs-5 col-sm-2 col-md-3 col-lg-2'>Service Date</th>");
                sb.AppendLine("    <th class='hidden-xs hidden-sm hidden-md col-lg-1'></th>");
                sb.AppendLine("    <th class='hidden-xs col-sm-3 col-md-3 col-lg-2'>Service Title</th>");
                sb.AppendLine("    <th class='col-xs-4 col-sm-3 col-md-4 col-lg-5'>Notes</th>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody class='availabilitUpdateTableBody'>");
                foreach (var service in Services)
                {
                    var uUser = cdc.ServiceUnavailables.FirstOrDefault(a => a.ServiceId == service.Id && a.UserId == Convert.ToInt32(Session["uid"]));
                    sb.AppendLine("<tr>");
                    sb.AppendLine("  <td class='col-xs-3 col-sm-2 col-md-2 col-lg-2 text-center'>");
                    if (uUser != null)
                    {
                        sb.AppendLine("  <label><input type='radio' name='SVC-" + service.Id + "' value='A' runat='server'>&nbsp;Yes</label>");
                        sb.AppendLine("  &nbsp; &nbsp; &nbsp;");
                        sb.AppendLine("  <label><input type='radio' name='SVC-" + service.Id + "' checked='checked' value='U' runat='server'>&nbsp;No</label>");
                    }
                    else
                    {
                        sb.AppendLine("  <label><input type='radio' name='SVC-" + service.Id + "' checked='checked' value='A' runat='server'>&nbsp;Yes</label>");
                        sb.AppendLine("  &nbsp; &nbsp; &nbsp;");
                        sb.AppendLine("  <label><input type='radio' name='SVC-" + service.Id + "' value='U' runat='server'>&nbsp;No</label>");
                    }

                    sb.AppendLine("  </td>");
                    sb.AppendLine("  <td class='col-xs-5 col-sm-2 col-md-3 col-lg-2'>" + service.ServiceDate.ToString("MMM dd, yyyy @ HH:mm tt") + "</td>");
                    sb.AppendLine("  <td class='hidden-xs hidden-sm hidden-md col-lg-1'>" + service.ServiceDate.ToString("dddd") + "</td>");
                    sb.AppendLine("  <td class='hidden-xs col-sm-3 col-md-3 col-lg-2'>" + service.ServiceTitle + "</td>");
                    sb.AppendLine("  <td class='col-xs-4 col-sm-3 col-md-4 col-lg-5'>");
                    sb.AppendLine("    <input type='text' name='txtNote-" + service.Id + "' maxlength='500' placeholder='Enter any notes' style='padding-left: 5px; width: 100%' value='" + ((uUser == null) ? "" : uUser.Notes) + "'>");
                    sb.AppendLine("  </td>");
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
                ltlAvailabilityUpdate.Text = sb.ToString();
            }
            else
            {
                var bNotify = false;

                var sInfo = string.Empty;
                sInfo += "<table>";
                sInfo += "<tr>";
                sInfo += "  <td valign='top'><img src='http://crossroads.ssjhost.com/content/images/umc-logo.gif' width='75' hspace='10'></td>";
                sInfo += "  <td valign='top'>";
                sInfo += "    <div class='messageTitle'>Service Unavailability</div>";
                sInfo += "    <div class='margin-5'>" + Session["fullname"].ToString() + ", would like to let everyone know that they are NOT available for the following services.</div>";
                sInfo += "    <div class='padding-20'>";
                foreach (var service in Services)
                {
                    if (Request.Form["SVC-" + service.Id] != null)
                    {
                        // Remove all records form ServiceUsers and ServiceUnavailables for this user.
                        var AUser = cdc.ServiceUsers.FirstOrDefault(a => a.ServiceId == service.Id && a.UserId == Convert.ToInt32(Session["uid"]));
                        if (AUser != null)
                        {
                            cdc.ServiceUsers.DeleteOnSubmit(AUser);
                        }

                        var UUser = cdc.ServiceUnavailables.FirstOrDefault(a => a.ServiceId == service.Id && a.UserId == Convert.ToInt32(Session["uid"]));
                        if (UUser != null)
                        {
                            cdc.ServiceUnavailables.DeleteOnSubmit(UUser);
                        }

                        if (Request.Form["SVC-" + service.Id] == "A")
                        {
                            cdc.ServiceUsers.InsertOnSubmit(new ServiceUser { ServiceId = service.Id, UserId = Convert.ToInt32(Session["uid"]) });
                        }
                        else
                        {
                            bNotify = true;
                            cdc.ServiceUnavailables.InsertOnSubmit(new ServiceUnavailable
                            {
                                ServiceId = service.Id,
                                UserId = Convert.ToInt32(Session["uid"]),
                                Notes = Request.Form["txtNote-" + service.Id].Replace("'", "")
                            });

                            sInfo += "Service Date: " + service.ServiceDate.ToString("MMMM dd, yyyy @ HH:mm tt");
                            if (Request.Form["txtNote-" + service.Id] != "")
                            {
                                sInfo += "<div class='margin-5'>" + Request.Form["txtNote-" + service.Id].Replace("'", "") + "</div>";
                            }
                            sInfo += "<div style='clear: both'></div>";
                        }

                        cdc.SubmitChanges();
                    }
                }

                sInfo += "    </div>";
                sInfo += "  </td>";
                sInfo += "</tr>";
                sInfo += "</table>";

                availabilityUpdateText.Visible = false;
                availabilityUpdateListing.Visible = false;
                pnlResponse.Visible = false;
                pnlError.Visible = false;

                if (bNotify)
                {
                    var users = cdc.Users.Where(a => a.UType == "V" || a.UType == "M" || a.UType == "T" || a.UType == "S").ToList();
                    foreach (var user in users)
                    {
                        if (ssjutils.SendEmail(ConfigurationManager.AppSettings["adminEmail"], user.Email, "Church Service Availability", sInfo))
                        {
                            pnlResponse.Visible = true;
                        }
                        else
                        {
                            pnlError.Visible = true;
                        }
                    }
                }
                else
                {
                    pnlResponse.Visible = true;
                }
            }
        }
    }
}