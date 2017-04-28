<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Centerwisereport.aspx.cs" Inherits="superadmin_Centerwisereport" Title="Centerwise Report" %>

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

 <script type="text/javascript">
        $(document).ready(function() {
        
	jQuery(".datepicker1").datepicker({showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
	jQuery(".datepicker1").datepicker({showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
            }

        });
    </script>   

<style type="text/css">
        .overlay
        {
          position: fixed;
          z-index: 98;
          top: 0px;
          left: 0px;
          right: 0px;
          bottom: 0px;
            background-color: #fff;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .overlayContent
        {
          z-index: 99;
          margin: 250px auto;
          width: 80px;
          height:80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        
    </style>
   <div class="free-forms">
       <asp:ScriptManager id="ScriptManager1" runat="server">
       </asp:ScriptManager>
       <asp:UpdatePanel id="UpdatePanel1" runat="server">
           <contenttemplate>
<asp:UpdateProgress id="UpdateProgress1" runat="server"><ProgressTemplate>
   <div class="overlay" />
            <div class="overlayContent">
	<img src="../layout/ajax.gif"  alt="Trace" /> 
	</div>
	</div>
</ProgressTemplate>
</asp:UpdateProgress> <TABLE class="common" width="100%"><TBODY><TR><TD style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; HEIGHT: 29px" colSpan=2><H4>View Centrewise Report</H4></TD></TR><TR><TD style="WIDTH: 260px">From Date <asp:TextBox id="txtfromcalender2" onkeypress="return AllowAlphabet(event)" onpaste="return false" runat="server" Width="92px" CssClass="text datepicker1"></asp:TextBox> </TD><TD>To Date <asp:TextBox id="txttocalender2" onkeypress="return AllowAlphabet(event)" onpaste="return false" runat="server" Width="92px" CssClass="text datepicker1"></asp:TextBox>&nbsp; <asp:Button id="btnsort1" onclick="btnsort1_Click" runat="server" Text="Sort" CssClass="btnStyle1" OnClientClick="javascript:return sortval2();"></asp:Button> </TD></TR><TR><TD colSpan=2><TABLE style="WIDTH: 100%"><%--  <tr id="cencode" visible="false" runat="server">
                               <td style="height: 20px; width: 290px;">
                                    Centre Code</td>
                                <td>
                                    <asp:Label ID="lbl_cen_code" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                          <tr visible="false" >
                                <td style="height: 20px; width: 290px;">
                                    Centre name</td>
                                <td>
                                    <asp:Label ID="lbl_cen_name" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            
                            <tr visible="false">
                                <td style="height: 20px; width: 290px;">
                                   Total no of Walkin enquiries</td>
                                <td >
                                   </td>
                                    <td id="visenq" visible="false" runat="server"> </td>
                            </tr>
                            <tr visible="false">
                            <td style="height: 20px; width: 290px;">
                                   Total no of Tele enquiries</td>
                                    <td>
                                      
                                    </td>
                            </tr >
                                 <tr visible="false">
                            <td style="height: 20px; width: 290px;">
                                    Total no of enquiries</td>
                                    <td>
                                    
                                    </td>
                            </tr>
                            <tr id="todenqu" runat="server" visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Today's Enquiries</td>
                                <td>
                                    <asp:Label ID="lbl_today_enq" CssClass="error" runat="server" Text=""></asp:Label></td><td></td>
                            </tr>
                            <tr visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Total no of students enrolled</td>
                                <td>
                                    <asp:Label ID="lbl_no_enroll" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td id="visenr" visible="false" runat="server"></td>
                            </tr>
                            <tr id="visfalse" visible="false" runat="server">
                                <td style="height: 20px; width: 290px;">
                                    Total no of batches in Progress&nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_no_batch" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Total Fees collected&nbsp;(Cash)</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lusum" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td style="height: 25px"></td>
                            </tr>
                            <tr visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Total Fees collected (Cheque)</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lucheque" runat="server" CssClass="error"></asp:Label></td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr visible="false">
                                <td style="width: 290px; height: 20px">
                                    Total Fees collected (Cash + Cheque)</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lumpcc" runat="server" CssClass="error"></asp:Label></td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Total revenue collected as Installment (Cash)</td>
                                <td>
                                    <asp:Label ID="lbl_tot_insamt" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Total revenue collected as Installment (Cheque)</td>
                                <td>
                                    <asp:Label ID="lbl_tot_inscheque" runat="server" CssClass="error"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr visible="false">
                                <td style="width: 290px; height: 20px">
                                    Total revenue collected as Installment (Cash + Cheque)</td>
                                <td>
                                    <asp:Label ID="lbl_tot_inscc" runat="server" CssClass="error"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr id="totfees" visible="false">
                                <td style="height: 20px; width: 290px;">
                                    Grand Total
                                </td>
                                <td >
                                    <asp:Label ID="lbl_fees_today" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr> --%><TBODY><TR><TD colSpan=3><H3 style="TEXT-ALIGN: center">Enquiry Details</H3><DIV style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px; TEXT-ALIGN: center" class="dataGrid"><TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse" id="tt1" class="common" cellSpacing=0 rules=all border=1 runat="server"><TBODY><TR><TD style="HEIGHT: 30px">Total no of Enquires </TD><TD style="HEIGHT: 30px"><asp:Label id="total_enquires" runat="server" Text=""></asp:Label> </TD></TR><TR><TD>Total no of Walkin enquiries </TD><TD><asp:Label id="lbl_tot_enq" runat="server" Text=""></asp:Label> </TD></TR><TR><TD>Total no of Tele enquiries </TD><TD><asp:Label id="lbl_tot_tele_enq" runat="server" Text=""></asp:Label> </TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD colSpan=3><H3 style="TEXT-ALIGN: center">Enrollment Details</H3><DIV style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px; TEXT-ALIGN: center" class="dataGrid"><asp:GridView id="gvtype1" runat="server" CssClass="common" EmptyDataText="No Record" width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Course Name" DataField="course">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total no.of students" DataField="studentsjoined" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
               
              </Columns>
         </asp:GridView> </DIV></TD></TR><TR><TD colSpan=3><H3 style="TEXT-ALIGN: center">Source Details</H3><DIV style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px; TEXT-ALIGN: center" class="dataGrid"><asp:GridView id="GridView1" runat="server" CssClass="common" EmptyDataText="No Record" width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Source Name" DataField="enq_aboutimage">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total no.of students" DataField="scount" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
               
            </Columns>
        </asp:GridView> </DIV></TD></TR><TR><TD colSpan=3><H3 style="TEXT-ALIGN: center">Profile Details</H3><DIV style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px; TEXT-ALIGN: center" class="dataGrid"><asp:GridView id="GridView2" runat="server" CssClass="common" EmptyDataText="No Record" width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Profile Name" DataField="enq_student_profile">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total no.of students" DataField="scount" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
               
            </Columns>
        </asp:GridView> </DIV></TD></TR><TR><TD colSpan=3><H3 style="TEXT-ALIGN: center">Fees Details (Without Taxs)</H3><DIV style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px; TEXT-ALIGN: center" class="dataGrid"><TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse" class="common" cellSpacing=0 rules=all border=1><TBODY><TR><TH>Collection Details </TH><TH>Total Number of students </TH><TH>Cash Amount </TH><TH>Cheque amount </TH><TH>Total amount </TH></TR><TR><TD align=center><asp:Label id="Label1" runat="server" Text="Fresh collection(New)"></asp:Label> </TD><TD align=center><asp:Label id="Freshstudent" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Freshcash" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Freshcheque" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Totalfresh" runat="server"></asp:Label> </TD></TR><TR><TD align=center><asp:Label id="Label2" runat="server" Text="Regular Collection(OLD)"></asp:Label> </TD><TD align=center><asp:Label id="Regularstudent" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Regularcash" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Regularcheque" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Totalregular" runat="server"></asp:Label> </TD></TR><TR><TD align=center><asp:Label id="Label3" runat="server" Text="Others(Late,Break etc)"></asp:Label> </TD><TD align=center><asp:Label id="Breakagestudent" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Breakcash" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="Breakcheque" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="TotalBreakage" runat="server"></asp:Label> </TD></TR></TBODY></TABLE></DIV></TD></TR><%-- <tr>
                                <td style="width: 290px; height: 29px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton></td>
                                <td style="height: 29px">
                                </td>
                                <td style="height: 29px">
                                </td>
                            </tr>--%></TBODY></TABLE></TD></TR><TR id="View1" runat="server" visible="false"><TD colSpan=2><IMG alt="View" src="../layout/32.gif" /> ---- Click on to View the Information </TD></TR></TBODY></TABLE>
</contenttemplate>
       </asp:UpdatePanel>
     
         </div>
         
         
</asp:Content>

