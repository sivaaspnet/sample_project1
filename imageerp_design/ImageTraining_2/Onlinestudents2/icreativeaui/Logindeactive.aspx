<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Logindeactive.aspx.cs" Inherits="superadmin_ViewEnquiry" Title="View Enquiry Page" EnableEventValidation = "false"  %>
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



	<h4>
        	<asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></h4>
    <div class="gridSort" style="margin-top:10px">
    </div>
    
    <div style="padding:0px 10px;">
    <table cellpadding="0" cellspacing="0" width="100%" >
    <tr><td>
		<div class="dataGrid">
        <asp:GridView ID="GridView1" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="UserName">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("centrelogin_id")%>' runat="server" />
                    
             <%#Eval("username")%>
                   
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <%#Eval("role")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ceter Code">
                <ItemTemplate>
                       <%#Eval("centre_code")%>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="centre useremail">
                <ItemTemplate>
                    <%#Eval("centre_useremail")%>
                    
                </ItemTemplate>
                </asp:TemplateField>
                  
                     <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%#Eval("status")%>
                    
                </ItemTemplate>
                </asp:TemplateField>
                  
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlfollowstatus" runat="server" CssClass="select">
                          <asp:ListItem Value="active">Active</asp:ListItem>
                          <asp:ListItem Value="deactive">Deactive</asp:ListItem>
                         
                        </asp:DropDownList>
                        <asp:Button ID="btnupd" runat="server"  CssClass="update" ToolTip="Update" OnClick="btnupd_Click"   />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
       </div>
       
        <p style="padding:10px 0px;">&nbsp;</p>
        
       <div style="display:none;">
        </div>
    </td></tr>
        </table>
     </div>   
 
    
    <div style="padding:0px 10px;" id="note" runat="server">

		</div>
		 
	</asp:Content>

