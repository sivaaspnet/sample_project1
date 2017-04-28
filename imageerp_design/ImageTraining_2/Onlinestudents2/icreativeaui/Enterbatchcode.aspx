<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Enterbatchcode.aspx.cs" Inherits="superadmin_Enterbatchcode" Title="View Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

function batchcode()
{
   if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="";
              document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please select batch code!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.backgroundColor="#e8ebd9";
             //alert("Please select batch code");
             return false;
         }  
}



</script>

<table class="common"  > 
            <tr>
                <td colspan="3" style="padding:0px;" ><h4>
                    To view batched student details</h4>
                </td>
            </tr>
    <tr>
        <td colspan="3" style=" text-align:center;">
      <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label></td>
    </tr>
            <tr>
                <td >
                    Select Batch code</td>
                <td  colspan="2">
                    <asp:DropDownList ID="ddl_batchcode" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:center;">
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="submit" OnClientClick="javascript:return batchcode();"/>
                    &nbsp;
                    <input id="Reset2" type="reset" value="Reset" class="submit" />&nbsp;
                </td>  
            </tr>
        </table>


</asp:Content>

