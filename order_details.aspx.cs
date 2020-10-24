using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order_details : System.Web.UI.Page
{
    dbConnection dbc = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string Orderid123 = "";
            if (!IsPostBack)
            {
                //string data = Session["OrderId"].ToString();

                //starting 20_10_2019
                if (!string.IsNullOrWhiteSpace(Request.QueryString["Orderid"]))
                {
                    Orderid123 = Request.QueryString["Orderid"].ToString();
                }

                if (Session["OrderId"] != null && Session["OrderId"] != "")
                {
                    Orderid123 = Session["OrderId"].ToString();
                }
                string orderrdata = clsCommon.Base64Decode(Orderid123);
                int oid = 0;
                int.TryParse(orderrdata.ToString(), out oid);
                if (oid > 0)
                {
                    OrderDetailsBind(oid);

                    //string addressstr = "select FirstName+' ' +LastName as CustName,Address,(select CityName from CityMaster where CityMaster.Id=CustomerAddress.CityId)as CityName,CustomerAddress.pincode,(select StateMaster.StateName from StateMaster where StateMaster.Id=CustomerAddress.StateId) as StateName,(select CountryMaster.CountryName from CountryMaster where CountryMaster.Id=CustomerAddress.CountryId)as CountryName,CustomerAddress.MobileNo from CustomerAddress where Id=(select AddressId from [Order] where id="+oid+") ;";

                    //string addressstr = "select FirstName as CustName,Address,(select CityName from CityMaster where CityMaster.Id=CustomerAddress.CityId)as CityName,CustomerAddress.pincode,(select StateMaster.StateName from StateMaster where StateMaster.Id=CustomerAddress.StateId) as StateName,(select CountryMaster.CountryName from CountryMaster where CountryMaster.Id=CustomerAddress.CountryId)as CountryName,CustomerAddress.MobileNo from CustomerAddress where Id=(select AddressId from [Order] where id=" + oid + ") ;";

                    //DataTable dtdataa = dbc.GetDataTable(addressstr);




                    //if (dtdataa != null && dtdataa.Rows.Count > 0)
                    //{
                    //    lbladdname.InnerHtml = dtdataa.Rows[0]["CustName"].ToString();
                    //    lbladd.InnerHtml = dtdataa.Rows[0]["Address"].ToString() + ", " + dtdataa.Rows[0]["CityName"] + "-" + dtdataa.Rows[0]["pincode"].ToString();
                    //    lbladdstate.InnerHtml = dtdataa.Rows[0]["StateName"] + ", " + dtdataa.Rows[0]["CountryName"];
                    //    lbladdmob.InnerHtml = dtdataa.Rows[0]["MobileNo"].ToString();
                    //}

                    //string OrderDetails = "select OrderItem.BuyWith,ISNULL(OrderItem.CustOfferCode,[Order].CustOfferCode) as CustOfferCode,[Order].Id as oid,  (DATENAME(dw,CAST(DATEPART(m, [Order].CreatedOnUtc) AS VARCHAR)+ '/'+ CAST(DATEPART(d, [Order].CreatedOnUtc) AS VARCHAR)  + '/' + CAST(DATEPART(yy, [Order].CreatedOnUtc) AS VARCHAR))) +' '+convert(varchar(12),[Order].CreatedOnUtc,106)+', '+convert(varchar(12),[Order].CreatedOnUtc,108) as EndDate,ISNULL([Order].OrderMRP,0) as MRP,ISNULL([Order].OrderTotal,0)as OrderTotal,[Order].TotalQTY,isnull((select top 1 Name from Payment_Methods where [Order].PaymentGatewayId=Payment_Methods.Id),'Default') as GatwayType  from [Order] Inner Join OrderItem ON OrderItem.OrderId = [Order].Id where [Order].Id=" + oid;

                    //DataTable dtorderdetails = dbc.GetDataTable(OrderDetails);

                    //string imaagedetails = "select Product.Name,Product.Mrp,Product.ProductMrp,Product.[DisplayNameInMsg],Product.[ShowMrpInMsg], Product.BuyWith1FriendExtraDiscount, Product.BuyWith5FriendExtraDiscount, Product.id as pid,OrderItem.Quantity,isnull(Unit,'0') as unitweg,isnull((select UnitName from UnitMaster where UnitMaster.Id=Product.UnitId),'Gram')as Unit from Product inner join OrderItem ON OrderItem.ProductId = Product.Id Where OrderItem.OrderId =" + oid ;
                    //DataTable dtimgstr = dbc.GetDataTable(imaagedetails);

                    //string productid = dtimgstr.Rows[0]["pid"].ToString();
                    //bool status = clsCommon.ProductStatus(productid);
                    //if (status == true)
                    //{
                    //    disp.InnerHtml = "";
                    //}
                    //string ProductNameinmsg = "";
                    //bool ismrp = false;

                    //if (dtorderdetails != null && dtorderdetails.Rows.Count > 0)
                    //{

                    //    ProductNameinmsg = dtimgstr.Rows[0]["DisplayNameInMsg"].ToString();
                    //    ismrp = bool.Parse(dtimgstr.Rows[0]["ShowMrpInMsg"].ToString());

                    //    lblorderid.InnerHtml = dtorderdetails.Rows[0]["oid"].ToString();
                    //    orderdatedid.InnerHtml = dtorderdetails.Rows[0]["EndDate"].ToString();
                    //    //lblmrp.InnerHtml = dtimgstr.Rows[0]["ProductMrp"].ToString();
                    //    lbltotordeamt.InnerHtml = dtorderdetails.Rows[0]["OrderTotal"].ToString();
                    //    lblqtyno.InnerHtml = dtorderdetails.Rows[0]["TotalQTY"].ToString();
                    //    lblpayment.InnerHtml = dtorderdetails.Rows[0]["GatwayType"].ToString();
                    //    string productname = dtimgstr.Rows[0]["Name"].ToString();

                    //    if (ProductNameinmsg.Length == 0 || ProductNameinmsg == null || ProductNameinmsg == "")
                    //    {
                    //        ProductNameinmsg = dtimgstr.Rows[0]["Name"].ToString();
                    //    }
                    //    string productidd = dtimgstr.Rows[0]["pid"].ToString();
                    //    string flag = dtorderdetails.Rows[0]["BuyWith"].ToString();
                    //    string custorder = dtorderdetails.Rows[0]["CustOfferCode"].ToString();

                    //    string mess = "";
                    //    string forcust = "";
                    //    string mrp = "";
                    //    mrp = dtimgstr.Rows[0]["Mrp"].ToString();
                    //    string date = clsCommon.getProductExpiredOnDate(productidd);
                    //    string ocode = "";
                    //    if (custorder != null && custorder != "")
                    //    {
                    //        ocode = "/?offercode=" + custorder;
                    //    }
                    //    string mrpd = "";

                    //    if (ismrp == true)
                    //    {
                    //        mrpd = "(MRP ₹ " + dtimgstr.Rows[0]["ProductMrp"].ToString() + ")";
                    //    }
                    //    if (flag == "1")
                    //    {
                    //        forcust = dtimgstr.Rows[0]["Mrp"].ToString();

                    //        //string title = "Final Step";
                    //        string[] daaata = forcust.Split('.');
                    //        forcust = daaata[0].ToString();
                    //        string[] mrpdata = mrp.Split('.');
                    //        mrp = mrpdata[0].ToString();
                    //        mess = "Share this offer on WhatsApp so that your friends can also make the most if it!";
                    //    }
                    //    else if (flag == "2")
                    //    {
                    //        forcust = dtimgstr.Rows[0]["BuyWith1FriendExtraDiscount"].ToString();

                    //        //string title = "Final Step";
                    //        string[] daaata = forcust.Split('.');
                    //        forcust = daaata[0].ToString();
                    //        string[] mrpdata = mrp.Split('.');
                    //        mrp = mrpdata[0].ToString();
                    //        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "');", true);
                    //        mess = "Since you have chosen to buy with 1 friend, share offer to ensure your friend buys it by " + date + " to pay offer price of only ₹" + forcust + " instead of single-buy price of ₹" + mrp + " at time of delivery.Link sosho.in";


                    //    }
                    //    else if (flag == "6")
                    //    {
                    //        forcust = dtimgstr.Rows[0]["BuyWith5FriendExtraDiscount"].ToString();
                    //        string[] daaata = forcust.Split('.');
                    //        forcust = daaata[0].ToString();


                    //        string[] mrpdata = mrp.Split('.');
                    //        mrp = mrpdata[0].ToString();
                    //        //string title = "Final Step";

                    //        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "');", true);
                    //        mess = "Since you have chosen to buy with 4 friends, share offer to ensure your friends buy it by  " + date + " to pay offer price of only ₹" + forcust + " instead of single-buy price of ₹" + mrp + " at time of delivery.";
                    //    }


                    //    string productdetails = string.Empty;
                    //    string enddate = string.Empty;

                    //    string proddetails = "Select TOP 1 FORMAT(EndDate, 'dd MMM yyy htt') AS ProductEndDate, Product.Name + ' at only Rs ' + CONVERT(nvarchar, Product.Mrp) + ' (MRP ' + CONVERT(nvarchar, Product.ProductMrp) + ') for ' + isnull(Unit, '0') + ' ' + isnull((select UnitName from UnitMaster where UnitMaster.Id = Product.UnitId),'Gram') as productdetails from Product inner join OrderItem ON OrderItem.ProductId = Product.Id Where OrderItem.OrderId =" + dtorderdetails.Rows[0]["oid"].ToString() + " Order By EndDate Desc";

                    //    DataTable dtproductdetail = dbc.GetDataTable(proddetails);
                    //    if (dtproductdetail.Rows.Count > 0)
                    //    {
                    //        productdetails = dtproductdetail.Rows[0]["productdetails"].ToString();
                    //        enddate = dtproductdetail.Rows[0]["ProductEndDate"].ToString();
                    //    }
                    //    string WhatsappMsg = "Hi! I bought " + productdetails + " and other items at great rates. Free shipping with Covid precautions and Cash on delivery. If you buy it before " + enddate + ", you can also get the same discount. Just follow this link: http://www.sosho.in" + ocode;
                    //    // lblmsgtest.InnerHtml = "<span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"web\" href=\"https://web.whatsapp.com/send?text=Hi! I just bought " + ProductNameinmsg + " at just ₹" + forcust + " " + mrpd + ". If you buy it before " + date + ", you can also get the same discount. Just follow this link: http://www.sosho.in" + ocode + " \"share/whatsapp/share\" target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span> <span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"mo-wa\" href=\"whatsapp://send?text=Hi! I just bought " + ProductNameinmsg + " at just ₹" + forcust + ". If you buy it before " + date + ", you can also get the same discount. Just follow this link: http://www.sosho.in" + ocode + " target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span>";
                    //    lblmsgtest.InnerHtml = "<span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"web\" href=\"https://web.whatsapp.com/send?text=" + WhatsappMsg + " \"share/whatsapp/share\" target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span> <span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"mo-wa\" href=\"whatsapp://send?text=" + WhatsappMsg + "\"target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span>";

                    //}
                    //if (dtimgstr.Rows.Count > 0)
                    //{
                    //   // lblnamee.InnerHtml = dtimgstr.Rows[0]["Name"].ToString();
                    //    //lblweigh.InnerHtml = dtimgstr.Rows[0]["unitweg"].ToString() + " " + dtimgstr.Rows[0]["Unit"];

                    //    string proddetail = "";
                    //    for (int i = 0; i < dtimgstr.Rows.Count; i++)
                    //    {
                    //        string productidd = dtimgstr.Rows[i]["pid"].ToString();
                    //        string imagename = "select ImageFileName from ProductImages where Productid=" + productidd + "";
                    //        DataTable dtimage = dbc.GetDataTable(imagename);
                    //        string query = "SELECT [KeyValue] FROM [StringResources] where KeyName='ProductImageUrl'";
                    //        DataTable dtfolder = dbc.GetDataTable(query);
                    //        string folder = "";
                    //        string imgname = "";
                    //        if (dtfolder != null && dtfolder.Rows.Count > 0)
                    //        {

                    //            folder = dtfolder.Rows[0]["KeyValue"].ToString();

                    //            if (dtimage != null && dtimage.Rows.Count > 0)
                    //            {
                    //                imgname = folder + dtimage.Rows[0]["ImageFileName"].ToString();
                    //            }
                    //        }

                    //        string pname = dtimgstr.Rows[i]["Name"].ToString();
                    //        string weight  = dtimgstr.Rows[i]["unitweg"].ToString() + " " + dtimgstr.Rows[i]["Unit"].ToString();
                    //        string qty = dtimgstr.Rows[i]["Quantity"].ToString();

                    //        proddetail += "<div class=\"col-md-4 col-sm-4 col-xs-4 padding\"><div><img src=" + imgname + " /></div></div>";
                    //        proddetail += "<div class=\"col-md-8 col-sm-8 col-xs-8 padding\"><p class=\"name\">"+ pname + "</p>";
                    //        proddetail += "<p class=\"qty\">Qty:<span>"+ qty + "</span></p>";
                    //        proddetail += "<div class=\"weight\"><p>weight:<span>" + weight + "</span></p></div></div>";
                    //    }


                    //    proddetails.InnerHtml = proddetail;

                    //}

                   
                }
            }

        }
        catch (Exception ee)
        {
        }
    }

    public void OrderDetailsBind(int orderid)
    {
        string apiString = clsCommon.strApiUrl + "api/Order/CustOrderDetailForMultipleProduct/?orderid=" + orderid;
        string data = clsCommon.GET(apiString);
        if (!String.IsNullOrEmpty(data))
        {
            ClsOrderModels.orderdetailformultiple objorder = JsonConvert.DeserializeObject<ClsOrderModels.orderdetailformultiple>(data);
            if (objorder.Response.Equals("1"))
            {
                lbladdname.InnerHtml = objorder.CustName;
                lbladd.InnerHtml = objorder.CustAddress;
                //lbladdstate.InnerHtml = dtdataa.Rows[0]["StateName"] + ", " + dtdataa.Rows[0]["CountryName"];
                lbladdmob.InnerHtml = objorder.CustMob;

                lblorderid.InnerHtml = objorder.OrderId;
                orderdatedid.InnerHtml = objorder.OrderDate;
                lbltotordeamt.InnerHtml = objorder.Amount;
                lblqtyno.InnerHtml = objorder.TotalQty;
                lblpayment.InnerHtml = objorder.PaymentMode;
                lblmsgtest.InnerHtml = "<span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"web\" href=\"https://web.whatsapp.com/send?text=" + objorder.WhatsappMsg + " \"share/whatsapp/share\" target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span> <span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"mo-wa\" href=\"whatsapp://send?text=" + objorder.WhatsappMsg + "\"target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span>";
                if (objorder.products != null && objorder.products.Count > 0){
                    //string productid = objorder.products.FirstOrDefault().ProductId;
                    //bool status = clsCommon.ProductStatus(productid);
                    //if (status == true)
                    //{
                    //    disp.InnerHtml = "";
                    //}
                    string proddetail = string.Empty;

                    foreach (var item in objorder.products)
                    {

                        proddetail += "<div class=\"col-md-4 col-sm-4 col-xs-4 padding\"><div><img src=\"" + item.ProductImg + "\" /></div></div>";
                        proddetail += "<div class=\"col-md-8 col-sm-8 col-xs-8 padding\"><p class=\"name\">" + item.ProductName + "</p>";
                        proddetail += "<p class=\"qty\">Qty:<span>" + item.Qty + "</span></p>";
                        proddetail += "<div class=\"weight\"><p>weight:<span>" + item.Weight + "</span></p></div></div>";

                    }
                    proddetails.InnerHtml = proddetail;


                }
                

            }
        }

    }
}







