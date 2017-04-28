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

public partial class imagemasterpage : System.Web.UI.MasterPage
{
    string _Qry;
    public string TestValue = "Test";
    protected void Page_Load(object sender, EventArgs e)
    {
        //HiddenField1.Value = "Admission.aspx?Test=1";
        //setlink.HRef = "Admission.aspx?Test=1";
        //Response.Write(Session["username"].ToString());
        SubMVC.ERP_Ashok.page_restriction();

        if (!IsPostBack)
        {

            if (Session["Centrerole"].ToString() != "SuperAdmin")
            {

                _Qry = "select Status from ERP_SiteStatus where centre_code='" + Session["centre_code"] + "' and Status='0'";


                //Response.Write(_Qry);
                //Response.End();

                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt1.Rows.Count > 0)
                {

                    Response.Redirect("wrongentry.aspx?offline=yes");

                }

            }




            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["username"].ToString() == "demo_sa")
            {
                
                lbl_role.Text = Session["Centrerole"].ToString();
                lbl_username.Text = Session["userID"].ToString();
                
                Label4.Visible = false;
                lbl_location.Visible = false;
                fillcentre();
                lblSearch.Visible = true;
                v.Visible = true;                
                //Button1.Visible = true;
                lblCentre.Visible = true;
                enroll.Visible = false;
                //lbl_location.Text = Session["Location"].ToString();
                //sess();
            }
            else
            {
                lbl_role.Text = Session["Centrerole"].ToString();
                lbl_username.Text = Session["userID"].ToString();
                lbl_location.Text = Session["Location"].ToString();
                lblSearch.Visible = false;
                v.Visible = false;
                //Button1.Visible = false;
                lblCentre.Visible = false;          
            }
            
            if (Session["centre_code"] == "" || Session["centre_code"] == null || Session["centre_code"].ToString() =="11")
            {
                lblCentre.Text = "Please select the centre to view details";
            }
            else 
            {
                v.SelectedValue = Session["centre_code"].ToString();
                if (Session["username"].ToString() == "demo_sa")
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
            if (Session["Centrerole"].ToString() == "Counselor" || Session["Centrerole"].ToString() == "Technical Head" || Session["Centrerole"].ToString() == "CentreManager" || Session["Centrerole"].ToString() == "SuperAdmin")
            {
                expressupdate();
            }
            else
            {
                enroll.Visible=false;
            }
            
        }
       
        //if (Session["centre_code"] != "" && Session["centre_code"] != null)
        //{
        //    ddl_Centre.SelectedValue = Session["centre_code"].ToString();
        //}

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
        Session["userID"] = "";
        Session["username"] = "";
        Session["Centrerole"] = "";
        Session["centre_code"] = "";
        Session["centre_region"] = "";
        Session["centre_loginstatus"] = "";
        Session["ENQ_ID"] = "";
        Session["Enqno"] = "";
        Session["Student_Id"] = "";
        Session["Password"] = "";
        Response.Redirect("Login.aspx");
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
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    if (v.SelectedValue == "")
    //    {
    //        lblCentre.Text = "";
    //        //lblerrmsg.Text = "Please select centre location";
    //    }
    //    else
    //    {
    //        Session["centre_code"] = v.SelectedValue.ToString();

    //        v.SelectedValue = Session["centre_code"].ToString();

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
    //        Session["centre_code"] = "11";
    //        v.SelectedValue = "";
    //        string[] spliturl = Request.Url.ToString().Split('/');
    //        //Response.Write(spliturl[spliturl.Length-1].ToString());
    //        lblCentre.Text = "";
    //        Response.Redirect(spliturl[spliturl.Length - 1].ToString());
    //        lblCentre.Text = "Please select the centre to view details";
    //    }
    //    else
    //    {
    //        Session["centre_code"] = v.SelectedValue.ToString();

    //        v.SelectedValue = Session["centre_code"].ToString();

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
            Session["centre_code"] = v.SelectedValue.ToString();

            v.SelectedValue = Session["centre_code"].ToString();            
            string[] spliturl = Request.Url.ToString().Split('/');
            //Response.Write(spliturl[spliturl.Length-1].ToString());
            lblCentre.Text = "";
            Response.Redirect(spliturl[spliturl.Length - 1].ToString());
            //lblerrmsg.Text = "You can view " + ddl_Centre.SelectedItem.ToString() + " details";
        }
    }

    private void expressupdate()
    {
        _Qry = "select a.student_id,Enrolled_By,a.enq_personal_name,b.coursename,b.enq_number,isnull(a.student_lastname,'.*.') as ExpressEnrollSt from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where a.Admission_id>0  and isnull(a.student_lastname,'.*.')='.*.'";

            
            if (Session["centre_code"].ToString() != "" && Session["centre_code"].ToString() != null && Session["centre_code"].ToString() != "11")
            {
                _Qry = _Qry + "and b.centre_code like '%" + Session["centre_code"].ToString() + "%'";
            }
            _Qry = _Qry + " Order by a.Admission_id desc";
           // _Qry = _Qry + " Order by a.Admission_id desc";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            lbl_count.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count<=0)
        {
            enroll.Visible = false;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();



        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl = new Label();
            HiddenField hdn = new HiddenField();

            lbl = (Label)gr.FindControl("lblStudId");
            hdn = (HiddenField)gr.FindControl("HdnExpressSt");
            HiddenField hdn1 = new HiddenField();
            hdn1 = (HiddenField)gr.FindControl("hdnEnqid");
            if (hdn.Value == ".*.")
            {
                lbl.Text = "<a href='expressupdate.aspx?end_id=" + hdn1.Value + "'>" + lbl.Text + "</a>";
                lbl.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            }

        }
    }
    }



