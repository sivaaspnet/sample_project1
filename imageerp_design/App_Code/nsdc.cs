using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Collections;
using System.IO;
/// <summary>
/// Summary description for image
/// </summary>
namespace nsdc
{
    public class DisposeObject
    {
        protected static void DisposeConnetion(SqlConnection Conn)
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();

            }
        }

        protected static void DisposeCommand(SqlCommand Comm)
        {
            Comm.Dispose();
        }

    }

    public class DataAccess : DisposeObject
    {

        public DataAccess()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Declaring Connection String
        // public static string ConnectionString = "Data Source=Provider=sqloledb; Data Source = VMSSQL01; Initial Catalog = db_67451; User Id = imagedb3218; Password=image3218";
        // public static string ConnectionString = "Data Source=Provider=sqloledb; Data Source = VMSSQL01; Initial Catalog = db_67451; User Id = imagedb3218; Password=image3218;Max Pool Size=75000;connect timeout=200000";
        // public static string ConnectionString = "Data Source=Provider=sqloledb; Data Source = VMSSQL01; Initial Catalog = db_67451; User Id = imagedb3218; Password=image3218;Max Pool Size=75000;connect timeout=200000;Integrated Security=SSPI;Persist Security Info=False;";
  #region Declaring Connection String
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connect"].ToString();
        #endregion
        //public static string ConnectionString = "Data Source=10.1.1.1; Initial Catalog=december_14;User ID=sa;Password=PERicom06*";
       
        #endregion
        #region Execute Dataset
        public static DataSet ExecuteDataset(string Sqlstatement)
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            DisposeConnetion(Conn);
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(Sqlstatement, Conn);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            DisposeConnetion(Conn);
            return dataSet;
        }
        public static DataSet ExecuteDataset(SqlCommand Comm)
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            DisposeConnetion(Conn);
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(Comm);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            DisposeConnetion(Conn);
            return dataSet;
        }
        #endregion

        public static SqlDataAdapter ExecuteDataAdapter(SqlCommand Comm)
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            DisposeConnetion(Conn);
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(Comm);
            return da;
        }




        #region Execute Scalar
        public static int ExecuteScalar_int(string Sqlstatement)
        {
            int retInt = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
                Comm.CommandTimeout = 30000;
                DisposeConnetion(Conn);
                Conn.Open();
                retInt = (int)Comm.ExecuteScalar();
                DisposeConnetion(Conn);
                DisposeCommand(Comm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return retInt;
        }
        public static string ExecuteScalar_str(string Sqlstatement)
        {
            string retstr = "";
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
                Comm.CommandTimeout = 30000;
                DisposeConnetion(Conn);
                Conn.Open();
                retstr = Comm.ExecuteScalar().ToString();
                DisposeConnetion(Conn);
                DisposeCommand(Comm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return retstr;
        }
        public static string ExecuteScalar_str(SqlCommand Comm)
        {
            string retInt = "";
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Comm.Connection = Conn;
                Comm.CommandTimeout = 30000;                        
                DisposeConnetion(Conn);
                Conn.Open();
                retInt = Comm.ExecuteScalar().ToString();
                DisposeConnetion(Conn);
                DisposeCommand(Comm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return retInt;
        }
        #endregion


        public static SqlDataReader ExecuteReader(string Sqlstatement)
        {
            SqlDataReader dr;
            SqlConnection Conn = new SqlConnection(ConnectionString);
            SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
            Comm.CommandTimeout = 30000;
            try
            {
                DisposeConnetion(Conn);
                Conn.Open();
                dr = Comm.ExecuteReader(CommandBehavior.CloseConnection);


            }
            catch (Exception ex)
            {
                throw;
            }

            return dr;
        }

        #region Execute DataTable
        public static DataTable ExecuteDataTable(string ConnectionString, string Sqlstatement)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                DisposeConnetion(Conn);
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Sqlstatement, Conn);
                da.Fill(dt);
                DisposeConnetion(Conn);
            }
            catch (Exception ex)
            {

                throw;
            }
            return dt;
        }

        public static DataTable ExecuteDataTable( SqlCommand Comm)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                DisposeConnetion(Conn);
                Conn.Open();
                Comm.Connection = Conn;
                Comm.CommandTimeout = 30000;
                SqlDataAdapter da = new SqlDataAdapter(Comm);
                da.Fill(dt);
                DisposeConnetion(Conn);
                DisposeCommand(Comm);
            }
            catch (Exception ex)
            {

                throw;
            }
            return dt;
        }

        public static DataTable ExecuteDataTable(string Sqlstatement)
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            DisposeConnetion(Conn);
            Conn.Open();
            SqlCommand cmd = new SqlCommand(Sqlstatement, Conn);
            cmd.CommandTimeout = 30000;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DisposeConnetion(Conn);
            DisposeCommand(cmd);
            return dt;
        }

        #endregion


        #region Execute NonQuery
        public static int ExecuteNonQuery(SqlCommand Comm)
        {
            int retInt = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                DisposeConnetion(Conn);
                Conn.Open();
                Comm.Connection = Conn;
                Comm.CommandTimeout = 30000;
                retInt = Comm.ExecuteNonQuery();
                DisposeConnetion(Conn);
                DisposeCommand(Comm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return retInt;
        }

        public static int ExecuteNonQuery(string Sqlstatement)
        {
            int retInt = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
                DisposeConnetion(Conn);
                Conn.Open();
                Comm.CommandTimeout = 30000;
                retInt = Comm.ExecuteNonQuery();
                DisposeConnetion(Conn);
                DisposeCommand(Comm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return retInt;
        }
        #endregion













    }
}
