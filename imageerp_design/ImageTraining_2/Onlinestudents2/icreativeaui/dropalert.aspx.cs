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

public partial class ImageTraining_2_Onlinestudents2_superadmin_dropalert : System.Web.UI.Page
{
    string _Qry,_Qry1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["studentid"] == null)
        {
            DropDownList1.Visible = true;
            Button1.Visible = true;
        }
        else
        {
            DropDownList2.Visible = true;
            Button2.Visible = true;
        }

    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
           _Qry = "update erp_batchcontentstatus set batchstatus='Deactive' where batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                _Qry += " update erp_batchdetails set dropdate=getdate(),status='Dropped', remarks='" + TextBox1.Text + "' where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and centrecode='" + Session["SA_centre_code"].ToString() + "'";
                 _Qry += " update erp_batchschedule set batchstatus='Deactive' where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and centrecode='" + Session["SA_centre_code"].ToString() + "'";
                 _Qry += " update adm_personalparticulars set remarks='" + TextBox1.Text + "',studentstatus='Break' where student_id in (select distinct bat.studentid from adm_personalparticulars per inner join erp_batchschedule bat on bat.studentid=per.student_id  where batchcode='" + Request.QueryString["batchcode"].ToString() + "')";
             MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

               _Qry = "select distinct studentid from adm_personalparticulars per inner join erp_batchschedule bat on bat.studentid=per.student_id  where batchcode='" + Request.QueryString["batchcode"].ToString() + "'";
                 DataTable dt = new DataTable();
                 dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                 if (dt.Rows.Count > 0)
                 {
                     
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         _Qry1 += " insert into erp_studentdrop (studentid,reason,droppeddate,status,centercode,action) values('" + dt.Rows[i]["studentid"].ToString() + "','" + TextBox1.Text + "',getdate(),'Break','" + Session["SA_centre_code"].ToString() + "','active')";

                     }
                     //Response.Write("<br>" + _Qry1);
                     MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                     showBox("Batch successfully dropped..!");
                     Response.Write("<script>window.parent.location.href = 'Editbatchslot.aspx'</script>");
                 }
                 else
                 {
                     showBox("Batch successfully dropped..!");
                     Response.Write("<script>window.parent.location.href = 'Editbatchslot.aspx'</script>");
                 }
      

    }

    
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["studentid"] != null)
        {
            _Qry = "update erp_batchschedule set dropdate=getdate() ,batchstatus='Deactive' where batchcode='" + Request.QueryString["batchcode"].ToString() + "' and centrecode='" + Session["SA_centre_code"].ToString() + "' and studentid='" + Request.QueryString["studentid"].ToString() + "'";
            _Qry += " update adm_personalparticulars set remarks='" + TextBox1.Text + "',studentstatus='Break' where student_id='" + Request.QueryString["studentid"].ToString() + "'";
            _Qry += " insert into erp_studentdrop (studentid,reason,droppeddate,status,centercode,action) values('" + Request.QueryString["studentid"].ToString() + "','"+TextBox1.Text+"',getdate(),'Break','"+Session["SA_centre_code"].ToString()+"','active')";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            showBox("Student dropped from the batch..!");
            Response.Write("<script>window.parent.location.href = 'batchstudentdrop.aspx?batchcode=" + Request.QueryString["batchcode"].ToString() + "'</script>");
            // Response.Redirect("batchstudentdrop.aspx?batchcode=" + Request.QueryString["batchcode"].ToString() + "");
        }
    }
}