//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//public partial class order_details : System.Web.UI.Page
//{
//    dbConnection dbc = new dbConnection();
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        try
//        {
//            string Orderid123 = "";
//            if (!IsPostBack)
//            {
//                //string data = Session["OrderId"].ToString();

//                //starting 20_10_2019
//                if (!string.IsNullOrWhiteSpace(Request.QueryString["Orderid"]))
//                {
//                    Orderid123 = Request.QueryString["Orderid"].ToString();
//                }

//                if (Session["OrderId"] != null && Session["OrderId"] != "")
//                {
//                    Orderid123 = Session["OrderId"].ToString();
//                }
//                string orderrdata = clsCommon.Base64Decode(Orderid123);
//                int oid = 0;
//                int.TryParse(orderrdata.ToString(), out oid);
//                if (oid > 0)
//                {

//                    //string addressstr = "select FirstName+' ' +LastName as CustName,Address,(select CityName from CityMaster where CityMaster.Id=CustomerAddress.CityId)as CityName,CustomerAddress.pincode,(select StateMaster.StateName from StateMaster where StateMaster.Id=CustomerAddress.StateId) as StateName,(select CountryMaster.CountryName from CountryMaster where CountryMaster.Id=CustomerAddress.CountryId)as CountryName,CustomerAddress.MobileNo from CustomerAddress where Id=(select AddressId from [Order] where id="+oid+") ;";

