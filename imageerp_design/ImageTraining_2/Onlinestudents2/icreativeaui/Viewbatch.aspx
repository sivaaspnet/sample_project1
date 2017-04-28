<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Viewbatch.aspx.cs" Inherits="superadmin_Viewbatch" Title="View Batch Details" %>
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
                 Batch Details &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; 
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" CssClass="btnStyle1" /></h4>
         </td>
     </tr>
     <tr>
         <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
             padding-top: 0px; text-align:center;">
                    <asp:Label ID="lblErrMsg" runat="server" CssClass="error"></asp:Label></td>
     </tr>
     <tr>
         <td colspan="2" align="center" valign="middle">
		 <div class="free-forms">
        <table id="tblbatch" CssClass="common"  runat="server"  border="0" cellpadding="0" cellspacing="0"
            visible="false" >
            <tr>
                <td colspan="1" rowspan="1">
                    &nbsp;Batch Code</td>
                <td colspan="1" rowspan="1" style="width: 124px;">
                    <asp:Label ID="txt_Batchcode" runat="server" 
                         Width="244px" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1" rowspan="1">
                    &nbsp;Batch Time</td>
                <td colspan="1" rowspan="1">
                    <asp:Label ID="txt_BatchTime" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" >
                    &nbsp;Module Name</td>
                <td colspan="1" style="width: 124px;">
                    <asp:Label ID="txt_Module" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1">
                    &nbsp;Batch Slot</td>
                <td colspan="1" >
                    <asp:Label ID="txt_BatchSlot" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1">
                    &nbsp;Faculty Name</td>
                <td colspan="1" style="width: 124px">
                    <asp:Label ID="txt_Faculty" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1">
                    &nbsp;Lab Name</td>
                <td colspan="1">
                    <asp:Label ID="txt_Lab" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" rowspan="1" style="height: 26px">
                    &nbsp;Batch Start Date</td>
                <td colspan="1" rowspan="1" style="height: 26px; width: 124px;">
                    <asp:Label ID="txt_Bstart" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                <td colspan="1" rowspan="1" style="height: 26px">
                    &nbsp;Batch End Date</td>
                <td colspan="1" rowspan="1" style="height: 26px">
                    <asp:Label ID="txt_Bend" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="height: 26px">
                    &nbsp;</td>
                <td colspan="1" style="height: 26px; width: 124px;">
                    &nbsp;</td>
                <td colspan="1" style="height: 26px">
                    <span class="file">&nbsp;Batch Slot</td>
                <td colspan="1" style="height: 26px">
                    <span class="file">
                    <asp:Label ID="txt_BatchSlot0" runat="server" Font-Bold="True" 
                        ForeColor="Maroon" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" rowspan="1" style="height: 26px">
                    &nbsp;Software(s)</td>
                <td colspan="3" rowspan="1" style="height: 26px">
                    <asp:Label ID="lblsoft" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"></asp:Label>
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
</div>

       <div style="padding:10px">
       <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" EmptyDataText="No Results Found" OnPageIndexChanging="GridView1_PageIndexChanging" width="100%">
                <Columns>
                
                     <asp:TemplateField HeaderText="Student ID">
                    
                    <ItemTemplate>
                    
                    <a href="Viewattendance.aspx?batchcode=<%#Eval("BatchCode") %>"> <%#Eval("studentid") %>  </a>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                   <asp:BoundField DataField="enq_personal_name" HeaderText="Student name" />
                    <asp:BoundField DataField="remarks" HeaderText="Student Remarks" HtmlEncode="false" />
                  
                                
                   
                </Columns>
            </asp:GridView>
			</div>  
         </td>
     </tr>
     <tr>
         <td align="center" colspan="2" valign="middle" style=" padding:0px">
         <h4>Batch Remarksp:GridView>
			</div>  
         </td>
     </tr>
     <tr>
         <td align="center" colspan="2" valign="middle" style=" padding:0px">
         <h4>Batch Remarks</h4>
         </td>
     </tr>
     <tr>
         <td >
			 <div style="padding:10px">
             <asp:GridView CssClass="common"  ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="No Remarks Found" width="100%">
                 <EmptyDataRowStyle Font-Bold="True" ForeColor="Maroon" />
                 <Columns>
                     <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                     <asp:BoundField DataField="editdate" HeaderText="Edited Date" />
                 </Columns>
             </asp:GridView>
			 <br />
       </div>
             <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="No Remarks Found"
                 Visible="False"></asp:Label></td>
     </tr>
        </table>
    </div>
 



</asp:Content>

