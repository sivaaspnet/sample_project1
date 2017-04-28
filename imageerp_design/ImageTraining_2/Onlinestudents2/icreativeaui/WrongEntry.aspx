<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WrongEntry.aspx.cs" Inherits="Onlinestudents2_superadmin_WrongEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>Home Page</title>
   <!-- slider style starts-->
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="../nivo-slider/themes/default/default.css"  type="text/css" media="screen" />
    <link rel="stylesheet" href="../nivo-slider/themes/pascal/pascal.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../nivo-slider/themes/orman/orman.css"type="text/css" media="screen" />
    <link rel="stylesheet" href="../nivo-slider/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../nivo-slider/demo/style.css" type="text/css" media="screen" />
    <link rel="shortcut icon" type="image/x-icon" href="../layout/logo.png"/>
 <!-- slider style ends-->
 
    <script type="text/javascript" src="../scripts/jquery-1.4.1.min.js"></script>
         <script type="text/javascript" src="../nivo-slider/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
    $(window).load(function() {
        $('#slider').nivoSlider();
    });
    </script>
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    
     
   
  <script type="text/javascript"> 
$(document).ready(function(){
$("#loginlogo").click(function(){
    $("#popup_name").slideDown();
  });
});
function TABLE1_onclick() {

}

</script>
  


</head>
<body>
    <form id="form1" runat="server">
   <!--wrapper start-->
<div id="outerwrapper">
<!--header start-->
<div ><ul id="navMain"><li class="imglogo"> <img src="../superadmin/layout/logo.png"/></li>
</ul></div>
<!--header end-->
<!--body start-->
<div style="background:#E7E7E7"  class="content_wrapper">
<!--slider start-->
<div style="margin:auto" align="center">
    <br />
    <img src="../layout/under-construction-logo.gif" alt="" style="width: 338px; height: 320px" /><br />
    <br />
    <asp:Label ID="lblofflinemessage" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label><asp:Label
        ID="lblpagerestrictionmessage" runat="server" Font-Bold="True" Font-Size="Medium"
        Text="You Can Not Enter Into This Page Please Contact Branch Manager."></asp:Label>
        <asp:Label ID="lblunauthroziedmessage" runat="server" Font-Bold="True" Font-Size="Medium" Text="Sorry...Authorized Persons Only Allowed."></asp:Label><br />

<!--slider end-->
</div>
<div id="loginlogo"><a href="home.aspx?val=1"></a>
</div>

<!--login start-->
    <tr>
        <td colspan="2" style="text-align: center">
        </td>
    </tr>
  <tr><td colspan="2" style="text-align:center">
      </td></tr>
  <tr>
    <td class="userlogin" style="width: 65px; font-weight:bold;"></td>
  </tr>
</div>


<div id="footer">&copy; 2010 Image Infotainment Limited. All rights reserved.</div>


<!--wrapper start-->
</div>
    </form>
</body>
</html>
