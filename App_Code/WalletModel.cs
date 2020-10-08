using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class WalletModel
    {
        public class getWalletDetail
        {
            public string response;
            public string message;
            public List<WalletDataList> WalletList { get; set; }

        }

        public class WalletDataList
        {
            public string wallet_id;
            public string campaign_name;
            public string wallet_amount;
            public string coupon_code;
            public string is_applicable_first_order;
            public string per_type;
            public string per_amount;
            public string min_order_amount;
            public string start_date;
            public string end_date;
        }

    public class RedeemeWallet
    {
        public string response;
        public string message;
        public string RedeemeAmount;
        public List<PromoCodeDataList> PromoCodeList { get; set; }
        //public List<CashbackDataList> CashbackList { get; set; }

    }

    public class PromoCodeDataList
    {
        public string wallet_id;
        public string campaign_name;
        public string PromoCode;
        public string per_type;
        public string per_amount;
        public string min_order_amount;
        public string balance;
        public string start_date;
        public string end_date;
        public string terms;
    }

    public class CashbackDataList
        {
            public string wallet_id;
            public string campaign_name;
            public string per_type;
            public string per_amount;
            public string min_order_amount;
            public string balance;
            public string start_date;
            public string end_date;
        }

    public class RedeemeWalletFromOrder
    {
        public string response;
        public string message;
        public string ValidationMessage;
        public string WalletId = "0";
        public string WalletLinkId = "0";
        public string WalletType = "0";
        public string CrAmount = "0";
        public string CrDate = "0";
        public string CrDescription = "0";
        public string balance = "0";
    }
    public class RedeemePromoCodeFromOrder
    {
        public string response;
        public string message;
        public string PromoCodeId;
        public string PromoCodeLinkId;
        public string PromoCodetype;
        public string PromoCodeCalcAmount;
        public string PromoCodeCrAmount;
        public string PromoCodeCrDate;
        public string PromoCodeCrDescription;
        public string PromoCodebalance;
        public string ValidationMessage;
    }

}
