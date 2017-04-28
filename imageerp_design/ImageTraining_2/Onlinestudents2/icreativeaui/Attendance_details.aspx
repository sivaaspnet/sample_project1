<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Attendance_details.aspx.cs" Inherits="Onlinestudents2_Attendance_details" Title="Attendance Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
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
function getpost()
{
    var totalcnt=document.getElementById('ContentPlaceHolder1_hdntotalcount').value;
    var res=0;
    var totalclass=document.getElementById('ContentPlaceHolder1_hdnclasscount').value;
    for(var i=0;i<totalcnt;i++)
    { 
        if(eval("document.getElementById('ContentPlaceHolder1_gvstudents_gvstu_chkstudent_"+i+"').checked"))
        {
            res=res+1; 
        }
    }
    if(document.getElementById('ContentPlaceHolder1_hdncoductorcancel').value=="conducted" || document.getElementById('ContentPlaceHolder1_hdncoductorcancel').value=="postponed")
    {
        for(var j=0;j<totalclass;j++)
        {
            if(document.getElementById('ContentPlaceHolder1_gvattendance_gvatt_txtreason_'+j).value=="")
            {
                alert('Please enter reason for not taking the class')
                document.getElementById('ContentPlaceHolder1_gvattendance_gvatt_txtreason_'+j).focus();
                return false;
            }
        }
    }
   if(confirm("Do you want to post attendance for these "+ res +" students"))
   {
        return true;
   }
   return false;   
}


function getindividualpost(column)
{
    var totalcnt=document.getElementById('ContentPlaceHolder1_hdntotalcount').value;
    var res=0;
    for(var i=0;i<totalcnt;i++)
    { 
       if(eval("document.getElementById('ContentPlaceHolder1_gvstudents_gvstu_chkstudent_"+i+"').checked"))
       {
            res=res+1; 
       }
    }
    if(document.getElementById('ContentPlaceHolder1_hdncoductorcancel').value=="conducted" || document.getElementById('ContentPlaceHolder1_hdncoductorcancel').value=="postponed")
    {
        if(document.getElementById('ContentPlaceHolder1_gvattendance_gvatt_txtreason_'+column).value=="")
            {
                alert('Please enter reason for not taking the class')
                document.getElementById('ContentPlaceHolder1_gvattendance_gvatt_txtreason_'+column).focus();
                return false;
            }
    }
    if(confirm("Do you want to post attendance for these "+ res +" students"))
   {
        return true;
   }
   return false; 
}

