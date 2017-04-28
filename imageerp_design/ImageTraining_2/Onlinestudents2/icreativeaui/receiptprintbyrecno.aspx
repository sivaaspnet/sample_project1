<%@ Page Language="C#" AutoEventWireup="true" CodeFile="receiptprintbyrecno.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_receiptprintbyrecno" %>
 
<
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Receipt Print </title>
<script type="text/javascript">

function breakout_of_frame()
{

  if (top.location != location) {
   top.location.href = window.parent.location.href  ;
  }
}

</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="800"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="menu_text"></td>
  </tr>
  <tr>
    <td bgcolor="#000000"></td>
  </tr>
</table>
        <asp:HiddenField ID="HiddenField1" runat="server" />
<table width="800" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000">
  <tr>
    <td >
    <table  border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000" style="width: 750px">
      <tr>
        <td width="700px" style="height: 600px">
        <table width="700px"  border="0">
          <tr>
            <td width="200" ><img src="../layout/image_logo.jpg" width="178" height="95" /></td>
            <td width="500px"><table width="100%" align="CENTER">
              <tr>
                <td class="style3 style5"><div align="" class="style5 style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; Image Infotainment Limited</strong></div></td>
              </tr>
              <tr >
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div></td>
              </tr>
              <tr >
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone:044-24661682/24670229 Fax:044-42737755 </div></td>
              </tr>
              <%--<tr id="Adyar" runat="server" visible="false">
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regd. Office : 73,Dr.Muthulakshmi Salai,L.B.Road,Adyar,Chennai-600020.</div></td>
              </tr>
              <tr id="Adyar1" runat="server" visible="false">
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone:044-24426386/42607850 Fax:044-42737755 </div></td>
              </tr>
              <tr id="Annanagar" runat="server" visible="false">
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regd. Office : AC-7,2nd Avenue,Anna Nagar,Chennai-600040.</div></td>
              </tr>
              <tr id="Annanagar1" runat="server" visible="false">
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone:044-42611913/26211137 Fax:044-42737755 </div></td>
              </tr>
              <tr id="Velachery" runat="server" visible="false">
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regd. Office : 137,LIC Colony Main Road,Velacherry,Chennai-600041.</div></td>
              </tr>
              <tr id="Velachery1" runat="server" visible="false">
                <td class="style3"><div align="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone:044-42334005/42334006 Fax:044-42737755 </div></td>
              </tr>--%>
            </table>
            </td>
          </tr>
        </table>
              <table width="700px">
                <tr>
                  <td width="140"><table>
                    <tr>
                        <td width="48">R.No<strong>:</strong></td>
                      <td width="80" height="26">
                      
                      <table width="80"  cellpadding="0" cellspacing="0" style="border-bottom:1px solid #333;" >
                         <tr>
                              <td style="height: 19px"><asp:Label ID="lbl_recpno" runat="server" Text=''></asp:Label></td>
                            </tr>
                        </table>
                          </td>
                    </tr>
                      <tr>
                        <td>Inv.No<strong>:</strong></td>
                        
                        <td height="26"><table width="80" cellpadding="0" cellspacing="0" style="border-bottom:1px solid #333;">
                            
                            <tr>
                              <td style="height: 25px"><asp:Label ID="lbl_invoice" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table>
                      <asp:Label ID="lblstudid" runat="server" Text='' Visible="false"></asp:Label></td>
                  <td width="282" align="center"><strong><u>RECEIPT</u></strong></td>
                  <td width="286"><table width="283">
                      <tr>
                        <td width="98">Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>:</strong></td>
                        <td width="127" height="26"><table width="140" height="25" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                  <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td>Course Code <strong>:</strong> </td>
                        <td height="26"><table width="140" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                            <tr>
                              <td>
                                  <asp:Label ID="lbl_coursecode" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle">
                          <strong>RECEIVED</strong> with thanks from Mr. / Mrs. / Ms&nbsp;
                          <asp:Label ID="lbl_studname" runat="server" Font-Bold="True"></asp:Label>
                          the sum of Rs.
                          <asp:Label ID="lbl_sum" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                           /-(Rupees
                      </td>
                  </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle">
                          <asp:Label ID="lbl_inwords" runat="server" Text=""></asp:Label>
                          )&nbsp; through 
                          <asp:Label ID="lbl_ddcc" runat="server" Font-Bold="True"></asp:Label>
                          </td>
                  </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle">
                          <asp:Label ID="lbl_Bank" runat="server" Visible="False"></asp:Label><asp:Label ID="lbl_BankName"
                              runat="server" Font-Bold="True" Visible="False"></asp:Label>
                          being payment towards
                          <asp:Label ID="lbl_paymenttowards" runat="server" Font-Bold="True"></asp:Label>&nbsp; &nbsp;for the Month of
                          <asp:Label ID="lbl_monthinstallment" runat="server" Font-Bold="True"></asp:Label></td>
                  </tr>
              </table>
          <table border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td><strong>Payment Details :- </strong></td>
            </tr>
          </table>
          <table width="700px" style="height:150px;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="200" style="height:150px;">
                  <table width="191" height="97" border="1" cellpadding="0" cellspacing="0" bordercolor="#000000">
                      <tr>
                        <td width="187" height="95"><table width="176" height="79" border="0" cellspacing="0" align="center" >
                            <tr>
                              <td height="23"><strong>Fees Rs. </strong></td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                                  <tr>
                                    <td style="height: 25px">
                                        <asp:Label ID="lbl_fees" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td width="74" height="29"><strong>Tax&nbsp; </strong></td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0">
                                  <tr>
                                    <td>
                                        <asp:Label ID="lbl_tax" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td><strong>Total Rs. </strong> </td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                                  <tr>
                                    <td>
                                        <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                  <td width="510" style="height: 150px" ><table width="357" height="116" border="0" cellspacing="0" align="right" >
                      <tr>
                        <td align="center">For <strong>Image Infotainment Limited</strong>
                            <table width="" align="right">
                          </table></td>
                      </tr>
                      <tr>
                        <td width="355" height="37">&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">Authorized Signatory</td>
                     
                      </tr>
                  </table></td>
                </tr>
              </table>
          <table>
            <tr>
                  <td>*Cheque Subject to realization</td>
            </tr>
                <tr>
                  <td>*Fees Once Paid will not be refunded </td>
                </tr>
          </table>
            <tr>
                        <td align="left">
                        <%--<div style="color: blue;"><span style="font-size:30px; font-weight:bold;">Image Infotainment Limited</span> </div>--%>
            &nbsp;<div id="Alwarpet" runat="server" visible="false">
                <strong>32,T.T.K Road,Alwarpet,Chennai-600018.Phone:044-24661682/24670229</strong></div>
            <%--<div id="Alwarpet1" runat="server" visible="false"></div>--%>
            &nbsp;<div id="Adyar" runat="server" visible="false">
                <strong>73,Dr.Muthulakshmi Salai,L.B.Road,Adyar,Chennai-600020.Phone:044-24426386/42607850</strong></div>
            <%--<div id="Adyar1" runat="server" visible="false"></div>--%>
            &nbsp;<div id="Annanagar" runat="server" visible="false">
                <strong>AC-7,2nd Avenue,Anna Nagar,Chennai-600040.Phone:044-42611913/26211137</strong></div>
            <%--<div id="Annanagar1" runat="server" visible="false"></div>--%>
            &nbsp;<div id="Velachery" runat="server" visible="false">
                <strong>137,LIC Colony Main Road,Velachery,Chennai-600041.Phone:044-42334005/42334006</strong></div>
                &nbsp;<div id="Ganganagar" runat="server" visible="false">
                <strong>VNxTL Tech Services Pvt Ltd.LAV Arcade,79 Bellary Road,Ganga Nagar,Bangalore–560032.Phone:080-40340000</strong></div>
                &nbsp;<div id="calicut" runat="server" visible="false">
                <strong>Image Infotainment Ltd 7th Floor, Sky Tower Mavoor road Jn,Calicut-1</strong></div>
            <%--<div id="Velachery1" runat="server" visible="false"></div>--%>
                        </td>
                    </tr>
            <tr>
            <td align="center" valign="middle">
                    <input id="Button1" class="submit" onclick="window.open('Receiptprintpage.aspx?studid=<%=lblstudid.Text%>&recptno=<%=lbl_recpno.Text%>&page=<%=HiddenField1.Value%>','PrintMe','height=500px,width=600px,scrollbars=1')"
                        type="button" value="Print" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="javascript:return breakout_of_frame();"
                        Text="View Receipt Details" />
                </td>
            </tr>
        </table>
          </tr>
          
