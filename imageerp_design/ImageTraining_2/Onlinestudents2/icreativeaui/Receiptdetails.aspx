<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Receiptdetails.aspx.cs" Inherits="superadmin_Receiptdetails" Title="Receipt Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#<%=txt_stuid.ClientID%>").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
  <script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
 function Receipt()
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
         else if((document.getElementById("ContentPlaceHolder1_ddl_instalnum").value==""))
         {
              alert("Please select installment number");
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").value == "";
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").focus();
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
 }
 function display()
 {
     document.getElementById("instal").style.display="none"
     document.getElementById("ContentPlaceHolder1_ddl_instalnum").style.display="none"
 }
function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txt_stuid").value="";
location.href="Receiptdetails.aspx";
}
</script>
  <div class="title-cont">
    <h3 class="cont-title">Receipt Details</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="Receiptdetails.aspx" class="last">Receipt Details</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>
  <div class="free-forms">
    <div class="search-sec-cont">
      <div align="center">
        <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label>
      </div>
      <ul>
        <li>
          <div class="wth-1">Enter Student ID</div>
          <div class="wth-2">
            <asp:TextBox ID="txt_stuid" CssClass="text input-txt" runat="server"></asp:TextBox>
          </div>
        </li>
      </ul>
      <div class="clear"></div>
      <div align="center">
        <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special" ControlToValidate="txt_stuid"></asp:CustomValidator>
      </div>
      <ul>
        <li id="studName" visible="false" runat="server">
          <div class="wth-1">Student Name</div>
          <div class="wth-2">
            <asp:Label ID="lblstudname" runat="server" Font-Bold="True" CssClass="label-txt2"></asp:Label>
          </div>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="white-cont">
      <div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="GridView2" Width="100%" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging">
          <Columns>
          <asp:TemplateField HeaderText="Instalment No">
            <ItemTemplate><%#Eval("installNo")%></ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="View Receipts">
            <ItemTemplate> <a rel="modal[]" href='Receiptprint.aspx?studid=<%#Eval("studentId")%>&recptno=<%#Eval("receipt")%>&invoiceno=<%#Eval("invoiceid") %>&iframe=true&amp;width=100%&amp;height=100%'><%#Eval("receipt")%></a> </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Invoice No">
            <ItemTemplate><%#Eval("invoiceid")%></ItemTemplate>
          </asp:TemplateField>
          </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView1" CssClass="tbl-cont3" Width="100%" runat="server" AutoGenerateColumns="False">
          <Columns>
          <asp:TemplateField HeaderText="Instalment No">
            <ItemTemplate><%#Eval("installNo")%></ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="View Receipts">
            <ItemTemplate> <a rel="modal[]" href='Receiptprint.aspx?studid=<%#Eval("studentId")%>&recptno=<%#Eval("receipt")%>&invoiceno=<%#Eval("invoiceno") %>&iframe=true&amp;width=100%&amp;height=100%'><%#Eval("receipt")%></a> </ItemTemplate>
          </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
      <div class="form-cont" style="padding:15px 0px 0px 0px;">
        <ul>
          <li id="instalno" visible="false" runat="server" class="no-borders">
            <label class="label-txt">Number of pending instalments :</label>
            <asp:Label ID="lbl_Instalmentno" runat="server" CssClass="label-txt2"></asp:Label>
          </li>
          <li id="Amounttot" visible="false" runat="server">
            <label class="label-txt">Total Pending Amount :</label>
            <span>
            <asp:Label ID="lblAmount" runat="server" CssClass="label-txt2"></asp:Label>
            <asp:HiddenField ID="hdnpending" runat="server" />
            </span> </li>
          <li id="visfalsefees" runat="server" visible="false">
            <asp:Label ID="lblfeespaid" Font-Size="Large" runat="server" Visible="False" CssClass="label-txt2"></asp:Label>
          </li>
          <li id="instal" visible="false" runat="server">
            <asp:Label ID="lblmsg" runat="server" Text="Select Installment Number"  CssClass="label-txt"></asp:Label>
            <asp:DropDownList ID="ddl_instalnum" runat="server" CssClass="sele-txt">
              <asp:ListItem Value="">--Select--</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <div align="center">
              <asp:Button ID="btn_submit" runat="server" Text="Add/View Receipt" CssClass="btnStyle1" OnClientClick="javascript:return Receipt();" OnClick="btn_submit_Click" />
              <asp:Button ID="Button1" runat="server" CssClass="btnStyle1" OnClick="Button1_Click" Text="Add Installment" Visible="False" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
</asp:Content>
