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

public partial class superadmin_addcentre : System.Web.UI.Page
{
    DataTable dtexport = new DataTable();
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6,centreid;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        //string strIP;
        //strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        ////Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
        

            if (Session["SA_Centrerole"] == "SuperAdmin" || Session["SA_Centrerole"] .ToString() == "SuperAdmin")
            {
                saform.Visible = true;
            }
            else
            {
                saform.Visible = false;
            }
        if (!IsPostBack)
        {
            displaycourseonload();
            fillgrid();
            fillcentre();
        }
       
    }
    public void fillsoftware()
    {
        _Qry = "select distinct Software,Software_id from Submodule_details_new where ModuleId='" + ddl_coursename.SelectedValue + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            ddlsoftware.DataSource = dt;
            ddlsoftware.DataTextField = "Software";
            ddlsoftware.DataValueField = "Software_id";
            ddlsoftware.DataBind();
            ddlsoftware.Items.Insert(0, new ListItem("Select", ""));
        
    }
    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + ddl_Track.SelectedValue + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT Module_Id,Replace(Module_Content,'~','''') as Module_Content from Module_Details ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "Module_Id";
        ddl_coursename.DataTextField = "Module_Content";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }
    public void fillcentre()
    {
        _Qry = "select * from img_centredetails ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_centre.DataSource = dt;
        ddl_centre.DataTextField = "centre_location";
        ddl_centre.DataValueField = "centre_code";
        ddl_centre.DataBind();
        ddl_centre.Items.Insert(0, new ListItem("Select", ""));

    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _Qry = "select student_id from adm_personalparticulars where student_id='" + txtc_code.Text + "' and studentstatus='active' and centre_code='" + ddl_centre.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = "select studentid from erp_batchschedule where studentid='" + txtc_code.Text + "'  and centrecode='" + ddl_centre.SelectedValue + "' and moduleid='" + ddl_coursename.SelectedValue + "' ";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt1.Rows.Count > 0)
                {
                    lblmsg.Text = "Already  student is running in a batch";
                }
                else
                {
                    _Qry = "insert into erp_oldbatchdetails(studentid,moduleid,centre_code,status,Software_id,softwarestatus) values ('" + txtc_code.Text + "','" + ddl_coursename.SelectedValue + "','" + ddl_centre.SelectedValue + "','active','" + ddlsoftware.SelectedValue + "','" + ddlstatus.SelectedValue + "')";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    lblmsg.Text = "student Deactived from the module";
                    fillgrid();
                }
            }
            else
            {
                lblmsg.Text = "No record found";
            }
        }
    }

    private void fillgrid()
    {
//        _Qry = @"select distinct id,studentid,old.moduleid,centre_code,status,module,old.Software_id,software from erp_oldbatchdetails old right join Submodule_details_new mod on 
//mod.moduleid=old.moduleid";
        _Qry = "select adm.enq_personal_name,a.id,a.studentid,b.module_content,c.Software_Name,d.centre_location,a.status,a.softwarestatus from erp_oldbatchdetails a inner join module_details b on a.moduleid=b.module_Id inner join Onlinestudent_Software c on a.Software_id = c.Software_Id inner join img_centredetails d on a.centre_code=d.centre_code inner join adm_personalparticulars adm on adm.student_id=a.studentid where 1=1 ";
        if (Session["SA_Centrerole"] == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
        {
            _Qry += " and adm.centre_code='" + Session["SA_centre_code"].ToString() + "'";
        }
        if(TextBox1.Text!="")
        {
            _Qry += " and studentid like '%"+TextBox1.Text+"%' ";
        }
        
        _Qry += "order by id desc";

        dtexport = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dtexport;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
       
    }
    protected void ddl_coursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsoftware();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString().ToUpper().Trim() == "TECHNICAL HEAD" || Session["SA_Centrerole"] .ToString().ToUpper().Trim() == "TECHNICAL HEAD")
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[7].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Visible = false;
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "sedit")
        {
            btnsubmit.Visible = false;
            Button2.Visible = true;
            lblmsg.Visible = false;
           
          
//            _Qry = @"select distinct id,studentid,old.moduleid,centre_code,status,mod.module,old.Software_id,software from erp_oldbatchdetails old inner join Submodule_details_new mod on 
//mod.moduleid=old.moduleid and old.Software_id=mod.Software_id where id='"+e.CommandArgument.ToString()+ "'";
//           

            _Qry = "select * from erp_oldbatchdetails where id='"+e.CommandArgument.ToString()+"'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txtc_code.Text = dt.Rows[0]["studentid"].ToString();
                displaycourseonload();
                ddl_coursename.SelectedValue = dt.Rows[0]["moduleid"].ToString().Trim();
                fillsoftware();
                ddlsoftware.SelectedValue = dt.Rows[0]["Software_id"].ToString();
                ddl_centre.SelectedValue = dt.Rows[0]["centre_code"].ToString();
                ddlstatus.SelectedValue = dt.Rows[0]["softwarestatus"].ToString();
                ddlstatus.SelectedValue = dt.Rows[0]["status"].ToString();
                HiddenField3.Value = e.CommandArgument.ToString();
               
            }
           
            //Response.Write(dt.Rows[0]["moduleid"].ToString());
            //Response.End();
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtc_code.Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Write(HiddenField2.Value);
        _Qry = "update erp_oldbatchdetails set status='"+ddlstatus0.SelectedValue+"', studentid='" + txtc_code.Text + "',Software_id='" + ddlsoftware.SelectedValue.ToString() + "',moduleid='" + ddl_coursename.SelectedValue + "',centre_code='" + ddl_centre.SelectedValue+ "' ,softwarestatus='"+ddlstatus.SelectedValue+"' where id='" + HiddenField3.Value.ToString() + "' ";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
     //   Response.Write(_Qry);
        lblmsg.Visible = true;
        lblmsg.Text = "Updated sucessfully";
        fillgrid();
        Button2.Visible = false;
        btnsubmit.Visible = true;
        txtc_code.Text = "";
        ddlsoftware.SelectedValue = "";
        ddl_coursename.SelectedValue ="";
        ddlsoftware.Items.Clear();
        ddl_centre.SelectedValue = "";
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(dtexport);

    }
    public void ExportTableData(DataTable dtdata)
    {
        //string fname = "Monthlycollection of " + Session["SA_Location"] + " centre.xls";
        //string attach = "attachment;filename="+fname+" ";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attach);
        //Response.ContentType = "application/ms-excel";

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Bookdetails-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
}
