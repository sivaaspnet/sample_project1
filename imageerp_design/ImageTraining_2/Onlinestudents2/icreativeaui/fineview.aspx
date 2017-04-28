<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="fineview.aspx.cs" Inherits="fineview" Title="Fine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txt_search").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
    
    
    
    function sortval2()
{

var start = document.getElementById("ContentPlaceHolder1_txtfromcalender2").value;
        var end = document.getElementById("ContentPlaceHolder1_txttocalender2").value;

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
        //alert(csDate);
//clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


   if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(csDate > 0)
        {
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").value=="";
             alert("Please select valid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor="#e8ebd9";
             return false;
        }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalender2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalender2").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(compDate < 0)
        {
             document.getElementById("ContentPlaceHolder1_txttocalender2").value=="";
             alert("Please select valid To date");
             document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor="#e8ebd9";
             return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
             alert("Please select centre code");
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
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
  <script type="text/javascript">
	$(document).ready(function() {
	
jQuery(".datepicker1").datepicker({showOn: 'both', buttonImage: 'layout/cal.png', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
		Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

		function EndRequestHandler(sender, args) {
jQuery(".datepicker1").datepicker({showOn: 'both', buttonImage: 'layout/cal.png', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
		}

	});
</script>
  <div class="title-cont">
    <h3 class="cont-title">View FINE Details</h3>
    <div class="breadcrumps">
      <ul>
        
        <li><a href="breakage.aspx">Breakage Details</a>/</li>
        <li><a href="#" class="last">View FINE Details</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <div class="search-sec-cont">
    <ul>
      <li class="date-sec-cont">
        <div class="wth-1">Date From</div>
        <div class="wth-2 date-pick-cont">
          <asp:TextBox id="txtfromcalender2" onkeydown="return false" onkeypress="return false" onpaste="return false" runat="server" CssClass="text datepicker1 date-input-txt"></asp:TextBox>
        </div>
        <div class="wth-3">To</div>
        <div class="wth-2 date-pick-cont">
          <asp:TextBox id="txttocalender2" onkeydown="return false"  onkeypress="return false" onpaste="return false" runat="server" CssClass="text datepicker1 date-input-txt"></asp:TextBox>
        </div>
      </li>
      <li>
        <div class="wth-1">Search By Student ID</div>
        <div class="wth-2"><span class="file">
          <asp:TextBox ID="txt_search" runat="server" CssClass="text input-txt"></asp:TextBox>
          </span></div>
      </li>
      <li>
        <asp:Button ID="btn_search" runat="server" CssClass="search-btn" OnClick="btn_search_Click" Text="Search" OnClientClick="javascript:return sortval2();"/>
      </li>
    </ul>
    <div class="clear"></div>
  </div>
  <div class="white-cont" style="padding:10px;">
   <div style="padding:0px 10px 10px 10px">
      <asp:GridView ID="GridView1" CssClass="tbl-cont3"  runat="server" AutoGenerateColumns="False" EmptyDataText="No Records" Width="100%" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
        <Columns>
        <asp:BoundField DataField="studentId" HeaderText="Student Id" />
        <asp:TemplateField HeaderText="Receipt_no">
          <ItemTemplate> <a rel="modal[]" href="finereceiptprint.aspx?studId=<%#Eval("studentId")%>&recptno=<%#Eval("receiptNo")%>&iframe=true&amp;width=100%&amp;height=100%"><%#Eval("receiptNo")%></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="studentname" HeaderText="Student Name" />
        <asp:BoundField   DataField="totalAmount" HeaderText="Fine Fees" />
        <asp:BoundField   DataField="finereason" HeaderText="Reason" />
        </Columns>
      </asp:GridView>
      <div class="file" style="padding:10px 0px 0px 0px;" align="center">
        <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" CssClass="download-btn">Download</asp:LinkButton>
      </div>
    </div>
  </div>
  
</asp:Content>
