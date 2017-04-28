<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="shufflebatch.aspx.cs" Inherits="superadmin_createnewBatch" Title="Add student To Running Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

$(document).ready(function()
{
$('#ContentPlaceHolder1_txt_studentid').keyup(function()
{
searchTable($(this).val());
});
});
function searchTable(inputVal)
{
var table = $('#ContentPlaceHolder1_Gridvw');
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
</script>
 <script language="javascript" type="text/javascript">
 var TargetBaseControl = null;
        
   window.onload = function()
   {
      try
      {
         //get target base control.
         TargetBaseControl = document.getElementById('<%= this.Gridvw.ClientID %>');
      }
      catch(err)
      {
         TargetBaseControl = null;
      }
   }
   

 function TestCheckBox()
   { 
        //Start and end date check
        var start = document.getElementById("ContentPlaceHolder1_txt_stratdate").value;
        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

        var start_s = start.split("-");
        //var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
        //var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
//        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        //var compDate = enDate - stDate;
        var csDate = stDate - toDate;     
        if(document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select module name!';
             document.getElementById("ContentPlaceHolder1_ddl_coursename").focus();
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
             //alert("Please select course");
             return false;
         }
         
         
        else if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select")
         {    
        
             document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select track!';
             document.getElementById("ContentPlaceHolder1_ddl_Track").focus();
             document.getElementById("ContentPlaceHolder1_ddl_Track").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_Track").style.backgroundColor="#e8ebd9";
             //alert("Please select track");
             return false;
         }
         
         else if(document.getElementById("ContentPlaceHolder1_lbl_coursename").innerHTML=="")
         {    
             document.getElementById("ContentPlaceHolder1_lbl_coursename").innerHTML=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please enter software name!';
             document.getElementById("ContentPlaceHolder1_lbl_coursename").focus();
             document.getElementById("ContentPlaceHolder1_lbl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_lbl_coursename").style.backgroundColor="#e8ebd9";
             return false;
         } 
       
         else if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="Select")
         {    
             document.getElementById("ContentPlaceHolder1_DropDownList1").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select batch time!';
             document.getElementById("ContentPlaceHolder1_DropDownList1").focus();
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
             return false;
         } 
    
         else  if(document.getElementById("ContentPlaceHolder1_ddl_labname").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_labname").value=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select lab name!';
             document.getElementById("ContentPlaceHolder1_ddl_labname").focus();
             document.getElementById("ContentPlaceHolder1_ddl_labname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_labname").style.backgroundColor="#e8ebd9";
             return false;
         } 
       else if(document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select faculty name!';
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").focus();
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.backgroundColor="#e8ebd9";
             return false;
         } 
         
          else if(document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="") 
         {    
             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select start date!';
             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             return false;
         } 
          else if(csDate < 0)
         {
             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Invalid start date!';
             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             return false;
        }
        
//         else if(document.getElementById("ContentPlaceHolder1_txt_enddate").value=="") 
//         {    
//             document.getElementById("ContentPlaceHolder1_txt_enddate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select end date!';
//             document.getElementById("ContentPlaceHolder1_txt_enddate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//        else if(csDate < 0)
//         {
//             document.getElementById("ContentPlaceHolder1_txt_enddate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Invalid end date!';
//             document.getElementById("ContentPlaceHolder1_txt_enddate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
//             return false;
//        }
//        else if(compDate < 0)
//        {
//             document.getElementById("ContentPlaceHolder1_txt_enddate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Invalid end date!';
//             document.getElementById("ContentPlaceHolder1_txt_enddate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
//             return false;
//        }
         else 
         {
          return true;
         }

              
      if(TargetBaseControl == null) return false;
      var TargetChildControl  = "CheckBox1";
            
      //get all the control of the type INPUT in the base control.
      var Inputs = TargetBaseControl.getElementsByTagName("input"); 
     // var total=0;
      for(var n = 0; n < Inputs.length; ++n) 
      {
      //alert(Inputs.length);
         if(Inputs[n].type == 'checkbox' && Inputs[n].checked)
         {
          total=total+1;
          if(total > 8)
            {
              alert("Please Select eight students for a batch") 
              Inputs[n].checked = false;
              return false;
            }
         }       
      }
   }
   function chkone(j) {
   
//       if(TargetBaseControl == null) return false;
//          var TargetChildControl  = "CheckBox1";
//                
//          //get all the control of the type INPUT in the base control.
//          var Inputs = TargetBaseControl.getElementsByTagName("input"); 
//          var total=0;
//          for(var n = 0; n < Inputs.length; ++n) {
//             if(Inputs[n].type == 'checkbox' && Inputs[n].checked)
//             {
//              total=total+1;
//              if(total > 8)
//                {
//                  alert("Please Select maximum of eight students for a batch") 
//                  j.checked = false;
//                  return false;
//                }
//             }
//          
//          }
      }
      
      function getrack()
      {
          if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Fast")
          {
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='';
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='none';
          }
          else if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Normal")
          {
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='';
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='none';
          }
          else if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Zip")
          {
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='';
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='none';
          }
          else if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select")
          {
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='none';
          }
      }

