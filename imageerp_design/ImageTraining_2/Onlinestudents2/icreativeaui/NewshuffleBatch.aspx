<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="NewshuffleBatch.aspx.cs" ValidateRequest="false" Inherits="OnlineStudents_superadmin_NewshuffleBatch" Title="NewshuffleBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

var TargetBaseControl = null;
var TargetBaseControl1 = null;
        
   window.onload = function()
   {
      try
      {
         //get target base control.
         TargetBaseControl = 
           document.getElementById('<%= this.Gridvw.ClientID %>');
          
      }
      catch(err)
      {
         TargetBaseControl = null;
       
      }
   }
        
   function TestCheckBox()
   {              
      if(TargetBaseControl == null) return false;
      
      //get target child control.
      var TargetChildControl = "CheckBox1";
            
      //get all the control of the type INPUT in the base control.
      var Inputs = TargetBaseControl.getElementsByTagName("input"); 
            
      for(var n = 0; n < Inputs.length; ++n)
      {
         if(Inputs[n].type == 'checkbox' && 
            Inputs[n].id.indexOf(TargetChildControl,0) >= 0 && 
            Inputs[n].checked)
            {
          var ii=1;
            }
      }
            if(ii==1)
            {
            document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML="";
           var res= confirm("Are you sure! You want to move?");
          if(res)
          {
          return true;
          }
          else
          {
           return false;
          }
            }
            else
            {
            document.getElementById("ContentPlaceHolder1_Gridvw_CheckBox1_0").focus();
            document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select studentid from the list!';
            return false;
            }
   }
    function changebatch()
    {
    if(document.getElementById("ContentPlaceHolder1_ddl_batchcode1").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").value=="";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").focus();
             document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode!';
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").style.backgroundColor="#e8ebd9";
             return false;
         }
      else if(document.getElementById("ContentPlaceHolder1_ddl_batchcode2").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").value=="";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").focus();
             document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode to view batch details!';
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else
         {
         TestCheckBox();
         if(document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML == '*Please select studentid from the list!')
         {
         return false;
         }
         else
         {
         return true;
         }
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
            Inputs[n].checked  )
             
               return true;
      alert('Select at least one student !');
  
      
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


