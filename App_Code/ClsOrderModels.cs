using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsOrderModels
/// </summary>
public class ClsOrderModels
{
    public class OrderSummery
    {
        public string Response;
        public string Message;
        //public List<OrderProductDataList> OrderProductList { get; set; }
        public List<OrderCustDataList> OrderCustomerList { get; set; }
    }

    public class OrderProductDataList
    {
        public string Proid;
        public string PName;
        public string proImage;
        public string produnit;
        public string unit;
        public string price;
        public string weight;


    }

    public class OrderCustDataList
    {

        public string cid;
        public string Caddrid;
        public string Cfname;
        public string Clname;
        public string addr;
        public string cph;
        public string tag;
        public string Countryname;
        public string statename;
        public string Cityname;
        public string pincode;
        public string Email;


    }


    public class getproduct
    {

        public string response;
        public string message;
        public List<ProductDataList> ProductList { get; set; }


    }

    public class ProductDataList
    {
        public ProductDataList()
        {
            ProductImageList = new List<ProductDataImagelist>();
        }
        public string pname;
        public string pdec;
        public string pkey;

        public string pnote;
        public string pprice;
        public string pwight;
        public string pvideo;

        public string poffer;
        //public string pbuy2;
        //public string pbuy5;
        public string shipping;
        public string psold;
        public string pJustBougth;
        public string pgst;


        public List<ProductDataImagelist> ProductImageList { get; set; }
    }

    public class ProductDataImagelist
    {
        public string prodid;
        public string proimagid;
        public string PImgname;
        public string PDisOrder;
    }


    //redeem Amount

    public class RedeemWalletModel
    {
        public String resultflag = "";
        public String MessageUrl = "";
        public String Message = "";
        public String Amount = "";
        public String WalletAmount = "";
        public String WalletAmountText = "";
        public String TotalAmount = "";
        public String RedeemAmountText = "";
        public String RedeemAmount = "";
    }

    public class ResultResponse
    {
        public String Response = "";
        public String Message = "";
       
    }


    ///paidamount==0
    public class PlaceOrderModel
    {
        public String resultflag = "";
        public String Message = "";
        public String OrderId = "";
        public String Ccode = "";
    }


    //paidamount>0
    public class PlaceOrder
    {
        public String resultflag = "";
        public String Message = "";
        public String txnId = "";
    }

    //Check pincode to Services available or Not

    public class CheckPincodeModel
    {
        public String resultflag = "";
        public String Message = "";
        public string JurisdictionID = "";
    }

    public class ProdDescModel
    {
        public string ProductDiscription = "";
        public string keyfeatures = "";
        public string Note = "";
    }

    public class PlaceMultipleOrderModel
    {
        public string CustomerId { get; set; }
        public string AddressId { get; set; }
        public string discountamount { get; set; }
        public string Redeemeamount { get; set; }
        public string orderMRP { get; set; }
        public string totalAmount { get; set; }
        public string totalQty { get; set; }
        public string totalWeight { get; set; }
        public List<ProductList> products { get; set; }
    }

    public class ProductList
    {
        public string productid { get; set; }
        public string couponCode { get; set; } 
        public string refrcode { get; set; } 
        public string Quantity { get; set; }
        public string buywith { get; set; }
        public decimal PaidAmount { get; set; }
    }

    public class ConfirmOrderModel
    {
        public string Productid { get; set; }
        public int Mrp { get; set; }
        public string Flag { get; set; }
        public int Qty { get; set; }
        public int Weight { get; set; }
        public int MrpTotal { get; set; }
    }

    public class OrderSummeryModel
    {
        public string Productid { get; set; }
        public int Qty { get; set; }
        public int Weight { get; set; }
    }

    public class OrderQuantityModel
    {
        public int Qty { get; set; }
    }


}