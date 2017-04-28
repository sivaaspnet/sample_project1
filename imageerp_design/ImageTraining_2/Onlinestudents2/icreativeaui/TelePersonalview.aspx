<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TelePersonalview.aspx.cs" Inherits="TelePersonalview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Personal View</title>
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/jquery-ui-1.8.2.custom.css" />    
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="scripts/main.js"></script> 
    <script type="text/javascript" src="scripts/jquery.rotatingMenu.js"></script>
    <script language="javascript" type="text/javascript">
    
     function trim(stringToTrim)
	   {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
       }
       function MaxLength(field, maxLength)
    {
        if (field.value.length >= maxLength)
            field.value = field.value.substring(0, maxLength - 1);
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
	    if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
		    return true; 
	    } else {
		    return false;
	    }
   }

function Validate_Email(Email)
           {
           //alert(Email);
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
          
          
      function update()
      {
      //alert("True");
//      if((document.getElementById("txtName").value)=="" || (document.getElementById("txtEmail").value)=="" || (document.getElementById("txtMobileNo").value)=="" || (document.getElementById("txtRemarks").value)=="" )
//      {
     
      if(trim(document.getElementById("txtName").value)=="")
             {
                 document.getElementById("txtName").value=="";   
                 alert('Please Enter the EnquiryName!');
                 document.getElementById("txtName").focus();
                 document.getElementById("txtName").style.border="#ff0000 1px solid";
                 document.getElementById("txtName").style.backgroundColor="#e8ebd9";           
                 return false;
             }
             else if(trim(document.getElementById("txtEmail").value)=="")
             {
                 document.getElementById("txtEmail").value=="";   
                 alert('Please Enter the EmailID!');
                 document.getElementById("txtEmail").focus();
                 document.getElementById("txtEmail").style.border="#ff0000 1px solid";
                 document.getElementById("txtEmail").style.backgroundColor="#e8ebd9";
                 return false;
             }
              else if(!Validate_Email(document.getElementById("txtEmail").value))
              {
	                alert('Please Enter the Valid EmailId!');
		            document.getElementById("txtEmail").focus();
                    document.getElementById("txtEmail").style.border="#ff0000 1px solid";
                    document.getElementById("txtEmail").style.backgroundColor="#e8ebd9";
		            return false;
	          }
        
           else if((document.getElementById("txtMobileNo").value)=="" || document.getElementById("txtMobileNo").value.length<10)
             {             
                 document.getElementById("txtMobileNo").value=="";
                 alert('Please Enter the Mobile number!');
                 document.getElementById("txtMobileNo").focus();
                 document.getElementById("txtMobileNo").style.border="#ff0000 1px solid";
                 document.getElementById("txtMobileNo").style.backgroundColor="#e8ebd9";
                 return false;
             }
    
                 else if(trim(document.getElementById("txtRemarks").value)=="")
             {
                 document.getElementById("txtRemarks").value=="";
                 alert('Please Enter your Remarks!');
                 document.getElementById("txtRemarks").focus();
                 document.getElementById("txtRemarks").style.border="#ff0000 1px solid";
                 document.getElementById("txtRemarks").style.backgroundColor="#e8ebd9";
                 return false;
             }
               
//             else
//             {
//             return true;
//             } 
//             
//         }
         else
         {
       if (top.location != self.location) {
     
       
     }
         }   
         
      }    


function btnprint_onclick() {
 javascript:window.print();
}

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  class="common" style="width: 600px" >
    <tr><td colspan="2" align="center" style=" padding:0px;"><h4>Personal Details</h4></td></tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Label ID="lblerror" runat="server" CssClass="error" Text=''></asp:Label></td>
        </tr>
    <tr><td >
        Name :</td><td >
            <asp:TextBox ID="txtName" CssClass="text" runat="server" Width="356px" MaxLength="50"></asp:TextBox></td></tr>
    <tr><td >
        Email ID :</td><td>
            <asp:TextBox ID="txtEmail" onpaste="return false" CssClass="text" runat="server" Width="356px" MaxLength="200"></asp:TextBox></td></tr>
    <tr><td >
                      Mobile No :</td><td style="width: 706px">
            <asp:TextBox ID="txtMobileNo" CssClass="text" runat="server" Width="356px" onKeyPress="return CheckNumeric(event)" MaxLength="10"></asp:TextBox></td></tr>
        <tr>
            <td >
                      Phone No :</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="text" Width="356px" onKeyPress="return CheckNumeric(event)" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td  style="height: 25px; width: 400px;">
                      Address :</td>
            <td style="height: 25px">
                <asp:TextBox ID="txtAddr" runat="server" CssClass="text" TextMode="MultiLine" Width="356px" onKeyPress="MaxLength(this,400);"></asp:TextBox></td>
        </tr>
        <tr>
            <td  style="height: 25px; width: 400px;">
                      Source :</td>
            <td style="height: 25px">
                   <asp:DropDownList ID="ddl_source" runat="server" CssClass="select" >
                                        <asp:ListItem value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="image web/internet">image web/internet</asp:ListItem>
                                        <asp:ListItem Value="Google">Google</asp:ListItem>
                                        <asp:ListItem Value="Just Dial">Just Dial</asp:ListItem>
                                        <asp:ListItem Value="Sulekha">Sulekha</asp:ListItem>
                                        <asp:ListItem Value="ROPS(Reference of past Student)">ROPS(Reference of past Student)</asp:ListItem>
                                        <asp:ListItem Value="ROCS(Reference of Current Student)">ROCS(Reference of Current Student)</asp:ListItem>
                                        <asp:ListItem Value="ROS (Reference of Staff)">ROS (Reference of Staff)</asp:ListItem>
                                        <asp:ListItem Value="Reference of enquiry">Reference of enquiry</asp:ListItem>
                                        <asp:ListItem Value="WOM(Words of Mouth)">WOM(Words of Mouth)</asp:ListItem>
                                        <asp:ListItem value="Board">Sign Board</asp:ListItem>
                                        <asp:ListItem Value="Tv advertisement">Tv advertisement</asp:ListItem>
                                        <asp:ListItem Value="Print advertisement">Print advertisement</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem> 
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td  style="height: 25px; width: 400px;">
                      Profile :</td>
            <td style="height: 25px">
                <asp:DropDownList ID="ddl_profile" runat="server" CssClass="select">
                          <asp:ListItem Value="">--Select--</asp:ListItem>
                          <asp:ListItem Value="School student">School student</asp:ListItem>
                          <asp:ListItem Value="College student">College student</asp:ListItem>
                          <asp:ListItem Value="Employed">Employed/Salaried</asp:ListItem>
                          <asp:ListItem Value="SelfEmployed">Self-Employed</asp:ListItem>
                          <asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
                          <asp:ListItem Value="Housewife">Housewife</asp:ListItem>
                          <asp:ListItem Value="SrCitizen">Sr.Citizen</asp:ListItem>
                          <asp:ListItem Value="Multimedia Professional">Multimedia Professional</asp:ListItem>
                          <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                      </asp:DropDownList></td>
        </tr>
        <tr>
            <td >
                Remarks</td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="text" TextMode="MultiLine" Width="356px" onKeyPress="MaxLength(this,400);"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Enquired By</td>
            <td>
                <asp:TextBox ID="txtenq_By" runat="server" CssClass="text" MaxLength="50" Width="356px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Modified By</td>
            <td>
                <asp:TextBox ID="txtmod_By" runat="server" CssClass="text" MaxLength="50" Width="356px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" colspan="2">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                
                <input id="btnprint" class="submit" type="button" value="Print" onclick="return btnprint_onclick()" />
                <asp:Button ID="btn_update" runat="server" Text="Update" CssClass="submit" OnClientClick="javascript:return update();" OnClick="btn_update_Click" /></td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
