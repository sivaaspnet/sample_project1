<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="1createnewBatch.aspx.cs" Inherits="superadmin_1createnewBatch" Title="Create Batch" %>
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
   function checkbox()
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
	     alert("Please select atleast one software");
	     document.getElementById('<%=this.CheckBoxList1.ClientID%>').focus();
         return false;	        
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
   
//      if(document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="")
//         {    
//             document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="";
//             document.getElementById("ContentPlaceHolder1_ddl_coursename").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
//             alert("Please select course");
//             return false;
//         }
//        if(document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="")
//         {    
//             document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select faculty name!';
//             document.getElementById("ContentPlaceHolder1_ddl_facultyname").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(document.getElementById("ContentPlaceHolder1_ddl_labname").value=="")
//         {    
//             document.getElementById("ContentPlaceHolder1_ddl_labname").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select lab name!';
//             document.getElementById("ContentPlaceHolder1_ddl_labname").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_labname").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_labname").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="") 
//         {    
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select start date!';
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(csDate < 0)
//         {
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Invalid start date!';
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
//             return false;
//        }

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
var maxchecks=document.getElementById("ContentPlaceHolder1_hdnfreesystem").value
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
//}

 function SearchValidate()
  {
     var start = document.getElementById("ContentPlaceHolder1_txt_stratdate").value;
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
//      var start = document.getElementById("ContentPlaceHolder1_txt_stratdate").value;
//        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

//        var start_s = start.split("-");
//        //var end_s = end.split("-");

//        var stDate = start_s[1]+"/"+start_s[0]+"/"+start_s[2];
//        //var enDate = end_s[2]+end_s[1]+end_s[0];
//        var startdate=  Date.parse(stDate);
//        var d = new Date();
//        var curr_date = d.getDate();
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
	     alert("Please select atleast one software");
	     document.getElementById('<%=this.CheckBoxList1.ClientID%>').focus();
         return false;	        
    }  
 
         if(document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_coursename").focus();
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
             alert("Please select course");
             return false;
         }        
         
         else if(document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             alert("Please select start date");
             return false;
         }
          else if(csDate < 0)          
         {    
             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             alert("Please select the valid start date");
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddlfac").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlfac").focus();
             document.getElementById("ContentPlaceHolder1_ddlfac").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlfac").style.backgroundColor="#e8ebd9";
             alert("Please select faculty");
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddlbatch").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlbatch").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.backgroundColor="#e8ebd9";
             alert("Please select batch time");
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddllab").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddllab").focus();
             document.getElementById("ContentPlaceHolder1_ddllab").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddllab").style.backgroundColor="#e8ebd9";
             alert("Please select lab");
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddlslot").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlslot").focus();
             document.getElementById("ContentPlaceHolder1_ddlslot").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlslot").style.backgroundColor="#e8ebd9";
             alert("Please select slot");
             return false;
         }
 }





 </script>


 <div class="free-forms">
         <table class="common" id="getdetails"  runat="server" width="100%">
             <tr>
                 <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                     padding-top: 0px">
                 <h4>Select list of students to be batched</h4>
                 </td>
             </tr>
             <tr>
                 <td colspan="4">
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" OnClick="Button1_Click" />
                 <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
             </tr>
             <tr>
                 <td style="" >
                     &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module name"></asp:Label></td><td style="">
                     &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddl_coursename_SelectedIndexChanged">
             </asp:DropDownList></td>
                 <td colspan="2">
                     &nbsp;<asp:Label ID="Label10" runat="server" Text="Search By Software Name"></asp:Label></td>
             </tr>
             <tr>
                 <td style="">
                     &nbsp;<asp:Label ID="Label4" runat="server" Text="Slot"></asp:Label></td>
                 <td style="">
                     &nbsp;<asp:DropDownList ID="ddlslot" runat="server" Width="150px">
                <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="Daily">Daily</asp:ListItem>
                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl_Slot" runat="server"></asp:Label></td>
                 <td colspan="2" rowspan="6">
                 <div style="overflow:auto; height:171px;" >
                 
                 
                     <asp:CheckBoxList ID="CheckBoxList1" Width="150px" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                     </asp:CheckBoxList> </div></td>
                    
             </tr>
             <tr>
                 <td style="">
                     &nbsp;<asp:Label ID="Label7" runat="server" Text="Lab Name" Width="57px"></asp:Label></td>
                 <td style="">
                     &nbsp;<asp:DropDownList ID="ddllab" runat="server" Width="150px">
                     </asp:DropDownList></td>
             </tr>
         
             <tr>
                 <td style="">
                     &nbsp;<asp:Label ID="Label5" runat="server" Text="Faculty Name"></asp:Label></td>
                 <td style="">
                     &nbsp;<asp:DropDownList ID="ddlfac" runat="server" Width="150px">
                     </asp:DropDownList></td>
             </tr>
             <tr><td style="" >
                 &nbsp;<asp:Label ID="Label3" runat="server" Text="Batch start-date"></asp:Label>
                 &nbsp; &nbsp;&nbsp;&nbsp;</td><td style="">
                     &nbsp;<asp:TextBox ID="txt_stratdate" onpaste="return false" CssClass="text datepicker" MaxLength="10" runat="server" Width="140px"></asp:TextBox>
                 &nbsp; &nbsp; &nbsp;</td>
             </tr>
             <tr>
                 <td style="">
                     &nbsp;<asp:Label ID="Label6" runat="server" Text="Batch Time"></asp:Label></td>
                 <td style="">
                     &nbsp;<asp:DropDownList ID="ddlbatch" runat="server" Width="150px">
                         <asp:ListItem Value="7AMto9Am">7AM to 9Am</asp:ListItem>
                         <asp:ListItem Value="9AMto11Am">9AM to 11Am</asp:ListItem>
                         <asp:ListItem Value="11AMto1PM">11AM to 1PM</asp:ListItem>
                         <asp:ListItem Value="1PMto3PM">1PM to 3PM</asp:ListItem>
                         <asp:ListItem Value="3PMto5PM">3PM to 5PM</asp:ListItem>
                         <asp:ListItem Value="5PMto7PM">5PM to 7PM</asp:ListItem>
                         <asp:ListItem Value="7PMto9PM">7PM to 9PM</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
             <tr>
                 <td style="">
                     &nbsp;Batch end-date&nbsp;
                 </td>
                 <td style="">
                     &nbsp;<asp:Label ID="txt_enddate" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
             </tr>
             <tr 
