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

public partial class Ipadmasterpage : System.Web.UI.MasterPage
{
    string _Qry;
    public string TestValue = "Test";
    protected void Page_Load(object sender, EventArgs e)
    {
        //HiddenField1.Value = "Admission.aspx?Test=1";
        //setlink.HRef = "Admission.aspx?Test=1";
        if (!IsPostBack)
        {
            if (Session["SA_Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["SA_Username"].ToString() == "sa")
            {
                lbl_role.Text = Session["SA_Centrerole"].ToString();
                lbl_username.Text = Session["SA_UserID"].ToString();
                
                Label4.Visible = false;
                lbl_location.Visible = false;
                fillcentre();
                lblSearch.Visible = true;
                v.Visible = true;                
                //Button1.Visible = true;
                lblCentre.Visible = true;
                //lbl_location.Text = Session["SA_Location"].ToString();
                //sess();
            }
            else
            {
                lbl_role.Text = Session["SA_Centrerole"].ToString();
                lbl_username.Text = Session["SA_UserID"].ToString();
                lbl_location.Text = Session["SA_Location"].ToString();
                lblSearch.Visible = false;
                v.Visible = false;
                //Button1.Visible = false;
                lblCentre.Visible = false;          
            }
            
            if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null || Session["SA_centre_code"].ToString() =="11")
            {
                lblCentre.Text = "Please select the centre to view details";
            }
            else 
            {
                v.SelectedValue = Session["SA_centre_code"].ToString();
                if (Session["SA_Username"].ToString() == "sa")
                {
                    lblCentre.Text = "";
                }
                else
                {
                    lblCentre.Text = "";
                    lblCentre.Visible = false;
                }
            }
        }
        
        //if (Session["SA_centre_code"] != "" && Session["SA_centre_code"] != null)
        //{
        //    ddl_Centre.SelectedValue = Session["SA_centre_code"].ToString();
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
        Session.Abandon();
        Session["SA_UserID"] = null;
        Session["SA_Username"] = null;
        Response.Redirect("Login.aspx?st=out");
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
    //        Session["SA_centre_code"] = v.SelectedValue.ToString();

    //        v.SelectedValue = Session["SA_centre_code"].ToString();

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
    //        Session["SA_centre_code"] = "11";
    //        v.SelectedValue = "";
    //        string[] spliturl = Request.Url.ToString().Split('/');
    //        //Response.Write(spliturl[spliturl.Length-1].ToString());
    //        lblCentre.Text = "";
    //        Response.Redirect(spliturl[spliturl.Length - 1].ToString());
    //        lblCentre.Text = "Please select the centre to view details";
    //    }
    //    else
    //    {
    //        Session["SA_centre_code"] = v.SelectedValue.ToString();

    //        v.SelectedValue = Session["SA_centre_code"].ToString();

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
            Session["SA_centre_code"] = v.SelectedValue.ToString();

            v.SelectedValue = Session["SA_centre_code"].ToString();            
            string[] spliturl = Request.Url.ToString().Split('/');
            //Response.Write(spliturl[spliturl.Length-1].ToString());
            lblCentre.Text = "";
            Response.Redirect(spliturl[spliturl.Length - 1].ToString());
            //lblerrmsg.Text = "You can view " + ddl_Centre.SelectedItem.ToString() + " details";
        }
    }
    }



