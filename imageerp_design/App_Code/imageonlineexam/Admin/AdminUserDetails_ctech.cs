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
/// Summary description for AdminUserDetails
/// </summary>
namespace MVC1
{
    public class AdminUserDetails_ctech
    {
        private string qry;
        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        public AdminUserDetails_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }

        #region Visibling The Controls
        public void CheckUser(Button btnSearch, TextBox txtSearch)
        {
            if (HttpContext.Current.Session["UserType"] != null)
            {
                string userType = HttpContext.Current.Session["UserType"].ToString();
                if (userType != "MASTER")
                {
                    btnSearch.Visible = false;
                    txtSearch.Visible = false;
                }
                else
                {
                    btnSearch.Visible = true;
                    txtSearch.Visible = true;
                }
            }

        }
        #endregion

        #region Fill UserDetails In The GridView
        public void GetAdminUserDetails(GridView grdUserDetails, TextBox txtSearch, Label lblNoOfRecords)
        {
            try
            {
                DataTable dt;
                string chkLoginId = "";
                if (HttpContext.Current.Session["UserType"] != null)
                {
                    string userType = HttpContext.Current.Session["UserType"].ToString();
                    int userId = Convert.ToInt32(HttpContext.Current.Session["AdUserId"].ToString());

                    if (userType != "MASTER")
                    {
                        chkLoginId = " And L.loginId=" + userId + "";
                    }
                }


                qry = " SELECT L.loginId,REPLACE(L.userName,'~','''')as userName, REPLACE(L.password,'~','''')as password,L.centreId,REPLACE(C.centreLocation,'~','''')as location,";
                qry += "Case IFNULL(L.status,1) When 1 THEN 'Enabled' Else 'Disabled' End as dispStatus,UserType";
                qry += " From Exam_AdminLogin L Inner JOIN ";
                qry += " Exam_CentreDetails C ON C.centreId=L.centreId And C.status=1 " + chkLoginId + " ";
                qry += " Where (L.userName LIKE  '%" + SiteFunctions.databaseset(txtSearch.Text) + "%') OR L.centreId IN( Select S.centreId From Exam_CentreDetails S Where S.centreLocation LIKE '%" + SiteFunctions.databaseset(txtSearch.Text) + "%' )   ";
                qry += " Order By L.dateMod Desc";
                //HttpContext.Current.Response.Write(qry);

                dt = FillDataControls.FillGridView(qry, grdUserDetails);
                lblNoOfRecords.Text = dt.Rows.Count.ToString();

                if (dt.Rows.Count > 0 && HttpContext.Current.Session["UserType"] != null)
                {
                  VisibleLinkButton(grdUserDetails);
                }

            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Visibling The Controls Based On User Type
        private void VisibleLinkButton(GridView grdUserDetails)
        {
            foreach (GridViewRow Row in grdUserDetails.Rows)
            {
                string userType = HttpContext.Current.Session["UserType"].ToString();
                int userId = Convert.ToInt32(HttpContext.Current.Session["AdUserId"].ToString());

                //HttpContext.Current.Response.Write("userType" + userType +"</br>");
               // HttpContext.Current.Response.Write("userId" + userId + "</br>");
                if (userType == "MASTER")
                {
                    ((LinkButton)Row.FindControl("lnkEdit")).Visible = true;
                    ((LinkButton)Row.FindControl("lnkDelete")).Visible = true;
                }
                else
                {
                    int chkUserId =Convert.ToInt32(grdUserDetails.DataKeys[Row.RowIndex].Value);
                    //HttpContext.Current.Response.Write("chkUserId" + chkUserId + "</br>");
                    if (chkUserId == userId)
                    {
                        ((LinkButton)Row.FindControl("lnkEdit")).Visible = true;
                        ((LinkButton)Row.FindControl("lnkDelete")).Visible = false;
                    }
                    else
                    {
                        ((LinkButton)Row.FindControl("lnkEdit")).Visible = false;
                        ((LinkButton)Row.FindControl("lnkDelete")).Visible = false;
                    }
                  

                }
            }
        }
        #endregion

    }
}
