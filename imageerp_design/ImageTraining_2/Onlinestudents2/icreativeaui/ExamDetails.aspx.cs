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
using MySql.Data.MySqlClient;

public partial class Onlinestudents2_superadmin_ExamDetails : System.Web.UI.Page
{
    int xx = 0;
    string _qry;
    int Exam_Status = 0;
    int marks = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            Fillsearchmodule();
            Fillsearchcourse();
            FillGrid();
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


    private void Fillsearchmodule()
    {
        _qry = "select module_content,module_Id from module_details order by Module_Id ";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        ddlsearchmodname.DataSource = dt1;
        ddlsearchmodname.DataValueField = "module_Id";
        ddlsearchmodname.DataTextField = "module_content";
        ddlsearchmodname.DataBind();
        ddlsearchmodname.Items.Insert(0, new ListItem("Select", ""));
    }


    private void FillGrid()
    {
        MySqlConnection con = new MySqlConnection("data source=localhost;user ID=root;Password=;Initial catalog=imageonlineexam;charset=utf8");
        con.Open();
        string CurrentModule = "";
        string NextModule = "";

        DataSet dsreg = new DataSet();
        DataTable dtreg = dsreg.Tables.Add();

        DataSet dscom = new DataSet();
        DataTable dtcom = dscom.Tables.Add();

        DataSet dsre = new DataSet();
        DataTable dtre = dsre.Tables.Add();

        dtreg.Columns.Add("Student ID", typeof(string));
        dtreg.Columns.Add("Student Name", typeof(string));
        dtreg.Columns.Add("Current Module", typeof(string));
        dtreg.Columns.Add("Exam Date", typeof(string));
        dtreg.Columns.Add("Registered Date", typeof(string));

        dtcom.Columns.Add("Student ID", typeof(string));
        dtcom.Columns.Add("Student Name", typeof(string));
        dtcom.Columns.Add("Current Module", typeof(string));
        dtcom.Columns.Add("Exam Date", typeof(string));
        dtcom.Columns.Add("Registered Date", typeof(string));
        dtcom.Columns.Add("Completed Date", typeof(string));
        dtcom.Columns.Add("marks", typeof(string));

        dtre.Columns.Add("Student ID", typeof(string));
        dtre.Columns.Add("Student Name", typeof(string));
        dtre.Columns.Add("Current Module", typeof(string));
        dtre.Columns.Add("Exam Date", typeof(string));
        dtre.Columns.Add("Registered Date", typeof(string));
        dtre.Columns.Add("Completed Date", typeof(string));
        dtre.Columns.Add("marks", typeof(string));

        _qry = "Select G.student_id,(P.enq_personal_name+' '+student_lastname) as StudentName ,G.Track1,cou.program,cou.course_id,";
        _qry += "(SELECT convert(varchar, (Select top 1 date_class from";
        _qry += " Onlinestudent_EditScheduleBatch as sb inner join Batch_Details as bd on bd.Batch_code=sb.Batch_code";
        _qry += "  where Batch_StudentId=G.student_id order by schedule_Id desc),110)) as Exam_Date ";
        _qry += " from img_coursedetails cou inner join ";
        _qry += " adm_generalinfo G on G.coursename= cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id ";

        _qry += " Where G.Student_id in (select batch_studentid from batch_details as bd inner join Onlinestudent_EditScheduleBatch as sb on ";
        _qry += " bd.Batch_code=sb.Batch_code where (Select top 1 date_class from Onlinestudent_EditScheduleBatch where batch_Code=bd.Batch_code";
        _qry += "  order by schedule_Id desc)>1 And (Select Status From Add_moduledetails where Module_Id=Batch_Module_Id)='Enable') ";
        //_qry += " And (SELECT replace(convert(varchar, getdate(), 111), '/', '-')) > (Select top 1 DATEADD([day], - 6, date_class) from";
        //_qry += " Onlinestudent_EditScheduleBatch as sb inner join Batch_Details as bd on bd.Batch_code=sb.Batch_code";
        //_qry += "  where Batch_StudentId=G.student_id order by schedule_Id desc)";
        _qry += " And G.centre_code='" + Session["SA_centre_code"] + "' ";

        if (ddlsearchcourse.SelectedValue == "" || ddlsearchcourse.SelectedValue == null)
        {

        }
        else
        {
            _qry += " And cou.program='" + ddlsearchcourse.SelectedItem.Text + "'";
        }

        _qry += " GROUP by G.student_id,P.student_id,P.enq_personal_name,student_lastname,G.Track1,cou.program,cou.course_id order by Cou.Course_id";

        //Response.Write(_qry);
        //Response.End();

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_qry);

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            _qry = "Select StudentId from exam_studentdetails Where StudentRegNo='" + dt1.Rows[i]["student_id"].ToString() + "' ";
            MySqlCommand cmd1 = new MySqlCommand(_qry, con);
            int stdid = Convert.ToInt32(cmd1.ExecuteScalar());

