<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Onlinestudents2_superadmin_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>

<body>
<form id="Form1" method="post" runat="server">
    &nbsp;&nbsp;
    <table>
        <tr>
            <td style="width: 100px; height: 25px">
                studentID</td>
            <td style="width: 100px; height: 25px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            <td style="width: 100px; height: 25px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="studentid" HeaderText="StudentID" />
                        <asp:BoundField DataField="receipt" HeaderText="ReceiptNo" />
                        <asp:BoundField DataField="date" HeaderText="ReceiptDate" />
                        <asp:BoundField DataField="paidamount" HeaderText="Paid Amount" />
                        <asp:BoundField DataField="total" HeaderText="Total Amount Paid" />
                        <asp:BoundField DataField="pending" HeaderText="Pending Amount" />
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</form>
</body> 
</html>
