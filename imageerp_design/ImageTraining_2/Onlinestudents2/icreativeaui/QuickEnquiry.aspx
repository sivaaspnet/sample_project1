<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="QuickEnquiry.aspx.cs" Inherits="superadmin_AddEnquiry" Title="Add Enquiry" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<script language="javascript" type="text/javascript">
  function checkaddress1()
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
//         else if(trim(document.getElementById("ContentPlaceHolder1_txtLname").value)=="")
//         {
//             
//             document.getElementById("ContentPlaceHolder1_txtLname").value=="";
//             alert("Please Enter student last name ");
//             document.getElementById("ContentPlaceHolder1_txtLname").focus();
//             document.getElementById("ContentPlaceHolder1_txtLname").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtLname").style.backgroundColor="#e8ebd9";
//             return false;
//         }
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
//         

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

//           else 
           
           if(trim(document.getElementById("ContentPlaceHolder1_txt_counseledtime").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").value=="";
             alert("Please Enter the Counseled Time");
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").focus();
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_counseledtime").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else if(trim(document.getElementById("ContentPlaceHolder1_ddl_profile").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_ddl_profile").value=="";
             alert("Please select the profile");
             document.getElementById("ContentPlaceHolder1_ddl_profile").focus();
             document.getElementById("ContentPlaceHolder1_ddl_profile").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_profile").style.backgroundColor="#e8ebd9";
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

         
         else
         {
         return true;
         }
         
     }


function Reset2_onclick() {
location.href="quickEnquiry.aspx";
}

function TABLE1_onclick() {

}






///////////////////////////////////////////////////////////////

function emptyValidation(fieldList)
 {
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	var cc="";
	for(i=0;i<field.length;i++)
        {
		    if(trim(document.getElementById(field[i]).value)=="")
              {
                document.getElementById(field[i]).focus();
			    document.getElementById(field[i]).style.border="#FF0000 1px solid";
			     document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
			    counter++;
			    if(cc == "") {
			        cc = field[i];
			    }
	          } 
              else 
              {
	            document.getElementById(field[i]).style.border="#EFEFEF";	
			    document.getElementById(field[i]).style.backgroundColor="#FFFFFF";	
	          }
	    }
	if(counter>0)
        {
		alert('Please populate the required/highlighted fields.');
        if(cc!="")
         {
        document.getElementById(cc).focus();
         }
		return false;				
	}  
      else{ return true; }				
}


function checkval()
{
if(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value=="")
  {
     alert("Please mention initial amount");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
     else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML)))
  {
     alert("Initial amount is greater than the course fee");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == ""))
  {
     alert("Please mention the no of installments"); 
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9";
     return false;
  }
   else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') &&  (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)))
    {
        alert(" Please enter less than or equal to (maximum number of installments)");
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").value=="";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9"
        return false;
    }
  else
  {
   //amt_ex_initial=parseInt(document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-parseInt(document.getElementById("txt_lumpinitial").value);
  //alert(document.getElementById("ContentPlaceHolder1_lbllumpamt").value);
  //alert(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value);
  amt_ex_initial=parseInt((document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value));
  //alert(amt_ex_initial);
  //double amt_ex_initial = Convert.ToDouble(lbllumpamt.Value) - Convert.ToDouble(txt_lumpinitial.Text);
        noofinstallments = document.getElementById("ContentPlaceHolder1_txt_instalamt1").value;
        //alert(noofinstallments);
        monthlyinstall = amt_ex_initial / noofinstallments;
        //txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
        //alert(monthlyinstall);
        document.getElementById("ContentPlaceHolder1_txtamtmonthly").value=Math.round(monthlyinstall, 0);
        return false;
  }
}

 
	


   //form1
function admissionform()
{ 
   
    return true;
    
} 
//form1
 function checkaddress()
  {
   if(document.getElementById("ContentPlaceHolder1_CheckBox1").checked==true)
   {
       document.getElementById("ContentPlaceHolder1_txt_permanentaddress").value=document.getElementById("ContentPlaceHolder1_txt_presentaddress").value;
       document.getElementById("ContentPlaceHolder1_txt_permanentstate").value=document.getElementById("ContentPlaceHolder1_txt_presentstate").value;
       document.getElementById("ContentPlaceHolder1_txt_permanentdistrict").value=document.getElementById("ContentPlaceHolder1_txt_presentdistrict").value;
       document.getElementById("ContentPlaceHolder1_txt_permanentpin").value=document.getElementById("ContentPlaceHolder1_txt_presentpin").value;
        document.getElementById("ContentPlaceHolder1_txt_permanentphone").value=document.getElementById("ContentPlaceHolder1_txt_presentphone").value;
  
   }
   else if(document.getElementById("ContentPlaceHolder1_CheckBox1").checked==false)
   {
       document.getElementById("ContentPlaceHolder1_txt_permanentaddress").value="";
       document.getElementById("ContentPlaceHolder1_txt_permanentstate").value="";
       document.getElementById("ContentPlaceHolder1_txt_permanentdistrict").value="";
       document.getElementById("ContentPlaceHolder1_txt_permanentpin").value="";
        document.getElementById("ContentPlaceHolder1_txt_permanentphone").value="";
       
   } 
  }
 function display()
     {
		 if(document.getElementById("ContentPlaceHolder1_ddl_payment").value=="Lump sum") 
			{
				document.getElementById("lump1").style.display='block';
				document.getElementById("lump2").style.display='none';
				document.getElementById("lump3").style.display='block';
				document.getElementById("lump4").style.display='none';
			}
			else  if(document.getElementById("ContentPlaceHolder1_ddl_payment").value=="Installment") 
		
			{
				document.getElementById("lump1").style.display='block';
				document.getElementById("lump2").style.display='block';
				document.getElementById("lump3").style.display='block';
				document.getElementById("lump4").style.display='block';
			}
			else
             {
                document.getElementById("lump1").style.display='none';
				document.getElementById("lump2").style.display='none';
                document.getElementById("lump3").style.display='none';
				document.getElementById("lump4").style.display='none';
              }
     }
     
     //form2
 function validstudy() 
 {
 
  
  
	
   
     return true;
     
}




//form3
 function losefocus1(obj)
    {
         if(document.getElementById("ContentPlaceHolder1_ddl_phydefect").value!="Yes")
         {
          obj.value="";
          obj.blur()
         }
    }
    //form3
function chkval1()
   {
          if(document.getElementById("ContentPlaceHolder1_ddl_phydefect").value!="Yes")
           {
            document.getElementById("ContentPlaceHolder1_txt_defectYes").value=""
           }
   }
//form3
function losefocuscash(obj)
    {
    
      if(document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value=='Cash')
         {
        
          obj.value="";
          obj.blur()
         }
   
    }
    function cashval()
   {

   if(document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value=='Cash')
          {
            document.getElementById("ContentPlaceHolder1_txtchequeno").value=""
            document.getElementById("ContentPlaceHolder1_txtbankname").value=""
          }
       
   }

