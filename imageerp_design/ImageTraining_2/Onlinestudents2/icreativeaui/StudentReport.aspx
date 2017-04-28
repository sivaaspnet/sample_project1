<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="StudentReport.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReport" Title="Student Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function Validate()
     {
  
         if(document.getElementById("ContentPlaceHolder1_txt_studentid").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_studentid").value=="";   
             document.getElementById("ContentPlaceHolder1_lbl_error").innerHTML ='*Please Enter the StudentID!';
             document.getElementById("ContentPlaceHolder1_txt_studentid").focus();
             document.getElementById("ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9";
             return false;
         }
        else
        {
        return true;
        }
       
        
  }

$(document).ready(function() {

    $("#ContentPlaceHolder1_txt_studentid").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txt_studentid").autocomplete('Handler4.ashx');
   // alert("check");  
    });  
</script>
<div class="free-forms">
  <h4>Student Report</h4>

    <table class="common" id="Table2" cellpadding="0" cellspacing="0" width="100%" >
 
        <tr>
            <td align="center" style="text-align: center; width: 70px;">
            </td>
            <td align="center" style="text-align:center; width: 121px;">
                <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            <td align="center" style="text-align: center; width: 69px;">
            </td>
        </tr>
        <tr>
            <td style="height: 31px" colspan="3" >
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="StudentID/Student Name : "></asp:Label>
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>                
                <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return Validate();"  CssClass="btnStyle1" OnClick="Button1_Click" Text="Submit" />
                <br />
                <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_studentid"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 70px; height: 23px;" >
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td style="width: 121px; height: 23px;" >
            </td>
            <td style="width: 69px; height: 23px;" >
            </td>
        </tr>
    </table>
	</div>
    <br />
    <br />
    <div style=" max-height:400px; overflow:auto;">      &nbsp;</div>

</asp:Content>

