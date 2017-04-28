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
using System.IO;
using System.Text;

public partial class ImageTraining_2_Onlinestudents2_superadmin_Popup10 : System.Web.UI.Page
{
    string _qry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill();
        }
    }

    public void fill()
    {
        _qry = "select c.projectname,b.module_content,a.Dispatchdate,a.projectguided_by,a.Senddate,CONVERT(VARCHAR,a.EvaluatedDate,105) as EvaluatedDate,a.Mark,a.EvaluatedBy,a.Remarks,a.Status from erp_studentprogress a inner join module_details b on a.moduleid=b.module_Id inner join projectdetails c on a.projectid=c.projectid where a.id='" + Request.QueryString["id"].ToString() + "'";
        DataTable d1 = new DataTable();
        d1 = MVC.DataAccess.ExecuteDataTable(_qry);
        if (d1.Rows.Count > 0)
        {

            //txtModule.Text = d1.Rows[0]["module_content"].ToString();
            //TextBox1.Text = d1.Rows[0]["projectname"].ToString();
            //txtDispatchdate.Text = d1.Rows[0]["Dispatchdate"].ToString();
            //txtproject.Text = d1.Rows[0]["projectguided_by"].ToString();
            //string send = d1.Rows[0]["Senddate"].ToString();
            //txtSenddate.Text = send;
            txtEvalDate.Text = d1.Rows[0]["EvaluatedDate"].ToString();
            txtmark.Text = d1.Rows[0]["Mark"].ToString();
            ddl_status.SelectedValue = d1.Rows[0]["Status"].ToString(); ;
            txtEvaluatedBy.Text = d1.Rows[0]["EvaluatedBy"].ToString();
            txtRemarks.Text = d1.Rows[0]["Remarks"].ToString();
        //    string dob = d1.Rows[0]["EvaluatedDate"].ToString();
        //    string[] strSplitArr = dob.Split(' ');
        //    string dob1 = strSplitArr[0].ToString();

        //    string dob2 = dob1;
        //    string[] strSplitArr1 = dob2.Split('/');

        //    //string smonth = "0"+strSplitArr1[0].ToString();

        //    string smonth = "";
        //    int smonth1 = Convert.ToInt32(strSplitArr1[0]);

        //    if (smonth1 < 9)
        //    {
        //        smonth = "0" + strSplitArr1[0].ToString();
        //    }
        //    else
        //    {
        //        smonth = strSplitArr1[0].ToString();
        //    }

        //    string sdate = strSplitArr1[1].ToString();
        //    string syear = strSplitArr1[2].ToString();

        //    string apdate = sdate + "-" + smonth + "-" + syear;
        //    txtEvalDate.Text = apdate;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string ss = txtEvalDate.Text;
        string[] split2 = ss.Split('-');
        string date1 = split2[2] + "-" + split2[1] + "-" + split2[0];
        _qry = @"update erp_studentprogress set Mark ='" + txtmark.Text + "',EvaluatedDate = '" + date1 + "',Remarks = '" + txtRemarks.Text + "',Status = '" + ddl_status.SelectedValue + "'  where id='" + Request.QueryString["id"] + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _qry);

        Response.Write("<script>window.parent.location.href = 'viewAssesment.aspx'</script>");

        
    }
}
