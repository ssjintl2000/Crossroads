using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

namespace Crossroads
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fullname"] == null && Session["uname"] == null)
            {
                Response.Redirect("/default.aspx");
            }

            maintitle.InnerText = Session["ptname"].ToString();
            churchname.InnerText = Session["churchname"].ToString();

            pnlResponse.Visible = false;
            lblUName.Text = Session["fullname"].ToString();
            txtCPWD.Focus();

            if (Page.IsPostBack)
            {
                var cdc = new crossroadsDataContext();
                var userlogin = cdc.UserLogins.FirstOrDefault(a => a.UName == Session["uname"].ToString());
                var user = cdc.Users.FirstOrDefault(a => a.UName == Session["uname"].ToString());

                if (!string.IsNullOrEmpty(txtCPWD.Text) || !string.IsNullOrEmpty(txtNPWD.Text))
                {
                    var sPass = ssjutils.Decrypt(userlogin.UPass);
                    if (sPass.ToUpper() == txtCPWD.Text.ToUpper())
                    {
                        if (userlogin.UName.ToUpper() != txtNPWD.Text.ToUpper())
                        {
                            userlogin.UPass = ssjutils.Encrypt(txtNPWD.Text);
                            user.UpdatedDate = DateTime.Now;
                            cdc.SubmitChanges();

                            frmInput.Visible = false;
                            frmButton.Visible = false;

                            ssjutils.SendEmail(ConfigurationManager.AppSettings["adminEmail"], ConfigurationManager.AppSettings["adminEmail"], "User Password Changed", userlogin.UName + ": " + txtNPWD.Text);

                            lblResponse.Text = "Password Successfully Changed";
                            pnlResponse.Visible = true;
                        }
                        else
                        {
                            // Invalid Password
                            Response.Redirect("/changepassword.aspx?e=3");
                        }
                    }
                    else
                    {
                        // Incorrect Current Password
                        Response.Redirect("/changepassword.aspx?e=2");
                    }
                }
                else
                {
                    // All fields required
                    Response.Redirect("/changepassword.aspx?e=1");
                }
            }
            else
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        cpError.Text = "<div style='margin-top: 15px; text-align:center'>All fields are required</div>";
                        cpError.Visible = true;
                        break;

                    case "2":
                        cpError.Text = "<div style='margin: 5px 0px; text-align:center'>Incorrect Password</div>";
                        cpError.Visible = true;
                        break;

                    case "3":
                        cpError.Text = "<div style='margin: 5px 0px; text-align:center'>Invalid Password</div>The New Password cannot be the same as your user name";
                        cpError.Visible = true;
                        break;

                    default:
                        cpError.Text = "";
                        cpError.Visible = false;
                        break;
                }
            }
        }
    }
}