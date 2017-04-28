<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="viewbreakstudents.aspx.cs" Inherits="viewbreakstudents" Title="Students Report-Break" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
  function CheckAll(chk)
{
  var isChecked = chk.checked;
  var thisItem = chk.id;
  var items = chk.parentNode.parentNode.parentNode.getElementsByTagName("input");
  for (i=0; i<items.length; i++)
  {
    if (items[i].id != thisItem && items[i].type=="checkbox")
    {
        if (isChecked)
        {
            items[i].checked = true;
        }
        else
        {
            items[i].checked = false;
        }
    }
  }
}

</script>

<div class="title-cont">
    <h3 class="cont-title">Students List-Break </h3>    
    <div class="clear"></div>
  </div>
  
        <div class="search-sec-cont">
       
       <ul>
        <li>
          <div class="wth-1">Keywords</div>
           <div class="wth-2">
        <asp:TextBox ID="txtkeywords" runat="server" style="width:80%;" CssClass="text input-txt"></asp:TextBox><br /> 
         (Name / StudentID)</div></li>
       <li class="date-sec-cont">
          <div class="wth-1">Date From </div>
          <div class="wth-2 date-pick-cont">
        <asp:TextBox ID="txtfromdate" CssClass="text datepicker date-input-txt" runat="server"  onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
         </div>         
          <div class="wth-3"> To </div>
            <div class="wth-2 date-pick-cont">
        <asp:TextBox ID="txttodate" CssClass="text datepicker date-input-txt" runat="server"  onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
      </div></li>
      
      <li>
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btnStyle1" 
                onclick="btnsearch_Click" />                   
              </li></ul>       	
		<div class="clear"></div>
   <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtkeywords"></asp:CustomValidator>
    <div align="center">
	 
	<asp:Label ID="lblcount" runat="server" CssClass="error"></asp:Label>
	  </div>

  
   
	
     <div style="padding:0px 10px 10px 10px">
       <asp:GridView ID="Gridview_admission" runat="server" AllowPaging="True" 
            CssClass="tbl-cont3" OnPageIndexChanging="Gridview_admission_PageIndexChanging" 
            PageSize="20" EmptyDataText="No records Found" Width="100%" 
            AutoGenerateColumns="False" onrowcommand="Gridview_admission_RowCommand" 
            onrowdatabound="Gridview_admission_RowDataBound" >
           <Columns>
              <asp:TemplateField>
              <HeaderTemplate>
              <asp:CheckBox ID="chkparent" runat="server"   onclick="javascript:CheckAll(this);" Text="All"  />               
              </HeaderTemplate>
               <ItemTemplate>
                   <asp:CheckBox ID="chkstudent" CssClass="chkchild" runat="server"/> 
                   <asp:HiddenField ID="hdnstudentid" runat="server" Value='<%#Eval("studentid") %>' /><asp:HiddenField ID="hdninvoiceid" runat="server" Value='<%#Eval("invoiceno") %>' />
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="studentid" HeaderText="Studentid" />
               <asp:BoundField DataField="studentname" HeaderText="Name" />
               <asp:TemplateField HeaderText="Invoice">
               <ItemTemplate>
                   <a target="_blank" href="InvoiceDetails.aspx?invno=<%#Eval("invoiceno") %>"><%#Eval("invoiceno") %></a>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="coursename" HeaderText="Course" /> 
               <asp:TemplateField HeaderText="Course Fees">
               <ItemTemplate>
               <%# Convert.ToDouble(Eval("coursefees"))%>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Paid Amount">
               <ItemTemplate>
               <%# Convert.ToDouble(Eval("paidamount"))%>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Pending">
               <ItemTemplate>
               <%# Convert.ToDouble(Eval("pendingamount"))%>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="lastpaiddate" HeaderText="Last Paid Date" />
               <asp:BoundField DataField="removedate" HeaderText="Remove Date" />
               <asp:TemplateField HeaderText="Action">
               <ItemTemplate>
                   <asp:LinkButton ID="lnkaction" CommandArgument='<%#Eval("invoiceno")+"~"+Eval("studentid") %>' CommandName="resume" runat="server">Resume</asp:LinkButton>
               </ItemTemplate>
               </asp:TemplateField>
           </Columns>
   <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView> 
            <div align="center" style="padding:10px 10px 0px 10px;">
            <asp:LinkButton ID="LnkDownlaodExcel" runat="server" OnClick="LnkDownlaodExcel_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
             
                    <asp:Button ID="btnsubmit" runat="server" Text="Resume Students" 
                        CssClass="btnStyle3" Visible="false" onclick="btnsubmit_Click" /></div>
         <div style="display:none;">
           <asp:GridView ID="gv_downloadadmission" runat="server"  
            CssClass="common"  
              EmptyDataText="No records Found" Width="100%" 
            AutoGenerateColumns="False"  >
           <Columns>             
               <asp:BoundField DataField="studentid" HeaderText="Studentid" />
               <asp:BoundField DataField="studentname" HeaderText="Name" />
               <asp:TemplateField HeaderText="Invoice">
               <ItemTemplate>
                   <label><%#Eval("invoiceno") %></label>
               </ItemTemplate>
               </asp:TemplateField>
                 <asp:BoundField DataField="coursename" HeaderText="Course" /> 
               <asp:TemplateField HeaderText="Course Fees">
               <ItemTemplate>
               <%# Convert.ToDouble(Eval("coursefees"))%>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Paid Amount">
               <ItemTemplate>
               <%# Convert.ToDouble(Eval("paidamount"))%>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Pending">
               <ItemTemplate>
               <%# Convert.ToDouble(Eval("pendingamount"))%>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="lastpaiddate" HeaderText="Last Paid Date" />
               <asp:BoundField DataField="removedate" HeaderText="Remove Date" />              
           </Columns>
   
        </asp:GridView> 
         </div>         
   </div>
    </div>
</asp:Content>

