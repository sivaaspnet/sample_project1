<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="viewincentivedetails.aspx.cs" Inherits="superadmin_viewincentivedetails" Title="Incentive Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txtstudentid").autocomplete('Handler2.ashx');
    
    });  
</script>
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	   {
	     return stringToTrim.replace(/^\s+|\s+$/g,"");
	   }
  function clearValidation(fieldList)
   {
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++)
	 {
		if(document.getElementById(field[i]).value!="") 
		{
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}	
}     
function sortval()
{
clearValidation('ContentPlaceHolder1_txtfromdate~ContentPlaceHolder1_txttodate');
  if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromdate").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.backgroundColor="#e8ebd9";
             return false;
         }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttodate").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttodate").value=="";   
             alert("Please select the To date");
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

function validateField()

{

if(trim(document.getElementById("ContentPlaceHolder1_txtstudentid").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtstudentid").value=="";   
             alert("Enter Student Name");
             document.getElementById("ContentPlaceHolder1_txtstudentid").focus();
             document.getElementById("ContentPlaceHolder1_txtstudentid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtstudentid").style.backgroundColor="#e8ebd9";
             return false;
         }
  
     else
     {
     return true;
     }
}
</script>

<div class="title-cont">
<h3 class="cont-title">
Incentive Details Report</h3></div>
 <div class="gridSort">
    <div class="search-sec-cont">
      <div align="center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label>
      </div>
      
      <ul>
        <li>
          <div class="wth-1">Student ID :</div>
          <div class="wth-2">
           <asp:TextBox ID="txtstudentid" runat="server" CssClass="text input-txt" MaxLength="50"></asp:TextBox>&nbsp;<asp:Button
                ID="btnSubmit" runat="server"  CssClass="search" OnClientClick="return validateField();" OnClick="btnSubmit_Click"  />
                   <br />
         <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtstudentid"></asp:CustomValidator>
           </div>
        </li>
        <li class="date-sec-cont">
          <div class="wth-1">Date From</div>
          <div class="wth-2 date-pick-cont">
            <asp:TextBox ID="txtfromdate" runat="server" CssClass="text datepicker date-input-txt" onkeypress="return false" onkeydown="return false" onpaste="return false"></asp:TextBox>
          </div>
          <div class="wth-3">To</div>
          <div class="wth-2 date-pick-cont">
           <asp:TextBox ID="txttodate" runat="server" CssClass="text datepicker date-input-txt" onkeypress="return false" onkeydown="return false" onpaste="return false"></asp:TextBox>
          </div>
        </li>
        <li>
           <asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="search-btn" OnClientClick="javascript:return sortval();" OnClick="btnsort_Click" /><br />
        </li>
      </ul>
      <div class="clear"></div>
      
    </div>
  </div>

  
  

	<div class="white-cont">
	<div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="gvIncentiveReport" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="tbl-cont3" EmptyDataText="No Records Found" 
             width="100%" OnPageIndexChanging="gvIncentiveReport_PageIndexChanging">
            <Columns>
               <asp:BoundField DataField="studentid" HeaderText="Student ID" />
               <asp:BoundField DataField="studentname" HeaderText="Student Name" />
               <asp:BoundField DataField="invoicenum" HeaderText="Invoice No" />
               <asp:BoundField DataField="receiptnum" HeaderText="Receipt No" /> 
               <asp:BoundField DataField="referedstudentname" HeaderText="Refered Student" /> 
               <asp:BoundField DataField="referedstaffname" HeaderText="Refered Staff" /> 
               <asp:TemplateField HeaderText="Action">
                 <ItemTemplate> 
                 <% if (Session["SA_Centrerole"].ToString() == "SuperAdmin")
                  { %>
                  <a  href='editincentive.aspx?icid=<%#Eval("icid")%>&stdid=<%#Eval("studentid")%>'>Edit</a> | 
                <% }  %>
                  <a rel="modal[]" href='incentivedetail.aspx?icid=<%#Eval("icid")%>&iframe=true&amp;width=100%&amp;height=100%'>Print</a>
                  </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView>
       </div></div>




</asp:Content>

