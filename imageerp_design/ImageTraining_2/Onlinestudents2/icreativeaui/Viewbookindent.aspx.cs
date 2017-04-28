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


public partial class superadmin_Course_New : System.Web.UI.Page
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
            fillcentre();
            fillgrid();
            fillgrid1();
        }
       
    }

    public void fillgrid()
    {
        _Qry = "select distinct bookname,(select count(bookid) from book_request where bookid=a.bookid group by bookid)as bookcount,(select count(bookstatus) from book_request where isnull(bookstatus,'')='Issued'and bookid=a.bookid)as bookissued,(select count(bookstatus) from book_request where bookstatus='Pending' and bookid=a.bookid )as bookpending from book_request a inner join bookdetails b on a.bookid=b.bookid where a.status='Approved'";
        if (DropDownList1.SelectedValue != "")
        {
            _Qry += "  and a.centrecode='" + DropDownList1.SelectedValue.ToString() + "'";
            
        }
    
          DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
               
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }

    private void fillcentre()
    {
        _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Centre_location";
        DropDownList1.DataValueField = "Centre_Code";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select", ""));
    }

    public void fillgrid1()
    {
        _Qry = @"select distinct br.studentid,adm.enq_personal_name,br.courseid,cou.program,convert(varchar,br.requested_date,103) as requested_date,br.status,convert(varchar,br.approved_date,103) as approved_date,(select count(bookid) from book_request where studentid=br.studentid and courseid=br.courseid and requested_date=br.requested_date)as bookcount,(select count(bookid) from book_request where bookstatus='Pending' and studentid=br.studentid and courseid=br.courseid and requested_date=br.requested_date) as pending,bd.bookname from book_request br inner join
adm_personalparticulars adm on adm.student_id=br.studentid inner join img_coursedetails cou on cou.course_id=br.courseid inner join bookdetails bd on br.bookid=bd.bookid where br.status='Approved'";
       
        
        if (TextBox1.Text != "")
        {
            _Qry += " and br.studentid='" + TextBox1.Text + "' or adm.enq_personal_name='" + TextBox1.Text + "' ";
          
          
        }
        if (TextBox3.Text != "")
        {
            _Qry += " and br.requested_date='" + TextBox3.Text + "'";

        }
        if (DropDownList2.SelectedValue.ToString() != "")
        {
            _Qry += " and br.bookstatus='" + DropDownList2.SelectedValue.ToString() + "'";

        }
        if (TextBox2.Text != "")
        {
            _Qry += " and bd.bookname='" + TextBox2.Text + "'";

        }
        DataTable d1 = new DataTable();
        d1 = MVC.DataAccess.ExecuteDataTable(_Qry);

       // _Qry = "select  distinct br.studentid,br.bookid,br.courseid,br.requested_date,bd.bookname from book_request br inner join bookdetails bd on br.bookid=bd.bookid";
        
       
        //DataTable dt1 = new DataTable();
        //dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);


        DataTable status = new DataTable();

        status.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("enq_personal_name", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("program", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("bookname", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("courseid", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("requested_date", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("approved_date", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("bookcount", System.Type.GetType("System.String")));
        status.Columns.Add(new DataColumn("pending", System.Type.GetType("System.String")));
        DataRow dr = status.NewRow();

        DataTable dtdistinct = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] args = new string[3];
        args[0] = "studentid";
        args[1] = "courseid";
        args[2] = "requested_date";        
        dtdistinct = d1.DefaultView.ToTable(true, args);


        foreach (DataRow drs in dtdistinct.Rows)
        {
            dr = status.NewRow();
            dr["status"] = getvalues(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "status");
            dr["requested_date"] = drs["requested_date"];
            dr["program"] = getvalues(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "program");
            dr["approved_date"] = getvalues(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "approved_date");
            dr["courseid"] = drs["courseid"];
            dr["studentid"] = drs["studentid"];
            dr["enq_personal_name"] = getvalues(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "enq_personal_name");
            dr["bookcount"] = getvalues(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "bookcount");
            dr["pending"] = getvalues(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "pending");
            dr["bookname"] = getbook(d1, "studentid='" + drs["studentid"] + "'and courseid='" + drs["courseid"] + "' and requested_date='" + drs["requested_date"] + "'", "bookname");
            status.Rows.Add(dr);
        }
    
        GridView2.DataSource = status;
        GridView2.DataBind();
    }

    string getvalues(DataTable dtexp, string expression, string column)
    {
        string book = "";
        DataRow[] dr = new DataRow[1000];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                book = val[column].ToString();
            }
        }
        return book;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid1();
    }
}
