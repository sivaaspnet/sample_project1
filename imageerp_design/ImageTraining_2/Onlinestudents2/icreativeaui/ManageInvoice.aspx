<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ManageInvoice.aspx.cs" Inherits="superadmin_ManageInvoice" Title="Manage Invoice" EnableEventValidation = "false"  %>
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
function sortval()
{
        var start = document.getElementById("ContentPlaceHolder1_txtfromcalender").value;
        var end = document.getElementById("ContentPlaceHolder1_txttocalender").value;

        var start_s = start.split("-");
        var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
        var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        if(curr_date<10)
        {
        curr_date='0'+curr_date;
        }
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        
        var compDate = enDate - stDate;
        var csDate = stDate - toDate;
        
        
         if( trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)==""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
         {
              
             alert("Please enter the dates");
         
           
             return false;
         } 
         else if(csDate > 0)
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender").value=="";
             alert("!Invalid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
             return false;
        }
 
     else
     {
     return true;
     }
}

function validateform()
{
         var ddlcourse = document.getElementById('<%= this.ddlcourse.ClientID %>');
         var txtcentercode = document.getElementById('<%= this.txtcentercode.ClientID %>');
         var txtstudentid = document.getElementById('<%= this.txtstudentid.ClientID %>');
         var txtinvoiceid = document.getElementById('<%= this.txtinvoiceid.ClientID %>');
         var txtreceiptno = document.getElementById('<%= this.txtreceiptno.ClientID %>');
         var txttrack = document.getElementById('<%= this.txttrack.ClientID %>');
         var txtcoursefees = document.getElementById('<%= this.txtcoursefees.ClientID %>');
         var txtinstallno = document.getElementById('<%= this.txtinstallno.ClientID %>');
         var txtpaymenttype = document.getElementById('<%= this.txtpaymenttype.ClientID %>');
         var txtbatchtime = document.getElementById('<%= this.txtbatchtime.ClientID %>');
         var txttaxpercent = document.getElementById('<%= this.txttaxpercent.ClientID %>');
         
         if (trim(txtcentercode.value) == "") {
             alert("Please enter center code");
             txtcentercode.focus();            
             txtcentercode.style.border="#ff0000 1px solid";
             txtcentercode.style.backgroundColor="#e8ebd9";
             return false;
         }
         else if (trim(txtstudentid.value) == "") {
             alert("Please enter student id");
             txtstudentid.focus();
             txtstudentid.style.border="#ff0000 1px solid";
             txtstudentid.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (trim(txtinvoiceid.value) == "") {
             alert("Please enter invoice number");          
             txtinvoiceid.focus();
             txtinvoiceid.style.border="#ff0000 1px solid";
             txtinvoiceid.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (trim(txtreceiptno.value) == "") {
             alert("Please enter receipt number");
             txtreceiptno.focus();
             txtreceiptno.style.border="#ff0000 1px solid";
             txtreceiptno.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (trim(txttrack.value) == "") {
             alert("Please enter track");
             txttrack.focus();
             txttrack.style.border="#ff0000 1px solid";
             txttrack.style.backgroundColor="#e8ebd9";
             return false
         } 
          else if(ddlcourse.value =="")
         {
             alert("Please select course name");
             ddlcourse.focus();
             ddlcourse.style.border="#ff0000 1px solid";
             ddlcourse.style.backgroundColor="#e8ebd9";
             return false
         } 
          else if (trim(txtcoursefees.value) == "") {
             alert("Please enter course fees");
             txtcoursefees.focus();
             txtcoursefees.style.border="#ff0000 1px solid";
             txtcoursefees.style.backgroundColor="#e8ebd9";
             return false
         }
          else if (trim(txtinstallno.value) == "") {
             alert("Please enter install no");
             txtinstallno.focus();
             txtinstallno.style.border="#ff0000 1px solid";
             txtinstallno.style.backgroundColor="#e8ebd9";
             return false
         }   
           else if (trim(txtpaymenttype.value) == "") {
             alert("Please enter payment type");
             txtpaymenttype.focus();
             txtpaymenttype.style.border="#ff0000 1px solid";
             txtpaymenttype.style.backgroundColor="#e8ebd9";
             return false
         }     
           else if (trim(txtbatchtime.value) == "") {
             alert("Please enter batch time");
             txtbatchtime.focus();
             txtbatchtime.style.border="#ff0000 1px solid";
             txtbatchtime.style.backgroundColor="#e8ebd9";
             return false
         }     
         else if (trim(txttaxpercent.value) == "") {
             alert("Please enter tax percent");
             txttaxpercent.focus();
             txttaxpercent.style.border="#ff0000 1px solid";
             txttaxpercent.style.backgroundColor="#e8ebd9";
             return false
         }  
         else
         {
          return true
         }
}



 
</script>

	 

	<h4>Manage Invoice</h4>
    <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
    	<tr>
    		<td colspan="3" style="text-align:center">
        	<asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td>
		</tr>
        <tr>
            <td valign="top">
                </td>
                
                <td colspan="2" >
                <label class="sort-head">From Date</label><br />
                <asp:TextBox ID="txtfromcalender" onpaste="return false" onKeyPress="return false"  runat="server" CssClass="text datepicker" Width="70px"></asp:TextBox>
                 
             
                </td>
            <td >
            	<label class="sort-head">To Date</label><br />
                <asp:TextBox ID="txttocalender" runat="server" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker" Width="70px"></asp:TextBox>&nbsp;
        <asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="btnStyle1" OnClick="btnsort_Click" OnClientClick="javascript:return sortval();" /></td>
              
                
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td colspan="2">
            </td>
            <td>
            </td>
        </tr>
      
    </table>
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
    <tr>
    <td align="right">Center Code </td>
    <td>
        <asp:TextBox ID="txtcentercode" runat="server" CssClass="text"></asp:TextBox></td>
    </tr> 
    <tr>
    <td align="right">Student ID</td>
    <td>
        <asp:TextBox ID="txtstudentid" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">Invoice ID</td>
    <td>
        <asp:TextBox ID="txtinvoiceid" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">Receipt No</td>
    <td>
        <asp:TextBox ID="txtreceiptno" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">Track</td>
    <td>
        <asp:TextBox ID="txttrack" runat="server" CssClass="text"></asp:TextBox></td>
    </tr> 
    <tr>
    <td align="right">Course Name</td>
    <td>
        <asp:DropDownList ID="ddlcourse" runat="server" CssClass="select"></asp:DropDownList></td>
    </tr>
     <tr>
    <td align="right">Course Fees</td>
    <td>
        <asp:TextBox ID="txtcoursefees" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">Install No</td>
    <td>
        <asp:TextBox ID="txtinstallno" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">Payment Type</td>
    <td>
        <asp:TextBox ID="txtpaymenttype" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="right">Batch Time</td>
    <td>
        <asp:TextBox ID="txtbatchtime" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right">Tax Percentage</td>
    <td>
        <asp:TextBox ID="txttaxpercent" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
      <tr>
    <td colspan="2" align="center" ><asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnStyle1" OnClientClick="return validateform();" OnClick="btnUpdate_Click"    />
        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnStyle1" OnClick="btnReset_Click"      /></td>
    </tr>
    </table>
    </div> 
    <div style="padding:0px 10px;">
    <table cellpadding="0" cellspacing="0" width="100%" >
    <tr><td>
		<div class="dataGrid">
        <asp:GridView ID="GridView1" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                    <ItemTemplate> 
                      <%#Eval("studentId")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Center Code">
                    <ItemTemplate> 
                      <%#Eval("centerCode")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Invoice No">
                <ItemTemplate>
                       <%#Eval("invoiceid")%>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Receipt No">
                <ItemTemplate>
                    <%#Eval("receiptno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Entered By">
                <ItemTemplate>
                    <%#Eval("enteredby")%> 
                </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Invoice Date">
                <ItemTemplate>
                     <%#Eval("dateIns")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Action">
                         <ItemTemplate> 
                                <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" ToolTip="Enable" CommandArgument='<%#Eval("id")%>'><img src="layout/edit.png" alt="Enable" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" ToolTip="Delete" CommandArgument='<%#Eval("id")%>'  OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="Disable" /></asp:LinkButton>
                   </ItemTemplate> </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
       </div>
       
        <p style="padding:10px 0px;">
            &nbsp;</p>
        
       <div style="display:none;">
           &nbsp;</div>
    </td></tr>
        </table>
     </div>   
    
    <div style="padding:0px 10px;" id="note" runat="server">
        &nbsp;</div>
		 
	</asp:Content>

