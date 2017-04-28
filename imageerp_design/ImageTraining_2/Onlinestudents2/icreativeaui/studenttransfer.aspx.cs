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
using System.Text.RegularExpressions;

public partial class superadmin_addcentre : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6,centreid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {
            fillgrid();
            fillcentre();
        }
       
    }
    public string removetilde(string str)
    {
        return MVC.CommonFunction.ReplaceTildWithQuote(str);
      
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_searchcode.Text);
    }
    protected void Validate_Special2(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtc_studentid.Text);
    }
    private void fillcentre()
    {
        _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddc_centre.DataSource = dt;
        ddc_centre.DataTextField = "Centre_location";
        ddc_centre.DataValueField = "Centre_Code";
        ddc_centre.DataBind();
        ddc_centre.Items.Insert(0, new ListItem("Select", ""));    
    }
    private void fillgrid()
    {
        _Qry = @"select centre_location,studentid,transferedTo,enq_personal_name,reason from erp_studenttransfer st inner join  img_centredetails on transferedTo=centre_code
inner join adm_personalparticulars adm on adm.student_id=st.studentid   where transferedfrom='" + Session["SA_centre_code"].ToString() + "'";
        if (txt_searchcode.Text != "")
        {
            _Qry += " and studentid like '%" + txt_searchcode.Text + "%'";
        }
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();

    }
    private void insertcentre()
    {
        if (Page.IsValid)
        {
            _Qry = "select count(studentid) from erp_studenttransfer where studentid='" + txtc_studentid.Text + "'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "Request Already Sent...";

            }
            else
            {
                _Qry3 = "insert into erp_studenttransfer([studentid],[reason],[transferedTo],[transferedfrom],[dateins])values('" + txtc_studentid.Text + "','" + txtc_reason.Text + "','" + ddc_centre.SelectedValue + "','" + Session["SA_centre_code"].ToString() + "',getdate())";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry3);
                lblmsg1.Text = "Student  Transfer Request Sent Successfully";
                fillgrid();
                refresh();
            }
        }
        
    }
    
   
    private void refresh()
    {
        txtc_studentid.Text = "";
        txtc_reason.Text = "";
        ddc_centre.SelectedValue = "";
   
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       // centreupdate();
        insertcentre();
        refresh();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
      
    }
    private void centreupdate()
    {
           

    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            fillgrid();
        }

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        refresh();
    }
}
