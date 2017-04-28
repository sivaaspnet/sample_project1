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
using MySql.Data.MySqlClient;
public partial class Onlinestudents_superadmin_BatchReport : System.Web.UI.Page
{
    string _Qry;
    int abc = 0;
    public string Htmlbuilder = "";
    int i = 0;
    int Course_ID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Htmlbuilder"] = "";
        }
        FillHeaderSection();
        Content();
    }

    #region headersection
    private void FillHeaderSection()
    {
        _Qry = "Select Student_Id,(select (enq_personal_name+' '+student_lastname) From adm_personalparticulars Where Student_id=";
        _Qry += "ag.Student_Id) as StudentName,(Select Invoice_Id From invoice_details Where Student_id=ag.Student_Id  ";
        _Qry += "Group By Student_id,Invoice_Id) as InvoiceNumber,(Select Program From img_CourseDetails Where";
        _Qry += " Course_Id=ag.Coursename) as Course,Track1 as Track,(SELECT convert(varchar, Dateins, 103)) as EnrolledDate";
        _Qry += " From adm_Generalinfo as ag Where Student_Id='ICH-106-7-11002'";


        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lblInv.Text = dt.Rows[0]["InvoiceNumber"].ToString();
            lblEnrDate.Text = dt.Rows[0]["EnrolledDate"].ToString();
            lblSId.Text = dt.Rows[0]["Student_Id"].ToString();
            LblSName.Text = dt.Rows[0]["StudentName"].ToString();
            lblCourse.Text = dt.Rows[0]["Course"].ToString();
            lblTrack.Text = dt.Rows[0]["Track"].ToString();
        }
        else
        {
            lblInv.Text = "";
            lblEnrDate.Text = "";
            lblSId.Text = "";
            LblSName.Text = "";
            lblCourse.Text = "";
            lblTrack.Text = "";
        }
    }
