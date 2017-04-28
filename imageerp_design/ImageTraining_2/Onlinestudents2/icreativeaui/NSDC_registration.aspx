<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/1imagemasterpage.master" AutoEventWireup="true" CodeFile="NSDC_registration.aspx.cs" Inherits="NSDC_registration" Title="NSDC REGISTRATION" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
  <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js" type="text/javascript"></script>
  <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" />
  
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
     <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js" type="text/javascript"></script>
  <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js" type="text/javascript"></script>

 
   <style type="text/css">
         body 
{
 background: rgb(247, 247, 247);
	
}
table {
	border-collapse:collapse;
	border-spacing:0;
	width: 100%;
	
}

h4{
	font-family: 'FranchiseRegular','Arial Narrow',Arial,sans-serif;
	color: rgb(6, 106, 117);
	padding: 2px 0 10px 0;
	font-weight: bold;
	
	padding-bottom: 30px;
}

fieldset
{
   border: 1px solid rgba(147, 184, 189,0.8);
	-webkit-box-shadow: 0pt 2px 5px rgba(105, 108, 109,  0.7),	0px 0px 8px 5px rgba(208, 223, 226, 0.4) inset;
	   -moz-box-shadow: 0pt 2px 5px rgba(105, 108, 109,  0.7),	0px 0px 8px 5px rgba(208, 223, 226, 0.4) inset;
	        box-shadow: 0pt 2px 5px rgba(105, 108, 109,  0.7),	0px 0px 8px 5px rgba(208, 223, 226, 0.4) inset;
	-webkit-box-shadow: 5px;
	-moz-border-radius: 5px;
		 border-radius: 5px;
		 padding:10px;
		 margin:10px;
		 padding-bottom: 30px;
		  padding-top: 30px;
}
legend
{
    font-size:larger;
    font-weight:bold;
    color:Black;
    font-family: 'FranchiseRegular','Arial Narrow',Arial,sans-serif;
	
}
.input-txt{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 150px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	color:#666666;
    margin-left: 0px;
    float:left;    
}
.input-txt:focus
{
    background-color: #FFFFCC;
}

.input-ddl{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 165px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	color:#666666;
    margin-left: 0px;
    float:left;
}
.input-ddl:focus
{
    background-color: #FFFFCC;
}
.input-ddl1{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 165px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	color:#666666;
    margin-left: 0px;
   
}
.input-ddl1:focus
{
    background-color: #FFFFCC;
}
.input-lbl
{
    font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	float:right;
	
}
.input-lbl1
{
    font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	float:left;
	
}
.input-lbl2
{
    font-family:Arial, Helvetica, sans-serif;
	font-size:16px;

	
}
.input-txt1{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 150px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	color:#666666;
    margin-left: 0px;
     
}
.input-txt1:focus
{
    background-color: #FFFFCC;
}



.submit-btn {
	height:30px;
	width:121px;
	background:#f6bb42;
	border-bottom:3px solid #c6901f;
	font-size:14px;
	color:#FFFFFF;
	font-weight:bold;
	text-transform:uppercase;
	font-family:Arial, Helvetica, sans-serif;
	cursor:pointer;
	float:right;
	margin-right:25px;
    border-left-style: none;
    border-left-color: inherit;
    border-left-width: 0px;
    border-right-style: none;
    border-right-color: inherit;
    border-right-width: 0px;
    border-top-style: none;
    border-top-color: inherit;
    border-top-width: 0px;
}
.excel-btn {
	height:30px;
	width:121px;
	background:#f6bb42;
	border-bottom:3px solid #c6901f;
	font-size:14px;
	color:#FFFFFF;
	font-weight:bold;
	text-transform:uppercase;
	font-family:Arial, Helvetica, sans-serif;
	cursor:pointer;
	float:right;
	margin-right:25px;
    border-left-style: none;
    border-left-color: inherit;
    border-left-width: 0px;
    border-right-style: none;
    border-right-color: inherit;
    border-right-width: 0px;
    border-top-style: none;
    border-top-color: inherit;
    border-top-width: 0px;
}
.list-btn
{
   
    height: 30px;
    text-transform: uppercase;
    font-family: Arial, Helvetica, sans-serif;
    cursor: pointer;
    
    width: 100px;
    background: #FFFFFF;
    color: #000000;
}
.required:after{
    content: "*";
    color: red; 
    float:right;
    width:10px;  
}​

​


.link-nsdc
{
    float:right;
}

.Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}
.Grid td {
      padding: 2px;
      border: solid 1px #c1c1c1; }
.Grid th
{
    background-position: #0000FF;
    padding: 4px 2px;
    color: #fff;
    background: #669999;
    border-left: solid 1px #525252;
    font-size: 1.3em;
}
.Grid .alt {
      background: #fcfcfc   }
.pagination-ys {
    /*display: inline-block;*/
    padding-left: 0;
    margin: 20px 0;
    border-radius: 4px;
}

.pagination-ys table > tbody > tr > td {
    display: inline;
}
.pagination-ys table > tbody > tr > td > a:hover,
.pagination-ys table > tbody > tr > td > span:hover,
.pagination-ys table > tbody > tr > td > a:focus,
.pagination-ys table > tbody > tr > td > span:focus {
    color: #97310e;
    background-color: #eeeeee;
    border-color: #dddddd;
}
            
        </style>
 
   
        
        
 
   <script type="text/javascript">
       $(document).ready(function() {




           district_fill($("#<%= ddl_tcstate.ClientID %> option:selected").text(), $("#<%= ddl_tcdistrict.ClientID %>"), $('#<%= hf_tcdistrict.ClientID %>'));
           district_fill($("#<%= ddl_emploc_state.ClientID %> option:selected").text(), $("#<%= ddl_emploc_district.ClientID %>"), $('#<%= hf_emploc_district.ClientID %>'));
           district_fill($("#<%= ddl_work_state.ClientID %> option:selected").text(), $("#<%= ddl_work_district.ClientID %>"), $('#<%= hf_work_district.ClientID %>'));

           datepicker();
           $("#<%= ddl_tcstate.ClientID %>").change(function() {
               district_fill($("#<%= ddl_tcstate.ClientID %> option:selected").text(), $("#<%= ddl_tcdistrict.ClientID %>"), $('#<%= hf_tcdistrict.ClientID %>'));
           });

           $("#<%= ddl_tcdistrict.ClientID %>").change(function() {
               $('#<%= hf_tcdistrict.ClientID %>').val($('#<%= ddl_tcdistrict.ClientID %> option:selected ').val());

           });

           $("#<%= ddl_emploc_state.ClientID %>").change(function() {
               district_fill($("#<%= ddl_emploc_state.ClientID %> option:selected").text(), $("#<%= ddl_emploc_district.ClientID %>"), $('#<%= hf_emploc_district.ClientID %>'));
           });

           $("#<%= ddl_emploc_district.ClientID %>").change(function() {
               $('#<%= hf_emploc_district.ClientID %>').val($('#<%= ddl_emploc_district.ClientID %> option:selected ').val());
           });

           $("#<%= ddl_work_state.ClientID %>").change(function() {
               district_fill($("#<%= ddl_work_state.ClientID %> option:selected").text(), $("#<%= ddl_work_district.ClientID %>"), $('#<%= hf_work_district.ClientID %>'));
           });

           $("#<%= ddl_work_district.ClientID %>").change(function() {
               $('#<%= hf_work_district.ClientID %>').val($('#<%= ddl_work_district.ClientID %> option:selected ').val());

           });
           $("#<%= ddl_salutation.ClientID %>").change(function() {
               //alert("salutation value" + $('#<%= ddl_salutation.ClientID %> option:selected ').text());
               var salutation = $('#<%= ddl_salutation.ClientID %> option:selected ').text();
               //alert("salutation" + salutation);
               if (salutation == "Mr.") {
                   $('#<%= ddl_gender.ClientID %>').val('M');
                   $('#<%= ddl_guardian.ClientID %>').val('1');
               }
               else if (salutation == "Ms.") {
                   $('#<%= ddl_gender.ClientID %>').val('F');
                   $('#<%= ddl_guardian.ClientID %>').val('2');

               }
               else if (salutation == "Mrs.") {
                   $('#<%= ddl_gender.ClientID %>').val('F');
                   $('#<%= ddl_guardian.ClientID %>').val('3');

               }
           });
           myFunction();
       });

       function check_alert() {
           alert("already registered candidate");
       }
       function district_fill(state, ddldistrict, hiddenfield) {

           var data = {};
           ddldistrict.empty();
           data.state = state;
           $.ajax({
               type: "POST",
               contentType: "application/json; charset=utf-8",
               url: "NSDC_registration.aspx/BindDatatoDropdown",
               data: "{data1:" + JSON.stringify(data) + "}",
               dataType: "json",
               success: function(data) {
                   ddldistrict.append($("<option></option>").val('').html("Select"));
                   $.each(data.d, function(key, value) {
                       ddldistrict.append($("<option></option>").val(value.district).html(value.district));
                   });
                   ddldistrict.val(hiddenfield.val());
               },

               error: function(result) {
                   //alert("Error in districtfill");
               }
           });

       }

       function today_date() {
           var today = new Date();
           var dd = today.getDate();
           var mm = today.getMonth() + 1; //January is 0!

           var yyyy = today.getFullYear();
           if (dd < 10) {
               dd = '0' + dd
           }
           if (mm < 10) {
               mm = '0' + mm
           }
           var today = mm + '/' + dd + '/' + yyyy;

           return today;

       }
       function day_difference(date1, date2) {
           var date_1 = date1.split('/');
           var date_2 = date2.split('/');
           var end = new Date(date_1[2], +date_1[0] - 1, date_1[1]);
           var start = new Date(date_2[2], +date_2[0] - 1, date_2[1]);
           var diff = (end.getTime() - start.getTime()) / (1000 * 60 * 60 * 24);

           return diff;
       }
       function calculate_age(dob) {
           var today = new Date();
           var nowyear = today.getFullYear();
           var nowmonth = today.getMonth();
           var nowday = today.getDate();
           var birth = new Date(dob);
           var birthyear = birth.getFullYear();
           var birthmonth = birth.getMonth();
           var birthday = birth.getDate();
           var age = nowyear - birthyear;
           var age_month = nowmonth - birthmonth;
           var age_day = nowday - birthday;

           if (age_month < 0 || (age_month == 0 && age_day < 0)) {
               age = parseInt(age) - 1;
           }

           return age;


       }
       function myFunction() {

           if (document.getElementById("<%=ddl_ttraining_status.ClientID %>").value == "1") {



               document.getElementById("<%=ddl_texp_year.ClientID %>").value = "";
               document.getElementById("<%=ddl_texp_month.ClientID %>").value = "";
               document.getElementById("<%=ddl_ttraining_status.ClientID %>").focus();
               document.getElementById("<%=ddl_texp_year.ClientID %>").disabled = true;
               document.getElementById("<%=ddl_texp_month.ClientID %>").disabled = true;
               return false;
           }

           else if (document.getElementById("<%=ddl_ttraining_status.ClientID %>").value != "1") {


               document.getElementById("<%=ddl_texp_year.ClientID %>").value = "";
               document.getElementById("<%=ddl_texp_month.ClientID %>").value = "";
               document.getElementById("<%=ddl_ttraining_status.ClientID %>").focus();
               document.getElementById("<%=ddl_texp_year.ClientID %>").disabled = false;
               document.getElementById("<%=ddl_texp_month.ClientID %>").disabled = false;

               return false;
           }
           else {
               return true;
           }
       }

       function datepicker() {

           var today = new Date();
           var nowyear = today.getFullYear();
           var nowmonth = today.getMonth();
           var nowday = today.getDate();
           jQuery("#<%=txt_dob.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {

               }
           });

           jQuery("#<%=txt_batch_start.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               minDate: new Date(nowyear, nowmonth, 1),
               onClose: function(dateText, inst) {
               }
           });

           jQuery("#<%=txt_batch_end.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {
                   placement();
               }
           }); jQuery("#<%=txt_passedout.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {
               }
           }); jQuery("#<%=txt_certfn_date.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {
               }
           }); jQuery("#<%=txt_assesmnt_date.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {
               }
           }); jQuery("#<%=txt_joindate.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {
               }
           }); jQuery("#<%=txt_pport_val.ClientID %>").datepicker({
               changeMonth: true,
               changeYear: true,
               yearRange: "-100:+100",
               dateFormat: "mm/dd/yy",
               onClose: function(dateText, inst) {
               }
           });


       }
       function placement() {
           //alert("placement");
           //alert("value  " + document.getElementById("<%=txt_batch_end.ClientID %>").value);
           var today = today_date();
           var difference = day_difference(today, document.getElementById("<%=txt_batch_end.ClientID %>").value);
           //alert("difference" + difference);
           if (difference < 1) {
               $('#<%=placement.ClientID %>').hide();
               //alert("works");
           }
           else
               $('#<%=placement.ClientID %>').show();

       }
       function numcheck(evt) {

           var charCode;
           if (window.event)
               charCode = window.event.keyCode;
           else
               charCode = evt.which;
           if (charCode >= 48 && charCode <= 57)
               return false;
           else if (charCode == 8)
               return false;
           return true;
       }

       function validation() {

           if ($('#<%=hf_id.ClientID %>').val() == "insert") {





               if (document.getElementById("<%=txt_enroll.ClientID %>").value == "") {
                   alert("Please enter Enrollment Number");
                   document.getElementById("<%=txt_enroll.ClientID %>").focus();
                   return false;
               } //registration details


               if (document.getElementById("<%=ddl_salutation.ClientID %>").value == "") {
                   alert("Please select Salutation");
                   document.getElementById("<%=ddl_salutation.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=txt_first_name.ClientID %>").value == "") {
                   alert("Please enter Candidate First name");
                   document.getElementById("<%=txt_first_name.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_first_name.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_first_name.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in candidate first name");
                       document.getElementById("<%=txt_first_name.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=txt_last_name.ClientID %>").value == "") {
                   alert("Please enter Candidate Last name");
                   document.getElementById("<%=txt_last_name.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_last_name.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_last_name.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in candidate last name");
                       document.getElementById("<%=txt_last_name.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddl_gender.ClientID %>").value == "") {
                   alert("Please Select Gender ");
                   document.getElementById("<%=ddl_gender.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=ddl_gender.ClientID %>").value != "") {
                   if (document.getElementById("<%=ddl_salutation.ClientID %>").value != "") {

                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "2" && document.getElementById("<%=ddl_salutation.ClientID %>").value != "2" && document.getElementById("<%=ddl_salutation.ClientID %>").value != "3") {
                           alert("Please select proper salutation");
                           document.getElementById("<%=ddl_salutation.ClientID %>").focus();
                           return false;
                       }
                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "1" && document.getElementById("<%=ddl_salutation.ClientID %>").value != "1") {
                           alert("Please select proper salutation");
                           document.getElementById("<%=ddl_salutation.ClientID %>").focus();
                           return false;
                       }
                   }

                   if (document.getElementById("<%=ddl_guardian.ClientID %>").value != "") {
                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "2" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "2" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "3" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "4") {
                           alert("Please select proper guardian type");
                           document.getElementById("<%=ddl_guardian.ClientID %>").focus();
                           return false;
                       }
                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "1" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "1" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "4") {
                           alert("Please select proper guardian type");
                           document.getElementById("<%=ddl_guardian.ClientID %>").focus();
                           return false;
                       }
                   }

               } //
               if (document.getElementById("<%=txt_dob.ClientID %>").value == "") {
                   alert("Please select Candidate Date of Birth");
                   document.getElementById("<%=txt_dob.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_dob.ClientID %>").value != "") {
                   var age = calculate_age(document.getElementById("<%=txt_dob.ClientID %>").value);
                   if (age < 14) {
                       alert("Candidate Age should not be less than 14 Years ");
                       document.getElementById("<%=txt_dob.ClientID %>").focus();
                       return false;
                   }
               }
               //
               if (document.getElementById("<%=txt_pob.ClientID %>").value == "") {
                   alert("Please Enter Candidate Place of Birth");
                   document.getElementById("<%=txt_pob.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddl_guardian.ClientID %>").value == "") {
                   alert("Please Select Guardian Type");
                   document.getElementById("<%=ddl_guardian.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=txt_fguardian.ClientID %>").value == "") {
                   alert("Please enter First name of Guardian");
                   document.getElementById("<%=txt_fguardian.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_fguardian.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_fguardian.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in First name of Guardian ");
                       document.getElementById("<%=txt_fguardian.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=txt_lguardian.ClientID %>").value == "") {
                   alert("Please enter Last name of Guardian");
                   document.getElementById("<%=txt_lguardian.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_lguardian.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_lguardian.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in Last name of Guardian ");
                       document.getElementById("<%=txt_lguardian.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=txt_mother.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_mother.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in Mother's name ");
                       document.getElementById("<%=txt_mother.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddlcaste.ClientID %>").value == "") {
                   alert("Please Select candidate caste");
                   document.getElementById("<%=ddlcaste.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddlreligion.ClientID %>").value == "") {
                   alert("Please Select candidate religion");
                   document.getElementById("<%=ddlreligion.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=txt_aadhar_no.ClientID %>").value != "") {
                   var pattern = /^([0-9]{4})+\ +([0-9]{4})+\ +([0-9]{4})$/;
                   if (!pattern.test(document.getElementById("<%=txt_aadhar_no.ClientID %>").value)) {
                       alert("Please enter Aadhar number in XXXX XXXX XXXX  format and it should be in numeric ");
                       document.getElementById("<%=txt_aadhar_no.ClientID %>").focus();
                       return false;
                   }
               } //personal details ends
               if (document.getElementById("<%=txt_taddress.ClientID %>").value == "") {
                   alert("Please Enter Trainee Address");
                   document.getElementById("<%=txt_taddress.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=ddl_tcstate.ClientID %>").value == "") {
                   alert("Select Tc state");
                   document.getElementById("<%=ddl_tcstate.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddl_tcdistrict.ClientID %>").value == "") {
                   alert("Select Tc District");
                   document.getElementById("<%=ddl_tcdistrict.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=txt_tpincode.ClientID %>").value == "") {
                   alert("Enter pincode in trainee details");
                   document.getElementById("<%=txt_tpincode.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_tpincode.ClientID %>").value != "") {
                   if (isNaN(document.getElementById("<%=txt_tpincode.ClientID %>").value) == true || document.getElementById("<%=txt_tpincode.ClientID %>").value.length != 6) {
                       alert("Enter valid pincode in trainee details");
                       document.getElementById("<%=txt_tpincode.ClientID %>").focus();
                       return false;
                   }

               } //

               if (document.getElementById("<%=txt_tmobileno.ClientID %>").value == "") {
                   alert("Enter trainee contact no");
                   document.getElementById("<%=txt_tmobileno.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_tmobileno.ClientID %>").value != "") {
                   if (isNaN(document.getElementById("<%=txt_tmobileno.ClientID %>").value) == true || document.getElementById("<%=txt_tmobileno.ClientID %>").value.length < 10 || document.getElementById("<%=txt_tmobileno.ClientID %>").value.length > 10) {
                       alert("Enter valid contact no of Trainee");
                       document.getElementById("<%=txt_tmobileno.ClientID %>").focus();
                       return false;
                   }
               } //

               if (document.getElementById("<%=txt_temail.ClientID %>").value != "") {
                   var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                   if (!filter.test(document.getElementById("<%=txt_temail.ClientID %>").value)) {
                       alert("Enter valid Email id of trainee");
                       document.getElementById("<%=txt_temail.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddl_teducation.ClientID %>").value == "") {
                   alert("Please select Education level  of Trainee");
                   document.getElementById("<%=ddl_teducation.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddl_tsector.ClientID %>").value == "") {
                   alert("Please select Sector Covered by Trainee");
                   document.getElementById("<%=ddl_tsector.ClientID %>").focus();
                   return false;
               } //trainee details ends


               if (document.getElementById("<%=txt_coursefee.ClientID %>").value == "") {
                   alert("Please enter Course fee");
                   document.getElementById("<%=txt_coursefee.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_coursefee.ClientID %>").value != "") {
                   var filter = /^\s*-?[1-9]\d*(\.\d{1,2})?\s*$/;
                   if (!filter.test(document.getElementById("<%=txt_coursefee.ClientID %>").value)) {
                       alert("Course fee should be in numeric");
                       document.getElementById("<%=txt_coursefee.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddl_trainerid.ClientID %>").value == "") {
                   alert("Please select TrainerID");
                   document.getElementById("<%=ddl_trainerid.ClientID %>").focus();
                   return false;
               }
               //
               if (document.getElementById("<%=ddl_feepaid.ClientID %>").value == "") {
                   alert("Select course fee paid by option");
                   document.getElementById("<%=ddl_feepaid.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=txt_batch_start.ClientID %>").value == "") {
                   alert("Please select Batch starting date ");
                   document.getElementById("<%=txt_batch_start.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_batch_start.ClientID %>").value != "") {
                   var today = today_date();
                   var difference = day_difference(today, document.getElementById("<%=txt_batch_start.ClientID %>").value);
                   //alert("difference" + difference);
                   if (difference > 30) {

                       alert("Invalid Batch Start Date");
                       document.getElementById("<%=txt_batch_start.ClientID %>").focus();
                       return false;
                   }


                   if (document.getElementById("<%=txt_batch_end.ClientID %>").value == "") {
                       alert("Please select Batch ending date ");
                       document.getElementById("<%=txt_batch_end.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_batch_end.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_batch_end.ClientID %>").value, document.getElementById("<%=txt_batch_start.ClientID %>").value);

                       if (difference < 30) {
                           alert("Invalid Batch end Date");
                           document.getElementById("<%=txt_batch_end.ClientID %>").focus();
                           return false;
                       }
                       if (document.getElementById("<%=txt_passedout.ClientID %>").value != "") {
                           var difference = day_difference(document.getElementById("<%=txt_passedout.ClientID %>").value, document.getElementById("<%=txt_batch_end.ClientID %>").value);

                           if (difference <= 0) {
                               alert("Invalid Passedout  Date");
                               document.getElementById("<%=txt_passedout.ClientID %>").focus();
                               return false;
                           }
                       } //passed out
                   } //batchend
               } //batch start
               if (document.getElementById("<%=ddl_train_status.ClientID %>").value == "") {
                   alert("Please Select training status");
                   document.getElementById("<%=ddl_train_status.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=ddl_train_status.ClientID %>").value != "") {
                   if (document.getElementById("<%=ddl_train_status.ClientID %>").value != "1" && document.getElementById("<%=ddl_train_status.ClientID %>").value != "2") {
                       alert("Please Select Proper training status");
                       document.getElementById("<%=ddl_train_status.ClientID %>").focus();
                       return false;
                   }
               } //

               if (document.getElementById("<%=ddl_data_year.ClientID %>").value == "") {
                   alert("Please Select  Data submit for year");
                   document.getElementById("<%=ddl_data_year.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=ddl_data_year.ClientID %>").value != "") {
                   var today = new Date();
                   var mm = today.getMonth(); //January is 0!
                   var yyyy = today.getFullYear();
                   var next_year = yyyy + 1;
                   var prev_year = yyyy - 1;
                   if (mm >= 3)// april
                       var data_year = yyyy + "-" + next_year;
                   else
                       var data_year = prev_year + "-" + yyyy;
                   if (document.getElementById("<%=ddl_data_year.ClientID %>").value != data_year) {
                       alert("Please select current financial year in the field of Data submitt ");
                       //alert(document.getElementById("<%=ddl_data_year.ClientID %>").value+"data_year" + data_year);
                       document.getElementById("<%=ddl_data_year.ClientID %>").focus();
                       return false;
                   }
               } //


               if (document.getElementById("<%=ddl_data_month.ClientID %>").value == "") {
                   alert("Please Select  Data submit for month");
                   document.getElementById("<%=ddl_data_month.ClientID %>").focus();
                   return false;
               }

               if (document.getElementById("<%=ddl_data_month.ClientID %>").value != "") {
                   var today = new Date();
                   var mm = today.getMonth(); //January is 0!
                   if (mm == 0)
                       var _mm = 11;
                   else
                       var _mm = mm - 1;
                   var yyyy = today.getFullYear();
                   if (document.getElementById("<%=ddl_data_month.ClientID %>").value != mm && document.getElementById("<%=ddl_data_month.ClientID %>").value != _mm) {
                       alert("Please select valid month in the field of Data submitt(month) ");
                       document.getElementById("<%=ddl_data_month.ClientID %>").focus();
                       return false;
                   }

               } //

               if (document.getElementById("<%=txt_attendance.ClientID %>").value != "") {
                   if (isNaN(document.getElementById("<%=txt_attendance.ClientID %>").value) == true) {
                       alert(" Please enter Attendance in numeric format");
                       document.getElementById("<%=txt_attendance.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_attendance.ClientID %>").value > 100) {
                       alert(" Attendance percentage should not be greater than 100");
                       document.getElementById("<%=txt_attendance.ClientID %>").focus();
                       return false;
                   }

               }  //
               //course details ends
               if ($('#<%=placement.ClientID %>').is(':visible')) {

                   if (document.getElementById("<%=txt_empcontact_name.ClientID %>").value != "") {
                       var pattern = /[^a-zA-Z.'\'']/;
                       if (pattern.test(document.getElementById("<%=txt_empcontact_name.ClientID %>").value)) {
                           alert("Numeric,special characters and  space are not allowed  in Employer Contact Person Name");
                           document.getElementById("<%=txt_empcontact_name.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_empcontact_no.ClientID %>").value != "") {
                       if (isNaN(document.getElementById("<%=txt_empcontact_no.ClientID %>").value) == true || document.getElementById("<%=txt_empcontact_no.ClientID %>").value.length < 10 || document.getElementById("<%=txt_empcontact_no.ClientID %>").value.length > 10) {
                           alert("Enter valid Employer Contact number");
                           document.getElementById("<%=txt_empcontact_no.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_earning_b4.ClientID %>").value != "") {
                       if (isNaN(document.getElementById("<%=txt_earning_b4.ClientID %>").value) == true) {
                           alert("Monthly earning/CTC should be in numeric.");
                           document.getElementById("<%=txt_earning_b4.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_earning_after.ClientID %>").value != "") {
                       if (isNaN(document.getElementById("<%=txt_earning_after.ClientID %>").value) == true) {
                           alert("Monthly Current CTC/Earning should be in numeric.");
                           document.getElementById("<%=txt_earning_after.ClientID %>").focus();
                           return false;
                       }
                   } //emp name, no,earning after,earning b4

               } //placement



               if (document.getElementById("<%=ddl_certified.ClientID %>").value != "" && document.getElementById("<%=ddl_certified.ClientID %>").value == "1") {

                   if (document.getElementById("<%=txt_certfn_date.ClientID %>").value == "") {
                       alert("Please select certification date ");
                       document.getElementById("<%=txt_certfn_date.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_certfn_date.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_certfn_date.ClientID %>").value, document.getElementById("<%=txt_passedout.ClientID %>").value);

                       if (difference <= 0) {
                           alert("Invalid Certification  Date");
                           document.getElementById("<%=txt_certfn_date.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_certfn_name.ClientID %>").value == "") {
                       alert("Please enter certification name  ");
                       document.getElementById("<%=txt_certfn_name.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_certfn_no.ClientID %>").value == "") {
                       alert("Please enter certificate number  ");
                       document.getElementById("<%=txt_certfn_no.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_assesmnt_date.ClientID %>").value == "") {
                       alert("Please select Assesment Date  ");
                       document.getElementById("<%=txt_assesmnt_date.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_assesmnt_date.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_assesmnt_date.ClientID %>").value, document.getElementById("<%=txt_batch_end.ClientID %>").value);

                       if (difference <= 0) {
                           alert("Invalid Assessment Date");
                           document.getElementById("<%=txt_assesmnt_date.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_agency.ClientID %>").value == "") {
                       alert("Please enter Agency name ");
                       document.getElementById("<%=txt_agency.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_Assessor.ClientID %>").value == "") {
                       alert("Please enter Assessor name ");
                       document.getElementById("<%=txt_Assessor.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_certfn_agency.ClientID %>").value == "") {
                       alert("Please enter Certifying Agency name ");
                       document.getElementById("<%=txt_certfn_agency.ClientID %>").focus();
                       return false;
                   }

               } //certified yes ends
               if ($('#<%=placement.ClientID %>').is(':visible')) {

                   if (document.getElementById("<%=ddl_place_status.ClientID %>").value != "" && document.getElementById("<%=ddl_place_status.ClientID %>").value == "1") {

                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "") {
                           alert("Please select Employment type ");
                           document.getElementById("<%=ddl_emplymnt_type.ClientID %>").focus();
                           return false;
                       }

                   } //placement yes
                   if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value != "") {
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "2" || document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "4") {
                           if (document.getElementById("<%=ddl_undertaking.ClientID %>").value == "") {
                               alert("Please select Undertaking for selfemployed collected from the trainee ");
                               document.getElementById("<%=ddl_undertaking.ClientID %>").focus();
                               return false;
                           }

                       } //employment 2,4 ;undertaking
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "3") {
                           if (document.getElementById("<%=ddl_upskill.ClientID %>").value == "") {
                               alert("Please select Proof of upskilling provided ");
                               document.getElementById("<%=ddl_upskill.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_proof.ClientID %>").value == "") {
                               alert("Please select Type of Proof  ");
                               document.getElementById("<%=ddl_proof.ClientID %>").focus();
                               return false;
                           }

                       } //employment 3 ;upskill , proof
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "1" || document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "3") {
                           if (document.getElementById("<%=txt_empname.ClientID %>").value == "") {
                               alert("Please enter Employer Name/Self Employed ");
                               document.getElementById("<%=txt_empname.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=txt_empcontact_name.ClientID %>").value == "") {
                               alert("Please enter Employer Contact Person Name ");
                               document.getElementById("<%=txt_empcontact_name.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=txt_empcontact_name.ClientID %>").value != "") {
                               var pattern = /[^a-zA-Z.'\'']/;
                               if (pattern.test(document.getElementById("<%=txt_empcontact_name.ClientID %>").value)) {
                                   alert("Numeric,special characters and  space are not allowed  in Employer Contact Person Name");
                                   document.getElementById("<%=txt_empcontact_name.ClientID %>").focus();
                                   return false;
                               }
                           }
                           if (document.getElementById("<%=txt_empcontact_desgtn.ClientID %>").value == "") {
                               alert("Please enter Employer Contact Person Designation ");
                               document.getElementById("<%=txt_empcontact_desgtn.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=txt_empcontact_no.ClientID %>").value == "") {
                               alert("Please enter Employer Contact Number ");
                               document.getElementById("<%=txt_empcontact_no.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=txt_empcontact_no.ClientID %>").value != "") {
                               if (isNaN(document.getElementById("<%=txt_empcontact_no.ClientID %>").value) == true || document.getElementById("<%=txt_empcontact_no.ClientID %>").value.length < 10 || document.getElementById("<%=txt_empcontact_no.ClientID %>").value.length > 10) {
                                   alert("Enter valid Employer Contact number");
                                   document.getElementById("<%=txt_empcontact_no.ClientID %>").focus();
                                   return false;
                               }
                           }
                           if (document.getElementById("<%=ddl_emploc_state.ClientID %>").value == "") {
                               alert("Please select Employer State ");
                               document.getElementById("<%=ddl_emploc_state.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_emploc_district.ClientID %>").value == "") {
                               alert("Please select Employer District ");
                               document.getElementById("<%=ddl_emploc_district.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_work_state.ClientID %>").value == "") {
                               alert("Please select State of Placement / work ");
                               document.getElementById("<%=ddl_work_state.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_work_district.ClientID %>").value == "") {
                               alert("Please select district of Placement / work  ");
                               document.getElementById("<%=ddl_work_district.ClientID %>").focus();
                               return false;
                           }

                       } //employment 1,3 ;employer details
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "1") {
                           if (document.getElementById("<%=ddl_feedback.ClientID %>").value == "") {
                               alert("Please enter Feedback collected from employer ");
                               document.getElementById("<%=ddl_feedback.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=ddl_feedback.ClientID %>").value != "" && document.getElementById("<%=ddl_feedback.ClientID %>").value != "3") {
                               if (document.getElementById("<%=ddl_freq_feedback.ClientID %>").value == "") {
                                   alert("Please enter Feedback Frequency ");
                                   document.getElementById("<%=ddl_freq_feedback.ClientID %>").focus();
                                   return false;
                               }
                           }

                       } //employment 1 ;feedback,freq feed 
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value != "2" || document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value != "4") {
                           if (document.getElementById("<%=txt_earning_b4.ClientID %>").value == "") {
                               alert("Please enter Monthly Earning/CTC before Training");
                               document.getElementById("<%=txt_earning_b4.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=txt_earning_b4.ClientID %>").value != "") {
                               if (isNaN(document.getElementById("<%=txt_earning_b4.ClientID %>").value) == true) {
                                   alert("Monthly earning/CTC should be in numeric.");
                                   document.getElementById("<%=txt_earning_b4.ClientID %>").focus();
                                   return false;
                               }
                           }
                           if (document.getElementById("<%=txt_earning_after.ClientID %>").value == "") {
                               alert("Please enter Monthly Current CTC/Earning ");
                               document.getElementById("<%=txt_earning_after.ClientID %>").focus();
                               return false;
                           }

                           else if (document.getElementById("<%=txt_earning_after.ClientID %>").value != "") {
                               if (isNaN(document.getElementById("<%=txt_earning_after.ClientID %>").value) == true) {
                                   alert("Monthly Current CTC/Earning should be in numeric.");
                                   document.getElementById("<%=txt_earning_after.ClientID %>").focus();
                                   return false;
                               }
                           }

                       } //employment not 2,4 ;earning after,before
                   } //employment not null
                   if (document.getElementById("<%=txt_passport.ClientID %>").value != "" && document.getElementById("<%=txt_pport_val.ClientID %>").value == "") {
                       alert("Please enter Passport validity Date");
                       document.getElementById("<%=txt_pport_val.ClientID %>").focus();
                       return false;
                   } //
                   if (document.getElementById("<%=ddl_feepaid.ClientID %>").value == "4" && document.getElementById("<%=ddl_fund_source.ClientID %>").value == "") {
                       alert("Please select source of funding");
                       document.getElementById("<%=ddl_fund_source.ClientID %>").focus();
                       return false;

                   } //
                   if (document.getElementById("<%=ddl_skills.ClientID %>").value == "") {
                       alert("Please Select Skilling Category");
                       document.getElementById("<%=ddl_skills.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=ddl_skills.ClientID %>").value != "") {
                       if (document.getElementById('<%=ddl_skills.ClientID %>').options[document.getElementById('<%=ddl_skills.ClientID %>').selectedIndex].text != "Corporate Paid - Up skilled") {
                           if (document.getElementById("<%=ddl_ttraining_status.ClientID %>").value == "") {
                               alert("Select Pre-training status of Trainee");
                               document.getElementById("<%=ddl_ttraining_status.ClientID %>").focus();
                               return false;
                           }


                       }
                       if (document.getElementById('<%=ddl_skills.ClientID %>').options[document.getElementById('<%=ddl_skills.ClientID %>').selectedIndex].text != "School") {
                           if (document.getElementById("<%=ddl_place_status.ClientID %>").value == "") {
                               alert("Please Select Placement Status");
                               document.getElementById("<%=ddl_place_status.ClientID %>").focus();
                               return false;
                           }

                       }
                   } //skilling category
               } //placement visible


           }


           else if ($('#<%=hf_id.ClientID %>').val() == "edit") {


               if (document.getElementById("<%=txt_enroll.ClientID %>").value == "") {
                   alert("Please enter Enrollment Number");
                   document.getElementById("<%=txt_enroll.ClientID %>").focus();
                   return false;
               } //registration details

               if (document.getElementById("<%=ddl_salutation.ClientID %>").value == "") {
                   alert("Please select Salutation");
                   document.getElementById("<%=ddl_salutation.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=txt_first_name.ClientID %>").value == "") {
                   alert("Please enter Candidate First name");
                   document.getElementById("<%=txt_first_name.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_first_name.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_first_name.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in candidate first name");
                       document.getElementById("<%=txt_first_name.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=txt_last_name.ClientID %>").value == "") {
                   alert("Please enter Candidate Last name");
                   document.getElementById("<%=txt_last_name.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_last_name.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_last_name.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in candidate last name");
                       document.getElementById("<%=txt_last_name.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddl_gender.ClientID %>").value == "") {
                   alert("Please Select Gender ");
                   document.getElementById("<%=ddl_gender.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=ddl_gender.ClientID %>").value != "") {
                   if (document.getElementById("<%=ddl_salutation.ClientID %>").value != "") {

                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "2" && document.getElementById("<%=ddl_salutation.ClientID %>").value != "2" && document.getElementById("<%=ddl_salutation.ClientID %>").value != "3") {
                           alert("Please select proper salutation");
                           document.getElementById("<%=ddl_salutation.ClientID %>").focus();
                           return false;
                       }
                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "1" && document.getElementById("<%=ddl_salutation.ClientID %>").value != "1") {
                           alert("Please select proper salutation");
                           document.getElementById("<%=ddl_salutation.ClientID %>").focus();
                           return false;
                       }
                   }

                   if (document.getElementById("<%=ddl_guardian.ClientID %>").value != "") {
                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "2" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "2" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "3" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "4") {
                           alert("Please select proper guardian type");
                           document.getElementById("<%=ddl_guardian.ClientID %>").focus();
                           return false;
                       }
                       if (document.getElementById("<%=ddl_gender.ClientID %>").value == "1" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "1" && document.getElementById("<%=ddl_guardian.ClientID %>").value != "4") {
                           alert("Please select proper guardian type");
                           document.getElementById("<%=ddl_guardian.ClientID %>").focus();
                           return false;
                       }
                   }

               } //
               if (document.getElementById("<%=txt_dob.ClientID %>").value == "") {
                   alert("Please select Candidate Date of Birth");
                   document.getElementById("<%=txt_dob.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_dob.ClientID %>").value != "") {
                   var age = calculate_age(document.getElementById("<%=txt_dob.ClientID %>").value);
                   if (age < 14) {
                       alert("Candidate Age should not be less than 14 Years ");
                       document.getElementById("<%=txt_dob.ClientID %>").focus();
                       return false;
                   }
               }
               //
               if (document.getElementById("<%=txt_pob.ClientID %>").value == "") {
                   alert("Please Enter Candidate Place of Birth");
                   document.getElementById("<%=txt_pob.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddl_guardian.ClientID %>").value == "") {
                   alert("Please Select Guardian Type");
                   document.getElementById("<%=ddl_guardian.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=txt_fguardian.ClientID %>").value == "") {
                   alert("Please enter First name of Guardian");
                   document.getElementById("<%=txt_fguardian.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_fguardian.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_fguardian.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in First name of Guardian ");
                       document.getElementById("<%=txt_fguardian.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=txt_lguardian.ClientID %>").value == "") {
                   alert("Please enter Last name of Guardian");
                   document.getElementById("<%=txt_lguardian.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_lguardian.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_lguardian.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in Last name of Guardian ");
                       document.getElementById("<%=txt_lguardian.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=txt_mother.ClientID %>").value != "") {
                   var pattern = /[^a-zA-Z.'\'']/;
                   if (pattern.test(document.getElementById("<%=txt_mother.ClientID %>").value)) {
                       alert("Numeric,special characters and  space are not allowed  in Mother's name ");
                       document.getElementById("<%=txt_mother.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddlcaste.ClientID %>").value == "") {
                   alert("Please Select candidate caste");
                   document.getElementById("<%=ddlcaste.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddlreligion.ClientID %>").value == "") {
                   alert("Please Select candidate religion");
                   document.getElementById("<%=ddlreligion.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=txt_aadhar_no.ClientID %>").value != "") {
                   var pattern = /^([0-9]{4})+\ +([0-9]{4})+\ +([0-9]{4})$/;
                   if (!pattern.test(document.getElementById("<%=txt_aadhar_no.ClientID %>").value)) {
                       alert("Please enter Aadhar number in XXXX XXXX XXXX  format and it should be in numeric");
                       document.getElementById("<%=txt_aadhar_no.ClientID %>").focus();
                       return false;
                   }
               } //personal details ends
               if (document.getElementById("<%=txt_taddress.ClientID %>").value == "") {
                   alert("Please Enter Trainee Address");
                   document.getElementById("<%=txt_taddress.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=ddl_tcstate.ClientID %>").value == "") {
                   alert("Select Tc state");
                   document.getElementById("<%=ddl_tcstate.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddl_tcdistrict.ClientID %>").value == "") {
                   alert("Select Tc District");
                   document.getElementById("<%=ddl_tcdistrict.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=txt_tpincode.ClientID %>").value == "") {
                   alert("Enter your pincode");
                   document.getElementById("<%=txt_tpincode.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_tpincode.ClientID %>").value != "") {
                   if (isNaN(document.getElementById("<%=txt_tpincode.ClientID %>").value) == true || document.getElementById("<%=txt_tpincode.ClientID %>").value.length != 6) {
                       alert("Enter valid pincode");
                       document.getElementById("<%=txt_tpincode.ClientID %>").focus();
                       return false;
                   }

               } //

               if (document.getElementById("<%=txt_tmobileno.ClientID %>").value == "") {
                   alert("Enter trainee contact no");
                   document.getElementById("<%=txt_tmobileno.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_tmobileno.ClientID %>").value != "") {
                   if (isNaN(document.getElementById("<%=txt_tmobileno.ClientID %>").value) == true || document.getElementById("<%=txt_tmobileno.ClientID %>").value.length < 10 || document.getElementById("<%=txt_tmobileno.ClientID %>").value.length > 10) {
                       alert("Enter valid contact no of Trainee");
                       document.getElementById("<%=txt_tmobileno.ClientID %>").focus();
                       return false;
                   }
               } //

               if (document.getElementById("<%=txt_temail.ClientID %>").value != "") {
                   var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                   if (!filter.test(document.getElementById("<%=txt_temail.ClientID %>").value)) {
                       alert("Enter valid Email id of trainee");
                       document.getElementById("<%=txt_temail.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddl_teducation.ClientID %>").value == "") {
                   alert("Please select Education level  of Trainee");
                   document.getElementById("<%=ddl_teducation.ClientID %>").focus();
                   return false;
               } //
               if (document.getElementById("<%=ddl_tsector.ClientID %>").value == "") {
                   alert("Please select Sector Covered by Trainee");
                   document.getElementById("<%=ddl_tsector.ClientID %>").focus();
                   return false;
               } //trainee details ends


               if (document.getElementById("<%=txt_coursefee.ClientID %>").value == "") {
                   alert("Please enter Course fee");
                   document.getElementById("<%=txt_coursefee.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_coursefee.ClientID %>").value != "") {
                   var filter = /^\s*-?[1-9]\d*(\.\d{1,2})?\s*$/;
                   if (!filter.test(document.getElementById("<%=txt_coursefee.ClientID %>").value)) {
                       alert("Course fee should be in numeric");
                       document.getElementById("<%=txt_coursefee.ClientID %>").focus();
                       return false;
                   }
               } //
               if (document.getElementById("<%=ddl_trainerid.ClientID %>").value == "") {
                   alert("Please Select TrainerID");
                   document.getElementById("<%=ddl_trainerid.ClientID %>").focus();
                   return false;
               }
               //
               if (document.getElementById("<%=ddl_feepaid.ClientID %>").value == "") {
                   alert("Select course fee paid by option");
                   document.getElementById("<%=ddl_feepaid.ClientID %>").focus();
                   return false;
               } //

               if (document.getElementById("<%=txt_batch_start.ClientID %>").value == "") {
                   alert("Please select Batch starting date ");
                   document.getElementById("<%=txt_batch_start.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=txt_batch_start.ClientID %>").value != "") {
                   var today = today_date();
                   var difference = day_difference(today, document.getElementById("<%=txt_batch_start.ClientID %>").value);

                   if (difference > 30) {
                       alert("Invalid Batch Start Date");
                       document.getElementById("<%=txt_batch_start.ClientID %>").focus();
                       return false;
                   }


                   if (document.getElementById("<%=txt_batch_end.ClientID %>").value == "") {
                       alert("Please select Batch ending date ");
                       document.getElementById("<%=txt_batch_end.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_batch_end.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_batch_end.ClientID %>").value, document.getElementById("<%=txt_batch_start.ClientID %>").value);

                       if (difference < 30) {
                           alert("Invalid Batch end Date");
                           document.getElementById("<%=txt_batch_end.ClientID %>").focus();
                           return false;
                       }

                   } //batchend
               } //batch start
               if (document.getElementById("<%=ddl_train_status.ClientID %>").value == "") {
                   alert("Please Select training status");
                   document.getElementById("<%=ddl_train_status.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=ddl_train_status.ClientID %>").value != "") {
                   if (document.getElementById("<%=ddl_train_status.ClientID %>").value != "3" && document.getElementById("<%=ddl_train_status.ClientID %>").value != "4") {
                       alert("Please Select Proper training status");
                       document.getElementById("<%=ddl_train_status.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=ddl_train_status.ClientID %>").value == "3" && document.getElementById("<%=txt_passedout.ClientID %>").value == "") {
                       alert("Please Select Passed out date");
                       document.getElementById("<%=txt_passedout.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_passedout.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_passedout.ClientID %>").value, document.getElementById("<%=txt_batch_end.ClientID %>").value);

                       if (difference <= 0) {
                           alert("Invalid Passedout  Date");
                           document.getElementById("<%=txt_passedout.ClientID %>").focus();
                           return false;
                       }
                   } //passed out

               } //train status

               if (document.getElementById("<%=ddl_data_year.ClientID %>").value == "") {
                   alert("Please Select Data submitted for the year of");
                   document.getElementById("<%=ddl_data_year.ClientID %>").focus();
                   return false;
               }
               else if (document.getElementById("<%=ddl_data_year.ClientID %>").value != "") {
                   var today = new Date();
                   var mm = today.getMonth(); //January is 0!
                   var yyyy = today.getFullYear();
                   var next_year = yyyy + 1;
                   var prev_year = yyyy - 1;
                   if (mm >= 3)// april
                       var data_year = yyyy + "-" + next_year;
                   else
                       var data_year = prev_year + "-" + yyyy;
                   if (document.getElementById("<%=ddl_data_year.ClientID %>").value != data_year) {
                       alert("Please select current financial year in the field of Data submitt ");
                       //alert(document.getElementById("<%=ddl_data_year.ClientID %>").value+"data_year" + data_year);
                       document.getElementById("<%=ddl_data_year.ClientID %>").focus();
                       return false;
                   }
               } //

               if (document.getElementById("<%=ddl_data_month.ClientID %>").value == "") {
                   alert("Please Enter Data submitted for the month of");
                   document.getElementById("<%=ddl_data_month.ClientID %>").focus();
                   return false;
               }

               else if (document.getElementById("<%=ddl_data_month.ClientID %>").value != "") {
                   var today = new Date();
                   var mm = today.getMonth(); //January is 0!
                   if (mm == 0)
                       var _mm = 11;
                   else
                       var _mm = mm - 1;
                   var yyyy = today.getFullYear();
                   if (document.getElementById("<%=ddl_data_month.ClientID %>").value != mm && document.getElementById("<%=ddl_data_month.ClientID %>").value != _mm) {
                       alert("Please select valid month in the field of Data submitt ");
                       document.getElementById("<%=ddl_data_month.ClientID %>").focus();
                       return false;
                   }

               } //
               if (document.getElementById("<%=txt_attendance.ClientID %>").value == "") {
                   alert("Please Enter Attendance");
                   document.getElementById("<%=txt_attendance.ClientID %>").focus();
                   return false;
               }

               else if (document.getElementById("<%=txt_attendance.ClientID %>").value != "") {
                   if (isNaN(document.getElementById("<%=txt_attendance.ClientID %>").value) == true) {
                       alert(" Please enter Attendance in numeric format");
                       document.getElementById("<%=txt_attendance.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_attendance.ClientID %>").value > 100) {
                       alert(" Attendance percentage should not be greater than 100");
                       document.getElementById("<%=txt_attendance.ClientID %>").focus();
                       return false;
                   }

               } //
               //course details ends
               if ($('#<%=placement.ClientID %>').is(':visible')) {

                   if (document.getElementById("<%=txt_empcontact_name.ClientID %>").value != "") {
                       var pattern = /[^a-zA-Z.'\'']/;
                       if (pattern.test(document.getElementById("<%=txt_empcontact_name.ClientID %>").value)) {
                           alert("Numeric,special characters and  space are not allowed  in Employer Contact Person Name");
                           document.getElementById("<%=txt_empcontact_name.ClientID %>").focus();
                           return false;
                       }
                   }

                   if (document.getElementById("<%=txt_empcontact_no.ClientID %>").value != "") {
                       if (isNaN(document.getElementById("<%=txt_empcontact_no.ClientID %>").value) == true || document.getElementById("<%=txt_empcontact_no.ClientID %>").value.length != 10) {
                           alert("Enter valid Employer Contact number");
                           document.getElementById("<%=txt_empcontact_no.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_earning_b4.ClientID %>").value != "") {
                       if (isNaN(document.getElementById("<%=txt_earning_b4.ClientID %>").value) == true) {
                           alert("Monthly earning/CTC should be in numeric.");
                           document.getElementById("<%=txt_earning_b4.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_earning_after.ClientID %>").value != "") {
                       if (isNaN(document.getElementById("<%=txt_earning_after.ClientID %>").value) == true) {
                           alert("Monthly Current CTC/Earning should be in numeric.");
                           document.getElementById("<%=txt_earning_after.ClientID %>").focus();
                           return false;
                       }
                   } //emp no,earning after,earning b4

               } //placement



               if (document.getElementById("<%=ddl_certified.ClientID %>").value != "" && document.getElementById("<%=ddl_certified.ClientID %>").value == "1") {

                   if (document.getElementById("<%=txt_certfn_date.ClientID %>").value == "") {
                       alert("Please select certification date ");
                       document.getElementById("<%=txt_certfn_date.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_certfn_date.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_certfn_date.ClientID %>").value, document.getElementById("<%=txt_passedout.ClientID %>").value);

                       if (difference <= 0) {
                           alert("Invalid Certification  Date");
                           document.getElementById("<%=txt_certfn_date.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_certfn_name.ClientID %>").value == "") {
                       alert("Please enter certification name  ");
                       document.getElementById("<%=txt_certfn_name.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_certfn_no.ClientID %>").value == "") {
                       alert("Please enter certificate number  ");
                       document.getElementById("<%=txt_certfn_no.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_assesmnt_date.ClientID %>").value == "") {
                       alert("Please select Assesment Date  ");
                       document.getElementById("<%=txt_assesmnt_date.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=txt_assesmnt_date.ClientID %>").value != "") {
                       var difference = day_difference(document.getElementById("<%=txt_assesmnt_date.ClientID %>").value, document.getElementById("<%=txt_batch_end.ClientID %>").value);

                       if (difference <= 0) {
                           alert("Invalid Assessment Date");
                           document.getElementById("<%=txt_assesmnt_date.ClientID %>").focus();
                           return false;
                       }
                   }
                   if (document.getElementById("<%=txt_agency.ClientID %>").value == "") {
                       alert("Please enter Agency name ");
                       document.getElementById("<%=txt_agency.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_Assessor.ClientID %>").value == "") {
                       alert("Please enter Assessor name ");
                       document.getElementById("<%=txt_Assessor.ClientID %>").focus();
                       return false;
                   }
                   if (document.getElementById("<%=txt_certfn_agency.ClientID %>").value == "") {
                       alert("Please enter Certifying Agency name ");
                       document.getElementById("<%=txt_certfn_agency.ClientID %>").focus();
                       return false;
                   }

               } //certified yes ends
               if ($('#<%=placement.ClientID %>').is(':visible')) {

                   if (document.getElementById("<%=ddl_place_status.ClientID %>").value != "" && document.getElementById("<%=ddl_place_status.ClientID %>").value == "1") {

                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "") {
                           alert("Please select Employment type ");
                           document.getElementById("<%=ddl_emplymnt_type.ClientID %>").focus();
                           return false;
                       }

                   } //placement yes
                   if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value != "") {
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "2" || document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "4") {
                           if (document.getElementById("<%=ddl_undertaking.ClientID %>").value == "") {
                               alert("Please select Undertaking for selfemployed collected from the trainee ");
                               document.getElementById("<%=ddl_undertaking.ClientID %>").focus();
                               return false;
                           }

                       } //employment 2,4 ;undertaking
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "3") {
                           if (document.getElementById("<%=ddl_upskill.ClientID %>").value == "") {
                               alert("Please select Proof of upskilling provided ");
                               document.getElementById("<%=ddl_upskill.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_proof.ClientID %>").value == "") {
                               alert("Please select Type of Proof  ");
                               document.getElementById("<%=ddl_proof.ClientID %>").focus();
                               return false;
                           }

                       } //employment 3 ;upskill , proof
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "1" || document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "3") {
                           if (document.getElementById("<%=txt_empname.ClientID %>").value == "") {
                               alert("Please enter Employer Name/Self Employed ");
                               document.getElementById("<%=txt_empname.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=txt_empcontact_name.ClientID %>").value == "") {
                               alert("Please enter Employer Contact Person Name ");
                               document.getElementById("<%=txt_empcontact_name.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=txt_empcontact_name.ClientID %>").value != "") {
                               var pattern = /[^a-zA-Z,.]/;
                               if (pattern.test(document.getElementById("<%=txt_empcontact_name.ClientID %>").value)) {
                                   alert("Numeric,special characters and  space are not allowed  in Employer Contact Person Name");
                                   document.getElementById("<%=txt_empcontact_name.ClientID %>").focus();
                                   return false;
                               }
                           }
                           if (document.getElementById("<%=txt_empcontact_desgtn.ClientID %>").value == "") {
                               alert("Please enter Employer Contact Person Designation ");
                               document.getElementById("<%=txt_empcontact_desgtn.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=txt_empcontact_no.ClientID %>").value == "") {
                               alert("Please enter Employer Contact Number ");
                               document.getElementById("<%=txt_empcontact_no.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=txt_empcontact_no.ClientID %>").value != "") {
                               if (isNaN(document.getElementById("<%=txt_empcontact_no.ClientID %>").value) == true || document.getElementById("<%=txt_empcontact_no.ClientID %>").value.length != 10) {
                                   alert("Enter valid Employer Contact number");
                                   document.getElementById("<%=txt_empcontact_no.ClientID %>").focus();
                                   return false;
                               }
                           }
                           if (document.getElementById("<%=ddl_emploc_state.ClientID %>").value == "") {
                               alert("Please select Employer State ");
                               document.getElementById("<%=ddl_emploc_state.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_emploc_district.ClientID %>").value == "") {
                               alert("Please select Employer District ");
                               document.getElementById("<%=ddl_emploc_district.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_work_state.ClientID %>").value == "") {
                               alert("Please select State of Placement / work ");
                               document.getElementById("<%=ddl_work_state.ClientID %>").focus();
                               return false;
                           }
                           if (document.getElementById("<%=ddl_work_district.ClientID %>").value == "") {
                               alert("Please select district of Placement / work  ");
                               document.getElementById("<%=ddl_work_district.ClientID %>").focus();
                               return false;
                           }

                       } //employment 1,3 ;employer details
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value == "1") {
                           if (document.getElementById("<%=ddl_feedback.ClientID %>").value == "") {
                               alert("Please enter Feedback collected from employer ");
                               document.getElementById("<%=ddl_feedback.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=ddl_feedback.ClientID %>").value != "" && document.getElementById("<%=ddl_feedback.ClientID %>").value != "3") {
                               if (document.getElementById("<%=ddl_freq_feedback.ClientID %>").value == "") {
                                   alert("Please enter Feedback Frequency ");
                                   document.getElementById("<%=ddl_freq_feedback.ClientID %>").focus();
                                   return false;
                               }
                           }

                       } //employment 1 ;feedback,freq feed 
                       if (document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value != "2" || document.getElementById("<%=ddl_emplymnt_type.ClientID %>").value != "4") {
                           if (document.getElementById("<%=txt_earning_b4.ClientID %>").value == "") {
                               alert("Please enter Monthly Earning/CTC before Training");
                               document.getElementById("<%=txt_earning_b4.ClientID %>").focus();
                               return false;
                           }
                           else if (document.getElementById("<%=txt_earning_b4.ClientID %>").value != "") {
                               if (isNaN(document.getElementById("<%=txt_earning_b4.ClientID %>").value) == true) {
                                   alert("Monthly earning/CTC should be in numeric.");
                                   document.getElementById("<%=txt_earning_b4.ClientID %>").focus();
                                   return false;
                               }
                           }
                           if (document.getElementById("<%=txt_earning_after.ClientID %>").value == "") {
                               alert("Please enter Monthly Current CTC/Earning ");
                               document.getElementById("<%=txt_earning_after.ClientID %>").focus();
                               return false;
                           }

                           else if (document.getElementById("<%=txt_earning_after.ClientID %>").value != "") {
                               if (isNaN(document.getElementById("<%=txt_earning_after.ClientID %>").value) == true) {
                                   alert("Monthly Current CTC/Earning should be in numeric.");
                                   document.getElementById("<%=txt_earning_after.ClientID %>").focus();
                                   return false;
                               }
                           }

                       } //employment not 2,4 ;earning after,before
                   } //employment yes
                   if (document.getElementById("<%=txt_passport.ClientID %>").value != "" && document.getElementById("<%=txt_pport_val.ClientID %>").value == "") {
                       alert("Please enter Passport validity Date");
                       document.getElementById("<%=txt_pport_val.ClientID %>").focus();
                       return false;
                   } //
                   if (document.getElementById("<%=ddl_feepaid.ClientID %>").value == "4" && document.getElementById("<%=ddl_fund_source.ClientID %>").value == "") {
                       alert("Please select source of funding");
                       document.getElementById("<%=ddl_fund_source.ClientID %>").focus();
                       return false;

                   } //
                   if (document.getElementById("<%=ddl_skills.ClientID %>").value == "") {
                       alert("Please Select Skilling Category");
                       document.getElementById("<%=ddl_skills.ClientID %>").focus();
                       return false;
                   }
                   else if (document.getElementById("<%=ddl_skills.ClientID %>").value != "") {
                       if (document.getElementById('<%=ddl_skills.ClientID %>').options[document.getElementById('<%=ddl_skills.ClientID %>').selectedIndex].text != "Corporate Paid - Up skilled") {
                           if (document.getElementById("<%=ddl_ttraining_status.ClientID %>").value == "") {
                               alert("Select Pre-training status of Trainee");
                               document.getElementById("<%=ddl_ttraining_status.ClientID %>").focus();
                               return false;
                           }

                       }
                       if (document.getElementById('<%=ddl_skills.ClientID %>').options[document.getElementById('<%=ddl_skills.ClientID %>').selectedIndex].text != "School") {
                           if (document.getElementById("<%=ddl_place_status.ClientID %>").value == "") {
                               alert("Please Select Placement Status");
                               document.getElementById("<%=ddl_place_status.ClientID %>").focus();
                               return false;
                           }

                       }
                   } //skilling category
               } //placement

           }
           hf_datefill();

           return true;

       }

       function null_alert() {
           alert("Please fillout mandatory fields");

       }
       function hf_datefill() {
           $('#<%= hf_dob.ClientID %>').val($('#<%= txt_dob.ClientID %>').val());
           $('#<%= hf_bstart.ClientID %>').val($('#<%= txt_batch_start.ClientID %>').val());
           $('#<%= hf_bend.ClientID %>').val($('#<%= txt_batch_end.ClientID %>').val());
           $('#<%= hf_passed.ClientID %>').val($('#<%= txt_passedout.ClientID %>').val());
           $('#<%= hf_assesment.ClientID %>').val($('#<%= txt_assesmnt_date.ClientID %>').val());
           $('#<%= hf_pvalidity.ClientID %>').val($('#<%= txt_pport_val.ClientID %>').val());
           $('#<%= hf_certification.ClientID %>').val($('#<%= txt_certfn_date.ClientID %>').val());
           $('#<%= hf_joindate.ClientID %>').val($('#<%= txt_joindate.ClientID %>').val());

       }
         
   </script>
            
       
       
         <h4>
            
        NSDC REGISTRATION FORM</h4>
        <fieldset id="reg_info"  >
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <legend >Registration Details:</legend>
        <table >
            <tr>
               
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Enrollment Number:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_enroll" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                
            </tr>
        </table>
        </fieldset>
        <br /><br />
        <fieldset id="personal_info">
        <legend>Personal Information:
        </legend>
        <table >
            <tr>
                <td >
                 <span class="required"></span><asp:Label ID="Label6" runat="server" Text="Salutation:" class="input-lbl"></asp:Label>
                </td>
                <td >
                <asp:DropDownList ID="ddl_salutation" runat="server" class="input-ddl" 
                       >
                    <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">Mr.</asp:ListItem>
                    <asp:ListItem Value="2">Ms.</asp:ListItem>
                    <asp:ListItem Value="3">Mrs.</asp:ListItem>                    
                    </asp:DropDownList>
                </td>
                <td>
                    <span class="required"></span><asp:Label ID="Label7" runat="server" Text="First Name Candidate:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_first_name" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                <td>
                    <span class="required"></span><asp:Label ID="Label8" runat="server" Text="Last Name Candidate:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_last_name" runat="server" class="input-txt"></asp:TextBox>
                    </td>
            </tr>
            <tr>
            <td >
                 <span class="required"></span>   <asp:Label ID="Label13" runat="server" Text="Gender:" class="input-lbl"></asp:Label>
                </td>
                <td >
                <asp:DropDownList ID="ddl_gender" runat="server" class="input-ddl">
                    <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="T">Transgender</asp:ListItem>                    
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                                  
                    </asp:DropDownList>    
                </td>
                 <td>
                   <span class="required"></span> <asp:Label ID="Label10" runat="server" Text="Date of Birth:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_dob" runat="server" class="input-txt "  onkeypress="return numcheck(event)"></asp:TextBox>
                    </td>
                 <td >
                      <span class="required"></span><asp:Label ID="Label21" runat="server" Text="Place of Birth:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_pob" runat="server" class="input-txt"></asp:TextBox>
                   </td>
            </tr>
            <tr>
            <td >
                    <span class="required"></span>  <asp:Label ID="Label9" runat="server" Text="Guardian Type:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:DropDownList ID="ddl_guardian" runat="server" class="input-ddl"> 
                    <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">S/O</asp:ListItem>
                    <asp:ListItem Value="2">D/O</asp:ListItem>
                     <asp:ListItem Value="3">W/O</asp:ListItem>
                    <asp:ListItem Value="4">C/O</asp:ListItem></asp:DropDownList>
                      </td>
                <td >
                 <span class="required"></span>  <asp:Label ID="Label11" runat="server" Text=" Guardian's First Name :" class="input-lbl"></asp:Label>
                    
                </td>
                <td >
                <asp:TextBox ID="txt_fguardian" runat="server" class="input-txt"></asp:TextBox>
                </td>
                <td>
                    <span class="required"></span><asp:Label ID="Label12" runat="server" 
                        Text="Guardian's last Name:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_lguardian" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                
               
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label14" runat="server" Text="Mother’s Maiden Name:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_mother" runat="server" class="input-txt"></asp:TextBox>
                   </td>
                <td>
                   <span class="required"></span>  <asp:Label ID="Label15" runat="server" Text="Caste:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                <asp:DropDownList ID="ddlcaste" runat="server" class="input-ddl">
                <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">Gen</asp:ListItem>
                    <asp:ListItem Value="2">OBC</asp:ListItem>
                     <asp:ListItem Value="3">SC</asp:ListItem>
                    <asp:ListItem Value="4">ST</asp:ListItem>
                    <asp:ListItem Value="3">PH</asp:ListItem>
                    <asp:ListItem Value="4">NA</asp:ListItem>
                    </asp:DropDownList>
                     </td>
                <td>
                     <span class="required"></span> <asp:Label ID="Label22" runat="server" Text="Religion:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                <asp:DropDownList ID="ddlreligion" runat="server" class="input-ddl">
                  <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">Hindu</asp:ListItem>
                    <asp:ListItem Value="2">Muslim</asp:ListItem>
                     <asp:ListItem Value="3">Christian</asp:ListItem>
                    <asp:ListItem Value="4">Sikh</asp:ListItem>
                    <asp:ListItem Value="5">Buddhist</asp:ListItem>
                    <asp:ListItem Value="6">Jews</asp:ListItem>  
                     <asp:ListItem Value="7">Other</asp:ListItem></asp:DropDownList>
                     </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label16" runat="server" Text="Aadhar Enrolment Number:" class="input-lbl"></asp:Label>
                    <br />
                </td>
                <td ><asp:TextBox ID="txt_aadhar_en" runat="server" class="input-txt"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="Aadhar Number:" class="input-lbl"></asp:Label>
                   </td>
                <td>
                    <asp:TextBox ID="txt_aadhar_no" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="Ration Card Number:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_ration" runat="server" class="input-txt"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label19" runat="server" Text="Disability:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    
                <asp:DropDownList ID="ddl_disability" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="YES">YES</asp:ListItem>
                    <asp:ListItem Value="NO">NO</asp:ListItem>
                </asp:DropDownList></td>
                
            </tr>
        </table></fieldset>
        <br /><br />
        <fieldset id="trainee">
        <legend>Trainee Details:
            <br />
        </legend>
        <table >
            <tr>
                <td >
                     <span class="required"></span> <asp:Label ID="Label20" runat="server" Text="Trainee Address:" class="input-lbl"></asp:Label>
                </td>
                <td >
                <asp:TextBox ID="txt_taddress" runat="server" class="input-txt" 
                        TextMode="MultiLine" Height="80px"></asp:TextBox>
                   </td>
                <td>
                   <span class="required"></span> <asp:Label ID="Label23" runat="server" Text="Tc State:" class="input-lbl"></asp:Label>
                 </td>
                <td >
                   <asp:DropDownList ID="ddl_tcstate" runat="server" CssClass="input-ddl"> </asp:DropDownList> </td>
                <td>
                  <span class="required"></span>  <asp:Label ID="Label24" runat="server" Text="Tc District:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddl_tcdistrict" runat="server" CssClass="input-ddl" > </asp:DropDownList> </td> 
            </tr>
            <tr>
            <td ><span class="required"></span> <asp:Label ID="Label25" runat="server" Text="PIN Code:" class="input-lbl"></asp:Label>
               
                  
                     </td>
                <td >
                 <asp:TextBox ID="txt_tpincode" runat="server" class="input-txt" MaxLength="6"></asp:TextBox>
                   </td>
                 <td>
                  <span class="required"></span>  <asp:Label ID="Label26" runat="server" Text="Contact no of Trainee:" class="input-lbl"></asp:Label>
                    </td>
                <td class="style1" >
                    <asp:TextBox ID="txt_tmobileno" runat="server" class="input-txt" MaxLength="12"></asp:TextBox>
                    </td>
                 <td >
                    <asp:Label ID="Label27" runat="server" Text="Type of Mobile:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2" >
                    <asp:DropDownList ID="ddl_tmobile" runat="server" class="input-ddl">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="1">Smart phone</asp:ListItem>
                        <asp:ListItem Value="2">Other</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
            <td >
                    <asp:Label ID="Label28" runat="server" Text="E-mail ID:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                   <asp:TextBox ID="txt_temail" runat="server" class="input-txt"></asp:TextBox>
                   </td>
                <td >
                 <span class="required"></span>  <asp:Label ID="Label29" runat="server"  Text="Pre-Training Status:" class="input-lbl"></asp:Label>
                    
                </td>
                <td class="style1" >
                 <asp:DropDownList ID="ddl_ttraining_status" runat="server" class="input-ddl" onchange="myFunction()" >
                     <asp:ListItem Value="">Select</asp:ListItem>
                     <asp:ListItem Value="1">Fresher</asp:ListItem>
                     <asp:ListItem Value="2">Experienced</asp:ListItem>
                    </asp:DropDownList>
               </td>
                <td >
                    <asp:Label ID="Label30" runat="server" Text="Work Experience:" class="input-lbl"></asp:Label>
                    
                </td>
                <td ><asp:Label ID="Label31" runat="server" Text="YEAR" CssClass="input-lbl1" ></asp:Label>
                    <br /> <asp:DropDownList ID="ddl_texp_year" runat="server" class="input-ddl" Width="80px" Height="20px"> </asp:DropDownList>
                
                     </td>
                
               
                <td ><asp:Label ID="Label32" runat="server" Text="MONTH" CssClass="input-lbl1"></asp:Label>
                    <br /> <asp:DropDownList ID="ddl_texp_month" runat="server" class="input-ddl" Width="80px" Height="20px"> </asp:DropDownList>
                
                     </td>
                
               
            </tr>
                            
            <tr>
                <td >
                  <span class="required"></span>  <asp:Label ID="Label34" runat="server" Text="Education Level:" class="input-lbl"></asp:Label>
                    <br />
                </td>
                <td ><asp:DropDownList ID="ddl_teducation" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Un Educated</asp:ListItem>
                    <asp:ListItem Value="2">5th to 8th</asp:ListItem>
                    <asp:ListItem Value="3">9th to 10th</asp:ListItem>
                    <asp:ListItem Value="4">11th to 12th</asp:ListItem>
                    <asp:ListItem Value="5">Under Graduate</asp:ListItem>
                    <asp:ListItem Value="6">Graduate</asp:ListItem>
                    <asp:ListItem Value="7">Post Graduate</asp:ListItem>
                    <asp:ListItem Value="8">ITI</asp:ListItem>
                    <asp:ListItem Value="9">Polytechnic</asp:ListItem>
                    <asp:ListItem Value="10">Diploma</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label35" runat="server" Text="Technical Education:" class="input-lbl"></asp:Label>
                    </td>
                <td class="style1" >
                    <asp:DropDownList ID="ddl_ttechnical" runat="server" class="input-ddl">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="1">YES</asp:ListItem>
                        <asp:ListItem Value="2">NO</asp:ListItem>
                </asp:DropDownList> </td>
                <td>
                   <span class="required"></span> <asp:Label ID="Label36"  runat="server" Text="Sector Covered:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddl_tsector"   runat="server" class="input-ddl">
                </asp:DropDownList></td>
            </tr>
            
        </table></fieldset>
        <br /><br />
        <fieldset id="course">
        <legend>Course Details:
        </legend>
        <table >
            <tr>
                <td >
                 <span class="required"></span>   <asp:Label ID="Label33" runat="server" Text="Course Enrolled:" class="input-lbl"></asp:Label>
                </td>
                <td >
                 <asp:TextBox ID="txt_coursename" runat="server" class="input-txt" ReadOnly="true" 
                        TextMode="MultiLine" Height="80px"></asp:TextBox>
                 <asp:Label ID="lbl_courseid" runat="server" Text="" Visible="false"></asp:Label>
                   </td>
                <td>
                    <span class="required"></span><asp:Label ID="Label37" runat="server" Text="Course Fee:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_coursefee" runat="server" class="input-txt" 
                        ToolTip="Enter the course fee with two decimals" ReadOnly="true"></asp:TextBox>
                    </td>
                <td>
                    <span class="required"></span><asp:Label ID="Label38" runat="server" Text="Trainer Id:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                   <asp:DropDownList ID="ddl_trainerid" runat="server" class="input-ddl">                  
                   
                    </asp:DropDownList>  </td>
            </tr>
            <tr>
            <td >
                    <span class="required"></span><asp:Label ID="Label39" runat="server" Text="Fee Paid By:" class="input-lbl"></asp:Label>
                </td>
                <td >
                <asp:DropDownList ID="ddl_feepaid" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Industry Sponsored</asp:ListItem>
                    <asp:ListItem Value="2">State Government</asp:ListItem>
                    <asp:ListItem Value="3">Self-Paid</asp:ListItem>
                    <asp:ListItem Value="4">CSR</asp:ListItem>
                   
                    </asp:DropDownList>
                </td>
                 <td>
                   <span class="required"></span> <asp:Label ID="Label40" runat="server" Text="Batch Start Date:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_batch_start" runat="server" class="input-txt" 
                       onkeypress="return numcheck(event)"></asp:TextBox>
                    </td>
                 <td >
                    <span class="required"></span><asp:Label ID="Label41" runat="server" Text="Batch End Date:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_batch_end" runat="server" class="input-txt" 
                        onkeypress="return numcheck(event)"></asp:TextBox>
                   </td>
            </tr>
            <tr>
            <td >
                  <span class="required"></span>  <asp:Label ID="Label42" runat="server" Text="Training Status:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:DropDownList ID="ddl_train_status" runat="server" class="input-ddl">
                        
                        <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">On going</asp:ListItem>
                    <asp:ListItem Value="2">Enrolled</asp:ListItem>
                    <asp:ListItem Value="3">Completed</asp:ListItem> 
                    <asp:ListItem Value="4">Drop out</asp:ListItem> 
                                        </asp:DropDownList>
                      </td>
                <td >
                   <span class="required"></span> <asp:Label ID="Label43" runat="server" Text="Data submit for:" class="input-lbl"></asp:Label>
                    
                </td>
                <td  ><asp:Label ID="Label52" runat="server" Text="YEAR" class="input-lbl1"></asp:Label>
                    <br />
              <asp:DropDownList ID="ddl_data_year" runat="server" class="input-ddl" Width="120px" 
                        Height="20px">
                   
                    </asp:DropDownList>
                    
             
                    </td>
                <td ><asp:Label ID="Label53" runat="server" Text="MONTH" class="input-lbl1"></asp:Label>
                    <br />
                <asp:DropDownList ID="ddl_data_month" runat="server" class="input-ddl" Width="60px" 
                        Height="20px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="0">JAN</asp:ListItem>
                    <asp:ListItem Value="1">FEB</asp:ListItem>
                    <asp:ListItem Value="2">MAR</asp:ListItem>
                    <asp:ListItem Value="3">APR</asp:ListItem>
                    <asp:ListItem Value="4">MAY</asp:ListItem>
                    <asp:ListItem Value="5">JUN</asp:ListItem>
                    <asp:ListItem Value="6">JUL</asp:ListItem>
                    <asp:ListItem Value="7">AUG</asp:ListItem>
                    <asp:ListItem Value="8">SEP</asp:ListItem>
                    <asp:ListItem Value="9">OCT</asp:ListItem>
                    <asp:ListItem Value="10">NOV</asp:ListItem>
                    <asp:ListItem Value="11">DEC</asp:ListItem>
                    </asp:DropDownList>
                    
                    </td>
                <td>
                    <asp:Label ID="Label44" runat="server" Text="Attendance(in%):" 
                        class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_attendance" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                
               
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label45" runat="server" Text="Passed out Date:" 
                        class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_passedout" runat="server" class="input-txt" 
                        onkeypress="return numcheck(event)"></asp:TextBox>
                   </td>
                <td>
                    <asp:Label ID="Label46" runat="server" Text="Grade:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                <asp:DropDownList ID="ddl_grade" runat="server" class="input-ddl">
                 <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">O</asp:ListItem>
                    <asp:ListItem Value="2">A</asp:ListItem>
                     <asp:ListItem Value="">A1</asp:ListItem>
                    <asp:ListItem Value="1">B</asp:ListItem>
                    <asp:ListItem Value="2">B1</asp:ListItem>
                     <asp:ListItem Value="">C</asp:ListItem>
                    <asp:ListItem Value="1">C1</asp:ListItem>
                    <asp:ListItem Value="2">D</asp:ListItem>
                     <asp:ListItem Value="2">D1</asp:ListItem>
                    </asp:DropDownList>
                     </td>
                <td>
                    <asp:Label ID="Label47" runat="server" Text="Certified:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                <asp:DropDownList ID="ddl_certified" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    </asp:DropDownList>
                     </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label48" runat="server" Text="Certification Date:" class="input-lbl"></asp:Label>
                    <br />
                </td>
                <td ><asp:TextBox ID="txt_certfn_date" runat="server" class="input-txt" 
                        onkeypress="return numcheck(event)"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label49" runat="server" Text="Certificate Name/Award:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_certfn_name" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                <td>
                    <asp:Label ID="Label50" runat="server" Text="Certificate No:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_certfn_no" runat="server" class="input-txt"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label51" runat="server" Text="Assessment Date:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    
                <asp:TextBox ID="txt_assesmnt_date" runat="server" class="input-txt" 
                        onkeypress="return numcheck(event)"></asp:TextBox>
               </td>
               <td >
                    <asp:Label ID="Label54" runat="server" Text="Agency:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    
                <asp:TextBox ID="txt_agency" runat="server" class="input-txt"></asp:TextBox>
               </td>
               <td >
                    <asp:Label ID="Label55" runat="server" Text="Assessor:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    
                <asp:TextBox ID="txt_Assessor" runat="server" class="input-txt"></asp:TextBox>
               </td>
                
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label56" runat="server" Text="Certifying Agency:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    
                <asp:TextBox ID="txt_certfn_agency" runat="server" class="input-txt"></asp:TextBox>
               </td>
               <td>
                  <span class="required"></span>  <asp:Label ID="Label81" runat="server" Text="Skilling Category:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddl_skills" 
                     runat="server" class="input-ddl">
                    </asp:DropDownList>
                    </td>
                    <td >
                    <asp:Label ID="Label62" runat="server" Text="Date of Joining:" class="input-lbl"></asp:Label>
                    </td>
                <td   >
                    <asp:TextBox ID="txt_joindate" runat="server" class="input-txt" onkeypress="return numcheck(event)"></asp:TextBox>
                    </td>
             </tr>
        </table></fieldset>
        <br /><br />
        <fieldset id="placement" runat="server" > 
        <legend>Placement Status:
        </legend>
        <table >
            <tr>
                <td >
                    <asp:Label ID="Label57" runat="server" Text="Placement Status:" class="input-lbl"></asp:Label>
                </td>
                <td >
                <asp:DropDownList ID="ddl_place_status" runat="server" CssClass="input-ddl">
                 <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem> </asp:DropDownList> 
                  </td>
                <td>
                    <asp:Label ID="Label58" runat="server" Text="EmploymentType:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                   <asp:DropDownList ID="ddl_emplymnt_type" runat="server" CssClass="input-ddl">
                      <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Employed Through Partner</asp:ListItem>
                    <asp:ListItem Value="2">Self Employed</asp:ListItem>
                    <asp:ListItem Value="3">Up Skilled</asp:ListItem>
                    <asp:ListItem Value="4">Opted for Higher Studies</asp:ListItem>
                   
                    </asp:DropDownList> </td>
                <td>
                    <asp:Label ID="Label59" runat="server" Text="Apprenticeship:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2" >
                    <asp:DropDownList ID="ddl_Apprenticeship" runat="server" CssClass="input-ddl"> 
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem></asp:DropDownList> </td> 
            </tr>
            <tr>
            <td >
                    <asp:Label ID="Label60" runat="server" Text="Proof of upskilling provided:" class="input-lbl"></asp:Label>
                </td>
                <td >
                  <asp:DropDownList ID="ddl_upskill" runat="server" class="input-ddl">
                  <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem> </asp:DropDownList>
                     </td>
                 <td>
                    <asp:Label ID="Label61" runat="server" Text="Type of proof:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:DropDownList ID="ddl_proof"   runat="server" class="input-ddl"> 
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Certifying skill enhancement from employer</asp:ListItem>
                    <asp:ListItem Value="2">Promotion</asp:ListItem>
                    <asp:ListItem Value="3">Increase in salary</asp:ListItem></asp:DropDownList>
                   </td>
                 
            </tr>
            <tr>
            <td >
                    <asp:Label ID="Label63" runat="server" Text="Employer Name/Self Employed:" class="input-lbl"></asp:Label>
                </td>
                <td >
                 <asp:TextBox ID="txt_empname" runat="server" class="input-txt"></asp:TextBox>
                   </td>
                 <td>
                    <asp:Label ID="Label64" runat="server" Text="Employer Contact Person Name:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_empcontact_name" runat="server" class="input-txt"></asp:TextBox>
                    </td>
                 <td >
                    <asp:Label ID="Label65" runat="server" Text="Employer Contact Person Designation:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2" >
                     <asp:TextBox ID="txt_empcontact_desgtn" runat="server" class="input-txt"></asp:TextBox>
                  </td>
            </tr>
            <tr>
            <td >
                    <asp:Label ID="Label66" runat="server" Text="Employer Contact No:" class="input-lbl"></asp:Label>
                </td>
                <td >
                 <asp:TextBox ID="txt_empcontact_no" runat="server" class="input-txt" 
                        MaxLength="12"></asp:TextBox>
                   </td>
                 <td>
                    <asp:Label ID="Label67" runat="server" Text="Employer State:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:DropDownList ID="ddl_emploc_state" runat="server" class="input-ddl">
                    </asp:DropDownList>
                    </td>
                 <td >
                    <asp:Label ID="Label68" runat="server" Text="Employer District:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2" ><asp:DropDownList ID="ddl_emploc_district" runat="server" class="input-ddl">
                    </asp:DropDownList>
                     </td>
            </tr>
             <tr>
            <td >
                    <asp:Label ID="Label69" runat="server" Text="Feedback Collected from Employer:" class="input-lbl"></asp:Label>
                </td>
                <td >
                <asp:DropDownList ID="ddl_feedback" runat="server" class="input-ddl">
                <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Satisfied</asp:ListItem>
                    <asp:ListItem Value="2">Not Satisfied</asp:ListItem>
                    <asp:ListItem Value="3">Not Collected</asp:ListItem></asp:DropDownList>
                    </td>
                 <td>
                    <asp:Label ID="Label70" runat="server" Text="Frequency of Feedback:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                     <asp:DropDownList ID="ddl_freq_feedback" runat="server" class="input-ddl">
                <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Monthly</asp:ListItem>
                    <asp:ListItem Value="2">QTR</asp:ListItem>
                    <asp:ListItem Value="3">Bi-Annually</asp:ListItem></asp:DropDownList> </td>
                 <td >
                    <asp:Label ID="Label71" runat="server" Text="Placement/work:" class="input-lbl"></asp:Label>
                    </td>
                <td ><asp:Label ID="Label75" runat="server" Text="STATE" class="input-lbl1"></asp:Label>
                    <br />
                <asp:DropDownList ID="ddl_work_state" runat="server" class="input-txt" Width="100px" Height="20px"> </asp:DropDownList>
                    
                    </td>
                <td ><asp:Label ID="Label76" runat="server" Text="DISTRICT" class="input-lbl1"></asp:Label>
                    <br />
                <asp:DropDownList ID="ddl_work_district" runat="server" class="input-txt" Width="100px" Height="20px"> </asp:DropDownList>
                    
                    </td>
                
            </tr>
            <tr>
            <td >
                    <asp:Label ID="Label72" runat="server" Text="Monthly Earning/CTC before Training:" class="input-lbl"></asp:Label>
                </td>
                <td >
                 <asp:TextBox ID="txt_earning_b4" runat="server" class="input-txt"></asp:TextBox>
                   </td>
                 <td>
                    <asp:Label ID="Label73" runat="server" Text="Monthly Current CTC/Earning:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                     <asp:TextBox ID="txt_earning_after" runat="server" class="input-txt"></asp:TextBox>
                 
                    </td>
                 <td >
                    <asp:Label ID="Label74" runat="server" Text="Undertaking for selfemployed collected from the trainee:" class="input-lbl"></asp:Label>
                    </td>
                <td colspan="2" ><asp:DropDownList ID="ddl_undertaking" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem></asp:DropDownList>
                     </td>
            </tr>
           
           
            
        </table></fieldset>
        <br /><br />
   
        <fieldset id="Additional_info">
        <legend>Additional Information:
        </legend><table >
            <tr>
                <td >
                    <asp:Label ID="Label77" runat="server" Text="Below Poverty Line:" class="input-lbl"></asp:Label>
                    <br />
                </td>
                <td >
                    <asp:DropDownList ID="ddl_poverty" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label78" runat="server" Text="Annual Household Income:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="ddl_annual_income" runat="server" class="input-ddl">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Below 96 Thousand</asp:ListItem>
                    <asp:ListItem Value="2">96 Thousand to 2.5 Lakh</asp:ListItem>
                     <asp:ListItem Value="3">2.5 Lakh - 5 Lakh</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td>
                    <asp:Label ID="Label79" runat="server" Text="Passport Number:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_passport" runat="server" class="input-txt"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label80" runat="server" Text="Validity Date:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_pport_val" runat="server" class="input-txt" 
                       onkeypress="return numcheck(event)"></asp:TextBox>
                   </td>
                

                <td>
                    <asp:Label ID="Label82" runat="server" Text="Source of Funding:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="ddl_fund_source" runat="server" class="input-ddl" >
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="1">Power Grid</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label83" runat="server" Text="Bank Name:" class="input-lbl"></asp:Label>
                    <br />
                </td>
                <td >
                    <asp:TextBox ID="txt_bank_name" runat="server" class="input-txt"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:Label ID="Label84" runat="server" Text="Branch Address:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                     <asp:TextBox ID="txt_bank_branchadd" runat="server" class="input-txt"></asp:TextBox>
               
                    </td>
                <td>
                    <asp:Label ID="Label85" runat="server" Text="IFSC Code:" class="input-lbl"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txt_ifsc" runat="server" class="input-txt"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label86" runat="server" Text="Bank  Account Number:" class="input-lbl"></asp:Label>
                    </td>
                <td >
                    <asp:TextBox ID="txt_accno" runat="server" class="input-txt"></asp:TextBox>
                   </td>
                
            </tr>
        </table></fieldset>
       
        
        
        <asp:Button ID="btnsubmit" CssClass="submit-btn" runat="server" Text="SUBMIT" 
            onclick="btnsubmit_Click" OnClientClick="return validation();"    />
        &nbsp;&nbsp;#  Required fields are marked with (<span style="color: #FF0000">*</span>) symbol
        <asp:HiddenField id="hf_tcdistrict" runat="server"/>
       <asp:HiddenField id="hf_emploc_district" runat="server"/>
       <asp:HiddenField id="hf_work_district" runat="server"/>       
        <asp:HiddenField ID="hf_id" runat="server" />       
        <asp:HiddenField ID="hf_dob" runat="server" />       
        <asp:HiddenField ID="hf_bstart" runat="server" />       
        <asp:HiddenField ID="hf_bend" runat="server"  />       
        <asp:HiddenField ID="hf_assesment" runat="server" />       
        <asp:HiddenField ID="hf_certification" runat="server" />       
        <asp:HiddenField ID="hf_passed" runat="server" />      
        <asp:HiddenField ID="hf_pvalidity" runat="server" />
       <asp:HiddenField ID="hf_joindate" runat="server" />
       
       
         <asp:HiddenField ID="hf_sdmscenterid" runat="server" />
        
      
        
        </asp:Content>
