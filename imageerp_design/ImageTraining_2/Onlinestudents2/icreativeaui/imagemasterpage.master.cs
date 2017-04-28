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

public partial class img_imagemasterpage : System.Web.UI.MasterPage
{
    string _Qry;
    public string TestValue = "Test";
    protected void Page_Load(object sender, EventArgs e)
    {
        //HiddenField1.Value = "Admission.aspx?Test=1";
        //setlink.HRef = "Admission.aspx?Test=1";
        //Response.Write(Session["SA_Username"].ToString());
        // SubMVC.ERP_Ashok.page_restriction();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {
           

            try
            {
                if (Session["SA_Centrerole"] != null)
                {
                    if (Session["SA_Centrerole"].ToString() != "SuperAdmin")
                    {

                        _Qry = "select Status from ERP_SiteStatus where centre_code='" + Session["SA_centre_code"] + "' and Status='0'";


                        //Response.Write(_Qry);
                        //Response.End();

                        DataTable dt1 = new DataTable();
                        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                        if (dt1.Rows.Count > 0)
                        {

                            Response.Redirect("wrongentry.aspx?offline=yes");

                        }

                    }
                    if (Session["SA_Username"].ToString() == "sa")
                    {
                        lbl_role.Text = Session["SA_Centrerole"].ToString();
                        lbl_username.Text = Session["SA_UserID"].ToString();
                        Label4.Visible = false;
                        lbl_location.Visible = false;
                        fillcentre();
                        lblSearch.Visible = true;
                        v.Visible = true;
                        //Button1.Visible = true;
                        lblCentre.Visible = true;
                        enroll.Visible = true;
                        transd.Visible = true;
                        //lbl_location.Text = Session["SA_Location"].ToString();
                        //sess();
                    }
                    ////else if (Session["SA_Centrerole"] .ToString() == "R&D")
                    ////{
                    ////    lbl_role.Text = Session["SA_Centrerole"] .ToString();
                    ////    lbl_username.Text = Session["SA_UserID"].ToString();
                    ////    Label4.Visible = false;
                    ////    lbl_location.Visible = false;
                    ////    fillcentre();
                    ////    lblSearch.Visible = true;
                    ////    v.Visible = true;
                    ////    //Button1.Visible = true;
                    ////    lblCentre.Visible = true;
                    ////}
                    ////else if (Session["SA_Centrerole"] .ToString() == "Region Head")
                    ////{
                    ////    lbl_role.Text = Session["SA_Centrerole"] .ToString();
                    ////    lbl_username.Text = Session["SA_UserID"].ToString();
                    ////    Label4.Visible = false;
                    ////    lbl_location.Visible = false;
                    ////    fillcentre1();
                    ////    lblSearch.Visible = true;
                    ////    v.Visible = true;
                    ////    //Button1.Visible = true;
                    ////    lblCentre.Visible = true;
                    ////}
                    ////else
                    ////{
                    ////    lbl_role.Text = Session["SA_Centrerole"] .ToString();
                    ////    lbl_username.Text = Session["SA_UserID"].ToString();
                    ////    lbl_location.Text = Session["SA_Location"].ToString();
                    ////    lblSearch.Visible = false;
                    ////    v.Visible = false;
                    ////    //Button1.Visible = false;
                    ////    lblCentre.Visible = false;
                    ////}


                    if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null || Session["SA_centre_code"].ToString() == "11")
                    {
                        lblCentre.Text = "Please select the centre to view details";
                    }
                    else
                    {
                        v.SelectedValue = Session["SA_centre_code"].ToString();
                        if (Session["SA_Username"].ToString() == "sa")
                        {
                            lblCentre.Text = "";
                            enroll.Visible = false;
                        }
                        else
                        {
                            lblCentre.Text = "";
                            lblCentre.Visible = false;
                        }
                    }
                    if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
                    {
                        notification_count();
                    }
                    else
                    {
                        enroll.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                
            }

        }

        if (Session["SA_Centrerole"] != null)
        {
            if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
            {
                transd.Visible = true;
                assesment.Visible = false;
                drop.Visible = false;
                leave.Visible = false;
                update.Visible = false;

            }

            ////if (Session["SA_Centrerole"] .ToString() == "Region Head")
            ////{
            ////    transd.Visible = true;
            ////    assesment.Visible = false;
            ////    drop.Visible = false;
            ////    leave.Visible = false;
            ////    update.Visible = false;

            ////}
            ////if (Session["SA_Centrerole"] .ToString() == "R&D")
            ////{
            ////    drop.Visible = false;
            ////    leave.Visible = false;
            ////    Label4.Visible = false;
            ////    lbl_location.Visible = false;
            ////    assesment.Visible = true;
            ////    update.Visible = false;
            ////    transd.Visible = false;
            ////}
            ////if (Session["SA_Centrerole"] .ToString() == "Certificate")
            ////{
            ////    drop.Visible = false;
            ////    leave.Visible = false;
            ////    Label4.Visible = false;
            ////    lbl_location.Visible = false;
            ////    assesment.Visible = true;
            ////    update.Visible = false;
            ////    transd.Visible = false;
            ////}
            ////if (Session["SA_Centrerole"] .ToString() == "Counselor")
            ////{
            ////    drop.Visible = false;
            ////    leave.Visible = false;

            ////    assesment.Visible = false;
            ////    update.Visible = true;
            ////    transd.Visible = false;
            ////}
            ////if (Session["SA_Centrerole"] .ToString() == "CentreManager")
            ////{
            ////    book.Visible = true;
            ////    assesment.Visible = false;
            ////    update.Visible = false;

            ////}
            ////if (Session["SA_Centrerole"] .ToString() == "Technical Head")
            ////{

            ////    update.Visible = false;

            ////}
            ////if (Session["SA_Centrerole"] .ToString() == "Printing Department")
            ////{
            ////    drop.Visible = false;
            ////    leave.Visible = false;
            ////    assesment.Visible = false;
            ////    update.Visible = false;
            ////    transd.Visible = false;
            ////    book.Visible = true;
            ////}
        }
        else
        {

           /// Response.Redirect("Login.aspx?st=exp");

        }

    }

        
   
