<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Popup10.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Popup10" Title="Untitled Page" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>pop up</title>
        
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/jquery-ui-1.8.2.custom.css" />    
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="scripts/main.js"></script> 
    <script type="text/javascript" src="scripts/jquery.rotatingMenu.js"></script>
     <script type="text/javascript">
     function validate()
     {
  
        if((document.getElementById("txtmark").value)=="")
         {
             document.getElementById("txtmark").value=="";   
             alert("Please select mark");
             document.getElementById("txtmark").focus();
             document.getElementById("txtmark").style.border="#ff0000 1px solid";
             return false;
         }
         
      else 
      if((document.getElementById("txtRemarks").value)=="")
         {
             
             document.getElementById("txtRemarks").value=="";
             alert("Please Enter Remarks!");
             document.getElementById("txtRemarks").focus();
             document.getElementById("txtRemarks").style.border="#ff0000 1px solid";
             document.getElementById("txtRemarks").style.backgroundColor="#e8ebd9";
             return false;
         }
         
            else 
            if(document.getElementById("ddl_status").value=="Select")
         {
             
             document.getElementById("ddl_status").focus();
             alert("*Please Select Status!");
             document.getElementById("ddl_status").style.border="#ff0000 1px solid";
             document.getElementById("ddl_status").style.backgroundColor="#e8ebd9";
             document.getElementById("ddl_status").style.backgroundColor="#e8ebd9";
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
<div>
<%-- <table style="WIDTH: 100%">

<tr id="TR2" runat="server">
<td style="HEIGHT: 40px"><STRONG>Module</STRONG></td>
<td style="HEIGHT: 40px"><asp:TextBox id="txtModule" runat="server" CssClass="text" ReadOnly="True" MaxLength="20"></asp:TextBox></td>
<td style="HEIGHT: 40px"></td>
<td style="HEIGHT: 40px"></td>
</tr>
<TR id="TR3" runat="server">
<TD
><STRONG>Project</STRONG></TD>
<TD><asp:TextBox id="TextBox1" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>
<TR>
<TD><STRONG>Project Guided By</STRONG></TD>
<TD><asp:TextBox id="txtproject" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"></asp:TextBox></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>
<TR>
<TD style="HEIGHT: 16px"><STRONG>Send Date</STRONG></TD>
<TD style="HEIGHT: 16px"><asp:TextBox id="txtSenddate" runat="server" ReadOnly="True" CssClass="text datepicker" MaxLength="20"></asp:TextBox></TD>
<TD style="HEIGHT: 16px"></TD>
<TD style="HEIGHT: 16px"></TD>
</TR>

</table>--%>
<table id="certificate" width="100%" runat="server">

<%-- <TR>
<TD style="WIDTH: 358px"><STRONG>Dispatch Date</STRONG></TD>
<TD><asp:TextBox id="txtDispatchdate" ReadOnly="True" runat="server" CssClass="text datepicker" MaxLength="30"></asp:TextBox></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>--%>

</table>
<table style="WIDTH: 100%" id="randd" runat="server">

<TR><TD ><STRONG>Evaluated Date</STRONG></TD>
<TD><asp:TextBox id="txtEvalDate"  ReadOnly="True" runat="server" CssClass="text"  MaxLength="4"></asp:TextBox></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>
<TR>
<TD style=" HEIGHT: 31px"><STRONG>Mark</STRONG></TD>
<TD style="HEIGHT: 31px"><asp:TextBox id="txtmark" onkeypress="return CheckNumeric(event)" runat="server" CssClass="text" MaxLength="3"></asp:TextBox></TD>
<TD style="HEIGHT: 31px"></TD>
<TD style="HEIGHT: 31px"></TD>
</TR>
<TR>
<TD ><STRONG>Remarks</STRONG></TD>
<TD><asp:TextBox id="txtRemarks" runat="server" CssClass="text" MaxLength="200"></asp:TextBox></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>
<TR>
<TD ><STRONG>Status</STRONG></TD>
<TD><asp:DropDownList id="ddl_status" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                </TR>
                                <TR>
                                <TD ><STRONG>Evaluated By</STRONG></TD>
                                <TD><asp:TextBox id="txtEvaluatedBy" ReadOnly="True" runat="server" CssClass="text" MaxLength="30"></asp:TextBox></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                </TR>
                                <tr>
                                <td>
                                    <asp:Button ID="Button1" CssClass="submit" runat="server" Text="Update" OnClick="Button1_Click" OnClientClick="return validate();"  />
                                </td>
                                </tr>
                                </table>
             
 
</div>
</form>
</body>
</html>