</table>
    
    </div>
    </form>
</body>
</html>


<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Receipt Print </title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="800"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="menu_text"></td>
  </tr>
  <tr>
    <td bgcolor="#000000"></td>
  </tr>
</table>
<table width="800" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000">
  <tr>
    <td >
    <table width="730"  border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000">
      <tr>
        <td width="726" style="height: 741px">
        <table width="720"  border="0">
          <tr>
            <td width="291" ><img src="../layout/image_logo.jpg" width="178" height="95" /></td>
            <td width="419"><table width="419" align="CENTER">
              <tr>
                <td width="411" class="style3 style5"><div align="center" class="style5 style1"><strong> Image Infotainment Limited</strong></div></td>
              </tr>
              <tr>
                <td class="style3"><div align="center">Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div></td>
              </tr>
              <tr>
                <td class="style3"><div align="center">Phone:044-24661682/24670229 Fax:044-42737755 </div></td>
              </tr>
            </table></td>
          </tr>
        </table>
              <table width="724">
                <tr>
                  <td width="140"><table>
                    <tr>
                        <td width="48">R.No<strong>:</strong></td>
                      <td width="80" height="26">
                      
                      <table width="80"  cellpadding="0" cellspacing="0" style="border-bottom:1px solid #333;" >
                         <tr>
                              <td style="height: 19px"><asp:Label ID="lbl_recpno" runat="server" Text=''></asp:Label></td>
                            </tr>
                        </table>
                          </td>
                    </tr>
                      <tr>
                        <td>Inv.No<strong>:</strong></td>
                        
                        <td height="26"><table width="80" cellpadding="0" cellspacing="0" style="border-bottom:1px solid #333;">
                            
                            <tr>
                              <td style="height: 25px"><asp:Label ID="lbl_invoice" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table>
                      <asp:Label ID="lblstudid" runat="server" Text='' Visible="false"></asp:Label></td>
                  <td width="282" align="center"><strong><u>RECEIPT</u></strong></td>
                  <td width="286"><table width="283">
                      <tr>
                        <td width="98">Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>:</strong></td>
                        <td width="127" height="26"><table width="140" height="25" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                  <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td>Course Code <strong>:</strong> </td>
                        <td height="26"><table width="140" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                            <tr>
                              <td>
                                  <asp:Label ID="lbl_coursecode" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                      <td colspan="3" style="height: 30px" valign="middle">
                          <strong>RECEIVED</strong> with thanks from Mr. / Mrs. / Ms&nbsp;
                          <asp:Label ID="lbl_studname" runat="server" Font-Bold="True"></asp:Label>
                          the sum of Rs.
                          <asp:Label ID="lbl_sum" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                           /-(Rupees
                      </td>
                  </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle">
                          <asp:Label ID="lbl_inwords" runat="server" Text=""></asp:Label>&nbsp; through 
                          <asp:Label ID="lbl_ddcc" runat="server" Font-Bold="True"></asp:Label>
                          Dated
                          <asp:Label ID="lbl_paydate" runat="server" Font-Bold="True"></asp:Label>
                          </td>
                  </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle">
                          Bank
                          <asp:Label ID="lbl_bankname" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                          being payment towards
                          <asp:Label ID="lbl_paymenttowards" runat="server" Font-Bold="True"></asp:Label>&nbsp; Instalment
                          Month
                          <asp:Label ID="lbl_monthinstallment" runat="server" Font-Bold="True"></asp:Label></td>
                  </tr>
              </table>
          <table border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td><strong>Payment Details :- </strong></td>
            </tr>
          </table>
          <table width="719" height="131" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="9">&nbsp;</td>
                  <td width="200"><table width="191" height="97" border="1" cellpadding="0" cellspacing="0" bordercolor="#000000">
                      <tr>
                        <td width="187" height="95"><table width="176" height="79" border="0" cellspacing="0" align="center" >
                            <tr>
                              <td height="23"><strong>Fees Rs. </strong></td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                                  <tr>
                                    <td style="height: 25px">
                                        <asp:Label ID="lbl_fees" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td width="74" height="29"><strong>Tax&nbsp; </strong></td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0">
                                  <tr>
                                    <td>
                                        <asp:Label ID="lbl_tax" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td><strong>Total Rs. </strong> </td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                                  <tr>
                                    <td>
                                        <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                  <td width="510" height="129"><table width="357" height="116" border="0" cellspacing="0" align="right" >
                      <tr>
                        <td align="center">For <strong>Image Infotainment Limited</strong>
                            <table width="" align="right">
                          </table></td>
                      </tr>
                      <tr>
                        <td width="355" height="37">&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">Authorized Signatory</td>
                     
                      </tr>
                  </table></td>
                </tr>
              </table>
          <table>
            <tr>
                  <td>*Cheque Subject to realization</td>
            </tr>
                <tr>
                  <td>*Fees Once Paid will not be refunded </td>
                </tr>
          </table>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <input id="Button1" type="button" value="Print" class="submit"  onclick="window.open('Receiptprintpage.aspx?studid=<%=lblstudid.Text%>&recptno=<%=lbl_recpno.Text%>','PrintMe','height=500px,width=600px,scrollbars=1')" />
        <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return breakout_of_frame();" OnClick="Button2_Click" Text="View Receipt Details" /></td>
  </tr>
</table>
    
    </div>
    </form>
</body>
</html>--%>
