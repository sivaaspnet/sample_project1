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

public partial class Onlinestudents2_BatchSchedule : System.Web.UI.Page
{
    string _Qry, os="", os1="", swa, os2="";
    //string Ipaddr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
            {
                Response.Redirect("Login.aspx");
            }
            _Qry = "Select Batch_StudentId,(select enq_personal_name from adm_personalparticulars where Student_Id=Batch_Studentid ";
            _Qry +=" group by Student_ID,enq_personal_name)as Name,";
            _Qry += "(Select Course_Name From Module_Details where Module_Id=Batch_Module_Id) as Course_Name,";
            _Qry += "Batch_Module_Content,Batch_Code,Centre_Code,Batch_Faculty,Batch_labname,Batch_track,batch_slot,batch_time,CONVERT(VARCHAR(10),Batch_startdate,111) as Batch_startdate,CONVERT(VARCHAR(10),Batch_enddate,111) as Batch_enddate From Batch_Details Where Batch_code='" + Request.QueryString["batchcode"] + "'";
            _Qry += " And Batch_Status='Inprogress'";

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                tblbatch.Visible = true;
                //txt_StudentId.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_StudentId"].ToString());
                //txt_StudentName.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Name"].ToString());
                txt_Course.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Course_Name"].ToString());
                txt_modulecontent.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_Module_Content"].ToString());
                txt_BatchCode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_Code"].ToString());
                txt_BatchSlot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batch_time"].ToString());
                txt_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batch_slot"].ToString());
                txt_BatchTrack.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
                txt_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_Faculty"].ToString());
                txt_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_labname"].ToString());
                lbl_Centrecode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Centre_Code"].ToString());
                lbl_Faculty.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_Faculty"].ToString());
                lbl_Lab.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_labname"].ToString());
                lbl_BatchTrack.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_track"].ToString());
                lbl_BatchTime.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batch_slot"].ToString());
                lbl_batchslot.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["batch_time"].ToString());
                lbl_Batchcode.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_Code"].ToString());
                txt_startdate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_startdate"].ToString());
                txt_enddate.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_enddate"].ToString());


                _Qry = "Select software_name from module_details where Module_Content='" + MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["Batch_Module_Content"].ToString()) + "'";
                SqlDataReader dr;
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    dr.Read();
                    string str = dr["software_name"].ToString();
                    string[] softwarename = str.Split(',');
                    int i = 0;
                    foreach (string soft in softwarename)
                    {
                        ddl_software.Items.Insert(i, new ListItem(soft, soft));
                        i = i + 1;
                    }
                    dr.Close();
                    ddl_software.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            else
            {
                tblbatch.Visible = false;
            }

            fillgrid();
            ddl_Content.Items.Insert(0, new ListItem("Select", ""));
        }
    }

    private void fillgrid()
    {
        _Qry = "Select Schedule_ID,software_name,Content,convert(varchar(10),Date_Class,111) as Dateofclass ";
        //_Qry += "(Select Class_Date From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as ClassHeld,(Select Reason From Onlinestudent_MasterAttendance as ma Where ma.Class_Content= ";
        //_Qry += "sa.Content) as Reason ";
        _Qry +=" From onlinestudent_schedulebatch as sa Where sa.Batch_Code='" + txt_BatchCode.Text + "' ";
        _Qry += " order by sa.software_name";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt1.Rows.Count > 0)
        //{
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (lbl_ScheduleID.Text == "" || lbl_ScheduleID.Text == null)
        {
            _Qry = "Select count(*) from onlinestudent_schedulebatch Where Batch_code='" + Request.QueryString["batchcode"] + "' ";
            _Qry += " And Software_Name='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_software.SelectedValue) + "'";
            _Qry += " And [Content]='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Content.SelectedValue) + "'";

            //Response.Write(_Qry);
            //Response.End();

            int count12 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (count12 <= 0)
            {

                string dateFrom = "";
                if (txt_classdate.Text != "")
                {
                    string str = txt_classdate.Text;
                    string[] split = str.Split('-');
                    dateFrom = split[2] + "-" + split[1] + "-" + split[0];
                }

                _Qry = "insert into onlinestudent_schedulebatch(Centre_Code,Course_Name,Software_Name,Module_Name,Batch_Code,Faculty_Name,";
                _Qry += "Lab_Name,Batch_Timing,Batch_Slot,Batch_Track,Content,Date_class,Date_Ins) ";
                _Qry += " Values('" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Centrecode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Course.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_software.SelectedValue) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_modulecontent.Text) + "',";
                _Qry += "'" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Batchcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Faculty.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_Lab.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTime.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_batchslot.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(lbl_BatchTrack.Text) + "',";
                _Qry += " '" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Content.SelectedValue) + "',";
                _Qry += "'" + dateFrom + "',getdate())";

                //Response.Write(_Qry);
                //Response.End();

                int count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                if (count > 0)
                {
                    lblmsg1.Text = "Content Details inserted successfully";
                }
                else
                {
                    lblmsg1.Text = "";
                }
                ddl_software.SelectedValue = "";
                _Qry = "select Content from Submodule_details_new Where Software='" + ddl_software.SelectedItem + "' And Module='" + txt_modulecontent.Text + "' order by Software";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                //if (dt1.Rows.Count > 0)
                //{
                ddl_Content.DataSource = dt1;
                ddl_Content.DataTextField = "Content";
                ddl_Content.DataValueField = "Content";
                ddl_Content.DataBind();
                //}
                ddl_Content.Items.Insert(0, new ListItem("Select", ""));
                txt_classdate.Text = "";
            }
            else
            {
                lblmsg1.Text = "This Content details already exists";
            }
            fillgrid();
        }
        else
        {
            _Qry = "Select count(*) from onlinestudent_schedulebatch Where Batch_code='" + Request.QueryString["batchcode"] + "' ";
            _Qry += " And Software_Name='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_software.SelectedValue) + "'";
            _Qry += " And [Content]='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Content.SelectedValue) + "'";
            _Qry += " And Schedule_ID<>"+lbl_ScheduleID.Text+"";

            //Response.Write(_Qry);
            //Response.End();

            int count12 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (count12 <= 0)
            {

                string dateFrom = "";
                if (txt_classdate.Text != "")
                {
                    string str = txt_classdate.Text;
                    string[] split = str.Split('-');
                    dateFrom = split[2] + "-" + split[1] + "-" + split[0];
                }

                _Qry = "Update onlinestudent_schedulebatch set Software_Name='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_software.SelectedValue) + "',";
                _Qry += "Content='" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_Content.SelectedValue) + "',";
                _Qry += "Date_class='" + dateFrom + "' Where Schedule_ID='" + lbl_ScheduleID.Text + "'";

                //Response.Write(_Qry);
                //Response.End();

                int count = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                if (count > 0)
                {
                    lblmsg1.Text = "Content Details updated successfully";
                }
                else
                {
                    lblmsg1.Text = "";
                }
                ddl_software.SelectedValue = "";
                _Qry = "select Content from Submodule_details_new Where Software='" + ddl_software.SelectedItem + "' And Module='" + txt_modulecontent.Text + "' order by Software";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                //if (dt1.Rows.Count > 0)
                //{
                ddl_Content.DataSource = dt1;
                ddl_Content.DataTextField = "Content";
                ddl_Content.DataValueField = "Content";
                ddl_Content.DataBind();
                //}
                ddl_Content.Items.Insert(0, new ListItem("Select", ""));
                txt_classdate.Text = "";
            }
            else
            {
                lblmsg1.Text = "This Content details already exists";
            }
            lbl_ScheduleID.Text = "";
            fillgrid();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void ddl_software_SelectedIndexChanged(object sender, EventArgs e)
    {
        _Qry = "select Content from Submodule_details_new Where Software='"+ddl_software.SelectedItem+"' And Module='"+txt_modulecontent.Text+"' order by Software";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt.Rows.Count > 0)
        //{
            ddl_Content.DataSource = dt;
            ddl_Content.DataTextField = "Content";
            ddl_Content.DataValueField = "Content";
            ddl_Content.DataBind();
        //}
        ddl_Content.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            _Qry = "Select Schedule_ID,software_name,Content,CONVERT(VARCHAR(10),Date_Class,111) as Dateofclass ";
            _Qry += " From onlinestudent_schedulebatch as sa Where sa.Schedule_ID='"+e.CommandArgument.ToString()+"' ";
            _Qry += " order by sa.software_name";

            SqlDataReader dr;
            dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            if (dr.HasRows)
            {
                dr.Read();
                ddl_software.SelectedValue = dr["software_name"].ToString();
                //ddl_software.SelectedItem = dr["software_name"].ToString();
                _Qry = "select Content from Submodule_details_new Where Software='" + ddl_software.SelectedItem + "' And Module='" + txt_modulecontent.Text + "' order by Software";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                //if (dt.Rows.Count > 0)
                //{
                ddl_Content.DataSource = dt;
                ddl_Content.DataTextField = "Content";
                ddl_Content.DataValueField = "Content";
                ddl_Content.DataBind();
                //}
                ddl_Content.Items.Insert(0, new ListItem("Select", ""));

                ddl_Content.SelectedValue = dr["Content"].ToString();

                txt_classdate.Text = dr["Dateofclass"].ToString();

                string dateFrom = "";;
                if (txt_classdate.Text != "")
                {
                    string str = txt_classdate.Text;
                    string[] split = str.Split('/');
                    txt_classdate.Text = split[2] + "-" + split[1] + "-" + split[0];
                }

                lbl_ScheduleID.Text = e.CommandArgument.ToString();

                dr.Close();
            }
        }
        if (e.CommandName == "Del")
        {
            _Qry = "Delete From onlinestudent_schedulebatch Where Schedule_ID="+e.CommandArgument.ToString()+"";
            int count12 = MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            if (count12 > 0)
            {
                lblmsg1.Text = "Content Details Deleted successfully";
                fillgrid();
                ddl_software.SelectedValue = "";
                _Qry = "select Content from Submodule_details_new Where Software='" + ddl_software.SelectedItem + "' And Module='" + txt_modulecontent.Text + "' order by Software";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                //if (dt1.Rows.Count > 0)
                //{
                    ddl_Content.DataSource = dt1;
                    ddl_Content.DataTextField = "Content";
                    ddl_Content.DataValueField = "Content";
                    ddl_Content.DataBind();
                //}
                ddl_Content.Items.Insert(0, new ListItem("Select", ""));
                txt_classdate.Text = "";
            }
            fillgrid();
            ddl_software.SelectedValue = "";
            //ddl_Content.SelectedValue = "";
            txt_classdate.Text = "";
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddl_software.SelectedValue = "";
        _Qry = "select Content from Submodule_details_new Where Software='" + ddl_software.SelectedItem + "' And Module='" + txt_modulecontent.Text + "' order by Software";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if (dt1.Rows.Count > 0)
        //{
        ddl_Content.DataSource = dt1;
        ddl_Content.DataTextField = "Content";
        ddl_Content.DataValueField = "Content";
        ddl_Content.DataBind();
        //}
        ddl_Content.Items.Insert(0, new ListItem("Select", ""));
        txt_classdate.Text = "";
    }
}
