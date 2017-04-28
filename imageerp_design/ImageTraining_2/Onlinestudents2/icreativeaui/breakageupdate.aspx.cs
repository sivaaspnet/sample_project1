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

public partial class Onlinestudents2_superadmin_breakageupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string qry1 = "select studentId,receiptNo from erp_receiptDetails where studentId='" + txt_studid.Text + "' and receiptType='breakage' and receiptNo ='" + txt_recp_no.Text + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry1);
        if (dt.Rows.Count > 0)
        {
            string qry = "update erp_receiptDetails set amount='" + ddl_breakage.SelectedValue + "' ,totalamount='" + ddl_breakage.SelectedValue + "' where studentId='" + txt_studid.Text + "' and receiptNo ='" + txt_recp_no.Text + "'";
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
        Label1.Text = "Updated";
        }
        else
        {
            Label1.Text = "Invalid Student Infomation";
        }

        
    }
}