//form3
function admform3()
{

document.getElementById("ContentPlaceHolder1_hdncou_id").value=document.getElementById("ContentPlaceHolder1_txt_coursenamee").value;
     var d = new Date();
     var curr_date = d.getDate();
     var curr_month = d.getMonth()+1;
     var curr_year = d.getFullYear();
     

   var courserecommend1='ContentPlaceHolder1_txtname_person1~ContentPlaceHolder1_txt_industry1~ContentPlaceHolder1_txt_org1~ContentPlaceHolder1_txt_desig1~ContentPlaceHolder1_txt_contactno1';
   var courserecommend2='ContentPlaceHolder1_txtname_person2~ContentPlaceHolder1_txt_industry2~ContentPlaceHolder1_txt_org2~ContentPlaceHolder1_txt_desig2~ContentPlaceHolder1_txt_contactno2';
   var mediaindus1='ContentPlaceHolder1_txtwhomknow1~ContentPlaceHolder1_txtcompinst1~ContentPlaceHolder1_txtdesig1~ContentPlaceHolder1_txtcontactno1';
   var mediaindus2='ContentPlaceHolder1_txtwhomknow2~ContentPlaceHolder1_txtcompinst2~ContentPlaceHolder1_txtdesig2~ContentPlaceHolder1_txtcontactno2';
   
    
    clearValidation(courserecommend1+'~'+courserecommend2+'~'+mediaindus1+'~'+mediaindus2);
	var f7=courserecommend1.split("~");
	var f8=courserecommend2.split("~");
	var f9=mediaindus1.split("~");
	var f10=mediaindus2.split("~");
	clearValidation('ContentPlaceHolder1_txt_countryofresi~ContentPlaceHolder1_txt_passportnum~ContentPlaceHolder1_txt_placeofiisue');
  if(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value=="")
  {
     alert("Please enter course name");
     document.getElementById("ContentPlaceHolder1_txt_coursenamee").focus();
     document.getElementById("ContentPlaceHolder1_txt_coursenamee").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_coursenamee").style.backgroundColor="#e8ebd9";
     return false;
  }
   else if(document.getElementById("ContentPlaceHolder1_ddl_payment").value == "")
  {
     alert("Please mention pattern of payment"); 
     document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
     document.getElementById("ContentPlaceHolder1_ddl_payment").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_ddl_payment").style.backgroundColor="#e8ebd9";
     return false;
  }
  else if(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value=="")
  {
     alert("Please mention initial amount");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
     else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML)))
  {
     alert("Initial amount is greater than the course fee");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
  else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == ""))
  {
     alert("Please mention the no of installments"); 
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9";
     return false;
  }
   else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') &&  (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)))
    {
        alert(" Please enter less than or equal to (maximum number of installments)");
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").value=="";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9"
        return false;
    }
   else if(document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value != 'Cash' && document.getElementById("ContentPlaceHolder1_txtchequeno").value=="")
  {
     alert("Please mention Cheque/D.D/Creditcard Details");
     document.getElementById("ContentPlaceHolder1_txtchequeno").focus();
     document.getElementById("ContentPlaceHolder1_txtchequeno").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtchequeno").style.backgroundColor="#e8ebd9";
     return false;
  }
   else if(document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value != 'Cash' && document.getElementById("ContentPlaceHolder1_txtbankname").value=="")
  {
     alert("Please mention the Bank Name");
     document.getElementById("ContentPlaceHolder1_txtbankname").focus();
     document.getElementById("ContentPlaceHolder1_txtbankname").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtbankname").style.backgroundColor="#e8ebd9";
     return false;
  }
  else if(document.getElementById("ContentPlaceHolder1_radiobtnindia1").checked == false && document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == false)
   {
      document.getElementById("ContentPlaceHolder1_radiobtnindia1").value=="";   
      alert("Please select the student type");
      document.getElementById("ContentPlaceHolder1_radiobtnindia1").focus();
      document.getElementById("ContentPlaceHolder1_radiobtnindia1").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_radiobtnindia1").style.backgroundColor="#e8ebd9";
      return false;
    }
     else if(document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == true && document.getElementById("ContentPlaceHolder1_txt_countryofresi").value == "")
   {
      alert("Enter Your country of residence");
      document.getElementById("ContentPlaceHolder1_txt_countryofresi").focus();
      document.getElementById("ContentPlaceHolder1_txt_countryofresi").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_txt_countryofresi").style.backgroundColor="#e8ebd9";
      return false;
    } 
     else if(document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == true && document.getElementById("ContentPlaceHolder1_txt_passportnum").value == "")
   {
      alert("Enter your passport number");
      document.getElementById("ContentPlaceHolder1_txt_passportnum").focus();
      document.getElementById("ContentPlaceHolder1_txt_passportnum").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_txt_passportnum").style.backgroundColor="#e8ebd9";
      return false;
    } 
       else if(document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == true && document.getElementById("ContentPlaceHolder1_txt_placeofiisue").value == "")
   {
      alert("Enter specify place of issue of passport");
      document.getElementById("ContentPlaceHolder1_txt_placeofiisue").focus();
      document.getElementById("ContentPlaceHolder1_txt_placeofiisue").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_txt_placeofiisue").style.backgroundColor="#e8ebd9";
      return false;
    } 
    
    else
    {
    return true;
    }
    
 
}
function studtype()
{
   if(document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == true)
   {
   document.getElementById("ContentPlaceHolder1_txt_countryofresi").style.display=''; 
   document.getElementById("ContentPlaceHolder1_txt_passportnum").style.display=''; 
   document.getElementById("ContentPlaceHolder1_txt_placeofiisue").style.display='';  
   document.getElementById("ContentPlaceHolder1_lblcountry").style.display=''; 
   document.getElementById("ContentPlaceHolder1_lblpassport").style.display=''; 
   document.getElementById("ContentPlaceHolder1_lblplace").style.display=''; 
   }
    else if(document.getElementById("ContentPlaceHolder1_radiobtnindia1").checked == true)
   {
   document.getElementById("ContentPlaceHolder1_txt_countryofresi").style.display='none'; 
   document.getElementById("ContentPlaceHolder1_txt_passportnum").style.display='none'; 
   document.getElementById("ContentPlaceHolder1_txt_placeofiisue").style.display='none'; 
   document.getElementById("ContentPlaceHolder1_lblcountry").style.display='none'; 
   document.getElementById("ContentPlaceHolder1_lblpassport").style.display='none'; 
   document.getElementById("ContentPlaceHolder1_lblplace").style.display='none'; 
   }
 
}
function setFees(programId,feesType)
{
    var res=0;
    var i;
    for(i=0;i<courseFees.length;i++)
    {
        if(parseInt(courseFees[i]["program"]) == parseInt(programId))
        {
            if(feesType=="Lump sum")
            {
                document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFees[i]["lump_sum"];
                document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFees[i]["lump_sum"];
                document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFees[i]["lump_sum"];
             }
            else if(feesType=="Installment")
            {
               document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFees[i]["instal_amount"];   
               document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFees[i]["instal_amount"]; 
               document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFees[i]["instal_amount"];    
            }
            else
            {
            document.getElementById("ContentPlaceHolder1_txt_lumpamt").InnerHtml = "0";
            document.getElementById("ContentPlaceHolder1_lbllumpamt").value= "0";
            }            
        }        
    }
    return res;    
}

