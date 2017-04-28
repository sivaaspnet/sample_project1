<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="addfaculty.aspx.cs" Inherits="superadmin_addfaculty" Title="Add Faculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	   {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
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

       	        
function faculty()
    {
     var optionalfields = 'ctl00_ContentPlaceHolder1_txt_company~ctl00_ContentPlaceHolder1_txt_designation~ctl00_ContentPlaceHolder1_txt_fromdate~ctl00_ContentPlaceHolder1_txt_todate~ctl00_ContentPlaceHolder1_txt_description~ctl00_ContentPlaceHolder1_txt_reason';
     var f6=optionalfields.split("~");
        clearValidation('ctl00_ContentPlaceHolder1_txt_facultyname~ctl00_ContentPlaceHolder1_txt_dob~ctl00_ContentPlaceHolder1_txt_per_address~ctl00_ContentPlaceHolder1_txt_temp_address~ctl00_ContentPlaceHolder1_txt_mobile~ctl00_ContentPlaceHolder1_txt_landline~ctl00_ContentPlaceHolder1_txt_email~ctl00_ContentPlaceHolder1_txt_institute~ctl00_ContentPlaceHolder1_txt_course~ctl00_ContentPlaceHolder1_txt_subject~ctl00_ContentPlaceHolder1_txt_yearofcompletion~ctl00_ContentPlaceHolder1_txt_percentage~'+optionalfields)
        if(document.getElementById("ctl00_ContentPlaceHolder1_txt_facultyname").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_facultyname").value=="";
             //alert("Please enter faculty name");
              document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter the faculty name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_facultyname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_facultyname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_facultyname").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_dob").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_dob").value=="";
            // alert("Please enter date of birth");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please Select the date of birth!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_dob").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_dob").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_dob").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_per_address").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_per_address").value=="";
             //alert("Please enter permanent address");
              document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter permanent address!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_per_address").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_per_address").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_per_address").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_temp_address").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_temp_address").value=="";
             //alert("Please enter Temporary Address address");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter Temporary Address address!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_temp_address").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_temp_address").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_temp_address").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").value=="";
             //alert("Please enter mobile number");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter mobile number!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").value!="" && document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").value.length<10)
         {
         
             //alert("Invalid Mobile No(Must have 10digits)")
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Invalid Mobile No(Must have 10digits!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_mobile").style.backgroundColor="#e8ebd9";
             return false;
         }
          
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_email").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").value=="";
             //alert("Please enter email-id");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter email-id!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(!Validate_Email(document.getElementById("ctl00_ContentPlaceHolder1_txt_email").value))
         {
             //alert("Please Enter the Valid Email-ID");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please Enter the Valid Email-ID!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_email").style.backgroundColor="#e8ebd9";
             return false;
         }      
         else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_institute").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_institute").value=="";
             //alert("Please enter institute name");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter institute name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_institute").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_institute").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_institute").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_course").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_course").value=="";
             //alert("Please enter course name ");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter course name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_course").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_course").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_course").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_subject").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_subject").value=="";
             //alert("Please enter subject name ");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter subject name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_subject").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_subject").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_subject").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_yearofcompletion").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_yearofcompletion").value=="";
             //alert("Please enter year of completion ");
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter year of completion!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_yearofcompletion").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_yearofcompletion").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_yearofcompletion").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_percentage").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_percentage").value=="";
            // alert("Please enter percentage obtained ");
            document.getElementById("ctl00_ContentPlaceHolder1_lbl_errormsg").innerHTML ='*Please enter percentage obtained!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_percentage").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_percentage").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_percentage").style.backgroundColor="#e8ebd9";
             return false;
         }
         
          
          else if(checkValidation(optionalfields) < f6.length && !emptyValidation(optionalfields))
          {
	        return false;
	      }
         else
         {
         return true;
         }
  }
