<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="New_Popup.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Popup10" Title="Untitled Page" %>
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
  
        if((document.getElementById("ddl_faculty").value)=="")
         {
             
             alert("Please select Faculty");
             document.getElementById("ddl_faculty").focus();
             document.getElementById("ddl_faculty").style.border="#ff0000 1px solid";
             return false;
         }
         
      else 
      if((document.getElementById("reason").value)=="")
         {
             
             document.getElementById("reason").value=="";
             alert("Please Enter reason!");
             document.getElementById("reason").focus();
             document.getElementById("reason").style.border="#ff0000 1px solid";
             document.getElementById("reason").style.backgroundColor="#e8ebd9";
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

<TR><TD ><STRONG>Faculty Name</STRONG></TD>
<TD>
    <asp:DropDownList ID="ddl_faculty" runat="server">
    </asp:DropDownList></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>
<TR>
<TD style=" HEIGHT: 31px"><STRONG>Compensate on</STRONG></TD>
<TD style="HEIGHT: 31px"><asp:TextBox id="date"  runat="server" CssClass="text" ReadOnly="true" ></asp:TextBox></TD>
<TD style="HEIGHT: 31px"></TD>
<TD style="HEIGHT: 31px"></TD>
</TR>
<TR>
<TD ><STRONG>Time</STRONG></TD>
<TD>
    <asp:DropDownList ID="ddl_batchtime" runat="server">
        <asp:ListItem Value="7AMto9Am">7AM to 9Am</asp:ListItem>
                         <asp:ListItem Value="9AMto11Am">9AM to 11Am</asp:ListItem>
                         <asp:ListItem Value="11AMto1PM">11AM to 1PM</asp:ListItem>
                         <asp:ListItem Value="1PMto3PM">1PM to 3PM</asp:ListItem>
                         <asp:ListItem Value="3PMto5PM">3PM to 5PM</asp:ListItem>
                         <asp:ListItem Value="5PMto7PM">5PM to 7PM</asp:ListItem>
                         <asp:ListItem Value="7PMto9PM">7PM to 9PM</asp:ListItem>
    </asp:DropDownList></TD>
<TD style="HEIGHT: 5px"></TD><TD style="HEIGHT: 5px"></TD>
</TR>
<TR>
<TD ><STRONG>Action</STRONG></TD>
<TD><asp:DropDownList id="ddl_status" runat="server">
                                    <asp:ListItem Value="Force to Close">Force to Close</asp:ListItem>
                                    <asp:ListItem Value="Compensate">Compensate</asp:ListItem>
                             
                                </asp:DropDownList></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                </TR>
                                <TR>
                                <TD ><STRONG>Reason</STRONG></TD>
                                <TD><asp:TextBox id="reason"  runat="server" CssClass="text" MaxLength="30"></asp:TextBox></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                <TD style="HEIGHT: 5px"></TD>
                                </TR>
                                <tr>
                                <td>
                                    <asp:Button ID="Button1" CssClass="submit" runat="server" Text="Compensate" OnClick="Button1_Click" OnClientClick="return validate()"   />
                                </td>
                                </tr>
                                </table>
             
 
</div>
</form>
</body>
</html>

