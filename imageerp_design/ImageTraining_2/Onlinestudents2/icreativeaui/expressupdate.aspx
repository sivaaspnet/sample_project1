<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="expressupdate.aspx.cs" Inherits="superadmin_Admission" Title="Admission form" %>
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
/*document.getElementById("ContentPlaceHolder1_hdncou_id").value=document.getElementById("ContentPlaceHolder1_txt_coursenamee").value;
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
	*/
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
   else if(document.getElementById("ContentPlaceHolder1_txt_install").value=="")
  {
    alert("Please Specify no.of install");
     document.getElementById("ContentPlaceHolder1_txt_install").value="";
     document.getElementById("ContentPlaceHolder1_txt_install").focus();
     document.getElementById("ContentPlaceHolder1_txt_install").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_install").style.backgroundColor="#e8ebd9";
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
				<li><a href="#tabs-1" style="color:black; font-weight:bold;">Step1</a></li><li><a href="#tabs-2" style="color:black; font-weight:bold;">Step2</a></li><li><a href="#tabs-3" style="color:black; font-weight:bold;">Step3</a></li></ul>
			<div id="tabs-1">
			    <div class="free-forms">
			 <table class="common" cellpadding="0" cellspacing="0" Width="100%">
    <tr>
     <td colspan="6" valign="top" style=" padding:0px; height: 24px;"><h3 style="font-weight:bold; margin:0px; color:orange;">Admission Form</h3></td></tr>
     <tr> <td colspan="6" valign="top" style=" padding:0px;"><h4>Personal Particulars:</h4></td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
            <label for="firstName" >First Name</label>&nbsp;</td>
      <td  align="left" valign="top" style="height: 29px; width: 138px;">
          <asp:TextBox CssClass="text" ID="txt_firstname" onkeypress="return AllowAlphabet(event)" MaxLength="50" runat="server"></asp:TextBox></td>
      <td  align="left" valign="top" style="height: 29px; width: 110px;" class="formlabel"><label for="lastName">Last Name</label></td>
      <td  align="left" valign="top" style="height: 29px" colspan="2">&nbsp;<asp:TextBox CssClass="text" ID="txt_lastname" onkeypress="return AllowAlphabet(event)" MaxLength="50" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px" valign="top" class="formlabel">
            <label for="languare">Mother Tongue</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px">
          <asp:TextBox CssClass="text" ID="txt_mothertongue" onkeypress="return AllowAlphabet(event)" MaxLength="50" runat="server"></asp:TextBox></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="martialStatus">Martial Status</label></td>
      <td align="left" valign="top" colspan="2">&nbsp;<asp:DropDownList ID="ddl_maritalstatus" runat="server">
           <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Single">Single</asp:ListItem>
          <asp:ListItem Value="Married">Married</asp:ListItem>
          </asp:DropDownList></td>
    </tr>
    
                     <tr>
                         <td align="left" colspan="2" style="width: 135px" valign="top" class="formlabel">
                             <label for="languare">Gender</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px">
          <asp:DropDownList ID="ddl_gender" runat="server">
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Male">Male</asp:ListItem>
          <asp:ListItem Value="Female">Female</asp:ListItem>
          </asp:DropDownList></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="martialStatus">Date of Birth</label></td>
      <td align="left" valign="top" colspan="2">&nbsp;<asp:TextBox ID="txt_dob" CssClass="text datepicker" runat="server" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px" valign="top" class="formlabel">
            <label for="nationality">Nationality</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px">
          <asp:TextBox ID="txt_nationality1" onkeypress="return AllowAlphabet(event)" MaxLength="30" CssClass="text" runat="server" Visible="False"></asp:TextBox>
          <asp:DropDownList id="txt_nationality" runat="server">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Indian</asp:ListItem>
                    <asp:ListItem>NRI</asp:ListItem>
                </asp:DropDownList></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="bloodGroup" >Blood Group</label></td>
      <td align="left" valign="top" colspan="2">&nbsp;<asp:DropDownList ID="ddl_bloodgroup" runat="server">
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
      <td align="left" valign="top" style="width: 135px" colspan="2" class="formlabel"><label for="mobile">Mobile</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px" class="formlabel">
          <asp:TextBox CssClass="text" onKeyPress="return CheckNumeric(event)" ID="txt_mobile" MaxLength="10" runat="server"></asp:TextBox></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="altMobile">Alternate Mobile</label></td>
        <td align="left" colspan="2" valign="top">
            &nbsp;<asp:TextBox CssClass="text" onKeyPress="return CheckNumeric(event)" ID="txt_altmobile" MaxLength="10" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px" valign="top" class="formlabel">
            <label for="email">Email</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px">
          <asp:TextBox CssClass="text" MaxLength="50" ID="txt_email" runat="server" ></asp:TextBox></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="altEmail">Alternate Email</label></td>
      <td align="left" valign="top" colspan="2"><asp:TextBox CssClass="text" MaxLength="50" ID="txt_altemail" runat="server" ></asp:TextBox>
         </td>
    </tr>
                 <tr>
                     <td align="left" colspan="2" style="width: 135px; height: 31px;" valign="top" class="formlabel">
                         Phone</td>
                     <td align="left" style="width: 138px; height: 31px;" valign="top">
                         <asp:TextBox ID="txt_permanentphone" runat="server" CssClass="text" MaxLength="11"
                             onkeypress="return CheckNumeric(event)"></asp:TextBox></td>
                     <td align="left" style="width: 110px; height: 31px;" valign="top" class="formlabel">
                         Batch Timing</td>
                     <td align="left" colspan="2" valign="top" style="height: 31px">
                         <asp:DropDownList ID="ddlbatchtime" runat="server" CssClass="select">
                             <asp:ListItem Value="7AM-9AM">7AM-9AM</asp:ListItem>
                             <asp:ListItem Value="9AM-11AM">9AM-11AM</asp:ListItem>
                             <asp:ListItem Value="11AM-1PM">11AM-1PM</asp:ListItem>
                             <asp:ListItem Value="1PM-3PM">1PM-3PM</asp:ListItem>
                             <asp:ListItem Value="3PM-5PM">3PM-5PM</asp:ListItem>
                             <asp:ListItem Value="5PM-7PM">5PM-7PM</asp:ListItem>
                             <asp:ListItem Value="7PM-9PM">7PM-9PM</asp:ListItem>
                         </asp:DropDownList></td>
                 </tr>
    <tr>
        <td align="left" colspan="6" style="height: 23px" valign="top" >
            <strong>Note</strong>:<span style=" color:Red;"> As appearing in your&nbsp;
        Academic Records / Certificates<asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label></span></td>
    </tr>
    <tr>
      <td colspan="6" align="left" valign="top" style=" padding:0px;"><h4>Parent / Guardian's Particulars:</h4></td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
            <label for="guardianName">Parent / Guardian's Name</label>&nbsp;</td>
      <td align="left" valign="top" style="height: 29px; width: 138px;"> <asp:TextBox CssClass="text" onkeypress="return AllowAlphabet(event)" MaxLength="30" ID="txt_guardianname" runat="server"></asp:TextBox> </td>
      <td align="left" valign="top" style="height: 29px; width: 110px;" class="formlabel"><label for="studentRelation">Relationship with the Student</label></td>
      <td align="left" valign="top" style="height: 29px" colspan="2" >&nbsp;<asp:TextBox CssClass="text" onkeypress="return AllowAlphabet(event)" MaxLength="30" ID="txt_relationship" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px" valign="top" class="formlabel">
            <label for="mobileGuard">Mobile</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px"><asp:TextBox CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="11" ID="txt_guardianmobile" runat="server"></asp:TextBox></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel">Phone (Office)</td>
      <td align="left" valign="top" colspan="2">&nbsp;<asp:TextBox CssClass="text" onKeyPress="return CheckNumeric(event)" MaxLength="11" ID="txt_guardianphone" runat="server"></asp:TextBox></td>
    </tr>
                 <tr>
                     <td align="left" colspan="2" style="width: 135px" valign="top" class="formlabel">
                         Email</td>
                     <td align="left" valign="top" style="width: 138px">
                     <asp:TextBox CssClass="text" MaxLength="30" ID="txt_guardianemail" runat="server"></asp:TextBox>
                        </td>
                     <td align="left" colspan="3" valign="top">
                     </td>
                 </tr>
    <tr>
      <td colspan="6" align="left" valign="top"></td>
    </tr>
    <tr>
      <td colspan="6" align="left" valign="top" style=" padding:0px;"><h4>Professional Details of Parent / Guardian (Optional)</h4></td>
    </tr>
                 <tr>
                     <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
                         Company</td>
                     <td align="left" valign="top" style="height: 29px; width: 138px;">
                         <input type="text" id="txt_company" name="txt_company" runat="server" class="text" maxlength="40" /></td>
                     <td align="left" valign="top" style="height: 29px; width: 110px;" class="formlabel">
                         Employment Status</td>
                     <td align="left" valign="top" style="height: 29px" colspan="2">
                         <asp:DropDownList ID="ddl_empstatus" runat="server">
                         <asp:ListItem Value="In service">In service</asp:ListItem>
                         <asp:ListItem Value="Retired">Retired</asp:ListItem>
                         </asp:DropDownList></td>
                 </tr>
    <tr>
      <td align="left" valign="top" style="width: 135px" colspan="2" class="formlabel"><label for="designation">Designation</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px"><input type="text" onkeypress="return AllowAlphabet(event)" id="txt_designation" name="txt_designation" runat="server" class="text" maxlength="40" /></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="workPlace" >Place of Work</label></td>
      <td align="left" valign="top" colspan="2"><input type="text" onkeypress="return AllowAlphabet(event)" id="txt_workPlace" name="txt_workPlace" runat="server" class="text" maxlength="30" /></td>
    </tr>
    <tr>
      <td align="left" valign="top" style="width: 135px" colspan="2" class="formlabel"><label for="industryType">Type of Industry</label>&nbsp;</td>
      <td align="left" valign="top" style="width: 138px"><input type="text" id="txt_industryType" onkeypress="return AllowAlphabet(event)" name="txt_industryType" runat="server" class="text" maxlength="30" /></td>
      <td align="left" valign="top" style="width: 110px" class="formlabel"><label for="income" >Monthly Income</label></td>
      <td align="left" valign="top" colspan="2"><input type="text" onKeyPress="return CheckNumeric(event)" id="txt_income" name="txt_income" runat="server" class="text" maxlength="7" /></td>
    </tr>
    <tr>
      <td align="left" valign="top" style="height: 29px; width: 135px;" colspan="2" class="formlabel"><label for="partnership">Proprietorship / Partnership (if Self Employed)</label>&nbsp;</td>
      <td colspan="4" align="left" valign="top" style="height: 29px"><input type="text" onkeypress="return AllowAlphabet(event)" id="txt_selfemployed" name="txt_selfemployed" runat="server" class="text" maxlength="30" /></td>
    </tr>
     <tr>
        <td align="left" colspan="6" valign="top"></td>
    </tr>
    <tr>
       <td align="left" colspan="6" valign="top" style=" padding:0px;"><h4>Address for Correspondence:</h4></td>
    </tr>
                 
    <tr>
        <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
            <label for="industryType">Present Address</label>&nbsp;</td>
      <td align="left" valign="top" style="height: 29px; width: 138px;"><input type="text" id="txt_presentaddress" name="txt_presentaddress" runat="server" class="text" maxlength="30" /></td>
      <td align="left" valign="top" style="height: 29px; width: 110px;" class="formlabel"><label for="income">
          District /Taluk</label></td>
      <td align="left" valign="top" style="height: 29px" colspan="2"><input type="text" id="txt_presentdistrict" onkeypress="return AllowAlphabet(event)" name="txt_presentdistrict" runat="server" class="text" maxlength="30" /></td>
    </tr>
                 <tr>
                     <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
                         City</td>
                     <td align="left" style="width: 138px; height: 29px" valign="top">
                         <asp:TextBox ID="txtpresentcity" runat="server" CssClass="text" MaxLength="20" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
                     <td align="left" style="width: 110px; height: 29px" valign="top" class="formlabel">
                         State</td>
                     <td align="left" colspan="2" style="height: 29px" valign="top">
                      <input type="text" id="txt_presentstate" onkeypress="return AllowAlphabet(event)" name="txt_presentstate" runat="server" class="text" maxlength="30" /></td>
                 </tr>
     <tr>
         <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
             Pin</td>
        <td align="left" valign="top" style="height: 29px; width: 138px;">
                         <input type="text" onkeypress="return CheckNumeric(event)" id="txt_presentpin" name="txt_presentpin" runat="server" class="text" maxlength="6" /></td>
        <td align="left" valign="top" style="height: 29px; width: 110px;"></td>
        <td align="left" valign="top" style="height: 29px" colspan="2">
                         </td>
     </tr>
     <tr>
          <td align="left" colspan="6" valign="top" style=" padding:0px;"><h4>please check if the address is same as above<asp:CheckBox ID="CheckBox1" OnClick="javascript:return checkaddress();" runat="server" /></h4></td>
     </tr>
     <tr>
         <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
             <label for="industryType">Permanent Address</label>&nbsp;</td>
      <td align="left" valign="top" style="height: 29px; width: 138px;"><input type="text" id="txt_permanentaddress" name="txt_permanentaddress" runat="server" class="text" maxlength="30" /></td>
      <td align="left" valign="top" style="height: 29px; width: 110px;" class="formlabel"><label for="income" >District /Taluk</label></td>
      <td align="left" valign="top" style="height: 29px" colspan="2">&nbsp;<input type="text" onkeypress="return AllowAlphabet(event)" id="txt_permanentdistrict" name="txt_permanentdistrict" runat="server" class="text" maxlength="30" onclick="return income_onclick()" /></td>
    </tr>
                 <tr>
                     <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
                         City</td>
                     <td align="left" style="width: 138px; height: 29px" valign="top">
                         <asp:TextBox ID="txtpermanentcity" runat="server" CssClass="text" MaxLength="20"
                             onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
                     <td align="left" style="width: 110px; height: 29px" valign="top" class="formlabel">
                         State</td>
                     <td align="left" colspan="2" style="height: 29px" valign="top">
                         <input type="text" onkeypress="return AllowAlphabet(event)" id="txt_permanentstate" name="txt_permanentstate" runat="server" class="text" maxlength="20" /></td>
                 </tr>
    <tr>
        <td align="left" colspan="2" style="width: 135px; height: 29px" valign="top" class="formlabel">
            Pin</td>
       <td align="left" valign="top" style="height: 29px; width: 138px;">
            <input type="text" onkeypress="return CheckNumeric(event)" id="txt_permanentpin" name="txt_permanentpin" runat="server" class="text" maxlength="6" /></td>
       <td align="left" valign="top" style="height: 29px; width: 110px;"></td>
        <td align="left" colspan="2" style="height: 29px" valign="top">
            </td>
    </tr>
     <tr>
        <td  colspan="6" valign="top" style="text-align:center;" >
            <br />
         <input id="admnextstep1" type="button" value="Next Step" class="btnStyle1"/>&nbsp;
            <input id="Reset1" type="reset" value="Reset" title="Reset" class="btnStyle2"/>&nbsp;</td>
    </tr>     
    </table>
	</div>
	   </div>
	   
	   
	   
	   
	   <div id="tabs-2">
		     <div class="free-forms">		
  <table class="common"  cellpadding="0" cellspacing="0" width="100%" >
    <tr>
      <td colspan="6" style="padding:0px;"><h4>Academic Qualification: (Please select whichever is applicable)</h4></td>
    </tr>
    <tr>
      <td align="left" valign="top" style="height: 18px"><b> Qualification</b></td>
      <td align="left" valign="top" style="height: 18px" colspan="2"><b> Major Subjects</b></td>
      <td align="left" valign="top" style="height: 18px"><b> Name of the School /College</b></td>
      <td align="left" valign="top" style="height: 18px"><b>City</b></td>
      <td align="left" valign="top" style="height: 18px"><b>State</b></td>
    </tr>
    <tr>
      <td style="height: 29px"><input type="text" id="ddlprimary" style="width:85px" onkeypress="return AllowAlphabet(event)" name="ddlprimary" runat="server" class="text" maxlength="30" />
          </td>
      <td colspan="2" style="height: 29px"><input type="text" id="txt_tenthmajor" style="width:85px" onkeypress="return AllowAlphabet(event)" name="txt_tenthmajor" runat="server" class="text" maxlength="30" /></td>
      <td style="height: 29px"><input type="text" id="txt_tenthinstitution" style="width:150px" onkeypress="return AllowAlphabet(event)" name="txt_tenthinstitution" runat="server" class="text" maxlength="30" /></td>
      <td style="height: 29px"><input type="text" id="txt_tenthcity" style="width:85px" onkeypress="return AllowAlphabet(event)" name="txt_tenthcity" class="text" runat="server" maxlength="30" /></td>
      <td style="height: 29px"><input type="text" id="txt_tenthstate" style="width:85px" onkeypress="return AllowAlphabet(event)" name="txt_tenthstate" class="text" runat="server" maxlength="30" /></td>
    </tr>
    
  </table>
           <br />
  <table class="common" cellpadding="0" cellspacing="0" style="width: 100%;">
    <tr>
      <td colspan="4" style="padding:0px;"><h4>Education in Digital Media and related fields (Optional)</h4></td>
    </tr>
    <tr>
      <td colspan="4" style="height: 23px"><b>Select if you have completed , attended or currently pursuing any course in any
          (Optional)</b></td>
    </tr>
    <tr>
      <td style="height: 27px" ><input type="checkbox"  id="GraphicDesigning" name="GraphicDesigning" value="GraphicDesigning" runat="server" />
        Graphic Designing</td>
      <td style="height: 27px"><input type="checkbox" id="WebDesigning" name="WebDesigning" value="WebDesigning"  runat="server" />
        Web Designing</td>
      <td style="height: 27px"><input type="checkbox" id="chk_3DAnimation" name="chk_3DAnimation" value="3D Animation" runat="server" />
        3D Animation</td>
      <td style="height: 27px" ><input type="checkbox" id="PostProduction" name="PostProduction" value="PostProduction" runat="server" />
        Post Production</td>
    </tr>
    <tr>
     <td style="height: 27px" ><input type="checkbox" id="FineArts" name="FineArts" value="FineArts" runat="server" />
        Fine Arts</td>
      <td style="height: 27px"><input type="checkbox" id="Programming" name="Programming" value="Programming" runat="server" />
        Programming</td>
      <td style="height: 27px"><input type="checkbox" id="check_2DAnimation" name="2DAnimation" value="2DAnimation" runat="server" />
        2D Animation</td>
      <td style="height: 27px"><input type="checkbox" id="Hardware" name="Hardware" value="Hardware" runat="server" />
        Hardware</td>
    </tr>
    <tr>
      <td style="height: 27px"><input type="checkbox" id="GameDesigning" name="GameDesigning" value="GameDesigning" runat="server" />
        Game Designing</td>
      <td style="height: 27px"><input type="checkbox" id="GameProgramming" name="GameProgramming" value="GameProgramming" runat="server" />
        Game Programming</td>
      <td style="height: 27px"><input type="checkbox" id="Networking" name="Networking" value="Networking" runat="server" />
        Networking</td>
      <td style="height: 27px"><input type="checkbox" id="FlashScripting" name="FlashScripting" value="FlashScripting" runat="server" />
        Flash Scripting</td>
    </tr>
  </table>
           <br />
  <table class="common"  cellpadding="0" cellspacing="0" width="100%">
    <tr>
      <td  align="left" valign="top" style="height: 20px; padding-bottom:0px;">
          &nbsp;Institution Name</td>
      <td  align="left" valign="top" style="height: 20px; padding-bottom:0px;">
          City</td>
      <td  align="left" valign="top" style="height: 20px; padding-bottom:0px;">
          Status of Completion</td>
    </tr>
    <tr>
      <td align="left" valign="top" style="height: 29px">
      <input name="txt_institutename1" maxlength="30" onkeypress="return AllowAlphabet(event)" type="text" runat="server" class="text institution" id="txt_institutename1" /></td>
      <td align="left" valign="top" style="height: 29px">
      <input name="txt_city1" maxlength="30" onkeypress="return AllowAlphabet(event)" type="text" runat="server" class="text" id="txt_city1" value=" " size="50" /></td>
      <td align="left" valign="top" style="height: 29px">
          <asp:DropDownList ID="ddl_digitalstatus" runat="server" Width="230px">
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Completed">Completed</asp:ListItem>
          <asp:ListItem Value="Pursuing">Pursuing</asp:ListItem>
          </asp:DropDownList>
          </td>
    </tr>
    <tr>
      <td align="left" valign="top" style="height: 29px">
      <input id="txt_institutename2" maxlength="30" name="txt_institutename2" onkeypress="return AllowAlphabet(event)" type="text" runat="server" class="text" /></td>
      <td align="left" valign="top" style="height: 29px">
      <input name="txt_city2" maxlength="30" onkeypress="return AllowAlphabet(event)" type="text" runat="server" class="text" id="txt_city2" /></td>
      <td align="left" valign="top" style="height: 29px">
       <asp:DropDownList ID="ddl_digitalstatus2" runat="server" Width="230">
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Completed">Completed</asp:ListItem>
          <asp:ListItem Value="Pursuing">Pursuing</asp:ListItem>
          </asp:DropDownList>
       </td>
    </tr>
  </table>
           <br />
  
  <table class="common" cellpadding="0" cellspacing="0" width="100%">
    <tr>
      <td colspan="5" style="padding:0px;"><h4>Employment Details (If any)</h4></td>
    </tr>
    <tr>
        <td>
            Name of the Organization&nbsp;</td>
        <td>
            Period of Employment&nbsp;</td>
        <td>
            Designation&nbsp;</td>
        <td>
            Current Status&nbsp;</td>
      <td>
          Annual Income</td>
    </tr>
    <tr>
        <td align="left"  rowspan="1" style="height: 29px" valign="top">
            <input name="txt_stu_organization" maxlength="40" onkeypress="return AllowAlphabet(event)" type="text" runat="server" class="text" style="width:100px;"  id="txt_stu_organization" />
            &nbsp;</td>
        <td align="left"  rowspan="1" style="height: 29px" valign="top">
            <input name="txt_stu_employment"  maxlength="30" style="width:100px;" type="text" runat="server" class="text" id="txt_stu_employment" />&nbsp;</td>
        <td align="left"  rowspan="1" style="height: 29px" valign="top">
            <input name="txt_stu_designation" maxlength="30" onkeypress="return AllowAlphabet(event)" type="text" runat="server" class="text" style="width:100px;" id="txt_stu_designation"/>&nbsp;</td>
        <td align="left"  style="height: 29px" valign="top">
          <asp:DropDownList ID="ddworkingstatus" runat="server" >
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Working">Working</asp:ListItem>
          <asp:ListItem Value="NotWorking">Not Working</asp:ListItem>
          </asp:DropDownList>
            &nbsp;</td>
        <td align="left" colspan="1" style="height: 29px" valign="top">
            <input name="txt_stu_annualincome"  onkeypress="return CheckNumeric(event)" style="width:100px;" maxlength="7" type="text" runat="server" class="text" id="txt_stu_annualincome" /></td>
    </tr>
  </table>
           <br />
		   
	
	
		   
  
	
	
  <table  class="common" cellpadding="0" cellspacing="0"  width="100%">
    <tr>
      <td colspan="18" style=" padding:0px;"><h4>Extra Curricular Activities:</h4></td>
    </tr>
    <tr>
      <td colspan="2" style=""><b>Activity</b>&nbsp;</td>
      <td align="left" valign="top" ><b>Participation level (Zonal, District, State, School)</b></td>
      <td colspan="14" rowspan="4" align="left" valign="top">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="height: 29px;">
            <input name="txt_activity1" onkeypress="return AllowAlphabet(event)" maxlength="30" type="text" runat="server" class="text" id="txt_activity1" />&nbsp;</td>
      <td >
          <asp:DropDownList ID="txt_participation1" runat="server" Width="230px">
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Zonal">Zonal</asp:ListItem>
          <asp:ListItem Value="District">District</asp:ListItem>
          <asp:ListItem Value="State">State</asp:ListItem>
          <asp:ListItem Value="School">School</asp:ListItem>
          </asp:DropDownList></td>
    </tr>
    <tr>
      <td style="height: 38px; " colspan="2"><input name="txt_activity2" onkeypress="return AllowAlphabet(event)" maxlength="30" type="text" runat="server" class="text" id="txt_activity2" />&nbsp;</td>
      <td style="height: 38px" >
        <asp:DropDownList ID="txt_participation2" runat="server" Width="230px">
          <asp:ListItem Value="">--Select--</asp:ListItem>
          <asp:ListItem Value="Zonal">Zonal</asp:ListItem>
          <asp:ListItem Value="District">District</asp:ListItem>
          <asp:ListItem Value="State">State</asp:ListItem>
          <asp:ListItem Value="School">School</asp:ListItem>
          </asp:DropDownList>
      </td>
    </tr>
      <tr>
          <td colspan="3" style=" text-align:center;">
         <input id="admnextstep2" type="button" value="Next Step" class="btnStyle1" />&nbsp; &nbsp;<input id="Reset2" type="reset" value="Reset"  title="Reset" class="btnStyle2"/></td>
      </tr>
  </table>
 
  </div>
           <br />
  </div>
  
  
  
  
  
   <div id="tabs-3">
   <div class="free-forms">
  
  
  
                  <table cellpadding="0" cellspacing="0" class="common" width="100%">
                      <tr>
                          <td align="left" colspan="5" valign="top">
                              <table cellpadding="0" cellspacing="0" class="common" width="100%">
                                  <tr>
                                      <td align="left" colspan="5" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                          padding-top: 0px" valign="top">
                                          <h4>
                                              Physical Defect</h4>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left"  valign="top">
                                          <b>Physical defect/chronic illness of a permanent nature if any</b> <span style="color: #ff0000">
                                              *</span></td>
                                      <td align="left" style="height: 27px" valign="top">
                                          <asp:DropDownList ID="ddl_phydefect" runat="server" onChange="chkval1()" Width="240px">
                                              <asp:ListItem Value="">--Select--</asp:ListItem>
                                              <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                              <asp:ListItem Value="No">No</asp:ListItem>
                                          </asp:DropDownList></td>
                                  </tr>
                                  <tr>
                                      <td align="left"  style=" height: 31px" valign="top">
                                          <label for="defectYes">
                                              If Yes, Please Mention Details:</label></td>
                                      <td align="left" valign="top">
                                          <input id="txt_defectYes" style="width:230px" runat="server" class="text" name="txt_defectYes" onfocus="losefocus1(this)"
                                              onkeypress="return AllowAlphabet(event)" type="text" /></td>
                                  </tr>
                                  <tr>
                                      <td align="left"   valign="top">
                                          <label for="blindness">
                                              <b>Color Blindness </b><span style="color: #ff0000">*</span></label></td>
                                      <td align="left" valign="top">
                                          <asp:DropDownList ID="ddl_clrblind" runat="server" Width="240px">
                                              <asp:ListItem Value="">--Select--</asp:ListItem>
                                              <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                              <asp:ListItem Value="No">No</asp:ListItem>
                                          </asp:DropDownList></td>
                                  </tr>
                                  <div id="generalvis" runat="server" visible="false">
                                  </div>
                                  <tr>
                                      <td align="left" colspan="5" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                          padding-top: 0px" valign="top">
                                          <h4>
                                              General Information</h4>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left"   valign="top">
                                          <label for="reasonJoining">
                                              Please provide in brief the reason for joining this course</label></td>
                                      <td style="height: 41px" valign="top">
                                          <asp:TextBox ID="txtarea_reason" runat="server" CssClass="common" onkeypress="return AllowAlphabet(event)"
                                              TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td align="left"  valign="top">
                                          When and how did you hear about IMAGE first?&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td align="right"  style=" width:440px;text-align: right" valign="top">
                                          When &nbsp;&nbsp;
                                      </td>
                                      <td align="left" valign="top">
                                          <asp:DropDownList ID="ddl_whenmonth" runat="server"  Width="180px">
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
                                          <asp:TextBox ID="txt_whenyear" runat="server" CssClass="text" MaxLength="4" onkeypress="return CheckNumeric(event)" Width="230px"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td align="right" style=" height: 28px; text-align: right"
                                          valign="top">
                                          <label for="how">
                                              How &nbsp; &nbsp;
                                          </label>
                                      </td>
                                      <td align="left" style="height: 28px" valign="top">
                                          <asp:TextBox ID="txtarea_howuknw" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"
                                              TextMode="MultiLine" Width="240px" ></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td align="left"  valign="top">
                                          <label for="heardImage">
                                              Give a list of other sources through which you heard about IMAGE</label></td>
                                      <td align="left" valign="top">
                                          <asp:TextBox ID="txtarea_heardimage" runat="server" CssClass="text" onkeypress="return AllowAlphabet(event)"
                                              TextMode="MultiLine" Width="240px"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                      <td align="left"  valign="top">
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left" colspan="5" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                          padding-top: 0px" valign="top">
                                          <h4>
                                              If this course was recommended to you please provide the following details (Optional)</h4>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left" colspan="5" style="height: 128px" valign="top">
                                          <table cellpadding="0" cellspacing="0" class="common" width="100%">
                                              <tr>
                                                  <td  style="padding-bottom: 0px;width:150px; height: 23px">
                                                      Name of the Person</td>
                                                  <td  style="padding-bottom: 0px;width:150px; height: 23px">
                                                      &nbsp;Industry</td>
                                                  <td  style="padding-bottom: 0px;width:150px; height: 23px">
                                                      Organization</td>
                                                  <td  style="padding-bottom: 0px;width:150px; height: 23px">
                                                      Designation</td>
                                                  <td style="padding-bottom: 0px; height: 23px">
                                                      Contact Number</td>
                                              </tr>
                                              <tr>
                                                  <td  style="height: 29px">
                                                      <input id="txtname_person1" runat="server" class="text" name="txtname_person1" onkeypress="return AllowAlphabet(event)"
                                                          type="text" style="width:150px" /></td>
                                                  <td  style="height: 29px">
                                                      <input id="txt_industry1" runat="server" class="text" name="txt_industry1" type="text" style="width:150px" /></td>
                                                  <td  style="height: 29px">
                                                      <input id="txt_org1" runat="server" class="text" name="txt_org1" type="text" style="width:150px"/></td>
                                                  <td  style="height: 29px">
                                                      <input id="txt_desig1" runat="server" class="text" maxlength="20" name="txt_desig1"
                                                          type="text" style="width:150px" /></td>
                                                  <td style="height: 29px">
                                                      <input id="txt_contactno1" runat="server" class="text" maxlength="10" name="txt_contactno1"
                                                          onkeypress="return CheckNumeric(event)" type="text" style="width:150px" /></td>
                                              </tr>
                                              <tr>
                                                  <td >
                                                      <input id="txtname_person2" runat="server" class="text" name="txtname_person2" onkeypress="return AllowAlphabet(event)"
                                                          type="text" style="width:150px" /></td>
                                                  <td >
                                                      <input id="txt_industry2" runat="server" class="text" name="txt_industry2" type="text" style="width:150px" /></td>
                                                  <td >
                                                      <input id="txt_org2" runat="server" class="text" name="txt_org2" type="text" style="width:150px" /></td>
                                                  <td ">
                                                      <input id="txt_desig2" runat="server" class="text" maxlength="20" name="txt_desig2"
                                                          type="text" style="width:150px" /></td>
                                                  <td>
                                                      <input id="txt_contactno2" runat="server" class="text" maxlength="10" name="txt_contactno2"
                                                          onkeypress="return CheckNumeric(event)" type="text" style="width:150px"/></td>
                                              </tr>
                                          </table>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left" colspan="5" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                          padding-top: 0px" valign="top">
                                          <h4>
                                              If you have professional contacts in the media industry, please mention the details
                                              (Optional)</h4>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="left" colspan="5" style="height: 120px" valign="top">
                                          <table cellpadding="0" cellspacing="0" class="common" width="100%">
                                              <tr>
                                                  <td  style="padding-bottom: 0px; width:190px; height: 23px">
                                                      Whom do you know&nbsp;</td>
                                                  <td  style="padding-bottom: 0px; width:190px; height: 23px">
                                                      Company / Institution&nbsp;</td>
                                                  <td  style="padding-bottom: 0px; width:190px; height: 23px">
                                                      Designation&nbsp;</td>
                                                  <td style="padding-bottom: 0px; width:190px; height: 23px">
                                                      Contact Number</td>
                                              </tr>
                                              <tr>
                                                  <td  style="height: 29px">
                                                      <input id="txtwhomknow1" runat="server" class="text" name="txtwhomknow1" onkeypress="return AllowAlphabet(event)"
                                                          type="text" style="width:150px"/></td>
                                                  <td  style="height: 29px">
                                                      <input id="txtcompinst1" runat="server" class="text" name="txtcompinst1" type="text" style="width:150px" /></td>
                                                  <td  style="height: 29px">
                                                      <input id="txtdesig1" runat="server" class="text" maxlength="20" name="txtdesig1"
                                                          type="text" style="width:150px"/></td>
                                                  <td style="height: 29px">
                                                      <input id="txtcontactno1" runat="server" class="text" maxlength="10" name="txtcontactno1"
                                                          onkeypress="return CheckNumeric(event)" type="text" style="width:150px" /></td>
                                              </tr>
                                              <tr>
                                                  <td >
                                                      <input id="txtwhomknow2" runat="server" class="text" name="txtwhomknow2" onkeypress="return AllowAlphabet(event)"
                                                          type="text" style="width:150px" />&nbsp;</td>
                                                  <td >
                                                      <input id="txtcompinst2" runat="server" class="text" name="txtcompinst2" type="text" style="width:150px" />&nbsp;</td>
                                                  <td >
                                                      <input id="txtdesig2" runat="server" class="text" maxlength="20" name="txtdesig2"
                                                          type="text" style="width:150px"/>&nbsp;</td>
                                                  <td>
                                                      <input id="txtcontactno2" runat="server" class="text" maxlength="10" name="txtcontactno2"
                                                          onkeypress="return CheckNumeric(event)" type="text" style="width:150px" /></td>
                                              </tr>
                                          </table>
                                      </td>
                                  </tr>
								  
								  </table>
		  
          <tr>
              <td align="left"  style="height: 23px" valign="top" colspan="5">
                  <strong><span style="font-size: 13px; color: #000; font-family: Helvetica,sans-serif">
                      <h4>
                          Add Installment</h4>
                  </span></strong>
              </td>
          </tr>
          <tr>
              <td align="left"  valign="top" style=" height: 23px;" >
                  <asp:TextBox ID="txt_install" runat="server" CssClass="text" MaxLength="2"></asp:TextBox></td>
              <td align="left" valign="top" style="height: 23px">
                  <script type="text/javascript">display("");</script>
                  </td>
          </tr>
          <tr>
              <td align="left"  valign="top" style="text-align:center;">
                  <br />
                  <asp:Button ID="btnnext3" CssClass="btnStyle1" runat="server" Text="Submit" OnClientClick="return admform3();" OnClick="btnnext3_Click1" />&nbsp; 
                  <input id="Reset3" type="reset" value="Reset"  class="btnStyle2" title="Reset" />
                  <br />
</td>
          </tr>
          
         
      </table>
          <asp:HiddenField ID="hdnlumpamt" runat="server" />
  </div>
  <script type="text/javascript">
  
    changepayment();
  
  </script>
  <p>&nbsp;</p>
   </div>
  
  </div>
  
</asp:Content>