#endregion

    #region Content

    private void Content()
    {
        MySqlConnection con = new MySqlConnection("data source=localhost;user ID=root;Password=;Initial catalog=imageonlineexam;charset=utf8");
        con.Open();
        _Qry = "select Course_Id From onlinestudent_course where course_code='"+lblCourse.Text+"'";
        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr.HasRows)
        {
            dr.Read();
            Course_ID = Convert.ToInt32(dr["Course_Id"].ToString());
            dr.Close();
        }
        _Qry = "Select Module_Content From Onlinestudent_Coursesoftware Where Course_Id=" + Course_ID + " order by CourseSoftware_ID";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //Htmlbuilder += "<tr>";
        //Htmlbuilder += "<td>";
        //Session["Htmlbuilder"]
        for (int ii = 0; ii < dt.Rows.Count; ii++)
        {
            abc = 0;
            Htmlbuilder = "";
            i = i + 1;
            //Response.Write("Loading:" + i);
            _Qry = "Select Batch_Code,Batch_Faculty,Batch_Time,(SELECT convert(varchar, Batch_Startdate, 103)) as stdate,(SELECT convert(varchar, Batch_Enddate, 103)) as endate,";
            _Qry += "(Select Mark From ProjectAssesment Where StudentId=Bd.Batch_StudentId And Module='" + dt.Rows[ii]["Module_Content"].ToString() + "')";
            _Qry += " as Projectmark From Batch_Details as Bd Where Batch_StudentId='ICH-106-7-11002' And ";
            _Qry += " Batch_Module_Content='" + dt.Rows[ii]["Module_Content"].ToString() + "'";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt1.Rows.Count > 0)
            {

                //Response.Write(Session["Htmlbuilder"]);
                //Response.End();
                string mark = "";
                string Examdate = "";
                _Qry = "Select StudentId from exam_studentdetails Where StudentRegNo='ICH-106-7-11002'";
                MySqlCommand cmd1 = new MySqlCommand(_Qry, con);
                int stdid = Convert.ToInt32(cmd1.ExecuteScalar());

                string cour_Name = "";
                int cour_idd = 0;
                cour_Name = MVC.CommonFunction.GetCoursecode(dt.Rows[ii]["Module_Content"].ToString());
                _Qry = "Select Course_id From exam_coursedetail where Course_name='" + cour_Name + "'";
                MySqlDataAdapter da15 = new MySqlDataAdapter(_Qry, con);
                DataTable dtcour = new DataTable();
                da15.Fill(dtcour);
                if (dtcour.Rows.Count > 0)
                {
                    cour_idd = Convert.ToInt32(dtcour.Rows[0]["Course_id"]);
                }

                _Qry = "Select mark,dateIns From Exam_Results where StudentId=" + stdid + "";
                _Qry += " And Status=1 And (Certificate_Id=" + cour_idd + " || software_Id=" + cour_idd + ")";
                //Response.Write("Test"+_qry);

                DataTable dtstatus = new DataTable();
                MySqlDataAdapter dastatus = new MySqlDataAdapter(_Qry, con);
                dastatus.Fill(dtstatus);

                if (dtstatus.Rows.Count > 0)
                {
                    string dateins = dtstatus.Rows[0]["dateIns"].ToString();
                    string[] datesplit = dateins.Split(' ');
                    string[] splitdate = datesplit[0].Split('/');
                    if (Convert.ToInt32(splitdate[0].ToString()) < 10)
                    {
                        splitdate[0] = "0" + splitdate[0];
                    }
                    Examdate = splitdate[0] + "-" + splitdate[1] + "-" + splitdate[2];
                    mark = dtstatus.Rows[0]["mark"].ToString();
                }
                else
                {
                    mark = "Pending";
                    Examdate = "Pending";
                }

                Htmlbuilder += "<tr align='center' valign='middle' bgcolor='#FFFFFF'>";
                
                //Htmlbuilder += "<td  >" + dt.Rows[ii]["Module_Content"].ToString() + "</td>";
                
                _Qry = "Select Software_Name From module_details Where Module_Content='" + dt.Rows[ii]["Module_Content"].ToString() + "'";
                DataTable dt3 = new DataTable();
                dt3 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    string Soft_Name = dt3.Rows[0]["Software_Name"].ToString();
                    string[] soft1 = Soft_Name.Split(',');

                    if (soft1.Length > 0)
                    {
                        int yy = 0;
                        int zz = 0;
                        Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='top' class='text'>" + i + "</td>";
                        Htmlbuilder += "<td  rowspan='" + soft1.Length + "' valign='top' class='text'>" + dt.Rows[ii]["Module_Content"].ToString() + "</td>";
                        for (int j = 0; j < soft1.Length; j++)
                        {
                            if (abc == 0)
                            {
                                _Qry = "Select Top 1 convert(varchar(10),Date_Class,103) as ClassStdate from Onlinestudent_ScheduleBatch where";
                                _Qry += " Batch_Code='" + dt1.Rows[0]["Batch_Code"].ToString() + "' And Software_Name='" + soft1[j].ToString() + "'";
                                _Qry += " Order By Schedule_ID Asc";

                                DataTable dtstdate = new DataTable();
                                dtstdate = MVC.DataAccess.ExecuteDataTable(_Qry);

                                _Qry = "Select Top 1 convert(varchar(10),Date_Class,103) as ClassEndate from Onlinestudent_ScheduleBatch where";
                                _Qry += " Batch_Code='" + dt1.Rows[0]["Batch_Code"].ToString() + "' And Software_Name='" + soft1[j].ToString() + "'";
                                _Qry += " Order By Schedule_ID Desc";

                                DataTable dtendate = new DataTable();
                                dtendate = MVC.DataAccess.ExecuteDataTable(_Qry);

                                Htmlbuilder += "<td>" + soft1[j].ToString() + "</td>";
                                if (zz == 0)
                                {
                                    zz = 100;
                                    Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='Bottom' class='text'><a href='Viewbatch.aspx?batchcode=" + dt1.Rows[0]["Batch_Code"].ToString() + "&Info=true&StudentID=ICH-106-7-11002'>" + dt1.Rows[0]["Batch_Code"].ToString() + "</a></td>";
                                    Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='Bottom' class='text'>" + dt1.Rows[0]["Batch_Faculty"].ToString() + "</td>";
                                }
                                Htmlbuilder += "<td>" + dt1.Rows[0]["Batch_Time"].ToString() + "</td>";
                                Htmlbuilder += "<td>" + dtstdate.Rows[0]["ClassStdate"].ToString() + "</td>";
                                Htmlbuilder += "<td >" + dtendate.Rows[0]["ClassEndate"].ToString() + "</td>";
                                //Htmlbuilder += "<td ><a href='Viewbatch.aspx?batchcode=" + dt1.Rows[0]["Batch_Code"].ToString() + "&Info=true'> " + dt1.Rows[0]["Batch_Code"].ToString() + " </a></td>";
                                if (yy == 0)
                                {
                                    yy = 100;
                                    if (dt1.Rows[0]["Projectmark"].ToString() == "" || dt1.Rows[0]["Projectmark"].ToString() == null)
                                    {
                                        Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='Bottom' class='text'> Pending </td>";
                                    }
                                    else
                                    {
                                        Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='Bottom' class='text'>" + dt1.Rows[0]["Projectmark"].ToString() + "</td>";
                                    }
                                    Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='Bottom' class='text'> " + mark + " </td>";
                                    Htmlbuilder += "<td rowspan='" + soft1.Length + "' valign='Bottom' class='text'> " + Examdate + " </td>";
                                }
                                Htmlbuilder += "</tr > ";
                            }
                            else
                            {
                                abc = abc + 1;
                                Htmlbuilder += "<tr align='center' valign='middle' bgcolor='#FFFFFF'>";
                                Htmlbuilder += "<td>" + soft1[j].ToString() + "</td>";
                                Htmlbuilder += "<td >" + dt1.Rows[0]["Batch_Faculty"].ToString() + "</td>";
                                Htmlbuilder += "<td>" + dt1.Rows[0]["Batch_Time"].ToString() + "</td>";
                                Htmlbuilder += "<td>" + dt1.Rows[0]["stdate"].ToString() + "</td>";
                                Htmlbuilder += "<td >" + dt1.Rows[0]["endate"].ToString() + "</td>";
                                //////Htmlbuilder += "<td ><a href='Viewbatch.aspx?batchcode=" + dt1.Rows[0]["Batch_Code"].ToString() + "&Info=true'> " + dt1.Rows[0]["Batch_Code"].ToString() + " </a></td>";
                                //if (dt1.Rows[0]["Projectmark"].ToString() == "" || dt1.Rows[0]["Projectmark"].ToString() == null)
                                //{
                                //    Htmlbuilder += "<td > Pending </td>";
                                //}
                                //else
                                //{
                                //    Htmlbuilder += "<td>" + dt1.Rows[0]["Projectmark"].ToString() + "</td>";
                                //}
                                //Htmlbuilder += "<td > " + mark + " </td>";
                                //Htmlbuilder += "<td > Pending </td>";
                                Htmlbuilder += "</tr > ";
                            }
                        }
                    }
                }
                Session["Htmlbuilder"] += Htmlbuilder;
            }
            else
            {
                //Htmlbuilder += "<td colspan='2' >" + dt.Rows[ii]["Module_Content"].ToString() + "</td>";

                _Qry = "Select Software_Name From module_details Where Module_Content='" + dt.Rows[ii]["Module_Content"].ToString() + "'";
                DataTable dt3 = new DataTable();
                dt3 = MVC.DataAccess.ExecuteDataTable(_Qry);
                Htmlbuilder += "<tr align='center' valign='middle' bgcolor='#FFFFFF'>";
                if (dt.Rows.Count > 0)
                {
                    string Soft_Name = dt3.Rows[0]["Software_Name"].ToString();
                    string[] soft = Soft_Name.Split(',');

                    if (soft.Length > 0)
                    {
                        int yy = 0;
                        int zz = 0;
                        Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='top' class='text'>" + i + "</td>";


                        Htmlbuilder += "<td  rowspan='" + soft.Length + "' valign='top' class='text'>" + dt.Rows[ii]["Module_Content"].ToString() + "</td>";
                        for (int j = 0; j < soft.Length; j++)
                        {
                            if (abc == 0)
                            {

                                Htmlbuilder += "<td>" + soft[j].ToString() + "</td>";
                                if (zz == 0)
                                {
                                    zz = 100;
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'>Pending</td>";
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'> Pending </td>";
                                }
                                Htmlbuilder += "<td> Pending </td>";
                                Htmlbuilder += "<td > Pending </td>";
                                Htmlbuilder += "<td > Pending </td>";
                                if (yy == 0)
                                {
                                    yy = 100;
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'> Pending </td>";
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'>  Pending </td>";
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'>  Pending  </td>";
                                }
                                Htmlbuilder += "</tr > ";
                            }
                            else
                            {
                                abc = abc + 1;
                                Htmlbuilder += "<tr align='center' valign='middle' bgcolor='#FFFFFF'>";
                                Htmlbuilder += "<td>" + soft[j].ToString() + "</td>";
                                if (zz == 0)
                                {
                                    zz = 100;
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'> Pending </td>";
                                }
                                Htmlbuilder += "<td> Pending </td>";
                                Htmlbuilder += "<td > Pending </td>";
                                Htmlbuilder += "<td > Pending </td>";
                                if (yy == 0)
                                {
                                    yy = 100;
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'> Pending </td>";
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'>  Pending </td>";
                                    Htmlbuilder += "<td rowspan='" + soft.Length + "' valign='Bottom' class='text'>  Pending  </td>";
                                }
                                Htmlbuilder += "</tr > ";
                            }
                        }
                    }
                }
                //Response.Write(Session["Htmlbuilder"]);
                //Response.End();
                Session["Htmlbuilder"] += Htmlbuilder;
            }
        }
        //Htmlbuilder += "</td>";
        //Htmlbuilder += "</tr>";
    }

    #endregion

}
