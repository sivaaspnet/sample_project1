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

public partial class superadmin_closingstatusview : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            filltable();
            fillcoursedropdown();
            fillcoursedropdown1();
        }
    }
    private void fillcoursedropdown()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program Group By a.Program,a.course_id,b.Program";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txt_courseasked.DataSource = dt;
        txt_courseasked.DataValueField = "course_id";
        txt_courseasked.DataTextField = "Program";
        txt_courseasked.DataBind();
        txt_courseasked.Items.Insert(0, new ListItem("Select", ""));

    }

    private void fillcoursedropdown1()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program Group By a.Program,a.course_id,b.Program";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        txt_coursepositioned.DataSource = dt;
        txt_coursepositioned.DataValueField = "course_id";
        txt_coursepositioned.DataTextField = "Program";
        txt_coursepositioned.DataBind();
        txt_coursepositioned.Items.Insert(0, new ListItem("Select", ""));

    }
    private void filltable()
    {
        _Qry = "select enq_courseasked,centre_code,enq_coursepositioned,enq_enqstatus,enq_number,enq_enrol_date from Img_enquiryform1 where enq_number='" + Request.QueryString["enqno"] + "'";
        
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lblenq_id.Text = dt.Rows[0]["enq_number"].ToString();
            lblcentrecode.Text = dt.Rows[0]["centre_code"].ToString();
            //if (dt.Rows[0]["enq_courseasked"] != null)
            //{
           txt_courseasked.SelectedValue = dt.Rows[0]["enq_courseasked"].ToString();
            //}
            //else
            //{
            //    txt_courseasked.SelectedValue = 1;
            //}
            txt_coursepositioned.SelectedValue = dt.Rows[0]["enq_coursepositioned"].ToString();
            //int result;
            //int.TryParse(dt.Rows[0]["enq_courseasked"].ToString(), out result);
            //if(result!=0)
            //{
            //    int course_id = Convert.ToInt32(dt.Rows[0]["enq_courseasked"].ToString());

            //    _Qry = "Select Program,course_id from img_coursedetails Where Course_Id=" + course_id + "";
            //    DataTable dtpro = new DataTable();
            //    dtpro = MVC.DataAccess.ExecuteDataTable(_Qry);
            //    if (dtpro.Rows.Count > 0)
            //    {
            //        txt_courseasked.SelectedValue = dtpro.Rows[0]["Program"].ToString();
            //    }
            //    else
            //    {
            //    }
            //}
            //else
            //{

            //    if (dt.Rows[0]["enq_courseasked"].ToString() == "" || dt.Rows[0]["enq_courseasked"].ToString() == null)
            //    {
            //    }
            //    else
            //    {
            //        txt_courseasked.SelectedValue = dt.Rows[0]["enq_courseasked"].ToString();
            //    }
            //}

            //int result1;
            //int.TryParse(dt.Rows[0]["enq_coursepositioned"].ToString(), out result1);
            //if (result1 != 0)
            //{
            //    int course_id1 = Convert.ToInt32(dt.Rows[0]["enq_coursepositioned"].ToString());

            //    _Qry = "Select Program from img_coursedetails Where Course_Id=" + course_id1 + "";
            //    DataTable dtpro1 = new DataTable();
            //    dtpro1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            //    if (dtpro1.Rows.Count > 0)
            //    {
            //        txt_coursepositioned.SelectedValue = dtpro1.Rows[0]["Program"].ToString();
            //    }
            //    else
            //    {
            //    }
         }
            else
            {
                if (dt.Rows[0]["enq_coursepositioned"].ToString() == "" || dt.Rows[0]["enq_coursepositioned"].ToString() == null)
                {
                }
                else
                {
                    txt_coursepositioned.SelectedValue = dt.Rows[0]["enq_coursepositioned"].ToString();
                }
            }
            
            //lblcscpositioned.Text = dt.Rows[0]["enq_coursepositioned"].ToString();
            string dob = dt.Rows[0]["enq_enrol_date"].ToString();
            string[] strSplitArr = dob.Split(' ');
            string dob1 = strSplitArr[0].ToString();

            string dob2 = dob1;
            string[] strSplitArr1 = dob2.Split('/');

            //string smonth = "0"+strSplitArr1[0].ToString();

            string smonth = "";
            int smonth1 = Convert.ToInt32(strSplitArr1[0]);

            if (smonth1 < 9)
            {
                smonth = "0" + strSplitArr1[0].ToString();
            }
            else
            {
                smonth = strSplitArr1[0].ToString();
            }

            string sdate = strSplitArr1[1].ToString();
            string syear = strSplitArr1[2].ToString();

            string apdate = sdate + "-" + smonth + "-" + syear;
            lblenrolldate.Text = apdate;

            if (lblenrolldate.Text == "1-01-1900")
            {
                lblenrolldate.Text = "";
            }

        }
        
  

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        

        string dob2 = lblenrolldate.Text;
        string[] strSplitArr1 = dob2.Split('-');

        string smonth = strSplitArr1[1].ToString();
        string sdate = strSplitArr1[0].ToString();
        string syear = strSplitArr1[2].ToString();

        string apdate = syear + "-" + smonth + "-" + sdate;
        //Response.Write(apdate);
        //Response.End();
        _Qry = "update Img_enquiryform1 set enq_courseasked='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseasked.SelectedValue) + "',enq_coursepositioned='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_coursepositioned.SelectedValue) + "',enq_enrol_date='" + apdate + "',Modified_By='" + Session["SA_Username"] + "' where enq_number='" + lblenq_id.Text + "' and centre_code='" + lblcentrecode.Text + "'";
        //Response.Write(_Qry);
        //Response.End();
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

        filltable();
        lblerrormsg.Text = "Closing status details updated sucessfully";
    }
}
