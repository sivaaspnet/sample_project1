<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="bkpcreatenewBatch.aspx.cs" Inherits="superadmin_testcreatenewBatch" Title="testcreatenewBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

function changepayment()
 {

 if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="0,2,3,4,5,6,7" ||  document.getElementById("ContentPlaceHolder1_DropDownList1").value=="6,7")
 {
  document.getElementById("ContentPlaceHolder1_dayslot").style.display=''; 
 }
 else
 {
  document.getElementById("ContentPlaceHolder1_ddlbatch0").value=document.getElementById("ContentPlaceHolder1_ddlbatch").value;

 document.getElementById("ContentPlaceHolder1_dayslot").style.display='none'; 
 }
 
 if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="6,7")
 {
  document.getElementById("ContentPlaceHolder1_CheckBoxList2").style.display=''; 
 }
 else
 {
  document.getElementById("ContentPlaceHolder1_CheckBoxList2").style.display='none'; 
 }
 
 }



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
        var atLeast = 1;    
    var department = document.getElementById("<%=this.CheckBoxList2.ClientID%>");  
     var checkboxdept = department.getElementsByTagName("input");
     var countdept=0;
     for (var i=0;i<checkboxdept.length;i++)
     {
       if (checkboxdept[i].checked)
        {
           countdept++;
        }
     }
       
        
          var atLeasta = 1;   
       
    var departmenta = document.getElementById("<%=this.CheckBoxList1.ClientID%>");  
  
     var checkboxdepta = departmenta.getElementsByTagName("input");
 
     var countdepta=0;
     for (var ii=0;ii<checkboxdepta.length;ii++)
     {
       if (checkboxdepta[ii].checked)
        {
           countdepta++;
        }
     }
       
        
        
         if(document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_coursename").focus();
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
             alert("Please select course");
             return false;
         }  
          else if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_DropDownList1").focus();
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
             alert("Please select Slot");
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
          else if(document.getElementById("ContentPlaceHolder1_ddlfac").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlfac").focus();
             document.getElementById("ContentPlaceHolder1_ddlfac").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlfac").style.backgroundColor="#e8ebd9";
             alert("Please select faculty");
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
           
          else if(document.getElementById("ContentPlaceHolder1_ddlbatch").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlbatch").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.backgroundColor="#e8ebd9";
             alert("Please select batch time");
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_ddlbatch0").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlbatch0").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatch0").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatch0").style.backgroundColor="#e8ebd9";
             alert("Please select batch time");
             return false;
         }
         
         else if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="6,7")
         {  
          if(document.getElementById("ContentPlaceHolder1_ddlbatch0").value == document.getElementById("ContentPlaceHolder1_ddlbatch").value)
         {    
             alert("Please select different batch time");
             return false;
         }
        if(atLeast>countdept)
    {
        alert("Please select atleast 1 days");
        return false;
   } 
         }
        
    
   else if(atLeasta>countdepta)
    {
        alert("Please select atleast 1 Software");
        return false;
   } 
         else
         {
         return true;
         }
     
   
     

         
         
 }





 </script>


 <div class="free-forms">
         <table class="common" id="getdetails"  runat="server" width="100%">
             <tr>
                 <td colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                     padding-top: 0px">
                 <h4>Select list of students to be batched</h4>
                 </td>
             </tr>
             <tr>
                 <td colspan="3">
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" OnClick="Button1_Click" />
                 <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
             </tr>
             <tr>
                 <td style="" >
                     &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module name"></asp:Label></td><td style="">
                     &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddl_coursename_SelectedIndexChanged">
             </asp:DropDownList></td>
                 <td>
                     &nbsp;<asp:Label ID="Label10" runat="server" Text="Search By Software Name"></asp:Label></td>
             </tr>
             <tr>
                 <td style="">
                     &nbsp;Slot</td>
                 <td style="">
                     
                 
                  
                         
                         <asp:DropDownList ID="DropDownList1" runat="server" Width="159px" onChange="changepayment()">
                         <asp:ListItem Value="">Select</asp:ListItem>
                         <asp:ListItem Value="2,4,6">MWF</asp:ListItem>
                         <asp:ListItem Value="3,5,7">TTS</asp:ListItem>
                         <asp:ListItem Value="2,3,4,5,6,7">Daily</asp:ListItem>
                         <asp:ListItem Value="0,2,3,4,5,6,7">ZIP</asp:ListItem>
                         <asp:ListItem Value="6,7">WEEKEND</asp:ListItem>
                      
                     </asp:DropDownList>
                     
                            <asp:CheckBoxList ID="CheckBoxList2"  runat="server" 
                         RepeatDirection="Horizontal" 
                         onselectedindexchanged="CheckBoxList2_SelectedIndexChanged" style="display:none" >
                         <asp:ListItem Value="6">Fri</asp:ListItem>
                         <asp:ListItem Value="7">Sat</asp:ListItem>
                     </asp:CheckBoxList>
                         <asp:HiddenField ID="HiddenField2"   runat="server">
                    
                         </asp:HiddenField>
               
               
                                    </td>
                    
                                 
                 <td rowspan="7">
                 <div style="overflow:auto; height:171px;" >
                 
                 
                     <asp:CheckBoxList ID="CheckBoxList1" Width="150px" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                         <asp:ListItem>select</asp:ListItem>
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
                     &nbsp;<asp:TextBox ID="txt_stratdate" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker" MaxLength="10" runat="server" Width="140px"></asp:TextBox>
                 &nbsp; &nbsp; &nbsp;</td>
             </tr>
             <tr>
                 <td style="">
                     &nbsp;<asp:Label ID="Label6" runat="server" Text="Batch Time"></asp:Label></td>
                 <td style="">
                     &nbsp;<asp:DropDownList ID="ddlbatch" runat="server" Width="150px" onChange="changepayment()">
                         <asp:ListItem Value="7AMto9Am">7AM to 9Am</asp:ListItem>
                         <asp:ListItem Value="9AMto11Am">9AM to 11Am</asp:ListItem>
                         <asp:ListItem Value="11AMto1PM">11AM to 1PM</asp:ListItem>
                         <asp:ListItem Value="1PMto3PM">1PM to 3PM</asp:ListItem>
                         <asp:ListItem Value="3PMto5PM">3PM to 5PM</asp:ListItem>
                         <asp:ListItem Value="5PMto7PM">5PM to 7PM</asp:ListItem>
                         <asp:ListItem Value="7PMto9PM">7PM to 9PM</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
             <tr id="dayslot" style="display:none;">
                 <td style="">
                     <span class="file">&nbsp;<asp:Label ID="Label11" 
                         runat="server" Text="Batch Time"></asp:Label></td>
                 <td style="">
                     <span class="file"><asp:DropDownList ID="ddlbatch0" runat="server" 
                         Width="150px">
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
                 <td colspan="3" style="text-align: center">
            
                     <span class="file">
    <asp:GridView ID="gvlab" runat="server" CssClass="common" Width="900px" AutoGenerateColumns="False" EmptyDataText="No Labs available" >
        <Columns>
             
            <asp:TemplateField HeaderText="Lab Name">
                <ItemTemplate>
                    <%#Eval("LabName1")%>
                    <asp:Label ID="lbl_labid" runat="server" Text='<%#Eval("LabName1")%>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          <%--  <asp:TemplateField HeaderText="ClassDate">
                <ItemTemplate>
                    <%#Eval("classdate1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="7AM to 9AM">
                <ItemTemplate>
                   <%#Eval("seven1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="9AM to 11AM">
                <ItemTemplate>
                    <%#Eval("nine1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="11AM to 1PM">
                <ItemTemplate>
                    <%#Eval("eleven1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="1PM to 3PM">
                <ItemTemplate>
                   <%#Eval("onepm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="3PM to 5PM">
                <ItemTemplate>
                    <%#Eval("threepm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="5PM to 7PM">
                <ItemTemplate>
                   <%#Eval("fivepm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="7PM to 9PM">
                <ItemTemplate>
                   <%#Eval("sevenpm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
        </asp:GridView>
        
        
                     </span>
            
             <asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClientClick="javascript:return SearchValidate();" OnClick="Button2_Click" Text="Check Availability"/>
                         <asp:HiddenField ID="hdnfreesystem" runat="server" />
                 </td>
             </tr>
             <tr visible="false" 
