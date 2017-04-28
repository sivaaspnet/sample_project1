<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="QuickAdmission.aspx.cs" Inherits="QuickAdmission" Title="Express Enrollment" %>

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
          if (document.getElementById("<%=txt_instalamt1.ClientID%>").value == 0) {
              document.getElementById("<%=txt_instalamt1.ClientID%> ").value = "";
          }

      }
      function install() {
          if (document.getElementById("<%=txt_lumpinitial.ClientID%> ").value == document.getElementById("<%=lbllumpamt.ClientID%>").value) {
              document.getElementById("insdate").style.display = 'none';
          }
          else {
              document.getElementById("insdate").style.display = 'table-row';
          }
      }


      function validate() {

       

          var start = document.getElementById("<%=txt_coursedatedate.ClientID%>").value;
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

          var start1 = document.getElementById("<%=txt_installdate.ClientID%> ").value;
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
          if (document.getElementById("<%=txtname.ClientID%>").value == "") {
              document.getElementById("<%=txtname.ClientID%>").value == "";
              document.getElementById("<%=txtname.ClientID%>").focus();
              document.getElementById("<%=txtname.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txtname.ClientID%>").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=txtmobile.ClientID%> ").value == "") {
              document.getElementById("<%=txtmobile.ClientID%>").value == "";
              document.getElementById("<%=txtmobile.ClientID%>").focus();
              document.getElementById("<%=txtmobile.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txtmobile.ClientID%>").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (trim(document.getElementById("<%=txtemail.ClientID%>").value) == "") {

              document.getElementById("<%=txtemail.ClientID%>").value == "";
              document.getElementById("<%=txtemail.ClientID%>").focus();
              document.getElementById("<%=txtemail.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txtemail.ClientID%>").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (!Validate_Email(document.getElementById("<%=txtemail.ClientID%> ").value)) {
              alert("Please Enter the Valid Email-ID");
              document.getElementById("<%=txtemail.ClientID%>").focus();
              document.getElementById("<%=txtemail.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txtemail.ClientID%>").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_aboutimage.ClientID%> ").value == "") {
              document.getElementById("<%=ddl_aboutimage.ClientID%>").value == "";
              document.getElementById("<%=ddl_aboutimage.ClientID%>").focus();
              document.getElementById("<%=ddl_aboutimage.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_aboutimage.ClientID%>").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=ddl_profile.ClientID%>").value == "") {
              document.getElementById("<%=ddl_profile.ClientID%>").value == "";
              document.getElementById("<%=ddl_profile.ClientID%>").focus();
              document.getElementById("<%=ddl_profile.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_profile.ClientID%>").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=txt_coursenamee.ClientID%> ").value == "") {
              document.getElementById("<%=txt_coursenamee.ClientID%>").value == "";
              document.getElementById("<%=txt_coursenamee.ClientID%>").focus();
              document.getElementById("<%=txt_coursenamee.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_coursenamee.ClientID%>").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=ddtrack.ClientID%>").value == "") {
              document.getElementById("<%=ddtrack.ClientID%>").value == "";
              document.getElementById("<%=ddtrack.ClientID%>").focus();
              document.getElementById("<%=ddtrack.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddtrack.ClientID%>").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=ddl_payment.ClientID%> ").value == "") {
              document.getElementById("<%=ddl_payment.ClientID%> ").value == "";
              document.getElementById("<%=ddl_payment.ClientID%> ").focus();
              document.getElementById("<%=ddl_payment.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_payment.ClientID%> ").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=txt_coursedatedate.ClientID%> ").value == "") {
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").value == "";
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").focus();
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (csDate < 0) {
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").value == "";
              alert("Invalid start date");
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").focus();
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_coursedatedate.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=txt_installdate.ClientID%> ").value == "") {
              document.getElementById("<%=txt_installdate.ClientID%> ").value == "";
              document.getElementById("<%=txt_installdate.ClientID%> ").focus();
              document.getElementById("<%=txt_installdate.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_installdate.ClientID%> ").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (csDate1 < 0) {
              document.getElementById("<%=txt_installdate.ClientID%> ").value == "";
              alert("Invalid Installment date");
              document.getElementById("<%=txt_installdate.ClientID%> ").focus();
              document.getElementById("<%=txt_installdate.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_installdate.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddlpaymentmode.ClientID%> ").value == "") {
              document.getElementById("<%=ddlpaymentmode.ClientID%> ").value == "";
              document.getElementById("<%=ddlpaymentmode.ClientID%> ").focus();
              document.getElementById("<%=ddlpaymentmode.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddlpaymentmode.ClientID%> ").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (parseInt(document.getElementById("<%=txt_instalamt1.ClientID%> ").value) > parseInt(document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").innerHTML)) {
              alert(" Please enter less than or equal to (maximum number of installments)");
              document.getElementById("<%=txt_instalamt1.ClientID%> ").value == "";
              document.getElementById("<%=txt_instalamt1.ClientID%> ").focus();
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=ddlpaymentmode.ClientID%> ").value != "Cash") {
              if (document.getElementById("<%=txtchequeno.ClientID%> ").value == "") {
                  document.getElementById("<%=txtchequeno.ClientID%> ").value == "";
                  document.getElementById("<%=txtchequeno.ClientID%> ").focus();
                  document.getElementById("<%=txtchequeno.ClientID%> ").style.border = "#ff0000 1px solid";
                  document.getElementById("<%=txtchequeno.ClientID%> ").style.backgroundColor = "#e8ebd9"
                  return false;
              }
              else if (document.getElementById("<%=txtchequeno0.ClientID%> ").value == "") {
                  document.getElementById("<%=txtchequeno0.ClientID%> ").value == "";
                  document.getElementById("<%=txtchequeno0.ClientID%> ").focus();
                  document.getElementById("<%=txtchequeno0.ClientID%> ").style.border = "#ff0000 1px solid";
                  document.getElementById("<%=txtchequeno0.ClientID%> ").style.backgroundColor = "#e8ebd9"
                  return false;
              }
              else if (document.getElementById("<%=txtbankname.ClientID%> ").value == "") {
                  document.getElementById("<%=txtbankname.ClientID%> ").value == "";
                  document.getElementById("<%=txtbankname.ClientID%> ").focus();
                  document.getElementById("<%=txtbankname.ClientID%> ").style.border = "#ff0000 1px solid";
                  document.getElementById("<%=txtbankname.ClientID%> ").style.backgroundColor = "#e8ebd9"
                  return false;
              }
              else {
                  return true;
              }
          }
          else if (document.getElementById("<%=txt_lumpinitial.ClientID%> ").value == "") {
              alert("Please mention initial amount");
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=txt_lumpinitial.ClientID%> ").value == "0") {
              alert("Initial amount cannot be Zero");
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((document.getElementById("<%=ddl_payment.ClientID%> ").value == 'Installment') && (document.getElementById("<%=txt_instalamt1.ClientID%> ").value == "")) {
              alert("Please mention the no of installments");
              document.getElementById("<%=txt_instalamt1.ClientID%> ").focus();
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((parseInt(document.getElementById("<%=txt_lumpinitial.ClientID%> ").value)) > (parseInt(document.getElementById("<%=txt_lumpamt.ClientID%> ").innerHTML))) {
              alert("Initial amount is greater than the course fee");
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=hdncentrecode.ClientID%> ").value != '') {
              if (document.getElementById("<%=hdncoursetype.ClientID%> ").value == 'Certificate') {
                  if ((parseInt(document.getElementById("<%=txt_lumpinitial.ClientID%> ").value)) < 2500) {
                      alert("Enrollment amount is Less ,Use Registration link.");
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
                      location.href = window.location.href;
                      return false;
                  }
              }
              else if (document.getElementById("<%=hdncoursetype.ClientID%> ").value == 'Diploma') {
                  if ((parseInt(document.getElementById("<%=txt_lumpinitial.ClientID%> ").value)) < 5000) {
                      alert("Enrollment amount is Less ,Use Registration link.");
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
                      document.getElementById("<%=txt_lumpinitial.ClientID%>").style.backgroundColor = "#e8ebd9";
                      location.href = window.location.href;
                      return false;
                  }
              }
          }
          else  if (document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").value == "0") {
              document.getElementById("<%=txt_coursenamee.ClientID%> ").value == "";
              document.getElementById("<%=txt_coursenamee.ClientID%> ").focus();
              document.getElementById("<%=txt_coursenamee.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_coursenamee.ClientID%> ").style.backgroundColor = "#e8ebd9"
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
          if (document.getElementById("<%=txt_lumpinitial.ClientID%> ").value == "") {
              alert("Please mention initial amount");
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
              document.getElementById("<%=txt_lumpinitial.ClientID%>").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_lumpinitial.ClientID%>").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((document.getElementById("<%=ddl_payment.ClientID%> ").value == 'Installment') && (document.getElementById("<%=txt_instalamt1.ClientID%> ").value == "")) {
              alert("Please mention the no of installments");
              document.getElementById("<%=txt_instalamt1.ClientID%> ").focus();
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if ((parseInt(document.getElementById("<%=txt_netamount.ClientID%> ").value)) > (parseInt(document.getElementById("<%=txt_lumpamt.ClientID%> ").innerHTML))) {
              alert("Initial amount is greater than the course fee");
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (parseInt(document.getElementById("<%=txt_instalamt1.ClientID%> ").value) > parseInt(document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").innerHTML)) {
              alert(" Please enter less than or equal to (maximum number of installments)");
              document.getElementById("<%=txt_instalamt1.ClientID%> ").value == "";
              document.getElementById("<%=txt_instalamt1.ClientID%> ").focus();
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_instalamt1.ClientID%> ").style.backgroundColor = "#e8ebd9"
              return false;
          }
          else if (document.getElementById("<%=hdncentrecode.ClientID%> ").value != '') {
              if (document.getElementById("<%=hdncoursetype.ClientID%> ").value == 'Certificate') {
                  if ((parseInt(document.getElementById("<%=txt_lumpinitial.ClientID%> ").value)) < 2500) {
                      alert("Enrollment amount is Less ,Use Registration link.");
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
                      location.href = window.location.href;
                      return false;
                  }
                  else {
                      amt_ex_initial = parseInt((document.getElementById("<%=lbllumpamt.ClientID%> ").value) - (document.getElementById("<%=txt_netamount.ClientID%> ").value));
                      //alert(amt_ex_initial);
                      //double amt_ex_initial = Convert.ToDouble(lbllumpamt.Value) - Convert.ToDouble(txt_lumpinitial.Text);
                      noofinstallments = document.getElementById("<%=txt_instalamt1.ClientID%> ").value;
                      //alert(noofinstallments);
                      monthlyinstall = amt_ex_initial / noofinstallments;
                      //txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
                      //alert(monthlyinstall);
                      document.getElementById("<%=txtamtmonthly.ClientID%> ").value = Math.round(monthlyinstall, 0);
                      return false;
                  }
              }
              else if (document.getElementById("<%=hdncoursetype.ClientID%> ").value == 'Diploma') {
                  if ((parseInt(document.getElementById("<%=txt_lumpinitial.ClientID%> ").value)) < 5000) {
                      alert("Enrollment amount is Less ,Use Registration link.");
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").focus();
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.border = "#ff0000 1px solid";
                      document.getElementById("<%=txt_lumpinitial.ClientID%> ").style.backgroundColor = "#e8ebd9";
                      location.href = window.location.href;
                      return false;
                  }
                  else {
                      amt_ex_initial = parseInt((document.getElementById("<%=lbllumpamt.ClientID%> ").value) - (document.getElementById("<%=txt_netamount.ClientID%> ").value));
                      //alert(amt_ex_initial);
                      //double amt_ex_initial = Convert.ToDouble(lbllumpamt.Value) - Convert.ToDouble(txt_lumpinitial.Text);
                      noofinstallments = document.getElementById("<%=txt_instalamt1.ClientID%> ").value;
                      //alert(noofinstallments);
                      monthlyinstall = amt_ex_initial / noofinstallments;
                      //txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
                      //alert(monthlyinstall);
                      document.getElementById("<%=txtamtmonthly.ClientID%> ").value = Math.round(monthlyinstall, 0);
                      return false;
                  }
              }
          }
          else {
              //amt_ex_initial=parseInt(document.getElementById("<%=txt_instalamt1.ClientID%> lbllumpamt").value)-parseInt(document.getElementById("txt_lumpinitial").value);
              //alert(document.getElementById("<%=txt_instalamt1.ClientID%> lbllumpamt").value);
              //alert(document.getElementById("<%=txt_instalamt1.ClientID%> txt_lumpinitial").value);
              amt_ex_initial = parseInt((document.getElementById("<%=lbllumpamt.ClientID%> ").value) - (document.getElementById("<%=txt_netamount.ClientID%> ").value));
              //alert(amt_ex_initial);
              //double amt_ex_initial = Convert.ToDouble(lbllumpamt.Value) - Convert.ToDouble(txt_lumpinitial.Text);
              noofinstallments = document.getElementById("<%=txt_instalamt1.ClientID%> ").value;
              //alert(noofinstallments);
              monthlyinstall = amt_ex_initial / noofinstallments;
              //txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
              //alert(monthlyinstall);
              document.getElementById("<%=txtamtmonthly.ClientID%> ").value = Math.round(monthlyinstall, 0);
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
          if (document.getElementById("ddl_phydefect ").value != "Yes") {
              obj.value = "";
              obj.blur()
          }
      }


      function chkval1() {
          if (document.getElementById("ddl_phydefect ").value != "Yes") {
              document.getElementById("txt_defectYes ").value = ""
          }
      }


      function losefocuscash(obj) {
          if (document.getElementById("<%=ddlpaymentmode.ClientID%> ").value == 'Cash') {
              obj.value = "";
              obj.blur()
          }
      }

      function cashval() {
          if (document.getElementById("<%=ddlpaymentmode.ClientID%> ").value == 'Cash') {
              document.getElementById("<%=txtchequeno.ClientID%> ").value = ""
              document.getElementById("<%=txtbankname.ClientID%> ").value = ""
          }
      }

      function clearInstallDropDown() {
          var selectopt = document.getElementById("<%=txt_instalamt1.ClientID%> ");
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
                          document.getElementById("<%=txt_lumpamt.ClientID%> ").innerHTML = courseFeesfast[i]["lump_sum"];
                          document.getElementById("<%=lbllumpamt.ClientID%> ").value = courseFeesfast[i]["lump_sum"];
                          document.getElementById("<%=hdnlumpamt.ClientID%> ").value = courseFeesfast[i]["lump_sum"];
                          document.getElementById("<%=lbl_tax.ClientID%> ").innerHTML = courseFeesfast[i]["tax"];
                          document.getElementById("<%=HiddenField2.ClientID%> ").value = courseFeesfast[i]["tax"];
                          document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").innerHTML = courseFeesfast[i]["noofinstall"];
                      }
                      else if (feesType == "Installment") {
                          document.getElementById("<%=txt_lumpamt.ClientID%> ").innerHTML = courseFeesfast[i]["instal_amount"];
                          document.getElementById("<%=lbllumpamt.ClientID%> ").value = courseFeesfast[i]["instal_amount"];
                          document.getElementById("<%=hdnlumpamt.ClientID%> ").value = courseFeesfast[i]["instal_amount"];
                          document.getElementById("<%=lbl_tax.ClientID%> ").innerHTML = courseFeesfast[i]["tax"];
                          document.getElementById("<%=HiddenField2.ClientID%> ").value = courseFeesfast[i]["tax"];
                          document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").innerHTML = courseFeesfast[i]["noofinstall"];
                          if (inset == 0) {
                              createInstallmentNumbers(courseFeesfast[i]["noofinstall"]);
                              inset = 1;
                          }
                      }
                      else {
                          document.getElementById("<%=txt_lumpamt.ClientID%> ").InnerHtml = "0";
                          document.getElementById("<%=lbllumpamt.ClientID%> ").value = "0";
                      }
                  }
              }
          }
          else if (track == "normal") {
              var arraylength = courseFeesnormal.length;
              for (i = 0; i < arraylength; i++) {
                  if (parseInt(courseFeesnormal[i]["program"]) == parseInt(programId)) {
                      if (feesType == "Lump sum") {
                          document.getElementById("<%=txt_lumpamt.ClientID%> ").innerHTML = courseFeesnormal[i]["lump_sum"];
                          document.getElementById("<%=lbllumpamt.ClientID%> ").value = courseFeesnormal[i]["lump_sum"];
                          document.getElementById("<%=hdnlumpamt.ClientID%> ").value = courseFeesnormal[i]["lump_sum"];
                          document.getElementById("<%=lbl_tax.ClientID%> ").innerHTML = courseFeesnormal[i]["tax"];
                          document.getElementById("<%=HiddenField2.ClientID%> ").value = courseFeesnormal[i]["tax"];
                          document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").innerHTML = courseFeesnormal[i]["noofinstall"];
                      }
                      else if (feesType == "Installment") {
                          document.getElementById("<%=txt_lumpamt.ClientID%> ").innerHTML = courseFeesnormal[i]["instal_amount"];
                          document.getElementById("<%=lbllumpamt.ClientID%> ").value = courseFeesnormal[i]["instal_amount"];
                          document.getElementById("<%=hdnlumpamt.ClientID%> ").value = courseFeesnormal[i]["instal_amount"];
                          document.getElementById("<%=lbl_tax.ClientID%> ").innerHTML = courseFeesnormal[i]["tax"];
                          document.getElementById("<%=HiddenField2.ClientID%> ").value = courseFeesnormal[i]["tax"];
                          document.getElementById("<%=lblmaxinstallnumber.ClientID%> ").innerHTML = courseFeesnormal[i]["noofinstall"];
                          if (inset == 0) {
                              createInstallmentNumbers(courseFeesnormal[i]["noofinstall"]);
                              inset = 1;
                          }
                      }
                      else {
                          document.getElementById("<%=txt_lumpamt.ClientID%> ").InnerHtml = "0";
                          document.getElementById("<%=lbllumpamt.ClientID%> ").value = "0";
                      }
                  }
              }
          }
          return res;
      }

      function createInstallmentNumbers3(noofinstallmt) {
          clearInstallDropDown();
          var ddlInstall = document.getElementById("<%=txt_instalamt1.ClientID%> ");
          for (i = 1; i <= noofinstallmt; i++) {
              var optn = document.createElement("OPTION");
              optn.text = i;
              optn.value = i;
              ddlInstall.options.add(optn);
          }
      }

      function setFees1() {
          document.getElementById("<%=hdncou_id.ClientID%> ").value = document.getElementById("<%=txt_coursenamee.ClientID%> ").value;
          var programFees = setFees(document.getElementById("<%=txt_coursenamee.ClientID%> ").value, document.getElementById("<%=ddl_payment.ClientID%> ").value, document.getElementById("<%=ddtrack.ClientID%> ").value.toLowerCase());
      }

      function display() {
          if (document.getElementById("<%=ddl_payment.ClientID%> ").value == "Lump sum") {
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
              document.getElementById("<%=txt_installdate.ClientID%> ").value = today;
          }
          else if (document.getElementById("<%=ddl_payment.ClientID%> ").value == "Installment") {
              document.getElementById("<%=txt_installdate.ClientID%> ").value = "";
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
          document.getElementById("<%=ddl_payment.ClientID%> ").value = "";
          if (document.getElementById("<%=txt_coursenamee.ClientID%> ").value == "") {
              document.getElementById("<%=ddl_payment.ClientID%> ").style.display = '';
              document.getElementById("<%=Label1.ClientID%> ").style.display = 'none';
              document.getElementById("<%=ddl_payment.ClientID%> ").value = "";
              document.getElementById("<%=ddl_payment.ClientID%> ").focus();
              display();
          }
          else if (document.getElementById("<%=txt_coursenamee.ClientID%> ").value == "65") {
              document.getElementById("<%=ddl_payment.ClientID%> ").style.display = 'none';
              document.getElementById("<%=ddl_payment.ClientID%> ").value = "Lump sum";
              document.getElementById("<%=Label1.ClientID%> ").style.display = '';
              //document.getElementById("<%=txt_instalamt1.ClientID%> ddl_payment").focus();
              document.getElementById("lump1").style.display = 'block';
              document.getElementById("lump2").style.display = 'none';
              document.getElementById("lump3").style.display = 'block';
              document.getElementById("lump4").style.display = 'none';
              var programFees = setFees(document.getElementById("<%=txt_coursenamee.ClientID%> ").value, "Lump sum", document.getElementById("<%=ddtrack.ClientID%> ").value.toLowerCase());
          }
          else {
              document.getElementById("<%=ddl_payment.ClientID%> ").style.display = '';
              document.getElementById("lump1").style.display = 'none';
              document.getElementById("lump2").style.display = 'none';
              document.getElementById("lump3").style.display = 'none';
              document.getElementById("lump4").style.display = 'none';
              document.getElementById("<%=Label1.ClientID%> ").style.display = 'none';
              document.getElementById("<%=ddl_payment.ClientID%> ").value = "";
              document.getElementById("<%=ddl_payment.ClientID%> ").focus();
          }
          var i;
          for (i = 0; i < coursetrack.length; i++) {
              if (parseInt(coursetrack[i]["course_id"]) == document.getElementById("<%=txt_coursenamee.ClientID%> ").value) {
                  document.getElementById("<%=hdncoursetype.ClientID%> ").value = coursetrack[i]["coursetype"];
              }
          }
      }

      function addOption(text, value) {
          var txt = document.getElementById("<%=txt_coursenamee.ClientID%> ");
          var optn = document.createElement("OPTION");
          optn.text = text;
          optn.value = value;
          txt.options.add(optn);
      }


      function clearDropDownList() {
          var selectbox = document.getElementById("<%=txt_coursenamee.ClientID%> ");
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
          document.getElementById("<%=txtamtmonthly.ClientID%> ").value = "";
          var tax = parseFloat(document.getElementById("<%=lbl_tax.ClientID%> ").innerHTML);
          //var tax=10.3;
          if (document.getElementById("<%=CheckBox1.ClientID%> ").checked) {
              var intial_course_amt = (100 * (document.getElementById("<%=txt_lumpinitial.ClientID%> ").value)) / (100 + tax);
              document.getElementById("<%=txt_netamount.ClientID%> ").value = Math.round(intial_course_amt, 0);
              var vat_tax = intial_course_amt * (tax / 100);
              document.getElementById("<%=txt_vat.ClientID%> ").value = Math.round(vat_tax, 0);
              document.getElementById("<%=netamount.ClientID%> ").value = Math.round(intial_course_amt, 0) + Math.round(vat_tax, 0);
          }
          else {
              var intial_course_amt = (document.getElementById("<%=txt_lumpinitial.ClientID%> ").value);
              document.getElementById("<%=txt_netamount.ClientID%> ").value = Math.round(intial_course_amt, 0);
              var vat_tax = intial_course_amt * (tax / 100);
              document.getElementById("<%=txt_vat.ClientID%> ").value = Math.round(vat_tax, 0);
              document.getElementById("<%=netamount.ClientID%> ").value = Math.round(intial_course_amt, 0) + Math.round(vat_tax, 0);
          }
      }


      //quick receipt validation start




      function add() {

          if (trim(document.getElementById("<%=txt_coursepositioned.ClientID%> ").value) == "") {
              alert("Please select course");
              document.getElementById("<%=txt_coursepositioned.ClientID%> ").value = "";
              document.getElementById("<%=txt_coursepositioned.ClientID%> ").focus();
              document.getElementById("<%=txt_coursepositioned.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_coursepositioned.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("<%=txt_studname.ClientID%> ").value) == "") {
              alert("Please Enter Student Name");
              document.getElementById("<%=txt_studname.ClientID%> ").value = "";
              document.getElementById("<%=txt_studname.ClientID%> ").focus();
              document.getElementById("<%=txt_studname.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_studname.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("<%=TextBox1.ClientID%> ").value) == "") {
              alert("Please Enter Student Contact No");
              document.getElementById("<%=TextBox1.ClientID%> ").value = "";
              document.getElementById("<%=TextBox1.ClientID%> ").focus();
              document.getElementById("<%=TextBox1.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=TextBox1.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=DropDownList1.ClientID%> ").value == "") {
              alert("Please Select sourse");
              document.getElementById("<%=DropDownList1.ClientID%> ").value == "";
              document.getElementById("<%=DropDownList1.ClientID%> ").focus();
              document.getElementById("<%=DropDownList1.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=DropDownList1.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_profile0.ClientID%> ").value == "") {
              alert("Please Select profile");
              document.getElementById("<%=ddl_profile0.ClientID%> ").value == "";
              document.getElementById("<%=ddl_profile0.ClientID%> ").focus();
              document.getElementById("<%=ddl_profile0.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_profile0.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value == "") {
              alert("Please Select Payment mode");
              document.getElementById("<%=ddl_paymode.ClientID%> ").value == "";
              document.getElementById("<%=ddl_paymode.ClientID%> ").focus();
              document.getElementById("<%=ddl_paymode.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_paymode.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value != "Cash" && document.getElementById("<%=txt_ddcc.ClientID%> ").value == "") {
              alert("Please enter cheque number");
              document.getElementById("<%=txt_ddcc.ClientID%> ").value = "";
              document.getElementById("<%=txt_ddcc.ClientID%> ").focus();
              document.getElementById("<%=txt_ddcc.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_ddcc.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value != "Cash" && document.getElementById("<%=dddate.ClientID%> ").value == "") {
              alert("Please enter cheque Date");
              document.getElementById("<%=dddate.ClientID%> ").value = "";
              document.getElementById("<%=dddate.ClientID%> ").focus();
              document.getElementById("<%=dddate.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=dddate.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value != "Cash" && document.getElementById("<%=txt_bankname.ClientID%> ").value == "") {
              alert("Please enter Bank name");
              document.getElementById("<%=txt_bankname.ClientID%> ").value = "";
              document.getElementById("<%=txt_bankname.ClientID%> ").focus();
              document.getElementById("<%=txt_bankname.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_bankname.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("<%=txt_initialamt.ClientID%> ").value) == "") {
              alert("Please Enter Initial Amount");
              document.getElementById("<%=txt_initialamt.ClientID%> ").value = "";
              document.getElementById("<%=txt_initialamt.ClientID%> ").focus();
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("<%=txt_initialamt.ClientID%> ").value) == "0") {
              alert("Please Enter Initial Amount");
              document.getElementById("<%=txt_initialamt.ClientID%> ").value = "";
              document.getElementById("<%=txt_initialamt.ClientID%> ").focus();
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (trim(document.getElementById("<%=txt_initialamt.ClientID%> ").value) < 500) {
              alert("Please Enter Initial Amount above 500");
              document.getElementById("<%=txt_initialamt.ClientID%> ").value = "";
              document.getElementById("<%=txt_initialamt.ClientID%> ").focus();
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (isNaN(document.getElementById("<%=txt_initialamt.ClientID%> ").value)) {
              alert("Please Enter amount in numerics");
              document.getElementById("<%=txt_initialamt.ClientID%> ").value = "";
              document.getElementById("<%=txt_initialamt.ClientID%> ").focus();
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
else if (trim(document.getElementById("<%=txt_initialamt.ClientID%> ").value) > 5000) {
              alert("Registration Amount is greater than 5000, Please use enrollment link");
              document.getElementById("<%=txt_initialamt.ClientID%> ").value = "";
              document.getElementById("<%=txt_initialamt.ClientID%> ").focus();
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_initialamt.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }


          else if ((parseInt(document.getElementById("<%=txt_initialamt.ClientID%> ").value)) > (parseInt(document.getElementById("lblbalanceamount ").innerHTML))) {
              alert("Please Check Your Installment Amount is Greater Than Balance Amount");
              //             //document.getElementById("<%=txt_instalamt1.ClientID%> lblamtwithtax").innerHTML = "";
              //             document.getElementById("<%=txt_instalamt1.ClientID%> lblamtwithtax").focus();
              //             document.getElementById("<%=txt_instalamt1.ClientID%> lblamtwithtax").style.border="#ff0000 1px solid";
              //             document.getElementById("<%=txt_instalamt1.ClientID%> lblamtwithtax").style.backgroundColor="#e8ebd9";
              return false;
          }

          else if (document.getElementById("<%=ddl_month.ClientID%> ").value == "") {
              alert("Please select Month");
              document.getElementById("<%=ddl_month.ClientID%> ").value = "";
              document.getElementById("<%=ddl_month.ClientID%> ").focus();
              document.getElementById("<%=ddl_month.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_month.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value == "") {
              alert("Please Select Payment mode");
              document.getElementById("<%=ddl_paymode.ClientID%> ").value == "";
              document.getElementById("<%=ddl_paymode.ClientID%> ").focus();
              document.getElementById("<%=ddl_paymode.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=ddl_paymode.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value != "Cash" && document.getElementById("<%=txt_ddcc.ClientID%> ").value == "") {
              alert("Please enter cheque number");
              document.getElementById("<%=txt_ddcc.ClientID%> ").value = "";
              document.getElementById("<%=txt_ddcc.ClientID%>").focus();
              document.getElementById("<%=txt_ddcc.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_ddcc.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value != "Cash" && document.getElementById("<%=dddate.ClientID%> ").value == "") {
              alert("Please enter cheque number");
              document.getElementById("<%=txt_ddcc.ClientID%> ").value = "";
              document.getElementById("<%=txt_ddcc.ClientID%> ").focus();
              document.getElementById("<%=txt_ddcc.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_ddcc.ClientID%> ").style.backgroundColor = "#e8ebd9";
              return false;
          }
          else if (document.getElementById("<%=ddl_paymode.ClientID%> ").value != "Cash" && document.getElementById("<%=txt_bankname.ClientID%> ").value == "") {
              alert("Please enter Bank name");
              document.getElementById("<%=txt_bankname.ClientID%> ").value = "";
              document.getElementById("<%=txt_bankname.ClientID%> ").focus();
              document.getElementById("<%=txt_bankname.ClientID%> ").style.border = "#ff0000 1px solid";
              document.getElementById("<%=txt_bankname.ClientID%> ").style.backgroundColor = "#e8ebd9";
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
          document.getElementById('<%=txt_paymentwords.ClientID%> ').innerHTML = finalWord;
          document.getElementById('<%=hdnpayinword.ClientID%> ').value = finalWord;

      }

      function calctax(amtwit) {
          var initial = parseInt(amtwit.value);
          //alert(initial);
          var tax = parseFloat(document.getElementById("<%=HiddenField2.ClientID%> ").value);
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
          document.getElementById("<%=lblamtwithtax.ClientID%> ").innerHTML = totinitialtax;
          document.getElementById("<%=hdnamt_tax.ClientID%> ").value = initial;
          test_skill(initial);
          document.getElementById("<%=hdninitamt.ClientID%> ").value = amtwit.value;

      }
      //end
	

     
     
</script>
  <div class="title-cont">
    <h3 class="cont-title">Express Enrollment</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="QuickAdmission.aspx" class="last">Express Enrollment</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>
  <div id="parent">
    <ul>
      <li><a href="#tabs-6">Registration</a></li>
      <li><a href="#tabs-5">Express Enrollment</a></li>
    </ul>
    <div class="clear"></div>
    <div class="white-cont">
      <div id="tabs-6">
        <div class="free-forms">
          <h4 class="cont-title3">Registration</h4>
          <div class="form-cont">
            <ul>
              <li>
                <div align="center">
                  <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                </div>
              </li>
              <li>
                <label class="label-txt"><span style="color: red">*</span> Course Code</label>
                <asp:DropDownList id="txt_coursepositioned" runat="server"  CssClass="select sele-txt" AutoPostBack="True" OnSelectedIndexChanged="txt_coursepositioned_SelectedIndexChanged" > </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"><span style="color: red">*</span> Student Name</label>
                <asp:TextBox id="txt_studname" runat="server" CssClass="text input-txt" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"><span style="color: red">*</span> Contact No</label>
                <asp:TextBox id="TextBox1" runat="server" CssClass="text input-txt" MaxLength="10" onkeypress="return CheckNumeric(event)" TextMode="SingleLine" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"><span style="color: red">*</span> Enquiry Source</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select sele-txt" onChange="chkvl9()">
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
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"><span style="color: red">*</span>Enquiry Profile</label>
                <span class="file">
                <asp:DropDownList ID="ddl_profile0" runat="server" CssClass="select sele-txt">
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
                </span> </li>
              <li>
                <label class="label-txt">Refered Name</label>
                <asp:TextBox ID="txtreferstudent" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"><span style="color: red">*</span> Payment Mode</label>
                <asp:DropDownList ID="ddl_paymode" runat="server" onChange="chkval()" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Cash">Cash</asp:ListItem>
                  <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                  <asp:ListItem Value="D.D">D.D</asp:ListItem>
                  <asp:ListItem Value="C.C">C.C</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt">Cheque / D.D No / C.C No</label>
                <asp:TextBox ID="txt_ddcc" onFocus="losefocus(this)" CssClass="text input-txt" MaxLength="20" runat="server"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">cheque/D.D&nbsp; Date</label>
                <span class="date-pick-cont">
                <asp:TextBox ID="dddate" runat="server" CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                </span> </li>
              <li>
                <label class="label-txt">Bank Name</label>
                <asp:TextBox ID="txt_bankname" onFocus="losefocus(this)" runat="server" CssClass="text input-txt" MaxLength="30"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Registration Amount (With Tax)</label>
                <asp:TextBox id="txt_initialamt" onkeypress="return CheckNumeric(event)" onkeyup="calctax(this)" runat="server" CssClass="text input-txt" MaxLength="6" ReadOnly="False"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Registration Amount (Without Tax)</label>
                <asp:Label id="lblamtwithtax" runat="server" Text=""></asp:Label>
              </li>
              <li>
                <label class="label-txt">Payment In Words</label>
                <asp:Label id="txt_paymentwords" runat="server" Text=""></asp:Label>
                <asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField>
                <SCRIPT type="text/javascript">
                    calctax(document.getElementById("<%=txt_instalamt1.ClientID%> txt_initialamt"));
                    function Reset1_onclick() {

                    }
                </SCRIPT>
              </li>
              <li>
                <label class="label-txt">Month Installment</label>
                <asp:DropDownList id="ddl_month" runat="server" CssClass="sele-txt">
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
                </asp:DropDownList>
              </li>
              <li style="text-align:center;">
                <div align="center" style="padding-bottom:25px;">
                  <asp:HiddenField id="HiddenField2" runat="server" Value="0"></asp:HiddenField>
                  <asp:Button id="Btnupdate" onclick="Btnupdate_Click" runat="server" Text="Make Receipt" CssClass="btnStyle1" OnClientClick="javascript:return add();"></asp:Button>
                </div>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
        </div>
       
         <div style="padding:0px 10px 10px 10px">
            <asp:GridView ID="GridView1"  CssClass="tbl-cont3" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
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
               <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
            </asp:GridView>
            <input id="hdnpayinword" runat="server" type="hidden" />
            <input id="hdnamt_tax" runat="server" type="hidden" />
            <input id="hdninitamt" runat="server" type="hidden" /> 
          </div>
      
        <div style="display:none">
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
            <asp:BoundField DataField="studentname" HeaderText="StudentName" />
            <asp:BoundField DataField="contactno" HeaderText="Contact No" />
            <asp:BoundField DataField="receiptno" HeaderText="Receipt No" />
            </Columns>
          </asp:GridView>
          <div align="center" style="padding:0px 0px 15px 0px;">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="downloadlink_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
          </div>
        </div>
      </div>
      <div id="tabs-5">
        <div class="free-forms">
          <h4 class="cont-title3"> Express Enrollment</h4>
          <form  id="TABLE1" language="javascript" onClick="return TABLE1_onclick()" >
            <div class="form-cont">
              <ul>
                <li>
                  <div align="center">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                  </div>
                </li>
                <li>
                  <label class="label-txt"><span style="color: red">*</span> First Name</label>
                  <asp:TextBox ID="txtname" runat="server" CssClass="text input-txt" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt"><span style="color: red">*</span> Mobile</label>
                  <asp:TextBox ID="txtmobile" runat="server" CssClass="text input-txt" MaxLength="10" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt"><span style="color: red">*</span> E-mail</label>
                  <asp:TextBox ID="txtemail" runat="server" CssClass="text input-txt" ></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt"><span class="file"><span style="color: red">*</span></span> Source</label>
                  <asp:DropDownList ID="ddl_aboutimage" runat="server" CssClass="select sele-txt" >
                    <asp:ListItem value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="image web/internet">image web/internet</asp:ListItem>
                    <asp:ListItem Value="Google">Google</asp:ListItem>
                    <asp:ListItem Value="Just Dial">Just Dial</asp:ListItem>
                    <asp:ListItem Value="Sulekha">Sulekha</asp:ListItem>
                    <asp:ListItem Value="ROPS(Reference of past Student)">ROPS(Reference of past Student)</asp:ListItem>
                    <asp:ListItem Value="ROCS(Reference of Current Student)">ROCS(Reference of Current Student)</asp:ListItem>
                    <asp:ListItem Value="ROS (Reference of Staff)">ROS (Reference of Staff)</asp:ListItem>
                    <asp:ListItem Value="Reference of enquiry">Reference of enquiry</asp:ListItem>
                    <asp:ListItem Value="WOM(Words of Mouth)">WOM(Words of Mouth)</asp:ListItem>
                    <asp:ListItem value="Board">Sign Board</asp:ListItem>
                    <asp:ListItem Value="Tv advertisement">Tv advertisement</asp:ListItem>
                    <asp:ListItem Value="Print advertisement">Print advertisement</asp:ListItem>
                    <asp:ListItem Value="Others">Others</asp:ListItem>
                  </asp:DropDownList>
                </li>
                <li>
                  <label class="label-txt"><span class="file"><span style="color: red">*</span></span> Profile</label>
                  <asp:DropDownList ID="ddl_profile" runat="server" CssClass="select sele-txt">
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
                </li>
                <li>
                  <label class="label-txt">Refered Name</label>
                  <asp:TextBox ID="txtenrollreferstudent" runat="server" CssClass="text input-txt"  MaxLength="50" ></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt"><span style="color: red">* </span> Course Positioned</label>
                  <asp:DropDownList ID="txt_coursenamee" runat="server" CssClass="select sele-txt" onchange="changepayment();"> </asp:DropDownList>
                  <asp:HiddenField ID="hdncoursetype" runat="server" />
                </li>
                <li>
                  <label class="label-txt"><span style="color: #ff0000">*</span> Track</label>
                  <asp:DropDownList ID="ddtrack" runat="server" CssClass="select sele-txt" onchange="setFees1();">
                    <asp:ListItem Value="Fast">Fast</asp:ListItem>
                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
                  </asp:DropDownList>
                </li>
                <li runat="server" id="paypattern">
                  <label class="label-txt"><span style="color: #ff0000">*</span> Payment Pattern</label>
                  <asp:DropDownList ID="ddl_payment" runat="server" onchange="display(this.value);setFees1();" CssClass="sele-txt">
                    <asp:ListItem Value="">--select--</asp:ListItem>
                    <asp:ListItem Value="Lump sum">Lump sum</asp:ListItem>
                    <asp:ListItem Value="Installment">Installment</asp:ListItem>
                  </asp:DropDownList>
                  &nbsp;
                  <asp:HiddenField ID="netamount" runat="server" />
                </li>
                <li id="lump1">
                  <label class="label-txt"><strong> Course Fees</strong> : </label>
                  <span id="txt_lumpamt" runat="server"></span>
                  <asp:HiddenField ID="lbllumpamt" runat="server" />
                </li>
                <li id="lump3">
                  <label class="label-txt">Initial Amount to be paid :</label>
                  <asp:TextBox ID="txt_lumpinitial" runat="server" CssClass="text input-txt" MaxLength="7" onchange="install()" onkeypress="return CheckNumeric(event)" onkeyup="return taxcalc();"></asp:TextBox>
                  <asp:CheckBox ID="CheckBox1" runat="server" Text="Include tax" OnClick="return taxcalc();" />
                </li>
                <li id="lump2">
                  <label class="label-txt">No. of Installments :</label>
                  <asp:TextBox ID="txt_instalamt1" runat="server" CssClass="text input-txt" onKeyUp="return checkZero()"></asp:TextBox>
                  <asp:Button ID="Button3" runat="server" OnClientClick="return checkval();" Text="Calculation" CssClass="submit" />
                  <br />
                  <label class="label-txt">Maximum  number of installments :</label>
                  <asp:Label ID="lblmaxinstallnumber" runat="server" Text="0" CssClass="error"></asp:Label>
                </li>
                <li>
                  <label class="label-txt">Course amount</label>
                  <asp:TextBox ID="txt_netamount" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text input-txt" MaxLength="10"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">ST at
                  <asp:Label ID="lbl_tax" runat="server"></asp:Label>
                  %</label>
                  <asp:TextBox ID="txt_vat" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text input-txt" MaxLength="10"></asp:TextBox>
                </li>
                <li id="lump4">
                  <label class="label-txt">Amount To be paid per month</label>
                  <asp:TextBox ID="txtamtmonthly" runat="server" CssClass="text input-txt" MaxLength="7" onkeypress="return CheckNumeric(event)" ReadOnly="True"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt"><span style="color: #ff0000">*</span> Coursestart date</label>
                  <span class="date-pick-cont">
                  <asp:TextBox ID="txt_coursedatedate" runat="server" CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                  </span> </li>
                <li id="insdate">
                  <label class="label-txt"><span style="color: #ff0000">*</span> Installment Date</label>
                  <span class="date-pick-cont">
                  <asp:TextBox ID="txt_installdate" runat="server" CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                  </span> </li>
                <li>
                  <label class="label-txt"><span style="color: #ff0000">*</span> Payment Mode</label>
                  <asp:DropDownList ID="ddlpaymentmode" runat="server" onchange="cashval()" CssClass="sele-txt">
                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                    <asp:ListItem Value="D.D">D.D</asp:ListItem>
                    <asp:ListItem Value="Creditcard">Creditcard</asp:ListItem>
                  </asp:DropDownList>
                </li>
                <li>
                  <label class="label-txt">Cheque/D.D. No/C.C No</label>
                  <asp:TextBox ID="txtchequeno" runat="server" CssClass="text input-txt" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt"><span class="file">Cheque/D.D./C.C Date</span></label>
                  <span class="file"> <span class="date-pick-cont">
                  <asp:TextBox ID="txtchequeno0" runat="server" CssClass="text datepicker date-input-txt" MaxLength="30"  onfocus="losefocuscash(this)" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                  </span> </span> </li>
                <li>
                  <label class="label-txt">Bank Name</label>
                  <asp:TextBox ID="txtbankname" runat="server" CssClass="text input-txt" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
                </li>
                <li>
                  <div align="center" style="padding-bottom:25px;">
                    <asp:Button ID="btnsubmit5" runat="server" CssClass="btnStyle1" OnClientClick="javascript:return validate();" Text="Submit" OnClick="btnsubmit5_Click1"  />
                    <asp:Button ID="Button1" runat="server" CssClass="reset-btn" Text="Reset" />
                  </div>
                </li>
                <li style="display:none">
                  <asp:HiddenField ID="hdnlumpamt" runat="server" />
                  <input id="hdnTab" name="hdnTab" type="hidden" value="Admission" />
                  <input id="hdncou_id" runat="server" name="hdncou_id" type="hidden" />
                  <asp:HiddenField ID="hdncentrecode" runat="server" />
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
