<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" ValidateRequest="false" AutoEventWireup="true" EnableEventValidation="false" CodeFile="addcentre.aspx.cs" Inherits="superadmin_addcentre" Title="Add Centre" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
 <%-- <script type="text/javascript">
$(document).ready(function(){
	$(".add-btn").click(function(event) {
		$('#add-centre-sec').slideDown();
		window.location.href="#add-centre-sec";
	});
});
</script>--%>
  <script language="javascript" type="text/javascript">
 
function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function CheckNumeric(GetEvt) {
    var Char = (GetEvt.which) ? GetEvt.which : event.keyCode

    if (Char > 31 && (Char < 48 || Char > 57))
        return false;
    return true;
}

function clearValidation(fieldList) {

    var field = new Array();
    field = fieldList.split("~");
    var counter = 0;
    for (i = 0; i < field.length; i++) {
        if (document.getElementById(field[i]).value != "") {
            document.getElementById(field[i]).style.border = "#999999 1px solid";
            document.getElementById(field[i]).style.backgroundColor = "#e8ebd9";
        }
    }

}

function Validate() {
    clearValidation('ContentPlaceHolder1_txtc_code~ContentPlaceHolder1_txtc_location~ContentPlaceHolder1_ddc_region~ContentPlaceHolder1_txt_enquirycount~ContentPlaceHolder1_txt_receiptcount~ContentPlaceHolder1_txt_invoicecount');

    //alert("test")

    if (trim(document.getElementById("ContentPlaceHolder1_txtc_code").value) == "") {
        document.getElementById("ContentPlaceHolder1_txtc_code").value == "";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Centre Code!';
        document.getElementById("ContentPlaceHolder1_txtc_code").focus();
        document.getElementById("ContentPlaceHolder1_txtc_code").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtc_code").style.backgroundColor = "#e8ebd9";

        return false;
    } else if (trim(document.getElementById("ContentPlaceHolder1_txtc_location").value) == "") {

        document.getElementById("ContentPlaceHolder1_txtc_location").value == "";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Centre Location!';
        document.getElementById("ContentPlaceHolder1_txtc_location").focus();
        document.getElementById("ContentPlaceHolder1_txtc_location").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtc_location").style.backgroundColor = "#e8ebd9";
        return false;
    } else if (document.getElementById("ContentPlaceHolder1_ddc_region").value == "") {

        document.getElementById("ContentPlaceHolder1_ddc_region").focus();
        document.getElementById("ContentPlaceHolder1_ddc_region").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_ddc_region").style.backgroundColor = "#e8ebd9";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = ' *Please Enter the Centre Region!';
        return false;
    } else if (trim(document.getElementById("ContentPlaceHolder1_txt_enquirycount").value) == "") {
        document.getElementById("ContentPlaceHolder1_txt_enquirycount").value == "";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Enquiry Count!';
        document.getElementById("ContentPlaceHolder1_txt_enquirycount").focus();
        document.getElementById("ContentPlaceHolder1_txt_enquirycount").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_enquirycount").style.backgroundColor = "#e8ebd9";
        return false;
    } else if (trim(document.getElementById("ContentPlaceHolder1_txt_receiptcount").value) == "") {
        document.getElementById("ContentPlaceHolder1_txt_receiptcount").value == "";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Receipt Count!';
        document.getElementById("ContentPlaceHolder1_txt_receiptcount").focus();
        document.getElementById("ContentPlaceHolder1_txt_receiptcount").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_receiptcount").style.backgroundColor = "#e8ebd9";
        return false;
    } else if (trim(document.getElementById("ContentPlaceHolder1_txt_invoicecount").value) == "") {
        document.getElementById("ContentPlaceHolder1_txt_invoicecount").value == "";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Invoice Count!';
        document.getElementById("ContentPlaceHolder1_txt_invoicecount").focus();
        document.getElementById("ContentPlaceHolder1_txt_invoicecount").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_invoicecount").style.backgroundColor = "#e8ebd9";
        return false;
    } else if (trim(document.getElementById("ContentPlaceHolder1_txt_incentivecount").value) == "") {
        document.getElementById("ContentPlaceHolder1_txt_incentivecount").value == "";
        document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Incentive Count!';
        document.getElementById("ContentPlaceHolder1_txt_incentivecount").focus();
        document.getElementById("ContentPlaceHolder1_txt_incentivecount").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txt_incentivecount").style.backgroundColor = "#e8ebd9";
        return false;
    } else {
        return true;
    }
}

