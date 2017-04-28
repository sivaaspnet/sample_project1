using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for CentreLogin
/// </summary>

namespace MVC1
{
    public class CentreLogin_ctech
    {
        private int _retInt;
        private string _qry;

        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        public CentreLogin_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }

        #region Filling Location In DropDownList
        public void FillLocation(DropDownList dpDown)
        {
            AdminBusinessLogic_ctech.FillLocationLogin(dpDown);
        }
        #endregion

        #region Validating Wheather The User Is Valid Or Not Based On The Centre Details
        public int CheckCentreDetails(string centreId, string centrePassword)
        {
            _retInt = 0;

            MySqlCommand cmd = new MySqlCommand();
            DataTable dt;
            Mysqlconn_ctech.disposeConnection(mySqlConn);
            mySqlConn.Open();
            cmd.Connection = mySqlConn;

            cmd.CommandText = "SELECT centreId From Exam_CentreDetails Where centreId=@centreId and centrePassword=@centrePassword And status=1";

            cmd.Parameters.Add("@centreId",MySqlDbType.VarChar,10);
            cmd.Parameters["@centreId"].Value = centreId;

            cmd.Parameters.Add("@centrePassword", MySqlDbType.VarChar, 50);
            cmd.Parameters["@centrePassword"].Value = centrePassword;

            try
            {
                dt = Mysqlconn_ctech.ExecuteMysqlDataTable(cmd);
                if (dt.Rows.Count>0)
                {
                    
                    _retInt = Convert.ToInt32(dt.Rows[0]["centreId"].ToString());

                }

            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
            finally
            {
                Mysqlconn_ctech.disposeConnection(mySqlConn, cmd);
            }
            
            return _retInt; 
        }
        #endregion

    }
}
