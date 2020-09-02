using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
       Session.Abandon();
       Session.Clear();

       HttpCookie aCookie = new HttpCookie("TUser");
       aCookie["id"] = "";
       aCookie["name"] = "";
       aCookie["mobile"] = "";
       aCookie["email"] = "";
       aCookie.Expires = DateTime.Now.AddMonths(-1);
       Response.Cookies.Add(aCookie);

       Response.Redirect("~/default.aspx?Logout=1",false);
 
        }
        catch (Exception )
        {
            
            throw;
        }
    }
}