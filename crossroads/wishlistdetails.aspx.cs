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
                }
                else
                {
                    // Add New
                }

                pnlForm.Visible = true;
            }
            else
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    // Update
                }
                else
                {
                    // Add New
                }
            }
        }

    }
}