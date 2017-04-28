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
<link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
<script language="javascript" type="text/javascript">
    function trim(stringToTrim) {
		return stringToTrim.replace(/^\s+|\s+$/g,"");
	}
   function clearValidation(fieldList) {	
		var field=new Array();
		field=fieldList.split("~");
		var counter=0;
		for(i=0;i<field.length;i++) {
			if(document.getElementById(field[i]).value!="") {
				document.getElementById(field[i]).style.border-bottom="#ffffff 2px solid";
			}
		}			
	}    
    function loginval() {
alert("login");
		clearValidation('txtusername~txtpassword');
		if(trim(document.getElementById("txtusername").value)==""){
			document.getElementById("txtusername").value=="";
			document.getElementById("lblerrmsg").innerHTML = '*Please Enter the User name!';
			document.getElementById("txtusername").focus();
			document.getElementById("txtusername").style.border="#ffffff 2px solid";
			return false;
		}    
		else if(trim(document.getElementById("txtpassword").value)==""){
			document.getElementById("txtpassword").value=="";
			document.getElementById("lblerrmsg").innerHTML = '*Please Enter the Password!';
			document.getElementById("txtpassword").focus();
			document.getElementById("txtpassword").style.border="#ffffff 2px solid";
			return false;
		}   
		else {
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
<body style="background:#1787cd;">
<form id="form1" runat="server">
  <!--wrapper start-->
  <div class="inner-cont3 login-outer-cont">
    <div class="logo2"><img src="layout/logo1.png"/></div>
    <div class="login-out-cont">
      <div class="login-bg"></div>
      <div id="outerwrapper" class="login-cont">
        <table class="login_table" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()" width="100%">
          <tr>
            <td><div class="log-cont">
                <div class="lock"><img src="images/lock.png" /></div>
                <ul>
                  <li>
                    <asp:TextBox ID="txtusername" runat="server" CssClass="TextBox"  autocomplete="off" AutoCompleteType="disabled"></asp:TextBox>
                    <label class="login-lbl">Username</label>
                  </li>
                  <li class="mrg-btm">
                    <asp:TextBox ID="txtpassword"  runat="server" CssClass="TextBox"  autocomplete="off" AutoCompleteType="disabled" TextMode="Password" ></asp:TextBox>
                    <label class="login-lbl">Password</label>
                  </li>
                  <li class="mrg-btm">
                    <asp:Label ID="lblerrmsg" CssClass="error" runat="server"></asp:Label>
                  </li>
                  <li class="btn-cont">
                    <asp:Button CssClass="submit-btn" ID="login" runat="server" Text="LOGIN" OnClientClick="javascript:return loginval();" OnClick="login_Click" />
                  </li>
                </ul>
              </div></td>
          </tr>
        </table>
      </div>
    </div>
    <div id="footer" class="footer">&copy; 2017 Image Infotainment Limited. All rights reserved.</div>
  </div>
</form>
<script type="text/javascript">
var inputValue = document.getElementsByClassName("TextBox");

var onFocus = function() { this.parentNode.classList.add("input-expand");};

var onBlur = function() {if (!this.value) this.parentNode.classList.remove("input-expand");};

for (var i = 0; i < inputValue.length; i++) {
    inputValue[i].addEventListener('focus', onFocus, false);
    inputValue[i].addEventListener('blur', onBlur, false);
}
    
</script>
</body>
</html>
