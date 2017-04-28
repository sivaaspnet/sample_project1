<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="drop.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReport" Title="Student Report" %>
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

</script>
    <br />
    <table class="common" id="Table2" >
        <tr>
            <td align="center" bgcolor="#666666" colspan="2" valign="middle" style=" text-align:center; height: 47px; padding:0pc;">
                  <p></p>
                  <h4>
                      Drop Student &nbsp;</h4>
                  </td>
        </tr>
        <tr>
            <td align="center" style="text-align:center;">
                <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="height: 32px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="StudentID : "></asp:Label>
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return Validate();"  CssClass="submit" OnClick="Button1_Click" Text="Submit" /></td>
        </tr>
        <tr>
            <td align="left" style="height: 32px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div style=" max-height:400px; overflow:auto;">      &nbsp;</div>

</asp:Content>