//                    string addressstr = "select FirstName as CustName,Address,(select CityName from CityMaster where CityMaster.Id=CustomerAddress.CityId)as CityName,CustomerAddress.pincode,(select StateMaster.StateName from StateMaster where StateMaster.Id=CustomerAddress.StateId) as StateName,(select CountryMaster.CountryName from CountryMaster where CountryMaster.Id=CustomerAddress.CountryId)as CountryName,CustomerAddress.MobileNo from CustomerAddress where Id=(select AddressId from [Order] where id=" + oid + ") ;";

//                    DataTable dtdataa = dbc.GetDataTable(addressstr);




//                    if (dtdataa != null && dtdataa.Rows.Count > 0)
//                    {
//                        lbladdname.InnerHtml = dtdataa.Rows[0]["CustName"].ToString();
//                        lbladd.InnerHtml = dtdataa.Rows[0]["Address"].ToString() + ", " + dtdataa.Rows[0]["CityName"] + "-" + dtdataa.Rows[0]["pincode"].ToString();
//                        lbladdstate.InnerHtml = dtdataa.Rows[0]["StateName"] + ", " + dtdataa.Rows[0]["CountryName"];
//                        lbladdmob.InnerHtml = dtdataa.Rows[0]["MobileNo"].ToString();
//                    }

