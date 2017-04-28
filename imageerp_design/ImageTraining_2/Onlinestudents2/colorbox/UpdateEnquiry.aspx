<%@ Page Language="C#" MasterPageFile="Onlinestudents2/1imagemasterpage.master" AutoEventWireup="true" CodeFile="UpdateEnquiry.aspx.cs" Inherits="UpdateEnquiry" Title="Update Enquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
  function checkaddress()
  {
   if(document.getElementById("ContentPlaceHolder1_CheckBox1").checked==true)
   {
       document.getElementById("ContentPlaceHolder1_txtpermanentaddress").value=document.getElementById("ContentPlaceHolder1_txtpresentaddress").value;
       document.getElementById("ContentPlaceHolder1_txtpermanentcity").value=document.getElementById("ContentPlaceHolder1_txtpresentcity").value;
       document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").value=document.getElementById("ContentPlaceHolder1_txtpresentdistrict").value;
       document.getElementById("ContentPlaceHolder1_txtpermanentstate").value=document.getElementById("ContentPlaceHolder1_txtpresentstate").value;
       document.getElementById("ContentPlaceHolder1_txtpermanentpincode").value=document.getElementById("ContentPlaceHolder1_txtpresentpincode").value;
   }
   else if(document.getElementById("ContentPlaceHolder1_CheckBox1").checked==false)
   {
       document.getElementById("ContentPlaceHolder1_txtpermanentaddress").value="";
       document.getElementById("ContentPlaceHolder1_txtpermanentcity").value="";
       document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").value="";
       document.getElementById("ContentPlaceHolder1_txtpermanentstate").value="";
       document.getElementById("ContentPlaceHolder1_txtpermanentpincode").value="";
   } 
  }
  function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}
function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
		return true; 
	} else {
		return false;
	}
}

 
   function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  
       function losefocus2(obj)
    {
         if(document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value=="" && document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value == 'NotStudied')
         {
            document.getElementById("ContentPlaceHolder1_txtinstitute").value=""
            document.getElementById("ContentPlaceHolder1_txtbranch").value=""
          obj.blur()
         } 
    }
     function chkval5()
   {
          if(document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value!="")
           {
            document.getElementById("ContentPlaceHolder1_txtinstitute").value=""
            document.getElementById("ContentPlaceHolder1_txtbranch").value=""
           }
       
   }	
