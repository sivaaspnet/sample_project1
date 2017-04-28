<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="viewAssesment.aspx.cs" Inherits="superadmin_ProjectAssesment" Title="Project Assesment" %>


<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" id="script1">
    </asp:ScriptManager>
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
 <h4>
      Project Details</h4>
      <div id="ViewAssesment">
     <table class="common" >
            <tr>
                <td colspan="3" style="height: 9px">
         <div class="gridSort" style="margin-top:10px;">  
                    <table class="common" style="width: 100%">
                        <tr id="Tr2" runat="server">
                        
                           <%--  <td style="width: 142px; height: 25px">
                             <%if (Session["SA_Centrerole"] .ToString() == "R&D")
                               {
         %>
                                <asp:Label ID="Label9" runat="server" Text="Search By Centre" Width="106px"></asp:Label>
                                
                                <%} %>
                                </td>--%>
                            <td style="width: 158px; height: 25px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="False" ForeColor="Black" Text="Search By Student ID"
                                    Width="117px"></asp:Label>
                            </td>
                            <td style="width: 167px; height: 25px">
                                <asp:Label ID="Label2" runat="server" Text="Searchby Module Name" Width="128px"></asp:Label></td>
                            <td style="width: 510px; height: 25px">
                                <asp:Label ID="Label10" runat="server" Text="From Date" Width="122px"></asp:Label></td>
                            <td style="width: 313px; height: 25px">
                                <asp:Label ID="Label8" runat="server" Text="To Date" Width="116px"></asp:Label></td>
                            <td style="width: 99px; height: 25px">
                                <asp:Label ID="Label3" runat="server" Text="Searchby Status" Width="87px"></asp:Label></td>
                            <td style="height: 25px">
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server">
                           <%--  <td style="width: 142px">
                            <%if (Session["SA_Centrerole"] .ToString() == "R&D")
                               {
         %>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                                </asp:DropDownList>
                                <%} %></td>--%>
                            <td style="width: 158px">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="text" Width="134px"></asp:TextBox></td>
                            <td style="width: 167px">
                                <asp:DropDownList ID="ddlsearchmodname" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 510px">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="text datepicker" Width="118px" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></td>
                            <td style="width: 313px">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="text datepicker" Width="118px" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="ddlstatus" runat="server" Width="85px">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                    <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                </asp:DropDownList>&nbsp;
                            </td>
                            <td><%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>--%>
                                <asp:Button ID="btnsearch" runat="server" CssClass="search" OnClientClick="return call();" OnClick="btnsearch_Click" />
                                <br />
                                  <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red"  ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="TextBox2"></asp:CustomValidator>
                     <%--      </contenttemplate>
                           </asp:UpdatePanel>--%>
                           
                           
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" style="width: 142px; text-align: center">
                            </td>
                            <td colspan="5" style="text-align: center">
                                <asp:Label ID="Label1" runat="server" CssClass="error" Text=""></asp:Label></td>
                            <td colspan="1" style="text-align: center">
                            </td>
                        </tr>
                    </table>
                    </div>
<br />

<asp:GridView id="GridView1" runat="server" Width="100%" CssClass="common"  
                        EmptyDataText="No Record Found" AutoGenerateColumns="False" AllowPaging="True" 
                        onpageindexchanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="studentid" HeaderText="studentID" />
                            <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                            <asp:BoundField DataField="module" HeaderText="Module" />
                            <asp:TemplateField HeaderText="ProjectName">
                            <ItemTemplate>
                                <a href="viewprojectmark.aspx?studentid=<%#Eval("studentid")%>&projectid=<%#Eval("projectid")%>&iframe=true&amp;width=580&amp;height=300"  rel="modal" onclick="return false">
                               <%#Eval("projectname")%></a>
                      
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="projectguided_by" HeaderText="Project Guided By" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            
                             <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                
         
                             <a href="Popup10.aspx?id=<%#Eval("id")%>&iframe=true&amp;width=370&amp;height=340"  rel="modal" onclick="return false">Edit</a>
                            
                      </ItemTemplate>
                            </asp:TemplateField>
                                   
                        
                        </Columns>
                        <EmptyDataRowStyle BorderColor="#C00000" />
                    </asp:GridView> 

                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click"><span class="file"><span class="file"><span class="file"><span class="file">Download</span></span></span></span></asp:LinkButton>

                </td>
            </tr>
        </table>
    </div>
    
    
     
    </div>

   
    
    

</asp:Content>

