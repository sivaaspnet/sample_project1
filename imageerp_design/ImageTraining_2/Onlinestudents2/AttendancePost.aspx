<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/Mainmasterpage.master" AutoEventWireup="true" CodeFile="AttendancePost.aspx.cs" Inherits="superadmin_AttendancePost" Title="Attendance Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
 function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}


onKeyPress="return CheckNumeric(event)"       
	        
   function clearValidation(fieldList)
    {
	
	    var field=new Array();
	    field=fieldList.split("~");
	    var counter=0;
	    for(i=0;i<field.length;i++)
	     {
		    if(document.getElementById(field[i]).value!="") 
		    {
			    document.getElementById(field[i]).style.border="#999999 1px solid";
			    document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		    }
		}
    } 
    function lab()
    {
    clearValidation('ctl00_ContentPlaceHolder1_txt_labname~ctl00_ContentPlaceHolder1_txt_systems')
      if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the lab name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter number of systems!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
    
function Reset1_onclick() {
location.href="Addlab.aspx";
}

</script>
    <table class="common">
        <tr>
            <td  style="padding:0px">
            <h4>Attendance</h4>

            </td>
        </tr>
        <tr><td style="text-align:center;color:Red;">
        <strong>Attendance Posted Successfully</strong></td>
    </tr></table>
</asp:Content>

