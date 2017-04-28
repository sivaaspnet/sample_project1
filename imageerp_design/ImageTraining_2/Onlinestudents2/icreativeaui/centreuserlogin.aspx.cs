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
using System.Text.RegularExpressions;


public partial class centreuserlogin : System.Web.UI.Page
{
    string _Qry;
    int i;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        fillgrid();
       
    }
    public string removetilde(string str)
    {
        return MVC.CommonFunction.ReplaceTildWithQuote(str);

    }
    public string maskpasswordcharacters(string str)
    {
        string subStr = string.Empty;
        if (str.Length > 4)
        {
            subStr = str.Substring(0, str.Length - 4);
            subStr = subStr + "####";

        }
        else
        {
        }
        return subStr;

    }
    public void fillgrid()
    {
        _Qry = "select b.centre_code,b.centre_location,b.centre_region,a.username,a.centre_useremail,a.userid,a.password,a.masterPassword from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.role='CentreManager'";
        if (txtsearchlocation.Text != "")
        {
            _Qry += " and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchlocation.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' ";
        }
        if (txtsearchname.Text != "")
        {
            _Qry += "and a.username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%'";
        }
        _Qry += "order by a.centre_id desc";
        //Response.Write(_Qry);
        //Response.End();
      
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();   
    }

    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Linkdownload_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(dt);
    }

    public void ExportTableData(DataTable dtdata)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + "Center_Details.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}
