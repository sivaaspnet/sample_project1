<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="Admission.aspx.cs" Inherits="superadmin_Admission" Title="Admission form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

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
      else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)))
     {
            alert(" Please enter less than or equal to (maximum number of installments)");
            document.getElementById("ContentPlaceHolder1_txt_instalamt1").value=="";
            document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
            document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
            document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9"
            return false;
     }
     else if(document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='tvm-1' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-101' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-102' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-103' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-106')
     {
         
           if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Certificate')
           { 
                if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 1779)
                {  
                     var querystring=window.location.search.substring(1);
                     querystring=querystring.replace("end_id","enqno"); 
                     alert("Enrollment amount is Less ,Use Registration link.");     
                     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
                     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
                     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
                     location.href = 'QuickAdmission.aspx?'+querystring;
                     return false;
                           
                 }
                 else
                 {
                         
                    amt_ex_initial=parseInt((document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value));
                    //alert(amt_ex_initial);
                     noofinstallments = document.getElementById("ContentPlaceHolder1_txt_instalamt1").value;
                    //alert(noofinstallments);
                    monthlyinstall = amt_ex_initial / noofinstallments;
                    //txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
                    //alert(monthlyinstall);
                     document.getElementById("ContentPlaceHolder1_txtamtmonthly").value=Math.round(monthlyinstall, 0);
                     return false; 
                         
                 }
                        
          }
          else if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Diploma')
          {           
               if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 4449)
                {
                             alert("Enrollment amount is Less ,Use Registration link.");
                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
                               location.href = 'QuickAdmission.aspx';
                             return false;
                }
                else
                {
                       
                        amt_ex_initial=parseInt((document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value));
                      // alert(amt_ex_initial); 
                        noofinstallments = document.getElementById("ContentPlaceHolder1_txt_instalamt1").value;
                        //alert(noofinstallments);
                        monthlyinstall = amt_ex_initial / noofinstallments;                       
                        document.getElementById("ContentPlaceHolder1_txtamtmonthly").value=Math.round(monthlyinstall, 0);
                        return false;
                 }                         
         }   
    }
    else
    {
       
         amt_ex_initial=parseInt((document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value));
  
         noofinstallments = document.getElementById("ContentPlaceHolder1_txt_instalamt1").value;
         //alert(noofinstallments);
        monthlyinstall = amt_ex_initial / noofinstallments;
        //txtamtmonthly.Text = Convert.ToString(Math.Round(monthlyinstall, 0));
       //  alert(monthlyinstall);
        document.getElementById("ContentPlaceHolder1_txtamtmonthly").value=Math.round(monthlyinstall, 0);
        return false;
    }
}

 function clearValidation(fieldList)
	   {
	
	    var field=new Array();
	    field=fieldList.split("~");
	    var counter=0;
	    for(i=0;i<field.length;i++)
	     {
		   //if(document.getElementById(field[i]).value!="")
		    //{
//			document.getElementById(field[i]).style.border="#EFEFEF 1px solid";
//			document.getElementById(field[i]).style.backgroundColor="#FFFFFF";
		    //}
	     }
	  }  
	
function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
function CheckNumeric(GetEvt)
  {
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
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
 
 function checkValidation(fieldList)
{
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++)
	{
		if(trim(document.getElementById(field[i]).value)=="")
		{
		counter++;
		} 
	}
	if(counter>0)
	{
		return counter;				
	} else { 
		return counter; 
	}				
}

function Cboxvalidation(fieldList)
{
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	var ctrue=0;
	for(i=0;i<field.length;i++)
	{
		if(document.getElementById(field[i]).checked==false)
		{
		counter++;
		} 
		else
		{
		ctrue++;
		}
	}
	if(counter>0)
	{
		return counter;				
	} 
	else if(ctrue>0)
	{
	   return ctrue+1;
	}
	else 
	{ 
		return "-1"; 
	}				
}
   
   //form1
