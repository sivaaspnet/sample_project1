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

public partial class superadmin_ViewReport : System.Web.UI.Page
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
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            viewonly_to_sa.Visible = true;//row id
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
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            //viewonly_to_sa.Visible = true;
            //ddl_sa_cencode.Visible = true;
            //_Qry = "select enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 3) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + ddl_sa_cencode.SelectedValue + "' ";

            _Qry = "select enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 3) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + ddl_sa_cencode.SelectedValue + "'";

            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

                _Qry = _Qry + "and f2.dateins between ('" + dateFrom + "') and ('" + dateTo + "')";
            }
            if (ddl_sa_cencode.SelectedValue != "" && ddl_sa_cencode.SelectedValue != null)
            {
                _Qry = _Qry + "and f2.centre_code like '%" + ddl_sa_cencode.SelectedValue + "%'";
            }
            _Qry = _Qry + " Order By enq.enq_id desc";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
           
            
        }
        else
        {
            

           //string _Qry100 = " select '<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>' as enqno from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number";
           // Response.Write(_Qry100);
           // Response.End();
            _Qry = "select enq.enq_number,case isnull(adm.enq_number,0) when '0' THEN ('<a href=''Admission.aspx?end_id='+enq.enq_number+'&iframe=true&amp;width=600&amp;height=325'' class=''link''>'+enq.enq_number+'</a>') ELSE  adm.enq_number end  as enqno,enq_personal_name,enq_enqstatus,convert(varchar, f2.dateins, 3) as dateins from img_enquiryform enq join img_enquiryform1 f2 on enq.enq_id=f2.enq_id left join adm_generalinfo as adm on enq.enq_number=adm.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";

            //  _Qry = "SELECT enq.enq_number,f1.enq_personal_name,enq.enq_enqstatus,enq.dateins,case when  ifnull(nri.enq_number,0) = '0' THEN case when  ifnull(adm.enq_number,0) = '0' THEN CONCAT('<a  href=''Admission.aspx?end_id=',enq.enq_number,'&iframe=true&amp;width=600&amp;height=325'' class=''link''>',enq.enq_number,'</a>')  ELSE  enq.enq_number end ELSE enq.enq_number   end as enqno from img_enquiryform1 enq inner join img_enquiryform f1 on enq.enq_number=f1.enq_number LEFT join adm_generalinfo adm on enq.enq_number=adm.enq_number LEFT join adm_nridetails nri on enq.enq_number=nri.enq_number where enq.centre_code='" + Session["SA_centre_code"] + "'";

            if (txtfromcalender.Text != "" && txttocalender.Text != "")
            {
                string str = txtfromcalender.Text;
                string[] split = str.Split('-');
                string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

                string str1 = txttocalender.Text;
                string[] split1 = str1.Split('-');
                string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
                _Qry = _Qry + "and f2.dateins between ('" + dateFrom + "') and ('" + dateTo + "')";
            }
            _Qry = _Qry + " Order By enq.enq_id desc";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //Response.Write(_Qry);
            //Response.End();
           
        }
        
        foreach (GridViewRow row in GridView1.Rows)
        {

            DropDownList ddlstatus = new DropDownList();
            ddlstatus = (DropDownList)row.FindControl("ddlfollowstatus");
            string lbl = ((Label)row.FindControl("hdnstatus")).Text;

            ddlstatus.SelectedValue = lbl;
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
            DropDownList ddlsta = new DropDownList();
            ddlsta = (DropDownList)row.FindControl("ddlfollowstatus");
            string lbl = ((Label)row.FindControl("lblhdnmsg")).Text;
            
            if (ddlsta.SelectedValue == "0")
            {
                Response.Write("");
            }
            else
            {
                _Qry = "update img_enquiryform1 set enq_enqstatus='"+ddlsta.SelectedValue+"' where enq_number='" + lbl + "'";
                //Response.Write(_Qry);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmessage.Text= "The Enquiry Status has been Updated Successfully";
            }
        }
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


    protected void ddl_sa_cencode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   }
