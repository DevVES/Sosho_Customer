using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    dbConnection objDbConnection = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
          
            if (!IsPostBack)
            {
                string buyflagdata = (string)Session["BuyFlag"];
                string buyqtydata = (string)Session["BuyQty"];
                if (buyflagdata == null)
                {
                    buyflagdata = "";
                   
                }
                if(buyqtydata==null)
                {
                     buyqtydata = "";
                }
                lblflag.Text = buyflagdata;
                lblqty.Text = buyqtydata;
                //string value123 = (string)Session["BuyFlag"];
                ////Session["BuyFlag123"] = value123;
                //HttpContext.Current.Session["BuyFlag123"] = value123;

                //HttpCookie aCookie;
                //string cookieName;
                //int limit = Request.Cookies.Count;
                //for (int i = 0; i < limit; i++)
                //{
                //    cookieName = Request.Cookies[i].Name;
                //    aCookie = new HttpCookie(cookieName);
                //    aCookie.Expires = DateTime.Now.AddHours(72);  // make it expire yesterday
                //    Response.Cookies.Add(aCookie); // overwrite it   

                //}
            }
            
        }
        catch (Exception ee)
        {
            
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string strApiUrl = clsCommon.strApiUrl;
        try
        {
            string lblflag1 = lblflag.Text;
            string lblqty1 = lblqty.Text;

            string aa = clsCommon.strApiUrl + "/api/Login/SendOtp?mobile_number=" + txtMobileNumber.Text;// + jobcard + "&UserId=" + userId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(aa);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                string data = readStream.ReadToEnd();
                if (!String.IsNullOrEmpty(data))
                {
                    string mobileencode = clsCommon.Base64Encode(txtMobileNumber.Text.ToString());
                    string link = "verify.aspx?m=" + mobileencode;
                    clsModals.clsSendOtpResponce objSendOtpResponse = JsonConvert.DeserializeObject<clsModals.clsSendOtpResponce>(data);
                    if (objSendOtpResponse.response.Equals("1"))
                    {
                       
                        if (lblflag1 != null && lblflag1 != "" && lblqty1 != null && lblqty1 != "")
                        {
                            HttpContext.Current.Session["BuyFlag"] = lblflag1;
                            Session["BuyQty"] = lblqty1;
                            link += "&f=" + lblflag1 + "&q=" + lblqty1 + "";
                          
                        }
                        //if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
                        //{
                        //    Response.Redirect(link + "&offercode=" + Request.QueryString["offercode"], false);
                        //}
                        //else
                        //{
                        //    Response.Redirect(link + "&offercode=" + Request.QueryString["offercode"], false);
                        //}
                        if (!string.IsNullOrWhiteSpace(Request.QueryString["fcode"]))
                        {
                            Response.Redirect(link + "&fcode=" + Request.QueryString["fcode"], false);
                        }
                        else
                        {
                            Response.Redirect(link + "&fcode=" + Request.QueryString["fcode"], false);
                        }

                        //Next Page Url
                    }
                }
            }
        }
        catch (Exception ex)
        {
          //  objDbConnection.InsertErrorLogs(ex.Message+" :: "+ex.StackTrace);
        }
    }
}