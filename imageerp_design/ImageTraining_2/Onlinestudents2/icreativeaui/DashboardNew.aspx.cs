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
        //if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        //{
            if (!IsPostBack)
            {
                admindashboard();
            }
       // }
    }

    private void admindashboard()
    {
       // double feescash =0, feescheque=0;
        
        //enquiry 
        _Qry = "select count(*)as cnt1 from img_enquiryform1 ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry = _Qry + " where dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centre_code='" + Session["SA_centre_code"] + "'";
        }
        else
        {
            _Qry += " where convert(varchar,dateins,3)= convert(varchar,getdate(),3) and centre_code='" + Session["SA_centre_code"] + "'";
        }

        DataTable dt = new DataTable();

        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            lbltotalenquiry.Text = dt.Rows[0]["cnt1"].ToString();
        }
        else
        {
            lbltotalenquiry.Text = "0";
        }

        //enroll
        _Qry = "select count(*)as cnt3 from adm_generalinfo ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry = _Qry + " where dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centre_code='" + Session["SA_centre_code"] + "'";
        }
        else
        {
            _Qry += " where convert(varchar,dateins,3)= convert(varchar,getdate(),3) and centre_code='" + Session["SA_centre_code"] + "'";

        }

        int count3 = Convert.ToInt32(MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry));
        lblTotalenrollment.Text = count3.ToString();

        //total fees cash

        _Qry = "select  cast(sum(totalamount)as float) as totalcollection  from 	erp_receiptDetails ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry = _Qry + " where dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centerCode='" + Session["SA_centre_code"] + "' and paymentMode='Cash' and receiptType='Invoice'";
        }
        else
        {
            _Qry += " where convert(varchar,dateIns,3)= convert(varchar,getdate(),3) and centerCode='" + Session["SA_centre_code"] + "' and paymentMode='Cash' and receiptType='Invoice'";

        }

        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt1.Rows.Count > 0)
        {

            double feescash = Convert.ToDouble(dt1.Rows[0]["totalcollection"]);
            lbltotlumpsum_tax.Text = amts(feescash);
            txt_feescash.Text = dt1.Rows[0]["totalcollection"].ToString();
          
           
        }


       


        //total fees cheque

        _Qry = "select  sum(totalamount) as totalcollection from 	erp_receiptDetails ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry = _Qry + " where dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centerCode='" + Session["SA_centre_code"] + "' and (paymentMode='Cheque' or paymentMode='D.D' or paymentMode='C.C' ) and receiptType='Invoice'";
        }
        else
        {
            _Qry += " where convert(varchar,dateIns,3)= convert(varchar,getdate(),3) and centerCode='" + Session["SA_centre_code"] + "' and (paymentMode='Cheque' or paymentMode='D.D' or paymentMode='C.C') and receiptType='Invoice'";

        }

        DataTable dt2 = new DataTable();
        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt2.Rows.Count > 0)
        {
             

            double feecheque = Convert.ToDouble(dt2.Rows[0]["totalcollection"]);
            lbltotlumpsum_cheque.Text = amts(feecheque);
            txt_feescheque.Text = dt2.Rows[0]["totalcollection"].ToString();
            
        }
        else
        {
            lbltotlumpsum_cheque.Text = "0";
        }

//tottal collection 
        lbl_totlump.Text = txt_feescash.Text + txt_feescheque.Text;
        txt_feescashcheque.Text = txt_feescash.Text + txt_feescheque.Text;


        //total revenue cheque collection
        _Qry = "select sum(totalAmount) totalcollection  from erp_receiptdetails   ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry = _Qry + " where dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centerCode='" + Session["SA_centre_code"] + "' and (paymentMode='Cheque' or paymentMode='D.D' or paymentMode='C.C' ) and installNo<>0 ";
        }
        else
        {
            _Qry += " where convert(varchar,dateIns,3)= convert(varchar,getdate(),3) and centerCode='" + Session["SA_centre_code"] + "' and (paymentMode='Cheque' or paymentMode='D.D' or paymentMode='C.C') and  installNo<>0";

        }

        DataTable dt5 = new DataTable();
        dt5 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt5.Rows.Count > 0)
        {
            lbltotinstal_cheque.Text = dt5.Rows[0]["totalcollection"].ToString();
            txt_revcheque.Text = dt5.Rows[0]["totalcollection"].ToString();

        }
        else
        {
            lbltotinstal_cheque.Text = "0";
        }


        //total revenue cash collection

        _Qry = "select sum(totalAmount) as totalcollection from erp_receiptdetails ";
        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        {
            string str = txtfromcalender1.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender1.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

            _Qry = _Qry + " where dateIns between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "') and centerCode='" + Session["SA_centre_code"] + "' and (paymentMode='Cash' ) and installNo<>0  ";
        }
        else
        {
            _Qry += " where convert(varchar,dateIns,3)= convert(varchar,getdate(),3) and centerCode='" + Session["SA_centre_code"] + "' and (paymentMode='Cash') and installNo<>0  ";

        }

        DataTable dt6 = new DataTable();
        dt6 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt6.Rows.Count > 0)
        {
            lbltotinstal_tax.Text = dt6.Rows[0]["totalcollection"].ToString();
            txt_revcash.Text = dt6.Rows[0]["totalcollection"].ToString();

        }
        else
        {
            lbltotinstal_tax.Text = "0";
        }

        lbl_totins.Text = txt_revcash.Text + txt_revcheque.Text;
        txt_revcashcheque.Text = txt_revcash.Text + txt_revcheque.Text;
        lbltotcollection_tax.Text = txt_feescashcheque.Text + txt_revcashcheque.Text;
        
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


    protected void btnsort_Click(object sender, EventArgs e)
    {
        admindashboard();
    }
}
