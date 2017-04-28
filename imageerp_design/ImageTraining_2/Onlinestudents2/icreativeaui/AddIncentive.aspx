<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="AddIncentive.aspx.cs" Inherits="superadmin_AddIncentive" Title="Incentive Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {
    $("#ct100_ContentPlaceHolder1_txt_stuid").autocomplete('Handler2.ashx');
});  
    
</script>
<script language="javascript" type="text/javascript">

  function trim(stringToTrim)
	{
		return stringToTrim.replace(/^\s+|\s+$/g,"");
    }
  
 
function Incentive()
 {
    var txtstudentid = document.getElementById('<%= this.txt_stuid.ClientID %>');
      
      if(trim(txtstudentid.value)=="")
         {    
             alert("Please Enter Student ID");
             txtstudentid.value == "";
             txtstudentid.focus();
             txtstudentid.style.border="#ff0000 1px solid";
             txtstudentid.style.backgroundColor="#e8ebd9";
             return false;
         }
       
         else
         {
         return true;
         }
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
       document.getElementById("tblstudent").style.display="block";      
       document.getElementById("tblstaff").style.display="none";
    }
    else if( val=="Staff")
    {       
       document.getElementById("tblstudent").style.display="none";      
       document.getElementById("tblstaff").style.display="block";
    }
     else if( val=="Both")
    {      
       document.getElementById("tblstudent").style.display="block";
       document.getElementById("tblstaff").style.display="block";
    }
  }
