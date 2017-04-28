<%@ Page Language="C#" MasterPageFile="~/ImageTraining_2/Onlinestudents2/icreativeaui/1imagemasterpage.master" AutoEventWireup="true" CodeFile="InvoiceMenu_info.aspx.cs" Inherits="superadmin_InvoiceMenu_info" Title="Invoice Menu Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




<h4>Invoice Details</h4>

<div class="free-forms">

 <table class="common" cellpadding="0" cellspacing="0" width="70%" > 
     <tr class="no-borders">
         <td colspan="3">
      <asp:Label ID="lbl_errormsg" runat="server" ForeColor="DarkRed"></asp:Label></td>
     </tr>
            
         
            
            <tr class="no-borders">
                <td colspan="3" style="text-align:center;" align="center" valign="middle">
                   <asp:GridView ID="Gridview_info" runat="server" CssClass="common" OnRowDataBound="gridviewinfo_bound" OnRowCommand="gridviewinfo_command" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" EmptyDataText="No records Found" PageSize="20" Width="100%">
            <Columns>
                
                 <asp:BoundField DataField="studentid" HeaderText="Student ID" />
                 <asp:BoundField DataField="studentname" HeaderText="Student Name" />
                 <asp:BoundField DataField="coursename" HeaderText="Course" />
              
               <asp:TemplateField HeaderText="Invoice Details">
               
                    <ItemTemplate>
                    <asp:HiddenField runat="server"  ID="hdnstudentid" Value='<%#Eval("studentid")%>'/>
                     <asp:HiddenField runat="server"  ID="hdncentrecode" Value='<%#Eval("centrecode")%>'/>                         
                     <asp:LinkButton ID="LinkButton1" CommandName="Inv"  runat="server" Visible="false"></asp:LinkButton>    
                     <asp:LinkButton ID="LinkButton2" CommandName="Inv" runat="server" Visible="false"></asp:LinkButton>    
                     <asp:LinkButton ID="LinkButton3" CommandName="Inv"  runat="server" Visible="false"></asp:LinkButton>
                     <asp:LinkButton ID="LinkButton4" CommandName="Inv"  runat="server" Visible="false"></asp:LinkButton>    
                     <asp:LinkButton ID="LinkButton5" CommandName="Inv" CommandArgument='17' runat="server" Visible="false">View Invoice</asp:LinkButton>                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
               <ItemTemplate>
               <asp:LinkButton runat="server" ID="lnk" CommandName="del" CommandArgument='<%#Eval("id")%>' OnClientClick="javascript:return confirm('Are u want to remove this Student Detail?');">Delete</asp:LinkButton>
               </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
                   </td>
                    
            </tr>
        </table>

</div>

</asp:Content>

