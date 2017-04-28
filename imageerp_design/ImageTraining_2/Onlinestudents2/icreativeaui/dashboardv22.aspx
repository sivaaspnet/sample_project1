<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="dashboardv22.aspx.cs" Inherits="dashboardv22" Title="Dashboard" %>

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
                    height: 29px" colspan="3">
                    <h4>
                        </h4>
                     
                </td>
            </tr>
            <tr>
            <td style="width: 260px">
                    Region
   <asp:DropDownList runat="server" ID="ddlregion"></asp:DropDownList>            </td>
                <td style="width: 260px">
                    From Date
                    <asp:TextBox ID="txtfromcalender2" onkeypress="return false" onkeydown="return false"
                        onpaste="return false" runat="server" Width="92px" CssClass="text datepicker1"></asp:TextBox>
                </td>
                <td>
                    To Date
                    <asp:TextBox ID="txttocalender2" onkeypress="return false" onkeydown="return false"
                        onpaste="return false" runat="server" Width="92px" CssClass="text datepicker1"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnsort1" OnClick="btnsort1_Click" runat="server" Text="Sort" CssClass="btnStyle1"
                        OnClientClick="javascript:return sortval2();"></asp:Button>
                </td>
            </tr>
           
            
          
            
            
    </table>
    <div class="dataGrid" style="padding:10px">
       <asp:GridView ID="Gridview_dashboard" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="Gridview_dashboard_PageIndexChanging" EmptyDataText="No records Found" OnRowCommand="Gridview_dashboard_RowCommand" PageSize="15" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Centre">
                  <ItemTemplate>
                  <asp:Label runat="server" ID="lblcentrename" Text='<%#Eval("centreName")%>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Billed Value">
                    <ItemTemplate>
                        <asp:LinkButton  Font-Underline="false" ID="lnkbilled" CommandName="billedvalue" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("BilledValue")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
          <asp:TemplateField HeaderText="Diploma">
                    <ItemTemplate>
                        <asp:LinkButton  Font-Underline="false" ID="lnkdiploma" CommandName="diploma" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("DiplomaCount")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Certificate">
                    <ItemTemplate>
                        <asp:LinkButton  Font-Underline="false" ID="lnkcertificate" CommandName="certificate" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("CertificateCount")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Collection">
                    <ItemTemplate>
                        <asp:LinkButton  Font-Underline="false" ID="lnktotalColl" CommandName="totalcollection" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("TotalCollection")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fees Receivable">
                    <ItemTemplate>
                        <asp:LinkButton  Font-Underline="false" ID="lnkfeesrec" CommandName="feesreceivable" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("FeesReceivable")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dropout Amount">
                    <ItemTemplate>
                        <asp:LinkButton  Font-Underline="false" ID="lnkdropout" CommandName="dropoutamount" CommandArgument='<%#Eval("centrecode")+","+Eval("centreName")%>' runat="server"><%#Eval("DropoutAmount")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <td colspan="3" style="border: 1px solid #ccc">
            <h4 style="text-align: center">
               </h4>  <!--  <th>
                                Collection Details
                            </th>      -->                     
                            
            <div  id="wrap" runat="server"  visible="false">
                <table  class="tbl">
                    <tbody>
                        <tr >
                        <th>
                                S.No
                            </th>
                            <th>
                                Centre Name
                            </th>
                         <th>
                                Billed Value
                            </th> 
                            <th>
                               Diploma
                            </th> 
                            <th>
                               Certificate
                            </th> 
                            <th>
                                Total Collection
                            </th>
                            <th>
                                Fees Receivable
                            </th>
                            <th>
                            Dropout Amount
                            </th>
                        </tr>
                       
                        <%=getdata()%>
                    </tbody>
                </table>
                </div>
            
        </td>
   
        
     
    </div>
    <h4 style="text-align: center">
        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Download Excel</asp:LinkButton>
    </h4>
</asp:Content>
