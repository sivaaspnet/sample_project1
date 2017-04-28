<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="LabDetails.aspx.cs" Inherits="superadmin_LabDetails" Title="Lab Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button3_onclick() {
document.getElementById("ContentPlaceHolder1_ddllab").value = "";
document.getElementById("ContentPlaceHolder1_ddlslot").value = "";
}

// ]]>
function valbatch()
{
if(document.getElementById("ContentPlaceHolder1_ddllab").value == "")
{
alert("Please select the lab name")
document.getElementById("ContentPlaceHolder1_ddllab").focus();
return false;
}
else if(document.getElementById("ContentPlaceHolder1_ddlslot").value == "")
{
alert("Please select the slot name")
document.getElementById("ContentPlaceHolder1_ddlslot").focus();
return false;
}
else
{
return true;
}
}
</script>

 <table class="common" >
     <tr>
         <td colspan="2" style="padding:0px;">
             <h4>
                 &nbsp;View students in the batch <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" CssClass="back" /></h4>
         </td>
     </tr>
     <tr>
         <td colspan="2" style="text-align:center;">
                    <asp:Label ID="lblErrMsg" runat="server" CssClass="error"></asp:Label></td>
     </tr>
     <tr>
         <td colspan="2">
             <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
                 <Columns>
                     <asp:TemplateField HeaderText="Lab Name">
                     <ItemTemplate>
                     <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("LabName").ToString()) %>
                     </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="System" HeaderText="Total System" />
                     <asp:BoundField DataField="7amto9am" HeaderText="7amto9am" />
                     <asp:BoundField DataField="9amto11am" HeaderText="9amto11am" />
                     <asp:BoundField DataField="11amto1pm" HeaderText="11amto1pm" />
                     <asp:BoundField DataField="1pmto3pm" HeaderText="1pmto3pm" />
                     <asp:BoundField DataField="3pmto5pm" HeaderText="3pmto5pm" />
                     <asp:BoundField DataField="5pmto7pm" HeaderText="5pmto7pm" />
                     <asp:BoundField DataField="7pmto9pm" HeaderText="7pmto9pm" />
                 </Columns>
                 <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
             </asp:GridView>
         </td>
     </tr>
     <tr>
         <td align="center" colspan="2" valign="middle" style="text-align:center;">
             &nbsp;<asp:GridView ID="GridView2" runat="server" Visible="False" AutoGenerateColumns="False">
                 <Columns>
                     <asp:TemplateField HeaderText="Batch Code">
                     
                     <ItemTemplate>
                     <a href="Viewbatch.aspx?batchcode=<%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Code").ToString()) %>&LabName=<%#Eval("LabName") %>"><%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Code").ToString()) %></a>
                     </ItemTemplate>
                     
                     </asp:TemplateField>
                     <asp:BoundField HeaderText="Track" DataField="Batch_Track" />
                     <asp:BoundField HeaderText="Module" DataField="Batch_Module_Content" />
                     <asp:BoundField HeaderText="Start Date" DataField="Batch_Startdate" />
                     <asp:BoundField HeaderText="End Date" DataField="Batch_Enddate" />
                 </Columns>
             </asp:GridView>
         </td>
     </tr>
     <tr>
         <td align="center" colspan="2" valign="middle">
         </td>
     </tr>
        </table>
    
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>



</asp:Content>

