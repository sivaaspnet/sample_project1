<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="masterpassword.aspx.cs" Inherits="superadmin_Changeyourpassword" Title="Master Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
	location.href="masterpassword.aspx";
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
   
    
     if(trim(document.getElementById("ContentPlaceHolder1_masterpass").value)=="")
     {
      document.getElementById("ContentPlaceHolder1_masterpass").value=="";
      document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = '*Please Enter your Master Password!';
      document.getElementById("ContentPlaceHolder1_masterpass").focus();
      document.getElementById("ContentPlaceHolder1_masterpass").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_masterpass").style.backgroundColor="#e8ebd9";
       return false;
     }
      else if(trim(document.getElementById("ContentPlaceHolder1_TextBox1").value)=="")
     {
      document.getElementById("ContentPlaceHolder1_TextBox1").value=="";
      document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML = '*Please Enter Captcha!';
      document.getElementById("ContentPlaceHolder1_TextBox1").focus();
      document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
       return false;
     }
        
     else
     {
     return true;
     }
  }   
</script>
<div class="title-cont">
    <h3 class="cont-title"><asp:Image ID="Image2" runat="server" Height="21px" ImageUrl="~/ImageTraining_2/Onlinestudents2/layout/Keychain_Access_Icon.png" Width="27px" /> Verification</h3>
    
    <div class="clear"></div>
  </div>
  <div class="free-forms">
    <div class="white-cont">
    <div class="form-cont" style="margin:0px auto; width:700px;">
      <ul>
        <li>
          <div align="center">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageTraining_2/Onlinestudents2/layout/imageLogo.png" />
          </div>
        </li>
        <li>
          <div align="center"><strong>Master Password is required to view Reports.</strong></div>
        </li>
        <li>
          <div align="center">
            <asp:Label ID="lblerrmsg" CssClass="error" runat="server" Text=""></asp:Label>
          </div>
        </li>
        <li>
          <label class="label-txt">Enter Master Password</label>
          <asp:TextBox ID="masterpass" runat="server" CssClass="text input-txt" TextMode="Password" MaxLength="15" ></asp:TextBox>
          <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special" ControlToValidate="masterpass"></asp:CustomValidator>
        </li>
        <li>
          <div align="center">
            <asp:Button CssClass="btnStyle1" ID="changepwd" runat="server" Text="Submit" OnClientClick="javascript:return changepwdval();" OnClick="changepwd_Click" />
            <input id="Reset1" class="reset-btn" onclick="javascript:return Reset();" type="button" value="Reset" />
          </div>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
  </div>
  </div>
</asp:Content>
