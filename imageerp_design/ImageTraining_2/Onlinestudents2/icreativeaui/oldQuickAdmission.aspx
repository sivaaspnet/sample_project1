<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="QuickAdmission.aspx.cs" Inherits="Onlinestudents2_Default2" Title="Express Enrollment" %>

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

function validate()
 {
 var start = document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value;
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
 
 var start1 = document.getElementById("ContentPlaceHolder1_txt_installdate").value;
        var start_s1 = start1.split("-");
        var stDate1 = parseInt(start_s1[2]+start_s1[1]+start_s1[0]);
        
        var d1 = new Date();
        var curr_date1 = d1.getDate();
        var curr_month1 = d1.getMonth();
        curr_month1++;
        var curr_year1 = d1.getFullYear();
        var mon1 =  (curr_month1 < 10 ? '0' : '') + curr_month1
        var dday1 =  (curr_date1 < 10 ? '0' : '') + curr_date1
        var toDate1 = parseInt(curr_year1 +''+ mon1 +''+ dday1);
        //var csDate = stDate - toDate;
        var csDate1 = parseInt(stDate1 - toDate1);
 if(document.getElementById("ContentPlaceHolder1_txtname").value=="")
 {
    document.getElementById("ContentPlaceHolder1_txtname").value=="";
    document.getElementById("ContentPlaceHolder1_txtname").focus();
    document.getElementById("ContentPlaceHolder1_txtname").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txtname").style.backgroundColor="#e8ebd9"
    return false;
 }
  else if(document.getElementById("ContentPlaceHolder1_txtmobile").value=="")
 {
    document.getElementById("ContentPlaceHolder1_txtmobile").value=="";
    document.getElementById("ContentPlaceHolder1_txtmobile").focus();
    document.getElementById("ContentPlaceHolder1_txtmobile").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txtmobile").style.backgroundColor="#e8ebd9"
    return false;
 }
 
 else if(document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="")
 {
    document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="";
    document.getElementById("ContentPlaceHolder1_ddl_aboutimage").focus();
    document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.backgroundColor="#e8ebd9"
    return false;
 }
 else if(document.getElementById("ContentPlaceHolder1_ddl_profile").value=="")
 {
    document.getElementById("ContentPlaceHolder1_ddl_profile").value=="";
    document.getElementById("ContentPlaceHolder1_ddl_profile").focus();
    document.getElementById("ContentPlaceHolder1_ddl_profile").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_ddl_profile").style.backgroundColor="#e8ebd9"
    return false;
 }
 
 
  else if(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value=="")
 {
    document.getElementById("ContentPlaceHolder1_txt_coursenamee").value=="";
    document.getElementById("ContentPlaceHolder1_txt_coursenamee").focus();
    document.getElementById("ContentPlaceHolder1_txt_coursenamee").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txt_coursenamee").style.backgroundColor="#e8ebd9"
    return false;
 }
  else if(document.getElementById("ContentPlaceHolder1_ddtrack").value=="")
 {
    document.getElementById("ContentPlaceHolder1_ddtrack").value=="";
    document.getElementById("ContentPlaceHolder1_ddtrack").focus();
    document.getElementById("ContentPlaceHolder1_ddtrack").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_ddtrack").style.backgroundColor="#e8ebd9"
    return false;
 }
  else if(document.getElementById("ContentPlaceHolder1_ddl_payment").value=="")
 {
    document.getElementById("ContentPlaceHolder1_ddl_payment").value=="";
    document.getElementById("ContentPlaceHolder1_ddl_payment").focus();
    document.getElementById("ContentPlaceHolder1_ddl_payment").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_ddl_payment").style.backgroundColor="#e8ebd9"
    return false;
 }
 else if(document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value=="")
 {
    document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value=="";
    document.getElementById("ContentPlaceHolder1_txt_coursedatedate").focus();
    document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.backgroundColor="#e8ebd9"
    return false;
 }
  else if(csDate < 0)
          {
             document.getElementById("ContentPlaceHolder1_txt_coursedatedate").value=="";
             alert("Invalid start date");
             document.getElementById("ContentPlaceHolder1_txt_coursedatedate").focus();
             document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_coursedatedate").style.backgroundColor="#e8ebd9";
             return false;
          }
  else if(document.getElementById("ContentPlaceHolder1_txt_installdate").value=="")
 {
    document.getElementById("ContentPlaceHolder1_txt_installdate").value=="";
    document.getElementById("ContentPlaceHolder1_txt_installdate").focus();
    document.getElementById("ContentPlaceHolder1_txt_installdate").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txt_installdate").style.backgroundColor="#e8ebd9"
    return false;
 }
 else if(csDate1 < 0)
          {
             document.getElementById("ContentPlaceHolder1_txt_installdate").value=="";
             alert("Invalid Installment date");
             document.getElementById("ContentPlaceHolder1_txt_installdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_installdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_installdate").style.backgroundColor="#e8ebd9";
             return false;
          }
 else if(document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value=="")
 {
    document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value=="";
    document.getElementById("ContentPlaceHolder1_ddlpaymentmode").focus();
    document.getElementById("ContentPlaceHolder1_ddlpaymentmode").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_ddlpaymentmode").style.backgroundColor="#e8ebd9"
    return false;
 }
 
 else if(document.getElementById("ContentPlaceHolder1_ddlpaymentmode").value !="Cash")
 {
   if(document.getElementById("ContentPlaceHolder1_txtchequeno").value =="")
    {
    document.getElementById("ContentPlaceHolder1_txtchequeno").value=="";
    document.getElementById("ContentPlaceHolder1_txtchequeno").focus();
    document.getElementById("ContentPlaceHolder1_txtchequeno").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txtchequeno").style.backgroundColor="#e8ebd9"
    return false;
    }
     else if(document.getElementById("ContentPlaceHolder1_txtchequeno0").value =="")
    {
    document.getElementById("ContentPlaceHolder1_txtchequeno0").value=="";
    document.getElementById("ContentPlaceHolder1_txtchequeno0").focus();
    document.getElementById("ContentPlaceHolder1_txtchequeno0").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txtchequeno0").style.backgroundColor="#e8ebd9"
    return false;
    }
    
   else if(document.getElementById("ContentPlaceHolder1_txtbankname").value =="")
    {
    document.getElementById("ContentPlaceHolder1_txtbankname").value=="";
    document.getElementById("ContentPlaceHolder1_txtbankname").focus();
    document.getElementById("ContentPlaceHolder1_txtbankname").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txtbankname").style.backgroundColor="#e8ebd9"
    return false;
    }
    else
    {
    return true;
    }
    
 }
 else if(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value=="" )
  {
     alert("Please mention initial amount");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
  else if(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value=="0" )
  {
     alert("Initial amount cannot be Zero");
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
     else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML)))
  {
     alert("Initial amount is greater than the course fee");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
  
//  else if(document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='tvm-1' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-101' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-102' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-103' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-106')
//  {
//  
//  
//                   if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Certificate')
//                  {
//                  
//                            if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 2001)
//                              {
//                                 alert("Enrollment amount is Less ,Use Registration link.");
//                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
//                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
//                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
//                                 location.href = 'QuickAdmission.aspx';
//                                 return false;
//                              }
//                  }
//                  else if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Diploma')
//                  {
//                  
//                            if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 5001)
//                              {
//                                 alert("Enrollment amount is Less ,Use Registration link.");
//                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
//                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
//                                 document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
//                                  location.href = 'QuickAdmission.aspx';
//                                 return false;
//                              }
//                  }
//                  else
//              {
//               return true;
//              }
//  }
  
 
 else
{
return true;
}
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

  else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (document.getElementById("ContentPlaceHolder1_txt_instalamt1").value == ""))
  {
     alert("Please mention the no of installments"); 
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9";
     return false;
  }
     else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_netamount").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML)))
  {
     alert("Initial amount is greater than the course fee");
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
     return false;
  }
