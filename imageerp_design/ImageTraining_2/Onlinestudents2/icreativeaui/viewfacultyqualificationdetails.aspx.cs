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

public partial class superadmin_viewfacultyqualificationdetails : System.Web.UI.Page
{
    string _Qry,Sftknown,os,pl,application,db,gui,web,multimedia,authoring,conversion,misc,othersft;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        display();

    }
   private void display()
    {
        _Qry = "select fac_name,fac_qua_Institute,fac_qua_course,fac_qua_subject,fac_percentage,fac_qua_yearofcompletion,fac_os,fac_pl,fac_applications,fac_database,fac_gui,fac_web,fac_multimedia,fac_authoring,fac_conversions,fac_miscellaneous,Othersftware from faculty_details where faculty_id='" + Request.QueryString["fac_id"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Sftknown = "";
        if (dt.Rows.Count > 0)
        {
            lbl_facname.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_name"].ToString());
            lbl_institute.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_qua_Institute"].ToString());
            lbl_course.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_qua_course"].ToString());
            lbl_subject.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_qua_subject"].ToString());
            lbl_percentage.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_percentage"].ToString());
            lbl_year.Text =MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_qua_yearofcompletion"].ToString());
            os = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_os"].ToString());

            pl = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_pl"].ToString());

            application = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_applications"].ToString());
            db = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_database"].ToString());

            gui = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_gui"].ToString());
            web = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_web"].ToString());

            multimedia = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_multimedia"].ToString());

            authoring = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_authoring"].ToString());

            conversion = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_conversions"].ToString());

            misc = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["fac_miscellaneous"].ToString());
            othersft = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Othersftware"].ToString());
           
            if (os != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + os;
                }
                else
                {
                    Sftknown = os;
                }
            }
            if (pl != "")
            {
                if (Sftknown != "")
                {
                Sftknown = Sftknown + "," + pl;
                }
                else
                {
                Sftknown = pl;
                }
            }
             if (application != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + application;
                }
                else
                {
                    Sftknown = application;
                }
            }
           if (db != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + db;
                }
                else
                {
                    Sftknown = db;
                }
            }
             if (gui != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + gui;
                }
                else
                {
                    Sftknown = gui;
                }
            }
            if (web != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + web;
                }
                else
                {
                    Sftknown = web;
                }
            }
            if (multimedia != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + multimedia;
                }
                else
                {
                    Sftknown = multimedia;
                }
            }
             if (authoring != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + authoring;
                }
                else
                {
                    Sftknown = authoring;
                }
            }

            if (conversion != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + conversion;
                }
                else
                {
                    Sftknown = conversion;
                }
            }

             if (misc != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + misc;
                }
                else
                {
                    Sftknown = misc;
                }
            }

           if (othersft != "")
            {
                if (Sftknown != "")
                {
                    Sftknown = Sftknown + "," + othersft;
                }
                else
                {
                    Sftknown = othersft;
                }
            }
          
            lblsftknown.Text = Sftknown;

        }
    }
}
