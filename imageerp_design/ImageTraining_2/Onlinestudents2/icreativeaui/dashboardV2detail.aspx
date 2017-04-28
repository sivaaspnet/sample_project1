<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="dashboardV2detail.aspx.cs" Inherits="dashboardV2detail" Title="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'mm-dd-yy', yearRange: '1970:2020' });
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'mm-dd-yy', yearRange: '1970:2020' });
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
        
        .style1
        {
            width: 83px;
        }
        .tbl {
    border-collapse: collapse;
    width:100%;
}

.tbl td {
    border: 1px solid black;
    text-align: center;
}
.tbl th {
    border: 1px solid black;
}
    </style>
    <div class="free-forms">
        

    
    <table class="common" width="100%">
        <tbody>
            <tr>
                <td style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px;
                    height: 29px" colspan="2">
                    <h4 id="headertext" runat="server">
                        </h4>
                     
                </td>
            </tr>
            
           
            
          
            
            
    </table>
    <div class="dataGrid" style="padding:10px">
       <asp:GridView ID="Gridview_dashboard" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_dashboard_PageIndexChanging" EmptyDataText="No records Found" PageSize="15" Width="100%">
            <Columns>
               <asp:BoundField HeaderText="Student ID" DataField="student_id" />
                     <asp:BoundField HeaderText="Student Name" DataField="enq_personal_name" />
               <asp:BoundField HeaderText="Billed Value" DataField="coursefees" />
               <asp:BoundField HeaderText="Source" DataField="about" />
               <asp:BoundField HeaderText="Profile" DataField="enq_student_profile" />
               <asp:BoundField HeaderText="Enrolled By" DataField="Enrolled_By" />
               <asp:BoundField HeaderText="Enrolled Date" DataField="dateofenroll" />
               <asp:BoundField HeaderText="Course" DataField="program" />
               <asp:BoundField HeaderText="Invoice" DataField="invoiceId" />
                  <asp:BoundField HeaderText="Total Paid Amount" DataField="totpaid" />
               <asp:BoundField HeaderText="Pending Amount" DataField="pending_amount" />
            <asp:BoundField HeaderText="Status" DataField="student_enrolledStatus" />
               <asp:BoundField HeaderText="Lastpaid Date" DataField="lastpaiddate" />
       
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
        <asp:GridView ID="Gridview_dashboard1" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_dashboard1_PageIndexChanging" EmptyDataText="No records Found" PageSize="15" Width="100%">
            <Columns>
               <asp:BoundField HeaderText="Student ID" DataField="student_id" />
                     <asp:BoundField HeaderText="Student Name" DataField="student_name" />
               <asp:BoundField HeaderText="Receipt No" DataField="receipt_no" />
               <asp:BoundField HeaderText="Course" DataField="program" />
               <asp:BoundField HeaderText="Amount" DataField="amount" />
               <asp:BoundField HeaderText="Tax" DataField="tax" />
               <asp:BoundField HeaderText="Total" DataField="total" />
               <asp:BoundField HeaderText="Date" DataField="date_ins" />
               <asp:BoundField HeaderText="Receipt Cut By" DataField="receiptcutby" />
              </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
        <asp:GridView ID="Gridview_dashboard2" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_dashboard2_PageIndexChanging" EmptyDataText="No records Found" PageSize="15" Width="100%">
            <Columns>
               <asp:BoundField HeaderText="Student ID" DataField="studentid" />
                     <asp:BoundField HeaderText="Student Name" DataField="Studentname" />
               <asp:BoundField HeaderText="Invoice" DataField="invoiceno" />
               <asp:BoundField HeaderText="Course" DataField="coursename" />
               <asp:BoundField HeaderText="Course Fees" DataField="coursefees" />
               <asp:BoundField HeaderText="Paid Amount" DataField="paidamount" />
               <asp:BoundField HeaderText="Pending Amount" DataField="pendingamount" />
               <asp:BoundField HeaderText="Last Paid Date" DataField="lastpaiddate" />
               <asp:BoundField HeaderText="Remove Date" DataField="removedate" />
              </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    
   
        
     
    </div>
    <div style="text-align:left">
<input id="bt_back1" type="button" 
                onclick="javascript:history.back();" value="Back"/>    </div>
    <h4 style="text-align: center">
        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Download Excel</asp:LinkButton>
    </h4>
</asp:Content>
