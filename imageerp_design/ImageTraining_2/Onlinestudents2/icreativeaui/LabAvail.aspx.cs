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

public partial class superadmin_LabAvail : System.Web.UI.Page
{
    string _Qry,_Qry1;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
           // fillfree();
           // fillgrid();
            txtfromdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txttodate.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
            fillfree();
            labname();
            ddl_labname.Items.Insert(0, new ListItem("Select", ""));
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }

        //Lblfree.Text = "free";

       
    }
    private void fillgrid()
    {
        //_Qry = "select LabId,[7amto9am] , [9amto11am] , [11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm],replace(Labname,'~','''')as Labname,replace(System,'~','''')as System from online_students_labavail where  Labname like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by LabId desc";

        //_Qry = "select LabId,(Select Count(*) From Batch_Details Where Batch_time='7amto9am' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += " as [7amto9am MWF] ,(Select Count(*) From Batch_Details Where Batch_time='7amto9am' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += " as [7amto9am TTS] ,(Select Count(*) From Batch_Details Where Batch_time='7amto9am' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += " as [7amto9am Daily] ,(Select Count(*) From Batch_Details Where Batch_time='9amto11am' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress')";
        //_Qry += "as [9amto11am MWF] ,(Select Count(*) From Batch_Details Where Batch_time='9amto11am' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress')";
        //_Qry += "as [9amto11am TTS] ,(Select Count(*) From Batch_Details Where Batch_time='9amto11am' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress')";
        //_Qry += "as [9amto11am Daily] ,(Select Count(*) From Batch_Details Where Batch_time='11amto1pm' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [11amto1pm MWF],(Select Count(*) From Batch_Details Where Batch_time='11amto1pm' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [11amto1pm TTS],(Select Count(*) From Batch_Details Where Batch_time='11amto1pm' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [11amto1pm Daily],(Select Count(*) From Batch_Details Where Batch_time='1pmto3pm' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [1pmto3pm MWF],(Select Count(*) From Batch_Details Where Batch_time='1pmto3pm' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [1pmto3pm TTS],(Select Count(*) From Batch_Details Where Batch_time='1pmto3pm' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [1pmto3pm Daily],(Select Count(*) From Batch_Details Where Batch_time='3pmto5pm' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [3pmto5pm MWF],(Select Count(*) From Batch_Details Where Batch_time='3pmto5pm' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [3pmto5pm TTS],(Select Count(*) From Batch_Details Where Batch_time='3pmto5pm' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [3pmto5pm Daily],(Select Count(*) From Batch_Details Where Batch_time='5pmto7pm' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [5pmto7pm MWF],(Select Count(*) From Batch_Details Where Batch_time='5pmto7pm' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [5pmto7pm TTS],(Select Count(*) From Batch_Details Where Batch_time='5pmto7pm' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [5pmto7pm Daily],(Select Count(*) From Batch_Details Where Batch_time='7pmto9pm' And Batch_Slot='MWF' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [7pmto9pm MWF],(Select Count(*) From Batch_Details Where Batch_time='7pmto9pm' And Batch_Slot='TTS' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [7pmto9pm TTS],(Select Count(*) From Batch_Details Where Batch_time='7pmto9pm' And Batch_Slot='Daily' And Batch_labname=online_students_labavail.LabName And Batch_Status='Inprogress') ";
        //_Qry += "as [7pmto9pm Daily],";
        //_Qry +="replace(Labname,'~','''')as Labname,replace(System,'~','''')as System from online_students_labavail where ";
        //_Qry += "Labname like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_labname.SelectedValue) + "%' And Centre_Code='" + Session["SA_centre_code"] + "' order by LabId desc";

        ////Response.Write(_Qry);
        ////Response.End();
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
    }
   
   private void refresh()
    {
        //txt_systems.Text = "";
        //txt_labname.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "edt")
        //{
        //    _Qry = "select Labname,LabId,System from online_students_labavail where LabId=" + e.CommandArgument.ToString() + "";
        //    DataTable dt = new DataTable();
        //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        //    if (dt.Rows.Count > 0)
        //    {
        //        txt_labname.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Labname"].ToString());
        //        txt_systems.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["System"].ToString());

        //        hiddn_id.Value = dt.Rows[0]["LabId"].ToString();
        //    }
        //}
        //if (e.CommandName == "del")
        //{
        //    _Qry = "delete from online_students_labavail where LabId='" + e.CommandArgument.ToString() + "'";
        //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
        //    fillgrid();
        //    lblmsg1.Text = "The lab details has been deleted successfully";
        //    refresh();
        //}
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillfree();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

       

        //if (hiddn_id.Value == "" || hiddn_id.Value == null)
        //{
        //    _Qry = "select count(LabId) from online_students_labavail where Labname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "' ";
        //    int count;
        //    count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
        //    if (count > 0)
        //    {
        //        lblmsg1.Text = "The lab name already exist";
        //    }
        //    else
        //    {
        //        //insert
        //       // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";


        //       _Qry = " INSERT INTO online_students_labavail (Labname , System , [7amto9am] , [9amto11am] , [11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm],Dateins,Datemod )VALUES ('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "', getdate(),getdate())";

              


        //        //Response.Write(_Qry);
        //        //Response.End();

        //        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
        //        fillgrid();
        //        lblmsg1.Text = "The lab details has been inserted successfully";
        //        refresh();
        //    }
        //}
        //else
        //{
        //    _Qry = "select count(LabId)from online_students_labavail where Labname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "' and LabId <> " + hiddn_id.Value + " ";
        //    int count;
        //    count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
        //    if (count > 0)
        //    {
        //        lblmsg1.Text = "The lab name already exist";
        //    }
        //    else
        //    {
        //        //update
        //        _Qry = "update online_students_labavail set Labname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "',System='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "',Dateins=getdate() where LabId=" + hiddn_id.Value + "";
        //        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
        //        fillgrid();
        //        lblmsg1.Text = "The lab details has been Updated successfully";
        //        refresh();
             
        //    }
        //}
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void labname()
    {


        _Qry = "select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_labname.DataSource = dt;
            ddl_labname.DataTextField = "Labname";
            ddl_labname.DataValueField = "LabId";
            ddl_labname.DataBind();

        }
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
            _Qry = "select convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(labId) as batchedlab,labId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101)  between '" + stdate + "' and '" + enddate + "'  and centrecode='" + Session["SA_centre_code"].ToString() + "' ";
            if (ddl_labname.SelectedValue != "")
            {
                _Qry += " and labid='" + ddl_labname.SelectedValue + "' ";
            }
            _Qry += " group by batchtiming,labId,convert(varchar(10),dateadd(d,0,classdate),101)";
            // Response.Write(_Qry+"<br>");
            DataTable dtlab = new DataTable();
            dtlab = MVC.DataAccess.ExecuteDataTable(_Qry);
            _Qry1 = " select labid,labname,system from online_students_labavail where centre_code='" + Session["SA_centre_code"].ToString() + "'";
            if (ddl_labname.SelectedValue != "")
            {
                _Qry1 += " and labid='" + ddl_labname.SelectedValue + "' ";
            }
            // Response.Write(_Qry1);
            DataTable dtlabcount = new DataTable();
            dtlabcount = MVC.DataAccess.ExecuteDataTable(_Qry1);

            DataTable freelab = new DataTable();

            freelab.Columns.Add(new DataColumn("labname1", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("Noofsys", System.Type.GetType("System.String")));
            // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("ninemwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("elevenmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("onepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("threepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("fivepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenpmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("seventts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("ninetts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("eleventts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("onepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("threepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("fivepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenpmtts", System.Type.GetType("System.String")));

            DataRow dr = freelab.NewRow();

            DataTable dt2 = new DataTable();
            // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] args = new string[3];

            args[0] = "labid";
            args[1] = "labname";
            args[2] = "system";

            dt2 = dtlabcount.DefaultView.ToTable(true, args);
            foreach (DataRow drs in dt2.Rows)
            {
                //string datecls = drs["classdate"].ToString();
                //string[] split = datecls.Split(',');
                //for (int i = 0; i < split.Length; i++)
                //{
                dr = freelab.NewRow();
                dr["labname1"] = drs["labname"];
                dr["Noofsys"] = drs["system"];
                // dr["classdate1"] = "";  //classdate in (" + classdatemwf + ")  and   //classdate in (" + classdatetts + ")  and
                dr["sevenmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and  batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
                dr["seventts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
                dr["ninemwf"] = getfreebatchedsystem(dtlab, "labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and  batchtiming='9AMto11AM'", Convert.ToInt32(drs["system"]));
                dr["ninetts"] = getfreebatchedsystem(dtlab, "labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='9AMto11AM'", Convert.ToInt32(drs["system"]));
                dr["elevenmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and  batchtiming='11AMto1PM'", Convert.ToInt32(drs["system"]));
                dr["eleventts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='11AMto1PM'", Convert.ToInt32(drs["system"]));
                dr["onepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and  batchtiming='1PMto3PM'", Convert.ToInt32(drs["system"]));
                dr["onepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='1PMto3PM'", Convert.ToInt32(drs["system"]));
                dr["threepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and  batchtiming='3PMto5PM'", Convert.ToInt32(drs["system"]));
                dr["threepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='3PMto5PM'", Convert.ToInt32(drs["system"]));
                dr["fivepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "'  and classdate in (" + classdatemwf + ") and  batchtiming='5PMto7PM'", Convert.ToInt32(drs["system"]));
                dr["fivepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='5PMto7PM'", Convert.ToInt32(drs["system"]));
                dr["sevenpmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and  batchtiming='7PMto9PM'", Convert.ToInt32(drs["system"]));
                dr["sevenpmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and  batchtiming='7PMto9PM'", Convert.ToInt32(drs["system"])); // and batchtiming='" + drs["batchtiming"].ToString() + "'
                freelab.Rows.Add(dr);
                // }
            }
            rplab.DataSource = freelab;
            rplab.DataBind();
        }
    }

    string getfreebatchedsystem(DataTable dtexp, string expression, int column)
    {
        string res = "";
        int batchedsystem = 0;
        int totalsystem = column;
        int freesystem = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                batchedsystem = Convert.ToInt32(val["batchedlab"]);
                freesystem = totalsystem - batchedsystem;
            }

        }
        if (batchedsystem > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>" + batchedsystem + " </span>/<span style='color:green; font-weight:bold;'>" + freesystem + " </span>";
        }
        else
        {
            res = "<span style='color:green; font-weight:bold;'>" + totalsystem + " </span>";
        }
        return res.ToString();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        fillfree();
		note.Visible=true;
    }
}
