<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="img_superadmin_Login" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>Home Page</title>
   <!-- slider style starts-->
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="nivo-slider/themes/default/default.css"  type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/pascal/pascal.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/orman/orman.css"type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/demo/style.css" type="text/css" media="screen" />
    <link rel="shortcut icon" type="image/x-icon" href="../layout/logo.png"/>
 <!-- slider style ends-->
 
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
         <script type="text/javascript" src="nivo-slider/jquery.nivo.slider.pack.js"></script>
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
       document.getElementById("txtusername").style.border="#fff 1px solid";
       document.getElementById("txtusername").style.backgroundColor="#e8ebd9";
       return false;
    }    
    else if(trim(document.getElementById("txtpassword").value)=="")
      {
       document.getElementById("txtpassword").value=="";
       document.getElementById("lblerrmsg").innerHTML = '*Please Enter the Password!';
       document.getElementById("txtpassword").focus();
       document.getElementById("txtpassword").style.border="#fff 1px solid";
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
function TABLE1_onclick() {

}

</script>
  


</head>
<body>
    <form id="form1" runat="server">
   <!--wrapper start-->
<div id="outerwrapper">
<!--header start-->
<div ><ul id="navMain"><li class="imglogo"> <img src="layout/logo1.png"/></li>



<table  class="login_table" style="width: 223px" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
    <tr>
        <td colspan="2" style="text-align: center">
        </td>
        <td colspan="1" style="width: 154px; text-align: center">
        </td>
    </tr>
  <tr><td colspan="2" style="text-align:center; height: 22px;">
      <asp:Label ID="lblerrmsg" CssClass="error" runat="server" ForeColor="White"></asp:Label></td>
      <td colspan="1" style="width: 154px; text-align: center; height: 22px;">
      </td>
  </tr>
  <tr>
    <td class="userlogin" style="width: 65px; font-weight:bold;"><label for="username">
        <strong>Username</strong></label></td>
    <td class="userlogin" style="width: 65px; font-weight:bold;">
        <strong>Password</strong></td>
      <td style="width: 154px">
      </td>
  </tr>
  <tr>
    <td class="userlogin" style="width: 65px;font-weight:bold;"><label for="password">
        <strong>
        <asp:TextBox ID="txtusername" runat="server" CssClass="TextBox"  autocomplete="off" AutoCompleteType="disabled"></asp:TextBox></strong></label></td>
    <td style="width: 154px" >
        <asp:TextBox ID="txtpassword"  runat="server" CssClass="TextBox"  autocomplete="off" AutoCompleteType="disabled" TextMode="Password" ></asp:TextBox>
        </td>
      <td style="width: 154px" valign="middle">
       
        <asp:Button CssClass="submitlog" ID="login" runat="server" Text="LOGIN" OnClientClick="javascript:return loginval();" OnClick="login_Click" /></td>
  </tr>
  
   <tr>
       <td colspan="2" style="text-align:right; height: 22px;">
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
       <td colspan="1" style="width: 154px; height: 22px; text-align: right">
       </td>
   </tr>
</table>





</ul>







</div>
<!--header end-->
<!--body start-->
<div style="background:#ccc"  class="content_wrapper">
<!--slider start-->
<div  id="wrapper" runat="server">
        <div class="slider-wrapper theme-default">
            <div id="slider" class="nivoSlider">
                <asp:Image ID="Image1"  width="957"  height="350" alt="image" runat="server" />
             
                             <asp:Image ID="Image2"  width="957"  height="350" alt="image" runat="server" />

                <asp:Image ID="Image3"  width="957"  height="350" alt="image" runat="server" />

                <asp:Image ID="Image4"  width="957"  height="350" alt="image" runat="server" />

           
           </div>
       </div>


<!--slider end-->

</div>

<!--login start-->

</div>


<div id="footer">&copy; 2010 Image Infotainment Limited. All rights reserved.</div>


<!--wrapper start-->
</div>
    </form>
</body>
</html>
