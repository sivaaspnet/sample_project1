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

public partial class superadmin_ProjectAssesment : System.Web.UI.Page
{
    string _Qry,_Qry1,_Qry2,_Qry3,_qry,centreid,batchcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {

            fillgrid1();
                Fillsearchmodule();
               
            
            
        }
    }


    private void Fillsearchmodule()
    {
        _qry = "select module_content,module_Id from module_details order by Module_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);
        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_Id";
        ddlsearchmodname.DataTextField = "module_content";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
       
    }

  
 
   
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
  
    private void fillgrid1()
    { 
        _Qry = "select * from view_progress where centrecode='" + Session["SA_centre_code"] + "' ";
        if(ddlsearchmodname.SelectedValue!="")
        {
            _Qry+=" and moduleid='"+ddlsearchmodname.SelectedValue+"' ";
        }
        if(ddlstatus.SelectedValue!="")
        {
            _Qry+=" and status ='"+ddlstatus.SelectedValue+"' ";
        }
       
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid1();
    }

  

   

}
