<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewfacultypersonal.aspx.cs" Inherits="superadmin_viewfacultypersonal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Faculty personal Details</title>
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
     <link href="styles/jquery-ui-1.8.2.custom.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript">
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
 function Validate_Email(Email)
           {
            var Str=Email
            var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
            if(CheckExpression.test(Str))
            {
	            return true;
            }
            else
            {
	            return false;
            }
          }  
 function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}
function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 0) {
		return true; 
	} else {
		return false;
	}
}
       function update()
       {
         clearValidation('txt_facname~txt_dob~txt_peraddress~txt_tempadd~txt_mobile~txt_landline~txt_email')
         if(document.getElementById("txt_facname").value=="")
         {
             alert("Please enter faculty name");
             document.getElementById("txt_facname").focus();
             document.getElementById("txt_facname").style.border="#ff0000 1px solid";
             document.getElementById("txt_facname").style.backgroundColor="#e8ebd9";
             return false;
         }
         if(document.getElementById("txt_dob").value=="")
         {
             alert("Please Date of birth in the format specified(DD_MM_YYYY)");
             document.getElementById("txt_dob").focus();
             document.getElementById("txt_dob").style.border="#ff0000 1px solid";
             document.getElementById("txt_dob").style.backgroundColor="#e8ebd9";
             return false;
         }
         if(document.getElementById("txt_peraddress").value=="")
         {
             alert("Please enter permanent address");
             document.getElementById("txt_peraddress").focus();
             document.getElementById("txt_peraddress").style.border="#ff0000 1px solid";
             document.getElementById("txt_peraddress").style.backgroundColor="#e8ebd9";
             return false;
         }
         if(document.getElementById("txt_tempadd").value=="")
         {
             alert("Please enter temporary address");
             document.getElementById("txt_tempadd").focus();
             document.getElementById("txt_tempadd").style.border="#ff0000 1px solid";
             document.getElementById("txt_tempadd").style.backgroundColor="#e8ebd9";
             return false;
         }
         if(document.getElementById("txt_mobile").value=="")
         {
             alert("Please enter mobile number");
             document.getElementById("txt_mobile").focus();
             document.getElementById("txt_mobile").style.border="#ff0000 1px solid";
             document.getElementById("txt_mobile").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_mobile").value!="" && document.getElementById("txt_mobile").value.length<10)
         {
             alert("Invalid Mobile No(Must have 10digits)")
             document.getElementById("txt_mobile").focus();
             document.getElementById("txt_mobile").style.border="#ff0000 1px solid";
             document.getElementById("txt_mobile").style.backgroundColor="#e8ebd9";
             return false;
         }
         
          if(document.getElementById("txt_email").value=="")
         {
             alert("Please enter email id");
             document.getElementById("txt_email").focus();
             document.getElementById("txt_email").style.border="#ff0000 1px solid";
             document.getElementById("txt_email").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(!Validate_Email(document.getElementById("txt_email").value))
         {
             alert("Please Enter the Valid Email-ID");
             document.getElementById("txt_email").focus();
             document.getElementById("txt_email").style.border="#ff0000 1px solid";
             document.getElementById("txt_email").style.backgroundColor="#e8ebd9";
             return false;
         }   
         else
         {
          return true;
         }
           
       }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    
        <table class="common"  > 
            <tr>
                <td colspan="3" style=" padding:0px" ><h4>
                    Faculty
                    Personal Details</h4>
                </td>
            </tr>
            <tr>
                <td class="w290 talignleft" colspan="3" style="text-align: center; ">
                    <asp:Label ID="lbl_error" runat="server" Text="" CssClass="error"></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 167px">
                    Faculty name</td>
                <td colspan="2">
                    <asp:Label ID="txt_facname" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 167px">
                    Date of birth&nbsp; (DD-MM-YYYY)</td>
                <td  colspan="2">
                    <asp:Label ID="txt_dob" runat="server" Text=''></asp:Label></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 167px">
                    Permanent address</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_peraddress" runat="server" MaxLength="100" CssClass="text" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 167px">
                    Temporary address</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_tempadd" runat="server" MaxLength="100" CssClass="text" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 167px">
                    Mobile no</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_mobile" runat="server" MaxLength="10" CssClass="text" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 167px">
                    Landline no</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_landline" runat="server" MaxLength="11" CssClass="text" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="w290 talignleft" style=" width: 167px;">
                    Email-id</td>
                <td colspan="2" style="height: 34px">
                    <asp:TextBox ID="txt_email" runat="server" MaxLength="50" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="w290 talignleft" colspan="3" style="height: 34px; text-align:center;">
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClientClick="javascript:return update();" CssClass="submit" OnClick="btn_update_Click" /></td>
            </tr>
        </table>
 
    </form>
</body>
</html>
