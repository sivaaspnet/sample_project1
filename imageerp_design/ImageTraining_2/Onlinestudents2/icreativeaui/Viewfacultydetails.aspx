<%@ Page Language="C#" MasterPageFile="~/OnlineStudents/imagemasterpage.master" AutoEventWireup="true" CodeFile="Viewfacultydetails.aspx.cs" Inherits="superadmin_Viewfacultydetails" Title="View Faculty Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}	
}     

</script>

<h4>View Faculty Details</h4>
    <table class="common"><tr>
    <td style="height: 40px;text-align:right">
       <asp:Label ID="Label1" runat="server" Text="Searchby Faculty Name"></asp:Label>
      
       <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text"></asp:TextBox>
        <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="submit" OnClick="btn_search_Click" />
        </td>
            </tr><tr><td style="text-align:center"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
    </tr></table>
    <br />
    
    
    <h4>Faculty Details</h4>
    <p>
    
        <asp:GridView ID="GridView1" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
            <PagerSettings Position="TopAndBottom" />
            <Columns>
                               
                <asp:TemplateField HeaderText="Faculty Name">
                <ItemTemplate>
                       <%#Eval("facultyname")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Shift Timing">
                <ItemTemplate>
                       <%#Eval("ShiftTiiming")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Specialisation">
                <ItemTemplate>
                       <%#Eval("Specialisation")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                  <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("faculty_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                        
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></p>
       <table width="1002" class="common"><tr><td style="color: #ff3366" colspan="2">Key:  </td></tr>
        <tr><td colspan="2"><img src="../layout/32.gif" alt="View" />-Click to View the Details</td></tr>
          </table> 
</asp:Content>