//                    string OrderDetails = "select [Order].BuyWith,[Order].CustOfferCode,[Order].Id as oid,  (DATENAME(dw,CAST(DATEPART(m, CreatedOnUtc) AS VARCHAR)+ '/'+ CAST(DATEPART(d, CreatedOnUtc) AS VARCHAR)  + '/' + CAST(DATEPART(yy, CreatedOnUtc) AS VARCHAR))) +' '+convert(varchar(12),CreatedOnUtc,106)+', '+convert(varchar(12),CreatedOnUtc,108) as EndDate,ISNULL([Order].OrderMRP,0) as MRP,ISNULL([Order].OrderTotal,0)as OrderTotal,[Order].TotalQTY,isnull((select top 1 Name from Payment_Methods where [Order].PaymentGatewayId=Payment_Methods.Id),'Default') as GatwayType  from [Order] where [Order].Id=" + oid + "";

//                    DataTable dtorderdetails = dbc.GetDataTable(OrderDetails);

//                    string imaagedetails = "select Product.ProductMrp,Product.Mrp,Product.BuyWith1FriendExtraDiscount,Product.BuyWith5FriendExtraDiscount,Product.id as pid,product.Name,isnull(Unit,'0') as unitweg,isnull((select UnitName from UnitMaster where UnitMaster.Id=Product.UnitId),'Gram')as Unit from Product where Product.Id=(select ProductId from orderitem where orderid=" + oid + ")";
//                    DataTable dtimgstr = dbc.GetDataTable(imaagedetails);

