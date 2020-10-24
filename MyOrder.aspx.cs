using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyOrder : System.Web.UI.Page
{
    dbConnection dbc = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //string CustomerId = clsCommon.getCurrentCustomer().id;
                //if (!string.IsNullOrWhiteSpace(CustomerId))
                //{
                //    string query = "SELECT [KeyValue] FROM [StringResources] where KeyName='ProductImageUrl'";
                //    DataTable dtfolder = dbc.GetDataTable(query);
                //    string folder = "";
                //    if (dtfolder.Rows.Count > 0)
                //    {
                //        folder = dtfolder.Rows[0]["KeyValue"].ToString();
                //    }
                //    Session["OrderId"] = "";
                //    string Querydata = "select [Order].id as OrderId,[Order].OrderTotal,FORMAT(CreatedOnUtc, 'dd MMM yyy htt') AS OrderDate from [Order]   where [Order].CustomerId=" + CustomerId + " order by [Order].id desc";

                //    DataTable dtproduct = dbc.GetDataTable(Querydata);

                //    string ProductNameinmsg = "";
                //    bool ismrp = false;
                //    string Orderdetails = "";

                //    if (dtproduct != null && dtproduct.Rows.Count > 0)
                //    {
                //        string dtdata = dbc.getindiantime().ToString("dd/MMM/yyyy HH:mm:ss tt");


                //        string mrp = "";
                //        string forcust = "";
                //        string date = "";
                //        string custid = clsCommon.getCurrentCustomer().id;
                //        clsModals.custorderdetails datacust = clsCommon.custdetails(custid);
                //        for (int i = 0; dtproduct.Rows.Count > i; i++)
                //        {


                //            //string productidd = dtproduct.Rows[i]["productid"].ToString();
                //            string orderidd = dtproduct.Rows[i]["OrderId"].ToString();
                //            string orderid64 = clsCommon.Base64Encode(dtproduct.Rows[i]["OrderId"].ToString());
                //            Orderdetails += "<div class=\"row\"> <div class=\"order-list\"> <ul> <li> <div class=\"inner\"> <div class=\"orderid left\"> <p><strong>" + dtproduct.Rows[i]["OrderId"].ToString() + "</strong></p> </div> <div class=\"left olist-date\"> <p>" + dtproduct.Rows[i]["OrderDate"].ToString() + "</p> </div> <div class=\"amount right\"> <p>Order Total:<span>" + dtproduct.Rows[i]["OrderTotal"] + "</span></p> </div> </div> </li> </ul>";
                //            string qry = "select Product.Id as ProductId,Product.ProductMrp,Product.Name,Product.[DisplayNameInMsg],Product.[ShowMrpInMsg] , Product.Mrp, Product.BuyWith1FriendExtraDiscount, Product.BuyWith5FriendExtraDiscount, (CONVERT(varchar ,Product.EndDate,106)) +' ' + (CONVERT(varchar ,Product.EndDate,108)) as pedate, [Order].Id as orderid, OrderItem.Id as orderitemid,ISNULL(OrderItem.CustOfferCode,[Order].CustOfferCode) as cccode,ISNULL(OrderItem.RefferedOfferCode,[Order].RefferedOfferCode) as Refercode,(select top 1 Product.EndDate from Product where Product.Id=OrderItem.ProductId order by Product.Id desc) as enddatetime  from Product Inner join OrderItem on OrderItem.ProductId=Product.Id Inner Join [Order] On [Order].Id = OrderItem.OrderId where [Order].Id=" + orderidd;
                //            DataTable dt = dbc.GetDataTable(qry);
                //            if (dt != null && dt.Rows.Count > 0)
                //            {

                //                DataTable dtlive = new DataTable();
                //                try
                //                {
                //                    dtlive = dt.Select("enddatetime<='" + dbc.getindiantime().ToString("dd/MMM/yyyy HH:mm:ss tt") + "'").CopyToDataTable();
                //                }
                //                catch (Exception ex)
                //                {


                //                }
                //                int flag1 = 0;

                //                if (dtlive != null && dtlive.Rows.Count > 0)
                //                {
                //                    DataRow[] drr = dtlive.Select("OrderId=" + orderidd);

                //                    if (drr.Length > 0)
                //                    {
                //                        flag1 = 1;
                //                    }
                //                }


                //                for (int j = 0; j < dt.Rows.Count; j++)
                //                {


                //                    string productidd = dt.Rows[j]["productid"].ToString();
                //                    string imagename = "select ImageFileName from ProductImages where Productid=" + productidd + "";
                //                    DataTable dtimage = dbc.GetDataTable(imagename);
                //                    string imgname = "";
                //                    if (dtimage != null && dtimage.Rows.Count > 0)
                //                    {
                //                        imgname = folder + dtimage.Rows[0]["ImageFileName"].ToString();
                //                    }







                //                    string flg = datacust.Buywith;
                //                    ProductNameinmsg = dt.Rows[j]["DisplayNameInMsg"].ToString();

                //                    if (ProductNameinmsg.Length == 0 || ProductNameinmsg == null || ProductNameinmsg == "")
                //                    {
                //                        ProductNameinmsg = dt.Rows[j]["Name"].ToString();
                //                    }
                //                    ismrp = bool.Parse(dt.Rows[j]["ShowMrpInMsg"].ToString());
                //                    mrp = dt.Rows[j]["Mrp"].ToString();

                //                    if (flg == "1")
                //                    {
                //                        forcust = dt.Rows[j]["Mrp"].ToString();
                //                    }
                //                    else if (flg == "2")
                //                    {
                //                        forcust = dt.Rows[j]["BuyWith1FriendExtraDiscount"].ToString();
                //                    }
                //                    else if (flg == "5")
                //                    {
                //                        forcust = dt.Rows[j]["BuyWith5FriendExtraDiscount"].ToString();
                //                    }
                //                    date = dt.Rows[j]["pedate"].ToString();





                //                    string productid1 = dt.Rows[j]["productid"].ToString();

                //                    string getdate = clsCommon.getProductExpiredOnDate(productid1);

                //                    bool produstatus = clsCommon.ProductStatus(productid1);
                //                    if (dt.Rows[j]["orderid"].ToString() == orderidd)
                //                    {


                //                        if (produstatus == false)
                //                        {

                //                            Orderdetails += "<table class=\"table table-bordered\"> <tbody> <tr> <td> <div class=\"left olist-img\"> <a href=\"\"> <img src=\"" + imgname + "\" /></a> </div> <div class=\"left olist-name\"> <p>" + dt.Rows[j]["Name"] + "</p><p class=\"olist-expired\">Expiring on " + getdate + "</p>  </div> <div class=\"right\"> <div class=\"details\"> <a href=\"order_details.aspx?Orderid=" + orderid64 + "\"> <p>View Details</p></a>";
                //                        }
                //                        else
                //                        {
                //                            Orderdetails += "<table class=\"table table-bordered\"> <tbody> <tr> <td> <div class=\"left olist-img\"> <a href=\"\"> <img src=\"" + imgname + "\" /></a> </div> <div class=\"left olist-name\"> <p>" + dt.Rows[j]["Name"] + "</p><p class=\"olist-expired\">Expired on " + getdate + "</p>  </div> <div class=\"right\"> <div class=\"details\"> <a href=\"order_details.aspx?Orderid=" + orderid64 + "\"> <p>View Details</p></a>";
                //                        }

                //                        string Couponcode = dt.Rows[j]["cccode"].ToString();
                //                        string link = "";
                //                        if (Couponcode == "0")
                //                        {

                //                        }
                //                        else
                //                        {
                //                            link = "?offercode=" + Couponcode + "";
                //                        }

                //                        string mrpd = "";

                //                        if (ismrp == true)
                //                        {
                //                            mrpd = "(MRP ₹ " + dt.Rows[j]["ProductMrp"].ToString() + ")";
                //                        }
                //                        if (flag1 < 1)
                //                        {
                //                            //Orderdetails+="<p class=\"share\">Share on</p> <div> <a href=\"\"><img src=\"images/facebook.png\"></a> <a href=\"\"><img src=\"images/instagram.png\"></a> <a href=\"\"><img src=\"images/whatsapp.png\"></a> </div>";
                //                            string productdetails = string.Empty;
                //                            string enddate = string.Empty;

                //                            string proddetails = "Select TOP 1 FORMAT(EndDate, 'dd MMM yyy htt') AS ProductEndDate, Product.Name + ' at only Rs ' + CONVERT(nvarchar, Product.Mrp) + ' (MRP ' + CONVERT(nvarchar, Product.ProductMrp) + ') for ' + isnull(Unit, '0') + ' ' + isnull((select UnitName from UnitMaster where UnitMaster.Id = Product.UnitId),'Gram') as productdetails from Product inner join OrderItem ON OrderItem.ProductId = Product.Id Where OrderItem.OrderId =" + orderidd + " Order By EndDate Desc";

                //                            DataTable dtproductdetail = dbc.GetDataTable(proddetails);
                //                            if (dtproductdetail.Rows.Count > 0)
                //                            {
                //                                productdetails = dtproductdetail.Rows[0]["productdetails"].ToString();
                //                                enddate = dtproductdetail.Rows[0]["ProductEndDate"].ToString();
                //                            }
                //                            string WhatsappMsg = "Hi! I bought " + productdetails + " and other items at great rates. Free shipping with Covid precautions and Cash on delivery. If you buy it before " + enddate + ", you can also get the same discount. Just follow this link: http://www.sosho.in" + link;


                //                            Orderdetails += "<p class=\"share\">Share on</p> <div class=\"social-links-myorder\"> <a target=\"_blank\" href=\"https://web.whatsapp.com/send?text=" + WhatsappMsg + " \"share/whatsapp/share\" data-action=\"share/whatsapp/share\"><img style=\"margin: 0 6px 0 0;border-radius: 4px;\" id=\"web\" src=\"images/whatsapp.png\" /></a> <a target=\"_blank\" href=\"whatsapp://send?text=" + WhatsappMsg + "\"><img id=\"mo-wa\" src=\"images/whatsapp.png\" /></a> <span id=\"fb-share-button\" style=\"padding-right:6px;\"></span></div>";
                //                        }

                //                        //<i class=\"fa fa-facebook\" style=\"cursor:pointer;font-size:18px;background: #3b5998;padding: 3px;margin-right: 0px;margin-top:2px;color: #fff;border-radius: 4px;\"></i>

                //                        Orderdetails += "</div> </div> </td>  </tr>  </tbody> </table>";
                //                    }
                //                }

                //            }
                //            Orderdetails += "</div> </div>";
                //        }
                //    }
                //    orderlistDetails.InnerHtml = Orderdetails;

                //}
                //else
                //{

                //}
                OrderListBind();
            }
        }
        catch (Exception ee)
        {


        }
    }

    public void OrderListBind()
    {
        string CustomerId = clsCommon.getCurrentCustomer().id;
        if (!string.IsNullOrWhiteSpace(CustomerId))
        {
            string apiString = clsCommon.strApiUrl + "api/Order/CustMultipleOrderList?custid=" + CustomerId;
            string data = clsCommon.GET(apiString);

            if (!String.IsNullOrEmpty(data))
            {
                ClsOrderModels.orderlist objorder = JsonConvert.DeserializeObject<ClsOrderModels.orderlist>(data);
                string Orderdetails = string.Empty;

                string Querydata = "select [Order].id as OrderId,[Order].OrderTotal,ISNULL([Order].PaidAmount,0) as PaidAmount ,FORMAT(CreatedOnUtc, 'dd MMM yyy htt') AS OrderDate from [Order]   where [Order].CustomerId=" + CustomerId + " order by [Order].id desc";

                DataTable dtproduct = dbc.GetDataTable(Querydata);

                if (dtproduct != null && dtproduct.Rows.Count > 0)
                {
                    for (int i = 0; dtproduct.Rows.Count > i; i++)
                    {
                        string orderidd = dtproduct.Rows[i]["OrderId"].ToString();
                        string orderid64 = clsCommon.Base64Encode(dtproduct.Rows[i]["OrderId"].ToString());
                        Orderdetails += "<div class=\"row\"> <div class=\"order-list\"> <ul> <li> <div class=\"inner\"> <div class=\"orderid left\"> <p><strong>" + dtproduct.Rows[i]["OrderId"].ToString() + "</strong></p> </div> <div class=\"left olist-date\"> <p>" + dtproduct.Rows[i]["OrderDate"].ToString() + "</p> </div> <div class=\"amount right\"> <p>Order Total:<span>" + dtproduct.Rows[i]["PaidAmount"] + "</span></p> </div> <div class=\"amount right\"> <a href=\"OrderSummery.aspx?orderid="+ dtproduct.Rows[i]["OrderId"].ToString() + "\"> Reorder</a> </div> </div> </li> </ul>";

                        if (objorder.ListOrder != null && objorder.ListOrder.Count > 0)
                        {

                            var list = new List<ClsOrderModels.ListOrder>();
                            try
                            {
                                list = objorder.ListOrder.Where(x => Convert.ToDateTime(x.expdate) <= Convert.ToDateTime(dbc.getindiantime())).ToList();
                            }
                            catch (Exception ex)
                            {


                            }
                            int flag1 = 0;

                            if (list != null && list.Count > 0)
                            {
                                var order = new ClsOrderModels.ListOrder();
                                order = list.Where(x => x.orderid == orderidd).FirstOrDefault();

                                if (order != null)
                                {
                                    flag1 = 1;
                                }
                            }

                            foreach (var item in objorder.ListOrder)
                            {
                                string productidd = item.productid;
                                string getdate = clsCommon.getProductExpiredOnDate(productidd);

                                bool produstatus = clsCommon.ProductStatus(productidd);
                                if (item.orderid == orderidd)
                                {


                                    if (produstatus == false)
                                    {

                                        Orderdetails += "<table class=\"table table-bordered\"> <tbody> <tr> <td> <div class=\"left olist-img\"> <a href=\"\"> <img src=\"" + item.productimg + "\" /></a> </div> <div class=\"left olist-name\"> <p>" + item.productname + "</p><p class=\"olist-expired\">Expiring on " + getdate + "</p>  </div> <div class=\"right\"> <div class=\"details\"> <a href=\"order_details.aspx?Orderid=" + orderid64 + "\"> <p>View Details</p></a>";
                                    }
                                    else
                                    {
                                        Orderdetails += "<table class=\"table table-bordered\"> <tbody> <tr> <td> <div class=\"left olist-img\"> <a href=\"\"> <img src=\"" + item.productimg + "\" /></a> </div> <div class=\"left olist-name\"> <p>" + item.productname + "</p><p class=\"olist-expired\">Expired on " + getdate + "</p>  </div> <div class=\"right\"> <div class=\"details\"> <a href=\"order_details.aspx?Orderid=" + orderid64 + "\"> <p>View Details</p></a>";
                                    }

                                    if (flag1 < 1)
                                    {

                                        Orderdetails += "<p class=\"share\">Share on</p> <div class=\"social-links-myorder\"> <a target=\"_blank\" href=\"https://web.whatsapp.com/send?text=" + item.whatsappMessage + " \"share/whatsapp/share\" data-action=\"share/whatsapp/share\"><img style=\"margin: 0 6px 0 0;border-radius: 4px;\" id=\"web\" src=\"images/whatsapp.png\" /></a> <a target=\"_blank\" href=\"whatsapp://send?text=" + item.whatsappMessage + "\"><img id=\"mo-wa\" src=\"images/whatsapp.png\" /></a> <span id=\"fb-share-button\" style=\"padding-right:6px;\"></span></div>";
                                    }
                                    Orderdetails += "</div> </div> </td>  </tr>  </tbody> </table>";

                                }
                            }

                        }
                        Orderdetails += "</div> </div>";
                    }
                }
                orderlistDetails.InnerHtml = Orderdetails;
            }
        }

    }

}