<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewAdmission.aspx.cs" Inherits="superadmin_ViewAdmission" Title="View Admission Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="http://cdn.webrupee.com/js" type="text/javascript"></script>
  <script src="js/jquery/Chart.bundle.min.js"></script>
  <script>
    var config = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [85, 15],
                backgroundColor: [
					"#ffffff",
					"#3089c5"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#3089c5"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 70,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config2 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [60, 40],
                backgroundColor: [
					"#ffffff",
					"#18a98b"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#18a98b"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 70,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config3 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [50, 50],
                backgroundColor: [
					"#ffffff",
					"#60a316"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#60a316"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 70,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config4 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [90, 10],
                backgroundColor: [
					"#ffffff",
					"#da8c0f"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#da8c0f"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 70,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };
	
	var config5 = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [25, 75],
                backgroundColor: [
					"#ffffff",
					"#d04437"
				],
				hoverBackgroundColor: [
					"#ffffff",
					"#d04437"
				],
				borderWidth: [
					0, 0
				],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
		    cutoutPercentage: 70,
            responsive: true,
            legend: {
                position: 'top',
				display: false
            },
            title: {
                display: false,
                text: 'Chart.js Doughnut Chart'
            },
            animation: {
                animateScale: false,
                animateRotate: true
            }
        }
    };

    window.onload = function() {
	    Chart.defaults.global.tooltips.enabled = false;
        var ctx = document.getElementById("chart-area").getContext("2d");
		var ctx2 = document.getElementById("chart-area2").getContext("2d");
		var ctx3 = document.getElementById("chart-area3").getContext("2d");
		var ctx4 = document.getElementById("chart-area4").getContext("2d");
		var ctx5 = document.getElementById("chart-area5").getContext("2d");
        window.myDoughnut = new Chart(ctx, config);
		window.myDoughnut2 = new Chart(ctx2, config2);
		window.myDoughnut3 = new Chart(ctx3, config3);
		window.myDoughnut4 = new Chart(ctx4, config4);
		window.myDoughnut5 = new Chart(ctx5, config5);
    };
</script>
  <script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ctl00_ContentPlaceHolder1_txtkeyword").autocomplete('Handler2.ashx');
   // alert("check");  
});  
</script>
  <script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ctl00_ContentPlaceHolder1_txtkeyword").autocomplete('Handler4.ashx');
   // alert("check");  
});  
</script>
  <script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ctl00_ContentPlaceHolder1_txtkeyword").autocomplete('Handler5.ashx');
   // alert("check");  
});  
</script>
  <script language="javascript" type="text/javascript">
 function trim(stringToTrim) {
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

 function AllowAlphabet(e){
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
 
function sortval1(){
	var start = document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value;
	var end = document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value;

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
        
   if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").value)=="" && trim(document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value)==""  && trim(document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value)==""){
             document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").value=="";   
             alert("Please enter the keywords");
             document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").style.backgroundColor="#e8ebd9";
           
             return false;
         }
	else if ((trim(document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value)!=""  && trim(document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value)=="")
	  {
		 document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value=="";   
		 alert("Please select the To date");
		 document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").focus();
		 document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
		 document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
		 return false;
	 }
	  else if ((trim(document.getElementById("ctl00_ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value)!=""  && trim(document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value)=="")
	  {
	   document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value=="";
		 alert("!Invalid From date");
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").focus();
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
		 return false;
	  }
	 else if(csDate > 0)
	 {
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value=="";
		 alert("!Invalid From date");
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").focus();
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
		 document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
		 return false;
	}
 
     else
     {
     	return true;
     }
}
</script>
  <div class="title-cont">
    <h3 class="cont-title">View Enrolled Student Report (
      <asp:Label ID="lblcount" runat="server"></asp:Label>
      )</h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="viewAdmission.aspx" class="last">View Enrolled Student Report</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>
  <div class="gridSort">
    <div class="search-sec-cont">
      <div align="center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label>
      </div>
      <ul id="viewby_admin" visible="false" runat="server">
        <li>
          <div class="wth-1">Select centre code</div>
          <div class="wth-2">
            <asp:DropDownList ID="ddl_centrcode" runat="server" OnSelectedIndexChanged="ddl_centrcode_SelectedIndexChanged"> </asp:DropDownList>
          </div>
        </li>
      </ul>
      <ul>
        <li>
          <div class="wth-1">Keywords :</div>
          <div class="wth-2">
            <asp:TextBox ID="txtkeyword" runat="server" CssClass="text input-txt"></asp:TextBox>
            <br />
            (Name / studentid / Course) </div>
        </li>
        <li class="date-sec-cont">
          <div class="wth-1">Date From</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txtfromcalender1" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" CssClass="text datepicker date-input-txt"></asp:TextBox>
          </div>
          <div class="wth-3">To</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txttocalender1" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" CssClass="text datepicker date-input-txt"></asp:TextBox>
          </div>
        </li>
        <li>
          <asp:Button ID="btnsort" runat="server" Text="Apply" CssClass="btnStyle1" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" />
        </li>
      </ul>
      <div class="clear"></div>
      <div align="center">
        <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtkeyword"></asp:CustomValidator>
      </div>
    </div>
  </div>
  <%--<div class="statistics-list">
    <ul>
      <li>
        <div class="statistics-item-1">
          <div class="statis-icon">
            <canvas id="chart-area" height="1" width="1"></canvas>
          </div>
          <div class="statis-value"><span>14</span></div>
          <div class="statis-details">Diploma</div>
          <div class="clear"></div>
        </div>
      </li>
      <li>
        <div class="statistics-item-2">
          <div class="statis-icon">
            <canvas id="chart-area2" height="1" width="1"></canvas>
          </div>
          <div class="statis-value"><span>14</span></div>
          <div class="statis-details">Higher Diploma</div>
          <div class="clear"></div>
        </div>
      </li>
      <li>
        <div class="statistics-item-3">
          <div class="statis-icon">
            <canvas id="chart-area3" height="1" width="1"></canvas>
          </div>
          <div class="statis-value"><span>14</span></div>
          <div class="statis-details">Certificate</div>
          <div class="clear"></div>
        </div>
      </li>
      <li>
        <div class="statistics-item-4">
          <div class="statis-icon">
            <canvas id="chart-area4" height="1" width="1"></canvas>
          </div>
          <div class="statis-value"><span>14</span></div>
          <div class="statis-details">Higher Certificate</div>
          <div class="clear"></div>
        </div>
      </li>
      <li class="last">
        <div class="statistics-item-5">
          <div class="statis-icon">
            <canvas id="chart-area5" height="1" width="1"></canvas>
          </div>
          <div class="statis-value">
            <span style="font-family:rupee;font-size:20px">R</span><asp:Label ID="billed" runat="server" Text="Label"></asp:Label>
          </div>
          <div class="statis-details">Billed Value</div>
          <div class="clear"></div>
        </div>
      </li>
    </ul>
    <div class="clear"></div>
  </div>--%>
  <div class="white-cont">
    <h4 class="cont-title2">Student Details</h4>
    <!--<div style="width:50%; float:left;">
      <div class="dataGrid" style="padding:0px 10px 10px 10px">
        <asp:GridView ID="gvtype" runat="server" CssClass="common" AutoGenerateColumns="False" width="100%">
          <Columns>
          <asp:BoundField HeaderText="Course Type" DataField="course"/>
          <asp:BoundField HeaderText="No.of students Joined" DataField="studentsjoined" />
          </Columns>
        </asp:GridView>
      </div>
    </div>
    <div style="width:50%; float:left;">
      <div style="line-height:30px; border:0px; color:Maroon; font-weight:bold; font-size:14px;">BilledValue :
        
      </div>
    </div>-->
    <div style="padding:0px 10px 10px 10px">
      <asp:GridView ID="Gridview_admission" runat="server" CssClass="tbl-cont3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" EmptyDataText="No records Found" OnRowCommand="Gridview_admission_RowCommand" PageSize="20" Width="100%">
        <Columns>
        <asp:TemplateField HeaderText="Student ID">
          <ItemTemplate> <%#Eval("studid")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Name" ItemStyle-CssClass="txt-trans-cap">
          <ItemTemplate> <a rel="modal" href="Viewstudentpersonaldetails.aspx?stuid=<%#Eval("student_id")%>&iframe=true&amp;width=600&amp;height=500" class="link2"><%#Eval("enq_personal_name")%></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="coursefees" HeaderText="Billed Value" ItemStyle-CssClass="txt-al-rt"/>
        <asp:BoundField DataField="about" HeaderText="Source" />
        <asp:BoundField DataField="enq_student_profile" HeaderText="Profile" />
        <asp:TemplateField HeaderText="Enrolled By">
          <ItemTemplate> <%#Eval("Enrolled_By")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="dateofenroll" HeaderText="Enrolled date" />
        <asp:TemplateField HeaderText="Course">
          <ItemTemplate> <a rel="modal" href="viewstudentcoursedetails.aspx?stuid=<%#Eval("student_id")%>&iframe=true&amp;width=600&amp;height=450"><img src="../layout/32.png" title="Click on to view the course details " alt="View" /></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice Details">
          <ItemTemplate>
            <asp:LinkButton ID="lnkInvoice" CommandName="Inv" CommandArgument='<%#Eval("invoiceId") + ","+Eval("student_id") %>' runat="server">View Invoice</asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
          <ItemTemplate>
            <asp:Label runat="server" ID="lblstatus" Text='<%#Eval("student_enrolledStatus") %>'></asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="lastpaiddate" HeaderText="Last Paid Date" />
        <asp:TemplateField HeaderText="Update" ItemStyle-CssClass="txt-al-ctr">
          <ItemTemplate> <a rel="modal[]" href="studentStatus.aspx?studname=<%#Eval("enq_personal_name")%>&enrollno=<%#Eval("student_id")%>&invoiceid=<%#Eval("invoiceId")%>&iframe=true&amp;width=600&amp;height=320"><img src="layout/edit.png" title="Update status"  alt="Trace" /></a>&nbsp; </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
      <div align="center" style="padding:10px 10px 0px 10px;">
        <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
      </div>
    </div>
  </div>
  <div class="white-cont" style="display: none">
    <div class="datagrid" style="padding:10px;">
      <asp:GridView id="GridView1" runat="server" Width="630px" CssClass="common" AutoGenerateColumns="False" PageSize="20" OnRowCommand="Gridview_admission_RowCommand" EmptyDataText="No records Found" OnPageIndexChanging="Gridview_admission_PageIndexChanging">
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
        <Columns>
        <asp:TemplateField HeaderText="Student ID">
          <ItemTemplate> <%#Eval("student_id")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Student Name ">
          <ItemTemplate> <%#Eval("enq_personal_name")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Course">
          <ItemTemplate> <%#Eval("program")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Invoice No">
          <ItemTemplate> <%#Eval("invoiceId") %> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="coursefees" HeaderText="CourseFees" />
        <asp:BoundField DataField="coursefeeswithtax" HeaderText="CourseFees With Tax" />
        <asp:BoundField DataField="totpaid" HeaderText="Total Paid Amount" />
        <asp:BoundField DataField="peinding_amount" HeaderText="Pending Amount" />
        <asp:BoundField DataField="about" HeaderText="Sourse" />
        <asp:BoundField DataField="enq_student_profile" HeaderText="Profile" />
        <asp:BoundField DataField="enq_present_address" HeaderText="Address" />
        <asp:BoundField DataField="enq_present_city" HeaderText="City" />
        <asp:BoundField DataField="enq_present_district" HeaderText="District" />
        <asp:BoundField DataField="enq_present_state" HeaderText="State" />
        <asp:BoundField DataField="enq_present_pincode" HeaderText="Pincode" />
        <asp:TemplateField HeaderText="Enrolled By">
          <ItemTemplate> <%#Eval("Enrolled_By")%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="dateofenroll" HeaderText="Enrolled date" />
        <asp:BoundField DataField="studentstatus" HeaderText="Student Status" />
        <asp:BoundField DataField="reason" HeaderText="Reason" />
        <asp:BoundField DataField="student_enrolledStatus" HeaderText="Student Current Status" />
        <asp:BoundField DataField="student_enrolledStatus_remarks" HeaderText="Student Remarks" />
        <asp:BoundField DataField="lastpaiddate" HeaderText="Last Paid Date" />
        </Columns>
      </asp:GridView>
    </div>
  </div>
  <div class="white-cont no-mrg">
    <div class="dataGrid" style="padding:10px;">
      <table class="common" visible="false" runat="server">
        <tr>
          <td colspan="2" style="padding:0px; height: 40px;"><h4>Student Joined Details </h4></td>
        </tr>
        <tr>
          <td><strong>From Date :<br />
            </strong>
            <asp:TextBox ID="TextBox1"  CssClass="text datepicker"  runat="server"></asp:TextBox></td>
          <td><strong>To Date : <br />
            </strong>
            <asp:TextBox ID="TextBox2" CssClass="text datepicker" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnsear" runat="server" CssClass="search" OnClick="btnsear_Click"  /></td>
        </tr>
        <tr style="text-align:center;">
          <td colspan="2" >&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"></td>
        </tr>
      </table>
      <table class="common" >
        <tr>
          <td colspan="2" style="color: #ff3366"> Key: </td>
        </tr>
        <tr>
          <td colspan="2"><img alt="View" src="../layout/32.png" />-Click to View the Details</td>
        </tr>
      </table>
    </div>
  </div>
</asp:Content>
