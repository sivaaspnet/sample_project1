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

public partial class superadmin_Centerwisereport : System.Web.UI.Page
{
    string _Qry;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_Centrerole"] .ToString() == "Counselor")
        {
            //fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "CentreManager")
        {
            if (!IsPostBack)
            {
                //fill_centrecode();
                filldatalist();
                //individualtable.Visible = true;
                //View1.Visible = true;
            } 
            //fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "Technical Head")
        {
            //fillgd();
        }
        if (Session["SA_Centrerole"] .ToString() == "Ipad")
        {

            //fillsuperadmindashboard();
            if (!IsPostBack)
            {
                //fill_centrecode();
                filldatalist();
                //individualtable.Visible = true;
                //View1.Visible = true;
            }        
        }


    }
  
    

    #region for displaying the dashboard for specific centres
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

        string qry = "select * from IpadDashboard('" + fromdate + "','" + todate + "','" + Session["SA_centre_code"].ToString() + "')";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                lbl_tot_enq.Text = dt.Rows[0]["no_enquiry"].ToString();
                lbl_no_enroll.Text = dt.Rows[0]["no_enroll"].ToString();
                //lbl_tot_lusum.Text = dt.Rows[0]["totalcashcollectedtotal"].ToString();
                double lbl_tot_lusum1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"]);
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

    #endregion

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

   
    protected void btnsort1_Click(object sender, EventArgs e)
    {
        filldatalist();
    }
}
