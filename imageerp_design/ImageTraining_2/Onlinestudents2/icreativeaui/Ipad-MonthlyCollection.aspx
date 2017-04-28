<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Ipad-MonthlyCollection.aspx.cs" Inherits="superadmin_MonthlyCollection" Title="Monthly Collection Report" %>
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

var start = document.getElementById("ContentPlaceHolder1_TextBox1").value;
        var end = document.getElementById("ContentPlaceHolder1_TextBox2").value;

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
        
clearValidation('ContentPlaceHolder1_TextBox1~ContentPlaceHolder1_TextBox2');
  if(trim(document.getElementById("ContentPlaceHolder1_TextBox1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_TextBox1").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_TextBox1").focus();
             document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(csDate > 0)
         {
             document.getElementById("ContentPlaceHolder1_TextBox1").value=="";
             alert("!Invalid From date");
             document.getElementById("ContentPlaceHolder1_TextBox1").focus();
             document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
             return false;
        }
   else if(trim(document.getElementById("ContentPlaceHolder1_TextBox2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_TextBox2").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_TextBox2").focus();
             document.getElementById("ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(compDate < 0)
        {
             document.getElementById("ContentPlaceHolder1_TextBox2").value=="";
             alert("Please select valid To date");
             document.getElementById("ContentPlaceHolder1_TextBox2").focus();
             document.getElementById("ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
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
function dis()
{
    if(document.getElementById("ContentPlaceHolder1_ddlcollectype").value=="initial")
    {
   // alert("val");
      document.getElementById("ContentPlaceHolder1_cutby").style.display="";
    }
    else if(document.getElementById("ContentPlaceHolder1_ddlcollectype").value=="all")
    {
 
    document.getElementById("ContentPlaceHolder1_cutby").value = ""; 
     //   alert(document.getElementById("ctl00_ContentPlaceHolder1_cutby").value);
    document.getElementById("ContentPlaceHolder1_cutby").style.display="none";
      
    }
}

function validview()
{
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
    else
    {
        return true;
    }
}

window.onload=function()
 {
 dis()
}


</script>
    <br />
    <table class="common" style="width: 746px">
    <tr><td style="padding:0px;">
       <h4>
          Collection Report &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
       </h4></td></tr>
      <tr><td>
    <p>
        <table border="0" cellpadding="0" width="100%">
         <tr visible="false" runat="server" id="Tr1">
                <td colspan="4">
                    Select Month :  
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
                    <asp:Button ID="view" runat="server" CssClass="submit" OnClientClick="javascript:return validview();" Text="View Details" OnClick="view_Click" />
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;Collection Type :
                    <asp:DropDownList ID="ddlcollectype" runat="server" onchange="javascript:return dis();">
                        <asp:ListItem Value="all">All</asp:ListItem>
                        <asp:ListItem Value="initial">Initial</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" id="cutby" runat="server">
                    Receipt Cut By :
                    <asp:DropDownList ID="ddlcutby" runat="server">
                    </asp:DropDownList></td>
            </tr>
             <tr>
            <td colspan="3">
                &nbsp;From Date &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" onpaste="return false" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="text datepicker" Width="92px"></asp:TextBox>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                 <td colspan="1">
                     &nbsp;To Date &nbsp; &nbsp;
                <asp:TextBox ID="TextBox2" onpaste="return false" runat="server" onkeypress="return AllowAlphabet(event)" CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Sort" CssClass="submit" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" /></td>
        </tr>
        </table>
    </p>
          <p>
              &nbsp;&nbsp;</p>
          
      </td></tr>
        </table>
    
    <br />
    <br />
    <table class="common" id="collectiongrid" runat="server" visible="false" style="width: 746px">
        <tr>
            <td style="padding:0px;">
                <h4>
                    Collection Report &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;&nbsp;
                </h4>
            </td>
        </tr>
        <tr>
            <td>
                <p>
                    <table border="0" cellpadding="0" width="100%">
            
            <tr  runat="server" id="Tr4">
                <td style="width: 30%; height: 19px">
                    Amount :&nbsp;
                    <asp:Label ID="lblcollectamount" runat="server" Font-Bold="true" ForeColor="blue" Font-Size="12" Text=""></asp:Label></td>
                <td style="width: 30%; height: 19px">
                    Tax :
                    <asp:Label ID="lblcollecttax" runat="server" Font-Bold="true" ForeColor="blue" Font-Size="12" Text=""></asp:Label></td>
                <td align="left" colspan="2" style="width: 255px; height: 19px" valign="middle">
                    &nbsp;Total
                    Collection Amount :
                    <asp:Label ID="lblamtpaid" runat="server" Font-Bold="true" ForeColor="blue" Font-Size="12"></asp:Label></td>
            </tr>
        </table>
    </p>
          <p>
              &nbsp;&nbsp;</p>
                <p>
       <asp:GridView ID="Gridview_admission" runat="server" AllowPaging="true" CssClass="common"  AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" PageSize="20" EmptyDataText="No records Found" Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <%#Eval("student_id")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                  <ItemTemplate>
                       <%#Eval("student_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt No">
                    <ItemTemplate>
                        <%#Eval("Receipt_no")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Course">
                    <ItemTemplate>
                        <%#Eval("program")%>
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
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <%#Eval("Date_ins")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Receipt cut by">
                    <ItemTemplate>
                        <%#Eval("receiptcutby")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="downloadlink_Click">Download Excel</asp:LinkButton></p>
            </td>
        </tr>
    </table>
    <br />
    
</asp:Content>

