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

public partial class analysisview : System.Web.UI.Page
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
            display_onload();
            fillcoursedropdown();
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
        txt_courseasked.DataValueField = "Program";
        txt_courseasked.DataTextField = "Program";
        txt_courseasked.DataBind();
        txt_courseasked.Items.Insert(0, new ListItem("Select", ""));

    }


    protected void Btn_update_Click(object sender, EventArgs e)
    {
        _Qry = "update Img_enquiryform1 set enq_coursepositioned='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_courseasked.SelectedValue) + "',enq_financialstatus='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblfinstatus.Text) + "',enq_interestlevel='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblinterest.Text) + "',enq_parent_support='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblparentsupport.Text) + "',enq_competitor_brand='" + MVC.CommonFunction.ReplaceQuoteWithTild(lblcompetitor.Text) + "',Modified_By='" + Session["SA_Username"] + "' where enq_number='" + lblenq_number.Text + "' and centre_code='" + Session["SA_centre_code"] + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

        _Qry1 = "update Img_enquiryform set enq_aboutimage='"+MVC.CommonFunction.ReplaceQuoteWithTild(lblabtimage.Text)+"' where enq_number='" + lblenq_number.Text + "' and centre_code='"+Session["SA_centre_code"]+"'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry1);

        display_onload();
        lblerrormsg.Text = "Analysis details updated sucessfully";
    }

    private void display_onload()
    {
        _Qry = "select f1.enq_id,f1.enq_number,f1.enq_aboutimage,enq_interestlevel,enq_coursepositioned,enq_financialstatus,enq_parent_support,enq_competitor_brand from Img_enquiryform f1 join Img_enquiryform1 f2 on f1.enq_number=f2.enq_number where f1.enq_number='" + Request.QueryString["enqno"] + "'";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lblenq_number.Text = dt.Rows[0]["enq_number"].ToString();

            int result;
            int.TryParse(dt.Rows[0]["enq_coursepositioned"].ToString(), out result);
            if(result!=0)
            {
                int course_id = Convert.ToInt32(dt.Rows[0]["enq_coursepositioned"].ToString());

                _Qry = "Select Program from img_coursedetails Where Course_Id=" + course_id + "";
                DataTable dtpro = new DataTable();
                dtpro = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dtpro.Rows.Count > 0)
                {
                    //lblcoursepositioned.Text = dtpro.Rows[0]["Program"].ToString();
                        txt_courseasked.SelectedValue = dtpro.Rows[0]["Program"].ToString();
                    //Response.Write(dtpro.Rows[0]["Program"].ToString());
                }
                else
                {
                    //txt_courseasked.SelectedValue = "";
                }
            }
            else
            {
                
                if (dt.Rows[0]["enq_coursepositioned"].ToString() == "" || dt.Rows[0]["enq_coursepositioned"].ToString() == null)
                {
                    //txt_courseasked.SelectedValue = "";
                }
                else
                {
                    txt_courseasked.SelectedValue = dt.Rows[0]["enq_coursepositioned"].ToString();
                }
                //lblcoursepositioned.Text = dt.Rows[0]["enq_coursepositioned"].ToString();
                //txt_courseasked.SelectedValue = dt.Rows[0]["enq_coursepositioned"].ToString();
                //Response.Write(dt.Rows[0]["enq_coursepositioned"].ToString());
            }

            lblfinstatus.Text = dt.Rows[0]["enq_financialstatus"].ToString();
            lblinterest.Text = dt.Rows[0]["enq_interestlevel"].ToString();
            lblparentsupport.Text = dt.Rows[0]["enq_parent_support"].ToString();
            lblcompetitor.Text = dt.Rows[0]["enq_competitor_brand"].ToString();
            lblabtimage.Text = dt.Rows[0]["enq_aboutimage"].ToString();
        }

    }
}
