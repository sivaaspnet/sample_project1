<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="NonBatchedAlert.aspx.cs" Inherits="Onlinestudents2_superadmin_NonBatchedAlert" Title="Non Batched Student Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="common" width="600px">
        <tr>
            <td  style="padding:0px;">
            <h4>
        Non Batched Student Details</h4>
    
            </td>
        </tr>
        <tr>
    <td style=" text-align:left">
       
        <asp:Label ID="Label1" runat="server" Text="Searchby Course Name"></asp:Label> &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="ddlsearchcourse" runat="server">
        </asp:DropDownList>&nbsp;
        <asp:Button ID="btn_search" runat="server"  CssClass="search" OnClick="btn_search_Click" />
        </td>
            </tr><tr><td style="text-align:center">
                
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label>
                <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label></td>
    </tr></table>
    <br />
    <div style="height:350px;overflow:auto;">
    <asp:GridView ID="GridView1" CssClass="common" AllowPaging="True" EmptyDataText="No Records Found" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="1000" >
        <Columns>
            <asp:BoundField DataField="Student ID" HeaderText="Student ID" />
            <asp:BoundField DataField="Student Name" HeaderText="Student Name" />
            <asp:BoundField DataField="Track" HeaderText="Track" />
            <asp:BoundField DataField="Course" HeaderText="Course" />
            <asp:BoundField DataField="Waiting For" HeaderText="Waiting Module" />
        </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>
    </div>
    <br />
    <br />
    <br />
</asp:Content>