//   function chkval1()
//   {
//          if(document.getElementById("ContentPlaceHolder1_ddl_source").value=="Others")
//           {
//            document.getElementById("ContentPlaceHolder1_txtsource").style.display='';
//          
//           }
//           else if(document.getElementById("ContentPlaceHolder1_ddl_source").value=="")
//           {
//            document.getElementById("ContentPlaceHolder1_txtsource").style.display='none';
//           }
//           else
//           {
//            document.getElementById("ContentPlaceHolder1_txtsource").style.display='none';
//           }
//         
//   }	
    function chkval2()
   {
          if(document.getElementById("ContentPlaceHolder1_txt_knowsimage").value=="Others")
           {
            document.getElementById("ContentPlaceHolder1_txtothersrefer").style.display='';
           }
           else if(document.getElementById("ContentPlaceHolder1_txt_knowsimage").value=="Image Student")
           {
            document.getElementById("ContentPlaceHolder1_ddl_Centre").style.display='';
            document.getElementById("ContentPlaceHolder1_txtReferalstudentid").style.display='';
            document.getElementById("ContentPlaceHolder1_txtothersrefer").style.display='none';
           }
           else if(document.getElementById("ContentPlaceHolder1_txt_knowsimage").value=="")
           {
           document.getElementById("ContentPlaceHolder1_txtothersrefer").style.display='none';
           document.getElementById("ContentPlaceHolder1_ddl_Centre").style.display='none';
           document.getElementById("ContentPlaceHolder1_txtReferalstudentid").style.display='none';
           }
           else
           {
           document.getElementById("ContentPlaceHolder1_txtothersrefer").style.display='none';
           document.getElementById("ContentPlaceHolder1_ddl_Centre").style.display='none';
           document.getElementById("ContentPlaceHolder1_txtReferalstudentid").style.display='none';
           }
   }	
     function chkval3()
   {
          if(document.getElementById("ContentPlaceHolder1_txtparentrelation").value=="Others")
           {
            document.getElementById("ContentPlaceHolder1_txtrelationothers").style.display='';
           }
           else if(document.getElementById("ContentPlaceHolder1_txtparentrelation").value=="")
           {
           document.getElementById("ContentPlaceHolder1_txtrelationothers").style.display='none';
           }
           else
           {
           document.getElementById("ContentPlaceHolder1_txtrelationothers").style.display='none';
           }
   }	
   function chkvalR3()
   {
          if(document.getElementById("ContentPlaceHolder1_ddldecision_relation").value=="Others")
           {
            document.getElementById("ContentPlaceHolder1_txt_dec_others").style.display='';
           }
           else if(document.getElementById("ContentPlaceHolder1_ddldecision_relation").value=="")
           {
           document.getElementById("ContentPlaceHolder1_txt_dec_others").style.display='none';
           }
           else
           {
           document.getElementById("ContentPlaceHolder1_txt_dec_others").style.display='none';
           }
   }
        function chkval4()
   {
          if(document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").value=="Others")
           {
           
              document.getElementById("ContentPlaceHolder1_txtenqothers").style.display='';
           }
           else if(document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").value=="")
           {
           document.getElementById("ContentPlaceHolder1_txtenqothers").style.display='none';
           }
           else
           {
           document.getElementById("ContentPlaceHolder1_txtenqothers").style.display='none';
           }
   }
      function chkvl9()
      {
         if(document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="Others")
           {
              document.getElementById("ContentPlaceHolder1_txt_abt_image").style.display='';
           }
            else if(document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="")
           {
           document.getElementById("ContentPlaceHolder1_txt_abt_image").style.display='none';
           }
           else
           {
           document.getElementById("ContentPlaceHolder1_txt_abt_image").style.display='none';
           }
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
 function Validate_Email(Email)
           {
            var Str=Email
            var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
            if(CheckExpression.test(Str))
            {
	            return true;
            }
            else
            {
	            return false;
            }
          }  
function emptyValidation(fieldList)
 {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++)
        {

		if(trim(document.getElementById(field[i]).value)=="")
          {
            document.getElementById(field[i]).value=="";
			document.getElementById(field[i]).style.border="#FF0000 1px solid";
			counter++;
	  } 
          else 
          {
	      document.getElementById(field[i]).style.border="#999999 1px solid";
			
	  }
	}
	
	if(counter>0)
        {
		alert('Please populate the required/Highlighted fields.');
		//document.getElementById("msg").value='Please populate the required fields.';
		return false;				
	}  
      else
        {
		return true;
	}		
		
}  
 function enquiryform1()
	 {
	 var start = document.getElementById("ContentPlaceHolder1_txtdob").value;
      var start_s = start.split("-");
      var stDate = start_s[2]+start_s[1]+start_s[0];
      var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        //var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        
        var csDate = toDate-stDate;
        
	 //clearValidation('ctl00_ContentPlaceHolder1_ddl_enquiryfor~ctl00_ContentPlaceHolder1_txt_Nationality~ctl00_ContentPlaceHolder1_txtenqothers~ctl00_ContentPlaceHolder1_txtreason~ctl00_ContentPlaceHolder1_ddl_aboutimage~ctl00_ContentPlaceHolder1_txt_abt_image~ctl00_ContentPlaceHolder1_ddl_gender~ctl00_ContentPlaceHolder1_txtqualification~ctl00_ContentPlaceHolder1_txtmainsub~ctl00_ContentPlaceHolder1_txtschoolcolname~ctl00_ContentPlaceHolder1_txtcity~ctl00_ContentPlaceHolder1_txtstate~ctl00_ContentPlaceHolder1_ddl_completionstatus~ctl00_ContentPlaceHolder1_txtinstitute~ctl00_ContentPlaceHolder1_txtbranch~ctl00_ContentPlaceHolder1_ddl_animationstatus~ctl00_ContentPlaceHolder1_txtname~ctl00_ContentPlaceHolder1_txtLname~ctl00_ContentPlaceHolder1_txtdob~ctl00_ContentPlaceHolder1_txtmobile~ctl00_ContentPlaceHolder1_txtemail~ctl00_ContentPlaceHolder1_ddl_maritalstatus~ctl00_ContentPlaceHolder1_txtphone~ctl00_ContentPlaceHolder1_txtpresentaddress~ctl00_ContentPlaceHolder1_txtpresentcity~ctl00_ContentPlaceHolder1_txtpresentdistrict~ctl00_ContentPlaceHolder1_txtpresentstate~ctl00_ContentPlaceHolder1_txtpresentpincode~ctl00_ContentPlaceHolder1_txtpermanentaddress~ctl00_ContentPlaceHolder1_txtpermanentcity~ctl00_ContentPlaceHolder1_txtpermanentstate~ctl00_ContentPlaceHolder1_txtpermanentdistrict~ctl00_ContentPlaceHolder1_txtpermanentpincode')
		 if(document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").value=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").value=="";
             alert("Please Select your enquiry for");
             document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").focus();
             document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").style.backgroundColor="#e8ebd9";
             return false;
         }
         if(document.getElementById("ContentPlaceHolder1_ddl_enquiryfor").value=="Others" && document.getElementById("ContentPlaceHolder1_txtenqothers").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txtenqothers").value=="";
             alert("Please enter your enquiry for");
             document.getElementById("ContentPlaceHolder1_txtenqothers").focus();
             document.getElementById("ContentPlaceHolder1_txtenqothers").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtenqothers").style.backgroundColor="#e8ebd9";
             return false;
         }
         
//         else if(trim(document.getElementById("ContentPlaceHolder1_txtreason").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtreason").value=="";
//             alert("Please Enter a valid reason");
//             document.getElementById("ContentPlaceHolder1_txtreason").focus();
//             document.getElementById("ContentPlaceHolder1_txtreason").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtreason").style.backgroundColor="#e8ebd9";
//             return false;
//         }
            else if(document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="")
         {
             alert("Select how you know about image ? ");
             document.getElementById("ContentPlaceHolder1_ddl_aboutimage").focus();
             document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="Others" && document.getElementById("ContentPlaceHolder1_txt_abt_image").value=="")
         {
             alert("Please enter how you know about image ? ");
             document.getElementById("ContentPlaceHolder1_txt_abt_image").focus();
             document.getElementById("ContentPlaceHolder1_txt_abt_image").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_abt_image").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(trim(document.getElementById("ContentPlaceHolder1_ddl_gender").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_ddl_gender").value=="";
             alert("Please select gender");
             document.getElementById("ContentPlaceHolder1_ddl_gender").focus();
             document.getElementById("ContentPlaceHolder1_ddl_gender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_gender").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtfname").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtfname").value=="";
             alert("Please Enter student first name ");
             document.getElementById("ContentPlaceHolder1_txtfname").focus();
             document.getElementById("ContentPlaceHolder1_txtfname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfname").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(trim(document.getElementById("ContentPlaceHolder1_txtmobile").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtmobile").value=="";
             alert("Please Enter mobile number ");
             document.getElementById("ContentPlaceHolder1_txtmobile").focus();
             document.getElementById("ContentPlaceHolder1_txtmobile").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtmobile").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ContentPlaceHolder1_txtmobile").value!="" && document.getElementById("ContentPlaceHolder1_txtmobile").value.length<10)
         {
             alert("Invalid Mobile No(Must have 10digits)")
             document.getElementById("ContentPlaceHolder1_txtmobile").focus();
             document.getElementById("ContentPlaceHolder1_txtmobile").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtmobile").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(trim(document.getElementById("ContentPlaceHolder1_txtemail").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtemail").value=="";
             alert("Please Enter the Email-ID");
             document.getElementById("ContentPlaceHolder1_txtemail").focus();
             document.getElementById("ContentPlaceHolder1_txtemail").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtemail").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txtemail").value))
         {
             alert("Please Enter the Valid Email-ID");
             document.getElementById("ContentPlaceHolder1_txtemail").focus();
             document.getElementById("ContentPlaceHolder1_txtemail").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtemail").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtdob").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtdob").value=="";
             alert("Please Enter student date of birth");
             document.getElementById("ContentPlaceHolder1_txtdob").focus();
             document.getElementById("ContentPlaceHolder1_txtdob").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtdob").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(csDate < 0)
         {
             alert("Please enter valid date of birth");
             document.getElementById("ContentPlaceHolder1_txtdob").focus();
             document.getElementById("ContentPlaceHolder1_txtdob").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtdob").style.backgroundColor="#e8ebd9";
             return false;
        }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtpresentaddress").value)=="")
         { 
             
             document.getElementById("ContentPlaceHolder1_txtpresentaddress").value=="";
             alert("Please Enter the Present Address");
             document.getElementById("ContentPlaceHolder1_txtpresentaddress").focus();
             document.getElementById("ContentPlaceHolder1_txtpresentaddress").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpresentaddress").style.backgroundColor="#e8ebd9";
             return false;
         }
              else if(trim(document.getElementById("ContentPlaceHolder1_txtpresentcity").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpresentcity").value=="";
             alert("Please Enter the Present City");
             document.getElementById("ContentPlaceHolder1_txtpresentcity").focus();
             document.getElementById("ContentPlaceHolder1_txtpresentcity").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpresentcity").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txtpresentdistrict").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpresentdistrict").value=="";
             alert("Please Enter the Present District");
             document.getElementById("ContentPlaceHolder1_txtpresentdistrict").focus();
             document.getElementById("ContentPlaceHolder1_txtpresentdistrict").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpresentdistrict").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txtpresentstate").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpresentstate").value=="";
             alert("Please Enter the Present State");
             document.getElementById("ContentPlaceHolder1_txtpresentstate").focus();
             document.getElementById("ContentPlaceHolder1_txtpresentstate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpresentstate").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(trim(document.getElementById("ContentPlaceHolder1_txtpresentpincode").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").value=="";
             alert("Please Enter the Present pincode");
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").focus();
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").style.backgroundColor="#e8ebd9";
             return false;
         }
             else if(document.getElementById("ContentPlaceHolder1_txtpresentpincode").value!="" && document.getElementById("ContentPlaceHolder1_txtpresentpincode").value.length<6)
         {
             alert("Invalid Pin Code(Must have 6 digits)")
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").focus();
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpresentpincode").style.backgroundColor="#e8ebd9";
             return false;
         }
         
           else if(trim(document.getElementById("ContentPlaceHolder1_txtpermanentaddress").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpermanentaddress").value=="";
             alert("Please Enter the Permanent Address");
             document.getElementById("ContentPlaceHolder1_txtpermanentaddress").focus();
             document.getElementById("ContentPlaceHolder1_txtpermanentaddress").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpermanentaddress").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txtpermanentcity").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpermanentcity").value=="";
             alert("Please Enter the Permanent City");
             document.getElementById("ContentPlaceHolder1_txtpermanentcity").focus();
             document.getElementById("ContentPlaceHolder1_txtpermanentcity").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpermanentcity").style.backgroundColor="#e8ebd9";
             return false;
         }
             else if(trim(document.getElementById("ContentPlaceHolder1_txtpermanentstate").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpermanentstate").value=="";
             alert("Please Enter the Permanent State");
             document.getElementById("ContentPlaceHolder1_txtpermanentstate").focus();
             document.getElementById("ContentPlaceHolder1_txtpermanentstate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpermanentstate").style.backgroundColor="#e8ebd9";
             return false;
         }
             else if(trim(document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").value=="";
             alert("Please Enter the Permanent District");
             document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").focus();
             document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpermanentdistrict").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(trim(document.getElementById("ContentPlaceHolder1_txtpermanentpincode").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").value=="";
             alert("Please Enter the Permanent Pincode");
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").focus();
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(document.getElementById("ContentPlaceHolder1_txtpermanentpincode").value!="" && document.getElementById("ContentPlaceHolder1_txtpermanentpincode").value.length<6)
         {
             alert("Invalid Pin Code(Must have 6 digits)")
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").focus();
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtpermanentpincode").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value != "" && document.getElementById("ContentPlaceHolder1_txtinstitute").value == "" && document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value!='NotStudied')
         {   
             alert("Please Enter your Institute name");
             document.getElementById("ContentPlaceHolder1_txtinstitute").focus();
             document.getElementById("ContentPlaceHolder1_txtinstitute").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstitute").style.backgroundColor="#e8ebd9";
             return false;
         } 
          else if(document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value != "" && document.getElementById("ContentPlaceHolder1_txtbranch").value == "" && document.getElementById("ContentPlaceHolder1_ddl_animationstatus").value!='NotStudied')
         {   
             alert("Please Enter your Branch name");
             document.getElementById("ContentPlaceHolder1_txtbranch").focus();
             document.getElementById("ContentPlaceHolder1_txtbranch").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtbranch").style.backgroundColor="#e8ebd9";
             return false;
         } 
          
             
         else
         {
         return true;
         }
     }  
     
     function enquiryform2() 
     {
     //clearValidation('ctl00_ContentPlaceHolder1_txtparentname~ctl00_ContentPlaceHolder1_txtparentrelation~ctl00_ContentPlaceHolder1_txtparent_cmp~ctl00_ContentPlaceHolder1_ddl_employementstatus~ctl00_ContentPlaceHolder1_txtparent_designation~ctl00_ContentPlaceHolder1_txtparent_placeofwork~ctl00_ContentPlaceHolder1_txtparent_typeofindustry~ctl00_ContentPlaceHolder1_txtparent_monthlyincome~ctl00_ContentPlaceHolder1_txtselfemployed~ctl00_ContentPlaceHolder1_ddl_support~ctl00_ContentPlaceHolder1_txtrequirements~ctl00_ContentPlaceHolder1_txtquestions~ctl00_ContentPlaceHolder1_ddl_finstatus~ctl00_ContentPlaceHolder1_txtmininvestment~ctl00_ContentPlaceHolder1_txtmaxinvestment~ctl00_ContentPlaceHolder1_txt_dmakername~ctl00_ContentPlaceHolder1_txt_dmakerrelationship~ctl00_ContentPlaceHolder1_txt_dmakercontactdetails~ctl00_ContentPlaceHolder1_txt_counseledtime~ctl00_ContentPlaceHolder1_txt_courseasked~ctl00_ContentPlaceHolder1_txt_coursepositioned~ctl00_ContentPlaceHolder1_txt_enrolldate');
     
        //Enrolled date check
        var start = document.getElementById("ContentPlaceHolder1_txt_enrolldate").value;
        var start_s = start.split("-");
        var stDate = parseInt(start_s[2]+start_s[1]+start_s[0]);
        
        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var dday =  (curr_date < 10 ? '0' : '') + curr_date
        var toDate = parseInt(curr_year +''+ mon +''+ dday);
        //var csDate = stDate - toDate;
        var csDate = parseInt(stDate - toDate);
     
      if(trim(document.getElementById("ContentPlaceHolder1_txtparentname").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtparentname").value=="";
             alert("Please enter your Parent's/Guardian's name");
             document.getElementById("ContentPlaceHolder1_txtparentname").focus();
             document.getElementById("ContentPlaceHolder1_txtparentname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtparentname").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtparentrelation").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtparentrelation").value=="";
             alert("Please select your Relationship with the Applicant");
             document.getElementById("ContentPlaceHolder1_txtparentrelation").focus();
             document.getElementById("ContentPlaceHolder1_txtparentrelation").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtparentrelation").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_txtparentrelation").value=="Others" && document.getElementById("ContentPlaceHolder1_txtrelationothers").value=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtrelationothers").value=="";
             alert("Please enter your Relationship with the Applicant");
             document.getElementById("ContentPlaceHolder1_txtrelationothers").focus();
             document.getElementById("ContentPlaceHolder1_txtrelationothers").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtrelationothers").style.backgroundColor="#e8ebd9";
             return false;
         }
         
//            else if(trim(document.getElementById("ContentPlaceHolder1_txtparentmobile").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparentmobile").value=="";
//             alert("Please enter your Parent's Mobile Number ");
//             document.getElementById("ContentPlaceHolder1_txtparentmobile").focus();
//             document.getElementById("ContentPlaceHolder1_txtparentmobile").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparentmobile").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//            else if(trim(document.getElementById("ContentPlaceHolder1_txtparentemail").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparentemail").value=="";
//             alert("Please enter your Parent's Email Id");
//             document.getElementById("ContentPlaceHolder1_txtparentemail").focus();
//             document.getElementById("ContentPlaceHolder1_txtparentemail").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparentemail").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//            else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txtparentemail").value))
//         {
//             alert("Please enter the Valid Email-ID");
//             document.getElementById("ContentPlaceHolder1_txtparentemail").focus();
//             document.getElementById("ContentPlaceHolder1_txtparentemail").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparentemail").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//             else if(trim(document.getElementById("ContentPlaceHolder1_txtparent_cmp").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparent_cmp").value=="";
//             alert("Please enter your Parent's Company Name ");
//             document.getElementById("ContentPlaceHolder1_txtparent_cmp").focus();
//             document.getElementById("ContentPlaceHolder1_txtparent_cmp").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparent_cmp").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         
//             else if(trim(document.getElementById("ContentPlaceHolder1_txtparent_designation").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparent_designation").value=="";
//             alert("Please enter your Parent's Designation ");
//             document.getElementById("ContentPlaceHolder1_txtparent_designation").focus();
//             document.getElementById("ContentPlaceHolder1_txtparent_designation").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparent_designation").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//            else if(trim(document.getElementById("ContentPlaceHolder1_txtparent_typeofindustry").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparent_typeofindustry").value=="";
//             alert("Please enter your Parent's type of Industry ");
//             document.getElementById("ContentPlaceHolder1_txtparent_typeofindustry").focus();
//             document.getElementById("ContentPlaceHolder1_txtparent_typeofindustry").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparent_typeofindustry").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//             else if(document.getElementById("ContentPlaceHolder1_ddl_employementstatus").value=="")
//         {
//             alert("Please enter your Parent's Employment Status ");
//             document.getElementById("ContentPlaceHolder1_ddl_employementstatus").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_employementstatus").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_employementstatus").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//              else if(trim(document.getElementById("ContentPlaceHolder1_txtparent_placeofwork").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparent_placeofwork").value=="";
//             alert("Please enter your Parent's place of work ");
//             document.getElementById("ContentPlaceHolder1_txtparent_placeofwork").focus();
//             document.getElementById("ContentPlaceHolder1_txtparent_placeofwork").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparent_placeofwork").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           
//              else if(trim(document.getElementById("ContentPlaceHolder1_txtparent_monthlyincome").value)=="")
//         {
//             document.getElementById("ContentPlaceHolder1_txtparent_monthlyincome").value=="";
//             alert("Please enter your Parent's Monthly Income ");
//             document.getElementById("ContentPlaceHolder1_txtparent_monthlyincome").focus();
//             document.getElementById("ContentPlaceHolder1_txtparent_monthlyincome").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparent_monthlyincome").style.backgroundColor="#e8ebd9";
//             return false;
//         }
              else if(document.getElementById("ContentPlaceHolder1_ddl_support").value=="")
         {
             alert("Please enter the type of support you get from your parents");
             document.getElementById("ContentPlaceHolder1_ddl_support").focus();
             document.getElementById("ContentPlaceHolder1_ddl_support").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_support").style.backgroundColor="#e8ebd9";
             return false;
         }
               else if(document.getElementById("ContentPlaceHolder1_ddl_support").value=="Others" && document.getElementById("ContentPlaceHolder1_txtsource").value=="")
         {
             alert("Please enter the type of support you get from your parents");
             document.getElementById("ContentPlaceHolder1_txtsource").focus();
             document.getElementById("ContentPlaceHolder1_txtsource").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsource").style.backgroundColor="#e8ebd9";
             return false;
         }
              
//              else if(document.getElementById("ContentPlaceHolder1_ddl_profile").value=="")
//         {
//             alert("Please Enter your Parent's profile ");
//             document.getElementById("ContentPlaceHolder1_ddl_profile").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_profile").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_profile").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//               else if(trim(document.getElementById("ContentPlaceHolder1_txtrequirements").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtrequirements").value=="";
//             alert("Please Enter the Requirements of the Enquiry");
//             document.getElementById("ContentPlaceHolder1_txtrequirements").focus();
//             document.getElementById("ContentPlaceHolder1_txtrequirements").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtrequirements").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//               else if(trim(document.getElementById("ContentPlaceHolder1_txtquestions").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtquestions").value=="";
//             alert("Please Enter the Questions raised");
//             document.getElementById("ContentPlaceHolder1_txtquestions").focus();
//             document.getElementById("ContentPlaceHolder1_txtquestions").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtquestions").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txtmininvestment").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").value=="";
//             alert("Please Enter your Minimum Investment Possible");
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").focus();
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").style.backgroundColor="#e8ebd9";
//             return false;
//         } else if(trim(document.getElementById("ContentPlaceHolder1_txtmaxinvestment").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtmaxinvestment").value=="";
//             alert("Please Enter your Maximum investment possible ");
//             document.getElementById("ContentPlaceHolder1_txtmaxinvestment").focus();
//             document.getElementById("ContentPlaceHolder1_txtmaxinvestment").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtmaxinvestment").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//          else if(parseInt(document.getElementById("ContentPlaceHolder1_txtmininvestment").value) > parseInt(document.getElementById("ContentPlaceHolder1_txtmaxinvestment").value))
//         {
//             alert("Enter Minimum Investment Amount lesser than Maximum Investment")   
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").value="";  
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").focus();
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtmininvestment").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txtarrangefund").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtarrangefund").value=="";
//             alert("Please Enter the details of how you have arranged for the fund");
//             document.getElementById("ContentPlaceHolder1_txtarrangefund").focus();
//             document.getElementById("ContentPlaceHolder1_txtarrangefund").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtarrangefund").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(document.getElementById("ContentPlaceHolder1_ddl_interestlevel").value=="")
//         {
//             alert("Please Select your Interest Level ");
//             document.getElementById("ContentPlaceHolder1_ddl_interestlevel").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_interestlevel").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_interestlevel").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txtwhoallattended").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtwhoallattended").value=="";
//             alert("Please Enter who all attended the Counseling");
//             document.getElementById("ContentPlaceHolder1_txtwhoallattended").focus();
//             document.getElementById("ContentPlaceHolder1_txtwhoallattended").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtwhoallattended").style.backgroundColor="#e8ebd9";
//             return false;
//       
//           else if(trim(document.getElementById("ContentPlaceHolder1_txt_dmakercontactdetails").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_dmakercontactdetails").value=="";
//             alert("Please Enter your decision maker's Contact Details ");
//             document.getElementById("ContentPlaceHolder1_txt_dmakercontactdetails").focus();
//             document.getElementById("ContentPlaceHolder1_txt_dmakercontactdetails").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_dmakercontactdetails").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txt_referrername").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_referrername").value=="";
//             alert("Please Enter your Referrer's Name");
//             document.getElementById("ContentPlaceHolder1_txt_referrername").focus();
//             document.getElementById("ContentPlaceHolder1_txt_referrername").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_referrername").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txt_knowsimage").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_knowsimage").value=="";
//             alert("Please Enter how your Referer came to know about Image ");
//             document.getElementById("ContentPlaceHolder1_txt_knowsimage").focus();
//             document.getElementById("ContentPlaceHolder1_txt_knowsimage").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_knowsimage").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txt_referrercontactdetails").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_referrercontactdetails").value=="";
//             alert("Please Enter the Referrer's Contact Details");
//             document.getElementById("ContentPlaceHolder1_txt_referrercontactdetails").focus();
//             document.getElementById("ContentPlaceHolder1_txt_referrercontactdetails").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_referrercontactdetails").style.backgroundColor="#e8ebd9";
//             return false;
//         }
           else if(trim(document.getElementById("ContentPlaceHolder1_txt_counseledtime").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").value=="";
             alert("Please Enter the Counseled Time");
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").focus();
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(trim(document.getElementById("ContentPlaceHolder1_txt_courseasked").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txt_courseasked").value=="";
             alert("Please Select the course asked for");
             document.getElementById("ContentPlaceHolder1_txt_courseasked").focus();
             document.getElementById("ContentPlaceHolder1_txt_courseasked").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_courseasked").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value=="";
             alert("Please Select the course positioned");
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").focus();
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.backgroundColor="#e8ebd9";
             return false;
         }
//         else if(document.getElementById("ContentPlaceHolder1_ddl_status").value=="")
//         {
//             alert("Please Enter the Status of the Enquiry");
//             document.getElementById("ContentPlaceHolder1_ddl_status").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_status").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_status").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         
//         else if(trim(document.getElementById("ContentPlaceHolder1_txt_enrolldate").value)=="")
//         {
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").value=="";
//             alert("Please Enter the Enrollment date positioned");
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.backgroundColor="#e8ebd9";
//             return false;
//          }
//           else if(csDate < 0)
//          {
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").value=="";
//             alert("Invalid enrollment date");
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.backgroundColor="#e8ebd9";
//             return false;
  //        }
//             else if(trim(document.getElementById("ContentPlaceHolder1_txt_enrolldate").value)=="")
//         {
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").value=="";
//             alert("Please Enter the Enrollment date positioned");
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.backgroundColor="#e8ebd9";
//             return false;
//          }
//           else if(csDate < 0)
//          {
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").value=="";
//             alert("Invalid enrollment date");
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.backgroundColor="#e8ebd9";
//             return false;
//          }
//             else if(trim(document.getElementById("ContentPlaceHolder1_txt_actionplan").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_actionplan").value=="";
//             alert("Please Enter the Enquiry's action plan");
//             document.getElementById("ContentPlaceHolder1_txt_actionplan").focus();
//             document.getElementById("ContentPlaceHolder1_txt_actionplan").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_actionplan").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//          else if(document.getElementById("ContentPlaceHolder1_checkfields").checked == false)
//         {
//             alert("Please Click on the checkbox before submitting the form");
//             document.getElementById("ContentPlaceHolder1_checkfields").focus();
//             document.getElementById("ContentPlaceHolder1_checkfields").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_checkfields").style.backgroundColor="#e8ebd9";
//             return false;
//         }
         
         else
         {
         return true;
         }
         
     }


function Reset2_onclick() {
location.href="AddEnquiry.aspx";
}

function TABLE1_onclick() {

}

function nextstep_onclick() {

}

    </script>

    <div id="tabs">
        <input id="hdnTab" name="hdnTab" type="hidden" value="Admission" />
        <ul>
            <li><a class="selector" href="#tabs-1" style="font-weight: bold; color: black">Step1</a></li><li><a href="#tabs-2" style="font-weight: bold; color: black">Step2</a><asp:Label
                ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></li></ul>
    			<div id="tabs-1">
			 <div class="free-forms">
    <table class="common" cellpadding="1" style="height: 892px">
    <tr>
        <td style=" padding:0px;" align="center" valign="middle" colspan="4">
           <h3 style="font-weight:bold; margin:0px; color:orange;"> ENQUIRY FORM-1</h3></td>
    </tr> 
       <asp:HiddenField ID="Hidnenq_id" runat="server" />
  
    <tr>
        <td align="left"  valign="top" style="height: 18px" colspan="2">
           <b> The Course Enquiry is for </b><span style="color:Red">*</span></td>
        <td  align="left" valign="top" style="height: 18px" colspan="2"> 
          <asp:DropDownList ID="ddl_enquiryfor" runat="server" CssClass="select" onChange="chkval4()">
          <asp:ListItem value="">--Select--</asp:ListItem>
          <asp:ListItem value="Myself">Myself</asp:ListItem>
          <asp:ListItem value="Daughter">Daughter</asp:ListItem>
          <asp:ListItem value="Son">Son</asp:ListItem>
          <asp:ListItem value="Others">Others</asp:ListItem>
          </asp:DropDownList>
          <asp:TextBox ID="txtenqothers" runat="server" style="display:none" CssClass="text" MaxLength="25"></asp:TextBox>
          </td>
        
    </tr>
    <tr>
        <td  align="left" valign="top" colspan="2">
            The Main reasons for enquiring about the course</td>
        <td  align="left"  colspan="2" valign="top">
         <asp:TextBox ID="txtreason" runat="server" MaxLength="100" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" >
           <b> How did you know about IMAGE ?</b> <span style="color:Red">*</span></td>
        <td colspan="2" >
        <asp:DropDownList ID="ddl_aboutimage" runat="server" CssClass="select" onChange="chkvl9()">
          <asp:ListItem value="">--Select--</asp:ListItem>
          <asp:ListItem value="News Paper">News Paper</asp:ListItem>
          <asp:ListItem value="Website">Website</asp:ListItem>
          <asp:ListItem value="Advertisement">Advertisement</asp:ListItem>
          <asp:ListItem value="Others">Others</asp:ListItem>
          </asp:DropDownList>
            <asp:TextBox ID="txt_abt_image" runat="server" MaxLength="25" CssClass="text" style="display:none"></asp:TextBox></td>
    </tr>
        <tr>
            <td  style="height: 24px" colspan="2">
              <b>  Gender</b> <span style="color:Red">*</span></td>
            <td  style="height: 24px" colspan="2">
                <asp:DropDownList ID="ddl_gender" runat="server" CssClass="select" >
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
      <td  valign="top" colspan="4" style=" padding:0px;"><h4>
          Personal Particulars&nbsp; (Mention the students's details if you are enquiring on his/her
          behalf)&nbsp; :</h4></td>

    </tr>
    <tr>
      <td align="left" valign="top" style="height: 26px">
         <b> First Name</b> <span style="color:Red">*</span></td>
      <td  align="left" valign="top" style="height: 26px;"><asp:TextBox ID="txtfname" MaxLength="30" runat="server" CssClass="text" Width="300px" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
     
      <td  align="left" valign="top" style="height: 26px;">
         <b> Last Name </b><span style="color:Red">*</span></td>

      <td align="left" valign="top" style="height: 26px"> <asp:TextBox ID="txtLname" runat="server" CssClass="text" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
           <b> Mobile </b><span style="color:Red">*</span></td>
        <td  align="left" valign="top" ><asp:TextBox ID="txtmobile" onpaste="return false" runat="server" MaxLength="10" CssClass="text" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
        
        </td>

        <td align="left" valign="top">
            Alternate Mobile
        </td>
       
        <td align="left" valign="top"> <asp:TextBox ID="txtaltmobile" onpaste="return false" CssClass="text"  runat="server" MaxLength="10" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
           <b> E-mail</b> <span style="color:Red">*</span></td>
        <td align="left" valign="top">
        <asp:TextBox MaxLength="40" ID="txtemail" runat="server" CssClass="text"></asp:TextBox>
        </td>
      
        <td align="left" valign="top">
            Phone(Res)</td>
       
        <td align="left" valign="top"> <asp:TextBox ID="txtphone" onpaste="return false" runat="server" MaxLength="11"  CssClass="text" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
        </td>
    </tr>
        <tr>
            <td align="left" valign="top">
          <b>Date of Birth</b> <span style="color:Red">*</span></td>
            <td align="left" valign="top" >
          <asp:TextBox ID="txtdob" runat="server" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker"></asp:TextBox></td>
          
            <td align="left" valign="top">
                Blood Group </td>
           
            <td align="left" valign="top">
                <asp:DropDownList ID="ddl_bloodgroup" runat="server">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="A1 Negative">A1 -ve</asp:ListItem>
                    <asp:ListItem Value="A1 Positive">A1 +ve</asp:ListItem>
                    <asp:ListItem Value="A1B Negative ">A1B -ve</asp:ListItem>
                    <asp:ListItem Value="A1B Positive ">A1B +ve</asp:ListItem>
                    <asp:ListItem Value="A2 Negative">A2 -ve</asp:ListItem>
                    <asp:ListItem Value="A2 Positive">A2 +ve</asp:ListItem>
                    <asp:ListItem Value="A2B Negative">A2B -ve</asp:ListItem>
                    <asp:ListItem Value="A2B Positive">A2B +ve</asp:ListItem>
                    <asp:ListItem Value="B Negative">B -ve</asp:ListItem>
                    <asp:ListItem Value="B Positive">B +ve</asp:ListItem>
                    <asp:ListItem Value="O Negative">O -ve</asp:ListItem>
                    <asp:ListItem Value="O Positive">O +ve</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" valign="top" style="height: 30px">
                <b>Martial Status</b> <span style="color:Red">*</span></td>
            <td align="left" valign="top" style="height: 30px; ">
                <asp:DropDownList ID="ddl_maritalstatus" runat="server">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Single">Single</asp:ListItem>
                    <asp:ListItem Value="Married">Married</asp:ListItem>
                </asp:DropDownList></td>
          
            <td align="left" valign="top" style="height: 30px">
                Mother Tongue </td>
            
            <td align="left" valign="top" style="height: 30px">
                <asp:TextBox ID="txt_mothertongue" runat="server" CssClass="text" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="height: 30px" valign="top">
                <b>Nationality</b> <span style="color:Red">*</span></td>
            <td align="left" style="height: 30px" valign="top">
                <asp:TextBox ID="txt_Nationality1" runat="server" CssClass="text" MaxLength="40" onkeypress="return AllowAlphabet(event)" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="txt_Nationality" runat="server">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Indian</asp:ListItem>
                    <asp:ListItem>NRI</asp:ListItem>
                </asp:DropDownList></td>

          
          
            <td align="left" style="height: 30px" valign="top">
            </td>
            <td align="left" style="height: 30px" valign="top">
            </td>
        </tr>
     <tr>
      <td colspan="4" valign="top" style="padding:0px;"><h4>Present Address </h4></td>

    </tr>
    <tr>
      <td align="left" valign="top">
          <b>Address </b><span style="color:Red">*</span></td>
      <td  align="left" valign="top" ><asp:TextBox MaxLength="100" ID="txtpresentaddress" runat="server" CssClass="text" Height="51px" TextMode="MultiLine"></asp:TextBox></td>
   
      <td  align="left" valign="top">
         <b> District/Taluk</b> <span style="color:Red">*</span></td>


      <td align="left" valign="top"><asp:TextBox ID="txtpresentdistrict" MaxLength="50" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="left" valign="top">
         <b> City</b> <span style="color:Red">*</span></td>
      <td align="left" valign="top"><asp:TextBox ID="txtpresentcity" MaxLength="50" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
     
      <td align="left" valign="top"><b> State</b> <span style="color:Red">*</span></td>
   
      <td align="left" valign="top"><asp:TextBox ID="txtpresentstate" MaxLength="50" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
           <b> Pincode</b> <span style="color:Red">*</span></td>
        <td align="left" valign="top" >
        <asp:TextBox ID="txtpresentpincode" onKeyPress="return CheckNumeric(event)" onpaste="return false"  MaxLength="6" runat="server" CssClass="text"></asp:TextBox>
        </td>
        
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
    </tr>
   <tr>
      <td  valign="top" style="padding:0px;" colspan="4"><h4>
          Permanent Address&nbsp; (Please check if the address is same as above)
          <asp:CheckBox ID="CheckBox1" OnClick="javascript:return checkaddress();" runat="server" /></h4></td>
   </tr>
    <tr>
      <td align="left" valign="top">
         <b> Address </b><span style="color:Red">*</span></td>
      <td  align="left" valign="top" ><asp:TextBox ID="txtpermanentaddress" MaxLength="100" runat="server" CssClass="text" Height="57px" TextMode="MultiLine" ></asp:TextBox></td>
    
      <td  align="left" valign="top">
         <b> District/Taluk </b><span style="color:Red">*</span></td>
     

      <td align="left" valign="top"><asp:TextBox ID="txtpermanentdistrict" MaxLength="50" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
           <b> City </b><span style="color:Red">*</span></td>
        <td align="left" valign="top" >
        <asp:TextBox ID="txtpermanentcity" runat="server" MaxLength="50" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
        </td>
       
        <td align="left" valign="top">
           <b> State</b> <span style="color:Red">*</span></td>
     
        <td align="left" valign="top">
            <asp:TextBox ID="txtpermanentstate" MaxLength="50" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
           <b> Pincode</b> <span style="color:Red">*</span></td>
        <td align="left" valign="top" >
            <asp:TextBox ID="txtpermanentpincode" onKeyPress="return CheckNumeric(event)" MaxLength="6" runat="server" CssClass="text"></asp:TextBox></td>
        <td align="left" valign="top">
            </td>
        <td align="left" valign="top">
        </td>
    </tr>
      <tr>
      <td  valign="top" style=" padding:0px;" colspan="4"><h4>Highest Qualification details </h4></td>

    </tr>
    <tr>
      <td align="left" valign="top">
        <b> Qualification</b> <span style="color:Red">*</span></td>
         <td  align="left" valign="top">
          <asp:TextBox ID="txtqualification" MaxLength="50" runat="server" CssClass="text"></asp:TextBox></td>
     
      <td  align="left" valign="top">
         <b> Main Sub</b> <span style="color:Red">*</span></td>

      <td align="left" valign="top"><asp:TextBox ID="txtmainsub" MaxLength="75" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="left" valign="top"><b>Name of the School/College</b> <span style="color:Red">*</span>&nbsp;</td>
      <td align="left" valign="top" ><asp:TextBox ID="txtschoolcolname" MaxLength="75" runat="server" CssClass="text" ></asp:TextBox></td>
      <td align="left" valign="top"><b> City </b><span style="color:Red">*</span></td>
  
      <td align="left" valign="top"><asp:TextBox ID="txtcity" runat="server" MaxLength="50" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
  <tr>
      <td align="left" valign="top"><b>State </b><span style="color:Red">*</span></td>
      <td align="left" valign="top" ><asp:TextBox ID="txtstate" MaxLength="50" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    
      <td align="left" valign="top"><b>Completion &nbsp;status</b> <span style="color:Red">*</span>&nbsp;</td>
   
      <td align="left" valign="top">  
      <asp:DropDownList ID="ddl_completionstatus" runat="server" CssClass="select">
          <asp:ListItem value="">--Select--</asp:ListItem>
          <asp:ListItem value="Completed">Completed</asp:ListItem>
          <asp:ListItem value="Pursuing">Pursuing</asp:ListItem>
          <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
          </asp:DropDownList></td>
    </tr>
       <tr>
      <td  valign="top" style="padding:0px;" colspan="4"><h4>Education in Animation and Graphics (Optional) </h4></td>

    </tr>
    <tr>
      <td align="left" valign="top">
       Completion status   </td>
      <td  align="left" valign="top" ><asp:DropDownList ID="ddl_animationstatus" runat="server" CssClass="select" onChange="chkval5()">
         <asp:ListItem value="">--Select--</asp:ListItem>
          <asp:ListItem value="Completed">Completed</asp:ListItem>
           <asp:ListItem value="Pursuing">Pursuing</asp:ListItem>
          <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
          <asp:ListItem value="NotStudied">Not Studied</asp:ListItem>
         </asp:DropDownList></td>
      <td  align="left" valign="top">
          Branch</td>
  

      <td align="left" valign="top"><asp:TextBox ID="txtbranch" MaxLength="40" runat="server" CssClass="text" onFocus="losefocus2(this)"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Institute
        </td>
        <td  align="left" valign="top">   <asp:TextBox ID="txtinstitute" MaxLength="40" runat="server" CssClass="text" onFocus="losefocus2(this)"></asp:TextBox>
        
        </td>
       <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
        
    </tr>
       
   
    <tr>
        <td  style="text-align:center;" valign="top" colspan="4">
            <br />
            &nbsp;&nbsp;
            <input id="step1" type="button" value="Next Step" class="btnStyle1"  />&nbsp; 
            <input id="Reset1" type="reset" value="Reset" title="Reset" class="btnStyle2" />
            &nbsp;&nbsp;&nbsp;<br />
            <br />           
           </td>
    </tr>
</table>
</div>
   </div>
        <div id="tabs-2">
		    <div class="free-forms">
            <table id="TABLE1" cellpadding="1" class="common" width="100%" onclick="return TABLE1_onclick()">
                <tr>
                    <td align="center" colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="middle">
                        <h3 style="font-weight: bold; margin: 0px; color: orange">
                            ENQUIRY FORM-2</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="top">
                        <h4>
                            Parent/Guardian's Particulars&nbsp;
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        <b>Parent/Guardian's Name</b> <span style="color: #000000">*</span>&nbsp;</td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtparentname" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" valign="top">
                        <b>Relationship with Applicant </b><span style="color: red">*</span></td>
                    <td align="left" valign="top">
					<asp:DropDownList ID="txtparentrelation" runat="server" CssClass="select" onChange="chkval3();" Width="300px">
                            <asp:ListItem Value="">--Select---</asp:ListItem>
                            <asp:ListItem Value="Parent">Parent</asp:ListItem>
                            <asp:ListItem Value="Guardian">Guardian</asp:ListItem>
                            <asp:ListItem Value="Friend">Friend</asp:ListItem>
                            <asp:ListItem Value="Others">Others</asp:ListItem>
                        </asp:DropDownList>
						<br />
                        <asp:TextBox ID="txtrelationothers" runat="server" CssClass="text" MaxLength="50"
                            Style="display: none" Width="290px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Mobile &nbsp;</td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtparentmobile" runat="server" CssClass="text" MaxLength="10" onkeypress="return CheckNumeric(event)"
                            onpaste="return false"></asp:TextBox></td>
                    <td align="left" colspan="2" style="height: 29px" valign="top">
                        Phone(Office)</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtparentphnumber" runat="server" CssClass="text" MaxLength="11"
                            onkeypress="return CheckNumeric(event)" onpaste="return false" Width="290px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        E-mail&nbsp;
                    </td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtparentemail" runat="server" CssClass="text" MaxLength="40"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="top">
                        <h4>
                            Professional Details of Parent /Guardian&nbsp; (Optional)</h4>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Company &nbsp;</td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtparent_cmp" runat="server" CssClass="text" MaxLength="75"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;Designation &nbsp;</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtparent_designation" runat="server" CssClass="text" MaxLength="75" Width="290px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Type of Industry &nbsp;</td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtparent_typeofindustry" runat="server" CssClass="text" MaxLength="75"></asp:TextBox></td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;Employment status &nbsp;</td>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="ddl_employementstatus" runat="server" CssClass="select" Width="300px">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="In Service">In Service</asp:ListItem>
                            <asp:ListItem Value="Retired">Retired</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Place of work
                    </td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtparent_placeofwork" runat="server" CssClass="text" MaxLength="50"></asp:TextBox></td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;Monthly Income
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtparent_monthlyincome" runat="server" CssClass="text" MaxLength="7"
                            onkeypress="return CheckNumeric(event)" onpaste="return false" Width="290px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Proprietorship/Partnership(if Self Employed)</td>
                    <td align="left" colspan="4" valign="top">
                        <asp:TextBox ID="txtselfemployed" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                        &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 198px" valign="top">
                        <b>Support of Parents </b><span style="color: red">*</span>
                    </td>
                    <td colspan="4" valign="top">
                        <asp:DropDownList ID="ddl_support" runat="server" CssClass="select">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="Very High">Very High</asp:ListItem>
                            <asp:ListItem Value="Good">Good</asp:ListItem>
                            <asp:ListItem Value="Average">Average</asp:ListItem>
                            <asp:ListItem Value="Low">Low</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="coursevis" runat="server" visible="false">
                    <td align="left" colspan="3" valign="top">
                        Source (As per the detailed discussion with the enquiry)</td>
                    <td align="left" colspan="3" valign="top">
                        <asp:DropDownList ID="ddl_source" runat="server" CssClass="select" onChange="chkval1()">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="Main Source">Main Source</asp:ListItem>
                            <asp:ListItem Value="Others">Others</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtsource" runat="server" CssClass="text" MaxLength="50" Style="display: none"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px; height: 24px" valign="top">
                        Enquiry Profile
                    </td>
                    <td align="left" colspan="4" style="height: 24px" valign="top">
                        <asp:DropDownList ID="ddl_profile" runat="server" CssClass="select">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="School student">School student</asp:ListItem>
                            <asp:ListItem Value="College student">College student</asp:ListItem>
                            <asp:ListItem Value="Employed/Salaried">Employed/Salaried</asp:ListItem>
                            <asp:ListItem Value="Self-Employed">Self-Employed</asp:ListItem>
                            <asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
                            <asp:ListItem Value="Housewife">Housewife</asp:ListItem>
                            <asp:ListItem Value="Sr.Citizen">Sr.Citizen</asp:ListItem>
                            <asp:ListItem Value="Multimedia Professional">Multimedia Professional</asp:ListItem>
                            <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Requirements of the enquiry
                    </td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtrequirements" runat="server" CssClass="text" MaxLength="50" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Questions raised by the enquiry
                    </td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtquestions" runat="server" CssClass="text" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="top">
                        <h4>
                            Competitors Visited (Optional)</h4>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Brand&nbsp;</td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtbrand" runat="server" CssClass="text" MaxLength="20"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" valign="top">
                        Location&nbsp;</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtlocation" runat="server" CssClass="text" MaxLength="20" Width="290px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Positive</td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtpositive" runat="server" CssClass="text" MaxLength="50"></asp:TextBox></td>
                    <td align="left" colspan="2" valign="top">
                        Negative</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtnegative" runat="server" CssClass="text" MaxLength="50" Width="290px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="top">
                        <h4>
                            Financial Details</h4>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        <b>Financial Status </b><span style="color: red">*</span></td>
                    <td align="left" colspan="4" valign="top">
                        <asp:DropDownList ID="ddl_finstatus" runat="server" CssClass="select">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="Very Good">Very Good</asp:ListItem>
                            <asp:ListItem Value="Good">Good</asp:ListItem>
                            <asp:ListItem Value="Average">Average</asp:ListItem>
                            <asp:ListItem Value="Bad">Bad</asp:ListItem>
                            <asp:ListItem Value="Very Bad">Very Bad</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <%--    <tr>
        <td align="left" colspan="2" valign="top" style="width: 198px">
           <b> Minimum investment possible </b><span style="color:Red">*</span></td>
        <td align="left" valign="top" style="width: 132px">
            <asp:TextBox ID="txtmininvestment" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="7" runat="server" CssClass="text"></asp:TextBox></td>
        <td align="left" colspan="2" valign="top" style="height: 39px">
            <b>Maximum investment &nbsp;possible</b><span style="color: #ff0000">*</span></td>
        <td align="left" valign="top">
            <asp:TextBox ID="txtmaxinvestment" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="7" runat="server" CssClass="text"></asp:TextBox></td>
    </tr>
--%>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        <b>Investment possible </b><span style="color: red">*</span></td>
                    <td align="left" style="width: 140px" valign="top">
                        <asp:TextBox ID="txtmininvestment" runat="server" CssClass="text" MaxLength="15"
                            onkeypress="return CheckNumeric(event)" onpaste="return false" Visible="False"></asp:TextBox>
                        <asp:DropDownList ID="ddl_Inv_Possible" runat="server">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="Rs.25,000 to 50,000">Rs.25,000 to 50,000</asp:ListItem>
                            <asp:ListItem Value="Rs.50,000 to 75,000">Rs.50,000 to 75,000</asp:ListItem>
                            <asp:ListItem Value="Rs.75,000 to 1,00,000">Rs.75,000 to 1,00,000</asp:ListItem>
                            <asp:ListItem Value="Above 1,00,000">Above 1,00,000</asp:ListItem>
                        </asp:DropDownList></td>
                    <td align="left" colspan="2" style="height: 39px" valign="top">
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtmaxinvestment" runat="server" CssClass="text" MaxLength="15"
                            onkeypress="return CheckNumeric(event)" onpaste="return false" Visible="False" Width="290px"></asp:TextBox></td>
                </tr>
                <tr id="enqplan" runat="server" visible="false">
                    <td align="left" colspan="3" valign="top">
                        How has the enquiry planned to arrange the funds required for the course
                    </td>
                    <td align="left" colspan="3" nowrap="nowrap" valign="top">
                        <asp:TextBox ID="txtarrangefund" runat="server" CssClass="text" MaxLength="50" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr id="interestvis" runat="server" visible="false">
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Interest level</td>
                    <td align="left" nowrap="nowrap" style="width: 132px" valign="top">
                        <asp:DropDownList ID="ddl_interestlevel" runat="server" CssClass="select">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="Very High">Very High</asp:ListItem>
                            <asp:ListItem Value="Good">Good</asp:ListItem>
                            <asp:ListItem Value="Average">Average</asp:ListItem>
                            <asp:ListItem Value="Low">Low</asp:ListItem>
                        </asp:DropDownList></td>
                    <td align="left" colspan="2" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr id="enqwho" runat="server" visible="false">
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Who all attended the counseling?</td>
                    <td align="left" nowrap="nowrap" style="width: 132px" valign="top">
                        <asp:TextBox ID="txtwhoallattended" runat="server" CssClass="text" MaxLength="70"
                            TextMode="MultiLine"></asp:TextBox></td>
                    <td align="left" colspan="2" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px; height: 29px" valign="top">
                        <h4>
                            Decision Makers
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        <b>Name </b><span style="color: red">*</span></td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txt_dmakername" runat="server" CssClass="text" MaxLength="20"></asp:TextBox></td>
                    <td align="left" colspan="2" style="height: 29px" valign="top">
                        Contact details</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txt_dmakercontactdetails" runat="server" CssClass="text" MaxLength="40" Width="290px"></asp:TextBox>&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px; height: 51px" valign="top">
                        <b>Relationship </b><span style="color: red">*</span></td>
                    <td align="left" style="width: 140px; height: 51px" valign="top">
                        <asp:TextBox ID="txt_dmakerrelationship" runat="server" CssClass="text" MaxLength="20"
                            ReadOnly="True" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddldecision_relation" runat="server" CssClass="select" onChange="chkvalR3();">
                            <asp:ListItem Value="">--Select---</asp:ListItem>
                            <asp:ListItem Value="Parent">Parent</asp:ListItem>
                            <asp:ListItem Value="Guardian">Guardian</asp:ListItem>
                            <asp:ListItem Value="Friend">Friend</asp:ListItem>
                            <asp:ListItem Value="Others">Others</asp:ListItem>
                        </asp:DropDownList>
						<br />
						 <asp:TextBox ID="txt_dec_others" runat="server" CssClass="text" MaxLength="50" Style="display: none"></asp:TextBox>
                    </td>
                    <td align="left" colspan="2" style="height: 51px" valign="top">
                       </td>
                    <td align="left" style="height: 51px" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="top">
                        <h4>
                            Whether enquiry was referred by someone (Optional)
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Name
                    </td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txt_referrername" runat="server" CssClass="text" MaxLength="50"></asp:TextBox></td>
                    <td align="left" colspan="2" valign="top">
                        Contact details
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txt_referrercontactdetails" runat="server" CssClass="text" MaxLength="40" Width="290px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        How did he know Image
                    </td>
                    <td align="left" colspan="4" valign="top">
                        <asp:DropDownList ID="txt_knowsimage" runat="server" CssClass="select" onChange="chkval2();">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="Tv Adds">Tv Adds</asp:ListItem>
                            <asp:ListItem Value="Paper">Paper</asp:ListItem>
                            <asp:ListItem Value="Posters">Posters</asp:ListItem>
                            <asp:ListItem Value="Banners">Banners</asp:ListItem>
                            <asp:ListItem Value="Image alumini">Image alumini</asp:ListItem>
                            <asp:ListItem Value="Image Student">Image Student</asp:ListItem>
                            <asp:ListItem Value="Others">Others</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtothersrefer" runat="server" CssClass="text" Style="display: none"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="ddl_Centre" runat="server" Style="display: none">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtReferalstudentid" runat="server" MaxLength="50" Style="display: none"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                        padding-top: 0px" valign="top">
                        <h4>
                            Enquiry Status</h4>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 198px" valign="top">
                        <b>Counseled time</b> <span style="color: red">*</span>
                    </td>
                    <td colspan="4" style="height: 29px" valign="top">
                        <asp:DropDownList ID="txt_counseledtime" runat="server">
                            <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="10mins">10 mins</asp:ListItem>
                            <asp:ListItem Value="15mins">15mins</asp:ListItem>
                            <asp:ListItem Value="20mins">20mins</asp:ListItem>
                            <asp:ListItem Value="25mins">25mins</asp:ListItem>
                            <asp:ListItem Value="30mins">30mins</asp:ListItem>
                            <asp:ListItem Value="35mins">35mins</asp:ListItem>
                            <asp:ListItem Value="40mins">40mins</asp:ListItem>
                            <asp:ListItem Value="45mins">45mins</asp:ListItem>
                            <asp:ListItem Value="50mins">50mins</asp:ListItem>
                            <asp:ListItem Value="55mins">55mins</asp:ListItem>
                            <asp:ListItem Value="1hour">1 hour</asp:ListItem>
                            <asp:ListItem Value="1hour 15 mins">1hour 15 mins</asp:ListItem>
                            <asp:ListItem Value="1hour 30 mins">1hour 30 mins</asp:ListItem>
                            <asp:ListItem Value="1hour 45 mins">1hour 45 mins</asp:ListItem>
                            <asp:ListItem Value="2hours">2 hours</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        <b>Course Asked</b> <span style="color: red">*</span></td>
                    <td align="left" colspan="4" style="height: 27px" valign="top">
                        <asp:DropDownList ID="txt_courseasked" runat="server" CssClass="select">
                        </asp:DropDownList><span style="color: red">&nbsp; </span>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        <b>Course Positioned</b> <span style="color: red">* &nbsp; &nbsp;</span></td>
                    <td align="left" colspan="4" style="height: 27px" valign="top">
                        <asp:DropDownList ID="txt_coursepositioned" runat="server" CssClass="select">
                        </asp:DropDownList></td>
                </tr>
              
                <tr id="enqaction" runat="server" visible="false">
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                        Enquiry's action plan
                    </td>
                    <td align="left" style="width: 132px" valign="top">
                        <asp:TextBox ID="txt_actionplan" runat="server" CssClass="text" MaxLength="40"></asp:TextBox></td>
                    <td align="left" colspan="2" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr id="enqsubmit" runat="server" visible="false">
                    <td align="left" colspan="2" style="width: 198px" valign="top">
                    </td>
                    <td align="left" colspan="2" valign="top">
                        <asp:CheckBox ID="checkfields" runat="server" />Are you sure of submitting the form?</td>
                    <td align="left" style="width: 195px" valign="top">
                    </td>
                    <td align="left" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center" valign="top">
                        <br />
                        <asp:Button ID="btnsubmit5" runat="server" CssClass="btnStyle1" OnClick="btnsubmit5_Click"
                            OnClientClick="javascript:return enquiryform2();" Text="Update" />&nbsp; &nbsp;<input
                                id="Reset2" class="btnStyle2" onclick="return Reset2_onclick()" title="Reset" type="reset"
                                value="Reset" />
                        <asp:HiddenField ID="hdntempID" runat="server" />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
			</div>
        </div>
    </div>
</asp:Content>

