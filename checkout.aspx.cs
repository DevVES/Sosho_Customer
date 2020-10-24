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
                    //Country.DataSource = dtc;
                    //Country.DataTextField = "countryName";
                    //Country.DataValueField = "Id";
                    //Country.DataBind();

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
                if (HttpContext.Current.Session["CountryId"] != null)
                    lblCountryId.Text = Session["CountryId"].ToString();
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

               //string query = "select (select top 1 CountryMaster.CountryName from CountryMaster where CountryMaster.Id=CustomerAddress.CountryId)as addr,CustomerAddress.Id as addrid,CustomerAddress.Id as addrid,FirstName,LastName,MobileNo,(select TagName from TagMaster where TagMaster.Id=CustomerAddress.TagId and TagMaster.IsActive=1)as tagName,Address,(select CityName from CityMaster where CityMaster.IsActive=1 and CityMaster.id=CustomerAddress.CityId) as City,(select statename from StateMaster where StateMaster.id=CustomerAddress.StateId and StateMaster.IsActive=1)as statename,PinCode  from CustomerAddress where CustomerId=" + custid + " and CustomerAddress.IsActive=1 and CustomerAddress.IsDeleted=0 and len(PinCode)>=6";

                //DataTable dtcustdetails = dbc.GetDataTable(query);

                string address = clsCommon.strApiUrl + "/api/CustomerAddress/AddressDairy_V4?custid=" + Customerid;
                string data = clsCommon.GET(address);

                ClsOrderModels.CustAddressDetailsList dtcustdetails = JsonConvert.DeserializeObject<ClsOrderModels.CustAddressDetailsList>(data);

                string Addrliststr="";
                if (dtcustdetails != null && dtcustdetails.CustAddressList.Count > 0)
                {
                    Addrliststr += "<div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12 mob-padding\"><div class=\"panel-info\"><div class=\"row\"><div class=\"panel-heading\"><h3>Existing Address</h3></div></div>";
                    foreach (var item in dtcustdetails.CustAddressList)
                    {
                        string pincode = item.pcode;
                        DataTable dtpincoced = dbc.GetDataTable("SELECT *  FROM [Zipcode] where zipcode=" + pincode + "");
                        if (dtpincoced != null && dtpincoced.Rows.Count > 0)
                        {
                            string fulladdress = string.Empty;
                            //onclick=\"Editaddr(" + dtcustdetails.Rows[i]["addrid"] + "  )\"
                            //Addrliststr += " <div class=\"row panel\"><div id=\"addresslist\" runat=\"server\"><div class=\"panel-body\"> <div class=\"col-md-12 edit-address padding\" style=\"display:flex\"> <div class=\"col-md-8 col-sm-8 left padding\" style=\"width:80%\">  <span id=\"txtname\" class=\"name\"><strong>" + dtcustdetails.Rows[i]["FirstName"].ToString() + " </strong></span> <span id=\"txtsurname\" class=\"name\"><strong>" + dtcustdetails.Rows[i]["LastName"] + " </strong></span>  <div class=\"tag\">  <p id=\"txttagname\">" + dtcustdetails.Rows[i]["tagName"] + "</p>  </div> <span id=\"txtmobile\" style=\"color: #2c2c2c;font-size:15px;font-weight: 700;padding: 0 0 0 12px;margin:0;\">" + dtcustdetails.Rows[i]["MobileNo"] + "</span>  </div> <div class=\"col-md-4 col-sm-4 right padding\" style=\"width:20%\"> <a class=\"edit\" id=\"btnedit\" runat=\"server\" data-toggle=\"modal\" data-target=\"#MyPopup\" onclick=\"Editaddr(" + dtcustdetails.Rows[i]["addrid"] + ")\"><i class=\"fa fa-edit\" runat=\"server\"></i></a> <button id=\"btndelete\" class=\"delete\" onclick=\"DeleteAddr(" + dtcustdetails.Rows[i]["addrid"] + ")\"><i class=\"fa fa-trash\"></i></button> </div> </div>  <hr> <div class=\"address\"> <p>" + dtcustdetails.Rows[i]["Address"] + ",  " + dtcustdetails.Rows[i]["City"] + " - " + dtcustdetails.Rows[i]["PinCode"] + ", " + dtcustdetails.Rows[i]["statename"] + ", " + dtcustdetails.Rows[i]["addr"] + "</span></p></div>   <hr> <div class=\"\" style=\"text-align:center\"> <button id=\"btnsave\" runat=\"server\" class=\"deliver-btn\"  onclick=\"Deliverydone(" + dtcustdetails.Rows[i]["addrid"] + ")\">Deliver Here</button>  </div></div></div> </div>";
                            if(string.IsNullOrEmpty(item.BuildingNo) && string.IsNullOrEmpty(item.Building) && string.IsNullOrEmpty(item.Area))
                            {
                                fulladdress = item.addr;
                            }
                            else
                            {
                                fulladdress = item.BuildingNo + "," + item.Building + "," + item.Area + "," + item.LandMark;
                            }
                           
                            Addrliststr += " <div class=\"row panel\"><div id=\"addresslist\" runat=\"server\"><div class=\"panel-body\"> <div class=\"col-md-12 edit-address padding\" style=\"display:flex\"> <div class=\"col-md-8 col-sm-8 left padding\" style=\"width:80%\">  <span id=\"txtname\" class=\"name\"><strong>" + item.fname + " </strong></span> <span id=\"txtsurname\" class=\"name\"></span>  <div class=\"tag\">  <p id=\"txttagname\">" +item.tagname + "</p>  </div> <span id=\"txtmobile\" style=\"color: #2c2c2c;font-size:15px;font-weight: 700;padding: 0 0 0 12px;margin:0;\">" + item.mob + "</span>  </div> <div class=\"col-md-4 col-sm-4 right padding\" style=\"width:20%\"> <a class=\"edit\" id=\"btnedit\" runat=\"server\" data-toggle=\"modal\" data-target=\"#MyPopup\" onclick=\"Editaddr(" + item.CustomerAddressId + ")\"><i class=\"fa fa-edit\" runat=\"server\"></i></a> <button id=\"btndelete\" class=\"delete\" onclick=\"DeleteAddr(" + item.CustomerAddressId + ")\"><i class=\"fa fa-trash\"></i></button> </div> </div>  <hr> <div class=\"address\"> <p>" + fulladdress + ",  " + item.cityname + " - " + item.pcode + ", " + item.statename + ", " + item.countryName + "</span></p></div>   <hr> <div class=\"\" style=\"text-align:center\"> <button id=\"btnsave\" runat=\"server\" class=\"deliver-btn\"  onclick=\"Deliverydone(" + item.CustomerAddressId + ",'" + item.pcode + "')\">Confirm And Deliver Here</button>  </div></div></div> </div>";
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

                string Querydata = "select (select CountryMaster.CountryName from CountryMaster where CountryMaster.IsActive=1 and CountryMaster.id=CustomerAddress.CustomerId) as cout1,CustomerAddress.CustomerId as countryyyyid,TagId,CustomerAddress.CustomerId,CityId,StateId,CountryId,CustomerAddress.Id as addrid,FirstName,LastName,MobileNo,(select TagName from TagMaster where TagMaster.Id=CustomerAddress.TagId and TagMaster.IsActive=1)as tagName,Address,Email,(select CityName from CityMaster where CityMaster.IsActive=1 and CityMaster.id=CustomerAddress.CityId) as City,(select statename from StateMaster where StateMaster.id=CustomerAddress.StateId and StateMaster.IsActive=1)as statename,PinCode,AreaId,BuildingId,BuildingNo,LandMark,OtherDetail,(select Area from Zipcode where Zipcode.IsActive=1 and Zipcode.id=CustomerAddress.AreaId) as AreaName,(select Building from tblBuilding where tblBuilding.IsActive=1 and tblBuilding.id=CustomerAddress.BuildingId) as BuildingName  from CustomerAddress where CustomerAddress.IsActive=1 and CustomerAddress.IsDeleted=0 and len(PinCode)>=6 and CustomerAddress.Id=" + AddressId + "";

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
                    string areaid = dtmain.Rows[0]["AreaId"].ToString();
                    string buildingid = dtmain.Rows[0]["BuildingId"].ToString();
                    string buildingname = dtmain.Rows[0]["BuildingName"].ToString();
                    string areaname = dtmain.Rows[0]["AreaName"].ToString();
                    string buildingno = dtmain.Rows[0]["BuildingNo"].ToString();
                    string landmark = dtmain.Rows[0]["LandMark"].ToString();
                    string otherDetails = dtmain.Rows[0]["OtherDetail"].ToString();
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
                        Email=emai,
                        AreaId = !string.IsNullOrEmpty(areaid) ? areaid : "-1",
                        BuildingId = !string.IsNullOrEmpty(buildingid) ? buildingid : "-1",
                        AreaName = areaname,
                        BuildingName = buildingname,
                        BuildingNo = buildingno,
                        Landmark = landmark,
                        OtherDetails = otherDetails

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
            ConfirmOrder();
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

    [WebMethod]
    public static object GetArea(string zipcode, string term)
    {
        List<ClsOrderModels.AreaDatalist> list = new List<ClsOrderModels.AreaDatalist>();
        try
        {
            
            string arealist = clsCommon.strApiUrl + "/api/MasterData/AreaList?zipcode=" + zipcode;
            string data = clsCommon.GET(arealist);
            ClsOrderModels.ZipCodeAreaList objarea = JsonConvert.DeserializeObject<ClsOrderModels.ZipCodeAreaList>(data);
            list = (from e in objarea.Arealist where e.AreaName.ToLower().Contains(term.ToLower()) select new ClsOrderModels.AreaDatalist { AreaId = e.AreaId, AreaName = e.AreaName }).ToList();
            return list;

        }
        catch
        {
            return list;
        }

    }

    [WebMethod]
    public static object GetBuilding(string areaId, string term)
    {
        List<ClsOrderModels.BuildingDatalist> list = new List<ClsOrderModels.BuildingDatalist>();
        try
        {

            string arealist = clsCommon.strApiUrl + "/api/MasterData/BuildingSocietyList?areaId=" + areaId;
            string data = clsCommon.GET(arealist);
            ClsOrderModels.AreaBuildingList objbuilding = JsonConvert.DeserializeObject<ClsOrderModels.AreaBuildingList>(data);
            list = (from e in objbuilding.Buildinglist where e.BuildingName.ToLower().Contains(term.ToLower()) select new ClsOrderModels.BuildingDatalist { BuildingId = e.BuildingId, BuildingName = e.BuildingName }).ToList();
            return list;

        }
        catch
        {
            return list;
        }

    }

    [WebMethod]
    public static string SaveAddress(string custid, string fname1,string tagid1, string Countryid1, string sid, string cid, string pinid1, string mobile1, string Email, string areaid, string area, string buildingid, string building, string buildingNo, string landmark, string other)
    {
        try
        {
            string strapipss = "" + clsCommon.strApiUrl + "/api/CustomerAddress/AddAddressV4?custid=" + custid + "&name=" + fname1 +  "&tagId=" + tagid1 + "&countryId=" + Countryid1 + "&sid=" + sid + "&cid=" + cid + "&pincode=" + pinid1 + "&mobile=" + mobile1 + "&Email=" + Email + "&areaid=" + areaid + "&area=" + area + "&buildingid=" + buildingid + "&building=" + building + "&buildingNo=" + buildingNo + "&landmark=" + landmark + "&others=" + other + "";

            string str = clsCommon.GET(strapipss);

            if (!string.IsNullOrWhiteSpace(str))
            {
                clsModals.CustAddress objcustdata = JsonConvert.DeserializeObject<clsModals.CustAddress>(str);
                {
                    string response = objcustdata.Response;
                    string lastdataid = objcustdata.LastId;
                    int iddd = 0;
                    int.TryParse(lastdataid.ToString(), out iddd);
                    if (iddd > 0)
                    {
                        string dataaa = clsCommon.Base64Encode(iddd.ToString());
                        HttpContext.Current.Session["Addressid"] = dataaa;
                        ConfirmOrder();
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
    public static string UpdateAddress(string custid, string addrid, string fname1, string tagid1, string Countryid1, string sid, string cid, string pinid1, string mobile1, string Email, string areaid, string area, string buildingid, string building, string buildingNo, string landmark, string other)
    {
        try
        {
            string strapipss = "" + clsCommon.strApiUrl + "/api/CustomerAddress/EditAddressV4?custid=" + custid + "&addrid2=" + addrid + "&name=" + fname1 + "&tagId=" + tagid1 + "&countryId=" + Countryid1 + "&sid=" + sid + "&cid=" + cid + "&pincode=" + pinid1 + "&mobile=" + mobile1 + "&Email=" + Email + "&areaid=" + areaid + "&area=" + area + "&buildingid=" + buildingid + "&building=" + building + "&buildingNo=" + buildingNo + "&landmark=" + landmark + "&others=" + other + "";

            string str = clsCommon.GET(strapipss);

            if (!string.IsNullOrWhiteSpace(str))
            {
                ClsOrderModels.ResultResponse objreed = JsonConvert.DeserializeObject<ClsOrderModels.ResultResponse>(str);
                if (objreed.Response.Equals("1"))
                {
                    string value = addrid;
                    string value1 = clsCommon.Base64Encode(value);
                    HttpContext.Current.Session["Addressid"] = value1;
                    ConfirmOrder();
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

    public static void ConfirmOrder()
    {
        List<ClsOrderModels.OrderSummeryModel> summeryModel;
        if ((HttpContext.Current.Session["summeryModel"] != null))
        {
            summeryModel = (List<ClsOrderModels.OrderSummeryModel>)HttpContext.Current.Session["summeryModel"];

        }
        else
        {
            summeryModel = new List<ClsOrderModels.OrderSummeryModel>();
        }


        ClsOrderModels.PlaceMultipleOrderNewModel OrderDetail;
        WalletModel.RedeemeWalletFromOrder walletHistory;
        WalletModel.RedeemePromoCodeFromOrder PromoHistory;

        if ((HttpContext.Current.Session["ConfirmOrder"] != null))
        {
            //OrderDetail = (ClsOrderModels.PlaceMultipleOrderModel)HttpContext.Current.Session["ConfirmOrder"];
            OrderDetail = (ClsOrderModels.PlaceMultipleOrderNewModel)HttpContext.Current.Session["ConfirmOrder"];

        }
        else
        {
            //OrderDetail = new ClsOrderModels.PlaceMultipleOrderModel();
            OrderDetail = new ClsOrderModels.PlaceMultipleOrderNewModel();
        }

        if ((HttpContext.Current.Session["WalletHistory"] != null))
        {
            walletHistory = (WalletModel.RedeemeWalletFromOrder)HttpContext.Current.Session["WalletHistory"];

        }
        else
        {
            walletHistory = new WalletModel.RedeemeWalletFromOrder();
        }

        if ((HttpContext.Current.Session["PromoHistory"] != null))
        {
            PromoHistory = (WalletModel.RedeemePromoCodeFromOrder)HttpContext.Current.Session["PromoHistory"];

        }
        else
        {
            PromoHistory = new WalletModel.RedeemePromoCodeFromOrder();
        }

        OrderDetail.WalletId = walletHistory.WalletId;
        OrderDetail.WalletLinkId = walletHistory.WalletLinkId;
        OrderDetail.WalletType = walletHistory.WalletType;
        OrderDetail.Walletbalance = walletHistory.balance;
        OrderDetail.WalletCrAmount = walletHistory.CrAmount;
        OrderDetail.WalletCrDate = walletHistory.CrDate;
        OrderDetail.WalletCrDescription = walletHistory.CrDescription;

        //OrderDetail.PromoCodeamount = PromoAmount;
        OrderDetail.PromoCodebalance = PromoHistory.PromoCodebalance;
        OrderDetail.PromoCodeCrAmount = PromoHistory.PromoCodeCrAmount;
        OrderDetail.PromoCodeCrDate = PromoHistory.PromoCodeCrDate;
        OrderDetail.PromoCodeCrDescription = PromoHistory.PromoCodeCrDescription;
        OrderDetail.PromoCodeId = PromoHistory.PromoCodeId;
        OrderDetail.PromoCodeLinkId = PromoHistory.PromoCodeLinkId;
        OrderDetail.PromoCodetype = PromoHistory.PromoCodetype;

        string PromoAmount = string.Empty;
        string Discount = string.Empty;
        string PaidAmt = string.Empty;
        string PromoCode = string.Empty;
        string reorderid = "0";
        string redeemamount = string.Empty;
        string totalamount = string.Empty;

        if ((HttpContext.Current.Session["PromoAmount"] != null) && (HttpContext.Current.Session["PromoAmount"].ToString() != ""))
        {
            PromoAmount = HttpContext.Current.Session["PromoAmount"].ToString();
        }
        if ((HttpContext.Current.Session["Discount"] != null) && (HttpContext.Current.Session["Discount"].ToString() != ""))
        {
            Discount = HttpContext.Current.Session["Discount"].ToString();
        }
        if ((HttpContext.Current.Session["PaidAmt"] != null) && (HttpContext.Current.Session["PaidAmt"].ToString() != ""))
        {
            PaidAmt = HttpContext.Current.Session["PaidAmt"].ToString();
        }
        if ((HttpContext.Current.Session["PromoCode"] != null) && (HttpContext.Current.Session["PromoCode"].ToString() != ""))
        {
            PromoCode = HttpContext.Current.Session["PromoCode"].ToString();
        }
        if ((HttpContext.Current.Session["reorderid"] != null) && (HttpContext.Current.Session["reorderid"].ToString() != ""))
        {
            reorderid = HttpContext.Current.Session["reorderid"].ToString();
        }
        if ((HttpContext.Current.Session["redeemamount"] != null) && (HttpContext.Current.Session["redeemamount"].ToString() != ""))
        {
            redeemamount = HttpContext.Current.Session["redeemamount"].ToString();
        }
        if ((HttpContext.Current.Session["totalamount"] != null) && (HttpContext.Current.Session["totalamount"].ToString() != ""))
        {
            totalamount = HttpContext.Current.Session["totalamount"].ToString();
        }

        OrderDetail.Cashbackamount = string.IsNullOrEmpty(PromoAmount) ? 0 : Convert.ToDecimal(PromoAmount);
        OrderDetail.discountamount = Discount;
        OrderDetail.PaidAmount = Convert.ToDecimal(PaidAmt);
        OrderDetail.PromoCode = PromoCode;
        OrderDetail.ReOrderId = reorderid;




        decimal payableamt = 0;
        decimal.TryParse(OrderDetail.products[0].PaidAmount.ToString(), out payableamt);
        if (payableamt > 0)
        {
            NewCode:

            string CCCode = "";
            string refercode = "";
            string addressid = "";

            if ((HttpContext.Current.Session["ReferCode"] != null) && (HttpContext.Current.Session["ReferCode"].ToString() != ""))
            {
                refercode = HttpContext.Current.Session["ReferCode"].ToString();
            }


            if ((HttpContext.Current.Session["JurisdictionId"] != null) && (HttpContext.Current.Session["JurisdictionId"].ToString() != ""))
            {
                OrderDetail.JurisdictionID = HttpContext.Current.Session["JurisdictionId"].ToString();
            }


            //if (refercode == "")
            //{
            //    string coddd = clsCommon.GenerateRandomNumber().ToString();
            //    int test = getcheck(coddd);

            //    if (test == 0)
            //    {
            //        goto NewCode;
            //    }

            //    CCCode = coddd;
            //}
            //else
            //{
            //}

            if ((HttpContext.Current.Session["Addressid"] != null))
            {
                addressid = HttpContext.Current.Session["Addressid"].ToString();
                addressid = clsCommon.Base64Decode(addressid);
            }


            OrderDetail.AddressId = addressid;
            OrderDetail.CustomerId = clsCommon.getCurrentCustomer().id;
            OrderDetail.Redeemeamount = redeemamount;
            OrderDetail.orderMRP = totalamount;
            OrderDetail.totalAmount = totalamount;

            foreach (var item in OrderDetail.products)
            {
                item.couponCode = CCCode;
                item.refrcode = refercode;
            }
            if (summeryModel.Count > 0 && summeryModel != null)
            {
                int totalqty = 0;
                //List<ClsOrderModels.OrderQuantityModel> orderQuantities = new List<ClsOrderModels.OrderQuantityModel>();
                //OrderDetail.orderMRP = totalamount;
                //OrderDetail.totalAmount = totalamount;
                foreach (var item in summeryModel)
                {
                    foreach (var product in OrderDetail.products)
                    {
                        if (item.Productid == product.productid)
                        {
                            product.Quantity = item.Qty.ToString();
                        }

                    }

                }
                for (int i = 0; i < OrderDetail.products.Count; i++)
                {
                    totalqty += Convert.ToInt32(OrderDetail.products[i].Quantity);
                }
                OrderDetail.totalQty = totalqty.ToString();
            }
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers["Content-type"] = "application/json";
            client.Headers["DeviceType"] = "Web";

            var model = JsonConvert.SerializeObject(OrderDetail);
            //var data = client.UploadString(clsCommon.strApiUrl + "/api/CODOrder/CODPlaceMultipleOrder", model);
            var data = client.UploadString(clsCommon.strApiUrl + "/api/CODOrder/CODPlaceMultipleOrderNew", model);
            //string creaturl = clsCommon.strApiUrl + "/api/CODOrder/CODPlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + (String.IsNullOrWhiteSpace(CCCode) ? "0" : CCCode) + "&refrcode=" + (String.IsNullOrWhiteSpace(rcode) ? "0" : rcode) + "";

            //string creaturl = clsCommon.strApiUrl + "/api/CODOrder/CODPlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + (String.IsNullOrWhiteSpace(CCCode) ? "0" : CCCode) + "&refrcode=" + rcode + "";

            //string res = clsCommon.GET(creaturl);

            if (!string.IsNullOrWhiteSpace(data))
            {
                ClsOrderModels.PlaceOrderModel objplaceorder = JsonConvert.DeserializeObject<ClsOrderModels.PlaceOrderModel>(data);
                //ClsOrderModels.PlaceMultipleOrderNewModel objplaceorder = JsonConvert.DeserializeObject<ClsOrderModels.PlaceMultipleOrderNewModel>(data);
                if (objplaceorder.resultflag == "1")
                {

                    string Oid = objplaceorder.OrderId;
                    string value = clsCommon.Base64Encode(Oid);
                    string couponcode = objplaceorder.Ccode;


                    if (!string.IsNullOrWhiteSpace(Oid))
                    {
                        HttpContext.Current.Session["PlaceOrderId"] = value;
                        HttpContext.Current.Session["CouponCode"] = couponcode;





                        //return data;

                    }
                    
                }
               

            }
            
        }
        
    }
}