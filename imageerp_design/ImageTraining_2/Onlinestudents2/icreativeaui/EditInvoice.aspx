<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditInvoice.aspx.cs" Inherits="Onlinestudents2_superadmin_EditInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="600">
            <tr>
                <td colspan="3" rowspan="3">
                    Student ID</td>
                <td colspan="1" rowspan="3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="3" rowspan="1">
                    Instalment No</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="4" rowspan="1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Instalment" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
