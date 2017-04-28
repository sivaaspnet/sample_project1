<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="studenttransfer.aspx.cs" Inherits="superadmin_addcentre" Title="Student Transfer" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txt_searchcode").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
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
  <div class="title-cont">
    <h3 class="cont-title">Student Transfer Details</h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="studenttransfer.aspx" class="last">Student Transfer</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
    <div class="free-forms">    
      <div class="white-cont">
 <div class="form-cont">
          <ul class="no-borders">
            <li>
             <div>
                <asp:Label ID="Label1" runat="server" Text="Searchby Studentid" class="label-txt" style="max-width:125px"></asp:Label>        
                <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>       
           </div>
            </li>
            <li>
        <asp:TextBox ID="txt_searchcode" CssClass="text input-txt" runat="server" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnsearch" runat="server" CssClass="search"  OnClick="btnsearch_Click"/>
  
         <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_searchcode"></asp:CustomValidator>
       </li>
           <li>
                <div style="padding:0px 10px 10px 10px">
    <asp:GridView ID="grdcentre" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" OnRowCommand="grdcentre_RowCommand" AllowPaging="True" OnPageIndexChanging="grdcentre_PageIndexChanging" width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Studentid">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <a class="error" href='studentreportdetails.aspx?StudentID=<%#Eval("studentid")%>'>
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
            <asp:BoundField DataField="reason" HeaderText="Reason" />
            <asp:BoundField DataField="centre_location" HeaderText="Transfered To" />
        </Columns>
         <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
    </asp:GridView>
                    </div>
    </li></ul>
    <div class="clear"></div></div>
  </div>
 <div class="white-cont">
       
         <h3 class="cont-title">Add Transfer Student Details</h3>
           
      <asp:CustomValidator ID="CustomValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special2" ControlToValidate="txtc_studentid"></asp:CustomValidator>
      <div class="form-cont">
     <ul class="no-borders">
            <li>  
        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label>
                      </li>
                           <li>
              <label class="label-txt">
                                StudentID</label>
                                <asp:TextBox ID="txtc_studentid" CssClass="text input-txt" runat="server" MaxLength="50"></asp:TextBox>
                                </li>
                        <li>
                         <label class="label-txt">
                                Reason For Transfering</label>                           
                                <asp:TextBox ID="txtc_reason" runat="server" MaxLength="25" TextMode="MultiLine"></asp:TextBox>
                        </li>
                        <li>
                         <label class="label-txt">
                                Transfered To</label>
                           
                                <asp:DropDownList ID="ddc_centre" runat="server">
                                   <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem Value="Tamilnadu">Tamilnadu</asp:ListItem>
                                    <asp:ListItem Value="Andrapradesh">Andra pradesh</asp:ListItem>
                                    <asp:ListItem Value="karnataka">Karnataka</asp:ListItem>
                                    <asp:ListItem Value="kerala">Kerala</asp:ListItem>
                                </asp:DropDownList></li>
       <li style="text-align:center;">
              <div align="center" style="padding-bottom:25px;">
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Validate();" OnClick="btnsubmit_Click"/>&nbsp;
                <asp:Button ID="BtnReset" runat="server" CssClass="reset-btn" OnClick="BtnReset_Click" Text="Reset" />
            </div>
    </li></ul><div class="clear"></div>
    <asp:HiddenField ID="hdnID" runat="server" />
	</div>
	
	
	 </div>
	 </div>
</asp:Content>

