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
/// Summary description for DataAccess
/// </summary>
namespace ICATERP
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
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ICAT-Connect"].ToString();
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
        #endregion

        #region Execute Scalar
        public static int ExecuteScalar(string ConnectionString,string Sqlstatement)
        {
            int retInt = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
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
        #endregion

        #region Execute Scalar
        public static string  ExecuteScalar(string ConnectionString, string Sqlstatement,string type)
        {
            string  retInt = "";
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
                DisposeConnetion(Conn);
                Conn.Open();
                retInt = (string)Comm.ExecuteScalar();
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

        #region Execute Reader
        public static SqlDataReader ExecuteReader(string ConnectionString, string Sqlstatement)
        {
            SqlDataReader dr;
            SqlConnection Conn = new SqlConnection(ConnectionString);
            SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
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
            finally
            {
               // DisposeConnetion(Conn);
                //DisposeCommand(Comm);
            }
            return dr;
        }
        #endregion

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

        public static DataTable ExecuteDataTable(string ConnectionString, SqlCommand Comm)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                DisposeConnetion(Conn);
                Conn.Open();
                Comm.Connection = Conn;
                SqlDataAdapter da = new SqlDataAdapter(Comm);
                da.Fill(dt);
                DisposeConnetion(Conn);
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
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DisposeConnetion(Conn);
            DisposeCommand(cmd);
            return dt;
        }

        #endregion

        #region Execute NonQuery
        public static int ExecuteNonQuery(string ConnectionString,SqlCommand Comm)
        {
            int retInt = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                DisposeConnetion(Conn);
                Conn.Open();
                Comm.Connection = Conn;
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

        public static int ExecuteNonQuery(string ConnectionString, string Sqlstatement)
        {
            int retInt = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlCommand Comm = new SqlCommand(Sqlstatement, Conn);
                DisposeConnetion(Conn);
                Conn.Open();
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

        #region Getting Category Page By passing category id and subcategory id
        public static string getCategorypage(int catid, int subcatid)
        {
            string page;
            if (catid == 1)
            {
                if (subcatid == 0)
                {
                    page = "product1.aspx";
                }
                else
                {
                    page = "product1.aspx?sub_id=" + subcatid + "";
                }
              

            }
            else
            {
                page = "product1.aspx";
            }
            return page;

        }
         #endregion

        public static void showMsgBox(string msg)
        {
            Page page = (Page)HttpContext.Current.Handler;
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
            page.Controls.Add(lbl);
        }

        public static string amountinwords(double amount)
        {
            string words="";
            string _Qry = " select words from fnNumToWords1('"+amount+"','n') ";
            DataTable dtwords = new DataTable();
            dtwords = ICATERP.DataAccess.ExecuteDataTable(_Qry);
            if (dtwords.Rows.Count > 0)
            {
                words = dtwords.Rows[0]["words"].ToString();
            }
            return words;
        }


        public static string amountinwords(int amount)
        {
            string words = "";
            string _Qry = " select words from fnNumToWords1('" + amount + "','n')";
            DataTable dtwords = new DataTable();
            dtwords = ICATERP.DataAccess.ExecuteDataTable(_Qry);
            if (dtwords.Rows.Count > 0)
            {
                words = dtwords.Rows[0]["words"].ToString();
            }
            return words;
        }

        public static string amts(int amountvalue)
        {
            string words;
            if (amountvalue >= 1000000000)
            {
                words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"00\",\"000");
            }
            else if (amountvalue >= 10000000)
            {
                words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
            }
            else if (amountvalue >= 100000)
            {
                words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
            }
            else
            {
                words = "Rs " + amountvalue.ToString("#,000");
            }
            return words;
        }

        public static string amts(double amountvalue)
        {
            string words;
            if (amountvalue >= 1000000000)
            {
                words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"00\",\"000");
            }
            else if (amountvalue >= 10000000)
            {
                words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
            }
            else if (amountvalue >= 100000)
            {
                words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
            }
            else
            {
                words = "Rs " + amountvalue.ToString("#,000");
            }
            return words;
        }

        public static string showBox(string msg)
        {
            string val= "<script language='javascript'> window.alert('" + msg + "');</script>";
            return val;
        }

        public static void Log(string err, string fn)
        {
            StreamWriter objReader = default(StreamWriter);
            string WebPath = HttpContext.Current.Server.MapPath(".");
            if (!Directory.Exists(WebPath + "\\Monthlycollection\\")) Directory.CreateDirectory(WebPath + "\\Monthlycollection\\");
            string defaultpath = WebPath + "\\Monthlycollection\\";
            string filename = fn + ".xls";
            if (!File.Exists(defaultpath + filename))
            {
                objReader = new StreamWriter(defaultpath + filename);

                objReader.Write(err.ToString());

                objReader.Close();
            }

            //HttpContext.Current.Response.Write("An error has occured, Please contact Admin");
        }


        public static void ExportTableData(DataTable dtdata, int startpos, int endpos, string title)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + title);
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            if (dtdata != null)
            {
                for (int i = startpos; i < endpos; i++)
                {
                    HttpContext.Current.Response.Write(dtdata.Columns[i].ToString() + "\t");
                }
                HttpContext.Current.Response.Write(System.Environment.NewLine);
                HttpContext.Current.Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtdata.Rows)
                {
                    for (int i = startpos; i < endpos; i++)
                    {
                        HttpContext.Current.Response.Write(dr[i].ToString() + "\t");
                    }
                    HttpContext.Current.Response.Write("\n");
                }
                HttpContext.Current.Response.End();
            }
        }

        public class NumberToEnglish
        {

            public String changeNumericToWords(double numb)
            {

                String num = numb.ToString();

                return changeToWords(num, false);

            }

            public String changeCurrencyToWords(String numb)
            {

                return changeToWords(numb, true);

            }

            public String changeNumericToWords(String numb)
            {

                return changeToWords(numb, false);

            }

            public String changeCurrencyToWords(double numb)
            {

                return changeToWords(numb.ToString(), true);

            }

            private String changeToWords(String numb, bool isCurrency)
            {

                String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";

                String endStr = (isCurrency) ? ("Only") : ("");

                try
                {

                    int decimalPlace = numb.IndexOf(".");

                    if (decimalPlace > 0)
                    {

                        wholeNo = numb.Substring(0, decimalPlace);

                        points = numb.Substring(decimalPlace + 1);

                        if (Convert.ToInt32(points) > 0)
                        {

                            andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents

                            endStr = (isCurrency) ? ("Cents " + endStr) : ("");

                            pointStr = translateCents(points);

                        }

                    }

                    val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);

                }

                catch { ;}

                return val;

            }

            private String translateWholeNumber(String number)
            {

                string word = "";

                try
                {

                    bool beginsZero = false;//tests for 0XX

                    bool isDone = false;//test if already translated

                    double dblAmt = (Convert.ToDouble(number));

                    //if ((dblAmt > 0) && number.StartsWith("0"))

                    if (dblAmt > 0)
                    {//test for zero or digit zero in a nuemric

                        beginsZero = number.StartsWith("0");

                        int numDigits = number.Length;

                        int pos = 0;//store digit grouping

                        String place = "";//digit grouping name:hundres,thousand,etc...

                        switch (numDigits)
                        {

                            case 1://ones' range

                                word = ones(number);

                                isDone = true;

                                break;

                            case 2://tens' range

                                word = tens(number);

                                isDone = true;

                                break;

                            case 3://hundreds' range

                                pos = (numDigits % 3) + 1;

                                place = " Hundred ";

                                break;

                            case 4://thousands' range

                            case 5:

                            case 6:

                                pos = (numDigits % 4) + 1;

                                place = " Thousand ";

                                break;

                            case 7://millions' range

                            case 8:

                            case 9:

                                pos = (numDigits % 7) + 1;

                                place = " Million ";

                                break;

                            case 10://Billions's range

                                pos = (numDigits % 10) + 1;

                                place = " Billion ";

                                break;

                            //add extra case options for anything above Billion...

                            default:

                                isDone = true;

                                break;

                        }

                        if (!isDone)
                        {//if transalation is not done, continue...(Recursion comes in now!!)

                            word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));

                            //check for trailing zeros

                            if (beginsZero) word = " and " + word.Trim();

                        }

                        //ignore digit grouping names

                        if (word.Trim().Equals(place.Trim())) word = "";

                    }

                }

                catch { ;}

                return word.Trim();

            }
            private String tens(String digit)
            {

                int digt = Convert.ToInt32(digit);

                String name = null;

                switch (digt)
                {

                    case 10:

                        name = "Ten";

                        break;

                    case 11:

                        name = "Eleven";

                        break;

                    case 12:

                        name = "Twelve";

                        break;

                    case 13:

                        name = "Thirteen";

                        break;

                    case 14:

                        name = "Fourteen";

                        break;

                    case 15:

                        name = "Fifteen";

                        break;

                    case 16:

                        name = "Sixteen";

                        break;

                    case 17:

                        name = "Seventeen";

                        break;

                    case 18:

                        name = "Eighteen";

                        break;

                    case 19:

                        name = "Nineteen";

                        break;

                    case 20:

                        name = "Twenty";

                        break;

                    case 30:

                        name = "Thirty";

                        break;

                    case 40:

                        name = "Fourty";

                        break;

                    case 50:

                        name = "Fifty";

                        break;

                    case 60:

                        name = "Sixty";

                        break;

                    case 70:

                        name = "Seventy";

                        break;

                    case 80:

                        name = "Eighty";

                        break;

                    case 90:

                        name = "Ninety";

                        break;

                    default:

                        if (digt > 0)
                        {

                            name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));

                        }

                        break;

                }

                return name;

            }

            private String ones(String digit)
            {

                int digt = Convert.ToInt32(digit);

                String name = "";

                switch (digt)
                {

                    case 1:

                        name = "One";

                        break;

                    case 2:

                        name = "Two";

                        break;

                    case 3:

                        name = "Three";

                        break;

                    case 4:

                        name = "Four";

                        break;

                    case 5:

                        name = "Five";

                        break;

                    case 6:

                        name = "Six";

                        break;

                    case 7:

                        name = "Seven";

                        break;

                    case 8:

                        name = "Eight";

                        break;

                    case 9:

                        name = "Nine";

                        break;

                }

                return name;

            }

            private String translateCents(String cents)
            {

                String cts = "", digit = "", engOne = "";

                for (int i = 0; i < cents.Length; i++)
                {

                    digit = cents[i].ToString();

                    if (digit.Equals("0"))
                    {

                        engOne = "Zero";

                    }

                    else
                    {

                        engOne = ones(digit);

                    }

                    cts += " " + engOne;

                }

                return cts;

            }

        }


        //#region NullTesting
        //public static object nulltesting(object str)
        //{
        //    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(str)))
        //    {
        //        str = "";
        //        return str;
        //    }
        //    str = Strings.Replace(Conversions.ToString(str), "~", "'", 1, -1, CompareMethod.Binary);
        //    str = RuntimeHelpers.GetObjectValue(str);
        //    return str;
        //}
        //#endregion


    }
}