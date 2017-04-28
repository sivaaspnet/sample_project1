using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ImageTraining_2_Onlinestudents2_img_auth_Moveoldstudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        fillgrid();
    }
    private void fillgrid()
    {
        string Qry = @"select * from [oldstudentdetails] where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='pending'";
        if (txtsearchid.Text != "")
        {
            Qry = Qry + " and oldstudentid like '%" + txtsearchid.Text + "%'";
        }
        DataTable dt4 = new DataTable();
        dt4 = MVC.DataAccess.ExecuteDataTable(Qry);
        GridView1.DataSource = dt4;
        GridView1.DataBind();
        GridView2.DataSource = dt4;
        GridView2.DataBind();
        lblerror.Text = "";
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkactivate")
        {
            string Qry = @"select * from [oldstudentdetails] where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='pending' and id= " + e.CommandArgument.ToString() + "";
        
           
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(Qry);
            if (dt.Rows.Count > 0)
            {
                lblstudentid.Text = dt.Rows[0]["oldstudentid"].ToString();
                lblstudentname.Text = dt.Rows[0]["studentname"].ToString();
                txtcurrentcoursefee.Text = Convert.ToDouble(Math.Round(Convert.ToDecimal(dt.Rows[0]["currentcoursefee"].ToString()), 0)).ToString();
                hdnid.Value = e.CommandArgument.ToString();
            }
        }


        if (e.CommandName == "lnkhide")
        {
            string Qry1 = @"update [oldstudentdetails] set status='Disable' where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='pending' and id= " + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qry1);
            fillgrid();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string Qry = @"select * from [oldstudentdetails] where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='pending' and id= '" + hdnid.Value + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(Qry);
            if (dt.Rows.Count > 0)
            {


                SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;

                cmd.CommandText = "[spdumpoldstudent]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
                cmd.Parameters.AddWithValue("studName", dt.Rows[0]["studentname"].ToString());
                cmd.Parameters.AddWithValue("stuprofile", dt.Rows[0]["profile"].ToString());
                cmd.Parameters.AddWithValue("aboutimage", dt.Rows[0]["source"].ToString());
                cmd.Parameters.AddWithValue("referedstudentname", "");
                cmd.Parameters.AddWithValue("mobileNo", dt.Rows[0]["mobile"].ToString());
                cmd.Parameters.AddWithValue("course", dt.Rows[0]["courseid"].ToString());
                cmd.Parameters.AddWithValue("track", dt.Rows[0]["track"].ToString());
                cmd.Parameters.AddWithValue("installmenttype", "Installment");
                cmd.Parameters.AddWithValue("initialAmt", txtinitialamt.Text);
                cmd.Parameters.AddWithValue("taxinitialAmt", "0");
                cmd.Parameters.AddWithValue("totalinitialAmt", txtinitialamt.Text);
                cmd.Parameters.AddWithValue("noofInstallment", txtnoinstallment.Text);
                cmd.Parameters.AddWithValue("cashType", "cash");
                cmd.Parameters.AddWithValue("bankname", "");
                cmd.Parameters.AddWithValue("chequeNo", "");
                cmd.Parameters.AddWithValue("chequeDt", "");
                cmd.Parameters.AddWithValue("userId", Session["SA_UserID"]);
                cmd.Parameters.AddWithValue("installmentDate", "");
                cmd.Parameters.AddWithValue("coursestartdate", "");
                cmd.Parameters.AddWithValue("coursefee", txtcurrentcoursefee.Text);
                cmd.Parameters.Add("@invoiceNo", SqlDbType.VarChar, 50);
                cmd.Parameters["@invoiceNo"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@newstudentid", SqlDbType.VarChar, 150);
                cmd.Parameters["@newstudentid"].Direction = ParameterDirection.Output;
                Conn.Open();
                cmd.ExecuteNonQuery();
                string inv_id = (string)cmd.Parameters["@invoiceNo"].Value;
                string newstudentid = (string)cmd.Parameters["@newstudentid"].Value;
                Conn.Close();
                switch (inv_id)
                {
                    case "E1":

                        lblerror.Text = "No running number in receipt";
                        break;
                    case "E2":
                        lblerror.Text = "No running number in invoice";
                        break;
                    case "E3":
                        lblerror.Text = "No Coursefees";
                        break;
                    case "E4":
                        lblerror.Text = "No details of user";
                        break;
                    case "E5":
                        lblerror.Text = "No centre code";
                        break;
                    case "E6":
                        lblerror.Text = "Student Already Enrolled";
                        break;
                    default:

                        string Qry1 = @"update [oldstudentdetails] set status='Moved',newstudentid='" + newstudentid + "' where centrecode='" + Session["SA_centre_code"].ToString() + "' and status='pending' and id= " + hdnid.Value + "";
                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qry1);

                        Server.Transfer("InvoiceDetails.aspx?invno=" + inv_id);

                        break;


                }
            }
        }
        catch(Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void btndownload_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=OldStudent-of-" + Session["SA_Location"] + "-center.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView2.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}