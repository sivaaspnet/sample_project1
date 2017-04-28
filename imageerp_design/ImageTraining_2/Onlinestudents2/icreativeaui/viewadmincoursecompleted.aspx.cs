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
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Mail;

public partial class Onlinestudents2_Default2 : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, CentreCount, CentreCode, enqno, dob1,chk1="";
    string inv_id = "";
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
  
   
   
    

    public void fillgrid()
    {
        string fromdate = "";
        string todate = "";
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            string str = txtfromdate.Text;
            string[] split = str.Split('-');
            fromdate = split[1] + "-" + split[0] + "-" + split[2];

            string str1 = txttodate.Text;
            string[] split1 = str1.Split('-');
            todate = split1[1] + "-" + split1[0] + "-" + split1[2];
            
        }
        _Qry = @"select distinct studentid,centre_code,softwarestatus,Module_Name,Software_Name from erp_oldbatchdetails old inner join Onlinestudent_Software new on  old.Software_id=new.Software_Id inner join Add_moduledetails a on old.moduleid=a.Module_Id where studentid not in (select studentid from erp_batchschedule where centrecode='" + Session["SA_centre_code"].ToString() + "') and centre_code='" + Session["SA_centre_code"].ToString() + "'";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }


    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Bookrequest.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
        
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
   
}

