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
        if (Request.QueryString["res"] == "ins")
        {
            lblmessage.Text = "The Follow up Details Inserted Successfully";
        }
        if (Session["SA_Centrerole"] .ToString() == "Ipad")
        {
            viewonly_to_sa.Visible = false;//row id
            //ddl_sa_cencode.Visible = true;
            if (!IsPostBack)
            {
                fill_cencode();//fill centre code
            }
        }
        else
        {
            viewonly_to_sa.Visible = false;
        }

       
    }

   

   private void fillgrid()
    {

        string headCentrecode = ConfigurationManager.AppSettings["Ipadcentrecode"].ToString();
        _Qry = @"select f2.centre_code,enq.enq_personal_mobile,enq.enq_personal_email,c.program ,f2.Created_By,enq.enq_number, enq.enq_number 
 as enqno,enq.enq_number,enq_personal_name,enq_enqstatus,
convert(varchar, f2.dateins, 103) as dateins 
from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_number=f2.enq_number 
 and enq.centre_code=f2.centre_code left join adm_generalinfo as adm on
 enq.enq_number=adm.enq_number  inner join  img_coursedetails as c on
 c.course_id=f2.enq_coursepositioned  ";

        if (Session["SA_centre_code"].ToString() == headCentrecode)
        {

            _Qry = _Qry + " where  f2.centre_code in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode + "')";
        }
        //Response.Write(_Qry);
       // Response.End();
        //else
        //{
        //    _Qry = _Qry + " where f2.centre_code ='" + Session["SA_centre_code"] + "'";
        //}



        if (txtkeyword.Text.Trim() != "")
        {
            _Qry += " and (enq.enq_number like '%" + txtkeyword.Text.Trim() + "%' or enq_personal_name like '%" + txtkeyword.Text.Trim() + "%' )";
        }
            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];
 
                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + "and f2.dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
            }
            _Qry = _Qry + " order by enq.enq_id desc";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            //Response.Write(_Qry);
            //Response.End();

            int ii = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                string Enq_Number = dt.Rows[ii]["enq_number"].ToString();

                _Qry = "Select count(*) from adm_personalparticulars where enq_number='" + Enq_Number + "'";
                int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count > 0)
                {
                    DropDownList ddlstatus = new DropDownList();
                    ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
                    ddlstatus.Visible = false;

                    Label lblstatus = new Label();
                    lblstatus = (Label)row.FindControl("hdnstatus");
                    lblstatus.Visible = true;
                    string lbl = ((Label)row.FindControl("hdnstatus")).Text;

                    Button btnupd = new Button();
                    btnupd = (Button)row.FindControl("btnupd");
                    btnupd.Visible = false;
                }
                else
                {
                    DropDownList ddlstatus = new DropDownList();
                    ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
                    ddlstatus.Visible = true;

                    Label lblstatus = new Label();
                    lblstatus = (Label)row.FindControl("hdnstatus");
                    lblstatus.Visible = false;

                    Button btnupd = new Button();
                    btnupd = (Button)row.FindControl("btnupd");
                    btnupd.Visible = true;


                    string lbl = ((Label)row.FindControl("hdnstatus")).Text;

                    ddlstatus.SelectedValue = lbl;
                }
                ii = ii + 1;
            }
           
       
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
            string lbl = ((Label)row.FindControl("lblhdnmsg")).Text;
            _Qry = "Select count(*) from adm_personalparticulars where enq_number='" + lbl + "'";
                int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count == 0)
                {
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
                            _Qry = "update img_enquiryform1 set enq_enqstatus='" + ddlsta.SelectedValue + "' where enq_number='" + lbl + "'";
                            //Response.Write(_Qry);
                            //Response.End();
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            fillgrid();
                            lblmessage.Text = "The Enquiry Status has been Updated Successfully";
                        }
                    }
                }
        }
        //Response.End();
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    private void disablelink()
    {
        _Qry = "SELECT ifnull(adm.enq_number,0),case isnull(adm.enq_number,0) when '0' THEN enq.enq_number ELSE  ('<a> rel=''modal[]'' href=''WelcomeAdmission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') end  as enqno  from img_enquiryform AS enq LEFT join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.enq_number='"+hdnenqID.Value+"'";
   
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
       
    }
    private void fill_cencode()
    {
        //for super admin
        _Qry = "SELECT centre_code from img_centredetails group by centre_code";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_sa_cencode.DataSource = dt;
        ddl_sa_cencode.DataValueField = "centre_code";
        ddl_sa_cencode.DataTextField = "centre_code";
        ddl_sa_cencode.DataBind();
        ddl_sa_cencode.Items.Insert(0, new ListItem("Select", ""));
    }





    protected void LnkDownlaodExcel_Click(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "Ipad")
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Imagedoc.xls");
            Response.Charset = "";
         
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        
            GridView2.RenderControl(htmlWrite);

            

            Response.Write(stringWrite.ToString());
            Response.End();


           
        }
        else
        {
            lblmessage.Text = "Please Contact Admin";
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */

    }
}
