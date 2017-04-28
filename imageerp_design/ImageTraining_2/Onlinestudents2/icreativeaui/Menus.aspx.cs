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

public partial class superadmin_Menus : System.Web.UI.Page
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
            fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "CentreManager")
        {
            fillgrid();
        }
        if (Session["SA_Centrerole"] .ToString() == "Technical Head")
        {
            fillgd();
        }
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
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
    #region for displaying the Dashboard for the Counselor & CentreManager
    void fillgrid()
    {
        _Qry = "SELECT c1.course_id,c1.program,c1.coursename,f1.duration,f1.track,f1.lump_sum,f1.instal_amount from img_coursedetails c1 JOIN img_centre_coursefee_details f1 on c1.course_id=f1.program where centre_code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        Gridviewcourse.DataSource = dt;
        Gridviewcourse.DataBind();
    }
    #endregion



    #region for paging in the grid
    protected void Gridviewcourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridviewcourse.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    #endregion


    #region for displaying the Dashboard for the Technical Head
    void fillgd()
    {
        _Qry = "SELECT c1.course_id,c1.program,f1.duration,f1.track from img_coursedetails c1 JOIN img_centre_coursefee_details f1 on c1.course_id=f1.program where centre_code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GriDVTECH.DataSource = dt;
        GriDVTECH.DataBind();
    }
    #endregion


    #region for paging in the grid1
    protected void GriDVTECH_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GriDVTECH.PageIndex = e.NewPageIndex;
        fillgd();
    }
    #endregion

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
    private void fill_centrecode()
    {
        _Qry = "SELECT centre_location,centre_code from img_centredetails ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_cencode.DataSource = dt;
        ddl_cencode.DataValueField = "centre_code";
        ddl_cencode.DataTextField = "centre_location";
        ddl_cencode.DataBind();
        ddl_cencode.Items.Insert(0, new ListItem("Select", ""));
    }
    #endregion

    #region for displaying the Dashboard for the Super Admin
    private void fillsuperadmindashboard()
    {
        try
        {
            _Qry = "select count(*)as cnt from img_enquiryform";

            DataTable dt = new DataTable(_Qry);
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbltotalenquiry.Text = dt.Rows[0]["cnt"].ToString();
            }
            else
            {
                lbltotalenquiry.Text = "0";
            }
            string dat = System.DateTime.UtcNow.ToString("dd/MM/yyyy");

            _Qry = "select count(*)as cnt from  img_enquiryform1 where convert(varchar,dateins,3)= convert(varchar,getdate(),3)";
            //Response.Write(_Qry);
            //Response.End();

            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbltodayenq.Text = dt.Rows[0]["cnt"].ToString();
            }
             _Qry = "select * from adm_generalinfo";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = "select sum(payment_installments) as Coursefee from adm_generalinfo";
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    //lbltotrevenue.Text = "Rs " + dt.Rows[0]["Coursefee"].ToString();
                    double cfee = Convert.ToDouble(dt.Rows[0]["Coursefee"]) * 0.103;
                    double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["Coursefee"]);
                    lbltotrevenue_tax.Text = "Rs " + cfee_tax.ToString();

                }
                else
                {
                    lbltotrevenue_tax.Text = "Rs 0";
                }
            }
            else
            {
                lbltotrevenue_tax.Text = "Rs 0";
            }
            _Qry = "select * from adm_generalinfo where payment_pattern='Lump sum'";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {

                _Qry = "select sum(payment_installments)as totalLumpamt from adm_generalinfo where payment_pattern='Lump sum'";
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    //lbltotlumpsum.Text = "Rs " + dt.Rows[0]["totalLumpamt"].ToString();
                    double cfee = Convert.ToDouble(dt.Rows[0]["totalLumpamt"]) * 0.103;
                    double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["totalLumpamt"]);
                    lbltotlumpsum_tax.Text = "Rs " + cfee_tax.ToString();
                }
            }
            else
            {
                lbltotlumpsum_tax.Text = "Rs 0";
            }

            _Qry = "select * from adm_generalinfo where payment_pattern='Installment'";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = "select sum(payment_installments)as totalinstall from adm_generalinfo where payment_pattern='Installment'";
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    //lbltotinstalmentamt.Text = "Rs " + dt.Rows[0]["totalinstall"].ToString();
                    double cfee = Convert.ToDouble(dt.Rows[0]["totalinstall"]) * 0.103;
                    double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["totalinstall"]);
                    lbltotinstal_tax.Text = "Rs " + cfee_tax.ToString();

                }
            }
            else
            {
                lbltotinstal_tax.Text = "Rs 0";
            }
            double sumamttax = 0;
            _Qry = " select tatamtpaidwithtax from install_amountdetails where convert(varchar,date,3)= convert(varchar,getdate(),3) and Receipt_no is Not null";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["tatamtpaidwithtax"] != "")
                    {
                        sumamttax = sumamttax + Convert.ToDouble(dt.Rows[i]["tatamtpaidwithtax"]);
                    }
                }
                lbltotcollection_tax.Text = "Rs " + sumamttax;
            }
            else
            {
                lbltotcollection_tax.Text = "Rs 0";
            }
            //DataTable dt50 = new DataTable();
            //_Qry = "select sum(tatamtpaidwithtax) as todayrevenue from install_amountdetails where date_format(date,'%Y-%m-%d')= date_format(Now(),'%Y-%m-%d') and Receipt_no is Not null";


            //dt50 = MVC.DataAccess.ExecuteDataTable(_Qry);

            //if (dt50.Rows.Count > 0)
            //{
            //    if (dt50.Rows[0]["todayrevenue"].ToString() != "")
            //    {

            //        lbltotcollection_tax.Text = "Rs " + dt50.Rows[0]["todayrevenue"].ToString();
            //        //double cfee = (Convert.ToDouble(dt.Rows[0]["todayrevenue"]) * 100) / 110.3;
            //        //double cfee_tax = Convert.ToDouble(dt.Rows[0]["todayrevenue"]) - Convert.ToDouble(cfee);
            //        //lbltodaycollection.Text = "Rs " + cfee_tax.ToString();
            //    }
            //    else
            //    {

            //        lbltotcollection_tax.Text = "Rs 0";
            //    }

            //}
            //else
            //{

            //    lbltotcollection_tax.Text = "Rs 0";
            //}


        }
        catch(Exception ex)
        { 
       
        }
    }
   

    #endregion

    #region for displaying the dashboard for specific centres
    private void filldatalist()
    {
        try
        {
            lbl_cen_code.Text = ddl_cencode.SelectedValue;

            _Qry = "select centre_location from img_centredetails where centre_code='" + ddl_cencode.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbl_cen_name.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centre_location"].ToString());
            }
            else
            {
                lbl_cen_name.Text = "";
            }
            _Qry = "select count(*)as cnt1 from img_enquiryform where centre_code='"+ddl_cencode.SelectedValue+"'";

            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbl_tot_enq.Text= dt.Rows[0]["cnt1"].ToString();
            }   
            else
            {
                lbl_tot_enq.Text = "0";
            }
            string dat = System.DateTime.UtcNow.ToString("dd/MM/yyyy");

            _Qry = "select count(*)as cnt2 from  img_enquiryform1 where convert(varchar, dateins, 3)= convert(varchar, getdate(), 3) and centre_code='" + ddl_cencode.SelectedValue + "'";

            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbl_today_enq.Text = dt.Rows[0]["cnt2"].ToString();
            }

            _Qry = "select count(*)as cnt3 from adm_studentid where centre_code='" + ddl_cencode.SelectedValue + "'";

            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lbl_no_enroll.Text = dt.Rows[0]["cnt3"].ToString();
            }
            _Qry = "SELECT COUNT(*) as bbb FROM (select count(*)as cnt4  from batch_details where centre_code='" + ddl_cencode.SelectedValue + "' and batch_status='Inprogress' group by batch_code)as aaa ";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt7 = new DataTable();
            dt7 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt7.Rows.Count > 0)
            {
                lbl_no_batch.Text = dt7.Rows[0]["bbb"].ToString();
            }
            _Qry = "select * from adm_generalinfo where payment_pattern='Lump sum' and centre_code='" + ddl_cencode.SelectedValue + "'";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = "select sum(payment_installments)as totalLumpamt from adm_generalinfo where payment_pattern='Lump sum' and centre_code='" + ddl_cencode.SelectedValue + "'";

                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows[0]["totalLumpamt"].ToString() != "")
                    {
                        //lbltotlumpsum.Text = "Rs " + dt.Rows[0]["totalLumpamt"].ToString();
                        double cfee = Convert.ToDouble(dt.Rows[0]["totalLumpamt"]) * 0.103;
                        double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["totalLumpamt"]);
                        lbl_tot_lusum.Text = "Rs " + cfee_tax.ToString();
                    }
                    else
                    {
                        lbl_tot_lusum.Text = "Rs 0";
                    }
                }
            }
            else
            {
                lbl_tot_lusum.Text = "Rs 0";
            }
            _Qry = "select * from adm_generalinfo where payment_pattern='Installment' and centre_code='" + ddl_cencode.SelectedValue + "'";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                _Qry = "select sum(payment_installments)as totalinstall from adm_generalinfo where payment_pattern='Installment' and centre_code='" + ddl_cencode.SelectedValue + "'";
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["totalinstall"].ToString() != "")
                    {
                        double cfee = Convert.ToDouble(dt.Rows[0]["totalinstall"]) * 0.103;
                        double cfee_tax = cfee + Convert.ToDouble(dt.Rows[0]["totalinstall"]);
                        lbl_tot_insamt.Text = "Rs " + cfee_tax.ToString();
                    }
                    else
                    {
                        lbl_tot_insamt.Text = "Rs 0";
                    }
                }
            }
            else
            {
                lbl_tot_insamt.Text = "Rs 0";
            }

            double sumamttax = 0;
            _Qry = " select tatamtpaidwithtax from install_amountdetails where convert(varchar,date,3)= convert(varchar,getdate(),3) and centre_code='" + ddl_cencode.SelectedValue + "' and Receipt_no is Not null";
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["tatamtpaidwithtax"] != "")
                    {
                        sumamttax = sumamttax + Convert.ToDouble(dt.Rows[i]["tatamtpaidwithtax"]);
                    }
                }
                lbl_fees_today.Text = "Rs " + sumamttax;
            }
            else
            {
                lbl_fees_today.Text = "Rs 0";
            }
           
            //_Qry = "select sum(tatamtpaidwithtax) as todayrevenue from install_amountdetails where date_format(date,'%Y-%m-%d')= date_format(Now(),'%Y-%m-%d') and centre_code='" + ddl_cencode.SelectedValue + "' and Receipt_no is Not null";


            //dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            //if (dt.Rows.Count > 0)
            //{
            //    if (dt.Rows[0]["todayrevenue"].ToString() != "")
            //    {

                    //lbl_fees_today.Text = "Rs " + dt.Rows[0]["todayrevenue"].ToString();
                    //double cfee = (Convert.ToDouble(dt.Rows[0]["todayrevenue"]) * 100) / 110.3;
                    //double cfee_tax = Convert.ToDouble(dt.Rows[0]["todayrevenue"]) - Convert.ToDouble(cfee);
                    //lbltodaycollection.Text = "Rs " + cfee_tax.ToString();
            //    }
            //    else
            //    {

            //        lbl_fees_today.Text = "Rs 0";
            //    }

            //}
            //else
            //{

                //lbl_fees_today.Text = "Rs 0";
            //}


        }
        catch (Exception ex)
        {

        }  
    
    }

    #endregion


    #region for selected index change of Centrecode
    protected void ddl_cencode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_cencode.SelectedValue == "")
        {
            individualtable.Visible = false;
            View1.Visible = false;
        }
        else
        {
            individualtable.Visible = true;
            View1.Visible = true;
            filldatalist();
        }

    }
    #endregion
}
