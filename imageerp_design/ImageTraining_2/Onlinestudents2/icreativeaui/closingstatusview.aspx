<%@ Page Language="C#" AutoEventWireup="true" CodeFile="closingstatusview.aspx.cs" Inherits="superadmin_closingstatusview" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Closing status</title>
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
 var start = document.getElementById("lblenrolldate").value;
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
        var csDate = stDate-toDate;
        //clearValidation('lblenrolldate~lblcseasked~lblcscpositioned')
        if(document.getElementById("lblenrolldate").value=="")
         {
             alert("Please select enrollment date");
             document.getElementById("lblenrolldate").focus();
             document.getElementById("lblenrolldate").style.border="#ff0000 1px solid";
             document.getElementById("lblenrolldate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(csDate < 0)
         {
             alert("Please select valid enrollment date");
             document.getElementById("lblenrolldate").focus();
             document.getElementById("lblenrolldate").style.border="#ff0000 1px solid";
             document.getElementById("lblenrolldate").style.backgroundColor="#e8ebd9";
             return false;
        }
         else if(document.getElementById("txt_courseasked").value=="")
         {
             alert("Please select course asked");
             document.getElementById("txt_courseasked").focus();
             document.getElementById("txt_courseasked").style.border="#ff0000 1px solid";
             document.getElementById("txt_courseasked").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_coursepositioned").value=="")
         {
             alert("Please select course positioned");
             document.getElementById("txt_coursepositioned").focus();
             document.getElementById("txt_coursepositioned").style.border="#ff0000 1px solid";
             document.getElementById("txt_coursepositioned").style.backgroundColor="#e8ebd9";
             return false;
         }
         else 
         {
         return true;
         } 
 }  


function btnprint_onclick()
 {
 javascript:window.print();
}

 </script>
</head>
<body>
<div class="white-cont2">
<form id="form1" runat="server">
  <h4 class="cont-title4 no-mrg">Closing status Details</h4>
  <div class="free-forms padd-cont">
    <div class="dataGrid">
    <div align="center"><asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label></div>
    <table width="100%" class="common2" >
      <tr style="background:#f5f5f5;">
        <td colspan="2">Enquiry no :
          <asp:Label ID="lblenq_id" CssClass="error" runat="server" Text="Label"></asp:Label></td>
      </tr>
      <tr>
        <td>Centre Code</td>
        <td><asp:Label ID="lblcentrecode" CssClass="text" runat="server" Text=''></asp:Label>
        </td>
      </tr>
      <tr style="background:#f5f5f5;">
        <td>Expected Enrollment Date</td>
        <td><span class="date-pick-cont"><asp:TextBox ID="lblenrolldate" onpaste="return false" CssClass="datepicker text date-input-txt" runat="server"></asp:TextBox></span>
        </td>
      </tr>
      <tr>
        <td>Course Asked for:</td>
        <td><asp:DropDownList ID="txt_courseasked" runat="server" CssClass="select sele-txt" Width="162"> </asp:DropDownList></td>
      </tr>
      <tr style="background:#f5f5f5;">
        <td>Course Positioned for:</td>
        <td><asp:DropDownList ID="txt_coursepositioned" runat="server" CssClass="select sele-txt" Width="162"> </asp:DropDownList></td>
      </tr>
      <tr>
        <td colspan="2" align="center" style="text-align:center;"><input id="btnprint" type="button" value="Print" class="btnStyle5" onclick="return btnprint_onclick()" />
          <asp:Button ID="btnupdate" CssClass="btnStyle1" runat="server" Text="Update" OnClientClick="javascript:return update();" OnClick="btnupdate_Click" /></td>
      </tr>
    </table>
    </div>
  </div>
</form>
</div>
</body>
</html>