function chkvalid()
{
               
      if(TargetBaseControl == null) return false;
      
      //get target child control.
      var TargetChildControl = "CheckBox1";
            
      //get all the control of the type INPUT in the base control.
      var Inputs = TargetBaseControl.getElementsByTagName("input"); 
            
      for(var n = 0; n < Inputs.length; ++n)
         if(Inputs[n].type == 'checkbox' && 
            Inputs[n].id.indexOf(TargetChildControl,0) >= 0 && 
            Inputs[n].checked)
          return true;        
            
      alert('Select at least one student!');
      return false;
 
 }
 
 var checkCount=0
function setChecks(obj)
{ 
if(document.getElementById("ContentPlaceHolder1_ddl_batchcode2").value=="")
{
alert("Select batch To Be Moved");
obj.checked = false
}
 else
 {
 
var maxchecks=document.getElementById("ContentPlaceHolder1_hdnfree").value
	if(obj.checked)
	{
	    checkCount=checkCount+1	 
	}
	else
	{
	    checkCount=checkCount-1
	}
	if (checkCount > maxchecks)
	{	    
        alert('This lab have '+maxchecks+' free systems only')
        obj.checked = false
        checkCount = checkCount - 1
    }
  }
}


 function SearchValidate()
  {
    var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.CheckBoxList1.ClientID%>');   
     var checkbox = CHK.getElementsByTagName("input");
     for (var i=0;i<checkbox.length;i++)
     {             
        if (checkbox[i].checked)
        {
            select++;            
        }
     }
 if(min>select)
	{
	     alert("Please select software(s)");
	     document.getElementById('<%=this.CheckBoxList1.ClientID%>').focus();
         return false;	        
    }  
 }





 </script>


 
         
     
<div class="free-forms" style="border:none">
<table class="no-borders" id="getdetails"  runat="server" width="100%">
             <tr>
                 <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                     padding-top: 0px">
                 <h4>Select Module</h4>
                 </td>
             </tr>
             <tr>
                 <td colspan="4">
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" Visible="False" /></td>
             </tr>
             <tr class="no-borders">
                 <td style="width: 144px" >
                     &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module name"></asp:Label></td><td>
                     &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server" OnSelectedIndexChanged="ddl_coursename_SelectedIndexChanged" AutoPostBack="True">
             </asp:DropDownList></td>
                 <td>
                     </td>
                 <td>&nbsp;
                     </td>
             </tr>
             <tr class="no-borders">
                 <td style="width: 144px">
                     &nbsp;<asp:Label ID="lbl_soft" runat="server" Text="Search by Software"></asp:Label></td>
                 <td>
                     <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                     </asp:CheckBoxList></td>
                 <td>
                 </td>
                 <td>
                 </td>
             </tr>
            
             <tr visible="false" runat="server" 
class="no-borders">
                 <td style="width: 144px; height: 23px">
                     <asp:Label ID="Label2" runat="server" Text="studentid"></asp:Label></td>
                 <td style="height: 23px">
                     <asp:TextBox ID="txt_search" runat="server" CssClass="text" ></asp:TextBox></td>
                 <td style="height: 23px">
                 </td>
                 <td style="height: 23px">
                 </td>
             </tr>
             <tr 
class="no-borders">
                 <td colspan="4" style="text-align: center">
            
             <asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClientClick="javascript:return SearchValidate();"  Text="Check Availability" OnClick="Button2_Click"/>
                         <asp:HiddenField ID="hdnfreesystem" runat="server" />
                 </td>
             </tr>
             
             
         <tr 
