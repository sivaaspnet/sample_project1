<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewAlteredInvoice.aspx.cs" Inherits="superadmin_ViewAlteredInvoice" Title="View Altered Invoice" EnableEventValidation = "false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txt_stuid").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
    
</script>
<script language="javascript" type="text/javascript">
  $(document).ready(function() {

    $("#ContentPlaceHolder1_txt_stuid").autocomplete('Handler3.ashx');
   // alert("check");  
    }); 
</script>
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

</script>

	 <div class="title-cont">
    <h3 class="cont-title">View Altered Invoice </h3>    
    <div class="clear"></div>
  </div>
 <div class="search-sec-cont">
       
       <ul>
        <li>
          <div class="wth-1">Enter Student ID</div>
           <div class="wth-2">
        <asp:TextBox ID="txt_stuid" runat="server"  CssClass="text input-txt"></asp:TextBox>
         </div></li>
       <li class="date-sec-cont">
          <div class="wth-1">Date From </div>
          <div class="wth-2 date-pick-cont">
        <asp:TextBox ID="txtfromcalender" CssClass="text datepicker date-input-txt" runat="server"  onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
         </div>         
          <div class="wth-3"> To </div>
            <div class="wth-2 date-pick-cont">
        <asp:TextBox ID="txttocalender" CssClass="text datepicker date-input-txt" runat="server"  onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
      </div></li>
      
      <li>
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btnStyle1" 
                onclick="btn_search_Click" />                   
              </li></ul>       	
		<div class="clear"></div>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_stuid"></asp:CustomValidator>
   

  
   
	
  <div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="GridView1" runat="server" CssClass="tbl-cont3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                    <ItemTemplate> 
                      <%#Eval("studentId")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Center Code">
                    <ItemTemplate> 
                      <%#Eval("centerCode")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Invoice No">
                <ItemTemplate>
                       <%#Eval("invoiceid")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Receipt No">
                <ItemTemplate>
                    <%#Eval("receiptno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Track">
                <ItemTemplate>
                    <%#Eval("track")%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Course Name">
                <ItemTemplate>
                    <%#Eval("course")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Course Fees">
                <ItemTemplate>
                    <%#Eval("coursefees")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tax Percentage">
                <ItemTemplate>
                    <%#Eval("taxpercentage")%> 
                </ItemTemplate>
                </asp:TemplateField>   
                         <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <%#Eval("remarks")%> 
                </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Entered By">
                <ItemTemplate>
                    <%#Eval("enteredby")%> 
                </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Invoice Date">
                <ItemTemplate>
                     <%#Eval("dateIns")%>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView>
      
       
       <div align="center" style="padding:10px 10px 0px 10px;">
       
       <asp:LinkButton ID="LnkDownlaodExcel" runat="server" CssClass="download-btn" OnClick="LinkButton4_Click">Download Excel</asp:LinkButton>              
            </div>
        
       <div style="display:none;">
            <asp:GridView ID="GridView2" runat="server" CssClass="common"  AutoGenerateColumns="False"  EmptyDataText="No Records Found" width="100%"    >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                    <ItemTemplate> 
                      <%#Eval("studentId")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Center Code">
                    <ItemTemplate> 
                      <%#Eval("centerCode")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Invoice No">
                <ItemTemplate>
                       <%#Eval("invoiceid")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Receipt No">
                <ItemTemplate>
                    <%#Eval("receiptno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Track">
                <ItemTemplate>
                    <%#Eval("track")%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Course Name">
                <ItemTemplate>
                    <%#Eval("course")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Course Fees">
                <ItemTemplate>
                    <%#Eval("coursefees")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tax Percentage">
                <ItemTemplate>
                    <%#Eval("taxpercentage")%> 
                </ItemTemplate>
                </asp:TemplateField>   
                         <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <%#Eval("remarks")%> 
                </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Entered By">
                <ItemTemplate>
                    <%#Eval("enteredby")%> 
                </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Invoice Date">
                <ItemTemplate>
                     <%#Eval("dateIns")%>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView></div>
         
    
    <div style="padding:0px 10px;" id="note" runat="server">
        &nbsp;</div>
		 </div></div>
	</asp:Content>

