<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="leaveapprove.aspx.cs" Inherits="superadmin_leaveapprove" Title="Leave Approve" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
 <script language="javascript" type="text/javascript">
 
   function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  
function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
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
	        
	 function Validate()
     {
     
        clearValidation('ContentPlaceHolder1_txtc_code~ContentPlaceHolder1_txtc_location~ContentPlaceHolder1_ddc_region~ContentPlaceHolder1_txt_enquirycount~ContentPlaceHolder1_txt_receiptcount~ContentPlaceHolder1_txt_invoicecount');
        
        //alert("test")
        
         if(trim(document.getElementById("ContentPlaceHolder1_txtc_code").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtc_code").value=="";   
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Centre Code!';
             document.getElementById("ContentPlaceHolder1_txtc_code").focus();
             document.getElementById("ContentPlaceHolder1_txtc_code").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_code").style.backgroundColor="#e8ebd9";
           
             return false;
         }
        
    
      else if(trim(document.getElementById("ContentPlaceHolder1_txtc_location").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtc_location").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Centre Location!';
             document.getElementById("ContentPlaceHolder1_txtc_location").focus();
             document.getElementById("ContentPlaceHolder1_txtc_location").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_location").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ContentPlaceHolder1_ddc_region").value=="")
         {
             
             document.getElementById("ContentPlaceHolder1_ddc_region").focus();
             document.getElementById("ContentPlaceHolder1_ddc_region").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddc_region").style.backgroundColor="#e8ebd9";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML =' *Please Enter the Centre Region!';
             return false;
         }
            
	       else if(trim(document.getElementById("ContentPlaceHolder1_txt_enquirycount").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_enquirycount").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Enquiry Count!';
             document.getElementById("ContentPlaceHolder1_txt_enquirycount").focus();
             document.getElementById("ContentPlaceHolder1_txt_enquirycount").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_enquirycount").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_receiptcount").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_receiptcount").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Receipt Count!';
             document.getElementById("ContentPlaceHolder1_txt_receiptcount").focus();
             document.getElementById("ContentPlaceHolder1_txt_receiptcount").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_receiptcount").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_invoicecount").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_invoicecount").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Invoice Count!';
             document.getElementById("ContentPlaceHolder1_txt_invoicecount").focus();
             document.getElementById("ContentPlaceHolder1_txt_invoicecount").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_invoicecount").style.backgroundColor="#e8ebd9";
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
    //var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

	if(CheckExpression.test(Str))// test Method to check for Regular Expression
	{
		return true;
	}
	else
	{
		return false
	}
}
function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_txtsearchlocation").value=="" && document.getElementById("ContentPlaceHolder1_txtsearchname").value=="" )
         {
         
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").focus();
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_txtc_code").value="";
document.getElementById("ContentPlaceHolder1_txtc_location").value="";
document.getElementById("ContentPlaceHolder1_txtc_managerid").value="";
document.getElementById("ContentPlaceHolder1_txt_manager_mailid").value="";
document.getElementById("ContentPlaceHolder1_txtc_managername").value="";
document.getElementById("ContentPlaceHolder1_txtcentrecat").value="";

document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value="";
document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").value="";


  var liste = document.getElementById("ContentPlaceHolder1_ddc_region");
                var howMany = liste.options.length;

                for(var i = 0; i < howMany; i++)
                {
                    if(liste[i].selected)
                    {
                    liste[i].selected=false;
                    }
                }    


}



</script>
    <br />
    <table class="common">
    <tr><td colspan="2" style="padding:0px;"><h4>Student Leave Request</h4></td></tr> <tr><td colspan="2">
    <asp:GridView ID="grdcentre" runat="server" CssClass="common" AutoGenerateColumns="False" OnRowCommand="grdcentre_RowCommand" AllowPaging="True" OnPageIndexChanging="grdcentre_PageIndexChanging" PageSize="10" EmptyDataText="No Records Found">
        <Columns>
             <asp:BoundField DataField="studentid" HeaderText="Student Id" />
            <asp:BoundField DataField="enq_personal_name" HeaderText="Name" />
            <asp:BoundField DataField="fromdate" HeaderText="From Date" />
            <asp:BoundField DataField="todate" HeaderText="To Date" />
            <asp:BoundField DataField="reason" HeaderText="Reason" />
             <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove" CommandName="approve" CssClass="submit" CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> 
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline" CssClass="submit" CommandName="decline" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>                 
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
        <EmptyDataRowStyle ForeColor="Red" />
    </asp:GridView>
    
    </td></tr></table>
    <br />
    <asp:HiddenField ID="hdnID" runat="server" />
    &nbsp;
    <br />
    <br />

</asp:Content>

