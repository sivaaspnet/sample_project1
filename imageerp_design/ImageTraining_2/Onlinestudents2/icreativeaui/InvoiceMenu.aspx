<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="InvoiceMenu.aspx.cs" Inherits="superadmin_InvoiceMenu" Title="Invoice Menu Page" %>

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
function Invoc()
 {
      if(trim(document.getElementById("ContentPlaceHolder1_txt_stuid").value)=="")
         {    
             alert("Please Enter Student ID");
             document.getElementById("ContentPlaceHolder1_txt_stuid").value == "";
             document.getElementById("ContentPlaceHolder1_txt_stuid").focus();
             document.getElementById("ContentPlaceHolder1_txt_stuid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stuid").style.backgroundColor="#e8ebd9";
             return false;
         }
       
         else
         {
         return true;
         }
 }


function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txt_stuid").value="";


}
</script>
  <div class="title-cont">
    <h3 class="cont-title">Invoice Details</h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="InvoiceMenu.aspx" class="last">Invoice Details</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
  <div class="search-sec-cont">
    <div align="center">
      <asp:Label ID="lbl_errormsg" runat="server" CssClass="error"></asp:Label>
    </div>
    <ul>
      <li>
        <div class="wth-1">Enter Student ID/ Invoice ID</div>
        <div class="wth-2">
          <asp:TextBox ID="txt_stuid" CssClass="text input-txt" runat="server" ></asp:TextBox>
        </div>
      </li>
      <li>
        <div align="center">
          <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Invoc();" OnClick="btn_submit_Click" />
        </div>
      </li>
    </ul>
    <div class="clear"></div>
    <div align="center">
      <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special" ControlToValidate="txt_stuid"></asp:CustomValidator>
    </div>
     <div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="GridView1" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="studentid" HeaderText="StudentID" />
                            <asp:BoundField DataField="program" HeaderText="Course Name" />
                            <asp:TemplateField HeaderText="Invoice No">
                                <ItemTemplate>
                                    <a  href="InvoiceDetails.aspx?invno=<%#Eval("invoiceid")%>"> <%#Eval("invoiceid")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
    </div>
  </div>
 
</asp:Content>
