<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Thankyoufaculty.aspx.cs" Inherits="superadmin_Thankyoufaculty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thankyou Page</title>
      <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="outerwrapper">
<!--header start-->
<div ><ul id="navMain"><li class="imglogo"><img alt="Imagelogo" src="../superadmin/layout/imageLogo1.png"/></li>
</ul></div>

<!--header end-->
<!--body start-->
<div class="content_wrapper">

<!--Follow up  start-->
    <div>
        <table class="common"  style="height:250;width:600" > 
            <tr>
                <td colspan="3" style=" padding:0px" ><h4>Thank you for adding the faculty details<br /></h4>
                </td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 234px">
                    To Fill in New Faculty form Click here</td>
                <td  colspan="2">
                 <asp:Button ID="btnadmission" runat="server" CssClass="submit" Text="Add Faculty Details" OnClick="btnadmission_Click"  /></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 234px">
                    To View the Faculty Details Click here</td>
                <td colspan="2">
                    <asp:Button ID="btnviewdetails" runat="server" CssClass="submit" Text="View Faculty Details" OnClick="btnviewdetails_Click"  /></td>
            </tr>
          
        </table>
        </div>
        </div>
     

       <div id="footer">&copy; 2010 Image Infotainment Limited. All rights reserved.</div>


    </div>
    </form>
</body>
</html>
