using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dashboard
/// </summary>
public class dashboard
{
	public dashboard()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string fromdate;
    public string todate;
    public string userid;
    public string usertype;
    public string centrecode;
    public string centreregion;
    public string year;
    public void fillEnrolledyear(DropDownList ddlyear)
    {
        string qry = "select distinct year(inv.dateins) as year from erp_invoicedetails inv order by year desc";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            ddlyear.DataSource = dt;
            ddlyear.DataTextField = "year";
            ddlyear.DataValueField = "year";
            ddlyear.DataBind();
            //ddlyear.Items.Insert(0,new ListItem("All",""));
        }
        else
        {
            ddlyear.Items.Insert(0, new ListItem("All", ""));
        }
    }
    public DataTable coursetype(dashboard dash)
    {
       string _Qry = @"select coursesegment as course,count(coursesegment) as studentsjoined  from (select coursesegment
from erp_invoicedetails inv inner join img_coursedetails cou on inv.courseid=cou.course_id and inv.status='active' and studentstatus='active'";
     
       if (dash.centrecode != "")
           _Qry += " and inv.centercode='" + dash.centrecode + "'";
       else if(dash.centreregion!="")
            _Qry += " and inv.centercode in (select centre_code from img_centredetails where centre_region='" + dash.centreregion+ "')";
       else if (dash.usertype == "Region Head")
            _Qry += " and inv.centercode in (select centreid from img_RTH_CentresFor_report where rthid='" + dash.userid + "')";
        _Qry +=" inner join adm_personalparticulars p on p.student_id=inv.studentid and p.centre_code=inv.centercode and substring(p.enq_number,1,3)<>'old' inner join adm_generalinfo b on inv.studentid=b.student_id ";
       if (dash.fromdate != "" && dash.todate != "")
        {
            _Qry += " and b.dateins between ('" + dash.fromdate + "') and DATEADD(day,1,'" + dash.todate + "')";
        }
        _Qry += " )  as sts  group by coursesegment";
        DataTable dttype = new DataTable();
        dttype = MVC.DataAccess.ExecuteDataTable(_Qry);
        return dttype;
    }

    public DataTable paymentmode(dashboard dash)
    {
        string qry = "select * from getdashboard_payment('" + dash.fromdate + "','" + dash.todate + "','" + dash.centrecode + "','" + dash.userid + "','"+dash.centreregion+"')";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(qry);
        return dt;
    }
    public DataTable enquiry_status(dashboard dash)
    {
        string qry = @"select b.enq_enqstatus as enquiry_status,Count(*) as count from img_enquiryform a inner join img_enquiryform1 b on a.enq_number=b.enq_number 
        where b.enq_enqstatus <> '' ";
        if (dash.centrecode != "")
            qry += " and a.centre_code='" + dash.centrecode + "'";
        else if (dash.centreregion != "")
            qry += " and a.centre_code in (select centre_code from img_centredetails where centre_region='" + dash.centreregion + "')";
        else if (dash.usertype == "Region Head")
            qry += " and a.centre_code in (select centreid from img_RTH_CentresFor_report where rthid='" + dash.userid + "')";
        if (dash.fromdate != "" && dash.todate != "")
        {
            qry += " and b.dateins between ('" + dash.fromdate + "') and DATEADD(day,1,'" + dash.todate + "')";
        }
        qry += "  group by b.enq_enqstatus order by count desc";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(qry);
        return dt;
    }
    public DataTable profile(dashboard dash)
    {
        string qry = @"select b.enq_student_profile as profile,Count(*) as count from img_enquiryform a inner join img_enquiryform1 b on a.enq_number=b.enq_number 
        where b.enq_student_profile <> '' ";       
        if (dash.centrecode != "")
            qry += " and a.centre_code='" + dash.centrecode + "'";
        else if (dash.centreregion != "")
            qry += " and a.centre_code in (select centre_code from img_centredetails where centre_region='" + dash.centreregion + "')";
        else if (dash.usertype == "Region Head")
            qry += " and a.centre_code in (select centreid from img_RTH_CentresFor_report where rthid='" + dash.userid + "')";
        if (dash.fromdate != "" && dash.todate != "")
        {
            qry += " and b.dateins between ('" + dash.fromdate + "') and DATEADD(day,1,'" + dash.todate + "')";
        }
        qry += "  group by b.enq_student_profile order by count desc";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(qry);
        return dt;
    }
    public DataSet source(dashboard dash)
    {
        string qry = @"select a.enq_aboutimage as source,Count(*) as count from img_enquiryform a inner join img_enquiryform1 b on a.enq_number=b.enq_number
         inner join adm_generalinfo adm on adm.enq_number=a.enq_number where a.enq_aboutimage<>'' ";
        if (dash.centrecode != "")
            qry += " and a.centre_code='" + dash.centrecode + "'"; 
        else if (dash.centreregion != "")
            qry += " and a.centre_code in (select centre_code from img_centredetails where centre_region='" + dash.centreregion + "')";
        else if (dash.usertype == "Region Head")
            qry += " and a.centre_code in (select centreid from img_RTH_CentresFor_report where rthid='" + dash.userid + "')";
        if (dash.fromdate != "" && dash.todate != "")
        {
            qry += " and b.dateins between ('" + dash.fromdate + "') and DATEADD(day,1,'" + dash.todate + "')";
        }
        qry += "  group by a.enq_aboutimage order by count desc";
        DataSet ds = MVC.DataAccess.ExecuteDataset(qry);
        return ds;
    }

    public DataSet coursedetails(dashboard dash)
    {
        string qry = @"select cou.program,count(inv.id) as count from erp_invoicedetails inv inner join img_coursedetails cou on inv.courseid=cou.course_id 
        inner join adm_personalparticulars p on p.student_id=inv.studentid and p.centre_code=inv.centercode and substring(p.enq_number,1,3)<>'old' inner join adm_generalinfo b on inv.studentid=b.student_id         
        where cou.year<>'2' ";
        if (dash.centrecode != "")
            qry += " and inv.centercode='" + dash.centrecode + "'";
        else if (dash.centreregion != "")
            qry += " and inv.centercode in (select centre_code from img_centredetails where centre_region='" + dash.centreregion + "')";
        else if (dash.usertype == "Region Head")
            qry += " and inv.centercode in (select centreid from img_RTH_CentresFor_report where rthid='" + dash.userid + "')";
        if (dash.fromdate != "" && dash.todate != "")
        {
            qry += " and inv.dateins between ('" + dash.fromdate + "') and DATEADD(day,1,'" + dash.todate + "')";
        }
        qry += "  group by cou.program order by count desc";
        DataSet ds = MVC.DataAccess.ExecuteDataset(qry);
        return ds;
    }
    public DataSet enrolldetails(dashboard dash)
    {
        string qry = @"select upper(CONVERT(varchar(3), inv.dateins, 100)) as mname,count(distinct inv.studentid) as count from erp_invoicedetails inv inner join img_coursedetails cou on inv.courseid=cou.course_id 
inner join adm_personalparticulars p on p.student_id=inv.studentid and p.centre_code=inv.centercode and substring(p.enq_number,1,3)<>'old' 
inner join adm_generalinfo b on inv.studentid=b.student_id where cou.year<>'2'   ";
        if (dash.centrecode != "")
            qry += " and inv.centercode='" + dash.centrecode + "'";
        else if (dash.centreregion != "")
            qry += " and inv.centercode in (select centre_code from img_centredetails where centre_region='" + dash.centreregion + "')";
        else if (dash.usertype == "Region Head")
            qry += " and inv.centercode in (select centreid from img_RTH_CentresFor_report where rthid='" + dash.userid + "')";
        if (dash.year != "")
        {
            qry += " and year(inv.dateins)='" + dash.year + "'";
        }
        qry += "  group by CONVERT(varchar(3), inv.dateins, 100),month(inv.dateins) order by month(inv.dateins)";
        DataSet ds = MVC.DataAccess.ExecuteDataset(qry);
        return ds;
    }
    public DataTable collection_summary(dashboard dash)
    {
        DataTable dt = new DataTable();
        if (dash.fromdate!="" && dash.todate!="")
        {
            SqlCommand comm = new SqlCommand("spDashboard_total");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("fromdate", dash.fromdate.Trim());
            comm.Parameters.AddWithValue("todate", dash.todate.Trim());
            comm.Parameters.AddWithValue("centreregion", dash.centreregion);
            comm.Parameters.AddWithValue("centrecodee", dash.centrecode);
            comm.Parameters.AddWithValue("useridRH", dash.userid);
           dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, comm);          
        }
        return dt;
    }
}

