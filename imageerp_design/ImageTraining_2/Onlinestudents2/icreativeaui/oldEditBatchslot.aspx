<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="EditBatchslot.aspx.cs" Inherits="superadmin_EditBatchslot" Title="Edit Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

// Extended Tooltip Javascript
// copyright 9th August 2002, 3rd July 2005, 24th August 2008
// by Stephen Chapman, Felgall Pty Ltd

// permission is granted to use this javascript provided that the below code is not altered
function pw() {return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth}; function mouseX(evt) {return evt.clientX ? evt.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft) : evt.pageX;} function mouseY(evt) {return evt.pageY ? evt.pageY : evt.clientY + (document.documentElement.scrollTop || document.body.scrollTop)} function popUp(evt,oi) {if (document.getElementById) {var wp = pw(); dm = document.getElementById(oi); ds = dm.style; st = ds.visibility; if (dm.offsetWidth) ew = dm.offsetWidth; else if (dm.clip.width) ew = dm.clip.width; if (st == "visible" || st == "show") { ds.visibility = "hidden"; } else {tv = mouseY(evt) - 220; lv = mouseX(evt) - (ew/4); if (lv < 2) lv = 2; else if (lv + ew > wp) lv -= ew/2; lv += 'px';tv += 'px';  ds.left = lv; ds.top = tv; ds.visibility = "visible";}}}


