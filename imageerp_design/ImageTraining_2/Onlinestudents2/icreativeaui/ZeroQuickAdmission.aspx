<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ZeroQuickAdmission.aspx.cs" Inherits="QuickAdmission" Title="Express Enrollment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
      function AllowAlphabet(e) {
          isIE = document.all ? 1 : 0
          keyEntry = !isIE ? e.which : event.keyCode;
          if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
              return true;
          } else {
              return false;
          }
      }

      function checkZero() {
          if (document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == 0) {
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").value = "";
          }

      }
      function install() {
          if (document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value == document.getElementById("ContentPlaceHolder1_lbllumpamt").value) {
              document.getElementById("insdate").style.display = 'none';
          }
          else {
              document.getElementById("insdate").style.display = 'table-row';
          }
      }


      function validate() {

       

          var start = document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value;
          var start_s = start.split("-");
          var stDate = parseInt(start_s[2] + start_s[1] + start_s[0]);

          var d = new Date();
          var curr_date = d.getDate();
          var curr_month = d.getMonth();
          curr_month++;
          var curr_year = d.getFullYear();
          var mon = (curr_month < 10 ? '0' : '') + curr_month
          var dday = (curr_date < 10 ? '0' : '') + curr_date
          var toDate = parseInt(curr_year + '' + mon + '' + dday);
          //var csDate = stDate - toDate;
          var csDate = parseInt(stDate - toDate);

          var start1 = document.getElementById("ContentPlaceHolder1_txt_installdate").value;
          var start_s1 = start1.split("-");
          var stDate1 = parseInt(start_s1[2] + start_s1[1] + start_s1[0]);

          var d1 = new Date();
          var curr_date1 = d1.getDate();
          var curr_month1 = d1.getMonth();
          curr_month1++;
          var curr_year1 = d1.getFullYear();
          var mon1 = (curr_month1 < 10 ? '0' : '') + curr_month1
          var dday1 = (curr_date1 < 10 ? '0' : '') + curr_date1
          var toDate1 = parseInt(curr_year1 + '' + mon1 + '' + dday1);
          //var csDate = stDate - toDate;
          var csDate1 = parseInt(stDate1 - toDate1);
          if (document.getElementById("ContentPlaceHolder1_txtname").value == "") {
              document.getElementById("ContentPlaceHolder1_txtname").value == "";
              document.getElementById("ContentPlaceHolder1_txtname").focus();
              document.getElementById("ContentPlaceHolder1_txtname").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txtname").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_txtmobile").value == "") {
              document.getElementById("ContentPlaceHolder1_txtmobile").value == "";
              document.getElementById("ContentPlaceHolder1_txtmobile").focus();
              document.getElementById("ContentPlaceHolder1_txtmobile").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txtmobile").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value == "") {
              document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value == "";
              document.getElementById("ContentPlaceHolder1_ddl_aboutimage").focus();
              document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_profile").value == "") {
              document.getElementById("ContentPlaceHolder1_ddl_profile").value == "";
              document.getElementById("ContentPlaceHolder1_ddl_profile").focus();
              document.getElementById("ContentPlaceHolder1_ddl_profile").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_profile").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_txt_coursenamee").value == "") {
              document.getElementById("ContentPlaceHolder1_txt_coursenamee").value == "";
              document.getElementById("ContentPlaceHolder1_txt_coursenamee").focus();
              document.getElementById("ContentPlaceHolder1_txt_coursenamee").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_coursenamee").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddtrack").value == "") {
              document.getElementById("ContentPlaceHolder1_ddtrack").value == "";
              document.getElementById("ContentPlaceHolder1_ddtrack").focus();
              document.getElementById("ContentPlaceHolder1_ddtrack").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddtrack").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_payment").value == "") {
              document.getElementById("ContentPlaceHolder1_ddl_payment").value == "";
              document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
              document.getElementById("ContentPlaceHolder1_ddl_payment").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_payment").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value == "") {
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value == "";
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").focus();
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (csDate < 0) {
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value == "";
              alert("Invalid start date");
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").focus();
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_txt_installdate").value == "") {
              document.getElementById("ContentPlaceHolder1_txt_installdate").value == "";
              document.getElementById("ContentPlaceHolder1_txt_installdate").focus();
              document.getElementById("ContentPlaceHolder1_txt_installdate").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_installdate").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (csDate1 < 0) {
              document.getElementById("ContentPlaceHolder1_txt_installdate").value == "";
              alert("Invalid Installment date");
              document.getElementById("ContentPlaceHolder1_txt_installdate").focus();
              document.getElementById("ContentPlaceHolder1_txt_installdate").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_installdate").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value == "") {
              document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value == "";
              document.getElementById("ContentPlaceHolder1_ddlpaymentmode").focus();
              document.getElementById("ContentPlaceHolder1_ddlpaymentmode").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddlpaymentmode").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value) > parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)) {
              alert(" Please enter less than or equal to (maximum number of installments)");
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == "";
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value != "Cash") {
              if (document.getElementById("ContentPlaceHolder1_txtchequeno").value == "") {
                  document.getElementById("ContentPlaceHolder1_txtchequeno").value == "";
                  document.getElementById("ContentPlaceHolder1_txtchequeno").focus();
                  document.getElementById("ContentPlaceHolder1_txtchequeno").style.border = "#ff0000 1px solid";
                  document.getElementById("ContentPlaceHolder1_txtchequeno").style.backgroundColor = "#e8ebd9"
                  return false;
              }
              else if (document.getElementById("ContentPlaceHolder1_txtchequeno0").value == "") {
                  document.getElementById("ContentPlaceHolder1_txtchequeno0").value == "";
                  document.getElementById("ContentPlaceHolder1_txtchequeno0").focus();
                  document.getElementById("ContentPlaceHolder1_txtchequeno0").style.border = "#ff0000 1px solid";
                  document.getElementById("ContentPlaceHolder1_txtchequeno0").style.backgroundColor = "#e8ebd9"
                  return false;
              }
              else if (document.getElementById("ContentPlaceHolder1_txtbankname").value == "") {
                  document.getElementById("ContentPlaceHolder1_txtbankname").value == "";
                  document.getElementById("ContentPlaceHolder1_txtbankname").focus();
                  document.getElementById("ContentPlaceHolder1_txtbankname").style.border = "#ff0000 1px solid";
                  document.getElementById("ContentPlaceHolder1_txtbankname").style.backgroundColor = "#e8ebd9"
                  return false;
              }
              else {
                  return true;
              }
          }
          else if (document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value == "") {
              alert("Please mention initial amount");
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value != "0") {
              alert("Initial amount can be Zero");
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == "")) {
              alert("Please mention the no of installments");
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML))) {
              alert("Initial amount is greater than the course fee");
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor = "#e8ebd9";
              return false;
          }
          
          
          else {
              return true;
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


      function checkval() {
          if (document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value == "") {
              alert("Please mention initial amount");
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == "")) {
              alert("Please mention the no of installments");
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((parseInt(document.getElementById("ContentPlaceHolder1_txt_netamount").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML))) {
              alert("Initial amount is greater than the course fee");
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value) > parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)) {
              alert(" Please enter less than or equal to (maximum number of installments)");
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == "";
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_hdncentrecode").value != '') {
             
          }
          else {

              document.getElementById("ContentPlaceHolder1_txtamtmonthly").value = '0';
              return false;
          }
      }

      function clearValidation(fieldList) {
          var field = new Array();
          field = fieldList.split("~");
          var counter = 0;
          for (i = 0; i < field.length; i++) {
              //if(document.getElementById(field[i]).value!="")
              //{
              //			document.getElementById(field[i]).style.border="#EFEFEF 1px solid";
              //			document.getElementById(field[i]).style.backgroundColor="#FFFFFF";
              //}
          }
      }

      function trim(stringToTrim) {
          return stringToTrim.replace(/^\s+|\s+$/g, "");
      }

      function CheckNumeric(GetEvt) {
          var Char = (GetEvt.which) ? GetEvt.which : event.keyCode

          if (Char > 31 && (Char < 48 || Char > 57))
              return false;
          return true;
      }

      function Validate_Email(Email) {
          var Str = Email
          var CheckExpression = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
          if (CheckExpression.test(Str)) {
              return true;
          }
          else {
              return false;
          }
      }


      //form3
      function losefocus1(obj) {
          if (document.getElementById("ContentPlaceHolder1_ddl_phydefect").value != "Yes") {
              obj.value = "";
              obj.blur()
          }
      }


      function chkval1() {
          if (document.getElementById("ContentPlaceHolder1_ddl_phydefect").value != "Yes") {
              document.getElementById("ContentPlaceHolder1_txt_defectYes").value = ""
          }
      }


      function losefocuscash(obj) {
          if (document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value == 'Cash') {
              obj.value = "";
              obj.blur()
          }
      }

      function cashval() {
          if (document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value == 'Cash') {
              document.getElementById("ContentPlaceHolder1_txtchequeno").value = ""
              document.getElementById("ContentPlaceHolder1_txtbankname").value = ""
          }
      }

      function clearInstallDropDown() {
          var selectopt = document.getElementById("ContentPlaceHolder1_txt_instalamt1");
          var numberOfOptions = selectopt.options.length
          for (i = 0; i < numberOfOptions; i++) {
              selectopt.remove(0)
          }
      }

      function setFees(programId, feesType, track) {
          var res = 0;
          var i;
          var inset = 0;
          if (track == "fast") {
              var arraylength = courseFeesfast.length;
              for (i = 0; i < arraylength; i++) {
                  if (parseInt(courseFeesfast[i]["program"]) == parseInt(programId)) {
                      if (feesType == "Lump sum") {
                          document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML = courseFeesfast[i]["lump_sum"];
                          document.getElementById("ContentPlaceHolder1_lbllumpamt").value = courseFeesfast[i]["lump_sum"];
                          document.getElementById("ContentPlaceHolder1_hdnlumpamt").value = courseFeesfast[i]["lump_sum"];
                          document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML = courseFeesfast[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_HiddenField2").value = courseFeesfast[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML = courseFeesfast[i]["noofinstall"];
                      }
                      else if (feesType == "Installment") {
                          document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML = courseFeesfast[i]["instal_amount"];
                          document.getElementById("ContentPlaceHolder1_lbllumpamt").value = courseFeesfast[i]["instal_amount"];
                          document.getElementById("ContentPlaceHolder1_hdnlumpamt").value = courseFeesfast[i]["instal_amount"];
                          document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML = courseFeesfast[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_HiddenField2").value = courseFeesfast[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML = courseFeesfast[i]["noofinstall"];
                          if (inset == 0) {
                              createInstallmentNumbers(courseFeesfast[i]["noofinstall"]);
                              inset = 1;
                          }
                      }
                      else {
                          document.getElementById("ContentPlaceHolder1_txt_lumpamt").InnerHtml = "0";
                          document.getElementById("ContentPlaceHolder1_lbllumpamt").value = "0";
                      }
                  }
              }
          }
          else if (track == "normal") {
              var arraylength = courseFeesnormal.length;
              for (i = 0; i < arraylength; i++) {
                  if (parseInt(courseFeesnormal[i]["program"]) == parseInt(programId)) {
                      if (feesType == "Lump sum") {
                          document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML = courseFeesnormal[i]["lump_sum"];
                          document.getElementById("ContentPlaceHolder1_lbllumpamt").value = courseFeesnormal[i]["lump_sum"];
                          document.getElementById("ContentPlaceHolder1_hdnlumpamt").value = courseFeesnormal[i]["lump_sum"];
                          document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML = courseFeesnormal[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_HiddenField2").value = courseFeesnormal[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML = courseFeesnormal[i]["noofinstall"];
                      }
                      else if (feesType == "Installment") {
                          document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML = courseFeesnormal[i]["instal_amount"];
                          document.getElementById("ContentPlaceHolder1_lbllumpamt").value = courseFeesnormal[i]["instal_amount"];
                          document.getElementById("ContentPlaceHolder1_hdnlumpamt").value = courseFeesnormal[i]["instal_amount"];
                          document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML = courseFeesnormal[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_HiddenField2").value = courseFeesnormal[i]["tax"];
                          document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML = courseFeesnormal[i]["noofinstall"];
                          if (inset == 0) {
                              createInstallmentNumbers(courseFeesnormal[i]["noofinstall"]);
                              inset = 1;
                          }
                      }
                      else {
                          document.getElementById("ContentPlaceHolder1_txt_lumpamt").InnerHtml = "0";
                          document.getElementById("ContentPlaceHolder1_lbllumpamt").value = "0";
                      }
                  }
              }
          }
          return res;
      }

      function createInstallmentNumbers3(noofinstallmt) {
          clearInstallDropDown();
          var ddlInstall = document.getElementById("ContentPlaceHolder1_txt_instalamt1");
          for (i = 1; i <= noofinstallmt; i++) {
              var optn = document.createElement("OPTION");
              optn.text = i;
              optn.value = i;
              ddlInstall.options.add(optn);
          }
      }

      function setFees1() {
          document.getElementById("ContentPlaceHolder1_hdncou_id").value = document.getElementById("ContentPlaceHolder1_txt_coursenamee").value;
          var programFees = setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value, document.getElementById("ContentPlaceHolder1_ddl_payment").value, document.getElementById("ContentPlaceHolder1_ddtrack").value.toLowerCase());
      }

      function display() {
          if (document.getElementById("ContentPlaceHolder1_ddl_payment").value == "Lump sum") {
              var today = new Date();
              var dd = today.getDate();
              var mm = today.getMonth() + 1; //January is 0!
              var yyyy = today.getFullYear();
              if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm }
              today = dd + '-' + mm + '-' + yyyy;
              document.getElementById("lump1").style.display = 'table-row';
              document.getElementById("lump2").style.display = 'none';
              document.getElementById("lump3").style.display = 'table-row';
              document.getElementById("lump4").style.display = 'none';
              //			document.getElementById("insdate").style.display='none';
              document.getElementById("ContentPlaceHolder1_txt_installdate").value = today;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_payment").value == "Installment") {
              document.getElementById("ContentPlaceHolder1_txt_installdate").value = "";
              document.getElementById("lump1").style.display = 'table-row';
              document.getElementById("lump2").style.display = 'table-row';
              document.getElementById("lump3").style.display = 'table-row';
              document.getElementById("lump4").style.display = 'table-row';
          }
          else {
              document.getElementById("lump1").style.display = 'table-row';
              document.getElementById("lump2").style.display = 'table-row';
              document.getElementById("lump3").style.display = 'table-row';
              document.getElementById("lump4").style.display = 'table-row';
          }
      }


      function changepayment() {
          document.getElementById("ContentPlaceHolder1_ddl_payment").value = "";
          if (document.getElementById("ContentPlaceHolder1_txt_coursenamee").value == "") {
              document.getElementById("ContentPlaceHolder1_ddl_payment").style.display = '';
              document.getElementById("ContentPlaceHolder1_Label1").style.display = 'none';
              document.getElementById("ContentPlaceHolder1_ddl_payment").value = "";
              document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
              display();
          }
          else if (document.getElementById("ContentPlaceHolder1_txt_coursenamee").value == "65") {
              document.getElementById("ContentPlaceHolder1_ddl_payment").style.display = 'none';
              document.getElementById("ContentPlaceHolder1_ddl_payment").value = "Lump sum";
              document.getElementById("ContentPlaceHolder1_Label1").style.display = '';
              //document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
              document.getElementById("lump1").style.display = 'block';
              document.getElementById("lump2").style.display = 'none';
              document.getElementById("lump3").style.display = 'block';
              document.getElementById("lump4").style.display = 'none';
              var programFees = setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value, "Lump sum", document.getElementById("ContentPlaceHolder1_ddtrack").value.toLowerCase());
          }
          else {
              document.getElementById("ContentPlaceHolder1_ddl_payment").style.display = '';
              document.getElementById("lump1").style.display = 'none';
              document.getElementById("lump2").style.display = 'none';
              document.getElementById("lump3").style.display = 'none';
              document.getElementById("lump4").style.display = 'none';
              document.getElementById("ContentPlaceHolder1_Label1").style.display = 'none';
              document.getElementById("ContentPlaceHolder1_ddl_payment").value = "";
              document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
          }
          var i;
          for (i = 0; i < coursetrack.length; i++) {
              if (parseInt(coursetrack[i]["course_id"]) == document.getElementById("ContentPlaceHolder1_txt_coursenamee").value) {
                  document.getElementById("ContentPlaceHolder1_hdncoursetype").value = coursetrack[i]["coursetype"];
              }
          }
      }

      function addOption(text, value) {
          var txt = document.getElementById("ContentPlaceHolder1_txt_coursenamee");
          var optn = document.createElement("OPTION");
          optn.text = text;
          optn.value = value;
          txt.options.add(optn);
      }


      function clearDropDownList() {
          var selectbox = document.getElementById("ContentPlaceHolder1_txt_coursenamee");
          var numberOfOptions = selectbox.options.length
          for (i = 0; i < numberOfOptions; i++) {
              selectbox.remove(0)
          }
      }

      function SetDetails() {
          var j;
          clearDropDownList()
          addOption("Select", "")
          for (j = 0; j < coursetrack.length; j++) {
              addOption(coursetrack[j]['coursename'], coursetrack[j]['course_id'])
          }
      }

      function taxcalc() {
          document.getElementById("ContentPlaceHolder1_txtamtmonthly").value = "";
          var tax = parseFloat(document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML);
          //var tax=10.3;
          if (document.getElementById("ContentPlaceHolder1_CheckBox1").checked) {
              var intial_course_amt = (100 * (document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) / (100 + tax);
              document.getElementById("ContentPlaceHolder1_txt_netamount").value = Math.round(intial_course_amt, 0);
              var vat_tax = intial_course_amt * (tax / 100);
              document.getElementById("ContentPlaceHolder1_txt_vat").value = Math.round(vat_tax, 0);
              document.getElementById("ContentPlaceHolder1_netamount").value = Math.round(intial_course_amt, 0) + Math.round(vat_tax, 0);
          }
          else {
              var intial_course_amt = (document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value);
              document.getElementById("ContentPlaceHolder1_txt_netamount").value = Math.round(intial_course_amt, 0);
              var vat_tax = intial_course_amt * (tax / 100);
              document.getElementById("ContentPlaceHolder1_txt_vat").value = Math.round(vat_tax, 0);
              document.getElementById("ContentPlaceHolder1_netamount").value = Math.round(intial_course_amt, 0) + Math.round(vat_tax, 0);
          }
      }


      //quick receipt validation start




      function add() {

          if (trim(document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value) == "") {
              alert("Please select course");
              document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value = "";
              document.getElementById("ContentPlaceHolder1_txt_coursepositioned").focus();
              document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("ContentPlaceHolder1_txt_studname").value) == "") {
              alert("Please Enter Student Name");
              document.getElementById("ContentPlaceHolder1_txt_studname").value = "";
              document.getElementById("ContentPlaceHolder1_txt_studname").focus();
              document.getElementById("ContentPlaceHolder1_txt_studname").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_studname").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("ContentPlaceHolder1_TextBox1").value) == "") {
              alert("Please Enter Student Contact No");
              document.getElementById("ContentPlaceHolder1_TextBox1").value = "";
              document.getElementById("ContentPlaceHolder1_TextBox1").focus();
              document.getElementById("ContentPlaceHolder1_TextBox1").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_DropDownList1").value == "") {
              alert("Please Select sourse");
              document.getElementById("ContentPlaceHolder1_DropDownList1").value == "";
              document.getElementById("ContentPlaceHolder1_DropDownList1").focus();
              document.getElementById("ContentPlaceHolder1_DropDownList1").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_DropDownList1").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_profile0").value == "") {
              alert("Please Select profile");
              document.getElementById("ContentPlaceHolder1_ddl_profile0").value == "";
              document.getElementById("ContentPlaceHolder1_ddl_profile0").focus();
              document.getElementById("ContentPlaceHolder1_ddl_profile0").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_profile0").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "") {
              alert("Please Select Payment mode");
              document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "";
              document.getElementById("ContentPlaceHolder1_ddl_paymode").focus();
              document.getElementById("ContentPlaceHolder1_ddl_paymode").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_paymode").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value != "Cash" && document.getElementById("ContentPlaceHolder1_txt_ddcc").value == "") {
              alert("Please enter cheque number");
              document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
              document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
              document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value != "Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "") {
              alert("Please enter cheque Date");
              document.getElementById("ContentPlaceHolder1_dddate").value = "";
              document.getElementById("ContentPlaceHolder1_dddate").focus();
              document.getElementById("ContentPlaceHolder1_dddate").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_dddate").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value != "Cash" && document.getElementById("ContentPlaceHolder1_txt_bankname").value == "") {
              alert("Please enter Bank name");
              document.getElementById("ContentPlaceHolder1_txt_bankname").value = "";
              document.getElementById("ContentPlaceHolder1_txt_bankname").focus();
              document.getElementById("ContentPlaceHolder1_txt_bankname").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_bankname").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value) == "") {
              alert("Please Enter Initial Amount");
              document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value) == "0") {
              alert("Please Enter Initial Amount");
              document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value) < 500) {
              alert("Please Enter Initial Amount above 500");
              document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (isNaN(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)) {
              alert("Please Enter amount in numerics");
              document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor = "#e8ebd9";
              return false;
          }
else if (trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value) > 5000) {
              alert("Registration Amount is greater than 5000, Please use enrollment link");
              document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor = "#e8ebd9";
              return false;
          }


          else if ((parseInt(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_lblbalanceamount").innerHTML))) {
              alert("Please Check Your Installment Amount is Greater Than Balance Amount");
              //             //document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = "";
              //             document.getElementById("ContentPlaceHolder1_lblamtwithtax").focus();
              //             document.getElementById("ContentPlaceHolder1_lblamtwithtax").style.border="#ff0000 1px solid";
              //             document.getElementById("ContentPlaceHolder1_lblamtwithtax").style.backgroundColor="#e8ebd9";
              return false;
          }

          else if (document.getElementById("ContentPlaceHolder1_ddl_month").value == "") {
              alert("Please select Month");
              document.getElementById("ContentPlaceHolder1_ddl_month").value = "";
              document.getElementById("ContentPlaceHolder1_ddl_month").focus();
              document.getElementById("ContentPlaceHolder1_ddl_month").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_month").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "") {
              alert("Please Select Payment mode");
              document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "";
              document.getElementById("ContentPlaceHolder1_ddl_paymode").focus();
              document.getElementById("ContentPlaceHolder1_ddl_paymode").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_ddl_paymode").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value != "Cash" && document.getElementById("ContentPlaceHolder1_txt_ddcc").value == "") {
              alert("Please enter cheque number");
              document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
              document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
              document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value != "Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "") {
              alert("Please enter cheque number");
              document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
              document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
              document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("ContentPlaceHolder1_ddl_paymode").value != "Cash" && document.getElementById("ContentPlaceHolder1_txt_bankname").value == "") {
              alert("Please enter Bank name");
              document.getElementById("ContentPlaceHolder1_txt_bankname").value = "";
              document.getElementById("ContentPlaceHolder1_txt_bankname").focus();
              document.getElementById("ContentPlaceHolder1_txt_bankname").style.border = "#ff0000 1px solid";
              document.getElementById("ContentPlaceHolder1_txt_bankname").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else {
              return true;
          }
      }

      function test_skill(rup) {
          var junkVal = rup;
          junkVal = Math.floor(junkVal);
          var obStr = new String(junkVal);
          numReversed = obStr.split("");
          actnumber = numReversed.reverse();

          if (Number(junkVal) >= 0) {
              //do nothing
          }
          else {
              alert('wrong Number cannot be converted');
              return false;
          }
          if (Number(junkVal) == 0) {
              document.getElementById('container').innerHTML = obStr + '' + 'Rupees Zero Only';
              return false;
          }
          if (actnumber.length > 9) {
              alert('Oops!!!! the Number is too big to covertes');
              return false;
          }

          var iWords = ["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];
          var ePlace = ['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen'];
          var tensPlace = ['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety'];

          var iWordsLength = numReversed.length;
          var totalWords = "";
          var inWords = new Array();
          var finalWord = "";
          j = 0;
          for (i = 0; i < iWordsLength; i++) {
              switch (i) {
                  case 0:
                      if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                          inWords[j] = '';
                      }
                      else {
                          inWords[j] = iWords[actnumber[i]];
                      }
                      inWords[j] = inWords[j] + ' Only';
                      break;
                  case 1:
                      tens_complication();
                      break;
                  case 2:
                      if (actnumber[i] == 0) {
                          inWords[j] = '';
                      }
                      else if (actnumber[i - 1] != 0 && actnumber[i - 2] != 0) {
                          inWords[j] = iWords[actnumber[i]] + ' Hundred and';
                      }
                      else {
                          inWords[j] = iWords[actnumber[i]] + ' Hundred';
                      }
                      break;
                  case 3:
                      if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                          inWords[j] = '';
                      }
                      else {
                          inWords[j] = iWords[actnumber[i]];
                      }
                      if (actnumber[i + 1] != 0 || actnumber[i] > 0) {
                          inWords[j] = inWords[j] + " Thousand";
                      }
                      break;
                  case 4:
                      tens_complication();
                      break;
                  case 5:
                      if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                          inWords[j] = '';
                      }
                      else {
                          inWords[j] = iWords[actnumber[i]];
                      }
                      inWords[j] = inWords[j] + " Lakh";
                      break;
                  case 6:
                      tens_complication();
                      break;
                  case 7:
                      if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
                          inWords[j] = '';
                      }
                      else {
                          inWords[j] = iWords[actnumber[i]];
                      }
                      inWords[j] = inWords[j] + " Crore";
                      break;
                  case 8:
                      tens_complication();
                      break;
                  default:
                      break;
              }
              j++;
          }

          function tens_complication() {
              if (actnumber[i] == 0) {
                  inWords[j] = '';
              }
              else if (actnumber[i] == 1) {
                  inWords[j] = ePlace[actnumber[i - 1]];
              }
              else {
                  inWords[j] = tensPlace[actnumber[i]];
              }
          }
          inWords.reverse();
          for (i = 0; i < inWords.length; i++) {
              finalWord += inWords[i];
          }
          document.getElementById('ContentPlaceHolder1_txt_paymentwords').innerHTML = finalWord;
          document.getElementById('ContentPlaceHolder1_hdnpayinword').value = finalWord;

      }

      function calctax(amtwit) {
          var initial = parseInt(amtwit.value);
          //alert(initial);
          var tax = parseFloat(document.getElementById("ContentPlaceHolder1_HiddenField2").value);
          var taxcal = parseFloat(initial / (tax + 100));
          //alert(taxcal);
          var taxcalh = parseFloat(taxcal * 100);
          //alert(taxcalh);
          //var totinitialtax=parseFloat(initial - taxcalh);
          var totinitialtax = parseFloat(taxcalh);
          //alert(totinitialtax);
          //totinitialtax=Math.round(totinitialtax)
          //alert(totinitialtax);
          totinitialtax = Math.round(totinitialtax, 0)
          //alert(totinitialtax);
          document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = totinitialtax;
          document.getElementById("ContentPlaceHolder1_hdnamt_tax").value = initial;
          test_skill(initial);
          document.getElementById("ContentPlaceHolder1_hdninitamt").value = amtwit.value;

      }
      //end
	

     
     
