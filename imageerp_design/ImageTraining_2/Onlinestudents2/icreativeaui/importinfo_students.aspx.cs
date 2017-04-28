using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Data.Odbc;
using System.Collections;

public partial class ImageTraining_2_Onlinestudents2_icreativeaui_importinfo_students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("Welcome.aspx");
        }
    }
    protected void uploadexcel(object sender, EventArgs e)
    {
        DataTable invaliddt = new DataTable();
        invaliddt.Columns.Add("studentid");
        invaliddt.Columns.Add("studentname"); 
        invaliddt.Columns.Add("coursename"); 
        invaliddt.Columns.Add("centrecode"); 
        invaliddt.Columns.Add("dateins");

        DataTable dtfinal = new DataTable();
        dtfinal.Columns.Add("studentid");
        dtfinal.Columns.Add("studentname");
        dtfinal.Columns.Add("coursename");
        dtfinal.Columns.Add("centrecode");
        dtfinal.Columns.Add("dateins");
        //checking from infotainment db
        DataTable dtinfo = info.DataAccess.ExecuteDataTable(info.DataAccess.ConnectionString, "select studentid,centercode,invoiceid from erp_invoicedetails where centercode='" + Session["SA_centre_code"].ToString() + "'");
       //checking from ctech db
        DataTable dtctech_info = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, "select studentid,centrecode from erp_infostudentlist");
        string excelPath = Server.MapPath("excel/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
        //  lblnote.Text = "path::::::::::::::::"+excelPath+"";
        FileUpload1.SaveAs(excelPath);


        string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

        string conString = string.Empty;
        switch (extension)
        {
            case ".xls": //Excel 97-03
                conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'";
                break;
            case ".xlsx": //Excel 07
                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'";
                break;
        }
      //  connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties='Excel 8.0;HDR=YES'";
        conString = String.Format(conString, excelPath);
        //try
        //{
        using (OleDbConnection excel_con = new OleDbConnection(conString))
        {
            excel_con.Open();
            DataTable dtExcelData = new DataTable();
            string sheet1 = "sheet1";
            using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "$] where [studentid] is not null and [studentname] is not null and [coursename] is not null and [centrecode] is not null", excel_con))
            {
                oda.Fill(dtExcelData);
            }
            excel_con.Close();
            //string campus = Session["locationcode"].ToString();
            //string inserted_by = Session["username"].ToString();


            
            //DataColumn newCol = new DataColumn("uid", typeof(string));
            //newCol.AllowDBNull = true;
            //dtExcelData.Columns.Add(newCol);
            DataColumn newCol1 = new DataColumn("remove", typeof(string));
            newCol1.AllowDBNull = true;
            dtExcelData.Columns.Add(newCol1);
           
            DataColumn newCol3 = new DataColumn("dateins", typeof(string));
            newCol3.AllowDBNull = true;
            dtExcelData.Columns.Add(newCol3);
            
            

            Random _r = new Random();
            //int i = 0;
            //int j = 0;
            DataRow[] drfilter;
            
            foreach (DataRow row in dtExcelData.Rows)
            {

              
                row["dateIns"] = DateTime.Now.ToString("MM/dd/yyyy");
                DataRow[] drfilterstudid_info = dtinfo.Select("studentid='" + row["studentid"] + "'");
                DataRow[] drfilterstudid_ctechinfo = dtctech_info.Select("studentid='" + row["studentid"] + "'");
                if (drfilterstudid_info.Length == 0)//checking in info                 
                    row["remove"] = "yes";               
                else
                    row["remove"] = "no";
                if (drfilterstudid_ctechinfo.Length > 0)//cheking in ctech info
                    row["remove"] = "yes";
                else
                    row["remove"] = "no";
            }

            drfilter = dtExcelData.Select("remove='no'");//valid data


            DataRow[] invaliddr = dtExcelData.Select("remove='yes'");//invalid data
            //if (invaliddr.Length > 0)
            //    invaliddt = invaliddr.CopyToDataTable();



            foreach (DataRow dr in invaliddr)
            {
                invaliddt.ImportRow(dr);
            }

            int validcount = drfilter.Length;
            //  int invalidcount = totalcount - validcount;
            int insertedrowcount = 0; string text = "";
            if (drfilter.Length > 0)
            {
                foreach (DataRow dr in drfilter)
                {
                    dtfinal.ImportRow(dr);
                }
                //dtfinal = drfilter.CopyToDataTable();

                int i;
                int duplicatecount = 0;

                int invalidrowcount = 0;
                int invalidcourse = 0;

                string consString = MVC.DataAccess.ConnectionString;//import in ctech db
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                         sqlBulkCopy.DestinationTableName = "dbo.erp_infostudentlist";
                       sqlBulkCopy.ColumnMappings.Add("studentid", "studentid");
                       sqlBulkCopy.ColumnMappings.Add("studentname", "studentname");
                       sqlBulkCopy.ColumnMappings.Add("coursename", "coursename");
                        sqlBulkCopy.ColumnMappings.Add("centrecode", "centrecode");
                        sqlBulkCopy.ColumnMappings.Add("dateins", "dateins");                        
                        con.Open();
                        sqlBulkCopy.WriteToServer(dtfinal);
                        con.Close();
                    }


                   

                }
            }

            if (dtfinal.Rows.Count > 0)
            {
                text += dtfinal.Rows.Count + " record Inserted. ";
                if (invaliddt.Rows.Count > 0)
                {
                    text += " " + invaliddt.Rows.Count + "  record not inserted.  Click the link below to open invalid Records...";
                }
                lbl_errormsg.Text = text;               
            }

            else
            {
                text = " 0 record inserted. ";
                if (invaliddt.Rows.Count > 0)
                {
                    text += " " + invaliddt.Rows.Count + " record not inserted.   Click the link below to open invalid Records...";
                }
                lbl_errormsg.Text = text;
               


            }


        }
        
        //if (invaliddt.Rows.Count > 0)
        //{
        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        //    string fileExcel = "Invalid_Lead" + " - " + System.DateTime.Now.Millisecond.ToString() + ".xls";
        //    string filePath = Server.MapPath("profileimages");
        //    string fileName = filePath + "\\" + fileExcel;
        //    gd.DataSource = invaliddt;
        //    gd.DataBind();
        //    // Render grid view control.
        //    gd.RenderControl(htw);

        //    // Write the rendered content to a file.
        //    string renderedGridView = sw.ToString();
        //    System.IO.File.WriteAllText(fileName, renderedGridView);
        //    HyperLink1.Text = "Click here to open invalid Records";
        //    HyperLink1.NavigateUrl = "profileimages/" + fileExcel;
        //    HyperLink1.Attributes.Add("Class", "error1");
        //    HyperLink1.Attributes.Add("style", "display:block");
        //}
    }
}
