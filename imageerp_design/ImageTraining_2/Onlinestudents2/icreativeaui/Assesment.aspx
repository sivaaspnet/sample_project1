<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Assesment.aspx.cs" Inherits="superadmin_ProjectAssesment" Title="Project Assesment" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript">
    $(document).ready(function() {
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(evt, args) {
        	jQuery(".datepicker").datepicker({showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });

    });
     });
</script>
  <script type="text/javascript">

// Extended Tooltip Javascript
// copyright 9th August 2002, 3rd July 2005, 24th August 2008
// by Stephen Chapman, Felgall Pty Ltd

// permission is granted to use this javascript provided that the below code is not altered
function pw() {return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth}; function mouseX(evt) {return evt.clientX ? evt.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft) : evt.pageX;} function mouseY(evt) {return evt.pageY ? evt.pageY : evt.clientY + (document.documentElement.scrollTop || document.body.scrollTop)} function popUp(evt,oi) {if (document.getElementById) {var wp = pw(); dm = document.getElementById(oi); ds = dm.style; st = ds.visibility; if (dm.offsetWidth) ew = dm.offsetWidth; else if (dm.clip.width) ew = dm.clip.width; if (st == "visible" || st == "show") { ds.visibility = "hidden"; } else {tv = mouseY(evt) - 220; lv = mouseX(evt) - (ew/4); if (lv < 2) lv = 2; else if (lv + ew > wp) lv -= ew/2; lv += 'px';tv += 'px';  ds.left = lv; ds.top = tv; ds.visibility = "visible";}}}


</script>
  <%--     <script type="text/javascript">
        function call()
        {
       
    var $tabs = jQuery('#ViewAssesment').tabs();
	$tabs.tabs('select', 1); // switch to second tab
	return false;
     alert("alert");
        }
        </script>--%>
  <%--<script type="text/javascript">