</script>

 <h4>Change Batch</h4>


       
    
		             
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
	<tr><td style="text-align:center">
    <asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
	    <tr id="tr1" runat="server">
            <td colspan="10" style=" padding:0px; height: 39px;">
                <h2  style="margin:0px; ">
                    <strong>Select student from this batch</strong></h2></td>
        </tr> 
        <tr id="tr2" runat="server">
            <td>
                <asp:Label ID="Label1" runat="server" Text="Faculty Name"></asp:Label><br />
                <asp:DropDownList ID="ddl_fac" runat="server" Width="97px">
                </asp:DropDownList></td>
            <td>
                Slot<br />
                <asp:DropDownList ID="ddl_slot" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="MWF">MWF</asp:ListItem>
                    <asp:ListItem Value="TTS">TTS</asp:ListItem>
                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                     <asp:ListItem Value="ZIP">ZIP</asp:ListItem>
                    <asp:ListItem Value="WEEKEND">WEEKEND</asp:ListItem>
                     <asp:ListItem Value="WEEKEND 2Hr">WEEKEND 2Hr</asp:ListItem>
                    <asp:ListItem Value="Custom">Custom</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                Select Month<br />
                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="text">
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
                <asp:DropDownList ID="ddlyear" runat="server" CssClass="text">
                    <asp:ListItem Value="2011">2011</asp:ListItem>
                    <asp:ListItem Value="2012">2012</asp:ListItem>
                    <asp:ListItem Value="2013">2013</asp:ListItem>
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" CssClass="submit" OnClick="btnsubmit_Click"
                    Text="Submit" /></td>
        </tr >

	
	
        <tr id="batch" runat="server" visible="false">
            <td colspan="5"  style="color: maroon; font-style: normal;">
                <strong>Select batchcode</strong>
                <asp:DropDownList ID="ddl_batchcode1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode1_SelectedIndexChanged" Width="214px">
                </asp:DropDownList></td>
            
        </tr>
		</table>
		
                    <asp:Label ID="lbl_mod" runat="server" Text="Module" Visible="False" Font-Bold="True" ForeColor="Maroon"></asp:Label>
               
                <asp:Label ID="lbl_Fmodule" runat="server"></asp:Label>
    <h4>
                                 Batch details</h4>
		                        <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" id="tblstudent" cellspacing="0" class="common" width="100%">
    
       
                    
                     <tr>
                        
                         <td colspan="4" align="center">
                             <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
                        
                     </tr>
                     <tr>
                         <td align="left">
                             Faculty Name<br />
                             <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="text">
                             </asp:DropDownList><br />
                       <asp:Label ID="Label2" runat="server"></asp:Label></td>
                         <td  align="left">Slot<br />
                             <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="text">
                                 <asp:ListItem Value="">All</asp:ListItem>
                                 <asp:ListItem Value="MWF">MWF</asp:ListItem>
                                 <asp:ListItem Value="TTS">TTS</asp:ListItem>
                                 <asp:ListItem Value="Daily">Daily</asp:ListItem>
                              <asp:ListItem Value="ZIP">ZIP</asp:ListItem>
                            <asp:ListItem Value="WEEKEND">WEEKEND</asp:ListItem>
                             <asp:ListItem Value="WEEKEND 2Hr">WEEKEND 2Hr</asp:ListItem>
                            <asp:ListItem Value="Custom">Custom</asp:ListItem>
                       </asp:DropDownList></td>
                         <td  align="left">Select Month<br />
                             <asp:DropDownList ID="ddlmonth1" runat="server" CssClass="text">
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
                         <td  align="left">Select Year<br />
                             <asp:DropDownList ID="ddlyear1" runat="server" CssClass="text" Width="100">
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
                             <asp:Button ID="Button1" runat="server" CssClass="btnStyle1" 
                                 Text="Submit" OnClick="Button1_Click" /></td>
                     </tr>
                 </table>
				 </div>
		
                                 <div class="free-forms" style="margin-top:10px">
    <table id="move" runat="server" cellpadding="0" cellspacing="0" class="common" width="100%">
         <tr>
             <td colspan="3" style=" padding:0px; height: 39px;">
                 <h2  style="margin:0px; width:100%;">
                     <strong>Move student to this batch</strong></h2></td>
         </tr>
         <tr>
             <td colspan="3" style="color: maroon; height: 25px;">
                 <strong>Select batchcode</strong><br /><asp:DropDownList ID="ddl_batchcode2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode2_SelectedIndexChanged">
                </asp:DropDownList>
                     <asp:Label ID="Label4" runat="server"></asp:Label> 
                 
                
                 <asp:HiddenField ID="ddlbatch1" runat="server" />
             </td>
         </tr>
         <tr class="no-borders">
             <td>
                 <strong>
                     <asp:Label ID="mod" runat="server" Text="Module" Visible="False" Font-Bold="True"></asp:Label></strong></td>
             <td style="height: 6px; width: 1020px;">
                 <asp:Label ID="lblsoftware" runat="server" Text=''></asp:Label></td>
             <td align="center" colspan="1" rowspan="10" style="text-align: center; width: 60%;">
                 <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="False" Width="100%">
                  <Columns>
                        <asp:TemplateField HeaderText="Software">
                                 <ItemTemplate>
                                     <asp:CheckBox ID="chksoftwareid" runat="server" Text='<%# Bind("software_name") %>' />
                                 <asp:HiddenField runat="server" ID="hdnsoftwareid" Value='<%# Bind("software_id") %>' /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                    </Columns>
                 
                 </asp:GridView>
             </td>
         </tr>
         <tr class="no-borders" style="font-weight: bold">
          <td style="width: 618px; height: 2px" >
                 <asp:Label ID="BatchTiming" runat="server" Text="BatchTiming" Visible="False" Font-Bold="True"></asp:Label></td>
             <td style="width: 1020px; height: 2px" >
                 <asp:Label ID="lbl_timing" runat="server"></asp:Label></td>
           
         </tr>
         <tr class="no-borders">
              <td style="width: 618px" >
                 <asp:Label ID="Slot" runat="server" Text="Slot" Visible="False" Font-Bold="True"></asp:Label></td>
             <td style="width: 1020px" >
                 <asp:Label ID="lbl_slot" runat="server"></asp:Label></td>
         </tr>
        
         <tr class="no-borders">
             <td style="width: 618px; height: 1px" >
                 <asp:Label ID="Lab" runat="server" Text="Lab" Visible="False" Font-Bold="True"></asp:Label></td>
             <td style="width: 1020px; height: 1px" >
                 <asp:Label ID="lbl_lab" runat="server"></asp:Label></td>
         </tr>
         <tr class="no-borders">
             <td style="width: 618px" >
                 <asp:Label ID="faculty" runat="server" Font-Bold="True" Text="Faculty Name" Visible="False"></asp:Label></td>
             <td style="width: 1020px" >
                 <asp:Label ID="name" runat="server"></asp:Label></td>
         </tr>
          <tr class="no-borders">
             <td style="width: 618px; height: 7px" >
                 <asp:Label ID="FreeSystem" runat="server" Text="Available" Visible="False" Font-Bold="True"></asp:Label></td>
             <td style="width: 1020px; height: 7px" >
                 <asp:Label ID="lbl_free" runat="server"></asp:Label>&nbsp;
                 <asp:Label ID="totalsys" runat="server"></asp:Label>
             </td>
         </tr>
         <tr class="no-borders">
             <td style="width: 618px; height: 7px">
             </td>
             <td style="width: 1020px; height: 7px">
             </td>
         </tr>
         <tr class="no-borders" align="center" style=" text-align:center;"> 
             <td colspan="2" align="center" style=" text-align:center;">&nbsp;
                 </td>
         </tr>
         <tr class="no-borders" align="center" style="text-align: center">
             <td align="center" colspan="2" style="height: 23px; text-align: center">
             </td>
         </tr>
         <tr class="no-borders" align="center" style="text-align: center">
             <td align="center" colspan="2" style="height: 32px; text-align: center">
             </td>
         </tr>
     </table>
			</div>
     
            </td>
        </tr>
        <tr id="lblstu" runat="server" visible="false">
            <td id="t1" runat="server" colspan="10" style="color: maroon;" visible="false" >
             <h2  style="margin:0px; ">
                <asp:Label ID="lbl_stu" runat="server" Font-Bold="True" Text="Select student" Visible="False"></asp:Label></h2></td>
                
        </tr>
        <tr runat="server" visible="false" id="gridshow">
            <td id="t2" runat="server" visible="false" colspan="10"  align="center" style=" text-align:center;"   >
                <asp:GridView ID="Gridvw" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="common" EmptyDataText="No Student Records Found">
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red"  />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1"  runat="server" OnClick="setChecks(this);" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Id">
                            <ItemTemplate>
                                <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("studentid").ToString())%>
                                <asp:Label ID="lbl_stdid" runat="server" Text='<%#Eval("studentid")%>' Visible="false"></asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("enq_personal_name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_Module" Visible="false" runat="server" Text='<%# Bind("module_content") %>'></asp:Label>
                                <asp:Label ID="name" runat="server" Text='<%# Bind("enq_personal_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="btn_Movestudent" runat="server" CssClass="btnStyle1"  Text="Allocate"  OnClientClick="javascript:return chkvalid();"  OnClick="btn_Movestudent_Click"  /></td>
        </tr>
        <tr>
            <td colspan="6" style=" text-align:center;">
                &nbsp;<asp:HiddenField ID="hdnModule" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="hdbcontent" runat="server" />
    <asp:HiddenField ID="hdnfree" runat="server" />
                <asp:HiddenField ID="hdnsoft" runat="server" />
            </td>
            <td colspan="1" style="width: 11px; text-align: center">
            </td>
            <td colspan="1" style="width: 61px; text-align: center">
            </td>
            <td colspan="1" style="text-align: center; width: 11px;">
            </td>
            <td colspan="1" style="text-align: center; width: 11px;">
            </td>
        </tr></table>
            </td>
        </tr>
    <tr>
        <td style="text-align: center">
</td>
    </tr>
</table>
</asp:Content>

