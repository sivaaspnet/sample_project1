<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/Mainmasterpage.master" AutoEventWireup="true" CodeFile="leaverequest.aspx.cs" Inherits="superadmin_leaverequest" Title="Leave Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

function batchcode()
{
   if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.backgroundColor="#e8ebd9";
             alert("Please select batch code");
             return false;
         }  
}

   function leave() 
     {
     //clearValidation('ContentPlaceHolder1_txtparentname~ContentPlaceHolder1_txtparentrelation~ContentPlaceHolder1_txtparent_cmp~ContentPlaceHolder1_ddl_employementstatus~ContentPlaceHolder1_txtparent_designation~ContentPlaceHolder1_txtparent_placeofwork~ContentPlaceHolder1_txtparent_typeofindustry~ContentPlaceHolder1_txtparent_monthlyincome~ContentPlaceHolder1_txtselfemployed~ContentPlaceHolder1_ddl_support~ContentPlaceHolder1_txtrequirements~ContentPlaceHolder1_txtquestions~ContentPlaceHolder1_ddl_finstatus~ContentPlaceHolder1_txtmininvestment~ContentPlaceHolder1_txtmaxinvestment~ContentPlaceHolder1_txt_dmakername~ContentPlaceHolder1_txt_dmakerrelationship~ContentPlaceHolder1_txt_dmakercontactdetails~ContentPlaceHolder1_txt_counseledtime~ContentPlaceHolder1_txt_courseasked~ContentPlaceHolder1_txt_coursepositioned~ContentPlaceHolder1_txt_enrolldate');
     
        //Enrolled date check
        var start = document.getElementById("ContentPlaceHolder1_txtfromdate").value;
        var start_s = start.split("-");
        var stDate = parseInt(start_s[2]+start_s[1]+start_s[0]);
        
        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var dday =  (curr_date < 10 ? '0' : '') + curr_date
        var toDate = parseInt(curr_year +''+ mon +''+ dday);
        //var csDate = stDate - toDate;
        var csDate = parseInt(stDate - toDate);
        
        
        
        
        
           var start1 = document.getElementById("ContentPlaceHolder1_txttodate").value;
        var start_s1 = start1.split("-");
        var stDate1 = parseInt(start_s1[2]+start_s1[1]+start_s1[0]);
        
        var d1 = new Date();
        var curr_date1 = d1.getDate();
        var curr_month1 = d1.getMonth();
        curr_month1++;
        var curr_year1 = d1.getFullYear();
        var mon1 =  (curr_month1 < 10 ? '0' : '') + curr_month1
        var dday1 =  (curr_date1 < 10 ? '0' : '') + curr_date1
        var toDate1 = parseInt(curr_year1 +''+ mon1 +''+ dday1);
        //var csDate = stDate - toDate;
        var csDate1 = parseInt(stDate1 - toDate1);
        
        
         if(document.getElementById("ContentPlaceHolder1_txtfromdate").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromdate").value=="";
             alert("Select Date");
             document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_txttodate").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txttodate").value=="";
             alert("Select Date");
             document.getElementById("ContentPlaceHolder1_txttodate").focus();
             document.getElementById("ContentPlaceHolder1_txttodate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttodate").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_txtreason").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txtreason").value=="";
             alert("Enter Reason For Leave");
             document.getElementById("ContentPlaceHolder1_txtreason").focus();
             document.getElementById("ContentPlaceHolder1_txtreason").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtreason").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(csDate < 0)
          {
             document.getElementById("ContentPlaceHolder1_txtfromdate").value=="";
             alert("Invalid start date");
             document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.backgroundColor="#e8ebd9";
             return false;
          }
           else if(csDate1 < 0)
          {
             document.getElementById("ContentPlaceHolder1_txttodate").value=="";
             alert("Invalid End date");
             document.getElementById("ContentPlaceHolder1_txttodate").focus();
             document.getElementById("ContentPlaceHolder1_txttodate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttodate").style.backgroundColor="#e8ebd9";
             return false;
          }
          else
          {
          return true;
          }

}
</script>

<table class="common" width="100%"   > 
<tr><td colspan="2" style="padding:0px;"><h4>Leave Request Form</h4> </td>
                 
            </tr>
<tr><td colspan="2" align="center">
<table  class="common">
            
             <tr><td colspan="2"  style="text-align:center;">  
                 <asp:Label ID="lblerrormsg" runat="server" CssClass="error" Text=""></asp:Label></td>
            </tr>
             <tr><td> From date</td>
                 <td> 
                     <asp:TextBox ID="txtfromdate" runat="server" CssClass="text datepicker"></asp:TextBox></td>
            </tr>
             <tr><td> To date</td>
                 <td> 
                     <asp:TextBox ID="txttodate" runat="server" CssClass="text datepicker"></asp:TextBox></td>
            </tr>
    <tr>
        <td>
            Reason</td>
        <td>
            <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center;">
            <asp:Button ID="btnsubmit" runat="server" OnClientClick="javascript:return leave();" CssClass="btnStyle1" OnClick="btnsubmit_Click"
                Text="Submit" />&nbsp;
            <asp:Button ID="btncancel" runat="server" CssClass="btnStyle2" OnClick="btncancel_Click"
                Text="Cancel" /></td>
    </tr>
    </table>
    </td></tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvleave" runat="server" AutoGenerateColumns="False" CssClass="common" Width="100%">
                <Columns>
                    <asp:BoundField DataField="fromdate" HeaderText="From Date" />
                    <asp:BoundField DataField="todate" HeaderText="To Date" />
                    <asp:BoundField DataField="reason" HeaderText="Reason" />
                    <asp:BoundField DataField="finalstatus" HeaderText="Status" />
                  
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
        </table>


</asp:Content>

