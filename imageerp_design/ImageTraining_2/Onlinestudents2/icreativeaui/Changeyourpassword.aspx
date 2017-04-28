<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Changeyourpassword.aspx.cs" Inherits="superadmin_Changeyourpassword" Title="Change Password" %>
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
<div class="title-cont">
<h3 class="cont-title">Change Password </h3>
</div>

<div class="white-cont">
<div class="padd-cont">
<div class="form-cont">
<div align="center">
      <asp:Label ID="lblerrmsg" CssClass="error" runat="server" Text=""></asp:Label></div>
  
  <ul>
  <li><label class="label-txt">Existing Password</label>
  <asp:TextBox ID="existingpwd" runat="server" CssClass="text input-txt" TextMode="Password"></asp:TextBox>
   <asp:CustomValidator ID="custSpecialValidator1" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special1" ControlToValidate="existingpwd"></asp:CustomValidator>
  </li>
  <li><label class="label-txt">New Password</label>
   <asp:TextBox ID="newpwd" runat="server" CssClass="text input-txt" TextMode="Password"></asp:TextBox>
   <asp:CustomValidator ID="custSpecialValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special2" ControlToValidate="newpwd"></asp:CustomValidator>
   </li>
  <li><label class="label-txt">Re-Enter Password</label>
        <asp:TextBox ID="reenterpwd" runat="server" CssClass="text input-txt" TextMode="Password"></asp:TextBox>
        <asp:CustomValidator ID="custSpecialValidator3" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special3" ControlToValidate="reenterpwd"></asp:CustomValidator>
        </li>
  <li>
  <div align="center">
  
      <asp:Button CssClass="btnStyle1" ID="changepwd" runat="server" Text="Submit" OnClientClick="javascript:return changepwdval();" OnClick="changepwd_Click" />
    <input id="Reset1" class="reset-btn" onclick="javascript:return Reset();" type="button" 
            value="Reset" />
 </div>  </li>  
 </ul><div class="clear"></div>
 </div></div>
</div> 

</asp:Content>

