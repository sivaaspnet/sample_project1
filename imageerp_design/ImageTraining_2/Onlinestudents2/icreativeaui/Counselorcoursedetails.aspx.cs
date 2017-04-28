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

public partial class superadmin_Counselorcoursedetails : System.Web.UI.Page
{

    string _Qry;
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        fillgrid();

        if (!IsPostBack)
        {
            fillcoursename();
            fillduration();
        }
    }
    void fillgrid()
    {
        //and username like '%" + obj.addTild(txtsearchname.Text) + "%'
        _Qry = "SELECT c1.program,c1.coursename,f1.duration,f1.track,f1.lump_sum,f1.instal_amount from img_coursedetails c1 JOIN img_centre_coursefee_details f1 on c1.course_id=f1.program and c1.status='active' and f1.status=1 where c1.course_id>0 ";
        if (ddlcourse.SelectedValue!= "")
        {
            _Qry = _Qry + "and c1.coursename like '%" + ddlcourse.SelectedItem + "%'";
        }
        if (ddduration.SelectedValue != "")
        {
            _Qry = _Qry + "and f1.duration like '%" + ddduration.SelectedItem + "%' ";
        }
        if (ddtrack.SelectedValue != "")
        {
            _Qry = _Qry + "and f1.track like '%" + ddtrack.SelectedItem + "%' ";
        }

        if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
        {
            _Qry = _Qry + " And centre_code='ICH-102' ";
        }
        else
        {
            _Qry = _Qry + " And centre_code='" + Session["SA_centre_code"].ToString() + "' ";
        }

        _Qry = _Qry + " Group By c1.course_id,c1.program,c1.coursename,f1.duration,f1.track,f1.lump_sum,f1.instal_amount";
       
     
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridviewcourse.DataSource = dt;
        Gridviewcourse.DataBind();
    }
    protected void Gridviewcourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridviewcourse.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
   private void fillcoursename()
    {
        _Qry = "select a.course_id,replace(a.coursename,'~','''') as coursename,b.program from img_coursedetails a inner join img_centre_coursefee_details b on a.course_id=b.program and a.status='active' and b.status=1 Group By a.Program,a.course_id,coursename,b.Program";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlcourse.DataSource = dt;
        ddlcourse.DataValueField = "course_id";
        ddlcourse.DataTextField = "coursename";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("Select", ""));
    }
   private void fillduration()
    {
        _Qry = "select program,replace(duration,'~','''') as duration from img_centre_coursefee_details Group By Program,duration";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddduration.DataSource = dt;
        ddduration.DataValueField = "program";//(course_id)program foreign key
        ddduration.DataTextField = "duration";
        ddduration.DataBind();
        ddduration.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(dt);
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
        Response.AppendHeader("Content-Disposition", "attachment;filename=coursedetails-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write("" + dc.ColumnName + "\t");
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