</script>
  <div id="parent">
    <ul>
      <li><a href="#tabs-6">Registration</a></li><li><a href="#tabs-5">Express Enrollment</a></li></ul>
    <div id="tabs-6">
      <div class="free-forms">
        <TABLE class="common" width=100% border="0" cellpadding="0" cellspacing="0">
          <TBODY>
            <TR>
              <TD colspan="2" style="padding:0px;"><H4>Registration</H4></TD>
            </TR>
              <tr>
                  <td class="formlabel">
                  </td>
                  <td>
                      <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
              </tr>
            <TR>
              <TD class="formlabel">Course Code <span style="color: red">*</span></TD>
              <TD><asp:DropDownList id="txt_coursepositioned" runat="server"  CssClass="select" AutoPostBack="True" OnSelectedIndexChanged="txt_coursepositioned_SelectedIndexChanged" > </asp:DropDownList></TD>
            </TR>
            <TR>
              <TD class="formlabel">Student Name <span style="color: red">*</span></TD>
              <TD><asp:TextBox id="txt_studname" runat="server" CssClass="text" TextMode="SingleLine" MaxLength="30"></asp:TextBox></TD>
            </TR>
             <TR>
              <TD class="formlabel">Contact No <span style="color: red">*</span></TD>
              <TD><asp:TextBox id="TextBox1" runat="server" CssClass="text" MaxLength="10" onkeypress="return CheckNumeric(event)" TextMode="SingleLine" ></asp:TextBox></TD>
            </TR>
         <tr>
            <td class="formlabel">
                Enquiry Source <span style="color: red">*</span></td>
            <td>
               <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select" onChange="chkvl9()">
          <asp:ListItem value="">--Select--</asp:ListItem>
      <asp:ListItem Value="image web/internet">image web/internet</asp:ListItem>
                                        <asp:ListItem Value="Google">Google</asp:ListItem>
                                         <asp:ListItem Value="Just Dial">Just Dial</asp:ListItem>
                                        <asp:ListItem Value="Sulekha">Sulekha</asp:ListItem>
                                         <asp:ListItem Value="ROPS(Reference of past Student)">ROPS(Reference of past Student)</asp:ListItem>
                                        <asp:ListItem Value="ROCS(Reference of Current Student)">ROCS(Reference of Current Student)</asp:ListItem>
                                        <asp:ListItem Value="ROS (Reference of Staff)">ROS (Reference of Staff)</asp:ListItem>
                                        <asp:ListItem Value="Reference of enquiry">Reference of enquiry</asp:ListItem>
                                        <asp:ListItem Value="WOM (Words of Mouth)">WOM(Words of Mouth)</asp:ListItem>
                                          <asp:ListItem value="Board">Sign Board</asp:ListItem>
                                        <asp:ListItem Value="Tv advertisement">Tv advertisement</asp:ListItem>
                                        <asp:ListItem Value="Print advertisement">Print advertisement</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
          
        
          </asp:DropDownList></td>
        </tr>
         <tr>
            <td class="formlabel">
                Enquiry Profile <span style="color: red">*</span></td>
            <td>
                <span class="file">
                                    <asp:DropDownList ID="ddl_profile0" runat="server" 
                    CssClass="select">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="School student">School student</asp:ListItem>
                                        <asp:ListItem Value="College student">College student</asp:ListItem>
                                        <asp:ListItem Value="Employed">Employed/Salaried</asp:ListItem>
                                        <asp:ListItem Value="SelfEmployed">Self-Employed</asp:ListItem>
                                        <asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
                                        <asp:ListItem Value="Housewife">Housewife</asp:ListItem>
                                        <asp:ListItem Value="SrCitizen">Sr.Citizen</asp:ListItem>
                                        <asp:ListItem Value="Multimedia Professional">Multimedia Professional</asp:ListItem>
                                        <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
        </tr>
              <tr>
                  <td class="formlabel">
                      Refered Name&nbsp; </td>
                  <td>
                      <asp:TextBox ID="txtreferstudent" runat="server" CssClass="text" ></asp:TextBox></td>
              </tr>
         <tr>
            <td class="formlabel">
                Payment Mode <span style="color: red">*</span></td>
            <td>
                <asp:DropDownList ID="ddl_paymode" runat="server" onChange="chkval()">
                <asp:ListItem Value="">--Select--</asp:ListItem>
                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                 <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                  <asp:ListItem Value="D.D">D.D</asp:ListItem>
                   <asp:ListItem Value="C.C">C.C</asp:ListItem>
                   
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel">
                Cheque / D.D No / C.C No</td>
            <td style="height: 37px">
                <asp:TextBox ID="txt_ddcc" onFocus="losefocus(this)" CssClass="text" MaxLength="20" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formlabel">
                cheque/D.D&nbsp; Date</td>
            <td style="height: 37px">
                <asp:TextBox ID="dddate" runat="server" CssClass="text datepicker" Width="123px" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formlabel">
                Bank Name</td>
            <td style="height: 37px">
                <asp:TextBox ID="txt_bankname" onFocus="losefocus(this)" runat="server" CssClass="text" MaxLength="30"></asp:TextBox></td>
        </tr>
            <TR>
              <TD  class="formlabel">Registration Amount 
                (With Tax)</TD>
              <TD><asp:TextBox id="txt_initialamt" onkeypress="return CheckNumeric(event)" onkeyup="calctax(this)" runat="server" CssClass="text" MaxLength="6" ReadOnly="False"></asp:TextBox></TD>
            </TR>
            <TR>
              <TD  class="formlabel">Registration Amount 
                (Without Tax)</TD>
              <TD><asp:Label id="lblamtwithtax" runat="server" Text=""></asp:Label>
              </TD>
            </TR>
            <TR>
              <TD  class="formlabel">Payment In Words</TD>
              <TD><asp:Label id="txt_paymentwords" runat="server" Text=""></asp:Label>
                <asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField>
                <SCRIPT type="text/javascript">
                    calctax(document.getElementById("ContentPlaceHolder1_txt_initialamt"));
                    function Reset1_onclick() {

                    }

                </SCRIPT>
              </TD>
            </TR>
            <TR>
              <TD  class="formlabel">Month Installment</TD>
              <TD><asp:DropDownList id="ddl_month" runat="server">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Jan">Jan</asp:ListItem>
                  <asp:ListItem Value="Feb">Feb</asp:ListItem>
                  <asp:ListItem Value="Mar">Mar</asp:ListItem>
                  <asp:ListItem Value="Apr">Apr</asp:ListItem>
                  <asp:ListItem Value="May">May</asp:ListItem>
                  <asp:ListItem Value="Jun">Jun</asp:ListItem>
                  <asp:ListItem Value="Jul">Jul</asp:ListItem>
                  <asp:ListItem Value="Aug">Aug</asp:ListItem>
                  <asp:ListItem Value="Sep">Sep</asp:ListItem>
                  <asp:ListItem Value="Oct">Oct</asp:ListItem>
                  <asp:ListItem Value="Nov">Nov</asp:ListItem>
                  <asp:ListItem Value="Dec">Dec</asp:ListItem>
                </asp:DropDownList></TD>
            </TR>
            <TR class="no-borders">
              <TD>&nbsp;</TD>
              <td align="left"><asp:HiddenField id="HiddenField2" runat="server" Value="0"></asp:HiddenField>
                <asp:Button id="Btnupdate" onclick="Btnupdate_Click" runat="server" Text="Make Receipt" CssClass="btnStyle1" OnClientClick="javascript:return add();"></asp:Button>
              </TD>
            </TR>
          </TBODY>
        </TABLE>
      </div>
      <div class="section">
        <div class="dataGrid">
          <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            Width="100%">
            <Columns>
            <asp:BoundField DataField="studentname" HeaderText="StudentName" />
            <asp:BoundField DataField="contactno" HeaderText="Contact No" />
            <asp:TemplateField HeaderText="ReceiptNumber">
              <ItemTemplate> <a rel="modal" href="Receiptprint.aspx?studid=<%#Eval("studentid")%>&recptno=<%#Eval("receiptno")%>&iframe=true&amp;width=1000&amp;height=700" class="error"> <%#Eval("receiptno")%> </a> </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Click To Enroll">
              <ItemTemplate> <a  href="<%#Eval("link")%> "> Enroll </a> </ItemTemplate>
            </asp:TemplateField>
            </Columns>
          </asp:GridView>
          <input id="hdnpayinword" runat="server" type="hidden" />
          <input id="hdnamt_tax" runat="server"
            type="hidden" />
          <input id="hdninitamt" runat="server" type="hidden" />
        </div>
      </div>
    </div>
      <div id="tabs-5">
      <div class="free-forms">
        <table width="100%" cellpadding="0" cellspacing="0"  id="TABLE1" language="javascript" onClick="return TABLE1_onclick()" >
          <tr>
            <td colspan="2" style=" padding:0px; height: 29px;"><h4> Express Enrollment</h4></td>
          </tr>
          <tr>
            <td></td>
            <td><asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
          </tr>
          <tr>
            <td class="formlabel">First Name <span style="color: red">*</span></td>
            <td><asp:TextBox ID="txtname" runat="server" CssClass="text" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="formlabel">Mobile <span style="color: red">*</span></td>
            <td><asp:TextBox ID="txtmobile" runat="server" CssClass="text" MaxLength="10" onkeypress="return CheckNumeric(event)"
                    onpaste="return false"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="formlabel">Source<span class="file"><span style="color: red">*</span></td>
            <td>
                <asp:DropDownList ID="ddl_aboutimage" runat="server" CssClass="select" >
                    <asp:ListItem value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="image web/internet">image web/internet</asp:ListItem>
                    <asp:ListItem Value="Google">Google</asp:ListItem>
                    <asp:ListItem Value="Just Dial">Just Dial</asp:ListItem>
                    <asp:ListItem Value="Sulekha">Sulekha</asp:ListItem>
                    <asp:ListItem Value="ROPS(Reference of past Student)">ROPS(Reference of past 
                    Student)</asp:ListItem>
                    <asp:ListItem Value="ROCS(Reference of Current Student)">ROCS(Reference of 
                    Current Student)</asp:ListItem>
                    <asp:ListItem Value="ROS (Reference of Staff)">ROS (Reference of Staff)</asp:ListItem>
                    <asp:ListItem Value="Reference of enquiry">Reference of enquiry</asp:ListItem>
                    <asp:ListItem Value="WOM(Words of Mouth)">WOM(Words of Mouth)</asp:ListItem>
                    <asp:ListItem value="Board">Sign Board</asp:ListItem>
                    <asp:ListItem Value="Tv advertisement">Tv advertisement</asp:ListItem>
                    <asp:ListItem Value="Print advertisement">Print advertisement</asp:ListItem>
                    <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                                            </td>
          </tr>
          <tr>
            <td class="formlabel">Profile<span class="file"><span style="color: red">*</span></td>
            <td>
                <asp:DropDownList ID="ddl_profile" runat="server" CssClass="select">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="School student">School student</asp:ListItem>
                    <asp:ListItem Value="College student">College student</asp:ListItem>
                    <asp:ListItem Value="Employed">Employed/Salaried</asp:ListItem>
                    <asp:ListItem Value="SelfEmployed">Self-Employed</asp:ListItem>
                    <asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
                    <asp:ListItem Value="Housewife">Housewife</asp:ListItem>
                    <asp:ListItem Value="SrCitizen">Sr.Citizen</asp:ListItem>
                    <asp:ListItem Value="Multimedia Professional">Multimedia Professional</asp:ListItem>
                    <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                </asp:DropDownList>
                                            </td>
          </tr>
            <tr>
                <td class="formlabel">
                    Refered Name</td>
                <td>
                    <asp:TextBox ID="txtenrollreferstudent" runat="server" CssClass="text"  MaxLength="50" ></asp:TextBox></td>
            </tr>
          <tr>
            <td class="formlabel">Course Positioned <span style="color: red">* </span> </td>
            <td><asp:DropDownList ID="txt_coursenamee" runat="server" CssClass="select" onchange="changepayment();"> </asp:DropDownList>
                <asp:HiddenField ID="hdncoursetype" runat="server" />
              </td>
          </tr>
          <tr>
            <td class="formlabel">Track <span style="color: #ff0000">*</span></td>
            <td><asp:DropDownList ID="ddtrack" runat="server" CssClass="select" onchange="setFees1();">
                <asp:ListItem Value="Fast">Fast</asp:ListItem>
                <asp:ListItem Value="Normal">Normal</asp:ListItem>
              </asp:DropDownList></td>
          </tr>
          <tr runat="server" id="paypattern">
            <td class="formlabel">Payment Pattern <span style="color: #ff0000">*</span></td>
            <td><asp:DropDownList ID="ddl_payment" runat="server" onchange="display(this.value);setFees1();">
                <asp:ListItem Value="">--select--</asp:ListItem>
                <asp:ListItem Value="Lump sum">Lump sum</asp:ListItem>
                <asp:ListItem Value="Installment">Installment</asp:ListItem>
              </asp:DropDownList>
              &nbsp;
              <asp:HiddenField ID="netamount" runat="server" />
            </td>
          </tr>
            <tr id="lump1">
              <td><strong> Course Fees</strong> : </td>
              <td><span id="txt_lumpamt" runat="server"></span>
                <asp:HiddenField ID="lbllumpamt" runat="server" />
              </td>
            </tr>
            <tr  id="lump3">
              <td> Initial Amount to be paid :</td>
              <td><asp:TextBox ID="txt_lumpinitial" runat="server" CssClass="text" MaxLength="7" onchange="install()" onkeypress="return CheckNumeric(event)" onkeyup="return taxcalc();"></asp:TextBox>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Include tax" OnClick="return taxcalc();" Width="84px" /></td>
            </tr>
            <tr id="lump2">
              <td> No. of Installments :</td>
              <td> 
              <asp:TextBox ID="txt_instalamt1" runat="server" CssClass="text" onKeyUp="return checkZero()"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" OnClientClick="return checkval();" Text="Calculation" CssClass="submit" /><br />
              Maximum  number of installments : 
                  <asp:Label ID="lblmaxinstallnumber" runat="server" Text="0" CssClass="error"></asp:Label>
              </td>
            </tr>
            <tr>
              <td> Course amount</td>
              <td><asp:TextBox ID="txt_netamount" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text" MaxLength="10"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td> ST at
                <asp:Label ID="lbl_tax" runat="server"></asp:Label>
                %</td>
              <td><asp:TextBox ID="txt_vat" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text" MaxLength="10"></asp:TextBox>
              </td>
            </tr>
            <tr id="lump4">
              <td> Amount To be paid per month</td>
              <td><asp:TextBox ID="txtamtmonthly" runat="server" CssClass="text" MaxLength="7" onkeypress="return CheckNumeric(event)" ReadOnly="True"></asp:TextBox></td>
            </tr>
          <tr>
            <td class="formlabel">Coursestart date<span style="color: #ff0000">*</span></td>
            <td><asp:TextBox ID="txt_coursedatedate" runat="server" CssClass="text datepicker"  
                     onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
          </tr>
          <tr id="insdate">
            <td class="formlabel"> Installment Date<span style="color: #ff0000">*</span></td>
            <td><asp:TextBox ID="txt_installdate" runat="server" CssClass="text datepicker"  
                    onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
          </tr>
          <tr>
            <td class="formlabel">Payment Mode <span style="color: #ff0000">*</span></td>
            <td><asp:DropDownList ID="ddlpaymentmode" runat="server" onchange="cashval()">
                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                <asp:ListItem Value="D.D">D.D</asp:ListItem>
                <asp:ListItem Value="Creditcard">Creditcard</asp:ListItem>
              </asp:DropDownList></td>
          </tr>
          <tr>
            <td class="formlabel">Cheque/D.D. No/C.C No</td>
            <td><asp:TextBox ID="txtchequeno" runat="server" CssClass="text" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="formlabel"> <span class="file">Cheque/D.D./C.C Date</td>
            <td><span class="file"><asp:TextBox ID="txtchequeno0" runat="server" 
                    CssClass="text datepicker" MaxLength="30"  onfocus="losefocuscash(this)" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
          </tr>
          <tr>
            <td class="formlabel"> Bank Name</td>
            <td><asp:TextBox ID="txtbankname" runat="server" CssClass="text" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox></td>
          </tr>
          <tr class="no-borders">
            <td></td>
            <td><asp:Button ID="btnsubmit5" runat="server" CssClass="btnStyle1" 
                    OnClientClick="javascript:return validate();" Text="Submit" OnClick="btnsubmit5_Click1"  />
              <asp:Button ID="Button1" runat="server" CssClass="btnStyle2" 
                    Text="Reset" /></td>
          </tr>
          <tr style="display:none">
            <td><asp:HiddenField ID="hdnlumpamt" runat="server" />
              <input id="hdnTab" name="hdnTab" type="hidden" value="Admission" />
              <input id="hdncou_id"
                    runat="server" name="hdncou_id" type="hidden" /></td>
            <td>
                <asp:HiddenField ID="hdncentrecode" runat="server" />
              </td>
          </tr>
        </table>
      </div>
    </div>
  </div>
</asp:Content>