//                    string productid = dtimgstr.Rows[0]["pid"].ToString();
//                    bool status = clsCommon.ProductStatus(productid);
//                    if (status == true)
//                    {
//                        disp.InnerHtml = "";                                        
//                    }
//                    if (dtorderdetails != null && dtorderdetails.Rows.Count > 0)
//                    {
//                        lblorderid.InnerHtml = dtorderdetails.Rows[0]["oid"].ToString();
//                        orderdatedid.InnerHtml = dtorderdetails.Rows[0]["EndDate"].ToString();
//                        lblmrp.InnerHtml = dtimgstr.Rows[0]["ProductMrp"].ToString();
//                        lbltotordeamt.InnerHtml = dtorderdetails.Rows[0]["OrderTotal"].ToString();
//                        lblqtyno.InnerHtml = dtorderdetails.Rows[0]["TotalQTY"].ToString();
//                        lblpayment.InnerHtml = dtorderdetails.Rows[0]["GatwayType"].ToString();

//                        string productidd = dtimgstr.Rows[0]["pid"].ToString();
//                        string flag = dtorderdetails.Rows[0]["BuyWith"].ToString();
//                        string custorder = dtorderdetails.Rows[0]["CustOfferCode"].ToString();

//                        string mess = "";
//                        string forcust = "";
//                        string mrp = "";
//                        mrp = dtimgstr.Rows[0]["Mrp"].ToString();
//                        string date = clsCommon.getProductExpiredOnDate(productidd);
//                        string ocode = "";
//                        if (custorder != null && custorder != "")
//                        {
//                            ocode = "/?offercode=" + custorder;
//                        }
//                        if (flag == "1")
//                        {
//                            mess = "Share this offer on WhatsApp so that your friends can also make the most if it!";
//                        }
//                        else if (flag == "2")
//                        {
//                            forcust = dtimgstr.Rows[0]["BuyWith1FriendExtraDiscount"].ToString();

