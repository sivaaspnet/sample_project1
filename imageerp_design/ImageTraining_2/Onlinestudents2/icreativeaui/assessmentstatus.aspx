<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="assessmentstatus.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_assessmentstatus" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<div class="gridSort" style="height:40px">
<table width="50%">
<tr>
<td>
Select Centre
</td>
<td>
    <asp:DropDownList ID="v" runat="server">
    </asp:DropDownList>
</td>
<td>
    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btnStyle1" OnClick="Button1_Click" />
</td>
</tr>
</table>
    <br />
    <br />
    <br />
    <br />
</div>

    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Records Found" AutoGenerateColumns="False" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
            <asp:BoundField DataField="studentId" HeaderText="Student ID" />
            <asp:BoundField DataField="program" HeaderText="Program" />
            <asp:BoundField DataField="Module" HeaderText="Module" />
            <asp:BoundField DataField="batchCode" HeaderText="Batchcode" />
            <asp:BoundField DataField="centre_location" HeaderText="Centre Location" />
            <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
         <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>

</asp:Content>