onKeyPress="return CheckNumeric(event)"       
	        
   function clearValidation(fieldList)
    {
	
	    var field=new Array();
	    field=fieldList.split("~");
	    var counter=0;
	    for(i=0;i<field.length;i++)
	     {
		    if(document.getElementById(field[i]).value!="") 
		    {
			    document.getElementById(field[i]).style.border="#999999 1px solid";
			    document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		    }
		}
    } 
 

    </script>           
    
    <table class="common" width="100%">
    <tr><td colspan="3" style="padding:0px;"><h4>
        Attendance Details</h4></td></tr>
          <tr><td colspan="3" style="text-align:center">
          <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label>
          </td>
    </tr>
    </table>
    <table id="tblatt" runat="server" class="common" width="100%" > 
               <tr><td colspan="3"> 
                   <asp:HiddenField ID="hdntotalcount" runat="server" />
                   <asp:HiddenField ID="hdnslotday" runat="server" />
                   <asp:HiddenField ID="hdnclasscount" runat="server" />
                   <asp:HiddenField ID="hdncoductorcancel" runat="server" />
                   <table id="tblbatch" runat="server" width="100%"  cellpadding="0" cellspacing="0" class="common">
                       <tr>
                           <td colspan="3" rowspan="3" width="119">
                               &nbsp;Batch Track</td>
                           <td colspan="1" rowspan="3" style="height: 37px; width: 225px;">
                <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="3" style="height: 37px; width: 94px;">
                               &nbsp;Module Name</td>
                           <td colspan="1" rowspan="3" style="height: 37px">
                        <asp:TextBox ID="txt_modulecontent" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>                       </tr>
                       <tr>                       </tr>
                       <tr>
                           <td height="35" colspan="3" rowspan="1">
                               &nbsp;Faculty Name</td>
                           <td  height="35" colspan="1" rowspan="1" style="width: 225px">
                <asp:TextBox ID="txt_Faculty" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                           <td height="35" colspan="1" rowspan="1" style="width: 94px" >
                               &nbsp;Lab Name</td>
                           <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_Lab" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="236px" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td height="35" colspan="3" rowspan="1" >
                               &nbsp;Batch Time</td>
                           <td colspan="1" rowspan="1" style="width: 225px">
                <asp:TextBox ID="txt_BatchTime" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="width: 94px" >
                               &nbsp;Batch Slot</td>
                           <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_BatchSlot" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td colspan="3" rowspan="1">
                               &nbsp;Batch Start Date</td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 225px;">
                               <asp:TextBox ID="txt_startdate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                   TextMode="SingleLine"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 94px;">
                               &nbsp;Batch End Date</td>
                           <td colspan="1" rowspan="1" style="height: 26px">
                               <asp:TextBox ID="txt_enddate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                   TextMode="SingleLine"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td height="35" colspan="3" rowspan="1">
                               &nbsp;Batch Code</td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 225px;">
                <asp:TextBox ID="txt_BatchCode" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="223px" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 94px;">                        </td>
                           <td colspan="1" rowspan="1" style="height: 26px">
                <asp:TextBox ID="txt_Course" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="235px" ReadOnly="True" Visible="False"></asp:TextBox></td>
                       </tr>
                   </table>
               </td></tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvstudents" runat="server" AutoGenerateColumns="False" style="float:left;">
                    <Columns>
                        <asp:TemplateField HeaderText="Students In The Batch">
                            <ItemTemplate>
                                <asp:CheckBox ID="gvstu_chkstudent" runat="server"  Text='<%# Eval("studentid") %>' Value='<%# Eval("studentid") %>'/> -
                                <asp:Label ID="gvstu_lblstudent" runat="server" Text='<%# Eval("enq_personal_name") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason">
                        <ItemTemplate>
                            <asp:TextBox ID="gvstu_txtstureason" runat="server" CssClass="text"></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                <div id="divupdateprevious" runat="server" style="max-height:400px; overflow:auto; float:right;">
                <h2 style="text-align:center; font-weight:bold;"> Update Previous Students Attendance </h2>
                  <asp:GridView ID="gvclasscontent" runat="server" AutoGenerateColumns="False">
                    <Columns>
                    <asp:BoundField HeaderText="Student Name" DataField="enq_personal_name" />
                    <asp:BoundField HeaderText="Student Id" DataField="studentid" />
                    <asp:BoundField HeaderText="Class Date" DataField="clsdate" />
                    <asp:BoundField HeaderText="Software" DataField="software_name" />
                    <asp:BoundField HeaderText="Content" DataField="class_content" /> 
                        <asp:TemplateField HeaderText="Reason">
                         <ItemTemplate>
                             <asp:HiddenField ID="hdnattendanceid" runat="server" Value='<%#Eval("attendance_id") %>' />
                             <asp:TextBox ID="txtreason" runat="server" CssClass="text"></asp:TextBox>                
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div style="margin:10px 0 0 50px;">
                <asp:Button ID="btnupdate" CssClass="submit" runat="server" Text="Update" OnClick="btnupdate_Click"/>
                </div>
                </div>
            </td>
        </tr>
               <tr id="trattendancegrid" runat="server">
               <td  colspan="3" align="center"> 
                   <asp:GridView ID="gvattendance" runat="server" AutoGenerateColumns="False" OnRowCommand="gvattendance_RowCommand">
                       <Columns>
                           <asp:TemplateField HeaderText="Software">
                               <ItemTemplate>
                                   <asp:Label ID="gvatt_lblsoftware" runat="server" Text='<%# Eval("software") %>'></asp:Label>
                                   <asp:HiddenField ID="gvatt_hdnsoftware" runat="server" Value='<%# Eval("software_id") %>' />
                                   <asp:HiddenField ID="gvatt_hdnmodulename" runat="server" Value='<%# Eval("module") %>' />
                                   <asp:HiddenField ID="gvatt_hdnmodule" runat="server" Value='<%# Eval("moduleid") %>' />
                                   <asp:HiddenField ID="gvatt_classdate" runat="server" Value='<%# Eval("classdate") %>' />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Content">
                               <ItemTemplate>
                                   <asp:Label ID="gvatt_lblcontent" runat="server" Text='<%# Eval("content") %>'></asp:Label>
                                   <asp:HiddenField ID="gvatt_hdncontent" runat="server" Value='<%# Eval("subcontentid") %>' />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Batchtime">
                               <ItemTemplate>
                                   <asp:Label ID="gvatt_lblbatchtime" runat="server" Text='<%# Eval("batchtiming") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Reason">
                               <ItemTemplate>
                                   <asp:TextBox ID="gvatt_txtreason" runat="server" CssClass="text"></asp:TextBox>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Action">
                               <ItemTemplate>
                                   <asp:Button ID="gvatt_btnpost"  OnClientClick='<%# "return getindividualpost("+Container.DataItemIndex+")"  %>'  CommandName="post" CommandArgument='<%# Container.DataItemIndex  %>' runat="server" CssClass="submit" Text="Post" />
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                   </asp:GridView><br />
                   <asp:Button ID="btnpostattendance" runat="server" Text="Post Attendance" CssClass="submit"  OnClientClick="javascript:return getpost();" OnClick="btnpostattendance_Click" /></td>
               </tr>
               <tr runat="server" id="trconductcancel"  visible="false" align="center">
                   <td colspan="3">
                        <strong>About Previous class :
                               <br />
                           </strong> 
                           <asp:Button ID="btnconducted" runat="server" CssClass="submit" Text="Conducted" OnClick="btnconducted_Click"  />&nbsp;
                           <asp:Button ID="btncancelled" runat="server" CssClass="submit" Text="Postponed" OnClick="btncancelled_Click" />
                   </td>
               </tr> 
        
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="common" Width="100%"
                    EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
            </td>
        </tr>
            </table>
</asp:Content>