//                            //string title = "Final Step";
//                            string[] daaata = forcust.Split('.');
//                            forcust = daaata[0].ToString();
//                            string[] mrpdata = mrp.Split('.');
//                            mrp = mrpdata[0].ToString();
//                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "');", true);
//                            mess = "Since you have chosen to buy with 1 friend, share offer to ensure your friend buys it by " + date + " to pay offer price of only ₹" + forcust + " instead of single-buy price of ₹" + mrp + " at time of delivery.Link sosho.in";


//                        }
//                        else if (flag == "6")
//                        {
//                            forcust = dtimgstr.Rows[0]["BuyWith5FriendExtraDiscount"].ToString();
//                            string[] daaata = forcust.Split('.');
//                            forcust = daaata[0].ToString();


//                            string[] mrpdata = mrp.Split('.');
//                            mrp = mrpdata[0].ToString();
//                            //string title = "Final Step";

//                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "');", true);
//                            mess = "Since you have chosen to buy with 4 friends, share offer to ensure your friends buy it by  " + date + " to pay offer price of only ₹" + forcust + " instead of single-buy price of ₹" + mrp + " at time of delivery.";
//                        }



//                        lblmsgtest.InnerHtml = "<span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"web\" href=\"https://web.whatsapp.com/send?text=Hi! I just bought this awesome product at just ₹" + forcust + ". If you buy it before " + date + ", you can also get the same discount. Just follow this link: http://www.sosho.in" + ocode + " \"share/whatsapp/share\" target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span> <span class=\"whatsapp\"><a class=\"fa fa-whatsapp\" id=\"mo-wa\" href=\"whatsapp://send?text=Hi! I just bought this awesome product at just ₹" + forcust + ". If you buy it before " + date + ", you can also get the same discount. Just follow this link: http://www.sosho.in" + ocode + " target=\"_blank\" style=\"cursor:pointer;font-size: 22px;background: #25D366;color: #fff;padding: 6px;border-radius: 4px;\"></a></span>";


//                    }




//                    if (dtimgstr.Rows.Count > 0)
//                    {
//                        lblnamee.InnerHtml = dtimgstr.Rows[0]["Name"].ToString();
//                        lblweigh.InnerHtml = dtimgstr.Rows[0]["unitweg"].ToString() + " " + dtimgstr.Rows[0]["Unit"];



//                        string productidd = dtimgstr.Rows[0]["pid"].ToString();
//                        string imagename = "select ImageFileName from ProductImages where Productid=" + productidd + "";
//                        DataTable dtimage = dbc.GetDataTable(imagename);
//                        string query = "SELECT [KeyValue] FROM [StringResources] where KeyName='ProductImageUrl'";
//                        DataTable dtfolder = dbc.GetDataTable(query);
//                        string folder = "";
//                        if (dtfolder.Rows.Count > 0)
//                        {
//                            folder = dtfolder.Rows[0]["KeyValue"].ToString();
//                        }
//                        string imgname = folder + dtimage.Rows[0]["ImageFileName"].ToString();

//                        lblimg123.InnerHtml = "<img src=" + imgname + ">";

//                    }


//                }
//            }

//        }
//        catch (Exception ee)
//        {
//        }
//    }



//}