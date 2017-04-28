<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Followupview.aspx.cs" Inherits="superadmin_Followupview" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Follow Up View</title>
<link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
<link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
<script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
<script language="javascript" type="text/javascript">
    function btnclose_onclick() 
    {
       javascript:window.close();
    }

    function btnprint_onclick() 
   {
      javascript:window.print();
   }

</script>
</head>
<body>
<div class="white-cont2">
<form id="form1" runat="server">
  <h4 class="cont-title4 no-mrg">Followup Details</h4>
  <div><asp:Label ID="lblmsg" CssClass="error" runat="server" Text=""></asp:Label></div>
  <div class="dataGrid" style="padding:10px;">
    <asp:GridView ID="GridView1" Visible="False" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
      <Columns>
      <asp:TemplateField HeaderText="Enquiry Number">
        <ItemTemplate> <%#Eval("enq_number")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Date">
        <ItemTemplate> <%#Eval("dateins")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Decision Status">
        <ItemTemplate> <%#Eval("Decision")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate> <%#Eval("remark")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Reminder Date">
        <ItemTemplate> <%#Eval("reminderdate")%> </ItemTemplate>
      </asp:TemplateField>
      </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="grdTele" Visible="False" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Records Found"  AllowPaging="True" OnPageIndexChanging="grdTele_PageIndexChanging" OnRowCommand="grdTele_RowCommand">
      <Columns>
      <asp:TemplateField HeaderText="Centre Code">
        <ItemTemplate> <%#Eval("centre_code")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Student Name">
        <ItemTemplate> <%#Eval("name")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Date">
        <ItemTemplate> <%#Eval("dateins")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Decision Status">
        <ItemTemplate> <%#Eval("Decision")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate> <%#Eval("remark")%> </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Reminder Date">
        <ItemTemplate> <%#Eval("reminderdate")%> </ItemTemplate>
      </asp:TemplateField>
      </Columns>
    </asp:GridView>
    <div style="padding:10px 0px;" align="center">
      <asp:LinkButton ID="LnkDownlaodExcel" runat="server" OnClick="LnkDownlaodExcel_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
    </div>
    <div style="display:none;">
      <asp:GridView ID="GvExport" runat="server" CssClass="common" EmptyDataText="No Records Found" >
        <EmptyDataRowStyle ForeColor="Red" />
      </asp:GridView>
    </div>
  </div>
</form>
</div>
</body>
</html>
