using Crossroads.database;
using Crossroads.utilities;

using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Crossroads
{
    public partial class memberdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] == null && Convert.ToInt32(Session["seclevel"]) < 2) { Response.Redirect("/default.aspx"); }

            pnlForm.Visible = false;
            pnlResponse.Visible = false;

            maintitle.InnerText = Session["ptname"].ToString();
            churchname.InnerText = Session["churchname"].ToString();

            var cdc = new crossroadsDataContext();

            LoadStates();

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    // Load Existing

                    #region Load Existing

                    var member = cdc.Users.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    memberFormHeader.InnerText = member.FName + " " + member.LName;
                    if (Session["seclevel"].ToString() == "5")
                    {
                        UserLogin ULogin = cdc.UserLogins.FirstOrDefault(a => a.UName.ToLower() == member.UName.ToLower());
                        memberFormHeader.InnerText += " - (U:" + member.UName + " | P:" + ssjutils.Decrypt(ULogin.UPass) + ")";
                        selectSecurity.Disabled = false;
                    }

                    if (member.UName.ToLower() == Session["uname"].ToString().ToLower()) { lnkChangePassword.Visible = true; }

                    inputFName.Value = member.FName;
                    inputLName.Value = member.LName;
                    inputAddress.Value = member.Address;
                    inputCity.Value = member.City;
                    selectState.Items.FindByValue(member.State).Selected = true;
                    inputZipCode.Value = member.ZipCode;
                    inputPhone.Value = member.Phone;
                    inputEmail.Value = member.Email;
                    inputPosition.Value = member.UPosition;
                    if (member.UStatus == "A") { selectStatus.SelectedIndex = 0; } else { selectStatus.SelectedIndex = 1; }
                    if (member.UGender == "M") { selectGender.SelectedIndex = 0; } else { selectGender.SelectedIndex = 1; }
                    if (member.UPrimary) { selectPrimary.SelectedIndex = 0; } else { selectPrimary.SelectedIndex = 1; }
                    if (member.UVocalist) { selectVocalist.SelectedIndex = 1; } else { selectVocalist.SelectedIndex = 0; }
                    switch (member.UType)
                    {
                        case "V":
                            selectType.SelectedIndex = 1;
                            break;

                        case "M":
                            selectType.SelectedIndex = 2;
                            break;

                        case "T":
                            selectType.SelectedIndex = 3;
                            break;

                        case "S":
                            selectType.SelectedIndex = 4;
                            break;
                    }

                    var memberlogin = cdc.UserLogins.FirstOrDefault(a => a.UName == member.UName);
                    switch (memberlogin.USecLevel)
                    {
                        case 0:
                            selectSecurity.SelectedIndex = 1;
                            break;

                        case 1:
                            selectSecurity.SelectedIndex = 0;
                            break;

                        case 5:
                            selectSecurity.SelectedIndex = 2;
                            break;
                    }
                    #endregion Load Existing
                }
                else
                {
                    // Add New
                    memberFormHeader.InnerText = "Add New Member";
                    memberFormHeader.InnerText.ToUpper();
                    selectState.Items.FindByValue("CO").Selected = true;
                }

                inputFName.Focus();
                pnlForm.Visible = true;
            }
            else
            {
                var sUName = "";
                var sInfo = "";

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    // Update

                    #region Update

                    var member = cdc.Users.FirstOrDefault(a => a.Id == Convert.ToInt32(Request.QueryString["id"]));
                    sUName = member.UName;

                    member.FName = inputFName.Value;
                    member.LName = inputLName.Value;
                    member.Address = inputAddress.Value;
                    member.City = inputCity.Value;
                    member.State = selectState.Value;
                    member.ZipCode = inputZipCode.Value;
                    member.Phone = inputPhone.Value;
                    member.Email = inputEmail.Value;
                    member.UPosition = inputPosition.Value;
                    member.UGender = selectGender.Value;
                    member.UPrimary = selectPrimary.Value == "Y" ? true : false;
                    member.UVocalist = selectVocalist.Value == "Y" ? true : false;
                    member.UType = selectType.Value;
                    member.UStatus = selectStatus.Value;
                    member.UpdatedDate = DateTime.Now;

                    var memberlogin = cdc.UserLogins.FirstOrDefault(a => a.UName == sUName);
                    memberlogin.USecLevel = Convert.ToInt32(selectSecurity.Value);

                    cdc.SubmitChanges();

                    sInfo += "<table>";
                    sInfo += "<tr>";
                    sInfo += "  <td valign='top'><img src='http://crossroads.ssjhost.com/content/images/umc-logo.gif' width='75' hspace='10'></td>";
                    sInfo += "  <td valign='top'>";
                    sInfo += "    <div class='messageTitle'>Website Update</div>";
                    sInfo += "    <div class='margin-5'>" + Session["FullName"].ToString() + ", has edited an existing user (" + inputFName.Value + " " + inputLName.Value + ") within the website.</div>";
                    sInfo += "    <div class='padding-20'>";
                    sInfo += "    </div>";
                    sInfo += "  </td>";
                    sInfo += "</tr>";
                    sInfo += "</table>";

                    #endregion Update
                }
                else
                {
                    // Add New

                    #region Add New

                    sUName = inputFName.Value.Substring(0, 1) + inputLName.Value;

                    var newuser = new User();
                    newuser.UName = sUName.ToLower();
                    newuser.FName = inputFName.Value;
                    newuser.LName = inputLName.Value;
                    newuser.Address = inputAddress.Value;
                    newuser.City = inputCity.Value;
                    newuser.State = selectState.Value;
                    newuser.ZipCode = inputZipCode.Value;
                    newuser.Phone = inputPhone.Value;
                    newuser.Email = inputEmail.Value;
                    newuser.UPosition = inputPosition.Value;
                    newuser.UGender = selectGender.Value;
                    newuser.UPrimary = selectPrimary.Value == "Y" ? true : false;
                    newuser.UVocalist = selectVocalist.Value == "Y" ? true : false;
                    newuser.UType = selectType.Value;
                    newuser.UStatus = selectStatus.Value;
                    newuser.UpdatedDate = DateTime.Now;
                    newuser.CreatedDate = DateTime.Now;
                    newuser.ChurchId = Convert.ToInt32(Session["churchid"]);
                    cdc.Users.InsertOnSubmit(newuser);
                    cdc.SubmitChanges();

                    var newlogin = new UserLogin();
                    newlogin.UName = sUName.ToLower();
                    newlogin.UPass = ssjutils.Encrypt(sUName.ToLower());
                    newlogin.USecLevel = Convert.ToInt32(selectSecurity.Value);
                    cdc.UserLogins.InsertOnSubmit(newlogin);
                    cdc.SubmitChanges();

                    sInfo += "<table>";
                    sInfo += "<tr>";
                    sInfo += "  <td valign='top'><img src='http://crossroads.ssjhost.com/content/images/umc-logo.gif' width='75' hspace='10'></td>";
                    sInfo += "  <td valign='top'>";
                    sInfo += "    <div class='messageTitle'>Website Update</div>";
                    sInfo += "    <div class='margin-5'>" + Session["FullName"].ToString() + ", has added a new user (" + inputFName.Value + " " + inputLName.Value + ") to the website.</div>";
                    sInfo += "    <div class='padding-20'>";
                    sInfo += "    </div>";
                    sInfo += "  </td>";
                    sInfo += "</tr>";
                    sInfo += "</table>";

                    #endregion Add New
                }

                var userlogins = cdc.UserLogins.Where(a => a.USecLevel == 5).ToList();
                string sRec = "";
                foreach (var user in userlogins)
                {
                    if (ssjutils.SendEmail("mike@ssjhost.com", cdc.Users.FirstOrDefault(a => a.UName == user.UName).Email, "Website Updates", sInfo))
                    {
                        pnlResponse.Visible = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
            }
        }

        void LoadStates()
        {
            selectState.Items.Add(new ListItem { Value = "AL", Text = "AL" });
            selectState.Items.Add(new ListItem { Value = "AK", Text = "AK" });
            selectState.Items.Add(new ListItem { Value = "AZ", Text = "AZ" });
            selectState.Items.Add(new ListItem { Value = "AR", Text = "AR" });
            selectState.Items.Add(new ListItem { Value = "CA", Text = "CA" });
            selectState.Items.Add(new ListItem { Value = "CO", Text = "CO" });
            selectState.Items.Add(new ListItem { Value = "CT", Text = "CT" });
            selectState.Items.Add(new ListItem { Value = "DE", Text = "DE" });
            selectState.Items.Add(new ListItem { Value = "DC", Text = "DC" });
            selectState.Items.Add(new ListItem { Value = "FL", Text = "FL" });
            selectState.Items.Add(new ListItem { Value = "GA", Text = "GA" });
            selectState.Items.Add(new ListItem { Value = "HI", Text = "HI" });
            selectState.Items.Add(new ListItem { Value = "ID", Text = "ID" });
            selectState.Items.Add(new ListItem { Value = "IL", Text = "IL" });
            selectState.Items.Add(new ListItem { Value = "IN", Text = "IN" });
            selectState.Items.Add(new ListItem { Value = "IA", Text = "IA" });
            selectState.Items.Add(new ListItem { Value = "KS", Text = "KS" });
            selectState.Items.Add(new ListItem { Value = "KY", Text = "KY" });
            selectState.Items.Add(new ListItem { Value = "LA", Text = "LA" });
            selectState.Items.Add(new ListItem { Value = "ME", Text = "ME" });
            selectState.Items.Add(new ListItem { Value = "MD", Text = "MD" });
            selectState.Items.Add(new ListItem { Value = "MA", Text = "MA" });
            selectState.Items.Add(new ListItem { Value = "MI", Text = "MI" });
            selectState.Items.Add(new ListItem { Value = "MN", Text = "MN" });
            selectState.Items.Add(new ListItem { Value = "MS", Text = "MS" });
            selectState.Items.Add(new ListItem { Value = "MO", Text = "MO" });
            selectState.Items.Add(new ListItem { Value = "MT", Text = "MT" });
            selectState.Items.Add(new ListItem { Value = "NE", Text = "NE" });
            selectState.Items.Add(new ListItem { Value = "NV", Text = "NV" });
            selectState.Items.Add(new ListItem { Value = "NH", Text = "NH" });
            selectState.Items.Add(new ListItem { Value = "NJ", Text = "NJ" });
            selectState.Items.Add(new ListItem { Value = "NM", Text = "NM" });
            selectState.Items.Add(new ListItem { Value = "NY", Text = "NY" });
            selectState.Items.Add(new ListItem { Value = "NC", Text = "NC" });
            selectState.Items.Add(new ListItem { Value = "ND", Text = "ND" });
            selectState.Items.Add(new ListItem { Value = "OH", Text = "OH" });
            selectState.Items.Add(new ListItem { Value = "OK", Text = "OK" });
            selectState.Items.Add(new ListItem { Value = "OR", Text = "OR" });
            selectState.Items.Add(new ListItem { Value = "PA", Text = "PA" });
            selectState.Items.Add(new ListItem { Value = "RI", Text = "RI" });
            selectState.Items.Add(new ListItem { Value = "SC", Text = "SC" });
            selectState.Items.Add(new ListItem { Value = "SD", Text = "SD" });
            selectState.Items.Add(new ListItem { Value = "TN", Text = "TN" });
            selectState.Items.Add(new ListItem { Value = "TX", Text = "TX" });
            selectState.Items.Add(new ListItem { Value = "UT", Text = "UT" });
            selectState.Items.Add(new ListItem { Value = "VT", Text = "VT" });
            selectState.Items.Add(new ListItem { Value = "VA", Text = "VA" });
            selectState.Items.Add(new ListItem { Value = "WA", Text = "WA" });
            selectState.Items.Add(new ListItem { Value = "WV", Text = "WV" });
            selectState.Items.Add(new ListItem { Value = "WI", Text = "WI" });
            selectState.Items.Add(new ListItem { Value = "WY", Text = "WY" });
        }
    }
}