//  else if(document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='tvm-1' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-101' || document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-102' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-103' ||document.getElementById("ContentPlaceHolder1_hdncentrecode").value=='ICH-106')
//  {
//  
//               if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Certificate')
//              {
//              
//                        if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 2001)
//                          {
//                             alert("Enrollment amount is Less ,Use Registration link.");
//                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
//                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
//                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
//                               location.href = 'QuickAdmission.aspx';
//                             return false;
//                           
//                          }
//              }
//              else if(document.getElementById("ContentPlaceHolder1_hdncoursetype").value=='Diploma')
//              {
//              
//                        if((parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value)) < 5001)
//                          {
//                             alert("Enrollment amount is Less ,Use Registration link.");
//                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").focus();
//                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.border="#ff0000 1px solid";
//                             document.getElementById("ContentPlaceHolder1_txt_lumpinitial").style.backgroundColor="#e8ebd9";
//                               location.href = 'QuickAdmission.aspx';
//                             return false;
//                          }
//              }
//              else
//              {
//               return true;
//              }
//}
  else
  {
  
  
  
   //amt_ex_initial=parseInt(document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-parseInt(document.getElementById("txt_lumpinitial").value);
  //alert(document.getElementById("ContentPlaceHolder1_lbllumpamt").value);
  //alert(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value);
  amt_ex_initial=parseInt((document.getElementById("ContentPlaceHolder1_lbllumpamt").value)-(document.getElementById("ContentPlaceHolder1_txt_netamount").value));
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
                 document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFees[i]["tax"];
                  document.getElementById("ContentPlaceHolder1_HiddenField2").value=courseFees[i]["tax"];
               
             
             }
            else if(feesType=="Installment")
            {
               document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFees[i]["instal_amount"];   
               document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFees[i]["instal_amount"]; 
               document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFees[i]["instal_amount"];  
                document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFees[i]["tax"];
                 document.getElementById("ContentPlaceHolder1_HiddenField2").value=courseFees[i]["tax"];
              
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
 function display()
     {
    // alert("");
		 if(document.getElementById("ContentPlaceHolder1_ddl_payment").value=="Lump sum") 
			{
				document.getElementById("lump1").style.display='table-row';
				document.getElementById("lump2").style.display='none';
				document.getElementById("lump3").style.display='table-row';
				document.getElementById("lump4").style.display='none';
			}
			else  if(document.getElementById("ContentPlaceHolder1_ddl_payment").value=="Installment") 
		
			{
				document.getElementById("lump1").style.display='table-row';
				document.getElementById("lump2").style.display='table-row';
				document.getElementById("lump3").style.display='table-row';
				document.getElementById("lump4").style.display='table-row';
			}
			else
             {
                document.getElementById("lump1").style.display='none';
				document.getElementById("lump2").style.display='none';
                document.getElementById("lump3").style.display='none';
				document.getElementById("lump4").style.display='none';
              }
     }
 function changepayment()
 {
 document.getElementById("ContentPlaceHolder1_ddl_payment").value="";
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
     
 function taxcalc()
 {
document.getElementById("ContentPlaceHolder1_txtamtmonthly").value="";
var tax=parseFloat(document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML);
//var tax=10.3;
 if(document.getElementById("ContentPlaceHolder1_CheckBox1").checked)
 {   
 var intial_course_amt =(100*(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value))/(100+tax);
 document.getElementById("ContentPlaceHolder1_txt_netamount").value=Math.round(intial_course_amt, 0);
 var vat_tax=intial_course_amt*(tax/100);
 document.getElementById("ContentPlaceHolder1_txt_vat").value=Math.round(vat_tax, 0);

 document.getElementById("ContentPlaceHolder1_netamount").value=Math.round(intial_course_amt, 0)+Math.round(vat_tax, 0);
 
 
 }
 else
 {

var intial_course_amt =(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value);
 document.getElementById("ContentPlaceHolder1_txt_netamount").value=Math.round(intial_course_amt, 0);
 var vat_tax=intial_course_amt*(tax/100);
 document.getElementById("ContentPlaceHolder1_txt_vat").value=Math.round(vat_tax, 0);
  document.getElementById("ContentPlaceHolder1_netamount").value=Math.round(intial_course_amt, 0)+Math.round(vat_tax, 0);
 
 }
 
 
 }
 
 
//quick receipt validation start




function add()
 {

 if(trim(document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value)=="")
         {    
             alert("Please select course");
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").value = "";
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").focus();
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_coursepositioned").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_studname").value)=="")
         {    
             alert("Please Enter Student Name");
             document.getElementById("ContentPlaceHolder1_txt_studname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_studname").focus();
             document.getElementById("ContentPlaceHolder1_txt_studname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studname").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_TextBox1").value)=="")
         {    
             alert("Please Enter Student Contact No");
             document.getElementById("ContentPlaceHolder1_TextBox1").value = "";
             document.getElementById("ContentPlaceHolder1_TextBox1").focus();
             document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
             return false;
         }
         
     else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value=="")
         {    
             alert("Please Select Payment mode");
             document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_ddcc").value == "")
         {    
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "")
         {    
             alert("Please enter cheque Date");
             document.getElementById("ContentPlaceHolder1_dddate").value = "";
             document.getElementById("ContentPlaceHolder1_dddate").focus();
             document.getElementById("ContentPlaceHolder1_dddate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_dddate").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_bankname").value == "")
         {    
             alert("Please enter Bank name");
             document.getElementById("ContentPlaceHolder1_txt_bankname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_bankname").focus();
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         
         
        else if(trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)==""   )
         {    
             alert("Please Enter Initial Amount");
             document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)=="0"   )
         {    
             alert("Please Enter Initial Amount");
             document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(isNaN(document.getElementById("ContentPlaceHolder1_txt_initialamt").value))
         {    
             alert("Please Enter amount in numerics");
             document.getElementById("ContentPlaceHolder1_txt_initialamt").value = "";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").focus();
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_initialamt").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_initialamt").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_lblbalanceamount").innerHTML)))
         {    
             alert("Please Check Your Installment Amount is Greater Than Balance Amount");
//             //document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = "";
//             document.getElementById("ContentPlaceHolder1_lblamtwithtax").focus();
//             document.getElementById("ContentPlaceHolder1_lblamtwithtax").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_lblamtwithtax").style.backgroundColor="#e8ebd9";
             return false;
         }
       
        else if(document.getElementById("ContentPlaceHolder1_ddl_month").value=="")
         {    
             alert("Please select Month");
             document.getElementById("ContentPlaceHolder1_ddl_month").value = "";
             document.getElementById("ContentPlaceHolder1_ddl_month").focus();
             document.getElementById("ContentPlaceHolder1_ddl_month").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_month").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value=="")
         {    
             alert("Please Select Payment mode");
             document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_ddcc").value == "")
         {    
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "")
         {    
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_bankname").value == "")
         {    
             alert("Please enter Bank name");
             document.getElementById("ContentPlaceHolder1_txt_bankname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_bankname").focus();
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else
         {
        
         return true;
         }
 
   
 }
 function test_skill(rup) {
	var junkVal=rup;
	junkVal=Math.floor(junkVal);
	var obStr=new String(junkVal);
	numReversed=obStr.split("");
	actnumber=numReversed.reverse();

	if(Number(junkVal) >=0){
		//do nothing
	}
	else{
		alert('wrong Number cannot be converted');
		return false;
	}
	if(Number(junkVal)==0){
		document.getElementById('container').innerHTML=obStr+''+'Rupees Zero Only';
		return false;
	}
	if(actnumber.length>9){
		alert('Oops!!!! the Number is too big to covertes');
		return false;
	}

	var iWords=["Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"];
	var ePlace=['Ten', ' Eleven', ' Twelve', ' Thirteen', ' Fourteen', ' Fifteen', ' Sixteen', ' Seventeen', ' Eighteen', ' Nineteen'];
	var tensPlace=['dummy', ' Ten', ' Twenty', ' Thirty', ' Forty', ' Fifty', ' Sixty', ' Seventy', ' Eighty', ' Ninety' ];

	var iWordsLength=numReversed.length;
	var totalWords="";
	var inWords=new Array();
	var finalWord="";
	j=0;
	for(i=0; i<iWordsLength; i++){
		switch(i)
		{
		case 0:
			if(actnumber[i]==0 || actnumber[i+1]==1 ) {
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			inWords[j]=inWords[j]+' Only';
			break;
		case 1:
			tens_complication();
			break;
		case 2:
			if(actnumber[i]==0) {
				inWords[j]='';
			}
			else if(actnumber[i-1]!=0 && actnumber[i-2]!=0) {
				inWords[j]=iWords[actnumber[i]]+' Hundred and';
			}
			else {
				inWords[j]=iWords[actnumber[i]]+' Hundred';
			}
			break;
		case 3:
			if(actnumber[i]==0 || actnumber[i+1]==1) {
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			if(actnumber[i+1] != 0 || actnumber[i] > 0){
				inWords[j]=inWords[j]+" Thousand";
			}
			break;
		case 4:
			tens_complication();
			break;
		case 5:
			if(actnumber[i]==0 || actnumber[i+1]==1 ) {
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			inWords[j]=inWords[j]+" Lakh";
			break;
		case 6:
			tens_complication();
			break;
		case 7:
			if(actnumber[i]==0 || actnumber[i+1]==1 ){
				inWords[j]='';
			}
			else {
				inWords[j]=iWords[actnumber[i]];
			}
			inWords[j]=inWords[j]+" Crore";
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
		if(actnumber[i]==0) {
			inWords[j]='';
		}
		else if(actnumber[i]==1) {
			inWords[j]=ePlace[actnumber[i-1]];
		}
		else {
			inWords[j]=tensPlace[actnumber[i]];
		}
	}
	inWords.reverse();
	for(i=0; i<inWords.length; i++) {
		finalWord+=inWords[i];
	}
	document.getElementById('ContentPlaceHolder1_txt_paymentwords').innerHTML=finalWord;
	document.getElementById('ContentPlaceHolder1_hdnpayinword').value=finalWord;
	
}

 function calctax(amtwit)
{
	var initial=parseInt(amtwit.value);
	//alert(initial);
var tax=parseFloat(document.getElementById("ContentPlaceHolder1_HiddenField2").value);
	var taxcal = parseFloat(initial /(tax+100));
	//alert(taxcal);
	var taxcalh = parseFloat(taxcal*100);
	//alert(taxcalh);
	//var totinitialtax=parseFloat(initial - taxcalh);
	var totinitialtax=parseFloat(taxcalh);
	//alert(totinitialtax);
	//totinitialtax=Math.round(totinitialtax)
	//alert(totinitialtax);
	totinitialtax=Math.round(totinitialtax,0)
	//alert(totinitialtax);
	document.getElementById("ContentPlaceHolder1_lblamtwithtax").innerHTML = totinitialtax;
	document.getElementById("ContentPlaceHolder1_hdnamt_tax").value = initial;
	test_skill(initial);
	document.getElementById("ContentPlaceHolder1_hdninitamt").value =amtwit.value;
	
}
//end
	

     
     
</script>
  <div id="parent">
    <ul>
      <li><a href="#tabs-6">Registration</a></li>
      <li><a href="#tabs-5">Express Enrollment</a></li>
    </ul>
    <div id="tabs-6">
      <div class="free-forms">
        <TABLE class="common" width=100% border="0" cellpadding="0" cellspacing="0">
          <TBODY>
            <TR>
              <TD colspan="2" style="padding:0px;"><H4>Registration</H4></TD>
            </TR>
            <TR>
              <TD class="formlabel">Course Code</TD>
              <TD><asp:DropDownList id="txt_coursepositioned" runat="server"  CssClass="select" AutoPostBack="True" OnSelectedIndexChanged="txt_coursepositioned_SelectedIndexChanged" > </asp:DropDownList></TD>
            </TR>
            <TR>
              <TD class="formlabel">Student Name</TD>
              <TD><asp:TextBox id="txt_studname" runat="server" CssClass="text" TextMode="SingleLine" MaxLength="30"></asp:TextBox></TD>
            </TR>
             <TR>
              <TD class="formlabel">Contact No</TD>
              <TD><asp:TextBox id="TextBox1" runat="server" CssClass="text" MaxLength="10" onkeypress="return CheckNumeric(event)" TextMode="SingleLine" ></asp:TextBox></TD>
            </TR>
         <tr>
            <td class="formlabel">
                Payment Mode</td>
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
                checque/D.D&nbsp; Date</td>
            <td style="height: 37px">
                <asp:TextBox ID="dddate" runat="server" CssClass="text datepicker" Width="123px"></asp:TextBox></td>
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
                  <asp:ListItem Value="Jun">Jun</as