    //public void CodeBehindFunction()
    //{
    //    Response.Write("Test");
    //    Response.End();
    //    //setlink.r
    //    //setlink.HRef = "Admission.aspx?Test=1";
    //}
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      
        ////Session["SA_Centrerole"] = null;
        ////Session["SA_centre_code"] = null;
        ////Session["SA_centre_region"] = null;
        ////Session["SA_centre_loginstatus"] = null;
        ////Session["ENQ_ID"] = null;
        ////Session["Enqno"] = null;
        ////Session["Student_Id"] = null;
        ////Session["Password"] = null;
       //// Session.Clear();
       
        Session.Abandon();
        Session["SA_UserID"] = null;
        Session["SA_Username"] = null;
        Response.Redirect("Login.aspx?st=out");
    }

    private void fillcentre()
    {
        _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        v.DataSource = dt;
        v.DataTextField = "Centre_location";
        v.DataValueField = "Centre_Code";
        v.DataBind();
        v.Items.Insert(0, new ListItem("Select", ""));        
}
    private void fillcentre1()
    {
        _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails where centre_region='" + Session["SA_centre_region"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        v.DataSource = dt;
        v.DataTextField = "Centre_location";
        v.DataValueField = "Centre_Code";
        v.DataBind();
        v.Items.Insert(0, new ListItem("Select", ""));
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    if (v.SelectedValue == "")
    //    {
    //        lblCentre.Text = "";
    //        //lblerrmsg.Text = "Please select centre location";
    //    }
    //    else
    //    {
    //        Session["SA_centre_code"] = v.SelectedValue.ToString();

    //        v.SelectedValue = Session["SA_centre_code"].ToString();

    //        string[] spliturl = Request.Url.ToString().Split('/');
    //        //Response.Write(spliturl[spliturl.Length-1].ToString());
    //        lblCentre.Text = "You can view " + v.SelectedItem.ToString() + " details";
    //        Response.Redirect(spliturl[spliturl.Length - 1].ToString());
    //        //lblerrmsg.Text = "You can view " + ddl_Centre.SelectedItem.ToString() + " details";
    //    }
    //}
    
    protected void v_SelectedIndexChanged1(object sender, EventArgs e)
    {
    //    if (v.SelectedValue == "" || v.SelectedValue ==null)
    //    {
    //        lblCentre.Text = "";
    //        Session["SA_centre_code"] = "11";
    //        v.SelectedValue = "";
    //        string[] spliturl = Request.Url.ToString().Split('/');
    //        //Response.Write(spliturl[spliturl.Length-1].ToString());
    //        lblCentre.Text = "";
    //        Response.Redirect(spliturl[spliturl.Length - 1].ToString());
    //        lblCentre.Text = "Please select the centre to view details";
    //    }
    //    else
    //    {
    //        Session["SA_centre_code"] = v.SelectedValue.ToString();

    //        v.SelectedValue = Session["SA_centre_code"].ToString();

    //        string[] spliturl = Request.Url.ToString().Split('/');
    //        //Response.Write(spliturl[spliturl.Length-1].ToString());
    //        lblCentre.Text = "";
    //        Response.Redirect(spliturl[spliturl.Length - 1].ToString());
    //        //lblerrmsg.Text = "You can view " + ddl_Centre.SelectedItem.ToString() + " details";
    //    }
        if (v.SelectedValue == "" || v.SelectedValue == null)
        {
            lblCentre.Text = "Please select the centre to view details";
            //lblerrmsg.Text = "Please select centre location";
        }
        else
        {
            Session["SA_centre_code"] = v.SelectedValue.ToString();
            Session["SA_Location"] = v.SelectedItem.Text;
            v.SelectedValue = Session["SA_centre_code"].ToString();
            _Qry = "Select centre_id,centre_location,centre_code,centre_region,Centre_category from img_centredetails where centre_code='" + v.SelectedValue.ToString() + "'";
            
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                Session["SA_Centre_category"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Centre_category"].ToString());
                Session["SA_CenterID"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_id"].ToString());
               // Session["SA_centre_code"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_code"].ToString());
               // Session["SA_Location"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_location"].ToString());
                Session["SA_centre_region"] = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_region"].ToString());
            }
            string[] spliturl = Request.Url.ToString().Split('/');
            //Response.Write(spliturl[spliturl.Length-1].ToString());
            lblCentre.Text = "";
            Response.Redirect(spliturl[spliturl.Length - 1].ToString());
            //lblerrmsg.Text = "You can view " + ddl_Centre.SelectedItem.ToString() + " details";
        }
    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("notification.aspx#Drop");
    }
    protected void lnk_leave_Click(object sender, EventArgs e)
    {
        Response.Redirect("notification.aspx#Leave");
    }
    protected void lnk_assesment_Click(object sender, EventArgs e)
    {
        Response.Redirect("notification.aspx#Assesment");
    }
    protected void lnk_update_Click(object sender, EventArgs e)
    {
        Response.Redirect("notification.aspx#Recommened");
    }



    private void notification_count()
    {
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            _Qry = "select count(*) as transfer from erp_studenttransfer where newstudentid is null";
            DataTable dtt = new DataTable();
            dtt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dtt.Rows.Count > 0)
            {

                lbl_trans.Text = dtt.Rows[0]["transfer"].ToString();
            }

        }

    ////    if (Session["SA_Centrerole"] .ToString() == "CentreManager")
    ////    {
    ////        _Qry = "select count(*) as leave from erp_studentleave where status_cen='Pending' and centercode='" + Session["SA_centre_code"].ToString() + "'";
    ////        DataTable dt1 = new DataTable();
    ////        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt1.Rows.Count > 0)
    ////        {
    ////            lbl_leave.Text = dt1.Rows[0]["leave"].ToString();
    ////        }
    ////        _Qry = "select count(*) as drop1 from erp_studentdrop where status='Requested' and centercode='" + Session["SA_centre_code"].ToString() + "'";
    ////        DataTable dt2 = new DataTable();
    ////        dt2 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt2.Rows.Count > 0)
    ////        {

    ////            lbl_drop.Text = dt2.Rows[0]["drop1"].ToString();
    ////        }
    ////        _Qry = "select count(distinct studentid) as book from book_request where status='Pending' and centrecode='" + Session["SA_centre_code"].ToString() + "'";
    ////        DataTable dtab = new DataTable();
    ////        dtab = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dtab.Rows.Count > 0)
    ////        {

    ////            lbl_book.Text = dtab.Rows[0]["book"].ToString();
    ////        }



    ////    }
    ////    if (Session["SA_Centrerole"] .ToString() == "Printing Department")
    ////    {
    ////        _Qry = "select count( distinct studentid) as book from book_request where status='Approved' and bookstatus='Pending'";
    ////        DataTable dtab1 = new DataTable();
    ////        dtab1 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dtab1.Rows.Count > 0)
    ////        {

    ////            lbl_book.Text = dtab1.Rows[0]["book"].ToString();
    ////        }
    ////    }

    ////    if (Session["SA_Centrerole"] .ToString() == "Technical Head")
    ////    {
    ////        _Qry = "select count(*) as leave from erp_studentleave where status='Pending' and centercode='" + Session["SA_centre_code"].ToString() + "'";
    ////        DataTable dt11 = new DataTable();
    ////        dt11 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt11.Rows.Count > 0)
    ////        {
    ////            lbl_leave.Text = dt11.Rows[0]["leave"].ToString();
    ////        }

    ////        _Qry = "select count(*) as drop1 from erp_studentdrop where status!='Requested' and action='active' and status!='Break' and centercode='" + Session["SA_centre_code"].ToString() + "'";
    ////        DataTable dt21 = new DataTable();
    ////        dt21 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt21.Rows.Count > 0)
    ////        {

    ////            lbl_drop.Text = dt21.Rows[0]["drop1"].ToString();
    ////        }
    ////    }


    ////    if (Session["SA_Centrerole"] .ToString() == "Technical Head")
    ////    {
    ////        _Qry = "select count(*) as assesment from erp_studentprogress where status='Pending' and centrecode='" + Session["SA_centre_code"].ToString() + "' and senddate is null";
    ////        DataTable dt25 = new DataTable();
    ////        dt25 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt25.Rows.Count > 0)
    ////        {
    ////            lbl_assesment.Text = dt25.Rows[0]["assesment"].ToString();
    ////        }

                     
    ////    }
    ////    if (Session["SA_Centrerole"] .ToString() == "R&D")
    ////    {
    ////        _Qry = "select count(*) as assesment from erp_studentprogress where status='Pending' and mark is null  and senddate is not null";
    ////        DataTable dt25 = new DataTable();
    ////        dt25 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt25.Rows.Count > 0)
    ////        {
    ////            lbl_assesment.Text = dt25.Rows[0]["assesment"].ToString();
    ////        }


    ////    }

    ////    if (Session["SA_Centrerole"] .ToString() == "Certificate")
    ////    {
    ////        _Qry = "select count(*) as assesment from erp_studentprogress where status='Pending'  and dispatchdate is null and senddate is not null";
    ////        DataTable dt25 = new DataTable();
    ////        dt25 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt25.Rows.Count > 0)
    ////        {
    ////            lbl_assesment.Text = dt25.Rows[0]["assesment"].ToString();
    ////        }

           	
    ////    }
    //////    if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "Technical Head")
    ////    if (Session["SA_Centrerole"] .ToString() == "Counselor")
    ////    {
    ////        _Qry = "select count(*) as update1 from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where a.Admission_id>0 and studentstatus='active' and a.centre_code='" + Session["SA_centre_code"].ToString() + "'  and isnull(a.student_lastname,'.*.')='.*.'";
    ////        DataTable dt3 = new DataTable();
    ////        dt3 = MVC.DataAccess.ExecuteDataTable(_Qry);
    ////        if (dt3.Rows.Count > 0)
    ////        {
    ////            lbl_update.Text = dt3.Rows[0]["update1"].ToString();
    ////        }
    ////    }

        lbl_notcount.Text = (Convert.ToInt32(lbl_leave.Text) + Convert.ToInt32(lbl_drop.Text) + Convert.ToInt32(lbl_update.Text) + Convert.ToInt32(lbl_trans.Text) + Convert.ToInt32(lbl_assesment.Text) + Convert.ToInt32(lbl_book.Text)).ToString();
    }


    protected void LinkButton1_Click2(object sender, EventArgs e)
    {
        Response.Redirect("notification.aspx#transfer");

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager")
        {

            Response.Redirect("notification.aspx#test");
        }
        else
        {
            Response.Redirect("notification.aspx#test");
        }
    }
}



