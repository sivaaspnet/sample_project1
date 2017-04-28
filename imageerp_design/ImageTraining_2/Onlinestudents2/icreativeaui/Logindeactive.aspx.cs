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

public partial class superadmin_ViewEnquiry : System.Web.UI.Page
{
    string _Qry;
    DataTable dtgrid = new DataTable();
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
       
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
          
            //ddl_sa_cencode.Visible = true;
            if (!IsPostBack)
            {
               
            }
        }
        else
        {
            
        }

       
    }



    private void fillgrid()
    {

        _Qry = @"select * from img_centrelogin where centre_code='" + Session["SA_centre_code"] + "'";

        DataTable dtgrid = new DataTable();
        dtgrid = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dtgrid;
            GridView1.DataBind();
  
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void btnupd_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            string lbl = ((HiddenField)row.FindControl("HiddenField1")).Value;
           
                    DropDownList ddlsta = new DropDownList();
                    ddlsta = (DropDownList)row.FindControl("ddlfollowstatus");
                    //Response.Write("Status Is:" + ddlsta.SelectedValue);
                    //Response.Write("Msg Is:" + lbl);

                    if (ddlsta.Visible == true)
                    {
                        if (ddlsta.SelectedValue == "0" || ddlsta.SelectedValue == "" || ddlsta.SelectedValue == null)
                        {
                            Response.Write("");
                        }
                        else
                        {
                            _Qry = "update img_centrelogin set status='" + ddlsta.SelectedValue + "' where centrelogin_id=" + lbl + "";
                            //Response.Write(_Qry);
                            //Response.End();
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            fillgrid();
                            lblmessage.Text = "The Login Status has been Updated Successfully";
                        }
                    }
             
        }
        //Response.End();
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }






   
}
