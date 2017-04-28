<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="NewBatchcreation.aspx.cs" Inherits="superadmin_NewBatchcreation" Title="Create Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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


 function SearchValidate()
           {
        
                    
                if(document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_coursename").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = '*Please select module name!';
             document.getElementById("ContentPlaceHolder1_ddl_coursename").focus();
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
             //alert("Please select course");
             return false;
         }
         
         
//         if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select")
//         {    
//             document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select";
//             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = '*Please select track!';
//             document.getElementById("ContentPlaceHolder1_ddl_Track").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_Track").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_Track").style.backgroundColor="#e8ebd9";
//             //alert("Please select track");
//             return false;
//         }
           }





 </script>


 
         <table class="common" width="600">
             <tr>
                 <td  style="padding:0px;">
                 <h4>Select list of students to be batched</h4>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" OnClick="Button1_Click" /></td>
             </tr>
             <tr>
                 <td >
                     &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module name"></asp:Label>
                     &nbsp; &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server">
             </asp:DropDownList></td>
             </tr>
             <tr>
                 <td>
                     &nbsp;<asp:Label ID="Label2" runat="server" Text="Search by student Id/Name"></asp:Label>&nbsp;
                     &nbsp;<asp:TextBox ID="txt_search" runat="server" CssClass="text"></asp:TextBox>
                     &nbsp;&nbsp;
            
             <asp:Button ID="Button2" runat="server" CssClass="search" OnClientClick="javascript:return SearchValidate();" OnClick="Button2_Click"/>&nbsp;
                     </td>
             </tr>
             <tr><td style="text-align:center;">
                 &nbsp;&nbsp;&nbsp; &nbsp;
             </td></tr>
             
         <tr><td style="text-align:center; height: 3px; width: 374px;"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
    </table>
    <br />
<div style="overflow:auto; max-height:400px;">
    <asp:GridView ID="Gridvw" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Student Records Found" AllowPaging="True" OnPageIndexChanging="Gridvw_PageIndexChanging" OnRowDataBound="Gridvw_RowDataBound" PageSize="100" >
            <Columns>
            
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                      
                        <asp:CheckBox ID="CheckBox1" runat="server" OnClick="chkone(this);" />

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
                <asp:TemplateField HeaderText="Track">
                <ItemTemplate>
                 <asp:Label ID="lbl_track" runat="server" Visible="false" Text='<%#Eval("Track")%>'></asp:Label>
                 <asp:Label ID="lbl_Bindtrack" runat="server" Text='<%#Eval("Track")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
               
            </Columns>
        </asp:GridView>
                                                    </div>
    <br />
        
        
    
    <table class="common" id="tblBatch" runat="server" visible="false">
        <tr>
            <td colspan="2" style=" padding:0px;"><h4>Create new batch for the selected students</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; height: 23px;"><asp:Label ID="Label1" CssClass="error" runat="server" Text=""></asp:Label>
            </td>
        </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 93px">
                        Software name</td>
                    <td style="width: 334px">
                        <asp:Label ID="lbl_coursename" runat="server" Text=''></asp:Label></td>
                </tr>
        <tr id="lbltvis" visible="false" runat="server">
            <td class="w290 talignleft" style="height: 23px; width: 93px;">
                Track</td>
            <td style="height: 23px; width: 334px;">
                <asp:Label ID="lbl_track" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
                 <td class="w290 talignleft" style="height: 26px; width: 93px;">
                     Track </td>
                    
                    <td style="height: 26px; width: 334px;">
                     
                     <asp:DropDownList ID="ddl_Track" runat="server" onChange="getrack()" >
                         <asp:ListItem>Select</asp:ListItem>
                         <asp:ListItem>Fast</asp:ListItem>
                         <asp:ListItem>Normal</asp:ListItem>
                         <asp:ListItem>Zip</asp:ListItem>
                     </asp:DropDownList></td>
             </tr>
        <tr>
            <td class="w290 talignleft" style="width: 93px">
                Batch Timing</td>
            <td style="width: 334px">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>7amto9am</asp:ListItem>
                    <asp:ListItem>9amto11am</asp:ListItem>
                    <asp:ListItem>11amto1pm</asp:ListItem>
                    <asp:ListItem>1pmto3pm</asp:ListItem>
                    <asp:ListItem>3pmto5pm</asp:ListItem>
                    <asp:ListItem>5pmto7pm</asp:ListItem>
                    <asp:ListItem>7pmto9pm</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
                    <td class="w290 talignleft" style="width: 93px">
                        Lab name</td>
                    <td style="width: 334px" >
                        <asp:DropDownList ID="ddl_labname" runat="server" OnSelectedIndexChanged="ddl_labname_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 93px">
                        Faculty name</td>
                    <td style="width: 334px">
                        <asp:DropDownList ID="ddl_facultyname" runat="server" OnSelectedIndexChanged="ddl_facultyname_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                
        <tr>
            <td class="w290 talignleft" style="width: 93px">
                Slot</td>
            <td style="width: 334px">
                <asp:DropDownList ID="ddl_slotnormal" runat="server" style="display:none;">
                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddl_slotfast" runat="server" style="display:none;">
                 <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddl_slotzip" runat="server" style="display:none;">
                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                 <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl_Slot" runat="server"></asp:Label>
                <script type="text/javascript">
                getrack();
                </script>
                </td>
                
        </tr>
                
        <tr>
            <td class="w290 talignleft" style="width: 93px" >
                Batch start-date</td>
            <td style="width: 334px; color: navy;" >
                <asp:TextBox ID="txt_stratdate" onpaste="return false" CssClass="text datepicker" MaxLength="10" runat="server"></asp:TextBox>
                 
                Batch end-date
                <asp:Label ID="txt_enddate" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style=" text-align:center">
                <br />
    <asp:Button ID="btn_submit" CssClass="submit" runat="server" Text="Allocate" OnClientClick="javascript:return TestCheckBox();" OnClick="btn_submit_Click" /> 
                        <asp:Button ID="BtnReset" runat="server" cssClass="submit" Text="Reset"  ToolTip="Reset" OnClick="BtnReset_Click"  /><br />
                <br />
            </td>
        </tr>
            </table>
    
    <br />


    
</asp:Content>

