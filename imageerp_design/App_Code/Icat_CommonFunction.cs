using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CommonFunction
/// </summary>
namespace ICATERP
{

   public interface IAdmin
    {
       void FillCategory(ref DropDownList ddlCategory);
       void FillSubcategory(ref DropDownList ddlSubcategory,string CategoryId);
    }
    public interface IAdmin1
    {
        void FillCategory(ref DropDownList ddlCategory);
        void FillSubcategory(ref DropDownList ddlSubcategory, string CategoryId);
    }
    //public class Jagan
    //{
    //    protected string qry
    //    {
            
    //    }
    //}

    public class CommonQry
    {
        protected string CategoryQry
        {
            get
            {
                StringBuilder strQry = new StringBuilder();
                strQry.Append(" Select CategoryId,CategoryName From Category where Status=1 ");
             

                return strQry.ToString();
            }
        }

        protected string SubcategoryQry
        {
            get
            {
                StringBuilder strQry = new StringBuilder();
                strQry.Append(" Select SubcategoryId,SubcategoryName From Subcategory Where CategoryId=@CategoryId And Status=1 ");


                return strQry.ToString();
            }
        }
    }

    public class CommonFunction : CommonQry, IAdmin
    {
        public CommonFunction()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Common Static Functions
        public static string ReplaceQuoteWithTild(string strName)
        {
            if (strName != "")
            {
                strName = strName.Replace("'", "~");
            }
            return strName;
        }

        public static string ReplaceTildWithQuote(string strName)
        {
            if (strName != "")
            {
                strName = strName.Replace("~", "'");
            }
            return strName;
        }

        public static string GetCoursecode(string strName)
        {
            if (strName == "" || strName == null)
            {
                strName = "";
            }
            else
            {
                if (strName == "GRAPHIC DESIGN")
                {
                    strName = "CGD";
                }
                else if (strName == "WEB DESIGN")
                {
                    strName = "CWD";
                }
                else if (strName == "MAYA 3D DESIGN")
                {
                    strName = "Basic Maya";
                }
                else if (strName == "MAYA ADVANCE (MODELING,TEXTURING & LIGHTING)")
                {
                    strName = "MayaAdvanced";
                }
                else if (strName == "RIGGING & ANIMATION")
                {
                    strName = "MayaAdvanced";
                }
                else if (strName == "MAYA ADVANCE (DYNAMICS)")
                {
                    strName = "MayaAdvanced";
                }
                else if (strName == "VIDEO EDITING")
                {
                    strName = "Premiere";
                }
                else if (strName == "VISUAL EFFECTS")
                {
                    strName = "Combustion";
                }
                else if (strName == "FLASH SCRIPT")
                {
                    strName = "FlashScripting";
                }
                else if (strName == "3ds MAX (ARCHITECTURAL)")
                {
                    strName = "3DSMax";
                }
                else if (strName == "ELEARNING")
                {
                    strName = "C-Elearning";
                }
                else if (strName == "MOBILE GAMING")
                {
                    strName = "C-MGaming";
                }
                else
                {
                    strName = strName;
                }
            }
            return strName;
        }

        public static string DynamicString(int valLength)
        {
            string retString;
            retString = System.Guid.NewGuid().ToString();
            retString = retString.Replace("-", string.Empty);
            retString = retString.Substring(0, valLength);
            return retString;
        }

        public static int CheckIsInt(string Id)
        {
            int OutNo = 0;
            int.TryParse(Id, out OutNo);
            return OutNo;

            //int.TryParse(Id,
        }
        #endregion

        #region Admin Common Function
        void IAdmin.FillCategory(ref DropDownList ddlCategory)
        {
            try
            {
                DataTable dt;
                dt = ICATERP.DataAccess.ExecuteDataTable(ICATERP.DataAccess.ConnectionString,CategoryQry);

                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        void IAdmin.FillSubcategory(ref DropDownList ddlSubcategory, string CategoryId)
        {
            try
            {
                DataTable dt = null;

                if (CategoryId != "")
                {
                    SqlCommand Comm = new SqlCommand();
                    Comm.CommandText = SubcategoryQry;

                    Comm.Parameters.AddWithValue("@CategoryId", CategoryId);
                    dt = ICATERP.DataAccess.ExecuteDataTable(ICATERP.DataAccess.ConnectionString, Comm);
                }
                ddlSubcategory.DataSource = dt;
                ddlSubcategory.DataTextField = "SubcategoryName";
                ddlSubcategory.DataValueField = "SubcategoryId";
                ddlSubcategory.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


        public static void traceloginstatus(string userid, string centercode)
        {           
            string ipadd = HttpContext.Current.Request.UserHostAddress;
            try
            {
                string qry = "insert into erp_logintrace (userid,centercode,ipaddress,dateins) values ('" + userid + "','" + centercode + "','" + ipadd + "',getdate())";
                //HttpContext.Current.Response.Write(qry);
                ICATERP.DataAccess.ExecuteNonQuery(ICATERP.DataAccess.ConnectionString, qry);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Pleae Contact Admin");
            }
             
        }
   
    }
}