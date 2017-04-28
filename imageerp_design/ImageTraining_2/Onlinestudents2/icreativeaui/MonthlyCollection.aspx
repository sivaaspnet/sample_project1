<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="MonthlyCollection.aspx.cs" Inherits="superadmin_MonthlyCollection" Title="Monthly Collection Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="http://cdn.webrupee.com/js" type="text/javascript"></script>
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
  <div class="title-cont">
    <h3 class="cont-title">Collection Report </h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Reports</a>/</li>
        <li><a href="MonthlyCollection.aspx" class="last">Monthly Collection Report</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
    <div style="padding:0px 10px 10px 10px;display:none">
      <asp:GridView ID="GridView1" ShowFooter="true" runat="server" CssClass="tbl-cont3"  AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" PageSize="20" EmptyDataText="No records Found" Width="100%" onrowdatabound="GridView1_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="Student ID">
          <ItemTemplate> <%#Eval("student_id")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Name">
          <ItemTemplate> <%#Eval("student_name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt No">
          <ItemTemplate> <%#Eval("Receipt_no")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Course">
          <ItemTemplate> <%#Eval("program")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount">
          <ItemTemplate> <%#Eval("Amount")%> </ItemTemplate>
          <FooterTemplate>
            <asp:Label ID="lblgridamount" runat="server" Text=""></asp:Label>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tax">
          <ItemTemplate> <%#Eval("Tax")%> </ItemTemplate>
          <FooterTemplate>
            <asp:Label ID="lblgridtax" runat="server" Text=""></asp:Label>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">
          <ItemTemplate> <%#Eval("Total")%> </ItemTemplate>
          <FooterTemplate>
            <asp:Label ID="lblgridtotal" runat="server" Text=""></asp:Label>
          </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
          <ItemTemplate> <%#Eval("Date_ins")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt cut by">
          <ItemTemplate> <%#Eval("receiptcutby")%> </ItemTemplate>
        </asp:TemplateField>
        </Columns>
           <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
    </div>
  </div>
  <div class="search-sec-cont">
    <ul>
      <li style="display:none;"> Select Month & year :
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
        <asp:DropDownList ID="ddlyear" runat="server">
          <asp:ListItem Value="">Select Year</asp:ListItem>
          <asp:ListItem Value="2010">2010</asp:ListItem>
          <asp:ListItem Value="2011">2011</asp:ListItem>
          <asp:ListItem Value="2012">2012</asp:ListItem>
          <asp:ListItem Value="2013">2013</asp:ListItem>
          <asp:ListItem Value="2014">2014</asp:ListItem>
          <asp:ListItem Value="2015">2015</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="view" runat="server" CssClass="submit" OnClientClick="javascript:return validview();" Text="View Details" OnClick="view_Click" />
      </li>
      <li>
        <div class="wth-1">Collection Type :</div>
        <div class="wth-2">
          <asp:DropDownList ID="ddlcollectype" runat="server"  Width="150px" onchange="javascript:return dis();"  CssClass="sele-txt">
            <asp:ListItem Value="all">All</asp:ListItem>
            <asp:ListItem Value="Fresh">Fresh</asp:ListItem>
            <asp:ListItem Value="Paid-Initial-Alone">Paid-Initial-Alone</asp:ListItem>
            <asp:ListItem Value="Regular-Fees">Regular-Fees</asp:ListItem>
            <asp:ListItem Value="Quick">Quick</asp:ListItem>
            <asp:ListItem Value="Others">Others(Late,Break etc)</asp:ListItem>
          </asp:DropDownList>
        </div>
      </li>
      <li>
        <div class="wth-1" > Receipt Cut By :</div>
        <div class="wth-2">
          <asp:DropDownList ID="ddlcutby" runat="server" Width="150px" CssClass="sele-txt"> </asp:DropDownList>
        </div>
      </li>
      <li  class="date-sec-cont">
        <div class="wth-1" > Date From </div>
        <div class="wth-2" ><span class="date-pick-cont">
          <asp:TextBox ID="TextBox1" onkeypress="return false" onkeydown="return false" onpaste="return false"  runat="server"  CssClass="text date-input-txt datepicker" Width="92px"></asp:TextBox>
          </span></div>
        <div class="wth-3" > To </div>
        <div class="wth-2" > <span class="date-pick-cont">
          <asp:TextBox ID="TextBox2" onkeypress="return false" onkeydown="return false" onpaste="return false"  runat="server"  CssClass="text date-input-txt datepicker" Width="92px"></asp:TextBox>
          </span> </div>
      </li>
    </ul>
    <div style="text-align:center">
      <asp:Button ID="Button1" runat="server" Text="Search" CssClass="search-btn" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" />
    </div>
    <div class="clear"></div>
    <div align="center">
      <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
      <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label>
    </div>
  </div>
  <div id="collectiongrid" runat="server" visible="false" class="analysis-sec">
    <ul>
      <li class="analysis-item-1">
        <div class="analysis-vlu">
          <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="lblcollectamount" runat="server"></asp:Label>
        </div>
        <div class="analysis-txt">Amount</div>
      </li>
      <li class="analysis-item-2">        
        <div class="analysis-vlu">
          <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="lblcollecttax" runat="server"></asp:Label>
        </div>
        <div class="analysis-txt">Tax</div>
      </li>
      <li class="analysis-item-3">        
        <div class="analysis-vlu">
          <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="lblamtpaid" runat="server"></asp:Label>
        </div>
        <div class="analysis-txt">Total</div>
      </li>
    </ul>
    <div class="clear"></div>
  </div>
  <div class="white-cont" style="padding:15px 10px 10px 10px">
      <asp:GridView ID="Gridview_admission" runat="server" AllowPaging="true" CssClass="tbl-cont3"  AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" PageSize="20" EmptyDataText="No records Found" Width="100%" >
        <Columns>
        <asp:TemplateField HeaderText="Student ID">
          <ItemTemplate> <%#Eval("student_id")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Name" ItemStyle-CssClass="txt-trans-cap">
          <ItemTemplate> <%#Eval("student_name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt No">
          <ItemTemplate> <%#Eval("Receipt_no")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Course">
          <ItemTemplate> <%#Eval("program")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="txt-al-rt">
          <ItemTemplate> <%#Eval("Amount")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tax" ItemStyle-CssClass="txt-al-rt">
          <ItemTemplate> <%#Eval("Tax")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="txt-al-rt">
          <ItemTemplate> <%#Eval("Total")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
          <ItemTemplate> <%#Eval("Date_ins")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt cut by">
          <ItemTemplate> <%#Eval("receiptcutby")%> </ItemTemplate>
        </asp:TemplateField>
        </Columns>
      <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        <EmptyDataRowStyle ForeColor="Red" />
      </asp:GridView>
      <div align="center" style="padding:10px 10px 0px 10px;">
        <asp:LinkButton ID="LinkButton2" CssClass="download-btn" runat="server" OnClick="downloadlink_Click">Download Excel</asp:LinkButton>
      </div>
  </div>
</asp:Content>
