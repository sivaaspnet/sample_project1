<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="EditBatch.aspx.cs" Inherits="superadmin_createnewBatch" Title="Create Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script language="javascript" type="text/javascript">

   

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
     
//      var start = document.getElementById("ContentPlaceHolder1_txt_stratdate").value;
//        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

//        var start_s = start.split("-");
//        //var end_s = end.split("-");

//        var stDate = start_s[1]+"/"+start_s[0]+"/"+start_s[2];
//        //var enDate = end_s[2]+end_s[1]+end_s[0];
//        var startdate=  Date.parse(stDate);
//        var d = new Date();
//        var curr_date = d.getDate();
 
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


 
         <table class="common" id="getdetails" visible="false"  runat="server" width="600">
             <tr>
                 <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                     padding-top: 0px">
                 <h4>Select list of students to be batched</h4>
                 </td>
             </tr>
             <tr>
                 <td colspan="4">
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" OnClick="Button1_Click" /></td>
             </tr>
             <tr>
                 <td style="width: 144px" >
                     &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module name"></asp:Label></td><td>
                     &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server" Enabled="False" Width="150px">
             </asp:DropDownList></td>
                 <td>
                     <asp:Label ID="Label4" runat="server" Text="Slot"></asp:Label></td>
                 <td>
                <asp:DropDownList ID="ddlslot" runat="server" Width="100px">
                <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="Daily">Daily</asp:ListItem>
                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl_Slot" runat="server"></asp:Label></td>
             </tr>
             <tr>
                 <td style="width: 144px">
                     &nbsp;<asp:Label ID="Label5" runat="server" Text="Faculty Name"></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddlfac" runat="server" Width="150px">
                     </asp:DropDownList></td>
                 <td>
                     <asp:Label ID="Label7" runat="server" Text="Lab Name" Width="57px"></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddllab" runat="server" Width="100px">
                     </asp:DropDownList></td>
             </tr>
             <tr><td style="width: 144px" >
                 &nbsp;<asp:Label ID="Label3" runat="server" Text="Batch start-date"></asp:Label>
                 &nbsp; &nbsp;&nbsp;&nbsp;</td><td>
                <asp:TextBox ID="txt_stratdate" onpaste="return false" CssClass="text " MaxLength="10" runat="server" ReadOnly="True"></asp:TextBox>
                 &nbsp; &nbsp; &nbsp;</td>
                 <td>
                     Batch end-date&nbsp;
                 </td>
                 <td>
                <asp:Label ID="txt_enddate" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
             </tr>
             <tr>
                 <td style="width: 144px">
                     &nbsp;<asp:Label ID="Label6" runat="server" Text="Batch Time"></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddlbatch" runat="server" Width="150px">
                         <asp:ListItem Value="7AMto9Am">7AM to 9Am</asp:ListItem>
                         <asp:ListItem Value="9AMto11Am">9AM to 11Am</asp:ListItem>
                         <asp:ListItem Value="11AMto1PM">11AM to 1PM</asp:ListItem>
                         <asp:ListItem Value="1PMto3PM">1PM to 3PM</asp:ListItem>
                         <asp:ListItem Value="3PMto5PM">3PM to 5PM</asp:ListItem>
                         <asp:ListItem Value="5PMto7PM">5PM to 7PM</asp:ListItem>
                         <asp:ListItem Value="7PMto9PM">7PM to 9PM</asp:ListItem>
                     </asp:DropDownList></td>
                 <td>
                 </td>
                 <td>
                 </td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align: center">
            
             <asp:Button ID="Button2" runat="server" CssClass="submit" OnClientClick="javascript:return SearchValidate();" OnClick="Button2_Click" Text="Check Availability"/>
                         <asp:HiddenField ID="hdnfreesystem" runat="server" />
                 </td>
             </tr>
             <tr visible="false">
                 <td colspan="4">
                     &nbsp;<asp:Label ID="Label2" runat="server" Text="Search by student Id/Name"></asp:Label>&nbsp;
                     &nbsp;<asp:TextBox ID="txt_search" runat="server" CssClass="text"></asp:TextBox>
                     &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                 </td>
             </tr>
             
             
         <tr>
             <td colspan="4" style="height: 3px; text-align: center">
                 <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
         </tr>
    </table>
    <br />
    <br />
                <table class="common" id="tblstudent" visible="true" runat="server" >
                <tr><td   style=" padding:0px;"><h4>
                    Batch details</h4>
            </td> </tr>
                <tr> <td align="center" style=" text-align:center;">
                    &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Batch Code">
                                <ItemTemplate>
                                    <a href='Viewbatch.aspx?batchcode=<%#Eval("BatchCode") %>'>
                                        <%#Eval("BatchCode") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="module_content" HeaderText="Module" />
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
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("BatchCode")%>'
                                    CommandName="edt"><img src="layout/pencilnew.png" width="17" align="middle" alt="edit" /></asp:LinkButton>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/completestatus.gif"
                                        Visible="False" Height="24px" Width="23px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
    
    
    </td></tr></table>
    <br />
<div>
    
                                                    </div>
    
    <table id="tblfree" class="common" runat="server" visible="false" width="700px">
    <tr><td style=" padding:0px;"><h4>Availability details</h4></td></tr>
        <tr>
            <td>
                            <table class="common" runat="server" visible="false">
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
                <table id="facultyfree" runat="server" class="common"><tr>
            <td  style=" padding:0px;"><h4>Faculty details</h4>
            </td>
        </tr><tr><td>
    <asp:GridView ID="gvfaculty" runat="server" CssClass="common" Width="900px"  AutoGenerateColumns="False" EmptyDataText="No Labs available" >
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
<table class="common" border="1" width="900px">
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