</script>
   <div class="title-cont">
    <h3 class="cont-title">Add Incentive</h3>
   
  </div>
      
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                    <div class="search-sec-cont">
    <div align="center">
      <asp:Label ID="lbl_errormsg" runat="server" CssClass="error"></asp:Label>
    </div>
    <ul>
      <li>
        <div class="wth-1">Enter Student ID</div>
        <div class="wth-2">
                    <asp:TextBox ID="txt_stuid" CssClass="text input-txt" runat="server" Width="225px"></asp:TextBox>
                    </div>
                    </li>  
      <li>
        <div align="center">                     
                     <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Incentive();" OnClick="btn_submit_Click" />
                                          <br />
                    <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_stuid"></asp:CustomValidator>
			</div></li>	 </ul><div class="clear"></div> </div>
                              
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                 <%--   <div class="title-cont"> STUDENT REFERENCE INCENTIVE FORM</div>--%>
					<div class="white-cont">
					 <h4 class="cont-title3">Joined Details</h4>
					<div class="padd-cont">
					<div class="form-cont">
                            <div align="center">
                                    <asp:Label ID="lblalert" runat="server" CssClass="error" Text=""></asp:Label>
                                    </div>
                           <ul>                       
                             <li><label class="label-txt">
                                    Student ID<span style="color: #ff0000">*</span></label>
                             <asp:TextBox ID="txtstudentid" runat="server" CssClass="text input-txt" MaxLength="60"
                                        Width="225px"></asp:TextBox></li>
                          <li><label class="label-txt">
                                    Student Name <span style="color: #ff0000">*</span></label>
                             <asp:TextBox ID="txtstudentname" runat="server" CssClass="text input-txt" MaxLength="50" Width="225px"></asp:TextBox>
                               </li>
                         <li><label class="label-txt">
                                    Invoice Number <span style="color: #ff0000">*</span></label>
                      <asp:TextBox ID="txtinvoicenum" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="10" Width="225px"></asp:TextBox>
                      </li>
                            <li><label class="label-txt">
                                    Receipt Number <span style="color: #ff0000">*</span></label>
                               <asp:TextBox ID="txtreceiptnum" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="225px"></asp:TextBox>
                               </li>
                            <li><label class="label-txt">
                                    Amount Paid <span style="color: #ff0000">*</span></label>
                              <asp:TextBox ID="txtamountpaid" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="225px"></asp:TextBox>
                              </li>
                            <li><label class="label-txt">
                                    Select Incentive Type<span style="color: #ff0000">*</span></label>
                              
                                <asp:DropDownList ID="ddlIncentiveType" runat="Server" CssClass="sele-txt" onChange="setIncentiveData(this.value)" >
                                <asp:ListItem Value="Student" >Student</asp:ListItem>
                                 <asp:ListItem Value="Staff" >Staff</asp:ListItem>
                                  <asp:ListItem Value="Both" >Both</asp:ListItem>
                                </asp:DropDownList></li>
                                </ul><div class="clear"></div></div></div>
                          
                            <h4 class="cont-title3">Reference Details</h4>
					<div class="padd-cont">
					<div class="form-cont">
                            <ul id="tblstudent" style="display:block;">           
                            <li><label class="label-txt">
                                        Refered Student Name
                                    </label>
                                    <asp:TextBox ID="txtreferstudentname" runat="server" CssClass="text input-txt" Width="225px"></asp:TextBox></li>
                                  <li><label class="label-txt">
                                        Refered Student ID<span style="color: #ff0000">*</span></label>
                                   <asp:TextBox ID="txtreferstudentid" runat="server" CssClass="text input-txt" Width="225px"></asp:TextBox></li>
                                 <li><label class="label-txt">
                                    Incentive Amount for Student</label>
                                   <asp:TextBox ID="txtstudentincentamt" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="125px"></asp:TextBox>
                                    </li>
                                     <li><label class="label-txt">
                                        Student Ref. Cheque No :</label>
                                   <asp:TextBox ID="txtstudentchequeno" runat="server" CssClass="text input-txt" Width="125px"></asp:TextBox></li>
                                 <li><label class="label-txt">
                                        Date</label>
                                        <span class="date-pick-cont">
                                   <asp:TextBox ID="txtstudentchequedate" runat="server" onpaste="return false" onKeyPress="return false" CssClass="text datepicker date-input-txt " Width="125px"></asp:TextBox>
                                   </span>
                                    <li><label class="label-txt">
                                     Bank Name </label>
                                  <asp:TextBox ID="txtstudentbankname" runat="server" CssClass="text input-txt" Width="225px"></asp:TextBox></li>
                                   </ul><div class="clear"></div>
                               
                                   <div class="padd-cont">
					<div class="form-cont">
                            <ul id="tblstaff" style="display:none;">           
                            <li><label class="label-txt">
                                   Refered Staff Name <span style="color: #ff0000">*</span></label>
                                   
                                    <asp:TextBox ID="txtreferstaffname" runat="server" CssClass="text input-txt" Width="225px"></asp:TextBox>
                                   </li>
                               <li><label class="label-txt">
                                        Incentive Amount for Staff</label>
                                 <asp:TextBox ID="txtstaffincentamt" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="12" Width="125px"></asp:TextBox>
                                 </li>
                                    <li><label class="label-txt">
                                        Staff Ref. Cheque No </label>
                                   <asp:TextBox ID="txtstaffchequeno" runat="server" CssClass="text input-txt" Width="125px"></asp:TextBox></li>
                               <li><label class="label-txt">
                                        Date :
                                     </label>
                                     <span class="date-pick-cont ">
                                  <asp:TextBox ID="txtstaffchequedate" runat="server" CssClass="text datepicker date-input-txt" Width="125px"></asp:TextBox>
                              </span></li>
                                    <li><label class="label-txt">
                                        Bank Name </label>                                 
                                        <asp:TextBox ID="txtstaffbankname" runat="server" CssClass="text input-txt" Width="225px"></asp:TextBox></li>
                               </ul><div class="clear"></div></div></div>
                           <div class="padd-cont">
					<div class="form-cont">
                            <ul>     <li><label class="label-txt">
                                    Approved By <span style="color: #ff0000">*</span></label>                                  
                                     <asp:TextBox ID="txtapproveby" runat="server" CssClass="text input-txt"  Width="225px"></asp:TextBox></li>
                                <li><label class="label-txt">
                                    Payment Issued By <span style="color: #ff0000">*</span></label>
                                         <asp:TextBox ID="txtpaymentissueby" runat="server" CssClass="text input-txt"  Width="225px"></asp:TextBox></li>
                            <li>
        <div align="center">
                                  <asp:Button ID="btnAddIncentive" runat="server" CssClass="btnStyle1"   Text="Save" OnClientClick="return validateForm();" OnClick="btnAddIncentive_Click" />
                                    <asp:Button  ID="btnReset"  runat="server" class="reset-btn"   Text="Reset" OnClick="btnReset_Click"  />
                          </div></li></ul><div class="clear"></div>
						</div></div>
                    </asp:View>
                </asp:MultiView>
  
</asp:Content>

