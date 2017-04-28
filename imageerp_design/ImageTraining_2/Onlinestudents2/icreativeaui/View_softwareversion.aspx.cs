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

public partial class Onlinestudents2_superadmin_View_softwareversion : System.Web.UI.Page
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
            fill_software();
        }
    }
    void fill_software()
    {
        _Qry = "select sub.software_Id,soft.software_name,soft.version from submodule_details sub inner join software_details soft on sub.software_id=soft.software_Id where course_id='" + Request.QueryString["cou_id"] + "' group by sub.software_id,soft.software_name,soft.version";
        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridviewsoftware.DataSource = dt;
        Gridviewsoftware.DataBind();
    }
    //protected void Gridviewsoftware_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "d")
    //    {
    //        _Qry = "update software_details set status='Disable' where software_Id='" + e.CommandArgument.ToString() + "'";
    //        obj.executenonquery(_Qry);
    //        fill_software();
    //        lblerrormsg.Text = "Software version disabled";
    //    }

    //in grid
     //<asp:TemplateField HeaderText="Action">
     //            <ItemTemplate>
                     
     //                <asp:Button ID="btn_Update" CommandArgument='<%#Eval("software_Id") %>' CommandName="d" runat="server" CssClass="submit" Text="Disable" OnClientClick="javascript:return confirm('Do you want to Disable the software?');" />
                 
     //            </ItemTemplate>
     //           </asp:TemplateField>  
    //}
    protected void Gridviewsoftware_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridviewsoftware.PageIndex = e.NewPageIndex;
        fill_software();
    }
}
