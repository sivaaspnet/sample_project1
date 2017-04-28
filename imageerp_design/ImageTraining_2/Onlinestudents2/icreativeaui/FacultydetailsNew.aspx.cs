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


public partial class Facultydetails : System.Web.UI.Page
{
    string qry, listspecial;
    string _Qry = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        Lstbxspecialsation.SelectionMode = ListSelectionMode.Multiple;

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }


        fillgrid();

        lblfree.Text = "free";
    }


    protected void btn_add_Click(object sender, EventArgs e)
    {
        int i;
        string j = "";
        for (i = 0; i <= Lstbxspecialsation.Items.Count - 1; i++)
        {
            if (j == "")
            {

                if (Lstbxspecialsation.Items[i].Selected)
                {
                    j = j + Lstbxspecialsation.Items[i].Text;
                }

            }
            else if (Lstbxspecialsation.Items[i].Selected)
            {

                j = j + "," + Lstbxspecialsation.Items[i].Text;

            }

        }
        if (lblfacid.Text == "" || lblfacid.Text == null)
        {
            qry = "select count(*) from onlinestudentsfacultydetails where FacultyName='" + txtfacultyname.Text + "' And centre_code='" + Session["SA_centre_code"] + "'";
            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);

            if (count > 0)
            {
                lbl_errormsg.Text = "Faculty Name Already Exists";
            }
            else
            {
                int facid = 0; ;
                qry = "insert into onlinestudentsfacultydetails (facultyname,specialisation,centre_code,MWF,TTS,Daily,dateins,datemod,status) values ('" + txtfacultyname.Text + "','" + j + "','" + Session["SA_centre_code"] + "','" + ddlMWF.SelectedValue + "','" + ddlTTS.SelectedValue + "','" + ddlDaily.SelectedValue + "',getdate(),getdate(),'Enable')";
                //Response.Write(qry+"<br>");
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                qry = "select max(faculty_id) as facid from onlinestudentsfacultydetails";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(qry);
                if (dt.Rows.Count > 0)
                {
                    facid = Convert.ToInt32(dt.Rows[0]["facid"]);
                }
                for (int k = 2; k < 8; k++)
                {
                    if (k == 2 || k == 4 || k == 6)
                    {
                        if (ddlMWF.SelectedValue == "7Amto5Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + ","+k+",'7AMto9Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                         }
                        else if (ddlMWF.SelectedValue == "9Amto7Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";

                        }
                        else if (ddlMWF.SelectedValue == "11Amto9Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'7PMto9Pm','" + Session["SA_centre_code"] + "',getdate())";

                        }
                    }
                    else if (k == 3 || k == 5 || k == 7)
                    {
                        if (ddlTTS.SelectedValue == "7Amto5Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'7AMto9Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                        }
                        else if (ddlTTS.SelectedValue == "9Amto7Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                        }
                        else if (ddlTTS.SelectedValue == "11Amto9Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'7PMto9Pm','" + Session["SA_centre_code"] + "',getdate())";
                        }
                    }
                    if (ddlDaily.SelectedValue == "7Amto5Pm")
                    {
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'7AMto9Am','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                    }
                   else  if (ddlDaily.SelectedValue == "9Amto7Pm")
                    {
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                    }
                    else if (ddlDaily.SelectedValue == "11Amto9Pm")
                    {
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + facid + "," + k + ",'7PMto9Pm','" + Session["SA_centre_code"] + "',getdate())";
                    }

 
                    //qry = "insert into onlinestudentsfacultydetails (Centre_Code,FacultyName,MWF,TTS,Daily,Specialisation,[7amto9am],[9amto11am],[11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm],DateIns,DateMod)values('" + Session["SA_centre_code"] + "','" + txtfacultyname.Text + "','" + ddlMWF.SelectedValue + "','" + ddlTTS.SelectedValue + "','" + ddlDaily.SelectedValue + "','" + j + "','" + lblfree.Text + "','" + lblfree.Text + "','" + lblfree.Text + "','" + lblfree.Text + "','" + lblfree.Text + "','" + lblfree.Text + "','" + lblfree.Text + "',getdate(),getdate())";
 
                    //Response.Write(qry);
                    //Response.End();
                    
                }
                //Response.Write(_Qry);
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                lbl_errormsg.Text = "Faculty details added sucessfully";
                fillgrid();
                clear();
            }
        }
        else
        {
            qry = "Select count(*) from onlinestudentsfacultydetails where FacultyName='" + txtfacultyname.Text + "' And Faculty_Id<>" + lblfacid.Text + " And centre_code='" + Session["SA_centre_code"] + "'";

            int count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);

            if (count > 0)
            {
                lbl_errormsg.Text = "Faculty Name Already Exists";
            }
            else
            {
                qry = " update onlinestudentsfacultydetails set FacultyName='" + txtfacultyname.Text + "',MWF='" + ddlMWF.SelectedValue + "',TTS='" + ddlTTS.SelectedValue + "',Daily='" + ddlDaily.SelectedValue + "',Specialisation='" + j + "' where Faculty_ID=" + lblfacid.Text + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                qry = "update img_centrelogin set username='" + txtfacultyname.Text + "' where username ='" + HiddenField1.Value + "' and centre_code='"+Session["SA_centre_code"].ToString()+"'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                qry = "update onlinestudent_masterattendance set Faculty_Name='" + txtfacultyname.Text + "' where Faculty_Name='" + HiddenField1.Value + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                qry = "update onlinestudent_attendance set Faculty_Name='" + txtfacultyname.Text + "' where Faculty_Name='" + HiddenField1.Value + "' and centre_code='" + Session["SA_centre_code"].ToString() + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                _Qry = " Delete from erp_facultytimedetails where facultyid="+lblfacid.Text+"";
                for (int k = 2; k < 8; k++)
                {
                    if (k == 2 || k == 4 || k == 6)
                    {
                        if (ddlMWF.SelectedValue == "7Amto5Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'7AMto9Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                         }
                        else if (ddlMWF.SelectedValue == "9Amto7Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";

                        }
                        else if (ddlMWF.SelectedValue == "11Amto9Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'7PMto9Pm','" + Session["SA_centre_code"] + "',getdate())";

                        }
                    }
                    else if (k == 3 || k == 5 || k == 7)
                    {
                        if (ddlTTS.SelectedValue == "7Amto5Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'7AMto9Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                        }
                        else if (ddlTTS.SelectedValue == "9Amto7Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                        }
                        else if (ddlTTS.SelectedValue == "11Amto9Pm")
                        {
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                            _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'7PMto9Pm','" + Session["SA_centre_code"] + "',getdate())";
                        }
                    }
                    if (ddlDaily.SelectedValue == "7Amto5Pm")
                    {
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'7AMto9Am','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                    }
                   else  if (ddlDaily.SelectedValue == "9Amto7Pm")
                    {
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'9AMto11Am','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                    }
                    else if (ddlDaily.SelectedValue == "11Amto9Pm")
                    {
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'11AMto1Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'1PMto3Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'3PMto5Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'5PMto7Pm','" + Session["SA_centre_code"] + "',getdate())";
                        _Qry += " INSERT INTO  [erp_facultytimedetails]( [Facultyid],[day],[batchtime],[centrecode],[dateins]) VALUES (" + lblfacid.Text + "," + k + ",'7PMto9Pm','" + Session["SA_centre_code"] + "',getdate())";
                    }
 
                }
                //Response.Write(qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                lbl_errormsg.Text = "Faculty details Updated sucessfully";
                fillgrid();
                clear();
                btn_add.Visible = true;               
            }
        }
    }

    private void clear()
    {
        txtfacultyname.Text = "";

        //for (int x = 0; x < rbtnlistshift.Items.Count; x++)
        //{
        //    rbtnlistshift.Items[x].Selected = false;
        //}

        ddlMWF.SelectedValue = "NIL";
        ddlTTS.SelectedValue = "NIL";
        ddlDaily.SelectedValue = "NIL";

        for (int i = 0; i < Lstbxspecialsation.Items.Count; i++)
        {
            Lstbxspecialsation.Items[i].Selected = false;
        }

    }
    private void fillgrid()
    {
        qry = "select Faculty_ID,FacultyName,MWF,TTS,Daily,Specialisation,DateIns,DateMod from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "' and Status='Enable' Order by Faculty_ID desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {

            // Lstbxspecialsation.Items.Clear();

            for (int i = 0; i < Lstbxspecialsation.Items.Count; i++)
            {
                Lstbxspecialsation.Items[i].Selected = false;
            }

            qry = "select Faculty_ID, FacultyName,MWF,TTS,Daily,Specialisation from onlinestudentsfacultydetails where Faculty_ID=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            HiddenField1.Value = dt.Rows[0]["FacultyName"].ToString();
            if (dt.Rows.Count > 0)
            {

                string Val;
                Val = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Specialisation"].ToString());

                string[] strSplitArr1 = Val.Split(',');

                for (int i = 0; i < strSplitArr1.Length; i++)
                {
                    // Response.Write(strSplitArr1[i] + "...<br>");

                    if (strSplitArr1[i] == Lstbxspecialsation.Items[0].Text)
                    {
                        Lstbxspecialsation.Items[0].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[1].Text)
                    {
                        Lstbxspecialsation.Items[1].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[2].Text)
                    {
                        Lstbxspecialsation.Items[2].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[3].Text)
                    {
                        Lstbxspecialsation.Items[3].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[4].Text)
                    {
                        Lstbxspecialsation.Items[4].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[5].Text)
                    {
                        Lstbxspecialsation.Items[5].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[6].Text)
                    {
                        Lstbxspecialsation.Items[6].Selected = true;
                    }
                    else if (strSplitArr1[i] == Lstbxspecialsation.Items[7].Text)
                    {
                        Lstbxspecialsation.Items[7].Selected = true;
                    }



                }

                string ShiftTime;
                ddlMWF.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["MWF"].ToString());
                ddlTTS.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["TTS"].ToString());
                ddlDaily.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Daily"].ToString());


                txtfacultyname.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["FacultyName"].ToString());
                //  rbtnlistshift.SelectedItem.Value = MVC.CommonFunction.dt.Rows[0]["ShiftTiiming"].ToString();
                //Lstbxspecialsation.SelectedItem  = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Specialisation"].ToString());

                lblfacid.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Faculty_ID"].ToString());

                if (dt.Rows.Count > 0)
                {

                }
                else
                {
                    btn_add.Visible = true;

                }
            }
        }
        if (e.CommandName == "del")
        {
            qry = "update  onlinestudentsfacultydetails set Status='Disable' where Faculty_ID='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
            fillgrid();
            lbl_errormsg.Text = "The Faculty details has been deleted successfully";
            clear();
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //        background-color: orange;
            //border-color: black;
            //color: black;
            //font-weight: bold;
            //padding-left: 5px;
            //text-shadow: none;

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell Cell_Header = new TableCell();

            Cell_Header = new TableCell();
            Cell_Header.Text = "Faculty Name";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.BackColor = System.Drawing.Color.White;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);


            Cell_Header = new TableCell();
            Cell_Header.Text = "Shift Timing";
            Cell_Header.BackColor = System.Drawing.Color.White;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);


            Cell_Header = new TableCell();
            Cell_Header.Text = "Specialisation";
            Cell_Header.BackColor = System.Drawing.Color.White;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Action";
            //Cell_Header.Style["Align"] = "center";
            Cell_Header.BackColor = System.Drawing.Color.White;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);


            GridView1.Controls[0].Controls.AddAt(0, HeaderRow);

        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
    }
}