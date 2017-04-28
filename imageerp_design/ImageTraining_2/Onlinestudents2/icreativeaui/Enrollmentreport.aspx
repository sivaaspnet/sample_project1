<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Enrollmentreport.aspx.cs" Inherits="superadmin_outstandingreport" Title="Enrolled and Unbatched Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

$(document).ready(function()
{
$('#ContentPlaceHolder1_TextBox1').keyup(function()
{
searchTable($(this).val());
});
});
function searchTable(inputVal)
{
var table = $('#ContentPlaceHolder1_Gridview_admission');
table.find('tr').each(function(index, row)
{
var allCells = $(row).find('td');
if(allCells.length > 0)
{
var found = false;
allCells.each(function(index, td)
{
var regExp = new RegExp(inputVal, 'i');
if(regExp.test($(td).text()))
{
found = true;
return false;
}
});
if(found == true)$(row).show();else $(row).hide();
}
});
}
</script>
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
        if(document.getElementById("ContentPlaceHolder1_txtfromdate").value=="")
        {
        alert("Please select the From Date");
        document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
        return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_txttodate").value=="")
        {
        alert("Please select the to date");
        document.getElementById("ContentPlaceHolder1_txttodate").focus();
        return false;
        }
     
        else
        {
            return true;
        } 
   
}
 
$(document).ready(function() {

    $("#ContentPlaceHolder1_TextBox1").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
    
</script>
<%--<style type="text/css">
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
        </style>--%>
        
        <table border="0" cellpadding="0">
            <tr>
                <td align="center" colspan="4">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 214px">From Date 
                    <asp:TextBox ID="txtfromdate" CssClass="text datepicker" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
                </td>
                <td style="width: 202px">To Date 
                    <asp:TextBox ID="txttodate" CssClass="text datepicker" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
                </td>
                <td style="width: 230px"><span class="file">
    
          
        
              Student Id&nbsp;&nbsp;<asp:TextBox ID="TextBox1"
                  runat="server" CssClass="text"></asp:TextBox>
               
                </td>
                <td>
            
                                      <asp:Button ID="view" runat="server" CssClass="btnStyle1" 
                                          OnClientClick="javascript:return validview();" OnClick="view_Click" 
                                          Text="Search" />
                                             <br />
                <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="TextBox1"></asp:CustomValidator>
                                          </td>
            </tr>
           
            
              <tr style="display:none;"> <td style="width: 214px">Student Status :
                    <asp:DropDownList ID="ddl_status" runat="server">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="active">Active</asp:ListItem>
                    <asp:ListItem Value="Completed">Completed</asp:ListItem>
                    <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
                    <asp:ListItem Value="Break">Break</asp:ListItem>
                 
                    </asp:DropDownList>&nbsp;
                  </td>  
                    </tr>
            
            <tr>
                <td colspan="4">
                <table border="0" cellpadding="0" width="100%">
          
            
            
        </table> </td>
            </tr>
        </table>
        
        
   <div class="free-forms">
    <table class="common" style="width: 100%">
    <tr><td style="padding:0px;">
      <h4>
          Enrolled and Unbatched Report
      </h4></td></tr>
      <tr><td>
    
        
    
   
                  <br />
                  <br />
       <asp:GridView ID="Gridview_admission" runat="server" CssClass="common" 
                      AutoGenerateColumns="False" AllowPaging="true" PageSize="20" 
                      OnPageIndexChanging="Gridview_admission_PageIndexChanging" 
                      EmptyDataText="No records Found" width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                   <a href="createnewbatch.aspx" alt=""><%#Eval("student_id")%></a>
                   
            
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                  <ItemTemplate>
                      <%#Eval("enq_personal_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                             <asp:TemplateField HeaderText="program">
                    <ItemTemplate>
                        <%#Eval("program")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CourseFees">
                    <ItemTemplate>
                        <%#Eval("courseFees")%>
                    </ItemTemplate>
                </asp:TemplateField>
   
                           <asp:TemplateField HeaderText="Enrolled Date">
                    <ItemTemplate>
                        <%#Eval("Datemod")%>
                    </ItemTemplate>
                </asp:TemplateField>
             
                
                <asp:TemplateField HeaderText="Invoice">
                    <ItemTemplate>
                        <a class="error" href='InvoiceDetails.aspx?invno=<%#Eval("invoiceid")%>'>
                        View Invoice
                   </a>
                    </ItemTemplate>
                </asp:TemplateField>

                
            </Columns>
        </asp:GridView>
  
          <p>
              <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton>&nbsp;</p>
      </td></tr>
        </table>
    
   </div>
    
    
</asp:Content>

