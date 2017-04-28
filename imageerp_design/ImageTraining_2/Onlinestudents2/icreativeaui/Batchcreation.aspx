<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Batchcreation.aspx.cs" Inherits="Onlinestudents2_superadmin_Batchcreation" Title="Create Batch" %>
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
        var start = document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value;
        //var end = document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").value;

        var start_s = start.split("-");
      //  var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
       // var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        
       // var compDate = enDate - stDate;
        var csDate = stDate - toDate;     
   
//      if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").value=="")
//         {    
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").value=="";
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").focus();
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
//             alert("Please select course");
//             return false;
//         }
//        if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").value=="")
//         {    
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").value=="";
//             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select faculty name!';
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").focus();
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").style.border="#ff0000 1px solid";
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").value=="")
//         {    
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").value=="";
//             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select lab name!';
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").focus();
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").style.border="#ff0000 1px solid";
//             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value=="") 
//         {    
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value=="";
//             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select start date!';
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").focus();
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(csDate < 0)
//         {
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value=="";
//             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Invalid start date!';
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").focus();
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
//             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
//             return false;
//        }

        if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select software name!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_coursename").style.backgroundColor="#e8ebd9";
             //alert("Please select course");
             return false;
         }
         
         
        else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_Track").value=="Select")
         {    
        
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Track").value=="Select";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select track!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Track").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Track").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Track").style.backgroundColor="#e8ebd9";
             //alert("Please select track");
             return false;
         }
         
         else if(document.getElementById("ctl00_ContentPlaceHolder1_lbl_coursename").innerHTML=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_coursename").innerHTML=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please enter software name!';
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_coursename").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_lbl_coursename").style.backgroundColor="#e8ebd9";
             return false;
         } 
       
         else if(document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value=="Select")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value=="Select";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select batch time!';
             document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
             return false;
         } 
    
         else  if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select lab name!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_labname").style.backgroundColor="#e8ebd9";
             return false;
         } 
       else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select faculty name!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_facultyname").style.backgroundColor="#e8ebd9";
             return false;
         } 
         
          else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value=="") 
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select start date!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             return false;
         } 
          else if(csDate < 0)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Invalid start date!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             return false;
        }
        
         else if(document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").value=="") 
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Please select end date!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(csDate < 0)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_Label1").innerHTML = '*Invalid end date!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
             return false;
        }
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
   
       if(TargetBaseControl == null) return false;
          var TargetChildControl  = "CheckBox1";
                
          //get all the control of the type INPUT in the base control.
          var Inputs = TargetBaseControl.getElementsByTagName("input"); 
          var total=0;
          for(var n = 0; n < Inputs.length; ++n) {
             if(Inputs[n].type == 'checkbox' && Inputs[n].checked)
             {
              total=total+1;
              if(total > 8)
                {
                  alert("Please Select maximum of eight students for a batch") 
                  j.checked = false;
                  return false;
                }
             }
          
          }
      }

 </script>


         <table class="common">
             <tr>
                 <td style=" padding:0px;" colspan="2"> <h4>Select list of students to be batched</h4>

                 </td>
             </tr>
             <tr>
                 <td style="text-align: left" colspan="2">
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" OnClick="Button1_Click" /></td>
             
             </tr>
             <tr><td style="text-align:left; width: 154px; padding-bottom:0px;">
                 &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Software name"></asp:Label>&nbsp;&nbsp;
            
         </td>
                 <td style="width: 236px; text-align: left; padding-bottom:0px;">
                     <asp:Label ID="Label2" runat="server" Text="Search by Track"></asp:Label></td>
             </tr>
             <tr>
                 <td style="text-align: left; width: 154px;">
             <asp:DropDownList ID="ddl_coursename" runat="server">
             </asp:DropDownList></td>
                 <td style="width: 236px; text-align: left">
                     <asp:DropDownList ID="ddl_Track" runat="server" >
                         <asp:ListItem>Select</asp:ListItem>
                         <asp:ListItem>Fast</asp:ListItem>
                         <asp:ListItem>Normal</asp:ListItem>
                         <asp:ListItem>Zip</asp:ListItem>
                     </asp:DropDownList>
                     &nbsp;
                     <asp:Button ID="Button2" runat="server" CssClass="search" OnClick="Button2_Click"/></td>
             </tr>
         <tr><td style="text-align:center;" colspan="2"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
    </table>

    <asp:GridView ID="Gridvw" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Student Records Found" AllowPaging="True" OnPageIndexChanging="Gridvw_PageIndexChanging" >
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
                
                <asp:TemplateField HeaderText="Mobile Number">
                <ItemTemplate>
                <%#Eval("enq_personal_mobile")%>
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
                 <%#Eval("Track")%>
                 <asp:Label ID="lbl_track" runat="server" Visible="false" Text='<%#Eval("Track")%>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
               
            </Columns>
            <PagerSettings Position="TopAndBottom" />
        </asp:GridView>
    <br />
    <br />
        

    
    <table class="common">
        <tr>
            <td colspan="2" style=" padding:0px;"> <h4>Create new batch for the selected students</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;"><asp:Label ID="Label1" CssClass="error" runat="server" Text=""></asp:Label>
            </td>
        </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 112px">
                        Software name</td>
                    <td>
                        &nbsp;<asp:Label ID="lbl_coursename" runat="server" Text=''></asp:Label></td>
                </tr>
        <tr>
            <td class="w290 talignleft" style="width: 112px">
                Track</td>
            <td>
                &nbsp;<asp:Label ID="lbl_track" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 112px">
                Batch Timing</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
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
                    <td class="w290 talignleft" style="width: 112px">
                        Lab name</td>
                    <td >
                        <asp:DropDownList ID="ddl_labname" runat="server" OnSelectedIndexChanged="ddl_labname_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 112px">
                        Faculty name</td>
                    <td>
                        <asp:DropDownList ID="ddl_facultyname" runat="server" OnSelectedIndexChanged="ddl_facultyname_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                
        <tr>
            <td class="w290 talignleft" style="width: 112px">
                Slot</td>
            <td>
                <asp:DropDownList ID="ddl_slotnormal" runat="server">
                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddl_slotfast" runat="server">
                 <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddl_slotzip" runat="server">
                <asp:ListItem Value="MWF">MWF</asp:ListItem>
                <asp:ListItem Value="TTS">TTS</asp:ListItem>
                 <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl_Slot" runat="server"></asp:Label></td>
        </tr>
                
        <tr>
            <td class="w290 talignleft" style="width: 112px" >
                Batch start-date</td>
            <td >
                <asp:TextBox ID="txt_stratdate" onpaste="return false" onKeyPress="return false" CssClass="text datepicker" MaxLength="10" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="height: 37px; width: 112px;">
                Batch end-date</td>
            <td style="height: 37px">
                <asp:TextBox ID="txt_enddate" onpaste="return false" onKeyPress="return false" runat="server" CssClass="text datepicker" MaxLength="10"></asp:TextBox></td>
        </tr>
            </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btn_submit" CssClass="submit" runat="server" Text="Allocate" OnClientClick="javascript:return TestCheckBox();" OnClick="btn_submit_Click" />&nbsp;
    &nbsp;<input id="btnreset" type="button" class="submit" value="Reset" onclick="return btnreset_onclick()" />&nbsp;&nbsp;
                        <br />


    
</asp:Content>

