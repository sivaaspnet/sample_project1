<%@ Page Language="C#" AutoEventWireup="true" CodeFile="batchrep.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_batchrep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BatchReport</title>
      <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style=" text-align:center;">
        <table class="common" style="width: 39%">
            <tr align="center">
                <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                    padding-top: 0px; height: 43px">
                    <h4>
                        Batch class report</h4>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 25px" >
                    <asp:Label ID="batchcode" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Batchcode:"></asp:Label>
                    <asp:Label ID="lbl_batch" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Module:"></asp:Label>
                    <asp:Label ID="lbl_module" runat="server"></asp:Label></td>
            </tr>
            <tr >
                <td colspan="4" align="center" style="text-align:center;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" Width="525px">
                        <Columns>
                            <asp:BoundField DataField="content" HeaderText="content" />
                            <asp:BoundField DataField="status" HeaderText="status" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
