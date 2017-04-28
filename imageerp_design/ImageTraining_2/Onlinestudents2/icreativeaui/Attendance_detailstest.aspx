<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Attendance_detailstest.aspx.cs" Inherits="Onlinestudents2_Attendance_detailstest" Title="Attendance Detailstest" %>
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
    function moduleval()
    {
    clearValidation('ctl00_ContentPlaceHolder1_txt_Software~ctl00_ContentPlaceHolder1_txt_Content')
    
      if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_Software").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Software").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter software name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Software").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Software").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Software").style.backgroundColor="#e8ebd9";
             return false;
         } 
     
      else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_Content").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Content").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the class content!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Content").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Content").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Content").style.backgroundColor="#e8ebd9";
             return false;
         } 
   else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").value)=="")
             {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the reason for cancellation!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").style.backgroundColor="#e8ebd9";
             return false;
             }

             else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").value)=="")
             {
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the reason for not post attendance in previous class!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").style.backgroundColor="#e8ebd9";
             return false;
             }
             else
             {
             return true;
             }
        
    } 


function cancel()
    {
    if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").value)=="")
             {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the reason for canceled the previous class!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").style.backgroundColor="#e8ebd9";
             return false;
             }
             else
             {
             return true;
             }
    }
    
    
    function conduct()
    {
    if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").value)=="")
             {
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the reason for not post attendance in previous class!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtreasonnotpost").style.backgroundColor="#e8ebd9";
             return false;
             }
             else
             {
             return true;
             }
    }

function getpost(columnNo)
{
    var totalcnt=document.getElementById('ContentPlaceHolder1_hdntotalcount').value;
    var res=0;
    for(var i=0;i<totalcnt;i++)
    {
       var values='ContentPlaceHolder1_gvstudents_chkstudent_'+i;
       if(eval("document.getElementById('ContentPlaceHolder1_gvstudents_chkstudent_"+i+"').checked"))
       {
            res=res+1; 
       } 
          
    }
   if(document.getElementById('ContentPlaceHolder1_gvreasonnotpost_txtreason_'+columnNo).value=="")
   {
    alert('please enter the reason.');
    document.getElementById('ContentPlaceHolder1_gvreasonnotpost_txtreason_'+columnNo).focus();
    return false;
   }
   else if(confirm("Do you want to post attendance for these "+ res +" students"))
   {
        return true;
   }
   return false;
   
}

function postpondattend()
{
    var totalcnt=document.getElementById('ContentPlaceHolder1_hdntotalcount').value;
    var res=0;
    for(var i=0;i<totalcnt;i++)
    {
       var values='ContentPlaceHolder1_gvstudents_chkstudent_'+i;
       if(eval("document.getElementById('ContentPlaceHolder1_gvstudents_chkstudent_"+i+"').checked"))
       {
            res=res+1; 
       } 
          
    }
   if(document.getElementById('ContentPlaceHolder1_txt_Reason').value=="")
   {
    alert('please enter the reason.');
    document.getElementById('ContentPlaceHolder1_txt_Reason').focus();
    return false;
   }
   else if(confirm("Do you want to post attendance for these "+ res +" students"))
   {
        return true;
   }
   return false;
   
}

