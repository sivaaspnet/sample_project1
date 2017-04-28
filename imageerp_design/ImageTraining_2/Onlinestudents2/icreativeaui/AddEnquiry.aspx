<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="AddEnquiry.aspx.cs" Inherits="superadmin_AddEnquiry" Title="Add Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
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
</script>
  <script language="javascript" type="text/javascript">
 
 
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
        
	 //clearValidation('ContentPlaceHolder1_ddl_enquiryfor~ContentPlaceHolder1_txt_Nationality~ContentPlaceHolder1_txtenqothers~ContentPlaceHolder1_txtreason~ContentPlaceHolder1_ddl_aboutimage~ContentPlaceHolder1_txt_abt_image~ContentPlaceHolder1_ddl_gender~ContentPlaceHolder1_txtqualification~ContentPlaceHolder1_txtmainsub~ContentPlaceHolder1_txtschoolcolname~ContentPlaceHolder1_txtcity~ContentPlaceHolder1_txtstate~ContentPlaceHolder1_ddl_completionstatus~ContentPlaceHolder1_txtinstitute~ContentPlaceHolder1_txtbranch~ContentPlaceHolder1_ddl_animationstatus~ContentPlaceHolder1_txtname~ContentPlaceHolder1_txtLname~ContentPlaceHolder1_txtdob~ContentPlaceHolder1_txtmobile~ContentPlaceHolder1_txtemail~ContentPlaceHolder1_ddl_maritalstatus~ContentPlaceHolder1_txtphone~ContentPlaceHolder1_txtpresentaddress~ContentPlaceHolder1_txtpresentcity~ContentPlaceHolder1_txtpresentdistrict~ContentPlaceHolder1_txtpresentstate~ContentPlaceHolder1_txtpresentpincode~ContentPlaceHolder1_txtpermanentaddress~ContentPlaceHolder1_txtpermanentcity~ContentPlaceHolder1_txtpermanentstate~ContentPlaceHolder1_txtpermanentdistrict~ContentPlaceHolder1_txtpermanentpincode')
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
          else if(trim(document.getElementById("ContentPlaceHolder1_ddl_gender").value)=="--Select--")
         {
             
             document.getElementById("ContentPlaceHolder1_ddl_gender").value=="--Select--";
             alert("Please select gender");
             document.getElementById("ContentPlaceHolder1_ddl_gender").focus();
             document.getElementById("ContentPlaceHolder1_ddl_gender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_gender").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtname").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtname").value=="";
             alert("Please Enter student first name ");
             document.getElementById("ContentPlaceHolder1_txtname").focus();
             document.getElementById("ContentPlaceHolder1_txtname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtname").style.backgroundColor="#e8ebd9";
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
//         else if(trim(document.getElementById("ContentPlaceHolder1_txtqualification").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtqualification").value=="";
 //             alert("Please Enter your qualification ");
  //           document.getElementById("ContentPlaceHolder1_txtqualification").focus();
  //           document.getElementById("ContentPlaceHolder1_txtqualification").style.border="#ff0000 1px solid";
  //           document.getElementById("ContentPlaceHolder1_txtqualification").style.backgroundColor="#e8ebd9";
  //           return false;
  //       } 
