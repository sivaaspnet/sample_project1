<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="preInvoicedetails.aspx.cs" Inherits="superadmin_preInvoicedetails" Title="PreInvoice Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
  function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
    function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}     
 function summaryvalidate()
     {
     //clearValidation('ContentPlaceHolder1_txtname~ContentPlaceHolder1_txtaddress~ContentPlaceHolder1_txtcoursename~ContentPlaceHolder1_txtdate~ContentPlaceHolder1_txtcoursefee');
       //alert(document.getElementById("ContentPlaceHolder1_txtinstalldate").value);
        //Start and end date check
        var start = document.getElementById("ContentPlaceHolder1_txtdate").value;
        var start_s = start.split("-");
        var stDate = start_s[2]+start_s[1]+start_s[0];
        
        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
//        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        
        var csDate = stDate - toDate;
        
        if(document.getElementById("ContentPlaceHolder1_txtinstall") && document.getElementById("ContentPlaceHolder1_hdnpay").value =="2")
        {
        var end = document.getElementById("ContentPlaceHolder1_txtinstalldate").value;
        var end_s = end.split("-");
        var enDate = end_s[2]+end_s[1]+end_s[0];
        
        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
//        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        var compDate = enDate - toDate;
        }

           if(trim(document.getElementById("ContentPlaceHolder1_txtname").value)=="")
         {    
             alert("Please Enter your Name");
             document.getElementById("ContentPlaceHolder1_txtname").value = "";
             document.getElementById("ContentPlaceHolder1_txtname").focus();
             document.getElementById("ContentPlaceHolder1_txtname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtname").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtaddress").value)=="")
         {    
             alert("Please Enter your Address");
             document.getElementById("ContentPlaceHolder1_txtaddress").value = "";
             document.getElementById("ContentPlaceHolder1_txtaddress").focus();
             document.getElementById("ContentPlaceHolder1_txtaddress").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtaddress").style.backgroundColor="#e8ebd9";
             return false;
         }
        
//         else if(trim(document.getElementById("ContentPlaceHolder1_txtcoursename").value)=="")
//         {    
//             alert("Please select the Course name");
//             document.getElementById("ContentPlaceHolder1_txtcoursename").value = "";
//             document.getElementById("ContentPlaceHolder1_txtcoursename").focus();
//             document.getElementById("ContentPlaceHolder1_txtcoursename").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtcoursename").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//          else if(trim(document.getElementById("ContentPlaceHolder1_txtcourseid").value)=="")
//         {    
//             alert("Please select the courseID");
//             document.getElementById("ContentPlaceHolder1_txtcourseid").value = "";
//             document.getElementById("ContentPlaceHolder1_txtcourseid").focus();
//             document.getElementById("ContentPlaceHolder1_txtcourseid").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtcourseid").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//   
            else if(trim(document.getElementById("ContentPlaceHolder1_txtdate").value)=="")
         {    
             alert("Please Enter your Course Start Date");
             document.getElementById("ContentPlaceHolder1_txtdate").value = "";
             document.getElementById("ContentPlaceHolder1_txtdate").focus();
             document.getElementById("ContentPlaceHolder1_txtdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtdate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(csDate < 0)
         {
             document.getElementById("ContentPlaceHolder1_txtdate").value=="";
             alert("*Invalid start date!");
             document.getElementById("ContentPlaceHolder1_txtdate").focus();
             document.getElementById("ContentPlaceHolder1_txtdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtdate").style.backgroundColor="#e8ebd9";
             return false;
        }
            else if(document.getElementById("ContentPlaceHolder1_txtinstall") && document.getElementById("ContentPlaceHolder1_hdnpay").value =="2" && (trim(document.getElementById("ContentPlaceHolder1_txtinstall").value)=="" || parseInt(document.getElementById("ContentPlaceHolder1_txtinstall").value)<1))
         {    
             alert("Please Enter your No of Installments");
             document.getElementById("ContentPlaceHolder1_txtinstall").value = "";
             document.getElementById("ContentPlaceHolder1_txtinstall").focus();
             document.getElementById("ContentPlaceHolder1_txtinstall").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstall").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txtcoursefee").value)=="")
         {    
             alert("Please Enter your Course Fees");
             document.getElementById("ContentPlaceHolder1_txtcoursefee").value = "";
             document.getElementById("ContentPlaceHolder1_txtcoursefee").focus();
             document.getElementById("ContentPlaceHolder1_txtcoursefee").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcoursefee").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ContentPlaceHolder1_txtinstalldate") && document.getElementById("ContentPlaceHolder1_hdnpay").value =="2" && document.getElementById("ContentPlaceHolder1_txtinstall").value > 0 && document.getElementById("ContentPlaceHolder1_txtinstalldate").value == "" )
         {    
             alert("Please Enter your Installment date");
             document.getElementById("ContentPlaceHolder1_txtinstalldate").value = "";
             document.getElementById("ContentPlaceHolder1_txtinstalldate").focus();
             document.getElementById("ContentPlaceHolder1_txtinstalldate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstalldate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_hdnpay").value =="2" && document.getElementById("ContentPlaceHolder1_txtinstalldate") && compDate < 0)
         {
             alert("*Invalid Installment date!");
             document.getElementById("ContentPlaceHolder1_txtinstalldate").value=="";
             document.getElementById("ContentPlaceHolder1_txtinstalldate").focus();
             document.getElementById("ContentPlaceHolder1_txtinstalldate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstalldate").style.backgroundColor="#e8ebd9";
             return false;
        }
          else if(document.getElementById("ContentPlaceHolder1_txtamountpaid").value=="")
         {    
             alert("Please Enter the total amount paid without tax");
             document.getElementById("ContentPlaceHolder1_txtamountpaid").value = "";
             document.getElementById("ContentPlaceHolder1_txtamountpaid").focus();
             document.getElementById("ContentPlaceHolder1_txtamountpaid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtamountpaid").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((parseInt(document.getElementById("ContentPlaceHolder1_txtcoursefee").value)) < (parseInt(document.getElementById("ContentPlaceHolder1_txtamountpaid").value)))
         {    
             alert("Amount to be paid is more than the course fee");
             document.getElementById("ContentPlaceHolder1_txtamountpaid").value = "";
             document.getElementById("ContentPlaceHolder1_txtamountpaid").focus();
             document.getElementById("ContentPlaceHolder1_txtamountpaid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtamountpaid").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         
         else
         {
         return true;
         }
     }

function CheckNumeric(GetEvt)
  {
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
  }
  function test_skill(rup) {
	var junkVal=rup;
	junkVal=Math.floor(junkVal);
	var obStr=new String(junkVal);
	numReversed=obStr.split("");
	actnumber=numReversed.reverse();

	if(Number(junkVal) >=0){
		//do nothing
	}
	else{
		alert('wrong Number cannot be converted');
		return false;
	}
	if(Number(junkVal)==0){
		document.getElementById('container').innerHTML=obStr+''+'Rupees Zero Only';
		return false;
	}
	if(actnumber.length>9){
		alert('Oops!!!! the Number is too big to covertes');
		return false;
	}

	var iWords=["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];
	var ePlace=['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen'];
	var tensPlace=['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety' ];

	var iWordsLength=numReversed.length;
	var totalWords="";
	var inWords=new Array();
	var finalWord="";
	j=0;
	for(i=0; i<iWordsLength; i++){
		switch(i)
		{
		case 0:
			if(actnumber[i]==0 || actnumber[i+1]==1 ) {
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			inWords[j]=inWords[j]+' Only';
			break;
		case 1:
			tens_complication();
			break;
		case 2:
			if(actnumber[i]==0) {
				inWords[j]='';
			}
			else if(actnumber[i-1]!=0 && actnumber[i-2]!=0) {
				inWords[j]=iWords[actnumber[i]]+' Hundred and';
			}
			else {
				inWords[j]=iWords[actnumber[i]]+' Hundred';
			}
			break;
		case 3:
			if(actnumber[i]==0 || actnumber[i+1]==1) {
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			if(actnumber[i+1] != 0 || actnumber[i] > 0){
				inWords[j]=inWords[j]+" Thousand";
			}
			break;
		case 4:
			tens_complication();
			break;
		case 5:
			if(actnumber[i]==0 || actnumber[i+1]==1 ) {
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			inWords[j]=inWords[j]+" Lakh";
			break;
		case 6:
			tens_complication();
			break;
		case 7:
			if(actnumber[i]==0 || actnumber[i+1]==1 ){
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			inWords[j]=inWords[j]+" Crore";
			break;
		case 8:
			tens_complication();
			break;
		default:
			break;
		}
		j++;
	}

	function tens_complication() {
		if(actnumber[i]==0) {
			inWords[j]='';
		}
		else if(actnumber[i]==1) {
			inWords[j]=ePlace[actnumber[i-1]];
		}
		else {
			inWords[j]=tensPlace[actnumber[i]];
		}
	}
	inWords.reverse();
	for(i=0; i<inWords.length; i++) {
		finalWord+=inWords[i];
	}
	document.getElementById('ContentPlaceHolder1_txt_paymentwords').innerHTML=finalWord;
	document.getElementById('ContentPlaceHolder1_hdnpayinword').value=finalWord;
	
}
function calctax(amtwit)
{
	var initial=parseInt(amtwit.value);
	var taxcal = parseFloat(initial * 10.3);
	var taxcalh = parseFloat(taxcal/100);
	var totinitialtax=Math.round(parseFloat(initial + taxcalh),0);
	//alert(totinitialtax);
	document.getElementById("ContentPlaceHolder1_lbltotamountpaid_tax").innerHTML = totinitialtax;
	
	test_skill(totinitialtax);
}
     </script>
      <input id="hdnpayinword" type="hidden" runat="server" />
  <table width="800" border="1" align="center" cellpadding="0" cellspacing="0" class="common">
<tr> <td style="padding:0px;"><h4>Summary</h4></td></tr>
<tr> <td style="text-align:center">
    <asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
<tr>
<td valign="top"><table width="780" border="1" align="center" cellpadding="0" cellspacing="0"> 
							  <tr>
								<td style="width:188px;height:25" class="w290 talignleft">&nbsp;Name</td>
								<td colspan="5">&nbsp;<asp:TextBox ID="txtname" CssClass="text" runat="server"></asp:TextBox></td>
							  </tr>
							  <tr>
								<td class="w290 talignleft" style="width: 188px; height: 42px">&nbsp;Address</td>
								<td colspan="5" style="height: 42px">&nbsp;<asp:TextBox ID="txtaddress" CssClass="text" runat="server" TextMode="MultiLine" Height="57px" ReadOnly="True" Width="196px"></asp:TextBox></td>
							  </tr>
							  <tr>
								<td class="w290 talignleft" style="width: 188px">&nbsp;Mobile</td>
								<td colspan="5">&nbsp;<asp:TextBox ID="txtphone" CssClass="text" MaxLength="11" onKeyPress="return CheckNumeric(event)" runat="server"></asp:TextBox></td>
							  </tr>
							  <tr>
								<td colspan="6">&nbsp;</td>
							  </tr>
							  <tr>
								<td style="width:188px;height:34px" class="w290 talignleft">Course Name</td>
                                  <td colspan="5" style="height: 34px">
                                    <asp:DropDownList ID="txtcoursename" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtcoursename_SelectedIndexChanged" Visible="False">
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:DropDownList ID="txtcourseid" CssClass="select" runat="server" Visible="False">
                                    </asp:DropDownList><asp:TextBox ID="txtCName" runat="server" CssClass="text" Width="424px" ReadOnly="True"></asp:TextBox></td>
							  </tr>
							  <tr>
								<td style="width:188px;height:25"  class="w290 talignleft">&nbsp;&nbsp;Centre</td>
								<td colspan="2">&nbsp;
                                    <asp:Label ID="txtcentre" runat="server" Text=''></asp:Label></td>
								<td style="width:165;height:25"  class="w290 talignleft">
                                    Course Start&nbsp;Date</td>
								<td colspan="2">&nbsp;&nbsp;<asp:TextBox ID="txtdate" CssClass="text datepicker" runat="server"></asp:TextBox></td>
							  </tr>
							  <tr>
								<td class="w290 talignleft" style="width: 188px">&nbsp;&nbsp;No. of Installments</td>
								<td colspan="2">&nbsp;&nbsp;<asp:TextBox ID="txtinstall" MaxLength="2" onKeyPress="return CheckNumeric(event)" CssClass="text" runat="server" ReadOnly="True"></asp:TextBox></td>
								<td  class="w290 talignleft">Course Fee </td>
								<td colspan="2">&nbsp;&nbsp;<asp:TextBox ID="txtcoursefee" MaxLength="11" onKeyPress="return CheckNumeric(event)" CssClass="text" runat="server" ReadOnly="True"></asp:TextBox></td>								
							  </tr>
							  <tr>
								<td colspan="1" class="w290 talignleft" style="width: 188px">
                                    &nbsp;Lumpsum Amount </td>
								<td colspan="2">
                                    <asp:Label ID="lbllumpamt" runat="server" Text=''></asp:Label></td>
								<td style="width:80;height:25" class="w290 talignleft" colspan="1">Initial Payment</td>
								<td style="width:126;height:25" colspan="2">
                                    <asp:Label ID="lbllumpinitial" runat="server" Text=''></asp:Label></td>
							  </tr>
							   <tr>
								<td colspan="2" class="w290 talignleft">&nbsp; Tax</td>
								<td style="width:208;height:25">
                                    <asp:Label ID="lbllumptax" runat="server" Text=''></asp:Label></td>
								<td colspan="1" class="w290 talignleft">
                                    Tax</td>
								<td colspan="3" >
                                    <asp:Label ID="lbllumpinitialtax" runat="server" Text=''></asp:Label></td>
							  </tr>
							     <tr>
								<td colspan="2" class="w290 talignleft">&nbsp;Total Lump Sum
                                </td>
								<td style="width:208;height:25">
                                    <asp:Label ID="lbltotlump_tax" runat="server" Text=''></asp:Label></td>
								<td colspan="1" class="w290 talignleft">
                                    Total Initial Payment</td>
								<td colspan="3">
                                    <asp:Label ID="lbltotlumpinitial_tax" runat="server" Text=''></asp:Label></td>
							  </tr>
							  <tr>
								<td colspan="2" class="w290 talignleft">
                                    Next&nbsp;Installment Date</td>
								<td style="width:208;height:25" class="w290 talignleft" align="center">Installments</td>
								<td colspan="1" class="w290 talignleft">&nbsp;Installment Amount </td>
								<td style="width:80;height:25" class="w290 talignleft" colspan="1">&nbsp;Tax</td>
								<td style="width:126;height:25" class="w290 talignleft" colspan="2">&nbsp;Total Amount </td>
							  </tr>
							   <tr>
								<td colspan="2"><asp:TextBox ID="txtinstalldate" CssClass="input-small text datepicker" runat="server"></asp:TextBox></td>
								<td class="w290 talignleft" align="center">Total Installment Amount</td>
								<td colspan="1">
                                    <asp:Label ID="lblinstallment" runat="server" Text=''></asp:Label></td>
								<td  colspan="1"><asp:Label ID="lblinstaltax" runat="server" Text=''></asp:Label></td>
								<td colspan="1" style="width: 153px"><asp:Label ID="lblinstalltotal" runat="server" Text=''></asp:Label></td>
							  </tr>
							  <tr>
								<td colspan="2" class="w290 talignleft">&nbsp;&nbsp;</td>
								<td class="w290 talignleft" align="center">Initial Payment</td>
								<td colspan="1">
                                    <asp:Label ID="lblinitialpay" runat="server" Text=''></asp:Label></td>
								<td  colspan="1"><asp:Label ID="lbltax" runat="server" Text=''></asp:Label></td>
								<td colspan="1" style="width: 153px"><asp:Label ID="lbltotamt" runat="server" Text=''></asp:Label></td>
							  </tr>
						
								  <tr>
									<td align="left" class="w290 talignleft" colspan="2" style="height: 25px">&nbsp;&nbsp;</td>
									<td class="w290 talignleft" align="center" style="height: 25px">
                                    Monthly Installment</td>
									<td align="left" colspan="1" style="height: 25px">
                                        <asp:Label ID="lblmonthlyinstal" runat="server" Text=''></asp:Label></td>
									<td align="left" colspan="1" style="height: 25px">
                                        <asp:Label ID="lblmonthlytax" runat="server" Text=''></asp:Label></td>
									<td align="left" colspan="1" style="height: 25px; width: 153px;">
                                        <asp:Label ID="lblmonthlytotal" runat="server" Text=''></asp:Label></td>
								  </tr>
							  <tr>
									<td align="left" class="w290 talignleft" colspan="2">&nbsp;&nbsp;</td>
									<td class="w290 talignleft" align="center">
                                        Total Amount Paid</td>
									<td align="left" colspan="1">
                                        <asp:TextBox ID="txtamountpaid" onKeyUp="calctax(this)" onKeyPress="return CheckNumeric(event)" runat="server" Width="60px"></asp:TextBox>
                                      </td>
									<td align="left" colspan="1">
                                        <asp:Label ID="lblamt_tax" runat="server" Text=""></asp:Label></td>
									<td align="left" colspan="1" style="width: 153px">
                                        <asp:Label ID="lbltotamountpaid_tax" runat="server" Text=""></asp:Label></td>
								  </tr>
    <tr>
        <td align="left" class="w290 talignleft" colspan="1" style="width: 188px">
            Amount Paid in words(With Tax)</td>
         <td align="left" colspan="5">
             <asp:Label ID="txt_paymentwords" runat="server" Text=''></asp:Label>
              <asp:HiddenField ID="HiddenField1" runat="server"  />
                <script type="text/javascript">
                calctax(document.getElementById("ContentPlaceHolder1_txtamountpaid"));
                </script>
             </td>
             
    </tr>
      <tr>
        <td align="left" class="w290 talignleft" colspan="1" style="width: 188px; height: 24px">
            Payment Towards</td>
            <td align="left" colspan="5" style="height: 24px">
                &nbsp;<asp:Label ID="txtpaytowards" runat="server" Text='Image infotainment limited'></asp:Label></td></tr>
								
							 
							  <tr align="center">
								<td colspan="6" class="w290 talignleft" style="height: 26px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp;
                                    <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Update" OnClick="Button1_Click" OnClientClick="javascript:return summaryvalidate();" />
                                    <asp:Button ID="Button2" runat="server" CssClass="submit" Text="Confirm" OnClick="Button2_Click" /></td>
							  </tr>
						  </table>
</td>
</tr>
</table>
    <asp:HiddenField ID="hdnsummary" runat="server" />
    <asp:HiddenField ID="hdnpay" runat="server" />
    <asp:Label ID="lblCID" runat="server" Text="" Visible="false"></asp:Label>


</asp:Content>

