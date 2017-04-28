<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="outstandingreporttest.aspx.cs" Inherits="superadmin_outstandingreporttest" Title="Outstanding Report test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script type="text/javascript">
$(document).ready(function() {
    $('#ContentPlaceHolder1_TextBox1').keyup(function() {
        searchTable($(this).val());
    });
});

function searchTable(inputVal) {
    var table = $('#ContentPlaceHolder1_Gridview_admission');
    table.find('tr').each(function(index, row) {
        var allCells = $(row).find('td');
        if (allCells.length > 0) {
            var found = false;
            allCells.each(function(index, td) {
                var regExp = new RegExp(inputVal, 'i');
                if (regExp.test($(td).text())) {
                    found = true;
                    return false;
                }
            });
            if (found == true) $(row).show();
            else $(row).hide();
        }
    });
}
</script>
  <script language="javascript" type="text/javascript">
	function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function clearValidation(fieldList) {

    var field = new Array();
    field = fieldList.split("~");
    var counter = 0;
    for (i = 0; i < field.length; i++) {
        if (document.getElementById(field[i]).value != "") {
            document.getElementById(field[i]).style.border = "#999999 1px solid";
            document.getElementById(field[i]).style.backgroundColor = "#e8ebd9";
        }
    }

}

function AllowAlphabet(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
        return true;
    } else {
        return false;
    }
}

function sortval1() {

    var start = document.getElementById("ContentPlaceHolder1_txtfromcalender1").value;
    var end = document.getElementById("ContentPlaceHolder1_txttocalender1").value;

    var start_s = start.split("-");
    var end_s = end.split("-");

    var stDate = start_s[2] + start_s[1] + start_s[0];
    var enDate = end_s[2] + end_s[1] + end_s[0];

    var d = new Date();
    var curr_date = d.getDate();
    if (curr_date < 10) {
        curr_date = '0' + curr_date;
    }
    var curr_month = d.getMonth();
    curr_month++;
    var curr_year = d.getFullYear();
    var mon = (curr_month < 10 ? '0' : '') + curr_month
    var toDate = parseInt(curr_year + '' + mon + '' + curr_date);

    var compDate = enDate - stDate;
    var csDate = stDate - toDate;

    clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');
    if (trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value) == "") {
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").value == "";
        alert("Please select the From date");
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor = "#e8ebd9";

        return false;
    } else if (csDate > 0) {
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").value == "";
        alert("!Invalid From date");
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor = "#e8ebd9";
        return false;
    } else if (trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value) == "") {
        document.getElementById("ContentPlaceHolder1_txttocalender1").value == "";
        alert("Please select the To date");
        document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
        document.getElementById("ContentPlaceHolder1_txttocalender1").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor = "#e8ebd9";
        return false;
    } else if (compDate < 0) {
        document.getElementById("ContentPlaceHolder1_txttocalender1").value == "";
        alert("Please select valid To date");
        document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
        document.getElementById("ContentPlaceHolder1_txttocalender1").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor = "#e8ebd9";
        return false;
    }
    else {
        return true;
    }
}


function validview() {
    var d = new Date();
    var curr_month = d.getMonth();
    var curr_year = d.getFullYear();  
    if (document.getElementById("ContentPlaceHolder1_ddlmonth").value == "") {
        alert("Please select the Month");
        document.getElementById("ContentPlaceHolder1_ddlmonth").focus();
        return false;
    } else if (document.getElementById("ContentPlaceHolder1_ddlyear").value == "") {
        alert("Please select the Year");
        document.getElementById("ContentPlaceHolder1_ddlyear").focus();
        return false;
    } else if (document.getElementById("ContentPlaceHolder1_ddlyear").value < curr_year) {
        alert("Please select the current or next  year");
        document.getElementById("ContentPlaceHolder1_ddlyear").focus();
        return false;
    } else if (document.getElementById("ContentPlaceHolder1_ddlyear").value == curr_year && document.getElementById("ContentPlaceHolder1_ddlmonth").value <= curr_month) {
        alert("Please select the current or next month and year");
        document.getElementById("ContentPlaceHolder1_ddlmonth").focus();
        return false;
    } else {
        return true;
    }

}
 

