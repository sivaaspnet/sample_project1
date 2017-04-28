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

public partial class ImageTraining_2_Onlinestudents2_superadmin_Default : System.Web.UI.Page
{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
        getstudentid();
    }
    private void getstudentid()
    {
        
        _Qry = " SELECT [admission_Id],[student_id] FROM [adm_personalparticulars] where admission_Id>0 ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        string js = "";
        string studentid = "";
        if (dt.Rows.Count > 0)
        {
            js = "<script language='javascript' type='text/javascript'>\n";
            js += "$(function() {\n";
            js += " var studentid=[";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (studentid == "")
                {
                    studentid = "'" + dt.Rows[i]["student_id"].ToString() + "'";
                }
                else
                {
                    studentid = studentid + "," + "'" + dt.Rows[i]["student_id"].ToString() + "'";
                }
            }

            js += "" + studentid + "];\n";
            js += "$( '#ContentPlaceHolder1_txt_studentid' ).autocomplete({source: studentid});\n";
            js += " });\n</script>";
        }
        Page.RegisterClientScriptBlock("studentid", js);
    }
}
