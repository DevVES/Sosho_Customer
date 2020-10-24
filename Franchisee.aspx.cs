using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Franchisee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void Save_Click(object sender, EventArgs e)
    //{
    //    string Customerid = clsCommon.getCurrentCustomer().id;
    //    string name = txtname.Text;
    //    string email = txtemail.Text;
    //    string mobile = txtmob.Text;
    //    string pin = txtpin.Text;
    //    string address = txtaddress.Text;
    //    var FranchiseeModel = new clsModals.AddFranchies();

    //    FranchiseeModel.Name = name;
    //    FranchiseeModel.Email = email;
    //    FranchiseeModel.Mobile = mobile;
    //    FranchiseeModel.PinCode = pin;
    //    FranchiseeModel.Address = address;
    //    FranchiseeModel.CreatedBy = Customerid;

    //    WebClient client = new WebClient();
    //    client.Encoding = Encoding.UTF8;
    //    client.Headers["Content-type"] = "application/json";

    //    var model = JsonConvert.SerializeObject(FranchiseeModel);
    //    var data = client.UploadString(clsCommon.strApiUrl + "/api/Franchies/BecomeNewFranchise", model);

    //    if (!string.IsNullOrWhiteSpace(data))
    //    {
    //        clsModals.AddFranchiesResponse obj = JsonConvert.DeserializeObject<clsModals.AddFranchiesResponse>(data);
    //        if (obj.response == "1")
    //        {
    //            Response.Write("<script>alert('Hello');</script>");
    //        }
    //        else
    //        {

    //        }
    //    }


    //}
    [System.Web.Services.WebMethod]
    public static clsModals.AddFranchiesResponse Save(clsModals.AddFranchies model)
    {
        var obj = new clsModals.AddFranchiesResponse();
        WebClient client = new WebClient();
        client.Encoding = Encoding.UTF8;
        client.Headers["Content-type"] = "application/json";
        string Customerid = clsCommon.getCurrentCustomer().id;
        model.CreatedBy = Customerid;
        var FranchiseeModel = JsonConvert.SerializeObject(model);
        var data = client.UploadString(clsCommon.strApiUrl + "/api/Franchies/BecomeNewFranchise", FranchiseeModel);
        if (!string.IsNullOrWhiteSpace(data))
        {
            obj = JsonConvert.DeserializeObject<clsModals.AddFranchiesResponse>(data);
            return obj;
        }
        return obj;

    }
    

    
}