class="no-borders">
                 <td colspan="3">
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
                <span class="file" style="display:none">
                            <asp:GridView ID="gvclass" runat="server" Width="100%"  
                    CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Labs available" 
                    AllowPaging="True" PageSize="15" OnPageIndexChanging="Gridvw_PageIndexChanging" 
                    onselectedindexchanged="gvclass_SelectedIndexChanged"   >
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
    
    </td></tr></table>
            </td>
        </tr>
         
                <tr visible="false">
                    <td class="w290 talignleft" style="width: 93px">
                        Software name</td>
                    <td style="width: 334px">
                        <asp:Label ID="lbl_coursename" runat="server" Text=''></asp:Label></td>
                </tr>
        <tr>
            <td colspan="2" style=" text-align:center" id="tblbutton">
                <br />
    <asp:Button ID="btn_submit" CssClass="btnStyle1" runat="server" Text="Allocate" OnClientClick="javascript:return chkvalid();" OnClick="btn_submit_Click" /> 
                        <asp:Button ID="BtnReset" runat="server" cssClass="btnStyle1" Text="Reset"  ToolTip="Reset" OnClick="BtnReset_Click"  /><br />
            </td>
        </tr>
            </table>
    </div>
	
	<div class="free-forms">
    <table id="tblfree" class="common" runat="server" visible="false" width="100%">
    <tr><td style=" padding:0px;"><h4>Availability details</h4></td></tr>
        <tr>
            <td>
                            <table class="common" width="100%" runat="server" visible="false">
                                <tr>
                                    <td style="height: 25px">
                                        <strong>Faculty Name :
                                            <asp:Label ID="lblfac_name" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></strong></td>
                                    <td style="height: 25px; color: #000000;">
                                        <strong>Lab Name : </strong>
                                        <asp:Label ID="lbllab_name" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td>
                                        <strong>Slot : </strong>
                                        <asp:Label ID="lbl_slotdetail" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
                                    <td style="color: #000000">
                                        <strong>Batch Time </strong>:
                                        <asp:Label ID="lblbatch_time" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td>
                                        <strong>Start Date : </strong>
                                        <asp:Label ID="lblst_date" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
                                    <td style="color: #000000">
                                        <strong>End Date : </strong>
                                        <asp:Label ID="lblen_date" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
                                </tr>
                            </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    <tr><td>
	<div class="free-forms" style="overflow:auto;">
                <table id="facultyfree" runat="server" class="common" width="100%"><tr>
            <td  style=" padding:0px;"><h4>Faculty details</h4>
            </td>
        </tr><tr><td>
    <asp:GridView ID="gvfaculty" runat="server" CssClass="common" Width="500px"  AutoGenerateColumns="False" EmptyDataText="No Labs available" >
        <Columns>
            <asp:TemplateField HeaderText="Faculty Name">
                <ItemTemplate>
                    <%#Eval("facultyname1")%>
                    <asp:Label ID="lbl_facid" runat="server" Text='<%#Eval("facultyname1")%>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          <%--  <asp:TemplateField HeaderText="ClassDate">
                <ItemTemplate>
                    <%#Eval("classdate")%>
                    
                </ItemTemplate>
            </asp:TemplateField>--%>
              <asp:TemplateField HeaderText="7AM to 9AM">
                <ItemTemplate>
                   <%#Eval("seven1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>   
             <asp:TemplateField HeaderText="9AM to 11AM">
                <ItemTemplate>
                    <%#Eval("nine1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="11AM to 1PM">
                <ItemTemplate>
                    <%#Eval("eleven1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="1PM to 3PM">
                <ItemTemplate>
                   <%#Eval("onepm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="3PM to 5PM">
                <ItemTemplate>
                    <%#Eval("threepm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="5PM to 7PM">
                <ItemTemplate>
                   <%#Eval("fivepm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="7PM to 9PM">
                <ItemTemplate>
                   <%#Eval("sevenpm1")%>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <asp:Repeater id="rpfac" runat="server">

