<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="changemaster.aspx.cs" Inherits="superadmin_Changeyourpassword" Title="Change Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
location.href="Changeyourpassword.aspx";
}

// ]]>
</script>

<script language="javascript" type="text/ecmascript">

 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
 function clearValidation(fieldList) 
 {
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) 
	{
		if(document.getElementById(field[i]).value!="") 
		{
			document.getElementById(field[i]).style.border="#EFEFEF 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#FFFFFF";
		}
	}	
}   

 function changepwdval()
  {
     var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
     clearValidation('ContentPlaceHolder1_existingpwd~ContentPlaceHolder1_newpwd~ContentPlaceHolder1_reenterpwd');
     if(trim(document.getElementById("ContentPlaceHolder1_existingpwd").value)=="")
     {
      document.getElementById("ContentPlaceHolder1_existingpwd").value=="";
      document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = '*Please Enter your Existing Password!';
      document.getElementById("ContentPlaceHolder1_existingpwd").focus();
      document.getElementById("ContentPlaceHolder1_existingpwd").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_existingpwd").style.backgroundColor="#e8ebd9";
       return false;
     }
      else if(trim(document.getElementById("ContentPlaceHolder1_newpwd").value)=="")
     {
      document.getElementById("ContentPlaceHolder1_newpwd").value=="";
      document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = '*Please Enter your New Password!';
      document.getElementById("ContentPlaceHolder1_newpwd").focus();
      document.getElementById("ContentPlaceHolder1_newpwd").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_newpwd").style.backgroundColor="#e8ebd9";
       return false;
     }
               else if(!re.test(document.getElementById("ContentPlaceHolder1_newpwd").value))
         {
             document.getElementById("ContentPlaceHolder1_newpwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_newpwd").focus();
             document.getElementById("ContentPlaceHolder1_newpwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_newpwd").style.backgroundColor="#e8ebd9";
             return false;
         }
         
      else if(trim(document.getElementById("ContentPlaceHolder1_reenterpwd").value)=="")
     {
      document.getElementById("ContentPlaceHolder1_reenterpwd").value=="";
      document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = '*Please Re-Enter your New Password!';
      document.getElementById("ContentPlaceHolder1_reenterpwd").focus();
      document.getElementById("ContentPlaceHolder1_reenterpwd").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_reenterpwd").style.backgroundColor="#e8ebd9";
       return false;
     }
      else if(document.getElementById("ContentPlaceHolder1_newpwd").value != document.getElementById("ContentPlaceHolder1_reenterpwd").value)
      {
      document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = '*Password Missmatch!';
      document.getElementById("ContentPlaceHolder1_newpwd").focus();
      document.getElementById("ContentPlaceHolder1_newpwd").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_newpwd").style.backgroundColor="#e8ebd9";
      document.getElementById("ContentPlaceHolder1_reenterpwd").focus();
      document.getElementById("ContentPlaceHolder1_reenterpwd").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_reenterpwd").style.backgroundColor="#e8ebd9";
      return false;
      }
     else
     {
     return true;
     }
  } 
  
  function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_existingpwd").value="";
document.getElementById("ContentPlaceHolder1_newpwd").value="";
document.getElementById("ContentPlaceHolder1_reenterpwd").value="";


}
  
  
  
  
  
  
  
</script>
<div class="login" style="width: 316px; height:218px; left: 38%; top: 35%;">
<h2 style="width: 304px">Change Master Password !!</h2>




<!--login end-->
    <br />
   <table  class="login_table" style="width: 265px;">
  <tr><td colspan="2" style="text-align:center">
      <asp:Label ID="lblerrmsg" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
  <tr>
    <td class="userlogin" style="width: 149px" ><label for="ExistingPassword" style="color:Black">Existing Master Password</label></td>
    <td >
        <asp:TextBox ID="existingpwd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="userlogin" style="width: 149px" ><label for="password" style="color:Black">New Master Password</label></td>
    <td >
        <asp:TextBox ID="newpwd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td class="userlogin" style="width: 149px" ><label for="repassword" style="color:Black">Re-Enter Password</label></td>
    <td >
        <asp:TextBox ID="reenterpwd" runat="server" CssClass="text" TextMode="Password"></asp:TextBox></td>
  </tr>
   <tr>
    <td style="width: 149px; text-align:right;">        
        <br />
        <asp:Button CssClass="submit" ID="changepwd" runat="server" Text="Submit" OnClientClick="javascript:return changepwdval();" OnClick="changepwd_Click" />
       
    </td>
    <td style="text-align:left;">
        <br />
        &nbsp;
        <input id="Reset1" class="submit" onclick="javascript:return Reset();" type="button"
            value="Reset" /></td>
   </tr>
</table>
    <br />
</div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

