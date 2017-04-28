<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Imageupload.aspx.cs" Inherits="superadmin_addcentre" Title="Image Banner" %>

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
 <div class="free-forms">
    <table class="common" width="100%">
        <tr>
            <td style="padding:0px;" > <h4>
                Banner Details</h4>
            </td>
        </tr>
                                <tr><td style="text-align:center"><asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
    </tr></table>
    
    <asp:GridView ID="grdcentre" runat="server" CssClass="common" AutoGenerateColumns="False" 
                                OnRowCommand="grdcentre_RowCommand" AllowPaging="True" 
                                OnPageIndexChanging="grdcentre_PageIndexChanging" width="100%" PageSize="5" 
                                EmptyDataText="No Records Found">
        <Columns>
            <asp:TemplateField HeaderText="Name">
             <ItemTemplate>
             <%#removetilde(Eval("imagename").ToString())%>
             </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
             <ItemTemplate>
                 <asp:Image ID="Image1" 
                     ImageUrl='<%#Eval("imageurl")%>' 
                     runat="server" Height="55px" Width="178px" />  
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    &nbsp;
                    <asp:LinkButton ID="lnkedit" CommandName="lnkedit" CommandArgument='<%#Eval("id")%>' runat="server"><img src="layout/edit.png" alt="edit"/></asp:LinkButton> 
               
                   </ItemTemplate>
                <FooterTemplate>
                    &nbsp;
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
        <EmptyDataRowStyle ForeColor="Red" />
    </asp:GridView>
    <br />
     
        
    <table cellspacing="0" cellpadding="0" class="common" width="100%">
        <tr>
            <td colspan="2" style="padding:0px; text-align:left"> <h4>
        Add Image </h4> 
            </td>
        </tr>
    <tr><td colspan="2" style="text-align:center">
        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label></td></tr>
                        <tr>
                            <td class="w290 talignleft" style="width: 127px">
                                Slide</td>
                            <td align="left" valign="middle">
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                    </td>
                        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 127px">
                &nbsp; ImageUpload</td>
            <td align="left" valign="middle">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="middle" style="text-align:center;s" >
                <br />
    
    <asp:Button ID="btnsubmit" runat="server" Text="Update" CssClass="btnStyle1" 
                    OnClientClick="javascript:return Validate();" OnClick="btnsubmit_Click"/>&nbsp;
                <asp:Button ID="BtnReset" runat="server" CssClass="btnStyle2" OnClick="BtnReset_Click"
                    Text="Reset" /><br />
                <br />
            </td>
        </tr>
                    </table></div>
    <asp:HiddenField ID="hdnID" runat="server" Value="0" />
    &nbsp;
    <br />
    <br />

</asp:Content>

