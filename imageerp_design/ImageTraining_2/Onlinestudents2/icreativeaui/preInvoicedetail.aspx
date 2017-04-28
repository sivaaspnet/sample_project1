<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="preInvoicedetail.aspx.cs" Inherits="superadmin_preInvoicedetails" Title="PreInvoice Details" %>
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

         else if (document.getElementById("ContentPlaceHolder1_hdncoursetype").value == 'Certificate') {
             if ((parseInt(document.getElementById("ContentPlaceHolder1_txtamountpaid").value)) < 2500) {
                 alert("Enrollment amount is Less.");
                 document.getElementById("ContentPlaceHolder1_txtamountpaid").focus();
                 document.getElementById("ContentPlaceHolder1_txtamountpaid").style.border = "#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtamountpaid").style.backgroundColor = "#e8ebd9";

                 return false;
             }
         }
         else if (document.getElementById("ContentPlaceHolder1_hdncoursetype").value == 'Diploma') {
             if ((parseInt(document.getElementById("ContentPlaceHolder1_txtamountpaid").value)) < 5000) {
                 alert("Enrollment amount is Less.");
                 document.getElementById("ContentPlaceHolder1_txtamountpaid").focus();
                 document.getElementById("ContentPlaceHolder1_txtamountpaid").style.border = "#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtamountpaid").style.backgroundColor = "#e8ebd9";

                 return false;
             }
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
	var taxcal = parseFloat(initial) * parseFloat(document.getElementById('ContentPlaceHolder1_HiddenField2').value);
	var taxcalh = parseFloat(taxcal/100);
	var totinitialtax=Math.round(parseFloat(initial + taxcalh),0);
	//alert(totinitialtax);
	document.getElementById("ContentPlaceHolder1_lbltotamountpaid_tax").innerHTML = totinitialtax;
	
	test_skill(totinitialtax);
}
     </script>
     <input id="hdnpayinword" type="hidden" runat="server" />
	   <div class="title-cont">
    <h3 class="cont-title">Summary</h3>
    <div class="clear"></div>
  </div>
  <div class="white-cont">
    <div class="form-cont">
      <ul>
        <li style="text-align:center">
    <asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label> </li>
        <li>
          <label class="label-txt">Name</label>
		<asp:TextBox ID="txtname" CssClass="text input-txt" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Address</label>
            <asp:TextBox ID="txtaddress" CssClass="text area-txt" runat="server" TextMode="MultiLine" Height="57px" ReadOnly="True" Width="196px"></asp:TextBox>
			 <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Mobile</label>				  
            <asp:TextBox ID="txtphone" CssClass="text input-txt" MaxLength="11" onKeyPress="return CheckNumeric(event)" runat="server"></asp:TextBox><span class="file">
                <asp:HiddenField ID="hdncoursetype" runat="server" />
                                <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Course Name</label>
                                    <asp:DropDownList CssClass="sele-txt"  ID="txtcoursename" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="txtcoursename_SelectedIndexChanged" Visible="False">
                                    </asp:DropDownList>&nbsp;&nbsp;
            <asp:DropDownList ID="txtcourseid" CssClass="select sele-txt" runat="server" Visible="False">
                                    </asp:DropDownList><asp:TextBox ID="txtCName" runat="server" CssClass="text input-txt" Width="424px" ReadOnly="True"></asp:TextBox> <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Centre</label>
                                    <asp:Label ID="txtcentre" runat="server" Text='' CssClass="form-txt"></asp:Label>							
                             <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Course Start Date</label>
             <span class="date-pick-cont">
            <asp:TextBox ID="txtdate" CssClass="text datepicker date-input-txt" runat="server"></asp:TextBox> 
                 </span><div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">No. of Installments</label>
            <asp:TextBox ID="txtinstall" MaxLength="2" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" runat="server" ></asp:TextBox>
								<div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Course Fee</label>
                                    <asp:TextBox ID="txtcoursefee" MaxLength="11" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" runat="server" ReadOnly="True"></asp:TextBox>						
							  <li>
          <label class="label-txt">Lumpsum Amount</label>
                                    <asp:Label ID="lbllumpamt" runat="server" Text='' CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Initial Payment</label>
                                    <asp:Label ID="lbllumpinitial" runat="server" Text='' CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Tax</label>
                                    <asp:Label ID="lbllumptax" runat="server" Text='' CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Initial Tax</label>
                                    <asp:Label ID="lbllumpinitialtax" runat="server" Text='' CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Total Lump Sum</label>
                                    <asp:Label ID="lbltotlump_tax" runat="server" Text='' CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Total Initial Payment</label>
                                    <asp:Label ID="lbltotlumpinitial_tax" runat="server" CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Next Installment Date</label>
          <span class="date-pick-cont">
              <asp:TextBox ID="txtinstalldate" CssClass="text datepicker date-input-txt" runat="server"></asp:TextBox>
              </span>
          <div class="clear"></div>
        </li>
            <li>
          <label class="label-txt">Installment Details</label>
          <table border="0" align="center" cellpadding="0" cellspacing="0" class="tbl-cont3">
              <tr>
                <th width="28%">Installments</th>
                <th width="26%">Installment Amount</th>
                <th width="20%">Tax</th>
                <th width="26%">Total Amount</th>
              </tr>
              <tr>
                   <td>Total Installment Amount</td>
			<td><asp:Label ID="lblinstallment" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
		   <td><asp:Label ID="lblinstaltax" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
		   <td><asp:Label ID="lblinstalltotal" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
							  </tr>
							  <tr>
                <td>Initial Payment</td>
                <td><asp:Label ID="lblinitialpay" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
                <td><asp:Label ID="lbltax" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
                <td><asp:Label ID="lbltotamt" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
              </tr>
		  <tr>
                <td>Monthly Installment</td>
                <td><asp:Label ID="lblmonthlyinstal" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
                <td><asp:Label ID="lblmonthlytax" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
                <td><asp:Label ID="lblmonthlytotal" runat="server" Text='' CssClass="form-txt"></asp:Label></td>
              </tr>
	 <tr>
                <td>Total Amount Paid</td>
                <td><asp:TextBox ID="txtamountpaid" onKeyUp="calctax(this)" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="input-txt"></asp:TextBox></td>
                <td><asp:Label ID="lblamt_tax" runat="server" Text="" CssClass="form-txt"></asp:Label></td>
                <td><asp:Label ID="lbltotamountpaid_tax" runat="server" Text="" CssClass="form-txt"></asp:Label></td>
              </tr>
            </table>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
   <div class="form-cont">
      <ul>
        <li>
          <label class="label-txt">Amount Paid in words(With Tax)</label>
             <asp:Label ID="txt_paymentwords" runat="server" Text='' CssClass="form-txt"></asp:Label>
              <asp:HiddenField ID="HiddenField1" runat="server"  />
                <script type="text/javascript">
                calctax(document.getElementById("ContentPlaceHolder1_txtamountpaid"));
                </script>
               <div class="clear"></div>
        </li>
        <li>
          <label class="label-txt">Payment Towards</label>
               <asp:Label ID="txtpaytowards" runat="server" Text='Image Creative Education Pvt Ltd.' CssClass="form-txt"></asp:Label>
          <div class="clear"></div>
        </li>
        <li style="text-align:center;">
          <div style="padding-bottom:25px;" align="center">
                                  
                                    <asp:Button ID="Button1" runat="server" CssClass="btnStyle1" Text="Update" OnClick="Button1_Click" OnClientClick="javascript:return summaryvalidate();" />
                                    <asp:Button ID="Button2" runat="server" CssClass="btnStyle2" Text="Confirm" OnClick="Button2_Click" />
						 </li>
      </ul>
      <div class="clear"></div>
    </div>
  </div>
    <asp:HiddenField ID="hdnsummary" runat="server" />
    <asp:HiddenField ID="hdnpay" runat="server" />
    <asp:HiddenField ID="hdninitial_Amnt" runat="server" />
    <asp:Label ID="lblCID" runat="server" Text="" Visible="false"></asp:Label>

</asp:Content>

