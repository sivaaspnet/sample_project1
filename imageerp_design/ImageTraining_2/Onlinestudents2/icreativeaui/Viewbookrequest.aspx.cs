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

public partial class ImageTraining_2_Onlinestudents2_superadmin_Viewbookrequest : System.Web.UI.Page
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
    }

    public void fillgrid()
    {
        _Qry = @"select distinct br.studentid,adm.enq_personal_name,br.courseid,cou.program,br.requested_date,br.status from book_request br inner join
adm_personalparticulars adm on adm.student_id=br.studentid inner join img_coursedetails cou on cou.course_id=br.courseid";
        DataTable d1 = new DataTable();
        d1 = MVC.DataAccess.ExecuteDataTable(_Qry);


        _Qry = "select br.studentid ,br.bookid,br.courseid,br.requested_date,bd.bookname from book_request br inner join bookdetails bd on br.bookid=bd.bookid";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

        DataTable status = new DataTable();

        status.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("enq_personal_name", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("program", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("bookname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("courseid", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("requested_date", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();
        foreach (DataRow drs in d1.Rows)
        {
            dr = status.NewRow();
            dr["status"] = drs["status"];
            dr["requested_date"] = drs["requested_date"];
            dr["program"] = drs["program"];
            dr["courseid"] = drs["courseid"];
            dr["studentid"] = drs["studentid"];
            dr["enq_personal_name"] = drs["enq_personal_name"];
            
            dr["bookname"] = getbook(dt1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "'and requested_date='" + drs["requested_date"] + "'", "bookname");
            status.Rows.Add(dr);
        }
            GridView1.DataSource = status;
            GridView1.DataBind();
        
    }

    string getbook(DataTable dtexp, string expression, string column)
    {
        string book = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                if (book == "")
                {
                    book = (val[column].ToString());
                }
                else if (book == (val[column].ToString()))
                {
                    book = (val[column].ToString());

                }
                else
                {
                    book = book + "," + (val[column].ToString());
                }

            }

        }
        return book.ToString();
    }
}
