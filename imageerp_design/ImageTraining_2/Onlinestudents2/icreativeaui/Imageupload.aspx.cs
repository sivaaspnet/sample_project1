using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class superadmin_addcentre : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6,centreid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {
           fillgrid();
        }
       
    }
    public string removetilde(string str)
    {
        return MVC.CommonFunction.ReplaceTildWithQuote(str);
      
    }
    private void fillgrid()
    {

        // _Qry = "select b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code,b.centre_region,b.centre_category from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.role='CentreManager' and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchlocation.Text) + "%' and a.username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by centre_id desc";

        //_Qry = "select b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code,b.centre_region,b.centre_category from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.role='CentreManager' and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchlocation.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' and a.username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centre_id desc";

        _Qry = "select * from erp_homeimage";


        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();

    }
   
    
   
    private void refresh()
    {
        
       
        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (hdnID.Value.ToString() == "0")
        {
            lblmsg1.Text = "Please select banner to be updated.";

        }
        else
        {

            if (FileUpload1.FileName != "")
            {
                #region load
                string temp = FileUpload1.FileName;
                Random rand = new Random(9999);
                int code = rand.Next();
                temp = code + temp;
                string img = "~/ImageTraining_2/Onlinestudents2/icreative/images/" + temp;
                FileUpload1.SaveAs(Server.MapPath(img));
                // ImgLoad.ImageUrl = img;
                #endregion

                string _Qry = "UPDATE erp_homeimage SET imageurl='" + img + "' WHERE id='" + hdnID.Value + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                lblmsg1.Text = "Image Updated..";
                fillgrid();

                //btnUp.Visible = false;
            }
            else
            {
                lblmsg1.Text = "Please Select Image....";
            }
        }

    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "lnkedit")
        {
            _Qry = "select * from erp_homeimage where id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {

                Label5.Text = dt.Rows[0]["imagename"].ToString();
                hdnID.Value = dt.Rows[0]["id"].ToString();
        
              

                

            }

           

        }
    }
   
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        refresh();
    }
}
