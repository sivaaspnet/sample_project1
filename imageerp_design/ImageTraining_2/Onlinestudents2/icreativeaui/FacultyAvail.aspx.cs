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

public partial class superadmin_FacultyAvail : System.Web.UI.Page
{
    string _Qry, _Qry1;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
           // fillgrid();
        
            txtfromdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txttodate.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
            fillfree();  
        }

        //Response.Write("Value Is:" + Session["SA_centre_code"]);
        //Response.End();

        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
        else
        {
            
        }

        //Lblfree.Text = "free";

       
    }
    private void fillgrid()
    {
     
        _Qry = "select Faculty_ID,replace(FacultyName,'~','''') as FacultyName,MWF,TTS,Daily,replace(ShiftTiiming,'~','''') as ShiftTiiming,";
        _Qry += "replace(Specialisation,'~','''') as Specialisation,[7amto9am],[9amto11am],[11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm] ";
        _Qry += "From Onlinestudentsfacultydetails Where Centre_Code='" + Session["SA_centre_code"] + "'";

        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    private void fillfree()
    {
        string stdate = "";
        stdate = txtfromdate.Text;
        string[] split = stdate.Split('-');
        stdate = split[1] + "/" + split[0] + "/" + split[2];
        string enddate = "";
        enddate = txttodate.Text;
        string[] split2 = enddate.Split('-');
        enddate = split2[1] + "/" + split2[0] + "/" + split2[2];
        string classdatemwf = "";
        string classdatetts = "";
        if (stdate != enddate)
        {
            _Qry = " select convert(varchar,classdate,101) as classdate from [spstartendclassdate]('" + stdate + "','" + enddate + "','MWF')";
            DataTable dtmwf = new DataTable();
            dtmwf = MVC.DataAccess.ExecuteDataTable(_Qry);
            for (int i = 0; i < dtmwf.Rows.Count; i++)
            {
                if (classdatemwf == "")
                {
                    classdatemwf = "'" + dtmwf.Rows[i]["classdate"].ToString() + "'";
                }
                else
                {
                    classdatemwf = classdatemwf + ",'" + dtmwf.Rows[i]["classdate"].ToString() + "'";
                }
            }
            _Qry = " select convert(varchar,classdate,101) as classdate from [spstartendclassdate]('" + stdate + "','" + enddate + "','TTS')";
            DataTable dttts = new DataTable();
            dttts = MVC.DataAccess.ExecuteDataTable(_Qry);
            for (int i = 0; i < dttts.Rows.Count; i++)
            {
                if (classdatetts == "")
                {
                    classdatetts = "'" + dttts.Rows[i]["classdate"].ToString() + "'";
                }
                else
                {
                    classdatetts = classdatetts + ",'" + dttts.Rows[i]["classdate"].ToString() + "'";
                }
            }

            _Qry1 = " select batchtiming,max(ss)  as batched,max(facultyId) as facultyId,convert(varchar,classdate,101) as classdate from (select   convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(facultyid) as ss,facultyId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101) between '" + stdate + "' and '" + enddate + "' and status='pending' and batchstatus='active'  and centrecode='" + Session["SA_centre_code"].ToString() + "' group by classdate,batchtiming,facultyid) as ss group by batchtiming,facultyId,convert(varchar,classdate,101)"; //(convert(varchar(10),dateadd(d,0,getdate()),101))
            // Response.Write(_Qry1);
            DataTable dtfac = new DataTable();
            dtfac = MVC.DataAccess.ExecuteDataTable(_Qry1);
            _Qry = " select faculty_id,ft.day,batchtime,facultyname from onlinestudentsfacultydetails fac inner join [erp_facultytimedetails] ft on ft.facultyid=fac.faculty_id  where fac.Status='Enable' and  fac.centre_code='" + Session["SA_centre_code"].ToString() + "'";
            // Response.Write(_Qry);
            DataTable dtfacname = new DataTable();
            dtfacname = MVC.DataAccess.ExecuteDataTable(_Qry);
            DataTable freefaculty = new DataTable();

            freefaculty.Columns.Add(new DataColumn("facultyname1", System.Type.GetType("System.String")));
            // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("sevenmwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("ninemwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("elevenmwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("onepmmwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("threepmmwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("fivepmmwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("sevenpmmwf", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("seventts", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("ninetts", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("eleventts", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("onepmtts", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("threepmtts", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("fivepmtts", System.Type.GetType("System.String")));
            freefaculty.Columns.Add(new DataColumn("sevenpmtts", System.Type.GetType("System.String")));
            DataRow drfac = freefaculty.NewRow();

            DataTable dtf = new DataTable();
            // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] arg = new string[2];

            arg[0] = "faculty_id";
            arg[1] = "facultyname";
            dtf = dtfacname.DefaultView.ToTable(true, arg);
            foreach (DataRow drs in dtf.Rows)
            {
                //string slotdate = "";
                //if (ddlslot.SelectedValue == "MWF")
                //{
                //    slotdate = "2,4,6";
                //}
                //else if (ddlslot.SelectedValue == "TTS")
                //{
                //    slotdate = "3,5,7";
                //}
                //else if (ddlslot.SelectedValue == "Daily")
                //{
                //    slotdate = "2,3,4,5,6,7";
                //}
                drfac = freefaculty.NewRow();
                drfac["facultyname1"] = drs["facultyname"];
                // dr["classdate1"] = "";
                drfac["sevenmwf"] = "-";
                drfac["seventts"] = "-";
                string mwfstring = "";
                string ttsstring = "";
                string res;
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='7AMto9AM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM'  and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        mwfstring = "MWF:" + res + "/";
                        drfac["sevenmwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='7AMto9AM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["seventts"] = res;
                    }
                }
                //drfac["seven1"] = mwfstring + ttsstring;

                mwfstring = "";
                ttsstring = "";
                drfac["ninemwf"] = "-";
                drfac["ninetts"] = "-";
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='9AMto11AM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        mwfstring = "MWF:" + res + "/";
                        drfac["ninemwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='9AMto11AM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["ninetts"] = res;
                    }
                }
                //drfac["nine1"] = mwfstring + ttsstring;
                mwfstring = "";
                ttsstring = "";
                drfac["elevenmwf"] = "-";
                drfac["eleventts"] = "-";
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='11AMto1PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        mwfstring = "MWF:" + res + "/";
                        drfac["elevenmwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='11AMto1PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["eleventts"] = res;
                    }
                }
                //drfac["eleven1"] = mwfstring + ttsstring;
                mwfstring = "";
                ttsstring = "";
                drfac["onepmmwf"] = "-";
                drfac["onepmtts"] = "-";
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='1PMto3PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        mwfstring = "MWF:" + res + "/";
                        drfac["onepmmwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='1PMto3PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["onepmtts"] = res;
                    }
                }
                //drfac["onepm1"] = mwfstring + ttsstring;
                mwfstring = "";
                ttsstring = "";
                drfac["threepmmwf"] = "-";
                drfac["threepmtts"] = "-";
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='3PMto5PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        mwfstring = "MWF:" + res + "/";
                        drfac["threepmmwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='3PMto5PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["threepmtts"] = res;
                    }
                }
                //drfac["threepm1"] = mwfstring + ttsstring;

                mwfstring = "";
                ttsstring = "";
                drfac["fivepmmwf"] = "-";
                drfac["fivepmtts"] = "-";
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='5PMto7PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        mwfstring = "MWF:" + res + "/";
                        drfac["fivepmmwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='5PMto7PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["fivepmtts"] = res;
                    }
                }
                // drfac["fivepm1"] = mwfstring + ttsstring;
                mwfstring = "";
                ttsstring = "";
                drfac["sevenpmmwf"] = "-";
                drfac["sevenpmtts"] = "-";
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (2,4,6) and batchtime='7PMto9PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatemwf + ")");
                    if (res != "")
                    {
                        ttsstring = "MWF:" + res;
                        drfac["sevenpmmwf"] = res;
                    }
                }
                if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (3,5,7) and batchtime='7PMto9PM'") > 0)
                {
                    res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatetts + ")");
                    if (res != "")
                    {
                        ttsstring = "TTS:" + res;
                        drfac["sevenpmtts"] = res;

                    }
                }
                //drfac["sevenpm1"] = mwfstring + ttsstring;

                freefaculty.Rows.Add(drfac);
            }
            if (freefaculty.Rows.Count > 0)
            {
                avail.Visible = true;
                rpfac.DataSource = freefaculty;
                rpfac.DataBind();
            }
        }
    }

    int getfreeclassdetails(DataTable dtexp, string expression)
    {
        int count = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            count += 1;
        }
        return count;
    }

    string getfreefaculty(DataTable dtexp, string expression)
    {
        string res = "<span style='color:green; font-weight:bold'>F</span>";
        int batched = 0;
        DataRow[] dr = new DataRow[100];

        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                batched = Convert.ToInt32(val["batched"]);
            }
        }
        if (batched > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>B</span>";
        }
        return res.ToString();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
  
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
       // fillgrid();
        fillfree();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

    
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell Cell_Header = new TableCell();

            Cell_Header = new TableCell();
            Cell_Header.Text = "Faculty Name";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Shift Timing";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "7am to 9am";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "9am to 11am";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "11am to 1pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "1pm to 3pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "3pm to 5pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "5pm to 7pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "7pm to 9pm";
            //Cell_Header.Style["Align"] = "center";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
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
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            //e.Row.Cells[4].Visible = false;
            //e.Row.Cells[5].Visible = false;
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        fillfree();
    }
}
