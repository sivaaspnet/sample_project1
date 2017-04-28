<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Viewbookrequest.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Viewbookrequest" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tab1" runat="server" class="common" language="javascript" onclick="return TABLE1_onclick()">
        <tr>
            <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px; height: 29px">
                <h4>
                    View BookRequest</h4>
            </td>
        </tr>
       <tr>
       <td>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record">
               <Columns>
                   <asp:BoundField DataField="studentid" HeaderText="StudentId" />
                   <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                   <asp:BoundField DataField="program" HeaderText="Course" />
                   <asp:BoundField DataField="bookname" HeaderText="Books" />
                   <asp:BoundField DataField="requested_date" HeaderText="Requested Date" />
                   <asp:BoundField DataField="status" HeaderText="Status" />
                  
               </Columns>
                                <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
           </asp:GridView>
       </td>
       </tr>
    </table>
</asp:Content>

