<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="BatchedAlert.aspx.cs" Inherits="Onlinestudents2_superadmin_BatchedAlert" Title="Exam Approval Alert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="common">
        <tr>
            <td colspan="2" style=" padding:0px;"><h4>
    Exam Approval Details</h4>
            </td>
        </tr>
        <tr>
    <td >
        <asp:Label ID="Label1" runat="server" Text="Searchby Course Name"></asp:Label></td>
            <td >
        <asp:Label ID="Label2" runat="server" Text="Searchby Module Name"></asp:Label></td>
        </tr>
        <tr>
        <td >
        <asp:DropDownList ID="ddlsearchcourse" runat="server">
        </asp:DropDownList></td>
            <td >
                <asp:DropDownList ID="ddlsearchmodname" runat="server">
        </asp:DropDownList><asp:Button ID="btn_search" runat="server"  CssClass="search" OnClick="btn_search_Click" /></td>
            </tr><tr>
                <td colspan="2" style="text-align: center">
                
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label>
                <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="2">
    <div style="height:350px;overflow:auto;">
    <asp:GridView ID="GridView1" CssClass="common" AllowPaging="True" EmptyDataText="No Records Found" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="100">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkstd" runat="server" />
                    <asp:Label ID="lblstdId" runat="server" Visible="false" Text='<%#Eval("Student ID") %>'></asp:Label>
                    <asp:Label ID="lblName" runat="server" Visible="false" Text='<%#Eval("Student Name") %>'></asp:Label>
                    <asp:Label ID="lblCourse" runat="server" Visible="false" Text='<%#Eval("Course") %>'></asp:Label>
                    <asp:Label ID="lblCurrmod" runat="server" Visible="false" Text='<%#Eval("Current Module") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Student ID" HeaderText="Student ID" />
            <asp:BoundField DataField="Student Name" HeaderText="Student Name" />
            <asp:BoundField DataField="Course" HeaderText="Course" />
            <asp:BoundField DataField="Current Module" HeaderText="Current Module" />
<asp:BoundField DataField="Exam Date" HeaderText="Exam Date" />
        </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>
    </div>
        </td>
    </tr>
    
    <tr>
        <td align="center" colspan="2" style="height: 26px" valign="middle">
            <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;<asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="submit" OnClick="btnApprove_Click" /><br />
        </td>
    </tr>
    </table>
</asp:Content>

