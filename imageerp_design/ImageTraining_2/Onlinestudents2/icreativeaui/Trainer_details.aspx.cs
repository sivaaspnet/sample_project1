using System;
using System.Collections.Generic;
//using System.Linq;
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
//using System.Xml.Linq;
using System.Data.SqlClient;
using System.Threading;

public partial class Trainer_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack == true)
        {

            centerfill(ddlcenter);
            ddlcenter.Items.Insert(0, new ListItem("Select", ""));
            centerfill(ddlcenter_search);
            ddlcenter_search.Items.Insert(0, new ListItem("All", ""));
            BindGrid();



        }
    }

    protected void centerfill(DropDownList ddlcenter)
    {
        DataTable dt_centre = nsdc.DataAccess.ExecuteDataTable("select distinct Center_Code,Center_Name from NSDC_centredetails order by Center_Name");
        ddlcenter.DataSource = dt_centre;
        ddlcenter.DataTextField = "Center_Name";
        ddlcenter.DataValueField = "Center_Code";
        ddlcenter.DataBind();

    }

    protected void BindGrid()
    {
        GridView1.DataSource = getdata(); ;
        GridView1.DataBind();





    }


    protected DataTable getdata()
    {
        string query = "select Center_Code,Center_Name,TrainerID,TrainerName from NSDC_centredetails where TrainerID<>'' and TrainerName<>''";

        if (ddlcenter_search.SelectedValue != "")
        {
            query += " and Center_Code ='" + ddlcenter_search.SelectedValue + "'";
        }
        query += " order by Center_Name asc";
        DataTable dt = nsdc.DataAccess.ExecuteDataTable(query);
        return dt;
    }


    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("CEdit"))
        {
            btnsubmit.Text = "Update";
            string[] trainer_center = e.CommandArgument.ToString().Split(',');
            DataTable dt = nsdc.DataAccess.ExecuteDataTable("select Center_Name,TrainerID,TrainerName from NSDC_centredetails where  TrainerID='" + trainer_center[0] + "' and Center_Code='" + trainer_center[1] + "'");
            ddlcenter.ClearSelection();
            ddlcenter.Items.FindByValue(trainer_center[1].ToString()).Selected = true;
            ddlcenter.Enabled = false;
            txttrainerid.Enabled = false;
            txttrainerid.Text = dt.Rows[0]["TrainerID"].ToString();
            txttrainername.Text = dt.Rows[0]["TrainerName"].ToString();

        }
        else if (e.CommandName.Equals("CDelete"))
        {
            string[] trainer_center = e.CommandArgument.ToString().Split(',');
            string qry_del = "delete from NSDC_centredetails where TrainerID='" + trainer_center[0] + "' and Center_Code='" + trainer_center[1] + "'  ";
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (btnsubmit.Text == "submit")
        {
            int check_centre = nsdc.DataAccess.ExecuteScalar_int("select count(*) from NSDC_centredetails where TrainerID='" + txttrainerid.Text + "'  and  Center_Code='" + ddlcenter.SelectedValue + "'");


            if (check_centre == 0)
            {
                string qry_insert = "";
                string id = nsdc.DataAccess.ExecuteScalar_str("SELECT CASE WHEN EXISTS(select NSDC_centredetID from NSDC_centredetails where Center_Code='" + ddlcenter.SelectedValue + "' and TrainerID is null and TrainerName is null ) THEN (select NSDC_centredetID from NSDC_centredetails where Center_Code='" + ddlcenter.SelectedValue + "' and TrainerID is null and TrainerName is null) ELSE 0 END");
                if (id == "0")
                {
                    DataTable dt = nsdc.DataAccess.ExecuteDataTable("select SDMS_CenterID,TCState,TCDistrict from NSDC_centredetails where Center_Code='" + ddlcenter.SelectedValue + "'");
                    qry_insert = "insert into NSDC_centredetails(Center_Code,Center_Name,SDMS_CenterID,TrainerID,TrainerName,TCState,TCDistrict) values('" + ddlcenter.SelectedValue + "','" + ddlcenter.SelectedItem.Text + "','" + dt.Rows[0]["SDMS_CenterID"] + "','" + txttrainerid.Text + "','" + txttrainername.Text + "','" + dt.Rows[0]["TCState"] + "','" + dt.Rows[0]["TCDistrict"] + "')";
                }
                else
                    qry_insert = "update NSDC_centredetails set TrainerID='" + txttrainerid.Text + "' ,TrainerName='" + txttrainername.Text + "' where NSDC_centredetID='" + id + "'";

                nsdc.DataAccess.ExecuteNonQuery(qry_insert);
                lblmsg.Text = "New Trainer detail added successfully";
            }
            else
                // Response.Write("This Trainer details already exists");
                lblmsg.Text = "This Trainer details already exists";


        }
        else
        {
            string qry_update = "update NSDC_centredetails set TrainerName='" + txttrainername.Text + "' where TrainerID='" + txttrainerid.Text + "' and Center_Code='" + ddlcenter.SelectedValue + "' ";
            nsdc.DataAccess.ExecuteNonQuery(qry_update);
            lblmsg.Text = "Trainer detail updated successfully";
        }

        refresh();
        BindGrid();

    }
    protected void refresh()
    {
        ddlcenter.Enabled = true;
        ddlcenter.ClearSelection();
        txttrainerid.Text = "";
        txttrainername.Text = "";
        btnsubmit.Text = "submit";
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Trainer_details.xls"));
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
