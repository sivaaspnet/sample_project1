<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ManageReceipt.aspx.cs" Inherits="superadmin_ManageReceipt" Title="Manage Receipt" EnableEventValidation = "false"  %>
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





 
</script>

	 

	<h4>Manage Receipts</h4>
    <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
    	<tr>
    		<td colspan="4" style="text-align:center">
        	<asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td>
		</tr>
        <tr>                 
              <td style="width: 147px" >
                    Enter Student ID</td>
                <td valign="middle" >
                   &nbsp; <asp:TextBox ID="txt_stuid" CssClass="text" runat="server"></asp:TextBox>  &nbsp;
                    </td>
                <td >
                <label class="sort-head">From Date</label><asp:TextBox ID="txtfromcalender" onpaste="return false" onKeyPress="return false"  runat="server" CssClass="text datepicker" Width="70px"></asp:TextBox>
                </td>
            <td >
            	<label class="sort-head">To Date</label><asp:TextBox ID="txttocalender" runat="server" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker" Width="70px"></asp:TextBox>&nbsp;
        <asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="btnStyle1" OnClick="btnsort_Click" OnClientClick="javascript:return sortval();" /></td>
              
                
        </tr>
        <tr>
        <td colspan="4" style="vertical-align: middle;">
            &nbsp;</td>
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
                
                <asp:TemplateField HeaderText="Receipt No">
                <ItemTemplate>
                    <%#Eval("receiptno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice No">
                <ItemTemplate>
                       <%#Eval("invoiceno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <%#Eval("amount")%> 
                </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tax">
                <ItemTemplate>
                    <%#Eval("taxamount")%> 
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Amount">
                <ItemTemplate>
                    <%#Eval("totalamount")%> 
                </ItemTemplate>
                </asp:TemplateField>        
                <asp:TemplateField HeaderText="Receipt Date">
                <ItemTemplate>
                     <%#Eval("dateIns")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt Type">
                <ItemTemplate>
                     <%#Eval("receiptType")%>
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>  
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