function normalpost()
{
    var totalcnt=document.getElementById('ContentPlaceHolder1_hdntotalcount').value;
    var res=0;
    for(var i=0;i<totalcnt;i++)
    {
       var values='ContentPlaceHolder1_gvstudents_chkstudent_'+i;
       if(eval("document.getElementById('ContentPlaceHolder1_gvstudents_chkstudent_"+i+"').checked"))
       {
            res=res+1; 
       } 
          
    }
   if(confirm("Do you want to post attendance for these "+ res +" students"))
   {
        return true;
   }
   return false;
   
}
    </script>           
    
    <table class="common" width="100%">
    <tr><td colspan="3" style="padding:0px;"><h4>
        Attendance Details</h4></td></tr>
          <tr><td colspan="3" style="text-align:center">
          <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label><asp:HiddenField ID="hdntotalcount" runat="server" />
          </td>
    </tr>
    </table>
    <table id="tblatt" visible="false" runat="server" class="common" width="100%" >
     
  
               <tr><td colspan="2"> 
                   <table id="tblbatch" runat="server" width="100%"  cellpadding="0" cellspacing="0" class="common" visible="false" >
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
                       
                       <tr>
                           <td height="35" colspan="3" rowspan="1">
                               Software Name</td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 225px;">
                <asp:TextBox ID="txt_Software" runat="server" CssClass="text" MaxLength="100" ReadOnly="True"
                    TextMode="SingleLine" Width="331px"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 94px;">                        </td>
                         <td colspan="1" rowspan="1" style="height: 26px">&nbsp;</td>
                       </tr>
                       <tr>
                         <td height="35" colspan="3">Content</td>
                         <td colspan="1" style="height: 26px; width: 225px;"><asp:TextBox ID="txt_Content" runat="server" CssClass="text" MaxLength="100" ReadOnly="True"
                    TextMode="SingleLine" Width="331px"></asp:TextBox></td>
                         <td colspan="1" style="height: 26px; width: 94px;"></td>
                         <td colspan="1" style="height: 26px">&nbsp;</td>
                       </tr>
                   </table>
               </td></tr>
               <tr>
               <td align="center" colspan="2">
                <asp:GridView ID="gvstudents" AutoGenerateColumns="false" runat="server" CssClass="common">
                        <Columns>
                        <asp:TemplateField HeaderText="Student"><ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkstudent" Text='<%# Eval("studentid") %>' Value='<%# Eval("studentid") %>'>
                            </asp:CheckBox> - 
                            <asp:Label runat="server" Text='<%# Eval("enq_personal_name") %>' ID="lblstudent"></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
               </td>
               </tr>
               <tr>
               <td colspan="2">
               <table id="visclassdaily" runat="server" visible="false" class="common" width="100%" >
               <tr>
            <td width="119">&nbsp;</td>
          <td>
                </td>
        </tr>
                   <tr runat="server" visible="false" id="btnconcan" align="center">
                       <td colspan="2" style="height: 35px">
                           <strong>About Previous class :
                               <br />
                               <br />
                           </strong>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                           <asp:Button ID="btnconducted" runat="server" CssClass="submit" Text="Conducted" OnClick="btnconducted_Click" />&nbsp;
                           <asp:Button ID="btncancelled" runat="server" CssClass="submit" Text="Postponed" OnClick="btncancelled_Click" />
                           <asp:HiddenField ID="hiddendtattendanceid" runat="server" />
                           <asp:HiddenField ID="HiddenField1" runat="server" />
                           <asp:HiddenField ID="HiddenField2" runat="server" />
                           <asp:HiddenField ID="HiddenField3" runat="server" />
                           <asp:Label ID="lblqry" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="lblconductedqry" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="lblcancelqry" runat="server" Visible="False"></asp:Label></td>
                   </tr>
                   <tr runat="server" visible="false" id="reasonconducted">
                       <td style="height: 35px">
                           Reason for not post</td>
                       <td style="height: 35px">
                           <asp:GridView ID="gvreasonnotpost" AutoGenerateColumns="false" runat="server"  CssClass="common" Width="100%"  EmptyDataText="No Records Found" OnRowCommand="gvreasonnotpost_RowCommand" >
                           <Columns>
                           <asp:TemplateField HeaderText="Software">
                           <ItemTemplate>
                               <asp:HiddenField ID="hdnsoftwareid" runat="server" Value='<%# Eval("software_id") %>' />
                               <asp:Label ID="lblsoftware" runat="server" Text='<%# Eval("software") %>'></asp:Label>
                           </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Content">
                           <ItemTemplate>
                           <asp:HiddenField ID="hdncontentid" runat="server" Value='<%# Eval("subcontentid") %>' />
                               <asp:Label ID="lblcontent" runat="server" Text='<%# Eval("content") %>'></asp:Label>
                           </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason">
                           <ItemTemplate>
                               <asp:TextBox ID="txtreason" runat="server" CssClass="text"></asp:TextBox>
                           </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Action">
                           <ItemTemplate>
                               <asp:Button ID="btnpost" OnClientClick='<%# "return getpost("+Container.DataItemIndex+")"  %>' CommandArgument='<%# Container.DataItemIndex  %>' CommandName="Post" CssClass="submit"  runat="server" Text="Post" />
                           </ItemTemplate>
                           </asp:TemplateField>
                           </Columns>
                           </asp:GridView>
                           </td>
                   </tr>
        <tr id="reasonvis" runat="server" visible="false">
            <td style="height: 35px" >
                Reasns for cancellation</td>
            <td style="height: 35px">
                <asp:TextBox ID="txt_Reason" runat="server" CssClass="text" MaxLength="200" ReadOnly="false" Width="330px" Height="18px"></asp:TextBox>&nbsp;
                <asp:Button ID="btncan" runat="server" CssClass="submit"  OnClientClick="javascript:return postpondattend();" OnClick="btncan_Click" Text="Add" /></td>
        </tr>
                <tr>
                    <td colspan="2" runat="server" style="text-align:center;" id="tdaddbutton">
                       
                        <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return normalpost();" />&nbsp;
                        &nbsp; &nbsp;                    
                        
                        </td>
                </tr>
               </table>
               </td>
               </tr> 
               <tr>
               <td colspan="2">
               <br />
               </td>
               </tr>
        
        <tr>
            <td colspan="2">
            
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="common" Width="100%"
                    EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging"
                    PageSize="15">
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Label ID="lbl_Centrecode" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_batchslot" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_BatchTime" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_BatchTrack" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Lab" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Faculty" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Batchcode" runat="server" Visible="false"></asp:Label>
                <asp:HiddenField ID="hdnReason" runat="server" />
                <asp:HiddenField ID="hiddenmoduleid" runat="server" />
                <asp:HiddenField ID="hiddencontentid" runat="server" />
            </td>
        </tr>
            </table>
</asp:Content>

