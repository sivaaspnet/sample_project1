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
using System.Collections.Generic;

public partial class monthlycollection_owncentres : System.Web.UI.Page
{
    string _Qry, fromdate, todate;
    DataTable dt = new DataTable();
    int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }

        if (Session["SA_Master"] == null || Session["SA_Master"] == "")
        {
            Response.Redirect("masterpassword.aspx");
        }
        if (Session["SA_Centrerole"].ToString() == "CentreManager" || Session["SA_Centrerole"].ToString() == "SuperAdmin" || Session["SA_Centrerole"].ToString() == "Region Head")
        {
            if (!IsPostBack)
            {

                string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
                txtfromcalender2.Text = mon;
                txttocalender2.Text = DateTime.Now.ToString("dd-MM-yyyy");
                //filldatalist();
            }
           
        }
        else
        {
            Response.Redirect("masterpassword.aspx");
        }



    }
    

    

    

    
    protected string getfeesdetails()
    {
        string htmlstr = "";
        double totalfresh=0; double totalregistration=0; double totalregular=0; double totalothers=0; double grandtotal=0;
        if (txtfromcalender2.Text != "" && txttocalender2.Text != "")
        {
            string str = txtfromcalender2.Text;
            string[] split = str.Split('-');
            fromdate = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender2.Text;
            string[] split1 = str1.Split('-');
            todate = split1[2] + "-" + split1[1] + "-" + split1[0];

        }
        string[] centrecodes = { "ICH-101", "ICH-102", "ICH-103", "ICH-106", "ICH-108", "ICH-109", "ICA-101", "IBG-101", "IHY-102", "IBG-106", "ICA-101", "ITR-101", "IEK-101", "IKT-101", "IKL-101", "IPT-101", "ITM-101", "IEK-102", "ITU-101", "IKN-101", "IPD-101" };
        string[] centres = { "Alwarpet", "Adyar", "Anna Nagar", "Velachery", "T.Nagar", "Perambur", "Calicut", "Jaynagar", "Ameerpet", "Indira Nagar", "Calicut", "Thrissur", "valanjambalam", "Kottayam", "Kollam", "Pathanamthitta", "Tiruvandram", "Palarivattam", "thodupuzha", "kannur" ,"Palakkad"};
       foreach (string centrecode in centrecodes)
       {
           int index=Array.IndexOf(centrecodes,centrecode);
        string qry = "select * from getDashboard6('" + fromdate + "','" + todate + "','" + centrecode + "')";
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        if (dt.Rows.Count > 0)
        {
                  double lbl_tot_lumpcc1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
            //Totalfresh.Text = amts(lbl_tot_lumpcc1);
           double tot_lumpcc1 = Convert.ToDouble(dt.Rows[0]["totalRegcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRegDdcollectedtotal"].ToString());
           // RegTotal.Text = amts(tot_lumpcc1);
            double lbl_tot_inscc1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString());
           // Totalregular.Text = amts(lbl_tot_inscc1);
            double totalbreakage = Convert.ToDouble(dt.Rows[0]["totalbreakagecash"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalbreakagedd"].ToString());
           // TotalBreakage.Text = amts(totalbreakage);
           // htmlstr += "<tr><td></td><td></td><td></td><td></td></tr>";
            double totalamnt = lbl_tot_lumpcc1 + tot_lumpcc1 + lbl_tot_inscc1 + totalbreakage;
            totalfresh += lbl_tot_lumpcc1;
            totalregistration+=tot_lumpcc1;
            totalregular += lbl_tot_inscc1;
            totalothers += totalbreakage;
            grandtotal += totalamnt;
            htmlstr +=" <tr><td>"+(index+1)+"</td><td >"+centres[index]+"</td>";
            htmlstr += "<td align='right' >" + amts(lbl_tot_lumpcc1) + "</td>";
            htmlstr += "<td  align='right'>" + amts(tot_lumpcc1) + "</td>";
            htmlstr += "<td  align='right'>" + amts(lbl_tot_inscc1) + "</td>";
            htmlstr += "<td  align='right'>" + amts(totalbreakage) + "</td>";
            htmlstr += "<td  align='right'><strong>" + amts(totalamnt) + "</strong></td></tr>";
            //htmlstr += "<tr><td >Registration</td><td >" + amts(tot_lumpcc1) + "</td></tr>";
            //htmlstr += "<tr><td >Regular Collection</td><td >" + amts(lbl_tot_inscc1) + "</td></tr>";
            //htmlstr += "<tr><td >Others(Late,Break etc)</td><td >" + amts(totalbreakage) + "</td></tr>";
            //htmlstr += "<tr><td ><strong>Total</strong></td><td style='background-color: grey;'><strong>" + amts(totalamnt) + "</strong></td></tr>";
        }
        index = 0;
       }
        if(htmlstr!="")
            htmlstr += " <tr><td></td><td><strong>Grand Total<strong></td>";
        htmlstr += "<td  align='right'>" + amts(totalfresh) + "</td>";
        htmlstr += "<td  align='right'>" + amts(totalregistration) + "</td>";
        htmlstr += "<td  align='right'>" + amts(totalregular) + "</td>";
        htmlstr += "<td  align='right'>" + amts(totalothers) + "</td>";
        htmlstr += "<td  align='right'><strong>" + amts(grandtotal) + "</strong></td></tr>";
     
        return htmlstr;
    }

    

    
    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words =  amountvalue.ToString("#,000");
        }
        return words;
    }

   
    protected void btnsort1_Click(object sender, EventArgs e)
    {
        //filldatalist();
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=OwnCentres_MonthlyCollection.xls");
        Response.Charset = "";
        // If you want the option to open the Excel file without saving than
        // comment out the line below
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        wrap.RenderControl(htmlWrite);
        string style = @"<style> .textmode { } </style>";
        Response.Write(style);
        Response.Write(stringWrite.ToString());
        Response.Flush();
        Response.End();
        
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void GridView2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblName = new Label();
            lblName = (Label)e.Item.FindControl("lblstudentjoined");
            cnt += Convert.ToInt32(lblName.Text.ToString());

        }
    }
}
