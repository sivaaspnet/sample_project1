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
      
        //  fillcoursedropdown();
            if (Request.QueryString["studentid"] != null)
            {
                tab2.Visible = true;
                tab1.Visible = false;
                getdetails();
                
            }
        
        }

    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_studentid.Text);
    }
    protected void Validate_Special2(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(searchbox.Text);
    }
     protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = true;
            _Qry = "select count(student_id) from adm_personalparticulars where student_id='" + txt_studentid.Text.Trim() + "' and centre_Code='" + Session["SA_centre_code"] + "' and studentstatus='active'";
            int count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count1 > 0)
            {

                //_Qry = "select coursecode,program,course_id,year from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid where centercode='" + Session["SA_centre_code"] + "' and studentid='" + txt_studentid.Text + "' and status='active'";
                // _Qry = "select a.invoiceId,b.coursecode,b.program,b.course_id,year,a.courseFees,cast(cast(sum(c.amount) as decimal(9,2)) AS FLOAT) as Amount_Paid,cast(cast(avg(a.coursefees-c.amount) as decimal(9,2)) AS FLOAT) as Pending from erp_invoicedetails a inner join img_coursedetails  b on   b.course_id=a.courseid inner join erp_receiptdetails c on a.studentId=c.studentId where a.centercode='" + Session["SA_centre_code"] + "' and a.studentid='" + txt_studentid.Text.Trim() + "' and a.status='active' group by a.courseFees,c.amount,b.coursecode,b.program,b.course_id,a.invoiceId,year";
                _Qry = @"select enq_personal_name,courseid,invoiceId,program,sum(rep.amount) as Amount_Paid ,inv.coursefees,inv.courseid,(inv.coursefees-sum(rep.amount))as pending from erp_receiptdetails rep
inner join erp_invoicedetails inv on inv.studentid=rep.studentid and inv.status='active'
inner join img_coursedetails cou on cou.course_id=inv.courseid inner join adm_personalparticulars adm on adm.student_id=inv.studentid
where rep.centercode='" + Session["SA_centre_code"] + "' and rep.studentid='" + txt_studentid.Text.Trim() + "' and rep.invoiceno=inv.invoiceid group by inv.coursefees ,inv.courseid,program,invoiceId,enq_personal_name";

                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {

                    Label1.Visible = false;
                    Label14.Text = dt.Rows[0]["program"].ToString();
                    invoice.Text = dt.Rows[0]["invoiceId"].ToString();
                    HiddenField1.Value = dt.Rows[0]["courseid"].ToString();
                    HiddenField2.Value = txt_studentid.Text;
                    HiddenField3.Value = dt.Rows[0]["invoiceId"].ToString();
                    Label4.Text = dt.Rows[0]["enq_personal_name"].ToString();
                    link1.HRef = "InvoiceDetails.aspx?invno=" + invoice.Text + "";
                    //  HiddenField2.Value = dt.Rows[0]["year"].ToString();
                    fillbook();


                }
                else
                {
                    Label1.Text = "Contact Admin";
                }

            }
            else
            {
                Label1.Text = "Student Dropped from ERP System,Contact Admin";

                tr1.Visible = false;
                tr2.Visible = false;
                tr3.Visible = false;
                t4.Visible = false;
                t5.Visible = false;
                t6.Visible = false;

            }
        }
       
    }
    //public void pending()
    //{
    //    _Qry = "select a.courseFees,cast(cast(sum(b.amount) as decimal(9,2)) AS FLOAT)as Amount_Paid,a.coursefees-b.amount as Pending from erp_invoicedetails a inner join erp_receiptdetails b on a.studentId=b.studentId where a.studentid='" + txt_studentid.Text + "' group by a.courseFees,b.amount ";
    //    DataTable dtab = new DataTable();
    //    dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    if (dtab.Rows.Count > 0)
    //    {
    //        Session["a"] = dtab.Rows[0]["courseFees"].ToString();
    //        Session["b"] = dtab.Rows[0]["Amount_Paid"].ToString();
    //        //Response.Write(Session["a"].ToString() + "<br/>");
    //        //Response.Write(Session["b"].ToString());
    //        if ((Session["a"].ToString()) == (Session["b"].ToString()))
    //        {
    //            Fees_pending.Text = "No";
    //            Amount_paid.Text = dtab.Rows[0]["Amount_Paid"].ToString();
    //            Pending_Amt.Text = "Nil";
    //            ddl_course.Visible = true;
    //            fillcourse();

    //        }
    //        else
    //        {
    //            Fees_pending.Text = "Yes";
    //            Amount_paid.Text = dtab.Rows[0]["Amount_Paid"].ToString();
    //            Pending_Amt.Text = dtab.Rows[0]["Pending"].ToString();
    //            ddl_course.Visible = false;
    //        }
    //    }
    //}

    public void fillbook()
    {
        _Qry = "select * from Onlinestudent_Coursebook where Course_Id='" + HiddenField1.Value + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CheckBoxList1.Items.Clear();
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = "book_content";
            CheckBoxList1.DataValueField = "book_Id";
            CheckBoxList1.DataBind();
        }

    }


    protected void Button3_Click(object sender, EventArgs e)
    {

    }

    public void insert()
    {
      int i;
      soft1();
      string str = TextBox1.Text;
      string[] split = str.Split('-');
      string requestdate = split[2] + "-" + split[1] + "-" + split[0];
      _Qry = "select studentid,courseid,bookid from book_request where studentid='" + txt_studentid.Text + "' and courseid='" + HiddenField1.Value + "' and bookid in("+chk1+")";
      DataTable dt = new DataTable();
      dt = MVC.DataAccess.ExecuteDataTable(_Qry);
      //Response.Write(_Qry);
      if (dt.Rows.Count <= 0)
      {
          for (i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
          {
              if (CheckBoxList1.Items[i].Selected == true)
              {

                  _Qry = "insert into Book_Request(studentid,centrecode,bookid,courseid,requested_date,status,bookstatus)values('" + txt_studentid.Text + "','" + Session["SA_centre_code"] + "','" + CheckBoxList1.Items[i].Value + "','" + HiddenField1.Value + "','" + requestdate + "','Pending','Pending')";
                  MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                  //Response.Write(_Qry);
              }
          }
          Label1.Visible = true;
          Label1.Text = "Books are assigned successfully";
          tr1.Visible = false;
          tr2.Visible = false;
          tr3.Visible = false;
          t4.Visible = false;
          t5.Visible = false;
          t6.Visible = false;
          txt_studentid.Text = "";
          TextBox1.Text = "";
          CheckBoxList1.Items.Clear();
        
      }
      else
      {
          Label1.Visible = true;
          Label1.Text = "Books are already assigned to this student";
      }


       
    }
    protected void btnsubmit5_Click(object sender, EventArgs e)
    {
        insert();
   
    }

    public void getdetails()
    {
        string reqdate="";
        if (Request.QueryString["request"] != null)
        {
             reqdate = Request.QueryString["request"].ToString();
            string smon = reqdate.Split('/')[1].ToString();
            string sdat = reqdate.Split('/')[0].ToString();
            string syear = reqdate.Split('/')[2].ToString();

            reqdate = smon + "/" + sdat + "/" + syear;
        }
        _Qry = @"select distinct br.studentid,adm.enq_personal_name,br.courseid,cou.program,bd.bookname,br.requested_date from book_request br inner join
adm_personalparticulars adm on adm.student_id=br.studentid inner join img_coursedetails cou on cou.course_id=br.courseid inner join bookdetails bd on bd.bookid=br.bookid where br.studentid='" + Request.QueryString["studentid"].ToString() + "'and br.courseid='" + Request.QueryString["course"].ToString() + "'and br.requested_date='" + reqdate.ToString() + "' ";

       //// Response.Write(_Qry);
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

 

        if (dt.Rows.Count > 0)
        {
            Label13.Text = dt.Rows[0]["studentid"].ToString();
            Label3.Text = dt.Rows[0]["enq_personal_name"].ToString();
            Label7.Text = dt.Rows[0]["program"].ToString();
            Label10.Text = dt.Rows[0]["requested_date"].ToString();
            Label11.Text = getbook(dt, "studentid='" + dt.Rows[0]["studentid"].ToString() + "'and program='" + dt.Rows[0]["program"].ToString() + "'and requested_date='" + dt.Rows[0]["requested_date"].ToString() + "'", "bookname");
            HiddenField4.Value = dt.Rows[0]["courseid"].ToString();
        }
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


    protected void Button6_Click(object sender, EventArgs e)
    {
         string str=DateTime.Now.ToString("MM-dd-yyyy");
         if (DropDownList1.SelectedValue.ToString() == "Approved")
         {

             _Qry = "update book_request set status='" + DropDownList1.SelectedValue.ToString() + "',approved_date='" + str + "' where studentid='" + Label13.Text + "'and courseid='" + HiddenField4.Value + "' and requested_date='" +Label10.Text+ "'";
             MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
             
         }
         else
             if (DropDownList1.SelectedValue.ToString() == "Rejected")
             {

                 _Qry = "update book_request set status='" + DropDownList1.SelectedValue.ToString() + "',approved_date='" + str + "',Reason='" + TextBox2.Text+ "' where studentid='" + Label13.Text + "'and courseid='" + HiddenField4.Value + "'";
                 MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                
             }
         Label2.Text = "Submitted successfully";
         tab1.Visible = false;
         tab2.Visible = true;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "Rejected")
        {
            tr10.Visible = true;
        }
        else
        {
            tr10.Visible = false;
        }
    }
    public void soft1()
    {
        int n;
        for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
        {
            if (CheckBoxList1.Items[n].Selected)
            {

                if (chk1 == "")
                {
                    chk1 = CheckBoxList1.Items[n].Value;
                }
                else
                {
                    chk1 = chk1 + "," + CheckBoxList1.Items[n].Value;
                }

            }

            //}
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
        _Qry = @"select distinct br.studentid,adm.enq_personal_name,br.courseid,cou.program,convert(varchar,br.requested_date,103) as requested_date,br.status from book_request br inner join
adm_personalparticulars adm on adm.student_id=br.studentid inner join img_coursedetails cou on cou.course_id=br.courseid where br.centrecode='" +Session["SA_centre_code"].ToString()+"'";
        if (fromdate != "" && todate != "")
        {
            _Qry += " and convert(varchar,br.requested_date,105) between '" + fromdate + "' and '" + todate + "'";
        }
        if (searchbox.Text != "")
        {
            _Qry += " and (br.studentid='" + searchbox.Text + "' or adm.enq_personal_name='" + searchbox.Text + "')";
        }
        DataTable d1 = new DataTable();
        d1 = MVC.DataAccess.ExecuteDataTable(_Qry);


        _Qry = "select br.studentid ,br.bookid,br.courseid,convert(varchar,br.requested_date,103) as requested_date,bd.bookname from book_request br inner join bookdetails bd on br.bookid=bd.bookid where br.centrecode='" + Session["SA_centre_code"].ToString() + "'";
        if (fromdate != "" && todate != "")
        {
            _Qry += " and convert(varchar,br.requested_date,105) between '" + fromdate + "' and '" + todate + "'";
        }
        //Response.Write(_Qry);
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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }
    }
}