</script>
<div id="tabs">
  
			<div id="tabs-1">

    <table class="common" cellpadding="1">
   <tr>
        <td colspan="6" style="text-align:left; padding:0px;">
           <h4>Add Faculty Details</h4>
            
        </td>
    </tr>
        <tr>
            <td align="left" colspan="6" style="text-align: center">
                <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td align="left" colspan="6" valign="top">
               <b>Personal Details</b></td>
        </tr>
        <tr>
            <td align="left" valign="top">
                Faculty Name
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="txt_facultyname" CssClass="text" runat="server" onkeypress="return false"></asp:TextBox></td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                Date of Birth</td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="txt_dob" CssClass="text datepicker" runat="server"></asp:TextBox></td>
        </tr>
    <tr>
      <td align="left" valign="top">
          Permanent Address</td>
      <td  align="left" valign="top">
      <asp:TextBox ID="txt_per_address" CssClass="text" runat="server" TextMode="MultiLine" Height="46px"></asp:TextBox></td>
      <td  align="left" valign="top">
          &nbsp;</td>
      <td  align="left" valign="top">
          Temporary Address</td>
      <td  align="left" valign="top">&nbsp;</td>

      <td align="left" valign="top">
          <asp:TextBox ID="txt_temp_address" CssClass="" runat="server" TextMode="MultiLine" Height="43px" Width="193px"></asp:TextBox>
          &nbsp;</td>
    </tr>
    <tr>
      <td align="left" valign="top">
          Mobile
      </td>
      <td align="left" valign="top">
      <asp:TextBox ID="txt_mobile" CssClass="text" runat="server" MaxLength="10" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
      <td align="left" valign="top"> </td>
      <td align="left" valign="top"> Landline(optional)</td>
      <td align="left" valign="top">&nbsp;</td>
      <td align="left" valign="top">
          <asp:TextBox ID="txt_landline" CssClass="text" runat="server" MaxLength="11" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
    </tr>
  <tr>
      <td align="left" valign="top">
          Email</td>
      <td align="left" valign="top">
          <asp:TextBox ID="txt_email" CssClass="text" runat="server"></asp:TextBox></td>
      <td align="left" valign="top"></td>
      <td align="left" valign="top"></td>
      <td align="left" valign="top">&nbsp;</td>
      <td align="left" valign="top">  </td>
    </tr>
       <tr>
      <td colspan="6" valign="top" style="padding:0px;"><h4>
          Experience Details (Optional)</h4></td>

    </tr>
    <tr>
      <td align="left" valign="top">
          Company Name</td>
      <td  align="left" valign="top">
          <asp:TextBox ID="txt_company" CssClass="text" runat="server"></asp:TextBox></td>
      <td  align="left" valign="top">
   
      </td>
      <td  align="left" valign="top">
          Designation</td>
      <td  align="left" valign="top">&nbsp;</td>

      <td align="left" valign="top">
          <asp:TextBox ID="txt_designation" CssClass="text" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
            From</td>
        <td  align="left" valign="top">   
        <asp:TextBox ID="txt_fromdate" onpaste="return false" onKeyPress="return false" CssClass="text datepicker" runat="server"></asp:TextBox></td>
       <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
            To</td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
            <asp:TextBox ID="txt_todate" onpaste="return false" onKeyPress="return false" CssClass="text datepicker" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="left" valign="top" >
          Description</td>
      <td  align="left" valign="top">
      <asp:TextBox ID="txt_description" CssClass="text" runat="server" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
      <td  align="left" valign="top">
          &nbsp;</td>
      <td  align="left" valign="top">
          Reason</td>
      <td  align="left" valign="top">&nbsp;</td>

      <td align="left" valign="top"> 
      <asp:TextBox ID="txt_reason" CssClass="text" runat="server" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
     <tr>
      <td colspan="6" valign="top">
          <b>Qualificatiom Details</b></td>

    </tr>
    <tr>
      <td align="left" valign="top">
          Institute</td>
      <td  align="left" valign="top">
      <asp:TextBox ID="txt_institute" CssClass="text" runat="server" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
      <td  align="left" valign="top">
          &nbsp;</td>
      <td  align="left" valign="top" >
          Course</td>
      <td  align="left" valign="top">&nbsp;</td>

      <td align="left" valign="top">
          <asp:TextBox ID="txt_course" CssClass="text" runat="server" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="left" valign="top">
          Subject</td>
      <td align="left" valign="top">
      <asp:TextBox ID="txt_subject" CssClass="text" runat="server" onkeypress="return AllowAlphabet(event)"></asp:TextBox></td>
      <td align="left" valign="top"> </td>
      <td align="left" valign="top"> Year Of Completion</td>
      <td align="left" valign="top" style="width: 5px">&nbsp;</td>
      <td align="left" valign="top">
          <asp:TextBox ID="txt_yearofcompletion" CssClass="text" runat="server" MaxLength="4" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Percentage</td>
        <td align="left" valign="top" >
            <asp:TextBox ID="txt_percentage" CssClass="text" MaxLength="3" runat="server" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
        <td align="left" valign="top">
            </td>
        <td align="left" valign="top">
            </td>
        <td align="left" valign="top" >
        </td>
        <td align="left" valign="top">
        </td>
    </tr>
        <tr>
            <td align="left" colspan="6"  valign="top">
            <b>Known Software(Optional)</b></td>
        </tr>
      
        <tr>
        <td align="left" valign="top">
            Operating Syatem</td>
        <td align="left" valign="top">  
            <asp:ListBox ID="ddl_OS" runat="server" SelectionMode="Multiple" Width="175px">
               
            <asp:ListItem Value="MS-DOS">MS DOS</asp:ListItem>
            <asp:ListItem Value="Windows">Windows</asp:ListItem>
            <asp:ListItem Value="Unix">Unix</asp:ListItem>
            <asp:ListItem Value="Linux">Linux</asp:ListItem>
            <asp:ListItem Value="Macintosh">Macintosh</asp:ListItem>
            </asp:ListBox></td>
        <td align="left" valign="top">
            </td>
        <td align="left" valign="top">
            Programming languages</td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
         
            <asp:ListBox ID="ddl_proglanguages" runat="server" SelectionMode="Multiple" Width="175px">
             
            <asp:ListItem Value="C">C</asp:ListItem>
            <asp:ListItem Value="C++">C++</asp:ListItem>
            <asp:ListItem Value="Basic">Basic</asp:ListItem>
            <asp:ListItem Value="QBasic">QBasic</asp:ListItem>
            <asp:ListItem Value="Pascal">Pascal</asp:ListItem>
            <asp:ListItem Value="Cobol">Cobol</asp:ListItem>
            <asp:ListItem Value="Fortran">Fortran</asp:ListItem>
            
            </asp:ListBox></td>
    </tr>
        <tr>
            <td align="left"  valign="top">
                Applications</td>
            <td align="left" valign="top">
              
                <asp:ListBox ID="ddl_applications" runat="server" SelectionMode="Multiple" Width="175px">
                  
                 <asp:ListItem Value="Foxbase">Foxbase</asp:ListItem>
                    <asp:ListItem Value="Foxpro">Foxpro</asp:ListItem>
                    <asp:ListItem Value="Ms-office">Ms-office</asp:ListItem>
                    <asp:ListItem Value="Flash">Flash(Action Scripting)</asp:ListItem>
                    <asp:ListItem Value="Director Lingo">Director(Lingo)</asp:ListItem>
                    <asp:ListItem Value="Director 3DLingo">Director(3D Lingo)</asp:ListItem>
                    <asp:ListItem Value="Pulse3D">Pulse 3D</asp:ListItem>
                    <asp:ListItem Value="Cult3D">Cult 3D</asp:ListItem>
                    <asp:ListItem Value="Viewpoint 3D">Viewpoint 3D</asp:ListItem>
                    <asp:ListItem Value="Sound Forge">Sound Forge</asp:ListItem>
                </asp:ListBox></td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                Database</td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                
                <asp:ListBox ID="ddl_database" runat="server" SelectionMode="Multiple" Width="175px">
                 
                  <asp:ListItem Value="MS Access">MS Access</asp:ListItem>
                    <asp:ListItem Value="SqlServer">Sql Server</asp:ListItem>
                    <asp:ListItem Value="Mysql">Mysql</asp:ListItem>
                    <asp:ListItem Value="Oracle">Oracle</asp:ListItem>
                    <asp:ListItem Value="Postgress">Postgress</asp:ListItem>
                    <asp:ListItem Value="sybase">sybase</asp:ListItem>
                
                </asp:ListBox></td>
        </tr>
        <tr>
            <td align="left"  valign="top">
                GUI Application</td>
            <td align="left"  valign="top">
             
                <asp:ListBox ID="ddl_GUI" runat="server" SelectionMode="Multiple" Width="175px" >
                 
                    <asp:ListItem Value="MicrosoftVC++">Microsoft VC++</asp:ListItem>
                     <asp:ListItem Value="MicrosoftVC++(MVC)">Microsoft VC++(MVC)</asp:ListItem>
                     <asp:ListItem Value="MicrosoftVisualBasic">Microsoft Visual Basic</asp:ListItem>
                     <asp:ListItem Value="MicrosoftVisualFoxpro">Microsoft Visual Foxpro</asp:ListItem>
                     <asp:ListItem Value="VB.NET">VB.NET</asp:ListItem>
                     <asp:ListItem Value="C#">C#</asp:ListItem>
                     <asp:ListItem Value="VC.NET">VC.NET</asp:ListItem>                   
                </asp:ListBox></td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                Web Development</td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top" style="height: 72px">
                
                <asp:ListBox ID="ddl_webdevelop" runat="server" SelectionMode="Multiple" Width="175px">
                
                    <asp:ListItem Value="ASP.NET(VB)">ASP.NET(VB)</asp:ListItem>
                    <asp:ListItem Value="ASP.NET(C#)">ASP.NET(C#)</asp:ListItem>
                    <asp:ListItem Value="ASP">ASP</asp:ListItem>
                    <asp:ListItem Value="PHP">PHP</asp:ListItem>
                    <asp:ListItem Value="PERL">PERL</asp:ListItem>
                    <asp:ListItem Value="CGI">CGI</asp:ListItem>
                    <asp:ListItem Value="HTML">HTML</asp:ListItem>
                    <asp:ListItem Value="CFM">CFM</asp:ListItem>
                    <asp:ListItem Value="VBScript">VB Script</asp:ListItem>
                    <asp:ListItem Value="JavaScript">Java Script</asp:ListItem>
                    <asp:ListItem Value="PerlScript">Perl Script</asp:ListItem>
                    <asp:ListItem Value="Dreamweaver">Dreamweaver</asp:ListItem>
                
                
                </asp:ListBox></td>
        </tr>
        <tr>
            <td align="left"  valign="top">
                Multimedia</td>
            <td align="left"  valign="top">
               
                <asp:ListBox ID="ddl_multimedia" runat="server" SelectionMode="Multiple" Width="175px">
                
                        <asp:ListItem Value="Photoshop">Photoshop</asp:ListItem>
                        <asp:ListItem Value="Illustrator">Illustrator</asp:ListItem>
                        <asp:ListItem Value="Indesign">Indesign</asp:ListItem>
                        <asp:ListItem Value="Pagemaker">Pagemaker</asp:ListItem>
                        <asp:ListItem Value="CoralDraw">Coral Draw</asp:ListItem>
                        <asp:ListItem Value="Flash">Flash</asp:ListItem>
                        <asp:ListItem Value="Maya">Maya</asp:ListItem>
                        <asp:ListItem Value="3DSMax">3DS Max</asp:ListItem>
                        <asp:ListItem Value="Premiere">Premiere</asp:ListItem>
                        <asp:ListItem Value="Combustion">Combustion</asp:ListItem>
                        <asp:ListItem Value="Image Readys">Image Readys</asp:ListItem>
                        <asp:ListItem Value="Flax">Flax</asp:ListItem>
                        <asp:ListItem Value="swish">swish</asp:ListItem>
                        <asp:ListItem Value="MSPowerpoint">MS Powerpoint</asp:ListItem>
                        <asp:ListItem Value="Morph">Morph</asp:ListItem>
                        <asp:ListItem Value="AfterEffects">After Effects</asp:ListItem>      
                
                </asp:ListBox></td>
            <td align="left" valign="top">
            </td>
            <td align="left"  valign="top">
                Authoring</td>
            <td align="left" valign="top">
            </td>
            <td align="left"  valign="top">
              
                <asp:ListBox ID="ddl_authoring" runat="server" SelectionMode="Multiple" Width="175px">
               
                        <asp:ListItem Value="Director">Director</asp:ListItem>
                        <asp:ListItem Value="Sony DVD Architect">Sony DVD Architect </asp:ListItem>
                        <asp:ListItem Value="Blue Berry Flash Back">Blue Berry Flash Back</asp:ListItem>
                        <asp:ListItem Value="DVD Lab Pro">DVD Lab Pro</asp:ListItem>
                
                </asp:ListBox></td>
        </tr>
        <tr>
            <td align="left"  valign="top">
                Conversions</td>
            <td align="left" valign="top">
            
                <asp:ListBox ID="ddl_conversions" runat="server" SelectionMode="Multiple" Width="175px">
                  
                        <asp:ListItem Value="Sorenson squeeze">Sorenson squeeze</asp:ListItem>
                        <asp:ListItem Value="Allok">Allok</asp:ListItem>
                        <asp:ListItem Value="Tempege">Tempege</asp:ListItem>
                        <asp:ListItem Value="Sound Forge">Sound Forge</asp:ListItem>              
                </asp:ListBox></td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
                Miscellaneous</td>
            <td align="left" valign="top">
            </td>
            <td align="left" valign="top">
             
                <asp:ListBox ID="ddl_miscellaneous" runat="server" SelectionMode="Multiple" Width="175px">
                 
                    <asp:ListItem Value="AZAX">AZAX</asp:ListItem>
                    <asp:ListItem Value="XML">XML</asp:ListItem>
                    <asp:ListItem Value="UMLScripting">UML Scripting</asp:ListItem>
                    <asp:ListItem Value="Ms-OfficeMacro">Ms-Office Macro</asp:ListItem>
                    <asp:ListItem Value="InstallShield">Install Shield</asp:ListItem>
                
                
                </asp:ListBox></td>
        </tr>
        
        <tr><td colspan="4">
            Others &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
           <asp:TextBox ID="sftothers" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                <td></td>
                <td></td>
            </tr>
   
    <tr>
        <td  style="text-align:center;" valign="top" colspan="6">
            <br />
            <asp:Button ID="btn_add" runat="server" Text="Submit" CssClass="submit" OnClientClick="javascript:return faculty();" OnClick="btn_add_Click" />&nbsp;
            &nbsp;<input id="Reset2" type="reset" value="Reset" class="submit" />
           &nbsp;&nbsp;
            <br />
            <br />
        </td>
    </tr>
</table>
                <br />
                <br />
                <br />

   

</div>
   </div>













</asp:Content>