//           else if(trim(document.getElementById("ContentPlaceHolder1_txtmainsub").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtmainsub").value=="";
//              alert("Please Enter your main subject");
//             document.getElementById("ContentPlaceHolder1_txtmainsub").focus();
//             document.getElementById("ContentPlaceHolder1_txtmainsub").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtmainsub").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//             else if(trim(document.getElementById("ContentPlaceHolder1_txtschoolcolname").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtschoolcolname").value=="";
//              alert("Please Enter your School/college name ");
//             document.getElementById("ContentPlaceHolder1_txtschoolcolname").focus();
//             document.getElementById("ContentPlaceHolder1_txtschoolcolname").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtschoolcolname").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//             else if(trim(document.getElementById("ContentPlaceHolder1_txtcity").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtcity").value=="";
//             alert("Please Enter your city ");
//             document.getElementById("ContentPlaceHolder1_txtcity").focus();
//             document.getElementById("ContentPlaceHolder1_txtcity").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtcity").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//               else if(trim(document.getElementById("ContentPlaceHolder1_txtstate").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtstate").value=="";
//             alert("Please Enter your state ");
//             document.getElementById("ContentPlaceHolder1_txtstate").focus();
//             document.getElementById("ContentPlaceHolder1_txtstate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtstate").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//        else if(document.getElementById("ContentPlaceHolder1_ddl_completionstatus").value=="")
//         {   
//             alert("Please Select your status  ");
//             document.getElementById("ContentPlaceHolder1_ddl_completionstatus").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_completionstatus").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_completionstatus").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
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
     //clearValidation('ContentPlaceHolder1_txtparentname~ContentPlaceHolder1_txtparentrelation~ContentPlaceHolder1_txtparent_cmp~ContentPlaceHolder1_ddl_employementstatus~ContentPlaceHolder1_txtparent_designation~ContentPlaceHolder1_txtparent_placeofwork~ContentPlaceHolder1_txtparent_typeofindustry~ContentPlaceHolder1_txtparent_monthlyincome~ContentPlaceHolder1_txtselfemployed~ContentPlaceHolder1_ddl_support~ContentPlaceHolder1_txtrequirements~ContentPlaceHolder1_txtquestions~ContentPlaceHolder1_ddl_finstatus~ContentPlaceHolder1_txtmininvestment~ContentPlaceHolder1_txtmaxinvestment~ContentPlaceHolder1_txt_dmakername~ContentPlaceHolder1_txt_dmakerrelationship~ContentPlaceHolder1_txt_dmakercontactdetails~ContentPlaceHolder1_txt_counseledtime~ContentPlaceHolder1_txt_courseasked~ContentPlaceHolder1_txt_coursepositioned~ContentPlaceHolder1_txt_enrolldate');
     
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
     
