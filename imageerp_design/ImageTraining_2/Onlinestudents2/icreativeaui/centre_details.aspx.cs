using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Threading;

public partial class centre_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack == true)
        {
            state_fill(ddltcstate);
            centerfill(ddlcenter);
            BindGrid();



        }
    }
    protected void state_fill(DropDownList ddl_tcstate)
    {
        string filePath = Server.MapPath("nsdc.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(filePath);
        ds.Tables[0].DefaultView.RowFilter = "States <>''";
        ddl_tcstate.DataSource = ds.Tables[0];
        ddl_tcstate.DataTextField = "States";
        ddl_tcstate.DataBind();
        ddl_tcstate.Items.Insert(0, new ListItem("Select", ""));

    }
    protected void centerfill(DropDownList ddlcenter)
    {
        DataTable dt_centre = nsdc.DataAccess.ExecuteDataTable("select centre_code,centre_location from img_centredetails");
        ddlcenter.DataSource = dt_centre;
        ddlcenter.DataTextField = "centre_location";
        ddlcenter.DataValueField = "centre_code";
        ddlcenter.DataBind();
        ddlcenter.Items.Insert(0, new ListItem("Select", ""));
    }

    protected void BindGrid()
    {
        GridView1.DataSource = getdata();
        GridView1.DataBind();





    }
    protected DataTable getdata()
    {
        string query = "select distinct Center_Code,Center_Name,SDMS_CenterID,TCState,TCDistrict from NSDC_centredetails ";

        if (txtcentre_name.Text != "" && txtcentre_name.Text != null)
        {
            query += " where Center_Name like'%" + txtcentre_name.Text + "%'";
        }
        query += " order by TCState asc";
        DataTable dt = nsdc.DataAccess.ExecuteDataTable(query);
        return dt;
    }





    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("CEdit"))
        {
            btnsubmit.Text = "Update";
            DataTable dt = nsdc.DataAccess.ExecuteDataTable("select Center_Name,SDMS_CenterID,TCState,TCDistrict from NSDC_centredetails where Center_Code='" + e.CommandArgument + "'");
            ddlcenter.ClearSelection();
            ddlcenter.Items.FindByValue(e.CommandArgument.ToString()).Selected = true;
            ddlcenter.Enabled = false;
            txt_sdms_centerid.Text = dt.Rows[0]["SDMS_CenterID"].ToString();
            ddltcstate.ClearSelection();
            ddltcstate.Items.FindByText(dt.Rows[0]["TCState"].ToString()).Selected = true;
            districtfill(dt.Rows[0]["TCState"].ToString());
            ddltcdistrict.ClearSelection();
            ddltcdistrict.Items.FindByText(dt.Rows[0]["TCDistrict"].ToString()).Selected = true;
        }
        else if (e.CommandName.Equals("CDelete"))
        {
            string qry_del = "delete from NSDC_centredetails where Center_Code='" + e.CommandArgument + "'";
            nsdc.DataAccess.ExecuteDataTable(qry_del);
            BindGrid();
        }
    }




    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddltcstate_SelectedIndexChanged(object sender, EventArgs e)
    {

        districtfill(ddltcstate.SelectedItem.Text);
    }
    protected void districtfill(string state)
    {
        string filepath = HttpContext.Current.Server.MapPath("States_district_list.xml");
        DataSet ds = new DataSet();
        DataTable dt;
        DataRow[] dr;
        DataTable dt1;
        ds.ReadXml(filepath);
        dt = ds.Tables[0];
        dr = dt.Select("States='" + state + "'");
        dt1 = dr.CopyToDataTable();
        ddltcdistrict.DataSource = dt1;
        ddltcdistrict.DataTextField = "Districts";
        ddltcdistrict.DataBind();
        ddltcdistrict.Items.Insert(0, new ListItem("Select", ""));

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (btnsubmit.Text == "submit")
        {
            int check_centre = nsdc.DataAccess.ExecuteScalar_int("select count(*) from NSDC_centredetails where Center_Code='" + ddlcenter.SelectedValue + "' and Center_Name='" + ddlcenter.SelectedItem.Text + "' ");


            if (check_centre == 0)
            {
                string qry_insert = "insert into NSDC_centredetails(Center_Code,Center_Name,SDMS_CenterID,TCState,TCDistrict) values('" + ddlcenter.SelectedValue + "','" + ddlcenter.SelectedItem.Text + "','" + txt_sdms_centerid.Text.Trim()+ "','" + ddltcstate.SelectedItem.Text + "','" + ddltcdistrict.SelectedItem.Text + "')";
                nsdc.DataAccess.ExecuteNonQuery(qry_insert);
                lblmsg.Text = "Centre Added successfully";
            }
            else
                //Response.Write("This Center already exists");
                lblmsg.Text = "This Center already exists";



        }
        else
        {
            string qry_update = "update NSDC_centredetails set SDMS_CenterID='" + txt_sdms_centerid.Text.Trim() + "',TCState='" + ddltcstate.SelectedItem.Text + "',TCDistrict='" + ddltcdistrict.SelectedItem.Text + "' where Center_Code='" + ddlcenter.SelectedValue + "'";
            nsdc.DataAccess.ExecuteNonQuery(qry_update);
            btnsubmit.Text = "Submit";
            lblmsg.Text = "Centre updated successfully";
        }
        refresh();
        BindGrid();

    }
    protected void refresh()
    {
        ddlcenter.Enabled = true;
        ddlcenter.ClearSelection();
        txt_sdms_centerid.Text = "";
        ddltcstate.ClearSelection();
        ddltcdistrict.ClearSelection();
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Centre_details.xls"));
        Response.ContentType = "application/ms-excel";
        DataTable dt = getdata();
        string str = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(str + Convert.ToString(dr[j]));
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }
}
