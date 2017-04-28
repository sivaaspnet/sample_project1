<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="Receiptedit.aspx.cs" Inherits="superadmin_Receiptedit" Title="Receipt Edit Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
	             
 function chkval()
   {
       if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "Cash")
          {
            document.getElementById("ContentPlaceHolder1_txt_ddcc").value=""
            document.getElementById("ContentPlaceHolder1_txt_bankname").value=""
          }
   }
   
 function losefocus(obj)
    {
       if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "Cash")
         {
          obj.value="";
          obj.blur()
         }
    }
    function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}  
 function add()
 {

         if(trim(document.getElementById("ContentPlaceHolder1_txt_studname").value)=="")
         {    
             alert("Please Enter Student Name");
             document.getElementById("ContentPlaceHolder1_txt_studname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_studname").focus();
             document.getElementById("ContentPlaceHolder1_txt_studname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studname").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)=="")
         {    
             alert("Please Enter Initial Amount");
             document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(isNaN(document.getElementById("ContentPlaceHolder1_txt_initialamt").value))
         {    
             alert("Please Enter amount in numerics");
             document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_lblbalanceamount").innerHTML)))
         {    
             alert("Please Check Your Installment Amount is Greater Than Balance Amount");
//             //document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = "";
//             document.getElementById("ContentPlaceHolder1_lblamtwithtax").focus();
//             document.getElementById("ContentPlaceHolder1_lblamtwithtax").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_lblamtwithtax").style.backgroundColor="#e8ebd9";
             return false;
         }
       
        else if(document.getElementById("ContentPlaceHolder1_ddl_month").value=="")
         {    
             alert("Please select Month");
             document.getElementById("ContentPlaceHolder1_ddl_month").value = "";
             document.getElementById("ContentPlaceHolder1_ddl_month").focus();
             document.getElementById("ContentPlaceHolder1_ddl_month").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_month").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value=="")
         {    
             alert("Please Select Payment mode");
             document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_ddcc").value == "")
         {    
                if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value=="Online Transfer")
                 {
                  alert("Please enter UTR No");
                  }
                  else                   
                  {
                 alert("Please enter cheque number");
                  } 
            
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
      
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "")
         {    
              if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value=="Online Transfer")
                 {
                  alert("Please select Online Transfer date");
                  }
                  else                   
                  {
                  alert("Please enter cheque date");
                  }             
             document.getElementById("ContentPlaceHolder1_dddate").value = "";
             document.getElementById("ContentPlaceHolder1_dddate").focus();
             document.getElementById("ContentPlaceHolder1_dddate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_dddate").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_bankname").value == "")
         {    
             alert("Please enter Bank name");
             document.getElementById("ContentPlaceHolder1_txt_bankname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_bankname").focus();
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else
         {
        
         return true;
         }
 
   
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
	//alert(initial);
	var tax=parseFloat(document.getElementById("ContentPlaceHolder1_hdnTax").value);
	var taxcal = parseFloat(initial /(tax+100));
	//alert(taxcal);
	var taxcalh = parseFloat(taxcal*100);
	//alert(taxcalh);
	//var totinitialtax=parseFloat(initial - taxcalh);
	var totinitialtax=parseFloat(taxcalh);
	//alert(totinitialtax);
	//totinitialtax=Math.round(totinitialtax)
	//alert(totinitialtax);
	totinitialtax=Math.round(totinitialtax,0)
	//alert(totinitialtax);
	document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = totinitialtax;
	document.getElementById("ContentPlaceHolder1_hdnAmtWithTax").value = totinitialtax;
	document.getElementById("ContentPlaceHolder1_hdnamt_tax").value = initial;
	test_skill(initial);
	document.getElementById("ContentPlaceHolder1_hdninitamt").value =amtwit.value;
	
}

</script>

    <input id="hdnpayinword" type="hidden" runat="server" />
    <input id="hdnamt_tax" type="hidden" runat="server" />
    <input id="hdninitamt" type="hidden" runat="server" />
   
       <div class="free-forms">       
    <table width="100%" class="common">
    <tr><td colspan="2" style="text-align:center">
        <asp:Label ID="lblerrorMsg" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
        <tr><td colspan="2 " style=" padding:0px;">  <h4>Add Receipt Details</h4></td></tr>        
                <tr>
                    <td class="formlabel">
                        Invoice Number</td>
                    <td>
                        &nbsp;<asp:Label ID="txt_Invoiceno" CssClass="text" runat="server" Text=""></asp:Label>
                        </td>
                        
                </tr>
                <tr>
                    <td class="formlabel">
                        Course Code</td>
                    <td>
                        &nbsp;<asp:Label ID="txt_coursecode" CssClass="text" runat="server" Text=""></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="formlabel">
                        Student Name</td>
                    <td>
                        <asp:TextBox ID="txt_studname" runat="server"  MaxLength="30" TextMode="SingleLine" CssClass="text"></asp:TextBox></td>
                </tr>
        <tr>
            <td class="formlabel">
                Balance Amount (with tax)</td>
            <td>
                <asp:Label ID="lblbalanceamount" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="formlabel">
                Balance Amount (without tax)</td>
            <td>
                <asp:Label ID="lbl_balwithouttax" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formlabel">
                Total Course Fee
            </td>
            <td style="height: 34px">
                <asp:Label ID="lbl_TOTALCOURSE_FEE"  CssClass="text" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="formlabel">
                Installment Amount (With Tax)</td>
            <td>
                <asp:TextBox ID="txt_initialamt" runat="server" ReadOnly="False" onKeyUp="calctax(this)" onKeyPress="return CheckNumeric(event)" CssClass="text" MaxLength="6" ></asp:TextBox></td>
        </tr>
         <tr>
            <td class="formlabel">
                Tax</td>
            <td>
                <asp:Label ID="lbldisplaytax" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td class="formlabel">
                Installment Amount (Without Tax)</td>
            <td>
                <asp:Label ID="lblamtwithtax" runat="server" Text=''></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td class="formlabel">
                Payment In Words</td>
            <td>
                <asp:Label ID="txt_paymentwords" runat="server" Text=''></asp:Label>
                <asp:HiddenField ID="HiddenField1" runat="server"  />
                <script type="text/javascript">
                calctax(document.getElementById("ContentPlaceHolder1_txt_initialamt"));
function Reset1_onclick() {

}

                </script>
             </td>
        </tr>
        <tr>
            <td class="formlabel">
                Month Installment</td>
            <td>
                &nbsp;<asp:DropDownList ID="ddl_month" runat="server">
                <asp:ListItem Value="">--Select--</asp:ListItem>
                <asp:ListItem Value="Jan">Jan</asp:ListItem>
                 <asp:ListItem Value="Feb">Feb</asp:ListItem>
                  <asp:ListItem Value="Mar">Mar</asp:ListItem>
                   <asp:ListItem Value="Apr">Apr</asp:ListItem>
                   <asp:ListItem Value="May">May</asp:ListItem>
                    <asp:ListItem Value="Jun">Jun</asp:ListItem>
                     <asp:ListItem Value="Jul">Jul</asp:ListItem>
                      <asp:ListItem Value="Aug">Aug</asp:ListItem>
                       <asp:ListItem Value="Sep">Sep</asp:ListItem>
                        <asp:ListItem Value="Oct">Oct</asp:ListItem>
                         <asp:ListItem Value="Nov">Nov</asp:ListItem>
                    <asp:ListItem Value="Dec">Dec</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel">
                Payment Mode</td>
            <td>
                <asp:DropDownList ID="ddl_paymode" runat="server" onChange="chkval()">
                <asp:ListItem Value="">--Select--</asp:ListItem>
                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                 <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                  <asp:ListItem Value="D.D">D.D</asp:ListItem>
                   <asp:ListItem Value="C.C">C.C</asp:ListItem>
                   <asp:ListItem Value="Online Transfer">Online Transfer</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel">
                Cheque / D.D No / C.C No / UTR No</td>
            <td style="height: 37px">
                <asp:TextBox ID="txt_ddcc" onFocus="losefocus(this)" CssClass="text" MaxLength="20" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formlabel">
                checque/D.D&nbsp; Date</td>
            <td style="height: 37px">
                <asp:TextBox ID="dddate" runat="server" CssClass="datepicker" Width="123px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formlabel">
                Bank Name</td>
            <td style="height: 37px">
                <asp:TextBox ID="txt_bankname" onFocus="losefocus(this)" runat="server" CssClass="text" MaxLength="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formlabel">
                Payment Towards</td>
            <td style="height: 37px">
                &nbsp;<asp:Label ID="txt_paymenttowards" runat="server" Text=' Image Creative Education Pvt Ltd.'></asp:Label>
                <asp:HiddenField ID="hdnTax" runat="server" />
            </td>
        </tr>
                <tr>
                    <td colspan="2" >
                        <asp:HiddenField ID="hdnAmtWithTax" runat="server" />
                       <asp:Button ID="btnBack" CssClass="btnStyle1" runat="server" Text="Back" OnClick="btnBack_Click" />
                       
                        <asp:Button ID="Btnupdate" CssClass="btnStyle1" runat="server" Text="Make Receipt" OnClientClick="javascript:return add();" OnClick="Btnupdate_Click"  />
                        
                        </td>
                </tr>
            </table>
			</div>
            
</asp:Content>

