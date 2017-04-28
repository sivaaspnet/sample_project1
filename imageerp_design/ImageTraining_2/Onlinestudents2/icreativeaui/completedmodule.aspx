<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="completedmodule.aspx.cs" Inherits="superadmin_addcentre" Title="Deactive" %>

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
    &nbsp;<br />
     
       <div class="free-forms"> 
    <table cellspacing="0" cellpadding="0" class="common" width="100%" id="saform" runat="server">
        <tr>
            <td colspan="2" style="padding:0px; text-align:left"> <h4>
                Deactive student from module</h4> 
            </td>
        </tr>
    <tr><td colspan="2" style="text-align:center">
        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label></td></tr>
                        <tr>
                            <td class="formlabel" style="width: 127px">
                                Studentid</td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="txtc_code" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                                
  <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtc_code"></asp:CustomValidator>
                                </td>
                        </tr>
                        <tr>
                            <td class="formlabel" style="width: 127px">
                                Module</td>
                            <td align="left" valign="middle">
                                <asp:DropDownList ID="ddl_coursename" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddl_coursename_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
        <tr>
            <td class="formlabel" style="width: 127px">
                Software</td>
            <td align="left" valign="middle">
                <asp:DropDownList ID="ddlsoftware" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel" style="width: 127px">
                status</td>
            <td align="left" valign="middle">
                <asp:DropDownList ID="ddlstatus" runat="server">
                  <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="pending">pending</asp:ListItem>
                    <asp:ListItem Value="Completed">Completed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel" style="width: 127px">
                software Status</td>
            <td align="left" valign="middle">
                <span class="file">
                <asp:DropDownList ID="ddlstatus0" runat="server">
                  <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="active">active</asp:ListItem>
                    <asp:ListItem Value="deactive">deactive</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel" style="width: 127px">
                Centre Code</td>
            <td align="left" valign="middle">
                <asp:DropDownList ID="ddl_centre" runat="server">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="middle" style=" height: 105px;" >
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <br />
                <asp:Button ID="Button2" runat="server" Text="Update" OnClientClick="javascript:return Validate();" CssClass="btnStyle1" OnClick="Button2_Click" Visible="False" />
    
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Validate();" OnClick="btnsubmit_Click"/>&nbsp;
                <br />
                <br />
            </td>
        </tr>
      
                    </table>
                    
                    <table cellspacing="0" cellpadding="0" class="common" width="100%">
                      <tr>
            <td align="left" colspan="2"  valign="middle">
                <asp:Label ID="Label1" runat="server" Text="StudentID"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" CssClass="search" EnableTheming="True" OnClick="Button1_Click" /></td>
        </tr>        
        <tr><td> <div style="height:358px; overflow:auto;">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="NO RECORD "
                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"
                    AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="100%">
                    <EmptyDataRowStyle BorderColor="#C00000" BorderStyle="Solid" />
                    <Columns>
                        <asp:BoundField DataField="studentid" HeaderText="studentid" />
                        <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                        <asp:BoundField DataField="module_content" HeaderText="modulename" />
                         <asp:BoundField DataField="Software_Name" HeaderText="Software" />
                        <asp:BoundField DataField="centre_location" HeaderText="centre_code" />
                        <asp:BoundField DataField="softwarestatus" HeaderText="status" />
                        <asp:BoundField DataField="status" HeaderText="Softwarestatus" />
                        <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"  Text='' Visible="false"></asp:Label>
                            <asp:LinkButton ID="LinkButton1" CommandName="sedit" CommandArgument='<%# Eval("id") %>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div> </td></tr>
                    </table>
                    </div>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click"><span class="file"><span class="file"><span class="file"><span class="file">Download</span></span></span></span></asp:LinkButton>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    &nbsp;&nbsp;
    <br />
    <br />

</asp:Content>