class="no-borders">
             <td colspan="4" style="height: 3px; text-align: center">
                 <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
         </tr>
    </table>
    
                                                    </div>
    
    
    <table class="common" id="tblBatch" runat="server" visible="false" >
        <tr>
            <td colspan="2" style=" padding:0px;"><h4>
                Add Student To Running Batch</h4>
            </td>
        </tr>
          
        <tr>
            <td colspan="2">   
                <div class="free-forms">
				
				<table id="Table1" runat="server" width="100%" class="common" visible="true">
                    <tr>
                        <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                            padding-top: 0px">
                            <h4>
                                Select Batch
                            </h4>
                        </td>
                    </tr>
                    <tr>
                         
                        <td colspan="4" style="text-align:center" >
                            <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
                         
                    </tr>
                    <tr>
                        <td>
                            Faculty Name <br />
                            <asp:DropDownList ID="ddl_fac" runat="server" CssClass="text"  Width="130px">
                            </asp:DropDownList><br />
                            <asp:Label ID="Label1" runat="server"></asp:Label></td>
                        <td>
                            Slot<br />
                            <asp:DropDownList ID="ddl_slot" runat="server" CssClass="text"    Width="130px">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                                <asp:ListItem Value="Daily">Daily</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            Select Month<br />
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="text"  Width="130px">
                                <asp:ListItem Value="01">January</asp:ListItem>
                                <asp:ListItem Value="02">February</asp:ListItem>
                                <asp:ListItem Value="03">March</asp:ListItem>
                                <asp:ListItem Value="04">April</asp:ListItem>
                                <asp:ListItem Value="05">May</asp:ListItem>
                                <asp:ListItem Value="06">June</asp:ListItem>
                                <asp:ListItem Value="07">July</asp:ListItem>
                                <asp:ListItem Value="08">August</asp:ListItem>
                                <asp:ListItem Value="09">September</asp:ListItem>
                                <asp:ListItem Value="10">October</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            Select Year<br />
                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="text"  Width="130px">
                                <asp:ListItem Value="2011">2011</asp:ListItem>
                                <asp:ListItem Value="2012">2012</asp:ListItem>
                                <asp:ListItem Value="2013">2013</asp:ListItem>
                                <asp:ListItem Value="2014">2014</asp:ListItem>
                                <asp:ListItem Value="2015">2015</asp:ListItem>
                                <asp:ListItem Value="2016">2016</asp:ListItem>
                                <asp:ListItem Value="2017">2017</asp:ListItem>
                                <asp:ListItem Value="2018">2018</asp:ListItem>
                                <asp:ListItem Value="2019">2019</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" OnClick="btnsubmit_Click"
                                Text="Submit" /></td>
                    </tr>
                </table>
				</div>
                
                <div class="free-forms">
				
				<table id="move" runat="server" class="common" style="width: 100%" visible="false">
                    <tr>
                        <td colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                            padding-top: 0px; height: 39px">
                            <h2 style="margin: 0px">
                                <strong>Move student to this batch</strong></h2>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="color: maroon">
                            <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="color: maroon; ">
                            <strong>Select batchcode</strong></td>
                        <td colspan="1" style="width: 302px; color: maroon; ">
                            <asp:DropDownList ID="ddl_batchcode2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode2_SelectedIndexChanged" Width="266px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                            <strong>
                                <asp:Label ID="mod" runat="server" Font-Bold="True" Text="Module" Visible="False"></asp:Label></strong></td>
                        <td style="width: 352px; ">
                            <asp:Label ID="lblsoftware" runat="server" Text=""></asp:Label></td>
                        <td rowspan="12" style="width: 302px">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="287px" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="5">
                                <Columns>
                                    <asp:TemplateField HeaderText="Content">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("content") %>'></asp:Label>
                                            <asp:Label ID="subid" runat="server" Text='<%# Bind("subcontent_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Classdate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("classdate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("classdate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td style="width: 89px;">
                            <asp:Label ID="BatchTiming" runat="server" Font-Bold="True" Text="BatchTiming" Visible="False"></asp:Label></td>
                        <td style="width: 352px; ">
                            <asp:Label ID="lbl_timing" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                            <asp:Label ID="Slot" runat="server" Font-Bold="True" Text="Slot" Visible="False"></asp:Label></td>
                        <td style="width: 352px; ">
                            <asp:Label ID="lbl_slot" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                            <asp:Label ID="Lab" runat="server" Font-Bold="True" Text="Lab" Visible="False"></asp:Label></td>
                        <td style="width: 352px; ">
                            <asp:Label ID="lbl_lab" runat="server"></asp:Label>
                            <asp:Label ID="lab_id" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 89px">
                            <asp:Label ID="faculty" runat="server" Font-Bold="True" Text="Faculty Name" Visible="False"></asp:Label></td>
                        <td style="width: 352px">
                            <asp:Label ID="name" runat="server"></asp:Label>
                            <asp:Label ID="fac_id" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                            <asp:Label ID="FreeSystem" runat="server" Font-Bold="True" Text="Available" Visible="False"></asp:Label></td>
                        <td style="width: 352px; height: 7px">
                            <asp:Label ID="lbl_free" runat="server"></asp:Label>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px;">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Current Strength" Width="101px" Visible="False"></asp:Label></td>
                        <td style="width: 352px; ">
                            <asp:Label ID="totalsys" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                        </td>
                        <td style="width: 352px; ">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px;">
                        </td>
                        <td style="width: 352px; ">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                        </td>
                        <td style="width: 352px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                        </td>
                        <td style="width: 352px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 89px; ">
                        </td>
                        <td style="width: 352px; ">
                        </td>
                    </tr>
                </table>
				
				</div>
                
                <div class="free-forms">
				<table class="common" id="tblstudent" runat="server" width="100%" visible="false" >
                <tr><td   style=" padding:0px; "><h4>
                    Select Student</h4>
            </td> </tr>
                    <tr>
                        <td style="">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Find By : StudentID /StudentName/Course"></asp:Label>
                            <asp:TextBox
                                ID="txt_studentid" runat="server" CssClass="text" MaxLength="200" Width="303px"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td id="serachs" runat="server" visible="false">
                            <asp:Label
                                    ID="Label9" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Course Name :"></asp:Label>&nbsp;<asp:DropDownList
                                        ID="coursename_ddl" runat="server">
                                    </asp:DropDownList>&nbsp;
                            <asp:Button ID="btn_search" runat="server" CssClass="search" OnClick="btn_search_Click" /></td>
                    </tr>
                <tr> <td style="height: 214px">
            <div style=" width:650px; max-height:400px; overflow:auto">          
    <asp:GridView ID="Gridvw" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Student Records Found"    Width="600px" OnPageIndexChanging="Gridvw_PageIndexChanging1" >
            <Columns>
            
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                      
                        <asp:CheckBox ID="CheckBox1"  runat="server" OnClick="setChecks(this);" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Id">
                <ItemTemplate>
                 <%#Eval("student_id")%>
                    <asp:Label ID="lbl_stdid" runat="server" Visible="false" Text='<%#Eval("student_id")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                <ItemTemplate>
                 <%#Eval("enq_personal_name")%>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course Name">
                <ItemTemplate>
                 <%#Eval("program")%>
                    <asp:Label ID="lbl_coursename" Visible="false" runat="server" Text='<%#Eval("course_id")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
               
            </Columns>
        <HeaderStyle BackColor="#FFC0C0" />
    </asp:GridView>
    
    </div>
    </td></tr>
                    <tr align="center" >
                        <td align="center" style="text-align:center;"> 
                            <asp:Button ID="btn_Movestudent" runat="server" CssClass="btnStyle1" OnClick="btn_Movestudent_Click"
                                OnClientClick="javascript:return chkvalid();" Text="Allocate" /></td>
                    </tr>
                </table>
				</div>
            </td>
        </tr>
         
                <tr visible="false">
                    <td class="w290 talignleft" style="width: 93px; height: 25px;">
                        Software name</td>
                    <td style="width: 334px; height: 25px;">
                        <asp:Label ID="lbl_coursename" runat="server" Text=''></asp:Label></td>
                </tr>
        <tr>
            <td colspan="2" style=" text-align:center" id="tblbutton">
                <asp:HiddenField ID="hdnModule" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="hdbcontent" runat="server" />
                <asp:HiddenField ID="hdnfree" runat="server" />
                &nbsp;<br />
                            <br />
                &nbsp;<br />
            </td>
        </tr>
            </table>
    <br />
    
</asp:Content>

