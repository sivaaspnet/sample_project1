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
/// Summary description for Centredetails
/// </summary>
namespace MVC1
{
    public class Centredetails_ctech
    {
        private string qry;
        private string _sqlConn = "";
        MySqlConnection mySqlConn = null;

        public Centredetails_ctech()
        {
            _sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            mySqlConn = new MySqlConnection(_sqlConn);
        }

        #region Make Disable the Submit Button
        public void CheckUser(Button btnSubmit, Label lblAuth, Button btnSearch, TextBox txtSearch)
        {
            if (HttpContext.Current.Session["UserType"] != null)
            {
                string userType = HttpContext.Current.Session["UserType"].ToString();
                if (userType != "MASTER")
                {
                    btnSubmit.Enabled = false;
                    lblAuth.Visible = true;

                    btnSearch.Visible = false;
                    txtSearch.Visible = false;
                }
                else
                {
                    btnSubmit.Enabled = true;
                    lblAuth.Visible = false;

                    btnSearch.Visible = true;
                    txtSearch.Visible = true;
                }
            }
           
        }
        #endregion

        #region Getting Centre Details
        public void GetCentreDetails(GridView grdCentreDetails, TextBox txtSearch, Label lblNoOfRecords)
        {
            try
            {
                string chkCentre = "";
                if (HttpContext.Current.Session["UserType"] != null)
                {
                    string userType = HttpContext.Current.Session["UserType"].ToString();
                    int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());
                    if (userType != "MASTER")
                    {
                        chkCentre = " And C.centreId=" + centreId + " ";
                    }
                }

                DataTable dt;
                qry = " Select C.centreId,REPLACE(C.centreLocation,'~','''')as location, REPLACE(C.centrePassword,'~','''')as password,C.status, ";
                qry += " Case ifNull(C.status,1) When 1 Then 'Enabled' Else 'Disabled' End as dispStatus ";
                qry += " From Exam_CentreDetails C Where  ifNull(C.centreLocation,'') Like '%" + SiteFunctions.databaseset(txtSearch.Text) + "%'  " + chkCentre + "  ";
                qry += " Order By C.dateMod desc ";
                dt = FillDataControls.FillGridView(qry, grdCentreDetails);

                lblNoOfRecords.Text = dt.Rows.Count.ToString();

                if (dt.Rows.Count > 0 && HttpContext.Current.Session["UserType"] != null)
                {
                   
                        VisibleLinkButton(grdCentreDetails);
                }
            }
            catch (Exception ex)
            {
                SiteFunctions.Log(ex);
            }
        }
        #endregion

        #region Visibling The Controls Based On User Type
        private void VisibleLinkButton(GridView grdCentreDetails)
        {
            foreach (GridViewRow Row in grdCentreDetails.Rows)
            {
                string userType = HttpContext.Current.Session["UserType"].ToString();
                int centreId = Convert.ToInt32(HttpContext.Current.Session["CentreId"].ToString());

                //HttpContext.Current.Response.Write("userType" + userType +"</br>");
                // HttpContext.Current.Response.Write("userId" + userId + "</br>");
                if (userType == "MASTER")
                {
                    ((LinkButton)Row.FindControl("lnkEdit")).Visible = true;
                    ((LinkButton)Row.FindControl("lnkDelete")).Visible = true;
                }
                else
                {
                    int chkCentreId = Convert.ToInt32(grdCentreDetails.DataKeys[Row.RowIndex].Value);
                    //HttpContext.Current.Response.Write("chkUserId" + chkUserId + "</br>");
                    if (chkCentreId == centreId)
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