<HeaderTemplate>
<table class="common"  width="400px">
<tr>
<th rowspan="2">Faculty Name</th>
<th colspan="2">7AM TO 9AM</th>
<th colspan="2">9AM TO 11AM</th>
<th colspan="2">11AM TO 1PM</th>
<th colspan="2">1PM TO 3PM</th>
<th colspan="2">3PM TO 5PM</th>
<th colspan="2">5PM TO 7PM</th>
<th colspan="2">7PM TO 9PM</th>
</tr>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
 <tr>

 </tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td><%#Eval("facultyname1")%> </td>
<td><%#Eval("sevenmwf")%> </td>
<td><%#Eval("seventts")%> </td>
<td><%#Eval("ninemwf")%> </td>
<td><%#Eval("ninetts")%> </td>
<td><%#Eval("elevenmwf")%> </td>
<td><%#Eval("eleventts")%> </td>
<td><%#Eval("onepmmwf")%> </td>
<td><%#Eval("onepmtts")%> </td>
<td><%#Eval("threepmmwf")%> </td>
<td><%#Eval("threepmtts")%> </td>
<td><%#Eval("fivepmmwf")%> </td>
<td><%#Eval("fivepmtts")%> </td>
<td><%#Eval("sevenpmmwf")%> </td>
<td><%#Eval("sevenpmtts")%> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>
    </td></tr></table></div>
	</div>
        <br />
        <br />
		<div class="free-forms">
            <table class="common" style="width: 100%; background-color: white;">
            <tr><td style="width: 36px; height: 25px;"> 
                <strong>Note :  </strong>
            </td>
                <td style="width: 24px; height: 25px;">
                    <strong>'- ' : </strong>
                </td>
                <td style="width: 210px; height: 25px;">The Faculty does not have shift in that time  </td>
                <td style="width: 11px; height: 25px;">
                    <span style="color: #008000; font-weight:bold;">'Free':</span></td>
                <td style="width: 142px; height: 25px;">
                    The Faculty free in that time 
                </td>
                <td style="width: 88px; height: 25px;" colspan="2">
                    <span style="color: #ff0000; font-weight:bold;">'Batched' :</span></td>
                <td style="width: 227px; height: 25px;">
                    The Faculty alloted another batch in that time 
                </td>
            </tr>
            </table>
			</div>
        <br />
    
    
    </td></tr>
    <tr><td>
            <div class="free-forms" style="overflow:auto;">    
                <table id="freedetails" runat="server" class="common" width="100%"><tr><td style=" padding:0px;"><h4>Lab details</h4>
            </td></tr> <tr><td>
        
        
           <asp:Repeater id="rplab" runat="server">

