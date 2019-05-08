using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crossroads.master
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] != null)
            {
                logincontainer.Visible = false;

                mainmenu.Visible = true;
                menuServices.Visible = Convert.ToInt32(Session["seclevel"]) > 0;
                menuSongs.Visible = Convert.ToInt32(Session["seclevel"]) > 0;
                menuMembers.Visible = Convert.ToInt32(Session["seclevel"]) > 0;
                menuAvailability.Visible = Convert.ToInt32(Session["seclevel"]) > 0;
                menuWishList.Visible = Convert.ToInt32(Session["seclevel"]) > 0;
            }

            if (Request.Url.OriginalString.ToLower().Contains("changepassword.aspx"))
            {
                logincontainer.Visible = true;
            }
        }
    }
}