<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receiptprintpage1.aspx.cs" Inherits="Onlinestudents2_superadmin_Receiptprintpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <script type="text/javascript" language="javascript">
     window.print();

    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
<table width="800px" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td style="border:0" >
    <table width="800px"  border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td style="height: 550px; width: 100%;">
            <table  border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000" style="width: 100%">
      <tr>
        <td style="height: 550px; width: 100%;">
        <table width="100%"  border="0">
        <tr>
        <td colspan="2" align="center" valign="middle">
            <strong><span style="font-size: 14pt">RECEIPT</span></strong></td>
        </tr>
          <tr>
            <td width="200px" ><img src="../layout/image_logo.jpg" width="178" height="95" /></td>
            <td width="600px"><table align="CENTER" style="width: 100%">
              <tr>
                <td class="style3 style5" align="center" valign="middle">
                    <div class="style5 style1">
                        <span style="font-size: 16pt"><strong>&nbsp; &nbsp;<span style="font-size: 18pt">VNXTL
                            TECH SERVICES PVT LTD<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></strong></span></div>
                </td>
              </tr>
              <tr>
                <td class="style3" align="left" valign="middle">
                    <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                        <span style="font-size: 9pt; font-family: 'Arial','sans-serif'">LAV Arcade,
                            <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml namespace="" prefix="ST1" ?><st1:street w:st="on"></st1:street><st1:address w:st="on"></st1:address>#79, Bellary Road, Ganga Nagar,
                            <st1:city w:st="on"></st1:city>
                            <st1:place w:st="on"></st1:place>
                            Bangalore 560 032. Ph: 4128 4111<o:p></o:p></span></p>
                </td>
              </tr>
              <tr>
                <td class="style3" align="center" valign="middle">
                    <span style="font-size: 9pt; font-family: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Service Tax Regn. No: AADCV5893NST001</span></td>
              </tr>
              
            </table></td>
          </tr>
        </table>
              <table width="100%" id="TABLE1">
                <tr>
                  <td width="140px"><table>
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
                  </table></td>
                  <td width="225px" align="center">&nbsp;</td>
                  <td width="425px"><table style="width: 100%">
                      <tr>
                        <td style="width: 65px" >Date &nbsp;&nbsp; &nbsp; <strong>:</strong></td>
                        <td height="26"><table width="140" height="25" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                  <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td style="width: 65px">Course <strong>:</strong> </td>
                        <td height="26"><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
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
                          <asp:Label ID="lbl_inwords" runat="server" Text=""></asp:Label>&nbsp; ) through 
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
          <table width="100%" style="height:110px;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td style="width: 9px">&nbsp;</td>
                  <td width="200" style="height:125px;"><table width="191" height="97" border="1" cellpadding="0" cellspacing="0" bordercolor="#000000">
                      <tr>
                        <td width="187" height="75px"><table width="176" height="75px" border="0" cellspacing="0" align="center" >
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
                  <td width="510px" height="150px"><table width="357" height="116" border="0" cellspacing="0" align="right" >
                      <tr>
                        <td align="center">For <strong>Image Infotainment Limited</strong>
                            <table style="text-align:right">
                          </table></td>
                      </tr>
                      <tr>
                        <td style="width:355;height:37"></td>
                      </tr>
                      <tr>
                        <td align="center">Authorized Signatory</td>
                      
                      </tr>
                  </table></td>
                </tr>
                <tr><td style="width: 9px; height: 38px;"></td>
                 <td colspan="2" style="height: 38px">*Cheque Subject to realization<br /> *Fees Once Paid will not be refunded 
                            <asp:Label ID="lbl_address" runat="server" Text="Label" Font-Bold="True" Visible="False"></asp:Label></td>
                 </tr>
              <tr>
                  <td style="width: 9px; height: 9px">
                  </td>
                  <td colspan="2" align="center" style="height: 9px" >
                      <span style="font-size: 10pt"><strong>Franchisor: IMAGE INFOTAINMENT LIMITED,
                          <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></strong></span></td>
              </tr>
              <tr>
                  <td style="width: 9px; height: 4px">
                  </td>
                  <td colspan="2" align="center" style="height: 4px">
                      &nbsp;<span style="font-size: 24pt"><span style="font-size: 9pt; font-family: 'Arial','sans-serif'">Regd
                          Office No:32,
                          <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml namespace="" prefix="ST1" ?><st1:street w:st="on"></st1:street><st1:address w:st="on"></st1:address>TTK Road, Alwarpet, Chennai 600 018. Ph: 4293 5293.<o:p></o:p></span></span></td>
              </tr>
              <tr>
                  <td style="width: 9px; height: 7px">
                  </td>
                  <td colspan="2" align="center" style="height: 7px">
                      <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                          <span style="font-size: 9pt; font-family: 'Arial','sans-serif'">Service Tax Regn.No:AAACI6238B<o:p></o:p></span></p>
                  </td>
              </tr>
                 
              </table>
      <tr style="height:25px;">
                        <td style="height:25px;" colspan="2" align="left">
                            &nbsp;</td>
                    </tr>
        </table>
      
       </td>
  </tr>
  
  
  
  <tr>
  <td>
  
  
  <table width="800px" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td style="height: 550px; width: 100%;" align="center" valign="top">
            <table  border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000" style="width: 100%">
      <tr>
        <td width="100%" style="height: 550px">
        <table width="100%"  border="0">
        <tr>
        <td colspan="2" align="center" valign="middle">
            <strong><span style="font-size: 14pt">RECEIPT</span></strong></td>
        </tr>
          <tr>
            <td width="200px" ><img src="../layout/image_logo.jpg" width="178" height="95" /></td>
            <td width="600px"><table width="100%" align="CENTER">
              <%--<tr>
                <td class="style3 style5"><div align="center" class="style5 style1"><strong> <span style="font-size: 16pt">&nbsp;IMAGE INFOTAINMENT LIMITED</span></strong></div></td>
              </tr>--%>
              <tr>
                <td class="style3 style5" align="center" valign="middle"><div class="style5 style1">
                    <span style="font-size: 16pt"><strong>&nbsp; &nbsp;<span style="font-size: 18pt">VNXTL
                        TECH SERVICES PVT LTD<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                            prefix="o" ?><?xml namespace="" prefix="O" ?><o:p></o:p></span></strong></span></div>
                </td>
              </tr>
              <tr>
                <td class="style3" align="center" valign="middle"><p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                    <span style="font-size: 9pt; font-family: 'Arial','sans-serif'">LAV Arcade,
                        <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml namespace="" prefix="ST1" ?><st1:street w:st="on"></st1:street><st1:address w:st="on"></st1:address>#79, Bellary Road, Ganga Nagar,
                        <st1:city w:st="on"></st1:city>
                        <st1:place w:st="on"></st1:place>
                        Bangalore 560 032. Ph: 4128 4111<o:p></o:p></span></p>
                </td>
              </tr>
              <tr>
                <td class="style3" align="center" valign="middle"><span style="font-size: 9pt; font-family: 'Arial','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    Service Tax Regn. No: AADCV5893NST001</span></td>
              </tr>
              
            </table></td>
          </tr>
        </table>
              <table width="100%" id="TABLE2">
                <tr>
                  <td width="140"><table>
                    <tr>
                        <td width="48">R.No<strong>:</strong></td>
                      <td width="80" height="26">
                      
                      <table width="80"  cellpadding="0" cellspacing="0" style="border-bottom:1px solid #333;" >
                         <tr>
                              <td style="height: 19px"><asp:Label ID="lbl_recpno1" runat="server" Text=''></asp:Label></td>
                            </tr>
                        </table>
                          </td>
                    </tr>
                      <tr>
                        <td>Inv.No<strong>:</strong></td>
                        
                        <td height="26"><table width="80" cellpadding="0" cellspacing="0" style="border-bottom:1px solid #333;">
                            
                            <tr>
                              <td style="height: 25px"><asp:Label ID="lbl_invoice1" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                  <td width="225px" align="center">&nbsp;</td>
                  <td width="425px"><table style="width: 100%">
                      <tr>
                        <td style="width: 65px" >Date  <strong>:</strong></td>
                        <td  height="26" align="left" valign="middle"><table width="140" height="25" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                  <asp:Label ID="lbl_date1" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td style="width: 65px">Course <strong>:</strong> </td>
                        <td height="26"><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                            <tr>
                              <td style="height: 25px" align="left" valign="middle">
                                  <asp:Label ID="lbl_coursecode1" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                      <td colspan="3" style="height: 30px" valign="middle" align="left">
                          <strong>RECEIVED</strong> with thanks from Mr. / Mrs. / Ms&nbsp;
                          <asp:Label ID="lbl_studname1" runat="server" Font-Bold="True"></asp:Label>
                          the sum of Rs.
                          <asp:Label ID="lbl_sum1" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                           /-(Rupees
                      </td>
                  </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle" align="left">
                          <asp:Label ID="lbl_inwords1" runat="server" Text=""></asp:Label>
                          )&nbsp; through 
                          <asp:Label ID="lbl_ddcc1" runat="server" Font-Bold="True"></asp:Label>
                          </td>
                  </tr>
                  <tr>
                      <td colspan="3" style="height: 30px" valign="middle" align="left">
                          <asp:Label ID="lbl_Bank1" runat="server" Visible="False"></asp:Label><asp:Label
                              ID="lbl_BankName1" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                          being payment towards
                          <asp:Label ID="lbl_paymenttowards1" runat="server" Font-Bold="True"></asp:Label>&nbsp; &nbsp;for the Month of
                          <asp:Label ID="lbl_monthinstallment1" runat="server" Font-Bold="True"></asp:Label></td>
                  </tr>
                 
              </table>

          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td align="left"><strong>Payment Details :- </strong></td>
            </tr>
          </table>
          <table width="100%" style="height:110px;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td style="width: 9px; height: 190px;">&nbsp;</td>
                  <td width="200" style="height:190px;"><table border="1" cellpadding="0" cellspacing="0" bordercolor="#000000">
                      <tr>
                        <td width="187" height="75px"><table border="0" cellspacing="0" align="center" >
                            <tr>
                              <td height="23"><strong>Fees Rs. </strong></td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                                  <tr>
                                    <td style="height: 25px">
                                        <asp:Label ID="lbl_fees1" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td width="74" height="29"><strong>Tax&nbsp; </strong></td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0">
                                  <tr>
                                    <td style="font-weight:normal;">
                                        <asp:Label ID="lbl_tax1" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                            <tr>
                              <td><strong>Total Rs. </strong> </td>
                              <td width="106"><table width="100" height="25" border="0" cellpadding="0" cellspacing="0" class="border">
                                  <tr>
                                    <td style="font-weight:normal;">
                                        <asp:Label ID="lbl_total1" runat="server" Text=""></asp:Label></td>
                                  </tr>
                              </table></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                  <td width="510" style="height: 190px"><table width="357" height="116" border="0" cellspacing="0" align="right" >
                      <tr>
                        <td align="center">For <strong>Image Infotainment Limited</strong>
                            <table style="text-align:right">
                          </table></td>
                      </tr>
                      <tr>
                        <td style="width:355;height:25px"></td>
                      </tr>
                      <tr>
                        <td align="center">Authorized Signatory</td>
                      
                      </tr>
                  </table></td>
                </tr>
                <tr><td></td>
                 <td colspan="2" align="left">*Cheque Subject to realization<br /> *Fees Once Paid will not be refunded 
                <asp:Label ID="lbl_address1" runat="server" Text="Label" Font-Bold="True" Visible="False"></asp:Label></td>
                 </tr>
              </table>
                       <tr >
                        <td  colspan="2" align="center" style="height: 12px">
                            &nbsp;<span style="font-size: 10pt"><strong>Franchisor: IMAGE INFOTAINMENT LIMITED,
                                <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml namespace="" prefix="O" ?><?xml namespace="" prefix="O" ?><o:p></o:p></strong></span></td>
                    </tr>
                <tr >
                    <td align="center" colspan="2" style="height: 6px" >
                        &nbsp;<span style="font-size: 24pt"><span style="font-size: 9pt; font-family: 'Arial','sans-serif'">Regd
                            Office No:32,
                            <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml namespace="" prefix="ST1" ?><?xml namespace="" prefix="ST1" ?><st1:street w:st="on"></st1:street><st1:address w:st="on"></st1:address>TTK Road, Alwarpet, Chennai 600 018. Ph: 4293 5293.<o:p></o:p></span></span></td>
                </tr>
                <tr >
                    <td align="left" colspan="2" >
                        <p align="center" class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
                            <span style="font-size: 9pt; font-family: 'Arial','sans-serif'">Service Tax Regn.No:AAACI6238B<o:p></o:p></span></p>
                    </td>
                </tr>
                <tr style="height: 25px">
                    <td align="left" colspan="2" style="height: 25px">
                    </td>
                </tr>

        </table>
  
  
  </td>
 
  
  </tr>
</table>
</td>
</tr>

</table>
</td>
</tr>
</table>
    </div>
    </form>
</body>
</html>
