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
                    lblproductdec.InnerHtml = objproduct.ProductList[0].pdec;
                    lblprodkeyfeature.InnerHtml = objproduct.ProductList[0].pkey;
                    lblprodnote.InnerHtml = objproduct.ProductList[0].pnote;
                    //lblpricemain.InnerHtml = clsCommon.rssymbol + buy1.ToString();
                    string videourl = objproduct.ProductList[0].pvideo;

                    content.InnerHtml = html;

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
    public static string ConfirmOrder(List<ClsOrderModels.ConfirmOrderModel> model)
    {
        ClsOrderModels.PlaceMultipleOrderModel orderModel = new ClsOrderModels.PlaceMultipleOrderModel();
        List<ClsOrderModels.ProductList> products = new List<ClsOrderModels.ProductList>();
        foreach (var item in model)
        {
            item.MrpTotal = item.Mrp * item.Qty;
            products.Add(new ClsOrderModels.ProductList
            {
                productid = item.Productid,
                buywith = item.Flag,
                PaidAmount = item.Mrp,
                Quantity = item.Qty.ToString(),
                couponCode = "0",
                refrcode = "0"
            });
        }
        orderModel.discountamount = "0";
        orderModel.Redeemeamount = "0";
        //orderModel.CustomerId = clsCommon.getCurrentCustomer().id;
        orderModel.orderMRP = model.Sum(x => x.MrpTotal).ToString();
        orderModel.totalAmount = orderModel.orderMRP;
        orderModel.totalQty = model.Sum(x => x.Qty).ToString();
        orderModel.totalWeight = (model.Sum(x => x.Qty) * model.Sum(x => x.Weight)).ToString();


        orderModel.products = products;
        HttpContext.Current.Session["ConfirmOrder"] = orderModel;

        HttpContext.Current.Session["IsCheckOut"] = "true";

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

            if (!String.IsNullOrEmpty(databanner))
            {
                if (objcategory.response.Equals("1"))
                {
                    for (int i = 0; i < objcategory.CategoryList.Count; i++)
                    {
                        if (i == 0)
                        {
                            // html = "<a href=\"#\" id=\"link\" runate=\"server\">";
                            html = "<div>";
                            html += "<img style='width:127px;' src=" + objcategory.CategoryList[i].CategoryImage + ">";
                            html += "<span>" + objcategory.CategoryList[i].CategoryName + "</span>";
                            html += "</div>";

                        }
                        else
                        {
                            //html += "<a href=\"#\" id=\"link\" runate=\"server\">";
                            html += "<img style='width:127px;' src=" + objcategory.CategoryList[i].CategoryImage + ">";
                            html += "<span>" + objcategory.CategoryList[i].CategoryName + "</span>";
                            //html += "</a>";
                        }
                    }
                    //lbltopbanner.Src = objcategory.CategoryList[0].CategoryImage;
                    //link.HRef = objcategory.CategoryList[0].CategoryDescription;
                }
            }
            //return objcategory;
            return html;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    [System.Web.Services.WebMethod]
    public static object GetNewdata(string JurisdictionId,string StartNo,string EndNo)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string html = "";

            //string aa = clsCommon.strApiUrl + "/api/Product/GetProductDetails";
            //string Homebanner = clsCommon.strApiUrl + "/api/Banner/getbannerimag";
            //string data = clsCommon.GET(aa);

            string dashboadapi = clsCommon.strApiUrl + "/api/Product/GetDashBoardProductDetails?JurisdictionID=" + JurisdictionId + "&StartNo=" + StartNo + "&EndNo=" + EndNo;
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
                    //lblproductdec.InnerHtml = objproduct.ProductList[0].pdec;
                    //lblprodkeyfeature.InnerHtml = objproduct.ProductList[0].pkey;
                    //lblprodnote.InnerHtml = objproduct.ProductList[0].pnote;
                    ////lblpricemain.InnerHtml = clsCommon.rssymbol + buy1.ToString();
                    //string videourl = objproduct.ProductList[0].pvideo;

                    //content.InnerHtml = html;

                    //if (!string.IsNullOrWhiteSpace(videourl))
                    //{
                    //    video.InnerHtml = "<iframe width=\"100%\" height=\"280px\" id=\"VideoId\" runat=\"server\" src=\"" + videourl + "\" frameborder=\"0\"  allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\"></iframe>";
                    //}

                   
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

            return html;

        }
        catch (Exception ee)
        {
            return "";
        }
    }
}