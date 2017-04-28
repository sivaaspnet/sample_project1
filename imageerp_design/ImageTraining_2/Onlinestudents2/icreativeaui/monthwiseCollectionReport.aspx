<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="monthwiseCollectionReport.aspx.cs" Inherits="monthwiseCollectionReport" Title="Collection Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    

    

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
      <div class="title-cont">
    <h3 class="cont-title">
                
                      Monthwise Collection Report </h3>
          <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Reports</a>/</li>
        <li><a href="monthwiseCollectionReport.aspx" class="last"> Monthwise Collection Report</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
    

<div class="search-sec-cont">
<ul>
<li><div class="wth-1"> Select Year</div>
    <div class="wth-2"><span class="date-pick-cont"><asp:DropDownList runat="server" CssClass="sele-txt" ID="ddlyear"></asp:DropDownList>   </span></div>
</li>
           
<li>
    <asp:Button ID="btnsort1" OnClick="btnsort1_Click" runat="server" Text="Search" CssClass="search-btn"></asp:Button>   
</li>
</ul>
<div class="clear"></div>
</div>
 
                   
   
       <div class="white-cont">  
    
      
    <div style="padding:0px 10px 10px 10px;overflow:scroll" id="wrap" runat="server">
       <asp:GridView ID="Gridview_dashboard" runat="server" CssClass="tbl-cont3" AllowPaging="True"  OnPageIndexChanging="Gridview_dashboard_PageIndexChanging" EmptyDataText="No records Found" OnRowCommand="Gridview_dashboard_RowCommand" PageSize="20" Width="100%">
            
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
            
       <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView>
    
   
     <asp:GridView ID="GridviewExcel" runat="server" CssClass="common"  Width="100%">
            
           
        </asp:GridView>
   <div align="center" style="padding:10px 10px 0px 10px;">  
   <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="download-btn">Download Excel</asp:LinkButton>
   </div>
        
     
    </div>
           </div>
        
  
</asp:Content>
