<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="batchstudentdrop.aspx.cs" Inherits="superadmin_Viewbatch" Title="View Batch Details" %>
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
 <div class="free-forms">
 <table  class="common" width="100%" > 
     <tr>
         <td colspan="2" style=" padding:0px">
             <h4>
                 Batch Details <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" CssClass="back" /></h4>
         </td>
     </tr>
     <tr>
         <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
             padding-top: 0px; text-align:center;">
                    <asp:Label ID="lblErrMsg" runat="server" CssClass="error"></asp:Label></td>
     </tr>
     <tr 
class="no-borders">
         <td colspan="2" align="center" valign="middle">
        <table id="tblbatch" width="100%" CssClass="common" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
            visible="false" >
            <tr>
                <td colspan="3" rowspan="1" style="height: 25px">
                    &nbsp;Batch Code</td>
                <td colspan="1" rowspan="1" style=" height: 25px;">
                    <asp:Label ID="txt_Batchcode" runat="server" 
                         Width="101px" Font-Bold="True" ForeColor="Maroon" Visible="False" ></asp:Label>
                    <asp:Label ID="LinkButton1" runat="server" CssClass="error" OnClick="LinkButton1_Click"></asp:Label><br />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                <td colspan="1" rowspan="1" style="height: 25px">
                    &nbsp;Batch Time</td>
                <td colspan="1" rowspan="1" style="height: 25px">
                    <asp:Label ID="txt_BatchTime" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="3" style="height: 41px" >
                    &nbsp;Module Name</td>
                <td colspan="1" rowspan="3" style="height: 41px;">
                    <asp:Label ID="txt_Module" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1" rowspan="3" style="height: 41px">
                    &nbsp;Batch Slot</td>
                <td colspan="1" rowspan="3" style="height: 41px" >
                    <asp:Label ID="txt_BatchSlot" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="height: 25px">
                    &nbsp;Faculty Name</td>
                <td colspan="1" rowspan="1" style="height: 25px;">
                    <asp:Label ID="txt_Faculty" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1" rowspan="1" style="height: 25px">
                    &nbsp;Lab Name</td>
                <td colspan="1" rowspan="1" style="height: 25px">
                    <asp:Label ID="txt_Lab" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="height: 26px">
                    &nbsp;Batch Start Date</td>
                <td colspan="1" rowspan="1" style="height: 26px;">
                    <asp:Label ID="txt_Bstart" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1" rowspan="1" style="height: 26px">
                    &nbsp;Batch End Date</td>
                <td colspan="1" rowspan="1" style="height: 26px">
                    <asp:Label ID="txt_Bend" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="height: 26px">
                    Software(s)</td>
                <td colspan="3" rowspan="1" style="height: 26px">
                    <asp:Label ID="lblsoft" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"></asp:Label></td>
            </tr>
        </table>


         
       <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" EmptyDataText="No Results Found" OnPageIndexChanging="GridView1_PageIndexChanging" align="center" width="100%">
                <Columns>
                
                    <asp:BoundField DataField="studentid" HeaderText="Student Id" />
                    <asp:BoundField DataField="enq_personal_name" HeaderText="Student name" />
                    <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a rel="modal" href="dropalert.aspx?studentid=<%#Eval("studentid")%>&batchcode=<%#Eval("batchcode")%>&iframe=true&amp;width=500&amp;height=140" class="error">Break</a>   
                                 </ItemTemplate>
            </asp:TemplateField>
                  
                                
                   
                </Columns>
            </asp:GridView>
         </td>
     </tr>
        </table>
    </div>
   



</asp:Content>

