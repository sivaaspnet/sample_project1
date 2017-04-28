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
using System.Web.Services;
public partial class DashboardV2 : System.Web.UI.Page
{
    dashboard dash=new dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            string mon = String.Format("{0:MM-01-yyyy}", DateTime.Now).Trim();
             txtfromcalender2.Text = mon;
              txttocalender2.Text = DateTime.Now.ToString("MM-dd-yyyy");
            //txtfromcalender2.Text = "04/01/2013";
            //txttocalender2.Text = "04/12/2017";
            ddlregionfill();
            fillyear();            
            //fillgrid();
            fillcoursetype();
            fillpaymentmode();
            fillprofile();
            fillcollectionsummary();
        }
        
    }
   
    [WebMethod]
    public static string getsource(data1 data1)
    {
      return GetData(data1).GetXml();
    }
    private static DataSet GetData(data1 data1)
    {
        DataSet ds = new DataSet();DataTable dt = new DataTable();
        dashboard dash = new dashboard();
        dash.usertype =HttpContext.Current.Session["SA_Centrerole"].ToString();
        dash.userid = "";
        dash.fromdate = data1.fromdate;
        dash.todate = data1.todate;
        dash.centrecode = data1.centrecode;
        dash.centreregion = data1.centreregion;
        if (data1.fromdate!="" && data1.todate!="")
        {            
            ds = dash.source(dash);            
        }       
        return ds;
    }
    [WebMethod]
    public static string getcourse(data1 data2)
    {
        return GetDatacourse(data2).GetXml();
    }
    private static DataSet GetDatacourse(data1 data1)
    {
        DataSet ds = new DataSet(); DataTable dt = new DataTable();
        dashboard dash = new dashboard();
        dash.usertype = HttpContext.Current.Session["SA_Centrerole"].ToString();
        dash.userid = "";
        dash.fromdate = data1.fromdate;
        dash.todate = data1.todate;
        dash.centrecode = data1.centrecode;
        dash.centreregion = data1.centreregion;
        if (data1.fromdate != "" && data1.todate != "")
        {
            ds = dash.coursedetails(dash);
        }
        return ds;
    }
    protected void fillyear()
    {
        dash.fillEnrolledyear(ddlyear);        
    }
    [WebMethod]
    public static string getenroll(data1 data3)
    {
        return GetDataEnroll(data3).GetXml();
    }
    private static DataSet GetDataEnroll(data1 data1)
    {
        DataSet ds = new DataSet(); DataTable dt = new DataTable();
        dashboard dash = new dashboard();
        dash.usertype = HttpContext.Current.Session["SA_Centrerole"].ToString();
        dash.userid = "";
        dash.year = data1.year;
        dash.centrecode = data1.centrecode;
        dash.centreregion = data1.centreregion;
        if (data1.year != "" )
        {
            ds = dash.enrolldetails(dash);
        }
        return ds;
    }
  
    public class data1
    {
        public string fromdate;
        public string todate;
        public string centrecode;
        public string centreregion;
        public string year;
    }
    //[WebMethod]
    //public static string getmonthwise(data1 data1)
    //{
    //    return getenrolledcount(data1).GetXml();
    //}
    //private static DataSet getenrolledcount(data1 data1)
    //{
    //    DataSet dt = new DataSet();
    //    dashboardbal bal = new dashboardbal();
    //    dashboarddal dal = new dashboarddal();
    //    if (HttpContext.Current.Session["locationcode"].ToString() != "")
    //    {
    //        dal.usertype = HttpContext.Current.Session["usertype"].ToString();
    //        if (dal.usertype == "Counsellor")
    //            dal.caname = HttpContext.Current.Session["username"].ToString();
    //        else
    //            dal.caname = "";
    //        dal.userid = "";
    //        dal.campus = Convert.ToInt32(HttpContext.Current.Session["locationcode"].ToString());
    //        dal.location = HttpContext.Current.Session["location"].ToString();
    //        dal.year = "";
    //        dal.lineyear = data1.year;
    //        dt = bal.performancechartbal(dal);
    //    }
    //    return dt;
    //}
    protected void ddlregionfill()
    {
        string qry = "select distinct centre_region from img_centredetails order by centre_region";
        DataTable dt = MVC.DataAccess.ExecuteDataTable(qry);
         ddlregion.DataSource = dt;
         ddlregion.DataTextField = "centre_region";
         ddlregion.DataValueField = "centre_region";
         ddlregion.DataBind();
         ddlregion.Items.Insert(0, new ListItem("All", ""));     
     
    }
    protected void ddlregionchanged(object sender,EventArgs e)
    {
        if (ddlregion.SelectedValue!= "")
        {
            string qry = "select centre_id,centre_code,centre_location from img_centredetails where centre_region='" + ddlregion.SelectedValue + "'";
            DataTable  dt1 = MVC.DataAccess.ExecuteDataTable(qry);
            ddlcentre.DataSource = dt1;
            ddlcentre.DataTextField = "centre_location";
            ddlcentre.DataValueField = "centre_code";
            ddlcentre.DataBind();
            ddlcentre.Items.Insert(0, new ListItem("All", ""));
            textarea.Visible = true;
        }
    }
    protected void fillcoursetype()
    {
      dash.usertype=Session["SA_Centrerole"].ToString();
      dash.userid = "";
      dash.fromdate = txtfromcalender2.Text;
      dash.todate = txttocalender2.Text;
      dash.centrecode = ddlcentre.SelectedValue;
      dash.centreregion = ddlregion.SelectedValue;
        DataTable dt = dash.coursetype(dash);
      if (dt.Rows.Count > 0)
      {
          foreach(DataRow dr in dt.Rows )
          {
            switch(dr["course"].ToString())
            {
                case "Certificate":
                    certificatecount.InnerText = dr["studentsjoined"].ToString();
                    //certificate.InnerText = "Certificate";
                    break;
                case "Diploma":
                    diplomacount.InnerText = dr["studentsjoined"].ToString();
                    //diploma.InnerText = "Diploma";
                    break;
                case "Higher Certificate":
                    hcertificatecount.InnerText = dr["studentsjoined"].ToString();
                    //hcertificate.InnerText = "Higher Certificate";
                    break;
                case "Higher Diploma":
                    hdiplomacount.InnerText = dr["studentsjoined"].ToString();
                    //hdiploma.InnerText = "Higher Diploma";
                    break;
            }
            }
      }
    }
    protected void fillpaymentmode()
    {
        string fromdate = "";string todate = "";int width = 0;
        dash.usertype = Session["SA_Centrerole"].ToString();
        dash.userid = "";
        //if (txtfromcalender2.Text != "" && txttocalender2.Text != "")
        //{
        //    string str = txtfromcalender2.Text;
        //    string[] split = str.Split('-');
        //    fromdate = split[2] + "-" + split[1] + "-" + split[0];

        //    string str1 = txttocalender2.Text;
        //    string[] split1 = str1.Split('-');
        //    todate = split1[2] + "-" + split1[1] + "-" + split1[0];

        //}
        dash.fromdate = txtfromcalender2.Text;
        dash.todate = txttocalender2.Text;
        dash.centrecode = ddlcentre.SelectedValue;
        dash.centreregion = ddlregion.SelectedValue;
        DataTable dt = dash.paymentmode(dash);
        if (dt.Rows.Count > 0)
        {
            #region paymentmode
            double cashamount = Convert.ToDouble(dt.Rows[0]["totalCashCollectedtotal"].ToString());
            double chequeamount = Convert.ToDouble(dt.Rows[0]["totalDDCollectedtotal"].ToString());
            double onlineamount = Convert.ToDouble(dt.Rows[0]["totalOnlineCollectedtotal"].ToString());
            double totalmount = cashamount + chequeamount + onlineamount;            
            lblcash.Text = amts(cashamount);
            lblcheque.Text = amts(chequeamount);
            lblonline.Text = amts(onlineamount);
            lbltotal.Text = amts(totalmount);            
            if (totalmount != 0)
            {
                divtotal.Attributes.Add("style", "width:100%");
                width = getpercent(totalmount, cashamount);
                divcash.Attributes.Add("style", "width:" + width + "%");
                width = getpercent(totalmount, chequeamount);
                divcheque.Attributes.Add("style", "width:" + width + "%");
                width = getpercent(totalmount, onlineamount);
                divonline.Attributes.Add("style", "width:" + width + "%");
            }
            #endregion
            #region enquiry
            string teleenq = dt.Rows[0]["tele_enquiry"].ToString();
            string walkinenq = dt.Rows[0]["no_enquiry"].ToString();
            string totenq = dt.Rows[0]["totalno_enquiry"].ToString();
            lblteleenq.Text = teleenq;
            lblwalkinenq.Text = walkinenq;
            lbltotenq.Text = totenq;
            if (totenq != "0")
            {
                hdntele.Value = getpercent(Convert.ToDouble(totenq), Convert.ToDouble(teleenq)).ToString();
                hdnwalkin.Value = getpercent(Convert.ToDouble(totenq), Convert.ToDouble(walkinenq)).ToString();
            }
            else
            {
                hdntele.Value = "0";
                hdnwalkin.Value = "0";
            }
            #endregion
        }
    }
    protected void fillprofile()
    {
        dash.usertype = Session["SA_Centrerole"].ToString();
        dash.userid = "";
        dash.fromdate = txtfromcalender2.Text;
        dash.todate = txttocalender2.Text;
        dash.centrecode = ddlcentre.SelectedValue;
        dash.centreregion = ddlregion.SelectedValue;
        DataTable dt = dash.profile(dash);
        string html = "";int list = 1;
        if(dt.Rows.Count>0)
        {
            double totalprofile = Convert.ToDouble(dt.Compute("sum(count)", "profile<>''"));
            int percentage = 0;
            foreach (DataRow dr in dt.Rows)
            {
                percentage = getpercent(totalprofile, Convert.ToDouble(dr["count"].ToString()));
                html += @"<li><div class='pro-list" + list + "'>";
                html += @"<div class='pro-vlu'>" + dr["count"].ToString() + "</div>";
                html += @"<div class='pro-dts'>
                <span class='pro-lt'>" + dr["profile"].ToString() + "</span><span class='pro-rt'>"+percentage+"%</span>";
                html+="<div class='clear'></div></div><div class='prt'><span style='width:"+percentage+"%'></span></div></div></li> ";
                if (list == 6)
                    list = 1;
                else  
                     list++;
            }
            holderprofile.Text = html;

        }
    }
    protected void fillcollectionsummary()
    {
        dash.usertype = Session["SA_Centrerole"].ToString();
        dash.userid = "";
        dash.fromdate = txtfromcalender2.Text;
        dash.todate = txttocalender2.Text;
        dash.centrecode = ddlcentre.SelectedValue;
        dash.centreregion = ddlregion.SelectedValue;
        DataTable dt = dash.collection_summary(dash);
        Gridview_collection.DataSource = dt;
        Gridview_collection.DataBind();
        
    }
    protected void Gridview_collection_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_collection.PageIndex = e.NewPageIndex;
        fillcollectionsummary();
    }
    protected void btnsort1_Click(object sender, EventArgs e)
    {
        fillcoursetype();
        fillpaymentmode();
        fillprofile();
        fillcollectionsummary();
    }
    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = amountvalue.ToString("#,000");
        }
        return words;
    }
    public int getpercent(double overall, double individual)
    {
        double div = individual / overall;
        double percentage = div * 100;
        if (percentage == 0)
            return 0;
        else if (percentage < 1 && percentage > 0)
            return 1;
        else
            return Convert.ToInt32(percentage);
    }
    #region old code
    protected void Gridview_dashboard_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != null && e.CommandName != "")
        {
            string[] arg = e.CommandArgument.ToString().Split(',');
            if (arg.Length > 1)
            {
                Session["dashCentreName"] = arg[1];
                Session["dashCentrecode"] = arg[0];
                Session["dashboardType"] = e.CommandName.ToString();
                Session["dashfromdate"] = txtfromcalender2.Text;
                Session["dashtodate"] = txttocalender2.Text;
                Response.Redirect("dashboardV2detail.aspx");
            }
        }

    }
   
    protected void fillgrid()
    {

        if (ddlregion.SelectedValue != "" && txtfromcalender2.Text.Trim() != "" && txttocalender2.Text.Trim() != "")
        {
            SqlCommand comm = new SqlCommand("spDashboard");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("fromdate", txtfromcalender2.Text.Trim());
            comm.Parameters.AddWithValue("todate", txttocalender2.Text.Trim());
            comm.Parameters.AddWithValue("region", ddlregion.SelectedValue);
            DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, comm);
          //  Gridview_dashboard.DataSource = dt;
          //  Gridview_dashboard.DataBind();
        }

    }
    protected string getdata()
    {
        string htmlstr = "";
        if (ddlregion.SelectedValue != "" && txtfromcalender2.Text.Trim() != "" && txttocalender2.Text.Trim() != "")
        {
            SqlCommand comm = new SqlCommand("spDashboard");
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("fromdate", txtfromcalender2.Text.Trim());
            comm.Parameters.AddWithValue("todate", txttocalender2.Text.Trim());
            comm.Parameters.AddWithValue("region", ddlregion.SelectedValue);
            DataTable dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, comm);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    htmlstr += " <tr><td>" + (i + 1).ToString() + "</td><td >" + dt.Rows[i]["centreName"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["BilledValue"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["DiplomaCount"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["CertificateCount"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["TotalCollection"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["FeesReceivable"].ToString() + "</td>";
                    htmlstr += "<td >" + dt.Rows[i]["DropoutAmount"].ToString() + "</td></tr>";
                }
            }
        }
        return htmlstr;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        wrap.Visible = true;
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Dashboard.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        wrap.RenderControl(htmlWrite);
        //string style = @"<style> .textmode { } </style>";
        //Response.Write(style);
        Response.Write(stringWrite.ToString());
        Response.Flush();
        Response.End();
    }
    #endregion
}
