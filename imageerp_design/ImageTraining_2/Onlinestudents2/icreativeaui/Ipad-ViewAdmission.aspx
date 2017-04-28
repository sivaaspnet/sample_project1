<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Ipad-ViewAdmission.aspx.cs" Inherits="superadmin_ViewAdmission" Title="View Admission Page" %>
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
        
   if(trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="" && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value)==""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtkeyword").value=="";   
             alert("Please enter the keywords");
             document.getElementById("ContentPlaceHolder1_txtkeyword").focus();
             document.getElementById("ContentPlaceHolder1_txtkeyword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtkeyword").style.backgroundColor="#e8ebd9";
           
             return false;
         }
        else if ((trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value)!=""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value)=="")
          {
             document.getElementById("ContentPlaceHolder1_txttocalender1").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if ((trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value)!=""  && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value)=="")
          {
           document.getElementById("ContentPlaceHolder1_txtfromcalender1").value=="";
             alert("!Invalid From date");
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
 
     else
     {
     return true;
     }
 
}





</script>
    <table cellpadding="1" class="common">
        <tr>
            <td colspan="3" style=" padding:0px;"><h4>View Enrolled Student Report</h4>

            </td>
        </tr>
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr id="viewby_admin" visible="false" runat="server">
            <td colspan="3">
                Select centre code<br />
                <asp:DropDownList ID="ddl_centrcode" runat="server" OnSelectedIndexChanged="ddl_centrcode_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="3">
                <strong>Keywords :
                    <br />
                    <asp:TextBox ID="txtkeyword" runat="server"></asp:TextBox><br />
                    (Name / studentId )<br />
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>
                From Date<br />
                </strong>
                <asp:TextBox ID="txtfromcalender1" onpaste="return false" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="text datepicker" Width="92px"></asp:TextBox>
                 
             
                </td>
            <td>
                <strong>
                To Date<br />
                </strong>
                <asp:TextBox ID="txttocalender1" onpaste="return false" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort" runat="server" Text="Sort" CssClass="submit" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" /></td>
        </tr>
      
    </table>
    <br />
    <table class="common" style="width: 511px">
    <tr><td style="padding:0px;">
      <h4>Student Details </h4></td></tr>
      <tr><td>
    <p>
       <asp:GridView ID="Gridview_admission" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" EmptyDataText="No records Found" OnRowCommand="Gridview_admission_RowCommand" Width="490px">
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <%#Eval("student_id")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name ">
                    <ItemTemplate>
                        <a rel="modal" href="Viewstudentpersonaldetails.aspx?stuid=<%#Eval("student_id")%>&iframe=true&amp;width=600&amp;height=325" class="error"><%#Eval("enq_personal_name")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Enrolled By">
                    <ItemTemplate>
                        <%#Eval("Enrolled_By")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course">
                    <ItemTemplate>
                        <a rel="modal" href="viewstudentcoursedetails.aspx?stuid=<%#Eval("student_id")%>&iframe=true&amp;width=600&amp;height=325"><img src="../layout/32.gif" title="Click on to view the course details " alt="View" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="centre_code" HeaderText="CentreCode" />
               <asp:TemplateField HeaderText="Invoice Details">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkInvoice" CommandName="Inv" CommandArgument='<%#Eval("qrystringvariable")%>' runat="server">View Invoice</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
        &nbsp;</p></td></tr>
        </table>
    
        <table class="common" >
            <tr>
                <td colspan="2" style="color: #ff3366">
                    Key:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img alt="View" src="../layout/32.gif" />-Click to View the Details</td>
            </tr>
            
        </table>
    <br />
    <br />
    
</asp:Content>

