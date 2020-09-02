using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    dbConnection dbc = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (!IsPostBack)
            //{

            HttpContext.Current.Cache.Remove("MasterPage.master");
                string Customerid = "";
                //if (HttpContext.Current.Request.Cookies.AllKeys.Contains("TUser"))
                //{
                currentCustomer objcust = clsCommon.getCurrentCustomer();
                if (objcust != null && objcust.id != null)
                {
                    Customerid = clsCommon.getCurrentCustomer().id;
                }
                else if (Customerid == null || Customerid == "")
                {

                    if (!Request.CurrentExecutionFilePath.Equals("/register.aspx"))
                    {
                        if (!Request.CurrentExecutionFilePath.Equals("/verify.aspx"))
                        {
                            if (!Request.CurrentExecutionFilePath.Equals("/default.aspx"))
                            {
                                string Url = Request.Url.ToString();
                                Session["URL"] = Url;
                                lbllogout.InnerHtml = "<p><i class=\"fa fa-user\"></i><span><a href=\"Logout.aspx\"></a></span></p>";
                                //Response.Redirect("~/register.aspx",false);
                                if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
                                {
                                    Response.Redirect("~/register.aspx?offercode=" + Request.QueryString["offercode"]);
                                }
                                else
                                {
                                    Response.Redirect("~/register.aspx");
                                }
                            }
                        }
                    }
                }




                HtmlMeta tag = new HtmlMeta();
                tag.Name = "description";
                tag.Content = clsCommon.getMataData();
                Page.Header.Controls.Add(tag);

                HtmlMeta tag1 = new HtmlMeta();
                tag1.Name = "keywords";
                tag1.Content = clsCommon.getMataDesc();
                Page.Header.Controls.Add(tag1);

                HtmlMeta tag2 = new HtmlMeta();
                tag2.Name = "title";
                tag2.Content = clsCommon.getMatatitle();
                Page.Header.Controls.Add(tag2);

            //HtmlMeta tag3 = new HtmlMeta();
            //tag3.Name = "og:image";
            //tag3.Content = clsCommon.getMataImg();
            //Page.Header.Controls.Add(tag3);

            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0");

            //If Login then Show Nothing otherwise show Logout Button
            currentCustomer objCurrentCustomer = clsCommon.getCurrentCustomer();
                if (objCurrentCustomer != null && objCurrentCustomer.mobile != null && objCurrentCustomer.mobile.Length > 1)
                {
                    //<i class=\"fa fa-user\"></i>
                    //lbllogout.InnerHtml = "<p><span><a href=\"Logout.aspx\">LogOut</a></span></p>";
                    lbllogout.InnerHtml = "<li><a href=\"PersonalInfo.aspx\">Personal Information</a></li><li><a href=\"MyWallet.aspx\">My Wallet</a></li>  <li><a href=\"MyOrder.aspx\">My Orders</a></li><li><p><span><a href=\"Logout.aspx\" id=\"logoutiddd\">LogOut</a></span></p></a></li>";
                }
                else
                {
                    //lbloo.Visible = false;
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
                    {
                        lbllogout.InnerHtml = "<li><a href='register.aspx?offercode=" + Request.QueryString["offercode"] + "'>Login</a></li>";
                    }
                    else
                    {
                        lbllogout.InnerHtml = "<li><a href='register.aspx'>Login</a></li>";
                    }
                    //

                    lblshow.InnerHtml = " ";

                    string path = HttpContext.Current.Request.Url.AbsolutePath;
                    if (path == "salebhai.in" || path == "/default.aspx")
                    {
                        lblshow.InnerHtml = "<a class=\"custom-header-toggle-button\" href=\"javascript:void(0);\" id=\"Menulist1\"><img class=\"custom-header-menu-nav-icon\" src=\"images/align-justify1.png\" alt=\"Nav\" /><img class=\"custom-header-menu-close-icon\" src=\"images/close-button.png\" alt=\"Close\" /></a>";
                    }
                }

                //Count Down
                string queryData = "select top 1 CONVERT(varchar(12),EndDate,107)+' '+CONVERT(varchar(20),EndDate,108) as Enddate1,StartDate,EndDate,sold  from Product where StartDate<='" + dbc.getindiantime().ToString("dd/MMM/yyyy hh:mm:ss tt") + "' and EndDate>='" + dbc.getindiantime().ToString("dd/MMM/yyyy hh:mm:ss tt") + "'";
                string endtime = "";
                string solditme = "";
                DataTable dttime = dbc.GetDataTable(queryData);
                if (dttime != null && dttime.Rows.Count > 0)
                {
                    endtime = dttime.Rows[0]["Enddate1"].ToString();
                    solditme = dttime.Rows[0]["sold"].ToString();
                    //Button1.InnerHtml = solditme;
                    //lblenddate.Value = endtime;

                }
                try
                {
                    DataTable dt = dbc.GetDataTable("select top 1 JustBougth from Product where StartDate<='" + dbc.getindiantime().ToString("dd/MMM/yyyy hh:mm:ss tt") + "' and EndDate>='" + dbc.getindiantime().ToString("dd/MMM/yyyy hh:mm:ss tt") + "' order by id desc ");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ms.InnerText = dt.Rows[0]["JustBougth"].ToString();

                    }
                }
                catch (Exception)
                {
                }

            //}
        }
        catch (Exception)
        {


        }
    }


}
