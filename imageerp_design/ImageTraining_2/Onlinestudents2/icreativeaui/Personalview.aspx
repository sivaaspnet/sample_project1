<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personalview.aspx.cs" Inherits="Personalview" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Untitled Page</title>
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
       
     function isNumberKey(GetEvt)
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



function onFileLoad(e) { 

    jQuery('#preview').html('<img height="100px" width="100px" src="'+e.target.result +'"/>'); 
 
}

function displayPreview(files) 
{
    var reader = new FileReader();
    reader.onload = onFileLoad;
    reader.readAsDataURL(files[0]);

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
      var start = document.getElementById("txtdob").value;
      var start_s = start.split("-");
      var stDate = start_s[2]+start_s[1]+start_s[0];
      var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        //var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        var csDate = toDate-stDate;
        
//        alert(stDate);
//        alert(toDate);
//        alert(csDate);
        
        
        
         clearValidation('lblname~txtdob~lblparentname~lblcompany~lbldesignatio~lblincome~lbladdress~lbldist~lblcityy~lblstate~lblpincod~lblphone~lblmobile~lblemailid')
         if(document.getElementById("lblname").value=="")
         {
             alert("Please enter student name name");
             document.getElementById("lblname").focus();
             document.getElementById("lblname").style.border="#ff0000 1px solid";
             document.getElementById("lblname").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txtdob").value=="")
         {
             alert("Please enter student date of birth");
             document.getElementById("txtdob").focus();
             document.getElementById("txtdob").style.border="#ff0000 1px solid";
             document.getElementById("txtdob").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(csDate < 0)
         {
             alert("Please enter valid date of birth");
             document.getElementById("txtdob").focus();
             document.getElementById("txtdob").style.border="#ff0000 1px solid";
             document.getElementById("txtdob").style.backgroundColor="#e8ebd9";
             return false;
        }
         else if(document.getElementById("lblparentname").value=="")
         {
             alert("Please enter parent/gaurdian name");
             document.getElementById("lblparentname").focus();
             document.getElementById("lblparentname").style.border="#ff0000 1px solid";
             document.getElementById("lblparentname").style.backgroundColor="#e8ebd9";
             return false;
         }
        
          else if(document.getElementById("lbladdress").value=="")
         {
             alert("Please enter permanent address");
             document.getElementById("lbladdress").focus();
             document.getElementById("lbladdress").style.border="#ff0000 1px solid";
             document.getElementById("lbladdress").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         
         
         
         
         
         
          else if(document.getElementById("txtmobile").value=="")
         {
             alert("Please enter Mobile No");
             document.getElementById("txtmobile").focus();
             document.getElementById("txtmobile").style.border="#ff0000 1px solid";
             document.getElementById("txtmobile").style.backgroundColor="#e8ebd9";
             return false;
         }
        
          else if(document.getElementById("txtemail").value=="")
         {
             alert("Please enter valid E-Mail Address");
             document.getElementById("txtemail").focus();
             document.getElementById("txtemail").style.border="#ff0000 1px solid";
             document.getElementById("txtemail").style.backgroundColor="#e8ebd9";
             return false;
         }   else if(!Validate_Email(document.getElementById("txtemail").value))
         {
             alert("Please Enter the Valid Email-ID");
             document.getElementById("txtemail").focus();
             document.getElementById("txtemail").style.border="#ff0000 1px solid";
             document.getElementById("txtemail").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         
         
         
          else if(document.getElementById("lbldist").value=="")
         {
             alert("Please enter district name");
             document.getElementById("lbldist").focus();
             document.getElementById("lbldist").style.border="#ff0000 1px solid";
             document.getElementById("lbldist").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("lblcityy").value=="")
         {
             alert("Please enter city name");
             document.getElementById("lblcityy").focus();
             document.getElementById("lblcityy").style.border="#ff0000 1px solid";
             document.getElementById("lblcityy").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("lblstate").value=="")
         {
             alert("Please enter state name ");
             document.getElementById("lblstate").focus();
             document.getElementById("lblstate").style.border="#ff0000 1px solid";
             document.getElementById("lblstate").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("lblpincod").value=="")
         {
             alert("Please enter pincode ");
             document.getElementById("lblpincod").focus();
             document.getElementById("lblpincod").style.border="#ff0000 1px solid";
             document.getElementById("lblpincod").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else if(document.getElementById("lblpincod").value!="" && document.getElementById("lblpincod").value.length<6)
         {
             alert("Invalid Pincode (Must have 6 digits)");
             document.getElementById("lblpincod").focus();
             document.getElementById("lblpincod").style.border="#ff0000 1px solid";
             document.getElementById("lblpincod").style.backgroundColor="#e8ebd9";
             return false;
         }  
        
     
         else
         {
         return true;
         }
         
      }    


function btnprint_onclick() {
 javascript:window.print();
}

    </script>
</head>
<body>
<div class="white-cont2">
  <form id="form1" runat="server">
    <h4 class="cont-title4 no-mrg">Personal Details</h4>
    <div class="free-forms padd-cont">
      <div align="center">
        <asp:Label ID="lblerror" runat="server" CssClass="error" Text=''></asp:Label>
      </div>
      <div class="form-cont">
        <ul>
          <li>
            <label class="label-txt">Enquiry no :</label>
            <asp:Label ID="lblenq_id" CssClass="error label-txt2" runat="server" Text=''></asp:Label>
          </li>
          <li>
            <label class="label-txt">Name :</label>
            <asp:TextBox ID="lblname" CssClass="text input-txt" runat="server" ></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Date of Birth :</label>
            <span class="date-pick-cont"><asp:TextBox ID="txtdob"  onpaste="return false" CssClass="datepicker text date-input-txt" runat="server"></asp:TextBox></span>
          </li>
          <li>
            <label class="label-txt">Parent Name</label>
            <asp:TextBox ID="lblparentname"  CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Mobile</label>
            <asp:TextBox ID="txtmobile"  Onkeypress="return isNumberKey(event)" CssClass="text input-txt" runat="server" MaxLength="10"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Email-id</label>
            <asp:TextBox ID="txtemail"  CssClass="text input-txt"  runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Student Photo</label>
            <asp:FileUpload ID="FileUpload1" runat="server" BackColor="Silver" BorderColor="#d1d1d1" BorderStyle="Solid" BorderWidth="1px" CssClass="submit" ForeColor="Maroon" onchange="displayPreview(this.files);" Width="200px" />
            <span id="preview"></span> </li>
        </ul>
        <div class="clear"></div>
        <h4 class="cont-title">Parent Professional Details</h4>
        <ul>
          <li>
            <label class="label-txt">Company</label>
            <asp:TextBox ID="lblcompany"  CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Designation</label>
            <asp:TextBox ID="lbldesignatio"  CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Income</label>
            <asp:TextBox ID="lblincome"  onpaste="return false" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
        </ul>
        <div class="clear"></div>
        <h4 class="cont-title">Contact Details (Permanent)</h4>
        <ul style="padding:0px 0px 40px 0px;">
          <li>
            <label class="label-txt">Address</label>
            <asp:TextBox ID="lbladdress"  MaxLength="95" CssClass="text area-txt" runat="server" TextMode="MultiLine"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">District</label>
            <asp:TextBox ID="lbldist"  CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">City</label>
            <asp:TextBox ID="lblcityy"  CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">State</label>
            <asp:TextBox ID="lblstate"  CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Pincode</label>
            <asp:TextBox ID="lblpincod"  onpaste="return false" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Phone</label>
            <asp:TextBox ID="lblphone"  onpaste="return false" MaxLength="11" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Mobile</label>
            <asp:TextBox ID="lblmobile"  onpaste="return false" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" runat="server" MaxLength="10"> </asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Email-id</label>
            <asp:TextBox ID="lblemailid"  MaxLength="100" CssClass="text input-txt" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Enquired By</label>
            <asp:TextBox ID="txtenq_By" runat="server" CssClass="text input-txt" MaxLength="100"  ReadOnly="True"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Modified By</label>
            <asp:TextBox ID="txtmod_By" runat="server" CssClass="text input-txt" MaxLength="100"  ReadOnly="True"></asp:TextBox>
          </li>
        </ul>
        <div class="clear"></div>
        <ul>
          <li>
            <label class="label-txt">Profile</label>
            <asp:DropDownList ID="ddl_profile" runat="server" CssClass="select sele-txt">
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
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt">Source</label>
            <asp:DropDownList ID="ddl_source" runat="server" CssClass="select sele-txt" >
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
            </asp:DropDownList>
          </li>
          <li>
            <div align="center">
              <input id="btnprint" class="btnStyle5" type="button" value="Print" onclick="return btnprint_onclick()" />
              <asp:Button ID="btn_update" runat="server" Text="Update" CssClass="btnStyle1" OnClientClick="javascript:return update();" OnClick="btn_update_Click" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </form>
</div>
</body>
</html>
