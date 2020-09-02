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

public partial class verify : System.Web.UI.Page
{
    dbConnection objDbConnection = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string buyflagdata = (string)HttpContext.Current.Session["test1"];
            //string buyqtydata = (string)Session["BuyQty"];

            //lblflag.Text= buyflagdata;
            //lblqty.Text = buyqtydata;

            if (!String.IsNullOrWhiteSpace(Request.QueryString["m"]))
            {
                resendbtn.Enabled = false;
                verifybtn.Enabled = false;
            }
            else
            {
               Response.Redirect("default",false);
            }


            string buyflagdata = "";
            if (!String.IsNullOrWhiteSpace(Request.QueryString["f"]))
            {
                buyflagdata = Request.QueryString["f"].ToString();
                lblflag.Text = buyflagdata;
               
            }


            string buyqtydata = "";
            
            if (!String.IsNullOrWhiteSpace(Request.QueryString["q"]))
            {
                buyqtydata = Request.QueryString["q"].ToString();
                lblqty.Text = buyqtydata;
            }
        }
    }
    protected void resendbtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["m"]))
            {
                string aa = clsCommon.strApiUrl + "/api/Login/SendOtp?mobile_number=" + clsCommon.Base64Decode(Request.QueryString["m"]);// + jobcard + "&UserId=" + userId;
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
                        clsModals.clsSendOtpResponce objSendOtpResponse = JsonConvert.DeserializeObject<clsModals.clsSendOtpResponce>(data);
                        if (objSendOtpResponse.response.Equals("1"))
                        {

                            if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
                            {
                                Response.Redirect("~/verify.aspx?offercode=" + Request.QueryString["offercode"]);
                            }
                            else
                            {
                                Response.Redirect("~/verify.aspx");
                            }
                        }
                    }
                }
            }
            else
            {
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
        catch (Exception ex)
        {
            objDbConnection.InsertErrorLogs(ex.Message + " :: " + ex.StackTrace);
        }
    }
    protected void verifybtn_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(Request.QueryString["m"]))
        {
            string aa = clsCommon.strApiUrl + "/api/Login/GetOtpVerify?mobile_number=" + clsCommon.Base64Decode(Request.QueryString["m"]) + "&otp=" + otp.Value;// + jobcard + "&UserId=" + userId;
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
                    clsModals.clsOtpVarificationResponce objSendOpResponse = JsonConvert.DeserializeObject<clsModals.clsOtpVarificationResponce>(data);
                    if (objSendOpResponse.response.Equals("1"))
                    {
                        HttpCookie aCookie = new HttpCookie("TUser");
                        aCookie["id"] = objSendOpResponse.userid;
                        aCookie["name"] = objSendOpResponse.FirstName + " " + objSendOpResponse.LastName;
                        aCookie["mobile"] = objSendOpResponse.MobileNo;
                        aCookie["email"] = objSendOpResponse.Email;
                            aCookie.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(aCookie);

                            

                            string buyflagvalue = lblflag.Text;
                            string buyqty = lblqty.Text;
                            
                        if(HttpContext.Current.Session["IsCheckOut"] != null && HttpContext.Current.Session["IsCheckOut"] != "" && HttpContext.Current.Session["IsCheckOut"].ToString() == "true")
                        {
                            HttpContext.Current.Session["buyqty"] = buyqty;
                            HttpContext.Current.Session["BuyFlag"] = buyflagvalue;
                            if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
                            {
                                Response.Redirect("~/checkout.aspx?offercode=" + Request.QueryString["offercode"]);
                            }
                            else
                            {
                                Response.Redirect("~/checkout.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("default",false);
                        }
                    }
                    else
                    {
                        //Alert objSendOtpResponse.message;
                    }
                }
            }
        }
        else
        {
            Response.Redirect("register",false);
        }
    }

    
}