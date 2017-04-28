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
using System.Text.RegularExpressions;

public partial class superadmin_CreateManager : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6, centreid, ddlcencode1;
    protected void Page_Load(object sender, EventArgs e)
    {


        //Response.Write(Session["centre_code"]);
        //Response.End();


        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {
            fillgrid();
        }

        if (!IsPostBack)
        {
            FillCentre();

            ddl_CentreCode.Items.Insert(0, new ListItem("select", ""));
        }
       
    }
    public string removetilde(string str)
    {
        return MVC.CommonFunction.ReplaceTildWithQuote(str);
      
    }
    private void fillgrid()
    {

        // _Qry = "select b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code,b.centre_region,b.centre_category from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.role='CentreManager' and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchlocation.Text) + "%' and a.username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by centre_id desc";

        _Qry = "select masterpassword,password,a.userid,b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code,b.centre_region,b.centre_category,a.login_status from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where role='NSDC'  order by centre_id desc";

        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();

    }
    private void FillCentre()
    {
        _Qry = "select Centre_location,centre_code+'#'+cast(centre_id as varchar) as code_id from img_centredetails ";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        if (dt.Rows.Count > 0)
        {
            ddl_CentreCode.DataSource = dt;

            ddl_CentreCode.DataTextField = "Centre_location";
            ddl_CentreCode.DataValueField = "code_id";

            ddl_CentreCode.DataBind();
        }
    }

    private void insertcentre()
    {
        if ((hdnID.Value == "" || hdnID.Value == null) && (hdnID1.Value == "" || hdnID1.Value == null))
        {
            //_Qry = "select count(centre_id) from img_centredetails where centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "'";
            ////Response.Write(_Qry);
            ////Response.End();
            //int count;
            //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            //if (count > 0)
            //{
            //    lblmsg1.Text = "The Centre Code Already Exist";

            //}
            //else
            //{
                _Qry1 = "select count(centrelogin_id) from img_centrelogin where userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "' or centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_manager_mailid.Text) + "'";
                //Response.Write(_Qry1);
                int count1;
                count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry1);
                if (count1 > 0)
                {
                    lblmsg1.Text = "Manager UserID or EmailId Already Exist";
                }

                else
                {
                    // _Qry = "insert into img_centredetails(centre_code,centre_category,centre_location,centre_region,centre_createdby,centre_updatedby,runningStudentIdType,Enquiry_Count,centre_dateins,centre_dateupd)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "','" + txtcentrecat.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_location.Text) + "','" + ddc_region.SelectedValue + "','" + Session["username"] + "','Notupdated','month','"+txt_enquirycount.Text+"',getdate(),getdate())";

                    // Response.Write(_Qry);
                    // Response.End();
                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);

                    //_Qry1 = "SELECT  centre_id FROM img_centredetails where centre_code='img-008";
                    ////Response.Write(_Qry);
                    //DataTable dt = new DataTable();
                    //dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
                    //centreid = dt.Rows[0][0].ToString();

                    //string code_id = ddl_CentreCode.SelectedValue;

                    //string[] strSplitArr1 = code_id.Split('#');
                    //string cen_code = strSplitArr1[0].ToString();
                    //string cen_id = strSplitArr1[1].ToString();



                    string ddlcencode = ddl_CentreCode.SelectedValue;
                    string[] strddlcensplit = ddlcencode.Split(' ');
                    ddlcencode1 = strddlcensplit[0].ToString();

                    string ddlcencode2 = ddlcencode1;

                   


                    string[] strsplit =ddlcencode2.Split('#');
                    string cen_code = strsplit[0].ToString();
                    string cen_id = strsplit[1].ToString();


                    //Response.Write(cen_code);
                    //Response.End();


                    
                    //Response.Write(cen_code + "<br>" + cen_id);
                    //Response.End();


                    _Qry1 = "insert into img_centrelogin(centre_id,username,userid,password,role,centre_code,centre_region,centre_useremail,createdby,updatedby,dateins,dateupd,masterPassword,login_status)values(" + cen_id + ",'" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managername.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "','" + txtc_managerpwd.Text + "','" + ddrole.SelectedValue + "','" + cen_code + "','" + ddc_region.SelectedValue + "','" + txt_manager_mailid.Text + "','" + Session["SA_username"] + "','Not Updated',getdate(),getdate(),'"+txt_masterpass.Text+"','"+ddlloginstatus.SelectedValue+"')";
                    //Response.Write(_Qry1);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                    fillgrid();   

                    // _Qry3 = "select count(cat_id) from img_categories where centre_category='"+txtcentrecat.SelectedValue+"'";
                    // //Response.Write(_Qry);
                    // int count3;
                    // count3 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry3);
                    // if (count3 > 0)
                    // {
                    //     lblmsg1.Text = "";
                    // }
                    // else
                    // {
                    //     _Qry = "insert into img_categories(centre_category)values('" + txtcentrecat.SelectedValue + "')";
                    //     //Response.Write(_Qry);
                    //     MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                    // }

                    // _Qry2 = "insert into img_batch_count(centre_code,batch_code,student_code,invoice_code,receipt_code)values('" + txtc_code.Text + "','0','0','0','0')";
                    // //Response.Write(_Qry);
                    // MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry2);
                    // lblmsg1.Text = "Centre Inserted Successfully";



                }
            }

       // }
       
    }
    
   
    private void refresh()
    {
        ddl_CentreCode.SelectedValue = "";
        txtc_managername.Text = "";
       
        ddrole.SelectedValue = "";
        ddc_region.SelectedValue = "";
        txtc_managerid.Text = "";
        txtc_managerpwd.Text = "";
        txtc_manager_repwd.Text = "";
        txt_manager_mailid.Text = "";
     
        hdnID.Value = "";
        hdnID1.Value = "";
        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       


        if ((hdnID.Value == "" || hdnID.Value == null) && (hdnID1.Value == "" || hdnID1.Value == null))
        {
            insertcentre();
        }
        else
        {
            centreupdate();
        }

        refresh();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkdel")
        {
            
            _Qry1 = "delete from img_centrelogin where centrelogin_id='" + e.CommandArgument.ToString() + "'";

            //Response.Write(_Qry1);
            //Response.End();

            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
            fillgrid();

            lblmsg1.Text = "The Centre Deleted Successfully";


        }
        if (e.CommandName == "lnkedit")
        {
            _Qry = "select a.userid,b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code+'#'+cast(b.centre_id as varchar) as code_id    ,b.centre_region,b.centre_category from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.centrelogin_id=" + e.CommandArgument.ToString() + "";

            //Response.Write(_Qry);
            //Response.End();


            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
               

                ddl_CentreCode.SelectedValue = dt.Rows[0]["code_id"].ToString();

                ddc_region.SelectedValue = dt.Rows[0]["centre_region"].ToString();
                txtc_managername.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["username"].ToString());
                ddrole.SelectedValue = dt.Rows[0]["role"].ToString();
                txt_manager_mailid.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_useremail"].ToString());
               txtc_managerid.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["userid"].ToString());
                
                hdnID.Value = dt.Rows[0]["centre_id"].ToString();
                hdnID1.Value = dt.Rows[0]["centrelogin_id"].ToString();
                
                lblmsg1.Text = "";
            }
         }
        if (e.CommandName == "lnkstatus")
        {
            string status = "";
            string[] comm_arg = e.CommandArgument.ToString().Split(',');
            if (comm_arg[1] == "Enable")
                status = "Disable";
            else if (comm_arg[1] == "Disable")
                status = "Enable";
            _Qry1 = "update  img_centrelogin set login_status='" + status + "' where centrelogin_id='" + comm_arg[0] + "'";

            //Response.Write(_Qry1);
            //Response.End();

            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
            fillgrid();

            lblmsg1.Text = "The Centre status updated Successfully";


        }
    }
    private void centreupdate()
    {
        if (hdnID.Value != "" && hdnID1.Value != "")
        {
            //_Qry = "select count(centre_id) from img_centredetails where centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "' and centre_id <> " + hdnID.Value + " ";
            ////Response.Write(_Qry);
            ////Response.End();
            //int count;
            //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            //if (count > 0)
            //{
            //    lblmsg1.Text = "The Centre Code already Exist";
            //}
            //else
            //{
                //_Qry1 = "select count(centrelogin_id) from img_centrelogin where (userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "' or centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_manager_mailid.Text) + "') and centrelogin_id <> " + hdnID1.Value + "";
                ////Response.Write(_Qry1);
                //int count1;
                //count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry1);
                //if (count1 > 0)
                //{
                //    lblmsg1.Text = "Manager UserID or EmailId Already Exist";
                //}
                //else
                //{
                    //_Qry = "update img_centredetails set centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "',centre_category='" + txtcentrecat.SelectedValue + "',centre_location='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_location.Text) + "',centre_region='" + ddc_region.SelectedValue + "',centre_updatedby='" + Session["username"] + "',centre_dateupd=getdate() where centre_id=" + hdnID.Value + "";
                    ////Response.Write(_Qry);
                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                            string cen_code = ddl_CentreCode.SelectedValue;

                            string[] strSplitArr1 = cen_code.Split('#');
                            string code = strSplitArr1[0].ToString();
                                        

                    //Response.Write(code_id + "<br>" + cen_code + "<br>" + cen_id);
                    //Response.End();
                    

                     _Qry1 = "update img_centrelogin set masterpassword='"+txt_masterpass.Text+"',centre_code='"+code+"', username='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managername.Text) + "',role='" + ddrole.SelectedValue + "',centre_region='" + ddc_region.SelectedValue + "',centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_manager_mailid.Text) + "',password='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerpwd.Text) + "',login_status='"+ddlloginstatus.SelectedValue+"',updatedby='" + Session["username"] + "',dateupd=getdate() where centrelogin_id=" + hdnID1.Value + "";
                    //Response.Write(_Qry);
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                    fillgrid();
                    refresh();

                    //_Qry3 = "select count(cat_id) from img_categories where centre_category='" + txtcentrecat.SelectedValue + "'";
                    ////Response.Write(_Qry);
                    //int count3;
                    //count3 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry3);
                    //if (count3 > 0)
                    //{
                    //    lblmsg1.Text = "";
                    //}
                    //else
                    //{
                    //    _Qry = "insert into img_categories(centre_category)values('" + txtcentrecat.SelectedValue + "')";
                    //    //Response.Write(_Qry);
                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //}

                    lblmsg1.Text = "The Centre Updated Successfully";

                }
            //}

        //}
       

    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();

    }

    public string maskpasswordcharacters(string str)
    {
        string subStr = string.Empty;
        if (str.Length > 4)
        {
             subStr = str.Substring(0, str.Length - 4);
             subStr =subStr+ "####";

        }
        else
        {
        }
        return subStr;

    }
    protected void grdcentre_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                //if (DataBinder.Eval(e.Row.DataItem, "active_status").ToString() == "0")
                //{
                //    e.Row.BackColor = System.Drawing.Color.PeachPuff;
                //}
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
}
