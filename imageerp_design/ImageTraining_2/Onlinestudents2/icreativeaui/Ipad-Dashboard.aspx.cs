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

public partial class superadmin_Dashboard : System.Web.UI.Page
{
    string _Qry;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            todayreport.Visible = false;
        }
        else
        {
            todayreport.Visible = true;
        }
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_Centrerole"] .ToString() == "Ipad")
        {

            fillsuperadmindashboard();
            if (!IsPostBack)
            {
                fill_centrecode();
               
                individualtable.Visible = false;
                View1.Visible = false;
            }        
        }


    }
 



    #region for paging in the grid
    protected void Gridviewcourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridviewcourse.PageIndex = e.NewPageIndex;
        //fillgrid();
    }
    #endregion

 


    #region for paging in the grid1
    protected void GriDVTECH_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GriDVTECH.PageIndex = e.NewPageIndex;
        //fillgd();
    }
    #endregion

    

    #region for filling the centre name for Super Admin
    private void fill_centrecode()
    {
        _Qry = @"SELECT distinct Centre_Location,b.centre_code from Img_Centre_coursefee_details a 
inner join Img_Centredetails b on a.centre_code = b.centre_code
 where a.runninginvoiceCentreCode='Ipad-100' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_cencode.DataSource = dt;
        ddl_cencode.DataValueField = "centre_code";
        ddl_cencode.DataTextField = "Centre_Location";
        ddl_cencode.DataBind();
        ddl_cencode.Items.Insert(0, new ListItem("Select", ""));
    }
    #endregion

    #region for displaying the Dashboard for the Super Admin

    private void fillsuperadmindashboard()
    {
        string fromdate = "";
        string todate = "";
        fromdate = DateTime.Now.ToString("MM/dd/yy");
        todate = DateTime.Now.ToString("MM/dd/yy");
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            fromdate = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            todate = split1[2] + "-" + split1[1] + "-" + split1[0];

        }
        string qry = "select * from getDashboard('" + fromdate + "','" + todate + "','')";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            lbltotalenquiry.Text = dt.Rows[0]["no_enquiry"].ToString();
            lblTotalenrollment.Text=dt.Rows[0]["no_enroll"].ToString();


            double lbltotlumpsum_tax1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"]);
            lbltotlumpsum_tax.Text = amts(lbltotlumpsum_tax1);

            double lbltotlumpsum_cheque1 = Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"]);
            lbltotlumpsum_cheque.Text = amts(lbltotlumpsum_cheque1);


            double lbl_totlump1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
            lbl_totlump.Text = amts(lbl_totlump1);
            
            
             double lbltotinstal_tax1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"]);
            lbltotinstal_tax.Text = amts(lbltotinstal_tax1);

            double lbltotinstal_cheque1 = Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"]);
            lbltotinstal_cheque.Text = amts(lbltotinstal_cheque1);

            double lbl_totins1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString());
            lbl_totins.Text = amts(lbl_totins1);



            double lbltotcollection_tax1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
            lbltotcollection_tax.Text = amts(lbltotcollection_tax1);
        }
    }

    #endregion

  
    private void filldatalist()
    {
        string fromdate = "";
        string todate = "";
        fromdate = DateTime.Now.ToString("MM/dd/yy");
        todate = DateTime.Now.ToString("MM/dd/yy");
        if (txtfromcalender2.Text != "" && txttocalender2.Text != "")
        {
            string str = txtfromcalender2.Text;
            string[] split = str.Split('-');
            fromdate = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender2.Text;
            string[] split1 = str1.Split('-');
            todate = split1[2] + "-" + split1[1] + "-" + split1[0];

        }
        if (ddl_cencode.SelectedValue != "")
        {
            string qry = "select * from getDashboard('" + fromdate + "','" + todate + "','"+ddl_cencode.SelectedValue+"')";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                lbl_tot_enq.Text = dt.Rows[0]["no_enquiry"].ToString();
                lbl_no_enroll.Text = dt.Rows[0]["no_enroll"].ToString();
                //lbl_tot_lusum.Text = dt.Rows[0]["totalcashcollectedtotal"].ToString();
                double lbl_tot_lusum1 =Convert.ToDouble( dt.Rows[0]["totalcashcollectedtotal"]);
                lbl_tot_lusum.Text = amts(lbl_tot_lusum1);
                double lbl_tot_lucheque1 = Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"]);
                lbl_tot_lucheque.Text = amts(lbl_tot_lucheque1);
                double lbl_tot_lumpcc1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
                lbl_tot_lumpcc.Text = amts(lbl_tot_lumpcc1);
                double lbl_tot_insamt1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"]);
                lbl_tot_insamt.Text = amts(lbl_tot_insamt1);
                double lbl_tot_inscheque1 = Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"]);
                lbl_tot_inscheque.Text = amts(lbl_tot_inscheque1);
                double lbl_tot_inscc1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString());
                lbl_tot_inscc.Text = amts(lbl_tot_inscc1);
                double lbl_fees_today1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
                lbl_fees_today.Text = amts(lbl_fees_today1);
            }
        }
    }


    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = "Rs " + amountvalue.ToString("#,000");
        }
        return words;
    }


    #region for selected index change of Centrecode
    protected void ddl_cencode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_cencode.SelectedValue == "")
        {
            visdate.Visible = false;
            individualtable.Visible = false;
            View1.Visible = false;
        }
        else
        {
            visdate.Visible = true;
            individualtable.Visible = true;
            //View1.Visible = true;
            filldatalist();
        }
    }
    #endregion
    protected void btnsort_Click(object sender, EventArgs e)
    {
        
        fillsuperadmindashboard();
    }
    protected void btnsort1_Click(object sender, EventArgs e)
    {
        filldatalist();
    }
}
