using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyWallet : System.Web.UI.Page
{
    dbConnection dbc = new dbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string CustomerId = clsCommon.getCurrentCustomer().id;

                //DataTable dtWallet = dbc.GetDataTable("select CustomerId,(sum(Cr_Amount)-sum(Dr_Amount)) as avlbal,SUM(Dr_Amount)as Usedamt from Customer_Wallet_History where CustomerId=" + CustomerId + "  group by customerid");
                //DataTable dtWallet = dbc.GetDataTable("select Customer_Id,(sum(Cr_Amount)-sum(Dr_Amount)) as avlbal,SUM(Dr_Amount)as Usedamt from tblWalletCustomerHistory where Customer_Id=" + CustomerId + "  group by Customer_Id");
                //if (dtWallet.Rows.Count > 0)
                //{
                //    lblusedbal.InnerHtml = dtWallet.Rows[0]["Usedamt"].ToString();
                //    lblavlbal.InnerHtml = dtWallet.Rows[0]["avlbal"].ToString();

                //}
                //else
                //{
                //    lblusedbal.InnerHtml = "0.00";
                //    lblavlbal.InnerHtml = "0.00";
                //}

                string apiString = clsCommon.strApiUrl + "api/Wallet/GetWalletHistory?CustomerId=" + CustomerId;
                string data = clsCommon.GET(apiString);
                if (!String.IsNullOrEmpty(data))
                {
                    WalletModel.getWalletHistory obj = JsonConvert.DeserializeObject<WalletModel.getWalletHistory>(data);
                    if (obj.response.Equals("1"))
                    {
                        walletbal.InnerHtml = Convert.ToDecimal(obj.WalletBalance).ToString("0.00");
                        string html = string.Empty;
                        foreach (var item in obj.WalletHistoryList)
                        {
                            string color = string.Empty;
                            string sign = string.Empty;
                            switch (item.type)
                            {
                                case "Debit":
                                    color = "red;";
                                    sign = "-₹ ";
                                    break;
                                case "Credit":
                                    color = "green;";
                                    sign = "+₹ ";
                                    break;
                                default:
                                    color = "black;";
                                    sign = "₹ ";
                                    break;

                            }
                                
                            html += "<a href=\"#\" class=\"list-group-item\">";
                            html += "<h5 class=\"list-group-item-heading\">" + item.Summary + "<span class=\"pull-right\" style=\"color:" + color + "\">" + sign + Convert.ToDecimal(item.CrDrAmount).ToString("0.00") + "</span></h5>";
                            html += "<p class=\"list-group-item-text\">"+item.Date+"<span class=\"pull-right\">Closing Balance:₹ "+ Convert.ToDecimal(item.Balance).ToString("0.00") + "</span></p></a>";

                        }

                        wallethistory.InnerHtml = html;
                    }

                }
            }
        }
        catch (Exception ee)
        {
            
        }
    }
}