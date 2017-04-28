<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ExamDetails.aspx.cs" Inherits="Onlinestudents2_superadmin_ExamDetails" Title="Exam Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h4>
    Exam Indent Details</h4>
    <table class="common"><tr>
    <td style="height: 40px;text-align:left">
        <asp:Label ID="Label3" runat="server" Text="Searchby Exam Status"></asp:Label>&nbsp;<asp:DropDownList ID="ddlexamstatus" runat="server">
            <asp:ListItem>Registered</asp:ListItem>
            <asp:ListItem>Completed</asp:ListItem>
            <asp:ListItem>Reexam</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Searchby Course Name"></asp:Label>&nbsp;
        <asp:DropDownList ID="ddlsearchcourse" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
            </tr>
        <tr>
            <td style="height: 40px; text-align: left">
        <asp:Label ID="Label2" runat="server" Text="Searchby Module Name"></asp:Label>&nbsp;<asp:DropDownList ID="ddlsearchmodname" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="submit" OnClick="btn_search_Click" /></td>
        </tr>
        <tr><td style="text-align:center">
                
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label>
                <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label></td>
    </tr>
    <tr>
    <td>
    <div style="height:350px;overflow:auto;">
    <asp:GridView ID="GridView1" CssClass="common" AllowPaging="True" Visible="false" EmptyDataText="No Records Found" runat="server" OnRowCommand="GridView1_RowCommand" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging">
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>
        <asp:GridView ID="GridView2" CssClass="common" AllowPaging="True" Visible="false" EmptyDataText="No Records Found" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" PageSize="100000">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkstd" runat="server" />
                    <asp:Label ID="lblstdId" runat="server" Visible="false" Text='<%#Eval("Student ID") %>'></asp:Label>
                    <asp:Label ID="lblName" runat="server" Visible="false" Text='<%#Eval("Student Name") %>'></asp:Label>
<%--                    <asp:Label ID="lblCourse" runat="server" Visible="false" Text='<%#Eval("Course") %>'></asp:Label>
--%>                    <asp:Label ID="lblCurrmod" runat="server" Visible="false" Text='<%#Eval("Current Module") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Student ID" HeaderText="Student ID" />
            <asp:BoundField DataField="Student Name" HeaderText="Student Name" />
            <asp:BoundField DataField="Current Module" HeaderText="Current Module" />
            <asp:BoundField DataField="Exam Date" HeaderText="Exam Date" />
            <asp:BoundField DataField="Registered Date" HeaderText="Registered Date" />
            <asp:BoundField DataField="Completed Date" HeaderText="Completed Date" />
            <asp:BoundField DataField="marks" HeaderText="marks" />
        </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>

    </div>
    </td>
    </tr>
    
    <tr>
    <td style="height: 26px" align="center" valign="middle">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;<asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="submit" Visible="false" OnClick="btnApprove_Click" /></td>
    </tr>
    </table>
</asp:Content>

