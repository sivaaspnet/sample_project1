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

public partial class Onlinestudents2_superadmin_AddSoftwares : System.Web.UI.Page
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
            fillgrid();
        }
    }

    private void fillgrid()
    {
        _Qry = "select Companyname,Company_name,software_id,software_name,software_code,version,Noofclasses from software_details  ";
        if (txtsearchname.Text != "")
        {
            _Qry = _Qry + " where software_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' ";
        }
        _Qry = _Qry + " order by software_id desc";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    private void insertsoftware()
    {
        if (hiddn_id.Value == "" || hiddn_id.Value == null)
        {
            _Qry = "select count(software_Id) from software_details where software_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softwarename.Text) + "' or software_code='"+ MVC.CommonFunction.ReplaceQuoteWithTild(txt_softcode.Text) +"'";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Software name and code already exist"; 
            }
            else
            {
                if (ddl_compnames.SelectedValue == "Others")
                {
                    _Qry = "insert into software_details(Companyname,Company_name,software_name,software_code,version,status,Noofclasses)values('" + ddl_compnames.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_company.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softwarename.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_version.Text) + "','Enable','"+MVC.CommonFunction.ReplaceQuoteWithTild(txtclasess.Text)+"')";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }
                else
                {
                    _Qry = "insert into software_details(Companyname,Company_name,software_name,software_code,version,status,Noofclasses)values('" + ddl_compnames.SelectedValue + "','" + ddl_compnames.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softwarename.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softcode.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_version.Text) + "','Enable','"+MVC.CommonFunction.ReplaceQuoteWithTild(txtclasess.Text)+"')";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }

                fillgrid();
                lblmsg1.Text = "The Software name has been added successfully";

                txt_company.Text = "";
                txt_softwarename.Text = "";
                txt_softcode.Text = "";
                txt_version.Text = "";
                txtclasess.Text = "";
                ddl_compnames.SelectedValue = "";
            }
        }
        else
        {
            _Qry = "select count(software_Id) from software_details where (software_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softwarename.Text) + "' and software_code='"+ MVC.CommonFunction.ReplaceQuoteWithTild(txt_softcode.Text)+"' and software_id<>" + hiddn_id.Value + ")";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            
            if (count > 0)
            {
                lblmsg1.Text = "The Software name and code already exist";
            }
            else
            {
                if (hiddn_softname.Value != txt_softwarename.Text)
                {
                    //replace
                    _Qry = "UPDATE module_details SET software_name = TRIM(BOTH ',' FROM REPLACE(CONCAT(',' , software_name, ','), CONCAT(',','" + hiddn_softname.Value + "', ',') , '" + txt_softwarename.Text + ",')) ";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }
                if (ddl_compnames.SelectedValue == "Others")
                {
                    _Qry = "update software_details set Companyname='" + ddl_compnames.SelectedValue + "',Company_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_company.Text) + "',software_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softwarename.Text) + "',software_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softcode.Text) + "',version='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_version.Text) + "',Noofclasses='"+MVC.CommonFunction.ReplaceQuoteWithTild(txtclasess.Text)+"' where software_id = '" + hiddn_id.Value + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

                }
                else
                {
                    _Qry = "update software_details set Companyname='" + ddl_compnames.SelectedValue + "',Company_name='" + ddl_compnames.SelectedValue + "',software_name='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softwarename.Text) + "',software_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_softcode.Text) + "',version='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_version.Text) + "',Noofclasses='"+MVC.CommonFunction.ReplaceQuoteWithTild(txtclasess.Text)+"' where software_id = '" + hiddn_id.Value + "'";
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                }

                fillgrid();
                lblmsg1.Text = "The software name has been updated successfully";

                txt_company.Text = "";
                txt_softwarename.Text = "";
                txt_softcode.Text = "";
                txt_version.Text = "";
                txtclasess.Text = "";
                ddl_compnames.SelectedValue = "";
                hiddn_id.Value = "";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        insertsoftware();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select Companyname,Company_name,software_name,software_id,software_code,version,Noofclasses from software_details where software_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Companyname"].ToString() == "Others")
                {

                    ddl_compnames.SelectedValue = dt.Rows[0]["Companyname"].ToString();
                    //txt_company.Visible = true;
                    txt_company.Text = dt.Rows[0]["Company_name"].ToString();
                    txt_softwarename.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["software_name"].ToString());
                    txt_softcode.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["software_code"].ToString());
                    txt_version.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["version"].ToString());
                    txtclasess.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Noofclasses"].ToString());
                    hiddn_id.Value = dt.Rows[0]["software_id"].ToString();
                    hiddn_softname.Value = dt.Rows[0]["software_name"].ToString();
                    lblmsg1.Text = "";
                }
                else
                {
                    ddl_compnames.SelectedValue = dt.Rows[0]["Company_name"].ToString();                    
                    txt_softwarename.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["software_name"].ToString());
                    txt_softcode.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["software_code"].ToString());
                    txt_version.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["version"].ToString());
                    txtclasess.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Noofclasses"].ToString());
                    hiddn_id.Value = dt.Rows[0]["software_id"].ToString();
                    hiddn_softname.Value = dt.Rows[0]["software_name"].ToString();
                    lblmsg1.Text = "";
                }
            }
        }
        if (e.CommandName == "del")
        {
            //"UPDATE module_details SET software_id = TRIM(BOTH ',' FROM REPLACE(CONCAT("," , software_id, ","), CONCAT(",",'22', ",") , ',')) WHERE module_Id=2";
            _Qry = "select software_id,software_name from software_details where software_id='" + e.CommandArgument.ToString() + "'";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            string SFT_NAME = dt.Rows[0]["software_name"].ToString();

            _Qry = "delete from software_details where software_id=" + e.CommandArgument.ToString() + "";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            //_Qry = "UPDATE module_details SET software_id = TRIM(BOTH ',' FROM REPLACE(CONCAT(',' , software_id, ','), CONCAT(',','" + e.CommandArgument.ToString() + "', ',') , ',')),software_name = TRIM(BOTH ',' FROM REPLACE(CONCAT(',' , software_name, ','), CONCAT(',','" + SFT_NAME + "', ',') , ',')) ";
            _Qry = "UPDATE module_details SET software_id = REPLACE((','+ software_id +','),(','+'" + e.CommandArgument.ToString() + "'+ ','),',') ,software_name = REPLACE((',' + software_name + ','), (','+'" + SFT_NAME + "'+ ',') , ',') ";
            Response.Write(_Qry);
            Response.End();
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            _Qry = "DELETE from module_details where software_id ='' or software_id =','";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            _Qry = "delete from submodule_details where software_id="+e.CommandArgument.ToString()+"";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

            lblmsg1.Text = "The Software name has been deleted successfully";
            fillgrid();
            txt_softwarename.Text = "";
            txt_softcode.Text = "";
            txt_version.Text = "";
            txtclasess.Text = "";
            ddl_compnames.SelectedValue = "";
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
