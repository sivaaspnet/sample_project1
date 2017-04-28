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

public partial class Onlinestudents2_superadmin_NonBatchedAlert : System.Web.UI.Page
{
    string _qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            FillGrid();
            Fillsearchcourse();
        }
    }

    private void Fillsearchcourse()
    {
        _qry = "select Course_Code,Course_Id from onlinestudent_course order by Course_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        ddlsearchcourse.DataSource = dt1;
        ddlsearchcourse.DataValueField = "Course_Id";
        ddlsearchcourse.DataTextField = "Course_Code";
        ddlsearchcourse.DataBind();
        ddlsearchcourse.Items.Insert(0, new ListItem("Select", ""));
    }

    private void FillGrid()
    {
        string CurrentModule = "";
        string NextModule = "";

        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add();
        dt.Columns.Add("Student ID", typeof(string));
        dt.Columns.Add("Student Name", typeof(string));
        dt.Columns.Add("Track", typeof(string));
        dt.Columns.Add("Course", typeof(string));
        dt.Columns.Add("Waiting For", typeof(string));

        _qry = "Select G.student_id,(P.enq_personal_name+' '+student_lastname) as StudentName ,G.Track1,cou.program,cou.course_id from img_coursedetails cou inner join ";
        _qry += " adm_generalinfo G on G.coursename= cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id ";
        _qry += " Where G.Student_Id Not In (Select Batch_StudentId From Batch_Details) ";
        _qry += " And G.centre_code='" + Session["SA_centre_code"] + "' ";
        

        if (ddlsearchcourse.SelectedValue == "" || ddlsearchcourse.SelectedValue == null)
        {

        }
        else
        {
            _qry += " And cou.program='" + ddlsearchcourse.SelectedItem.Text + "'";
        }
        _qry = _qry + " And (Select enq_enqstatus from img_enquiryform1 Where img_enquiryform1.enq_number=P.enq_number)<>'Dropped'";
        _qry += " GROUP by G.student_id,P.student_id,P.enq_personal_name,student_lastname,G.Track1,cou.program,cou.course_id";
        _qry += " order by Cou.Course_id";

        //Response.Write(_qry);
        //Response.End();
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            //dr1[4] = dt1.Rows[i]["course_id"].ToString();
          
                _qry = "Select Top 1 Module_Content From Onlinestudent_Coursesoftware where Course_Id=";
                _qry += " (select I.Course_Id from Onlinestudent_Course I inner join img_coursedetails c on";
                _qry += " I.Course_Code=C.Program where C.Course_Id='" + dt1.Rows[i]["course_id"].ToString() + "') And ";
                _qry += " Module_Content Not In(Select Batch_Module_Content From batch_details where Batch_studentid='" + dt1.Rows[i]["student_id"].ToString() + "') ";

                DataTable dt3 = new DataTable();
                dt3 = MVC.DataAccess.ExecuteDataTable(_qry);
                if (dt3.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = dt1.Rows[i]["student_id"].ToString();
                    dr1[1] = dt1.Rows[i]["StudentName"].ToString();
                    dr1[2] = dt1.Rows[i]["Track1"].ToString();
                    dr1[3] = dt1.Rows[i]["program"].ToString();
                    dr1[4] = dt3.Rows[0]["Module_Content"].ToString();
                    dt.Rows.Add(dr1);
                }
                
        }

        //Response.End();

        if (dt.Rows.Count > 0)
        {
            //GridView1.PageSize = dt.Rows.Count;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    FillGrid();
    //}
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}
