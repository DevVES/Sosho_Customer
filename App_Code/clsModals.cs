﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsModals
/// </summary>
public class clsModals
{
	public clsModals()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
    public class clsSendOtpResponce
    {
      public  string response { get; set; }
      public string message { get; set; }   
    }
    public class clsOtpVarificationResponce
    {
        public string response { get; set; }
        public string message { get; set; }
        public string userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
    }

    //ProductModel

    public class getproduct
    {

        public string response;
        public string message;
        public List<ProductDataList> ProductList { get; set; }
       
    }
    public class ProductDataList
    {
        public string productid;
        public string pname;
        public string pdec;
        public string pkey;
        public string pnote;
        public string pprice;
        public string pwight;
        public string pvideo;
        public string poffer;
        public string pbuy2;
        public string pbuy5;
        public string shipping;
        public string psold;
        public string pJustBougth;
        public string enddate;
        public string penddate;
        public string IsQtyFreeze;

        public List<ProductDataImagelist> ProductImageList { get; set; }
    }
    public class ProductDataImagelist
    {
        public string prodid;
        public string proimagid;
        public string PImgname;
        public string PDisOrder;
    }

    //Banner Image    
        public class BnnerImage
        {

            public string response;
            public string message;
            public List<BannerDataList> BannerImageList { get; set; }

        }
        public class BannerDataList
        {
            public string ImgUrl;
            public string Title;
            public string AltText;
            public string DataLink;
        }
    public class NewBnnerImage
    {
        public string response;
        public string message;
        public string BannerPosition;
        public List<IntermediateBannerImage> IntermediateBannerImages { get; set; }
        public List<IntermediateBannerImage> BannerImageList { get; set; }
    }
    //public class IntermediateBannerImage
    //{
    //    public string Title;
    //    public string bannerURL;
    //    public string bannerId;
    //    public int ActionId;
    //    public string action;
    //    public string categoryId;
    //    public string categoryName;
    //    public int ProductId;
    //    public string ProductName;
    //    public string openUrlLink;
    //    public string MaxQty;
    //    public string MinQty;
    //    public bool IsQtyFreeze;
    //    public string MRP;
    //    public string Discount;
    //    public string SellingPrice;
    //    public string Weight;
    //}
    public class IntermediateBannerImage
    {
        public string Title;
        public string bannerURL;
        public string bannerId;
        public int ActionId;
        public string action;
        public string categoryId;
        public string categoryName;
        public int ProductId;
        //public string AttributeId;
        public string ProductName;
        public string openUrlLink;
        //public string  MaxQty;
        //public string MinQty;
        //public bool IsQtyFreeze;
        //public string MRP;
        //public string Discount;
        //public string SellingPrice;
        //public string Weight;
        public List<ProductAttributes> ProductAttributesList { get; set; }
    }

    public class ProductAttributes
    {
        public string Mrp;
        public string Discount;
        public string PackingType;
        public string soshoPrice;
        public string weight;
        public string isOutOfStock;
        public string isSelected;
        public string isQtyFreeze;
        public string isBestBuy;
        public string MinQty;
        public string MaxQty;
        public string AttributeId;
        public string AImageName;
    }

    //Add Address Sucessfully Message

    public class CustAddress
        {
            public string Response;
            public string Message;
            public string LastId;

        }

    //customer order details

    public class custorderdetails
    {
        public string Response;
        public string Message;
        public string Orderid;
        public string Buywith;
        public string OrderDate;
        public string OrderTime;
        public string Custoffercode;
        public string ReferCode;
        public string ProductEnddate;
        public string ProductStartDate;
        public string ProductId;
        public string OrderItemId;
    }

    public class getCategory
    {
        public List<CategoryDataList> CategoryList { get; set; }
        public string response;
        public string message;
    }

