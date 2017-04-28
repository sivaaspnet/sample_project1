using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.IO;
using MVC1;
/// <summary>
/// Summary description for SiteFunctions
/// </summary>
/// 
namespace MVC1
{
public class SiteFunctions
{
    #region Handling The Injection
    public static string databaseset(string st)
    {
        if (st != "")
        {
            string str;
            str = st.Replace( "'", "~");
            return str;
        }
        else
        {
            return st;
        }
    }

    public static string databaseget(string st)
    {
        if (st != "")
        {
            string str;
            str = st.Replace( "~", "'");
            return str;
        }
        else
        {
            return st;
        }
    }

    #endregion

    #region Handling The Exception
    public static void Log(Exception err)
    {
        StreamWriter objReader = default(StreamWriter);
        string WebPath = HttpContext.Current.Server.MapPath(".");
        if (!Directory.Exists(WebPath + "\\ErrorLogs\\")) Directory.CreateDirectory(WebPath + "\\ErrorLogs\\");
        string defaultpath = WebPath + "\\ErrorLogs\\";
        string filename = System.DateTime.Now.ToString("MM_dd_yyyy") + ".txt";
        if (!File.Exists(defaultpath + filename))
        {
            objReader = new StreamWriter(defaultpath + filename);
            objReader.Write(DateTime.Now + " = ");
            objReader.WriteLine(objReader.NewLine);
            objReader.Write(err.ToString());
            objReader.WriteLine(objReader.NewLine);
            objReader.Close();
        }
        else
        {
            objReader = File.AppendText(defaultpath + filename);
            objReader.Write(DateTime.Now + " = ");
            objReader.WriteLine(objReader.NewLine);
            objReader.WriteLine(err.ToString());
            objReader.WriteLine(objReader.NewLine);
            objReader.Flush();
            objReader.Close();
        }
        //HttpContext.Current.Response.Write("An error has occured, Please contact Admin");
    }

    public static void WriteString(string writeString)
    {
        StreamWriter objReader = default(StreamWriter);
        string WebPath = HttpContext.Current.Server.MapPath(".");
        if (!Directory.Exists(WebPath + "\\ErrorLogs\\")) Directory.CreateDirectory(WebPath + "\\ErrorLogs\\");
        string defaultpath = WebPath + "\\ErrorLogs\\";
        string filename = System.DateTime.Now.ToString("MM_dd_yyyy") + ".txt";
        if (!File.Exists(defaultpath + filename))
        {
            objReader = new StreamWriter(defaultpath + filename);
            objReader.Write(DateTime.Now + " = ");
            objReader.WriteLine(objReader.NewLine);
            objReader.Write(writeString);
            objReader.WriteLine(objReader.NewLine);
            objReader.Close();
        }
        else
        {
            objReader = File.AppendText(defaultpath + filename);
            objReader.Write(DateTime.Now + " = ");
            objReader.WriteLine(objReader.NewLine);
            objReader.WriteLine(writeString);
            objReader.WriteLine(objReader.NewLine);
            objReader.Flush();
            objReader.Close();
        }
    }
    #endregion

    #region Closing The Sleeping Connections
    public static void CloseSleepConnection(int minOfSleeping)
    {
        string qry = "show processlist";
        ArrayList m_ProcessesToKill = new ArrayList();
        MySqlConnection Conn = new MySqlConnection( Mysqlconn_ctech.ConnectionString);
        MySqlCommand Comm = new MySqlCommand(qry, Conn);
        DataTable dt;
        try
        {
            Mysqlconn_ctech.disposeConnection(Conn);
            Conn.Open();
            dt = Mysqlconn_ctech.ExecuteMysqlDataTable(Comm);
            if (dt.Rows.Count>0)
            {
                int i;
                for(i=0;i<=dt.Rows.Count-1 ;i++)
                {
                    int iPID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                    string strState = dt.Rows[i]["Command"].ToString();
                    int iTime = Convert.ToInt32(dt.Rows[i]["Time"].ToString());

                    if (strState == "Sleep" && iTime >= minOfSleeping && iPID > 0)
                    {
                        // This connection is sitting around doing nothing. Kill it.
                        m_ProcessesToKill.Add(iPID);
                    }
                }
            }
            foreach (int aPID in m_ProcessesToKill)
            {
                //HttpContext.Current.Response.Write(aPID + "</BR>");

                string strSQL = "kill " + aPID;
                Comm.CommandText = strSQL;
                Comm.ExecuteNonQuery();
            }

        }
        catch(Exception ex)
        {
            Log(ex);
        }
        finally
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }
    #endregion
}

public class FillDataControls
{
    #region Execute Command With Return Parameter
    public static int ExecuteNonquery(string qry)
    {
        int retCount = 0;
        try
        {
            retCount = Mysqlconn_ctech.ExecuteMySqlCommand(qry);
        }
        catch (Exception ex)
        {
            SiteFunctions.Log(ex);
        }
        return retCount;
    }
    #endregion

