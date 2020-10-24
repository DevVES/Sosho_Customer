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
        public string AreaId;
        public string BuildingId;
        public string AreaName;
        public string BuildingName;
        public string BuildingNo;
        public string Landmark;
        public string OtherDetails;


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
        public string CountryID = "";
        public string CountryName = "";
        public string StateID = "";
        public string StateName = "";
        public string CityId = "";
        public string CityName = "";
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
    public class PlaceMultipleOrderNewModel
    {
        public string CustomerId { get; set; }
        public string AddressId { get; set; }
        public string JurisdictionID { get; set; }
        public decimal Cashbackamount { get; set; }
        public string discountamount { get; set; }
        public string Redeemeamount { get; set; }
        public string orderMRP { get; set; }
        public string totalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string totalQty { get; set; }
        public string totalWeight { get; set; }

        public string PromoCodeamount { get; set; }

        public string WalletId;
        public string WalletLinkId;
        public string WalletType;
        public string WalletCrAmount;
        public string WalletCrDate;
        public string WalletCrDescription;
        public string Walletbalance;


        public string PromoCodeId;
        public string PromoCode;
        public string PromoCodeLinkId;
        public string PromoCodetype;
        public string PromoCodeCrAmount;
        public string PromoCodeCrDate;
        public string PromoCodeCrDescription;
        public string PromoCodebalance;
        public string ReOrderId { get; set; }
        public List<ProductListNew> products { get; set; }
    }
    public class ProductListNew
    {
        public int BannerProductType { get; set; }
        public int BannerId { get; set; }
        public string productid { get; set; }
        public string couponCode { get; set; }
        public string refrcode { get; set; }
        public string Quantity { get; set; }
        public decimal PaidAmount { get; set; }
        public string UnitId { get; set; }
        public string Unit { get; set; }
        public string Productvariant { get; set; }
        public string AttributeId { get; set; }
        public decimal Mrp { get; set; }
        public bool isOfferExpired = false;
        public bool isProductAvailable = true;
        public bool isOutOfStock = false;

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
    public class ConfirmOrderNewModel
    {
        public int BannerProductType { get; set; }
        public int BannerId { get; set; }
        public string Productid { get; set; }
        public string Grpid { get; set; }
        public int Mrp { get; set; }
        public int SoshoPrice { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public string UnitId { get; set; }
        public int MrpTotal { get; set; }
        public int SoshoTotal { get; set; }
        public string Productvariant { get; set; }
        public bool isOfferExpired { get; set; }
        public bool isProductAvailable { get; set; }
        public bool isOutOfStock { get; set; }
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

    public class ZipCodeAreaList
    {
        public string Response;
        public string Message;

        public List<AreaDatalist> Arealist { get; set; }
    }
    public class AreaDatalist
    {
        //public string LocationId;
        //public string Location;
        public string AreaId;
        public string AreaName;
    }

    public class AreaBuildingList
    {
        public string Response;
        public string Message;

        public List<BuildingDatalist> Buildinglist { get; set; }
    }
    public class BuildingDatalist
    {
        public string AreaId;
        public string AreaName;
        public string BuildingId;
        public string BuildingName;
    }

    public class CustAddressDetailsList
    {
        public string Response;
        public string Message;
        public List<CustAddressDataList> CustAddressList { get; set; }

    }

    public class CustAddressDataList
    {
        public string Custid;
        public string fname;
        public string lname;
        public string tagname;
        public string countryId;
        public string countryName;
        public string stateId;
        public string statename;
        public string cityId;
        public string cityname;
        public string addr;
        public string email;
        public string pcode;
        public string mob;
        public string CustomerAddressId;
        public string AreaId;
        public string Area;
        public string BuildingId;
        public string Building;
        public string BuildingNo;
        public string LandMark;
        public string OtherDetail;


    }

    public class orderlist
    {
        public String Responce = "";
        public String Message = "";
        public List<ListOrder> ListOrder { get; set; }

    }

    public class ListOrder
    {
        public String orderid = "";
        public string orderdate = "";
        public string totalamt = "";
        public string productname = "";
        public string productimg = "";
        public string expdate = "";
        public string whatsappflag = "";
        public string whatsappMessage = "";
        public string IsCancel = "";
        public String OrderStatusText = "";
        public string OrderStatus = "";
        public string productid = "";


    }

    public class orderdetailformultiple
    {
        public string CustName;
        public string CustAddress;
        public string CustMob;
        public string OrderId;
        public string OrderDate;
        public string Amount;
        public string WhatsappMsg = "";
        //public string facebookMsg;
        public string TotalQty;
        public string PaymentMode;
        public string Response;
        public string Message;
        public string IsCancel;
        public string OrderStatus;
        public string OrderStatusText;
        public List<OrderedProductList> products { get; set; }


    }
    public class OrderedProductList
    {
        public string ProductImg;
        public string ProductName;
        //public string WhatsappbtnShowStatus;
        // public string WhatsappMsg;            
        public string ProductEnddate;
        public string Weight;
        public string MRP;
        public string Qty;
        public string SoshoPrice;
        public string ProductId;
        // public string BuyWith;
    }

    public class ReOrderProductList
    {
        public string response { get; set; }
        public string message { get; set; }
        public string AddressId { get; set; }
        public List<CustAddressDataListForReorder> CustAddressList { get; set; }
        public List<NewProductDataList> ProductList { get; set; }
        //public string OrderId { get; set; }

        //public string ProductId { get; set; }
        //public string AttributeId { get; set; }
        //public string ProductName { get; set; }
        //public string UnitId { get; set; }
        //public string UnitName { get; set; }
        //public string Unit { get; set; }
        //public bool isOutOfStock { get; set; }
        //public bool isOfferExpired { get; set; }
        //public decimal Mrp { get; set; }
        //public decimal SoshoPrice { get; set; }
        //public decimal Quantity { get; set; }
    }

    public class CustAddressDataListForReorder
    {
        public string Custid;
        public string fname;
        public string lname;
        public string tagname;
        public string countryId;
        public string countryName;
        public string stateId;
        public string statename;
        public string cityId;
        public string cityname;
        public string addr;
        public string email;
        public string pcode;
        public string mob;
        public string CustomerAddressId;
        public string AreaId;
        public string Area;
        public string BuildingId;
        public string Building;
        public string BuildingNo;
        public string LandMark;
        public string OtherDetail;


    }
    public class NewProductDataList
    {
        public NewProductDataList()
        {
            ProductAttributesList = new List<ProductAttributelist>();
        }
        public string CategoryId;
        public string CategoryName;
        public string ProductId;
        public string ProductName;
        public int Quantity;
        public string OfferEndDate;
        public string ItemType;
        public string Title;
        public string bannerURL;
        public string bannerId;
        public bool isOfferExpired { get; set; }
        public bool isProductAvailable { get; set; }
        public List<ProductAttributelist> ProductAttributesList { get; set; }
    }

    public class ProductAttributelist
    {
        public double Mrp;
        public string Discount;
        public string PackingType;
        public double soshoPrice;
        public string weight;
        public bool isOutOfStock;
        public bool isSelected;
        public bool isQtyFreeze;
        public bool isBestBuy;
        public int MinQty;
        public int MaxQty;
        public string AttributeId;
        public string AImageName;
    }


}