    public class CategoryDataList
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
        public List<SubCategoryDataList> SubCategoryList { get; set; }
    }
    public class SubCategoryDataList
    {
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
    }
    //20-08-2020 Developed By :- Hiren
    //public class getNewproduct
    //{

    //    public string response;
    //    public string message;
    //    public string WhatsAppNo;
    //    public List<NewProductDataList> ProductList { get; set; }
    //}
    public class getNewproduct
    {
        public string response;
        public string message;
        public string WhatsAppNo;
        public string BannerPosition;
        //public List<HomePageBannerImage> HomePageBannerImages { get; set; }
        public List<NewProductDataList> ProductList { get; set; }

    }
    //public class NewProductDataList
    //{
    //    public NewProductDataList()
    //    {
    //        ProductImageList = new List<ProductDataImagelist>();
    //        ProductAttributesList = new List<ProductAttributelist>();
    //    }
    //    public List<ProductDataImagelist> ProductImageList { get; set; }
    //    public List<ProductAttributelist> ProductAttributesList { get; set; }

    //    public string CategoryId;
    //    public string CategoryName;
    //    public string MRP;
    //    public string Discount;
    //    public string Name;
    //    public string OfferEndDate;
    //    public string SellingPrice;
    //    public string SoldCount;
    //    public string SpecialMessage;
    //    public string Weight;
    //    public string DisplayOrder;
    //    //public string IsProductDetails;
    //    public string IsProductVariant;
    //    public string IsQtyFreeze;
    //    public string SoshoRecommended;
    //    public string IsSoshoRecommended;
    //    public string IsSpecialMessage;
    //    public string MaxQty;
    //    public string MinQty;
    //    public string IsProductDescription;
    //    public string ProductDescription;
    //    public string ProductNotes;
    //    public string ProductKeyFeatures;
    //    public string ProductId;
    //}
    public class NewProductDataList
    {
        public NewProductDataList()
        {
            //ProductImageList = new List<ProductDataImagelist>();
            ProductAttributesList = new List<ProductAttributelist>();
        }
        //public List<ProductDataImagelist> ProductImageList { get; set; }
        public List<ProductAttributelist> ProductAttributesList { get; set; }

        public string CategoryId;
        public string CategoryName;
        public string ProductId;
        public string ProductName;
        public string OfferEndDate;
        public string SoldCount;
        public int DisplayOrder;
        public string SoshoRecommended;
        public bool IsSoshoRecommended;
        public string SpecialMessage;
        public bool IsSpecialMessage;
        public bool IsProductDescription;
        public string ProductDescription;
        public string ProductNotes;
        public string ProductKeyFeatures;
        public string ItemType;

        //public string SubCategoryId;
        //public string SubCategoryName;
        //public string MRP;
        //public string Discount;
        //public string Name;
        //public string SellingPrice;
        //public string Weight;
        //public string IsProductVariant;
        //public string IsQtyFreeze;
        //public string MaxQty;
        //public string MinQty;
        public bool isFreeShipping;
        public bool isFixedShipping;
        public double FixedShipRate;

        public string Title;
        public string bannerURL;
        public string bannerId;
        public int ActionId;
        public string action;
        public string openUrlLink;
        public string ActionCategoryId;
        public string ActionCategoryName;

    }
    public class ProductAttributelist
    {
        public string Mrp;
        public string Discount;
        public string PackingType;
        public string soshoPrice;
        public string weight;
        public string isOutOfStock;
        public string isSelected;
        public string isQtyFreeze;
        public string isBestBuy;
        public string MinQty;
        public string MaxQty;
        public string AttributeId;
        public string AImageName;
    }
    //12-10-2020 Developed By :- Hiren
    public class getSearchproduct
    {
        public string response;
        public string[] message;
    }

    public class finallistformulti
    {

        public string CustomerDetail;
        public string paymentmode;
        public string deliverymsg;
        public string whatsappmsg;
        public string facebookMsg;
        public string Response;
        public string Message;
        public string OrderTotal;
        public string PromoCode;
        public string CashbackAmount;
        public string ReedeemAmount;
        public string DiscountAmount;
        public List<finallistprod> finallistprods { get; set; }

    }

    public class finallistprod
    {
        public int BannerProductType;
        public string ProductName;
        public string Qty;
        //public string msg;
    }

    public class AddFranchies
    {
        public string Name;
        public string Email;
        public string Mobile;
        public string PinCode;
        public string Address;
        public string CreatedBy;
    }

    public class AddFranchiesResponse
    {
        public string response;
        public string message;
        public String FranchieId = "";
    }

    public class getPreviousProduct
    {
        public string response;
        public string message;
        public string WhatsAppNo;
        public List<ReOrderProductList> ProductList { get; set; }

    }

    public class ReOrderProductList
    {
        public ReOrderProductList()
        {
        }

        public string CategoryId;
        public string CategoryName;
        public string ProductId;
        public string ProductName;
        public string OfferEndDate;
        public string SoldCount;
        public int DisplayOrder;
        public string SoshoRecommended;
        public bool IsSoshoRecommended;
        public string SpecialMessage;
        public bool IsSpecialMessage;
        public bool IsProductDescription;
        public string ProductDescription;
        public string ProductNotes;
        public string ProductKeyFeatures;
        public string ItemType;
        public string SubCategoryId;
        public string SubCategoryName;
        public double MRP;
        public string Discount;
        //public string Name;
        public double SoshoPrice;
        public string Weight;
        //public string IsProductVariant;
        //public string IsQtyFreeze;
        public int MaxQty;
        public int MinQty;
        public bool isFreeShipping;
        public bool isFixedShipping;
        public bool isOutOfStock;
        public bool isSelected;
        public bool isQtyFreeze;
        public bool isBestBuy;
        public string AttributeId;
        public double FixedShipRate;
        public string Title;
        public string bannerURL;
        public string bannerId;
        public int ActionId;
        public string action;
        public string openUrlLink;
        public string ActionCategoryId;
        public string ActionCategoryName;
        public string PackingType;
        public string AImageName;
        public int OrderedQuantity;
        public string NumberOfTimesOrdered;
    }

    public class CheckJurisdictionModel
    {
        public string Response { get; set; }
        public string Message { get; set; }
    }

}