using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderSummery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
    {
       
        try
        {
            string orderid = string.Empty;
            string Customerid = "";
            ltrerr.Text = "";
            if (!IsPostBack)
            {
                Customerid = clsCommon.getCurrentCustomer().id;
                lblCustid.Text = Customerid.ToString();
                //Customerid = "1010";
                //lblCustid.Text = Customerid.ToString();
                //Session Value

                //Temp Static Value For Testing
               // Session["Addressid"] = "1";
                //Session["BuyFlag"] = "1";
                //Session["BuyQty"] = "2";
               Session["ccode"] = "";
                //Sessioin GetValue and Decoder
                
                string AddrId = "";
                string Buyqty = "";
                string BuyFlag ="";
                string reffcode = "";
                HttpContext.Current.Session["WalletHistory"] = null;
                //ccode
                if ((HttpContext.Current.Session["ReferCode"] != null) && (HttpContext.Current.Session["ReferCode"] != ""))
                {
                    string buyaddren = Session["ReferCode"].ToString();
                   // reffcode = clsCommon.Base64Decode(buyaddren);
                    lblccode.Text = buyaddren;
                }

                //session Address
                if ((HttpContext.Current.Session["Addressid"] != null))
                {
                    string buyaddren = Session["Addressid"].ToString();
                    AddrId = clsCommon.Base64Decode(buyaddren);
                    lbladdrid.Text = AddrId;
                }
                if (HttpContext.Current.Session["WhatsAppNo"] != null)
                {
                    lblWhatsAppNo.Text = Session["WhatsAppNo"].ToString();
                }
                //Buy Quentity
                if ((HttpContext.Current.Session["buyqty"] != null))
                {
                    string buyqtyen = Session["BuyQty"].ToString();
                    Buyqty = clsCommon.Base64Decode(buyqtyen);
                }

                //Buy Flag
                if ((HttpContext.Current.Session["BuyFlag"] != null))
                {
                    string buyflagen = Session["BuyFlag"].ToString();   
                    BuyFlag = clsCommon.Base64Decode(buyflagen);
                    lblbuyflag.Text = BuyFlag;
                }

                //if (!string.IsNullOrWhiteSpace(Request.QueryString["orderid"]))
                //{
                //     orderid = Request.QueryString["orderid"].ToString();
                //    //HttpContext.Current.Session["orderid"] = orderid;
                //    GetProductDetailsForReorder(orderid);

                //}
                //else
                //{
                //    getaddr(Customerid, AddrId, BuyFlag);
                //}

                
                GetProductDetails(Customerid, AddrId, BuyFlag, Buyqty);
                //getreedemamt(Customerid, "200", " 0");
                //200 and 0 Not effected

            }
        }
        catch (Exception ee)
        {
            ltrerr.Text = ee.StackTrace;
        }
    }

    //public void getaddr(string Custid, string addressid, string buyflag = "")
    //{
    //    try
    //    {

    //        string aa = clsCommon.strApiUrl + "/api/OrderSummery/GetOrderSummery?custid=" + Custid + "&AddressId=" + addressid + "&BuyFlag=" + buyflag + "";

    //        string data = clsCommon.GET(aa);
    //        if (!String.IsNullOrEmpty(data))
    //        {
    //            ClsOrderModels.OrderSummery objsummery = JsonConvert.DeserializeObject<ClsOrderModels.OrderSummery>(data);
    //            if (objsummery.Response.Equals("1"))
    //            {
    //                lblfname.InnerText = objsummery.OrderCustomerList[0].Cfname + " " + objsummery.OrderCustomerList[0].Clname;
    //                if (string.IsNullOrEmpty(objsummery.OrderCustomerList[0].BuildingNo) && string.IsNullOrEmpty(objsummery.OrderCustomerList[0].BuildingName) && string.IsNullOrEmpty(objsummery.OrderCustomerList[0].AreaName))
    //                {
    //                    add1.InnerText = objsummery.OrderCustomerList[0].addr;
    //                }
    //                else
    //                {
    //                    add1.InnerText = objsummery.OrderCustomerList[0].BuildingNo + "," + objsummery.OrderCustomerList[0].BuildingName + "," + objsummery.OrderCustomerList[0].AreaName + "," + objsummery.OrderCustomerList[0].Landmark;
    //                }
    //                //add1.InnerText = objsummery.OrderCustomerList[0].addr;
    //                add2.InnerText = objsummery.OrderCustomerList[0].Cityname + " ," + objsummery.OrderCustomerList[0].statename;
    //                add3.InnerText = objsummery.OrderCustomerList[0].Countryname;                  
    //                lblmno.InnerText = " " + objsummery.OrderCustomerList[0].cph;
    //            }
    //            else
    //            {
    //                spnAddrbtn.InnerHtml = "Select Address";
    //            }
    //        }
    //    }
    //    catch (Exception ee)
    //    {

    //        ltrerr.Text = ee.StackTrace;
    //    }
    //}

    public void GetProductDetails(string Custid, string addressid, string buyflag, string buyqty)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string html = "";
            //ClsOrderModels.PlaceMultipleOrderModel orderModel;
            ClsOrderModels.PlaceMultipleOrderNewModel orderModel;
            if ((HttpContext.Current.Session["ConfirmOrder"] != null))
            {
                //orderModel = (ClsOrderModels.PlaceMultipleOrderModel)HttpContext.Current.Session["ConfirmOrder"];
                orderModel = (ClsOrderModels.PlaceMultipleOrderNewModel)HttpContext.Current.Session["ConfirmOrder"];

            }
            else
            {
                //orderModel = new ClsOrderModels.PlaceMultipleOrderModel();
                orderModel = new ClsOrderModels.PlaceMultipleOrderNewModel();
            }

            if(orderModel != null)
            {
                foreach (var item in orderModel.products)
                {
                    string imgname = "";
                    string prodname = "";
                    string Weight = "";

                    var SoshoTotal = item.PaidAmount * Convert.ToDecimal(item.Quantity);
                    var MrpTotal = item.Mrp * Convert.ToDecimal(item.Quantity);
                    string Unit = item.Unit;
                    string UnitId = item.UnitId;
                    string imgquery="", querydata="";
                    DataTable dtimg, dtpathimg;

                    //string imgquery = "select ProductImages.ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from ProductImages inner join Product ON Product.Id = ProductImages.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where ProductImages.ProductId =" + item.productid + " and isnull(ProductImages.Isdeleted,0)=0";
                    //DataTable dtimg = dbc.GetDataTable(imgquery);

                    //string querydata = "select KeyValue from StringResources where KeyName='ProductImageUrl'";
                    //DataTable dtpathimg = dbc.GetDataTable(querydata);

                    //if(item.Productvariant.ToString() == "true")
                    //{
                    //    imgquery = "select Product_ProductAttribute_Mapping.ProductImage as ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from Product_ProductAttribute_Mapping inner join Product ON Product.Id = Product_ProductAttribute_Mapping.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where Product_ProductAttribute_Mapping.ProductId =" + item.productid + " and isnull(Product_ProductAttribute_Mapping.Isdeleted,0)=0 and Product_ProductAttribute_Mapping.Id=" + item.AttributeId;
                    //    dtimg = dbc.GetDataTable(imgquery);

                    //    querydata = "select KeyValue from StringResources where KeyName='ProductAttributeImageUrl'";
                    //    dtpathimg = dbc.GetDataTable(querydata);
                    //}
                    //else
                    //{
                    if (item.Productvariant.ToString() == "BannerProduct")
                    {
                        //imgquery = "select ImageName as ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from IntermediateBanners InBanner inner join Product ON Product.Id = InBanner.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where InBanner.ProductId =" + item.productid + " and isnull(InBanner.Isdeleted,0)=0";
                        imgquery = "select pm.ProductImage as ImageFileName, Product.Name, pm.PackingType,UnitMaster.UnitName,Product.Unit,pm.IsQtyFreeze,pm.MaxQty from IntermediateBanners InBanner inner join Product ON Product.Id = InBanner.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId inner join Product_ProductAttribute_Mapping pm ON pm.ProductId = Product.Id Where InBanner.ProductId =" + item.productid + " and isnull(InBanner.Isdeleted,0)=0 and pm.Id=" + item.AttributeId;
                        dtimg = dbc.GetDataTable(imgquery);

                        querydata = "select KeyValue from StringResources where KeyName='ProductAttributeImageUrl'";
                        dtpathimg = dbc.GetDataTable(querydata);
                    }
                    else if (item.Productvariant.ToString() == "HomeBannerProduct")
                    {
                        //imgquery = "select ImageName as ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from IntermediateBanners InBanner inner join Product ON Product.Id = InBanner.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where InBanner.ProductId =" + item.productid + " and isnull(InBanner.Isdeleted,0)=0";
                        imgquery = "select pm.ProductImage as ImageFileName, Product.Name, pm.PackingType,UnitMaster.UnitName,Product.Unit,pm.IsQtyFreeze,pm.MaxQty from HomepageBanner HomeBanner inner join Product ON Product.Id = HomeBanner.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId inner join Product_ProductAttribute_Mapping pm ON pm.ProductId = Product.Id Where HomeBanner.ProductId =" + item.productid + " and isnull(HomeBanner.Isdeleted,0)=0 and pm.Id=" + item.AttributeId;
                        dtimg = dbc.GetDataTable(imgquery);

                        querydata = "select KeyValue from StringResources where KeyName='ProductAttributeImageUrl'";
                        dtpathimg = dbc.GetDataTable(querydata);
                    }
                    else
                    {
                        //imgquery = "select ProductImages.ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from ProductImages inner join Product ON Product.Id = ProductImages.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where ProductImages.ProductId =" + item.productid + " and isnull(ProductImages.Isdeleted,0)=0";
                        //dtimg = dbc.GetDataTable(imgquery);

                        //querydata = "select KeyValue from StringResources where KeyName='ProductImageUrl'";
                        //dtpathimg = dbc.GetDataTable(querydata);

                        imgquery = "select Product_ProductAttribute_Mapping.ProductImage as ImageFileName, Product.Name,Product_ProductAttribute_Mapping.PackingType,UnitMaster.UnitName,Product.Unit,Product_ProductAttribute_Mapping.IsQtyFreeze,Product_ProductAttribute_Mapping.MaxQty from Product_ProductAttribute_Mapping inner join Product ON Product.Id = Product_ProductAttribute_Mapping.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where Product_ProductAttribute_Mapping.ProductId =" + item.productid + " and isnull(Product_ProductAttribute_Mapping.Isdeleted,0)=0 and Product_ProductAttribute_Mapping.Id=" + item.AttributeId;
                        dtimg = dbc.GetDataTable(imgquery);

                        querydata = "select KeyValue from StringResources where KeyName='ProductAttributeImageUrl'";
                        dtpathimg = dbc.GetDataTable(querydata);
                    }
                    //}
                    string urlpathimg = "";
                    Boolean IsQtyFreeze = false;
                    string MaxQty = string.Empty;
                    if (dtpathimg != null && dtpathimg.Rows.Count > 0)
                    {
                        urlpathimg = dtpathimg.Rows[0]["KeyValue"].ToString();
                    }
                    if (dtimg != null && dtimg.Rows.Count > 0 )
                    {
                        //Weight = dtimg.Rows[0]["Unit"].ToString() + "-" + dtimg.Rows[0]["UnitName"].ToString();
                        Weight = Unit + "-" + UnitId;
                        prodname = dtimg.Rows[0]["Name"].ToString();
                        if (!string.IsNullOrEmpty(urlpathimg))
                        {
                            imgname = urlpathimg + dtimg.Rows[0]["ImageFileName"].ToString();
                        }
                        if(!string.IsNullOrEmpty(dtimg.Rows[0]["IsQtyFreeze"].ToString()))
                        {
                            if (dtimg.Rows[0]["IsQtyFreeze"].ToString() == "True")
                                IsQtyFreeze = true;
                        }
                        if (!string.IsNullOrEmpty(dtimg.Rows[0]["MaxQty"].ToString()))
                        {
                                MaxQty = dtimg.Rows[0]["MaxQty"].ToString();
                        }

                        if (!string.IsNullOrEmpty(dtimg.Rows[0]["PackingType"].ToString()))
                        {
                            prodname = string.Concat(prodname, ',',' ', dtimg.Rows[0]["PackingType"].ToString());
                        }
                       
                    }
                    html += "<div class=\"single-product\">";
                    html += "<input type=\"hidden\" id=\"hdnCustId\" value=\"" + Custid + "\">";
                    html += "<div class=\"single-product left\"><div class=\"product-image\"><img id=\"proimg\" src=\""+imgname+"\"/></div></div>";
                    html += "<div class=\"single-product right\"><div class=\"product-name-order\" id=\"lblpname\"><p>"+prodname+"</p></div>";
                    //html += "<div class=\"price\"><div class=\"gram\">Price / Qty :<p id=\"lblproprice\"> " + item.PaidAmount + "</p> <span id=\"lbldisplayunit\"> Weight:"+ Weight +"</span></div>";
                    html += "<div class=\"price\"><div class=\"gram\"> <span id=\"lbldisplayunit\"> Weight:" + Weight + "</span></div>";
                    html += "<div class=\"final-amt\"><p id=\"lbltotprices\">" + SoshoTotal + ".00 </p></div></div>";
                    html += "<div class=\"price\"><div class=\"gram\"> <span id=\"lblproprice\"> <span>Price / Qty : " + item.PaidAmount + "</span> <span id=\"lblmrp\" style=\"display:none;\">"+item.Mrp+"</span></div></div>";
                    //if (IsQtyFreeze)
                    //{
                    //    html += "<div class=\"product-qty\"><div class=\"inline col-sm-3\" style=\"padding: 0px;\"><button type=\"button\" style=\"color:white;background-color:#1DA1F2\" class=\"minus\" id=\"btnminuqty\" onclick=\"PriceMinus(" + item.productid +','+item.AttributeId+','+item.PaidAmount+','+item.Mrp+','+item.BannerId+','+item.BannerProductType+",this)\"><i class=\"fa fa-minus\"></i></button>";
                    //    html += "<div class=\"qty\" style=\"display: grid;\"><input readonly=true type=\"text\" id=\"txtqty\" value=\"" + item.Quantity + "\" class=\"\" style=\"width:29px; height:27px;\" onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g,'')\" maxlength=\"2\" />";
                    //    html += "<a onclick=\"saveitem(0); return false;\" class=\"hide\" > Save </a></div>";
                    //    html += "<button type=\"button\"  class=\"plus\" id=\"btnplus\" style=\"color:white;background-color:#a5a5a5\" onclick=\"Priceplus(" + item.productid + ',' + item.AttributeId + ',' + item.PaidAmount + ',' + item.Mrp + ','  + item.BannerId + ',' + item.BannerProductType + ",this)\" disabled><i class=\"fa fa-plus\"></i></button></div>";

                    //    if (!item.isProductAvailable)
                    //    {
                    //        html += "<div class=\"col-sm-4\" style=\"border: 2px solid red;text-align: center;color: red;font-size: large;font-weight: 600;border-radius: 8px;\"><lable>Not Serviceble</lable></div>";
                    //    }else if (item.isOfferExpired){
                    //        html += "<div class=\"col-sm-4\" style=\"border: 2px solid red;text-align: center;color: red;font-size: large;font-weight: 600;border-radius: 8px;\"><lable>Offer Expired</lable></div>";
                    //    }
                    //    else if (item.isOutOfStock)
                    //    {
                    //        html += "<div class=\"clsOutofStock col-sm-4\" style=\"border: 2px solid red;text-align: center;color: red;font-size: large;font-weight: 600;border-radius: 8px;\"><lable>Out of Stock</lable></div>";
                    //    }

                    //    html += "</div><div class=\"product-line-price\"><i class=\"fa fa-trash\" onclick=\"Remove(" + item.productid + ","+item.AttributeId+ ",this)\"></i></div></div></div>";
                    //}
                    //else
                    //{
                        html += "<div class=\"product-qty\"><div class=\"inline col-sm-3\" style=\"padding: 0px;\"><button type=\"button\" class=\"minus\" style=\"color:white;background-color:#1DA1F2\" id=\"btnminuqty\" onclick=\"PriceMinus(" + item.productid + ',' + item.AttributeId + ',' + item.PaidAmount + ',' + item.Mrp + ',' + item.BannerId + ',' + item.BannerProductType + ",this)\"><i class=\"fa fa-minus\"></i></button>";
                        html += "<div class=\"qty\" style=\"display: grid;\"><input type=\"text\" readonly=true id=\"txtqty\" value=\"" + item.Quantity + "\" class=\"\" style=\"width:29px; height:27px;\" onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g,'')\" maxlength=\"2\" />";
                        html += "<a onclick=\"saveitem(0); return false;\" class=\"hide\" > Save </a></div>";
                        html += "<button type=\"button\"  class=\"plus\" id=\"btnplus\" style=\"color:white;background-color:#1DA1F2\" onclick=\"Priceplus(" + item.productid + ',' + item.AttributeId + ',' + item.PaidAmount + ',' + item.Mrp + ',' + item.BannerId + ',' + item.BannerProductType + ",this,"+MaxQty+")\"><i class=\"fa fa-plus\"></i></button></div>";

                        if (!item.isProductAvailable)
                        {
                            html += "<div class=\"col-sm-4\" style=\"border: 2px solid red;text-align: center;color: red;font-size: large;font-weight: 600;border-radius: 8px;\"><lable>Not Serviceble</lable></div>";
                        }
                        else if (item.isOfferExpired)
                        {
                            html += "<div class=\"col-sm-4\" style=\"border: 2px solid red;text-align: center;color: red;font-size: large;font-weight: 600;border-radius: 8px;\"><lable>Offer Expired</lable></div>";
                        }
                        else if (item.isOutOfStock)
                        {
                            html += "<div class=\"clsOutofStock col-sm-4\" style=\"border: 2px solid red;text-align: center;color: red;font-size: large;font-weight: 600;border-radius: 8px;\"><lable>Out of Stock</lable></div>";
                        }

                        html += "</div><div class=\"product-line-price\"><i class=\"fa fa-trash\" onclick=\"Remove(" + item.productid +","+item.AttributeId+ ",this)\"></i></div></div></div>";
                    //}
                    if (item.isOfferExpired || !item.isProductAvailable || item.isOutOfStock)
                    {
                        productstatus.Value = "true";
                    }


                    prodcontent.InnerHtml = html;
                    totwtshipping.InnerText = orderModel.totalAmount;
                    totmrp.InnerText = orderModel.orderMRP;
                    spntotDiscount.InnerText = (Convert.ToDecimal(orderModel.orderMRP) - Convert.ToDecimal(orderModel.totalAmount)).ToString();
                    lbltotpayamt.InnerText = orderModel.totalAmount;
                }
                string Customerid = clsCommon.getCurrentCustomer().id;
                getreedemamt(Customerid, orderModel.totalAmount);

            }

            
           


            //string aa = clsCommon.strApiUrl + "/api/OrderSummery/GetProductDetails?buyflag=" + buyflag + "";

            //string data = clsCommon.GET(aa);
            //if (!String.IsNullOrEmpty(data))
            //{
            //    ClsOrderModels.getproduct objproname = JsonConvert.DeserializeObject<ClsOrderModels.getproduct>(data);
            //    if (objproname.response.Equals("1"))
            //    {
            //        //Singal Product PRice and Details
            //        decimal price = 0;
            //        decimal.TryParse(objproname.ProductList[0].pprice.ToString(), out price);

            //        lblpname.InnerText = objproname.ProductList[0].pname;
            //        lblproprice.InnerText = price.ToString();
            //        lbldisplayunit.InnerText = "  " + objproname.ProductList[0].pwight;

            //        //one price * qty
            //        int buyqtyint = 0;
            //        int.TryParse(buyqty.ToString(), out buyqtyint);
            //        decimal Pricewithqty = price * buyqtyint;
            //        lbltotprices.InnerText = Pricewithqty.ToString();
            //        totwtshipping.InnerText = Pricewithqty.ToString();
            //        txtqty.Value = buyqtyint.ToString();
            //        //Offer Price
            //        decimal offer = decimal.Parse(objproname.ProductList[0].poffer);
            //        lblofferprice.Text = offer.ToString();
            //        int totqty = int.Parse(buyqty);

            //        decimal totoffer = buyqtyint * offer;
            //        lblqty.Text = buyqty;
            //        lbltotofferprice.InnerHtml = totoffer.ToString();



            //        //Gst
            //        //string gststr = objproname.ProductList[0].pgst;
            //        //decimal gst = 0;
            //        //decimal.TryParse(gststr.ToString(), out gst);
            //        //decimal gsttemp = Math.Round(gst, 0);
            //        //gst = (price * gst) / 100;
            //        //gst = Math.Round(gst, 2);
            //        //gst = Math.Round(gst, 0);
            //        //lblgst.InnerText = "GST(" + gsttemp + "%) :" + gst;
            //        // lblpayableamt.InnerText = "Payable Amount: " + fPrice;


            //        //Shipping Price and Final Price
            //        decimal shipping = 0;
            //        decimal.TryParse(objproname.ProductList[0].shipping.ToString(), out shipping);
            //        //shipping = 0;
            //        decimal totshi = 0;
            //        if (shipping == 0)
            //        {
            //            //Free Shipping 
            //            lblshipping.InnerHtml = "Free Shipping";

            //        }
            //        else
            //        {
            //            //shipping Charge 
            //            lblshipping.InnerHtml = "(+) Shipping Included: (₹";
            //            lblshipping1.Text = shipping.ToString();
            //            lblqty1.Text = buyqtyint.ToString();
            //            totshi = shipping * buyqtyint;
            //            lbltotshipping.InnerHtml = totshi.ToString();
            //            lblmul.InnerHtml = "*";
            //            lblrs.InnerHtml = ":₹";
            //            lblbr.InnerHtml = ")";

            //        }


            //        //final Payable Amount
            //        decimal fPrice = Math.Round((Pricewithqty + totshi - totoffer), 2);
            //        //totwithshipp.InnerText = "Shipping Included: " + fPrice;
            //        lbltotpayamt.InnerHtml = fPrice.ToString();
            //        lbltemp.Text = fPrice.ToString();
            //        //lblredeemtext.Visible = false;

            //        //Image Url Source 
            //        string query = "SELECT [KeyValue] FROM [StringResources] where KeyName='ProductImageUrl'";
            //        DataTable dtfolder = dbc.GetDataTable(query);
            //        string folder = "";
            //        if (dtfolder.Rows.Count > 0)
            //        {
            //            folder = dtfolder.Rows[0]["KeyValue"].ToString();
            //        }


            //        string path = folder + objproname.ProductList[0].ProductImageList[0].PImgname;
            //        //proimg.Src = "/ProductImage/" + objproname.ProductList[0].ProductImageList[0].PImgname;
            //        proimg.Src = path;

            //        //string Dtmonth = DateTime.Now.AddDays(7).ToString("MMMM");

            //        //string dtdays = DateTime.Now.AddDays(7).ToString("dd");

            //        //string datfullday = DateTime.Now.AddDays(7).ToString("dddd");

            //        //string fulldate = datfullday + " " + dtdays + " " + Dtmonth;
            //        string fulldate = clsCommon.DeliveryTimeLine;
            //        lbldeliverydate.InnerText = "Delivery within Ahmedabad in 2-3 business days";

            //    }
            //}
        }
        catch (Exception ee)
        {

            ltrerr.Text = ee.StackTrace;
        }
    }

    public void getreedemamt(string Custid, string OrderAmount = "")
    {
        try
        {
            dbConnection dbc = new dbConnection();
            //string aa = clsCommon.strApiUrl + "/api/RedeemWallet/RedeemWallet?CustomerId=" + Custid + "&OrderTotal=" + payableamt + "&Redemeamount=" + reedemamt + "";
            string aa = clsCommon.strApiUrl + "api/Wallet/GetCustomerOfferDetail?CustomerId=" + Custid + "&OrderAmount=" + OrderAmount;
            string redeem = clsCommon.GET(aa);
            string html = string.Empty;
            if (!String.IsNullOrEmpty(redeem))
            {
                //ClsOrderModels.RedeemWalletModel objreed = JsonConvert.DeserializeObject<ClsOrderModels.RedeemWalletModel>(redeem);
                WalletModel.RedeemeWallet objreed = JsonConvert.DeserializeObject<WalletModel.RedeemeWallet>(redeem);
                // if (objreed.resultflag.Equals("1"))
                //{
                //    reeamt.InnerHtml = objreed.WalletAmount.ToString();

                //}
                if (objreed.response.Equals("1"))
                {
                    reeamt.InnerHtml = string.IsNullOrEmpty(objreed.RedeemeAmount) ? "0" : objreed.RedeemeAmount;
                    punchamt.Value = objreed.RedeemableAmount;
                    lblshowmsgwallet.InnerHtml = objreed.RedeemDetails;
                    minOrderAmount.Value = objreed.MinimumOrderAmount;
                    reedemableAmount.Value = objreed.RedeemableAmount;
                    if (objreed.PromoCodeList != null && objreed.PromoCodeList.Count > 0)
                    {
                        foreach (var item in objreed.PromoCodeList)
                        {
                            item.terms = item.terms.Replace("\r\n","<br/>");
                            html += "<div class=\"row\"><div class=\"col-md-12\"><div class=\"col-md-6\">";
                            html += "<label class=\"control-label\"><strong>" + item.PromoCode  +"</strong></label>";
                            html += "<label class=\"control-label\" style=\"text-align:left; font-weight:200;\">"+item.terms+ "</label></div>";
                            html += "<div class=\"col-md-6\" style=\"text-align:end;\"><input type=\"button\" style=\"font-size: 13px; background: #fff;border-color:  rgb(29, 161, 242);font-size:13px;color: rgb(29, 161, 242);\" name =\"applydiscountcouponcode\" value=\"Apply\" class=\"btn btn-primary\" onclick=\"Applypromocode('"+item.PromoCode+"')\" /></div></div></div><hr />";

                        }
                        promolist.InnerHtml = html;
                    }

                }
                
                else
                {
                    reeamt.InnerHtml = "0";
                }
            }
        }
        catch (Exception ee)
        {

            ltrerr.Text = ee.StackTrace;
        }
    }


    //CouponCodeavailable or not testing

    public static int getcheck(string code)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string querydata = "select top 1 Id from [order] where CustOfferCode='" + code + "'";
            DataTable dtcheck = dbc.GetDataTable(querydata);
            if(dtcheck.Rows.Count>0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }
        catch (Exception ee)
        {
            return 0;
        }
    }


    //Redeem Wallet Information 
    [System.Web.Services.WebMethod]
    public static string ReedemWalletDetails(string Reeamt, String CustId, string PayAmt)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            //string aa = clsCommon.strApiUrl + "/api/RedeemWallet/RedeemWallet?CustomerId=" + CustId + "&OrderTotal=" + PayAmt + "&Redemeamount=" + Reeamt + "";
            string aa = clsCommon.strApiUrl + "/api/Wallet/RedeemeWalletFromOrder?CustomerId=" + CustId + "&OrderAmount=" + PayAmt + "&RedeemeAmount=" + Reeamt + "";

            string redeem = clsCommon.GET(aa);
            if (!String.IsNullOrEmpty(redeem))
            {
                //ClsOrderModels.RedeemWalletModel objreed = JsonConvert.DeserializeObject<ClsOrderModels.RedeemWalletModel>(redeem);
                //if (objreed.resultflag.Equals("1") || objreed.resultflag.Equals("0"))
                //{
                //    return redeem;
                //}
                WalletModel.RedeemeWalletFromOrder objeWalletdt = JsonConvert.DeserializeObject<WalletModel.RedeemeWalletFromOrder>(redeem);
                //if(objeWalletdt.response.Equals("1"))
                //{
                //    return redeem;
                //}
                //return "";

                HttpContext.Current.Session["WalletHistory"] = objeWalletdt;
                return redeem;
            }
            else
            {
                return "";
            }
        }

        catch (Exception ee)
        {
            return "";

        }

    }

    //Redeem Wallet Information 
    [System.Web.Services.WebMethod]
    public static string RedeemePromoCodeFromOrder(string promocode, String CustId, string PayAmt)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string aa = clsCommon.strApiUrl + "/api/Wallet/RedeemePromoCodeFromOrder?CustomerId=" + CustId + "&OrderAmount=" + PayAmt + "&PromoCode=" + promocode;

            string promo = clsCommon.GET(aa);
            if (!String.IsNullOrEmpty(promo))
            {
                WalletModel.RedeemePromoCodeFromOrder objeWalletdt = JsonConvert.DeserializeObject<WalletModel.RedeemePromoCodeFromOrder>(promo);
                HttpContext.Current.Session["PromoHistory"] = objeWalletdt;
                return promo;
            }
            else
            {
                return "";
            }
        }

        catch (Exception ee)
        {
            return "";

        }

    }

    //Payment Method Services Price more than zero
    [System.Web.Services.WebMethod]
    public static object PlaceOrderAmtMoreThanZero(String CustId, string PayAmt, string addr, string qty, string buyflag, string disc, string redm, string ccode, string shipcharg)
    {
        dbConnection dbc=new dbConnection();
        try
        {
            decimal payableamt = 0;
            decimal.TryParse(PayAmt.ToString(), out payableamt);
            if (payableamt > 0)
            {
                NewCode: 
                string coddd = clsCommon.GenerateRandomNumber().ToString();                
                int test = getcheck(coddd);

                if (test == 0)
                {
                    goto NewCode;
                }

                string CCCode = clsCommon.Base64Encode(coddd);
                    
                string creaturl = clsCommon.strApiUrl + "/api/Order/GenerateOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount="+disc+"&Redeemeamount="+redm+"&couponCode="+CCCode+"";


                string res = clsCommon.GET(creaturl);

                if (!string.IsNullOrWhiteSpace(res))
                {
                    
                    ClsOrderModels.PlaceOrder objpaymentmode=JsonConvert.DeserializeObject<ClsOrderModels.PlaceOrder>(res);
                    if (objpaymentmode.resultflag == "1")
                    {

                        string tid = objpaymentmode.txnId;

                        
                       
                        if (!string.IsNullOrWhiteSpace(tid))
                        {
                            HttpContext.Current.Session["txnId"] = objpaymentmode.txnId;
                            return res;
                        }
                        else
                        {
                            return "";
                        }

                    }
                    else
                    {
                        return "";
                    }

                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }

        }
        catch (Exception ee)
        {
            return "";

        }
        
    }


    //Directly order Price paid 0
    [System.Web.Services.WebMethod]
    public static object PlaceOrderAmtZero(String CustId, string PayAmt, string addr, string qty, string buyflag, string disc, string redm, string ccode, string shipcharg)
    {
        try
        {
       
            decimal payableamt = 0;
            decimal.TryParse(PayAmt.ToString(), out payableamt);
            if (payableamt == 0)
            {
                NewCode:
                string coddd = clsCommon.GenerateRandomNumber().ToString();
                int test = getcheck(coddd);

                if (test == 0)
                {
                    goto NewCode;
                }

                string CCCode = clsCommon.Base64Encode(coddd);

                string creaturl = clsCommon.strApiUrl + "/api/PlaceOrder/PlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + CCCode + "";

            
                string res = clsCommon.GET(creaturl);

                if (!string.IsNullOrWhiteSpace(res))
                {
                    ClsOrderModels.PlaceOrderModel objplaceorder = JsonConvert.DeserializeObject<ClsOrderModels.PlaceOrderModel>(res);
                    
                    if(objplaceorder.resultflag=="1"){

                        string Oid = objplaceorder.OrderId;
                        string value = clsCommon.Base64Encode(Oid);

                       

                        if (!string.IsNullOrWhiteSpace(Oid))
                        {
                            HttpContext.Current.Session["PlaceOrderId"] = value;
                            return res;
                           
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                    
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
            
        }
        catch (Exception ee)
        {
            return "";

        }
        
    }

    [System.Web.Services.WebMethod]
    public static object CODPlaceOrder(String CustId, string PayAmt, string addr, string qty, string buyflag, string disc, string redm, string ccode, string shipcharg, string rcode)
    {
        try
        {
            decimal payableamt = 0;
            decimal.TryParse(PayAmt.ToString(), out payableamt);
            if (payableamt > 0)
            {
            NewCode:

                string CCCode = "";
            string rrrCCode = "";
            string refercode = "";
            if (rcode == "")
                {
                    string coddd = clsCommon.GenerateRandomNumber().ToString();
                    int test = getcheck(coddd);

                    if (test == 0)
                    {
                        goto NewCode;
                    }

                   // CCCode = clsCommon.Base64Encode(coddd);
                    CCCode = coddd;
                }
                else
                {
                    //rrrCCode = clsCommon.Base64Encode(rcode);
                    //refercode = rrrCCode.ToString();
                }

            //string creaturl = clsCommon.strApiUrl + "/api/CODOrder/CODPlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + (String.IsNullOrWhiteSpace(CCCode) ? "0" : CCCode) + "&refrcode=" + (String.IsNullOrWhiteSpace(rcode) ? "0" : rcode) + "";

            string creaturl = clsCommon.strApiUrl + "/api/CODOrder/CODPlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + (String.IsNullOrWhiteSpace(CCCode) ? "0" : CCCode) + "&refrcode=" +rcode + "";

                string res = clsCommon.GET(creaturl);

                if (!string.IsNullOrWhiteSpace(res))
                {
                    ClsOrderModels.PlaceOrderModel objplaceorder = JsonConvert.DeserializeObject<ClsOrderModels.PlaceOrderModel>(res);

                    if (objplaceorder.resultflag == "1")
                    {

                        string Oid = objplaceorder.OrderId;
                        string value = clsCommon.Base64Encode(Oid);
                        string couponcode = objplaceorder.Ccode;


                        if (!string.IsNullOrWhiteSpace(Oid))
                        {
                            HttpContext.Current.Session["PlaceOrderId"] = value;
                            HttpContext.Current.Session["CouponCode"] = couponcode;


                           


                            return res;

                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }

                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }

        }
        catch (Exception ee)
        {
            return "";

        }

    }
    [System.Web.Services.WebMethod]
    public static object CODPlaceMultipleOrder(List<ClsOrderModels.ConfirmOrderNewModel> summeryModel,string totalamount,string redeemamount, string PromoAmount, string Discount, string PaidAmt, string PromoCode,string reorderid = "0")
    {
        try
        {
            HttpContext.Current.Session["summeryModel"] = summeryModel;
            HttpContext.Current.Session["totalamount"] = totalamount;
            HttpContext.Current.Session["redeemamount"] = redeemamount;
            HttpContext.Current.Session["PromoAmount"] = PromoAmount;
            HttpContext.Current.Session["Discount"] = Discount;
            HttpContext.Current.Session["PaidAmt"] = PaidAmt;
            HttpContext.Current.Session["PromoCode"] = PromoCode;
            HttpContext.Current.Session["reorderid"] = reorderid;

            return "Success";
            //ClsOrderModels.PlaceMultipleOrderModel OrderDetail;
            //ClsOrderModels.PlaceMultipleOrderNewModel OrderDetail;
            //WalletModel.RedeemeWalletFromOrder walletHistory;
            //WalletModel.RedeemePromoCodeFromOrder PromoHistory;
            //if ((HttpContext.Current.Session["ConfirmOrder"] != null))
            //{
            //    //OrderDetail = (ClsOrderModels.PlaceMultipleOrderModel)HttpContext.Current.Session["ConfirmOrder"];
            //    OrderDetail = (ClsOrderModels.PlaceMultipleOrderNewModel)HttpContext.Current.Session["ConfirmOrder"];

            //}
            //else
            //{
            //    //OrderDetail = new ClsOrderModels.PlaceMultipleOrderModel();
            //    OrderDetail = new ClsOrderModels.PlaceMultipleOrderNewModel();
            //}

            //if ((HttpContext.Current.Session["WalletHistory"] != null))
            //{
            //    walletHistory = (WalletModel.RedeemeWalletFromOrder)HttpContext.Current.Session["WalletHistory"];

            //}
            //else
            //{
            //    walletHistory = new WalletModel.RedeemeWalletFromOrder();
            //}

            //if ((HttpContext.Current.Session["PromoHistory"] != null))
            //{
            //    PromoHistory = (WalletModel.RedeemePromoCodeFromOrder)HttpContext.Current.Session["PromoHistory"];

            //}
            //else
            //{
            //    PromoHistory = new WalletModel.RedeemePromoCodeFromOrder();
            //}

            //OrderDetail.WalletId = walletHistory.WalletId;
            //OrderDetail.WalletLinkId = walletHistory.WalletLinkId;
            //OrderDetail.WalletType = walletHistory.WalletType;
            //OrderDetail.Walletbalance = walletHistory.balance;
            //OrderDetail.WalletCrAmount = walletHistory.CrAmount;
            //OrderDetail.WalletCrDate = walletHistory.CrDate;
            //OrderDetail.WalletCrDescription = walletHistory.CrDescription;

            ////OrderDetail.PromoCodeamount = PromoAmount;
            //OrderDetail.PromoCodebalance = PromoHistory.PromoCodebalance;
            //OrderDetail.PromoCodeCrAmount = PromoHistory.PromoCodeCrAmount;
            //OrderDetail.PromoCodeCrDate = PromoHistory.PromoCodeCrDate;
            //OrderDetail.PromoCodeCrDescription = PromoHistory.PromoCodeCrDescription;
            //OrderDetail.PromoCodeId = PromoHistory.PromoCodeId;
            //OrderDetail.PromoCodeLinkId = PromoHistory.PromoCodeLinkId;
            //OrderDetail.PromoCodetype = PromoHistory.PromoCodetype;

            //OrderDetail.Cashbackamount = string.IsNullOrEmpty(PromoAmount) ? 0 : Convert.ToDecimal(PromoAmount);
            //OrderDetail.discountamount = Discount;
            //OrderDetail.PaidAmount = Convert.ToDecimal(PaidAmt);
            //OrderDetail.PromoCode = PromoCode;
            //OrderDetail.ReOrderId = reorderid;




            //decimal payableamt = 0;
            //decimal.TryParse(OrderDetail.products[0].PaidAmount.ToString(), out payableamt);
            //if (payableamt > 0)
            //{
            //NewCode:

            //    string CCCode = "";
            //    string refercode = "";
            //    string addressid = "";
                
            //    if ((HttpContext.Current.Session["ReferCode"] != null) && (HttpContext.Current.Session["ReferCode"].ToString() != ""))
            //    {
            //        refercode = HttpContext.Current.Session["ReferCode"].ToString();
            //    }


            //    if ((HttpContext.Current.Session["JurisdictionId"] != null) && (HttpContext.Current.Session["JurisdictionId"].ToString() != ""))
            //    {
            //        OrderDetail.JurisdictionID = HttpContext.Current.Session["JurisdictionId"].ToString();
            //    }


            //    if (refercode == "")
            //    {
            //        string coddd = clsCommon.GenerateRandomNumber().ToString();
            //        int test = getcheck(coddd);

            //        if (test == 0)
            //        {
            //            goto NewCode;
            //        }

            //        CCCode = coddd;
            //    }
            //    else
            //    {
            //    }

            //    if ((HttpContext.Current.Session["Addressid"] != null))
            //    {
            //        addressid = HttpContext.Current.Session["Addressid"].ToString();
            //        addressid = clsCommon.Base64Decode(addressid);
            //    }

               
            //    OrderDetail.AddressId = addressid;
            //    OrderDetail.CustomerId = clsCommon.getCurrentCustomer().id;
            //    OrderDetail.Redeemeamount = redeemamount;
            //    OrderDetail.orderMRP = totalamount;
            //    OrderDetail.totalAmount = totalamount;

            //    foreach (var item in OrderDetail.products)
            //    {
            //        item.couponCode = CCCode;
            //        item.refrcode = refercode;
            //    }
            //    if (summeryModel.Count > 0 && summeryModel != null)
            //    {
            //        int totalqty = 0;
            //        //List<ClsOrderModels.OrderQuantityModel> orderQuantities = new List<ClsOrderModels.OrderQuantityModel>();
            //        //OrderDetail.orderMRP = totalamount;
            //        //OrderDetail.totalAmount = totalamount;
            //        foreach (var item in summeryModel)
            //        {
            //            foreach (var product in OrderDetail.products)
            //            {
            //                if(item.Productid == product.productid)
            //                {
            //                    product.Quantity = item.Qty.ToString();
            //                }
                            
            //            }
                        
            //        }
            //        for (int i = 0; i < OrderDetail.products.Count; i++)
            //        {
            //            totalqty += Convert.ToInt32(OrderDetail.products[i].Quantity);
            //        }
            //        OrderDetail.totalQty = totalqty.ToString();
            //    }
            //    WebClient client = new WebClient();
            //    client.Encoding = Encoding.UTF8;
            //    client.Headers["Content-type"] = "application/json";
            //    client.Headers["DeviceType"] = "Web";

            //    var model = JsonConvert.SerializeObject(OrderDetail);
            //    //var data = client.UploadString(clsCommon.strApiUrl + "/api/CODOrder/CODPlaceMultipleOrder", model);
            //    var data = client.UploadString(clsCommon.strApiUrl + "/api/CODOrder/CODPlaceMultipleOrderNew", model);
            //    //string creaturl = clsCommon.strApiUrl + "/api/CODOrder/CODPlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + (String.IsNullOrWhiteSpace(CCCode) ? "0" : CCCode) + "&refrcode=" + (String.IsNullOrWhiteSpace(rcode) ? "0" : rcode) + "";

            //    //string creaturl = clsCommon.strApiUrl + "/api/CODOrder/CODPlaceOrder?CustomerId=" + CustId + "&PaidAmount=" + PayAmt + "&AddressId=" + addr + "&Quantity=" + qty + "&buywith=" + buyflag + "&discountamount=" + disc + "&Redeemeamount=" + redm + "&couponCode=" + (String.IsNullOrWhiteSpace(CCCode) ? "0" : CCCode) + "&refrcode=" + rcode + "";

            //    //string res = clsCommon.GET(creaturl);

            //    if (!string.IsNullOrWhiteSpace(data))
            //    {
            //        ClsOrderModels.PlaceOrderModel objplaceorder = JsonConvert.DeserializeObject<ClsOrderModels.PlaceOrderModel>(data);
            //        //ClsOrderModels.PlaceMultipleOrderNewModel objplaceorder = JsonConvert.DeserializeObject<ClsOrderModels.PlaceMultipleOrderNewModel>(data);
            //        if (objplaceorder.resultflag == "1")
            //        {

            //            string Oid = objplaceorder.OrderId;
            //            string value = clsCommon.Base64Encode(Oid);
            //            string couponcode = objplaceorder.Ccode;


            //            if (!string.IsNullOrWhiteSpace(Oid))
            //            {
            //                HttpContext.Current.Session["PlaceOrderId"] = value;
            //                HttpContext.Current.Session["CouponCode"] = couponcode;





            //                return data;

            //            }
            //            else
            //            {
            //                return "";
            //            }
            //        }
            //        else
            //        {
            //            return "";
            //        }

            //    }
            //    else
            //    {
            //        return "";
            //    }
            //}
            //else
            //{
            //    return "";
            //}

        }
        catch (Exception ee)
        {
            return "";

        }

    }

    [System.Web.Services.WebMethod]
    public static string Remove(string productid, string attributeid)
    {
        ClsOrderModels.PlaceMultipleOrderNewModel orderModel;
        if ((HttpContext.Current.Session["ConfirmOrder"] != null))
        {
            orderModel = (ClsOrderModels.PlaceMultipleOrderNewModel)HttpContext.Current.Session["ConfirmOrder"];

        }
        else
        {
            orderModel = new ClsOrderModels.PlaceMultipleOrderNewModel();
        }

        if (orderModel != null)
        {
            if (orderModel.products.Count > 1)
            {
                ClsOrderModels.ProductListNew product = orderModel.products.Where(x => x.productid == productid && x.AttributeId == attributeid).FirstOrDefault();
                orderModel.products.Remove(product);

                HttpContext.Current.Session["ConfirmOrder"] = orderModel;
                string p = "false";
                foreach (var item in orderModel.products)
                {
                    if(item.isOfferExpired || item.isOutOfStock || !item.isProductAvailable)
                    {
                        p = "true";
                    } 
                }


                return "Success,"+ p;
            }
            else
            {
                HttpContext.Current.Session["ConfirmOrder"] = null;
                return "lastproduct";
            }
            
        }
        else
        {
            return "Fail";
        }
    }
    [System.Web.Services.WebMethod]
    public static string  GetProductDetailsForReorder(string orderid)
    {
        try
        {


            string JurisdictionId = string.Empty;
            if ((HttpContext.Current.Session["JurisdictionId"] != null))
            {
                JurisdictionId = HttpContext.Current.Session["JurisdictionId"].ToString();
            }
            string CustomerId = clsCommon.getCurrentCustomer().id;

            string apiString = clsCommon.strApiUrl + "api/CODOrder/GetProductListFromReOrder?orderid=" + orderid + "&JurisdictionId=" + JurisdictionId + "&CustomerId=" + CustomerId;
            string data = clsCommon.GET(apiString);

            if (!String.IsNullOrEmpty(data))
            {
                ClsOrderModels.ReOrderProductList objorder = JsonConvert.DeserializeObject<ClsOrderModels.ReOrderProductList>(data);
                string value = clsCommon.Base64Encode(objorder.AddressId);
                //HttpContext.Current.Session["Addressid"] = value;
                //getaddr(CustomerId, objorder.AddressId);
                ClsOrderModels.PlaceMultipleOrderNewModel orderModel = new ClsOrderModels.PlaceMultipleOrderNewModel();
                List<ClsOrderModels.ProductListNew> products = new List<ClsOrderModels.ProductListNew>();
                List<ClsOrderModels.ConfirmOrderNewModel> model = new List<ClsOrderModels.ConfirmOrderNewModel>();

                if ((HttpContext.Current.Session["ConfirmOrder"] != null))
                {
                    orderModel = (ClsOrderModels.PlaceMultipleOrderNewModel)HttpContext.Current.Session["ConfirmOrder"];

                }
                else
                {
                    orderModel = new ClsOrderModels.PlaceMultipleOrderNewModel();
                }
                int Qty = 0;
                if (orderModel.products != null && orderModel.products.Count > 0)
                {

                    foreach (var item in objorder.ProductList)
                    {
                        var product = orderModel.products.Where(x => x.productid == item.ProductId && x.AttributeId == item.ProductAttributesList.FirstOrDefault().AttributeId).FirstOrDefault();
                        if (product != null)
                        {
                            foreach (var prod in orderModel.products)
                            {
                                if (item.ProductId == prod.productid)
                                {
                                    var attribute = item.ProductAttributesList.Where(x => x.AttributeId == prod.AttributeId).FirstOrDefault();
                                    if (attribute != null)
                                    {
                                        var qty = Convert.ToInt32(prod.Quantity);
                                        qty += attribute.Quantity;
                                        prod.Quantity = qty.ToString();
                                    }

                                }

                            }
                        }
                        else
                        {
                            int BannerProductType = Convert.ToInt32(item.ItemType);
                            int BannerId = string.IsNullOrEmpty(item.bannerId) ? 0 : Convert.ToInt32(item.bannerId);
                            string Productid = item.ProductId;
                            //int Qty = item.Quantity;
                            string ProductVariant = item.ItemType == "1" ? string.Empty : "BannerProduct";
                            bool isOfferExpired = item.isOfferExpired;
                            bool isProductAvailable = item.isProductAvailable;

                            int mrp = 0; int soshoprice = 0;
                            string grpid = string.Empty, Unit = string.Empty, Unitid = string.Empty;
                            bool isOutOfStock = false;



                            foreach (var attributes in item.ProductAttributesList)
                            {
                                mrp = Convert.ToInt32(attributes.Mrp);
                                soshoprice = Convert.ToInt32(attributes.soshoPrice);
                                grpid = attributes.AttributeId;
                                Unit = attributes.weight.Split('-')[0];
                                Unitid = attributes.weight.Split('-')[1];
                                isOutOfStock = attributes.isOutOfStock;
                                Qty = attributes.Quantity;
                            }

                            model.Add(new ClsOrderModels.ConfirmOrderNewModel
                            {
                                BannerProductType = BannerProductType,
                                BannerId = BannerId,
                                Productid = Productid,
                                Grpid = grpid,
                                Mrp = mrp,
                                SoshoPrice = soshoprice,
                                Qty = Qty,
                                Unit = Unit,
                                UnitId = Unitid,
                                Productvariant = ProductVariant,
                                isOfferExpired = isOfferExpired,
                                isProductAvailable = isProductAvailable,
                                isOutOfStock = isOutOfStock

                            });

                        }

                    }

                    foreach (var item in model)
                    {
                        item.MrpTotal = item.Mrp * item.Qty;
                        item.SoshoTotal = item.SoshoPrice * item.Qty;
                        orderModel.products.Add(new ClsOrderModels.ProductListNew
                        {
                            productid = item.Productid,
                            PaidAmount = item.SoshoPrice,
                            Quantity = item.Qty.ToString(),
                            UnitId = item.UnitId.ToString(),
                            Unit = item.Unit.ToString(),
                            Productvariant = item.Productvariant,
                            AttributeId = item.Grpid,
                            //UnitId = "Gram",
                            //Unit = "500",
                            couponCode = "0",
                            refrcode = "0",
                            BannerId = item.BannerId,
                            BannerProductType = item.BannerProductType,
                            Mrp = item.Mrp,
                            isOfferExpired = item.isOfferExpired,
                            isOutOfStock = item.isOutOfStock,
                            isProductAvailable = item.isProductAvailable
                        });
                    }

                    orderModel.discountamount = "0";
                    orderModel.Redeemeamount = "0";
                    //orderModel.CustomerId = clsCommon.getCurrentCustomer().id;
                    orderModel.orderMRP = model.Sum(x => x.MrpTotal).ToString();
                    orderModel.totalAmount = model.Sum(x => x.SoshoTotal).ToString();
                    orderModel.totalQty = model.Sum(x => x.Qty).ToString();
                    //orderModel.totalWeight = (model.Sum(x => x.Qty) * model.Sum(x => x.Weight)).ToString();
                    orderModel.totalWeight = "0";

                }
                else
                {
                    foreach (var item in objorder.ProductList)
                    {
                        int BannerProductType = Convert.ToInt32(item.ItemType);
                        int BannerId = string.IsNullOrEmpty(item.bannerId) ? 0 : Convert.ToInt32(item.bannerId);
                        string Productid = item.ProductId;
                        //int Qty = item.Quantity;
                        string ProductVariant = item.ItemType == "1" ? string.Empty : "BannerProduct";
                        bool isOfferExpired = item.isOfferExpired;
                        bool isProductAvailable = item.isProductAvailable;

                        int mrp = 0; int soshoprice = 0;
                        string grpid = string.Empty, Unit = string.Empty, Unitid = string.Empty;
                        bool isOutOfStock = false;



                        foreach (var attributes in item.ProductAttributesList)
                        {
                            mrp = Convert.ToInt32(attributes.Mrp);
                            soshoprice = Convert.ToInt32(attributes.soshoPrice);
                            grpid = attributes.AttributeId;
                            Unit = attributes.weight.Split('-')[0];
                            Unitid = attributes.weight.Split('-')[1];
                            isOutOfStock = attributes.isOutOfStock;
                            Qty = attributes.Quantity;
                        }

                        model.Add(new ClsOrderModels.ConfirmOrderNewModel
                        {
                            BannerProductType = BannerProductType,
                            BannerId = BannerId,
                            Productid = Productid,
                            Grpid = grpid,
                            Mrp = mrp,
                            SoshoPrice = soshoprice,
                            Qty = Qty,
                            Unit = Unit,
                            UnitId = Unitid,
                            Productvariant = ProductVariant,
                            isOfferExpired = isOfferExpired,
                            isProductAvailable = isProductAvailable,
                            isOutOfStock = isOutOfStock

                        });


                    }

                    foreach (var item in model)
                    {
                        item.MrpTotal = item.Mrp * item.Qty;
                        item.SoshoTotal = item.SoshoPrice * item.Qty;
                        products.Add(new ClsOrderModels.ProductListNew
                        {
                            productid = item.Productid,
                            PaidAmount = item.SoshoPrice,
                            Quantity = item.Qty.ToString(),
                            UnitId = item.UnitId.ToString(),
                            Unit = item.Unit.ToString(),
                            Productvariant = item.Productvariant,
                            AttributeId = item.Grpid,
                            //UnitId = "Gram",
                            //Unit = "500",
                            couponCode = "0",
                            refrcode = "0",
                            BannerId = item.BannerId,
                            BannerProductType = item.BannerProductType,
                            Mrp = item.Mrp,
                            isOfferExpired = item.isOfferExpired,
                            isOutOfStock = item.isOutOfStock,
                            isProductAvailable = item.isProductAvailable
                        });
                    }

                    orderModel.discountamount = "0";
                    orderModel.Redeemeamount = "0";
                    //orderModel.CustomerId = clsCommon.getCurrentCustomer().id;
                    orderModel.orderMRP = model.Sum(x => x.MrpTotal).ToString();
                    orderModel.totalAmount = model.Sum(x => x.SoshoTotal).ToString();
                    orderModel.totalQty = model.Sum(x => x.Qty).ToString();
                    //orderModel.totalWeight = (model.Sum(x => x.Qty) * model.Sum(x => x.Weight)).ToString();
                    orderModel.totalWeight = "0";

                    orderModel.products = products;
                }
               
                //getreedemamt(CustomerId, orderModel.totalAmount);
                HttpContext.Current.Session["ConfirmOrder"] = orderModel;

                return "Success";
            }
            return "";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    [System.Web.Services.WebMethod]
    public static object GetReedemableAmount(string OrderAmount = "")
    {
        string customerid = clsCommon.getCurrentCustomer().id;
        string aa = clsCommon.strApiUrl + "api/Wallet/GetCustomerOfferDetail?CustomerId=" + customerid + "&OrderAmount=" + OrderAmount;
        string redeem = clsCommon.GET(aa);
        if (!String.IsNullOrEmpty(redeem))
        {
            WalletModel.RedeemeWallet objreed = JsonConvert.DeserializeObject<WalletModel.RedeemeWallet>(redeem);
            return objreed;

        }
        else
        {
            return "";
        }
    }
}