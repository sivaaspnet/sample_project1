<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="editIncentive.aspx.cs" Inherits="superadmin_editIncentive" Title="Incentive Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {
    $("#ContentPlaceHolder1_txt_stuid").autocomplete('Handler2.ashx');
});  
    
</script>
<script language="javascript" type="text/javascript">

  function trim(stringToTrim)
	{
		return stringToTrim.replace(/^\s+|\s+$/g,"");
    }
  
 
 

function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txt_stuid").value="";


}
   function clearValidation(fieldList) 
   {	
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

    function CheckNumeric(GetEvt)
    {
	    var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
    	
	    if(Char > 31 && (Char < 48 || Char >57))
		    return false;
		    return true;
    }

   function MaxLength(field, maxLength)
    {
        if (field.value.length >= maxLength)
            field.value = field.value.substring(0, maxLength - 1);
    }
      
    
         
     function AllowAlphabet(e)
        {
	        isIE=document.all? 1:0
	        keyEntry = !isIE? e.which:event.keyCode;
	        if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
		        return true; 
	        } else {
		        return false;
	        }
        }
function validateForm()
{ 
         var txtstudentid = document.getElementById('<%= this.txtstudentid.ClientID %>');
         var txtstudentname = document.getElementById('<%= this.txtstudentname.ClientID %>');
         var txtinvoicenum = document.getElementById('<%= this.txtinvoicenum.ClientID %>');
         var txtreceiptnum = document.getElementById('<%= this.txtreceiptnum.ClientID %>');
         var txtamountpaid = document.getElementById('<%= this.txtamountpaid.ClientID %>');
         var txtreferstudentname = document.getElementById('<%= this.txtreferstudentname.ClientID %>');
         var txtstudentincentamt = document.getElementById('<%= this.txtstudentincentamt.ClientID %>');
         var txtapproveby = document.getElementById('<%= this.txtapproveby.ClientID %>');
         var txtpaymentissueby = document.getElementById('<%= this.txtpaymentissueby.ClientID %>');
         var ddlreftype = document.getElementById('<%= this.ddlIncentiveType.ClientID %>');
         var txtrefstudid = document.getElementById('<%= this.txtreferstudentid.ClientID %>');
         var txtreferstaff = document.getElementById('<%= this.txtreferstaffname.ClientID %>');
          
         if (txtstudentid.value == "") {
             alert("Please enter Student ID");
             txtstudentid.focus();            
             txtstudentid.style.border="#ff0000 1px solid";
             txtstudentid.style.backgroundColor="#e8ebd9";
             return false;
         }
         else if (txtstudentname.value == "") {
             alert("Please enter address");
             txtstudentname.focus();
             txtstudentname.style.border="#ff0000 1px solid";
             txtstudentname.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (txtinvoicenum.value == "") {
             alert("Please enter invoice number");          
             txtinvoicenum.focus();
             txtinvoicenum.style.border="#ff0000 1px solid";
             txtinvoicenum.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (txtreceiptnum.value == "") {
             alert("Please enter receipt number");
             txtreceiptnum.focus();
             txtreceiptnum.style.border="#ff0000 1px solid";
             txtreceiptnum.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (txtamountpaid.value == "") {
             alert("Please enter amount paid");
             txtamountpaid.focus();
             txtamountpaid.style.border="#ff0000 1px solid";
             txtamountpaid.style.backgroundColor="#e8ebd9";
             return false
         } 
          else if (txtapproveby.value == "") {
             alert("Please enter approve by");
             txtapproveby.focus();
               txtapproveby.style.border="#ff0000 1px solid";
             txtapproveby.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (txtpaymentissueby.value == "") {
             alert("Please enter payment issue by");
             txtpaymentissueby.focus();
               txtpaymentissueby.style.border="#ff0000 1px solid";
             txtpaymentissueby.style.backgroundColor="#e8ebd9";
             return false
         }     
         else if(ddlreftype.value =="Student")
         {
           if(txtrefstudid.value == "") 
           {
             alert("Please enter reference student id");
             txtrefstudid.focus();
             txtrefstudid.style.border="#ff0000 1px solid";
             txtrefstudid.style.backgroundColor="#e8ebd9";
             return false
           }           
         } 
         else if(ddlreftype.value =="Staff")
         {
           if(txtreferstaff.value == "") 
           {
             alert("Please enter reference staff name");
             txtreferstaff.focus();
             txtreferstaff.style.border="#ff0000 1px solid";
             txtreferstaff.style.backgroundColor="#e8ebd9";
             return false
           }           
         }  
         else if(ddlreftype.value =="Both")
         {
           if(txtrefstudid.value == "") 
           {
             alert("Please enter reference student id");
             txtrefstudid.focus();
             txtrefstudid.style.border="#ff0000 1px solid";
             txtrefstudid.style.backgroundColor="#e8ebd9";
             return false
           }   
           else if(txtreferstaff.value == "") 
           {
             alert("Please enter reference staff name");
             txtreferstaff.focus();
             txtreferstaff.style.border="#ff0000 1px solid";
             txtreferstaff.style.backgroundColor="#e8ebd9";
             return false
           }           
         }      
         else
         {
          return true
         }
}
  function setIncentiveData(val)
  {
    if(val=="Student")
    {       
       document.getElementById("<%= this.tblstudent.ClientID %>").style.display="block";      
       document.getElementById("<%= this.tblstaff.ClientID %>").style.display="none";
    }
    else if( val=="Staff")
    {       
       document.getElementById("<%= this.tblstudent.ClientID %>").style.display="none";      
       document.getElementById("<%= this.tblstaff.ClientID %>").style.display="block";
    }
     else if( val=="Both")
    {      
       document.getElementById("<%= this.tblstudent.ClientID %>").style.display="block";
       document.getElementById("<%= this.tblstaff.ClientID %>").style.display="block";
    }
  }
</script>
  <div class="free-forms">
    <table border="0" style="width: 100%">
        <tr>
            <td align="left" colspan="3" style="height: 25px" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 20px" valign="middle">
                &nbsp;<table class="common" width="100%">
                            <tr>
                                <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                    padding-top: 0px">
                                    <h4>
                                       STUDENT REFERENCE INCENTIVE FORM</h4>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Label ID="lblalert" runat="server" CssClass="error" Text=""></asp:Label></td>
                            </tr>
                              <tr>
                                <td class="formlabel" colspan="2" style="height: 30px">
                                    <span style="background-color: #f9f9f9">Joined Details</span></td>
                            </tr>
                            <tr style="background-color: #f9f9f9">
                                <td class="formlabel">
                                    Student ID<span style="color: #ff0000">*</span></td>
                                <td align="left" valign="middle">
                                    <asp:TextBox ID="txtstudentid" runat="server" CssClass="text" MaxLength="60"
                                        Width="225px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="formlabel">
                                    Student Name <span style="color: #ff0000">*</span></td>
                                <td align="left" style="height: 25px" valign="middle">
                                    <asp:TextBox ID="txtstudentname" runat="server" CssClass="text" MaxLength="50" Width="225px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formlabel">                                    
                                    Invoice Number<span style="color: #565656; background-color: #f9f9f9;">*</span></td>
                                <td align="left" valign="middle" style="color: #ff0000">
                                    <asp:TextBox ID="txtinvoicenum" runat="server" CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="10" Width="225px"></asp:TextBox></td>
                            </tr>
                            <tr style="color: #565656; background-color: #f9f9f9">
                                <td class="formlabel">
                                  
                                    Receipt Number <span style="color: #ff0000;">*</span></td>
                                <td align="left" valign="middle" style="color: #565656; background-color: #f9f9f9">
                                    <asp:TextBox ID="txtreceiptnum" runat="server" CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="225px"></asp:TextBox></td>
                            </tr>
                            <tr style="color: #565656; background-color: #f9f9f9">
                                <td class="formlabel">
                                   
                                    Amount Paid <span style="color: #ff0000">*</span></td>
                                <td align="left" valign="middle" style="color: #565656">
                                       <asp:TextBox ID="txtamountpaid" runat="server" CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="225px"></asp:TextBox></td>
                            </tr>                        
                            <tr style="color: #565656">
                                <td class="formlabel">
                                    <strong>
                                    Select Incentive Type&nbsp; </strong><span style="color: #ff0000">*</span></td>
                                <td align="left" valign="middle" style="color: #565656">
                                <asp:DropDownList ID="ddlIncentiveType" runat="Server" CssClass="text" onChange="setIncentiveData(this.value)" >
                                <asp:ListItem Value="Student" >Student</asp:ListItem>
                                 <asp:ListItem Value="Staff" >Staff</asp:ListItem>
                                  <asp:ListItem Value="Both" >Both</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr> 
                            <tr>
                                <td class="formlabel" colspan="2" style="height: 30px">
                                    Reference Details</td>
                            </tr>
                            <tr>
                            <td colspan="2">
                            <table id="tblstudent" runat="Server"   style="display:block;" class="common" cellpadding="0" cellspacing="0" width="100%" >
                                <tr>
                                    <td >
                                        Refered Student Name
                                    </td>
                                    <td >
                                    <asp:TextBox ID="txtreferstudentname" runat="server" CssClass="text" Width="225px"></asp:TextBox></td>
                                    <td >
                                        Refered Student ID&nbsp; <span style="color: #ff0000">*</span></td>
                                    <td style="color: #565656">
                                        <asp:TextBox ID="txtreferstudentid" runat="server" CssClass="text" Width="225px"></asp:TextBox></td>
                                </tr>
                                <tr style="color: #565656">
                                    <td >
                                       Incentive Amount for Student 
                                    </td>
                                    <td style="width: 174px; color: #ff0000;">
                                      <asp:TextBox ID="txtstudentincentamt" runat="server" CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="125px"></asp:TextBox>
                                    </td>
                                    <td >
                                        Student Ref. Cheque No :
                                        <br />
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtstudentchequeno" runat="server" CssClass="text" Width="125px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td >
                                        Date :</td>
                                    <td >
                                        &nbsp;<asp:TextBox ID="txtstudentchequedate" runat="server" CssClass="text datepicker" Width="125px" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
                                    <td >
                                     Bank Name : 
                                    </td>
                                    <td>
                                     <asp:TextBox ID="txtstudentbankname" runat="server" CssClass="text" Width="225px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table  id="tblstaff" runat="Server" style="display:none;" class="common" cellpadding="0" cellspacing="0" width="100%" >
                                <tr>
                                    <td>
                                        Refered Staff Name&nbsp; <span style="color: #ff0000">*</span></td>
                                    <td style="color: #565656">
                                    <asp:TextBox ID="txtreferstaffname" runat="server" CssClass="text" Width="225px"></asp:TextBox></td>
                                    <td style="color: #565656">
                                    </td>
                                    <td style="color: #565656">
                                    </td>
                                </tr>
                                <tr style="color: #565656">
                                    <td>
                                        Incentive Amount for Staff
                                    </td>
                                    <td>
                                        <span style="color: #ff0000">&nbsp;</span><asp:TextBox ID="txtstaffincentamt" runat="server" CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="125px"></asp:TextBox></td>
                                    <td >
                                        Staff Ref. Cheque No : &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtstaffchequeno" runat="server" CssClass="text" Width="125px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Date :
                                     </td>
                                    <td>
                                         <asp:TextBox ID="txtstaffchequedate" runat="server" CssClass="text datepicker" Width="125px" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
                                    <td>
                                        Bank Name : </td>
                                    <td>
                                        <asp:TextBox ID="txtstaffbankname" runat="server" CssClass="text" Width="225px"></asp:TextBox></td>
                                </tr>
                            </table>
                            </td>
                            </tr>
                           <tr>
                                <td class="formlabel" style="height: 38px">
                                    Approved By <span style="color: #ff0000">*</span>
                                </td>
                                <td align="left" style="height: 38px" valign="middle">
                                     <asp:TextBox ID="txtapproveby" runat="server" CssClass="text"  Width="225px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="formlabel" style="height: 38px">
                                    Payment Issued By <span style="color: #ff0000">*</span>
                                </td>
                                <td align="left" style="height: 38px" valign="middle">
                                       <asp:TextBox ID="txtpaymentissueby" runat="server" CssClass="text"  Width="225px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="height: 29px" valign="middle">
                                    &nbsp;<asp:Button ID="btnUpdateIncentive" runat="server" CssClass="btnStyle1"   Text="Update" OnClientClick="return validateForm();" OnClick="btnUpdateIncentive_Click"  />
                                    <asp:Button  ID="btnReset"  runat="server" class="btnStyle2"   Text="Reset" OnClick="btnReset_Click"  /></td>
                            </tr>
                        </table>
						</td>
        </tr>
        <tr>
            <td style="border:none">
                </td>
        </tr>
    </table>
	</div>
    <br />
    <br />
  
</asp:Content>

