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

public partial class superadmin_Addlab : System.Web.UI.Page
{
    string _Qry;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            labname();
            ddl_labname.Items.Insert(0, new ListItem("Select", ""));
            fillgrid();
        }
        if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
        {
            Response.Redirect("GetCentreDetails.aspx");
        }

        Lblfree.Text = "free"; 
    }

    private void labname()
    {
        _Qry = "select LabId,Labname from online_students_labavail where Centre_Code='" + Session["SA_centre_code"] + "'";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_labname.DataSource = dt;
            ddl_labname.DataTextField = "Labname";
            ddl_labname.DataValueField = "Labname";
            ddl_labname.DataBind();

        }
    }


    private void fillgrid()
    {
        _Qry = @"select LabId,[7amto9am]  = CASE
        WHEN [7amto9am] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [7amto9am]
        END , [9amto11am]  = CASE
        WHEN [9amto11am] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [9amto11am]
        END , [11amto1pm]  = CASE
        WHEN [11amto1pm] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [11amto1pm]
        END ,[1pmto3pm]  = CASE
        WHEN [1pmto3pm] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [1pmto3pm]
        END ,[3pmto5pm]= CASE
        WHEN [3pmto5pm] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [3pmto5pm]
        END ,[5pmto7pm]= CASE
        WHEN [5pmto7pm] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [5pmto7pm]
        END ,[7pmto9pm]= CASE
        WHEN [7pmto9pm] = 'free' THEN '<span style=''color:green;font-weight:bold''>Free</span>'
        ELSE [7pmto9pm]
        END ,replace(Labname,'~','''')as Labname,replace(Labcode,'~','''')as Labcode,replace(System,'~','''')as System from online_students_labavail where  Labname like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(ddl_labname.SelectedValue) + "%' And Centre_Code='" + Session["SA_centre_code"] + "' order by LabId desc";
       
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
   
   private void refresh()
    {
        txt_systems.Text = "";
        txt_labname.Text = "";
        txtLabcode.Text = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select Labname,LabCode,LabId,System from online_students_labavail where LabId=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                txt_labname.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Labname"].ToString());
                txtLabcode.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["LabCode"].ToString());
                txt_systems.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["System"].ToString());

                hiddn_id.Value = dt.Rows[0]["LabId"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from online_students_labavail where LabId='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
            fillgrid();
            labname();
            ddl_labname.Items.Insert(0, new ListItem("Select", ""));
            lblmsg1.Text = "The lab details has been deleted successfully";
            refresh();
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (hiddn_id.Value == "" || hiddn_id.Value == null)
        {
            _Qry = "select count(LabId) from online_students_labavail where Labname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "' And Centre_Code='" + Session["SA_centre_code"] + "' ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The lab name already exist";
            }
            else
            {
                //insert
               // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";


                _Qry = " INSERT INTO online_students_labavail (Centre_Code,Labname ,Labcode, System , [7amto9am] , [9amto11am] , [11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm],Dateins,Datemod )VALUES ('" + Session["SA_centre_code"] + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtLabcode.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "','" + Lblfree.Text + "', getdate(),getdate())";

              


                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                labname();
                ddl_labname.Items.Insert(0, new ListItem("Select", ""));
                lblmsg1.Text = "The lab details has been inserted successfully";
                refresh();
            }
        }
        else
        {
            _Qry = "select count(LabId)from online_students_labavail where Labname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "' and LabId <> " + hiddn_id.Value + " And Centre_Code='" + Session["SA_centre_code"] + "'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The lab name already exist";
            }
            else
            {
                //update
                _Qry = "update online_students_labavail set Labname='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "',Labcode='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtLabcode.Text) + "',System='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "',Dateins=getdate() where LabId=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                
                labname();
                ddl_labname.Items.Insert(0, new ListItem("Select", ""));
                fillgrid();
                lblmsg1.Text = "The lab details has been Updated successfully";
                refresh();
                hiddn_id.Value = "";
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
}
