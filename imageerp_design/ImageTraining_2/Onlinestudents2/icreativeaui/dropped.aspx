<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="dropped.aspx.cs" Inherits="superadmin_Droppedstudentdetails" Title="Dropped Student Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_TextBox2").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_TextBox2").autocomplete('Handler4.ashx');
   // alert("check");  
    });  
</script>
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	   {
	     return stringToTrim.replace(/^\s+|\s+$/g,"");
	   }
  function clearValidation(fieldList)
   {
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++)
	 {
		if(document.getElementById(field[i]).value!="") 
		{
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}	
}     
function sortval()
{
clearValidation('ContentPlaceHolder1_txtfromcalender~ContentPlaceHolder1_txttocalender');
  if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
             return false;
         }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalender").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender").style.backgroundColor="#e8ebd9";
             return false;
         }
     else
     {
     return true;
     }
}
</script>


  <h4>Dropped Student Report</h4>      
         <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
    <tr><td >
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr>
            <td >
                &nbsp;
               From Date<br />
                &nbsp;
                <asp:TextBox ID="txtfromcalender" runat="server" CssClass="text datepicker" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>                </td>
           
            <td >
               &nbsp;
                To Date<br />
                &nbsp;<asp:TextBox ID="txttocalender" runat="server" CssClass="text datepicker" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
                &nbsp;<asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="btnStyle1" onclientclick="javascript:return sortval();" OnClick="btnsort_Click" /><br />
                &nbsp; &nbsp;
				</td>
        </tr>
    </table>
  </div>
    <br />
	 <div class="free-forms">
	
<table class="common" width=100%><tr><td style=" padding:0px;">
 <h4>Dropped student Details</h4>
    &nbsp; &nbsp;
    <asp:Label ID="Label1" class="formlabel" runat="server" Text="Student ID/Name"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox>&nbsp;<asp:Button
        ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click" />
         <br />
                <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="TextBox2"></asp:CustomValidator>
        
        </td></tr>
    <tr>
        <td style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px">
        </td>
    </tr>
 <tr><td>
    <p>
    
        <asp:GridView ID="GridView1" width="100%" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("student_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                   <ItemTemplate>
                    <a class="error" href='studentreportdetails.aspx?StudentID=<%#Eval("student_id")%>'>
                        <%#Eval("student_id")%>
                    </a>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="enq_personal_name" HeaderText="Name" />
                   <asp:BoundField DataField="program" HeaderText="Program" />
                <asp:BoundField DataField="coursefees" HeaderText="Coursefees" />
                <asp:BoundField DataField="reason" HeaderText="Reason" />
                <asp:BoundField DataField="droppeddate" HeaderText="Dropped Date" />
                <asp:BoundField DataField="studentstatus" HeaderText="Status" />
             
                <asp:TemplateField HeaderText="View Invoice">
                   
                   <ItemTemplate>
                    <a class="error" href='InvoiceDetails.aspx?invno=<%#Eval("invoiceId")%>'>
                        Invoice
                    </a>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView></p></td></tr>
         <tr>
          
            <td colspan="4" style="text-align:center; height: 25px;" >
			<div style="width:88%">
                <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click">Download excel</asp:LinkButton>
				</div>
				</td>
           
              </tr>
        </table> </div>
    <br />






</asp:Content>

