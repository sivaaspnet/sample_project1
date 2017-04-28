<%@ Page Language="C#" AutoEventWireup="true" CodeFile="breakageupdate.aspx.cs" Inherits="Onlinestudents2_superadmin_breakageupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Breakage Receipt </title>
    <script type="text/javascript">
    function add(){
    
        if(document.getElementById("txt_studid").value=="")
         {
             document.getElementById("txt_studid").value=="";
             document.getElementById("txt_studid").focus();
             document.getElementById("txt_studid").style.border="#ff0000 1px solid";
             document.getElementById("txt_studid").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_recp_no").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_recp_no").focus();
             document.getElementById("txt_recp_no").style.border="#ff0000 1px solid";
             document.getElementById("txt_recp_no").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ddl_breakage").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("ddl_breakage").focus();
             document.getElementById("ddl_breakage").style.border="#ff0000 1px solid";
             document.getElementById("ddl_breakage").style.backgroundColor="#e8ebd9";
             return false;
         }
         }
         </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="3">
                    Student Breakage Receipt Update</td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="width: 172px">
                    <strong>Student_id</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_studid" runat="server"></asp:TextBox></td>
                <td style="width: 244px">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 172px">
                    <strong>Receipt_no</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_recp_no" runat="server"></asp:TextBox></td>
                <td style="width: 244px">
                </td>
            </tr>
            <tr>
                <td style="width: 172px">
                    <strong>Breakage amount</strong></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddl_breakage" runat="server" onChange="calctax(this)">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                        <asp:ListItem Value="1000">1000</asp:ListItem>
                        <asp:ListItem Value="1500">1500</asp:ListItem>
                        <asp:ListItem Value="2000">2000</asp:ListItem>
                        <asp:ListItem Value="2500">2500</asp:ListItem>
                        <asp:ListItem Value="3000">3000</asp:ListItem>
                        <asp:ListItem Value="3500">3500</asp:ListItem>
                        <asp:ListItem Value="4000">4000</asp:ListItem>
                        <asp:ListItem Value="4500">4500</asp:ListItem>
                        <asp:ListItem Value="5000">5000</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 244px">
                </td>
            </tr>
            <tr>
                <td style="width: 172px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                    <asp:Button ID="Button1" runat="server" Text="Update Query" OnClick="Button1_Click" OnClientClick="return add();" /></td>
                <td style="width: 244px; height: 23px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
