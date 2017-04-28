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

public partial class superadmin_Holiday_New : System.Web.UI.Page
{
    string _Qry, dob1, apdate, dob3, dob4, dob5, dday6, dmonth7, dyear8, apdate9,dob11, dob33, dob44, dday66, dmonth77, dyear88, apdate99;

   
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


        Lblfree.Text = "free";

       
    }
    private void fillgrid()
    {


        //_Qry = "select CONVERT(VARCHAR(10),Hoilday_date,105) as Hoilday_date,Holiday_reason,Holiday_Id from atn_hoilday where  Hoilday_date like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_searchdate.Text) + "%' order by Holiday_Id ";

        //if (txt_searchdate.Text != "")
        //{

        //    dob11 = txt_searchdate.Text;
        //    string[] strSplitArr22 = dob11.Split(' ');
        //    dob33 = strSplitArr22[0].ToString();

        //    dob44 = dob33;

        //    string[] strSplitArr55 = dob44.Split('-');
        //    dday66 = strSplitArr55[0].ToString();
        //    dmonth77 = strSplitArr55[1].ToString();
        //    dyear88 = strSplitArr55[2].ToString();

        //    apdate99 = dyear88 + "-" + dmonth77 + "-" + dday66;




        //    _Qry = "select CONVERT(VARCHAR(10),Hoilday_date,105) as Hoilday_date,Holiday_reason,Holiday_Id from atn_hoilday where  Hoilday_date like  convert(datetime,'" + apdate99 + "')  order by Holiday_Id desc";

        //    //Response.Write(_Qry);
        //    //Response.End();
        //}
        //else
        //{
        //    _Qry = "select CONVERT(VARCHAR(10),Hoilday_date,105) as Hoilday_date,Holiday_reason,Holiday_Id from atn_hoilday where  Hoilday_date like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_searchdate.Text) + "%' order by Holiday_Id desc";
        //}
        //Response.Write(_Qry);
       // Response.End();







        _Qry = "select  CONVERT(VARCHAR(10),Hoilday_date,105) as Hoilday_date,Replace(Holiday_reason,'~','''') as Holiday_reason,Holiday_Id from atn_hoilday where  ";
        _Qry += " Holiday_reason like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Txt_search_reason.Text.Trim()) + "%'  ";

        if (DDlSearchbyyear.SelectedValue == "" || DDlSearchbyyear.SelectedValue == null)
        {
            _Qry += "order by Holiday_Id ";
        }
        else
        {


            _Qry += " And year(Hoilday_date)='" + DDlSearchbyyear.SelectedValue + "' order by Holiday_Id ";


            //Response.Write(_Qry);
            //Response.End();
        }




        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void refresh()
    {
        txt_holidate.Text = "";
        txt_Reason.Text = "";
        //ddl_Status.SelectedValue = "";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            _Qry = "select CONVERT(VARCHAR(10),Hoilday_date,105) as Hoilday_date,Holiday_reason,Holiday_Id from atn_hoilday where Holiday_Id=" + e.CommandArgument.ToString() + "";


        //Response.Write(_Qry);
        //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dt.Rows.Count > 0)
            {
                txt_holidate.Text = dt.Rows[0]["Hoilday_date"].ToString();
                txt_Reason.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Holiday_reason"].ToString());
                //ddl_Status.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Status"].ToString());

                hiddn_id.Value = dt.Rows[0]["Holiday_Id"].ToString();
            }
        }
        if (e.CommandName == "del")
        {
            _Qry = "delete from atn_hoilday where Holiday_Id='" + e.CommandArgument.ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            fillgrid();
            lblmsg1.Text = "The Holiday details has been deleted successfully";
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

            string dob = txt_holidate.Text;
            string[] strSplitArr = dob.Split(' ');
            dob1 = strSplitArr[0].ToString();

            string dob2 = dob1;

            string[] strSplitArr1 = dob2.Split('-');
            string dday = strSplitArr1[0].ToString();
            string dmonth = strSplitArr1[1].ToString();
            string dyear = strSplitArr1[2].ToString();

            string apdate = dyear + "-" + dmonth + "-" + dday;




            _Qry = "select count(Holiday_Id) from atn_hoilday where Hoilday_date='" + apdate + "' ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = " Holiday Date already exist";
            }
            else
            {
                //insert
               // _Qry = " INSERT INTO img_labdetails (centre_code , lab_name , sys_count , createdby , dateins )VALUES ('" + Session["SA_centre_code"] + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_labname.Text) + "', '" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_systems.Text) + "', '" + Session["SA_Username"] + "', NOW())";




                _Qry = " INSERT INTO atn_hoilday (Hoilday_date ,Holiday_reason,dateins )VALUES ('" + apdate + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Reason.Text) + "',getdate())";

              


                //Response.Write(_Qry);
                //Response.End();

                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The Holiday Details has been inserted successfully";
                refresh();
            }
        }
        else
        {


            dob3 = txt_holidate.Text;
            string[] strSplitArr1 = dob3.Split(' ');
            dob4 = strSplitArr1[0].ToString();

            dob5 = dob4;

            string[] strSplitArr2 = dob5.Split('-');
            dday6 = strSplitArr2[0].ToString();
            dmonth7 = strSplitArr2[1].ToString();
            dyear8 = strSplitArr2[2].ToString();

            apdate9 = dyear8 + "-" + dmonth7 + "-" + dday6;




            _Qry = "select count(Holiday_Id) from atn_hoilday where Hoilday_date='" + apdate9 + "' and Holiday_Id <> " + hiddn_id.Value + " ";
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
            if (count > 0)
            {
                lblmsg1.Text = " Holiday Date already exist";
            }
            else
            {
                //update



               



                _Qry = "update atn_hoilday set Hoilday_date='" + apdate9 + "',Holiday_reason='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_Reason.Text) + "',datemod=getdate() where Holiday_Id=" + hiddn_id.Value + "";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString,_Qry);
                fillgrid();
                lblmsg1.Text = "The Holiday Details has been Updated successfully";
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Holiday_New.aspx");
    }

}
