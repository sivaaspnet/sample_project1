<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewEnquiry.aspx.cs" Inherits="superadmin_ViewEnquiry" Title="View Enquiry Page" EnableEventValidation = "false"  %>

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
        
        
         if(trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="" && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)==""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtkeyword").value=="";   
             alert("Please enter the keywords");
             document.getElementById("ContentPlaceHolder1_txtkeyword").focus();
             document.getElementById("ContentPlaceHolder1_txtkeyword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtkeyword").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)!="" )
         {
         
         var atLeast = 1;  
         var counter=0;	    
         var CHK = document.getElementById('<%=this.RadioButtonList1.ClientID%>');   
        var checkbox = CHK.getElementsByTagName("input");
         for (var i=0;i<checkbox.length;i++)
         {             
        if (checkbox[i].checked)
        {
            counter++;            
        }
        }
             if(atLeast>counter)
	    {
	         alert("Please select Search By..!");
	          document.getElementById("ContentPlaceHolder1_RadioButtonList1").focus();
             document.getElementById("ContentPlaceHolder1_RadioButtonList1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_RadioButtonList1").style.backgroundColor="#e8ebd9";
             return false;	        
        }   
             else
             {
             return true;
             }
         }
        else if ((trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)!=""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
          {
             document.getElementById("ContentPlaceHolder1_txttocalender").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if ((trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)!=""  && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)=="")
          {
           document.getElementById("ContentPlaceHolder1_txtfromcalender").value=="";
             alert("!Invalid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
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
function IMG1_onclick() {

}

$(document).ready(function() {
    $("#ContentPlaceHolder1_txtkeyword").autocomplete('Handler1.ashx');      
});  
</script>
  <div class="title-cont">
    <h3 class="cont-title">View Enquiry Student Report (
      <asp:Label ID="lblcount" runat="server"></asp:Label>
      )</h3>
    <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="viewenquiry.aspx" class="last">View Enquiry Student Report</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <div class="content-links" align="right"> <a href="Droppedstudentdetails.aspx" class="error">Dropped Student Report</a> <a href="Followingstudentdetails.aspx" class="error">Following Student Report</a> </div>
  <div class="gridSort">
    <div class="search-sec-cont">
      <div align="center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label>
      </div>
      <ul id="viewonly_to_sa" runat="server">
        <li>
          <div class="wth-1">Select centre code</div>
          <div class="wth-2">
            <asp:DropDownList ID="ddl_sa_cencode" runat="server" CssClass="sele-txt"> </asp:DropDownList>
          </div>
        </li>
      </ul>
      <ul>
        <li>
          <div class="wth-1">Keywords:</div>
          <div class="wth-2">
            <asp:TextBox ID="txtkeyword" CssClass="text input-txt" runat="server"></asp:TextBox>
          </div>
        </li>
        <li>
          <div class="wth-1">Search By</div>
          <div class="wth-2">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="Student Name">Name</asp:ListItem>
              <asp:ListItem Value="About Image">Sourse</asp:ListItem>
              <asp:ListItem Value="Profile">Profile</asp:ListItem>
              <asp:ListItem Value="Qualification">Qualification</asp:ListItem>
              <asp:ListItem Value="Institution">Institution</asp:ListItem>
              <asp:ListItem Value="Area">Area</asp:ListItem>
            </asp:RadioButtonList>
          </div>
        </li>
        <li class="date-sec-cont">
          <div class="wth-1">Date From</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txtfromcalender" onpaste="return false" onKeyPress="return false"  onkeydown="return false" runat="server" CssClass="text datepicker date-input-txt"></asp:TextBox>
          </div>
          <div class="wth-3">To</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txttocalender" runat="server" onpaste="return false" onKeyPress="return false"  onkeydown="return false" CssClass="text datepicker date-input-txt"></asp:TextBox>
          </div>
        </li>
        <li>
          <asp:Button ID="btnsort" runat="server" Text="Apply" CssClass="btnStyle1" OnClick="btnsort_Click" OnClientClick="javascript:return sortval();" />
        </li>
      </ul>
      <div class="clear"></div>
      <div align="center">
        <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special" ControlToValidate="txtkeyword" CssClass="error"></asp:CustomValidator>
      </div>
    </div>
  </div>
  <div class="white-cont no-mrg">
   <div style="padding:0px 10px 10px 10px">
      <asp:GridView ID="GridView1" runat="server" CssClass="tbl-cont3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" >
        <Columns>
        <asp:TemplateField HeaderText="Enquiry No">
          <ItemTemplate> <%#Eval("enqno")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date/Time">
          <ItemTemplate> <%#Eval("dateins")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name">
          <ItemTemplate> <%#Eval("enq_personal_name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Source">
          <ItemTemplate> <%#Eval("about")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Profile">
          <ItemTemplate> <%#Eval("enq_student_profile")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enquired By">
          <ItemTemplate> <%#Eval("Created_By") %> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Closing Details">
          <ItemTemplate> <a rel="modal" href="closingstatusview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=300"><img src="../layout/32.png" title="Click here to view the closing details" alt="View" /></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="View More...">
          <ItemTemplate> <a rel="modal" href='personalview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&width=1000&height=700'><img src="../layout/32.png" title="Click here to view the personal details" alt="View" id="IMG1" language="javascript" onclick="return IMG1_onclick()" /></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reminder Date">
          <ItemTemplate> <%#Eval("reminderdate") %> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remark">
          <ItemTemplate> <%#Eval("remark") %> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
          <ItemTemplate>
            <asp:DropDownList ID="ddlfollowstatus" runat="server" CssClass="sele-txt">
              <asp:ListItem Value="Following">Following</asp:ListItem>
              <asp:ListItem Value="Spot enrolled">Spot enrolled</asp:ListItem>
              <asp:ListItem Value="Very prospective">Very prospective</asp:ListItem>
              <asp:ListItem Value="Prospective">Prospective</asp:ListItem>
              <asp:ListItem Value="Not prospective">Not prospective</asp:ListItem>
              <asp:ListItem Value="Fake">Fake</asp:ListItem>
              <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
              <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>
              <asp:ListItem Value="Not Reachable">Not Reachable</asp:ListItem>
              <asp:ListItem Value="RNR">RNR</asp:ListItem>
              <asp:ListItem Value="Wrong Number">Wrong Number</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="hdnstatus" Visible="false" runat="server"  Text='<%#Eval("enq_enqstatus")%>'></asp:Label>
            <asp:Button ID="btnupd" runat="server"  CssClass="update" ToolTip="Update" OnClick="btnupd_Click"   />
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Followups">
          <ItemTemplate>
            <asp:Label ID="lblhdnmsg" runat="server" Text='<%#Eval("enq_number")%>' Visible="false"></asp:Label>
            <a  rel="modal[]" href="followup.aspx?viewenqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=500"><img src="layout/text.png" title="Add follow ups"  alt="Trace" /></a>&nbsp;<a style="margin-left:15px;"  rel="modal[]" href="followupview.aspx?viewenqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=500"><img src="../layout/32.png" title="View Follow ups" alt="View" /></a> </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle ForeColor="Red" />
        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
    </div>
    <div style="padding:10px;" align="center">
      <asp:LinkButton ID="LnkDownlaodExcel" runat="server" OnClick="LnkDownlaodExcel_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
    </div>
    <div class="dataGrid2" style="display:none;">
      <asp:GridView ID="GridView2" runat="server" CssClass="common2" AutoGenerateColumns="False" EmptyDataText="No Records Found" >
        <EmptyDataRowStyle ForeColor="Red" />
        <Columns>
        <asp:TemplateField HeaderText="Enquiry No">
          <ItemTemplate> <%#Eval("enqno")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name">
          <ItemTemplate> <%#Eval("enq_personal_name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enquired By">
          <ItemTemplate> <%#Eval("Created_By") %> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="program" HeaderText="Course" />
        <asp:TemplateField HeaderText="Date/Time">
          <ItemTemplate> <%#Eval("dateins")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Personal Number">
          <ItemTemplate> <%#Eval("enq_personal_mobile")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
          <ItemTemplate> <%#Eval("enq_personal_email")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="about" HeaderText="sourse" />
        <asp:BoundField DataField="enq_student_profile" HeaderText="profile" />
        <asp:BoundField DataField="enq_high_qualification" HeaderText="Qualification" />
        <asp:BoundField DataField="enq_high_institution" HeaderText="Institution" />
        <asp:BoundField DataField="enq_present_district" HeaderText="Address" />
        <asp:BoundField DataField="enq_enqstatus" HeaderText="Status" />
        <asp:BoundField DataField="dateins" HeaderText="Expected Enrollment Date" />
        <asp:BoundField DataField="reminderdate" HeaderText="Reminder Date" />
        <asp:BoundField DataField="remark" HeaderText="Remark" />
        </Columns>
        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
    </div>
    <asp:HiddenField ID="hdnenqID" runat="server" Value='<%#Eval("enq_number")%>' />
    <div style="padding:10px;" id="note" runat="server">
      <ul class="list-items">
        <li><img src="../layout/text.png"  alt="Trace" /> &nbsp;Click on to Trace the Follow ups</li>
        <li><img src="../layout/32.png" alt="View" /> &nbsp;Click to View the Details</li>
        <li>
          <asp:Label ID="Label1" runat="server" ForeColor="DarkGreen" CssClass="link" Text="Enquiry No"></asp:Label>
          ---Click on Enquiry No to Reach the Admission form</li>
        <li>
          <asp:Label ID="Label2" runat="server" ForeColor="DarkGreen" CssClass="link1" Text="Enquiry No"></asp:Label>
          ---Click on Enquiry No to update for express enrolled student</li>
      </ul>
    </div>
  </div>
</asp:Content>
