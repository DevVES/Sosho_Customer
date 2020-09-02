using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using paytm;


public class dbConnection
{
    // public string consString = @"Data Source=DISHA\SQLEXPRESS;Initial Catalog=SalebhaiOnePage;User Id=sa;Password=123";
    //string consString = @"Data Source=S97-74-232-233\SQLEXPRESS;Initial Catalog=SalebhaiOnePage;Integrated Security=True;Persist Security Info=False";
    //string consString = @"Data Source=S97-74-232-233\SQLEXPRESS;Initial Catalog=SalebhaiOnePage_Staging;Integrated Security=True;Persist Security Info=False";
    //string consString = @"Data Source=LAPTOP-GI3RT09I\SQLEXPRESS01;Initial Catalog=SalebhaiOnePage;Integrated Security=True;Persist Security Info=False";
    string consString = @"Data Source=VES-02\SQLEXPRESS;Initial Catalog=SalebhaiOnePageStaging;Integrated Security=True;Persist Security Info=False";
    SqlConnection conn = new SqlConnection();
    string ErrorMsgPrefix = "Error in dbConnection.cs  ";
    public SqlConnection GetConnectionForAdapter()
    {
        if (conn.State == ConnectionState.Open)
        {
            return conn;
        }
        else
        {
            conn.ConnectionString = consString;
            return conn;
        }
    }

