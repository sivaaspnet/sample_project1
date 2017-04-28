<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="staffreport.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;
        <br />
        <br />
        <table style="width: 39%" >
            <tr>
                <td style="width: 20px; height: 66px">
        <asp:DropDownList ID="DropDownList1" runat="server">
  <asp:ListItem>-Select-</asp:ListItem>
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
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 66px">
        <asp:Label ID="lbl_grid" runat="server"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
        </div>
    </form>
</body>
</html>
