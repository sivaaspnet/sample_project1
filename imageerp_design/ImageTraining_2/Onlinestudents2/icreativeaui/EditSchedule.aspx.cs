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
using System.Globalization;

public partial class Onlinestudents2_superadmin_EditSchedule : System.Web.UI.Page
{
    string BatchCount, batch_code, couname, couid, todate, holdate;
    int noofcls;
    DateTime stdate, lastday;
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            Fillvalue();
            FillBatchSchedule();
            //FillBatchCode();
            //ddlsoftwre.Items.Insert(0, new ListItem("Select", ""));
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("GetCentreDetails.aspx");
        }
    }

    private void Fillvalue()
    {
        _Qry = "Select Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,Batch_Time,convert(varchar(10),Batch_Startdate,105) as Batch_Startdate,convert(varchar(10),Batch_enddate,105) as Batch_Enddate ";
        _Qry += " From Batch_Details Where Batch_Code='" + Request.QueryString["Batch_Code"] + "' Group By Batch_Code,batch_Module_content,batch_Faculty,batch_LabName,Batch_Track,Batch_Slot,";
        _Qry += "Batch_Time,Batch_Startdate,Batch_Enddate";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            tblbatch.Visible = true;
            txt_BatchTrack.Text = dt.Rows[0]["Batch_Track"].ToString();
            txt_Module.Text = dt.Rows[0]["batch_Module_content"].ToString();
            txt_Faculty.Text = dt.Rows[0]["batch_Faculty"].ToString();
            txt_Lab.Text = dt.Rows[0]["batch_LabName"].ToString();
            txt_BatchSlot.Text = dt.Rows[0]["Batch_Slot"].ToString();
            txt_BatchTime.Text = dt.Rows[0]["Batch_Time"].ToString();
            txt_Bstart.Text = dt.Rows[0]["Batch_Startdate"].ToString();
            txt_Bend.Text = dt.Rows[0]["Batch_Enddate"].ToString();
        }
    }

    private void FillBatchSchedule()
    {
        _Qry = "Select Software_Name,Content,CONVERT(VARCHAR(10),Date_Class,103) as Date_Class From onlinestudent_schedulebatch where Batch_Code='" + Request.QueryString["Batch_Code"] + "'";
        _Qry += " And Schedule_ID=" + Request.QueryString["ScheduleId"] + "";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            txt_Software.Text = dt.Rows[0]["Software_Name"].ToString();
            txt_Content.Text = dt.Rows[0]["Content"].ToString();
            txt_stratdate.Text = dt.Rows[0]["Date_Class"].ToString();

            if (txt_stratdate.Text != "")
            {
                string str = txt_stratdate.Text;
                string[] split = str.Split('/');
                txt_stratdate.Text = split[0] + "-" + split[1] + "-" + split[2];
            }
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        datecalc();
    }

    private static int dayOfWeek(DateTime adSource)
    {

        // Calender Functionality cloned by used defined logic
        DayOfWeek dWeek = adSource.DayOfWeek;

        switch (dWeek)
        {

            case DayOfWeek.Monday:
                return 1;

            case DayOfWeek.Tuesday:
                return 2;

            case DayOfWeek.Wednesday:
                return 3;

            case DayOfWeek.Thursday:
                return 4;

            case DayOfWeek.Friday:
                return 5;

            case DayOfWeek.Saturday:
                return 6;

            case DayOfWeek.Sunday:
                return 0;

        }

        return 0;

    }
    public static DateTime getDate(string date)//date= 24-10-2007
    {

        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl-NL");
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("nl-NL");
        System.IFormatProvider format = new System.Globalization.CultureInfo("nl-NL", true);
        DateTime date1 = DateTime.ParseExact(date, "yyyy/MM/dd", null);

        return date1; // 10-24-2007

    }
    private void datecalc()
    {

        string soft_id = "";
        int Noofdays = 0;
        _Qry = "Select Count(*) From Onlinestudent_EditScheduleBatch where Batch_Code='" + Request.QueryString["Batch_Code"] + "' ";
        _Qry += " And Schedule_Id>=" + Request.QueryString["ScheduleId"] + "";

        Noofdays = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

        noofcls = Noofdays;

        string sdate;

        string str = txt_stratdate.Text;
        string[] split = str.Split('-');

        sdate = split[2] + "-" + split[1] + "-" + split[0];

        DateTime stdat = getDate(sdate);

        //stdat = stdat.
        //Response.Write(stdat);
        //Response.End();
        int submod_Id = 0;
        int z = 0;
        int submodule_id = 0;
        string module_name = "", software_name = "", mod_content = "";
        int i = 0;
        while (noofcls > i)
        {
            SqlDataReader dr;

            string MyString;
            MyString = stdat.ToString("yyyy-MM-dd");
            stdat = DateTime.ParseExact(MyString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            //Response.Write("Test:" + MyString + "One More:" + stdat);
            //Response.End();

            holdate = "";
            _Qry = "select Hoilday_date from atn_hoilday where Hoilday_date='" + MyString + "'";

            //Response.Write(_Qry);
            //Response.End();
            DataTable dt6 = new DataTable();
            dt6 = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (z == 0)
            {
                _Qry = "Update Onlinestudent_EditScheduleBatch set Reason='"+txt_Reason.Text+"' Where ";
                _Qry += " module_Name='" + txt_Module.Text + "' And Schedule_Id=" + Request.QueryString["ScheduleId"] + "";

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            }

            //Response.Write("<br>stdate is:" + stdat);
            //Response.Write("<br>Mystring is:" + MyString);

            if (z == 0)
            {
                _Qry = "Select Top 1 * from Onlinestudent_EditScheduleBatch where module_Name='" + txt_Module.Text + "' And Schedule_id=" + Request.QueryString["ScheduleId"] + "";
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    dr.Read();
                    submodule_id = Convert.ToInt32(dr["Schedule_id"]);
                    module_name = dr["Module_Name"].ToString();
                    software_name = dr["Software_Name"].ToString();
                    mod_content = dr["Content"].ToString();
                    dr.Close();
                }
            }
            else
            {
                _Qry = "Select Top 1 * from Onlinestudent_EditScheduleBatch where module_Name='" + txt_Module.Text + "' And Schedule_id>" + submod_Id + "";
                //SqlDataReader dr;
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    dr.Read();
                    submodule_id = Convert.ToInt32(dr["Schedule_id"]);
                    module_name = dr["Module_Name"].ToString();
                    software_name = dr["Software_Name"].ToString();
                    mod_content = dr["Content"].ToString();
                    dr.Close();
                }
            }


            //Response.End();

            if (dt6.Rows.Count > 0)
            {
                holdate = dt6.Rows[0]["Hoilday_date"].ToString();
            }
            if (txt_BatchTrack.Text == "Normal" && txt_BatchSlot.Text == "MWF")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 5) && holdate == "")
                {
                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;

                    _Qry = "Update Onlinestudent_EditScheduleBatch set Date_Class='" + MyString + "' where Module_Name='" + txt_Module.Text + "'";
                    _Qry += " And Schedule_Id=" + submodule_id + "";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (txt_BatchTrack.Text == "Normal" && txt_BatchSlot.Text == "TTS")
            {

                if ((dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 6) && holdate == "")
                {

                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;

                    _Qry = "Update Onlinestudent_EditScheduleBatch set Date_Class='" + MyString + "' where Module_Name='" + txt_Module.Text + "'";
                    _Qry += " And Schedule_Id=" + submodule_id + "";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (txt_BatchTrack.Text == "Zip" && txt_BatchSlot.Text == "MWF")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 5) && holdate == "")
                {

                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;

                    _Qry = "Update Onlinestudent_EditScheduleBatch set Date_Class='" + MyString + "' where Module_Name='" + txt_Module.Text + "'";
                    _Qry += " And Schedule_Id=" + submodule_id + "";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (txt_BatchTrack.Text == "Zip" && txt_BatchSlot.Text == "TTS")
            {
                if ((dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 6) && holdate == "")
                {

                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;

                    _Qry = "Update Onlinestudent_EditScheduleBatch set Date_Class='" + MyString + "' where Module_Name='" + txt_Module.Text + "'";
                    _Qry += " And Schedule_Id=" + submodule_id + "";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }

            if (txt_BatchTrack.Text == "Fast" && txt_BatchSlot.Text == "Daily")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 5 || dayOfWeek(stdat) == 6) && holdate == "")
                {
                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;

                    _Qry = "Update Onlinestudent_EditScheduleBatch set Date_Class='" + MyString + "' where Module_Name='" + txt_Module.Text + "'";
                    _Qry += " And Schedule_Id=" + submodule_id + "";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }
            if (txt_BatchTrack.Text == "Zip" && txt_BatchSlot.Text == "Daily")
            {
                if ((dayOfWeek(stdat) == 1 || dayOfWeek(stdat) == 2 || dayOfWeek(stdat) == 3 || dayOfWeek(stdat) == 4 || dayOfWeek(stdat) == 5 || dayOfWeek(stdat) == 6) && holdate == "")
                {
                    i = i + 1;
                    z = z + 1;
                    submod_Id = submodule_id;

                    _Qry = "Update Onlinestudent_EditScheduleBatch set Date_Class='" + MyString + "' where Module_Name='" + txt_Module.Text + "'";
                    _Qry += " And Schedule_Id=" + submodule_id + "";

                    //Response.Write(_Qry);
                    //Response.End();

                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    if (i == noofcls)
                    {
                        lastday = stdat;
                    }
                }

                stdat = stdat.AddDays(1);

            }



        }
        string dob = lastday.ToString();
        string[] strSplitArr = dob.Split(' ');
        string dob1 = strSplitArr[0].ToString();

        //txt_enddate.Text = dob1;
        string dateTo = "";

        if (dob1 != "")
        {
            string str1 = dob1;
            string[] split1 = str1.Split('-');
            dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
        }

        _Qry = "Update Batch_Details set Batch_Enddate='" + dateTo + "' where Batch_Code='" + Request.QueryString["Batch_Code"] + "'";

        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);


        lblerror.Text = "Batch Scheduling Update Successfully";

        //Response.Write("Lastday is:" + dob1);
        //Response.End();

    }

}