 public int ExecuteQuery(string query)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = openConnection();//Open
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        catch (Exception e)
        {
            //InsertLogs(ErrorMsgPrefix + " ExecuteQuery Msg:" + e.Message, "", e.StackTrace + query);
        }
        finally
        {
            closeConnection();
        }
        return 0;
        //Close
    }
    public DataTable GetDataTable(string query = "")
    {
        DataTable dt = new DataTable();
        try
        {
            if (!String.IsNullOrEmpty(query))
            {
                SqlDataAdapter adap = new SqlDataAdapter(query, GetConnectionSalebhai_AppServices());
                adap.Fill(dt);
            }
            else
            {
                dt = null;
            }
        }
        catch (Exception err)
        {
            dt = null;
        }
        return dt;
    }
    public SqlConnection GetConnectionSalebhai_AppServices()
    {
        try
        {

            conn.ConnectionString = consString;
            return conn;

        }
        catch (Exception ex)
        {
            // InsertLogsfORaPP(LOGS.LogLevel.Error, "GetConnectionSalebhai_AppServices", ex.Message.ToString());
            return null;
            //cnn.Close();
        }
        //  return cnn;
    } 
   #region Customer_Wallet_SMS
    public int Customer_Wallet_SMS(string MobileNumber, string SMS_Text)
    {
        int result = 0;
        try
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://hapi.smsapi.org/SendSMS.aspx?UserName=sms_salebhai&password=240955&MobileNo=" + MobileNumber + "&SenderID=SLBHAI&CDMAHeader=SLBHAI&Message=" + SMS_Text);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            string correct = responseString.Substring(0, 2);
            respStreamReader.Close();
            myResp.Close();
            result = 1;
        }
        catch (Exception err)
        {

        }
        return result;
    }
    #endregion
    public string calculateChecksum(string secretkey, string allparamvalues)
    {

        byte[] dataToEncryptByte = Encoding.UTF8.GetBytes(allparamvalues);
        byte[] keyBytes = Encoding.UTF8.GetBytes(secretkey);
        HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes);
        byte[] checksumByte = hmacsha256.ComputeHash(dataToEncryptByte);
        String checksum = toHex(checksumByte);

        return checksum;
    }
    public string toHex(byte[] bytes)
    {
        StringBuilder hex = new StringBuilder(bytes.Length * 2);
        foreach (byte b in bytes)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();


    }
    public string sha256_getchksm(string password)
    {
        System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
        System.Text.StringBuilder hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
        foreach (byte theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }
        return hash.ToString();
    }

    public int ExecuteQueryWithParams(string query, string[] parameters)
    {
        try
        {
            query = query.ToLower();
            String CheckQry = query;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;

            for (int counter = 1; counter <= parameters.Length; counter++)
            {
                cmd.Parameters.AddWithValue("@" + counter.ToString(), parameters[counter - 1]);
                string s1 = "@" + counter.ToString();
                string s2 = parameters[counter - 1];
                CheckQry = CheckQry.Replace(s1, s2);
            }
            conn = openConnection();
            cmd.Connection = conn;
            int val = cmd.ExecuteNonQuery();
            conn.Close();
            return val;
        }
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            conn.Close();
        }
    }
    public int ExecuteScalarQueryWithParams(string query, string[] parameters)
    {
        try
        {
            String CheckQry = query;
            query = query.ToLower();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;

            for (int counter = 1; counter <= parameters.Length; counter++)
            {
                cmd.Parameters.AddWithValue("@" + counter.ToString(), parameters[counter - 1]);
                string s1 = "@" + counter.ToString();
                string s2 = parameters[counter - 1];
                CheckQry = CheckQry.Replace(s1, s2);
            }
            conn = openConnection();
            cmd.Connection = conn;
            object value = cmd.ExecuteScalar();
            int val = Convert.ToInt32(value);
            conn.Close();
            return val;
        }
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            conn.Close();
        }
    }
      public string genCheckSum(Dictionary<string, string> parameters, string merchantKey)
    {
        string checksum = CheckSum.generateCheckSum(merchantKey, parameters);
        return checksum;
    }
    public SqlConnection openConnection()
    {
        if (conn.State == ConnectionState.Open)
        {
            return conn;
        }
        else
        {
            conn.ConnectionString = consString;
            conn.Open();
        }
        return conn;
    }
    public void closeConnection()
    {
        if (conn.State == ConnectionState.Closed)
        {
            return;
        }
        else
        {
            conn.Close();
        }

    }

    public DataTable GetDataTableWithParams(string query, string[] parameters)
    {
        try
        {
            query = query.ToLower();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            for (int counter = 1; counter <= parameters.Length; counter++)
            {
                cmd.Parameters.AddWithValue("@" + counter.ToString(), parameters[counter - 1]);
            }
            conn = openConnection();
            cmd.Connection = conn;
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cmd;
            adap.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            conn.Close();
        }

    }
    public object ExecuteSQLScalerWithTrn(string sqlStatement, SqlConnection con, SqlTransaction Trn)
    {
        object obj = null;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlStatement;
            cmd.Connection = con;
            cmd.Transaction = Trn;
            cmd.CommandText = sqlStatement;
            obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            cmd.Dispose();
            return obj;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetDataTableWithParamsWithTrn(string query, string[] parameters, SqlConnection con, SqlTransaction Trn)
    {
        try
        {
            query = query.ToLower();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            for (int counter = 1; counter <= parameters.Length; counter++)
            {
                cmd.Parameters.AddWithValue("@" + counter.ToString(), parameters[counter - 1]);
            }
            conn = openConnection();
            cmd.Connection = conn;
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cmd;
            adap.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            conn.Close();
        }

    }
    public int ExecuteQueryWithTrn(string query, SqlConnection con, SqlTransaction Trn)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Transaction = Trn;
            cmd.Connection = con;
            int i = cmd.ExecuteNonQuery();
            closeConnection();
            return i;
        }
        catch (Exception ex)
        {
            return 0;
        }
        finally
        {
            conn.Close();
        }
    }
    public DataTable GetDataTableWithTrn(string query, SqlConnection con, SqlTransaction Trn)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Transaction = Trn;
            cmd.Connection = con;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);
            //closeConnection();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DateTime getindiantime()
    {
        try
        {
            DateTime nonISD = DateTime.Now;
            //Change Time zone to ISD timezone
            TimeZoneInfo myTZ = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //DateTime ISDTime = TimeZoneInfo.ConvertTime(nonISD, TimeZoneInfo.Local, myTZ);
            DateTime ISDTime = TimeZoneInfo.ConvertTime(nonISD, myTZ);
            //ISDTime = DateTime.ParseExact(ISDTime,"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
            return ISDTime;
        }
        catch (Exception ex)
        {
            return DateTime.Now;
        }
    }

     public string getindiantimeString(bool needTimeToo=false)
    {
        try
        {
            DateTime nonISD = DateTime.Now;
            //Change Time zone to ISD timezone
            TimeZoneInfo myTZ = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //DateTime ISDTime = TimeZoneInfo.ConvertTime(nonISD, TimeZoneInfo.Local, myTZ);
            DateTime ISDTime = TimeZoneInfo.ConvertTime(nonISD, myTZ);
            //ISDTime = DateTime.ParseExact(ISDTime,"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
            if (needTimeToo)
	{
                return ISDTime.ToString("dd-MMM-yyyy HH:mm:ss");
	}
            return ISDTime.ToString("dd-MMM-yyyy");
        }
        catch (Exception ex)
        {
            return DateTime.Now.ToString("dd-MMM-yyyy");
        }
    }

    public string getDOCMtime()
    {
        try
        {
            DateTime nonISD = DateTime.Now;

            //Change Time zone to ISD timezone
            TimeZoneInfo myTZ = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //DateTime ISDTime = TimeZoneInfo.ConvertTime(nonISD, TimeZoneInfo.Local, myTZ);
            DateTime ISDTime = TimeZoneInfo.ConvertTime(nonISD, myTZ);
            //ISDTime = DateTime.ParseExact(ISDTime,"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
            string currentDateString = ISDTime.ToString("dd-MM-yyyy HH:mm:ss");

            string[] dt1 = currentDateString.Split(' ');
            string[] date = dt1[0].Split('-');
            string[] time = dt1[1].Split(':');

            return date[2] + "-" + date[1] + "-" + date[0] + " " + time[0] + ":" + time[1] + ":" + time[2];
        }
        catch (Exception ex)
        {
            return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }

    public void SendSMS(String Mobile, String Sms)
    {
        /// <summary>
        /// FLAG FOR SMS
        /// Did not respond 1
        /// Movement 2    
        /// Refund 3
        /// Cashback 4
        /// Informing collection 5
        /// Delivery Late 6
        /// </summary>
        /// <param name="Mobile"></param>
        /// <param name="Sms"></param>
        try
        {
            //dbConnection dbc = new dbConnection();
            //string[] prm = { Request.Cookies["TUser"]["Id"].ToString(), Mobile, Sms, flag.ToString() };
            //int i = dbc.ExecuteQueryWithParams("insert into Taaza_Sms (Userid,Sentto,SmsText,Flag,doc) Values (@1,@2,@3,@4,DATEADD(MINUTE, 330, GETUTCDATE()))", prm);
            //if (i > 0)
            {
                Sms = System.Web.HttpUtility.UrlEncode(Sms);
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create
                ("https://hapi.smsapi.org/SendSMS.aspx?UserName=TaazaFood&password=TaazaFood2016&MobileNo=" + Mobile
                + "&SenderID=TaazaF&CDMAHeader=TaazaF&Message=" + Sms);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();

                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                string correct = responseString.Substring(0, 2);
                respStreamReader.Close();
                myResp.Close();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public string GetIP4Address()
    {
        try
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            Console.WriteLine(hostName);
            // Get the IP
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }
        catch (Exception err)
        {
            //InsertLogs(LOGS.LogLevel.Error, "GetIP4Address", err.Message.ToString());
            return null;
        }
    }

    public void InsertErrorLogs(string errorDetail)
    {
        ExecuteQueryWithParams("INSERT INTO [dbo].[ErrorLogs] ([Detail] ,[DOC]) VALUES ('" + errorDetail + "' ,'" + getindiantime().ToString("dd-MMM-yyyy HH:mm:ss") + "' )", new string[] { });
    }

}
