<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="outstandingreport_old.aspx.cs" Inherits="superadmin_outstandingreport_old" Title="Outstanding Report" %>
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

 function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) 
	{
		return true; 
	} 
	else
	 {
		return false;
	}
}
 
function sortval1()
{

var start = document.getElementById("ContentPlaceHolder1_txtfromcalender1").value;
        var end = document.getElementById("ContentPlaceHolder1_txttocalender1").value;

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
        
clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');
  if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(csDate > 0)
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").value=="";
             alert("!Invalid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
             return false;
        }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalender1").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(compDate < 0)
        {
             document.getElementById("ContentPlaceHolder1_txttocalender1").value=="";
             alert("Please select valid To date");
             document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
             return false;
        }
//          else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
//         {
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
//             alert("Please select centre code");
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
//             return false;
//         }
     else
     {
     return true;
     }
}





</script>
    <table cellpadding="1" class="common">
        <tr>
            <td colspan="3" style=" padding:0px;"><h4>View Collection Report</h4>

            </td>
        </tr>
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr id="viewby_admin" visible="false" runat="server">
            <td colspan="3">
                Select centre code<br />
                <asp:DropDownList ID="ddl_centrcode" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                From Date<br />
                <asp:TextBox ID="txtfromcalender1" onpaste="return false" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="text datepicker" Width="92px"></asp:TextBox>
                 
             
                </td>
            <td>
                To Date<br />
                <asp:TextBox ID="txttocalender1" onpaste="return false" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort" runat="server" Text="Sort" CssClass="submit" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" /></td>
        </tr>
      
    </table>
    <br />
    <table class="common" style="width: 746px">
    <tr><td style="padding:0px;">
      <h4>
          Collection Report
      </h4></td></tr>
      <tr><td>
    <p>
        <table border="0" cellpadding="0" width="100%">
            <tr>
                <td style="width: 30%; height: 19px">
                </td>
                <td style="width: 7%; height: 19px">
                </td>
                <td >
                    &nbsp;
                    <asp:Label ID="lblamtpaid" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
    </p>
          <p>
       <asp:GridView ID="Gridview_admission" runat="server" CssClass="common" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" EmptyDataText="No records Found" Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <%#Eval("student_id")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                  <ItemTemplate>
                       <%#Eval("enq_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile Number">
                    <ItemTemplate>
                        <%#Eval("mobile")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Invoice No">
                    <ItemTemplate>
                        <%#Eval("Invoice_no")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt No">
                    <ItemTemplate>
                        <%#Eval("receipt_no")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <%#Eval("Amount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tax">
                    <ItemTemplate>
                        <%#Eval("Tax")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <%#Eval("Total")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due Date">
                    <ItemTemplate>
                        <%#Eval("Date")%>
                    </ItemTemplate>
                </asp:TemplateField>
     
                
                <%--<asp:TemplateField HeaderText="Payment Mode">
                    <ItemTemplate>
                        <%#Eval("payment_mode")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
            </Columns>
        </asp:GridView>
        &nbsp;</p>
          <p>
              <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton>&nbsp;</p>
      </td></tr>
        </table>
    
    <br />
    <br />
    
</asp:Content>

