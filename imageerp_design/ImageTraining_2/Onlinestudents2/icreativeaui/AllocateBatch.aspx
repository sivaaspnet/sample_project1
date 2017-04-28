<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="AllocateBatch.aspx.cs" Inherits="Onlinestudents2_superadmin_AllocateBatch" Title="Allocate Batch" %>
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
         else if(document.getElementById("ContentPlaceHolder1_HiddenField1").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_HiddenField1").value=="";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please search students!';
             //alert("Please select course");
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
         else if(document.getElementById("ContentPlaceHolder1_ddl_BatchCode").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_BatchCode").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select batch code!';
             document.getElementById("ContentPlaceHolder1_ddl_BatchCode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_BatchCode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_BatchCode").style.backgroundColor="#e8ebd9";
             return false;
         }
         else 
         {
          return true;
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
//             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select track!';
//             document.getElementById("ContentPlaceHolder1_ddl_Track").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_Track").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_Track").style.backgroundColor="#e8ebd9";
//             //alert("Please select track");
//             return false;
//         }
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


 
         <table class="common" width="600px">
             <tr>
                 <td style=" padding:0px;"><h4>
                     Select list of students to be batched</h4>
                 </td>
             </tr>
             <tr>
                 <td style="text-align: left">
                     <asp:Button ID="Button1" runat="server" CssClass="submit" Text="View Batch" OnClick="Button1_Click" /></td>
             </tr>
             <tr><td style="text-align:left">
                 &nbsp;<asp:Label ID="lbl_search" runat="server" Text="Search by Module Name"></asp:Label>&nbsp;&nbsp; &nbsp; &nbsp;<asp:DropDownList ID="ddl_coursename" runat="server">
             </asp:DropDownList>
             &nbsp;
             &nbsp; &nbsp; &nbsp;&nbsp;
         </td></tr>
             <tr>
                 <td style="text-align: left">
                     &nbsp;<asp:Label ID="Label2" runat="server" Text="Search by student Id/Name"></asp:Label>&nbsp;
                     <asp:TextBox ID="txt_search" runat="server" CssClass="text"></asp:TextBox>
                     &nbsp;
                     <asp:Button ID="Button2" runat="server" CssClass="search" OnClientClick="javascript:return SearchValidate();"  OnClick="Button2_Click"/></td>
             </tr>
         <tr><td style="text-align:center; height: 26px;"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
    </table>
    <br />

    <asp:GridView ID="Gridvw" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Student Records Found" AllowPaging="True" OnPageIndexChanging="Gridvw_PageIndexChanging" >
            <Columns>
            
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                      
                        <asp:CheckBox ID="CheckBox1" runat="server"/>

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
        
       
    <br />
    
    <table class="common" id="tblBatch" runat="server" visible="false">
        <tr>
            <td colspan="2" style=" padding:0px;"> <h4>
                Allocate batch for the selected students</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; "><asp:Label ID="Label1" CssClass="error" runat="server" Text=""></asp:Label>
            </td>
        </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 80px">
                        Software name</td>
                    <td>
                        <asp:Label ID="lbl_coursename" runat="server" Text=''></asp:Label></td>
                </tr>
                        <tr>
            <td class="w290 talignleft" style="width: 80px">
                Batch Code</td>
            <td>
                <asp:DropDownList ID="ddl_BatchCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_BatchCode_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td id="trackvis" runat="server" class="w290 talignleft" style="width: 80px">
                Track</td>
            <td>
                <asp:Label ID="lbl_track" runat="server" Text=""></asp:Label></td>
        </tr>


        <tr>
            <td class="w290 talignleft" style="width: 80px">
                Batch Timing</td>
            <td>
                <asp:Label ID="lbl_Timing" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
                    <td class="w290 talignleft" style="width: 80px; height: 20px">
                        Lab name</td>
                    <td style="height: 20px" >
                        <asp:Label ID="lbl_Lab" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 80px">
                        Faculty name</td>
                    <td>
                        <asp:Label ID="lbl_Faculty" runat="server" Text=""></asp:Label></td>
                </tr>
                
        <tr>
            <td class="w290 talignleft" style="width: 80px">
                Slot</td>
            <td>
                <asp:Label ID="lbl_Slot" runat="server"></asp:Label></td>
        </tr>
                
        <tr>
            <td class="w290 talignleft" style="width: 80px" >
                Batch start-date</td>
            <td >
                <asp:Label ID="lbl_BatchStartDate" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="height: 37px; width: 80px;">
                Batch end-date</td>
            <td style="height: 37px">
                <asp:Label ID="lbl_BatchEndDate" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px; text-align:center;">
    <asp:Button ID="btn_submit" CssClass="submit" runat="server" Text="Allocate" OnClientClick="javascript:return TestCheckBox();" OnClick="btn_submit_Click" />
                        <asp:Button ID="BtnReset" runat="server" cssClass="submit" Text="Reset"  ToolTip="Reset" OnClick="BtnReset_Click"  /></td>
        </tr>
            </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    
    <br />


    
</asp:Content>

