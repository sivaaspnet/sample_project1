<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="receiptediting.aspx.cs" Inherits="superadmin_Receiptedit" Title="Receipt Edit Page" %>
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

 if(trim(document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value)=="")
         {    
             alert("Please select course");
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value = "";
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").focus();
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_studname").value)=="")
         {    
             alert("Please Enter Student Name");
             document.getElementById("ContentPlaceHolder1_txt_studname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_studname").focus();
             document.getElementById("ContentPlaceHolder1_txt_studname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studname").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)==""   )
         {    
             alert("Please Enter Initial Amount");
             document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)=="0"   )
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
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "")
         {    
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
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
var tax=parseFloat(document.getElementById("ContentPlaceHolder1_HiddenField2").value);
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
	document.getElementById("ContentPlaceHolder1_hdnamt_tax").value = initial;
	test_skill(initial);
	document.getElementById("ContentPlaceHolder1_hdninitamt").value =amtwit.value;
	
}

</script>

    <input id="hdnpayinword" type="hidden" runat="server" />
    <input id="hdnamt_tax" type="hidden" runat="server" />
    <input id="hdninitamt" type="hidden" runat="server" />
   
            
    <table width="400" class="common" border="1">
        <tr><td colspan="2 " style=" padding:0px;">  <h4>
            Express Receipt</h4></td></tr>        
                <tr>
                    <td class="w290 talignleft" style="width: 191px">
                        Course Code</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="txt_coursepositioned" runat="server" CssClass="select" AutoPostBack="True" OnSelectedIndexChanged="txt_coursepositioned_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 191px">
                        Student Name</td>
                    <td>
                        <asp:TextBox ID="txt_studname" runat="server"  MaxLength="30" TextMode="SingleLine" CssClass="text"></asp:TextBox></td>
                </tr>
        <tr>
            <td class="w290 talignleft" style="width: 191px">
                Registration Amount (With Tax)</td>
            <td>
                <asp:TextBox ID="txt_initialamt" runat="server" ReadOnly="False" onKeyUp="calctax(this)" onKeyPress="return CheckNumeric(event)" CssClass="text" MaxLength="6" >0</asp:TextBox></td>
        </tr>
         <tr>
            <td class="w290 talignleft" style="width: 191px">
                Registration Amount (Without Tax)</td>
            <td>
                <asp:Label ID="lblamtwithtax" runat="server" Text=''></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 191px">
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
            <td class="w290 talignleft" style="width: 191px">
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
                    <td colspan="2" style="height:30px" align="center" valign="middle" class="w290 talignleft">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; 
                        <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="Btnupdate" CssClass="submit" runat="server" Text="Make Receipt" OnClientClick="javascript:return add();" OnClick="Btnupdate_Click"  />
                        
                        </td>
                </tr>
            </table>
    <br />
    <table style=" margin:auto;" align="center">
        <tr align="center">
            <td style="width: 100px ; text-align:center;" align="center">
                <asp:GridView class="common" ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" Width="395px">
                    <Columns>
                        <asp:BoundField DataField="student_name" HeaderText="StudentName" />
                        <asp:TemplateField HeaderText="ReceiptNumber">
                            <ItemTemplate>
                               <a rel="modal" href="Receiptprint2.aspx?student_id=<%#Eval("student_id")%>&rec_no=<%#Eval("rec_no")%>&iframe=true&amp;width=1000&amp;height=700" class="error">
                                  <%#Eval("rec_no")%>
                              </a>
                              
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
            
</asp:Content>