function admissionform()
{ 
   var valid = emptyValidation('ContentPlaceHolder1_txt_firstname~ContentPlaceHolder1_ddl_gender~ContentPlaceHolder1_txt_dob~ContentPlaceHolder1_txt_mobile~ContentPlaceHolder1_txt_email~ContentPlaceHolder1_txt_presentaddress~ContentPlaceHolder1_txt_presentdistrict~ContentPlaceHolder1_txt_presentstate~ContentPlaceHolder1_txt_presentpin~ContentPlaceHolder1_txt_permanentaddress~ContentPlaceHolder1_txt_permanentdistrict~ContentPlaceHolder1_txt_permanentstate~ContentPlaceHolder1_txt_permanentpin')
    if(!valid) 
    {
        return false;
    }
    else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txt_email").value))
    {
       alert("Enter valid email id");
       document.getElementById("ContentPlaceHolder1_txt_email").focus();
       document.getElementById("ContentPlaceHolder1_txt_email").style.border="#ff0000 1px solid";
       document.getElementById("ContentPlaceHolder1_txt_email").style.backgroundColor="#e8ebd9";
       return false;
     
    }  
//    else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txt_altemail").value))
//    {
//       alert("Enter valid alternate email id");
//       document.getElementById("ContentPlaceHolder1_txt_altemail").focus();
//       document.getElementById("ContentPlaceHolder1_txt_altemail").style.border="#ff0000 1px solid";
//       document.getElementById("ContentPlaceHolder1_txt_altemail").style.backgroundColor="#e8ebd9";
//       return false;
//    }
//    else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txt_guardianemail").value))
//    {
//       alert("Enter valid alternate email id");
//       document.getElementById("ContentPlaceHolder1_txt_guardianemail").focus();
//       document.getElementById("ContentPlaceHolder1_txt_guardianemail").style.border="#ff0000 1px solid";
//       document.getElementById("ContentPlaceHolder1_txt_guardianemail").style.backgroundColor="#e8ebd9";
//       return false; 
//    } 
    else 
    {
    return true;
    }
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
//  if(document.getElementById("ContentPlaceHolder1_ddlprimary").value == "")
//   {
//       alert("Please enter your highest qualification");
//       document.getElementById("ContentPlaceHolder1_ddlprimary").focus();
//       document.getElementById("ContentPlaceHolder1_ddlprimary").style.border="#ff0000 1px solid";
//       document.getElementById("ContentPlaceHolder1_ddlprimary").style.backgroundColor="#e8ebd9";
//       return false; 
//       
//   } 
//	var tenth = 'ContentPlaceHolder1_txt_tenthmajor~ContentPlaceHolder1_txt_tenthinstitution~ContentPlaceHolder1_txt_tenthcity~ContentPlaceHolder1_txt_tenthstate';

//    var cbox = 'ContentPlaceHolder1_GraphicDesigning~ContentPlaceHolder1_WebDesigning~ContentPlaceHolder1_chk_3DAnimation~ContentPlaceHolder1_PostProduction~ContentPlaceHolder1_FineArts~ContentPlaceHolder1_Programming~ContentPlaceHolder1_check_2DAnimation~ContentPlaceHolder1_Hardware~ContentPlaceHolder1_GameDesigning~ContentPlaceHolder1_GameProgramming~ContentPlaceHolder1_Networking~ContentPlaceHolder1_FlashScripting';
//    var txtbx='ContentPlaceHolder1_txt_institutename1~ContentPlaceHolder1_txt_city1~ContentPlaceHolder1_ddl_digitalstatus';
//    var activity='ContentPlaceHolder1_txt_participation1~ContentPlaceHolder1_txt_participation2';
//  
//    var empdet='ContentPlaceHolder1_txt_stu_organization~ContentPlaceHolder1_txt_stu_employment~ContentPlaceHolder1_txt_stu_designation~ContentPlaceHolder1_ddworkingstatus~ContentPlaceHolder1_txt_stu_annualincome';
//    
//    //clearValidation('ContentPlaceHolder1_ddlprimary~'+tenth+'~'+cbox+'~'+txtbx+'~'+activity+'~'+empdet);

//	var f5=cbox.split("~");
//	var f6=empdet.split("~");
//	
//	var valid = emptyValidation(tenth);
//	if(!valid) {
//		return false;
//	
//	} else if((Cboxvalidation(cbox) < f5.length || Cboxvalidation(cbox)== 13) && Cboxvalidation(cbox) > 0 && !emptyValidation(txtbx)) {
//			return false;
//	}

//	else if(document.getElementById("ContentPlaceHolder1_txt_activity1").value!="" && document.getElementById("ContentPlaceHolder1_txt_participation1").value=="")
//	{
//	    if(!emptyValidation('ContentPlaceHolder1_txt_participation1')) {
//			return false;
//		}
//	}
//	else if(checkValidation(empdet) < f6.length && !emptyValidation(empdet)) {
//		return false;
//	}
//	else if(document.getElementById("ContentPlaceHolder1_txt_activity2").value!="" && document.getElementById("ContentPlaceHolder1_txt_participation2").value=="")
//	{
//	if(!emptyValidation('ContentPlaceHolder1_txt_participation2')) {
//			return false;
//		}
//    }
//    //new
//    else if(document.getElementById("ContentPlaceHolder1_txtname_person1").value!="" && document.getElementById("ContentPlaceHolder1_txt_industry1").value=="" && document.getElementById("ContentPlaceHolder1_txt_org1").value=="" && document.getElementById("ContentPlaceHolder1_txt_desig1").value=="" && document.getElementById("ContentPlaceHolder1_txt_contactno1").value=="")
//	{
//	if(!emptyValidation('ContentPlaceHolder1_txt_industry1~ContentPlaceHolder1_txt_org1~ContentPlaceHolder1_txt_desig1~ContentPlaceHolder1_txt_contactno1'))
//	   {
//		 return false;
//	   }
//	 } 
// else if(document.getElementById("ContentPlaceHolder1_txtname_person2").value!="" && document.getElementById("ContentPlaceHolder1_txt_industry2").value=="" && document.getElementById("ContentPlaceHolder1_txt_org2").value=="" && document.getElementById("ContentPlaceHolder1_txt_desig2").value=="" && document.getElementById("ContentPlaceHolder1_txt_contactno2").value=="")
//	{
//	if(!emptyValidation('ContentPlaceHolder1_txt_industry2~ContentPlaceHolder1_txt_org2~ContentPlaceHolder1_txt_desig2~ContentPlaceHolder1_txt_contactno2'))
//	   {
//		 return false;
//	   }
//	 } 
//    else
//    { return true;}
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
     
//     if(document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").value && document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").value != '') 
//     {
//        var Expdate = document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").value;
//        var msplit = Expdate.split("-");
//        var expMon = msplit["1"];
//        var expYr = msplit["2"];
//     }
     //parseInt(document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").value 
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

//  else if(document.getElementById("ContentPlaceHolder1_txtarea_reason").value=="")
//  {
//     alert("Please enter the reason to join this course");
//     document.getElementById("ContentPlaceHolder1_txtarea_reason").value="";
//     document.getElementById("ContentPlaceHolder1_txtarea_reason").focus();
//     document.getElementById("ContentPlaceHolder1_txtarea_reason").style.border="#ff0000 1px solid";
//     document.getElementById("ContentPlaceHolder1_txtarea_reason").style.backgroundColor="#e8ebd9";
//     return false;
//  }
//  else if(document.getElementById("ContentPlaceHolder1_ddl_whenmonth").value=="")
//  {
//     alert("Please select the month");
//     document.getElementById("ContentPlaceHolder1_ddl_whenmonth").value="";
//     document.getElementById("ContentPlaceHolder1_ddl_whenmonth").focus();
//     document.getElementById("ContentPlaceHolder1_ddl_whenmonth").style.border="#ff0000 1px solid";
//     document.getElementById("ContentPlaceHolder1_ddl_whenmonth").style.backgroundColor="#e8ebd9";
//     return false;
//  }
//  else if(document.getElementById("ContentPlaceHolder1_txt_whenyear").value=="")
//  {
//     alert("Please enter the year");
//     document.getElementById("ContentPlaceHolder1_txt_whenyear").value="";
//     document.getElementById("ContentPlaceHolder1_txt_whenyear").focus();
//     document.getElementById("ContentPlaceHolder1_txt_whenyear").style.border="#ff0000 1px solid";
//     document.getElementById("ContentPlaceHolder1_txt_whenyear").style.backgroundColor="#e8ebd9";
//     return false;
//  }
//  else if(document.getElementById("ContentPlaceHolder1_txtarea_howuknw").value=="")
//  {
//     alert("Please mention how you know about Image");
//     document.getElementById("ContentPlaceHolder1_txtarea_howuknw").value="";
//     document.getElementById("ContentPlaceHolder1_txtarea_howuknw").focus();
//     document.getElementById("ContentPlaceHolder1_txtarea_howuknw").style.border="#ff0000 1px solid";
//     document.getElementById("ContentPlaceHolder1_txtarea_howuknw").style.backgroundColor="#e8ebd9";
//     return false;
//  }
//  
//  else if(trim(document.getElementById("ContentPlaceHolder1_txtarea_heardimage").value)=="")
//  {
//     alert("Please mention list of sources");
//     document.getElementById("ContentPlaceHolder1_txtarea_heardimage").value="";
//     document.getElementById("ContentPlaceHolder1_txtarea_heardimage").focus();
//     document.getElementById("ContentPlaceHolder1_txtarea_heardimage").style.border="#ff0000 1px solid";
//     document.getElementById("ContentPlaceHolder1_txtarea_heardimage").style.backgroundColor="#e8ebd9";
//     return false;
//  }
  	if(checkValidation(courserecommend1) < f7.length && !emptyValidation(courserecommend1)) {
		return false;
	}
	else if(checkValidation(courserecommend2) < f8.length && !emptyValidation(courserecommend2)) {
		return false;
	}
	else if(checkValidation(mediaindus1) < f9.length && !emptyValidation(mediaindus1)) {
		return false;
	}
	else if(checkValidation(mediaindus2) < f10.length && !emptyValidation(mediaindus2)) {
		return false;
	}
   else if(document.getElementById("ContentPlaceHolder1_ddl_fundplann").value=="")
  {
     alert("Please mention your fund plan");
     document.getElementById("ContentPlaceHolder1_ddl_fundplann").focus();
     document.getElementById("ContentPlaceHolder1_ddl_fundplann").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_ddl_fundplann").style.backgroundColor="#e8ebd9";
     return false;
  }
  else if(document.getElementById("check_loan").checked == true &&  document.getElementById("ContentPlaceHolder1_txt_loan").value == "")
  {
     alert("Please mention loan details");
     document.getElementById("ContentPlaceHolder1_txt_loan").focus();
     document.getElementById("ContentPlaceHolder1_txt_loan").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_loan").style.backgroundColor="#e8ebd9";
      return false;
  }
   else if(document.getElementById("check_sponsor").checked == true && document.getElementById("ContentPlaceHolder1_txt_sponsor").value == "")
   {
     alert("Please mention sponsorship details");
     document.getElementById("ContentPlaceHolder1_txt_sponsor").focus();
     document.getElementById("ContentPlaceHolder1_txt_sponsor").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_sponsor").style.backgroundColor="#e8ebd9";
     return false;
   } 
    else if(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value=="")
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
  else if(document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='tvm-1' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-101' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-102' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-103' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-106')
  {
  
                    if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Certificate')
                  {
                  
                            if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 2500)
                              {
                                 alert("Enrollment amount is Less ,Use Registration link.");
                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
                                 location.href = 'QuickAdmission.aspx';
                                 return false;
                              }
                  }
                  else if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Diploma')
                  {
                  
                            if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 5000)
                              {
                                 alert("Enrollment amount is Less ,Use Registration link.");
                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
                                  location.href = 'QuickAdmission.aspx';
                                 return false;
                              }
                  }
                  
                  
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
   else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)))
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
//      else if(document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == true && document.getElementById("ContentPlaceHolder1_txt_dateofissue").value == "")
//   {
//      alert("Enter select date of issue");
//      document.getElementById("ContentPlaceHolder1_txt_dateofissue").focus();
//      document.getElementById("ContentPlaceHolder1_txt_dateofissue").style.border="#ff0000 1px solid";
//      document.getElementById("ContentPlaceHolder1_txt_dateofissue").style.backgroundColor="#e8ebd9";
//      return false;
//    } 
//     else if(document.getElementById("ContentPlaceHolder1_radiobtnnri").checked == true && document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").value == "")
//   {
//      alert("Select date of expiry");
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").focus();
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").style.border="#ff0000 1px solid";
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").style.backgroundColor="#e8ebd9";
//      return false;
//    } 
//     else if(parseInt(expMon)< parseInt(curr_month) && parseInt(expYr)== parseInt(curr_year) )
//	 {
//	  alert("Expiry Date Is not valid");
//	   document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").focus();
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").style.border="#ff0000 1px solid";
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").style.backgroundColor="#e8ebd9";
//	 return false;
//	  }
//    else if(parseInt(expYr)< parseInt(curr_year) && parseInt(expYr)!= parseInt(curr_year) )
//	{
//	  alert("Expiry Year Is not valid");
//	   document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").focus();
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").style.border="#ff0000 1px solid";
//      document.getElementById("ContentPlaceHolder1_txt_dateofexpiry").style.backgroundColor="#e8ebd9";
//	  return false;
//	}
//    
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
 
 var i;
    for(i=0;i<coursetrack.length;i++)
    {
   
       if(parseInt(coursetrack[i]["course_id"]) == document.getElementById("ContentPlaceHolder1_txt_coursenamee").value)
        {
          
   document.getElementById("ContentPlaceHolder1_hdncoursetype").value=coursetrack[i]["coursetype"];
 
        }
    
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

<div id="tabs">
<input type="hidden" id="hdnTab" name="hdnTab" value="Admission" />
<input type="hidden" id="hdncou_id" name="hdncou_id" runat="server"/>
<ul>
      <li><a href="#tabs-1"  class="selector">Step1</a></li>
      <li><a href="#tabs-2" >Step2</a></li>
        <li><a href="#tabs-3" >Step3</a></li>
         
    </ul>
 <div class="clear"></div>
 <div class="white-cont">	
		
			<div id="tabs-1">
			 <div class="free-forms">
          <h4 class="cont-title2">Admission Form</h4>
          </div>
          <h4 class="cont-title3">Personal Particulars</h4>
          <div class="padd-cont">
            <div class="form-cont2"> 
      <ul>
              <li>
                  <label class="label-txt">First Name</label>
          <asp:TextBox CssClass="text input-txt" ID="txt_firstname" onkeypress="return AllowAlphabet(event)" MaxLength="50" runat="server"></asp:TextBox>
      </li>
      <li>
                  <label class="label-txt">Last Name</label>
    <asp:TextBox CssClass="text input-txt" ID="txt_lastname" onkeypress="return AllowAlphabet(event)" MaxLength="50" runat="server"></asp:TextBox></li>
    <li>
                  <label class="label-txt">Mother Tongue</label>
          <asp:TextBox CssClass="text input-txt" ID="txt_mothertongue" onkeypress="return AllowAlphabet(event)" MaxLength="50" runat="server"></asp:TextBox></li>
      <li>
                  <label class="label-txt">Martial Status</label><asp:DropDownList ID="ddl_maritalstatus" runat="server" CssClass="sele-txt">
           <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Single">Single</asp:ListItem>
          <asp:ListItem Value="Married">Married</asp:ListItem>
          </asp:DropDownList></li>
   <li>
                  <label class="label-txt">Gender</label>
          <asp:DropDownList ID="ddl_gender" runat="server" CssClass="sele-txt">
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Male">Male</asp:ListItem>
          <asp:ListItem Value="Female">Female</asp:ListItem>
          </asp:DropDownList></li>
     <li>
                  <label class="label-txt">Date of Birth</label>
                  <span class="date-pick-cont">
                  <asp:TextBox ID="txt_dob" CssClass="text datepicker date-input-txt" runat="server"></asp:TextBox></span></li>
   <li>
                  <label class="label-txt">Nationality</label>
          <asp:TextBox ID="txt_nationality1" onkeypress="return AllowAlphabet(event)" MaxLength="30" CssClass="text input-txt" runat="server" Visible="False"></asp:TextBox>
          <asp:DropDownList id="txt_nationality" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Indian</asp:ListItem>
                    <asp:ListItem>NRI</asp:ListItem>
                </asp:DropDownList></li>
      <li>
                  <label class="label-txt">Blood Group</label>
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
          </asp:DropDownList></li>
   <li>
                  <label class="label-txt">Mobile</label>
          <asp:TextBox CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" ID="txt_mobile" MaxLength="10" runat="server"></asp:TextBox></li>
      <li>
                  <label class="label-txt">Alternate Mobile</label>
            <asp:TextBox CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" ID="txt_altmobile" MaxLength="10" runat="server"></asp:TextBox></li>
    <li>
                  <label class="label-txt">Email</label>
          <asp:TextBox CssClass="text input-txt" MaxLength="50" ID="txt_email" runat="server"></asp:TextBox></li>
      <li>
                  <label class="label-txt">Alternate Email</label>
                  <asp:TextBox CssClass="text input-txt" MaxLength="50" ID="txt_altemail" runat="server" ></asp:TextBox></li>
        <li>
                  <label class="label-txt">
                         Phone</label>
                      <asp:TextBox ID="txt_permanentphone" runat="server" CssClass="text input-txt" MaxLength="11"
                             onkeypress="return CheckNumeric(event)"></asp:TextBox></li>
  <li>
  <div style="text-align:center">
            <strong>Note</strong>:<span  class="error"> As appearing in your&nbsp;
        Academic Records / Certificates</span></div></li>
        </ul>
        <div class="clear"></div></div></div>
   
   
   <h4 class="cont-title3">Parent / Guardian's Particulars:</h4>
          <div class="padd-cont">
            <div class="form-cont2"> 
      <ul>
              <li>
                  <label class="label-txt">Parent / Guardian's Name</label>
                  <asp:TextBox CssClass="text input-txt" onkeypress="return AllowAlphabet(event)" MaxLength="30" ID="txt_guardianname" runat="server"></asp:TextBox></li>
      <li>
                  <label class="label-txt">Relationship with the Student</label>
                   <asp:TextBox CssClass="text input-txt" onkeypress="return AllowAlphabet(event)" MaxLength="30" ID="txt_relationship" runat="server"></asp:TextBox></li>
    <li>
                  <label class="label-txt">Mobile</label>
                  <asp:TextBox CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="11" ID="txt_guardianmobile" runat="server"></asp:TextBox></li>
      <li>
                  <label class="label-txt">Phone (Office)</label>
                  <asp:TextBox CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="11" ID="txt_guardianphone" runat="server"></asp:TextBox></li>
     <li>
                  <label class="label-txt">
                         Email</label>                   
                     <asp:TextBox CssClass="text input-txt" MaxLength="30" ID="txt_guardianemail" runat="server"></asp:TextBox>
                        </li>
                        </ul>
                        <div class="clear"></div></div></div> 
    
    
    
     <h4 class="cont-title3">Professional Details of Parent / Guardian (Optional)</h4>
          <div class="padd-cont">
            <div class="form-cont2"> 
      <ul>
              <li>
                  <label class="label-txt">   
                         Company</label>
                    <input type="text" id="txt_company" name="txt_company" runat="server" class="text input-txt" maxlength="40" /></li>
                     <li>
                  <label class="label-txt">  
                         Employment Status</label>                     
                         <asp:DropDownList ID="ddl_empstatus" runat="server" CssClass="sele-txt">
                         <asp:ListItem Value="In service">In service</asp:ListItem>
                         <asp:ListItem Value="Retired">Retired</asp:ListItem>
                         </asp:DropDownList></li>
                <li>
                  <label class="label-txt">Designation</label>
                  <input type="text" onkeypress="return AllowAlphabet(event)" id="txt_designation" name="txt_designation" runat="server" class="text input-txt" maxlength="40" /></li>
      <li>
                  <label class="label-txt">Place of Work</label>
                  <input type="text" onkeypress="return AllowAlphabet(event)" id="txt_workPlace" name="txt_workPlace" runat="server" class="text input-txt" maxlength="30" /></li>
    <li>
                  <label class="label-txt">Type of Industry</label>
                  
                  <input type="text" id="txt_industryType" onkeypress="return AllowAlphabet(event)" name="txt_industryType" runat="server" class="text input-txt" maxlength="30" /></li>
      <li>
                  <label class="label-txt">Monthly Income</label>
                  <input type="text" onKeyPress="return CheckNumeric(event)" id="txt_income" name="txt_income" runat="server" class="text input-txt" maxlength="7" /></li>
    <li>
                  <label class="label-txt">Proprietorship / Partnership (if Self Employed)</label>
                  <input type="text" onkeypress="return AllowAlphabet(event)" id="txt_selfemployed" name="txt_selfemployed" runat="server" class="text input-txt" maxlength="30" /></li>
   </ul>
   <div class="clear"></div></div></div>
   
   
    <h4 class="cont-title3">Address for Correspondence</h4>
          <div class="padd-cont">
            <div class="form-cont2"> 
      <ul>
              <li>
                  <label class="label-txt">   
  Present Address</label>
  <input type="text" id="txt_presentaddress" name="txt_presentaddress" runat="server" class="text input-txt" width="260px" maxlength="30" /></li>
      <li>
                  <label class="label-txt">
          District /Taluk</label>
          <input type="text" id="txt_presentdistrict" onkeypress="return AllowAlphabet(event)" name="txt_presentdistrict" runat="server" class="text input-txt" maxlength="30" /></li>
    <li>
                  <label class="label-txt">
                         City</label>
                    <asp:TextBox ID="txtpresentcity" runat="server" CssClass="text input-txt" MaxLength="20" onkeypress="return AllowAlphabet(event)"></asp:TextBox></li>
                   <li>
                  <label class="label-txt">
                         State</label>
                      <input type="text" id="txt_presentstate" onkeypress="return AllowAlphabet(event)" name="txt_presentstate" runat="server" class="text input-txt" maxlength="30" /></li>
                <li>
                  <label class="label-txt">
             Pin</label>
                         <input type="text" onkeypress="return CheckNumeric(event)" id="txt_presentpin" name="txt_presentpin" runat="server" class="text input-txt" maxlength="6" /></li>
       </ul><div class="clear"></div></div></div>
       
      <h4 class="cont-title3">
      please check if the address is same as above<asp:CheckBox ID="CheckBox1" OnClick="javascript:return checkaddress();" runat="server" /></h4>
          <div class="padd-cont">
            <div class="form-cont2"> 
      <ul>
              <li>
                  <label class="label-txt">         
      Permanent Address</label>
      <input type="text" id="txt_permanentaddress" name="txt_permanentaddress" runat="server" class="text input-txt" maxlength="30"  /></li>
      <li>
                  <label class="label-txt"> District /Taluk</label>
                  <input type="text" onkeypress="return AllowAlphabet(event)" id="txt_permanentdistrict" name="txt_permanentdistrict" runat="server" class="text input-txt" maxlength="30" onclick="return income_onclick()" /></li>
    <li>
                  <label class="label-txt"> 
                         City</label>
                     <asp:TextBox ID="txtpermanentcity" runat="server" CssClass="text input-txt" MaxLength="20"
                             onkeypress="return AllowAlphabet(event)"></asp:TextBox></li>
                     <li>
                  <label class="label-txt"> 
                         State</label>
                 <input type="text" onkeypress="return AllowAlphabet(event)" id="txt_permanentstate" name="txt_permanentstate" runat="server" class="text input-txt" maxlength="20" /></li>
                <li>
                  <label class="label-txt"> 
            Pin</label>
   <input type="text" onkeypress="return CheckNumeric(event)" id="txt_permanentpin" name="txt_permanentpin" runat="server" class="text input-txt" maxlength="6" /></li>
      
       </ul><div class="clear"></div>
       <div style="text-align:center">
         <input id="admnextstep1" type="button" value="Next Step" class="btnStyle1"/>
            <input id="Reset1" type="reset" value="Reset" title="Reset" class="reset-btn" /></div>
    </div></div>	   
	   </div>
	  <div id="tabs-2">
        <div class="free-forms">         
          <h4 class="cont-title3">Academic Qualification: (Please select whichever is applicable)</h4>
        
          <div class="padd-cont form-cont6">
            <ul>
              <li class="txt-li">
                <label class="label-txt3">Qualification</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Major Subjects</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">Name of the School /College</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">City</label>
              </li>
              <li class="txt-li">
                <label class="label-txt3">State</label>
              </li>
            </ul>
            <div class="clear"></div>
            <ul>
              <li>
                <input type="text" id="ddlprimary" style="width:85px" onkeypress="return AllowAlphabet(event)" name="ddlprimary" runat="server" class="text input-txt" maxlength="30" />
              </li>
              <li>
                <input type="text" id="txt_tenthmajor" style="width:85px" onkeypress="return AllowAlphabet(event)" name="txt_tenthmajor" runat="server" class="text  input-txt" maxlength="30" />
              </li>
              <li>
                <input type="text" id="txt_tenthinstitution" style="width:150px" onkeypress="return AllowAlphabet(event)" name="txt_tenthinstitution" runat="server" class="text input-txt" maxlength="30" />
              </li>
              <li>
               <input type="text" id="txt_tenthcity" style="width:85px" onkeypress="return AllowAlphabet(event)" name="txt_tenthcity" class="text input-txt" runat="server" maxlength="30" />
              </li>
              <li>
                <input type="text" id="txt_tenthstate" style="width:85px" onkeypress="return AllowAlphabet(event)" name="txt_tenthstate" class="text input-txt" runat="server" maxlength="30" />
              </li>
            </ul>
            <div class="clear"></div>
          </div>


	  
     		
  
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
         <input id="admnextstep2" type="button" value="Next Step" class="btnStyle1" />
                <input id="Reset2" type="reset" value="Reset"  title="Reset" class="btnStyle2"/>
 
         </div>
          </div>
        </div>
      </div>  
 <div id="tabs-3">
			   <div class="free-forms">         
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
                               <asp:HiddenField ID="hdncentrecode" runat="server" />
                <asp:HiddenField ID="hdncoursetype" runat="server" />
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
              <asp:Button ID="btnnext3" CssClass="btnStyle1" runat="server" Text="Submit" OnClientClick="javascript:return admform3();" OnClick="btnnext3_Click1" />
                                       
                                          <input id="Reset5" class="btnStyle2" title="Reset" type="reset" value="Reset" />
                                         
                              <asp:HiddenField ID="hdnlumpamt" runat="server" />
                          <asp:HiddenField ID="hdninitial_Amnt" runat="server" />
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

