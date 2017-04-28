
<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/1imagemasterpage.master" AutoEventWireup="true" CodeFile="imageNSDC.aspx.cs" Inherits="imageNSDC" Title="NSDC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
      function fileupload_alert() {
          alert("Please select a file to upload");
      }
  </script>
     <h4>NSDC REGISTRATION</h4>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="NSDC.aspx" Font-Bold="True">NSDC</asp:HyperLink>
        <div class="dataGrid" style="padding:10px">
     <asp:GridView ID="gd_candidates" runat="server" CssClass="common" AlternatingRowStyle-CssClass="alt"  AutoGenerateColumns="false" 
        AllowPaging="true" EmptyDataText="No Records Found" PageSize="10" OnPageIndexChanging="OnPageIndexChanging" CellPadding="3" CellSpacing="1" OnRowDataBound="RowDataBound">
     
    <Columns>
    
        <asp:BoundField ItemStyle-Width="50px" DataField="studentId" HeaderText="Student ID"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="50px" DataField="enq_personal_name" HeaderText="Student Name">
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>        
         <asp:BoundField ItemStyle-Width="150px" DataField="coursename" HeaderText="Course Enrolled" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>    
          <asp:TemplateField HeaderText="NSDC" ItemStyle-Width="150px">
    <ItemTemplate>
    <asp:Label ID="lblcenter" runat="server" Text='<%#Eval("studentId") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
         </Columns>
         <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        </asp:GridView>
        </div>
        <i style="font-style: normal">You are viewing page
        <%=gd_candidates.PageIndex + 1%>of<%=gd_candidates.PageCount%>
        </i>
       
      <asp:HiddenField runat="server" ID="hf_centreID"/>
   </asp:Content>