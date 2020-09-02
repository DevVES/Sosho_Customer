using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Order
{
    public class Logger
    {

        public Logger()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void InsertLogs(InvoiceLOGS.InvoiceLogLevel Logtype, string tranid = "", int paymentmethod = 0, bool issuccess = false, String ShortMsg = "", String detailmsg = "")
        {
            dbConnection dbc = new dbConnection();
            try
            {
                DateTime curr_time = dbc.getindiantime();

                int logtypeid = 0;


                logtypeid = (int)Logtype;


                if (InvoiceLOGS.InvoiceLogLevel.Success.CompareTo(Logtype) == 1)
                {
                    //logtypeid = InvoiceLOGS.InvoiceLogLevel.Success;
                }
                //InvoiceLOGS.InvoiceLogLevel.TryParse(Logtype.ToString(), out logtypeid);
                //InvoiceLOGS.InvoiceLogLevel myval = (InvoiceLOGS.InvoiceLogLevel)Enum.Parse(typeof(TestEnum), Logtype.ToString());

                string[] insert = { logtypeid.ToString(), tranid, paymentmethod.ToString(), issuccess.ToString(), detailmsg, ShortMsg };
                string cmd = "INSERT INTO [dbo].[PaymentTransactionLogs] ([LogLevel],[TrnId],[PaymentMethod],[IsSuccess],[ResponseString],[DOC],[ShortMsg])  VALUES  (@1,@2,@3,@4,@5,DATEADD(MINUTE, 330, GETUTCDATE()),@6)";

                int value = dbc.ExecuteQueryWithParams(cmd, insert);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                dbc.closeConnection();
            }
        }

    }
    public class InvoiceLOGS
    {
        public enum InvoiceLogLevel
        {
            Success = 10,
            Information = 20,
            Warning = 30,
            Error = 40,
            FailRespons = 50
        }
    }
}