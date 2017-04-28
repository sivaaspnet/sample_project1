<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewfacultyexpdetails.aspx.cs" Inherits="superadmin_viewfacultyexpdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View Experience Details</title>
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
     <table class="common"  style="height:250;width:600" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()" > 
            <tr>
                <td colspan="3"  style="padding:0px" >
                <h4>
                    Faculty Experience Details </h4>
                </td>
            </tr>
            <tr>
                <td class="w290 talignleft" colspan="3" style="text-align: center; height: 26px;">
                    <asp:Label ID="lbl_error" runat="server" Text="" CssClass="error"></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 91px">
                    Company</td>
                <td colspan="2">
                    <asp:Label ID="lbl_company" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 91px">
                    Designation</td>
                <td  colspan="2">
                    <asp:Label ID="lbl_designation" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 91px; height: 23px;">
                    From date</td>
                <td colspan="2" style="height: 23px">
                    <asp:Label ID="lbl_fromdate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 91px">
                    To date</td>
                <td colspan="2">
                    <asp:Label ID="lbl_todate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="height: 25px; width: 91px;">
                    Description</td>
                <td colspan="2" style="height: 25px">
                    <asp:Label ID="lbl_description" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 91px">
                    Reason to relieve</td>
                <td colspan="2">
                    <asp:Label ID="lbl_reason" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
 
      
    </form>
</body>
</html>
