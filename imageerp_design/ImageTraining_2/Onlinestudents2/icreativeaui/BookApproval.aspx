<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="BookApproval.aspx.cs" Inherits="Onlinestudents2_superadmin_BookApproval" Title="Book Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <table border="1" class="common" style="z-index: 100; left: 340px; top: 153px" width="400">
        <tr>
            <td colspan="2" style="text-align: center" valign="middle">
                <asp:Label ID="lblmsg" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
<%--        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 37px;">
                Student ID</td>
            <td style="width: 100px; height: 37px;">
                <asp:TextBox ID="txtstudentid" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px">
                Student Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtstudentname" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 29px;">
                Course Name</td>
            <td style="width: 100px; height: 29px;">
                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" Width="473px"></asp:TextBox></td>
        </tr>
        <tr id="bookvis" runat="server" visible="false">
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Books</td>
            <td style="width: 100px; height: 23px">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td align="center" class="w290 talignleft" colspan="2" style="height: 30px" valign="middle">
                <input id="Button1" class="submit" onclick="return Button1_onclick()" type="button"
                    value="Reset" />
                <asp:Button ID="Btnadd" runat="server" CssClass="submit" OnClick="Btnadd_Click" OnClientClick="javascript:return readCheckBoxList();"
                    Text="Add" />
            </td>
        </tr>--%>
        <tr>
            <td align="center" colspan="2" style="height: 30px" valign="middle">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="StudentId" HeaderText="Student ID" />
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                        <asp:BoundField DataField="SoftwareName" HeaderText="Software Name" />
                        <asp:BoundField Visible="False" DataField="Bookstatus" HeaderText="Book Status" />
                        <asp:TemplateField HeaderText="Book Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" Visible="false" runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                    <asp:ListItem Value="Process">Process</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblCourse" Visible="false" runat="server" Text='<%#Eval("Courseware_Id") %>'></asp:Label>
                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%#Eval("Courseware_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProcessDate" HeaderText="Process Date/Time " />
                        <asp:BoundField DataField="SentDate" HeaderText="Sent Date/Time" />
                        <asp:BoundField DataField="ReceivedDate" HeaderText="Received Date/Time" />
                        <asp:TemplateField HeaderText="Book Approval">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" CommandArgument='<%#Eval("Courseware_Id") %>'
                            CommandName="Book">Send</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" Visible="false" runat="server" CommandArgument='<%#Eval("Courseware_Id") %>'
                            CommandName="BookView">View</asp:LinkButton>
                                <asp:Label ID="lblApprove" Visible="false" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 30px" valign="middle">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="submit" OnClick="Button2_Click"
                    Text="Update Status" Visible="False" /></td>
        </tr>
    </table>
</asp:Content>

