<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentStatus.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_icreative_studentStatus" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Status Page</title>
<script type="text/javascript" src="scripts/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="scripts/htmltooltip.js"></script>
<script src="scripts/jquery.autocomplete.js" type="text/javascript"></script>
<link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
<link rel="stylesheet" href="styles/jquery.treeview.css" type="text/css" />
<link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
<link type="text/css" rel="stylesheet" media="screen" href="styles/jquery-ui-1.8.2.custom.css" />
<script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
<script type="text/javascript" src="scripts/main.js"></script>
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
function followupval()
{
//clearValidation('ddlstatus~txtremarks');
    if (document.getElementById("<%=ddlstatus.ClientID %>").value == "")
         {
            
             alert("Please Select Student Status");
             document.getElementById("<%=ddlstatus.ClientID %>").focus();
             document.getElementById("<%=ddlstatus.ClientID %>").style.border = "#ff0000 1px solid";
             document.getElementById("<%=ddlstatus.ClientID %>").style.backgroundColor = "#e8ebd9";
           
             return false;
         }
         else if (trim(document.getElementById("<%=ddlstatus.ClientID %>").value) == "Others" && trim(document.getElementById("<%=txtremarks.ClientID %>").value) == "")
         {
             alert("Please Enter the Remarks");
             document.getElementById("<%=txtremarks.ClientID %>").focus();
             document.getElementById("<%=txtremarks.ClientID %>").style.border = "#ff0000 1px solid";
             document.getElementById("<%=txtremarks.ClientID %>").style.backgroundColor = "#e8ebd9";
           
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
<div class="white-cont2">
  <form id="form1" runat="server">
    <h4 class="cont-title4 no-mrg">Student Status</h4>
    <div class="free-forms">
      <asp:Label runat="server" ID="lblmsg" ForeColor="Red"></asp:Label>
      <div class="form-cont">
        <ul>
          <li>
            <label class="label-txt">Student Name:</label>
            <span class="label-txt2"><%=Request.QueryString["studname"]%></span> </li>
          <li>
            <label class="label-txt">Enrollment No:</label>
            <span class="label-txt2"><%=Request.QueryString["enrollno"]%></span> </li>
          <li>
            <label class="label-txt">Course:</label>
            <asp:Label ID="lblcourse_name" runat="server" CssClass="label-txt2"></asp:Label>
          </li>
          <li>
            <label class="label-txt">Status:</label>
            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="select sele-txt">
              <asp:ListItem Value="">--Select--</asp:ListItem>
              <asp:ListItem Value="On Going">On Going</asp:ListItem>
              <asp:ListItem Value="Completed">Completed</asp:ListItem>
              <asp:ListItem Value="Dropout">Dropout</asp:ListItem>
              <asp:ListItem Value="Others">Others</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt">Remarks</label>
            <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" CssClass="text area-txt"></asp:TextBox>
          </li>
          <li>
            <div align="center">
              <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnStyle1" OnClick="btnsubmit_Click" onclientclick="javascript:return followupval();" />
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
