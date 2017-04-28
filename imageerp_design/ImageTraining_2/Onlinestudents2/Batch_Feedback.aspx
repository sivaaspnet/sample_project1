<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/Mainmasterpage.master" AutoEventWireup="true" CodeFile="Batch_Feedback.aspx.cs" Inherits="superadmin_Enterbatchcode" Title="View Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

function batchcode()
{
   if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.backgroundColor="#e8ebd9";
             alert("Please select batch code");
             return false;
         }  
}



</script>

<table class="common"   > 
            <tr>
                <td colspan="3" style="padding:0px"><h4>
                    To view batch details</h4>
                </td>
            </tr>
    <tr>
        <td colspan="3" style="padding-right: 0px; text-align:center; padding-left: 0px; padding-bottom: 0px;
            padding-top: 0px">
      <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label></td>
    </tr>
            <tr>
                <td colspan="3">
                    Select Batch code&nbsp;</td>
            </tr>
    <tr>
        <td colspan="3">
                    <asp:DropDownList ID="ddl_batchcode" runat="server">
                    </asp:DropDownList></td>
    </tr>
            <tr>
                <td  style="text-align:center;" colspan="3">
                    
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="submit" OnClientClick="javascript:return batchcode();"/>
                    <input id="Reset2" type="reset" value="Reset" class="submit" />
                </td>  
            </tr>
        </table>


</asp:Content>

