<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="Receiptsummary.aspx.cs" Inherits="superadmin_Receiptsummary" Title="Receipt Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script language="javascript" type="text/javascript">
          function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
	        
	       function receiptmodifyval()
          {
             if(trim(document.getElementById("ContentPlaceHolder1_lbl_paymenttype").value)=="")
              {    
                 alert("Please Enter the payment in words");
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").value = "";
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").focus();
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").style.backgroundColor="#e8ebd9";
                 return false;
               } 
                 else if(trim(document.getElementById("ContentPlaceHolder1_lbl_amount").value)=="")
              {    
                 alert("Please Enter the monthly installment amount");
                 document.getElementById("ContentPlaceHolder1_lbl_amount").value = "";
                 document.getElementById("ContentPlaceHolder1_lbl_amount").focus();
                 document.getElementById("ContentPlaceHolder1_lbl_amount").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_lbl_amount").style.backgroundColor="#e8ebd9";
                 return false;
               }  
           
              else if(trim(document.getElementById("ContentPlaceHolder1_lbl_monthinstall").value)=="")
              {    
                 alert("Please Enter the Month Installment");
                 document.getElementById("ContentPlaceHolder1_lbl_monthinstall").value = "";
                 document.getElementById("ContentPlaceHolder1_lbl_monthinstall").focus();
                 document.getElementById("ContentPlaceHolder1_lbl_monthinstall").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_lbl_monthinstall").style.backgroundColor="#e8ebd9";
                 return false;
               } 
                else if(trim(document.getElementById("ContentPlaceHolder1_lbl_paymenttype").value)=="")
              {    
                 alert("Please Enter the Payment type");
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").value = "";
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").focus();
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_lbl_paymenttype").style.backgroundColor="#e8ebd9";
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
   
    function test_skill(rup) 
    {
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
	document.getElementById('ContentPlaceHolder1_lbl_paywords').innerHTML=finalWord;
	document.getElementById('ContentPlaceHolder1_hdnpaywords').value=finalWord;
}
function calctax(amtwit)
{
	var initial=parseInt(amtwit.value);
	var taxcal = parseFloat(initial * 10.3);
	var taxcalh = parseFloat(taxcal/100);
	var totinitialtax=parseFloat(initial + taxcalh);
	document.getElementById("ContentPlaceHolder1_lbltotamtwithtax").innerHTML = totinitialtax;
	document.getElementById("ContentPlaceHolder1_hdnpaytax").value = totinitialtax;
	test_skill(totinitialtax);
	document.getElementById("ContentPlaceHolder1_hdnpayinitial").value = amtwit.value;
	
}
 
	    </script>     

    <input id="hdnpaywords" type="hidden" runat="server" />
    <input id="hdnpayinitial" type="hidden" runat="server" />
    <input id="hdnpaytax" type="hidden" runat="server" />
    
        <table class="common">
        <tr><td colspan="4" style="padding:0px"><h4>Receipt Details Summary</h4></td></tr>
         <tr><td colspan="4" style="text-align:center">
             <asp:Label ID="lblerrmsg" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
        <tr><td class="w290 talignleft" style="width: 123px">
            Receipt Number</td><td colspan="3">
                <asp:Label ID="lbl_recpno" runat="server" Text=""></asp:Label></td></tr>
         <tr><td class="w290 talignleft" style="width: 123px">
             Date</td><td colspan="3">
                 <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td></tr>
          <tr><td class="w290 talignleft" style="width: 123px">
              Invoice Number</td><td colspan="3">
                  <asp:Label ID="lbl_invoicenum" runat="server" Text=""></asp:Label></td></tr>
           <tr><td class="w290 talignleft" style="height: 25px; width: 123px;">
               Course Code</td><td style="height: 25px">
               <asp:Label ID="lbl_coursecode" runat="server" Text=""></asp:Label></td>
               <td class="w290 talignleft" style="height: 25px; width: 148px;">
               Student Name</td>
               <td style="height: 25px">
               <asp:Label ID="lbl_studname" runat="server" Text=""></asp:Label></td></tr>
            <tr>
                <td class="w290 talignleft" style="width: 123px">
               Amount(Without Tax)</td><td>
                
                   <asp:Label ID="lbl_amount" runat="server" Text=''></asp:Label>
                   
                   </td>
                 <td class="w290 talignleft" style="width: 148px">
               Tax </td><td>  <asp:Label ID="Label1" runat="server" Text="10.3 %"></asp:Label> 
                   
                   </td></tr>
                <tr>
                <td class="w290 talignleft" style="width: 123px">Amount (With Tax)
                   </td>
                <td><asp:Label ID="lbltotamtwithtax" runat="server" Text=''></asp:Label>
                   </td>
                <td class="w290 talignleft" style="width: 148px">
                 Payment In Words </td>
                <td>      
                   <asp:Label ID="lbl_paywords" runat="server" Text=""></asp:Label>
              <!--   <script type="text/javascript">
                calctax(document.getElementById("ContentPlaceHolder1_lbl_amount"));
                </script> -->
                    </td>
            </tr>
            <tr>
                <td class="w290 talignleft" style="width: 123px">
                    Month Installment</td>
                <td>
                    <asp:TextBox ID="lbl_monthinstall" CssClass="text" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td class="w290 talignleft" style="width: 148px">
                    Payment Type</td>
                <td>      
                    <asp:TextBox ID="lbl_paymenttype" CssClass="text" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnmodify" runat="server" CssClass="submit" Text="Update" OnClick="btnmodify_Click"  OnClientClick="javascript:return receiptmodifyval();" />
                    <asp:Button ID="btnconfirmit" runat="server" CssClass="submit" Text="Confirm" OnClick="btnconfirmit_Click" OnClientClick="javascript:return receiptmodifyval();" Visible="False"  /></td>
            </tr>
        
        
        
        </table>
</asp:Content>

