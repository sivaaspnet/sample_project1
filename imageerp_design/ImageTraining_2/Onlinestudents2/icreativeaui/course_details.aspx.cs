using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class course_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
            if (!IsPostBack == true)
            {

                BindGrid();
                ddlcoursefill();

            }
        
    }
    protected void BindGrid()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds.ReadXml(Server.MapPath("course_details.xml"));
        if (ddlcourse.SelectedValue == "")
        {
            if (ds != null && ds.HasChanges())
            {
                grdcourse.DataSource = ds;
                grdcourse.DataBind();
            }
            else
            {
                grdcourse.DataBind();
            }
        }
        else
        {
            DataRow[] dr;
            DataTable dt1=new DataTable();
            dt = ds.Tables[0];
            dr = dt.Select("coursename='" + ddlcourse.SelectedItem.Text + "'");
            if (dr.Length != 0)
            {
                //dt1 = dr.CopyToDataTable();
                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dt1);
                grdcourse.DataSource = ds1;
                grdcourse.DataBind();
            }
            else
            {
                ddlcourse.ClearSelection();
                Response.Write("No Data Found");
            }

        }
    }
    protected void BindGrid1()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds.ReadXml(Server.MapPath("course_details.xml"));
        if (ds != null && ds.HasChanges())
        {
            grdcourse.DataSource = ds;
            grdcourse.DataBind();
        }
        else
            grdcourse.DataBind();
    }
    protected void ddlcoursefill()
    {
        string filePath = Server.MapPath("course_details.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(filePath);
        ddlcourse.DataSource = ds;
        ddlcourse.DataTextField = "coursename";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("All", ""));


    }
    protected void gvEmployee_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Add"))
        {
            TextBox txtAddERPcourse_id = (TextBox)grdcourse.FooterRow.FindControl("txtAddERPcourse_id");
            TextBox txtAddprogram = (TextBox)grdcourse.FooterRow.FindControl("txtAddprogram");
            TextBox txtAddcoursename = (TextBox)grdcourse.FooterRow.FindControl("txtAddcoursename");
            TextBox txtAddNSDCCourseid = (TextBox)grdcourse.FooterRow.FindControl("txtAddNSDCCourseid");
            string qry = "select count(*) from img_coursedetails where course_id='" + txtAddERPcourse_id.Text.Trim() + "' and program='" + txtAddprogram.Text.Trim() + "' and coursename='" + txtAddcoursename.Text.Trim() + "'";
            int check_count_db = nsdc.DataAccess.ExecuteScalar_int(qry);
            bool check_Xml = check_xml(txtAddERPcourse_id.Text);
            if (check_count_db > 0)
            {
                if (check_Xml == false)
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(Server.MapPath("course_details.xml"));
                    XmlElement parentelement = xmldoc.CreateElement("Table");

                    XmlElement ERPcourse_id = xmldoc.CreateElement("ERPcourse_id");
                    XmlElement program = xmldoc.CreateElement("program");
                    XmlElement coursename = xmldoc.CreateElement("coursename");
                    XmlElement NSDCCourseid = xmldoc.CreateElement("NSDCCourseid");

                    ERPcourse_id.InnerText = txtAddERPcourse_id.Text.Trim();
                    program.InnerText = txtAddprogram.Text.Trim();
                    coursename.InnerText = txtAddcoursename.Text.Trim();
                    NSDCCourseid.InnerText = txtAddNSDCCourseid.Text.Trim();
                    parentelement.AppendChild(ERPcourse_id);
                    parentelement.AppendChild(program);
                    parentelement.AppendChild(coursename);
                    parentelement.AppendChild(NSDCCourseid);

                    xmldoc.DocumentElement.AppendChild(parentelement);
                    xmldoc.Save(Server.MapPath("course_details.xml"));
                    BindGrid();
                    lblmsg.Text = "New course added successfully";
                }
                else
                    // Response.Write("This course already exists");
                    lblmsg.Text = "This course already exists";
                

            }
            else
            {
                //Response.Write(txtAddcoursename.Text + " is not a valid course");
                lblmsg.Text = txtAddcoursename.Text + " is not a valid course";
            }
        }
    }
    protected bool check_xml(string ERPcourse_id)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(Server.MapPath("course_details.xml"));
        XmlNodeList theList = xmldoc.SelectNodes("/NewDataSet/Table/ERPcourse_id[text()='" + ERPcourse_id + "']");
        if (theList.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdcourse.EditIndex = e.NewEditIndex;

        BindGrid();
    }
    protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = grdcourse.Rows[e.RowIndex].DataItemIndex;
        string ERPcourse_id = (grdcourse.Rows[e.RowIndex].FindControl("lblERPcourse_id") as Label).Text;
        BindGrid1();
        int pos = create_list(ERPcourse_id);

        DataSet ds = grdcourse.DataSource as DataSet;
        ds.Tables[0].Rows[pos].Delete();
        ds.WriteXml(Server.MapPath("course_details.xml"));
        ddlcourse.ClearSelection();
        BindGrid();
        ddlcoursefill();
    }
    protected void gvEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int i = grdcourse.Rows[e.RowIndex].DataItemIndex;
        string ERPcourse_id = (grdcourse.Rows[e.RowIndex].FindControl("lblERPcourse_id") as Label).Text;
        string NSDCCourseid = (grdcourse.Rows[e.RowIndex].FindControl("txtNSDCCourseid") as TextBox).Text.Trim();
        grdcourse.EditIndex = -1;
        BindGrid1();
        int pos = create_list(ERPcourse_id);
        DataSet ds = (DataSet)grdcourse.DataSource;
        ds.Tables[0].Rows[pos]["NSDCCourseid"] = NSDCCourseid;
        ds.WriteXml(Server.MapPath("course_details.xml"));
        BindGrid1();
        ddlcourse.ClearSelection();
        ddlcoursefill();
    }
    protected void gvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdcourse.EditIndex = -1;
        BindGrid();
    }
    protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcourse.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        BindGrid();

    }
    public class centre_list
    {
        public string coursename;
        public string program;
        public string ERPcourse_id;
        public string NSDCCourseid;
    }
    protected int create_list(string centre_code)
    {
        List<centre_list> list = new List<centre_list>();

        String FileName = Server.MapPath("course_details.xml");
        XmlTextReader tr = new XmlTextReader(FileName);

        while (tr.Read())
        {
            centre_list obj = new centre_list();
            if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "coursename")
            {
                obj.coursename = tr.ReadElementString();

            }
            if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "program")
            {
                obj.program = tr.ReadElementString();
            }
            if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "ERPcourse_id")
            {
                obj.ERPcourse_id = tr.ReadElementString();
            }
            if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "NSDCCourseid")
            {
                obj.NSDCCourseid = tr.ReadElementString();
            }


            if (!String.IsNullOrEmpty(obj.ERPcourse_id))
                list.Add(obj);
        }
        tr.Close();
        int n = -1;
        foreach (centre_list item in list)
        {
            if (item.ERPcourse_id == centre_code)
            {
                n = list.IndexOf(item);
                return n;

            }
        }
        return n;
    }
    protected DataTable getdata()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds.ReadXml(Server.MapPath("course_details.xml"));
        if (ddlcourse.SelectedValue == "")
        {
            dt = ds.Tables[0];
            return dt;
        }
        else
        {
            DataRow[] dr;
            DataTable dt1=new DataTable();
            dt = ds.Tables[0];
            dr = dt.Select("coursename='" + ddlcourse.SelectedItem.Text + "'");
            //dt1 = dr.CopyToDataTable();
            return dt1;
        }
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Course_details.xls"));
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

