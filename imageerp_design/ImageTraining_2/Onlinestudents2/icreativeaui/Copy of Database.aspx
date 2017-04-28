<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Database.aspx.cs" Inherits="Onlinestudents2_superadmin_Database" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Height="142px" TextMode="MultiLine" Width="1010px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Select" Width="474px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insert/Update"
            Width="468px" /><br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label><br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
