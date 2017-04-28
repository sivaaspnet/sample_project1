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

public partial class ImageTraining_2_Onlinestudents2_superadmin_popup : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        expressupdate();
    }
    private void expressupdate()
    {
        _Qry = "select a.student_id,Enrolled_By,a.enq_personal_name,b.coursename,b.enq_number,isnull(a.student_lastname,'.*.') as ExpressEnrollSt from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where a.Admission_id>0  and isnull(a.student_lastname,'.*.')='.*.'";


        if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
        {
            _Qry = _Qry + "and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
        }
        _Qry = _Qry + " Order by a.Admission_id desc";
        // _Qry = _Qry + " Order by a.Admission_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        lbl_count.Text = dt.Rows.Count.ToString();

        GridView1.DataSource = dt;
        GridView1.DataBind();



        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl = new Label();
            HiddenField hdn = new HiddenField();

            lbl = (Label)gr.FindControl("lblStudId");
            hdn = (HiddenField)gr.FindControl("HdnExpressSt");
            HiddenField hdn1 = new HiddenField();
            hdn1 = (HiddenField)gr.FindControl("hdnEnqid");
            if (hdn.Value == ".*.")
            {
                lbl.Text = "<a href='expressupdate.aspx?end_id=" + hdn1.Value + "'>" + lbl.Text + "</a>";
                lbl.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            }

        }
    }
}
