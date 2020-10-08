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
            if(!IsPostBack)
            {
                string CustomerId = clsCommon.getCurrentCustomer().id;

                //DataTable dtWallet = dbc.GetDataTable("select CustomerId,(sum(Cr_Amount)-sum(Dr_Amount)) as avlbal,SUM(Dr_Amount)as Usedamt from Customer_Wallet_History where CustomerId=" + CustomerId + "  group by customerid");
                DataTable dtWallet = dbc.GetDataTable("select Customer_Id,(sum(Cr_Amount)-sum(Dr_Amount)) as avlbal,SUM(Dr_Amount)as Usedamt from tblWalletCustomerHistory where Customer_Id=" + CustomerId + "  group by Customer_Id");
                if (dtWallet.Rows.Count > 0)
                {
                    lblusedbal.InnerHtml = dtWallet.Rows[0]["Usedamt"].ToString();
                    lblavlbal.InnerHtml = dtWallet.Rows[0]["avlbal"].ToString();

                }
                else
                {
                    lblusedbal.InnerHtml = "0.00";
                    lblavlbal.InnerHtml = "0.00";
                }
            }
        }
        catch (Exception ee)
        {
            
        }
    }
}