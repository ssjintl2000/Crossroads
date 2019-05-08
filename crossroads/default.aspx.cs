using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Web.UI;

namespace Crossroads
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            crossroadsDataContext cdc = new crossroadsDataContext();
            if (Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(txtUName.Text) && !string.IsNullOrEmpty(txtPWD.Text))
                {
                    UserLogin uUser = cdc.UserLogins.FirstOrDefault(a => a.UName == txtUName.Text);
                    if (uUser != null)
                    {
                        var sDePass = ssjutils.Decrypt(uUser.UPass);
                        if (sDePass == txtPWD.Text)
                        {
                            Session["uname"] = uUser.UName;
                            Session["seclevel"] = uUser.USecLevel;

                            User uUserData = cdc.Users.FirstOrDefault(a => a.UName == uUser.UName);
                            Church uChurch = cdc.Churches.FirstOrDefault(a => a.Id == uUserData.ChurchId);

                            Session["uid"] = uUserData.Id;
                            Session["fullname"] = uUserData.FName + " " + uUserData.LName;
                            Session["email"] = uUserData.Email;
                            Session["churchid"] = uChurch.Id;
                            Session["churchname"] = uChurch.CName;
                            Session["ptname"] = uChurch.PTName;

                            if (sDePass != uUser.UName)
                            {
                                Session["authenticated"] = true;
                                uUser.LastLogin = DateTime.Now;
                                cdc.SubmitChanges();
                                Response.Redirect("~/main.aspx");
                            }
                            else
                            {
                                // Must Change Password
                                Response.Redirect("~/changepassword.aspx");
                            }
                        }
                        else
                        {
                            // Incorrect Password
                            Response.Redirect("~/default.aspx?e=3");
                        }
                    }
                    else
                    {
                        // User Not Found
                        Response.Redirect("~/default.aspx?e=2");
                    }
                }
                else
                {
                    // All fields required
                    Response.Redirect("~/default.aspx?e=1");
                }
            }
            else
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        loginerror.Text = "All fields are required, Please try again...";
                        loginerror.Visible = true;
                        txtUName.Focus();
                        break;

                    case "2":
                        loginerror.Text = "UserName not found, Please try again...";
                        loginerror.Visible = true;
                        txtUName.Focus();
                        break;

                    case "3":
                        loginerror.Text = "Incorrect Password, Please try again...";
                        loginerror.Visible = true;
                        txtPWD.Focus();
                        break;

                    default:
                        loginerror.Text = "";
                        loginerror.Visible = false;
                        txtUName.Focus();
                        break;
                }
            }
        }
    }
}