class="no-borders">
                 <td colspan="4" style="text-align: center">
            
             <asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClientClick="javascript:return SearchValidate();" OnClick="Button2_Click" Text="Check Availability"/>
                         <asp:HiddenField ID="hdnfreesystem" runat="server" />
                 </td>
             </tr>
             <tr visible="false" 
class="no-borders">
                 <td colspan="4">
                     &nbsp;<asp:Label ID="Label2" runat="server" Text="Search by student Id/Name"></asp:Label>&nbsp;
                     &nbsp;<asp:TextBox ID="txt_search" runat="server" CssClass="text"></asp:TextBox>
                     &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                 </td>
             </tr>
             
             
   
    </table>
	</div>
   
<div>
    
                                                    </div>
    
    <div class="free-forms">
    <table class="common" id="tblBatch" runat="server" visible="false" width="100%" >
        <tr>
            <td colspan="2" style=" padding:0px;"><h4>Create new batch for the selected students</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; height: 14px;"><asp:Label ID="Label1" CssClass="error" runat="server" Text="Select the students to create the batch"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Find By : StudentID /StudentName/Course"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text" MaxLength="200" Width="237px"></asp:TextBox>
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr visible="false" runat="server">
            <td colspan="2" style="height: 23px">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Course Name :"></asp:Label>&nbsp;<asp:DropDownList ID="coursename_ddl" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btn_search" runat="server" CssClass="search" OnClick="btn_search_Click" /></td>
        </tr>
          
        <tr>
            <td colspan="2">   
                <br />
                <table class="common" id="tblstudent" runat="server" >
                <tr><td   style=" padding:0px;"><h4>Students details</h4>
            </td> </tr>
                <tr> <td>
           <div style=" width:650px; max-height:400px; overflow:auto">     
               <span class="file">
                            <asp:GridView ID="gvclass" runat="server" Width="100%"  CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Labs available" AllowPaging="True" PageSize="15" OnPageIndexChanging="Gridvw_PageIndexChanging"   >
                                <Columns>
                                    <asp:TemplateField HeaderText="Class Date">
                                        <ItemTemplate>
                                            <%#Eval("classdate")%>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="ClassDate">
                <ItemTemplate>
                    <%#Eval("classdate1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Content">
                                        <ItemTemplate>
                                            <%#Eval("content")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Faculty Details">
                                        <ItemTemplate>
                                            <%#Eval("Faculty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lab  Details">
                                        <ItemTemplate>
                                            <%#Eval("Lab")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </span>     
    <asp:GridView ID="Gridvw" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Student Records Found" OnPageIndexChanging="Gridvw_PageIndexChanging"   Width="100%" >
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
                  <asp:Label id="lbl_stdname" runat="server" Text='<%#Eval("enq_personal_name")%>'></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course Name">
                <ItemTemplate>
                 <%#Eval("program")%>
                    <asp:Label ID="lbl_coursename" Visible="false" runat="server" Text='<%#Eval("course_id")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
               
            </Columns