function Validate_Email(Email) {
    var Str = Email
    var CheckExpression = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
        //var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

    if (CheckExpression.test(Str)) // test Method to check for Regular Expression
    {
        return true;
    } else {
        return false
    }
}

function SearchValidate() {
    if (document.getElementById("ContentPlaceHolder1_txtsearchlocation").value == "" && document.getElementById("ContentPlaceHolder1_txtsearchname").value == "") {

        document.getElementById("ContentPlaceHolder1_txtsearchlocation").focus();
        document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.border = "#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.backgroundColor = "#e8ebd9";
        return false;
    } else {
        return true;
    }

}
function Reset() {
    //alert("True");
    document.getElementById("ContentPlaceHolder1_txtc_code").value = "";
    document.getElementById("ContentPlaceHolder1_txtc_location").value = "";
    document.getElementById("ContentPlaceHolder1_txtc_managerid").value = "";
    document.getElementById("ContentPlaceHolder1_txt_manager_mailid").value = "";
    document.getElementById("ContentPlaceHolder1_txtc_managername").value = "";
    document.getElementById("ContentPlaceHolder1_txtcentrecat").value = "";

    document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value = "";
    document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").value = "";


    var liste = document.getElementById("ContentPlaceHolder1_ddc_region");
    var howMany = liste.options.length;

    for (var i = 0; i < howMany; i++) {
        if (liste[i].selected) {
            liste[i].selected = false;
        }
    }


}
</script>
  <div class="title-cont">
    <h3 class="cont-title">Centre Details</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Centre</a>/</li>
        <li><a href="addcentre.aspx" class="last">Centre Details</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>
  <div class="search-sec-cont">
    <ul>
      <li>
        <div class="wth-1">Centre code</div>
        <div class="wth-2">
          <asp:TextBox ID="txt_searchcode" runat="server" CssClass="text input-txt"></asp:TextBox>
        </div>
      </li>
      <li>
        <div class="wth-1">Location</div>
        <div class="wth-2">
          <asp:TextBox ID="txt_searchlocation" runat="server" CssClass="text input-txt"></asp:TextBox>
        </div>
      </li>
      <li>
        <asp:Button ID="btnsearch" runat="server" CssClass="search-btn" Text="Search"  OnClick="btnsearch_Click"/>
      </li>
    </ul>
    <div class="clear"></div>
    <div align="center">
      <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>
    </div>
  </div>
  <div class="white-cont">
    <%--<div align="right" style="padding:15px 15px 0px 15px;"><a href="#" class="add-btn">Add Centre</a></div>--%>
   <div style="padding:0px 10px 10px 10px; overflow:scroll">
      <asp:GridView ID="grdcentre" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" OnRowCommand="grdcentre_RowCommand" AllowPaging="True" OnPageIndexChanging="grdcentre_PageIndexChanging"  PageSize="10" EmptyDataText="No Records Found">
        <Columns>
        <asp:TemplateField HeaderText="Centre&nbsp;Code">
          <ItemTemplate> <%#removetilde(Eval("centre_code").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Centre&nbsp;Location">
          <ItemTemplate> <%#removetilde(Eval("centre_location").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Centre&nbsp;Region">
          <ItemTemplate> <%#removetilde(Eval("centre_region").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Enquiry_Count" HeaderText="Enquiry&nbsp;Count" />
        <asp:BoundField DataField="Rec_Total" HeaderText="Receipt&nbsp;Count" />
        <asp:BoundField DataField="InvoiceCount" HeaderText="Invoice&nbsp;Count" />
        <asp:BoundField DataField="IncentiveCount" HeaderText="Incentive&nbsp;Count" />
        <asp:BoundField DataField="center_address" HeaderText="Centre&nbsp;Address" />
        <asp:BoundField DataField="address1" HeaderText="Address1" />
        <asp:BoundField DataField="address2" HeaderText="Address2" />
        <asp:BoundField DataField="insititueName" HeaderText="Institue&nbsp;Name" />
        <asp:BoundField DataField="For_institute" HeaderText="For&nbsp;Institute" />
        <asp:TemplateField HeaderText="Action">
          <ItemTemplate> &nbsp;
            <asp:LinkButton ID="lnkedit" CommandName="lnkedit" CommandArgument='<%#Eval("centre_id")%>' runat="server"><img src="layout/edit.png" alt="edit"/></asp:LinkButton>
          </ItemTemplate>
          <FooterTemplate> &nbsp; </FooterTemplate>
        </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        <EmptyDataRowStyle ForeColor="Red" />
      </asp:GridView>
    </div>
  </div>
  <div id="add-centre-sec" class="add-centre-sec" >
    <div class="white-cont">
      <h4 class="cont-title2"> Add Centre Details</h4>
      <div class="form-cont">
        <ul>
          <li>
            <div style="padding:0px; text-align:left"></div>
            <div align="center">
              <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label>
            </div>
          </li>
          <li>
            <label class="label-txt">Centre Code</label>
            <asp:TextBox ID="txtc_code" runat="server" CssClass="text input-txt" MaxLength="8"></asp:TextBox>
            eg:ICH-101 </li>
          <li>
            <label class="label-txt">Centre Location</label>
            <asp:TextBox ID="txtc_location" runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Centre Region</label>
            <asp:DropDownList ID="ddc_region" runat="server" CssClass="text sele-txt">
              <asp:ListItem Value="">--Select--</asp:ListItem>
              <asp:ListItem Value="Tamilnadu">Tamilnadu</asp:ListItem>
              <asp:ListItem Value="Andrapradesh">Andra pradesh</asp:ListItem>
              <asp:ListItem Value="karnataka">Karnataka</asp:ListItem>
              <asp:ListItem Value="kerala">Kerala</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt">Enquiry Count</label>
            <asp:TextBox ID="txt_enquirycount" runat="server" onKeyPress="return CheckNumeric(event)" MaxLength="10" CssClass="text input-txt"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Receipt Count</label>
            <asp:TextBox ID="txt_receiptcount" runat="server" onKeyPress="return CheckNumeric(event)" MaxLength="10" CssClass="text input-txt"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Invoice Count</label>
            <asp:TextBox ID="txt_invoicecount" runat="server" onKeyPress="return CheckNumeric(event)" MaxLength="10" CssClass="text input-txt"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Incentive Count</label>
            <asp:TextBox ID="txt_incentivecount" runat="server" CssClass="text input-txt" MaxLength="10" onkeypress="return CheckNumeric(event)"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Centre Address</label>
            <asp:TextBox ID="txtcentreaddress" runat="server" TextMode="MultiLine" CssClass="area-txt"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Address1</label>
            <span class="file">
            <asp:TextBox ID="txtadd1" runat="server" TextMode="MultiLine" CssClass="area-txt"></asp:TextBox>
            </span> </li>
          <li>
            <label class="label-txt"><span class="file">Address2</span></label>
            <span class="file">
            <asp:TextBox ID="txtadd2" runat="server" TextMode="MultiLine" CssClass="area-txt"></asp:TextBox>
            </span> </li>
          <li>
            <label class="label-txt">Insititue Name</label>
            <span class="file">
            <asp:TextBox ID="txtinstitute" runat="server" CssClass="text input-txt"></asp:TextBox>
            </span> </li>
          <li>
            <label class="label-txt">For Institute</label>
            <span class="file">
            <asp:TextBox ID="txtforins" runat="server" CssClass="text input-txt"></asp:TextBox>
            </span> </li>
          <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">
              <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Validate();" OnClick="btnsubmit_Click"/>
              <asp:Button ID="BtnReset" runat="server" CssClass="reset-btn" OnClick="BtnReset_Click" Text="Reset" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  </div>
  <asp:HiddenField ID="hdnID" runat="server" />
</asp:Content>
