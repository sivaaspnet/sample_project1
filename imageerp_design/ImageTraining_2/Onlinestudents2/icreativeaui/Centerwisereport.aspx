<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Centerwisereport.aspx.cs" Inherits="superadmin_Centerwisereport" Title="Centerwise Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
		}
		else {
			return false;
		}
	}

	function sortval1() {

		var start = document.getElementById("ContentPlaceHolder1_txtfromcalender1").value;
		var end = document.getElementById("ContentPlaceHolder1_txttocalender1").value;

		var start_s = start.split("-");
		var end_s = end.split("-");

		//        if(start_s[0]<10)
		//        {
		//        start_s[0]=0+start_s[0];
		//        }

		var stDate = start_s[2] + start_s[1] + start_s[0];
		//        if(end_s[0]<10)
		//        {
		//        end_s[0]=0+end_s[0];
		//        }
		var enDate = end_s[2] + end_s[1] + end_s[0];

		var d = new Date();
		var curr_date = d.getDate();

		//alert(curr_date);
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
		//alert(stDate);
		//alert(toDate);
		//alert(csDate);
		//clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


		if (trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value) == "") {
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").value == "";
			alert("Please select the From date");
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor = "#e8ebd9";

			return false;
		}
		else if (csDate > 0) {
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").value == "";
			alert("Please select valid From date");
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor = "#e8ebd9";
			return false;
		}
		else if (trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value) == "") {
			document.getElementById("ContentPlaceHolder1_txttocalender1").value == "";
			alert("Please select the To date");
			document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
			document.getElementById("ContentPlaceHolder1_txttocalender1").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor = "#e8ebd9";
			return false;
		}
		else if (compDate < 0) {
			document.getElementById("ContentPlaceHolder1_txttocalender1").value == "";
			alert("Please select valid To date");
			document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
			document.getElementById("ContentPlaceHolder1_txttocalender1").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor = "#e8ebd9";
			return false;
		}
		else if (document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "") {
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "";
			alert("Please select centre code");
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor = "#e8ebd9";
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
		else {
			return true;
		}
	}

	function sortval2() {

		var start = document.getElementById("ContentPlaceHolder1_txtfromcalender2").value;
		var end = document.getElementById("ContentPlaceHolder1_txttocalender2").value;

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
		//alert(csDate);
		//clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


		if (trim(document.getElementById("ContentPlaceHolder1_txtfromcalender2").value) == "") {
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").value == "";
			alert("Please select the From date");
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor = "#e8ebd9";

			return false;
		}
		else if (csDate > 0) {
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").value == "";
			alert("Please select valid From date");
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor = "#e8ebd9";
			return false;
		}
		else if (trim(document.getElementById("ContentPlaceHolder1_txttocalender2").value) == "") {
			document.getElementById("ContentPlaceHolder1_txttocalender2").value == "";
			alert("Please select the To date");
			document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
			document.getElementById("ContentPlaceHolder1_txttocalender2").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor = "#e8ebd9";
			return false;
		}
		else if (compDate < 0) {
			document.getElementById("ContentPlaceHolder1_txttocalender2").value == "";
			alert("Please select valid To date");
			document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
			document.getElementById("ContentPlaceHolder1_txttocalender2").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor = "#e8ebd9";
			return false;
		}
		else if (document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "") {
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "";
			alert("Please select centre code");
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border = "#ff0000 1px solid";
			document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor = "#e8ebd9";
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
		else {
			return true;
		}
	}



</script>
  <script type="text/javascript">
	$(document).ready(function () {

		jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
		Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

		function EndRequestHandler(sender, args) {
			jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
		}

	});
</script>
  <style type="text/css">
.overlay {
	position: fixed;
	z-index: 98;
	top: 0px;
	left: 0px;
	right: 0px;
	bottom: 0px;
	background-color: #fff;
	filter: alpha(opacity=80);
	opacity: 0.8;
}
.overlayContent{
	z-index: 99;
	margin: 250px auto;
	width: 80px;
	height:80px;
}
.overlayContent h2{
	font-size: 18px;
	font-weight: bold;
	color: #000;
}
.style1{
	width: 83px;
}
	
</style>
  
  <div class="free-forms">
    <asp:ScriptManager id="ScriptManager1" runat="server"> </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
      <ContentTemplate>
        <asp:UpdateProgress id="UpdateProgress1" runat="server">
          <ProgressTemplate>
            <div class="overlay"></div>
            <div class="overlayContent"> <img src="../layout/ajax.gif"  alt="Trace" /> </div>
          </ProgressTemplate>
        </asp:UpdateProgress>
        

            <div class="title-cont">
    <h3 class="cont-title">
                
                       View Centrewise Report </h3>
           <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Reports</a>/</li>
        <li><a href="Centerwisereport.aspx" class="last">View Centrewise Report</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
        <div class="search-sec-cont">
          <ul>
            <li><div class="wth-1">From Date</div>
              <div class="wth-2"><span class="date-pick-cont"><asp:TextBox ID="txtfromcalender2" onkeypress="return false" onkeydown="return false" onpaste="return false" runat="server" CssClass="text datepicker input-txt  date-input-txt"></asp:TextBox></span></div>
            </li>
            <li><div class="wth-1">To Date</div>
             <div class="wth-2"><span class="date-pick-cont"> <asp:TextBox ID="txttocalender2" onkeypress="return false" onkeydown="return false" onpaste="return false" runat="server" CssClass="text datepicker input-txt  date-input-txt"></asp:TextBox></span></div>
            </li>
            <li>
              <asp:Button ID="btnsort1" OnClick="btnsort1_Click" runat="server" Text="Search" CssClass="search-btn" OnClientClick="javascript:return sortval2();"></asp:Button>
            </li>
          </ul>
          <div class="clear"></div>
        </div>
        <div id="wrap" runat="server">
          <div id="wraps" runat="server">
            <div class="report-sec white-cont" align="right">Centerwise Report -
              <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
              - To -
              <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="sec-cont">
              <div class="lt-section white-cont" style="width:49%">
                <h4 class="cont-title">Enquiry Details</h4>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px; text-align: center" class="dataGrid2">
                  <table style="width: 100%; border-collapse: collapse" id="tt1" class="common2" runat="server">
                    <tbody>
                      <tr>
                        <th width="33.3%"><div align="center">Walkin Enquiries</div></th>
                        <th width="33.3%"><div align="center">Tele Enquiries</div></th>
                        <th width="33.3%"><div align="center">Total</div></th>
                      </tr>
                      <tr>
                        <td><div align="center">
                            <asp:Label ID="lbl_tot_enq" runat="server" Text=""></asp:Label>
                          </div></td>
                        <td><div align="center">
                            <asp:Label ID="lbl_tot_tele_enq" runat="server" Text=""></asp:Label>
                          </div></td>
                        <td><div align="center">
                            <asp:Label ForeColor="Maroon" Font-Bold="true" ID="total_enquires" runat="server" Text=""> </asp:Label>
                          </div></td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
              <div class="rt-section white-cont " style="width:49%">
                <h4 class="cont-title"> Enrollment Details</h4>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px; text-align: center" class="dataGrid2">
                  <asp:Repeater id="GridView2" runat="server" onitemdatabound="GridView2_ItemDataBound">
                    <HeaderTemplate>
                      <table width="100%" class="common2" style="border-collapse: collapse; margin-bottom:15px;">
                      <tr>
                        <th width="50%">Course Type </th>
                        <th width="50%">Total No. Of Students</th>
                      </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                      <tr>
                        <td width="50%"><%#Eval("course")%> </td>
                        <td width="50%"><asp:Label ID="lblstudentjoined" runat="server" Text='<%#Eval("studentsjoined")%>'></asp:Label></td>
                      </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                      </table>
                    </FooterTemplate>
                  </asp:Repeater>
                  <table width="100%" class="common2" style="border-collapse: collapse;">
                    <tr>
                      <th width="50%">Total</th>
                      <th width="50%">Billed Value</th>
                    </tr>
                    <tr>
                      <td style="text-align: center; color: Maroon;" class="style1"><asp:Label Font-Bold="true" ID="total" runat="server" Text="0"></asp:Label></td>
                      <td style="width: 181px;text-align: center; color: Maroon;" class="style1"><asp:Label Font-Bold="true" ID="billedvalue" runat="server" Text="0"></asp:Label></td>
                    </tr>
                  </table>
                </div>
              </div>
              <div class="clear"></div>
            </div>
            <div class="sec-cont white-cont">
              <div class="lt-section" style="width:49%">
                <h4 class="cont-title"> Enquiry-Source Name</h4>
                <div class="dataGrid2">
                  <table width="100%" class="common" style="border-collapse: collapse;">
                    <tr>
                      <th style="text-align: center; width: 70%">Source</th>
                      <th style="text-align: center; width: 30%">Count</th>
                    </tr>
                    <tr>
                      <td>News Paper</td>
                      <td><asp:Label ID="News" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Website</td>
                      <td><asp:Label ID="Website" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Print Advertisement</td>
                      <td><asp:Label ID="Advertisement" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>TV Advertisement</td>
                      <td><asp:Label ID="tv" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Google</td>
                      <td><asp:Label ID="google" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>JustDial</td>
                      <td><asp:Label ID="JustDial" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Sulekha</td>
                      <td><asp:Label ID="Sulekha" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>ROPS 
                        <div class="pop-txt">
                          <ul>
                            <li><a>?</a>
                              <div class="pop-sub">Reference&nbsp;of&nbsp;past&nbsp;Student</div>
                            </li>
                          </ul>
                        </div></td>
                      <td><asp:Label ID="ROPS" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>ROCS 
                        <div class="pop-txt">
                          <ul>
                            <li><a>?</a>
                              <div class="pop-sub">Reference&nbsp;of&nbsp;Current&nbsp;Student</div>
                            </li>
                          </ul>
                        </div></td>
                      <td><asp:Label ID="ROCS" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>ROS 
                        <div class="pop-txt">
                          <ul>
                            <li><a>?</a>
                              <div class="pop-sub">Reference&nbsp;of&nbsp;Staff</div>
                            </li>
                          </ul>
                        </div></td>
                      <td><asp:Label ID="ROS" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Reference of enquiry</td>
                      <td><asp:Label ID="Referenceofenquiry" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>WOM 
                        <div class="pop-txt">
                          <ul>
                            <li><a>?</a>
                              <div class="pop-sub">Words&nbsp;of&nbsp;Mouth</div>
                            </li>
                          </ul>
                        </div></td>
                      <td><asp:Label ID="WOM" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Board</td>
                      <td><asp:Label ID="Board" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Others</td>
                      <td><asp:Label ID="others" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td><strong>Total</strong></td>
                      <td><strong style="color:#800000">0</strong></td>
                    </tr>
                  </table>
                </div>
              </div>
              <div class="rt-section" style="width:49%">
                <h4 class="cont-title">Enquiry-Profile</h4>
                <div class="dataGrid2">
                  <table width="100%" class="common" style="border-collapse: collapse;">
                    <tr>
                      <th style="width:70%">Category</th>
                      <th style="width:30%">Count</th>
                    </tr>
                    <tr>
                      <td>School student</td>
                      <td><asp:Label ID="school" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>College student</td>
                      <td><asp:Label ID="college" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Employed</td>
                      <td><asp:Label ID="Employed" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Unemployed</td>
                      <td><asp:Label ID="Unemployed" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Self - Employed</td>
                      <td><asp:Label ID="Self" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Housewife</td>
                      <td><asp:Label ID="Housewife" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Sr.Citizen</td>
                      <td><asp:Label ID="Citizen" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Multimedia - Professional</td>
                      <td><asp:Label ID="Professional" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>Corporate</td>
                      <td><asp:Label ID="Corporate" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                      <td><strong>Total</strong></td>
                      <td><strong style="color:#800000">0</strong></td>
                    </tr>
                  </table>
                </div>
              </div>
              <div class="clear"></div>
            </div>
            <div class="sec-cont white-cont">
              <h4 class="cont-title"> Fees Details (With Taxes)</h4>
              <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px; text-align: center" class="dataGrid2">
                <table style="width: 100%; border-collapse: collapse" class="common">
                  <tbody>
                    <tr>
                      <th>Collection Details</th>
                      <th>Total No. of students</th>
                      <th>Cash Amount</th>
                      <th>Cheque amount</th>
                      <th>Total amount</th>
                    </tr>
                    <tr>
                      <td><asp:Label ID="Label1" runat="server" Text="Fresh collection (New)"></asp:Label></td>
                      <td><asp:Label ID="Freshstudent" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Freshcash" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Freshcheque" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Totalfresh" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td><asp:Label ID="Label2" runat="server" Text="Regular Collection (Old)"></asp:Label></td>
                      <td><asp:Label ID="Regularstudent" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Regularcash" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Regularcheque" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Totalregular" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td><asp:Label ID="Label3" runat="server" Text="Others (Late, Break etc)"></asp:Label></td>
                      <td><asp:Label ID="Breakagestudent" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Breakcash" runat="server"></asp:Label></td>
                      <td><asp:Label ID="Breakcheque" runat="server"></asp:Label></td>
                      <td><asp:Label ID="TotalBreakage" runat="server"></asp:Label></td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
</asp:Content>
