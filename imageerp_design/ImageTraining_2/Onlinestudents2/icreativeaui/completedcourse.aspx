<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="completedcourse.aspx.cs" Inherits="superadmin_addcentre" Title="Deactive" %>

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

function vv()
{
if(document.getElementById("ContentPlaceHolder1_txtc_code").value=="")
{
alert("Please enter Studentid");
      document.getElementById("ContentPlaceHolder1_txtc_code").focus();
      document.getElementById("ContentPlaceHolder1_txtc_code").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_txtc_code").style.backgroundColor="#e8ebd9";
      return false;
}
else
{
return true;
}
}


</script>
    <br />
    &nbsp;<br />
     
       <div class="free-forms"> 
    <table cellspacing="0" cellpadding="0" class="common" width="100%">
        <tr>
            <td colspan="3" style="padding:0px; text-align:left"> <h4>
                Deactive student from Course</h4> 
            </td>
        </tr>
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label></td></tr>
                        <tr>
                            <td class="formlabel" style="width: 127px">
                                Studentid</td>
                            <td  align="left" valign="middle" style="width:75px;">
                                <asp:TextBox ID="txtc_code" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                                </td>
                                            <td >
 <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="return vv()" OnClick="Button2_Click" />
 <br />
  <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtc_code"></asp:CustomValidator>
 </td>
                        </tr>
     
     
       
        <tr id="t1" runat="server" visible="false" >
        <td class="formlabel" style="width: 127px">
          Course
        </td>
            <td align="left" colspan="2"  valign="middle">
                &nbsp;
                <asp:CheckBoxList ID="CheckBoxList1"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"  >
                </asp:CheckBoxList></td>
        </tr>
        <tr id="t2" runat="server" visible="false">
            <td class="formlabel" style="width: 127px">
         Module
        </td>
            <td align="left" colspan="2" valign="middle" >
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" Enabled="false" RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:CheckBoxList>&nbsp;</td>
        </tr>
         <tr id="t3" runat="server" visible="false">
            <td class="formlabel" style="width: 127px">
        Software
        </td >
            <td align="left" colspan="2" valign="middle" >
                <asp:CheckBoxList ID="CheckBoxList3" runat="server" Enabled="false" RepeatColumns="4" RepeatDirection="Horizontal" >
                </asp:CheckBoxList>&nbsp;</td>
        </tr>
        <tr id="t4" runat="server" visible="false">
        <td colspan="3">
        <center>
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btnStyle1" OnClick="Button1_Click1" /></center>
        </td>
        </tr>
        <tr id="t5" runat="server" >
        <td colspan="3" style="text-align:center;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="StudentID" />
                    <asp:BoundField DataField="enq_personal_name" HeaderText="StudentName" />
                    <asp:BoundField DataField="studentstatus" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </td>
        </tr>
                    </table>
                    </div>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    &nbsp;&nbsp;
    <br />
    <br />

</asp:Content>