<HeaderTemplate>
 
<table class="common"  width="100%">
<tr>
<th rowspan="2">LAB Name</th>
<th colspan="2">7AM TO 9AM</th>
<th colspan="2">9AM TO 11AM</th>
<th colspan="2">11AM TO 1PM</th>
<th colspan="2">1PM TO 3PM</th>
<th colspan="2">3PM TO 5PM</th>
<th colspan="2">5PM TO 7PM</th>
<th colspan="2">7PM TO 9PM</th>
</tr>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
<th>MWF</th>
<th>TTS</th>
 <tr>

 </tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td><%#Eval("labname1")%> </td>
<td><%#Eval("sevenmwf")%> </td>
<td><%#Eval("seventts")%> </td>
<td><%#Eval("ninemwf")%> </td>
<td><%#Eval("ninetts")%> </td>
<td><%#Eval("elevenmwf")%> </td>
<td><%#Eval("eleventts")%> </td>
<td><%#Eval("onepmmwf")%> </td>
<td><%#Eval("onepmtts")%> </td>
<td><%#Eval("threepmmwf")%> </td>
<td><%#Eval("threepmtts")%> </td>
<td><%#Eval("fivepmmwf")%> </td>
<td><%#Eval("fivepmtts")%> </td>
<td><%#Eval("sevenpmmwf")%> </td>
<td><%#Eval("sevenpmtts")%> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>




         </td></tr></table></div>
        <br />
    
    
    </td></tr>
        <tr>
            <td>
			<div class="free-forms">
                <table id="tblclass" runat="server" class="common" visible="false" width="100%">
                    <tr>
                        <td  style=" padding:0px;">
                            <h4>
                                Class details</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
    </table>
	</div>
    <br />
<div class="free-forms">
<table id="tblconform" class="common" border="0" runat="server" visible="false" width="100%">
    <tr><td colspan="2" style=" padding:0px;"><h4>Confirmation  For Batch Creation</h4></td></tr>
    <tr><td><div class="free-forms"> <table class="common" width="100%"> 
        <tr>
            <td colspan="2" style="height: 25px">
                <strong>Batch Code :</strong>
                <asp:Label ID="lblbatchcode" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 25px">
                <strong>Module Name :</strong>
                <asp:Label ID="lblmodule_name" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
            <td style="height: 25px">
                <strong>Slot : </strong>&nbsp;<asp:Label ID="lblslot" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 25px">
                <strong>Start Date :</strong>
            <asp:Label ID="lblstartdate" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
            <td style="height: 25px">
                <strong>End Date :</strong>
            <asp:Label ID="lblenddate" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
        </tr>
    <tr>
        <td style="height: 25px">
            <strong>Faculty Name :
                <asp:Label ID="lblfac" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></strong></td><td style="height: 25px">
                    <strong>Lab Name : </strong><asp:Label ID="lbllab" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 25px" >
            <strong>Batch Time :</strong>
            <asp:Label ID="lblbatch" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
             <td style="height: 25px">
                </td>
            
    </tr>
        <tr>
            <td colspan="2">
                <strong>Software(s) :&nbsp;</strong>
            <asp:Label ID="lblsoftware" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
        </tr>
     </table> </div>   </td></tr>
    <tr><td colspan="2"> 
        <asp:Literal ID="literalconform" runat="server"></asp:Literal> </td></tr>
    <tr><td  colspan="2" style="text-align:center;" >  
        <asp:Button ID="btnconform" runat="server" Text="Conform" OnClick="btnconform_Click" CssClass="btnStyle1" />&nbsp;
        <asp:Button ID="btncancel" runat="server" CssClass="btnStyle1" OnClick="btncancel_Click"
            Text="Cancel" />
        <asp:Label ID="lblbatchqry" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblmainqry" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lbldeactive" runat="server" Visible="False"></asp:Label></td></tr></table></div>
    
</asp:Content>

