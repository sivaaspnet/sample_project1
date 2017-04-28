<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Ipad-outstandingreport.aspx.cs" Inherits="superadmin_outstandingreport" Title="Outstanding Report" %>
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


function validview()
{
var d = new Date();
        var curr_month = d.getMonth();
        var curr_year = d.getFullYear();  
      // alert("Month is : "+curr_month);       
//        alert("Year is : "+curr_year);  
        if(document.getElementById("ContentPlaceHolder1_ddlmonth").value=="")
        {
        alert("Please select the Month");
        document.getElementById("ContentPlaceHolder1_ddlmonth").focus();
        return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_ddlyear").value=="")
        {
        alert("Please select the Year");
        document.getElementById("ContentPlaceHolder1_ddlyear").focus();
        return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_ddlyear").value< curr_year)
        {       
        alert("Please select the current or next  year");
        document.getElementById("ContentPlaceHolder1_ddlyear").focus();
        return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_ddlyear").value== curr_year &&  document.getElementById("ContentPlaceHolder1_ddlmonth").value<=curr_month)
        {
        alert("Please select the current or next month and year");
        document.getElementById("ContentPlaceHolder1_ddlmonth").focus();
        return false;
        }
        else
        {
            return true;
        } 
   
}
 

</script>
<style type="text/css">
        div.htmltooltip{
        background: none repeat scroll 0 0 #59B1E8;
    border: 1px solid #2781BA;
    color: black;
    left: -1000px;
    padding: 3px;
    position: absolute;
    top: -1000px;
    z-index: 1000;
        }
 </style>
    <br />
    <table class="common" style="width: 746px">
    <tr><td style="padding:0px;">
      <h4>
          Outstanding Report
      </h4></td></tr>
      <tr><td>
    
        <table border="0" cellpadding="0" width="100%">
            <tr>
                <td align="center" colspan="3">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;Select Month :  
                    <asp:DropDownList ID="ddlmonth" runat="server" >
                <asp:ListItem Value="">Select Month</asp:ListItem>
                <asp:ListItem Value="1">January</asp:ListItem>
                <asp:ListItem Value="2">February</asp:ListItem>
                <asp:ListItem Value="3">March</asp:ListItem>
                <asp:ListItem Value="4">April</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">June</asp:ListItem>
                <asp:ListItem Value="7">July</asp:ListItem>
                <asp:ListItem Value="8">August</asp:ListItem>
                <asp:ListItem Value="9">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
                    &nbsp; Select Year :
                    <asp:DropDownList ID="ddlyear" runat="server">
                    <asp:ListItem Value="">Select Year</asp:ListItem>
                    <asp:ListItem Value="2010">2010</asp:ListItem>
                    <asp:ListItem Value="2011">2011</asp:ListItem>
                    <asp:ListItem Value="2012">2012</asp:ListItem>
                    <asp:ListItem Value="2013">2013</asp:ListItem>
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                    <asp:Button ID="view" runat="server" CssClass="submit" OnClientClick="javascript:return validview();" OnClick="view_Click" Text="View Details" />
                    </td>
            </tr>
            <tr>
                <td colspan="3">
                <table border="0" cellpadding="0" width="100%">
          
            
            <tr id="Tr1"  runat="server">
                <td style="width: 30%; height: 19px">
                    Amount :
                    <asp:Label ID="lblAmount" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="12pt"></asp:Label></td>
                <td style="width: 23%; height: 19px">
                    Tax :
                    <asp:Label ID="lblTax" runat="server" Font-Bold="true" ForeColor="blue" Font-Size="12" Text=""></asp:Label></td>
                <td align="right" style="width: 40%; height: 19px" valign="middle">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Total
                    Amount :
                    <asp:Label ID="lbltotalAmt" runat="server" Font-Bold="true" ForeColor="blue" Font-Size="12"></asp:Label></td>
            </tr>
        </table> </td>
            </tr>
        </table>
    
          <p>
       <asp:GridView ID="Gridview_admission" runat="server" CssClass="common" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" EmptyDataText="No records Found" Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <a href="" rel="htmltooltip"><div  class="htmltooltip"><table><tr><td>
                           <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("detailsinfo")%>'></asp:Literal></td></tr></table> </div> <%#Eval("studentid")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                  <ItemTemplate>
                       <%#Eval("Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number">
                    <ItemTemplate>
                        <%#Eval("Phone")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due Date">
                    <ItemTemplate>
                        <%#Eval("lastdate")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Invoice No">
                    <ItemTemplate>
                        <%#Eval("invoice")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course">
                    <ItemTemplate>
                        <%#Eval("Program")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="No. Balance Ins.">
                    <ItemTemplate>
                        <%#Eval("noofinstallment")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <%#Eval("balanceamount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tax">
                    <ItemTemplate>
                        <%#Eval("balancetax")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <%#Eval("totalbalance")%>
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
              <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton>&nbsp;</p>
      </td></tr>
        </table>
    
    <br />
    <br />
    
</asp:Content>

