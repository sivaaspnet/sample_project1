<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncentiveDetail.aspx.cs" Inherits="superadmin_IncentiveDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Incentive Details</title>
  <style type="text/css">
@media print {
    #btnPrint {
        display :  none;
    }
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="500" border="0"  style="border: 1px solid black; margin: 12px auto;" cellpadding="0" cellspacing="0" >
	<tr>
	<td>
	<table id="visbkimage" runat="server" border="0" width="500" style="background-repeat:no-repeat;" cellpadding="0" cellspacing="0">
	 
	  <tr>
		<td style="padding-left:338px; padding-top:5px">   
            <strong><span style="font-size: 14pt; text-decoration: underline;">INCENTIVE FORM</span></strong></td>
	  </tr>
	  <tr id="common" runat="server" >
		<td style="text-align: center;">
           
           <table><tbody><tr><td><img alt="Image" src="../layout/image_logo.jpg"></td>
            <td class="style2"> <div style="color: blue;"><span style="font-size:30px; font-weight:bold;">Image Creative Education Pvt. Ltd.</span> </div>
            <div>Head Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div>
            <div>Phone:044-24661682/24670229</div></td><td class="style1"><img alt="Image" src="../layout/logo2.png"></td></tr></tbody></table>
            </td>
	  </tr> 
	  <tr>
	  <td style="height: 221px">

	  <table width="850" id="TABLE1" >
	    <tr><td style="height: 21px; width: 170px;" >
            &nbsp;Student Name :</td>
	  <td style="height: 21px; width: 265px;"   ><b>
          <asp:Label ID="lblstudname" runat="server" Text=''></asp:Label></b></td>
              <td align="right" style="height: 21px; width: 298px;">
                  Date : &nbsp;</td>
              <td style="height: 21px">
              <asp:Label ID="lblDate" runat="server" Text=''></asp:Label>
              </td>
	  </tr> <tr>
    <td style="height: 21px; width: 170px;">
        &nbsp;Student ID&nbsp; :</td>
    <td colspan="3" style="height: 21px">
                  <asp:Label ID="lblstudid" runat="server" Text=''></asp:Label></td>
  </tr>
          <tr>
              <td style="height: 21px; width: 170px;">
                  &nbsp;Centre Code :
              </td>
              <td colspan="3" style="height: 21px">
                  <asp:Label ID="lblcentrecode" runat="server" Text=""></asp:Label>
                  (
                  <asp:Label ID="lbllocation" runat="server" Text=""></asp:Label>
                  )</td>
          </tr>
          <tr>
              <td style="width: 170px; height: 21px">
                  &nbsp;Course Code :
              </td>
              <td colspan="3" style="height: 21px">
                  <asp:Label ID="lblcourse" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 170px; height: 21px">
                  &nbsp;Date of Admission :
              </td>
              <td colspan="3" style="height: 21px">
                  <asp:Label ID="lbldoj" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 170px">
                  &nbsp;Invoice Number :</td>
              <td colspan="3" style="height: 21px">
                  <asp:Label ID="lblinvoiceno" runat="server" Text=""></asp:Label></td>
              
          </tr> 
          <tr> 
                  <asp:Label ID="lblcoursecode" Visible="false" runat="server" Text=''></asp:Label><td style="height: 21px; width: 170px;">
                      &nbsp;Receipt Number :</td>
              <td style="height: 21px; width: 265px;">
                  <asp:Label ID="lblreceiptnum" runat="server" Text=""></asp:Label></td>
              <td style="height: 21px; width: 298px;">
                  </td>
              <td style="height: 21px">
                  &nbsp;</td>
          </tr>
          <tr>
              <td style="height: 21px; width: 170px;">
                  &nbsp;Amount Paid :
              </td>
              <td style="height: 21px; width: 265px;">
                  <asp:Label ID="lblamountpaid" runat="server" Text=""></asp:Label></td>
              <td style="height: 21px; width: 298px;">
                  </td>
              <td style="height: 21px">
                  </td>
          </tr> 
      </table> 
      </td>
      </tr> 
      <tr>
      <td style="height: 210px">     
       <table id="tblreferstudent" runat="server"  style="display:none;" cellpadding="0" width="100%">
        <tr>
                  <td colspan="2" style="height: 19px">
                      <strong>&nbsp;Reference Student Detail :</strong>
                  </td>
              </tr>
         <tr>
            <td style="height: 19px; width: 170px;" >
                &nbsp;Student Name :</td>
             <td style=" height: 19px">
                 <asp:Label ID="lblreferestudentname" runat="server" Text=""></asp:Label></td>
         </tr>
           <tr>
               <td style="width: 13px">
                   &nbsp;Student ID :</td>
               <td >
                   <asp:Label ID="lblreferstudentid" runat="server"></asp:Label></td>
           </tr>
           <tr>
               <td colspan="2">
                  &nbsp;Received a Sum of Rs. _______________ Bearing Cheque No : ___________ Date : _________ Drawn on :  _________________
               </td>
           </tr>
          <tr>
                  <td colspan="2">  
                  <div id="divStud" runat="Server">
                  </div>
                  </td>
              </tr>
       </table>
          <table id="tblreferstaff"  runat="server" style="display:none;" cellpadding="0" width="100%">
              <tr>
                  <td colspan="2" style="height: 19px">
                      <strong>&nbsp;Reference Staff Detail :</strong>
                  </td>
              </tr>
              <tr>
                  <td style="height: 19px; width: 170px;">
                      &nbsp;Staff Name :</td>
                  <td style="height: 19px">
                      &nbsp;<asp:Label ID="lblreferstaffname" runat="server" Text=''></asp:Label></td>
              </tr>              
              <tr>
                  <td colspan="2">
                  &nbsp;Received a Sum of Rs. _______________ Bearing Cheque No : ___________ Date : _________ Drawn on :  _________________
                      
              </tr>
               
        </table>
      </td>
      </tr>   
	   <tr><td align="center" valign="middle" style="min-height:120px;vertical-align:middle;">
           <div style="min-height:120px;"> 
               <table border="0" cellpadding="0" width="100%">
                   <tr>
                       <td style="height: 19px;width:30%;">&nbsp;
                           <strong>Approved by : <asp:Label ID="lblapprove" runat="server" Text=""></asp:Label></strong></td>
                       <td style="height: 19px;width:30%;">
                           </td>
                       <td align="left" style="height: 19px;width:40%;" valign="middle">
                           &nbsp; <strong>Issued by : <asp:Label ID="lblpayment" runat="server" Text=""></asp:Label></strong></td>
                   </tr> 
               </table>
        </div>
          
	</td></tr>
	  <tr>
	    <td style="text-align:center"> 
	    <input id="btnPrint" class="submit"   onclick="javascript:window.print();" type="button" value="Print" />&nbsp;
                 
	    </td>
	  </tr>
	</table>
	</td>
	</tr>
</table>
    <asp:HiddenField ID="hdnicID" runat="server" />
    </div>
    </form>
</body>
</html>