function setFees(programId,feesType,track)
{
    var res=0;
    var i;
    var inset=0; 
    if(track=="fast")
    {
        var arraylength=courseFeesfast.length; 
        for(i=0;i<arraylength;i++)
        {
            if(parseInt(courseFeesfast[i]["program"]) == parseInt(programId))
            {
                if(feesType=="Lump sum")
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFeesfast[i]["lump_sum"];
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFeesfast[i]["lump_sum"];
                    document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFeesfast[i]["lump_sum"];
                    document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesfast[i]["noofinstall"];
                }
                else if(feesType=="Installment")
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFeesfast[i]["instal_amount"];   
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFeesfast[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFeesfast[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesfast[i]["noofinstall"];
                    if(inset==0)
                    {
                        createInstallmentNumbers(courseFeesfast[i]["noofinstall"]);
                        inset=1;
                    }
                }
                else
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").InnerHtml = "0";
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value= "0";
                }
            }
        }
    }
    else if(track=="normal")
    {
        var arraylength=courseFeesnormal.length; 
        for(i=0;i<arraylength;i++)
        {
            if(parseInt(courseFeesnormal[i]["program"]) == parseInt(programId))
            {
                if(feesType=="Lump sum")
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFeesnormal[i]["lump_sum"];
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFeesnormal[i]["lump_sum"];
                    document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFeesnormal[i]["lump_sum"];
                    document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesnormal[i]["noofinstall"];
                }
                else if(feesType=="Installment")
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFeesnormal[i]["instal_amount"];   
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFeesnormal[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFeesnormal[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesnormal[i]["noofinstall"];
                    if(inset==0)
                    {
                        createInstallmentNumbers(courseFeesnormal[i]["noofinstall"]);
                        inset=1;
                    }
                }
                else
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").InnerHtml = "0";
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value= "0";
                }
            }
        }
    }      
    return res;    
}
 function setFees1()
 {
 //alert(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value);
    document.getElementById("ContentPlaceHolder1_hdncou_id").value=document.getElementById("ContentPlaceHolder1_txt_coursenamee").value;
    var programFees=setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value,document.getElementById("ContentPlaceHolder1_ddl_payment").value,document.getElementById("ContentPlaceHolder1_ddtrack").value.toLowerCase());
 }   
 
 function changepayment()
 {
 //alert(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value);
 if(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value=="")
 {
  document.getElementById("ContentPlaceHolder1_ddl_payment").style.display=''; 
  document.getElementById("ContentPlaceHolder1_Label1").style.display='none'; 
 document.getElementById("ContentPlaceHolder1_ddl_payment").value="";
 document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
 display();
 }
 else if(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value=="65")
 {
 //alert("True");
  document.getElementById("ContentPlaceHolder1_ddl_payment").style.display='none'; 
 document.getElementById("ContentPlaceHolder1_ddl_payment").value="Lump sum";
 document.getElementById("ContentPlaceHolder1_Label1").style.display=''; 
 //document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
document.getElementById("lump1").style.display='block';
document.getElementById("lump2").style.display='none';
document.getElementById("lump3").style.display='block';
document.getElementById("lump4").style.display='none'; 
 var programFees=setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value,"Lump sum",document.getElementById("ContentPlaceHolder1_ddtrack").value.toLowerCase());
 }
 else
 {
 document.getElementById("ContentPlaceHolder1_ddl_payment").style.display=''; 
document.getElementById("lump1").style.display='none';
document.getElementById("lump2").style.display='none';
document.getElementById("lump3").style.display='none'; 
document.getElementById("lump4").style.display='none'; 
document.getElementById("ContentPlaceHolder1_Label1").style.display='none'; 
 document.getElementById("ContentPlaceHolder1_ddl_payment").value="";
 document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
 }
 }
     
     function addOption(text,value)
{
	
	var txt=document.getElementById("ContentPlaceHolder1_txt_coursenamee");
	var optn = document.createElement("OPTION");
	optn.text = text;
	optn.value = value;
	txt.options.add(optn);
}


     function clearDropDownList()
{
	var selectbox=document.getElementById("ContentPlaceHolder1_txt_coursenamee");
	var numberOfOptions = selectbox.options.length  
	for (i=0; i<numberOfOptions; i++) 
	{  
		selectbox.remove(0)  
	}  
}
 function SetDetails()
{
//var val=document.getElementById("ContentPlaceHolder1_ddtrack").value ;

var j;
clearDropDownList()
addOption("Select","")
         for(j=0;j<coursetrack.length;j++)
            {
            
//               if((coursetrack[j]['track'])==val)
//               {
              
                  addOption(coursetrack[j]['coursename'],coursetrack[j]['course_id'])
                 
              
               //}
            }
}    
     










</script>