$(document).ready(function()
{
$('#ContentPlaceHolder1_TextBox2').keyup(function()
{
searchTable($(this).val());
});
});
function searchTable(inputVal)
{
var table = $('#ContentPlaceHolder1_GridView1');
table.find('tr').each(function(index, row)
{
var allCells = $(row).find('td');
if(allCells.length > 0)
{
var found = false;
allCells.each(function(index, td)
{
var regExp = new RegExp(inputVal, 'i');
if(regExp.test($(td).text()))
{
found = true;
return false;
}
});
if(found == true)$(row).show();else $(row).hide();
}
});
}
</script>--%>
  <script language="javascript" type="text/javascript">
 
 
 $(document).ready(function() {

    $("#ContentPlaceHolder1_TextBox2").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
 
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
	        
	 function Validate()
     {
         if(trim(document.getElementById("ContentPlaceHolder1_txt_StudentId").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_StudentId").value=="";   
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Student ID!';
             document.getElementById("ContentPlaceHolder1_txt_StudentId").focus();
             document.getElementById("ContentPlaceHolder1_txt_StudentId").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_StudentId").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txt_StudentName").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_StudentName").value=="";   
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Student Name!';
             document.getElementById("ContentPlaceHolder1_txt_StudentName").focus();
             document.getElementById("ContentPlaceHolder1_txt_StudentName").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_StudentName").style.backgroundColor="#e8ebd9";
             return false;
         }
    
      else if(trim(document.getElementById("ContentPlaceHolder1_ddlcourse").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_ddlcourse").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the course!';
             document.getElementById("ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ContentPlaceHolder1_ddlmodname").value=="")
         {
             
             document.getElementById("ContentPlaceHolder1_ddlmodname").focus();
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the module!';
             document.getElementById("ContentPlaceHolder1_ddlmodname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlmodname").style.backgroundColor="#e8ebd9";
             document.getElementById("ContentPlaceHolder1_ddlmodname").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txtproject").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtproject").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Project Guide!';
             document.getElementById("ContentPlaceHolder1_txtproject").focus();
             document.getElementById("ContentPlaceHolder1_txtproject").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtproject").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }   
     }
       function Validate_Email(Email)
{
	var Str=Email
	//var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

	if(CheckExpression.test(Str))// test Method to check for Regular Expression
	{
		return true;
	}
	else
	{
		return false
	}
}
function searchval()
{
if(document.getElementById("ContentPlaceHolder1_txtsearchlocation").value=="" && document.getElementById("ContentPlaceHolder1_txtsearchname").value=="" )
         {
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").focus();
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.backgroundColor="#e8ebd9";
             return false;
         } 
        else
        {
        return true;
        }

}
function btnreset_onclick()
 {
  location.href="addcentre.aspx";
 }
 
 $(document).ready(function() {

    $("#ContentPlaceHolder1_txtstudentid").autocomplete('Handler2.ashx');
   // alert("check");  
    }); 
    
    
    
    function validate3()
    {
     var start = document.getElementById("ContentPlaceHolder1_txtSenddate").value;
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
    
    if(document.getElementById("ContentPlaceHolder1_txtproject").value=="")
 {
     alert("Please select Project Guide");
     document.getElementById("ContentPlaceHolder1_txtproject").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtproject").focus();
             return false;
 }
 else
 if((document.getElementById("ContentPlaceHolder1_txtSenddate").value=="")&& (document.getElementById("ContentPlaceHolder1_HiddenField2").value=="Technical Head"))
 {
     alert("Please select send date");
     document.getElementById("ContentPlaceHolder1_txtSenddate").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtSenddate").focus();
             return false;
 }
 else if((csDate < 0))
          {
             document.getElementById("ContentPlaceHolder1_txtSenddate").value=="";
             alert("Invalid start date");
             document.getElementById("ContentPlaceHolder1_txtSenddate").focus();
             document.getElementById("ContentPlaceHolder1_txtSenddate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtSenddate").style.backgroundColor="#e8ebd9";
             return false;
          }
    else
    {
    return true;
    }
    }
    
    
    
    
    
    
    function validate1()
    {
    if(document.getElementById("ContentPlaceHolder1_ddl_module").value=="")
    {
    alert("Please select Module");
     document.getElementById("ContentPlaceHolder1_ddl_module").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_module").style.backgroundColor="#e8ebd9";
             return false;
    }
    else
    if(document.getElementById("ContentPlaceHolder1_ddl_projectname").value=="")
    {
    alert("Please select Project");
     document.getElementById("ContentPlaceHolder1_ddl_projectname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_projectname").style.backgroundColor="#e8ebd9";
             return false;
    }
    else
    {
    return true;
    }
    }
    
   
</script>
  <script type="text/javascript">
 function validate2()
    {
   var start = document.getElementById("ContentPlaceHolder1_txtSenddate").value;
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
       
        var start5 = document.getElementById("ContentPlaceHolder1_txtEvalDate").value;
        var start_s5 = start5.split("-");
        var stDate5 = parseInt(start_s5[2]+start_s5[1]+start_s5[0]);
         
        var d5 = new Date();
        var curr_date5 = d5.getDate();
        var curr_month5 = d5.getMonth();
        curr_month5++;
        var curr_year5 = d5.getFullYear();
        var mon5 =  (curr_month5 < 10 ? '0' : '') + curr_month5
        var dday5 =  (curr_date5 < 10 ? '0' : '') + curr_date5
        var toDate5 = parseInt(curr_year5 +''+ mon5 +''+ dday5);
        //var csDate = stDate - toDate;
        var csDate5 = parseInt(stDate5 - toDate5);
    
     
     if(document.getElementById("ContentPlaceHolder1_txtproject").value=="")
 {
     alert("Please select Project Guide");
     document.getElementById("ContentPlaceHolder1_txtproject").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtproject").focus();
             return false;
 }
 else if(document.getElementById("ContentPlaceHolder1_txtSenddate").value=="")
 {
     alert("Please select send date");
     document.getElementById("ContentPlaceHolder1_txtSenddate").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtSenddate").focus();
             return false;
 }
 else if((csDate < 0) && (document.getElementById("ContentPlaceHolder1_HiddenField2").value=="Technical Head"))
          {
             document.getElementById("ContentPlaceHolder1_txtSenddate").value=="";
             alert("Invalid start date");
             document.getElementById("ContentPlaceHolder1_txtSenddate").focus();
             document.getElementById("ContentPlaceHolder1_txtSenddate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtSenddate").style.backgroundColor="#e8ebd9";
             return false;
          }

    else if(document.getElementById("ContentPlaceHolder1_txtmark").value=="")
    {
    alert("Please Enter Mark");
     document.getElementById("ContentPlaceHolder1_txtmark").style.border="#ff0000 1px solid";
       document.getElementById("ContentPlaceHolder1_txtmark").focus(); 
             return false;
    }
    else if(document.getElementById("ContentPlaceHolder1_txtEvalDate").value=="")
 {
     alert("Please select date");
     document.getElementById("ContentPlaceHolder1_txtEvalDate").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtEvalDate").focus();
             return false;
 }
 else if(csDate5 < 0)
          {
             document.getElementById("ContentPlaceHolder1_txtEvalDate").value=="";
             alert("Invalid start date");
             document.getElementById("ContentPlaceHolder1_txtEvalDate").focus();
             document.getElementById("ContentPlaceHolder1_txtEvalDate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtEvalDate").style.backgroundColor="#e8ebd9";
             return false;
          }
    else if(document.getElementById("ContentPlaceHolder1_txtEvaluatedBy").value=="")
    {
    alert("Please Enter Evaluateby field");
     document.getElementById("ContentPlaceHolder1_txtEvaluatedBy").style.border="#ff0000 1px solid";
     document.getElementById("ContentPlaceHolder1_txtEvaluatedBy").focus();
             return false;
    }
//    else if(document.getElementById("ContentPlaceHolder1_txtRemarks").value=="")
//    {
//    alert("Please enter Remarks");
//     document.getElementById("ContentPlaceHolder1_txtRemarks").style.border="#ff0000 1px solid";
//     document.getElementById("ContentPlaceHolder1_txtRemarks").focus();
//             return false;
//    }
     else if(document.getElementById("ContentPlaceHolder1_ddl_status").value=="Select")
    {
    alert("Please select status");
     document.getElementById("ContentPlaceHolder1_ddl_status").style.border="#ff0000 1px solid";
      document.getElementById("ContentPlaceHolder1_ddl_status").style.backgroundColor="#e8ebd9";
      document.getElementById("ContentPlaceHolder1_ddl_status").focus();
             return false;
    }
    else
    {
    return true;
    }
    }

</script>
  <div id="parent">
  
<div class="content-links">
         <a href="viewAssesment.aspx" class="error">View Assessments</a>
         <a href="Assesment.aspx" class="error">Add Assessment</a>
    </div>
    <h4> Project Details</h4>
    <div id="Assesment"  >
      <TABLE style="WIDTH:100%" id="projecthead" class="common" runat="server">
        <TBODY>
          <TR>
            <TD colSpan=2><TABLE class="common" cellSpacing=0 cellPadding=0 width="100%">
                <TBODY>
                  <tr runat="server">
                    <td style="width: 150px; height: 11px"></td>
                    <td colspan="2" rowspan="1" style="height: 11px"><asp:Label id="lblmsg1" runat="server" Text="" CssClass="error"></asp:Label></td>
                  </tr>
                  <TR id="search" runat="server">
                    <TD style="width: 150px; HEIGHT: 11px"><STRONG>&nbsp;StudentID</STRONG></TD>
                    <TD style="WIDTH: 160px; HEIGHT: 11px">&nbsp;
                      <asp:TextBox id="txtstudentid" runat="server" CssClass="text"></asp:TextBox>
                      &nbsp;
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstudentid"
            ErrorMessage="*" ValidationGroup="v"></asp:RequiredFieldValidator>
                      <asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField>
                      &nbsp; </TD>
                    <TD style="HEIGHT: 11px" rowSpan=4>&nbsp;
                      <asp:Button id="Button1" onclick="Button1_Click1" runat="server" CssClass="search" ValidationGroup="v"></asp:Button>
                     <br />
                      <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ValidationGroup="v" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtstudentid"></asp:CustomValidator></TD>
                  </TR>
                </TBODY>
              </TABLE></TD>
          </TR>
          <TR>
            <TD style="HEIGHT: 23px" colSpan=2><TABLE style="WIDTH: 138%" id="name" runat="server" visible="false">
                <TBODY>
                  <TR>
                    <TD style="WIDTH: 150px; HEIGHT: 5px"><asp:Label id="Label6" runat="server" Font-Bold="True" Text="Student ID" Visible="False"></asp:Label></TD>
                    <TD style="HEIGHT: 5px" align=left colspan="2"><asp:Label id="Label7" runat="server" ForeColor="Maroon" Font-Bold="True" Visible="False"></asp:Label></TD>
                    <TD style="HEIGHT: 5px"></TD>
                    <TD style="HEIGHT: 5px"></TD>
                  </TR>
                  <TR>
                    <TD style="WIDTH: 150px; HEIGHT: 25px"><STRONG>Student name</STRONG></TD>
                    <TD style="HEIGHT: 25px" align=left>    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label id="txt_StudentName" runat="server" ForeColor="Maroon" Font-Bold="True" Width="150px" ReadOnly="True" MaxLength="100"></asp:Label></TD>
                    <TD style="HEIGHT: 25px"></TD>
                    <TD style="HEIGHT: 25px"></TD>
                  </TR>
                  <TR>
                    <TD style="WIDTH: 150px; height: 25px;"><STRONG>Course</STRONG></TD>
                    <TD style="WIDTH: 100px; height: 25px;" align=left colspan="2">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label id="txtCourse" runat="server" ForeColor="Maroon" Font-Bold="True" Width="150px" ReadOnly="True" MaxLength="20"></asp:Label></TD>
                  </TR>
                    <tr>
                        <td style="width: 150px; height: 25px">
                        </td>
                        <td align="left" colspan="2" style="width: 100px; height: 25px">
                        </td>
                    </tr>
                </TBODY>
              </TABLE></TD>
          </TR>
          <TR id="a1" runat="server" visible="false">
            <TD style="WIDTH: 150px; HEIGHT: 23px"><STRONG>&nbsp;Select Module</STRONG></TD>
            <TD style="HEIGHT: 23px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddl_module" runat="server"  CssClass="autowidth" OnSelectedIndexChanged="ddl_module_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList></TD>
          </TR>
          <TR id="a2" runat="server" visible="false">
            <TD><STRONG>&nbsp;Select Project</STRONG></TD>
            <TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddl_projectname" runat="server" CssClass="autowidth">
                <asp:ListItem>Select</asp:ListItem>
              </asp:DropDownList></TD>
          </TR>
          <TR id="a3" runat="server" visible="false">
            <td width="150px;">&nbsp;</td>
            <TD style="HEIGHT: 31px;"><asp:Button id="btn_submit" onclick="btn_submit_Click" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="return validate1()"></asp:Button>
            </TD>
            <TD style="HEIGHT: 31px; TEXT-ALIGN: center"></TD>
          </TR>
          <TR id="Tr1" runat="server">
            <TD style="TEXT-ALIGN: center" colSpan=3>
            <DIV style="MARGIN-TOP: 10px" class="free-forms">
                <TABLE style="WIDTH: 100%" id="tblvis" cellSpacing=0 cellPadding=0 runat="server" visible="false">
                  <TBODY>
                    <TR align=left>
                      <TD style="HEIGHT: 7px" id="tech" colSpan=2 runat="server"><TABLE style="WIDTH: 100%">
                          <TBODY>
                            <TR runat="server">
                              <TD style="HEIGHT: 40px"><STRONG>Module</STRONG></TD>
                              <TD style="HEIGHT: 40px"><asp:TextBox id="txtModule" runat="server" CssClass="text" ReadOnly="True" MaxLength="20"></asp:TextBox></TD>
                              <TD style="HEIGHT: 40px"></TD>
                              <TD style="HEIGHT: 40px"></TD>
                            </TR>
                            <TR runat="server">
                              <TD><STRONG>Project</STRONG></TD>
                              <TD><asp:TextBox id="TextBox1" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                            <TR>
                              <TD><STRONG>Project Guided By</STRONG></TD>
                              <TD><asp:TextBox id="txtproject" runat="server" CssClass="text" MaxLength="30"></asp:TextBox></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                            <TR>
                              <TD style="HEIGHT: 16px"><STRONG>Send Date</STRONG></TD>
                              <TD style="HEIGHT: 16px"><asp:TextBox id="txtSenddate" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false"  CssClass="text datepicker" MaxLength="20"></asp:TextBox></TD>
                              <TD style="HEIGHT: 16px"></TD>
                              <TD style="HEIGHT: 16px"></TD>
                            </TR>
                          </TBODY>
                        </TABLE></TD>
                    </TR>
                    <TR align=left>
                      <TD colSpan=2><TABLE id="certificate" width="100%" runat="server">
                          <TBODY>
                            <TR>
                              <TD style="WIDTH: 215px"><STRONG>Dispatch Date</STRONG></TD>
                              <TD><asp:TextBox id="txtDispatchdate" runat="server" CssClass="text datepicker" MaxLength="30" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                          </TBODY>
                        </TABLE></TD>
                    </TR>
                    <TR align=left>
                      <TD style="HEIGHT: 11px" colSpan=2><TABLE style="WIDTH: 100%" id="randd" runat="server">
                          <TBODY>
                            <TR>
                              <TD style="WIDTH: 215px"><STRONG>Evaluated Date</STRONG></TD>
                              <TD><asp:TextBox id="txtEvalDate" onkeypress="return false" onkeydown="return false" onpaste="return false"  runat="server" CssClass="text datepicker" MaxLength="4"></asp:TextBox></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                            <TR>
                              <TD style="WIDTH: 215px; HEIGHT: 31px"><STRONG>Mark</STRONG></TD>
                              <TD style="HEIGHT: 31px"><asp:TextBox id="txtmark" onkeypress="return CheckNumeric(event)" runat="server" CssClass="text" MaxLength="3"></asp:TextBox></TD>
                              <TD style="HEIGHT: 31px"></TD>
                              <TD style="HEIGHT: 31px"></TD>
                            </TR>
                            <TR>
                              <TD style="WIDTH: 215px"><STRONG>Remarks</STRONG></TD>
                              <TD><asp:TextBox id="txtRemarks" runat="server" CssClass="text" MaxLength="200"></asp:TextBox></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                            <TR>
                              <TD style="WIDTH: 215px"><STRONG>Status</STRONG></TD>
                              <TD><asp:DropDownList id="ddl_status" runat="server">
                                  <asp:ListItem>Select</asp:ListItem>
                                  <asp:ListItem>Approved</asp:ListItem>
                                  <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                            <TR>
                              <TD style="WIDTH: 215px"><STRONG>Evaluated By</STRONG></TD>
                              <TD><asp:TextBox id="txtEvaluatedBy" runat="server" CssClass="text" MaxLength="30"></asp:TextBox></TD>
                              <TD style="HEIGHT: 5px"></TD>
                              <TD style="HEIGHT: 5px"></TD>
                            </TR>
                          </TBODY>
                        </TABLE></TD>
                    </TR>
                    <TR>
                      <TD style="HEIGHT: 36px; TEXT-ALIGN: center" align=center colSpan=2 rowSpan=2><asp:Button id="ddl_insert" onclick="ddl_insert_Click" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="return validate3()"></asp:Button>
                        <asp:Button id="ddl_update" onclick="Button1_Click" runat="server" Text="Submit" Visible="False" CssClass="btnStyle1" OnClientClick="return validate2()"></asp:Button>
                        <asp:HiddenField id="HiddenField2" runat="server"></asp:HiddenField>
                      </TD>
                    </TR>
                  </TBODY>
                </TABLE>
              </DIV></TD>
          </TR>
        </TBODY>
      </TABLE>
      <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>
    </div>
  </div>
</asp:Content>
