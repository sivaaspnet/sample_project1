<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewFeedback.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_ViewFeedback" Title="View Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table class="common" id="getdetails"  runat="server" width="100%">
             <tr>
                 <td colspan="9" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                     padding-top: 0px">
                 <h4> Feedback Report</h4>
                 <h5> Overall Percentage : <asp:Label ID="lblPercent" runat="Server" /> %</h5>
                 </td>
             </tr>
<tr >
<td  align="center">
From Date
</td>
<td>
    <asp:TextBox ID="TextBox1" class="text datepicker" runat="server"></asp:TextBox>
</td>
<td align="left">

To Date
</td>
<td>
    <asp:TextBox ID="TextBox2"  class="text datepicker" runat="server"></asp:TextBox>


</td>
<td align="center">
Software
</td>
<td>
    <asp:DropDownList ID="ddl_software" runat="server" Width="103px">
    </asp:DropDownList>
    </td>
<td>
Trainer Name
</td>

<td>
    <asp:DropDownList ID="ddl_faculty" runat="server">
    </asp:DropDownList>
</td>
<td>
    <asp:Button ID="Button2" CssClass="btnStyle1" runat="server" Text="Sort" OnClick="Button2_Click" />

</td>
</tr>
</table>
<table class="common" width="100%">
<tr>
  <td>
    <asp:GridView  Width="100%" CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound"   >
                <Columns>
                    <asp:BoundField DataField="FacultyName" HeaderText="Trainer Name" />
                    <asp:BoundField DataField="Software_Name" HeaderText="Software Taught" />
                    <asp:BoundField DataField="timing" HeaderText="Batch Timing" /> 
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="student_id" HeaderText="Reg No" />   
                    <asp:TemplateField HeaderText="Overall Rating">
                     <ItemTemplate>
                       <a rel="modal" href="IndividualRating.aspx?stuid=<%#Eval("student_id")%>&batch=<%#Eval("batchcode")%>&iframe=true&amp;width=600&amp;height=325" class="error"><%#Eval("overall")%></a>
                    </ItemTemplate>
                   </asp:TemplateField>                             
                </Columns>
                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
            </asp:GridView>
            
            Excellent - 5&nbsp;&nbsp;&nbsp;&nbsp;   Good - 4&nbsp;&nbsp;&nbsp;&nbsp;   Average -3
      </td>
   </tr>                     
</table >
</asp:Content>

