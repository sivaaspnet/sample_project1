<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewfacultyqualificationdetails.aspx.cs" Inherits="superadmin_viewfacultyqualificationdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Faculty Qualification</title>
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
<script language="javascript" type="text/javascript">
<!--

function TABLE1_onclick() {

}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
              <table class="common"  id="TABLE1" language="javascript" onclick="return TABLE1_onclick()" > 
            <tr>
                <td colspan="3" style=" padding:0px" ><h4>
                    Faculty Qualification Details</h4>
                </td>
            </tr>
            <tr>
                <td class="w290 talignleft" colspan="3"  style=" text-align:center;">
                    <asp:Label ID="lbl_error" runat="server" Text="" CssClass="error"></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 158px; height: 20px">
                    Faculty name</td>
                <td colspan="2" style="height: 20px">
                    <asp:Label ID="lbl_facname" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 158px">
                    Institute</td>
                <td  colspan="2">
                    <asp:Label ID="lbl_institute" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 158px">
                    Course</td>
                <td colspan="2">
                    <asp:Label ID="lbl_course" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 158px">
                    Subject</td>
                <td colspan="2">
                    <asp:Label ID="lbl_subject" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 158px">
                    Percentage of marks obtained</td>
                <td colspan="2">
                    <asp:Label ID="lbl_percentage" runat="server" Text=''></asp:Label></td>
            </tr>
              <tr>
                <td class="w290 talignleft" style="width: 158px">
                 Softwares Known</td>
                <td colspan="2">
                    <asp:Label ID="lblsftknown" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 158px">
                    Year of completion</td>
                <td colspan="2" style="height: 26px">
                    <asp:Label ID="lbl_year" runat="server" Text=''></asp:Label></td>
            </tr>
        </table>
 
    </form>
</body>
</html>
