<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Centerwisereport1.aspx.cs" Inherits="superadmin_Centerwisereport" Title="Centerwise Report" %>

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

   <div class="free-forms">
     <table width="100%" class="common">
        <tr>
            <td colspan="2" style=" padding:0px; height: 29px;"><h4>
                View Centrewise Report</h4>
            </td>
        </tr>
        <tr >
            <td style="width: 260px" >
                From Date
                <asp:TextBox ID="txtfromcalender2" onpaste="return false" onKeyPress="return false"  runat="server"  CssClass="text datepicker" Width="92px"></asp:TextBox>
                 
             
                </td>
            <td>
                To Date
                <asp:TextBox ID="txttocalender2" onpaste="return false" onKeyPress="return false"  runat="server"  CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort1" runat="server" Text="Sort" CssClass="btnStyle1" OnClientClick="javascript:return sortval2();" OnClick="btnsort1_Click" /></td>
        </tr>
            <tr><td colspan="2"  >
             
                        <table style="width:100%" >
                            <tr id="cencode" visible="false" runat="server">
                                <td style="height: 20px; width: 290px;">
                                    Centre Code</td>
                                <td>
                                    <asp:Label ID="lbl_cen_code" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                          <tr >
                                <td style="height: 20px; width: 290px;">
                                    Centre name</td>
                                <td>
                                    <asp:Label ID="lbl_cen_name" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total no of enquiries</td>
                                <td >
                                    <asp:Label ID="lbl_tot_enq" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td id="visenq" visible="false" runat="server">  <a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Enq=1&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" title="Click to View the Enquiry" /></a></td>
                            </tr>
                            <tr id="todenqu" runat="server" visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Today's Enquiries</td>
                                <td>
                                    <asp:Label ID="lbl_today_enq" CssClass="error" runat="server" Text=""></asp:Label></td><td></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total no of students enrolled</td>
                                <td>
                                    <asp:Label ID="lbl_no_enroll" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td id="visenr" visible="false" runat="server"> <a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Adm=1&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" title="Click to view the Enrolment Detail" /></a></td>
                            </tr>
                            <tr id="visfalse" visible="false" runat="server">
                                <td style="height: 20px; width: 290px;">
                                    Total no of batches in Progress&nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_no_batch" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td><a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Batch=1&iframe=true&amp;width=1600&amp;height=850"><img src="../layout/32.gif" alt="View" title="Click to View the batch detail" /></a></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total Fees collected&nbsp;(Cash)</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lusum" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td style="height: 25px"></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total Fees collected (Cheque)</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lucheque" runat="server" CssClass="error"></asp:Label></td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 290px; height: 20px">
                                    Total Fees collected (Cash + Cheque)</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lumpcc" runat="server" CssClass="error"></asp:Label></td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total revenue collected as Installment (Cash)</td>
                                <td>
                                    <asp:Label ID="lbl_tot_insamt" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 290px;">
                                    Total revenue collected as Installment (Cheque)</td>
                                <td>
                                    <asp:Label ID="lbl_tot_inscheque" runat="server" CssClass="error"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 290px; height: 20px">
                                    Total revenue collected as Installment (Cash + Cheque)</td>
                                <td>
                                    <asp:Label ID="lbl_tot_inscc" runat="server" CssClass="error"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr id="totfees">
                                <td style="height: 20px; width: 290px;">
                                    Grand Total
                                </td>
                                <td>
                                    <asp:Label ID="lbl_fees_today" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr>
                                <td style="width: 290px; height: 29px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton></td>
                                <td style="height: 29px">
                                </td>
                                <td style="height: 29px">
                                </td>
                            </tr>
                          
                        </table>
             
                  </td></tr>    
                 <tr id="View1" visible="false" runat="server"><td colspan="2">
                 <img src="../layout/32.gif" alt="View" /> ---- Click on to View the Information
                 </td></tr> 
        </table>
         </div>
         
         
</asp:Content>