</script>
 <%--<style type="text/css">
        div.htmltooltip{
       background: none repeat scroll 0 0 ivory;
    border: 1px solid black;
    color: black;
    left: -1000px;
    margin-left:-73px;
    padding: 3px;
    position: absolute;
    top: -1000px;
    z-index: 1000;
        }
        </style>--%>
 <script language="javascript" type="text/javascript">
 function val()
   { 
    if(document.getElementById("ContentPlaceHolder1_TextBox1").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_TextBox1").value=="";
             alert( "*Please Enter Reason For Changing Batch Details!");
             document.getElementById("ContentPlaceHolder1_TextBox1").focus();
             document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else
         
         {
         return true;
         }
      }
   

 function TestCheckBox()
   { 
        
   
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
             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
             alert('*Invalid slot start date!');
             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
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
    <table id="getdetails" runat="server" visible="false" class="common" width="100%">
        <tr>
            <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px">
                <h4>
                    Select list of students to be batched</h4>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" CssClass="submit" OnClick="Button1_Click"
                    Text="View Batch" /></td>
        </tr>
        <tr>
            <td style="">
                &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module name"></asp:Label></td>
            <td style="">
                &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_coursename_SelectedIndexChanged"
                    Width="150px">
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
                    <asp:ListItem Value="custom">custom</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl_Slot" runat="server"></asp:Label></td>
            <td colspan="2" rowspan="6">
                <div style="overflow: auto; height: 171px">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </div>
            </td>
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
        <tr>
            <td >
                &nbsp;<asp:Label ID="Label3" runat="server" Text="Batch start-date"></asp:Label>
                &nbsp; &nbsp; &nbsp;</td>
            <td style="">
                &nbsp;<asp:TextBox ID="txt_stratdate" runat="server" Width="140px" CssClass="text datepicker" MaxLength="10"
                    onpaste="return false"></asp:TextBox>
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
                &nbsp;<asp:Label ID="txt_enddate" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClick="Button2_Click"
                    OnClientClick="javascript:return SearchValidate();" Text="Check Availability" />
                <asp:HiddenField ID="hdnfreesystem" runat="server" />
            </td>
        </tr>
        <tr visible="false">
            <td colspan="4">
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Search by student Id/Name"></asp:Label>&nbsp;
                &nbsp;<asp:TextBox ID="txt_search" runat="server" CssClass="text"></asp:TextBox>
                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <span class="file">
    <asp:GridView ID="gvfaculty" runat="server" CssClass="common" Width="100%"  AutoGenerateColumns="False" EmptyDataText="No Labs available" >
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
    
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 3px; text-align: center">
                <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
    </table>
	</div>
    
	<div class="free-forms" style="border-style:none">
                <table class="common" id="tblstudent" visible="true" runat="server" width="100%" >
                    <tr>
                        <td colspan="4" style="padding:0px;" >
                            <h4>
                    Batch details</h4>
                        </td>
                    </tr>
             <tr>
            <td >
                Faculty Name<br />
                <asp:DropDownList ID="ddl_fac" Width="120px" runat="server">
                </asp:DropDownList></td>
                 <td>
                     Slot<br />
                     <asp:DropDownList ID="ddl_slot"  Width="120px"  runat="server">
                         <asp:ListItem Value="">All</asp:ListItem>
                         <asp:ListItem Value="MWF">MWF</asp:ListItem>
                         <asp:ListItem Value="TTS">TTS</asp:ListItem>
                         <asp:ListItem Value="Daily">Daily</asp:ListItem>
                         <asp:ListItem Value="custom">custom</asp:ListItem>
                     </asp:DropDownList></td>
            <td>
                Select Month<br />
                <asp:DropDownList ID="ddlmonth"  Width="120px"  runat="server" CssClass="text">
                <asp:ListItem Value="">All</asp:ListItem>
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
                <asp:DropDownList ID="ddlyear"  Width="120px"  runat="server" CssClass="text" >
                   <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="2011">2011</asp:ListItem>
                <asp:ListItem Value="2012">2012</asp:ListItem>
                <asp:ListItem Value="2013">2013</asp:ListItem>
                <asp:ListItem Value="2014">2014</asp:ListItem>
                <asp:ListItem Value="2015">2015</asp:ListItem>
                <asp:ListItem Value="2016">2016</asp:ListItem>
                <asp:ListItem Value="2017">2017</asp:ListItem>
                <asp:ListItem Value="2018">2018</asp:ListItem>
                <asp:ListItem Value="2019">2019</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
        
                <tr> <td align="center" style=" text-align:center;" colspan="4">
                    &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="common11" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Batch Code">
                    
                    <ItemTemplate>
                    
                    <a href="batchstudentdrop.aspx?batchcode=<%#Eval("BatchCode") %>"> <%#Eval("BatchCode") %>  </a>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("module_content") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                   
                       <%--      <a href=""  rel="htmltooltip" onclick="return false"><div id="t1"  class="htmltooltip">
                          <%#Eval("software")%></div> <%#Eval("module_content")%></a>--%>
                          <%#Eval("module_content")%>
                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("module_id") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="slot" HeaderText="Slot" HtmlEncode="False" />
                            <asp:BoundField DataField="batchtiming" HeaderText="Time" HtmlEncode="False" />
                            <asp:BoundField DataField="labname" HeaderText="Lab" HtmlEncode="False" />
                            <asp:BoundField DataField="facultyname" HeaderText="Faculty" HtmlEncode="False" />
                            <asp:BoundField DataField="startdate" HeaderText="Startdate" />
                            <asp:BoundField DataField="enddate" HeaderText="Enddate" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate  >
                                    <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("BatchCode")%>'
                                    CommandName="edt" ToolTip="Edit Batch"><img src="layout/pencilnew.png"  align="middle" alt="edit" /></asp:LinkButton>
                                     <a rel="modal" href='dropalert.aspx?batchcode=<%#Eval("batchcode")%>&iframe=true&width=500&height=140' class="error"><asp:Image id="suspend" runat="server"  ImageUrl="layout/delete.png" align="middle" alt="edit" ToolTip="Suspend  Batch" /></a>   
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/completestatus.gif"
                                        Visible="False" Height="24px" Width="23px" ToolTip="Batch Completed" />
 
                                         <a href='NewChangeBatch.aspx?batchcode=<%#Eval("batchcode")%>&module=<%# Eval("module_id") %>&software=<%#Eval("software_id")%>' class="error"><asp:Image id="change" runat="server"  ImageUrl="layout/refresh_icon.gif"  align="middle" alt="Change" ToolTip="Change  Batch" /></a>   
                                        <a href='newshufflebatch.aspx?batchcode=<%#Eval("batchcode")%>&module=<%# Eval("module_id") %>&software=<%#Eval("software_id")%>' class="error"><asp:Image id="Image2" runat="server"  ImageUrl="layout/shuffle.png"  align="middle" alt="Change" ToolTip="Change  Batch" /></a>   
                                        
                                       
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
    
    
    </td></tr></table></div>
     
													
	<div class="free-forms" runat="server" id="d1" style="border-style:none">
    <table id="Table1" class="common" runat="server" visible="false" width="100%">
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
							</div>
							
    <div class="free-forms" runat="server" id="d2" style="border-style:none">
	<table id="tblfree" class="common" runat="server" visible="false" width="100%">
    <tr><td style=" padding:0px;"><h4>Availability details</h4></td></tr>
       
    <tr><td>
                <table id="facultyfree" runat="server" class="common" width="100%"><tr>
            <td  style=" padding:0px;"><h4>Faculty details</h4>
            </td>
        </tr><tr><td>
    
    <asp:Repeater id="rpfac" runat="server">

<HeaderTemplate>
<table class="common" width="100%">
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

    </td></tr></table>
    </td>
    </tr>
    </table>
	
	</div>




















	
        
        <table class="common" style="width: 100%; background-color:rgb(239, 241, 231)" runat="server" id="t1">
            <tr>
                <td style="width: 36px; height: 25px; font-size: x-small">
                    <strong>Note : </strong>
                </td>
                <td style="width: 24px; height: 25px;font-size: x-small">
                    <strong>'- ' : </strong>
                </td>
                <td style="width: 210px; height: 25px;font-size: x-small">
                    The Faculty does not have shift in that time
                </td>
                <td style="width: 11px; height: 25px">
                    <span style="font-weight: bold; color: #008000;font-size: x-small">'Free':</span></td>
                <td style="width: 142px; height: 25px;font-size: x-small">
                    The Faculty free in that time
                </td>
                <td colspan="2" style="width: 88px; height: 25px">
                    <span style="font-weight: bold; color: #ff0000;font-size: x-small" >'Batched':</span></td>
                <td style="width: 227px; height: 25px;font-size: x-small">
                    The Faculty alloted another batch in that time
                </td>
            </tr>
        </table>
     
    
    
  
 
                
                <table id="freedetails" runat="server" class="common" visible="false"><tr><td style=" padding:0px;"><h4>Lab details</h4>
            </td></tr> <tr><td>
    <asp:GridView ID="gvlab" runat="server" CssClass="common" Width="100%" AutoGenerateColumns="False" EmptyDataText="No Labs available" >
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




         </td></tr></table>
     
    
    
  
       
                <table id="tblclass" runat="server" class="common" visible="false">
                    <tr>
                        <td  style=" padding:0px;">
                            <h4>
                                Class details</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvclass" runat="server" Width="650px"  CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Labs available" AllowPaging="True" PageSize="15"   >
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
                        </td>
                    </tr>
                </table>
      

    
<div class="free-forms" style="border-style:none">
<table id="tblconform" class="common" border="0" runat="server" visible="false" width="100%">
    <tr><td colspan="2" style=" padding:0px;"><h4>Confirmation  For Batch Updation</h4></td></tr>
    <tr><td style="height: 172px"> <table class="common" style="width: 100%"> 
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
                <strong>Slot : </strong>
                <asp:Label ID="lblslot" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
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
        <td colspan="2">
            <strong>Batch Time :</strong>
            <asp:Label ID="lblbatch" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
    </tr>
        <tr>
            <td colspan="2">
                <strong>Reason For Changing Batch Details:<br />
                </strong>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="text"
                TextMode="MultiLine" Width="397px" Height="34px" MaxLength="50"></asp:TextBox></td>
        </tr>
     </table>    </td></tr>
    <tr><td colspan="2" style="height: 25px"> 
        <asp:Literal ID="literalconform" runat="server"></asp:Literal> </td></tr>
    <tr><td  colspan="2" style="text-align:center;" >  
        <asp:Button ID="btnconform" runat="server" OnClientClick="return val();" Text="Conform" OnClick="btnconform_Click" CssClass="btnStyle1" />&nbsp;
        <asp:Button ID="btncancel" runat="server" CssClass="btnStyle2" OnClick="btncancel_Click"
            Text="Cancel" />
        <asp:Label ID="lblbatchqry" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblmainqry" runat="server" Visible="False"></asp:Label></td></tr></table></div>
    
</asp:Content>

