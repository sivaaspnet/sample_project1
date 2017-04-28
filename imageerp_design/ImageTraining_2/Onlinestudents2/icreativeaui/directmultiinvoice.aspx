<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="directmultiinvoice.aspx.cs" Inherits="Onlinestudents2_directmultiinvoice" Title="Direct Multi Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txt_studentid").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
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
 if(document.getElementById("ContentPlaceHolder1_txt_studentid").value=="")
 {
    document.getElementById("ContentPlaceHolder1_txt_studentid").value=="";
    document.getElementById("ContentPlaceHolder1_txt_studentid").focus();
    document.getElementById("ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9"
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
  else if(document.getElementById("ContentPlaceHolder1_txt_lumpinitial").value<=0 )
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
  else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)))
    {
        alert(" Please enter less than or equal to (maximum number of installments)");
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").value=="";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9"
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
  else if((document.getElementById("ContentPlaceHolder1_ddl_payment").value == 'Installment') && (parseInt(document.getElementById("ContentPlaceHolder1_txt_instalamt1").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML)))
    {
        alert(" Please enter less than or equal to (maximum number of installments)");
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").value=="";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").focus();
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_instalamt1").style.backgroundColor="#e8ebd9"
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
                     document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFeesfast[i]["tax"];
                }
                else if(feesType=="Installment")
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFeesfast[i]["instal_amount"];   
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFeesfast[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFeesfast[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFeesfast[i]["tax"];
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
                       document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFeesnormal[i]["tax"];
                    document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesnormal[i]["noofinstall"];
                }
                else if(feesType=="Installment")
                {
                    document.getElementById("ContentPlaceHolder1_txt_lumpamt").innerHTML=courseFeesnormal[i]["instal_amount"];   
                    document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFeesnormal[i]["instal_amount"]; 
                    document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFeesnormal[i]["instal_amount"]; 
                       document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFeesnormal[i]["tax"];
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

  // alert(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value);
    document.getElementById("ContentPlaceHolder1_hdncou_id").value=document.getElementById("ContentPlaceHolder1_txt_coursenamee").value;
    var programFees=setFees(document.getElementById("ContentPlaceHolder1_txt_coursenamee").value,document.getElementById("ContentPlaceHolder1_ddl_payment").value,document.getElementById("ContentPlaceHolder1_ddtrack").value.toLowerCase());
 }   
 function display()
     {
//     alert("");
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
 
 function vvl()
 {
 if(document.getElementById('ContentPlaceHolder1_txt_studentid').value=="")
 {
  alert("Please Enter Student Id");
             document.getElementById("ContentPlaceHolder1_txt_studentid").focus();
             document.getElementById("ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9";
             return false;
 }
 else
 
{
return true;
}
 }
     
     
</script>
	<div class="title-cont">
    <h3 class="cont-title">Mulitple Invoice/Course Upgrade</h3>
    </div>
  <div class="white-cont">
        <div class="form-cont">
          <ul class="no-borders">
            <li>
              <div align="center">
                 <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
              </div>
            </li>
            <li>
              <label class="label-txt">Student Id <span style="color: #ff0000">*</span></label>
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text input-txt" MaxLength="20"></asp:TextBox>
            </li>
            <li style="text-align:center;">
              <div align="center" style="padding-bottom:25px;">
               <asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClick="Button2_Click"
                    Text="submit" OnClientClick="return vvl();" />
                  
                    <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_studentid"></asp:CustomValidator>
   
				  <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
              </div>
            </li>
          </ul>
          <div class="clear"></div>
        </div>
      </div>
  
  
  
  
  <div class="white-cont">
        <div class="form-cont">
       
        <ul class="no-borders">                
         <li>
              <div align="center">
                <asp:Label ID="lbl_coursename" runat="server" ForeColor="Blue"></asp:Label>
              </div>
            </li>
                  <li>
            <label class="label-txt"> 
               Course Positioned <span style="color: red">* </span></label>
                  <asp:DropDownList ID="txt_coursenamee" runat="server" CssClass="sele-txt" onchange="changepayment();">
                </asp:DropDownList></li>
      <li>
            <label class="label-txt"> 
               Track <span style="color: #ff0000">*</span></label>
              <asp:DropDownList ID="ddtrack" runat="server" CssClass="sele-txt" onchange="setFees1();">
                    <asp:ListItem Value="Fast">Fast</asp:ListItem>
                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
                    <asp:ListItem Value="Zip">Zip</asp:ListItem>
                </asp:DropDownList></li>
       <li runat="server" id="paypattern">
            <label class="label-txt"> 
             Payment Pattern <span style="color: #ff0000">*</span></label>
              <asp:DropDownList ID="ddl_payment" runat="server" onchange="setFees1();display(this.value);" CssClass="sele-txt">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Lump sum">Lump sum</asp:ListItem>
                    <asp:ListItem Value="Installment">Installment</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="netamount" runat="server" />
            </li>
         <li>
            <label class="label-txt">Course Fees </label>
                           <span id="txt_lumpamt" runat="server"></span>
                      <asp:HiddenField ID="lbllumpamt" runat="server" />
             </li>
                      
          <li id="lump3">
            <label class="label-txt">
              Initial Amount to be paid </label>
               <asp:TextBox ID="txt_lumpinitial" runat="server" CssClass="text  input-txt" MaxLength="7" onkeypress="return CheckNumeric(event)" onkeyup="return taxcalc();"></asp:TextBox>
              <asp:CheckBox ID="CheckBox1" runat="server" Text="Include tax" OnClick="return taxcalc();" Width="84px" /></li>
            
                <li id="lump2">
            <label class="label-txt">
              			No. of Installments </label>
                 <asp:TextBox ID="txt_instalamt1" runat="server" CssClass="text  input-txt" MaxLength="2" onkeypress="return CheckNumeric(event)"></asp:TextBox>
              <asp:Button ID="Button3" runat="server" OnClientClick="return checkval();" Text="Calculation" CssClass="btnStyle1" /><br />
              <div  style="margin-left:320px"> Maximum  number of installments : 
                  <asp:Label ID="lblmaxinstallnumber" runat="server" Text="0" CssClass="error"></asp:Label></div></li>
                       <li>
            <label class="label-txt">
                            Course amount  </label>                  
                            <asp:TextBox ID="txt_netamount" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text  input-txt" MaxLength="10"></asp:TextBox>
                   </li>       
                      <li>
            <label class="label-txt">
                            VAT at 
                            <asp:Label ID="lbl_tax" runat="server"></asp:Label>%</label>
                           <asp:TextBox ID="txt_vat" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text input-txt" MaxLength="10"></asp:TextBox>
                            </li>
                        <li id="lump4">
            <label class="label-txt">
                    Amount To be paid per month</label>
                        <asp:TextBox ID="txtamtmonthly" runat="server" CssClass="text input-txt" MaxLength="7" onkeypress="return CheckNumeric(event)" ReadOnly="True"></asp:TextBox>
                    <li>
            <label class="label-txt">
                           Coursestart date <span style="color: #ff0000">*</span></label>
                   <span class="date-pick-cont">
                  <asp:TextBox ID="txt_coursedatedate" runat="server" CssClass="text datepicker date-input-txt"  
                                 onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                                 </span>
                                 </li>
                    <li>
            <label class="label-txt">
                            Installment Date <span style="color: #ff0000">*</span></label>
                     <span class="date-pick-cont">    <asp:TextBox ID="txt_installdate" runat="server" CssClass="text datepicker date-input-txt"  
                                onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                                </span></li>
                    <li>
            <label class="label-txt">
                           Payment Mode <span style="color: #ff0000">*</span></label>
                         <asp:DropDownList ID="ddlpaymentmode" runat="server" onchange="cashval()" CssClass="sele-txt">
                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                <asp:ListItem Value="D.D">D.D</asp:ListItem>
                                <asp:ListItem Value="Creditcard">Creditcard</asp:ListItem>
                            </asp:DropDownList></li>
                    <li>
            <label class="label-txt">
                            Cheque/D.D. No/C.C No</label>
                <asp:TextBox ID="txtchequeno" runat="server" CssClass="text  input-txt" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
                   </li>
                      <li>
            <label class="label-txt">
                            Bank Name</label>
                 <asp:TextBox ID="txtbankname" runat="server" CssClass="text input-txt" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox>
                  </li>
                    <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">
                            <asp:Button ID="btnsubmit5" runat="server" CssClass="btnStyle1" 
                                OnClientClick="javascript:return validate();" Text="Submit" OnClick="btnsubmit5_Click1"  />
                            <asp:Button ID="Button1" runat="server" CssClass="reset-btn" 
                                Text="Reset" /></div>
                                </li>
                                </ul>
                                 <asp:HiddenField ID="hdnlumpamt" runat="server" />
                            <input id="hdnTab" name="hdnTab" type="hidden" value="Admission" /><input id="hdncou_id"
                                runat="server" name="hdncou_id" type="hidden" />
                                <div class="clear"></div>
                  </div>                  
   
    </div>
</asp:Content>

