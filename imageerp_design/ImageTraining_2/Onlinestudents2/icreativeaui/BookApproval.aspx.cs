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

public partial class Onlinestudents2_superadmin_BookApproval : System.Web.UI.Page
{
    string _Qry;
    int courseid;
    int getdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Request.QueryString["BookAppr"] == "Succ")
        {
            lblmsg.Text = "Book Sent Sucessfully";
        }
        if (!IsPostBack)
        {
            fillgrid();
            //filldropdown();
            //BookReq();

            //bookvis.Visible = true;

            //_Qry="Select Course_Id from Courseware_Course where CourseName='"+txtCourse.Text+"'";
            //SqlDataReader dr;
            //dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            //if (dr.HasRows)
            //{
            //    dr.Read();
            //    courseid = Convert.ToInt32(dr["Course_Id"]);
            //    dr.Close();
            //}

            ////Response.Write("CourseId:" + courseid);

            //_Qry = "Select Software_Id,SoftwareName from Courseware_Software where Course_Id=" + courseid + " ";
            //_Qry += "And Software_Id Not In(Select SoftwareId from Courseware where CourseId=" + courseid + ")";
            ////Response.Write(_Qry);
            ////Response.End();
            //DataTable dt = new DataTable();
            //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            //CheckBoxList1.DataSource = dt;
            //CheckBoxList1.DataTextField = "SoftwareName";
            //CheckBoxList1.DataValueField = "Software_Id";
            //CheckBoxList1.DataBind();

            ////for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            ////{
            ////    if (CheckBoxList1.Items[i].Selected)
            ////    {
            //        //_Qry = "Select DateIns from Courseware where StudentId='" + Request.QueryString["student_id"] + "' order by Courseware_Id desc";
            //        _Qry = "select Top 1 DATEDIFF(day, DateIns, GETDATE()) as DateCourseWare from Courseware where StudentId='" + Request.QueryString["student_id"] + "'";
            //        SqlDataReader dr2;
            //        dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            //        if (dr2.HasRows)
            //        {
            //            dr2.Read();
            //            getdate = Convert.ToInt32(dr2["DateCourseWare"]);
            //            if (getdate > 7)
            //            {
            //                CheckBoxList1.Enabled = true;
            //            }
            //            else
            //            {
            //                CheckBoxList1.Enabled = false;
            //            }
            //            dr2.Close();
            //        }
            //    }
            //}
        }
    }

    private void fillgrid()
    {
        _Qry = "Select Courseware_Id,StudentId,StudentName,(select CourseName from Courseware_Course where Course_id=Courseware.CourseId) as CourseName,";
        _Qry +=" (select SoftwareName from Courseware_Software where Software_Id=Courseware.SoftwareId) as SoftwareName,Bookstatus,ProcessDate,SentDate,ReceivedDate from courseware";
        _Qry += " Where StudentId='" + Request.QueryString["student_id"] + "'";

        //Response.Write("QUERY:" + _Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        string Bookstatus;
        int i=0;
        foreach (GridViewRow r in GridView1.Rows)
        {
            Bookstatus = dt.Rows[i]["Bookstatus"].ToString();
            if (Bookstatus == "Sent" || Bookstatus == "Received")
            {
                LinkButton lnksent = new LinkButton();
                lnksent = (LinkButton)r.FindControl("LinkButton2");
                lnksent.Visible = true;

                LinkButton lnkapprove = new LinkButton();
                lnkapprove = (LinkButton)r.FindControl("LinkButton1");
                lnkapprove.Visible = false;

                Label lblAppr = new Label();
                lblAppr = (Label)r.FindControl("lblApprove");
                lblAppr.Visible = false;
            }
            else if (Bookstatus == "Pending")
            {
                LinkButton lnksent = new LinkButton();
                lnksent = (LinkButton)r.FindControl("LinkButton2");
                lnksent.Visible = false;

                LinkButton lnkapprove = new LinkButton();
                lnkapprove = (LinkButton)r.FindControl("LinkButton1");
                lnkapprove.Visible = false;

                Label lblAppr = new Label();
                lblAppr = (Label)r.FindControl("lblApprove");
                lblAppr.Visible = true;
                lblAppr.Text = "Pending";
            }
            else
            {
                LinkButton lnksent = new LinkButton();
                lnksent = (LinkButton)r.FindControl("LinkButton2");
                lnksent.Visible = false;

                LinkButton lnkapprove = new LinkButton();
                lnkapprove = (LinkButton)r.FindControl("LinkButton1");
                lnkapprove.Visible = true;

                Label lblAppr = new Label();
                lblAppr = (Label)r.FindControl("lblApprove");
                lblAppr.Visible = false;
            }
            i = i + 1;
        }

        string Bookstatus1;
        int ii = 0;
        int kk = 0;
        foreach (GridViewRow r in GridView1.Rows)
        {
            Bookstatus1 = dt.Rows[ii]["Bookstatus"].ToString();
            if (Bookstatus1 == "Received")
            {
                Label lblc = new Label();
                lblc = (Label)r.FindControl("lblCourse");
                lblc.Visible = true;
                lblc.Text = "Received";
            }
            else if (Bookstatus1 == "Sent")
            {
                Label lblc = new Label();
                lblc = (Label)r.FindControl("lblCourse");
                lblc.Visible = true;
                lblc.Text = "Sent";
            }
            else if (Bookstatus1 == "Process")
            {
                Label lblc = new Label();
                lblc = (Label)r.FindControl("lblCourse");
                lblc.Visible = true;
                lblc.Text = "Process";
            }
            else
            {
                DropDownList ddbook = new DropDownList();
                ddbook = (DropDownList)r.FindControl("DropDownList1");
                ddbook.Visible = true;
                ddbook.SelectedValue = Bookstatus1;
                kk = kk + 1;
            }
            ii = ii + 1;
        }
        if (kk > 0)
        {
            Button2.Visible = true;
        }
        else
        {
            Button2.Visible = false;
        }
    }

    //private void filldropdown()
    //{
    //    _Qry = "select Course_Id,CourseName From Courseware_Course";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    DropDownList1.DataSource = dt;
    //    DropDownList1.DataTextField = "CourseName";
    //    DropDownList1.DataValueField = "Course_Id";
    //    DropDownList1.DataBind();
    //    DropDownList1.Items.Insert(0, new ListItem("Select", ""));
    //}

    //private void BookReq()
    //{
    //    _Qry = "select a.student_id as student_id,a.enq_personal_name,c.coursename,case when isnull(a.bookstatus,0)=0 ";
    //    _Qry += " then 'Pending'";
    //    _Qry += " else bookstatus end as bookstatus from adm_personalparticulars a ";
    //    _Qry += " inner join adm_generalinfo b on a.student_id=b.student_id inner join img_coursedetails c";
    //    _Qry += " on b.coursename=c.course_id where b.centre_code='" + Session["SA_centre_code"] + "' ";
    //    _Qry += " And BookReceived<>'Yes' And  b.student_id='"+Request.QueryString["student_id"]+"'";

    //    //Response.Write(_Qry);
    //    //Response.End();
    //    SqlDataReader dr;
    //    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
    //    if (dr.HasRows)
    //    {
    //        dr.Read();
    //        Request.QueryString["student_id"] = dr["student_id"].ToString();
    //        txtstudentname.Text = dr["enq_personal_name"].ToString();
    //        txtCourse.Text = dr["coursename"].ToString();
    //        dr.Close();
    //        //txtcourse.Text = dr["coursename"].ToString();
    //    }
        
    //}
    //protected void Btnadd_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
    //    {
    //        if (CheckBoxList1.Items[i].Selected)
    //        {
    //            _Qry = "Select Course_Id from Courseware_Course where CourseName='" + txtCourse.Text + "'";
    //            SqlDataReader dr;
    //            dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
    //            if (dr.HasRows)
    //            {
    //                dr.Read();
    //                courseid = Convert.ToInt32(dr["Course_Id"]);
    //                dr.Close();
    //            }

    //            //Response.Write("CourseId:" + courseid);
    //            //Response.Write("Test:"+CheckBoxList1.Items[i].Value);
    //            _Qry = "Insert into Courseware values('" + Request.QueryString["student_id"] + "','" + txtstudentname.Text + "','" + courseid + "','" + CheckBoxList1.Items[i].Value + "','Pending',getdate(),getdate())";
    //            //Response.Write(_Qry);
    //            //Response.End();
    //            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
    //        }
    //    }
    //    Response.Redirect("CourseWare.aspx?Bookreq=Succ");
    //    //Response.End();
    //}
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //}
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Book")
        {
            Response.Redirect("BookApprovalDetails.aspx?Courseware_Id=" + e.CommandArgument.ToString() + "");
        }

        if (e.CommandName == "BookView")
        {
            Response.Redirect("BookApprovalDetails.aspx?CoursewareId=" + e.CommandArgument.ToString() + "");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GridView1.Rows)
        {
            Label lcourse = new Label();
            lcourse = (Label)r.FindControl("lblID");

            DropDownList ddl = new DropDownList();
            ddl = (DropDownList)r.FindControl("DropDownList1");

            if (ddl.SelectedValue == "Pending")
            {
                _Qry = "Update Courseware set Bookstatus='" + ddl.SelectedValue + "' where Courseware_Id=" + lcourse.Text + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else if (ddl.SelectedValue == "Process")
            {
                _Qry = "Update Courseware set Bookstatus='" + ddl.SelectedValue + "',ProcessDate=getdate() where Courseware_Id=" + lcourse.Text + "";
                //Response.Write(_Qry);
                //Response.End();
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else if (ddl.SelectedValue == "Sent")
            {
                _Qry = "Update Courseware set Bookstatus='" + ddl.SelectedValue + "',SentDate=getdate() where Courseware_Id=" + lcourse.Text + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else if (ddl.SelectedValue == "Received")
            {
                _Qry = "Update Courseware set Bookstatus='" + ddl.SelectedValue + "',ReceivedDate=getdate() where Courseware_Id=" + lcourse.Text + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }


            int k = 0;
            int j = 0;
            int z = 0;
            string Bookstatus;
            _Qry = "Select Bookstatus from Courseware where StudentId='" + Request.QueryString["student_id"] + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Bookstatus = dt.Rows[i]["Bookstatus"].ToString();
                if (Bookstatus != "Received")
                {
                    k = k + 1;
                }
                if (Bookstatus != "Sent")
                {
                    j = j + 1;
                }
                if (Bookstatus != "Process")
                {
                    z = z + 1;
                }
            }

            if (k == 0)
            {
                _Qry = "Update adm_personalparticulars set Bookstatus='Received',BookReceived='Yes',DateMod=getdate() where student_id='" + Request.QueryString["student_id"] + "'";
                //Response.Write(_Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else if (j == 0)
            {
                _Qry = "Update adm_personalparticulars set Bookstatus='Sent',DateMod=getdate() where student_id='" + Request.QueryString["student_id"] + "'";
                //Response.Write(_Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else if (z == 0 || z==1)
            {
                _Qry = "Update adm_personalparticulars set Bookstatus='Process',DateMod=getdate() where student_id='" + Request.QueryString["student_id"] + "'";
                //Response.Write(_Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }
            else
            {
                _Qry = "Update adm_personalparticulars set Bookstatus='Pending HO',DateMod=getdate() where student_id='" + Request.QueryString["student_id"] + "'";
                //Response.Write(_Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }

            //_Qry = "Update Courseware set Bookstatus='" + ddl.SelectedValue + "' where Courseware_Id=" + lcourse.Text + "";
            //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }

        fillgrid();
    }
}
