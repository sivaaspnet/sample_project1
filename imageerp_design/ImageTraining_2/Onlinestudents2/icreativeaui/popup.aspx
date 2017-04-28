<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popup.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>pop up</title>
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="common">
            <tr>
                <td style="width: 144px">
                    No Of student To Be Updated</td>
                <td style="width: 100px">
                    <asp:Label ID="lbl_count" runat="server" ForeColor="Blue"></asp:Label></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common"
                        Width="196px">
                        <Columns>
                            <asp:TemplateField HeaderText="Student ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("student_id") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HdnExpressSt" runat="server" Value='<%#Eval("ExpressEnrollSt")%>' />
                                    <asp:HiddenField ID="hdnEnqid" runat="server" Value='<%#Eval("enq_number")%>' />
                                    <asp:Label ID="lblStudId" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("enq_personal_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("enq_personal_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 144px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
