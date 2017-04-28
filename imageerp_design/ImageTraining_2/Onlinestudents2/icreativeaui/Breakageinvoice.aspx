<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Breakageinvoice.aspx.cs" Inherits="superadmin_InvoiceMenu" Title="Invoice Menu Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
$(document).ready(function() {
    $("#ContentPlaceHolder1_txt_stuid").autocomplete('Handler2.ashx'); 
});  
</script>
  <script language="javascript" type="text/javascript">
function trim(stringToTrim)	        {
	return stringToTrim.replace(/^\s+|\s+$/g,"");
}
function Invoc() {
     if(trim(document.getElementById("ContentPlaceHolder1_txt_stuid").value)==""){    
		 alert("Please Enter Student ID");
		 document.getElementById("ContentPlaceHolder1_txt_stuid").value == "";
		 document.getElementById("ContentPlaceHolder1_txt_stuid").focus();
		 document.getElementById("ContentPlaceHolder1_txt_stuid").style.border="#ff0000 1px solid";
		 document.getElementById("ContentPlaceHolder1_txt_stuid").style.backgroundColor="#e8ebd9";
		 return false;
	 }
   
	 else {
	 	 return true;
	 }
 }


function Reset(){
	document.getElementById("ContentPlaceHolder1_txt_stuid").value="";
}

</script>
  <div class="title-cont">
    <h3 class="cont-title">Add Breakage Details</h3>
    <div class="breadcrumps">
      <ul>
       
        <li><a href="breakage.aspx">Breakage Details</a>/</li>
        <li><a href="#" class="last">Add Breakage Details</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <div class="search-sec-cont">
    <div align="center">
      <asp:Label ID="lbl_errormsg" runat="server" ForeColor="DarkRed"></asp:Label>
    </div>
    <ul>
      <li>
        <div class="wth-1">Enter Student ID</div>
        <div class="wth-2">
          <asp:TextBox ID="txt_stuid" CssClass="text input-txt" runat="server"></asp:TextBox>
        </div>
      </li>
      <li>
        <div align="center">
          <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Invoc();" OnClick="btn_submit_Click" />
        </div>
      </li>
    </ul>
    <div align="center">
      <asp:CustomValidator ID="CustomValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special2" ControlToValidate="txt_stuid"></asp:CustomValidator>
    </div>
    <div class="clear"></div>
  </div>
</asp:Content>
