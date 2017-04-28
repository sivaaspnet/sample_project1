<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="insertoldreceipt.aspx.cs" Inherits="superadmin_insertoldreceipt" Title="Receipt edit" %>
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
 function Validate_Email(Email)
           {
            var Str=Email
            var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
            if(CheckExpression.test(Str))
            {
	            return true;
            }
            else
            {
	            return false;
            }
          }  
 function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
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
function emptyValidation(fieldList)
 {
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	var cc="";
	for(i=0;i<field.length;i++)
        {
		    if(trim(document.getElementById(field[i]).value)=="")
              {
                document.getElementById(field[i]).focus();
			    document.getElementById(field[i]).style.border="#FF0000 1px solid";
			     document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
			    counter++;
			    if(cc == "") {
			        cc = field[i];
			    }
	          } 
              else 
              {
	            document.getElementById(field[i]).style.border="#EFEFEF";	
			    document.getElementById(field[i]).style.backgroundColor="#FFFFFF";	
	          }
	    }
	if(counter>0)
        {
		alert('Please populate the required/highlighted fields.');
        if(cc!="")
         {
        document.getElementById(cc).focus();
         }
		return false;				
	}  
      else{ return true; }				
}

function checkValidation(fieldList)
{
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++)
	{
		if(trim(document.getElementById(field[i]).value)=="")
		{
		counter++;
		} 
	}
	if(counter>0)
	{
		return counter;				
	} else { 
		return counter; 
	}				
} 

    function onchangeddl()
{
 if(document.getElementById('ctl00_ContentPlaceHolder1_ddlpattern').value=="Cash")
    {
     document.getElementById('ctl00_ContentPlaceHolder1_trbank').style.display="none";
     document.getElementById('ctl00_ContentPlaceHolder1_trchallon').style.display="none";
    } 
    else if(document.getElementById('ctl00_ContentPlaceHolder1_ddlpattern').value!="Cash")
    {
    document.getElementById('ctl00_ContentPlaceHolder1_trbank').style.display='';
     document.getElementById('ctl00_ContentPlaceHolder1_trchallon').style.display='';
    }
 }
 function validate()
 {
  if(document.getElementById('ctl00_ContentPlaceHolder1_txtname').value=="")
  {
  alert('Please enter the student id');
  document.getElementById('ctl00_ContentPlaceHolder1_txtname').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txtinvoice').value=="")
  {
  alert('Please enter the invoice number');
  document.getElementById('ctl00_ContentPlaceHolder1_txtinvoice').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txtreceipt').value=="")
  {
  alert('Please entr the receipt number');
  document.getElementById('ctl00_ContentPlaceHolder1_txtreceipt').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txtamount').value=="")
  {
  alert('Please enter the amount');
  document.getElementById('ctl00_ContentPlaceHolder1_txtamount').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txttax').value=="")
  {
  alert('Please enter the tax');
  document.getElementById('ctl00_ContentPlaceHolder1_txttax').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txttotal').value=="")
  {
  alert('Please enter the total amount');
  document.getElementById('ctl00_ContentPlaceHolder1_txttotal').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txtinstall').value=="")
  {
  alert('Please enter the installment number');
  document.getElementById('ctl00_ContentPlaceHolder1_txtinstall').focus();
  return false;
  }
  else if(document.getElementById('ctl00_ContentPlaceHolder1_txtrecdate').value=="")
  {
  alert('Please select the receipt date');
  document.getElementById('ctl00_ContentPlaceHolder1_txtrecdate').focus();
  return false;
  }
  else
  {
  return true;
  }
 }
</script>
 
  <div class="title-cont">
 <h3 class="cont-title">Add Old Receipt</h3>
</div>
			 

    <div class="white-cont">    
                 <div align="center">           
            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>
                           </div>
                        
    <div class="form-cont">
        <ul>     
        <li></li>             
   <li>
            <label class="label-txt"> 
                        Student id</label>                   
                        <asp:TextBox ID="txtname" CssClass="text input-txt" runat="server" ></asp:TextBox>
                        <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtname"></asp:CustomValidator>
                        </li>
              <li>
            <label class="label-txt"> 
                        Invoice No</label>
              <asp:TextBox ID="txtinvoice" CssClass="text input-txt" runat="server"></asp:TextBox></li>
                <li>
            <label class="label-txt"> 
                        Receipt No</label>
                 <asp:TextBox ID="txtreceipt" runat="server" CssClass="text input-txt"></asp:TextBox></li>
                 <li>
            <label class="label-txt"> 
                Amount
            </label>
                <asp:TextBox ID="txtamount" runat="server" CssClass="text input-txt"></asp:TextBox></li>
        <li>
            <label class="label-txt"> 
                Tax</label>
                <asp:TextBox ID="txttax" runat="server" CssClass="text input-txt"></asp:TextBox></li>
          <li>
            <label class="label-txt"> 
                Total amount</label>
                <asp:TextBox ID="txttotal" runat="server" CssClass="text input-txt"></asp:TextBox></li>
              <li>
            <label class="label-txt"> 
                        Installment Number</label>
            <asp:TextBox ID="txtinstall" runat="server" CssClass="text input-txt"></asp:TextBox></li>
                <li>
            <label class="label-txt"> 
                        Receipt date</label>
                        <span class="date-pick-cont">
                  <asp:TextBox ID="txtrecdate" runat="server" CssClass="text datepicker date-input-txt" onkeydown="return false" onkeypress="return false" onpaste="return false" ></asp:TextBox>
             </span>   </li>
               <li>
            <label class="label-txt"> 
                        Payment towards</label>              
                        <asp:TextBox ID="txttowards" CssClass="text input-txt" runat="server"></asp:TextBox></li>
                <li>
            <label class="label-txt"> 
                        Receipt Type</label>
                     <asp:DropDownList ID="ddltype" CssClass="sele-txt" runat="server">
                        <asp:ListItem Value="Invoice">Invoice</asp:ListItem>
                        <asp:ListItem Value="Breakage">Breakage</asp:ListItem>
                        </asp:DropDownList></li>
                <li>
            <label class="label-txt"> 
                        Payment Type</label>
                        <asp:DropDownList ID="ddlpattern" runat="server"  CssClass="sele-txt">
                         <asp:ListItem Value="Cash">Cash</asp:ListItem>
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                    <asp:ListItem Value="D.D">D.D</asp:ListItem>
                    <asp:ListItem Value="C.C">Creditcard</asp:ListItem>
                        </asp:DropDownList></li>
                <li id="trbank">
            <label class="label-txt"> 
                Bank name</label>
                <asp:TextBox ID="txtbank" runat="server" CssClass="text input-txt"></asp:TextBox></li>
                <li id="trchallon" >
                   <label class="label-txt">
                        Challon number</label>                   
                        <asp:TextBox ID="txtcheckno" runat="server" CssClass="text input-txt"></asp:TextBox>
                </li>
               
              <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;"> 
            <asp:Button ID="btn_add" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return validate();" OnClick="btn_add_Click" />&nbsp;
            <input id="Reset2" type="reset" class="reset-btn" value="Reset" class="submit" /></div></li>
            <li>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tbl-cont3">
                <Columns>
                <asp:BoundField DataField="studentid" HeaderText="Student Id" />
                    <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                   <asp:BoundField DataField="receiptno" HeaderText="Receipt" />
                   <asp:BoundField DataField="invoiceno" HeaderText="Invoice" />
                   <asp:BoundField DataField="amount" HeaderText="Amount" />
                   <asp:BoundField DataField="taxamount" HeaderText="Tax" />
                   <asp:BoundField DataField="totalamount" HeaderText="Total Amount" />
                   <asp:BoundField DataField="date" HeaderText="Receipt Date" />
                   
                </Columns>
            </asp:GridView>
            </li>
            </ul>
          <div class="clear"></div>
       
</div></div>
   

     













</asp:Content>

