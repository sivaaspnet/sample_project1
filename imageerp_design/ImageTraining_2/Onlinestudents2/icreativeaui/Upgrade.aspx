<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Upgrade.aspx.cs" Inherits="Onlinestudents2_Default2" Title="Course Upgrade" %>
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
     else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_netamount").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").value)))
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
     else if((parseInt(document.getElementById("ContentPlaceHolder1_txt_netamount").value)) > (parseInt(document.getElementById("ContentPlaceHolder1_txt_lumpamt").value)))
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
  amt_ex_initial=parseInt((document.getElementById("ContentPlaceHolder1_txt_lumpamt").value)-(document.getElementById("ContentPlaceHolder1_txt_netamount").value));
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
                document.getElementById("ContentPlaceHolder1_txt_lumpamt").value=courseFees[i]["lump_sum"];
                document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFees[i]["lump_sum"];
                document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFees[i]["lump_sum"];
                 document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFees[i]["tax"];
               
             
             }
            else if(feesType=="Installment")
            {
               document.getElementById("ContentPlaceHolder1_txt_lumpamt").value=courseFees[i]["instal_amount"];   
               document.getElementById("ContentPlaceHolder1_lbllumpamt").value=courseFees[i]["instal_amount"]; 
               document.getElementById("ContentPlaceHolder1_hdnlumpamt").value=courseFees[i]["instal_amount"];  
                document.getElementById("ContentPlaceHolder1_lbl_tax").innerHTML=courseFees[i]["tax"];
              
            }
            else
            {
            document.getElementById("ContentPlaceHolder1_txt_lumpamt").value = "0";
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
 
 
 $(document).ready(function() {

    $("#ContentPlaceHolder1_txt_studentid").autocomplete('Handler2.ashx');
   // alert("check");  
    }); 
 
     
</script>
<div class="free-forms">
    <table  class="common" width="100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()" >
        <tr>
            <td colspan="2" style=" padding:0px; height: 29px;">
               <h4>Course Upgrade</h4></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
            </td>
            <td style="width: 339px; height: 31px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
    
        <tr>
        <tr>
            <td style="width: 100px; height: 31px">
                <strong>Student Id </strong><span style="color: #ff0000">*</span></td>
            <td style="width: 339px; height: 31px">
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text" MaxLength="20"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClick="Button2_Click"
                    Text="submit" />
                    <br />
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special2" ControlToValidate="txt_studentid"></asp:CustomValidator>
                    
                    </td>
        </tr>
        <tr class="no-borders">
        <td colspan="2" style="width: 357px" runat="server" id="d1" visible="false">
            <asp:Label ID="Label3" runat="server" Text="Invoice Details" Font-Bold="True" Font-Size="Medium"></asp:Label>
            <br />
              <br />
        <table  style="border:solid 1px black; border-collapse:collapse; "  width="100%">
        <tr >
        <td align="center" style="width: 129px; height: 25px;border:solid 2px black;">
            <asp:Label ID="Label7" runat="server" Text="Student ID" Font-Bold="True"></asp:Label>
        </td>
            <td align="center" style="border-right: black 2px solid; border-top: black 2px solid;
                border-left: black 2px solid; width: 129px; border-bottom: black 2px solid; height: 25px">
                <strong>Student Name</strong></td>
        <td align="center" style="height: 25px;border:solid 2px black;">
            <asp:Label ID="Label8" runat="server" Text="Invoice No" Font-Bold="True"></asp:Label>
        </td>
        <td align="center" style="height: 25px;border:solid 2px black;">
            <asp:Label ID="Label9" runat="server" Text="Course Name" Font-Bold="True"></asp:Label>
        </td>
        <td align="center" style="height: 25px;border:solid 2px black;">
            <asp:Label ID="Label10" runat="server" Text="Course Fees" Font-Bold="True"></asp:Label>
        </td>
        <td align="center" style="height: 25px;border:solid 2px black;">
            <asp:Label ID="Label2" runat="server" Text="Pending Amount" Font-Bold="True"></asp:Label>
        </td>
        <td align="center" style="height: 25px;border:solid 2px black;">
            <asp:Label ID="Label11" runat="server" Text="Fees Pending" Font-Bold="True"></asp:Label>
        </td>
        </tr>
        <tr>
        <td style="width: 129px;border:solid 2px black;" align="center">
            <asp:Label ID="sid" runat="server" Text=""></asp:Label>
        </td>
            <td align="center" style="border-right: black 2px solid; border-top: black 2px solid;
                border-left: black 2px solid; width: 129px; border-bottom: black 2px solid">
                <asp:Label ID="Label4" runat="server"></asp:Label></td>
        <td style="width: 129px;border:solid 2px black;" align="center">
            <asp:Label ID="invoice" runat="server" Text=""></asp:Label>
        </td>
        <td style="width: 129px;border:solid 2px black;" align="center">
        <asp:Label ID="Label14" runat="server"></asp:Label>
        </td>
        <td style="width: 129px;border:solid 2px black;" align="center">
            <asp:Label ID="cfees" runat="server" Text=""></asp:Label>
        </td>
         <td style="width: 129px;border:solid 2px black;" align="center">
             <asp:Label ID="pendingamt" runat="server"></asp:Label>
        </td>
        <td style="width: 129px;border:solid 2px black;" align="center">
            <asp:Label ID="Fees_pending" runat="server"></asp:Label>
        </td>
        </tr>
        </table>
     
        </td>
        </tr>
            <tr id="t4" runat="server" visible="false">
                <td style="width: 100px; height: 31px">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Select Course"></asp:Label></td>
                <td style="width: 339px; height: 31px">
                    <asp:DropDownList ID="txt_coursenamee" runat="server">
                    </asp:DropDownList>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </td>
            </tr>
        <tr id="t5" runat="server" visible="false">
            <td style="width: 100px; height: 29px;" >
                <strong>Track</strong> <span style="color: #ff0000">*</span></td>
            <td style="width: 339px; height: 29px;" >
                <asp:DropDownList ID="ddtrack" runat="server" CssClass="select">
                    <asp:ListItem Value="Fast">Fast</asp:ListItem>
                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
           
                </asp:DropDownList></td>
        </tr>
        <tr runat="server" id="paypattern" visible="false">
            <td style="height: 29px; width: 100px;" >
                <strong>Payment Pattern </strong><span style="color: #ff0000">*</span></td>
            <td style="width: 339px; height: 29px;" >
                <asp:DropDownList ID="ddl_payment" runat="server" onchange="display(this.value);setFees1();">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Lump sum">Lump sum</asp:ListItem>
                    <asp:ListItem Value="Installment">Installment</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:HiddenField ID="netamount" runat="server" />
            </td>
        </tr>
        <tr class="no-borders">
            <td colspan="2" id="d2" runat="server" style="height: 231px" visible="false"  >

              
               
                  <table   class="common" style="width: 100%"   >
                    <tr id="lump1">
                          <td style="height: 1px; width: 197px;" >
                              Course Fees :
                      </td>
                          <td style="height: 1px" >
                            <asp:TextBox id="txt_lumpamt" runat="server" CssClass="text" MaxLength="25"></asp:TextBox>
                              <asp:HiddenField ID="lbllumpamt" runat="server" />
                            </td>
                      
                   </tr>
                   
                    <tr  id="lump3" >
                        <td style="height: 10px; width: 197px;" >
                            Initial Amount to be paid :</td>
                        <td style="height: 10px" >
                            <asp:TextBox ID="txt_lumpinitial" runat="server" CssClass="text" MaxLength="7" onkeypress="return CheckNumeric(event)" onkeyup="return taxcalc();"></asp:TextBox>
                      <asp:CheckBox ID="CheckBox1" runat="server" Text="Include tax" OnClick="return taxcalc();" Width="84px" /></td>
                    </tr>
                       <tr id="lump2" >
                          <td style="height: 3px; width: 197px;" >
                      No. of Installments :</td>
                          <td style="height: 3px" >
                              <asp:TextBox ID="txt_instalamt1" runat="server" CssClass="text" MaxLength="2" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                         
                              <asp:Button ID="Button3" runat="server" OnClientClick="return checkval();" Text="Calculation" CssClass="btnStyle1"  /></td>
                      </tr>
                    <tr>
                        <td style="height: 10px; width: 197px;" >
                            Course amount</td>
                        <td style="height: 10px" >
                            <asp:TextBox ID="txt_netamount" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text" MaxLength="10"></asp:TextBox>
                            </td>
                       </tr>
                    <tr>
                        <td style="height: 31px; width: 197px;" >
                            VAT at 
                            <asp:Label ID="lbl_tax" runat="server"></asp:Label>%</td>
                        <td style="height: 31px" >
                            <asp:TextBox ID="txt_vat" onKeyPress="return AllowAlphabet(event)"  onpaste="return false" runat="server" CssClass="text" MaxLength="10"></asp:TextBox>
                            </td>
                      </tr>
                      <tr id="lump4">
                          <td style="width: 197px" >
                              Amount To be paid per month</td>
                          <td >
                              <asp:TextBox ID="txtamtmonthly" runat="server" CssClass="text" MaxLength="7" onkeypress="return CheckNumeric(event)" ReadOnly="True"></asp:TextBox></td>
                        
                      </tr>
                      <tr>
                          <td style="width: 197px">
                          </td>
                          <td>
                          </td>
                      </tr>
                </table>   
            </td>
        </tr>
      
        <tr id="tr1" runat="server" visible="false">
            <td style="">
                <strong>Coursestart date</strong><span style="color: #ff0000">*</span></td>
            <td style="">
                <asp:TextBox ID="txt_coursedatedate" runat="server" CssClass="text datepicker" onkeypress="return AllowAlphabet(event)"
                    onpaste="return false"></asp:TextBox></td>
        </tr>
        <tr id="tr2" runat="server" visible="false">
            <td style="">
                <strong>
                Installment Date</strong><span style="color: #ff0000">*</span></td>
            <td style="">
                <asp:TextBox ID="txt_installdate" runat="server" CssClass="text datepicker" onkeypress="return AllowAlphabet(event)"
                    onpaste="return false"></asp:TextBox></td>
        </tr>
        <tr id="tr3" runat="server" visible="false">
            <td style=" height: 29px;">
                <strong>Payment Mode</strong> <span style="color: #ff0000">*</span></td>
            <td style="width: 339px; height: 29px;">
                <asp:DropDownList ID="ddlpaymentmode" runat="server" onchange="cashval()">
                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                    <asp:ListItem Value="D.D">D.D</asp:ListItem>
                    <asp:ListItem Value="Creditcard">Creditcard</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr id="tr4" runat="server" visible="false">
            <td style="width: 100px">
                Cheque/D.D. No/C.C No</td>
            <td style="width: 339px">
                <asp:TextBox ID="txtchequeno" runat="server" CssClass="text" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox></td>
        </tr>
        <tr id="tr5" runat="server" visible="false">
            <td style="width: 100px; height: 23px">
                Bank Name</td>
            <td style="width: 339px; height: 23px">
                <asp:TextBox ID="txtbankname" runat="server" CssClass="text" MaxLength="30" onfocus="losefocuscash(this)"></asp:TextBox></td>
        </tr>
        <tr id="tr6" runat="server" visible="false">
            <td style="width: 100px">
            </td>
            <td style="width: 339px">
                <asp:Button ID="btnsubmit5" runat="server" CssClass="btnStyle1" 
                    OnClientClick="javascript:return validate();" Text="Submit" OnClick="btnsubmit5_Click1"  />
                <asp:Button ID="Button1" runat="server" CssClass="btnStyle2" 
                    Text="Reset" /></td>
        </tr>
        <tr class="no-borders">
            <td style="width: 100px; height: 23px">
                <asp:HiddenField ID="hdnlumpamt" runat="server" />
                <input id="hdnTab" name="hdnTab" type="hidden" value="Admission" /><input id="hdncou_id"
                    runat="server" name="hdncou_id" type="hidden" /></td>
            <td style="width: 339px; height: 23px">
            </td>
        </tr>
    </table>
	</div>
</asp:Content>

