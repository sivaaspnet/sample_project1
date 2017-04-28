<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="unpaidstudents.aspx.cs" Inherits="unpaidstudents" Title="Un Paid Students Report" EnableEventValidation="false" %>
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

function validatebreak()
{
    if(document.getElementById("ctl00_ContentPlaceHolder1_txtreason").value=="")
    {
        alert("Please enter reason");
        document.getElementById("ctl00_ContentPlaceHolder1_txtreason").focus();
        return false;
    }
    else
    {
        return true;
    }
}

function getreason(value,typeval)
{
    document.getElementById("ctl00_ContentPlaceHolder1_reason").style.display='block';
    document.getElementById("ctl00_ContentPlaceHolder1_btnfinal").value=value + " Students";
    document.getElementById("ctl00_ContentPlaceHolder1_lblreason").innerHTML=value;
    document.getElementById("ctl00_ContentPlaceHolder1_hdnreason").value=value;
    document.getElementById("ctl00_ContentPlaceHolder1_hdntype").value=typeval;
    return false;
}

</script>
   <div class="title-cont">
    <h3 class="cont-title">Unpaid Students List</h3>    
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
            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btnStyle1" 
                onclick="btnsearch_Click" />
                
                    
              </li></ul>
    
        	
		<div class="clear"></div>
	 
	<div align="center">
	 <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtkeywords"></asp:CustomValidator></div>
    <div align="center">
	 
	  <asp:Label ID="lblcount" runat="server" CssClass="error"></asp:Label>   
	  </div>
     <div style="padding:0px 10px 10px 10px">
       <asp:GridView ID="Gridview_admission" runat="server" AllowPaging="True" 
            CssClass="tbl-cont3" OnPageIndexChanging="Gridview_admission_PageIndexChanging" 
            PageSize="20" EmptyDataText="No records Found" Width="100%" 
            AutoGenerateColumns="False" onrowcommand="Gridview_admission_RowCommand" >
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
               <asp:BoundField DataField="doj" HeaderText="DOJ" />
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
               <asp:TemplateField HeaderText="Action">
               <ItemTemplate>
                   <asp:LinkButton ID="lnkaction" CommandArgument='<%#Eval("invoiceno")+"~"+Eval("studentid") %>' CommandName="Break" runat="server">Remove</asp:LinkButton>/
                   <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("invoiceno")+"~"+Eval("studentid") %>' CommandName="drop" runat="server">Drop</asp:LinkButton>/
                   <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("invoiceno")+"~"+Eval("studentid") %>' CommandName="bre" runat="server">Break</asp:LinkButton>
               </ItemTemplate>
               </asp:TemplateField>
           </Columns>
 
   <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView> 
                <div align="center" style="padding:10px 10px 0px 10px;">
                <asp:LinkButton ID="LnkDownlaodExcel" runat="server" CssClass="download-btn" OnClick="LnkDownlaodExcel_Click">Download Excel</asp:LinkButton>
                 <asp:Button ID="btnsubmit" runat="server" Text="Send Un Paid List" CssClass="btnStyle3" onclick="btnsubmit_Click" />
                    <asp:Button ID="btnbreak" runat="server" Text="Send Break List" 
                        CssClass="btnStyle3" OnClientClick="return getreason('Break','Multi');"/>
                    <asp:Button ID="btndrop" runat="server" Text="Send Drop List" 
                        CssClass="btnStyle3" OnClientClick="return getreason('Drop','Multi');"/>
                   </div>
           <div style="display:none;">
            <asp:GridView ID="gv_download" runat="server"  
            CssClass="common"  
             EmptyDataText="No records Found" Width="100%" 
            AutoGenerateColumns="False"  >
             <Columns>             
               <asp:BoundField DataField="studentid" HeaderText="Studentid" />
               <asp:BoundField DataField="studentname" HeaderText="Name" />
               <asp:BoundField DataField="doj" HeaderText="DOJ" />
               <asp:TemplateField HeaderText="Invoice">
               <ItemTemplate>
                  <label> <%#Eval("invoiceno") %></label>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="coursename" HeaderText="Course" /> 
               <asp:TemplateField HeaderText="Course Fees">
               <ItemTemplate>
                <label><%# Convert.ToDouble(Eval("coursefees"))%></label>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Paid Amount">
               <ItemTemplate>
               <label> <%# Convert.ToDouble(Eval("paidamount"))%></label>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Pending">
               <ItemTemplate>
                <label><%# Convert.ToDouble(Eval("pendingamount"))%></label>
               </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="dateindb" HeaderText="Last Paid Date(MM/dd/YYYY)" />              
           </Columns>
   
        </asp:GridView> 
           </div>   </div>   
   </div>
   <div class="white-cont">
    <div id="reason" runat="server" style="display:none;">
   <div class="form-cont">
            <ul class="no-borders">
            <li></li>
        <li>
                <label class="label-txt"> Reason for 
            <asp:Label ID="lblreason" runat="server" Text=""></asp:Label> 
            <asp:HiddenField ID="hdnreason" runat="server" />
            <asp:HiddenField ID="hdntype" runat="server" />
       </label>
            <asp:TextBox ID="txtreason" runat="server" CssClass="text input-txt"></asp:TextBox> </li>
        <li style="text-align:center;">
                <div align="center" style="padding-bottom:25px;">
        <asp:Button ID="btnfinal" runat="server" CssClass="btnStyle3" OnClientClick="return validatebreak();" 
                onclick="btnfinal_Click" />
                 </div></li></ul>
       <div class="clear"></div>
        </div>
    </div>
    </div>
</asp:Content>

