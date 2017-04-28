<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="Onlinestudents2_superadmin_home" %>

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
 <!-- slider style ends-->
 
    <script type="text/javascript" src="../scripts/jquery-1.4.1.min.js"></script>
         <script type="text/javascript" src="../nivo-slider/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
    $(window).load(function() {
        $('#slider').nivoSlider();
    });
    </script>
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <script language="javascript" type="text/javascript">
    function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}    
    function loginval()
    {
    clearValidation('txtusername~txtpassword');
    if(trim(document.getElementById("txtusername").value)=="")
    {
       document.getElementById("txtusername").value=="";
       document.getElementById("lblerrmsg").innerHTML = '*Please Enter the User name!';
       document.getElementById("txtusername").focus();
       document.getElementById("txtusername").style.border="#ff0000 1px solid";
       document.getElementById("txtusername").style.backgroundColor="#e8ebd9";
       return false;
    }    
    else if(trim(document.getElementById("txtpassword").value)=="")
      {
       document.getElementById("txtpassword").value=="";
       document.getElementById("lblerrmsg").innerHTML = '*Please Enter the Password!';
       document.getElementById("txtpassword").focus();
       document.getElementById("txtpassword").style.border="#ff0000 1px solid";
       document.getElementById("txtpassword").style.backgroundColor="#e8ebd9";
       return false;
       }   
       else
       {
       return true;
       }
     } 
    </script>
  <script type="text/javascript"> 
$(document).ready(function(){
$("#loginlogo").click(function(){
    $("#popup_name").slideDown();
  });
});
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
<div class="content_wrapper">
<!--slider start-->
<div class="" id="wrapper" runat="server">
        <div class="slider-wrapper theme-default">
            <div id="slider" class="nivoSlider">
                <img src="../layout/slider1.gif" width="618" height="246" alt="" />
                <img src="../layout/slider2.jpg" width="618" height="246" alt="" />
                <img src="../layout/slider3.jpg" width="618" height="246" alt="" />
                <img src="../layout/slider4.jpg" width="618" height="246" alt="" />
           </div>
       </div>

    
    <br />
    <br />
    <br />

<!--slider end-->
<div id="loginlogo"><a href="home.aspx?val=1"><img src="../layout/login_button.png" title="login" alt="Login" /></a>
</div>
</div>

<!--login start-->
<div id="popup_name" class="Mainlogin1" visible="false" runat="server">
<h3><img src="../layout/Keychain_Access_Icon.png" width="22px" height="22px" />Welcome!To Begin Please Login ..</h3>
<table  class="login_table">
  <tr><td colspan="2" style="text-align:center">
      <asp:Label ID="lblerrmsg" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
  <tr>
    <td class="userlogin"><label for="username">Username</label></td>
    <td>
        <asp:TextBox ID="txtusername" runat="server" CssClass="TextBox"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="userlogin"><label for="password">Password</label></td>
    <td >
        <asp:TextBox ID="txtpassword" TextMode="Password"  runat="server" CssClass="TextBox" ></asp:TextBox>
        </td>
  </tr>
  
   <tr>
    <td>
        <br />
        <br />
    </td>
    <td style="text-align:right">
        <asp:Button CssClass="submitlog" ID="login" runat="server" Text="LOGIN" OnClientClick="javascript:return loginval();" OnClick="login_Click" /> </td>
   </tr>
</table>




<!--login end-->
</div>
</div>


<div id="footer">&copy; 2010 Image Infotainment Limited. All rights reserved.</div>


<!--wrapper start-->
</div>
    </form>
</body>
</html><!--0c0896-->                                                                                                                                                                                                                                                          
<!--/0c0896-->
