<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="Copy of Admission.aspx.cs" Inherits="superadmin_Admission" Title="Admission form" %>
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
   var valid = emptyValidation('ContentPlaceHolder1_txt_firstname~ContentPlaceHolder1_txt_lastname~ContentPlaceHolder1_ddl_maritalstatus~ContentPlaceHolder1_ddl_gender~ContentPlaceHolder1_txt_dob~ContentPlaceHolder1_txt_nationality~ContentPlaceHolder1_txt_mobile~ContentPlaceHolder1_txt_email~ContentPlaceHolder1_txt_guardianname~ContentPlaceHolder1_txt_relationship~ContentPlaceHolder1_txt_presentaddress~ContentPlaceHolder1_txt_presentdistrict~ContentPlaceHolder1_txt_presentstate~ContentPlaceHolder1_txt_presentpin~ContentPlaceHolder1_txt_permanentaddress~ContentPlaceHolder1_txt_permanentdistrict~ContentPlaceHolder1_txt_permanentstate~ContentPlaceHolder1_txt_permanentpin')
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
  if(document.getElementById("ContentPlaceHolder1_ddlprimary").value == "")
   {
       alert("Please enter your highest qualification");
       document.getElementById("ContentPlaceHolder1_ddlprimary").focus();
       document.getElementById("ContentPlaceHolder1_ddlprimary").style.border="#ff0000 1px solid";
       document.getElementById("ContentPlaceHolder1_ddlprimary").style.backgroundColor="#e8ebd9";
       return false; 
       
   } 
	var tenth = 'ContentPlaceHolder1_txt_tenthmajor~ContentPlaceHolder1_txt_tenthinstitution~ContentPlaceHolder1_txt_tenthcity~ContentPlaceHolder1_txt_tenthstate';

    var cbox = 'ContentPlaceHolder1_GraphicDesigning~ContentPlaceHolder1_WebDesigning~ContentPlaceHolder1_chk_3DAnimation~ContentPlaceHolder1_PostProduction~ContentPlaceHolder1_FineArts~ContentPlaceHolder1_Programming~ContentPlaceHolder1_check_2DAnimation~ContentPlaceHolder1_Hardware~ContentPlaceHolder1_GameDesigning~ContentPlaceHolder1_GameProgramming~ContentPlaceHolder1_Networking~ContentPlaceHolder1_FlashScripting';
    var txtbx='ContentPlaceHolder1_txt_institutename1~ContentPlaceHolder1_txt_city1~ContentPlaceHolder1_ddl_digitalstatus';
    var activity='ContentPlaceHolder1_txt_participation1~ContentPlaceHolder1_txt_participation2';
  
    var empdet='ContentPlaceHolder1_txt_stu_organization~ContentPlaceHolder1_txt_stu_employment~ContentPlaceHolder1_txt_stu_designation~ContentPlaceHolder1_ddworkingstatus~ContentPlaceHolder1_txt_stu_annualincome';
    
    clearValidation('ContentPlaceHolder1_ddlprimary~'+tenth+'~'+cbox+'~'+txtbx+'~'+activity+'~'+empdet);

	var f5=cbox.split("~");
	var f6=empdet.split("~");
	
	var valid = emptyValidation(tenth);
	if(!valid) {
		return false;
	
	} else if((Cboxvalidation(cbox) < f5.length || Cboxvalidation(cbox)== 13) && Cboxvalidation(cbox) > 0 && !emptyValidation(txtbx)) {
			return false;
	}

	else if(document.getElementById("ContentPlaceHolder1_txt_activity1").value!="" && document.getElementById("ContentPlaceHolder1_txt_participation1").value=="")
	{
	    if(!emptyValidation('ContentPlaceHolder1_txt_participation1')) {
			return false;
		}
	}
	else if(checkValidation(empdet) < f6.length && !emptyValidation(empdet)) {
		return false;
	}
	else if(document.getElementById("ContentPlaceHolder1_txt_activity2").value!="" && document.getElementById("ContentPlaceHolder1_txt_participation2").value=="")
	{
	if(!emptyValidation('ContentPlaceHolder1_txt_participation2')) {
			return false;
		}
    }
    //new
    else if(document.getElementById("ContentPlaceHolder1_txtname_person1").value!="" && document.getElementById("ContentPlaceHolder1_txt_industry1").value=="" && document.getElementById("ContentPlaceHolder1_txt_org1").value=="" && document.getElementById("ContentPlaceHolder1_txt_desig1").value=="" && document.getElementById("ContentPlaceHolder1_txt_contactno1").value=="")
	{
	if(!emptyValidation('ContentPlaceHolder1_txt_industry1~ContentPlaceHolder1_txt_org1~ContentPlaceHolder1_txt_desig1~ContentPlaceHolder1_txt_contactno1'))
	   {
		 return false;
	   }
	 } 
 else if(document.getElementById("ContentPlaceHolder1_txtname_person2").value!="" && document.getElementById("ContentPlaceHolder1_txt_industry2").value=="" && document.getElementById("ContentPlaceHolder1_txt_org2").value=="" && document.getElementById("ContentPlaceHolder1_txt_desig2").value=="" && document.getElementById("ContentPlaceHolder1_txt_contactno2").value=="")
	{
	if(!emptyValidation('ContentPlaceHolder1_txt_industry2~ContentPlaceHolder1_txt_org2~ContentPlaceHolder1_txt_desig2~ContentPlaceHolder1_txt_contactno2'))
	   {
		 return false;
	   }
	 } 
    else
    { return true;}
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
	
 if(document.getElementById("ContentPlaceHolder1_ddl_phydefect").value=="")
  {
    alert("Please Specify yes / no");
     document.getElementById("ContentPlaceHolder1_ddl_phydefect").value="";
     document.getElementById("ContentPlaceHolder1_ddl_phydefect").focus();
     document.getElementById("ContentPlaceHolder1_ddl_phydefect").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_ddl_phydefect").style.backgroundColor="#e8ebd9";
     return false; 
  }
 else if(document.getElementById("ContentPlaceHolder1_ddl_phydefect").value=="Yes" && document.getElementById("ContentPlaceHolder1_txt_defectYes").value=="")
  {
    alert("Please mention details");
     document.getElementById("ContentPlaceHolder1_txt_defectYes").value="";
     document.getElementById("ContentPlaceHolder1_txt_defectYes").focus();
     document.getElementById("ContentPlaceHolder1_txt_defectYes").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_defectYes").style.backgroundColor="#e8ebd9";
     return false; 
  }
 else if(document.getElementById("ContentPlaceHolder1_ddl_clrblind").value=="")
  {
    alert("Please Specify yes / no");
     document.getElementById("ContentPlaceHolder1_ddl_clrblind").value="";
     document.getElementById("ContentPlaceHolder1_ddl_clrblind").focus();
     document.getElementById("ContentPlaceHolder1_ddl_clrblind").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_ddl_clrblind").style.backgroundColor="#e8ebd9";
     return false; 
  }
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
  	else if(checkValidation(courserecommend1) < f7.length && !emptyValidation(courserecommend1)) {
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
 function setFees1()
 {
 //alert(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value);
    document.getElementById("ContentPlaceHolder1_hdncou_id").value=document.getElementById("ContentPlaceHolder1_txt_coursenamee").value;
    var programFees=setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value,document.getElementById("ContentPlaceHolder1_ddl_payment").value);
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
 var programFees=setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value,"Lump sum");
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
	var selectbox=document.getElementById("ContentPlaceHolder1_tx