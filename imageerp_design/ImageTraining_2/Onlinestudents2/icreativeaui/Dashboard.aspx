<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="superadmin_Dashboard" Title="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}    

 function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) 
	{
		return true; 
	} 
	else
	 {
		return false;
	}
}
 
function sortval1()
{

var start = document.getElementById("ContentPlaceHolder1_txtfromcalender1").value;
        var end = document.getElementById("ContentPlaceHolder1_txttocalender1").value;

        var start_s = start.split("-");
        var end_s = end.split("-");
        
//        if(start_s[0]<10)
//        {
//        start_s[0]=0+start_s[0];
//        }
        
        var stDate = start_s[2]+start_s[1]+start_s[0];
//        if(end_s[0]<10)
//        {
//        end_s[0]=0+end_s[0];
//        }
        var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        
        //alert(curr_date);
        if(curr_date<10)
        {
        curr_date='0'+curr_date;
        }
        
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        
        var compDate = enDate - stDate;
        var csDate = stDate - toDate;
        //alert(stDate);
        //alert(toDate);
        //alert(csDate);
//clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


   if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(csDate > 0)
        {
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").value=="";
             alert("Please select valid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
             return false;
        }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalender1").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(compDate < 0)
        {
             document.getElementById("ContentPlaceHolder1_txttocalender1").value=="";
             alert("Please select valid To date");
             document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
             return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
             alert("Please select centre code");
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
             return false;
         }
//          else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
//         {
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
//             alert("Please select centre code");
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
//             return false;
//         }
     else
     {
     return true;
     }
}

function sortval2()
{

var start = document.getElementById("ContentPlaceHolder1_txtfromcalender2").value;
        var end = document.getElementById("ContentPlaceHolder1_txttocalender2").value;

        var start_s = start.split("-");
        var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
        var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        if(curr_date<10)
        {
        curr_date='0'+curr_date;
        }
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        
        var compDate = enDate - stDate;
        var csDate = stDate - toDate;
        //alert(csDate);
//clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


   if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(csDate > 0)
        {
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").value=="";
             alert("Please select valid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor="#e8ebd9";
             return false;
        }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalender2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalender2").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(compDate < 0)
        {
             document.getElementById("ContentPlaceHolder1_txttocalender2").value=="";
             alert("Please select valid To date");
             document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor="#e8ebd9";
             return false;
        }
        else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
             alert("Please select centre code");
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
             return false;
         }
//          else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
//         {
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
//             alert("Please select centre code");
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
//             return false;
//         }
     else
     {
     return true;
     }
}



</script>

<% if (Session["SA_Centrerole"].ToString() == "Counselor" || Session["SA_Centrerole"].ToString() == "CentreManager")
   {
       %>
  <table class="common"><tr><td  style=" padding:0px;"><h4>Course Details</h4></td></tr> 
     <tr><td>

<asp:GridView ID="Gridviewcourse" Width="500" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Results Found" PageSize="10" OnPageIndexChanging="Gridviewcourse_PageIndexChanging" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField HeaderText="Program">
                 <ItemTemplate>
                     <a rel="modal" href="view_softwareversion.aspx?cou_id=<%#Eval("course_id")%>&iframe=true&amp;width=600&amp;height=500"><%#Eval("program")%></a>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Duration">
                 <ItemTemplate>
                   <%#Eval("duration")%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Track">
                 <ItemTemplate>
                   <%#Eval("track")%>
                 </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Lump Sum">
                 <ItemTemplate>
                   <%#Eval("lump_sum")%>
                 </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Installment Amount">
                 <ItemTemplate>
                   <%#Eval("instal_amount")%>
                 </ItemTemplate>
                </asp:TemplateField>       
            </Columns>
        </asp:GridView>
        </td></tr>
        </table>
    <br />
        <%} %>   
    <% if (Session["SA_Centrerole"].ToString() == "Technical Head")
    {
    %>
  <table class="common"><tr><td  style=" padding:0px;"><h4>Course Details</h4></td></tr> 
     <tr><td>
<asp:GridView ID="GriDVTECH" Width="500" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Results Found" PageSize="10" HorizontalAlign="Center" OnPageIndexChanging="GriDVTECH_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Program">
                 <ItemTemplate>
                           <a rel="modal" href="view_softwareversion.aspx?cou_id=<%#Eval("course_id")%>&iframe=true&amp;width=600&amp;height=500"><%#Eval("program")%></a>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Duration">
                 <ItemTemplate>
                  <%#Eval("duration")%>
                 </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Track">
                 <ItemTemplate>
                  <%#Eval("track")%>
                 </ItemTemplate>
                </asp:TemplateField>
                 
            </Columns>
        </asp:GridView>
        </td></tr>
        </table>
    <br />
        <%} %>
        
         <%if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
         {
         %>
   <table width="600" class="common">
        <tr>
            <td colspan="3" style=" padding:0px"><h4>
                Dash board Consolidated Report For All Centre</h4>
            </td>
        </tr>
       <tr>
            <td style="width: 322px" >
                From Date
                <asp:TextBox ID="txtfromcalender1"   runat="server"  onpaste="return false" onKeyPress="return false"  CssClass="text datepicker" Width="92px"></asp:TextBox>
                 
             
                </td>
            <td>
                To Date
                <asp:TextBox ID="txttocalender1"  runat="server" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort" runat="server" Text="Sort" CssClass="submit" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" /></td>
        </tr>
       <tr id="todayreport" runat="server">
           <td class="w290 talignleft" colspan="2">
               <strong>Today's Conslidated Report</strong></td>
       </tr>
        <tr>
       <td class="w290 talignleft" style="width: 322px"> <img src="../layout/icon.plus.gif" alt="" />    
                Total no of enquiries in all the branches  :</td>
            <td>
                <asp:Label ID="lbltotalenquiry" CssClass="error" runat="server" Text=''></asp:Label></td>
              
        </tr>
        <tr>
       <td class="w290 talignleft" style="width: 322px"> <img src="../layout/icon.plus.gif" alt="" />    
                Total no of Enrollment in all the branches  :</td>
            <td>
                <asp:Label ID="lblTotalenrollment" CssClass="error" runat="server" Text=''></asp:Label></td>
              
        </tr>
        <tr id="todenq" visible="false" runat="server">
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Today's enquiries  :
            </td>
            <td>
                <asp:Label ID="lbltodayenq" CssClass="error" runat="server" Text=''></asp:Label></td>
               
        </tr>
          <tr id="revenueenrollment" runat="server" visible="false">
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total revenue from enrollment :
            </td>
          
                 <td>
                     <asp:Label ID="lbltotrevenue_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
          <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total Fees collected (Cash)&nbsp; :
            </td>
         
                 <td><asp:Label ID="lbltotlumpsum_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total Fees collected (Cheque)&nbsp; :
            </td>
         
                 <td><asp:Label ID="lbltotlumpsum_cheque" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total Fees collected (Cash + Cheque)&nbsp; :
            </td>
         
                 <td><asp:Label ID="lbl_totlump" CssClass="error" runat="server"></asp:Label></td>
        </tr>
          <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total revenue collected as  Installment (Cash) :
            </td>
           
                 <td><asp:Label ID="lbltotinstal_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
         <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total revenue collected as  Installment (Cheque) :
            </td>
           
                 <td><asp:Label ID="lbltotinstal_cheque" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
         <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />  Total revenue collected as  Installment (Cash + Cheque) :
            </td>
           
                 <td><asp:Label ID="lbl_totins" CssClass="error" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td class="w290 talignleft" style="width: 322px"><img src="../layout/icon.plus.gif" alt="" />
                Grand Total:&nbsp;</td>
          
                 <td><asp:Label ID="lbltotcollection_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
       <tr>
           <td class="w290 talignleft" style="width: 322px">
               <asp:LinkButton ID="lnk_down" runat="server" OnClick="lnk_down_Click">Download Excel</asp:LinkButton></td>
           <td>
           </td>
       </tr>
    </table>
    <br />
     <table width="500" class="common">
        <tr>
            <td colspan="2" style=" padding:0px; height: 29px;"><h4>
                View Centrewise Report</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
            &nbsp;Sortby Centre name&nbsp;
                <asp:DropDownList ID="ddl_cencode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_cencode_SelectedIndexChanged" ToolTip="Select the centre code">
                </asp:DropDownList></td>
        </tr>
        <tr id="visdate" runat="server" visible="false">
            <td style="width: 260px" >
                From Date
                <asp:TextBox ID="txtfromcalender2" runat="server" onpaste="return false" onKeyPress="return false"  CssClass="text datepicker" Width="92px"></asp:TextBox>
                 
             
                </td>
            <td>
                To Date
                <asp:TextBox ID="txttocalender2"  runat="server" onpaste="return false" onKeyPress="return false" CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort1" runat="server" Text="Sort" CssClass="submit" OnClientClick="javascript:return sortval2();" OnClick="btnsort1_Click" /></td>
        </tr>
            <tr><td colspan="2" style="text-align:center" align="center">
             
                        <table style="width:500px" align="center" runat="server" id="individualtable">
                            <tr id="cencode" visible="false" runat="server">
                                <td style="height: 20px; width: 290px;">
                                    Centre Code</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_cen_code" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                          <tr id="cenname" visible="false" runat="server">
                                <td style="height: 20px; width: 290px;">
                                    Centre name</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_cen_name" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total no of enquiries</td>
                                <td style="width: 126px" >
                                    <asp:Label ID="lbl_tot_enq" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td id="visenq" visible="false" runat="server">  <a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Enq=1&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" title="Click to View the Enquiry" /></a></td>
                            </tr>
                            <tr id="todenqu" runat="server" visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Today's Enquiries</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_today_enq" CssClass="error" runat="server" Text=""></asp:Label></td><td></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total no of students enrolled</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_no_enroll" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td id="visenr" visible="false" runat="server"> <a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Adm=1&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" title="Click to view the Enrolment Detail" /></a></td>
                            </tr>
                            <tr id="visfalse" visible="false" runat="server">
                                <td style="height: 20px; width: 290px;">
                                    Total no of batches in Progress&nbsp;</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_no_batch" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td><a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Batch=1&iframe=true&amp;width=1600&amp;height=850"><img src="../layout/32.gif" alt="View" title="Click to View the batch detail" /></a></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total Fees collected&nbsp;(Cash)</td>
                                <td style="height: 25px; width: 126px;">
                                    <asp:Label ID="lbl_tot_lusum" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td style="height: 25px"></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total Fees collected (Cheque)</td>
                                <td style="height: 25px; width: 126px;">
                                    <asp:Label ID="lbl_tot_lucheque" runat="server" CssClass="error"></asp:Label></td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 290px; height: 20px">
                                    Total Fees collected (Cash + Cheque)</td>
                                <td style="height: 25px; width: 126px;">
                                    <asp:Label ID="lbl_tot_lumpcc" runat="server" CssClass="error"></asp:Label></td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total revenue collected as Installment (Cash)</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_tot_insamt" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total revenue collected as Installment (Cheque)</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_tot_inscheque" runat="server" CssClass="error"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 290px; height: 20px">
                                    Total revenue collected as Installment (Cash + Cheque)</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_tot_inscc" runat="server" CssClass="error"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Grand Total</td>
                                <td style="width: 126px">
                                    <asp:Label ID="lbl_fees_today" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr>
                                <td style="width: 290px; height: 20px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton></td>
                                <td style="width: 126px">
                                </td>
                                <td>
                                </td>
                            </tr>
                          
                        </table>
             
                  </td></tr>    
                 <tr id="View1" visible="false" runat="server"><td colspan="2">
                 <img src="../layout/32.gif" alt="View" /> ---- Click on to View the Information
                 </td></tr> 
        </table>
         
         
         
         <%} %>
</asp:Content>