<div class="title-cont">
    <h3 class="cont-title">Way To Enroll</h3>
  </div>
  <div id="tabs">
    <input type="hidden" id="hdnTab" name="hdnTab" value="Admission" />
    <ul>
      <li><a href="#tabs-1"  class="selector">Step1</a></li>
      <li><a href="#tabs-2" >Step2</a></li>
      <li><a href="#tabs-3" >Step3</a></li>
      <li><a href="#tabs-4" >Step4</a></li>
      <li><a href="#tabs-5" >Step5</a></li>
    </ul>
    <div class="clear"></div>
    <div class="white-cont">
      <div id="tabs-1">
        <div class="free-forms">
          <h4 class="cont-title2">Enquiry Form - 1</h4>
          <div class="padd-cont form-cont2">
            <asp:HiddenField ID="Hidnenq_id" runat="server" />
            <ul>
              <li>
                <label class="label-txt"> The Course Enquiry is for <span style="color:Red">*</span></label>
                <asp:DropDownList ID="ddl_enquiryfor" runat="server" CssClass="sele-txt" onChange="chkval4()">
                  <asp:ListItem value="">--Select--</asp:ListItem>
                  <asp:ListItem value="Myself">Myself</asp:ListItem>
                  <asp:ListItem value="Daughter">Daughter</asp:ListItem>
                  <asp:ListItem value="Son">Son</asp:ListItem>
                  <asp:ListItem value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtenqothers" runat="server" style="display:none" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> The Main reasons for enquiring about the course</label>
                <asp:TextBox ID="txtreason" runat="server" MaxLength="100" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> How did you know about IMAGE ?<span style="color:Red">*</span></label>
                <asp:DropDownList ID="ddl_aboutimage" runat="server" CssClass="sele-txt" onChange="chkvl9()">
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
                <label class="label-txt"> Gender <span style="color:Red">*</span></label>
                <asp:DropDownList ID="ddl_gender" runat="server" CssClass="sele-txt" >
                  <asp:ListItem>--Select--</asp:ListItem>
                  <asp:ListItem Value="Male">Male</asp:ListItem>
                  <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <div class="padd-cont form-cont2">
            <h4 class="cont-title3"> Personal Particulars (Mention the students's details if you are enquiring on his/her
              behalf)</h4>
            <ul>
              <li>
                <label class="label-txt"> First Name <span style="color:Red">*</span></label>
                <asp:TextBox ID="txtname" MaxLength="30" runat="server" CssClass="text input-txt" Width="300px" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Last Name</label>
                <asp:TextBox ID="txtLname" runat="server" CssClass="text input-txt" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Mobile<span style="color:Red">*</span></label>
                <asp:TextBox ID="txtmobile" onpaste="return false" runat="server" MaxLength="10" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Alternate Mobile</label>
                <asp:TextBox ID="txtaltmobile" onpaste="return false" CssClass="text input-txt"  runat="server" MaxLength="10" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> E-mail <span style="color:Red">*</span></label>
                <asp:TextBox MaxLength="40" ID="txtemail" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Phone(Res)</label>
                <asp:TextBox ID="txtphone" onpaste="return false" runat="server" MaxLength="11"  CssClass="text input-txt" onKeyPress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Date of Birth <span style="color:Red">*</span></label>
                <span class="date-pick-cont">
                <asp:TextBox ID="txtdob" runat="server" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker date-input-txt"></asp:TextBox>
                </span></li>
              <li>
                <label class="label-txt"> Blood Group </label>
                <asp:DropDownList ID="ddl_bloodgroup" runat="server" CssClass="sele-txt">
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
                <label class="label-txt"> Martial Status</label>
                <asp:DropDownList ID="ddl_maritalstatus" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Single">Single</asp:ListItem>
                  <asp:ListItem Value="Married">Married</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Mother Tongue </label>
                <asp:TextBox ID="txt_mothertongue" runat="server" CssClass="text input-txt" MaxLength="30" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Nationality</label>
                <asp:TextBox ID="txt_Nationality1" runat="server" CssClass="text input-txt" MaxLength="40" onkeypress="return AllowAlphabet(event)" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="txt_Nationality" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">Select</asp:ListItem>
                  <asp:ListItem>Indian</asp:ListItem>
                  <asp:ListItem>NRI</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Present Address</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Address<span style="color:Red">*</span></label>
                <asp:TextBox MaxLength="100" ID="txtpresentaddress" runat="server" CssClass="text  area-txt" Width="260px" Height="51px" TextMode="MultiLine"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">District/Taluk <span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpresentdistrict" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> City<span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpresentcity" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> State<span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpresentstate" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Pincode <span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpresentpincode" onKeyPress="return CheckNumeric(event)" onpaste="return false"  MaxLength="6" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Permanent Addres (Please check if the address is same as above)
            <asp:CheckBox ID="CheckBox1" OnClick="javascript:return checkaddress1();" runat="server" />
          </h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Address<span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpermanentaddress" MaxLength="100" runat="server" CssClass="text area-txt" Height="57px" Width="260px" TextMode="MultiLine" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">District/Taluk <span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpermanentdistrict" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> City <span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpermanentcity" runat="server" MaxLength="50" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> State<span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpermanentstate" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Pincode<span style="color:Red">*</span></label>
                <asp:TextBox ID="txtpermanentpincode" onKeyPress="return CheckNumeric(event)" MaxLength="6" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Highest Qualification details</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Qualification</label>
                <asp:TextBox ID="txtqualification" MaxLength="50" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Main Sub</label>
                <asp:TextBox ID="txtmainsub" MaxLength="75" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Name of the School/College</label>
                <asp:TextBox ID="txtschoolcolname" MaxLength="75" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> City</label>
                <asp:TextBox ID="txtcity" runat="server" MaxLength="50" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">State</label>
                <asp:TextBox ID="txtstate" MaxLength="50" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Completion status</label>
                <asp:DropDownList ID="ddl_completionstatus" runat="server" CssClass="sele-txt">
                  <asp:ListItem value="">--Select--</asp:ListItem>
                  <asp:ListItem value="Completed">Completed</asp:ListItem>
                  <asp:ListItem value="Pursuing">Pursuing</asp:ListItem>
                  <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Education in Animation and Graphics (Optional)
            <asp:CheckBox ID="CheckBox2" OnClick="javascript:return checkaddress1();" runat="server" />
          </h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Completion status </label>
                <asp:DropDownList ID="ddl_animationstatus" runat="server" CssClass="sele-txt" onChange="chkval5()">
                  <asp:ListItem value="">--Select--</asp:ListItem>
                  <asp:ListItem value="Completed">Completed</asp:ListItem>
                  <asp:ListItem value="Pursuing">Pursuing</asp:ListItem>
                  <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
                  <asp:ListItem value="NotStudied">Not Studied</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Branch</label>
                <asp:TextBox ID="txtbranch" MaxLength="40" runat="server" CssClass="text input-txt" onFocus="losefocus2(this)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Institute</label>
                <asp:TextBox ID="txtinstitute" MaxLength="40" runat="server" CssClass="text input-txt" onFocus="losefocus2(this)"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
            <div align="center"  style="padding:10px">
              <input id="step1" type="button" value="Next Step" class="btnStyle1"  />
              &nbsp;
              <input id="Reset1" type="reset" value="Reset" title="Reset" class="reset-btn" />
            </div>
          </div>
        </div>
      </div>
      <div id="tabs-2">
        <div class="free-forms">
          <h4 class="cont-title2">Enquiry Form - 2</h4>
          <h4 class="cont-title3">Parent/Guardian's Particulars</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Parent/Guardian's Name</label>
                <asp:TextBox ID="txtparentname" MaxLength="50" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Relationship with Applicant</label>
                <asp:TextBox ID="txtrelationothers" runat="server" CssClass="text input-txt" style="display:none; width:290px" MaxLength="50"></asp:TextBox>
                <asp:DropDownList ID="txtparentrelation" runat="server" CssClass="sele-txt"  onChange="chkval3();" >
                  <asp:ListItem Value="">--Select---</asp:ListItem>
                  <asp:ListItem Value="Parent">Parent</asp:ListItem>
                  <asp:ListItem Value="Guardian">Guardian</asp:ListItem>
                  <asp:ListItem Value="Friend">Friend</asp:ListItem>
                  <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Mobile </label>
                <asp:TextBox ID="txtparentmobile" onpaste="return false" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="10"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Phone(Office)</label>
                <asp:TextBox Width="290px" ID="txtparentphnumber" onpaste="return false" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text input-txt" MaxLength="11"></asp:TextBox >
              </li>
              <li>
                <label class="label-txt"> E-mail</label>
                <asp:TextBox ID="txtparentemail" MaxLength="40" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">Professional Details of Parent /Guardian (Optional)</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Company </label>
                <asp:TextBox ID="txtparent_cmp" MaxLength="75" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Designation</label>
                <asp:TextBox ID="txtparent_designation" MaxLength="75" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Type of Industry</label>
                <asp:TextBox ID="txtparent_typeofindustry" MaxLength="75" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Employment status</label>
                <asp:DropDownList ID="ddl_employementstatus" runat="server" CssClass="sele-txt" >
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="In Service">In Service</asp:ListItem>
                  <asp:ListItem Value="Retired">Retired</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Place of work </label>
                <asp:TextBox ID="txtparent_placeofwork" MaxLength="50" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Monthly Income </label>
                <asp:TextBox ID="txtparent_monthlyincome" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="7" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Proprietorship/Partnership(if Self Employed)</label>
                <asp:TextBox ID="txtselfemployed" runat="server" MaxLength="50" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Support of Parents </label>
                <asp:DropDownList ID="ddl_support" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Very High">Very High</asp:ListItem>
                  <asp:ListItem Value="Good">Good</asp:ListItem>
                  <asp:ListItem Value="Average">Average</asp:ListItem>
                  <asp:ListItem Value="Low">Low</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li id="coursevis" visible="false" runat="server">
                <label class="label-txt"> Source (As per the detailed discussion with the enquiry)</label>
                <asp:DropDownList ID="ddl_source" runat="server" CssClass="sele-txt" onChange="chkval1()">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Main Source">Main Source</asp:ListItem>
                  <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtsource" CssClass="text input-txt" style="display:none" MaxLength="50" runat="server"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Enquiry Profile<span style="color:Red">*</span> </label>
                <asp:DropDownList ID="ddl_profile" runat="server" CssClass="sele-txt">
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
              </li>
              <li>
                <label class="label-txt"> Requirements of the enquiry </label>
                <asp:TextBox ID="txtrequirements" MaxLength="50" runat="server" TextMode="MultiLine" CssClass="text area-txt" Width="260px"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Questions raised by the enquiry </label>
                <asp:TextBox ID="txtquestions" MaxLength="100" runat="server" TextMode="MultiLine" CssClass="text area-txt" Width="260px"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Competitors Visited (Optional)</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Brand</label>
                <asp:TextBox ID="txtbrand" MaxLength="20" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Location</label>
                <asp:TextBox ID="txtlocation" MaxLength="20" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Positive</label>
                <asp:TextBox ID="txtpositive" runat="server" MaxLength="50" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Negative</label>
                <asp:TextBox ID="txtnegative" runat="server" MaxLength="50" CssClass="text  input-txt"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">Financial Details</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Financial Status </label>
                <asp:DropDownList ID="ddl_finstatus" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Very Good">Very Good</asp:ListItem>
                  <asp:ListItem Value="Good">Good</asp:ListItem>
                  <asp:ListItem Value="Average">Average</asp:ListItem>
                  <asp:ListItem Value="Bad">Bad</asp:ListItem>
                  <asp:ListItem Value="Very Bad">Very Bad</asp:ListItem>
                </asp:DropDownList>
              </li>
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
              <li>
                <label class="label-txt"> Investment possible</label>
                <asp:TextBox ID="txtmininvestment" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="15" runat="server" CssClass="text input-txt" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="ddl_Inv_Possible" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Rs.25,000 to 50,000">Rs.25,000 to 50,000</asp:ListItem>
                  <asp:ListItem Value="Rs.50,000 to 75,000">Rs.50,000 to 75,000</asp:ListItem>
                  <asp:ListItem Value="Rs.75,000 to 1,00,000">Rs.75,000 to 1,00,000</asp:ListItem>
                  <asp:ListItem Value="Above 1,00,000">Above 1,00,000</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtmaxinvestment" onpaste="return false" onKeyPress="return CheckNumeric(event)" MaxLength="15" runat="server" CssClass="text input-txt" Visible="False" Width="290px"></asp:TextBox>
              </li>
              <li id="enqplan" runat="server" visible="false">
                <label class="label-txt"> How has the enquiry planned to arrange the funds required for the course</label>
                <asp:TextBox ID="txtarrangefund" MaxLength="50" CssClass="text input-txt" runat="server" TextMode="MultiLine" Width="260px"></asp:TextBox>
              </li>
              <li id="interestvis" runat="server" visible="false">
                <label class="label-txt"> Interest level</label>
                <asp:DropDownList ID="ddl_interestlevel" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Very High">Very High</asp:ListItem>
                  <asp:ListItem Value="Good">Good</asp:ListItem>
                  <asp:ListItem Value="Average">Average</asp:ListItem>
                  <asp:ListItem Value="Low">Low</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li id="enqwho" runat="server" visible="false">
                <label class="label-txt"> Who all attended the counseling?</label>
                <asp:TextBox ID="txtwhoallattended" runat="server" MaxLength="70" TextMode="MultiLine" CssClass="text input-txt"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Decision Makers </h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Name</label>
                <asp:TextBox ID="txt_dmakername" MaxLength="20" runat="server" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Contact details</label>
                <asp:TextBox ID="txt_dmakercontactdetails" MaxLength="40" runat="server" Width="290px" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Relationship </label>
                <asp:TextBox ID="txt_dmakerrelationship" MaxLength="20" Visible="false" runat="server" CssClass="text input-txt" ReadOnly="True"></asp:TextBox>
                <asp:DropDownList ID="ddldecision_relation" runat="server" CssClass="sele-txt"  onChange="chkvalR3();">
                  <asp:ListItem Value="">--Select---</asp:ListItem>
                  <asp:ListItem Value="Parent">Parent</asp:ListItem>
                  <asp:ListItem Value="Guardian">Guardian</asp:ListItem>
                  <asp:ListItem Value="Friend">Friend</asp:ListItem>
                  <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txt_dec_others" runat="server" CssClass="text input-txt" MaxLength="50" Style="display: none" ></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Whether enquiry was referred by someone (Optional) </h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Name</label>
                <asp:TextBox ID="txt_referrername" runat="server" MaxLength="50" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Contact details </label>
                <asp:TextBox ID="txt_referrercontactdetails" MaxLength="40" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> How did he know Image </label>
                <asp:DropDownList ID="txt_knowsimage" runat="server" CssClass="sele-txt" onChange="chkval2();">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Tv Adds">Tv Adds</asp:ListItem>
                  <asp:ListItem Value="Paper">Paper</asp:ListItem>
                  <asp:ListItem Value="Posters">Posters</asp:ListItem>
                  <asp:ListItem Value="Banners">Banners</asp:ListItem>
                  <asp:ListItem Value="Image alumini">Image alumini</asp:ListItem>
                  <asp:ListItem Value="Image Student">Image Student</asp:ListItem>
                  <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtothersrefer" style="display:none" runat="server" CssClass="text input-txt" ></asp:TextBox>
                <asp:DropDownList ID="ddl_Centre" style="display:none" runat="server" CssClass="sele-txt"> </asp:DropDownList>
                <asp:TextBox ID="txtReferalstudentid" style="display:none" runat="server" MaxLength="50" CssClass="input-txt"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Enquiry Status </h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt">Counseled time</label>
                <asp:DropDownList ID="txt_counseledtime" runat="server" CssClass="sele-txt">
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
                <label class="label-txt"> Enrollment Date Positioned <span style="color: #ff0000">*</span></label>
                <span class="date-pick-cont" style="margin-bottom:10px;">
                <asp:TextBox ID="txt_enrolldate" onpaste="return false" onKeyPress="return false" runat="server" CssClass="text datepicker date-input-txt" ></asp:TextBox>
                </span> </li>
              <li>
                <label class="label-txt"> Course Asked<span style="color:Red">*</span></label>
                <asp:DropDownList ID="txt_courseasked" runat="server" CssClass="sele-txt"> </asp:DropDownList>
                <span style="color:Red">&nbsp; </span> </li>
              <li>
                <label class="label-txt"> Course Positioned<span style="color:Red">*</span></label>
                <asp:DropDownList ID="txt_coursepositioned" runat="server" CssClass="sele-txt"> </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Status <span style="color:Red">*</span></label>
                <asp:DropDownList ID="ddl_status" runat="server" CssClass="sele-txt">
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
              <li id="enqaction" visible="false" runat="server">
                <label class="label-txt"> Enquiry's action plan </label>
                <asp:TextBox ID="txt_actionplan" runat="server" MaxLength="40" CssClass="text input-txt"></asp:TextBox>
              </li>
              <li id="enqsubmit" visible="false" runat="server">
                <label class="label-txt">
                <asp:CheckBox ID="checkfields" runat="server" />
                Are you sure of submitting the form?</label>
              </li>
              <li>
                <input id="hdncou_id" runat="server" name="hdncou_id" type="hidden" />
                <input id="Hidden1" name="hdnTab" type="hidden" value="Admission" />
              </li>
            </ul>
            <div class="clear"></div>
            <div align="center">
              <input id="step2" type="button" value="Next Step" class="btnStyle1"  />
              <input id="Reset2" type="reset" value="Reset"   class="reset-btn" onclick="return Reset2_onclick()" />
              <asp:HiddenField ID="hdntempID" runat="server" />
            </div>
          </div>
        </div>
      </div>
      <div id="tabs-3">
        <div class="free-forms">
          <h4 class="cont-title2">Enquiry Form - 3</h4>
          <h4 class="cont-title3"> Personal Particulars</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Mother Tongue</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="text input-txt" MaxLength="50" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Blood Group</label>
                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="sele-txt">
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
                <label class="label-txt"> Alternate Mobile</label>
                <asp:TextBox ID="txt_altmobile" runat="server" CssClass="text input-txt" MaxLength="10" onkeypress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Alternate Email</label>
                <asp:TextBox ID="txt_altemail" runat="server" CssClass="text input-txt" MaxLength="50"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Phone</label>
                <asp:TextBox ID="txt_permanentphone" runat="server" CssClass="text input-txt" MaxLength="11" onkeypress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li> Note:<span style="color: #000000"><strong> As appearing in your Academic Records
                / Certificates</strong></span></li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">Parent / Guardian's Particulars</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt">Mobile</label>
                <asp:TextBox ID="txt_guardianmobile" runat="server" CssClass="text input-txt" MaxLength="11" onkeypress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Phone (Office)</label>
                <asp:TextBox ID="txt_guardianphone" runat="server" CssClass="text input-txt" MaxLength="11" onkeypress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Email</label>
                <asp:TextBox ID="txt_guardianemail" runat="server" CssClass="text input-txt" MaxLength="30"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">Professional Details of Parent / Guardian (Optional)</h4>
          <div class="padd-cont form-cont2">
            <ul>
              <li>
                <label class="label-txt"> Company</label>
                <input id="txt_company" runat="server" class="text input-txt" maxlength="40" name="txt_company" type="text" />
              </li>
              <li>
                <label class="label-txt"> Employment Status</label>
                <asp:DropDownList ID="ddl_empstatus" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="In service">In service</asp:ListItem>
                  <asp:ListItem Value="Retired">Retired</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Designation</label>
                <input id="txt_designation" runat="server" class="text input-txt" maxlength="40" name="txt_designation" onkeypress="return AllowAlphabet(event)" type="text"  />
              </li>
              <li>
                <label class="label-txt"> Place of Work</label>
                <input id="txt_workPlace" runat="server" class="text input-txt" maxlength="30" name="txt_workPlace" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <label class="label-txt"> Type of Industry</label>
                <input id="txt_industryType" runat="server" class="text input-txt" maxlength="30" name="txt_industryType" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <label class="label-txt"> Monthly Income</label>
                <input id="txt_income" runat="server" class="text input-txt" maxlength="7" name="txt_income" onkeypress="return CheckNumeric(event)" type="text" />
              </li>
              <li>
                <label class="label-txt"> Proprietorship / Partnership (if Self Employed)</label>
                <input id="txt_selfemployed" runat="server" class="text input-txt" maxlength="30" name="txt_selfemployed" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
            </ul>
            <div class="clear"></div>
            <div align="center">
              <input id="step3" class="btnStyle1" type="button" value="Next Step" />
              <input id="Reset3" class="reset-btn" title="Reset" type="reset" value="Reset" />
            </div>
          </div>
        </div>
      </div>
      <div id="tabs-4">
        <div class="free-forms">
          <h4 class="cont-title2">Enquiry Form - 4</h4>;
          <h4 class="cont-title3">Education in Digital Media and related fields (Optional)</h4>
          <div class="padd-cont form-cont4">
            <label class="label-txt3">Select if you have completed , attended or currently pursuing any course in any (Optional)</label>
            <ul style="padding:10px 0px 0px 100px;">
              <li>
                <input id="GraphicDesigning" runat="server" name="GraphicDesigning" type="checkbox" value="GraphicDesigning" />
                <label class="label-txt3">Graphic Designing</label>
              </li>
              <li>
                <input id="WebDesigning" runat="server" name="WebDesigning" type="checkbox" value="WebDesigning" />
                <label class="label-txt3">Web Designing</label>
              </li>
              <li>
                <input id="chk_3DAnimation" runat="server" name="chk_3DAnimation" type="checkbox" value="3D Animation" />
                <label class="label-txt3">3D Animation</label>
              </li>
              <li>
                <input id="PostProduction" runat="server" name="PostProduction" type="checkbox" value="PostProduction" />
                <label class="label-txt3">Post Production</label>
              </li>
              <li>
                <input id="FineArts" runat="server" name="FineArts" type="checkbox" value="FineArts" />
                <label class="label-txt3">Fine Arts</label>
              </li>
              <li>
                <input id="Programming" runat="server" name="Programming" type="checkbox" value="Programming" />
                <label class="label-txt3">Programming</label>
              </li>
              <li>
                <input id="check_2DAnimation" runat="server" name="2DAnimation" type="checkbox" value="2DAnimation" />
                <label class="label-txt3">2D Animation</label>
              </li>
              <li>
                <input id="Hardware" runat="server" name="Hardware" type="checkbox" value="Hardware" />
                <label class="label-txt3">Hardware</label>
              </li>
              <li>
                <input id="GameDesigning" runat="server" name="GameDesigning" type="checkbox" value="GameDesigning" />
                <label class="label-txt3">Game Designing</label>
              </li>
              <li>
                <input id="GameProgramming" runat="server" name="GameProgramming" type="checkbox" value="GameProgramming" />
                <label class="label-txt3">Game Programming</label>
              </li>
              <li>
                <input id="Networking" runat="server" name="Networking" type="checkbox" value="Networking" />
                <label class="label-txt3">Networking</label>
              </li>
              <li>
                <input id="FlashScripting" runat="server" name="FlashScripting" type="checkbox" value="FlashScripting" />
                <label class="label-txt3">Flash Scripting</label>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <div class="padd-cont form-cont5">
            <ul>
              <li class="txt-li">
                <label class="label-txt3">Institution Name</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">City</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Status of Completion</label>
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input id="txt_institutename1" runat="server" class="text institution input-txt" maxlength="30" name="txt_institutename1" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <input id="txt_city1" runat="server" class="text input-txt" maxlength="30" name="txt_city1" onkeypress="return AllowAlphabet(event)" size="50" type="text" value=" " />
              </li>
              <li>
                <asp:DropDownList ID="ddl_digitalstatus" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Completed">Completed</asp:ListItem>
                  <asp:ListItem Value="Pursuing">Pursuing</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input id="txt_institutename2" runat="server" class="text input-txt" maxlength="30" name="txt_institutename2" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <input id="txt_city2" runat="server" class="text input-txt" maxlength="30" name="txt_city2" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <asp:DropDownList ID="ddl_digitalstatus2" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Completed">Completed</asp:ListItem>
                  <asp:ListItem Value="Pursuing">Pursuing</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">Employment Details (If any)</h4>
          <div class="padd-cont form-cont6">
            <ul>
              <li class="txt-li">
                <label class="label-txt3">Name of the Organization</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Period of Employment</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Designation</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Current Status</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Annual Income</label>
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input  id="txt_stu_organization" runat="server" class="text input-txt" maxlength="40" name="txt_stu_organization" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <input id="txt_stu_employment" runat="server" class="text input-txt" maxlength="30" name="txt_stu_employment" type="text" />
              </li>
              <li>
                <input  id="txt_stu_designation" runat="server" class="text input-txt" maxlength="30" name="txt_stu_designation" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <asp:DropDownList ID="ddworkingstatus" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Working">Working</asp:ListItem>
                  <asp:ListItem Value="NotWorking">Not Working</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <input id="txt_stu_annualincome" runat="server" class="text input-txt" maxlength="7" name="txt_stu_annualincome" onkeypress="return CheckNumeric(event)" type="text" />
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">Extra Curricular Activities:</h4>
          <div class="padd-cont form-cont5">
            <ul>
              <li class="txt-li">
                <label class="label-txt3">Activity</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Participation level (Zonal, District, State, School)</label>
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input id="txt_activity1" runat="server" class="text input-txt" maxlength="30" name="txt_activity1" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <asp:DropDownList ID="txt_participation1" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Zonal">Zonal</asp:ListItem>
                  <asp:ListItem Value="District">District</asp:ListItem>
                  <asp:ListItem Value="State">State</asp:ListItem>
                  <asp:ListItem Value="School">School</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input id="txt_activity2" runat="server" class="text input-txt" maxlength="30" name="txt_activity2" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <asp:DropDownList ID="txt_participation2" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Zonal">Zonal</asp:ListItem>
                  <asp:ListItem Value="District">District</asp:ListItem>
                  <asp:ListItem Value="State">State</asp:ListItem>
                  <asp:ListItem Value="School">School</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <div class="padd-cont form-cont2 no-padd-tp">
            <div align="center">
              <input id="step4" class="btnStyle1" type="button" value="Next Step" />
              <input id="Reset4" class="btnStyle2" title="Reset" type="reset" value="Reset" />
            </div>
          </div>
        </div>
      </div>
      <div id="tabs-5">
        <div class="free-forms">
          <h4 class="cont-title2">Enquiry Form - 5</h4>
          <h4 class="cont-title3">Physical Defect</h4>
          <div class="padd-cont form-cont">
            <ul>
              <li>
                <label class="label-txt">Physical defect/chronic illness of a permanent nature if any</label>
                <asp:DropDownList ID="ddl_phydefect" runat="server" onChange="chkval1()" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Yes">Yes</asp:ListItem>
                  <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> If Yes, Please Mention Details</label>
                <input id="txt_defectYes" runat="server" class="text input-txt" name="txt_defectYes" onfocus="losefocus1(this)" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <label class="label-txt"> Color Blindness</label>
                <asp:DropDownList ID="ddl_clrblind" runat="server"  CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Yes">Yes</asp:ListItem>
                  <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">General Information</h4>
          <div class="padd-cont form-cont">
            <ul>
              <li>
                <label class="label-txt"> Please provide in brief the reason for joining this course</label>
                <asp:TextBox ID="txtarea_reason" runat="server" CssClass="textbox area-txt" onkeypress="return AllowAlphabet(event)" TextMode="MultiLine" Width="260px"></asp:TextBox>
              </li>
              <li> When and how did you hear about IMAGE first?</li>
              <li>
                <label class="label-txt"> When </label>
                <asp:DropDownList ID="ddl_whenmonth" runat="server" CssClass="sele-txt">
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
                <asp:TextBox ID="txt_whenyear" runat="server" CssClass="text input-txt" MaxLength="4" onkeypress="return CheckNumeric(event)" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> How</label>
                <asp:TextBox ID="txtarea_howuknw" runat="server" CssClass="text input-txt" onkeypress="return AllowAlphabet(event)" TextMode="MultiLine" Width="260px" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Give a list of other sources through which you heard about IMAGE</label>
                <asp:TextBox ID="txtarea_heardimage" runat="server" CssClass="text area-txt" onkeypress="return AllowAlphabet(event)" TextMode="MultiLine" Width="260px"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3">If this course was recommended to you please provide the following details (Optional)</h4>
          <div class="padd-cont form-cont6">
            <ul>
              <li class="txt-li"><label class="label-txt3">Name of the Person</label></li>
              <li class="txt-li"><label class="label-txt3">Industry</label></li>
              <li class="txt-li"><label class="label-txt3">Organization</label></li>
              <li class="txt-li"><label class="label-txt3">Designation</label></li>
              <li class="txt-li"><label class="label-txt3">Contact Number</label></li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input id="txtname_person1" runat="server" class="text input-txt" name="txtname_person1" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <input id="txt_industry1" runat="server" class="text input-txt" name="txt_industry1" type="text"/>
              </li>
              <li>
                <input id="txt_org1" runat="server" class="text input-txt" name="txt_org1" type="text" />
              </li>
              <li>
                <input id="txt_desig1" runat="server" class="tex input-txt" maxlength="20" name="txt_desig1" type="text" />
              </li>
              <li>
                <input id="txt_contactno1" runat="server" class="text input-txt" maxlength="10" name="txt_contactno1" onkeypress="return CheckNumeric(event)" type="text" />
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input id="txtname_person2" runat="server" class="text input-txt" name="txtname_person2" onkeypress="return AllowAlphabet(event)" type="text" />
              </li>
              <li>
                <input id="txt_industry2" runat="server" class="text input-txt" name="txt_industry2" type="text" />
              </li>
              <li>
                <input id="txt_org2" runat="server" class="text input-txt" name="txt_org2" type="text"/>
              </li>
              <li>
                <input id="txt_desig2" runat="server" class="text input-txt" maxlength="20" name="txt_desig2" type="text" />
              </li>
              <li>
                <input id="txt_contactno2" runat="server" class="text input-txt" maxlength="10" name="txt_contactno2"  onkeypress="return CheckNumeric(event)" type="text" />
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> If you have professional contacts in the media industry, please mention the details (Optional)</h4>
          <div class="padd-cont form-cont7 no-padd-btm">
            <ul>
              <li class="txt-li"><label class="label-txt3">Whom do you know</label></li>
              <li class="txt-li"><label class="label-txt3">Company / Institution</label></li>
              <li class="txt-li"><label class="label-txt3">Designation</label></li>
              <li class="txt-li"><label class="label-txt3">Contact Number</label></li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li><input id="txtwhomknow1" runat="server" class="text input-txt" name="txtwhomknow1" onkeypress="return AllowAlphabet(event)" type="text"/></li>
              <li><input id="txtcompinst1" runat="server" class="text input-txt" name="txtcompinst1" type="text" /></li>
              <li><input id="txtdesig1" runat="server" class="text input-txt" maxlength="20" name="txtdesig1" type="text" /></li>
              <li><input id="txtcontactno1" runat="server" class="text input-txt" maxlength="10" name="txtcontactno1" onkeypress="return CheckNumeric(event)" type="text" /></li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li><input id="txtwhomknow2" runat="server" class="text input-txt" name="txtwhomknow2" onkeypress="return AllowAlphabet(event)" type="text" /></li>
              <li><input id="txtcompinst2" runat="server" class="text input-txt" name="txtcompinst2" type="text" /></li>
              <li><input id="txtdesig2" runat="server" class="text input-txt" maxlength="20" name="txtdesig2" type="text" /></li>
              <li><input id="txtcontactno2" runat="server" class="text input-txt" maxlength="10" name="txtcontactno2" onkeypress="return CheckNumeric(event)" type="text" /></li>
            </ul>
            <div class="clear"></div>
          </div>
          <div class="padd-cont form-cont">
            
            <ul>
              <li>
                <label  class="label-txt">have you paid or intended to fund your study?</label>
                <asp:DropDownList ID="ddl_fundplann" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Parent's Personal Funds">Parent's Personal Funds</asp:ListItem>
                  <asp:ListItem Value="Guardian's Personal Funds">Guardian's Personal Funds</asp:ListItem>
                  <asp:ListItem Value="Self"> Self</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt">
                <input id="check_loan" name="check_loan" type="checkbox" value="loan" />
                Loan (Mention Details)</label>
                <input id="txt_loan" runat="server" class="text input-txt" name="txt_loan" type="text" />
              </li>
              <li>
                <label  class="label-txt">
                <input id="check_sponsor" name="Game Designing5" type="checkbox" value="Game Designing" />
                Any Sponsorship (Mention Details)</label>
                <input id="txt_sponsor" runat="server" class="text input-txt" name="txt_sponsor" type="text" />
              </li>
              <li>
                <label class="label-txt">Track<span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="ddtrack" runat="server" CssClass="sele-txt" OnChange="setFees1();">
                  <asp:ListItem Value="Normal">Normal</asp:ListItem>
                  <asp:ListItem Value="Fast">Fast</asp:ListItem>
                  <asp:ListItem Value="Zip">Zip</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Course Name<span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="txt_coursenamee" runat="server" CssClass="sele-txt" onchange="changepayment();"> </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt">Payment Pattern<span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="ddl_payment" runat="server" CssClass="sele-txt" OnChange="display(this.value);setFees1();">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Lump sum">Lump sum</asp:ListItem>
                  <asp:ListItem Value="Installment">Installment</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server" CssClass="label-txt2" Font-Bold="True" Text="Lumpsum"></asp:Label>
              </li>
              <li id="lump1">
                <label class="label-txt"> Course Fees </label>
                <span id="txt_lumpamt" runat="server" style="padding-top:9px; display:inline-block;"></span>
                <asp:HiddenField ID="lbllumpamt" runat="server" />
              </li>
              <li id="lump3">
                <label  class="label-txt"> Initial Amount to be paid </label>
                <asp:TextBox ID="txt_lumpinitial" runat="server" CssClass="text input-txt" MaxLength="7" onkeypress="return CheckNumeric(event)"></asp:TextBox>
              </li>
              <li id="lump2">
                <label  class="label-txt"> No. of Installments</label>
                <asp:TextBox ID="txt_instalamt1" runat="server" CssClass="text input-txt" MaxLength="2" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                <div align="right"> Maximum  number of installments :
                  <asp:Label ID="lblmaxinstallnumber" runat="server" Text="0" CssClass="error"></asp:Label>
                </div>
                <asp:Button ID="Button1" runat="server" OnClientClick="return checkval();" Text="Calculation" />
              </li>
              <li id="lump4">
                <label  class="label-txt"> Amount To be paid per month</label>
                <asp:TextBox ID="txtamtmonthly" runat="server" CssClass="text input-txt" MaxLength="7" onkeypress="return CheckNumeric(event)" ReadOnly="True"></asp:TextBox>
              </li>
              <script type="text/javascript">display("");</script>
              <li>
                <label  class="label-txt">Batch Time <span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="ddlbatchtime" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="7AM-9AM">7AM-9AM</asp:ListItem>
                  <asp:ListItem Value="9AM-11AM">9AM-11AM</asp:ListItem>
                  <asp:ListItem Value="11AM-1PM">11AM-1PM</asp:ListItem>
                  <asp:ListItem Value="1PM-3PM">1PM-3PM</asp:ListItem>
                  <asp:ListItem Value="3PM-5PM">3PM-5PM</asp:ListItem>
                  <asp:ListItem Value="5PM-7PM">5PM-7PM</asp:ListItem>
                  <asp:ListItem Value="7PM-9PM">7PM-9PM</asp:ListItem>
                </asp:DropDownList>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
          <h4 class="cont-title3"> Payment Details</h4>
          <div class="padd-cont form-cont">
            <ul>
              <li>
                <label class="label-txt"> Payment Mode<span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="ddlpaymentmode" runat="server" onchange="cashval()" CssClass="sele-txt">
                  <asp:ListItem Value="Cash">Cash</asp:ListItem>
                  <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                  <asp:ListItem Value="D.D">D.D</asp:ListItem>
                  <asp:ListItem Value="Creditcard">Creditcard</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Cheque/D.D. No/C.C No</label>
                <asp:TextBox ID="txtchequeno" runat="server" CssClass="text input-txt" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> Cheque/D.D Date</label>
                <span class="date-pick-cont">
                <asp:TextBox ID="txtchequeno0" runat="server" CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false"  MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
                </span></li>
              <li>
                <label class="label-txt"> Bank Name</label>
                <asp:TextBox ID="txtbankname" runat="server" CssClass="text input-txt" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
              </li>
              <li id="rdnvis" runat="server" visible="false">
                <label class="label-txt"> Select Student type <span style="color: #ff0000">*</span></label>
                <asp:RadioButton ID="radiobtnindia1" runat="server" GroupName="radiobtnindia" onchange="return studtype()" Text="Residents" />
                <asp:RadioButton ID="radiobtnnri" runat="server" GroupName="radiobtnindia" onchange="return studtype()" Text="Non Residents" Width="100px" />
              </li>
              <li>
                <label class="label-txt" ID="lblcountry" runat="server" Style="display: none"> Country of residence (Currently)</label>
                <asp:TextBox ID="txt_countryofresi" runat="server" CssClass="text input-txt" MaxLength="25" Style="display: none"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt" ID="lblpassport" runat="server" Style="display: none"> Passport number</label>
                <asp:TextBox ID="txt_passportnum" runat="server" CssClass="text input-txt" MaxLength="8" Style="display: none"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt" ID="lblplace" runat="server" Style="display: none"> Place of Issue</label>
                <asp:TextBox ID="txt_placeofiisue" runat="server" CssClass="text input-txt" MaxLength="20" Style="display: none"></asp:TextBox>
              </li>
            </ul>
            <div class="clear"></div>
            <div align="center">
              <asp:Button ID="btnsubmit5" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="return admform3();"  OnClick="btnsubmit5_Click"/>
              <input id="Reset5" class="reset-btn" title="Reset" type="reset" value="Reset" />
              <asp:HiddenField ID="hdnlumpamt" runat="server" />
            </div>
          </div>
        </div>
      </div>
                 </div>
  </div>
  <script type="text/javascript">
  	changepayment();
  </script>

</asp:Content>