    #region Filling Datas In The DropDown
    public static void FillDropDownList(DropDownList DropDown, object MysqlStatement, object ListText, object ListValue)
        {
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt;

            MySqlConnection mySqlConn = new MySqlConnection(Mysqlconn_ctech.ConnectionString);
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            cmd.Connection = mySqlConn;
            cmd.CommandText = MysqlStatement.ToString();
            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(cmd);

                DropDown.DataSource = dt;
                DropDown.DataTextField = SiteFunctions.databaseget(ListText.ToString());
                DropDown.DataValueField = SiteFunctions.databaseget(ListValue.ToString());
                DropDown.DataBind();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, cmd);
            }
        }

    public static void FillDropDownList(DropDownList DropDown, string MysqlStatement, object ListText, object ListValue, object defval)
        {

            MySqlCommand cmd = new MySqlCommand();
            DataTable dt;

            MySqlConnection mySqlConn = new MySqlConnection(Mysqlconn_ctech.ConnectionString);
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();

            cmd.Connection = mySqlConn;
            cmd.CommandText = MysqlStatement;
            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(cmd);

                DropDown.DataSource = dt;
                DropDown.DataTextField = SiteFunctions.databaseget(ListText.ToString());
                DropDown.DataValueField = SiteFunctions.databaseget(ListValue.ToString());
                DropDown.DataBind();

                DropDown.SelectedValue = defval.ToString();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, cmd);
            }
        }
    #endregion

    #region Filling Datas In The GridView And Return Datatable
        public static void FillGridView( GridView GridViewName, string MysqlStatement)
        {
            MySqlConnection Conn = new MySqlConnection(Mysqlconn_ctech.ConnectionString);
            try
            {
                Mysqlconn_ctech.disposeConnection(Conn);
                Conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(MysqlStatement, Conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Table");
                GridViewName.DataSource = ds;
                GridViewName.DataBind();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Conn.Dispose();
            }
         
        }

        public static DataTable FillGridView(string qry, GridView gridControl)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
                gridControl.DataSource = dt;
                gridControl.DataBind();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            return dt;
        }


        #endregion

    #region Filling Datas In The Datalist And Return Datatable
        public static void FillDataList(DataList DataListName, string MysqlStatement)
        {
            MySqlConnection Conn = new MySqlConnection(Mysqlconn_ctech.ConnectionString);
            try
            {
                Mysqlconn_ctech.disposeConnection(Conn);
                Conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(MysqlStatement.ToString(), Conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Table");
                DataListName.DataSource = ds;
                DataListName.DataBind();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Conn.Dispose();
            }
        }

        public static DataTable FillDataList(string qry, DataList dtaList)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(qry);
                dtaList.DataSource = dt;
                dtaList.DataBind();
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            return dt;
        }
    #endregion
}

public class CommonFunction
    {
        private string qry;

        #region Validating Number
        public int isNumeric(string id)
        {
            int outno = 0;
            bool isNumeric = int.TryParse(id, out outno);
            return outno;
        }
        #endregion

        #region Generating Dynamic code
        public string GetDynamicCode(int valLength)
        {
            string returnString = "";
            returnString = System.Guid.NewGuid().ToString();
            returnString = returnString.Replace("-", string.Empty);
            returnString = returnString.Substring(0, valLength);
            return returnString;
        }
        #endregion

        #region Decrease The Length Of The String
    public static string Managelength(string strVal, int strLength)
    {
        string retString = strVal;
        if (strVal != "" && strVal.Length > strLength)
        {
            retString = strVal.Substring(0, strLength) + "..";
        }
       
        return SiteFunctions.databaseget(retString);
    }
    #endregion

        #region Validate UserType
        public static void CheckSession()
    {
        if (HttpContext.Current.Session["UserType"] == null || HttpContext.Current.Session["AdUserId"] == null || HttpContext.Current.Session["CentreId"] == null)
        {
            //also Used In Toplinks Page
            HttpContext.Current.Session["Msg"] = "Session Expired!! Please Login Again";
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
    }

        public static void CheckUserType()
    {
        if (HttpContext.Current.Session["UserType"] == null || HttpContext.Current.Session["AdUserId"] == null || HttpContext.Current.Session["CentreId"] == null)
        {
            //also Used In Toplinks Page
            HttpContext.Current.Session["Msg"] = "Session Expired!! Please Login Again";
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        //--
        else if (HttpContext.Current.Session["UserType"].ToString() != "MASTER")
        {
            HttpContext.Current.Session["Msg"] = "Invalid attempt!!.";

            HttpContext.Current.Session["UserType"] = null;
            HttpContext.Current.Session["AdUserId"] = null;
            HttpContext.Current.Session["CentreId"] = null;
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        //---
    }

    public static void CheckUserTypeEX()
    {
        if (HttpContext.Current.Session["UserType"] == null || HttpContext.Current.Session["AdUserId"] == null || HttpContext.Current.Session["CentreId"] == null)
        {
            //also Used In Toplinks Page
            HttpContext.Current.Session["Msg"] = "Session Expired!! Please Login Again";
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        //--
        //else if (HttpContext.Current.Session["UserType"].ToString() != "MASTER")
        //{
        //    HttpContext.Current.Session["Msg"] = "Invalid attempt!!.";

        //    HttpContext.Current.Session["UserType"] = null;
        //    HttpContext.Current.Session["AdUserId"] = null;
        //    HttpContext.Current.Session["CentreId"] = null;
        //    HttpContext.Current.Response.Redirect("Default.aspx");
        //}
        //---
    }

        public static void CheckNoNUserType()
    {
        if (HttpContext.Current.Session["UserType"] == null || HttpContext.Current.Session["AdUserId"] == null || HttpContext.Current.Session["CentreId"] == null)
        {
            //also Used In Toplinks Page
            HttpContext.Current.Session["Msg"] = "Session Expired!! Please Login Again";
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        //--
        else if (HttpContext.Current.Session["UserType"].ToString() == "MASTER")
        {
            HttpContext.Current.Session["Msg"] = "Invalid attempt!!.";

            HttpContext.Current.Session["UserType"] = null;
            HttpContext.Current.Session["AdUserId"] = null;
            HttpContext.Current.Session["CentreId"] = null;
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        //---
    }
    #endregion
    }

}