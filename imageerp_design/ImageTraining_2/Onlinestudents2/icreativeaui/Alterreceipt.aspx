<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Alterreceipt.aspx.cs" Inherits="superadmin_Alterreceipt" Title="Receipt edit" %>
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

function faculty()
{
    if(document.getElementById("ContentPlaceHolder1_txtchangereason").value=="")
    { 
        alert("Please enter the reason for change the receipt");
        document.getElementById("ContentPlaceHolder1_txtchangereason").value == "";
        document.getElementById("ContentPlaceHolder1_txtchangereason").focus();
        document.getElementById("ContentPlaceHolder1_txtchangereason").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtchangereason").style.backgroundColor="#e8ebd9";
        return false;
    }
    else
    {
        return true;
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

       	        
 
</script>
 
   <div class="title-cont">
    <h3 class="cont-title">Alter Receipt</h3>
    </div>
			 
  <div class="white-cont">
            <h4  class="cont-title2">
                Receipt Edit</h4>
             

       <div class="form-cont">
        <ul>
                
            <li>
            <label class="label-txt">
            Student Id</label>
            <asp:TextBox ID="txtstudentid" runat="server" CssClass="text input-txt"></asp:TextBox> <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtstudentid"></asp:CustomValidator></li>
        <li>
            <label class="label-txt">
            Receipt No</label>
            <asp:TextBox ID="txtreceipt" runat="server" CssClass="text input-txt"></asp:TextBox>&nbsp;
            <asp:Button ID="btnsearch" runat="server" CssClass="search" OnClick="btnsearch_Click" /></li>
        <li>
            <label class="label-txt"></label>
                <asp:GridView ID="gvreceipt" CssClass="tbl-cont3" runat="server" AutoGenerateColumns="False" OnRowCommand="gvreceipt_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="invoiceno" HeaderText="Invoice no" />
                        <asp:BoundField DataField="date" HeaderText="Receipt date" />
                        <asp:TemplateField HeaderText="Receipt No">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edt" CommandArgument='<%# Eval("receiptno") %>' Text='<%# Eval("receiptno") %>'></asp:LinkButton>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
          </li>
      </ul> <div class="clear"></div>
      <div id="details" runat="server" visible="false">
         <ul>
    <li >
          <div  align="center">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></div>
                   </li>         <li>
            <label class="label-txt">
                        Student id</label>
                  
                        <asp:TextBox ID="txtname" CssClass="text input-txt " runat="server" ></asp:TextBox></li>
              <li>
            <label class="label-txt">
                        Invoice No</label>
          <asp:TextBox ID="txtinvoice" CssClass="text input-txt" runat="server"></asp:TextBox></li>
                 <li>
            <label class="label-txt">
                Amount</label>
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
              <asp:TextBox ID="txtrecdate" runat="server" Width="125px" onkeypress="return false" onkeydown="return false" onpaste="return false" CssClass="text datepicker date-input-txt"></asp:TextBox> </li>
          </span>    <li>
            <label class="label-txt">
                        Payment Type</label>
                    <asp:DropDownList ID="ddlpattern" runat="server" CssClass="sele-txt">
                         <asp:ListItem Value="Cash">Cash</asp:ListItem>
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                    <asp:ListItem Value="D.D">D.D</asp:ListItem>
                    <asp:ListItem Value="Creditcard">Creditcard</asp:ListItem>
<asp:ListItem Value="Online Transfer">Online Transfer</asp:ListItem>
                        </asp:DropDownList></li>
                <li>
            <label class="label-txt">
                Bank name</label>
                <asp:TextBox ID="txtbank" runat="server" CssClass="text input-txt"></asp:TextBox></li>
                 <li>
            <label class="label-txt">
                        Challon number</label>
                  
                        <asp:TextBox ID="txtcheckno" runat="server" CssClass="text input-txt"></asp:TextBox></li>
               <li>
            <label class="label-txt">
                        Reason</label>
               <asp:TextBox ID="txtchangereason" Width="260px" TextMode="MultiLine" runat="server" CssClass="text input-txt"></asp:TextBox></li>
              
                  <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">
            <asp:Button ID="btn_add" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return faculty();" OnClick="btn_add_Click" />&nbsp;
            <input id="Reset2" type="reset" value="Reset" class="reset-btn" /></div>
               </li></ul>
               <div class="clear"></div>
               </div></div>
               </div>
   

     













</asp:Content>