//      if(trim(document.getElementById("ContentPlaceHolder1_txtparentname").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparentname").value=="";
//             alert("Please enter your Parent's/Guardian's name");
//             document.getElementById("ContentPlaceHolder1_txtparentname").focus();
//             document.getElementById("ContentPlaceHolder1_txtparentname").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparentname").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         else if(trim(document.getElementById("ContentPlaceHolder1_txtparentrelation").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtparentrelation").value=="";
//             alert("Please select your Relationship with the Applicant");
//             document.getElementById("ContentPlaceHolder1_txtparentrelation").focus();
//             document.getElementById("ContentPlaceHolder1_txtparentrelation").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtparentrelation").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//          else if(document.getElementById("ContentPlaceHolder1_txtparentrelation").value=="Others" && document.getElementById("ContentPlaceHolder1_txtrelationothers").value=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtrelationothers").value=="";
//             alert("Please enter your Relationship with the Applicant");
//             document.getElementById("ContentPlaceHolder1_txtrelationothers").focus();
//             document.getElementById("ContentPlaceHolder1_txtrelationothers").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtrelationothers").style.backgroundColor="#e8ebd9";
//             return false;
//         }
         
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
//              else if(document.getElementById("ContentPlaceHolder1_ddl_support").value=="")
//         {
//             alert("Please enter the type of support you get from your parents");
//             document.getElementById("ContentPlaceHolder1_ddl_support").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_support").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_support").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//               else if(document.getElementById("ContentPlaceHolder1_ddl_support").value=="Others" && document.getElementById("ContentPlaceHolder1_txtsource").value=="")
//         {
//             alert("Please enter the type of support you get from your parents");
//             document.getElementById("ContentPlaceHolder1_txtsource").focus();
//             document.getElementById("ContentPlaceHolder1_txtsource").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtsource").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         else 
//         if(document.getElementById("ContentPlaceHolder1_ddl_profile").value=="")
//         {
//             alert("Please enter the type of Enquiry Profile");
//             document.getElementById("ContentPlaceHolder1_ddl_profile").focus();
 //            document.getElementById("ContentPlaceHolder1_ddl_profile").style.border="#ff0000 1px solid";
 //            document.getElementById("ContentPlaceHolder1_ddl_profile").style.backgroundColor="#e8ebd9";
 //            return false;
 //        }
              
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
//           else if(document.getElementById("ContentPlaceHolder1_ddl_finstatus").value=="")
//         {
//             alert("Please Enter your Financial Status ");
//             document.getElementById("ContentPlaceHolder1_ddl_finstatus").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_finstatus").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_finstatus").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//         
//         else if(document.getElementById("ContentPlaceHolder1_ddl_Inv_Possible").value=="")
//         {
//             alert("Please Select your Investment Status ");
//             document.getElementById("ContentPlaceHolder1_ddl_Inv_Possible").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_Inv_Possible").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_Inv_Possible").style.backgroundColor="#e8ebd9";
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
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_txt_dmakername").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_dmakername").value=="";
//             alert("Please Enter the decision maker's name ");
//             document.getElementById("ContentPlaceHolder1_txt_dmakername").focus();
//             document.getElementById("ContentPlaceHolder1_txt_dmakername").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_dmakername").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//           else if(trim(document.getElementById("ContentPlaceHolder1_ddldecision_relation").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_ddldecision_relation").value=="";
//             alert("Please select your Relationship with the Applicant");
//             document.getElementById("ContentPlaceHolder1_ddldecision_relation").focus();
//             document.getElementById("ContentPlaceHolder1_ddldecision_relation").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddldecision_relation").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//          else if(document.getElementById("ContentPlaceHolder1_ddldecision_relation").value=="Others" && document.getElementById("ContentPlaceHolder1_txt_dec_others").value=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txt_dec_others").value=="";
//             alert("Please enter your Relationship with the Applicant");
//             document.getElementById("ContentPlaceHolder1_txt_dec_others").focus();
//             document.getElementById("ContentPlaceHolder1_txt_dec_others").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_dec_others").style.backgroundColor="#e8ebd9";
//             return false;
//         }
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
         if(trim(document.getElementById("ContentPlaceHolder1_txt_counseledtime").value)=="")
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
         else if(document.getElementById("ContentPlaceHolder1_ddl_status").value=="")
         {
             alert("Please Enter the Status of the Enquiry");
             document.getElementById("ContentPlaceHolder1_ddl_status").focus();
             document.getElementById("ContentPlaceHolder1_ddl_status").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_status").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_enrolldate").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").value=="";
             alert("Please Enter the Enrollment date positioned");
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").focus();
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.backgroundColor="#e8ebd9";
             return false;
          }
           else if(csDate < 0)
          {
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").value=="";
             alert("Invalid enrollment date");
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").focus();
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_enrolldate").style.backgroundColor="#e8ebd9";
             return false;
          }
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
  <div class="title-cont">
    <h3 class="cont-title">Walkin Enquiry</h3>
    <div class="breadcrumps">
      <ul>
        <li><a href="enquirytype.aspx">Enquiry</a>/</li>
        <li><a href="#" class="last">Walkin Enquiry</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <div id="tabs">
    <input type="hidden" id="hdnTab" name="hdnTab" value="Admission" />
    <ul>
      <li><a href="#tabs-1"  class="selector">Step1</a></li>
      <li><a href="#tabs-2" >Step2</a></li>
    </ul>
    <div class="clear"></div>
    <div class="white-cont">
      <div id="tabs-1">
        <div class="free-forms">
          <h4 class="cont-title2">Enquiry Form - 1</h4>
          <div class="padd-cont">
            <div class="form-cont">
              <asp:HiddenField ID="Hidnenq_id" runat="server" />
              <ul>
                <li>
                  <label class="label-txt">The Course Enquiry is for<span style="color:Red">*</span></label>
                  <asp:DropDownList ID="ddl_enquiryfor" runat="server" CssClass="select sele-txt" onChange="chkval4()">
                    <asp:ListItem value="">--Select--</asp:ListItem>
                    <asp:ListItem value="Myself">Myself</asp:ListItem>
                    <asp:ListItem value="Daughter">Daughter</asp:ListItem>
                    <asp:ListItem value="Son">Son</asp:ListItem>
                    <asp:ListItem value="Others">Others</asp:ListItem>
                  </asp:DropDownList>
                  <asp:TextBox ID="txtenqothers" runat="server" style="display:none" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">The Main reasons for enquiring about the course</label>
                  <asp:TextBox ID="txtreason" runat="server" MaxLength="100" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">How did you know about IMAGE? <span style="color:Red">*</span></label>
                  <asp:DropDownList ID="ddl_aboutimage" runat="server" CssClass="select sele-txt" onChange="chkvl9()">
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
                  <asp:TextBox ID="txt_abt_image" runat="server" MaxLength="25" CssClass="text input-txt" style="display:none"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Refered Student Name</label>
                  <asp:TextBox ID="txtreferstudentname" runat="server" CssClass="text input-txt" ></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Gender<span style="color:Red">*</span></label>
                  <asp:DropDownList ID="ddl_gender" runat="server" CssClass="select sele-txt" >
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                  </asp:DropDownList>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </div>
          <h4 class="cont-title3">Personal Particulars&nbsp; (Mention the students's details if you are enquiring on his/her behalf):</h4>
          <div class="padd-cont">
            <div class="form-cont2">
              <ul>
                <li>
                  <label class="label-txt">First Name <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtname" MaxLength="30" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Last Name</label>
                  <asp:TextBox ID="txtLname" runat="server" CssClass="text input-txt" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Mobile <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtmobile" onpaste="return false" runat="server" MaxLength="10" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Alternate Mobile</label>
                  <asp:TextBox ID="txtaltmobile" onpaste="return false" CssClass="text input-txt"  runat="server" MaxLength="10" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">E-mail <span style="color:Red">*</span></label>
                  <asp:TextBox MaxLength="40" ID="txtemail" runat="server" CssClass="text input-txt"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Phone(Res)</label>
                  <asp:TextBox ID="txtphone" onpaste="return false" runat="server" MaxLength="11"  CssClass="text input-txt" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Date of Birth <span style="color:Red">*</span></label>
                  <span class="date-pick-cont">
                  <asp:TextBox ID="txtdob" runat="server" onKeyPress="return false"  onpaste="return false" CssClass="text datepicker date-input-txt"></asp:TextBox>
                  </span> </li>
                <li>
                  <label class="label-txt">Blood Group</label>
                  <asp:DropDownList ID="ddl_bloodgroup" runat="server" CssClass="select sele-txt" >
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
                  </asp:DropDownList>
                </li>
                <li>
                  <label class="label-txt">Martial Status</label>
                  <asp:DropDownList ID="ddl_maritalstatus" runat="server" CssClass="select sele-txt" >
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Single">Single</asp:ListItem>
                    <asp:ListItem Value="Married">Married</asp:ListItem>
                  </asp:DropDownList>
                </li>
                <li>
                  <label class="label-txt">Mother Tongue</label>
                  <asp:TextBox ID="txt_mothertongue" runat="server" CssClass="text input-txt" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Nationality</label>
                  <asp:TextBox ID="txt_Nationality1" runat="server" CssClass="text input-txt" MaxLength="40" onkeypress="return AllowAlphabet(event)" Visible="False"></asp:TextBox>
                  <asp:DropDownList ID="txt_Nationality" runat="server" CssClass="select sele-txt" >
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Indian</asp:ListItem>
                    <asp:ListItem>NRI</asp:ListItem>
                  </asp:DropDownList>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </div>
          <h4 class="cont-title3">Present Address </h4>
          <div class="padd-cont">
            <div class="form-cont2">
              <ul>
                <li>
                  <label class="label-txt">Address <span style="color:Red">*</span></label>
                  <asp:TextBox MaxLength="100" ID="txtpresentaddress" runat="server" CssClass="text area-txt" Height="51px" TextMode="MultiLine"  ></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">District/Taluk/Place <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpresentdistrict" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">City <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpresentcity" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">State <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpresentstate" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Pincode <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpresentpincode" onKeyPress="return CheckNumeric(event)" onpaste="return false"  MaxLength="6" runat="server" CssClass="text input-txt"></asp:TextBox>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </div>
          <h4 class="cont-title3"> Permanent Address&nbsp; (Please check if the address is same as above)
            <input type="checkbox" ID="CheckBox1"   onclick="checkaddress()" runat="server" />
          </h4>
          <div class="padd-cont">
            <div class="form-cont2">
              <ul>
                <li>
                  <label class="label-txt">Address <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpermanentaddress" MaxLength="100" runat="server" CssClass="text area-txt" Height="57px" TextMode="MultiLine" ></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">District/Taluk /Place <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpermanentdistrict" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">City <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpermanentcity" runat="server" MaxLength="50" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">State <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpermanentstate" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Pincode <span style="color:Red">*</span></label>
                  <asp:TextBox ID="txtpermanentpincode" onKeyPress="return CheckNumeric(event)" MaxLength="6" runat="server" CssClass="text input-txt"></asp:TextBox>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </div>
          <h4 class="cont-title3">Highest Qualification details </h4>
          <div class="padd-cont">
            <div class="form-cont2">
              <ul>
                <li>
                  <label class="label-txt">Qualification <span style="color:Red"></span></label>
                  <asp:TextBox ID="txtqualification" MaxLength="50" runat="server" CssClass="text input-txt"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Core Sub</label>
                  <asp:TextBox ID="txtmainsub" MaxLength="75" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Name of the School/College</label>
                  <asp:TextBox ID="txtschoolcolname" MaxLength="75" runat="server" CssClass="text input-txt" ></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">City</label>
                  <asp:TextBox ID="txtcity" runat="server" MaxLength="50" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">State</label>
                  <asp:TextBox ID="txtstate" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Completion status</label>
                  <asp:DropDownList ID="ddl_completionstatus" runat="server" CssClass="select sele-txt">
                    <asp:ListItem value="">--Select--</asp:ListItem>
                    <asp:ListItem value="Completed">Completed</asp:ListItem>
                    <asp:ListItem value="Pursuing">Pursuing</asp:ListItem>
                    <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
                  </asp:DropDownList>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </div>
          <h4 class="cont-title3">Education in Animation and Graphics (Optional) </h4>
          <div class="padd-cont">
            <div class="form-cont2">
              <ul>
                <li>
                  <label class="label-txt">Completion status</label>
                  <asp:DropDownList ID="ddl_animationstatus" runat="server" CssClass="select sele-txt" onChange="chkval5()">
                    <asp:ListItem value="">--Select--</asp:ListItem>
                    <asp:ListItem value="Completed">Completed</asp:ListItem>
                    <asp:ListItem value="Pursuing">Pursuing</asp:ListItem>
                    <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
                    <asp:ListItem value="NotStudied">Not Studied</asp:ListItem>
                  </asp:DropDownList>
                </li>
                <li>
                  <label class="label-txt">Branch</label>
                  <asp:TextBox ID="txtbranch" MaxLength="40" runat="server" CssClass="text input-txt" onFocus="losefocus2(this)"></asp:TextBox>
                </li>
                <li>
                  <label class="label-txt">Institute</label>
                  <asp:TextBox ID="txtinstitute" MaxLength="40" runat="server" CssClass="text input-txt" onFocus="losefocus2(this)"></asp:TextBox>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
          </div>
          <div class="form-cont">
            <ul>
              <li>
                <div style="text-align:center; padding:0px 0px 25px 0px;">
                  <input id="nextstep" type="button" value="Next Step" class="btnStyle1" onclick="return nextstep_onclick()"  />
                  <input id="Reset1" type="reset" value="Reset" title="Reset" class="reset-btn" />
                </div>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
        </div>
      </div>
      <div id="tabs-2">
        <div class="free-forms">
          <form id="TABLE1">
            <div class="free-forms">
              <h4 class="cont-title2">Enquiry Form - 2</h4>
            </div>
            <h4 class="cont-title3">Parent/Guardian's Particulars</h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Parent/Guardian's Name <span style="color: #ff0000"></span></label>
                    <asp:TextBox ID="txtparentname" MaxLength="50" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Relationship with Applicant </label>
                    <asp:TextBox ID="txtrelationothers" runat="server" CssClass="text input-txt" style="display:none;" MaxLength="50"></asp:TextBox>
                    <asp:DropDownList ID="txtparentrelation" runat="server" CssClass="select sele-txt"  onChange="chkval3();" >
                      <asp:ListItem Value="">--Select---</asp:ListItem>
                      <asp:ListItem Value="Parent">Parent</asp:ListItem>
                      <asp:ListItem Value="Guardian">Guardian</asp:ListItem>
                      <asp:ListItem Value="Friend">Friend</asp:ListItem>
                      <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                  <li>
                    <label class="label-txt">Mobile </label>
                    <asp:TextBox ID="txtparentmobile" onpaste="return false" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="10"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Phone(Office)</label>
                    <asp:TextBox ID="txtparentphnumber" onpaste="return false" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text input-txt" MaxLength="11"></asp:TextBox >
                  </li>
                  <li>
                    <label class="label-txt">E-mail</label>
                    <asp:TextBox ID="txtparentemail" MaxLength="40" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
            <h4 class="cont-title3"> Professional Details of Parent /Guardian&nbsp; (Optional)</h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Company </label>
                    <asp:TextBox ID="txtparent_cmp" MaxLength="75" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Designation</label>
                    <asp:TextBox ID="txtparent_designation" MaxLength="75" runat="server" CssClass="text input-txt" ></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Type of Industry</label>
                    <asp:TextBox ID="txtparent_typeofindustry" MaxLength="75" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Employment status</label>
                    <asp:DropDownList ID="ddl_employementstatus" runat="server" CssClass="select sele-txt" >
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="In Service">In Service</asp:ListItem>
                      <asp:ListItem Value="Retired">Retired</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                  <li>
                    <label class="label-txt">Place of work</label>
                    <asp:TextBox ID="txtparent_placeofwork" MaxLength="50" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Monthly Income</label>
                    <asp:TextBox ID="txtparent_monthlyincome" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="7" runat="server" CssClass="text input-txt" ></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Proprietorship/Partnership(if Self Employed)</label>
                    <asp:TextBox ID="txtselfemployed" runat="server" MaxLength="50" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li style="height:40px;">&nbsp;</li>
                  <li>
                    <label class="label-txt">Support of Parents</label>
                    <asp:DropDownList ID="ddl_support" runat="server" CssClass="select sele-txt">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="Very High">Very High</asp:ListItem>
                      <asp:ListItem Value="Good">Good</asp:ListItem>
                      <asp:ListItem Value="Average">Average</asp:ListItem>
                      <asp:ListItem Value="Low">Low</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2" id="coursevis" visible="false" runat="server">
                <ul>
                  <li>
                    <label class="label-txt">Source (As per the detailed discussion with the enquiry)</label>
                    <asp:DropDownList ID="ddl_source" runat="server" CssClass="select sele-txt" onChange="chkval1()">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="Main Source">Main Source</asp:ListItem>
                      <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtsource" CssClass="text input-txt" style="display:none" MaxLength="50" runat="server"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Enquiry Profile</label>
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
                  <li style="height:40px;">&nbsp;</li>
                  <li>
                    <label class="label-txt">Requirements of the enquiry</label>
                    <asp:TextBox ID="txtrequirements" MaxLength="50" runat="server" TextMode="MultiLine" CssClass="text area-txt"></asp:TextBox>
                  </li>
                  <li style="height:56px;">&nbsp;</li>
                  <li>
                    <label class="label-txt">Questions raised by the enquiry</label>
                    <asp:TextBox ID="txtquestions" MaxLength="100" runat="server" TextMode="MultiLine" CssClass="text area-txt"></asp:TextBox>
                  </li>
                  <li style="height:40px;">&nbsp;</li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
            <h4 class="cont-title3"> Competitors Visited (Optional)</h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Brand</label>
                    <asp:TextBox ID="txtbrand" MaxLength="20" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Location</label>
                    <asp:TextBox ID="txtlocation" MaxLength="20" runat="server" CssClass="text input-txt" ></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Positive</label>
                    <asp:TextBox ID="txtpositive" runat="server" MaxLength="50" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Negative</label>
                    <asp:TextBox ID="txtnegative" runat="server" MaxLength="50" CssClass="text input-txt" ></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
            <h4 class="cont-title3"> Financial Details</h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Financial Status</label>
                    <asp:DropDownList ID="ddl_finstatus" runat="server" CssClass="select sele-txt">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="Very Good">Very Good</asp:ListItem>
                      <asp:ListItem Value="Good">Good</asp:ListItem>
                      <asp:ListItem Value="Average">Average</asp:ListItem>
                      <asp:ListItem Value="Bad">Bad</asp:ListItem>
                      <asp:ListItem Value="Very Bad">Very Bad</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                  <li>
                    <label class="label-txt">Investment possible</label>
                    <asp:TextBox ID="txtmininvestment" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="15" runat="server" CssClass="text input-txt" Visible="False"></asp:TextBox>
                    <asp:DropDownList ID="ddl_Inv_Possible" runat="server" CssClass="select sele-txt">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="Rs.25,000 to 50,000">Rs.25,000 to 50,000</asp:ListItem>
                      <asp:ListItem Value="Rs.50,000 to 75,000">Rs.50,000 to 75,000</asp:ListItem>
                      <asp:ListItem Value="Rs.75,000 to 1,00,000">Rs.75,000 to 1,00,000</asp:ListItem>
                      <asp:ListItem Value="Above 1,00,000">Above 1,00,000</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                  <li>
                    <asp:TextBox ID="txtmaxinvestment" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="15" runat="server" CssClass="text input-txt" Visible="False" ></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2" id="enqplan" runat="server" visible="false">
                <ul>
                  <li>
                    <label class="label-txt">How has the enquiry planned to arrange the funds required for the course</label>
                    <asp:TextBox ID="txtarrangefund" MaxLength="50" CssClass="text input-txt" runat="server" TextMode="MultiLine"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2" id="interestvis" runat="server" visible="false">
                <ul>
                  <li>
                    <label>Interest level</label>
                    <asp:DropDownList ID="ddl_interestlevel" runat="server" CssClass="select sele-txt">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="Very High">Very High</asp:ListItem>
                      <asp:ListItem Value="Good">Good</asp:ListItem>
                      <asp:ListItem Value="Average">Average</asp:ListItem>
                      <asp:ListItem Value="Low">Low</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2" id="enqwho" runat="server" visible="false">
                <ul>
                  <li>
                    <label>Who all attended the counseling?</label>
                    <asp:TextBox ID="txtwhoallattended" runat="server" MaxLength="70" TextMode="MultiLine" CssClass="text input-txt"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
            <h4 class="cont-title3"> Decision Makers </h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Name</label>
                    <asp:TextBox ID="txt_dmakername" MaxLength="20" runat="server" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Contact details</label>
                    <asp:TextBox ID="txt_dmakercontactdetails" MaxLength="40" runat="server"  CssClass="text input-txt"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Relationship</label>
                    <asp:TextBox ID="txt_dmakerrelationship" MaxLength="20" Visible="false" runat="server" CssClass="text input-txt" ReadOnly="True"></asp:TextBox>
                    <asp:DropDownList ID="ddldecision_relation" runat="server" CssClass="select sele-txt"  onChange="chkvalR3();">
                      <asp:ListItem Value="">--Select---</asp:ListItem>
                      <asp:ListItem Value="Parent">Parent</asp:ListItem>
                      <asp:ListItem Value="Guardian">Guardian</asp:ListItem>
                      <asp:ListItem Value="Friend">Friend</asp:ListItem>
                      <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                  <li>
                    <asp:TextBox ID="txt_dec_others" runat="server" CssClass="text input-txt" MaxLength="50" Style="display: none" ></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
            <h4 class="cont-title3">Whether enquiry was referred by someone (Optional) </h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Name</label>
                    <asp:TextBox ID="txt_referrername" runat="server" MaxLength="50" CssClass="text input-txt"></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">Contact details</label>
                    <asp:TextBox ID="txt_referrercontactdetails" MaxLength="40" runat="server" CssClass="text input-txt" ></asp:TextBox>
                  </li>
                  <li>
                    <label class="label-txt">How did he know Image</label>
                    <asp:DropDownList ID="txt_knowsimage" runat="server" CssClass="select sele-txt" onChange="chkval2();">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
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
                    <asp:TextBox ID="txtothersrefer" style="display:none" runat="server" CssClass="text input-txt" ></asp:TextBox>
                    <asp:DropDownList ID="ddl_Centre" style="display:none" runat="server"> </asp:DropDownList>
                    <asp:TextBox ID="txtReferalstudentid" style="display:none" runat="server" MaxLength="50"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
            <h4 class="cont-title3">Enquiry Status</h4>
            <div class="padd-cont">
              <div class="form-cont2">
                <ul>
                  <li>
                    <label class="label-txt">Counseled time <span style="color:Red">*</span></label>
                    <asp:DropDownList ID="txt_counseledtime" runat="server" CssClass="select sele-txt">
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
                  </li>
                  <li>
                    <label class="label-txt">Expected Date of Enrollment <span style="color: #ff0000">*</span></label>
                    <span class="date-pick-cont">
                    <asp:TextBox ID="txt_enrolldate" onpaste="return false" onKeyPress="return false" runat="server" CssClass="text datepicker date-input-txt" ></asp:TextBox>
                    </span> </li>
                  <li>
                    <label class="label-txt">Course Asked <span style="color:Red">*</span></label>
                    <asp:DropDownList ID="txt_courseasked" runat="server" CssClass="select sele-txt"> </asp:DropDownList>
                  </li>
                  <li>
                    <label class="label-txt">Course Positioned <span style="color:Red">*</span></label>
                    <asp:DropDownList ID="txt_coursepositioned" runat="server" CssClass="select sele-txt"> </asp:DropDownList>
                  </li>
                  <li>
                    <label class="label-txt">Status <span style="color:Red">*</span></label>
                    <asp:DropDownList ID="ddl_status" runat="server" CssClass="select sele-txt">
                      <asp:ListItem Value="">--Select--</asp:ListItem>
                      <asp:ListItem Value="Spot enrolled">Spot enrolled</asp:ListItem>
                      <asp:ListItem Value="Very propective">Very prospective</asp:ListItem>
                      <asp:ListItem Value="Propective">Prospective</asp:ListItem>
                      <asp:ListItem Value="Not propective">Not prospective</asp:ListItem>
                      <asp:ListItem Value="Fake">Fake</asp:ListItem>
                      <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
                      <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>
                    </asp:DropDownList>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2" id="enqaction" visible="false" runat="server">
                <ul>
                  <li>
                    <label class="label-txt">Enquiry's action plan</label>
                    <asp:TextBox ID="txt_actionplan" runat="server" MaxLength="40" CssClass="text input-txt"></asp:TextBox>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont2" id="enqsubmit" visible="false" runat="server">
                <ul>
                  <li>
                    <label class="label-txt">Are you sure of submitting the form?</label>
                    <asp:CheckBox ID="checkfields" runat="server" />
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
              <div class="form-cont">
                <ul>
                  <li>
                    <asp:Label ID="lblalertmsg" runat="server" ForeColor="red" ></asp:Label>
                  </li>
                  <li>
                    <div align="center">
                      <asp:Button ID="btnsubmit5" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return enquiryform2();"  OnClick="btnsubmit5_Click"/>
                      <input id="Reset2" type="reset" value="Reset"  title="Reset" class="reset-btn" onclick="return Reset2_onclick()" />
                      <asp:HiddenField ID="hdntempID" runat="server" />
                    </div>
                  </li>
                </ul>
                <div class="clear"></div>
              </div>
            </div>
          </form>
        </div>
        <div>
          <input id="hdncou_id" runat="server" name="hdncou_id" type="hidden" />
          <input id="Hidden1" name="hdnTab" type="hidden" value="Admission" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>
