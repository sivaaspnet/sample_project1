<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printstudentreport.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReportDetails" Title="Student details" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Invoice Print Page</title>
    <script type="text/javascript" language="javascript">
     window.print();
    </script> 
    <style type="text/css">
    table tr td{
    padding:2px;
    
    }
    </style>
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
</head>
<body>
   <form id="form1" runat="server">
        <table  width="80%" align="center" class="common"  border="1" cellpadding="0" cellspacing="0">
      <tr>
          <td align="center" colspan="1" style="height: 1px" valign="middle">
              <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageTraining_2/Onlinestudents2/images/logo/image-infotainment-limited.png" Height="69px" Width="126px" /></td>
        <td colspan="5" align="center" valign="middle" style="height: 1px">
            <strong style="color: navy; font-size: 18pt; font-variant: normal; text-decoration: none;">Student  Report</strong></td>
        </tr>
            <tr>
                <td align="left" style="width: 170px; height: 2px" valign="middle">
                </td>
                <td align="left" colspan="4" style="height: 2px" valign="middle">
                    <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            </tr>
      <tr id="tr1" runat="server" style="color: #000000">
        <td align="left" valign="middle" style="width: 170px; height: 10px;">
            <strong>Student Name : </strong>
            </td>
        <td align="left" valign="middle" style="height: 10px;" colspan="4">
            <asp:Label ID="LblSName" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
      </tr>
            <tr runat="server" style="color: #000000">
                <td align="left" style="width: 170px; height: 10px" valign="middle">
                    <strong>
                        Student Id No &nbsp;: &nbsp;</strong></td>
                <td align="left" style="height: 10px; font-weight: bold;" valign="middle" colspan="4">
            <asp:Label ID="lblSId" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr runat="server" style="color: #000000">
                <td align="left" style="width: 170px; height: 10px" valign="middle">
                    <strong>Invoice No : &nbsp;</strong></td>
                <td align="left" style="height: 10px" valign="middle" colspan="4">
            <asp:Label ID="lblInv" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            </tr>
      <tr id="tr2" runat="server" style="font-weight: bold; color: #000000">
        <td align="left" valign="middle" style="width: 170px; height: 10px;">
            Enrolment Date : 
              </td>
        <td align="left" valign="middle" style="height: 10px;" colspan="4">
              <asp:Label ID="lblEnrDate" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
      </tr>
            <tr id="Tr5" runat="server" style="color: #000000">
                <td align="left" style="width: 170px; height: 10px" valign="middle">
                    <strong>Course : </strong>
                </td>
                <td align="left" style="height: 10px" valign="middle" colspan="4">
            <asp:Label ID="lblCourse" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            </tr>
            <tr id="Tr6" runat="server" style="color: #000000">
                <td align="left" style="width: 170px; height: 10px" valign="middle">
                    <strong>Track : </strong>
                </td>
                <td align="left" style="height: 10px" valign="middle" colspan="4">
                  <asp:Label ID="lblTrack" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            </tr>
            <tr id="Tr4" runat="server" style="color: #000000">
                <td align="left" colspan="5" style="height: 3px;padding:0px;" valign="middle">
                 <h4>Contact Details</h4>
                </td>
            </tr>
        <tr id="tr3" runat="server">
            <td align="left" style="width: 170px; height: 7px" valign="middle">
                <asp:Label ID="lbl_phone" runat="server" Font-Bold="True" Text="PhoneNumber :"></asp:Label>
                <asp:Label ID="lbl_no" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td align="left" style="height: 7px; width: 205px;" valign="middle">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Mail ID :"></asp:Label>
                <asp:Label ID="lbl_mail" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td align="left" colspan="3" style="height: 7px" valign="middle">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Address :" Visible="False"></asp:Label>
                <asp:Label ID="lbl_add" runat="server" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label></td>
        </tr>
            <tr>
                <td colspan="5" style="height: 25px;padding:0px;">
                <h4> Fees Details</h4>
                </td>
            </tr>
      <tr>
        <td style="width: 170px; height: 25px;">&nbsp;<strong>Course Fee :</strong><asp:Label ID="lbl_coursefees" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        <td style="width: 205px; height: 25px;">&nbsp;<strong>Pending Amount :</strong><asp:Label ID="lbl_pendingamt" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
          <td colspan="3" style="height: 25px">
              <strong>Pending Amount with tax:</strong><asp:Label ID="lbl_pendingwithtax" runat="server"
                    ForeColor="Maroon" Font-Bold="True"></asp:Label>&nbsp;&nbsp;</td>
      </tr>
            <tr>
                <td colspan="5" style="padding:0px;">
                <h4> Batch Details</h4>
                    </td>
            </tr>
            <tr>
                <td colspan="5" align="center" style=" text-align:center;">
                    &nbsp;<asp:GridView CssClass="common"  ID="GridView1" runat="server" AutoGenerateColumns="False" Width="690px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
            <Columns>
                <asp:BoundField DataField="module" HeaderText="module" >
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="batchcode" HeaderText="batchcode" HtmlEncode="False" />
                <asp:BoundField DataField="status" HeaderText="status" HtmlEncode="False" />
                <asp:BoundField HeaderText="Content Status" DataField="content" HtmlEncode="False" />
            </Columns>
        </asp:GridView>
                <asp:LinkButton ID="lnk_inv" runat="server" OnClick="lnk_inv_Click" Font-Bold="True" ForeColor="Green" Width="356px" Visible="False">View Student Invoice</asp:LinkButton>
                </td>
            </tr>
    </table>

 </form>

</body>
</html>
