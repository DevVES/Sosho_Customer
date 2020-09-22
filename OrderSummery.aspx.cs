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



                getaddr(Customerid, AddrId, BuyFlag);
                GetProductDetails(Customerid, AddrId, BuyFlag, Buyqty);
                getreedemamt(Customerid, "200", " 0");
                //200 and 0 Not effected

            }
        }
        catch (Exception ee)
        {
            ltrerr.Text = ee.StackTrace;
        }
    }

    public void getaddr(string Custid, string addressid, string buyflag)
    {
        try
        {

            string aa = clsCommon.strApiUrl + "/api/OrderSummery/GetOrderSummery?custid=" + Custid + "&AddressId=" + addressid + "&BuyFlag=" + buyflag + "";

            string data = clsCommon.GET(aa);
            if (!String.IsNullOrEmpty(data))
            {
                ClsOrderModels.OrderSummery objsummery = JsonConvert.DeserializeObject<ClsOrderModels.OrderSummery>(data);
                if (objsummery.Response.Equals("1"))
                {
                    lblfname.InnerText = objsummery.OrderCustomerList[0].Cfname + " " + objsummery.OrderCustomerList[0].Clname;
                    add1.InnerText = objsummery.OrderCustomerList[0].addr;
                    add2.InnerText = objsummery.OrderCustomerList[0].Cityname + " ," + objsummery.OrderCustomerList[0].statename;
                    add3.InnerText = objsummery.OrderCustomerList[0].Countryname;                  
                    lblmno.InnerText = " " + objsummery.OrderCustomerList[0].cph;
                }
            }
        }
        catch (Exception ee)
        {

            ltrerr.Text = ee.StackTrace;
        }
    }

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

                    var MrpTotal = item.PaidAmount * Convert.ToDecimal(item.Quantity);
                    string Unit = item.Unit;
                    string UnitId = item.UnitId;
                    string imgquery="", querydata="";
                    DataTable dtimg, dtpathimg;

                    //string imgquery = "select ProductImages.ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from ProductImages inner join Product ON Product.Id = ProductImages.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where ProductImages.ProductId =" + item.productid + " and isnull(ProductImages.Isdeleted,0)=0";
                    //DataTable dtimg = dbc.GetDataTable(imgquery);

                    //string querydata = "select KeyValue from StringResources where KeyName='ProductImageUrl'";
                    //DataTable dtpathimg = dbc.GetDataTable(querydata);

                    if(item.Productvariant.ToString() == "true")
                    {
                        imgquery = "select Product_ProductAttribute_Mapping.ProductImage as ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from Product_ProductAttribute_Mapping inner join Product ON Product.Id = Product_ProductAttribute_Mapping.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where Product_ProductAttribute_Mapping.ProductId =" + item.productid + " and isnull(Product_ProductAttribute_Mapping.Isdeleted,0)=0 and Product_ProductAttribute_Mapping.Id=" + item.AttributeId;
                        dtimg = dbc.GetDataTable(imgquery);

                        querydata = "select KeyValue from StringResources where KeyName='ProductAttributeImageUrl'";
                        dtpathimg = dbc.GetDataTable(querydata);
                    }
                    else
                    {
                        if (item.Productvariant.ToString() == "BannerProduct")
                        {
                            imgquery = "select ImageName as ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from IntermediateBanners InBanner inner join Product ON Product.Id = InBanner.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where InBanner.ProductId =" + item.productid + " and isnull(InBanner.Isdeleted,0)=0";
                            dtimg = dbc.GetDataTable(imgquery);

                            querydata = "select KeyValue from StringResources where KeyName='TopBannerImageUrl'";
                            dtpathimg = dbc.GetDataTable(querydata);
                        }
                        else
                        {
                            imgquery = "select ProductImages.ImageFileName, Product.Name,UnitMaster.UnitName,Product.Unit,Product.IsQtyFreeze from ProductImages inner join Product ON Product.Id = ProductImages.ProductId inner join UnitMaster ON UnitMaster.Id = Product.UnitId Where ProductImages.ProductId =" + item.productid + " and isnull(ProductImages.Isdeleted,0)=0";
                            dtimg = dbc.GetDataTable(imgquery);

                            querydata = "select KeyValue from StringResources where KeyName='ProductImageUrl'";
                            dtpathimg = dbc.GetDataTable(querydata);
                        }
                    }
                    string urlpathimg = "";
                    Boolean IsQtyFreeze = false;
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
                       
                    }
                    html += "<div class=\"single-product\">";
                    html += "<input type=\"hidden\" id=\"hdnCustId\" value=\"" + Custid + "\">";
                    html += "<div class=\"single-product left\"><div class=\"product-image\"><img id=\"proimg\" src=\""+imgname+"\"/></div></div>";
                    html += "<div class=\"single-product right\"><div class=\"product-name-order\" id=\"lblpname\"><p>"+prodname+"</p></div>";
                    //html += "<div class=\"price\"><div class=\"gram\">Price / Qty :<p id=\"lblproprice\"> " + item.PaidAmount + "</p> <span id=\"lbldisplayunit\"> Weight:"+ Weight +"</span></div>";
                    html += "<div class=\"price\"><div class=\"gram\"> <span id=\"lbldisplayunit\"> Weight:" + Weight + "</span></div>";
                    html += "<div class=\"final-amt\"><p id=\"lbltotprices\">" + MrpTotal + ".00 </p></div></div>";
                    html += "<div class=\"price\"><div class=\"gram\"> <span id=\"lbldisplayunit\"> <span>Price / Qty : " + item.PaidAmount + "</span></div></div>";
                    if (IsQtyFreeze)
                    {
                        html += "<div class=\"product-qty\"><div class=\"inline\"><button type=\"button\" style=\"color:white;background-color:#1DA1F2\" class=\"minus\" id=\"btnminuqty\" onclick=\"PriceMinus(" + item.productid + ",this)\" disabled><i class=\"fa fa-minus\"></i></button>";
                        html += "<div class=\"qty\" style=\"display: grid;\"><input readonly=true type=\"text\" id=\"txtqty\" value=\"" + item.Quantity + "\" class=\"\" style=\"width:29px; height:27px;\" onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g,'')\" maxlength=\"2\" />";
                        html += "<a onclick=\"saveitem(0); return false;\" class=\"hide\" > Save </a></div>";
                        html += "<button type=\"button\"  class=\"plus\" id=\"btnplus\" style=\"color:white;background-color:#1DA1F2\" onclick=\"Priceplus(" + item.productid + ",this)\" disabled><i class=\"fa fa-plus\"></i></button></div></div>";
                        html += "<div class=\"product-line-price\"><i class=\"fa fa-trash\" onclick=\"Remove(" + item.productid + ",this)\"></i></div></div></div>";
                    }
                    else
                    {
                        html += "<div class=\"product-qty\"><div class=\"inline\"><button type=\"button\" class=\"minus\" style=\"color:white;background-color:#1DA1F2\" id=\"btnminuqty\" onclick=\"PriceMinus(" + item.productid + ",this)\"><i class=\"fa fa-minus\"></i></button>";
                        html += "<div class=\"qty\" style=\"display: grid;\"><input type=\"text\" id=\"txtqty\" value=\"" + item.Quantity + "\" class=\"\" style=\"width:29px; height:27px;\" onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g,'')\" maxlength=\"2\" />";
                        html += "<a onclick=\"saveitem(0); return false;\" class=\"hide\" > Save </a></div>";
                        html += "<button type=\"button\"  class=\"plus\" id=\"btnplus\" style=\"color:white;background-color:#1DA1F2\" onclick=\"Priceplus(" + item.productid + ",this)\"><i class=\"fa fa-plus\"></i></button></div></div>";
                        html += "<div class=\"product-line-price\"><i class=\"fa fa-trash\" onclick=\"Remove(" + item.productid + ",this)\"></i></div></div></div>";
                    }
                    prodcontent.InnerHtml = html;
                    totwtshipping.InnerText = orderModel.totalAmount;
                    lbltotpayamt.InnerText = orderModel.totalAmount;
                }
                
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

    public void getreedemamt(string Custid, string payableamt, string reedemamt)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            //string aa = clsCommon.strApiUrl + "/api/RedeemWallet/RedeemWallet?CustomerId=" + Custid + "&OrderTotal=" + payableamt + "&Redemeamount=" + reedemamt + "";
            string aa = clsCommon.strApiUrl + "api/Wallet/GetCustomerOfferDetail?CustomerId=" + Custid;
            string redeem = clsCommon.GET(aa);
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
                    reeamt.InnerHtml = objreed.RedeemeAmount.ToString();

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
                if(objeWalletdt.response.Equals("1"))
                {
                    return redeem;
                }
                return "";
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
    public static object CODPlaceMultipleOrder(List<ClsOrderModels.OrderSummeryModel> summeryModel,string totalamount)
    {
        try
        {
            //ClsOrderModels.PlaceMultipleOrderModel OrderDetail;
            ClsOrderModels.PlaceMultipleOrderNewModel OrderDetail;
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

                if (refercode == "")
                {
                    string coddd = clsCommon.GenerateRandomNumber().ToString();
                    int test = getcheck(coddd);

                    if (test == 0)
                    {
                        goto NewCode;
                    }

                    CCCode = coddd;
                }
                else
                {
                }

                if ((HttpContext.Current.Session["Addressid"] != null))
                {
                    addressid = HttpContext.Current.Session["Addressid"].ToString();
                    addressid = clsCommon.Base64Decode(addressid);
                }

               
                OrderDetail.AddressId = addressid;
                OrderDetail.CustomerId = clsCommon.getCurrentCustomer().id;

                foreach (var item in OrderDetail.products)
                {
                    item.couponCode = CCCode;
                    item.refrcode = refercode;
                }
                if (summeryModel.Count > 0 && summeryModel != null)
                {
                    int totalqty = 0;
                    //List<ClsOrderModels.OrderQuantityModel> orderQuantities = new List<ClsOrderModels.OrderQuantityModel>();
                    OrderDetail.orderMRP = totalamount;
                    OrderDetail.totalAmount = totalamount;
                    foreach (var item in summeryModel)
                    {
                        foreach (var product in OrderDetail.products)
                        {
                            if(item.Productid == product.productid)
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





                            return data;

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
    public static string Remove(string productid)
    {
        ClsOrderModels.PlaceMultipleOrderModel orderModel;
        if ((HttpContext.Current.Session["ConfirmOrder"] != null))
        {
            orderModel = (ClsOrderModels.PlaceMultipleOrderModel)HttpContext.Current.Session["ConfirmOrder"];

        }
        else
        {
            orderModel = new ClsOrderModels.PlaceMultipleOrderModel();
        }

        if (orderModel != null)
        {
            if (orderModel.products.Count > 1)
            {
                ClsOrderModels.ProductList product = orderModel.products.Where(x => x.productid == productid).FirstOrDefault();
                orderModel.products.Remove(product);

                HttpContext.Current.Session["ConfirmOrder"] = orderModel;

                return "Success";
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
}