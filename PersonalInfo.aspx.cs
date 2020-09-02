using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;
using System.Web.Services;


public partial class PersonalInfo : System.Web.UI.Page
{
    dbConnection dbc = new dbConnection();
   
    string Customerid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                edittable.Visible = false;
                editsection.Visible = true;
                Customerid = clsCommon.getCurrentCustomer().id;

                string qry = "select top 1 FirstName,LastName,(select CityName from CityMaster where Id= CityId) as CityName,(select StateName from StateMaster where Id= StateId) as stateName,Email,MobileNo from CustomerAddress where CustomerId=" + Customerid +"order by Id asc";
                DataTable dtcust = dbc.GetDataTable(qry);

                if(dtcust.Rows.Count>0 && dtcust != null)
                {
                    name.InnerText = dtcust.Rows[0]["FirstName"].ToString() + " " + dtcust.Rows[0]["LastName"].ToString();
                    city.InnerText = dtcust.Rows[0]["CityName"].ToString();
                    state.InnerText = dtcust.Rows[0]["stateName"].ToString();
                    email11.InnerText = dtcust.Rows[0]["Email"].ToString();
                    mobile.InnerText = dtcust.Rows[0]["MobileNo"].ToString();                   
                }

            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        edittable.Visible = true;
        editsection.Visible = false;
        Customerid = clsCommon.getCurrentCustomer().id;

        string QUESTATE = "SELECT Id,statename from  StateMaster where IsActive=1  order by id asc";
        DataTable dtstate = dbc.GetDataTable(QUESTATE);
        if (dtstate != null && dtstate.Rows.Count > 0)
        {
            ddlstate.DataSource = dtstate;
            ddlstate.DataTextField = "statename";
            ddlstate.DataValueField = "Id";
            ddlstate.DataBind();            
        }

        string quecity = "SELECT Id,CityName from  CityMaster where IsActive=1  order by id asc";
        DataTable dtcityy = dbc.GetDataTable(quecity);
        if (dtcityy != null && dtcityy.Rows.Count > 0)
        {
            ddlcity.DataSource = dtcityy;
            ddlcity.DataTextField = "CityName";
            ddlcity.DataValueField = "Id";
            ddlcity.DataBind();

        }


        string qry = "select top 1 FirstName,LastName,CityId,StateId,Email,MobileNo from CustomerAddress where CustomerId=" + Customerid + "order by Id asc";
        DataTable dtedit = dbc.GetDataTable(qry);

        if (dtedit.Rows.Count > 0 && dtedit != null)
        {
            int cityid = 0,stateid=0;
            int.TryParse(dtedit.Rows[0]["CityId"].ToString(), out cityid);
            int.TryParse(dtedit.Rows[0]["StateId"].ToString(), out stateid);
            

            txtfname.Text = dtedit.Rows[0]["FirstName"].ToString();
            txtlname.Text = dtedit.Rows[0]["LastName"].ToString();
            //ddlcity.SelectedIndex = cityid-1;
            //ddlstate.SelectedIndex = stateid-1;
            //ddlcity.SelectedItem.ToString() = dtedit.Rows[0]["CityName"].ToString();
           // txtstate.Text = dtedit.Rows[0]["stateName"].ToString();
            txtemail.Text = dtedit.Rows[0]["Email"].ToString();
            txtmob.Text = dtedit.Rows[0]["MobileNo"].ToString();
            txtmob.Enabled = false;

        }                
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        edittable.Visible = false;
        editsection.Visible = true;
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        Customerid = clsCommon.getCurrentCustomer().id;
        string fname = txtfname.Text;
        string lname = txtlname.Text;
        string email = txtemail.Text;

        string cityid = (ddlcity.SelectedValue).ToString();


        //string cityid = ddlcity.SelectedItem.ToString();
        string stateid = (ddlstate.SelectedValue).ToString();

        String querynew = "UPDATE [dbo].[CustomerAddress] SET [FirstName] = @1 ,[LastName]= @2,[Email] = @3 ,[CityId]=@4 ,[StateId]=@5 WHERE [CustomerId] =  '" + Customerid + "'";
        string[] parms_new = { fname, lname, email, cityid, stateid };
        int resvaltrn = dbc.ExecuteQueryWithParams(querynew, parms_new);

        if(resvaltrn >0)
        {
            

            Customerid = clsCommon.getCurrentCustomer().id;

            string qry = "select top 1 FirstName,LastName,(select CityName from CityMaster where Id= CityId) as CityName,(select StateName from StateMaster where Id= StateId) as stateName,Email,MobileNo from CustomerAddress where CustomerId=" + Customerid + "order by Id asc";
            DataTable dtcust = dbc.GetDataTable(qry);

            if (dtcust.Rows.Count > 0 && dtcust != null)
            {
                name.InnerText = dtcust.Rows[0]["FirstName"].ToString() + " " + dtcust.Rows[0]["LastName"].ToString();
                city.InnerText = dtcust.Rows[0]["CityName"].ToString();
                state.InnerText = dtcust.Rows[0]["stateName"].ToString();
                email11.InnerText = dtcust.Rows[0]["Email"].ToString();
                mobile.InnerText = dtcust.Rows[0]["MobileNo"].ToString();
            }

            edittable.Visible = false;
            editsection.Visible = true;
        }
    }
    [WebMethod]
    public static string GetCityList(string id)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string cid = id;

            string quecity = "SELECT 0 as id, 'Select City' as CityName UNION  select  Id,CityName from  CityMaster where IsActive=1 AND StateId='" + id + "' order by id asc";
            DataTable dt = dbc.GetDataTable(quecity);

            string response = "";
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "ID asc";
                dt = dv.ToTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    response = response + dt.Rows[i]["id"].ToString() + ",";
                    response = response + dt.Rows[i]["Cityname"].ToString() + "###";
                }
                response = response.TrimEnd('#');
                return response;

            }
            return response;

        }
        catch
        {
            return null;
        }
    }
    [WebMethod]
    public static string GetMainCourse(string id)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string cid = id;

            string QUESTATE = "SELECT Id,statename from  StateMaster where IsActive=1 and Id='" + id + "' order by id asc";
            DataTable dt = dbc.GetDataTable(QUESTATE);

            string response = "";
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "Id asc";
                dt = dv.ToTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    response = response + dt.Rows[i]["id"].ToString() + ",";
                    response = response + dt.Rows[i]["StateName"].ToString() + "###";
                }
                response = response.TrimEnd('#');
                return response;

            }
            return response;

        }
        catch
        {
            return null;
        }
    }
}