</script>
      <div class="title-cont">
    <h3 class="cont-title">Outstanding Report</h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Reports</a>/</li>
        <li><a href="outstandingreporttest.aspx" class="last">Outstanding Report</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>

    <div class="search-sec-cont">
   
     
 
      <ul>
        <li><div class="wth-1">Search by :</div>
            <div class="wth-2">

           
          <asp:DropDownList ID="ddlsearchlastpaid" runat="server" CssClass="sele-txt">
            <asp:ListItem Value="">Select</asp:ListItem>
            <asp:ListItem Value="equal3">Last paid month is equal 3</asp:ListItem>
            <asp:ListItem Value="above3">Last paid month is above 3</asp:ListItem>
            <asp:ListItem Value="below3">Last paid month is below 3</asp:ListItem>
          </asp:DropDownList> </div>
        </li>
     
        <li><div class="wth-1">From Join Date :</div>
          <div  class="wth-2">  <span class="date-pick-cont"><asp:TextBox CssClass="text datepicker input-txt" ID="txtfromdate" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></span></div>
        </li>
        <li><div class="wth-1">To Join Date :</div>
          <div class="wth-2"> <span class="date-pick-cont"><asp:TextBox CssClass="text datepicker input-txt" ID="txttodate" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></span></div>
        </li>
            <li><div class="wth-1"> Find By(Student Id) :</div>
         <div class="wth-2"> <asp:TextBox ID="TextBox1" runat="server" CssClass="input-txt"></asp:TextBox> <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special" ControlToValidate="TextBox1"></asp:CustomValidator></div>
         
        </li>
        <li>
          <asp:Button ID="view" runat="server" CssClass="search-btn" OnClientClick="javascript:return validview();" OnClick="view_Click" Text="Search" />
        </li>
      </ul>
           <div class="clear"></div>
    <div align="center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label>
    </div>
    </div>
 
  
 
      <div class="white-cont">
      <div  id="Tr1"  runat="server" class="analysis-sec">
    <ul>
      <li class="analysis-item-1">
        <div class="analysis-vlu">
          <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="lblAmount" runat="server"></asp:Label>
        </div>
        <div class="analysis-txt">Amount</div>
      </li>
      <li class="analysis-item-2">        
        <div class="analysis-vlu">
          <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="lblTax" runat="server"></asp:Label>
        </div>
        <div class="analysis-txt">Tax</div>
      </li>
      <li class="analysis-item-3">        
        <div class="analysis-vlu">
          <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="lbltotalAmt" runat="server"></asp:Label>
        </div>
        <div class="analysis-txt">Total</div>
      </li>
    </ul>
    <div class="clear"></div>
  </div> 
    <div style="padding:0px 10px 10px 10px">
          <asp:Label ID="lblcount" CssClass="error" runat="server"></asp:Label>
      <asp:GridView ID="Gridview_admission" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" AllowPaging="true" PageSize="30" OnPageIndexChanging="Gridview_admission_PageIndexChanging" EmptyDataText="No records Found" Width="100%" >
        <Columns>
        <%-- <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <a href="" rel="htmltooltip"><div  class="htmltooltip"><table><tr><td>
                           <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("detailsinfo")%>'></asp:Literal></td></tr></table> </div> <%#Eval("studentid")%></a>
                    </ItemTemplate>
                </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Student ID">
          <ItemTemplate>
            <asp:HiddenField ID="hdnlastreceiptdate" runat="server" Value='<%#Eval("lastreceiptdate")%>' />
            <%#Eval("studentid")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Name">
          <ItemTemplate> <%#Eval("Name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DOJ">
          <ItemTemplate> <%#Eval("dateofjoin")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Phone">
          <ItemTemplate> <%#Eval("Phone")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice">
          <ItemTemplate> <a target="_blank" title="Click to see invoice" href="InvoiceDetails.aspx?invno=<%#Eval("invoice")%>"><%#Eval("invoice")%></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Course">
          <ItemTemplate> <%#Eval("Program")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fees">
          <ItemTemplate> <%#Eval("coursefees")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Paid amt">
          <ItemTemplate> <%#Eval("Totalpaidamount")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Last Paid date">
          <ItemTemplate> <%#Eval("lastreceiptdate")%> </ItemTemplate>
        </asp:TemplateField>
        <%-- <asp:TemplateField HeaderText="Due Date">
                    <ItemTemplate>
                        <%#Eval("lastdate")%>
                    </ItemTemplate>
                </asp:TemplateField>
            
                 <asp:TemplateField HeaderText="No. Balance Ins.">
                    <ItemTemplate>
                        <%#Eval("noofinstallment")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Pending Amt">
          <ItemTemplate> <%#Eval("balanceamount")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pending Tax">
          <ItemTemplate> <%#Eval("balancetax")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Pending">
          <ItemTemplate> <%#Eval("totalbalance")%> </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Payment Mode">
                    <ItemTemplate>
                        <%#Eval("payment_mode")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
        </Columns>
             <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
       <div align="center" style="padding:10px 10px 0px 10px;">  
      <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClick="LinkButton1_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
    </div>
    </div>
    </div>
    <div class="file datagrid" style="display:none;">
      <asp:GridView ID="Gridview1" runat="server" CssClass="common" AutoGenerateColumns="False"  Width="100%" >
        <Columns>
        <asp:TemplateField HeaderText="Enroll Date">
          <ItemTemplate> <%#Eval("dateofjoin")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Name">
          <ItemTemplate> <%#Eval("Name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student ID">
          <ItemTemplate> <%#Eval("studentid")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Course">
          <ItemTemplate> <%#Eval("Program")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice No">
          <ItemTemplate> <%#Eval("invoice")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Course Fees">
          <ItemTemplate> <%#Eval("coursefees")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Paid amt">
          <ItemTemplate> <%#Eval("Totalpaidamount")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pending Amt">
          <ItemTemplate> <%#Eval("balanceamount")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Amt Pending">
          <ItemTemplate> <%#Eval("totalbalance")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Last Paid date">
          <ItemTemplate> <%#Eval("lastreceiptdate")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Phone">
          <ItemTemplate> <%#Eval("Phone")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks">
          <ItemTemplate> </ItemTemplate>
        </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
    
  </div>
</asp:Content>
