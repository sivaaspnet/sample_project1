<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BatchReport.aspx.cs" Inherits="Onlinestudents_superadmin_BatchReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        
        <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center" valign="top"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td colspan="5" align="center" valign="middle"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td align="center" valign="middle"><p><strong>Student  Batch Report</strong></p></td>
            <td width="20%" height="150" align="center" valign="middle" bgcolor="#666666">&nbsp;</td>
          </tr>
        </table></td>
        </tr>
      <tr>
        <td height="35" align="left" valign="middle" style="width: 270px"><strong>&nbsp; Inv.  No :
            <asp:Label ID="lblInv" runat="server"></asp:Label></strong></td>
        <td align="left" valign="middle">&nbsp;</td>
          <td align="left" colspan="3" valign="middle">
              <strong>&nbsp;Enrolment Date : </strong>
              <asp:Label ID="lblEnrDate" runat="server" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td height="35" align="left" valign="middle" style="width: 270px"><strong>&nbsp;Student Name: <asp:Label ID="LblSName" runat="server" Text=""></asp:Label></strong></td>
        <td width="24%" align="left" valign="middle"><strong>
                        &nbsp;Course :
            <asp:Label ID="lblCourse" runat="server" Text=""></asp:Label></strong></td>
        <td style="width: 236px" align="left" valign="middle"><strong>&nbsp;Student Id No:
            <asp:Label ID="lblSId" runat="server" Text=""></asp:Label></strong></td>
          <td align="left" colspan="2" valign="middle">
              <strong>
                        &nbsp;Track :
                  <asp:Label ID="lblTrack" runat="server" Text=""></asp:Label></strong></td>
      </tr>
      <tr>
        <td style="width: 270px">&nbsp;</td>
        <td>&nbsp;</td>
        <td style="width: 236px">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td align="center" valign="top" >
    <table width="100%" border="1" align="center" cellpadding="1" cellspacing="1">
      <tr align="center" valign="top" bgcolor="#FFFFFF" class="text">
        <td width="5%" rowspan="2" class="text"><strong>S.no</strong></td>
        <td rowspan="2" class="text"><strong>Module</strong></td>
        <td rowspan="2" class="text"><strong>Software</strong></td>
        <td width="10%" rowspan="2" class="text"><strong>Batch Code</strong></td>
        <td width="10%" rowspan="2" class="text"><strong>Faculty Name </strong></td>
        <td colspan="3" class="text"><strong>Batch Details</strong></td>
        <td width="10%" rowspan="2" class="text"><strong>Project </strong></td>
        <td colspan="2" class="text"><strong>Test</strong></td>
        </tr>
      <tr align="center" valign="middle" >
        <td width="8%" height="30" class="text"><strong>Timing</strong></td>
        <td width="8%" class="text"><strong>St Date</strong></td>
        <td width="8%" class="text"><strong>En Date</strong></td>
        <td width="6%" class="text"><strong>Mark</strong></td>
        <td class="text"><strong>Date</strong></td>
      </tr>
      
      <%=Session["Htmlbuilder"]%>
      </table>
      </td>
      </tr>
      </table>
    </div>
        
    </form>
</body>
</html>
