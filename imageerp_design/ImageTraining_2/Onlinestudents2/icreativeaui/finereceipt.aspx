<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="finereceipt.aspx.cs" Inherits="superadmin_finereceipt" Title="Fine Receipt Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
function trim(stringToTrim) {
	return stringToTrim.replace(/^\s+|\s+$/g,"");
}
	             
function chkval(){
	if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "Cash"){
		document.getElementById("ContentPlaceHolder1_txt_ddcc").value=""
		document.getElementById("ContentPlaceHolder1_txt_bankname").value=""
	}
}
   
function losefocus(obj){
   if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "Cash"){
		obj.value="";
		obj.blur()
	}
}
function CheckNumeric(GetEvt){
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
	return false;
	return true;
}  
 function add() {    
	if(trim(document.getElementById("ContentPlaceHolder1_txt_studname").value)=="")
	 {    
		 alert("Please enter student name");
		 document.getElementById("ContentPlaceHolder1_txt_studname").value = "";
		 document.getElementById("ContentPlaceHolder1_txt_studname").focus();
		 document.getElementById("ContentPlaceHolder1_txt_studname").style.border="#ff0000 1px solid";
		 document.getElementById("ContentPlaceHolder1_txt_studname").style.backgroundColor="#e8ebd9";
		 return false;
	 }
	else if(trim(document.getElementById("ContentPlaceHolder1_TextBox1").value)=="")
	 {    
		 alert("Please select fees");
		 document.getElementById("ContentPlaceHolder1_TextBox1").value = "";
		 document.getElementById("ContentPlaceHolder1_TextBox1").focus();
		 document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
		 document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
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
	 else if(document.getElementById("ContentPlaceHolder1_txtreason").value=="")
	 {    
		 alert("Please enter the reason");
		 document.getElementById("ContentPlaceHolder1_txtreason").value = "";
		 document.getElementById("ContentPlaceHolder1_txtreason").focus();
		 document.getElementById("ContentPlaceHolder1_txtreason").style.border="#ff0000 1px solid";
		 document.getElementById("ContentPlaceHolder1_txtreason").style.backgroundColor="#e8ebd9";
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
		 alert("Please enter cheque number");
		 document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
		 document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
		 document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
		 document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
		 return false;
	 }
	 else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_dddate").value == "")
	 {    
		 alert("Please enter cheque Date");
		 document.getElementById("ContentPlaceHolder1_txt_dddate").value = "";
		 document.getElementById("ContentPlaceHolder1_txt_dddate").focus();
		 document.getElementById("ContentPlaceHolder1_txt_dddate").style.border="#ff0000 1px solid";
		 document.getElementById("ContentPlaceHolder1_txt_dddate").style.backgroundColor="#e8ebd9";
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
	 
	 else {
	
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

function calctax(amtwit){
	var initial=parseInt(amtwit.value);
	var taxcal = parseFloat(initial /110.3);
	var taxcalh = parseFloat(taxcal*100);
	var totinitialtax=parseFloat(taxcalh);
	totinitialtax=Math.round(totinitialtax,0)
	//alert(totinitialtax);
	document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = totinitialtax;
	document.getElementById("ContentPlaceHolder1_hdnamt_tax").value = initial;
	test_skill(initial);
	document.getElementById("ContentPlaceHolder1_hdninitamt").value =amtwit.value;
}

</script>
  <div class="title-cont">
    <h3 class="cont-title">Add FINE Details</h3>
    <div class="breadcrumps">
      <ul>
        
        <li><a href="breakage.aspx">Breakage Details</a>/</li>
        <li><a href="#">Add FINE</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <input id="hdnpayinword" type="hidden" runat="server" />
  <input id="hdnamt_tax" type="hidden" runat="server" />
  <input id="hdninitamt" type="hidden" runat="server" />
  <div class="white-cont" style="padding:10px;">
    <form id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
      <div class="form-cont">
        <div style="text-align:center">
          <asp:Label ID="lblerrorMsg" CssClass="error" runat="server" Text=''></asp:Label>
        </div>
        <ul>
          <li>
            <label class="label-txt">Student Name</label>
            <asp:TextBox ID="txt_studname" runat="server" CssClass="text input-txt" MaxLength="50"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Fine</label>
            <asp:DropDownList onChange="calctax(this)" Visible="false" ID="ddl_breakage" runat="server" CssClass="input-txt"> </asp:DropDownList>
            <asp:TextBox ID="TextBox1" onKeyUp="calctax(this)" runat="server" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" MaxLength="5"></asp:TextBox>
            <asp:HiddenField ID="txt_initialamt" Value="0" runat="server" />
            <asp:HiddenField ID="lblamtwithtax" Value="0" runat="server" />
          </li>
          <li>
            <label class="label-txt">Payment In Words</label>
            <asp:Label ID="txt_paymentwords" runat="server" Text='' CssClass="label-txt2"></asp:Label>
            <asp:HiddenField ID="HiddenField1" runat="server"  />
            <script type="text/javascript">
            	calctax(document.getElementById("ContentPlaceHolder1_txt_initialamt"));
				function Reset1_onclick() { }
            </script>
          </li>
          <li>
            <label class="label-txt">Month Installment</label>
            <asp:DropDownList ID="ddl_month" runat="server" CssClass="sele-txt">
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
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt">Reason</label>
            <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine" CssClass="area-txt"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Payment Mode</label>
            <asp:DropDownList ID="ddl_paymode" runat="server" onChange="chkval()" CssClass="sele-txt">
              <asp:ListItem Value="">--Select--</asp:ListItem>
              <asp:ListItem Value="Cash">Cash</asp:ListItem>
              <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
              <asp:ListItem Value="D.D">D.D</asp:ListItem>
              <asp:ListItem Value="C.C">C.C</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt">Cheque / D.D No / C.C No</label>
            <asp:TextBox ID="txt_ddcc" onKeyPress="return CheckNumeric(event)" onFocus="losefocus(this)" CssClass="text input-txt" MaxLength="10" runat="server"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Cheque / D.D Date</label>
            <span class="date-pick-cont">
            <asp:TextBox ID="txt_dddate" runat="server" CssClass="datepicker date-input-txt"  onkeypress="return false" onpaste="return false"></asp:TextBox>
            </span>
          <li>
            <label class="label-txt">Bank Name</label>
            <asp:TextBox ID="txt_bankname" onFocus="losefocus(this)" runat="server" CssClass="text input-txt" MaxLength="30"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Payment Towards</label>
            <asp:Label ID="txt_paymenttowards" runat="server" Text='Image Creative Education Pvt Ltd.' CssClass="label-txt2"></asp:Label>
         
          </li>
          <li>
            <div align="center">
              <asp:Button ID="btnBack" CssClass="reset-btn" runat="server" Text="Back" OnClick="btnBack_Click" />
              <asp:Button ID="Btnupdate" CssClass="btnStyle1" runat="server" OnClientClick="javascript:return add();"  Text="Make Receipt" OnClick="Btnupdate_Click" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </form>
  </div>
</asp:Content>
