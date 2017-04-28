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

public partial class superadmin_LabDetails : System.Web.UI.Page
{
    string _Qry;
    string batchtrak;
    public string _Labname = "";
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            fillgrid();
            secondgrid();
        }
        _Labname = Request.QueryString["LabName"].ToString();
    }
    #endregion

    #region to go to the enter batch code page
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("LabAvail.aspx");
    }
    #endregion


    #region for filling the student list
    private void fillgrid()
    {
        _Qry = "Select LabName,System,(Select Count(*) From Batch_Details Where batch_Time='7amto9am' And batch_Labname='" + Request.QueryString["LabName"] + "') as [7amto9amM],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='9amto11am' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [9amto11amM],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='11amto1pm' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [11amto1pmM] ,";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='1pmto3pm' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [1pmto3pmM],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='3pmto5pm' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [3pmto5pmM],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='5pmto7pm' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [5pmto7pmM],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='7pmto9pm' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [7pmto9pmM],";
        //_Qry += " (Select Batch_Code From Batch_Details Where batch_Time='7pmto9pm' And Batch_slot='MWF' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as Batch_Code";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='7amto9am' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "') as [7amto9amT],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='9amto11am' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [9amto11amT],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='11amto1pm' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [11amto1pmT] ,";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='1pmto3pm' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [1pmto3pmT],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='3pmto5pm' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [3pmto5pmT],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='5pmto7pm' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [5pmto7pmT],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='7pmto9pm' And Batch_slot='TTS' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [7pmto9pmT],";

        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='7amto9am' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "') as [7amto9amD],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='9amto11am' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [9amto11amD],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='11amto1pm' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [11amto1pmD] ,";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='1pmto3pm' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [1pmto3pmD],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='3pmto5pm' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [3pmto5pmD],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='5pmto7pm' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [5pmto7pmD],";
        _Qry += "(Select Count(*) From Batch_Details Where batch_Time='7pmto9pm' And Batch_slot='Daily' And batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "') as [7pmto9pmD]";

        _Qry += " From online_students_labavail Where Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "'";

        //[9amto11am],[11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm],";
        _Qry += " Order By LabId";

        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    #endregion


    private void secondgrid()
    {
        _Qry = "Select Batch_Code,'" + Request.QueryString["LabName"] + "' as LabName,Batch_Track,Batch_Module_Content,(Select convert(varchar(10),Batch_Startdate,103)) as Batch_Startdate,(Select convert(varchar(10),Batch_Enddate,103)) as Batch_Enddate From Batch_Details Where batch_Labname='" + Request.QueryString["LabName"] + "' And centre_code='" + Session["SA_centre_code"] + "' ";
        _Qry += " Group By Batch_Code,Centre_Code,Batch_Track,Batch_Module_Content,Batch_Startdate,Batch_Enddate";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            GridView2.Visible = true;
        }
        else
        {
            GridView2.Visible = false;
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

   // #region for paging Student grid
   // protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   // {
   //     GridView1.PageIndex = e.NewPageIndex;
   //     fillgrid();
   // }
   // #endregion




    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    //_Qry = "Select batch_code,batch_labname,batch_faculty,batch_time,System,count(*) as noofsystem,batch_slot";
    //    //_Qry += " from batch_details";
    //    //_Qry += " inner join online_students_labavail on batch_details.batch_labname=online_students_labavail.LabName ";
 
    //    //_Qry +=" Where batch_time='" + ddl_time.SelectedValue + "' And batch_Labname='" + Request.QueryString["LabName"] + "'";
    //    //_Qry +=" Group by batch_slot,batch_time,batch_labname,batch_faculty,batch_code,System";

    //    _Qry = "Select LabName,System,(Select Count(*) From Batch_Details Where batch_Time='[7amto9am]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [7amto9am],";
    //    _Qry = "(Select Count(*) From Batch_Details Where batch_Time='[9amto11am]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [9amto11am],";
    //    _Qry += "(Select Count(*) From Batch_Details Where batch_Time='[11amto1pm]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [11amto1pm] ,";
    //    _Qry += "(Select Count(*) From Batch_Details Where batch_Time='[1pmto3pm]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [1pmto3pm],";
    //    _Qry += "(Select Count(*) From Batch_Details Where batch_Time='[3pmto5pm]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [3pmto5pm],";
    //    _Qry += "(Select Count(*) From Batch_Details Where batch_Time='[5pmto7pm]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [5pmto7pm],";
    //    _Qry += "(Select Count(*) From Batch_Details Where batch_Time='[7pmto9pm]' And batch_Labname='" + Request.QueryString["LabName"] + "') as [7pmto9pm],";
    //    _Qry += " (Select Batch_Code From Batch_Details Where batch_Time='[7pmto9pm]' And batch_Labname='" + Request.QueryString["LabName"] + "') as Batch_Code";
    //    _Qry += " From online_students_labavail Where batch_Labname='" + Request.QueryString["LabName"] + "'";
            
    //        //[9amto11am],[11amto1pm],[1pmto3pm],[3pmto5pm],[5pmto7pm],[7pmto9pm],";
    //    _Qry += " Order By LabId";

    //    //Response.Write(_Qry);
    //    //Response.End();
    //    DataTable dt = new DataTable();
    //    dt = MVC.DataAccess.ExecuteDataTable(_Qry);
    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();
    //}
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
    //        background-color: orange;
    //border-color: black;
    //color: black;
    //font-weight: bold;
    //padding-left: 5px;
    //text-shadow: none;

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell Cell_Header = new TableCell();

            Cell_Header = new TableCell();
            Cell_Header.Text = "Lab Name";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Total System";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "7am to 9am";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "9am to 11am";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "11am to 1pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "1pm to 3pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "3pm to 5pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "5pm to 7pm";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "7pm to 9pm";
            //Cell_Header.Style["Align"] = "center";
            Cell_Header.BackColor = System.Drawing.Color.Orange;
            Cell_Header.BorderColor = System.Drawing.Color.Black;
            Cell_Header.ForeColor = System.Drawing.Color.Black;
            Cell_Header.Style["font-weight"] = "bold";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 3;
            HeaderRow.Cells.Add(Cell_Header);


            GridView1.Controls[0].Controls.AddAt(0, HeaderRow);

        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }
    }
}
