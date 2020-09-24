using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public partial class checkout : System.Web.UI.Page
{
    dbConnection dbc = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
                {
                    string couponcode = Request.QueryString["offercode"].ToString();
                    Session["ReferCode"] = couponcode;
                    Session["cccode"] = couponcode;
                }
                string custid = clsCommon.getCurrentCustomer().id;
                string MobileNo = clsCommon.getCurrentCustomer().mobile;
                mobileno.Value = MobileNo;
                lblCustid1.Text = custid.ToString();

                string Querydata = "SELECT Id,TagName from  TagMaster where IsActive=1 order by id asc";
                DataTable dt = dbc.GetDataTable(Querydata);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Tag.DataSource = dt;
                    Tag.DataTextField = "TagName";
                    Tag.DataValueField = "Id";
                    Tag.DataBind();

                    ppddltag.DataSource = dt;
                    ppddltag.DataTextField = "TagName";
                    ppddltag.DataValueField = "Id";
                    ppddltag.DataBind();
                    
                }

                string QUESTATE = "SELECT Id,statename from  StateMaster where IsActive=1  order by id asc";
                DataTable dtstate = dbc.GetDataTable(QUESTATE);
                if (dtstate != null && dtstate.Rows.Count > 0)
                {
                    ppstate.DataSource = dtstate;
                    ppstate.DataTextField = "statename";
                    ppstate.DataValueField = "Id";
                    ppstate.DataBind();

                    state.DataSource = dtstate;
                    state.DataTextField = "statename";
                    state.DataValueField = "Id";
                    state.DataBind();

                }

                string quecity = "SELECT Id,CityName from  CityMaster where IsActive=1  order by id asc";
                DataTable dtcityy = dbc.GetDataTable(quecity);
                if (dtcityy != null && dtcityy.Rows.Count > 0)
                {
                    ppcity.DataSource = dtcityy;
                    ppcity.DataTextField = "CityName";
                    ppcity.DataValueField = "Id";
                    ppcity.DataBind();

                    city.DataSource = dtcityy;
                    city.DataTextField = "CityName";
                    city.DataValueField = "Id";
                    city.DataBind();
                }

                string querryc = "SELECT  Id,countryName from  CountryMaster where IsActive=1 order by id asc";
                DataTable dtc = dbc.GetDataTable(querryc);
                if (dtc != null && dtc.Rows.Count > 0)
                {
                    Country.DataSource = dtc;
                    Country.DataTextField = "countryName";
                    Country.DataValueField = "Id";
                    Country.DataBind();

                    ppcounty.DataSource = dtc;
                    ppcounty.DataTextField = "countryName";
                    ppcounty.DataValueField = "Id";
                    ppcounty.DataBind();
                }

                //Session["BuyFlag"] = 1;
                //Session["BuyQty"] = 1;

                //string buyaddren = Session["Addressid"].ToString();
                //string buyqtyen = Session["BuyQty"].ToString();
                //string buyflagen = Session["BuyFlag"].ToString();

                string AddrId = "";
                string Buyqty = "";
                string BuyFlag = "";

                ////session Address
                //if ((HttpContext.Current.Session["Addressid"] != null))
                //{
                //    AddrId = clsCommon.Base64Decode(buyaddren);
                //    //lbladdrid.Text = AddrId;
                //}
                if(HttpContext.Current.Session["WhatsAppNo"] != null)
                {
                    lblWhatsAppNo.Text = Session["WhatsAppNo"].ToString();
                }
                if (HttpContext.Current.Session["PinCode"] != null)
                    lblPinCode.Text = Session["PinCode"].ToString();
                //Buy Quentity
                if ((HttpContext.Current.Session["buyqty"] != null))
                {
                    string buyqty1 = Session["BuyQty"].ToString();
                    Buyqty = clsCommon.Base64Decode(buyqty1);
                }

                //Buy Flag
                if ((HttpContext.Current.Session["BuyFlag"] != null))
                {
                    string flagvalue = Session["BuyFlag"].ToString();
                    BuyFlag = clsCommon.Base64Decode(flagvalue);
                    //lblbuyflag.Text = BuyFlag;
                }

               string Customerid = clsCommon.getCurrentCustomer().id;

               string query = "select (select top 1 CountryMaster.CountryName from CountryMaster where CountryMaster.Id=CustomerAddress.CountryId)as addr,CustomerAddress.Id as addrid,CustomerAddress.Id as addrid,FirstName,LastName,MobileNo,(select TagName from TagMaster where TagMaster.Id=CustomerAddress.TagId and TagMaster.IsActive=1)as tagName,Address,(select CityName from CityMaster where CityMaster.IsActive=1 and CityMaster.id=CustomerAddress.CityId) as City,(select statename from StateMaster where StateMaster.id=CustomerAddress.StateId and StateMaster.IsActive=1)as statename,PinCode  from CustomerAddress where CustomerId=" + custid + " and CustomerAddress.IsActive=1 and CustomerAddress.IsDeleted=0 and len(PinCode)>=6";

                DataTable dtcustdetails = dbc.GetDataTable(query);
                 string Addrliststr="";
                if (dtcustdetails != null && dtcustdetails.Rows.Count > 0)
                {
                    Addrliststr += "<div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12 mob-padding\"><div class=\"panel-info\"><div class=\"row\"><div class=\"panel-heading\"><h3>Existing Address</h3></div></div>";
                    for (int i = 0; i < dtcustdetails.Rows.Count; i++)
                    {
                        string pincode = dtcustdetails.Rows[i]["PinCode"].ToString();
                        DataTable dtpincoced = dbc.GetDataTable("SELECT *  FROM [Zipcode] where zipcode=" + pincode + "");
                        if (dtpincoced != null && dtpincoced.Rows.Count > 0)
                        {
                            //onclick=\"Editaddr(" + dtcustdetails.Rows[i]["addrid"] + "  )\"
                            //Addrliststr += " <div class=\"row panel\"><div id=\"addresslist\" runat=\"server\"><div class=\"panel-body\"> <div class=\"col-md-12 edit-address padding\" style=\"display:flex\"> <div class=\"col-md-8 col-sm-8 left padding\" style=\"width:80%\">  <span id=\"txtname\" class=\"name\"><strong>" + dtcustdetails.Rows[i]["FirstName"].ToString() + " </strong></span> <span id=\"txtsurname\" class=\"name\"><strong>" + dtcustdetails.Rows[i]["LastName"] + " </strong></span>  <div class=\"tag\">  <p id=\"txttagname\">" + dtcustdetails.Rows[i]["tagName"] + "</p>  </div> <span id=\"txtmobile\" style=\"color: #2c2c2c;font-size:15px;font-weight: 700;padding: 0 0 0 12px;margin:0;\">" + dtcustdetails.Rows[i]["MobileNo"] + "</span>  </div> <div class=\"col-md-4 col-sm-4 right padding\" style=\"width:20%\"> <a class=\"edit\" id=\"btnedit\" runat=\"server\" data-toggle=\"modal\" data-target=\"#MyPopup\" onclick=\"Editaddr(" + dtcustdetails.Rows[i]["addrid"] + ")\"><i class=\"fa fa-edit\" runat=\"server\"></i></a> <button id=\"btndelete\" class=\"delete\" onclick=\"DeleteAddr(" + dtcustdetails.Rows[i]["addrid"] + ")\"><i class=\"fa fa-trash\"></i></button> </div> </div>  <hr> <div class=\"address\"> <p>" + dtcustdetails.Rows[i]["Address"] + ",  " + dtcustdetails.Rows[i]["City"] + " - " + dtcustdetails.Rows[i]["PinCode"] + ", " + dtcustdetails.Rows[i]["statename"] + ", " + dtcustdetails.Rows[i]["addr"] + "</span></p></div>   <hr> <div class=\"\" style=\"text-align:center\"> <button id=\"btnsave\" runat=\"server\" class=\"deliver-btn\"  onclick=\"Deliverydone(" + dtcustdetails.Rows[i]["addrid"] + ")\">Deliver Here</button>  </div></div></div> </div>";

                            Addrliststr += " <div class=\"row panel\"><div id=\"addresslist\" runat=\"server\"><div class=\"panel-body\"> <div class=\"col-md-12 edit-address padding\" style=\"display:flex\"> <div class=\"col-md-8 col-sm-8 left padding\" style=\"width:80%\">  <span id=\"txtname\" class=\"name\"><strong>" + dtcustdetails.Rows[i]["FirstName"].ToString() + " </strong></span> <span id=\"txtsurname\" class=\"name\"></span>  <div class=\"tag\">  <p id=\"txttagname\">" + dtcustdetails.Rows[i]["tagName"] + "</p>  </div> <span id=\"txtmobile\" style=\"color: #2c2c2c;font-size:15px;font-weight: 700;padding: 0 0 0 12px;margin:0;\">" + dtcustdetails.Rows[i]["MobileNo"] + "</span>  </div> <div class=\"col-md-4 col-sm-4 right padding\" style=\"width:20%\"> <a class=\"edit\" id=\"btnedit\" runat=\"server\" data-toggle=\"modal\" data-target=\"#MyPopup\" onclick=\"Editaddr(" + dtcustdetails.Rows[i]["addrid"] + ")\"><i class=\"fa fa-edit\" runat=\"server\"></i></a> <button id=\"btndelete\" class=\"delete\" onclick=\"DeleteAddr(" + dtcustdetails.Rows[i]["addrid"] + ")\"><i class=\"fa fa-trash\"></i></button> </div> </div>  <hr> <div class=\"address\"> <p>" + dtcustdetails.Rows[i]["Address"] + ",  " + dtcustdetails.Rows[i]["City"] + " - " + dtcustdetails.Rows[i]["PinCode"] + ", " + dtcustdetails.Rows[i]["statename"] + ", " + dtcustdetails.Rows[i]["addr"] + "</span></p></div>   <hr> <div class=\"\" style=\"text-align:center\"> <button id=\"btnsave\" runat=\"server\" class=\"deliver-btn\"  onclick=\"Deliverydone(" + dtcustdetails.Rows[i]["addrid"] + ",'" + dtcustdetails.Rows[i]["PinCode"] + "')\">Deliver Here</button>  </div></div></div> </div>";
                        }
                    }

                    Addrliststr += "</div></div>";
                    addresslist.InnerHtml = Addrliststr;
                }

                //DeleAddr

            }
        }
        catch (Exception ee)
        {
            ltrerr123.Text = "Errorr" + ee.StackTrace;
        }
    }


    [WebMethod]
    public static string GetMainCourse(string id)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string cid = id;

            string QUESTATE = "SELECT Id,statename from  StateMaster where IsActive=1 and CountryId='" + id + "' order by id asc";
            DataTable dt = dbc.GetDataTable(QUESTATE);
            
            string response = "";
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "Id asc";
                dt = dv.ToTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    response = response + dt.Rows[i]["id"].ToString() + ",";
                    response = response + dt.Rows[i]["StateName"].ToString() + "###";
                }
                response = response.TrimEnd('#');
                return response;

            }
            return response;

        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public static object EditAddress(string id)
    {
        ClsOrderModels.OrderSummery objordresum = new ClsOrderModels.OrderSummery();
        try
        {
            dbConnection dbc = new dbConnection();
            string AddressId = id;           
            {

                string Querydata = "select (select CountryMaster.CountryName from CountryMaster where CountryMaster.IsActive=1 and CountryMaster.id=CustomerAddress.CustomerId) as cout1,CustomerAddress.CustomerId as countryyyyid,TagId,CustomerAddress.CustomerId,CityId,StateId,CountryId,CustomerAddress.Id as addrid,FirstName,LastName,MobileNo,(select TagName from TagMaster where TagMaster.Id=CustomerAddress.TagId and TagMaster.IsActive=1)as tagName,Address,Email,(select CityName from CityMaster where CityMaster.IsActive=1 and CityMaster.id=CustomerAddress.CityId) as City,(select statename from StateMaster where StateMaster.id=CustomerAddress.StateId and StateMaster.IsActive=1)as statename,PinCode  from CustomerAddress where CustomerAddress.IsActive=1 and CustomerAddress.IsDeleted=0 and len(PinCode)>=6 and CustomerAddress.Id=" + AddressId + "";

                DataTable dtmain = dbc.GetDataTable(Querydata);
                
                if (dtmain.Rows.Count > 0)
                {
                    objordresum.Response = "1";
                    objordresum.Message = "Sucess";

                    objordresum.OrderCustomerList = new List<ClsOrderModels.OrderCustDataList>();

                    //for (int i = 0; i < dtmain.Rows.Count; i++)
                    //{
                    //string Custid = dtmain.Rows[i]["custid"].ToString();
                    string Custid = dtmain.Rows[0]["CustomerId"].ToString();
                    string AddrId = AddressId;
                    string Fname = dtmain.Rows[0]["FirstName"].ToString();
                    string Lname = dtmain.Rows[0]["LastName"].ToString();
                    string TagName = dtmain.Rows[0]["TagId"].ToString();
                    string CountryName = dtmain.Rows[0]["CountryId"].ToString();
                    string StateName = dtmain.Rows[0]["StateId"].ToString();
                    string CityName = dtmain.Rows[0]["CityId"].ToString();
                    string MobileNo = dtmain.Rows[0]["MobileNo"].ToString();
                    string addr = dtmain.Rows[0]["Address"].ToString();
                    string pin = dtmain.Rows[0]["PinCode"].ToString();
                    string emai = dtmain.Rows[0]["Email"].ToString();
                    objordresum.OrderCustomerList.Add(new ClsOrderModels.OrderCustDataList
                    {
                        cid = Custid,
                        Caddrid = AddrId,
                        Cfname = Fname,
                        Clname = Lname,
                        addr = addr,
                        tag = TagName,
                        Countryname = CountryName,
                        statename = StateName,
                        Cityname = CityName,
                        cph = MobileNo,
                        pincode = pin,
                        Email=emai

                    });
                }
                else
                {
                    objordresum.Response = "0";
                    objordresum.Message = "No Data Found";
                }

                return objordresum;
            }
        }
        catch (Exception ee)
        {
            objordresum.Response = "-1";
            objordresum.Message = "Somthing Wrong";
            return objordresum;
        }
    }                    
   

    [WebMethod]
    public static string DeleteAddress(string id)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string AddressId = id;

            string QUESTATE = "select CustomerAddress.Id as addrid,FirstName,LastName,MobileNo,(select TagName from TagMaster where TagMaster.Id=CustomerAddress.TagId and TagMaster.IsActive=1)as tagName,Address,(select CityName from CityMaster where CityMaster.IsActive=1 and CityMaster.id=CustomerAddress.CityId) as City,(select statename from StateMaster where StateMaster.id=CustomerAddress.StateId and StateMaster.IsActive=1)as statename,PinCode  from CustomerAddress where CustomerAddress.IsActive=1 and CustomerAddress.IsDeleted=0 and len(PinCode)>=6 and CustomerAddress.Id=" + AddressId + "";
            DataTable dt = dbc.GetDataTable(QUESTATE);

            string response = "";
            if (dt.Rows.Count > 0)
            {
                string updae = "update CustomerAddress set IsActive=0 where CustomerAddress.id=" + AddressId + "";
                int i = dbc.ExecuteQuery(updae);
                 i = 1;

                if(i>0)
                {
                    response="1";
                }
            }
            return response;

        }
        catch
        {
            return null;
        }
    }


    [WebMethod]
    public static string GetCityList(string id)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string cid = id;

            string quecity = "SELECT  Id,CityName from  CityMaster where IsActive=1 AND StateId='" + id + "' order by id asc";
            DataTable dt = dbc.GetDataTable(quecity);

            string response = "";
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "ID asc";
                dt = dv.ToTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    response = response + dt.Rows[i]["id"].ToString() + ",";
                    response = response + dt.Rows[i]["Cityname"].ToString() + "###";
                }
                response = response.TrimEnd('#');
                return response;

            }
            return response;

        }
        catch
        {
            return null;
        }
    }

  
    [WebMethod]
    public static string GetURL(string custid, string fname1, string lname, string tagid1, string Countryid1, string sid, string cid, string addr1, string pinid1, string mobile1, string Email)
    {
        try
        {
            string strapipss = "" + clsCommon.strApiUrl + "/api/CustomerAddress/AddAddress?custid=" + custid + "&fname1=" + fname1 + "&lname=" + lname + "&tagid1=" + tagid1 + "&Countryid1=" + Countryid1 + "&sid=" + sid + "&cid=" + cid + "&addr1=" + addr1 + "&pinid1=" + pinid1 + "&mobile1=" + mobile1 + "&Email=" + Email + "";

            string str = clsCommon.GET(strapipss);

            if(!string.IsNullOrWhiteSpace(str))
            {
                clsModals.CustAddress objcustdata = JsonConvert.DeserializeObject<clsModals.CustAddress>(str);
                {
                    string response = objcustdata.Response;
                    string lastdataid = objcustdata.LastId;
                    int iddd = 0;
                    int.TryParse(lastdataid.ToString(), out iddd);
                    if(iddd>0)
                    {
                        string dataaa = clsCommon.Base64Encode(iddd.ToString());
                        HttpContext.Current.Session["Addressid"] = dataaa;
                    }
                }
                
            }

            return str;
        }
        catch (Exception)
        {

            return null;

        }
    }

    [WebMethod]
    public static object saveandeditaddress(string custid, string fname1, string lname, string tagid1, string Countryid1, string sid, string cid, string addr1, string pinid1, string mobile1, string Email, string Addressid)
    {
        try
        {

            string data = clsCommon.strApiUrl+"/api/CustomerAddress/EditAddress?custid2="+custid+"&addrid2="+Addressid+"&fname2="+fname1+"&lname2="+lname+"&tagid2="+tagid1+"&Countryid2="+Countryid1+"&sid2="+sid+"&cid2="+cid+"&addr2="+addr1+"&pinid2="+pinid1+"&mobile2="+mobile1+"&Emailid="+Email+"";

            string str = clsCommon.GET(data);

            if (!string.IsNullOrWhiteSpace(str))
            {

                ClsOrderModels.ResultResponse objreed = JsonConvert.DeserializeObject<ClsOrderModels.ResultResponse>(str);
                    if (objreed.Response.Equals("1"))
                    {
                        string value = Addressid;
                        string value1 = clsCommon.Base64Encode(value);
                        HttpContext.Current.Session["Addressid"] = value1;
                        return str;

                    }
                    return "";   
            }

            

            return str;
        }
        catch (Exception)
        {

            return null;

        }
    }

    [WebMethod]
    public static object passaddressid(string AddressIdd)
    {
        try
        {
            string valuege = AddressIdd;
            string valuencode = clsCommon.Base64Encode(valuege);
            HttpContext.Current.Session["Addressid"] = valuencode;
            return "1";
        }
        catch (Exception e)
        {
            return "";
        }
        
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
    }
}