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

public partial class superadmin_Centerwisereport : System.Web.UI.Page
{
    string _Qry, fromdate,todate;
    DataTable dt = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
        //{
        //    todayreport.Visible = false;
        //}
        //else
        //{
        //    todayreport.Visible = true;
        //}
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        
        if (Session["SA_Master"] == null || Session["SA_Master"] == "")
        {
            Response.Redirect("masterpassword.aspx");
        }
        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "SuperAdmin" || Session["SA_Centrerole"] .ToString() == "Region Head")
        {
            if (!IsPostBack)
            {

                string mon = String.Format("{0:01-MM-yyyy}", DateTime.Now).Trim();
                txtfromcalender2.Text = mon;
                txttocalender2.Text = DateTime.Now.ToString("dd-MM-yyyy");
                filltype();
                fillsource();
                fillprofile();
                filldatalist();
            }
            Label4.Text = txtfromcalender2.Text;
            Label5.Text = txttocalender2.Text;
        }
        else
        {
            Response.Redirect("masterpassword.aspx");
        }
      


    }
    //#region for displaying the Dashboard for the Counselor & CentreManager
    //void fillgrid()
    //{
    //    _Qry = "SELECT c1.course_id,c1.program,c1.coursename,f1.duration,f1.track,f1.lump_sum,f1.instal_amount from img_coursedetails c1 JOIN img_centre_coursefee_details f1 on c1.course_id=f1.program where centre_code='" + Session["SA_centre_code"] + "' ";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);

    //    Gridviewcourse.DataSource = dt;
    //    Gridviewcourse.DataBind();
    //}
    //#endregion



    //#region for paging in the grid
    //protected void Gridviewcourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    Gridviewcourse.PageIndex = e.NewPageIndex;
    //    //fillgrid();
    //}
    //#endregion


    //#region for displaying the Dashboard for the Technical Head
    //void fillgd()
    //{
    //    _Qry = "SELECT c1.course_id,c1.program,f1.duration,f1.track from img_coursedetails c1 JOIN img_centre_coursefee_details f1 on c1.course_id=f1.program where centre_code='" + Session["SA_centre_code"] + "' ";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    GriDVTECH.DataSource = dt;
    //    GriDVTECH.DataBind();
    //}
    //#endregion


    //#region for paging in the grid1
    //protected void GriDVTECH_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GriDVTECH.PageIndex = e.NewPageIndex;
    //    //fillgd();
    //}
    //#endregion

    //#region for filling the centre code for Super Admin
    //private void fill_centrecode()
    //{
    //    _Qry = "SELECT centre_code from img_centredetails group by centre_code";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    ddl_cencode.DataSource = dt;
    //    ddl_cencode.DataValueField = "centre_code";
    //    ddl_cencode.DataTextField = "centre_code";
    //    ddl_cencode.DataBind();
    //    ddl_cencode.Items.Insert(0, new ListItem("Select", ""));
    //}
    //#endregion

    #region for filling the centre name for Super Admin
    //private void fill_centrecode()
    //{
    //    _Qry = "SELECT Centre_Location,centre_code from Img_Centredetails where Centre_Location<>'Super' group by Centre_Location,centre_Code ";
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    ddl_cencode.DataSource = dt;
    //    ddl_cencode.DataValueField = "centre_code";
    //    ddl_cencode.DataTextField = "Centre_Location";
    //    ddl_cencode.DataBind();
    //    ddl_cencode.Items.Insert(0, new ListItem("Select", ""));
    //}
    #endregion

    #region for displaying the Dashboard for the Super Admin

    //private void fillsuperadmindashboard()
    //{
    //    //try
    //    //{
    //        _Qry = "select count(*)as cnt1 from img_enquiryform1  ";
    //        //_Qry += " And convert(varchar, dateins, 3)= convert(varchar, getdate(), 3)";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " where dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " where convert(varchar,dateins,3)= convert(varchar,getdate(),3)";
    //        }
    //        //Response.Write(_Qry);
    //        DataTable dt = new DataTable();

    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            lbltotalenquiry.Text = dt.Rows[0]["cnt1"].ToString();
    //        }
    //        else
    //        {
    //            lbltotalenquiry.Text = "0";
    //        }

    //        //Response.Write("test");
    //        //Response.End();
    //        string dat = System.DateTime.UtcNow.ToString("dd/MM/yyyy");

    //        _Qry = "select count(*)as cnt2 from  img_enquiryform1 ";
    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " Where dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " Where convert(varchar,dateins,3)= convert(varchar,getdate(),3)";
    //        }
    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            lbltodayenq.Text = dt.Rows[0]["cnt2"].ToString();
    //        }

    //        _Qry = "select count(*)as cnt3 from adm_generalinfo ";
    //        //_Qry += "  centre_code='" + ddl_cencode.SelectedValue + "'";


    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " where dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " where convert(varchar,dateins,3)= convert(varchar,getdate(),3)";
    //        }

    //        //Response.Write(_Qry);
    //        //Response.End();

    //        int count3 = Convert.ToInt32(MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry));
    //        lblTotalenrollment.Text = count3.ToString();

    //        //_Qry = "select count(*)as cnt3 from Ipad_studentid where centre_code='" + ddl_cencode.SelectedValue + "'";

    //        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        //if (dt.Rows.Count > 0)
    //        //{
    //        //    lbl_no_enroll.Text = dt.Rows[0]["cnt3"].ToString();
    //        //}
    //        _Qry = "SELECT COUNT(*) as bbb FROM (select count(*)as cnt4  from batch_details Where batch_status='Inprogress' group by batch_code)as aaa ";
    //        //Response.Write(_Qry);
    //        //Response.End();
    //        DataTable dt7 = new DataTable();
    //        dt7 = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt7.Rows.Count > 0)
    //        {
    //            lbl_no_batch.Text = dt7.Rows[0]["bbb"].ToString();
    //        }
    //        _Qry = "select * from adm_generalinfo where payment_pattern='Lump sum' ";
    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            _Qry = "select sum(payment_installments)as totalLumpamt from adm_generalinfo where payment_pattern='Lump sum' ";

    //            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //            if (dt.Rows.Count > 0)
    //            {

    //                if (dt.Rows[0]["totalLumpamt"].ToString() != "")
    //                {
    //                    //lbltotlumpsum.Text = "Rs " + dt.Rows[0]["totalLumpamt"].ToString();
    //                    double cfee = Convert.ToDouble(dt.Rows[0]["totalLumpamt"]) * 0.103;
    //                    double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["totalLumpamt"]);
    //                    //lbl_tot_lusum.Text = "Rs " + cfee_tax.ToString();
    //                }
    //                else
    //                {
    //                    //lbl_tot_lusum.Text = "Rs 0";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            //lbl_tot_lusum.Text = "Rs 0";
    //        }
    //        _Qry = "select * from adm_generalinfo where payment_pattern='Installment' ";
    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            _Qry = "select sum(payment_installments)as totalinstall from adm_generalinfo where payment_pattern='Installment' ";
    //            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //            if (dt.Rows.Count > 0)
    //            {
    //                if (dt.Rows[0]["totalinstall"].ToString() != "")
    //                {
    //                    double cfee = Convert.ToDouble(dt.Rows[0]["totalinstall"]) * 0.103;
    //                    double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["totalinstall"]);
    //                    //lbl_tot_insamt.Text = "Rs " + cfee_tax.ToString();
    //                }
    //                else
    //                {
    //                    //lbl_tot_insamt.Text = "Rs 0";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            //lbl_tot_insamt.Text = "Rs 0";
    //        }

    //        double sumamttax = 0;
    //        _Qry = " select tatamtpaidwithtax from install_amountdetails where Receipt_no is Not null";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3)";
    //        }

    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                if (dt.Rows[i]["tatamtpaidwithtax"] != "")
    //                {
    //                    sumamttax = sumamttax + Convert.ToDouble(dt.Rows[i]["tatamtpaidwithtax"]);

    //                    sumamttax = Math.Round(sumamttax, 0);

    //                    //string feeslump = sumamttax.ToString();
    //                    //string[] splitfee = feeslump.Split('.');
    //                    //int splitval=Convert.ToInt32(splitfee[1].ToString());
    //                    //string enrollfees=splitfee[0]  

    //                }
    //            }
    //            //lbl_fees_today.Text = "Rs " + sumamttax;
    //        }
    //        else
    //        {
    //            //lbl_fees_today.Text = "Rs 0";
    //        }

    //        double sumamttax1 = 0;
    //        _Qry = " select tatamtpaidwithtax from install_amountdetails  ";
    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " Where date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " Where convert(varchar,date,3)= convert(varchar,getdate(),3)";
    //        }
    //        _Qry += " And (select count(*) from adm_generalinfo where Student_id=install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        //convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no is Not null ";

    //        _Qry += " And (select count(*) from receipt_Details  where receipt_no=install_amountdetails.receipt_no";
    //        _Qry += "  And payment_mode='Cash')>0";
    //        //Response.Write(_Qry);
    //        //Response.End();

    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                if (dt.Rows[i]["tatamtpaidwithtax"] != "")
    //                {
    //                    sumamttax1 = sumamttax1 + Convert.ToDouble(dt.Rows[i]["tatamtpaidwithtax"]);
    //                    sumamttax1 = sumamttax1;
    //                    sumamttax1 = Math.Round(sumamttax, 0);
    //                }
    //            }
    //        }

    //        //------------------------------------------------------ Old Cash Installment Details ---------------------------

    //        //int cen_code = 0;

    //        //if (ddl_cencode.SelectedValue == "ICH-106" || ddl_cencode.SelectedValue == "ICH-106")
    //        //{
    //        //    cen_code = 6;
    //        //}
    //        //if (ddl_cencode.SelectedValue == "ICH-103" || ddl_cencode.SelectedValue == "ICH-103")
    //        //{
    //        //    cen_code = 3;
    //        //}

    //        double sumamttax1cash = 0;
    //        _Qry = " select total_install_amount from Old_install_amountdetails  ";
    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " Where date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " Where convert(varchar,date,3)= convert(varchar,getdate(),3)";
    //        }
    //        _Qry += " And (select count(*) from Oldenrolled_details where Student_id=Old_install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date_ins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date_ins,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        //convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no>0 ";

    //        _Qry += " And (select count(*) from Oldreceipt_Details where rec_no=Old_install_amountdetails.receipt_no";
    //        _Qry += "  And payment_mode like 'cash%')>0";
    //        //Response.Write("<br/>" + _Qry);
    //        //Response.End();

    //        DataTable dtold = new DataTable();
    //        dtold = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dtold.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dtold.Rows.Count; i++)
    //            {
    //                if (dtold.Rows[i]["total_install_amount"] != "")
    //                {
    //                    sumamttax1cash = sumamttax1cash + Convert.ToDouble(dtold.Rows[i]["total_install_amount"]);
    //                    sumamttax1cash = sumamttax1cash;
    //                    sumamttax1cash = Math.Round(sumamttax1cash, 0);
    //                }
    //            }
    //        }

    //        //Response.Write("<br/>sumamttax1 is:" + sumamttax1);
    //        //Response.Write("<br/>sumamttax1cash is:" + sumamttax1cash);
    //        double sumamttotcash = sumamttax1 + sumamttax1cash;
    //        //Response.Write("<br/>sumamttotcash is:" + sumamttotcash);

    //        if (sumamttotcash >= 10000000)
    //        {
    //            lbltotlumpsum_tax.Text = "Rs " + sumamttotcash.ToString("##\",\"00\",\"00\",\"000");
    //        }
    //        else if (sumamttotcash >= 100000)
    //        {
    //            lbltotlumpsum_tax.Text = "Rs " + sumamttotcash.ToString("##\",\"00\",\"000");
    //        }
    //        else
    //        {
    //            lbltotlumpsum_tax.Text = "Rs " + sumamttotcash.ToString("#,000");
    //        }

    //        if (sumamttotcash <= 0)
    //        {
    //            lbltotlumpsum_tax.Text = "Rs 0";
    //        }

    //        //--------------------------------------------------- Lump Cheque --------------------------------------


    //        double sumamttax1cheque = 0;
    //        _Qry = " select tatamtpaidwithtax from install_amountdetails  ";
    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " Where date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " Where convert(varchar,date,3)= convert(varchar,getdate(),3)";
    //        }
    //        _Qry += " And (select count(*) from adm_generalinfo where Student_id=install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        //convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no is Not null ";

    //        _Qry += " And (select count(*) from receipt_Details  where receipt_no=install_amountdetails.receipt_no";
    //        _Qry += "  And payment_mode='Cheque')>0";
    //        //Response.Write("<br/>" + _Qry);
    //        //Response.End();

    //        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                if (dt.Rows[i]["tatamtpaidwithtax"] != "")
    //                {
    //                    sumamttax1cheque = sumamttax1cheque + Convert.ToDouble(dt.Rows[i]["tatamtpaidwithtax"]);
    //                    sumamttax1cheque = sumamttax1cheque;
    //                    sumamttax1cheque = Math.Round(sumamttax1cheque, 0);
    //                }
    //            }
    //            //lbltotcollection_tax.Text = "Rs " + sumamttax;

    //            //if (sumamttax1cheque >= 10000000)
    //            //{
    //            //    lbl_tot_lucheque.Text = "Rs " + sumamttax1cheque.ToString("##\",\"00\",\"00\",\"000");
    //            //}
    //            //else if (sumamttax1cheque >= 100000)
    //            //{
    //            //    lbl_tot_lucheque.Text = "Rs " + sumamttax1cheque.ToString("##\",\"00\",\"000");
    //            //}
    //            //else
    //            //{
    //            //    lbl_tot_lucheque.Text = "Rs " + sumamttax1cheque.ToString("#,000");
    //            //}

    //            //lbl_tot_lucheque.Text = "Rs " + sumamttax1cheque.ToString("#,000");
    //        }
    //        //else
    //        //{
    //        //    //lbltotcollection_tax.Text = "Rs 0";
    //        //    lbl_tot_lucheque.Text = "Rs 0";
    //        //}


    //        //------------------------------------------------------ Old Cheque Installment Details ---------------------------

    //        //int cen_code = 0;

    //        //if (ddl_cencode.SelectedValue == "ICH-106" || ddl_cencode.SelectedValue == "ICH-106")
    //        //{
    //        //    cen_code = 6;
    //        //}
    //        //if (ddl_cencode.SelectedValue == "ICH-103" || ddl_cencode.SelectedValue == "ICH-103")
    //        //{
    //        //    cen_code = 3;
    //        //}

    //        double sumamttax1oldcheque = 0;
    //        _Qry = " select total_install_amount from Old_install_amountdetails  ";
    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " Where date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "')";
    //        }
    //        else
    //        {
    //            _Qry += " Where convert(varchar,date,3)= convert(varchar,getdate(),3)";
    //        }
    //        _Qry += " And (select count(*) from Oldenrolled_details where Student_id=Old_install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date_ins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date_ins,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        //convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no>0 ";

    //        _Qry += " And (select count(*) from Oldreceipt_Details where rec_no=Old_install_amountdetails.receipt_no";
    //        _Qry += "  And payment_mode like 'Cheque%')>0";
    //        //Response.Write("<br/>" + _Qry);
    //        //Response.End();

    //        DataTable dtoldc = new DataTable();
    //        dtoldc = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dtoldc.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dtoldc.Rows.Count; i++)
    //            {
    //                if (dtoldc.Rows[i]["total_install_amount"] != "")
    //                {
    //                    sumamttax1oldcheque = sumamttax1oldcheque + Convert.ToDouble(dtoldc.Rows[i]["total_install_amount"]);
    //                    sumamttax1oldcheque = sumamttax1oldcheque;
    //                    sumamttax1oldcheque = Math.Round(sumamttax1oldcheque, 0);
    //                }
    //            }
    //        }
    //        ////Response.Write("<br/>sumamttax1cheque is:" + sumamttax1cheque);
    //        ////Response.Write("<br/>sumamttax1oldcheque is:" + sumamttax1oldcheque);
    //        double sumamttotcheque = sumamttax1cheque + sumamttax1oldcheque;
    //        //Response.Write("<br/>sumamttotcheque is:" + sumamttotcheque);
    //        if (sumamttotcheque >= 10000000)
    //        {
    //            lbltotlumpsum_cheque.Text = "Rs " + sumamttotcheque.ToString("##\",\"00\",\"00\",\"000");
    //        }
    //        else if (sumamttotcheque >= 100000)
    //        {
    //            lbltotlumpsum_cheque.Text = "Rs " + sumamttotcheque.ToString("##\",\"00\",\"000");
    //        }
    //        else
    //        {
    //            lbltotlumpsum_cheque.Text = "Rs " + sumamttotcheque.ToString("#,000");
    //        }

    //        if (sumamttotcheque <= 0)
    //        {
    //            lbltotlumpsum_cheque.Text = "Rs 0";
    //        }


    //        //----------------------------------------------------- End ----------------------------------------------

    //        double lumptot;
    //        lumptot = sumamttotcash + sumamttotcheque;
    //        if (lumptot > 0)
    //        {
    //            if (lumptot >= 10000000)
    //            {
    //                lbl_totlump.Text = "Rs " + lumptot.ToString("##\",\"00\",\"00\",\"000");
    //            }
    //            else if (lumptot >= 100000)
    //            {
    //                lbl_totlump.Text = "Rs " + lumptot.ToString("##\",\"00\",\"000");
    //            }
    //            else
    //            {
    //                lbl_totlump.Text = "Rs " + lumptot.ToString("#,000");
    //            }

    //            //lbl_tot_lumpcc.Text = "Rs " + lumptot.ToString("#,000");
    //        }
    //        else
    //        {
    //            lbl_totlump.Text = "Rs 0";
    //        }

    //        //----------------------------------------------------- Total ---------------------------------------------

    //        double summamtinstall1 = 0;
    //        _Qry = "select tatamtpaidwithtax from install_amountdetails where (select count(*) from adm_generalinfo ";
    //        _Qry += "where Student_id=install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))=0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))=0";
    //        }

    //        _Qry += "  And (select count(*) from receipt_Details";
    //        _Qry += " where Student_id=install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        _Qry += " and (select count(*) from receipt_Details";
    //        _Qry += "  where Student_id=install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        }


    //        //_Qry += " convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no is Not null and Receipt_no in (select Receipt_no from receipt_Details";
    //        _Qry += " where Student_id=install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))";
    //        }

    //        //_Qry += " And Centre_code='" + ddl_cencode.SelectedValue + "'";

    //        _Qry += " And (select count(*) from receipt_Details  where receipt_no=install_amountdetails.receipt_no";
    //        _Qry += " And instal_no>0 And  payment_mode='Cash')>0";
    //        //Response.Write("<br/>" + _Qry);
    //        //Response.End();
    //        DataTable dt2 = new DataTable();
    //        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt2.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt2.Rows.Count; i++)
    //            {
    //                if (dt2.Rows[i]["tatamtpaidwithtax"] != "")
    //                {
    //                    summamtinstall1 = summamtinstall1 + Convert.ToDouble(dt2.Rows[i]["tatamtpaidwithtax"]);
    //                    summamtinstall1 = summamtinstall1;
    //                    summamtinstall1 = Math.Round(summamtinstall1, 0);
    //                }
    //            }

    //            //if (summamtinstall1 >= 10000000)
    //            //{
    //            //    lbl_tot_insamt.Text = "Rs " + summamtinstall1.ToString("##\",\"00\",\"00\",\"000");
    //            //}
    //            //else if (summamtinstall1 >= 100000)
    //            //{
    //            //    lbl_tot_insamt.Text = "Rs " + summamtinstall1.ToString("##\",\"00\",\"000");
    //            //}
    //            //else
    //            //{
    //            //    lbl_tot_insamt.Text = "Rs " + summamtinstall1.ToString("#,000");
    //            //}

    //            //lbltotcollection_tax.Text = "Rs " + sumamttax;
    //            //lbl_tot_insamt.Text = "Rs " + summamtinstall1.ToString("#,000");
    //        }

    //        //--------------------------------------------------- Old Installment Cash ----------------------------------------

    //        //if (ddl_cencode.SelectedValue == "ICH-106" || ddl_cencode.SelectedValue == "ICH-106")
    //        //{
    //        //    cen_code = 6;
    //        //}
    //        //if (ddl_cencode.SelectedValue == "ICH-103" || ddl_cencode.SelectedValue == "ICH-103")
    //        //{
    //        //    cen_code = 3;
    //        //}

    //        double summamtinstall1cash = 0;
    //        _Qry = "select total_install_amount from Old_install_amountdetails where (select count(*) from Oldenrolled_details ";
    //        _Qry += "where Student_id=Old_install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date_ins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))=0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date_ins,3)= convert(varchar,getdate(),3))=0";
    //        }

    //        _Qry += "  And (select count(*) from Oldreceipt_Details";
    //        _Qry += " where Student_id=Old_install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        _Qry += " and (select count(*) from Oldreceipt_Details";
    //        _Qry += "  where Student_id=Old_install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3))>0";
    //        }


    //        //_Qry += " convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no>0 and Receipt_no in (select rec_no from Oldreceipt_Details";
    //        _Qry += " where Student_id=Old_install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3))";
    //        }

    //        //_Qry += " And Center_code=" + cen_code + "";

    //        _Qry += " And (select count(*) from Oldreceipt_Details  where rec_no=Old_install_amountdetails.receipt_no";
    //        _Qry += " And instal_number>1 And  payment_mode like 'cash%')>0";
    //        //Response.Write("<br/>" + _Qry);
    //        //Response.End();
    //        DataTable dt2old = new DataTable();
    //        dt2old = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt2old.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt2old.Rows.Count; i++)
    //            {
    //                if (dt2old.Rows[i]["total_install_amount"] != "")
    //                {
    //                    summamtinstall1cash = summamtinstall1cash + Convert.ToDouble(dt2old.Rows[i]["total_install_amount"]);
    //                    summamtinstall1cash = summamtinstall1cash;
    //                    summamtinstall1cash = Math.Round(summamtinstall1cash, 0);
    //                }
    //            }
    //        }

    //        double suminscash = summamtinstall1 + summamtinstall1cash;


    //        if (suminscash >= 10000000)
    //        {
    //            lbltotinstal_tax.Text = "Rs " + suminscash.ToString("##\",\"00\",\"00\",\"000");
    //        }
    //        else if (suminscash >= 100000)
    //        {
    //            lbltotinstal_tax.Text = "Rs " + suminscash.ToString("##\",\"00\",\"000");
    //        }
    //        else
    //        {
    //            lbltotinstal_tax.Text = "Rs " + suminscash.ToString("#,000");
    //        }

    //        if (suminscash <= 0)
    //        {
    //            lbltotinstal_tax.Text = "Rs 0";
    //        }


    //        //------------------------------------------------------ Installment Cheque --------------------------------------

    //        double summamtinstall1cheque = 0;
    //        _Qry = "select tatamtpaidwithtax from install_amountdetails where (select count(*) from adm_generalinfo ";
    //        _Qry += "where Student_id=install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))=0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))=0";
    //        }

    //        _Qry += "  And (select count(*) from receipt_Details";
    //        _Qry += " where Student_id=install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        _Qry += " and (select count(*) from receipt_Details";
    //        _Qry += "  where Student_id=install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        }


    //        //_Qry += " convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no is Not null and Receipt_no in (select Receipt_no from receipt_Details";
    //        _Qry += " where Student_id=install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And dateins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,dateins,3)= convert(varchar,getdate(),3))";
    //        }

    //        //_Qry += " And Centre_code='" + ddl_cencode.SelectedValue + "'";

    //        _Qry += " And (select count(*) from receipt_Details  where receipt_no=install_amountdetails.receipt_no";
    //        _Qry += "  And payment_mode='Cheque')>0";
    //        //Response.Write("<br/>"+_Qry);
    //        //Response.End();
    //        DataTable dt2c = new DataTable();
    //        dt2c = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt2c.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt2c.Rows.Count; i++)
    //            {
    //                if (dt2c.Rows[i]["tatamtpaidwithtax"] != "")
    //                {
    //                    summamtinstall1cheque = summamtinstall1cheque + Convert.ToDouble(dt2c.Rows[i]["tatamtpaidwithtax"]);
    //                    summamtinstall1cheque = summamtinstall1cheque;
    //                    summamtinstall1cheque = Math.Round(summamtinstall1cheque, 0);
    //                }
    //            }

    //            //if (summamtinstall1cheque >= 10000000)
    //            //{
    //            //    lbl_tot_inscheque.Text = "Rs " + summamtinstall1cheque.ToString("##\",\"00\",\"00\",\"000");
    //            //}
    //            //else if (summamtinstall1cheque >= 100000)
    //            //{
    //            //    lbl_tot_inscheque.Text = "Rs " + summamtinstall1cheque.ToString("##\",\"00\",\"000");
    //            //}
    //            //else
    //            //{
    //            //    lbl_tot_inscheque.Text = "Rs " + summamtinstall1cheque.ToString("#,000");
    //            //}
    //            //lbltotcollection_tax.Text = "Rs " + sumamttax;
    //            //lbl_tot_inscheque.Text = "Rs " + summamtinstall1cheque.ToString("#,000");
    //        }
    //        //else
    //        //{
    //        //    //lbltotcollection_tax.Text = "Rs 0";
    //        //    lbl_tot_inscheque.Text = "Rs 0";
    //        //}

    //        //--------------------------------------------------- Old Installment cheque ----------------------------------------

    //        //if (ddl_cencode.SelectedValue == "ICH-106" || ddl_cencode.SelectedValue == "ICH-106")
    //        //{
    //        //    cen_code = 6;
    //        //}
    //        //if (ddl_cencode.SelectedValue == "ICH-103" || ddl_cencode.SelectedValue == "ICH-103")
    //        //{
    //        //    cen_code = 3;
    //        //}

    //        double summamtinstall1oldcheque = 0;
    //        _Qry = "select total_install_amount from Old_install_amountdetails where (select count(*) from Oldenrolled_details ";
    //        _Qry += "where Student_id=Old_install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date_ins between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))=0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date_ins,3)= convert(varchar,getdate(),3))=0";
    //        }

    //        _Qry += "  And (select count(*) from Oldreceipt_Details";
    //        _Qry += " where Student_id=Old_install_amountdetails.student_id ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3))>0";
    //        }

    //        _Qry += " and (select count(*) from Oldreceipt_Details";
    //        _Qry += "  where Student_id=Old_install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))>0";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3))>0";
    //        }


    //        //_Qry += " convert(varchar,dateins,3)= convert(varchar,getdate(),3))>0";
    //        _Qry += " and Receipt_no>0 and Receipt_no in (select rec_no from Oldreceipt_Details";
    //        _Qry += " where Student_id=Old_install_amountdetails.student_id  ";

    //        if (txtfromcalender1.Text != "" && txttocalender1.Text != "")
    //        {
    //            string str = txtfromcalender1.Text;
    //            string[] split = str.Split('-');
    //            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];

    //            string str1 = txttocalender1.Text;
    //            string[] split1 = str1.Split('-');
    //            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];

    //            _Qry = _Qry + " And date between ('" + dateFrom + "') and DATEADD(day,1,'" + dateTo + "'))";
    //        }
    //        else
    //        {
    //            _Qry += " And convert(varchar,date,3)= convert(varchar,getdate(),3))";
    //        }

    //        //_Qry += " And Center_code=" + cen_code + "";

    //        _Qry += " And (select count(*) from Oldreceipt_Details  where rec_no=Old_install_amountdetails.receipt_no";
    //        _Qry += " And instal_number>1 And  payment_mode like 'cheque%')>0";
    //        //Response.Write("<br/>" + _Qry);
    //        //Response.End();
    //        DataTable dt2oldcheque = new DataTable();
    //        dt2oldcheque = MVC.DataAccess.ExecuteDataTable(_Qry);
    //        if (dt2oldcheque.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dt2oldcheque.Rows.Count; i++)
    //            {
    //                if (dt2oldcheque.Rows[i]["total_install_amount"] != "")
    //                {
    //                    summamtinstall1oldcheque = summamtinstall1oldcheque + Convert.ToDouble(dt2oldcheque.Rows[i]["total_install_amount"]);
    //                    summamtinstall1oldcheque = summamtinstall1oldcheque;
    //                    summamtinstall1oldcheque = Math.Round(summamtinstall1oldcheque, 0);
    //                }
    //            }
    //        }

    //        //Response.Write(summamtinstall1cheque);
    //        //Response.Write(summamtinstall1oldcheque);
    //        //Response.End();
    //        double suminsoldcheque = summamtinstall1cheque + summamtinstall1oldcheque;


    //        if (suminsoldcheque >= 10000000)
    //        {
    //            lbltotinstal_cheque.Text = "Rs " + suminsoldcheque.ToString("##\",\"00\",\"00\",\"000");
    //        }
    //        else if (suminsoldcheque >= 100000)
    //        {
    //            lbltotinstal_cheque.Text = "Rs " + suminsoldcheque.ToString("##\",\"00\",\"000");
    //        }
    //        else
    //        {
    //            lbltotinstal_cheque.Text = "Rs " + suminsoldcheque.ToString("#,000");
    //        }

    //        if (suminsoldcheque <= 0)
    //        {
    //            lbltotinstal_cheque.Text = "Rs 0";
    //        }





    //        // ------------------------------------------------------ Finished ------------------------------------------------

    //        double instot;
    //        instot = suminscash + suminsoldcheque;
    //        if (instot > 0)
    //        {
    //            if (instot >= 10000000)
    //            {
    //                lbl_totins.Text = "Rs " + instot.ToString("##\",\"00\",\"00\",\"000");
    //            }
    //            else if (instot >= 100000)
    //            {
    //                lbl_totins.Text = "Rs " + instot.ToString("##\",\"00\",\"000");
    //            }
    //            else
    //            {
    //                lbl_totins.Text = "Rs " + instot.ToString("#,000");
    //            }
    //            //lbl_tot_inscc.Text = "Rs " + instot.ToString("#,000");
    //        }
    //        else
    //        {
    //            lbl_totins.Text = "Rs 0";
    //        }

    //        //----------------------------------------------------- Total ---------------------------------------------
    //    //}
    //    //catch (Exception ex)
    //    //{

    //    //}  
    //}

    #endregion

    #region for displaying the dashboard for specific centres
    private void filldatalist()
    {
        
       
        if (txtfromcalender2.Text != "" && txttocalender2.Text != "")
        {
            string str = txtfromcalender2.Text;
            string[] split = str.Split('-');
            fromdate = split[2] + "-" + split[1] + "-" + split[0];

            string str1 = txttocalender2.Text;
            string[] split1 = str1.Split('-');
             todate = split1[2] + "-" + split1[1] + "-" + split1[0];

        }
       
            string qry = "select * from getDashboard5('" + fromdate + "','" + todate + "','"+Session["SA_centre_code"].ToString()+"')";
        
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                Freshstudent.Text = dt.Rows[0]["totalfstudents"].ToString();
                Regularstudent.Text = dt.Rows[0]["totalrstudents"].ToString();
                Breakagestudent.Text = dt.Rows[0]["breakstudents"].ToString();
                lbl_tot_tele_enq.Text = dt.Rows[0]["tele_enquiry"].ToString();
                lbl_tot_enq.Text = dt.Rows[0]["no_enquiry"].ToString();
                total_enquires.Text = dt.Rows[0]["totalno_enquiry"].ToString();
                //lbl_no_enroll.Text = dt.Rows[0]["no_enroll"].ToString();
                //lbl_tot_lusum.Text = dt.Rows[0]["totalcashcollectedtotal"].ToString();
                double lbl_tot_lusum1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"]);
                //lbl_tot_lusum.Text = amts(lbl_tot_lusum1);
                Freshcash.Text = amts(lbl_tot_lusum1);
                double lbl_tot_lucheque1 = Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"]);
                //lbl_tot_lucheque.Text = amts(lbl_tot_lucheque1);
                Freshcheque.Text = amts(lbl_tot_lucheque1);
                double lbl_tot_lumpcc1 = Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
                //lbl_tot_lumpcc.Text = amts(lbl_tot_lumpcc1);
                Totalfresh.Text = amts(lbl_tot_lumpcc1);
                double lbl_tot_insamt1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"]);
                //lbl_tot_insamt.Text = amts(lbl_tot_insamt1);
                Regularcash.Text = amts(lbl_tot_insamt1);
                double lbl_tot_inscheque1 = Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"]);
                //lbl_tot_inscheque.Text = amts(lbl_tot_inscheque1);
                Regularcheque.Text = amts(lbl_tot_inscheque1);
                double lbl_tot_inscc1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString());
                //lbl_tot_inscc.Text = amts(lbl_tot_inscc1);
                Totalregular.Text = amts(lbl_tot_inscc1);
                double lbl_fees_today1 = Convert.ToDouble(dt.Rows[0]["totalRevenueCashCollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalRevenueDDCollectedTotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalcashcollectedtotal"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalDdcollectedtotal"].ToString());
                //lbl_fees_today.Text = amts(lbl_fees_today1);
                double bkcash = Convert.ToDouble(dt.Rows[0]["totalbreakagecash"]);
                Breakcash.Text = amts(bkcash);
                double bkcheque = Convert.ToDouble(dt.Rows[0]["totalbreakagedd"]);
                Breakcheque.Text = amts(bkcheque);
                double totalbreakage = Convert.ToDouble(dt.Rows[0]["totalbreakagecash"].ToString()) + Convert.ToDouble(dt.Rows[0]["totalbreakagedd"].ToString());
                TotalBreakage.Text = amts(totalbreakage);
            }
    }

    #endregion

    private void filltype()
    {
        
        try
        {
            SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            string str = txtfromcalender2.Text;
            string[] split = str.Split('-');
            string dateFrom = split[2] + "-" + split[1] + "-" + split[0];
            string str1 = txttocalender2.Text;
            string[] split1 = str1.Split('-');
            string dateTo = split1[2] + "-" + split1[1] + "-" + split1[0];
            cmd.CommandText = "[centrewisereport]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("centrecode", Session["SA_centre_code"]);
            cmd.Parameters.AddWithValue("fromdt", dateFrom);
            cmd.Parameters.AddWithValue("todt", dateTo);
            cmd.Parameters.Add("@bsc", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@msc", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@diploma", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ipad", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@certficate", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@website", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@newspaper", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@advertisement", SqlDbType.VarChar, 50);
            cmd.Parameters["@bsc"].Direction = ParameterDirection.Output;
            cmd.Parameters["@msc"].Direction = ParameterDirection.Output;
            cmd.Parameters["@diploma"].Direction = ParameterDirection.Output;
            cmd.Parameters["@ipad"].Direction = ParameterDirection.Output;
            cmd.Parameters["@certficate"].Direction = ParameterDirection.Output;

            cmd.Parameters["@website"].Direction = ParameterDirection.Output;
            cmd.Parameters["@newspaper"].Direction = ParameterDirection.Output;
            cmd.Parameters["@advertisement"].Direction = ParameterDirection.Output;
            //string certi = (string)cmd.Parameters["@certficate"].Value;
            Conn.Open();
            cmd.ExecuteNonQuery();
          BSC.Text = (string)cmd.Parameters["@bsc"].Value;
            MSC.Text = (string)cmd.Parameters["@msc"].Value;
           Ipad.Text = (string)cmd.Parameters["@ipad"].Value;
          Diploma.Text = (string)cmd.Parameters["@diploma"].Value;
          Certificate.Text = (string)cmd.Parameters["@certficate"].Value;
          News.Text = (string)cmd.Parameters["@newspaper"].Value;
          Website.Text = (string)cmd.Parameters["@website"].Value;
          Advertisement.Text = (string)cmd.Parameters["@advertisement"].Value;
            Conn.Close();
        }
        catch (Exception ex)
        {
           // Label4.Text = ex.ToString();
        }
        //gvtype1.DataSource = dttype;
        //gvtype1.DataBind();
    }

    public void fillsource()
    {
 
     //   GridView1.DataSource = dttype;
      //  GridView1.DataBind();
    }

    public void fillprofile()
    {
        //GridView2.DataSource = dttype;
       // GridView2.DataBind();

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
    //protected void ddl_cencode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddl_cencode.SelectedValue == "")
    //    {
    //        visdate.Visible = false;
    //        individualtable.Visible = false;
    //        View1.Visible = false;
    //    }
    //    else
    //    {
    //        visdate.Visible = true;
    //        individualtable.Visible = true;
    //        //View1.Visible = true;
    //        filldatalist();
    //    }
    //}
    #endregion
    //protected void btnsort_Click(object sender, EventArgs e)
    //{
        
    //    fillsuperadmindashboard();
    //}
    protected void btnsort1_Click(object sender, EventArgs e)
    {
        filldatalist();
        filltype();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=myexcel.xls");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

        wrap.RenderControl(hw);

        Response.Write( sw.ToString());
        Response.End();
        //filldatalist();
        //ExportTableData(dt);

    }
    public void ExportTableData(DataTable dtdata)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Centrewisereport-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write("" + dc.ColumnName + "\t");
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
}
