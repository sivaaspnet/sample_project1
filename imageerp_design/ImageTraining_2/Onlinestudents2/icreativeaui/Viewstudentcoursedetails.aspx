<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewstudentcoursedetails.aspx.cs" Inherits="superadmin_Viewstudentcoursedetails" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Student Course details</title>
<link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
</head>
<body>
<div class="white-cont2">
  <form id="form1" runat="server">
    <h4 class="cont-title4 no-mrg">Students Course Details</h4>
    <div class="form-cont" style="padding:12px;">
      <ul>
        <li>
          <label class="label-txt">Program</label>
          <asp:Label ID="lblcourse_program" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt">Course Name</label>
          <asp:Label ID="lblcourse_name" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt"> Track</label>
          <asp:Label ID="lblcourse_track" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    <h4 class="cont-title4 no-mrg">Student Fee Details </h4>
    <div class="form-cont" style="padding:12px;">
      <ul>
        <li>
          <label class="label-txt"> Payment Pattern&nbsp;</label>
          <asp:Label ID="lblfee_mode" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt"> No of Installments</label>
          <asp:Label ID="lblfee_installment" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt"> Course Fee</label>
          <asp:Label ID="lblfee_amount" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt"> Tax</label>
          <asp:Label ID="lblfee_tax" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li class="no-mrg">
          <label class="label-txt"> Total Amount</label>
          <asp:Label ID="lblfee_Total" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
  </form>
</div>
</body>
</html>
