//using Com.Amazon.Pwain;
//using Com.Amazon.Pwain.Types;
//using Com.Amazon.Pwain;
//using Com.Amazon.Pwain.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1;
using WebApplication1.Order;

public partial class Payment : System.Web.UI.Page
{
    dbConnection dbCon = new dbConnection();
    DataTable Get_Transactiontbl = new DataTable();
    string txnId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["txnId"] != null)
        {
            txnId = Session["txnId"].ToString();


            DataTable dttrnamount = dbCon.GetDataTable("select [PaidAmount] from [AlterNetOrder] where [TrnId]='" + txnId + "'");
            if(dttrnamount != null & dttrnamount.Rows.Count>0)
            {
                trnamount.Text = dttrnamount.Rows[0]["PaidAmount"].ToString();
            }
           
            //Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, txnId, 0, false, "1.Trn came to make payment", " ");

            try
            {

            }
            catch (Exception ex)
            {
                Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, txnId, 0, false, "11111.Trn came to make payment:ERROR", "MSG: " + ex.Message.ToString());
                // ASK TEAM IF ERROR COMES IN ABOVE CODE
            }
        }
        else
        {
            //Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, "", 0, false, "111111.Trn came to make payment", "TRNID NOT FOUND IN QRY STR");
            // ASK TEAM IF TRNID NOT FOUND IN QRY STR
        }
    }
    protected void PaytmButton_Click(object sender, EventArgs e)
    {
        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 2, false, "1.Trn came to make payment for: Paytm", "1");
        #region Paytm
        //antony commented for testing 
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        decimal orderamnt = 0;
        string email = string.Empty;
        string mobilenumber = string.Empty;
        string C_id = string.Empty;
        string ordrid = string.Empty;
        try
        {
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 2, false, "1.Trn came to make payment for: Paytm", "2");
            string qry = "select PaidAmount,AddressId from [AlterNetOrder] where TrnId='" + txnId + "'";
            DataTable dtorderdetails = dbCon.GetDataTable(qry);
            if (dtorderdetails != null & dtorderdetails.Rows.Count > 0)
            {
                Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 2, false, "1.Trn came to make payment for: Paytm", "3");
                bool o = decimal.TryParse(dtorderdetails.Rows[0]["PaidAmount"].ToString(), out orderamnt);

                string qryadd = "select CustomerId,MobileNo,Email from CustomerAddress where Id=" + dtorderdetails.Rows[0]["AddressId"].ToString() + "";
                DataTable dtadddetails = dbCon.GetDataTable(qryadd);
                if (dtadddetails != null & dtadddetails.Rows.Count > 0)
                {
                    Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 2, false, "1.Trn came to make payment for: Paytm", "4");
                    email = dtadddetails.Rows[0]["Email"].ToString();
                    mobilenumber = dtadddetails.Rows[0]["MobileNo"].ToString();
                    C_id = dtadddetails.Rows[0]["CustomerId"].ToString();
                    ordrid = txnId;
                    Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 2, false, "1.Trn came to make payment for: Paytm", "5");
                }              
            }           
            //email = "admin@yourStore.com";
            //mobilenumber = "1616161616";
            //C_id = "1";
            //ordrid = "2019091715301218131";
        }
        catch (Exception err)
        {
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 2, false, "1.Trn came to make payment for PATM:ERROR", "MSG: " + err.Message.ToString());

        }

        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, ordrid, 2, false, "1.Trn came to make payment for PAYTM", " ");
        if (orderamnt > 0 && !String.IsNullOrEmpty(ordrid) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(C_id))
        {
            //orderamnt = 1; //REMOVE
            try
            {
                String Str1 = "UPDATE [dbo].[CitrusPayment] SET [Payment_Method_Id] = @1 ,[Cit_TimeOfTransaction] = DATEADD(MINUTE, 330, GETUTCDATE()) ,[HasGone] = @2,[IsRecordsFetchedFromCitrus]= @3, [GoneTime] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TxnId] = '" + ordrid + "'";

                string[] parm = { "2", "1", "0" };

                int resval = dbCon.ExecuteQueryWithParams(Str1, parm);
                if (resval > 0)
                {
                    String Str2 = "UPDATE [dbo].[AlterNetOrder] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TrnId] = '" + ordrid + "'";

                    string[] parm2 = { "2" };

                    int resval2 = dbCon.ExecuteQueryWithParams(Str2, parm2);
                    if (resval2 > 0)
                    {
                        String Str3 = "UPDATE [dbo].[Order] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TRNID] = '" + ordrid + "'";

                        string[] parm3 = { "2" };

                        int resval3 = dbCon.ExecuteQueryWithParams(Str3, parm3);
                    }
                }
            }
            catch (Exception err)
            {
            }
            #region paytm
            string PayAmt = String.Format("{0:0.00}", orderamnt);

            parameters.Add("MID", Constant.Message.PAYTM_MID);
            parameters.Add("CHANNEL_ID", Constant.Message.PAYTM_channel_id);
            parameters.Add("INDUSTRY_TYPE_ID", Constant.Message.PAYTM_Industry_Type);
            parameters.Add("WEBSITE", Constant.Message.PAYTM_website);
            parameters.Add("EMAIL", email);
            parameters.Add("MOBILE_NO", mobilenumber);
            parameters.Add("CUST_ID", C_id);
            parameters.Add("ORDER_ID", ordrid);
            parameters.Add("TXN_AMOUNT", PayAmt);
            parameters.Add("CALLBACK_URL", Constant.Message.PG_ReturnURL_Paym); //This parameter is not mandatory. Use this to pass the callback url dynamically.

            //if (_customerService.IsCustomerEligibleto_Paytm_Promo(_workContext.CurrentCustomer.Id))
            //{
            //    parameters.Add("PROMO_CAMP_ID", "PAYTMSB");
            //}
            string getCheckSum = dbCon.genCheckSum(parameters, Constant.Message.PAYTM_merchantKey);
            parameters.Add("CHECKSUMHASH", getCheckSum);
            String paytm_trnid = string.Empty;
            paytm_trnid = ordrid;

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>SaleBhai Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + Constant.Message.PAYTM_URL + ordrid + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + getCheckSum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
            #endregion
        }
        else
        {
            //SOME VALUE IS MISSING
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, "", 2, false, "1.Trn came to make payment for: PAYTM", "Email = " + email + ",Custid = " + C_id.ToString() + ",mobile = " + mobilenumber + ",trnid" + ordrid);
        }
        #endregion
    }  
    protected void MobikwikButton_Click(object sender, ImageClickEventArgs e)
    {
        decimal orderamnt = 0;
        string email = string.Empty;
        string mobilenumber = string.Empty;
        string C_id = string.Empty;
        string ordrid = string.Empty;
       // decimal.TryParse(Get_Transactiontbl.Rows[0]["OrderAmount"].ToString(), out orderamnt);
        try
        {
            //email = Get_Transactiontbl.Rows[0]["Email"].ToString();
            //mobilenumber = Get_Transactiontbl.Rows[0]["Mobile_Number"].ToString();
            //C_id = Get_Transactiontbl.Rows[0]["CustomerId"].ToString();
            //ordrid = Get_Transactiontbl.Rows[0]["TxnId"].ToString();

            string qry = "select PaidAmount,AddressId from [AlterNetOrder] where TrnId='" + txnId + "'";
            DataTable dtorderdetails = dbCon.GetDataTable(qry);
            if (dtorderdetails != null & dtorderdetails.Rows.Count > 0)
            {
                bool o = decimal.TryParse(dtorderdetails.Rows[0]["PaidAmount"].ToString(), out orderamnt);

                string qryadd = "select CustomerId,MobileNo,Email from CustomerAddress where Id=" + dtorderdetails.Rows[0]["AddressId"].ToString() + "";
                DataTable dtadddetails = dbCon.GetDataTable(qryadd);
                if (dtadddetails != null & dtadddetails.Rows.Count > 0)
                {
                    email = dtadddetails.Rows[0]["Email"].ToString();
                    mobilenumber = dtadddetails.Rows[0]["MobileNo"].ToString();
                    C_id = dtadddetails.Rows[0]["CustomerId"].ToString();
                    ordrid = txnId;
                }
            }   
        }
        catch (Exception err)
        {
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 3, false, "1.Trn came to make payment for MOBI:ERROR", "MSG: " + err.Message.ToString());

        }
        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, ordrid, 3, false, "1.Trn came to make payment for MOBI", " ");

        if (orderamnt > 0 && !String.IsNullOrEmpty(ordrid) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(C_id))
        {
            try
            {
                String Str1 = "UPDATE [dbo].[CitrusPayment] SET [Payment_Method_Id] = @1 ,[Cit_TimeOfTransaction] = DATEADD(MINUTE, 330, GETUTCDATE()) ,[HasGone] = @2,[IsRecordsFetchedFromCitrus]= @3 ,[GoneTime] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TxnId] = '" + ordrid + "'";

                string[] parm = { "3", "1", "0"};

                int resval = dbCon.ExecuteQueryWithParams(Str1, parm);
                if(resval>0)
                {
                    String Str2 = "UPDATE [dbo].[AlterNetOrder] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TrnId] = '" + ordrid + "'";

                    string[] parm2 = { "3"};

                    int resval2 = dbCon.ExecuteQueryWithParams(Str2, parm2);
                    if (resval2 > 0)
                    {
                        String Str3 = "UPDATE [dbo].[Order] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TRNID] = '" + ordrid + "'";

                        string[] parm3 = { "3" };

                        int resval3 = dbCon.ExecuteQueryWithParams(Str3, parm3);
                    }
                }
            }
            catch (Exception err)
            {

            }

            #region Mobikwik
            //orderamnt = 1; //REMOVE
            string redirecturl = Constant.Message.PG_ReturnURL_Mobikwik;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            String secretKey = "oCGlWYFyeSzuEabKfamimyGVHP9E";
            String Mer_Name = "SaleBhai";
            String Mer_Id = "MBK7769";
            string PayAmt = String.Format("{0:0.00}", orderamnt);
            String checksumString = null;
            parameters.Add("email", email); // new field
            parameters.Add("amount", PayAmt);// new field
            parameters.Add("cell", mobilenumber); // new field
            parameters.Add("orderid", ordrid);// new field
            parameters.Add("merchantname", Mer_Name);
            parameters.Add("mid", Mer_Id);
            parameters.Add("redirecturl", redirecturl);
            parameters.Add("live", "live");

            checksumString = "'" + mobilenumber + "''" + email + "''" + PayAmt + "''" + ordrid + "''" + redirecturl + "''" + Mer_Id + "'".Trim();
            String checksum = dbCon.calculateChecksum(secretKey, checksumString);

            string MobikwikURL = "https://www.mobikwik.com/wallet";

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>SaleBhai Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";

            outputHTML += "<form method='POST' action='" + MobikwikURL + "' name='f2'>";

            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='checksum' value='" + checksum + "'>";

            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f2.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);

            ///////SalebhaiPaymentResponseMobikwik
            
            
            #endregion
        }
        else
        {

            //SOME VALUE IS MISSING
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, "", 3, false, "1.Trn came to make payment for: MOBI", "Email = " + email + ",Custid = " + C_id.ToString() + ",mobile = " + mobilenumber + ",trnid" + ordrid);
        }

    }
    protected void FreechargeButton_Click(object sender, ImageClickEventArgs e)
    {
        decimal orderamnt = 0;
        string email = string.Empty;
        string mobilenumber = string.Empty;
        string C_id = string.Empty;
        string ordrid = string.Empty;

      //  decimal.TryParse(Get_Transactiontbl.Rows[0]["OrderAmount"].ToString(), out orderamnt);
        try
        {
            //email = Get_Transactiontbl.Rows[0]["Email"].ToString();
            //mobilenumber = Get_Transactiontbl.Rows[0]["Mobile_Number"].ToString();
            //C_id = Get_Transactiontbl.Rows[0]["CustomerId"].ToString();
            //ordrid = Get_Transactiontbl.Rows[0]["TxnId"].ToString();
            string qry = "select PaidAmount,AddressId from [AlterNetOrder] where TrnId='" + txnId + "'";
            DataTable dtorderdetails = dbCon.GetDataTable(qry);
            if (dtorderdetails != null & dtorderdetails.Rows.Count > 0)
            {
                bool o = decimal.TryParse(dtorderdetails.Rows[0]["PaidAmount"].ToString(), out orderamnt);

                string qryadd = "select CustomerId,MobileNo,Email from CustomerAddress where Id=" + dtorderdetails.Rows[0]["AddressId"].ToString() + "";
                DataTable dtadddetails = dbCon.GetDataTable(qryadd);
                if (dtadddetails != null & dtadddetails.Rows.Count > 0)
                {
                    email = dtadddetails.Rows[0]["Email"].ToString();
                    mobilenumber = dtadddetails.Rows[0]["MobileNo"].ToString();
                    C_id = dtadddetails.Rows[0]["CustomerId"].ToString();
                    ordrid = txnId;
                }
            }   
        }
        catch (Exception err)
        {
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 4, false, "1.Trn came to make payment for FC:ERROR", "MSG: " + err.Message.ToString());

        }
        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, ordrid, 4, false, "1.Trn came to make payment for FC", " ");


        if (orderamnt > 0 && !String.IsNullOrEmpty(ordrid) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(C_id))
        {
            try
            {

                String Str1 = "UPDATE [dbo].[CitrusPayment] SET [Payment_Method_Id] = @1 ,[Cit_TimeOfTransaction] = DATEADD(MINUTE, 330, GETUTCDATE()) ,[HasGone] = @2,[IsRecordsFetchedFromCitrus]= @3,[GoneTime] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TxnId] = '" + ordrid + "'";

                string[] parm = { "4", "1", "0"};

                int resval = dbCon.ExecuteQueryWithParams(Str1, parm);
                if (resval > 0)
                {
                    String Str2 = "UPDATE [dbo].[AlterNetOrder] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TrnId] = '" + ordrid + "'";

                    string[] parm2 = { "4" };

                    int resval2 = dbCon.ExecuteQueryWithParams(Str2, parm2);
                    if (resval2 > 0)
                    {
                        String Str3 = "UPDATE [dbo].[Order] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TRNID] = '" + ordrid + "'";

                        string[] parm3 = { "4" };

                        int resval3 = dbCon.ExecuteQueryWithParams(Str3, parm3);
                    }
                }
            }
            catch (Exception err)
            {


            }


            #region Freecharge
            //orderamnt = 1; //REMOVE
            string surl = Constant.Message.PG_ReturnURL_Freecharge;
            string furl = Constant.Message.PG_ReturnURL_Freecharge_Fail;
            string PayAmt = String.Format("{0:0.00}", orderamnt);

            string customerName = "customer";
            string currency = "INR";
            string productInfo = "auth";
            string customNote = "pleaseplease";
            string os = "window";
            string channel = "WEB";
            string merchantId = "4GFuHKPCVTITXz";


            string pass_str = "{'amount': '" + PayAmt + "', 'channel': '" + channel + "', 'currency': '" + currency + "', 'customNote': '" + customNote + "', 'customerName': '" + customerName + "', 'email': '" + email + "', 'furl': '" + furl + "', 'merchantId': '" + merchantId + "', 'merchantTxnId': '" + ordrid + "', 'mobile': '" + mobilenumber + "', 'os': '" + os + "', 'productInfo': '" + productInfo + "', 'surl': '" + surl + "'}46527af4-8719-4e1a-bd82-cc5723742e69";

            if (String.IsNullOrEmpty(mobilenumber))
            {
                pass_str = "{'amount': '" + PayAmt + "', 'channel': '" + channel + "', 'currency': '" + currency + "', 'customNote': '" + customNote + "', 'customerName': '" + customerName + "', 'email': '" + email + "', 'furl': '" + furl + "', 'merchantId': '" + merchantId + "', 'merchantTxnId': '" + ordrid + "',  'os': '" + os + "', 'productInfo': '" + productInfo + "', 'surl': '" + surl + "'}46527af4-8719-4e1a-bd82-cc5723742e69";
            }



            pass_str = pass_str.Replace("'", "\"");
            pass_str = pass_str.Replace(" ", "");

            string chksm = dbCon.sha256_getchksm(pass_str);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("merchantTxnId", ordrid); // new field
            parameters.Add("amount", PayAmt);// new field
            parameters.Add("currency", currency); // new field
            parameters.Add("furl", furl);// new field
            parameters.Add("surl", surl);
            parameters.Add("productInfo", productInfo);
            parameters.Add("email", email);
            if (!String.IsNullOrEmpty(mobilenumber))
            {
                parameters.Add("mobile", mobilenumber);
            }
            parameters.Add("customerName", customerName);// new field
            parameters.Add("customNote", customNote);
            parameters.Add("channel", channel);
            parameters.Add("os", os);
            parameters.Add("merchantId", merchantId);
            parameters.Add("checksum", chksm);

            string FreechargeURL = "https://checkout.freecharge.in/api/v1/co/pay/init";
            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<form method='post' action='" + FreechargeURL + "' name='f1fc'>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1fc.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);           
            #endregion

        }
        else
        {
            //SOME VALUE IS MISSING
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, "", 4, false, "1.Trn came to make payment for: FC", "Email = " + email + ",Custid = " + C_id.ToString() + ",mobile = " + mobilenumber + ",trnid" + ordrid);
        }
    }

    protected void AmazonPayButton_Click(object sender, ImageClickEventArgs e)
    {
        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 5, false, "1.Trn came to make payment for: AmazonPay", "ENTRY IN AMAZON METHOD");
        decimal orderamnt = 0;
        string email = string.Empty;
        string mobilenumber = string.Empty;
        string C_id = string.Empty;
        string ordrid = string.Empty;
        int orderamnt_int = 0;

        //decimal.TryParse(Get_Transactiontbl.Rows[0]["OrderAmount"].ToString(), out orderamnt);
        //String accessKey = "AKIAJWRQFDKI4CSMB2HQ";
        //String secretKey = "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";
        //String sellerId = "ASVEYAIF8RBST";

        #region Testing_ENV
        // String accessKey = "AKIAJIJMTWVP5TOL7Y7Q";
        // String secretKey = "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";
        // String sellerId = "A1T5DRWMBFNP17";
        // String PG_ReturnURL_AmazonPay = "http://apptest.salebhai.com/SalebhaiPaymentResponseAmazonPay.aspx"; 
        //// String PG_ReturnURL_AmazonPay = "http://localhost:3152/SalebhaiPaymentResponseAmazonPay.aspx";
        // string Is_Sandbox = "true";
        // string Order_Amount = "1";



        #endregion



        #region LIVE KEY_23.05.2018

        String accessKey = "AKIAJRMNEGDNOIYL3VZA"; //_localizationService.GetLocaleStringResourceByName("AmazonPay_accessKeyLive").ResourceValue;// "AKIAJRMNEGDNOIYL3VZA";
        String secretKey = "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"; //_localizationService.GetLocaleStringResourceByName("AmazonPay_secretKeyLive").ResourceValue;//"l3r63lvIACRzpAeKhJKaXY6xCVCUeo0VSouhbRhn";
        String sellerId = "A26X47MGDVEEGE"; //_localizationService.GetLocaleStringResourceByName("AmazonPay_sellerIdLive").ResourceValue;//"A26X47MGDVEEGE"; 
        #endregion
        String PG_ReturnURL_AmazonPay = Constant.Message.PG_ReturnURL_AmazonPay;

        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 5, false, "12222.Trn came to make payment for: AmazonPay", "ENTRY IN AMAZON METHOD");

        try
        {
            //email = Get_Transactiontbl.Rows[0]["Email"].ToString();
            //mobilenumber = Get_Transactiontbl.Rows[0]["Mobile_Number"].ToString();
            //C_id = Get_Transactiontbl.Rows[0]["CustomerId"].ToString();
            //ordrid = Get_Transactiontbl.Rows[0]["TxnId"].ToString();
           
            string qry = "select PaidAmount,AddressId from [AlterNetOrder] where TrnId='" + txnId + "'";
            DataTable dtorderdetails = dbCon.GetDataTable(qry);
            if (dtorderdetails != null & dtorderdetails.Rows.Count > 0)
            {
                bool o = decimal.TryParse(dtorderdetails.Rows[0]["PaidAmount"].ToString(), out orderamnt);
                orderamnt_int = (Int32)orderamnt;

                string qryadd = "select CustomerId,MobileNo,Email from CustomerAddress where Id=" + dtorderdetails.Rows[0]["AddressId"].ToString() + "";
                DataTable dtadddetails = dbCon.GetDataTable(qryadd);
                if (dtadddetails != null & dtadddetails.Rows.Count > 0)
                {
                    email = dtadddetails.Rows[0]["Email"].ToString();
                    mobilenumber = dtadddetails.Rows[0]["MobileNo"].ToString();
                    C_id = dtadddetails.Rows[0]["CustomerId"].ToString();
                    ordrid = txnId;
                }
            }   
        }
        catch (Exception err)
        {
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 5, false, "2.Trn came to make payment for AmazonPay:ERROR", "MSG: " + err.Message.ToString());

        }




       // orderamnt = 1;

        if (orderamnt > 0 && !String.IsNullOrEmpty(ordrid) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(C_id) && orderamnt_int > 0)
        {
            try
            {

                String Str1 = "UPDATE [dbo].[CitrusPayment] SET [Payment_Method_Id] = @1 ,[Cit_TimeOfTransaction] = DATEADD(MINUTE, 330, GETUTCDATE()) ,[HasGone] = @2,[IsRecordsFetchedFromCitrus]= @3,[GoneTime] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TxnId] = '" + ordrid + "'";

                string[] parm = { "5", "1", "0" };

                int resval = dbCon.ExecuteQueryWithParams(Str1, parm);
                if (resval > 0)
                {
                    String Str2 = "UPDATE [dbo].[AlterNetOrder] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TrnId] = '" + ordrid + "'";

                    string[] parm2 = { "5" };

                    int resval2 = dbCon.ExecuteQueryWithParams(Str2, parm2);
                    if (resval2 > 0)
                    {
                        String Str3 = "UPDATE [dbo].[Order] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TRNID] = '" + ordrid + "'";

                        string[] parm3 = { "5" };

                        int resval3 = dbCon.ExecuteQueryWithParams(Str3, parm3);
                    }
                }
            }
            catch (Exception err)
            {

                Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 5, false, "2999995.Trn came to make payment for AmazonPay:ERROR", "MSG: " + err.Message.ToString());
            }

            //#region PAY
            //try
            //{
            //    String Order_Amount = orderamnt.ToString();
            //    MerchantConfiguration merchantConfiguration;
            //    PWAINBackendSDK pwaInBackendSDK;
            //    var parametersold = new Dictionary<string, string>();
            //    parametersold.Add(PWAINConstants.SELLER_ORDER_ID, ordrid);//parametersold.Add(PWAINConstants.SELLER_ORDER_ID, "MYTESTSELLERID");
            //    parametersold.Add(PWAINConstants.ORDER_TOTAL_AMOUNT, Order_Amount);
            //    parametersold.Add(PWAINConstants.ORDER_TOTAL_CURRENCY_CODE, "INR");
            //    //  parametersold.Add(PWAINConstants.ORDER_TOTAL_CURRENCY_CODE, "INR");
            //    parametersold.Add(PWAINConstants.REDIRECT_URL, PG_ReturnURL_AmazonPay);//parametersold.Add(PWAINConstants.REDIRECT_URL, "https://d70b1d97.ngrok.io/Home/Verify");
            //    // The type initializer for 'Com.Amazon.Pwain.Manager.RecordManager' threw an exception.

            //    //  parametersold.Add(PWAINConstants.IS_SANDBOX, Is_Sandbox);
            //    parametersold.Add(PWAINConstants.TRANSACTION_TIMEOUT, "10000");

            //    merchantConfiguration = new MerchantConfiguration.Builder().WithSellerIdValue(sellerId).WithAwsAccessKeyIdValue(accessKey).WithAwsSecretKeyIdValue(secretKey).build();
            //    pwaInBackendSDK = new PWAINBackendSDK(merchantConfiguration);
            //    String url = pwaInBackendSDK.GetPaymentUrl(parametersold);

            //    Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, ordrid, 5, false, "3.Trn came to make payment for: AmazonPay", "ENTRY IN AMAZON METHOD URL::" + url);

            //    Response.Redirect(url, false);

            //    #region AmazonPay RESPONSE

            //    #region Testing_ENV

            //    //String accessKey = "AKIAJIJMTWVP5TOL7Y7Q";//"AKIAJWRQFDKI4CSMB2HQ";
            //    //String secretKey = "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";//"dWupFJnpJRaOT65DampqGTFsQIdr1YD6LAOxGuyp";
            //    //String sellerId = "A1T5DRWMBFNP17";//"ASVEYAIF8RBST";


            //    #endregion


            //    #region LIVE KEY_23.05.2018

            //    //String accessKey = "AKIAJRMNEGDNOIYL3VZA"; //_localizationService.GetLocaleStringResourceByName("AmazonPay_accessKeyLive").ResourceValue;// "AKIAJRMNEGDNOIYL3VZA";
            //    //String secretKey = "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"; //_localizationService.GetLocaleStringResourceByName("AmazonPay_secretKeyLive").ResourceValue;//"l3r63lvIACRzpAeKhJKaXY6xCVCUeo0VSouhbRhn";
            //    //String sellerId = "A26X47MGDVEEGE"; //_localizationService.GetLocaleStringResourceByName("AmazonPay_sellerIdLive").ResourceValue;//"A26X47MGDVEEGE"; 
            //    #endregion

            //    string sellerOrderId = string.Empty;
            //    string orderTotalAmount = string.Empty;
            //    string orderTotalCurrencyCode = string.Empty;
            //    string reasonCode = string.Empty;
            //    string amazonOrderId = string.Empty;
            //    string signature = string.Empty;
            //    string status = string.Empty;
            //    string transactionDate = string.Empty;
            //    string description = string.Empty;
            //    //MerchantConfiguration merchantConfiguration;
            //    //PWAINBackendSDK pwaInBackendSDK;


            //    String amazonpay_trnid = string.Empty;
            //    int Result_OrderId = 0;
            //    AllPaymentResponse pay_resp = new AllPaymentResponse();
            //    var agentname = "";
            //    try
            //    {
            //        agentname = Request.UserAgent.ToLower();
            //    }
            //    catch (Exception E)
            //    {
            //        agentname = "";

            //    }


            //    #region Verify TRN

            //    try
            //    {
            //        sellerOrderId = this.Request.QueryString["sellerOrderId"];
            //        orderTotalAmount = this.Request.QueryString["orderTotalAmount"];
            //        orderTotalCurrencyCode = this.Request.QueryString["orderTotalCurrencyCode"];
            //        reasonCode = this.Request.QueryString["reasonCode"];
            //        amazonOrderId = this.Request.QueryString["amazonOrderId"];
            //        signature = this.Request.QueryString["signature"];
            //        status = this.Request.QueryString["status"];
            //        transactionDate = this.Request.QueryString["transactionDate"];
            //        description = this.Request.QueryString["description"];

            //        //sellerOrderId = "2019091810163513621";
            //        //orderTotalAmount = "1";
            //        //orderTotalCurrencyCode = "INR";
            //        //reasonCode = "001";
            //        //amazonOrderId = "111";
            //        //signature = "";
            //        //status = "SUCCESS";
            //        //transactionDate = "2019-09-18 10:00:00";
            //        //description = "";

            //        amazonpay_trnid = sellerOrderId;

            //        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, sellerOrderId, 5, false, "RESPONSE: AMAZON PAY", "FULL RESPONSE  ::" + " OrderID: " + sellerOrderId + " Order Amount: " + orderTotalAmount + " Amazon Order ID: " + amazonOrderId + " Status: " + status + " Description: " + description);

            //        //Add the response parameter values to a Dictionary
            //        var parameters = new Dictionary<string, string>();
            //        parameters.Add(PWAINConstants.SELLER_ORDER_ID, sellerOrderId);
            //        parameters.Add(PWAINConstants.ORDER_TOTAL_AMOUNT, orderTotalAmount);
            //        parameters.Add(PWAINConstants.ORDER_TOTAL_CURRENCY_CODE, orderTotalCurrencyCode);
            //        parameters.Add(PWAINConstants.REASON_CODE, reasonCode);
            //        parameters.Add(PWAINConstants.AMAZON_ORDER_ID, amazonOrderId);
            //        parameters.Add(PWAINConstants.VERIFY_SIGNATURE, signature);
            //        parameters.Add(PWAINConstants.STATUS, status);
            //        parameters.Add(PWAINConstants.TRANSACTION_DATE, transactionDate);
            //        parameters.Add(PWAINConstants.DESCRIPTION, description);

            //        String AllParamsInResponse = " OrderID: " + sellerOrderId + " Order Amount: " + orderTotalAmount + " Amazon Order ID: " + amazonOrderId + " Status: " + status + " Description: " + description + " reasonCode " + reasonCode + " signature " + signature + " transactionDate " + transactionDate + " orderTotalCurrencyCode " + orderTotalCurrencyCode;

            //        if (!String.IsNullOrEmpty(amazonpay_trnid))
            //        {

            //            int resval = pay_resp.UpdateAndSaveTransactionBeforeOrderGenerated(5, amazonpay_trnid, AllParamsInResponse.ToString(), 2);

            //            if (resval > 0)
            //            {
            //            }
            //            else
            //            {
            //                Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, amazonpay_trnid, 5, false, "5.AMAZONPAY:SalebhaiPaymentResponseAMAZONPAY: TRN NOT UPDATED " + Result_OrderId.ToString(), "Success");
            //            }

            //            if (reasonCode == "001" && status == "SUCCESS")
            //            {
            //                try
            //                {

            //                    #region Verify TRN
            //                    merchantConfiguration = new MerchantConfiguration.Builder().WithSellerIdValue(sellerId).WithAwsAccessKeyIdValue(accessKey).WithAwsSecretKeyIdValue(secretKey).build();
            //                    pwaInBackendSDK = new PWAINBackendSDK(merchantConfiguration);

            //                    try
            //                    {
            //                        pwaInBackendSDK.VerifySignature(parameters);

            //                        string abc = " OrderID: " + sellerOrderId + " Order Amount: " + orderTotalAmount + " Amazon Order ID: " + amazonOrderId + " Status: " + status + " Description: " + description;


            //                        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, sellerOrderId, 5, false, "RESPONSE_ VARIFIED SUCCESS FULLY: AMAZON PAY", "FULL RESPONSE  ::" + abc);

            //                        try
            //                        {
            //                            Result_OrderId = pay_resp.PaymentResponseAmazonPay(parameters, AllParamsInResponse.ToString(), amazonpay_trnid, orderTotalAmount, amazonOrderId);
            //                        }
            //                        catch (Exception err)
            //                        {
            //                            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, amazonpay_trnid, 5, false, "34466.AMAZONPAY:ERROR  SalebhaiPaymentResponseAMAZONPAY IN ORDER GENERATION", "Error: " + err.Message.ToString());

            //                            Result_OrderId = 0;
            //                        }


            //                        if (Result_OrderId > 0) // OrderId generated
            //                        {
            //                            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, amazonpay_trnid, 5, false, "5.AMAZONPAY:SalebhaiPaymentResponseAMAZONPAY: ORDER GENERATED Id: " + Result_OrderId.ToString(), "Success");

            //                            string sb_val = pay_resp.RedirectToApp(Result_OrderId, amazonpay_trnid, 5, agentname);
            //                            if (!String.IsNullOrEmpty(sb_val))
            //                            {

            //                                Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, amazonpay_trnid, 5, false, "555.SalebhaiPaymentResponseAMAZONPAY: ORDER GENERATED APP SCRIPT: ", "Result_OrderId val =  " + Result_OrderId.ToString() + "Success : " + sb_val.ToString());


            //                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", sb_val.ToString());
            //                            }

            //                        }
            //                        else
            //                        {
            //                            Result_OrderId = 0;
            //                            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, amazonpay_trnid, 5, false, "5.AMAZONPAY:SalebhaiPaymentResponseAMAZONPAY: ORDER NOT GENERATED Id: ", "Fail");
            //                        }

            //                    }
            //                    catch (Exception err)
            //                    {
            //                        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, amazonpay_trnid, 5, false, "34466.AMAZONPAY:ERROR  SalebhaiPaymentResponseAMAZONPAY IN ORDER GENERATION", "Error: " + err.Message.ToString());

            //                        Result_OrderId = 0;
            //                    }
            //                    #endregion



            //                }
            //                catch (Exception err)
            //                {
            //                    Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, amazonpay_trnid, 5, false, "3.AMAZONPAY:ERROR  SalebhaiPaymentResponseAMAZONPAY IN ORDER GENERATION", "Error: " + err.Message.ToString());

            //                    Result_OrderId = 0;
            //                }
            //            }
            //            else
            //            {
            //                Result_OrderId = 0;
            //                Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, amazonpay_trnid, 5, false, "5.AMAZONPAY:SalebhaiPaymentResponseAMAZONPAY: ORDER NOT GENERATED Id: ", "NOT SUCCESS REASON::" + AllParamsInResponse);
            //            }

            //        }
            //        else
            //        {
            //            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, amazonpay_trnid, 5, false, "4.AMAZONPAY:SalebhaiPaymentResponseAMAZONPAY", "NO TRANSACTION ID RESPONSE FOUND ");
            //            Result_OrderId = 0;
            //        }

            //        string sb_valn = pay_resp.RedirectToApp(Result_OrderId, amazonpay_trnid, 5, agentname);
            //        if (!String.IsNullOrEmpty(sb_valn))
            //        {

            //            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, amazonpay_trnid, 5, false, "555.SalebhaiPaymentResponseAMAZONPAY: ORDER GENERATED APP SCRIPT: ", "Result_OrderId val =  " + Result_OrderId.ToString() + "Success : " + sb_valn.ToString());


            //            ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", sb_valn.ToString());
            //        }
            //    }
            //    catch (Exception err)
            //    {
            //        Response.Write("Exception : " + e);
            //    }
            //    #endregion




            //    #endregion


            //}
            //catch (Exception err)
            //{
            //    Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 5, false, "2585555.Trn came to make payment for AmazonPay:ERROR", "MSG: " + err.Message.ToString());
            //}

            //#endregion
        }
        else
        {
            //SOME VALUE IS MISSING
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, "", 5, false, "1.Trn came to make payment for: AmazonPay", "Email = " + email + ",Custid = " + C_id.ToString() + ",mobile = " + mobilenumber + ",trnid" + ordrid);
        }

    }
    protected void billdeskbtn_Click(object sender, EventArgs e)
    {
        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, "", 6, false, "001.Trn came to make payment for BD", " ");
        decimal orderamnt = 0;
        string email = string.Empty;
        string mobilenumber = string.Empty;
        string C_id = string.Empty;
        string ordrid = string.Empty;
        //decimal.TryParse(Get_Transactiontbl.Rows[0]["OrderAmount"].ToString(), out orderamnt);

        try
        {
            //email = Get_Transactiontbl.Rows[0]["Email"].ToString();
            //mobilenumber = Get_Transactiontbl.Rows[0]["Mobile_Number"].ToString();
            //C_id = Get_Transactiontbl.Rows[0]["CustomerId"].ToString();
            //ordrid = Get_Transactiontbl.Rows[0]["TxnId"].ToString();

            string qry = "select PaidAmount,AddressId from [AlterNetOrder] where TrnId='" + txnId + "'";
            DataTable dtorderdetails = dbCon.GetDataTable(qry);
            if (dtorderdetails != null & dtorderdetails.Rows.Count > 0)
            {
                bool o = decimal.TryParse(dtorderdetails.Rows[0]["PaidAmount"].ToString(), out orderamnt);

                string qryadd = "select CustomerId,MobileNo,Email from CustomerAddress where Id=" + dtorderdetails.Rows[0]["AddressId"].ToString() + "";
                DataTable dtadddetails = dbCon.GetDataTable(qryadd);
                if (dtadddetails != null & dtadddetails.Rows.Count > 0)
                {
                    email = dtadddetails.Rows[0]["Email"].ToString();
                    mobilenumber = dtadddetails.Rows[0]["MobileNo"].ToString();
                    C_id = dtadddetails.Rows[0]["CustomerId"].ToString();
                    ordrid = txnId;
                }
            }
        }
        catch (Exception err)
        {
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, ordrid, 6, false, "1.Trn came to make payment for BD:ERROR", "MSG: " + err.Message.ToString());

        }
        Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Information, ordrid, 6, false, "1.Trn came to make payment for BD", " ");

        if (orderamnt > 0 && !String.IsNullOrEmpty(ordrid) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(C_id))
        {
            try
            {

                String Str1 = "UPDATE [dbo].[CitrusPayment] SET [Payment_Method_Id] = @1 ,[Cit_TimeOfTransaction] = DATEADD(MINUTE, 330, GETUTCDATE()) ,[HasGone] = @2,[IsRecordsFetchedFromCitrus]= @3,[GoneTime] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TxnId] = '" + ordrid + "'";

                string[] parm = { "6", "1", "0" };

                int resval = dbCon.ExecuteQueryWithParams(Str1, parm);
                if (resval > 0)
                {
                    String Str2 = "UPDATE [dbo].[AlterNetOrder] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TrnId] = '" + ordrid + "'";

                    string[] parm2 = { "6" };

                    int resval2 = dbCon.ExecuteQueryWithParams(Str2, parm2);
                    if (resval2 > 0)
                    {
                        String Str3 = "UPDATE [dbo].[Order] SET [PaymentGatewayId] = @1 ,[UpdatedOnUtc] = DATEADD(MINUTE, 330, GETUTCDATE()) WHERE [TRNID] = '" + ordrid + "'";

                        string[] parm3 = { "6" };

                        int resval3 = dbCon.ExecuteQueryWithParams(Str3, parm3);
                    }
                }
            }
            catch (Exception err)
            {

            }

            //orderamnt = 1; //REMOVE

            #region Billdesk
            string data_string = "SALEBHAI|" + ordrid + "|NA|" + orderamnt + "|NA|NA|NA|INR|NA|R|salebhai|NA|NA|F|" + mobilenumber + "|" + email + "|NA|NA|NA|NA|NA|" + Constant.Message.PG_ReturnURL_BillDesk;
            string commonkey = "htNDOPkBZr58";
            //string key = "msg";
            string hash = string.Empty;
            hash = GetHMACSHA256(data_string, commonkey);
            hash = hash.ToUpper();
            data_string = data_string + "|" + hash;

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>SaleBhai Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            //outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='https://pgi.billdesk.com/pgidsk/PGIMerchantPayment' name='billdeskcbdhost' id='billdeskcbdhost'>";
            outputHTML += "<input type='hidden' name='msg' id='msg' value='" + data_string + "'>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.billdeskcbdhost.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);


            #endregion

        }
        else
        {
            //SOME VALUE IS MISSING
            Logger.InsertLogs(InvoiceLOGS.InvoiceLogLevel.Error, "", 6, false, "1.Trn came to make payment for: BD", "Email = " + email + ",Custid = " + C_id.ToString() + ",mobile = " + mobilenumber + ",trnid" + ordrid);
        }




    }
    private string GetHMACSHA256(string text, string key)
    {
        UTF8Encoding encoder = new UTF8Encoding();

        byte[] hashValue;
        byte[] keybyt = encoder.GetBytes(key);
        byte[] message = encoder.GetBytes(text);

        HMACSHA256 hashString = new HMACSHA256(keybyt);
        string hex = "";

        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;
    } 

}