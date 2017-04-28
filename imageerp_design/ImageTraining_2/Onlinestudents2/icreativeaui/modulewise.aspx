<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="modulewise.aspx.cs" Inherits="superadmin_modulewise" Title="Create Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="950px"> 
        <tr>
        <td style="height: 55px">
        Search by
        </td>
        <td style="height: 55px">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="Module" Selected="True">Module</asp:ListItem>
            <asp:ListItem Value="Software">Software</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        </tr>
            <tr>
                <td style="width: 100px; height: 37px;">
                    <asp:Label ID="lbl_module" runat="server" Text="Module Name" Width="134px"></asp:Label></td>
                <td width="200">
                    <asp:DropDownList ID="ddl_module" runat="server">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Status" Width="64px"></asp:Label></td>
                <td style="width: 120px;">
                    <asp:DropDownList ID="ddl_status" runat="server">
                        <asp:ListItem Value="">All</asp:ListItem>
                        <asp:ListItem Value="pending">InProgress</asp:ListItem>
                        <asp:ListItem Value="completed">Completed</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td style="width: 100px; height: 37px;"><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btnStyle1" /></td>
            </tr>
            <tr id="count" runat="server" visible="false" >
                <td style="width: 100px; height: 43px;">
                    <asp:Label ID="Label3" runat="server" Text="Total Student Count" Width="193px"></asp:Label></td>
                <td style="width: 100px; height: 43px;">
                    <asp:Label ID="lbl_count" runat="server" Text="0" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label></td>
                <td style="width: 100px; height: 43px;">
                </td>
                <td style="width: 125px; height: 43px;">
                </td>
                <td style="width: 100px; height: 43px;">
                </td>
            </tr>
            <tr>
                <td colspan="5">
                
                <div style="overflow:auto; float:left; height:700px; " >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record" Width="650px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10">
                        <Columns>
                            <asp:BoundField DataField="studentid" HeaderText="StudentID" />
                            <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                            <asp:BoundField DataField="program" HeaderText="Course" />
                            <asp:BoundField DataField="status1" HeaderText="Status" HtmlEncode="False" />
                        </Columns>
                    </asp:GridView>
             </div>
             
             
           <div style="overflow:auto; float:left; height:500px; padding-left:30px;" >
                    <asp:GridView ID="GridView2" style="border:0px;" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" Width="250px"  >
                        <Columns>
                            <asp:BoundField DataField="software" HeaderText="SoftwareName" >
                                <HeaderStyle Font-Bold="True" />
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="totstudent" HeaderText="Total Student" >
                                <HeaderStyle Font-Bold="True" />
                                <ItemStyle Font-Bold="True" ForeColor="#C00000" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                 </div>
                </td>
            </tr>
        </table>
       
    </div>
</asp:Content>
