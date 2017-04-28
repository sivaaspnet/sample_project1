<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="course_details.aspx.cs" Inherits="course_details" Title="NSDC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
       
 
        .input-lbl2
{
   
	font-size:16px;
float:right;
	
}
.input-txt1{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 210px;
	
	font-size:14px;
	color:#666666;
    margin-left: 0px;
     
}
.input-txt1:focus
{
    background-color: #FFFFCC;
}
.input-txt_multi{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 70px;
    padding: 0 5px;
    width: 230px;
	
	font-size:14px;
	color:#666666;
    margin-left: 0px;
     
}
.input-txt_multi:focus
{
    background-color: #FFFFCC;
}
.input-ddl{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 400px;
	
	font-size:14px;
	color:#666666;
    margin-left: 0px;
    float:left;
}
.input-ddl:focus
{
    background-color: #FFFFCC;
}


   
    </style>
 <script type="text/javascript">
        function  validation() {
            //alert("validate");
            if (document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddERPcourse_id")).ClientID  %>").value == "") {
                alert("Please enter ERP courseID");
                document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddERPcourse_id")).ClientID %>").focus();
                return false;
            }
            else if (document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddERPcourse_id")).ClientID %>").value != "") {
                 
                   if (isNaN(document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddERPcourse_id")).ClientID %>").value)==true) {
                       alert("ERP courseID should be in numeric ");
                       document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddERPcourse_id")).ClientID %>").focus();
                       return false;
                   }
               }
            if (document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddprogram")).ClientID  %>").value == "") {
                alert("Please enter Program name of course");
                document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddprogram")).ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddcoursename")).ClientID  %>").value == "") {
                alert("Please enter Course name");
                document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddcoursename")).ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddNSDCCourseid")).ClientID  %>").value == "") {
                alert("Please enter NSDC CourseID");
                document.getElementById("<%=((TextBox)grdcourse.FooterRow.FindControl("txtAddNSDCCourseid")).ClientID %>").focus();
                return false;
            }
          
             
          
            return true;
        }
        function ValidateGrid(x)
        {
        //alert("ValidateGrid");
        var grdcourse=document.getElementById('<%=grdcourse.ClientID %>');

        var selectedRowIndex=x.parentNode.parentNode.rowIndex;

        var txtNSDCCourseid=grdcourse.rows[parseInt(selectedRowIndex)].cells[3].children[0];
  
        if (txtNSDCCourseid.value == "") {
                alert("Please enter NSDC CourseID");
                txtNSDCCourseid.focus();
                return false;
            }
            return true;
        }
       </script>
      <div class="title-cont">
    <h3 class="cont-title">Course Details</h3>
    <div style="color:#1b70c5; font-size:14px; float:right; margin-top:30px">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="course_details.aspx">Course List</asp:HyperLink>&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="centre_details.aspx">Centre List</asp:HyperLink>&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Trainer_details.aspx">Trainer List</asp:HyperLink>
</div>
  </div> 
      
     <div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Course Name</div>
        <div class="wth-2"> <asp:DropDownList runat="server" ID="ddlcourse" CssClass="input-ddl"></asp:DropDownList></div>
      </li>
        <li>
      
    
        
       <asp:Button ID="btnsearch" runat="server" CssClass="search"  OnClick="btnsearch_Click"/>
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
   <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
	</div>




<div class="white-cont">
<div style="padding:0px 10px 10px 10px">
             
   
    <asp:GridView ID="grdcourse" runat="server" AutoGenerateColumns="false" ShowFooter="true"
    OnRowCommand="gvEmployee_OnRowCommand"
    onrowcancelingedit="gvEmployee_RowCancelingEdit"
    onrowdeleting="gvEmployee_RowDeleting" onrowediting="gvEmployee_RowEditing"
    onrowupdating="gvEmployee_RowUpdating"
    onpageindexchanging="gvEmployee_PageIndexChanging"  AllowPaging="true"  
        PageSize="10" CssClass="tbl-cont3" CellPadding="3" CellSpacing="1" >
<Columns>
       
    <asp:TemplateField HeaderText="ERPcourse_id" HeaderStyle-Width="100px">
        
    <ItemTemplate >
        <asp:Label ID="lblERPcourse_id" runat="server" Text='<%#DataBinder.Eval(
                             Container. DataItem,"ERPcourse_id") %>'></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtAddERPcourse_id" runat="server" CssClass="text input-txt" ></asp:TextBox>       
    </FooterTemplate>
    </asp:TemplateField>
 
    <asp:TemplateField HeaderText="program" HeaderStyle-Width="100px">
    <ItemTemplate >
        <asp:Label ID="lblprogram" runat="server" Text='<%#DataBinder.Eval(
                            Container. DataItem,"program") %>'></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtAddprogram" runat="server" CssClass="text input-txt "></asp:TextBox>       
    </FooterTemplate>
    </asp:TemplateField>
 
    <asp:TemplateField HeaderText="coursename" HeaderStyle-Width="100px">
    
    <ItemTemplate >
        <asp:Label ID="lblcoursename" runat="server" Text='<%#DataBinder.Eval(
                              Container. DataItem,"coursename") %>'></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtAddcoursename" runat="server" CssClass="input-txt_multi" TextMode="MultiLine" ></asp:TextBox>       
    </FooterTemplate>
    </asp:TemplateField>
 
    <asp:TemplateField HeaderText="NSDCCourseid" HeaderStyle-Width="100px">
    <EditItemTemplate>
        <asp:TextBox ID="txtNSDCCourseid" runat="server" Text='<%#DataBinder.Eval(
                            Container. DataItem,"NSDCCourseid") %>' CssClass="text input-txt" ></asp:TextBox>       
    </EditItemTemplate>
    <ItemTemplate >
        <asp:Label ID="lblNSDCCourseid" runat="server" Text='<%#DataBinder.Eval(
                              Container. DataItem,"NSDCCourseid") %>'></asp:Label>
    </ItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtAddNSDCCourseid" runat="server" CssClass="text input-txt"></asp:TextBox>       
    </FooterTemplate>
    </asp:TemplateField>
 
    
    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="150px">
<EditItemTemplate>
    <asp:LinkButton ID="lbtnUpdate" CommandName="Update" runat="server" OnClientClick='javascript:return ValidateGrid(this);'  >
                                              Update</asp:LinkButton>/
    <asp:LinkButton ID="lbtnCancel"  CommandName="Cancel" runat="server">
                                              Cancel</asp:LinkButton>
</EditItemTemplate>
<ItemTemplate>
    <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" >
                                               Edit</asp:LinkButton>/
    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" OnClientClick='javascript:return confirm("Do you want to delete this course details?");'>
                                                Delete</asp:LinkButton>
</ItemTemplate>        
<FooterTemplate>
    <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" OnClientClick="return validation();">
                                                   Add</asp:LinkButton>
</FooterTemplate>
</asp:TemplateField>    
    
</Columns>
       <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
</asp:GridView></div>
<%--<i style="font-style: normal">You are viewing page 
        <%=grdcourse.PageIndex + 1%> of  <%=grdcourse.PageCount%>
        </i>--%>
<div align="center" style="padding:0px 0px 15px 0px;">
           <asp:LinkButton ID="btn_excel" onclick="btn_excel_Click" 
      runat="server" CssClass="download-btn">Download as Excel </asp:LinkButton>
          </div>

 
 </div>
</asp:Content>