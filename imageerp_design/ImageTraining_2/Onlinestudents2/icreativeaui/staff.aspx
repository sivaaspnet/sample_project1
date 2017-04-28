<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="staff.aspx.cs" Inherits="Onlinestudents2_superadmin_staff" Title="StaffReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript">
 function Validate()
 {
 if((document.getElementById("ContentPlaceHolder1_DropDownList1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_DropDownList1").value=="";   
             document.getElementById("ContentPlaceHolder1_DropDownList1").focus();
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if((document.getElementById("ContentPlaceHolder1_DropDownList2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_DropDownList2").value=="";   
             document.getElementById("ContentPlaceHolder1_DropDownList2").focus();
             document.getElementById("ContentPlaceHolder1_DropDownList2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DropDownList2").style.backgroundColor="#e8ebd9";
             return false;
         }
    
      else if((document.getElementById("ContentPlaceHolder1_DropDownList3").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_DropDownList3").value=="";
            document.getElementById("ContentPlaceHolder1_DropDownList3").focus();
             document.getElementById("ContentPlaceHolder1_DropDownList3").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DropDownList3").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         }
 </script>
    <div>
        &nbsp;&nbsp;
        <br />
        <br />
        <table style="width: 39%" class="common">
            <tr align="center">
                <td colspan="4" style="padding:0px;">
                <h4>Staff Report</h4>
                </td>
            </tr>
            <tr align="center">
                <td style="width: 20px; height: 66px">
        <asp:DropDownList ID="DropDownList1" runat="server">
  <asp:ListItem Value="">-Select-</asp:ListItem>
 <asp:ListItem  Value="01">Jan</asp:ListItem>
 <asp:ListItem Value="02">Feb</asp:ListItem>
 <asp:ListItem Value="03">Mar</asp:ListItem>
 <asp:ListItem Value="04">Apr</asp:ListItem>
 <asp:ListItem Value="05">May</asp:ListItem>
 <asp:ListItem Value="06">Jun</asp:ListItem>
 <asp:ListItem Value="07">Jul</asp:ListItem>
 <asp:ListItem Value="08">Aug</asp:ListItem>
 <asp:ListItem Value="09">Sep</asp:ListItem>
 <asp:ListItem Value="10">Oct</asp:ListItem>
 <asp:ListItem Value="11">Nov</asp:ListItem>
 <asp:ListItem Value="12">Dec</asp:ListItem>
        </asp:DropDownList><asp:Label ID="lbl_month" runat="server" Visible="False"></asp:Label><asp:Label ID="lbl_year" runat="server" Visible="False"></asp:Label></td>
                <td style="width: 24px; height: 66px">
        <asp:DropDownList ID="DropDownList2" runat="server">
          
        </asp:DropDownList></td>
                <td style="width: 24px; height: 66px">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList></td>
                <td style="height: 66px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="javascript:return Validate();;" Text="Submit" CssClass="submit" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 66px; text-align:center;"   >
        <asp:Label ID="lbl_grid" runat="server"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
        </div>
  
</asp:Content>

