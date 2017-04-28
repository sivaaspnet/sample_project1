<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Update_New_Student.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Update_New_Student" Title="Update New Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
  <tr>
    <td align="center" valign="middle"><table width="38%" border="0">
      <tr>
        <td width="35%"><b>Student Id</b></td>
        <td width="65%">&nbsp;<asp:TextBox ID="txtStudentId" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td align="center" valign="middle">
            &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Sumbit" OnClick="btnSubmit_Click" CssClass="submit" />
            </td>
      </tr>
    </table></td>
  </tr>
    <tr>
        <td align="center"  valign="middle">
        </td>
    </tr>
   
  <tr>
  
    <td align="center" valign="middle" style=" padding:0px;"><h4>
        Update New Student</h4></td>
  </tr>
    <tr>
        <td align="center" valign="middle">
            <asp:Label ID="lblerrormsg" runat="server" CssClass="error"></asp:Label>&nbsp;<asp:HiddenField
                ID="HdnId" runat="server" />
        </td>
    </tr>
  <tr>
    <td align="center" valign="middle"><table width="100%" border="0" cellpadding="2" cellspacing="2">
      <tr>
        <td width="16%" height="28"><b>Student Name</b></td>
        <td >&nbsp;<asp:TextBox ID="txt_name" runat="server"></asp:TextBox></td>
        <td width="13%"><b>Course Name</b></td>
        <td style="width: 250px">&nbsp;
            <asp:DropDownList ID="ddlcourse" runat="server">
            </asp:DropDownList>
            </td>
          <td style="width: 86px">
            <asp:Label ID="lblcourse" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td style="height: 18px"><b>Tax</b></td>
        <td style="height: 18px;">&nbsp;<asp:TextBox ID="txttax" runat="server">10.3</asp:TextBox></td>
        <td style="height: 18px"><b>Course Fees</b></td>
        <td style="height: 18px; width: 250px;">&nbsp;<asp:TextBox ID="txtcoursefees" runat="server"></asp:TextBox></td>
          <td style="width: 86px; height: 18px">
          </td>
      </tr>
      <tr>
        <td><b>Invoice No</b></td>
        <td style="">&nbsp;<asp:TextBox ID="txtinvoice" runat="server" Width="142px"></asp:TextBox></td>
        <td><b>No. Installment</b></td>
        <td style="width: 250px">&nbsp;<asp:TextBox ID="txtinstall" runat="server"></asp:TextBox></td>
          <td style="width: 86px">
          </td>
      </tr>
      <tr>
        <td style="height: 28px">         <b> Installment Type</b></td>
        <td style="height: 28px;">&nbsp;<asp:TextBox ID="txtinstalltype" runat="server"></asp:TextBox></td>
        <td style="height: 28px">         <b> Track</b></td>
        <td style="height: 28px; width: 250px;">&nbsp;
            <asp:DropDownList ID="ddltrack" runat="server">
            <asp:ListItem Value="">select</asp:ListItem>
            <asp:ListItem Value="Fast">Fast</asp:ListItem>
            <asp:ListItem Value="Normal">Normal</asp:ListItem>
            </asp:DropDownList></td>
          <td style="width: 86px; height: 28px">
          </td>
      </tr>
      <tr>
        <td> <b>Centre Code</b></td>
        <td >&nbsp;<asp:TextBox ID="txtcentercode" runat="server"></asp:TextBox></td>
        <td><b>Enq. No.</b></td>
        <td style="width: 250px">&nbsp;<asp:TextBox ID="txtenqno" runat="server"></asp:TextBox></td>
          <td style="width: 86px">
          </td>
      </tr>
        <tr>
            <td>
                <strong>Batch time</strong></td>
            <td>
                &nbsp;<asp:TextBox ID="txtbatch" runat="server"></asp:TextBox></td>
            <td>
            </td>
            <td style="width: 250px">
            </td>
            <td style="width: 86px">
            </td>
        </tr>
      <tr>
        <td colspan="4" style="height: 18px"></td>
          <td colspan="1" style="width: 86px; height: 18px">
          </td>
        </tr>
      <tr>
        <td>&nbsp;<b>Temp.Address</b></td>
        <td>&nbsp;<asp:TextBox ID="txttempaddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        <td>&nbsp;<b>Perm.Address</b></td>
        <td style="width: 250px">&nbsp;<asp:TextBox ID="txtpermaddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
          <td style="width: 86px">
          </td>
      </tr>
      <tr>
        <td>&nbsp;<b>Mobile</b></td>
        <td>&nbsp;<asp:TextBox ID="txtmobile" runat="server"></asp:TextBox></td>
        <td>&nbsp;<b>E mail</b></td>
        <td style="width: 250px">&nbsp;<asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
          <td style="width: 86px">
          </td>
      </tr>
        <tr>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5" style="height: 18px" valign="middle">
            </td>
        </tr>
      <tr>
          <td align="center" colspan="5" style="height: 18px" valign="middle">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="submit" OnClick="BtnUpdate_Click"  />
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
</asp:Content>

