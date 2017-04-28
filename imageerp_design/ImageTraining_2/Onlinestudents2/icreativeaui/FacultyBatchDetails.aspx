<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="FacultyBatchDetails.aspx.cs" Inherits="superadmin_FacultyBatchDetails" Title="Faculty Batch Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button3_onclick() {
document.getElementById("ctl00_ContentPlaceHolder1_ddllab").value = "";
document.getElementById("ctl00_ContentPlaceHolder1_ddlslot").value = "";
}

// ]]>
function valbatch()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_ddllab").value == "")
{
alert("Please select the lab name")
document.getElementById("ctl00_ContentPlaceHolder1_ddllab").focus();
return false;
}
else if(document.getElementById("ctl00_ContentPlaceHolder1_ddlslot").value == "")
{
alert("Please select the slot name")
document.getElementById("ctl00_ContentPlaceHolder1_ddlslot").focus();
return false;
}
else
{
return true;
}
}
</script>

 <table  class="common" >
     <tr>
         <td colspan="2" style="padding:0px">
             <h4>
                 View Faculty Batch Details<asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  ToolTip="Back" CssClass="back" Text="Back" /></h4>
         </td>
     </tr>
     <tr>
         <td align="center" colspan="2" valign="middle">
             <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
                 <Columns>
                     <asp:BoundField DataField="batch_code" HeaderText="Batch Code" />
                     <asp:BoundField DataField="batch_labname" HeaderText="Lab Name" />
                     <asp:BoundField DataField="batch_faculty" HeaderText="Faculty Name" />
                     <asp:BoundField DataField="Batch_slot" HeaderText="Batch Slot" />
                 </Columns>
                 <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
             </asp:GridView>
                    <asp:Label ID="lblErrMsg" runat="server" CssClass="error"></asp:Label>
         </td>
     </tr>
        </table>
    
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>



</asp:Content>

