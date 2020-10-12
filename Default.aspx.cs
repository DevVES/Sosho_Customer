using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    dbConnection dbc = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //object data = clsCommon.custdetails("1");

            //Getdata();
            GetCategoryData();

            var custid = clsCommon.getCurrentCustomer().id;
            string walletHistory = clsCommon.strApiUrl + "/api/Wallet/GetWalletHistory?CustomerId=" + custid;
            string data = clsCommon.GET(walletHistory);

            //GetProductdataTest("1","1","5");
            //if (!IsPostBack)
            //{

            //    qty();

            //    if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
            //    {
            //        string couponcode = Request.QueryString["offercode"].ToString();


            //        string query = "select OrderTotal,BuyWith from [order] where CustOfferCode='" + couponcode + "'";
            //        DataTable dtcode = dbc.GetDataTable(query);
            //        if (dtcode.Rows.Count > 0)
            //        {
            //            string value1 = dtcode.Rows[0]["BuyWith"].ToString();

            //            //qty();
            //            if (value1 == "1")
            //            {

            //                //BuyOne.Text = "Buy For " + clsCommon.rssymbol + dtcode.Rows[0]["OrderTotal"].ToString();
            //                //BuyOneWithFriend.Visible = false;
            //                //BuyFivewithFriend.Visible = false;

            //            }
            //            else if (value1 == "2")
            //            {
            //                //BuyOne.Visible = false;
            //                //BuyOneWithFriend.Text = "Buy For " + clsCommon.rssymbol + dtcode.Rows[0]["OrderTotal"].ToString();
            //                //BuyFivewithFriend.Visible = false;
            //            }
            //            else if (value1 == "6")
            //            {
            //                //BuyOne.Visible = false;
            //                //BuyOneWithFriend.Visible = false;
            //                //BuyFivewithFriend.Text = "Buy For " + clsCommon.rssymbol + dtcode.Rows[0]["OrderTotal"].ToString();
            //            }

            //            //  whtp.InnerHtml = "<a target=\"_blank\" href='https://web.whatsapp.com/send?text=Hello!l like this product on Sosho.in and thought of sharing with you! They’ve got some amazing group buy discounts, valid only till 25 oct 2019 12:00 PM. How about we buy it together?' data-action=\"share/whatsapp/share\"><img id=\"web\" src=\"images/whatsapp.png\" /></a><a target=\"_blank\" href=\"whatsapp://send?text=Hello!l like this product on Sosho.in and thought of sharing with you! They’ve got some amazing group buy discounts, valid only till 25 oct 2019 12:00 PM. How about we buy it together?\"><img id=\"mo-wa\" src=\"images/whatsapp.png\" /></a>";

            //        }
            //    }
            //}
        }
        catch (Exception ee)
        {

        }
    }

    public void qty()
    {
        try
        {
            //DateTime localDate = DateTime.Now;

            string str = "Select  IsQtyFreeze from Product  where StartDate <= '" + dbc.getindiantimeString(true) + "' and EndDate>= '" + dbc.getindiantimeString(true) + "' ";
            DataTable dtcode = dbc.GetDataTable(str);
            if (dtcode != null && dtcode.Rows.Count > 0)
            {
                string IsQtyFreez = dtcode.Rows[0]["IsQtyFreeze"].ToString();
                if (IsQtyFreez == "True")
                {
                    //btnminus.Disabled = true;
                    //txtqty.Disabled = true;
                    //btnplus.Disabled = true;
                }
            }

        }
        catch (Exception)
        {
        }


    }
    public void Getdata()
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string html = "", JurisdictionID = "";

            //string aa = clsCommon.strApiUrl + "/api/Product/GetProductDetails";
            //string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
            //string data = clsCommon.GET(aa);

            string dashboadapi = clsCommon.strApiUrl + "/api/Product/GetDashBoardProductDetails?JurisdictionID=" + JurisdictionID + "";
            string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
            string data = clsCommon.GET(dashboadapi);

            if (!String.IsNullOrEmpty(data))
            {
                clsModals.getproduct objproduct = JsonConvert.DeserializeObject<clsModals.getproduct>(data);
                if (objproduct.response.Equals("1"))
                {
                    for (int j = 0; j < objproduct.ProductList.Count; j++)
                    {
                        html += "<div class=\"row\" style =\"padding - top: 6px; \">";
                        html += "<div class=\"owl - carousel owl - theme\" id=\"imagsliderimg\" runat=\"server\">";
                        if (objproduct.ProductList[j].ProductImageList != null && objproduct.ProductList[j].ProductImageList.Count > 0)
                        {

                            for (int i = 0; i < objproduct.ProductList[j].ProductImageList.Count; i++)
                            {
                                if (i == 0)
                                {

                                    html += "<div class=\"item active\"><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " alt=\"v1\" style=\"width: 100%;\"/></div>";


                                }
                                else
                                {
                                    html += "<div class=\"item\"><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " alt=\"v2\" style=\"width: 100%;\"/></div>";
                                }

                            }
                        }
                        html += "</div></div>";

                        html += "<div class=\"row\">";
                        html += "<div id=\"qty\">";
                        html += "<div class=\"align\">";
                        if (objproduct.ProductList[j].IsQtyFreeze == "True")
                        {
                            html += "<button class=\"btn\" type=\"button\" id=\"btnminus\" runat=\"server\" onclick=\"plusqty(0,this)\" disabled><i class=\"fa fa-minus\"></i></button>";
                            html += "<input readonly=true id=\"txtqty\" runat=\"server\" value=\"1\" onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\" />";
                            html += "<button class=\"btn\" type=\"button\" id=\"btnplus\" runat=\"server\" onclick=\"plusqty(1,this)\" disabled><i class=\"fa fa-plus\"></i></button>";
                        }
                        else
                        {
                            html += "<button class=\"btn\" type=\"button\" id=\"btnminus\" runat=\"server\" onclick=\"plusqty(0,this)\"><i class=\"fa fa-minus\"></i></button>";
                            html += "<input id=\"txtqty\" runat=\"server\" value=\"1\" onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\" />";
                            html += "<button class=\"btn\" type=\"button\" id=\"btnplus\" runat=\"server\" onclick=\"plusqty(1,this)\"><i class=\"fa fa-plus\"></i></button>";
                        }
                        html += "</div></div></div>";

                        decimal buy1 = 0;
                        string buy1price = objproduct.ProductList[j].pprice;
                        decimal.TryParse(buy1price.ToString(), out buy1);
                        buy1 = Math.Round(buy1, 0);
                        string BuyOne = "BUY ALONE AT " + clsCommon.rssymbol + buy1;

                        decimal buy2 = 0;
                        string check = objproduct.ProductList[j].pbuy2;
                        decimal.TryParse(check.ToString(), out buy2);
                        buy2 = Math.Round(buy2, 0);
                        string BuyOneWithFriend = "BUY WITH 1 FRIEND AT " + clsCommon.rssymbol + buy2;

                        decimal buy5 = 0;
                        string buy5price = objproduct.ProductList[j].pbuy5;
                        decimal.TryParse(buy5price.ToString(), out buy5);
                        buy5 = Math.Round(buy5, 0);
                        string BuyFivewithFriend = "BUY With 4 FRIENDS AT " + clsCommon.rssymbol + buy5;

                        string enddate = clsCommon.getProductExpiredOnDate(objproduct.ProductList[j].productid);

                        html += "<div class=\"row\"><div id=\"share-btn\"><div class=\"col-md-3 col-sm-2 col-xs-1\"></div><div id=\"btnbuyccode\"><div class=\"col-md-6 col-sm-8 col-xs-10\"><div class=\"buy-options\">";
                        html += "<p><input type=\"button\" name=\"BuyFivewithFriend\" class=\"button btn-block\"  value=\"" + BuyFivewithFriend + "\" id=\"BuyFivewithFriend\" onclick=\"BuyFivewithFriend_Click(" + objproduct.ProductList[j].productid + "," + objproduct.ProductList[j].pprice + "," + objproduct.ProductList[j].pwight.Substring(0, objproduct.ProductList[j].pwight.IndexOf('-')) + ",this)\" ></p>";
                        html += "<p><input type=\"button\" name=\"BuyOneWithFriend\" class=\"button btn-block\"  value=\"" + BuyOneWithFriend + "\" id=\"BuyOneWithFriend\" onclick=\"BuyOneWithFriend_Click(" + objproduct.ProductList[j].productid + "," + objproduct.ProductList[j].pprice + "," + objproduct.ProductList[j].pwight.Substring(0, objproduct.ProductList[j].pwight.IndexOf('-')) + ",this)\" ></p>";
                        html += "<p><input type=\"button\" name=\"BuyOne\" class=\"button btn-block\"  value=\"" + BuyOne + "\" id=\"BuyOne\" onclick=\"BuyOne_Click(" + objproduct.ProductList[j].productid + "," + objproduct.ProductList[j].pprice + "," + objproduct.ProductList[j].pwight.Substring(0, objproduct.ProductList[j].pwight.IndexOf('-')) + ",this)\" ></p>";
                        html += "</div></div></div><div class=\"col-md-3 col-sm-2 col-xs-1\"></div></div></div>";

                        html += "<div class=\"row offer-time\" style=\"border-bottom: 0px\"><input type=\"hidden\" id=\"lblenddate\" value= \"" + objproduct.ProductList[j].penddate + "\"> <div class=\"col-md-6 col-sm-6 col-xs-8 padding\"><div class=\"inner\"><img src=\"images/discount.png\"/>";
                        html += "<div id=\"timer\"><p>Offer Expiring: <span id=\"demo\" style=\"color: black;\"></span></p></div></div></div><div class=\"offer-zone\"><span class=\"button\">" + objproduct.ProductList[j].psold + "</span></div></div>";

                        html += "<div class=\"row\"><div id=\"location\" ><div class=\"delivery-line\"><p>Delivery in ahmedabad only</p></div><div class=\"address-search\" style=\"margin-left: 0px;\"><p style=\"margin: 0; font-size: 14px; font-weight: 700;\" > Delivery in 2-3 days</p><p style=\"margin: 0; font-size: 14px; font-weight: 700;\" > Free Delivery | Cash On Delivery</p></div></div></div>";
                        html += "<div class=\"row\"><div id=\"share\" ><p> Share this product with your friends</p><div class=\"social-links\" style=\"display: inline-flex\">";
                        html += "<a target=\"_blank\" href=\"https://web.whatsapp.com/send?text=Hello!l like this product on Sosho.in and thought of sharing with you! They’ve got some amazing group buy discounts, valid only till " + enddate + ". How about we buy it together?\" data-action=\"share/whatsapp/share\">";
                        html += "<img id=\"web\" src=\"images/whatsapp.png\"/></a>";
                        html += "<a target=\"_blank\" href=\"whatsapp://send?text=Hello!l like this product on Sosho.in and thought of sharing with you! They’ve got some amazing group buy discounts, valid only till " + enddate + ". How about we buy it together?\">";
                        html += "<img id=\"mo-wa\" src=\"images/whatsapp.png\" /></a>";
                        html += "<span id=\"fb-share-button\" style=\"padding-right:6px;\"><i class=\"fa fa-facebook\" style=\"cursor:pointer; font-size:22px; background:#3b5998; padding:6px; margin-right: 0px; color: #fff; border-radius: 4px;\"></i></span>";
                        html += "</div></div></div>";

                        html += "<div class=\"row\"><div id=\"share-btn\"><div class=\"col-md-3 col-sm-2 col-xs-1\"></div><div id=\"btnbuyccode\"><div class=\"col-md-6 col-sm-8 col-xs-10\"><div class=\"buy-options\">";
                        html += "<p><input class=\"button btn-block\" data-toggle=\"modal\" data-target=\"#myModal\"  type=\"button\" id=\"btnmodal\"  onclick=\"getproddesc(" + objproduct.ProductList[j].ProductImageList[0].prodid + ")\" value=\"Product Description\"></p>";
                        html += "</div></div></div><div class=\"col-md-3 col-sm-2 col-xs-1\"></div></div></div>";
                    }

                    //html.
                    // lblproductdec.InnerHtml = objproduct.ProductList[0].pdec;
                    //lblprodkeyfeature.InnerHtml = objproduct.ProductList[0].pkey;
                    //lblprodnote.InnerHtml = objproduct.ProductList[0].pnote;
                    //lblpricemain.InnerHtml = clsCommon.rssymbol + buy1.ToString();
                    string videourl = objproduct.ProductList[0].pvideo;

                    //content.InnerHtml = html;

                    if (!string.IsNullOrWhiteSpace(videourl))
                    {
                        video.InnerHtml = "<iframe width=\"100%\" height=\"280px\" id=\"VideoId\" runat=\"server\" src=\"" + videourl + "\" frameborder=\"0\"  allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\"></iframe>";
                    }
                }

            }

            string databanner = clsCommon.GET(Homebanner);


            if (!String.IsNullOrEmpty(databanner))
            {
                clsModals.BnnerImage objbanner = JsonConvert.DeserializeObject<clsModals.BnnerImage>(databanner);
                if (objbanner.response.Equals("1"))
                {
                    //lbltopbanner.Src = objbanner.BannerImageList[0].ImgUrl;
                    //link.HRef = objbanner.BannerImageList[0].DataLink;
                }
            }



        }
        catch (Exception ee)
        {

        }
    }
    public void Logout()
    {
        try
        {

            Response.Cookies.Clear();
            Response.Redirect("~/Default.aspx");

        }
        catch (Exception ee)
        {

        }
    }


    [System.Web.Services.WebMethod]
    public static object PincodeCheck(string Pincode)
    {
        try
        {
            string aa = clsCommon.strApiUrl + "/api/CheckPincode/CheckPincode?Pincode=" + Pincode + "";
            string res = clsCommon.GET(aa);

            if (res != "")
            {
                ClsOrderModels.CheckPincodeModel objpin = JsonConvert.DeserializeObject<ClsOrderModels.CheckPincodeModel>(res);
                //if (objpin.resultflag == "1")
                //{

                HttpContext.Current.Session["JurisdictionId"] = objpin.JurisdictionID;
                return res;


                //}
                //else
                //{
                //    return "0";
                //}


            }
            else
            {
                return "";
            }
        }
        catch (Exception ee)
        {

        }
        return "";

    }

    [System.Web.Services.WebMethod]
    public static object getproddesc(string prodid)
    {
        try
        {
            string aa = clsCommon.strApiUrl + "/api/Product/GetProductDetails";
            ClsOrderModels.ProdDescModel prodDesc = new ClsOrderModels.ProdDescModel();
            string data = clsCommon.GET(aa);

            if (!String.IsNullOrEmpty(data))
            {
                clsModals.getproduct product = JsonConvert.DeserializeObject<clsModals.getproduct>(data);
                clsModals.ProductDataList objproduct = product.ProductList.Where(m => m.productid == prodid).FirstOrDefault();
                if (product.response.Equals("1"))
                {
                    if (product.ProductList.Count > 0)
                    {
                        prodDesc.ProductDiscription = objproduct.pdec;
                        prodDesc.keyfeatures = objproduct.pkey;
                        prodDesc.Note = objproduct.pnote;
                    }
                }

            }


            return prodDesc;
        }
        catch (Exception ee)
        {
            return "";
        }


    }
    [System.Web.Services.WebMethod]
    //public static string ConfirmOrder(List<ClsOrderModels.ConfirmOrderModel> model)
    public static string ConfirmOrder(List<ClsOrderModels.ConfirmOrderNewModel> model, string WhatsAppNo, string PinCode)
    {
        ClsOrderModels.PlaceMultipleOrderNewModel orderModel = new ClsOrderModels.PlaceMultipleOrderNewModel();
        List<ClsOrderModels.ProductListNew> products = new List<ClsOrderModels.ProductListNew>();
        foreach (var item in model)
        {
            item.MrpTotal = item.Mrp * item.Qty;
            products.Add(new ClsOrderModels.ProductListNew
            {
                productid = item.Productid,
                PaidAmount = item.Mrp,
                Quantity = item.Qty.ToString(),
                UnitId = item.UnitId.ToString(),
                Unit = item.Unit.ToString(),
                Productvariant = item.Productvariant,
                AttributeId = item.Grpid,
                //UnitId = "Gram",
                //Unit = "500",
                couponCode = "0",
                refrcode = "0"
            });
        }

        //ClsOrderModels.PlaceMultipleOrderModel orderModel = new ClsOrderModels.PlaceMultipleOrderModel();
        //List<ClsOrderModels.ProductList> products = new List<ClsOrderModels.ProductList>();
        //foreach (var item in model)
        //{
        //    item.MrpTotal = item.Mrp * item.Qty;
        //    products.Add(new ClsOrderModels.ProductList
        //    {
        //        productid = item.Productid,
        //        buywith = item.Flag,
        //        PaidAmount = item.Mrp,
        //        Quantity = item.Qty.ToString(),
        //        couponCode = "0",
        //        refrcode = "0"
        //    });
        //}
        orderModel.discountamount = "0";
        orderModel.Redeemeamount = "0";
        //orderModel.CustomerId = clsCommon.getCurrentCustomer().id;
        orderModel.orderMRP = model.Sum(x => x.MrpTotal).ToString();
        orderModel.totalAmount = orderModel.orderMRP;
        orderModel.totalQty = model.Sum(x => x.Qty).ToString();
        //orderModel.totalWeight = (model.Sum(x => x.Qty) * model.Sum(x => x.Weight)).ToString();
        orderModel.totalWeight = "0";

        orderModel.products = products;
        HttpContext.Current.Session["ConfirmOrder"] = orderModel;

        HttpContext.Current.Session["IsCheckOut"] = "true";
        HttpContext.Current.Session["WhatsAppNo"] = WhatsAppNo;
        HttpContext.Current.Session["PinCode"] = PinCode;
        return "Success";
    }
    //protected void BuyOne_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string flag = "1";
    //        string qty = txtqty.Value;

    //        string flageng = clsCommon.Base64Encode(flag);
    //        string qtyeng = clsCommon.Base64Encode(qty);

    //        Session["BuyFlag"] = flageng;
    //        Session["BuyQty"] = qtyeng;
    //        if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
    //        {
    //            Response.Redirect("~/checkout.aspx?offercode=" + Request.QueryString["offercode"]);
    //        }
    //        else
    //        {
    //            Response.Redirect("~/checkout.aspx");
    //        }
    //    }
    //    catch (Exception ee)
    //    {


    //    }
    //}
    //protected void BuyOneWithFriend_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string flag = "2";
    //        string qty = txtqty.Value;

    //        string flageng = clsCommon.Base64Encode(flag);
    //        string qtyeng = clsCommon.Base64Encode(qty);

    //        Session["BuyFlag"] = flageng;
    //        Session["BuyQty"] = qtyeng;
    //        if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
    //        {
    //            Response.Redirect("~/checkout.aspx?offercode=" + Request.QueryString["offercode"]);
    //        }
    //        else
    //        {
    //            Response.Redirect("~/checkout.aspx");
    //        }
    //    }
    //    catch (Exception ee)
    //    {
    //    }
    //}
    //protected void BuyFivewithFriend_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string flag = "6";
    //        string qty = txtqty.Value;

    //        string flageng = clsCommon.Base64Encode(flag);
    //        string qtyeng = clsCommon.Base64Encode(qty);

    //        Session["BuyFlag"] = flageng;
    //        Session["BuyQty"] = qtyeng;
    //        if (!string.IsNullOrWhiteSpace(Request.QueryString["offercode"]))
    //        {
    //            Response.Redirect("~/checkout.aspx?offercode=" + Request.QueryString["offercode"]);
    //        }
    //        else
    //        {
    //            Response.Redirect("~/checkout.aspx");
    //        }
    //    }
    //    catch (Exception ee)
    //    {

    //    }
    //}

    [System.Web.Services.WebMethod]
    public static object GetFillData(string JurisdictionId)
    {
        try
        {
            string Categorybanner = clsCommon.strApiUrl + "/api/Category/GetDashBoardCategoryDetails";
            string databanner = clsCommon.GET(Categorybanner);
            clsModals.getCategory objcategory = JsonConvert.DeserializeObject<clsModals.getCategory>(databanner);
            string html = "";

            html = "<div id='ca-container' class='ca-new-container'>";
            html += "<div class='ca-nav'>";
            html += "<span class='ca-nav-prev' style='background: transparent url(../images/arrows.png) no-repeat top left;'>Previous</span>";
            html += "<span class='ca-nav-next' style='background: transparent url(../images/arrows.png) no-repeat top left; background-position:top right;'>Next</span>";
            html += "</div>";
            html += "<div class='ca-wrapper' style='overflow: hidden; '>";
            if (!String.IsNullOrEmpty(databanner))
            {
                if (objcategory.response.Equals("1"))
                {
                    for (int i = 0; i < objcategory.CategoryList.Count; i++)
                    {
                        html += "<div class='ca-item' style=' left: 0px;'>";
                        html += "<div>";
                        html += "<img src=" + objcategory.CategoryList[i].CategoryImage + " class='CategoryImagecenter' />";
                        html += "<span class='CategoryText'>" + objcategory.CategoryList[i].CategoryName + "</span>";
                        html += "</div>";
                        html += "</div>";
                    }
                    //lbltopbanner.Src = objcategory.CategoryList[0].CategoryImage;
                    //link.HRef = objcategory.CategoryList[0].CategoryDescription;
                }
            }
            html += "</div>";
            html += "</div>";
            //return objcategory;
            return html;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    [System.Web.Services.WebMethod]
    public static object GetProductdata(string JurisdictionId, string StartNo, string EndNo, string BannerCount, string ProductId = "", int CategoryId = -1,int SubCategoryId = -1,string InterBannerid = "",int SearchProductId = -1)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string html = "", sWhatsAppNo = "", BannerHtml = "", BannerIntermediateHtml = "", sProductCount = "", sInterBannerId = "", sBannerPosition = "";

            //string aa = clsCommon.strApiUrl + "/api/Product/GetProductDetails";
            //string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
            //string data = clsCommon.GET(aa);

            string dashboadapi = clsCommon.strApiUrl + "/api/Product/GetDashBoardProductDetails?JurisdictionID=" + JurisdictionId + "&CategoryId=" + CategoryId + "&SubCategoryId=" + SubCategoryId + "&ProductId=" + ProductId + "&StartNo=" + StartNo + "&EndNo=" + EndNo + "&InterBannerid=" + InterBannerid + "&SearchProductId=" + SearchProductId;
            string Homebanner = clsCommon.strApiUrl + "/api/Banner/GetDashBoardBannerImag?JurisdictionId=" + JurisdictionId;
            string data = clsCommon.GET(dashboadapi);

            int iBannerCount = 0;
            if (!String.IsNullOrEmpty(data))
            {
                clsModals.getNewproduct objproduct = JsonConvert.DeserializeObject<clsModals.getNewproduct>(data);
                if (objproduct.response.Equals("1"))
                {

                    sWhatsAppNo = objproduct.WhatsAppNo;
                    string sDiscount = "", sProductVariant = "", sMrp = "", sSoshoPrice = "", sWeight = "", sIsProductDescription = "", sAImageName = "";
                    decimal dMrp = 0, dSoshoPrice = 0, dSavePrice = 0;
                    string sProductId = "", sGrpId = "", sCategoryId = "";
                    string sisSelected = "", sProductName = "", sProductDesc = "", sProductKeyFeatures = "";
                    int iIndex = 0;
                    string  sBannerActionId = "", sOpenUrlLink = "", sBannerCategoryId = "", sCategoryName = "";
                    string sBannerProductId = "", sBannerProductMrp = "", sBannerWeight = "";

                    sProductCount = objproduct.ProductList.Where(x=>x.ItemType == "1").Count().ToString();
                    //if (StartNo == "1")
                    //    iBannerCount = 1;
                    //else
                    //{
                    //    if (objproduct.ProductList.Count == 5)
                    //        iBannerCount++;
                    //}


                    html = "<table style='width:100%;'>";
                    BannerHtml = "<div class='row'>";
                    for (int j = 0; j < objproduct.ProductList.Count; j++)
                    {
                        if (objproduct.ProductList[j].ItemType == "2")
                        {
                            BannerHtml += "<div class='offer-banner'>";
                            BannerHtml += "<img class='img' src='" + objproduct.ProductList[j].bannerURL + "' />";
                            //BannerHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
                            BannerHtml += "</div>";


                        }
                        if (objproduct.ProductList[j].ItemType == "1")
                        {


                            sProductId = objproduct.ProductList[j].ProductId;
                            sCategoryId = objproduct.ProductList[j].CategoryId;
                            //sDiscount = objproduct.ProductList[j].ProductAttributesList[j].Discount;
                            //sProductVariant = objproduct.ProductList[j].IsProductVariant;
                            sIsProductDescription = objproduct.ProductList[j].ProductDescription;
                            sProductName = objproduct.ProductList[j].ProductName;
                            sProductDesc = objproduct.ProductList[j].ProductDescription;
                            sProductKeyFeatures = objproduct.ProductList[j].ProductKeyFeatures;

                            //if (sProductVariant.ToString() == "false")
                            //{
                            //    if (!string.IsNullOrEmpty(objproduct.ProductList[j].SpecialMessage))
                            //    {
                            //        html += "<tr  id='tr" + iIndex + "'>";
                            //        html += "<td colspan='5' class='BlueText' style='padding:7px;padding-top:5px;text-align:center; '>" + objproduct.ProductList[j].SpecialMessage + " </td>";
                            //        html += "</tr>";
                            //    }
                            //    html += "<tr id='tr" + iIndex + "'>";

                            //    if (!string.IsNullOrEmpty(sDiscount))
                            //    {

                            //        html += "<td style='padding-top:5px;width:50%;text-align:center;'>";
                            //        if (sDiscount.ToString() != "0% Off" && sDiscount.ToString() != "₹ 0 Off")
                            //        {
                            //            html += "<div  class='DiscountOffer'>";
                            //            html += sDiscount;
                            //            html += "</div>";
                            //        }
                            //    }
                            //    else
                            //        html += "<td style='padding-top:5px;width:50%;text-align:center;'>";

                            //    if (objproduct.ProductList[j].ProductImageList != null && objproduct.ProductList[j].ProductImageList.Count > 0)
                            //    {

                            //        for (int i = 0; i < objproduct.ProductList[j].ProductImageList.Count; i++)
                            //        {
                            //            if (i == 0)
                            //            {
                            //                html += "<div><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " class='ProductImage'/></div>";
                            //            }
                            //            else
                            //            {
                            //                html += "<div><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " class='ProductImage'/></div>";
                            //            }

                            //            //}

                            //            //}
                            //            html += "</td>";
                            //            html += "<td style='width:50%;'>";
                            //            //html += "<table style='width:100%; position:relative; bottom:-6px; right:166px;'>";
                            //            html += "<table class='tableheader'>";
                            //            if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
                            //            {
                            //                html += "<tr>";
                            //                html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px; text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
                            //                html += "</tr>";
                            //            }
                            //            if (!string.IsNullOrEmpty(objproduct.ProductList[j].MRP))
                            //            {
                            //                dMrp = Convert.ToDecimal(objproduct.ProductList[j].MRP);
                            //            }
                            //            if (!string.IsNullOrEmpty(objproduct.ProductList[j].SellingPrice))
                            //            {
                            //                dSoshoPrice = Convert.ToDecimal(objproduct.ProductList[j].SellingPrice);
                            //            }
                            //            dSavePrice = (dMrp - dSoshoPrice);
                            //            html += "<tr class='AmazonFont'>";
                            //            //html += "<td style='padding-top:5px;text-align:-webkit-center;' colspan='3'>";
                            //            //html += "<td style='padding-top:5px;' colspan='3'>";
                            //            html += "<td class='ProductCenter' colspan='3'>";
                            //            html += "<span class='ProductName'>" + sProductName + "</span>";
                            //            html += "</td>";
                            //            html += "</tr>";
                            //            html += "<tr>";
                            //            html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
                            //            html += "<td class='ProductMRPValue'>:</td>";
                            //            html += "<td class='ProductMRPValue ProductMRPText'><del>₹ " + objproduct.ProductList[j].SellingPrice + "</del></td>";
                            //            html += "</tr>";
                            //            html += "<tr class='AmazonFont' style='padding-top:15px;'>";
                            //            html += "<td class='SoshoPrice' >Sosho Price</td>";
                            //            html += "<td class='SoshoColon'>:</td>";
                            //            html += "<td class='SoshoPriceValue'>₹ " + objproduct.ProductList[j].MRP + "</td>";
                            //            //html += "<td class='SoshoPrice'>₹ " + objproduct.ProductList[j].MRP + "</td>";
                            //            html += "</tr>";
                            //            html += "<tr class='AmazonFont'>";
                            //            html += "<td class='ProudctMRPText'>You Save</td>";
                            //            html += "<td>:</td>";
                            //            html += "<td class='ProductMRPText'>₹ " + dSavePrice + "</td>";
                            //            html += "</tr>";
                            //            html += "<tr>";
                            //            html += "<td  class='ProductDropDown' colspan='2'>";
                            //            //html += "<input id='txtweight' class='AmazonFont WeightText' runat='server' value='" + objproduct.ProductList[j].Weight + "' />";
                            //            html += "<span class='AmazonFont'>" + objproduct.ProductList[j].Weight + "</span>";
                            //            //html += "</td><td></td> ";
                            //            html += "</td> ";
                            //            html += "<td style='padding-top:15px;padding-left:0px;' >";
                            //            if (!string.IsNullOrEmpty(sIsProductDescription))
                            //            {
                            //                if (sIsProductDescription.ToString() == "true")
                            //                    html += "<img src='images/info - new.png' style='width:20px;height:20px' onclick='image(" + iIndex + "," + sProductId + ",this)' />";
                            //            }
                            //            //html += "<span style='font-family:'Amazon Ember''><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
                            //            html += "</td>";
                            //            //html += "<td style='font-family:Verdana;font-size:18px;padding-top:15px; '></td>";
                            //            html += "</td>";
                            //            html += "</tr>";

                            //            html += "<tr id='BtnAdd" + sProductId + "'>";
                            //            //html += "<td style='padding-top:15px;padding-left:27px;'>";
                            //            html += "<td style='padding-top:6px;padding-left:10px;' colspan='3'>";
                            //            html += "<button type='button' class='btn BlueText BtnAddText' onclick='AddClick(" + iIndex + "," + sProductId + "," + sProductId + "," + sMrp + ",this)'>ADD</button>";
                            //            html += "<input type='hidden' id='hdnProductId" + sProductId + "' value='" + sProductId + "'>";
                            //            html += "<input type='hidden' id='hdnGrpId" + sProductId + "' value='" + sProductId + "'>";
                            //            html += "<input type='hidden' id='hdnCategoryId" + sProductId + "' value='" + sCategoryId + "'>";
                            //            html += "<input type='hidden' id='hdnPName" + sProductId + "' value='" + sProductName + "'>";
                            //            //html += "<input type='hidden' id='hdnPDescription" + iIndex + "' value='" + sProductDesc + "'>";
                            //            html += "<input type='hidden' id='hdnPKeyFeature" + sProductId + "' value='" + sProductKeyFeatures + "'>";
                            //            html += "<input type='hidden' id='hdnProductVariant" + sProductId + "' value='" + sProductVariant + "'>";
                            //            //html += "</td>";
                            //            //html += "<td>";
                            //            //html += "&nbsp; <span style='font-family:'Amazon Ember''><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
                            //            html += "&nbsp;<span class='SoldCount'> " + objproduct.ProductList[j].SoldCount + "</span>";
                            //            html += "</td>";
                            //            html += "</tr>";
                            //            html += "<tr id='AddShow" + sProductId + "' style='display:none;'>";
                            //            html += "<td colspan='3' style='padding-top:15px;padding-left:10px;' class='AmazonFont'>";
                            //            html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='plusqty(0," + sProductId + "," + sProductId + ",this)'><i class='fa fa-minus'></i></button>";
                            //            html += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:40px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
                            //            html += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='plusqty(1," + sProductId + "," + sProductId + ",this)'><i class='fa fa-plus'></i></button>";
                            //            html += "</td>";
                            //            html += "</tr>";
                            //            html += "</table>";
                            //            html += "</td>";
                            //            html += "</tr>";

                            //            html += "<tr>";
                            //            html += "<td colspan='5'> <hr class='solid'>";
                            //            html += "</td>";
                            //            html += "</tr>";
                            //            //html += "</td>";
                            //            //html += "</tr>";
                            //            //html += "</table>";
                            //            iIndex++;
                            //        }

                            //    }

                            //}
                            //else
                            //{
                            //Product Attribute Image
                            if (objproduct.ProductList[j].ProductAttributesList != null && objproduct.ProductList[j].ProductAttributesList.Count > 0)
                            {

                                for (int h = 0; h < objproduct.ProductList[j].ProductAttributesList.Count; h++)
                                {
                                    sGrpId = objproduct.ProductList[j].ProductAttributesList[h].AttributeId;
                                    sDiscount = objproduct.ProductList[j].ProductAttributesList[h].Discount;
                                    sMrp = objproduct.ProductList[j].ProductAttributesList[h].Mrp;
                                    sSoshoPrice = objproduct.ProductList[j].ProductAttributesList[h].soshoPrice;
                                    sWeight = objproduct.ProductList[j].ProductAttributesList[h].weight;
                                    sAImageName = objproduct.ProductList[j].ProductAttributesList[h].AImageName;
                                    sisSelected = objproduct.ProductList[j].ProductAttributesList[h].isSelected;


                                    if (!string.IsNullOrEmpty(sMrp))
                                        dMrp = Convert.ToDecimal(sMrp);
                                    if (!string.IsNullOrEmpty(sSoshoPrice))
                                        dSoshoPrice = Convert.ToDecimal(sSoshoPrice);

                                    dSavePrice = (dMrp - dSoshoPrice);
                                    //}
                                    if (!string.IsNullOrEmpty(objproduct.ProductList[j].SpecialMessage))
                                    {
                                        if (sisSelected == "false")
                                            html += "<tr  id='tr" + iIndex + "' style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                                        else
                                            html += "<tr  id='tr" + iIndex + "' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                                        html += "<td colspan='5' class='BlueText' style='padding:7px;padding-top:5px;text-align:center; '>" + objproduct.ProductList[j].SpecialMessage + " </td>";
                                        html += "</tr>";
                                    }
                                    if (sisSelected == "false")
                                        html += "<tr id='tr" + iIndex + "' style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                                    else
                                        html += "<tr id='tr" + iIndex + "' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";


                                    if (!string.IsNullOrEmpty(sDiscount))
                                    {
                                        //if (sisSelected == "false")
                                        //    html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' style='display:none;'>";
                                        //else
                                        html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' >";
                                        if (sDiscount.ToString() != "0% Off" && sDiscount.ToString() != "₹ 0 Off")
                                        {
                                            html += "<div   class='DiscountOffer'>";
                                            html += sDiscount;
                                            html += "</div>";
                                        }
                                    }
                                    else
                                        html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' >";

                                    html += "<div><img src=\'" + sAImageName + "'\" class='ProductImage'/></div>";
                                    //}
                                    html += "</td>";
                                    html += "<td style='width:50%;'>";
                                    //html += "<table style='width:100%;position:relative;bottom:-6px;right:166px;'>";
                                    //if (sisSelected == "false")
                                    //    html += "<table class='tableheader' id='tbl" + iIndex + "' style='display:none;'>";
                                    //else
                                    html += "<table class='tableheader' id='tbl" + iIndex + "'>";
                                    if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
                                    {
                                        html += "<tr>";
                                        html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px;text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
                                        html += "</tr>";
                                    }

                                    html += "<tr class='AmazonFont'>";

                                    //html += "<td style='padding-top:5px;text-align:-webkit-center;' colspan='3'>";
                                    //html += "<td style='padding-top:5px;' colspan='3'>";

                                    html += "<td class='ProductCenter' colspan='3'>";

                                    html += "<span class='ProductName'>" + sProductName + "</span>";
                                    html += "</td>";
                                    html += "</tr>";
                                    html += "<tr>";
                                    html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
                                    html += "<td class='ProductMRPValue'>:</td>";
                                    html += "<td class='ProductMRPValue ProductMRPText'><del>₹ " + sMrp + "</del></td>";
                                    html += "</tr>";
                                    html += "<tr class='AmazonFont' style='padding-top:15px;'>";
                                    html += "<td class='SoshoPrice'>Sosho Price</td>";
                                    html += "<td class='SoshoColon'>:</td>";
                                    html += "<td class='SoshoPriceValue'>₹ " + sSoshoPrice + "</td>";
                                    //html += "<td class='SoshoPrice'>₹ " + sSoshoPrice + "</td>";
                                    html += "</tr>";
                                    html += "<tr class='AmazonFont'>";
                                    html += "<td class='ProudctMRPText'>You Save</td>";
                                    html += "<td>:</td>";
                                    html += "<td class='ProductMRPText'>₹ " + dSavePrice + "</td>";
                                    html += "</tr>";
                                    html += "<tr>";
                                    html += "<td class='ProductDropDown' colspan='2'>";
                                    html += "<select ID='ddlUnit" + sGrpId + "'  runat='server' onclick=\"myPackSize(" + iIndex + ",'" + sDiscount + "'," + sProductId + "," + sGrpId + ",this)\">";
                                    html += "<option Value='" + sWeight + "'>" + sWeight + "</option>";
                                    html += "</select>";
                                    html += "</td>";
                                    html += "<td>";
                                    //html += "</td><td></td> ";
                                    //html += "<td style='padding-top:15px;padding-left:0px;' >";
                                    if (!string.IsNullOrEmpty(sIsProductDescription))
                                    {
                                        // if (sIsProductDescription.ToString() == "true")
                                        html += "<img src='images/info - new.png' style='width:20px;height:20px;cursor:pointer;' onclick='image(" + iIndex + "," + sProductId + ",this)' />";
                                    }
                                    //html += "<span class='SoldCount'><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
                                    html += "</td>";
                                    //html += "<td style='font-family:Verdana;font-size:18px;padding-top:15px;'></td>";
                                    html += "</tr>";
                                    //}


                                    //html += "<tr id='BtnAdd" + iIndex + "'>";
                                    html += "<tr id='BtnAdd" + sGrpId + "'>";
                                    //html += "<td style='padding-top:15px;padding-left:27px;'>";
                                    html += "<td style='padding-top:6px;padding-left:10px;' colspan='3'>";
                                    html += "<button type='button' class='btn BlueText BtnAddText' onclick='AddClick(" + iIndex + "," + sProductId + "," + sGrpId + "," + sSoshoPrice + ",this)'>ADD</button>";
                                    html += "<input type='hidden' id='hdnProductId" + sGrpId + "' value='" + sProductId + "'>";
                                    html += "<input type='hidden' id='hdnGrpId" + sGrpId + "' value='" + sGrpId + "'>";
                                    html += "<input type='hidden' id='hdnCategoryId" + sGrpId + "' value='" + sCategoryId + "'>";
                                    html += "<input type='hidden' id='hdnPName" + sGrpId + "' value='" + sProductName + "'>";
                                    //html += "<input type='hidden' id='hdnPDescription" + iIndex + "' value='" + sProductDesc + "'>";
                                    html += "<input type='hidden' id='hdnPKeyFeature" + sGrpId + "' value='" + sProductKeyFeatures + "'>";
                                    html += "<input type='hidden' id='hdnProductVariant" + sGrpId + "' value='" + sProductVariant + "'>";
                                    //html += "</td>";
                                    //html += "<td>";
                                    html += "&nbsp;<span class='SoldCount'> " + objproduct.ProductList[j].SoldCount + "</span>";
                                    html += "</td>";
                                    html += "</tr>";
                                    //html += "<tr id='AddShow" + iIndex + "' style='display:none;'>";
                                    html += "<tr id='AddShow" + sGrpId + "' style='display:none;'>";
                                    html += "<td colspan='3' style='padding-top:15px;padding-left:10px;' class='AmazonFont'>";
                                    html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='plusqty(0," + sProductId + "," + sGrpId + "," + sSoshoPrice + ",this)'><i class='fa fa-minus'></i></button>";
                                    html += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:40px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
                                    html += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='plusqty(1," + sProductId + "," + sGrpId + "," + sSoshoPrice + ",this)'><i class='fa fa-plus'></i></button>";
                                    html += "</td>";
                                    html += "</tr>";
                                    html += "</table>";
                                    html += "</td>";
                                    html += "</tr>";


                                    if (sisSelected == "false")
                                        html += "<tr style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                                    else
                                        html += "<tr class='trGrp" + sGrpId + "'>";
                                    html += "<td colspan='5'> <hr class='solid'>";
                                    html += "</td>";
                                    html += "</tr>";
                                    //html += "</td>";
                                    //html += "</tr>";
                                    //html += "</table>";
                                    iIndex++;
                                }

                            }
                            // }
                        }


                        if (objproduct.ProductList[j].ItemType == "3")
                        {


                            sBannerActionId = objproduct.ProductList[j].ActionId.ToString();

                            BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
                            BannerIntermediateHtml += "<div class='offer-banner'>";

                            if (sBannerActionId == "1") // Action Id = 1 (Open Url)
                            {
                                sOpenUrlLink = objproduct.ProductList[j].openUrlLink.ToString();

                                BannerIntermediateHtml += "<a href='" + sOpenUrlLink + "' target='_blank'>";
                                BannerIntermediateHtml += "<img class='img' src='" + objproduct.ProductList[j].bannerURL + "' />";
                                BannerIntermediateHtml += "</a>";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "</div>";
                            }
                            else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
                            {
                                sBannerCategoryId = objproduct.ProductList[j].ActionCategoryId.ToString();
                                sCategoryName = objproduct.ProductList[j].ActionCategoryName.ToString();

                                BannerIntermediateHtml += "<img class='img' style='cursor:pointer;' src='" + objproduct.ProductList[j].bannerURL + "' onclick='Categoryimage(" + sBannerCategoryId + ",this)'/>";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "</div>";
                            }
                            else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
                            {
                                sBannerProductId = objproduct.ProductList[j].ProductId.ToString();

                                sBannerProductMrp = objproduct.ProductList[j].ProductAttributesList[0].soshoPrice.ToString();
                                sBannerWeight = objproduct.ProductList[j].ProductAttributesList[0].weight.ToString();
                                sGrpId = objproduct.ProductList[j].ProductAttributesList[0].AttributeId;
                                //sBannerProductMrp = objbanner.IntermediateBannerImages[0].MRP.ToString();
                                //sBannerWeight = objbanner.IntermediateBannerImages[0].Weight.ToString();

                                BannerIntermediateHtml += "<div class='offer-banner'>";
                                BannerIntermediateHtml += "<img class='img' src='" + objproduct.ProductList[j].bannerURL + "' />";
                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
                                BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + 0 + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>Buy Now</button>";
                                BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
                                //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
                                BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sGrpId + "," + sBannerProductMrp + ",this)'><i class='fa fa-minus'></i></button>";
                                BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
                                //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
                                BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sGrpId + "," + sBannerProductMrp + ",this)'><i class='fa fa-plus'></i></button>";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "</div>";

                            }
                            else if (sBannerActionId == "-1") // Action Id =-1 (None)
                            {
                                BannerIntermediateHtml += "<img class='img' src='" + objproduct.ProductList[j].bannerURL + "' />";
                                BannerIntermediateHtml += "</div>";
                                BannerIntermediateHtml += "</div>";
                            }
                            sInterBannerId = objproduct.ProductList[j].bannerId;
                            BannerIntermediateHtml += "</div>";

                        }

                        if (objproduct.ProductList.Count == (j + 1))
                        {
                            var hdnProdId = objproduct.ProductList.Where(x => x.ItemType == "1").FirstOrDefault().ProductId;
                            html += "<input type='hidden' id='hdnProdId' value='" + hdnProdId + "'/>";
                        }
                        
                    }

                    html += "</table>";
                    BannerHtml += "</div>";

                    sBannerPosition = objproduct.BannerPosition;
                }

            }

            //string databanner = clsCommon.GET(Homebanner);

            //string sBannerPosition = "", sBannerActionId = "", sOpenUrlLink = "", sBannerCategoryId = "", sCategoryName = "";
            //string sBannerProductId = "", sBannerProductMrp = "", sBannerWeight="";
            //if (!String.IsNullOrEmpty(databanner))
            //{
            //    clsModals.NewBnnerImage objbanner = JsonConvert.DeserializeObject<clsModals.NewBnnerImage>(databanner);
            //    if (objbanner.response.Equals("1"))
            //    {
            //        sBannerPosition = objbanner.BannerPosition;
            //        if (objbanner.BannerImageList != null && objbanner.BannerImageList.Count > 0)
            //        {
            //            BannerHtml = "<div class='row'>";
            //            for (int h = 0; h < objbanner.BannerImageList.Count; h++)
            //            {
            //                BannerHtml += "<div class='offer-banner'>";
            //                BannerHtml += "<img class='img' src='" + objbanner.BannerImageList[h].bannerURL + "' />";
            //                BannerHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                BannerHtml += "</div>";
            //                if (h == 0)
            //                    BannerHtml += "<br />";
            //            }
            //            BannerHtml += "</div>";
            //        }
            //        if (objbanner.IntermediateBannerImages != null && objbanner.IntermediateBannerImages.Count > 0)
            //        {
            //            if (StartNo == "1")
            //            {
            //                if (iBannerCount == 1)
            //                {
            //                    sBannerActionId = objbanner.IntermediateBannerImages[0].ActionId.ToString();

            //                    BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
            //                    BannerIntermediateHtml += "<div class='offer-banner'>";

            //                    if (sBannerActionId == "1") // Action Id = 1 (Open Url)
            //                    {
            //                        sOpenUrlLink = objbanner.IntermediateBannerImages[0].openUrlLink.ToString();

            //                        BannerIntermediateHtml += "<a href='" + sOpenUrlLink + "' target='_blank'>";
            //                        BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
            //                        BannerIntermediateHtml += "</a>";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "</div>";
            //                    }
            //                    else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
            //                    {
            //                        sBannerCategoryId = objbanner.IntermediateBannerImages[0].categoryId.ToString();
            //                        sCategoryName = objbanner.IntermediateBannerImages[0].categoryName.ToString();

            //                        BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' onclick='Categoryimage(" + sBannerCategoryId + ",'" + sCategoryName+ "',this)' />";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "</div>";
            //                    }
            //                    else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
            //                    {
            //                        sBannerProductId = objbanner.IntermediateBannerImages[0].ProductId.ToString();
            //                        sBannerProductMrp = objbanner.IntermediateBannerImages[0].ProductAttributesList[0].Mrp.ToString();
            //                        sBannerWeight = objbanner.IntermediateBannerImages[0].ProductAttributesList[0].weight.ToString();
            //                        //sBannerProductMrp = objbanner.IntermediateBannerImages[0].MRP.ToString();
            //                        //sBannerWeight = objbanner.IntermediateBannerImages[0].Weight.ToString();

            //                        BannerIntermediateHtml += "<div class='offer-banner'>";
            //                        BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
            //                        BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
            //                        BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + 0 + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>ADD</button>";
            //                        BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
            //                        //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
            //                        BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
            //                        BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
            //                        //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
            //                        BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "</div>";

            //                    }
            //                    else if (sBannerActionId == "-1") // Action Id =-1 (None)
            //                    {
            //                        BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
            //                        BannerIntermediateHtml += "</div>";
            //                        BannerIntermediateHtml += "</div>";
            //                    }
            //                    //BannerIntermediateHtml += "</div>";
            //                    //BannerIntermediateHtml += "</div>";

            //                    //BannerIntermediateHtml = "<div class='row'>";
            //                    //BannerIntermediateHtml += "<div class='offer-banner'>";
            //                    //BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
            //                    //BannerIntermediateHtml += "</div>";
            //                    //BannerIntermediateHtml += "</div>";
            //                }
            //            }
            //            else
            //            {
            //                if (iBannerCount.ToString() != sProductCount.ToString())
            //                {
            //                    BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
            //                    for (int h = 0; h < objbanner.IntermediateBannerImages.Count; h++)
            //                    {
            //                        sBannerActionId = objbanner.IntermediateBannerImages[h].ActionId.ToString();

            //                        if (sBannerActionId == "1") // Action Id = 1 (Open Url)
            //                        {
            //                            sOpenUrlLink = objbanner.IntermediateBannerImages[h].openUrlLink.ToString();

            //                            if (h > 0)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }
            //                        else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
            //                        {
            //                            sBannerCategoryId = objbanner.IntermediateBannerImages[h].categoryId.ToString();
            //                            sCategoryName = objbanner.IntermediateBannerImages[h].categoryName.ToString();

            //                            if (h > 0)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' onclick='Categoryimage(" + sBannerCategoryId + ",'" + sCategoryName + "',this)' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }
            //                        else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
            //                        {
            //                            sBannerProductId = objbanner.IntermediateBannerImages[h].ProductId.ToString();
            //                            //sBannerProductMrp = objbanner.IntermediateBannerImages[h].MRP.ToString();
            //                            //sBannerWeight = objbanner.IntermediateBannerImages[h].Weight.ToString();
            //                            sBannerProductMrp = objbanner.IntermediateBannerImages[h].ProductAttributesList[h].Mrp.ToString();
            //                            sBannerWeight = objbanner.IntermediateBannerImages[h].ProductAttributesList[h].weight.ToString();
            //                            if (h > 0)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
            //                                BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + h + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>ADD</button>";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
            //                                //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
            //                                BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
            //                                BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
            //                                //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
            //                                BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }
            //                        else if (sBannerActionId == "-1") // Action Id =-1 (None)
            //                        {
            //                            //BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";

            //                            if (h > 0)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }

            //                    }
            //                }
            //                else
            //                {
            //                    for (int h = 0; h < objbanner.IntermediateBannerImages.Count; h++)
            //                    {
            //                        sBannerActionId = objbanner.IntermediateBannerImages[h].ActionId.ToString();
            //                        BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
            //                        if (sBannerActionId == "1") // Action Id = 1 (Open Url)
            //                        {
            //                            sOpenUrlLink = objbanner.IntermediateBannerImages[h].openUrlLink.ToString();
            //                            if (h == iBannerCount)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }
            //                        else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
            //                        {
            //                            sBannerCategoryId = objbanner.IntermediateBannerImages[h].categoryId.ToString();
            //                            sCategoryName = objbanner.IntermediateBannerImages[h].categoryName.ToString();

            //                            if (h == iBannerCount)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }
            //                        else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
            //                        {
            //                            if (h == iBannerCount)
            //                            {
            //                                sBannerProductId = objbanner.IntermediateBannerImages[h].ProductId.ToString();
            //                                //sBannerProductMrp = objbanner.IntermediateBannerImages[h].MRP.ToString();
            //                                //sBannerWeight = objbanner.IntermediateBannerImages[h].Weight.ToString();
            //                                sBannerProductMrp = objbanner.IntermediateBannerImages[h].ProductAttributesList[h].Mrp.ToString();
            //                                sBannerWeight = objbanner.IntermediateBannerImages[h].ProductAttributesList[h].weight.ToString();
            //                                if (h > 0)
            //                                {
            //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                    BannerIntermediateHtml += "</div>";
            //                                    BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
            //                                    BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + h + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>ADD</button>";
            //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
            //                                    BannerIntermediateHtml += "</div>";
            //                                    BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
            //                                    //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
            //                                    BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
            //                                    BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
            //                                    //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
            //                                    BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
            //                                    BannerIntermediateHtml += "</div>";
            //                                    if (h == 0)
            //                                        BannerIntermediateHtml += "<br />";
            //                                }
            //                            }
            //                        }
            //                        else if (sBannerActionId == "-1") // Action Id =-1 (None)
            //                        {
            //                            //BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";

            //                            if (h == iBannerCount)
            //                            {
            //                                BannerIntermediateHtml += "<div class='offer-banner'>";
            //                                BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
            //                                BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
            //                                BannerIntermediateHtml += "</div>";
            //                                if (h == 0)
            //                                    BannerIntermediateHtml += "<br />";
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            BannerIntermediateHtml += "</div>";
            //        }
            //    }
            //}


            //return html;
           
            return new { productcount = sProductCount, response = html, whatsapp = sWhatsAppNo, bannerresponse = BannerHtml, intermediateresponse = BannerIntermediateHtml, productdata = JsonConvert.DeserializeObject<clsModals.getNewproduct>(data), InterBannerId = sInterBannerId };
        }
        catch (Exception ee)
        {
            return "";
        }


        ////Old Code
        //try
        //{
        //    dbConnection dbc = new dbConnection();
        //    string html = "", sWhatsAppNo = "", BannerHtml = "", BannerIntermediateHtml = "", sProductCount = "";

        //    //string aa = clsCommon.strApiUrl + "/api/Product/GetProductDetails";
        //    //string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
        //    //string data = clsCommon.GET(aa);

        //    string dashboadapi = clsCommon.strApiUrl + "/api/Product/GetDashBoardProductDetails?JurisdictionID=" + JurisdictionId + "&StartNo=" + StartNo + "&EndNo=" + EndNo;
        //    string Homebanner = clsCommon.strApiUrl + "/api/Banner/GetDashBoardBannerImag?JurisdictionId=" + JurisdictionId;
        //    string data = clsCommon.GET(dashboadapi);

        //    int iBannerCount = 0;
        //    if (!String.IsNullOrEmpty(data))
        //    {
        //        clsModals.getNewproduct objproduct = JsonConvert.DeserializeObject<clsModals.getNewproduct>(data);
        //        if (objproduct.response.Equals("1"))
        //        {
        //            sWhatsAppNo = objproduct.WhatsAppNo;
        //            string sDiscount = "", sProductVariant = "", sMrp = "", sSoshoPrice = "", sWeight = "", sIsProductDescription = "", sAImageName = "";
        //            decimal dMrp = 0, dSoshoPrice = 0, dSavePrice = 0;
        //            string sProductId = "", sGrpId = "", sCategoryId = "";
        //            string sisSelected = "", sProductName = "", sProductDesc = "", sProductKeyFeatures = "";
        //            int iIndex = 0;
        //            sProductCount = objproduct.ProductList.Count.ToString();
        //            if (StartNo == "1")
        //                iBannerCount = 1;
        //            else
        //            {
        //                if (objproduct.ProductList.Count == 5)
        //                    iBannerCount++;
        //            }
        //            html = "<table style='width:100%;'>";
        //            for (int j = 0; j < objproduct.ProductList.Count; j++)
        //            {
        //                sProductId = objproduct.ProductList[j].ProductId;
        //                sCategoryId = objproduct.ProductList[j].CategoryId;
        //                sDiscount = objproduct.ProductList[j].Discount;
        //                sProductVariant = objproduct.ProductList[j].IsProductVariant;
        //                sIsProductDescription = objproduct.ProductList[j].IsProductDescription;
        //                sProductName = objproduct.ProductList[j].Name;
        //                sProductDesc = objproduct.ProductList[j].ProductDescription;
        //                sProductKeyFeatures = objproduct.ProductList[j].ProductKeyFeatures;

        //                if (sProductVariant.ToString() == "false")
        //                {
        //                    if (!string.IsNullOrEmpty(objproduct.ProductList[j].SpecialMessage))
        //                    {
        //                        html += "<tr  id='tr" + iIndex + "'>";
        //                        html += "<td colspan='5' class='BlueText' style='padding:7px;padding-top:5px;text-align:center; '>" + objproduct.ProductList[j].SpecialMessage + " </td>";
        //                        html += "</tr>";
        //                    }
        //                    html += "<tr id='tr" + iIndex + "'>";

        //                    if (!string.IsNullOrEmpty(sDiscount))
        //                    {

        //                        html += "<td style='padding-top:5px;width:50%;text-align:center;'>";
        //                        if (sDiscount.ToString() != "0% Off" && sDiscount.ToString() != "₹ 0 Off")
        //                        {
        //                            html += "<div  class='DiscountOffer'>";
        //                            html += sDiscount;
        //                            html += "</div>";
        //                        }
        //                    }
        //                    else
        //                        html += "<td style='padding-top:5px;width:50%;text-align:center;'>";

        //                    if (objproduct.ProductList[j].ProductImageList != null && objproduct.ProductList[j].ProductImageList.Count > 0)
        //                    {

        //                        for (int i = 0; i < objproduct.ProductList[j].ProductImageList.Count; i++)
        //                        {
        //                            if (i == 0)
        //                            {
        //                                html += "<div><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " class='ProductImage'/></div>";
        //                            }
        //                            else
        //                            {
        //                                html += "<div><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " class='ProductImage'/></div>";
        //                            }

        //                            //}

        //                            //}
        //                            html += "</td>";
        //                            html += "<td style='width:50%;'>";
        //                            //html += "<table style='width:100%; position:relative; bottom:-6px; right:166px;'>";
        //                            html += "<table class='tableheader'>";
        //                            if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
        //                            {
        //                                html += "<tr>";
        //                                html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px; text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
        //                                html += "</tr>";
        //                            }
        //                            if (!string.IsNullOrEmpty(objproduct.ProductList[j].MRP))
        //                            {
        //                                dMrp = Convert.ToDecimal(objproduct.ProductList[j].MRP);
        //                            }
        //                            if (!string.IsNullOrEmpty(objproduct.ProductList[j].SellingPrice))
        //                            {
        //                                dSoshoPrice = Convert.ToDecimal(objproduct.ProductList[j].SellingPrice);
        //                            }
        //                            dSavePrice = (dMrp - dSoshoPrice);
        //                            html += "<tr class='AmazonFont'>";
        //                            //html += "<td style='padding-top:5px;text-align:-webkit-center;' colspan='3'>";
        //                            //html += "<td style='padding-top:5px;' colspan='3'>";
        //                            html += "<td class='ProductCenter' colspan='3'>";
        //                            html += "<span class='ProductName'>" + sProductName + "</span>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            html += "<tr>";
        //                            html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
        //                            html += "<td class='ProductMRPValue'>:</td>";
        //                            html += "<td class='ProductMRPValue ProductMRPText'><del>₹ " + objproduct.ProductList[j].SellingPrice + "</del></td>";
        //                            html += "</tr>";
        //                            html += "<tr class='AmazonFont' style='padding-top:15px;'>";
        //                            html += "<td class='SoshoPrice' >Sosho Price</td>";
        //                            html += "<td class='SoshoColon'>:</td>";
        //                            html += "<td class='SoshoPriceValue'>₹ " + objproduct.ProductList[j].MRP + "</td>";
        //                            //html += "<td class='SoshoPrice'>₹ " + objproduct.ProductList[j].MRP + "</td>";
        //                            html += "</tr>";
        //                            html += "<tr class='AmazonFont'>";
        //                            html += "<td class='ProudctMRPText'>You Save</td>";
        //                            html += "<td>:</td>";
        //                            html += "<td class='ProductMRPText'>₹ " + dSavePrice + "</td>";
        //                            html += "</tr>";
        //                            html += "<tr>";
        //                            html += "<td  class='ProductDropDown' colspan='2'>";
        //                            //html += "<input id='txtweight' class='AmazonFont WeightText' runat='server' value='" + objproduct.ProductList[j].Weight + "' />";
        //                            html += "<span class='AmazonFont'>" + objproduct.ProductList[j].Weight + "</span>";
        //                            //html += "</td><td></td> ";
        //                            html += "</td> ";
        //                            html += "<td style='padding-top:15px;padding-left:0px;' >";
        //                            if (!string.IsNullOrEmpty(sIsProductDescription))
        //                            {
        //                                if (sIsProductDescription.ToString() == "true")
        //                                    html += "<img src='images/info - new.png' style='width:20px;height:20px' onclick='image(" + iIndex + "," + sProductId + ",this)' />";
        //                            }
        //                            //html += "<span style='font-family:'Amazon Ember''><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
        //                            html += "</td>";
        //                            //html += "<td style='font-family:Verdana;font-size:18px;padding-top:15px; '></td>";
        //                            html += "</td>";
        //                            html += "</tr>";

        //                            html += "<tr id='BtnAdd" + sProductId + "'>";
        //                            //html += "<td style='padding-top:15px;padding-left:27px;'>";
        //                            html += "<td style='padding-top:6px;padding-left:10px;' colspan='3'>";
        //                            html += "<button type='button' class='btn BlueText BtnAddText' onclick='AddClick(" + iIndex + "," + sProductId + "," + sProductId + "," + sMrp + ",this)'>ADD</button>";
        //                            html += "<input type='hidden' id='hdnProductId" + sProductId + "' value='" + sProductId + "'>";
        //                            html += "<input type='hidden' id='hdnGrpId" + sProductId + "' value='" + sProductId + "'>";
        //                            html += "<input type='hidden' id='hdnCategoryId" + sProductId + "' value='" + sCategoryId + "'>";
        //                            html += "<input type='hidden' id='hdnPName" + sProductId + "' value='" + sProductName + "'>";
        //                            //html += "<input type='hidden' id='hdnPDescription" + iIndex + "' value='" + sProductDesc + "'>";
        //                            html += "<input type='hidden' id='hdnPKeyFeature" + sProductId + "' value='" + sProductKeyFeatures + "'>";
        //                            html += "<input type='hidden' id='hdnProductVariant" + sProductId + "' value='" + sProductVariant + "'>";
        //                            //html += "</td>";
        //                            //html += "<td>";
        //                            //html += "&nbsp; <span style='font-family:'Amazon Ember''><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
        //                            html += "&nbsp;<span class='SoldCount'> " + objproduct.ProductList[j].SoldCount + "</span>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            html += "<tr id='AddShow" + sProductId + "' style='display:none;'>";
        //                            html += "<td colspan='3' style='padding-top:15px;padding-left:10px;' class='AmazonFont'>";
        //                            html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='plusqty(0," + sProductId + "," + sProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                            html += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:40px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
        //                            html += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='plusqty(1," + sProductId + "," + sProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            html += "</table>";
        //                            html += "</td>";
        //                            html += "</tr>";

        //                            html += "<tr>";
        //                            html += "<td colspan='5'> <hr class='solid'>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            //html += "</td>";
        //                            //html += "</tr>";
        //                            //html += "</table>";
        //                            iIndex++;
        //                        }

        //                    }

        //                }
        //                else
        //                {
        //                    //Product Attribute Image
        //                    if (objproduct.ProductList[j].ProductAttributesList != null && objproduct.ProductList[j].ProductAttributesList.Count > 0)
        //                    {

        //                        for (int h = 0; h < objproduct.ProductList[j].ProductAttributesList.Count; h++)
        //                        {
        //                            sGrpId = objproduct.ProductList[j].ProductAttributesList[h].AttributeId;
        //                            sDiscount = objproduct.ProductList[j].ProductAttributesList[h].Discount;
        //                            sMrp = objproduct.ProductList[j].ProductAttributesList[h].soshoPrice;
        //                            sSoshoPrice = objproduct.ProductList[j].ProductAttributesList[h].Mrp;
        //                            sWeight = objproduct.ProductList[j].ProductAttributesList[h].weight;
        //                            sAImageName = objproduct.ProductList[j].ProductAttributesList[h].AImageName;
        //                            sisSelected = objproduct.ProductList[j].ProductAttributesList[h].isSelected;


        //                            if (!string.IsNullOrEmpty(sMrp))
        //                                dMrp = Convert.ToDecimal(sMrp);
        //                            if (!string.IsNullOrEmpty(sSoshoPrice))
        //                                dSoshoPrice = Convert.ToDecimal(sSoshoPrice);

        //                            dSavePrice = (dSoshoPrice - dMrp);
        //                            //}
        //                            if (!string.IsNullOrEmpty(objproduct.ProductList[j].SpecialMessage))
        //                            {
        //                                if (sisSelected == "false")
        //                                    html += "<tr  id='tr" + iIndex + "' style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
        //                                else
        //                                    html += "<tr  id='tr" + iIndex + "' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
        //                                html += "<td colspan='5' class='BlueText' style='padding:7px;padding-top:5px;text-align:center; '>" + objproduct.ProductList[j].SpecialMessage + " </td>";
        //                                html += "</tr>";
        //                            }
        //                            if (sisSelected == "false")
        //                                html += "<tr id='tr" + iIndex + "' style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
        //                            else
        //                                html += "<tr id='tr" + iIndex + "' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";


        //                            if (!string.IsNullOrEmpty(sDiscount))
        //                            {
        //                                //if (sisSelected == "false")
        //                                //    html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' style='display:none;'>";
        //                                //else
        //                                html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' >";
        //                                if (sDiscount.ToString() != "0% Off" && sDiscount.ToString() != "₹ 0 Off")
        //                                {
        //                                    html += "<div   class='DiscountOffer'>";
        //                                    html += sDiscount;
        //                                    html += "</div>";
        //                                }
        //                            }
        //                            else
        //                                html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' >";

        //                            html += "<div><img src=" + sAImageName + " class='ProductImage'/></div>";
        //                            //}
        //                            html += "</td>";
        //                            html += "<td style='width:50%;'>";
        //                            //html += "<table style='width:100%;position:relative;bottom:-6px;right:166px;'>";
        //                            //if (sisSelected == "false")
        //                            //    html += "<table class='tableheader' id='tbl" + iIndex + "' style='display:none;'>";
        //                            //else
        //                            html += "<table class='tableheader' id='tbl" + iIndex + "'>";
        //                            if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
        //                            {
        //                                html += "<tr>";
        //                                html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px;text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
        //                                html += "</tr>";
        //                            }

        //                            html += "<tr class='AmazonFont'>";

        //                            //html += "<td style='padding-top:5px;text-align:-webkit-center;' colspan='3'>";
        //                            //html += "<td style='padding-top:5px;' colspan='3'>";

        //                            html += "<td class='ProductCenter' colspan='3'>";

        //                            html += "<span class='ProductName'>" + sProductName + "</span>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            html += "<tr>";
        //                            html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
        //                            html += "<td class='ProductMRPValue'>:</td>";
        //                            html += "<td class='ProductMRPValue ProductMRPText'><del>₹ " + sMrp + "</del></td>";
        //                            html += "</tr>";
        //                            html += "<tr class='AmazonFont' style='padding-top:15px;'>";
        //                            html += "<td class='SoshoPrice'>Sosho Price</td>";
        //                            html += "<td class='SoshoColon'>:</td>";
        //                            html += "<td class='SoshoPriceValue'>₹ " + sSoshoPrice + "</td>";
        //                            //html += "<td class='SoshoPrice'>₹ " + sSoshoPrice + "</td>";
        //                            html += "</tr>";
        //                            html += "<tr class='AmazonFont'>";
        //                            html += "<td class='ProudctMRPText'>You Save</td>";
        //                            html += "<td>:</td>";
        //                            html += "<td class='ProductMRPText'>₹ " + dSavePrice + "</td>";
        //                            html += "</tr>";
        //                            html += "<tr>";
        //                            html += "<td class='ProductDropDown' colspan='2'>";
        //                            html += "<select ID='ddlUnit" + sGrpId + "'  runat='server' onclick=\"myPackSize(" + iIndex + ",'" + sDiscount + "'," + sProductId + "," + sGrpId + ",this)\">";
        //                            html += "<option Value='" + sWeight + "'>" + sWeight + "</option>";
        //                            html += "</select>";
        //                            html += "</td>";
        //                            html += "<td>";
        //                            //html += "</td><td></td> ";
        //                            //html += "<td style='padding-top:15px;padding-left:0px;' >";
        //                            if (!string.IsNullOrEmpty(sIsProductDescription))
        //                            {
        //                                if (sIsProductDescription.ToString() == "true")
        //                                    html += "<img src='images/info - new.png' style='width:20px;height:20px;cursor:pointer;' onclick='image(" + iIndex + "," + sProductId + ",this)' />";
        //                            }
        //                            //html += "<span class='SoldCount'><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
        //                            html += "</td>";
        //                            //html += "<td style='font-family:Verdana;font-size:18px;padding-top:15px;'></td>";
        //                            html += "</tr>";
        //                            //}


        //                            //html += "<tr id='BtnAdd" + iIndex + "'>";
        //                            html += "<tr id='BtnAdd" + sGrpId + "'>";
        //                            //html += "<td style='padding-top:15px;padding-left:27px;'>";
        //                            html += "<td style='padding-top:6px;padding-left:10px;' colspan='3'>";
        //                            html += "<button type='button' class='btn BlueText BtnAddText' onclick='AddClick(" + iIndex + "," + sProductId + "," + sGrpId + "," + sMrp + ",this)'>ADD</button>";
        //                            html += "<input type='hidden' id='hdnProductId" + sGrpId + "' value='" + sProductId + "'>";
        //                            html += "<input type='hidden' id='hdnGrpId" + sGrpId + "' value='" + sGrpId + "'>";
        //                            html += "<input type='hidden' id='hdnCategoryId" + sGrpId + "' value='" + sCategoryId + "'>";
        //                            html += "<input type='hidden' id='hdnPName" + sGrpId + "' value='" + sProductName + "'>";
        //                            //html += "<input type='hidden' id='hdnPDescription" + iIndex + "' value='" + sProductDesc + "'>";
        //                            html += "<input type='hidden' id='hdnPKeyFeature" + sGrpId + "' value='" + sProductKeyFeatures + "'>";
        //                            html += "<input type='hidden' id='hdnProductVariant" + sGrpId + "' value='" + sProductVariant + "'>";
        //                            //html += "</td>";
        //                            //html += "<td>";
        //                            html += "&nbsp;<span class='SoldCount'> " + objproduct.ProductList[j].SoldCount + "</span>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            //html += "<tr id='AddShow" + iIndex + "' style='display:none;'>";
        //                            html += "<tr id='AddShow" + sGrpId + "' style='display:none;'>";
        //                            html += "<td colspan='3' style='padding-top:15px;padding-left:10px;' class='AmazonFont'>";
        //                            html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='plusqty(0," + sProductId + "," + sGrpId + ",this)'><i class='fa fa-minus'></i></button>";
        //                            html += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:40px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
        //                            html += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='plusqty(1," + sProductId + "," + sGrpId + ",this)'><i class='fa fa-plus'></i></button>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            html += "</table>";
        //                            html += "</td>";
        //                            html += "</tr>";


        //                            if (sisSelected == "false")
        //                                html += "<tr style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
        //                            else
        //                                html += "<tr class='trGrp" + sGrpId + "'>";
        //                            html += "<td colspan='5'> <hr class='solid'>";
        //                            html += "</td>";
        //                            html += "</tr>";
        //                            //html += "</td>";
        //                            //html += "</tr>";
        //                            //html += "</table>";
        //                            iIndex++;
        //                        }

        //                    }
        //                }

        //            }

        //            html += "</table>";


        //        }

        //    }

        //    string databanner = clsCommon.GET(Homebanner);

        //    string sBannerPosition = "", sBannerActionId = "", sOpenUrlLink = "", sBannerCategoryId = "", sCategoryName = "";
        //    string sBannerProductId = "", sBannerProductMrp = "", sBannerWeight = "";
        //    if (!String.IsNullOrEmpty(databanner))
        //    {
        //        clsModals.NewBnnerImage objbanner = JsonConvert.DeserializeObject<clsModals.NewBnnerImage>(databanner);
        //        if (objbanner.response.Equals("1"))
        //        {
        //            sBannerPosition = objbanner.BannerPosition;
        //            if (objbanner.BannerImageList != null && objbanner.BannerImageList.Count > 0)
        //            {
        //                BannerHtml = "<div class='row'>";
        //                for (int h = 0; h < objbanner.BannerImageList.Count; h++)
        //                {
        //                    BannerHtml += "<div class='offer-banner'>";
        //                    BannerHtml += "<img class='img' src='" + objbanner.BannerImageList[h].bannerURL + "' />";
        //                    BannerHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                    BannerHtml += "</div>";
        //                    if (h == 0)
        //                        BannerHtml += "<br />";
        //                }
        //                BannerHtml += "</div>";
        //            }
        //            if (objbanner.IntermediateBannerImages != null && objbanner.IntermediateBannerImages.Count > 0)
        //            {
        //                if (StartNo == "1")
        //                {
        //                    if (iBannerCount == 1)
        //                    {
        //                        sBannerActionId = objbanner.IntermediateBannerImages[0].ActionId.ToString();

        //                        BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
        //                        BannerIntermediateHtml += "<div class='offer-banner'>";

        //                        if (sBannerActionId == "1") // Action Id = 1 (Open Url)
        //                        {
        //                            sOpenUrlLink = objbanner.IntermediateBannerImages[0].openUrlLink.ToString();

        //                            BannerIntermediateHtml += "<a href='" + sOpenUrlLink + "' target='_blank'>";
        //                            BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
        //                            BannerIntermediateHtml += "</a>";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "</div>";
        //                        }
        //                        else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
        //                        {
        //                            sBannerCategoryId = objbanner.IntermediateBannerImages[0].categoryId.ToString();
        //                            sCategoryName = objbanner.IntermediateBannerImages[0].categoryName.ToString();

        //                            BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' onclick='Categoryimage(" + sBannerCategoryId + ",'" + sCategoryName + "',this)' />";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "</div>";
        //                        }
        //                        else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
        //                        {
        //                            sBannerProductId = objbanner.IntermediateBannerImages[0].ProductId.ToString();
        //                            sBannerProductMrp = objbanner.IntermediateBannerImages[0].MRP.ToString();
        //                            sBannerWeight = objbanner.IntermediateBannerImages[0].Weight.ToString();

        //                            BannerIntermediateHtml += "<div class='offer-banner'>";
        //                            BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
        //                            BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
        //                            BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + 0 + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>ADD</button>";
        //                            BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
        //                            //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                            BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                            BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
        //                            //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                            BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "</div>";

        //                        }
        //                        else if (sBannerActionId == "-1") // Action Id =-1 (None)
        //                        {
        //                            BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
        //                            BannerIntermediateHtml += "</div>";
        //                            BannerIntermediateHtml += "</div>";
        //                        }
        //                        //BannerIntermediateHtml += "</div>";
        //                        //BannerIntermediateHtml += "</div>";

        //                        //BannerIntermediateHtml = "<div class='row'>";
        //                        //BannerIntermediateHtml += "<div class='offer-banner'>";
        //                        //BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[0].bannerURL + "' />";
        //                        //BannerIntermediateHtml += "</div>";
        //                        //BannerIntermediateHtml += "</div>";
        //                    }
        //                }
        //                else
        //                {
        //                    if (iBannerCount.ToString() != sProductCount.ToString())
        //                    {
        //                        BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
        //                        for (int h = 0; h < objbanner.IntermediateBannerImages.Count; h++)
        //                        {
        //                            sBannerActionId = objbanner.IntermediateBannerImages[h].ActionId.ToString();

        //                            if (sBannerActionId == "1") // Action Id = 1 (Open Url)
        //                            {
        //                                sOpenUrlLink = objbanner.IntermediateBannerImages[h].openUrlLink.ToString();

        //                                if (h > 0)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }
        //                            else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
        //                            {
        //                                sBannerCategoryId = objbanner.IntermediateBannerImages[h].categoryId.ToString();
        //                                sCategoryName = objbanner.IntermediateBannerImages[h].categoryName.ToString();

        //                                if (h > 0)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' onclick='Categoryimage(" + sBannerCategoryId + ",'" + sCategoryName + "',this)' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }
        //                            else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
        //                            {
        //                                sBannerProductId = objbanner.IntermediateBannerImages[h].ProductId.ToString();
        //                                sBannerProductMrp = objbanner.IntermediateBannerImages[h].MRP.ToString();
        //                                sBannerWeight = objbanner.IntermediateBannerImages[h].Weight.ToString();
        //                                if (h > 0)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
        //                                    BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + h + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>ADD</button>";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
        //                                    //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                                    BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                                    BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
        //                                    //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                                    BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }
        //                            else if (sBannerActionId == "-1") // Action Id =-1 (None)
        //                            {
        //                                //BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";

        //                                if (h > 0)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }

        //                        }
        //                    }
        //                    else
        //                    {
        //                        for (int h = 0; h < objbanner.IntermediateBannerImages.Count; h++)
        //                        {
        //                            sBannerActionId = objbanner.IntermediateBannerImages[h].ActionId.ToString();
        //                            BannerIntermediateHtml = "<div class='row' id='OtherBanner'>";
        //                            if (sBannerActionId == "1") // Action Id = 1 (Open Url)
        //                            {
        //                                sOpenUrlLink = objbanner.IntermediateBannerImages[h].openUrlLink.ToString();
        //                                if (h == iBannerCount)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }
        //                            else if (sBannerActionId == "2") // Action Id =2 (Navigate To Category)
        //                            {
        //                                sBannerCategoryId = objbanner.IntermediateBannerImages[h].categoryId.ToString();
        //                                sCategoryName = objbanner.IntermediateBannerImages[h].categoryName.ToString();

        //                                if (h == iBannerCount)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }
        //                            else if (sBannerActionId == "3") // Action Id =3 (Add To Cart)
        //                            {
        //                                if (h == iBannerCount)
        //                                {
        //                                    sBannerProductId = objbanner.IntermediateBannerImages[h].ProductId.ToString();
        //                                    sBannerProductMrp = objbanner.IntermediateBannerImages[h].MRP.ToString();
        //                                    sBannerWeight = objbanner.IntermediateBannerImages[h].Weight.ToString();
        //                                    if (h > 0)
        //                                    {
        //                                        BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                        BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                        BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                        BannerIntermediateHtml += "</div>";
        //                                        BannerIntermediateHtml += "<div id='divBannerAdd" + sBannerProductId + "'>";
        //                                        BannerIntermediateHtml += "<button type='button' class='btn BlueText BtnAddText BannerAddPostion' onclick='BannerAddClick(" + h + "," + sBannerProductId + "," + sBannerProductMrp + ",this)'>ADD</button>";
        //                                        BannerIntermediateHtml += "<input type='hidden' id='hdnddlUnit" + sBannerProductId + "' value='" + sBannerWeight + "'>";
        //                                        BannerIntermediateHtml += "</div>";
        //                                        BannerIntermediateHtml += "<div id='divBannerAddShow" + sBannerProductId + "' class='AmazonFont BannerAddPostion' style='display:none;'>";
        //                                        //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                                        BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnminus' runat='server' onclick='Bannerplusqty(0," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-minus'></i></button>";
        //                                        BannerIntermediateHtml += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:30px;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
        //                                        //BannerIntermediateHtml += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                                        BannerIntermediateHtml += "<button class='ProductBtn' type='button' id='btnplus' runat='server' onclick='Bannerplusqty(1," + sBannerProductId + "," + sBannerProductId + ",this)'><i class='fa fa-plus'></i></button>";
        //                                        BannerIntermediateHtml += "</div>";
        //                                        if (h == 0)
        //                                            BannerIntermediateHtml += "<br />";
        //                                    }
        //                                }
        //                            }
        //                            else if (sBannerActionId == "-1") // Action Id =-1 (None)
        //                            {
        //                                //BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";

        //                                if (h == iBannerCount)
        //                                {
        //                                    BannerIntermediateHtml += "<div class='offer-banner'>";
        //                                    BannerIntermediateHtml += "<img class='img' src='" + objbanner.IntermediateBannerImages[h].bannerURL + "' />";
        //                                    BannerIntermediateHtml += "<input type='hidden' id='hdnBannerPosition' value='" + sBannerPosition + "'>";
        //                                    BannerIntermediateHtml += "</div>";
        //                                    if (h == 0)
        //                                        BannerIntermediateHtml += "<br />";
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                BannerIntermediateHtml += "</div>";
        //            }
        //        }
        //    }


        //    //return html;

        //    return new { productcount = sProductCount, response = html, whatsapp = sWhatsAppNo, bannerresponse = BannerHtml, intermediateresponse = BannerIntermediateHtml, productdata = JsonConvert.DeserializeObject<clsModals.getNewproduct>(data) };
        //}
        //catch (Exception ee)
        //{
        //    return "";
        //}
    }

    public void GetCategoryData()
    {
        try
        {
            string Categorybanner = clsCommon.strApiUrl + "/api/Category/GetDashBoardCategoryDetails";
            string databanner = clsCommon.GET(Categorybanner);
            clsModals.getCategory objcategory = JsonConvert.DeserializeObject<clsModals.getCategory>(databanner);
            string html = "";

            html = "<div id='ca-container' class='ca-new-container'>";
            html += "<div class='ca-nav'>";
            html += "<span class='ca-nav-prev' style='background: transparent url(../images/arrows.png) no-repeat top left;'>Previous</span>";
            html += "<span class='ca-nav-next' style='background: transparent url(../images/arrows.png) no-repeat top left; background-position:top right;'>Next</span>";
            html += "</div>";
            html += "<div class='ca-wrapper' style='overflow: hidden; '>";
            if (!String.IsNullOrEmpty(databanner))
            {
                if (objcategory.response.Equals("1"))
                {
                    for (int i = 0; i < objcategory.CategoryList.Count; i++)
                    {
                        html += "<div class='ca-item' style=' left: 0px;cursor:pointer;'>";
                        html += "<div>";
                        html += "<img src='" + objcategory.CategoryList[i].CategoryImage + "' class='CategoryImagecenter' id=\"img"+ objcategory.CategoryList[i].Id + "\" onclick=\"Categoryimage(" + objcategory.CategoryList[i].Id + ",this,'category')\" />";
                        html += "<span class='CategoryText' id=\"text" + objcategory.CategoryList[i].Id + "\" >" + objcategory.CategoryList[i].CategoryName + "</span>";
                        html += "</div>";
                        html += "</div>";
                    }

                }
            }
            html += "</div>";
            html += "</div>";

            divCategory.InnerHtml = html;

            html = string.Empty;
            if (!String.IsNullOrEmpty(databanner))
            {
                if (objcategory.response.Equals("1"))
                {
                    html += "<input type='hidden' id='hdnCategory' value='" + objcategory.CategoryList[0].Id + "'/>";
                    html += "<input type='hidden' id='hdnSubCat' value='-1'/>";
                    html += "<label class='control-label SubCat'  onclick='GetProduct(-1," + objcategory.CategoryList[0].Id + ",this)'   >All</label>";
                    for (int i = 0; i < objcategory.CategoryList[0].SubCategoryList.Count; i++)
                    {
                        html += "<label class='control-label SubCat' id='SubCat" + objcategory.CategoryList[0].SubCategoryList[i].SubCategoryId + "' onclick='GetProduct(" + objcategory.CategoryList[0].SubCategoryList[i].SubCategoryId + "," + objcategory.CategoryList[0].SubCategoryList[i].CategoryId + ",this)'>" + objcategory.CategoryList[0].SubCategoryList[i].SubCategoryName + "</label>";
                    }

                }
            }
            divSubCat.InnerHtml = html;


        }
        catch (Exception ex)
        {

        }
    }

    //public void GetProductdataTest(string JurisdictionId, string StartNo, string EndNo)
    //{
    //    try
    //    {
    //        dbConnection dbc = new dbConnection();
    //        string html = "", JurisdictionID = "1";

    //        //string aa = clsCommon.strApiUrl + "/api/Product/GetProductDetails";
    //        //string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
    //        //string data = clsCommon.GET(aa);

    //        string dashboadapi = clsCommon.strApiUrl + "/api/Product/GetDashBoardProductDetails?JurisdictionID=" + JurisdictionID + "&StartNo=" + StartNo + "&EndNo=" + EndNo;
    //        string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
    //        string data = clsCommon.GET(dashboadapi);

    //        if (!String.IsNullOrEmpty(data))
    //        {
    //            clsModals.getNewproduct objproduct = JsonConvert.DeserializeObject<clsModals.getNewproduct>(data);
    //            string sDiscount = "", sProductVariant = "", sMrp = "", sSoshoPrice = "", sWeight = "", sIsProductDescription = "", sAImageName = "";

    //            for (int j = 0; j < objproduct.ProductList.Count; j++)
    //            {
    //                html += "<div class='row' style ='padding-top:6px;'> ";
    //                html += "<div class='owl-carouselowl-theme' id='imagsliderimg' runat='server'>";
    //                html += "<div class='item active'>";
    //                html += "<table style='width:100%;'>";
    //                if (!string.IsNullOrEmpty(objproduct.ProductList[j].SpecialMessage))
    //                {
    //                    html += "<tr>";
    //                    html += "<td colspan='5' class='BlueText' style='padding:7px;padding-top:5px;text-align:center; '>" + objproduct.ProductList[j].SpecialMessage + " </td>";
    //                    html += "</tr>";
    //                }
    //                html += "<tr>";

    //                sDiscount = objproduct.ProductList[j].Discount;
    //                sProductVariant = objproduct.ProductList[j].IsProductVariant;
    //                sIsProductDescription = objproduct.ProductList[j].IsProductDescription;

    //                if (sProductVariant.ToString() == "false")
    //                {
    //                    if (!string.IsNullOrEmpty(sDiscount))
    //                    {
    //                        html += "<td style='padding-top:5px;'>";
    //                        html += "<div  style='color:white; background-color:red;border-radius:50px; padding:15px; width:77px; position:absolute; text-align:center;'>";
    //                        html += sDiscount;
    //                        html += "</div>";
    //                    }
    //                    if (objproduct.ProductList[j].ProductImageList != null && objproduct.ProductList[j].ProductImageList.Count > 0)
    //                    {

    //                        for (int i = 0; i < objproduct.ProductList[j].ProductImageList.Count; i++)
    //                        {
    //                            if (i == 0)
    //                            {
    //                                html += "<div><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " class='ProductImage'/></div>";
    //                            }
    //                            else
    //                            {
    //                                html += "<div><img src=" + objproduct.ProductList[j].ProductImageList[i].PImgname + " class='ProductImage'/></div>";
    //                            }

    //                        }
    //                    }
    //                    html += "</td>";
    //                    html += "<td>";
    //                    html += "<table style='width:100%; position:relative; bottom:-6px; right:166px;'>";

    //                    if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
    //                    {
    //                        html += "<tr>";
    //                        html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px; text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
    //                        html += "</tr>";
    //                    }

    //                    html += "<tr>";
    //                    html += "<td style='padding-top:5px;' colspan='3'>";
    //                    html += "<span class='ProductName'>" + objproduct.ProductList[j].Name + "</span>";
    //                    html += "</td>";
    //                    html += "</tr>";
    //                    html += "<tr>";
    //                    html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
    //                    html += "<td class='ProductMRPValue'>:</td>";
    //                    html += "<td class='ProductMRPValue' style='font-size:15px;'>₹ " + objproduct.ProductList[j].MRP + "</td>";
    //                    html += "</tr>";
    //                    html += "<tr class='AmazonFont' style='padding-top:15px;'>";
    //                    html += "<td class='SoshoPrice' >Sosho Price</td>";
    //                    html += "<td class='SoshoColon'>:</td>";
    //                    html += "<td class='SoshoPriceValue'>₹ " + objproduct.ProductList[j].SellingPrice + "</td>";
    //                    html += "</tr>";
    //                    html += "<tr class='AmazonFont'>";
    //                    html += "<td class='ProudctMRPText'>You Save</td>";
    //                    html += "<td>:</td>";
    //                    html += "<td style='font-size:15px;'>₹ " + objproduct.ProductList[j].MRP + "</td>";
    //                    html += "</tr>";
    //                    html += "<tr>";
    //                    html += "<td  class='ProductDropDown'>";
    //                    html += "<input id='txtweight' class='AmazonFont' runat='server' value='" + objproduct.ProductList[j].Weight + "' style ='width:120px;'/>";
    //                    html += "</td><td></td> ";
    //                    html += "<td style='padding-top:15px;padding-left:0px;' >";
    //                    if (!string.IsNullOrEmpty(sIsProductDescription))
    //                    {
    //                        if (sIsProductDescription.ToString() == "True")
    //                            html += "<img src='images/info - new.png' style='width:20px;height:20px' />";
    //                    }
    //                    html += "<span style='font-family:'Amazon Ember''><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
    //                    html += "</td>";
    //                    html += "<td style='font-family:Verdana;font-size:18px;padding-top:15px; '></td>";
    //                    html += "</tr>";
    //                }
    //                else
    //                {
    //                    //Product Attribute Image
    //                    if (objproduct.ProductList[j].ProductAttributesList != null && objproduct.ProductList[j].ProductAttributesList.Count > 0)
    //                    {
    //                        for (int h = 0; h < objproduct.ProductList[j].ProductAttributesList.Count; h++)
    //                        {
    //                            sDiscount = objproduct.ProductList[j].ProductAttributesList[h].Discount;
    //                            sMrp = objproduct.ProductList[j].ProductAttributesList[h].Mrp;
    //                            sSoshoPrice = objproduct.ProductList[j].ProductAttributesList[h].soshoPrice;
    //                            sWeight = objproduct.ProductList[j].ProductAttributesList[h].weight;
    //                            sAImageName = objproduct.ProductList[j].ProductAttributesList[h].AImageName;
    //                        }

    //                        if (!string.IsNullOrEmpty(sDiscount))
    //                        {
    //                            html += "<td style='padding-top:5px;'>";
    //                            html += "<div  style='color:white;background-color:red;border-radius:50px;padding:15px;width:77px;position:absolute;text-align:center;'>";
    //                            html += sDiscount;
    //                            html += "</div>";
    //                        }
    //                        html += "<div><img src=" + sAImageName + " class='ProductImage'/></div>";
    //                    }
    //                    html += "</td>";
    //                    html += "<td>";
    //                    html += "<table style='width:100%;position:relative;bottom:-6px;right:166px;'>";

    //                    if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
    //                    {
    //                        html += "<tr>";
    //                        html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px;text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
    //                        html += "</tr>";
    //                    }

    //                    html += "<tr>";
    //                    html += "<td style='padding-top:5px;' colspan='3'>";
    //                    html += "<span class='ProductName'>" + objproduct.ProductList[j].Name + "</span>";
    //                    html += "</td>";
    //                    html += "</tr>";
    //                    html += "<tr>";
    //                    html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
    //                    html += "<td class='ProductMRPValue'>:</td>";
    //                    html += "<td class='ProductMRPValue' style='font-size:15px;'>₹ " + sMrp + "</td>";
    //                    html += "</tr>";
    //                    html += "<tr class='AmazonFont' style='padding-top:15px;'>";
    //                    html += "<td class='SoshoPrice'>Sosho Price</td>";
    //                    html += "<td class='SoshoColon'>:</td>";
    //                    html += "<td class='SoshoPriceValue'>₹ " + sSoshoPrice + "</td>";
    //                    html += "</tr>";
    //                    html += "<tr class='AmazonFont'>";
    //                    html += "<td class='ProudctMRPText'>You Save</td>";
    //                    html += "<td>:</td>";
    //                    html += "<td style='font-size:15px;'>₹ " + sMrp + "</td>";
    //                    html += "</tr>";
    //                    html += "<tr>";
    //                    html += "<td class='ProductDropDown'>";
    //                    html += "<select ID='ddlUnit' runat='server'>";
    //                    html += "<option Value='" + sWeight + "'>" + sWeight + "</option>";
    //                    html += "</select>";
    //                    //html += "</td><td></td> ";
    //                    html += "</td> ";
    //                    html += "<td style='padding-top:15px;padding-left:0px;' >";
    //                    html += "<img src='images/info - new.png' style='width:20px;height:20px' />";
    //                    html += "<span style='font-family:'Amazon Ember''><b> " + objproduct.ProductList[j].SoldCount + "</b></span>";
    //                    html += "</td>";
    //                    html += "<td style='font-family:Verdana;font-size:18px;padding-top:15px;'></td>";
    //                    html += "</tr>";
    //                }

    //                html += "<tr>";
    //                html += "<td style='padding-top:15px;padding-left:27px;'>";
    //                html += "<button type='button' class='btn BlueText' style='color:white;font-size:16px;width:93px;'>ADD</button>";
    //                html += "</td>";
    //                html += "</tr>";
    //                html += "<tr>";
    //                html += "<td colspan='3' style='padding-top:15px;padding-left:27px;' class='AmazonFont'>";
    //                html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server'><i class='fa fa-minus'></i></button>";
    //                html += "<input id='txtqty' runat='server' value='1' style='font-weight:bold;width:40px;'/>";
    //                html += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' ><i class='fa fa-plus'></i></button>";
    //                html += "</td>";
    //                html += "</tr>";
    //                html += "</table>";
    //                html += "</td>";
    //                html += "</tr>";
    //                html += "</table>";
    //                html += "</div></div></div>";

    //            }
    //            //content.InnerHtml = html;

    //        }









    //        string databanner = clsCommon.GET(Homebanner);


    //        if (!String.IsNullOrEmpty(databanner))
    //        {
    //            clsModals.BnnerImage objbanner = JsonConvert.DeserializeObject<clsModals.BnnerImage>(databanner);
    //            if (objbanner.response.Equals("1"))
    //            {
    //                //lbltopbanner.Src = objbanner.BannerImageList[0].ImgUrl;
    //                //link.HRef = objbanner.BannerImageList[0].DataLink;
    //            }
    //        }

    //        //return html;

    //    }
    //    catch (Exception ee)
    //    {
    //        // return "";
    //    }
    //}
    [System.Web.Services.WebMethod]
    public static object GetSubCategory(string categoryid)
    {
        string Categorybanner = clsCommon.strApiUrl + "/api/Category/GetDashBoardCategoryDetails";
        string databanner = clsCommon.GET(Categorybanner);
        clsModals.getCategory objcategory = JsonConvert.DeserializeObject<clsModals.getCategory>(databanner);
        string html = string.Empty;
        try
        {
            if (!String.IsNullOrEmpty(databanner))
            {
                if (objcategory.response.Equals("1"))
                {
                    var SubCatList = objcategory.CategoryList.Where(x => x.Id == categoryid).FirstOrDefault().SubCategoryList;
                    html += "<input type='hidden' id='hdnCategory' value='" + categoryid + "'/>";
                    html += "<input type='hidden' id='hdnSubCat' value='-1'/>";
                    html += "<label class='control-label SubCat' onclick='GetProduct(-1," + categoryid + ",this)'  >All</label>";
                    for (int i = 0; i < SubCatList.Count; i++)
                    {
                        html += "<label class='control-label SubCat' id='SubCat" + SubCatList[i].SubCategoryId  + "'  onclick ='GetProduct(" + SubCatList[i].SubCategoryId + "," + SubCatList[i].CategoryId + ",this)'>" + SubCatList[i].SubCategoryName + "</label>";
                    }

                }
            }
            return html;

        }
        catch (Exception ex)
        {
            return ex.ToString();
        }

    }
    [System.Web.Services.WebMethod]
    public static object GetResultsBySearch(string Searchname1,string JurisdictionId)
    {
        if (!string.IsNullOrEmpty(Searchname1))
        {
            string Search = clsCommon.strApiUrl + "/api/Search/GetResultsBySearch?Searchname1=" + Searchname1 + "&JurisdictionId=" + JurisdictionId;;
            string databanner = clsCommon.GET(Search);
            var obj = JsonConvert.DeserializeObject(databanner);
            clsModals.getSearchproduct objsearchproduct = JsonConvert.DeserializeObject<clsModals.getSearchproduct>(databanner);
            string[] html = null;
            if (!String.IsNullOrEmpty(databanner))
            {
                if (objsearchproduct.response.Equals("1"))
                {
                    html = objsearchproduct.message;
                }
            }
            return html;
        }
        else
            return 0;
    }
}