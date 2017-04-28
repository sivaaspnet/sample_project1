<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ipad-InvoiceDetails.aspx.cs" Inherits="superadmin_InvoiceDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Invoice Details</title>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="500" border="0"  style="border: 1px solid black; margin: 12px auto;" cellpadding="0" cellspacing="0" >
	<tr>
	<td>
	<table id="visbkimage" runat="server" border="0" width="500" style="background-repeat:no-repeat;" cellpadding="0" cellspacing="0">
	 
	  <tr>
		<td style="padding-left:375px; padding-top:5px">   
            <strong><span style="font-size: 14pt; text-decoration: underline;">
            INVOICE</span></strong></td>
	  </tr>
	  <tr>
		<td style="text-align: center;">
           
            <img src="../layout/image_logo.jpg" alt="Image" />
            <%--<div style="color: blue;"><span style="font-size:30px; font-weight:bold;">Image Infotainment Limited</span> </div>
            <div id="Alwarpet" runat="server" visible="false">Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div>
            <div id="Alwarpet1" runat="server" visible="false">Phone:044-24661682/24670229</div>
            <div id="Adyar" runat="server" visible="false">Regd. Office : 73,Dr.Muthulakshmi Salai,L.B.Road,Adyar,Chennai-600020.</div>
            <div id="Adyar1" runat="server" visible="false">Phone:044-24426386/42607850</div>
            <div id="Annanagar" runat="server" visible="false">Regd. Office : AC-7,2nd Avenue,Anna Nagar,Chennai-600040.</div>
            <div id="Annanagar1" runat="server" visible="false">Phone:044-42611913/26211137</div>
            <div id="Velachery" runat="server" visible="false">Regd. Office : 137,LIC Colony Main Road,Velacherry,Chennai-600041.</div>
            <div id="Velachery1" runat="server" visible="false">Phone:044-42334005/42334006</div>--%>
            <div style="color: blue;"><span style="font-size:30px; font-weight:bold;">Image Infotainment Limited</span> </div>
            <div>Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div>
            <div>Phone:044-24661682/24670229</div>
            </td>
	  </tr>
	    <%--<tr>
		<td><table width="850">
		<tr><td ><div style="color: blue;"><h3 style="font-size:25px;padding-left:265px">Image Infotainment Limited</h3> </div></td>
		</tr><tr><td style="padding-left:265px"><div>Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div></td></tr><tr><td style="padding-left:350px"><div>Phone:044-24661682/24670229</div></td></tr></table>		</td>
	  </tr>--%>
	
	  <tr><td>

	  <table width="850" id="TABLE1">
	    <tr><td >Student Name:</td>
	  <td  colspan="3"><b>
          <asp:Label ID="lblstudname" runat="server" Text=''></asp:Label></b></td>
	  </tr> <tr>
    <td style="height: 21px">Address :</td>
    <td colspan="3" style="height: 21px">
        <asp:Label ID="lbladdress" runat="server" Text=''></asp:Label></td>
  </tr>
          <tr>
              <td>
                  Phone:</td>
              <td >
                  <asp:Label ID="lblphone" runat="server" Text=''></asp:Label></td>
                  <td>
                  Date:</td>
              <td>
              <asp:Label ID="lblDate" runat="server" Text=''></asp:Label>
              </td>
          </tr>
          <%--<tr>
              <td>
                  Course Name:
              </td>
              <td style="font-size:smaller;">
                  <asp:Label ID="lblcoursecode" runat="server" Text=''></asp:Label></td>
              <td>
                  Track:</td>
              <td>
              <asp:Label ID="lbltrack" runat="server" Text=''></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  Course ID :</td>
              <td>
                  <asp:Label ID="lblcourse_id" runat="server" Text=''></asp:Label></td>
              <td>
                  Batch Time:</td>
              <td>
                  <asp:Label ID="lblbatchtime" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
              <td>
                  Center:</td>
              <td>
                  <asp:Label ID="lblcentre" runat="server" Text=''></asp:Label>
                  (<asp:Label ID="lbl_centrename" runat="server"></asp:Label>)</td>
              <td>
                  Course Fees:</td>
              <td>
                  <asp:Label ID="lblcoursefee" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
              <td>
                  Student ID No. :</td>
              <td>
                  <asp:Label ID="lblstudid" runat="server" Text=''></asp:Label></td>
              <td>
                  Tax (10.3 %)</td>
              <td>
                  <asp:Label ID="lbltax" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td>
                  Invoice Number</td>
              <td>
                  <asp:Label ID="lblinvoiceno" runat="server" Text=''></asp:Label></td>
              <td>
                  No of Installments:</td>
              <td>
                  <asp:Label ID="lblnoofinstal" runat="server" Text=''></asp:Label></td>
          </tr>--%>
          
          <tr>
              <%--<td>
                  Course Name:
              </td>
              <td>--%>
                  <asp:Label ID="lblcoursecode" Visible="false" runat="server" Text=''></asp:Label><%--</td>--%><td style="height: 21px">
                  Course Code :</td>
              <td style="height: 21px">
                  <asp:Label ID="lblcourse_id" runat="server" Text=''></asp:Label></td>
              <td style="height: 21px">
                  Track:</td>
              <td style="height: 21px">
              <asp:Label ID="lbltrack" runat="server" Text=''></asp:Label>
              </td>
          </tr>
          <tr>
              <td style="height: 21px">
                  Center:</td>
              <td style="height: 21px">
                  <asp:Label ID="lblcentre" runat="server" Text=''></asp:Label>(<asp:Label ID="lbl_centrename"
                      runat="server"></asp:Label>)</td>
              <td style="height: 21px">
                  Batch Time:</td>
              <td style="height: 21px">
                  <asp:Label ID="lblbatchtime" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
               <td style="height: 21px">
                  Student ID No. :</td>
              <td style="height: 21px">
                  <asp:Label ID="lblstudid" runat="server" Text=''></asp:Label></td>
              <td style="height: 21px">
                  Course Fees:</td>
              <td style="height: 21px">
                  <asp:Label ID="lblcoursefee" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
             <td>
                  Invoice Number</td>
              <td>
                  <asp:Label ID="lblinvoiceno" runat="server" Text=''></asp:Label></td>
              <td>
                  Tax (10.3 %)</td>
              <td>
                  <asp:Label ID="lbltax" runat="server"></asp:Label></td>
          </tr>
          <tr id="insvisfal" runat="server" visible="false">
              
              <td>
                  No of Installments:</td>
              <td>
                  <asp:Label ID="lblnoofinstal" runat="server" Text=''></asp:Label></td>
          </tr>
      </table></td></tr>
	   <tr><td align="center" valign="middle" style="height: 279px" >
           <br />
           <div style=" min-height:450px;">
	    <asp:GridView width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#AEAEAE" BorderWidth="1px" BorderStyle="Solid">
               <Columns>
                   <asp:TemplateField HeaderText="Installment Number"><ItemTemplate>
                    <%#Eval("installNumber")%>
                   </ItemTemplate>
                       <HeaderStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Installment Due Date" ><ItemTemplate> <%#Eval("installdate")%></ItemTemplate>
                       <HeaderStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Amount to be paid"><ItemTemplate><%#Eval("initialAmount")%></ItemTemplate>
                       <HeaderStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Tax"><ItemTemplate><%#Eval("initialAmountTax")%></ItemTemplate>
                       <HeaderStyle Width="100px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="100px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Total Amount Payable"><ItemTemplate><%#Eval("totinittax")%></ItemTemplate>
                        <HeaderStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>
                   <asp:TemplateField HeaderText="Receipt No"><ItemTemplate><%#Eval("receiptNo")%></ItemTemplate>
                       <HeaderStyle Width="125px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="125px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Amount Paid"><ItemTemplate><%#Eval("totalamtpaid")%></ItemTemplate>
                       <HeaderStyle Width="125px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="125px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Date"><ItemTemplate><%#Eval("date")%></ItemTemplate>
                       <HeaderStyle Width="100px" HorizontalAlign="Left" VerticalAlign="Top" />
                       <ItemStyle Width="100px" HorizontalAlign="Left" VerticalAlign="Middle" />
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>
               <br />
               <table border="0" cellpadding="0" width="100%">
                   <tr>
                       <td style="height: 19px;width:30%;">
                           </td>
                       <td style="height: 19px;width:30%;">
                           </td>
                       <td align="left" style="height: 19px;width:40%;" valign="middle">
                           &nbsp;
                           Total Amount Paid :
                           <asp:Label ID="lblamtpaid" runat="server" Font-Bold="True"></asp:Label></td>
                   </tr>
                   
               </table>
        </div>
          
	</td></tr>
	  <tr>
	    <td><table width="812" height="320" border="0" cellpadding="0" cellspacing="0" align="center">
          <tr>
            <td colspan="8" valign="top"><table width="807" border="0"  cellspacing="0" >
                <tr>
                  <td>
                  <br />
                  <br />
                  <table width="811" border="0"cellpadding="0">
                      <tr>
                        <td style="width: 520px;">
                            <table border="0" cellspacing="0">
                              <tr>
                                <td><table>
                                </table></td>
                              </tr>
                              <tr>
                                <td></td>
                              </tr>
                              <tr>
                                <td></td>
                              </tr>
                              <tr>
                                <td><strong>
                                    <br />
                                    Student  Signature</strong></td>
                              </tr>
                          </table>
                            &nbsp;</td>
                        <td></td>
                        <td><table border="0" cellspacing="0">
                            <tr>
                              <td>For <strong>Image Infotainment Limited</strong></td>
                            </tr>
                            <tr>
                              <td style="width:355;height:60px">
                              </td>
                            </tr>
                            <tr align="center" valign="middle">
                              <td><strong>Authorised Signatory</strong></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                </tr>
            </table>
                <table width="800">
                    
                    <tr>
                        <td align="left">
                            <strong><span style="font-size: 10pt">TERMS &amp; CONDITIONS :</span></strong></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span style="font-size: 9pt">1.Fees Once Paid will not be refunded</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span style="font-size: 9pt">2.Monthly Installments Should be paid on due date (Even
                                During Break)</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span style="font-size: 9pt">3.Cheque/DD should be drawn in favour of <strong>Image
                                Infotainment Ltd</strong>.,</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span style="font-size: 9pt">4.Cheque Returned Charges Rs.200</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span style="font-size: 9pt">5.Course Fees should be paid on or before 10th of every
                                month.A fine of Rs. 100/- will be charged from 11th to 15th of respective month,
                                after which he/she</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span style="font-size: 9pt">&nbsp;&nbsp; would not be allowed to attend classes.</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_address" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr style="text-align: center;"  runat="server" id="print">
                        <td style="text-align: center; vertical-align:text-bottom">
                           <input id="Button1" class="submit"   onclick="window.open('Invoiceprint.aspx?invno=<%=lblinvoiceno.Text%>','PrintMe','height=500px,width=600px,scrollbars=1')" type="button"
                                value="Print" />
                            <asp:Button ID="btnhme" runat="server" CssClass="submit" OnClick="btnhme_Click" Text="View Admission" /></td>
                    </tr>
                </table>
            </td>
          </tr>
        </table></td>
	  </tr>
	</table>
	</td>
	</tr>
</table>
    <asp:HiddenField ID="hdninvoiceID" runat="server" />
    </div>
    </form>
</body>
</html>