            int ii = 0;
            _qry = "Select Batch_Code,Batch_Module_Content from Batch_Details where Batch_studentId='" + dt1.Rows[i]["student_id"].ToString() + "' And Batch_Status<>'Completed'";

            //_qry += " And (Select top 1 date_class from Onlinestudent_EditScheduleBatch where batch_Code=Batch_Details.Batch_code";
            _qry += "  And (Select Status From Add_moduledetails where Module_Id=Batch_Module_Id)='Enable'";
            if (ddlsearchmodname.SelectedValue == "" || ddlsearchmodname.SelectedValue == null)
            {

            }
            else
            {
                _qry += " And Batch_Module_Id=" + ddlsearchmodname.SelectedValue + "";
            }

            _qry += " order by Batch_studentId ";

                    DataTable dt2 = new DataTable();
                    dt2 = MVC.DataAccess.ExecuteDataTable(_qry);
                    if (dt2.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            Exam_Status = 0;
                                CurrentModule = dt2.Rows[j]["Batch_Module_Content"].ToString();

                                string cour_Name = "";
                                int cour_idd = 0;
                                cour_Name = MVC.CommonFunction.GetCoursecode(CurrentModule);


                                _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                                MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                                DataTable dtcour = new DataTable();
                                da15.Fill(dtcour);
                                if (dtcour.Rows.Count > 0)
                                {
                                    cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                                }
                                if (stdid > 0)
                                {

                                    _qry = "Select status,dateMod from exam_studentcoursedetails where StudentId=" + stdid + "";
                                    _qry += " And Status<>2 And (Certificate_Id=" + cour_idd + " || softwareId=" + cour_idd + ")";
                                    DataTable dt11 = new DataTable();
                                    MySqlDataAdapter da1 = new MySqlDataAdapter(_qry, con);
                                    da1.Fill(dt11);

                                    

                                    if (dt11.Rows.Count > 0)
                                    {
                                        string datemod = dt11.Rows[0]["dateMod"].ToString();

                                        string[] changedate = datemod.Split(' ');

                                        string finaldate = "";

                                        if (changedate.Length > 0)
                                        {
                                            string[] splitdate = changedate[0].Split('/');
                                            if (Convert.ToInt32(splitdate[0]) < 10)
                                            {
                                                splitdate[0] = "0" + splitdate[0];
                                            }
                                            finaldate = splitdate[0] + "-" + splitdate[1] + "-" + splitdate[2];
                                        }

                                        Exam_Status = Convert.ToInt32(dt11.Rows[0]["status"].ToString());

                                        if (Exam_Status == 1)
                                        {
                                            DataRow drreg = dtreg.NewRow();
                                            drreg[0] = dt1.Rows[i]["student_id"].ToString();
                                            drreg[1] = dt1.Rows[i]["StudentName"].ToString();
                                            drreg[2] = CurrentModule.ToString();
                                            drreg[3] = dt1.Rows[i]["Exam_Date"].ToString();
                                            drreg[4] = finaldate;

                                            dtreg.Rows.Add(drreg);
                                        }
                                        if (Exam_Status == 3)
                                        {
                                            _qry = "Select mark,dateIns From Exam_Results where StudentId=" + stdid + "";
                                            _qry += " And Status=1 And (Certificate_Id=" + cour_idd + " || software_Id=" + cour_idd + ")";
                                            //Response.Write("Test"+_qry);

                                            DataTable dtstatus = new DataTable();
                                            MySqlDataAdapter dastatus = new MySqlDataAdapter(_qry, con);
                                            dastatus.Fill(dtstatus);

                                            if (dtstatus.Rows.Count > 0)
                                            {
                                                marks = Convert.ToInt32(dtstatus.Rows[0]["mark"].ToString());

                                                if (marks > 40)
                                                {
                                                    string dateins = dtstatus.Rows[0]["dateIns"].ToString();

                                                    string[] resultdate = dateins.Split(' ');

                                                    string Completeddate = "";

                                                    if (resultdate.Length > 0)
                                                    {
                                                        string[] splitdate = resultdate[0].Split('/');
                                                        if (Convert.ToInt32(splitdate[0]) < 10)
                                                        {
                                                            splitdate[0] = "0" + splitdate[0];
                                                        }
                                                        Completeddate = splitdate[0] + "-" + splitdate[1] + "-" + splitdate[2];
                                                    }

                                                    DataRow drcom = dtcom.NewRow();
                                                    drcom[0] = dt1.Rows[i]["student_id"].ToString();
                                                    drcom[1] = dt1.Rows[i]["StudentName"].ToString();
                                                    drcom[2] = CurrentModule.ToString();
                                                    drcom[3] = dt1.Rows[i]["Exam_Date"].ToString();
                                                    drcom[4] = finaldate;
                                                    drcom[5] = Completeddate;
                                                    drcom[6] = marks;
                                                    dtcom.Rows.Add(drcom);
                                                }
                                                else
                                                {
                                                    string dateins = dtstatus.Rows[0]["dateIns"].ToString();

                                                    string[] resultdate = dateins.Split(' ');

                                                    string Completeddate = "";

                                                    if (resultdate.Length > 0)
                                                    {
                                                        string[] splitdate = resultdate[0].Split('/');
                                                        if (Convert.ToInt32(splitdate[0]) < 10)
                                                        {
                                                            splitdate[0] = "0" + splitdate[0];
                                                        }
                                                        Completeddate = splitdate[0] + "-" + splitdate[1] + "-" + splitdate[2];
                                                    }

                                                    DataRow drre = dtre.NewRow();
                                                    drre[0] = dt1.Rows[i]["student_id"].ToString();
                                                    drre[1] = dt1.Rows[i]["StudentName"].ToString();
                                                    drre[2] = CurrentModule.ToString();
                                                    drre[3] = dt1.Rows[i]["Exam_Date"].ToString();
                                                    drre[4] = finaldate;
                                                    drre[5] = Completeddate;
                                                    drre[6] = marks;
                                                    dtre.Rows.Add(drre);
                                                }
                                            }
                                        }
                                    }

                                }
                        }
                    }
        }

        string strex = ddlexamstatus.SelectedValue.ToString();
        if (strex == "Registered")
        {
            btnApprove.Visible = false;
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView1.DataSource = dtreg;
            GridView1.DataBind();
        }
        if (strex == "Completed")
        {
            btnApprove.Visible = false;
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView1.DataSource = dtcom;
            GridView1.DataBind();
        }
        if (strex == "Reexam")
        {
            btnApprove.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = true;
            GridView2.DataSource = dtre;
            GridView2.DataBind();
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        lblmsg1.Text = "";
        FillGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkApr")
        {
            string idInfo = e.CommandArgument.ToString();
            string[] args = new string[3];
            char[] splitter = { ';' };
            args = idInfo.Split(splitter);
            Response.Write("Stu Id=" + args[0].ToString() + "Module=" + args[1].ToString() + "Batch Code=" + args[2].ToString());
            Response.End();
        }
    }
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    FillGrid();
    //}
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        int _retInt = 0;
        int setFlag = 0;
        MySqlConnection con = new MySqlConnection("data source=localhost;user ID=root;Password=;Initial catalog=imageonlineexam;charset=utf8");
        con.Open();
        MySqlCommand Comm = new MySqlCommand();
        MySqlCommand StudentComm = new MySqlCommand();
        MySqlCommand CourseComm = new MySqlCommand();
        foreach (GridViewRow roww in GridView2.Rows)
        {
            xx = 0;

            Label lblstdid = new Label();
            lblstdid = (Label)roww.FindControl("lblstdId");

            Label lblstdname = new Label();
            lblstdname = (Label)roww.FindControl("lblName");

            Label lblcourse = new Label();
            lblcourse = (Label)roww.FindControl("lblCourse");

            Label lblcurrmod = new Label();
            lblcurrmod = (Label)roww.FindControl("lblCurrmod");

            CheckBox chbox = new CheckBox();
            chbox = (CheckBox)roww.FindControl("chkstd");
            if (chbox.Checked == true)
            {
                Comm.Dispose();
                _qry = "Select count(studentId)as cnt From exam_studentdetails Where TRIM(studentRegNo)='" + lblstdid.Text.ToString() + "'";
                //Response.Write(_qry);
                //Response.End();
                Comm.CommandText = _qry;
                Comm.Connection = con;
                //Comm.Parameters.Add("@txtRegNo", MySqlDbType.VarChar, 50).Value = lblstdid.Text.ToString();
                //Comm.Parameters.Add("@txtName", MySqlDbType.VarChar, 100).Value = lblstdname.Text.ToString();
                _retInt = Convert.ToInt32(Comm.ExecuteScalar());
                if (_retInt > 0)
                {
                        int Cert_Id = 0;
                        int Course_Id = 0;
                        int Dcou_Id = 0;
                        int CCou_Id = 0;
                        string DCourseType = "";
                        string CCOurseType = "";
                        string centre_location = "";
                        DataTable dtcourse = new DataTable();
                        //dtcourse.Rows.Count = 0;
                        DataTable dtdiploma = new DataTable();
                        int centre_id = 0;
                        _qry = "Select centre_location from img_centredetails where Centre_id=" + Session["SA_CenterID"] + "";
                        DataTable dt = new DataTable();
                        dt = MVC.DataAccess.ExecuteDataTable(_qry);
                        if (dt.Rows.Count > 0)
                        {
                            centre_location = dt.Rows[0]["centre_location"].ToString();
                        }
                        setFlag = 1;
                        int studentId = 0;

                        _qry = "Select centreId From exam_centredetails where centreLocation='" + centre_location + "'";
                        MySqlDataAdapter da = new MySqlDataAdapter(_qry, con);
                        DataTable dtcen = new DataTable();
                        da.Fill(dtcen);
                        if (dtcen.Rows.Count > 0)
                        {
                            centre_id = Convert.ToInt32(dtcen.Rows[0]["centreId"]);
                        }

                        string cour_Name = "";
                        int cour_idd = 0;
                        cour_Name = MVC.CommonFunction.GetCoursecode(lblcurrmod.Text.ToString());


                        _qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                        MySqlDataAdapter da15 = new MySqlDataAdapter(_qry, con);
                        DataTable dtcour = new DataTable();
                        da15.Fill(dtcour);
                        if (dtcour.Rows.Count > 0)
                        {
                            cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                        }

                        _qry = "Select StudentId from exam_studentdetails Where StudentRegNo='" + lblstdid.Text.ToString() + "' ";
                        MySqlCommand cmd1 = new MySqlCommand(_qry, con);
                        int stdid = Convert.ToInt32(cmd1.ExecuteScalar());

                        if (stdid > 0)
                        {
                            marks = 0;
                            _qry = "Select * from Exam_StudentCourseDetails where StudentId=" + stdid + "";
                            _qry += " And Status=3 And (Certificate_Id=" + cour_idd + " || softwareId=" + cour_idd + ")";
                            //Response.Write("<br>" + _qry);
                            //Response.End();
                            DataTable dt11 = new DataTable();
                            MySqlDataAdapter da1 = new MySqlDataAdapter(_qry, con);
                            da1.Fill(dt11);

                            if (dt11.Rows.Count > 0)
                            {
                                _qry = "Select resultId,mark,dateIns From Exam_Results where StudentId=" + stdid + "";
                                _qry += " And Status=1 And (Certificate_Id=" + cour_idd + " || software_Id=" + cour_idd + ")";
                                //Response.Write("Test"+_qry);

                                DataTable dtstatus = new DataTable();
                                MySqlDataAdapter dastatus = new MySqlDataAdapter(_qry, con);
                                dastatus.Fill(dtstatus);
                                if (dtstatus.Rows.Count > 0)
                                {
                                    marks = Convert.ToInt32(dtstatus.Rows[0]["mark"].ToString());
                                    if (marks < 40)
                                    {
                                        _qry = "Delete From Exam_Results Where resultId=" + dtstatus.Rows[0]["resultId"].ToString() + "";
                                        MySqlCommand cmd = new MySqlCommand(_qry, con);
                                        cmd.ExecuteNonQuery();

                                        _qry = "Update Exam_StudentCourseDetails set Status=1 Where detailId=" + dt11.Rows[0]["detailId"] + "";
                                        MySqlCommand cmd12 = new MySqlCommand(_qry, con);
                                        cmd12.ExecuteNonQuery();
                                        lblmsg1.Text = "Reexam Registered Successfully";
                                    }
                                }
                            }
                        }
                }                
            }
        }
        FillGrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}
