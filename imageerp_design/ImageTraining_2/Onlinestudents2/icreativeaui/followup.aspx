<%@ Page Language="C#" AutoEventWireup="true" CodeFile="followup.aspx.cs" Inherits="superadmin_followup" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Follow Up Page</title>
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
clearValidation('dddesicionstatus~txtremarks');
 if(document.getElementById("dddesicionstatus").value=="")
         {
            
             alert("Please Select the Decision Status");
             document.getElementById("dddesicionstatus").focus();
             document.getElementById("dddesicionstatus").style.border="#ff0000 1px solid";
             document.getElementById("dddesicionstatus").style.backgroundColor="#e8ebd9";
           
             return false;
         }
  else if(trim(document.getElementById("txtremarks").value)=="")
         {
             document.getElementById("txtremarks").value=="";   
             alert("Please Enter the Remarks");
             document.getElementById("txtremarks").focus();
             document.getElementById("txtremarks").style.border="#ff0000 1px solid";
             document.getElementById("txtremarks").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(trim(document.getElementById("txtreminder").value)=="")
         {
             document.getElementById("txtreminder").value=="";   
             alert("Please Enter the Reminder Date");
             document.getElementById("txtreminder").focus();
             document.getElementById("txtreminder").style.border="#ff0000 1px solid";
             document.getElementById("txtreminder").style.backgroundColor="#e8ebd9";
           
             return false;
         }
  else
  {
  return true;
  }
}

function btnreset_onclick() {
location.href="Followup.aspx";
}

</script>
</head>
<body>
<div class="white-cont2">
  <form id="form1" runat="server">
    <h4 class="cont-title4 no-mrg">Student Followup Details
      <asp:Button ID="Button1" runat="server" CssClass="back"  ToolTip="Back" OnClick="Button1_Click" Visible="false" />
    </h4>
    <div class="free-forms">
      <div class="form-cont" style="padding-bottom:15px;">
        <ul>
          <li>
            <label class="label-txt">Student Name :</label>
            <asp:Label ID="lblstuname" runat="server" CssClass="label-txt2"></asp:Label>
          </li>
          <li>
            <label class="label-txt">Student Mobile :</label>
            <asp:Label ID="lblmobile" runat="server" CssClass="label-txt2"></asp:Label>
          </li>
          <li>
            <label class="label-txt">Student Email :</label>
            <asp:Label ID="lblemail" runat="server" CssClass="label-txt2"></asp:Label>
          </li>
          <li>
            <label class="label-txt">Center Code :</label>
            <span class="label-txt2"><%=Session["SA_centre_code"] %></span></li>
          <li>
            <label class="label-txt"> Enquiry No :</label>
            <span class="label-txt2"><%=Request.QueryString["enqno"]%></span></li>
          <li>
            <label class="label-txt">Center Code :</label>
            <span class="label-txt2"><%=Session["SA_centre_code"] %></span></li>
          <li>
            <label class="label-txt">Decision Status :</label>
            <asp:DropDownList ID="dddesicionstatus" runat="server" CssClass="select sele-txt mrg-tp">
              <asp:ListItem Value="">--Select--</asp:ListItem>
              <asp:ListItem Value="Following">Following</asp:ListItem>
              <asp:ListItem Value="Spot enrolled">Spot enrolled</asp:ListItem>
              <asp:ListItem Value="Very prospective">Very prospective</asp:ListItem>
              <asp:ListItem Value="Prospective">Prospective</asp:ListItem>
              <asp:ListItem Value="Not prospective">Not prospective</asp:ListItem>
              <asp:ListItem Value="Fake">Fake</asp:ListItem>
              <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
              <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>
              <asp:ListItem Value="Not Reachable">Not Reachable</asp:ListItem>
              <asp:ListItem Value="RNR">RNR</asp:ListItem>
              <asp:ListItem Value="Wrong Number">Wrong Number</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt">Remarks</label>
            <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" CssClass="text area-txt mrg-tp"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Reminder Date</label>
            <span class="date-pick-cont mrg-tp">
            <asp:TextBox ID="txtreminder" runat="server"  CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
            </span> </li>
          <li class="no-mrg">
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
