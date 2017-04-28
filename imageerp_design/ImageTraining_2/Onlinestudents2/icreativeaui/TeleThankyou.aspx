<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="TeleThankyou.aspx.cs" Inherits="Onlinestudents2_superadmin_TeleThankyou" Title="Thankyou Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--Follow up  start-->
    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
       
        <table style="width:300;  margin:auto;"  border="1"   > 
            <tr>
                <td colspan="6" style="padding:0px; " ><h4 style="text-align:center;">Thank you for the Enquiry</h4>
                </td>
            </tr>
            <tr>
                <td style="width: 162px; height: 31px; text-align:center" >
                 <asp:Button ID="btnenquiry" runat="server" CssClass="btnStyle1" OnClick="btnenquiry_Click"
                        Text="New Enquiry" /></td>
                <td colspan="2" style="width: 162px; height: 31px; text-align:center">
                    <asp:Button ID="btnviewdetails" runat="server" CssClass="btnStyle1" OnClick="btnviewdetails_Click"
                        Text="View Enquiry Details" /></td>
                        <td style="width: 162px; height: 31px; text-align:center" >
                 <asp:Button ID="btnWalkin" runat="server" CssClass="btnStyle1"  
                        Text="Walkin Enquiry" OnClick="btnWalkin_Click"   /></td>
                <td style="width: 162px; height: 31px; text-align:center" >
                 <asp:Button ID="btnregistration" runat="server" CssClass="btnStyle1"  
                        Text="Registration" OnClick="btnregistration_Click" /></td>
                   <td style="width: 162px; height: 31px; text-align:center" >
                 <asp:Button ID="btnerollment" runat="server" CssClass="btnStyle1"  
                        Text="Express Enrollment" OnClick="btnerollment_Click"  /></td>
                         
            </tr>
          
        </table>
        </div>
    <br />
    <br />

</asp:Content>

