<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Schedulebatchcode.aspx.cs" Inherits="superadmin_Schedulebatchcode" Title="Batch Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

function batchcode()
{
   if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML = '*Please select batch code!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.backgroundColor="#e8ebd9";
             //alert("Please select batch code");
             return false;
         }  
}



</script>

<table class="common"  > 
 <tr><td colspan="3" style="text-align:center">
      <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
            <tr>
                <td colspan="3" style=" padding:0px" ><h4>
                    Schedule batch </h4>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    Select Batch code<br />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:DropDownList ID="ddl_batchcode" runat="server">
                    </asp:DropDownList>&nbsp;</td>
            </tr>
            <tr>
                <td class="w290 talignleft" colspan="3">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="submit" OnClientClick="javascript:return batchcode();"/>
                    <input id="Reset2" type="reset" value="Reset" class="submit" />
                </td>  
            </tr>
        </table>


</asp:Content>

