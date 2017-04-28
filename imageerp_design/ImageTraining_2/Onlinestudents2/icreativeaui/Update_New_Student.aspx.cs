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

public partial class ImageTraining_2_Onlinestudents2_superadmin_Update_New_Student : System.Web.UI.Page
{
    string insertqry;
    double totalamt = 0;
    double totalinstall = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillcourse();
        }


    }
    protected void fillcourse()
    {
        string qry = "select cd.course_id,cd.program from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and feed.centre_code='" + Session["SA_centre_code"].ToString() + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);

        ddlcourse.DataSource = dt;
        ddlcourse.DataValueField = "Course_Id";
        ddlcourse.DataTextField = "program";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("Select", ""));


        if (HdnId.Value != "")
        {
            BtnUpdate.Visible = true;
        }
        else
        {
            BtnUpdate.Visible = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
     
        string Qry = "Select id.studentid,ef.enq_number,ef.enq_personal_name,ef.enq_personal_email,ef.enq_personal_mobile,ef.centre_code,ef.enq_present_address,ef.enq_permanant_address,id.installno,id.batchTime,id.track,id.paymenttype,id.invoiceid,cd.Course_Id,id.coursefees from img_enquiryform ef inner join adm_personalparticulars pp on pp.enq_number=ef.enq_number inner join erp_invoicedetails id on pp.student_id=id.studentid inner join erp_studentcoursedetails escd on escd.studentid=id.studentid inner join img_coursedetails cd on cd.course_id=escd.courseid where  id.studentid='ich-111-03-3035' ";

        DataTable dtval = new DataTable();
        dtval = MVC.DataAccess.ExecuteDataTable(Qry);
        if (dtval.Rows.Count > 0)
        {
            //fillcourse();


            // From img_enquiryform table
            txtenqno.Text = dtval.Rows[0]["enq_number"].ToString();
            txt_name.Text = dtval.Rows[0]["enq_personal_name"].ToString();
            txtemail.Text = dtval.Rows[0]["enq_personal_email"].ToString();
            txtmobile.Text = dtval.Rows[0]["enq_personal_mobile"].ToString();
            txtcentercode.Text = dtval.Rows[0]["centre_code"].ToString();
            txttempaddress.Text = dtval.Rows[0]["enq_present_address"].ToString();
            txtpermaddress.Text = dtval.Rows[0]["enq_permanant_address"].ToString();


            // From erp_invoicedetails table
            HdnId.Value = dtval.Rows[0]["studentid"].ToString();
            txtcoursefees.Text = dtval.Rows[0]["coursefees"].ToString();
            txtinstalltype.Text = dtval.Rows[0]["paymenttype"].ToString();
            ddltrack.SelectedValue = dtval.Rows[0]["track"].ToString();
            txtbatch.Text = dtval.Rows[0]["batchTime"].ToString();
            txtinvoice.Text = dtval.Rows[0]["invoiceid"].ToString();
            txtinstall.Text = dtval.Rows[0]["installno"].ToString();

            // From img_coursedetails table
            ddlcourse.SelectedValue = dtval.Rows[0]["Course_Id"].ToString();
            
            
            
            
           
        }
       

        if (HdnId.Value != "")
        {
            BtnUpdate.Visible = true;
        }
        else
        {
            BtnUpdate.Visible = false;
        }
      
    }
   
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
       string  _Qry1 = "update img_enquiryform set enq_number='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtenqno.Text) + "',enq_personal_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_name.Text) + "',enq_personal_email='" + txtemail.Text + "',enq_personal_mobile='" + txtmobile.Text + "',centre_code='" + txtcentercode.Text + "',enq_present_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txttempaddress.Text) + "',enq_permanant_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtpermaddress.Text) + "',datemod=getdate() where enq_number='"+txtenqno.Text+"'";

        //Response.Write(_Qry);
        //Response.End();

        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);



        string _Qry2 = "update erp_invoicedetails set coursefees='" + txtcoursefees.Text + "',paymenttype='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstalltype.Text) + "',track='" + ddltrack.SelectedValue + "',batchTime='" + txtbatch.Text + "',invoiceid='" + txtinvoice.Text + "',installno='" + txtinstall.Text + "' where studentid='" + txtStudentId.Text + "'";

        //Response.Write(_Qry);
        //Response.End();

        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);



        string _Qry3 = "update img_coursedetails set program='" + ddlcourse.SelectedItem + "' where course_id='" + ddlcourse.SelectedValue + "'";

        //Response.Write(_Qry);
        //Response.End();

        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry3);

        lblerrormsg.Text = "New student details has been updated successfully";


        clear();


    }

    private void clear()
    {
       
        txtenqno.Text = "";
        txt_name.Text = "";
        txtemail.Text = "";
        txtmobile.Text = "";
        txtcentercode.Text = "";
        txttempaddress.Text = "";
        txtpermaddress.Text = "";
        HdnId.Value = "";
        txtcoursefees.Text = "";
        txtinstalltype.Text = "";
        ddltrack.SelectedValue = "";
        txtbatch.Text = "";
        txtinvoice.Text = "";
        txtinstall.Text = "";
        ddlcourse.SelectedValue = "";

        txtStudentId.Text = "";
    }


}
