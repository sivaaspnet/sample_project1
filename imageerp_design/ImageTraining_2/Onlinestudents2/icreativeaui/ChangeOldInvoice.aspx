<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeOldInvoice.aspx.cs" Inherits="Onlinestudents2_superadmin_ChangeOldInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="1000px">
            <tr>
                <td colspan="4" rowspan="3" style="height: 19px">
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    Student ID</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    Center Code</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="txtcencode" runat="server"></asp:TextBox>1.Alwarpet,2.Adyar,3.Annanagar,6.Velachery,4.Ganaganagar</td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    Change Student ID</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="txtchgstuid" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    Course Fees</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="txtCoursefees" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    No Of Installment</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    Update query</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="TextBox3" runat="server" Height="244px" TextMode="MultiLine" Width="837px"></asp:TextBox></td>
            </tr>
            <tr id="insamt" runat="server" visible="false">
                <td colspan="3" rowspan="1" style="width: 178px">
                    Installment Amount</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
            </tr>
            <tr id="instax" runat="server" visible="false">
                <td colspan="3" rowspan="1" style="width: 178px; height: 19px">
                    Installment Tax</td>
                <td colspan="1" rowspan="1" style="height: 19px">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
            </tr>
            <tr id="totinsamt" runat="server" visible="false">
                <td colspan="3" rowspan="1" style="width: 178px; height: 19px">
                    Total Installment Amount</td>
                <td colspan="1" rowspan="1" style="height: 19px">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="width: 178px">
                    Receipt No</td>
                <td colspan="1" rowspan="1">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" colspan="4" rowspan="1" valign="middle">
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Add Installment" />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="FillGrid" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update Query" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Receipt" /><asp:Button
                        ID="Button4" runat="server" Text="Change Old Student ID" OnClick="Button4_Click1" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Change New Student ID" />
                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Change New student Course Fees" />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" rowspan="1" valign="middle">
                </td>
            </tr>
        </table>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
