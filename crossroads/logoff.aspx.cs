using System;

namespace Crossroads
{
    public partial class logoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            maintitle.InnerText = Session["ptname"].ToString();
            churchname.InnerText = Session["churchname"].ToString();

            Session["authenticated"] = null;
            Session["uname"] = null;
            Session["useclevel"] = null;
            Session["fullname"] = null;
            Session["email"] = null;
            Session["uid"] = null;
            Session["curserviceid"] = null;
            Session["churchid"] = null;
            Session["churchname"] = null;
        }
    }
}