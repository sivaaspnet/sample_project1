<%@ Page Language="C#" AutoEventWireup="true" CodeFile="analysisview.aspx.cs" Inherits="analysisview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Analysis View</title>
      <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>		
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
    function Update()
    {
         //clearValidation('lblcoursepositioned~lblfinstatus~lblinterest~lblparentsupport~lblcompetitor~lblabtimage')
         if(document.getElementById("txt_courseasked").value=="")
         {
             alert("Please select the course positioned");
             document.getElementById("txt_courseasked").focus();
             document.getElementById("txt_courseasked").style.border="#ff0000 1px solid";
             document.getElementById("txt_courseasked").style.backgroundColor="#e8ebd9";
             return false;
         }
//         else if(document.getElementById("lblfinstatus").value=="")
//         {
//             alert("Please enter financial status");
//             document.getElementById("lblfinstatus").focus();
//             document.getElementById("lblfinstatus").style.border="#ff0000 1px solid";
//             document.getElementById("lblfinstatus").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         else if(document.getElementById("lblinterest").value=="")
//         {
//             alert("Please enter interest level");
//             document.getElementById("lblinterest").focus();
//             document.getElementById("lblinterest").style.border="#ff0000 1px solid";
//             document.getElementById("lblinterest").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         else if(document.getElementById("lblparentsupport").value=="")
//         {
//             alert("Please enter parent support");
//             document.getElementById("lblparentsupport").focus();
//             document.getElementById("lblparentsupport").style.border="#ff0000 1px solid";
//             document.getElementById("lblparentsupport").style.backgroundColor="#e8ebd9";
//             return false;
//         }
        
         else if(document.getElementById("lblabtimage").value=="")
         {
             alert("Please enter how to do know about image");
             document.getElementById("lblabtimage").focus();
             document.getElementById("lblabtimage").style.border="#ff0000 1px solid";
             document.getElementById("lblabtimage").style.backgroundColor="#e8ebd9";
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
    <form id="form1" runat="server">
    <div>
    <table  class="common">
    <tr><td colspan="2" align="left" style=" padding:0px">
       <h4> Analysis Details </h4>
    </td></tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Label ID="lblerrormsg" runat="server" CssClass="error" Text=''></asp:Label></td>
        </tr>
    <tr><td colspan="2">
        Enquiry No :<asp:Label ID="lblenq_number" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
        <tr>
            <td class="w290 talignleft" style="width: 110px">
                Course Positioned</td>
            <td>
                &nbsp;<asp:DropDownList ID="txt_courseasked" runat="server" CssClass="select">
                
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 110px">
                Financial Status</td>
            <td>
                &nbsp;<asp:TextBox ID="lblfinstatus" CssClass="text" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 110px">
                Interest Level</td>
            <td>
                &nbsp;<asp:TextBox ID="lblinterest" CssClass="text" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 110px">
                Parent Support</td>
            <td>
                &nbsp;<asp:TextBox ID="lblparentsupport" CssClass="text" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 110px"> 
                Competitors Institute</td>
            <td>
                &nbsp;<asp:TextBox ID="lblcompetitor" CssClass="text" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 110px">
                About Image</td>
            <td>
                &nbsp;<asp:TextBox ID="lblabtimage" CssClass="text" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td  style="text-align:center" colspan="2">
                
                <input id="btnprint" class="submit" type="button" value="Print" onclick="return btnprint_onclick()" />
                <asp:Button ID="Btn_update" CssClass="submit" runat="server" Text="Update" OnClientClick="javascript:return Update();" OnClick="Btn_update_Click" /></td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
