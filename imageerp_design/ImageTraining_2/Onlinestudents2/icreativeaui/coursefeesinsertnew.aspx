<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="coursefeesinsertnew.aspx.cs" Inherits="coursefeesinsertnew" Title="Course Fees Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
	        
	        function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}
function validate()
{
    if($('.checkBoxClass').find('input[type=checkbox]:checked').length == 0)
    {
        alert("Please select atleast one centre");
        return false;
    }
    else if(trim(document.getElementById("ContentPlaceHolder1_ddl_course").value)=="")
    {
        document.getElementById("ContentPlaceHolder1_ddl_course").value=="";
        alert('*Please select course!');
        document.getElementById("ContentPlaceHolder1_ddl_course").focus();
        return false;
    } 
    else if($('.chkfast').find('input[type=checkbox]:checked').length == 0 && $('.chknormal').find('input[type=checkbox]:checked').length == 0)
    {
        alert("Please select any track");
        return false;
    }
    else if($('.chkfast').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_ddlfastduration").val()=="")
    {
        alert("Please select duration");
        $("#ContentPlaceHolder1_ddlfastduration").focus();
        return false;
    } 
    else if($('.chkfast').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtfastmaxinstall").val()=="")
    {
        alert("Please enter maximum number of installment");
        $("#ContentPlaceHolder1_txtfastmaxinstall").focus();
        return false;
    } 
    else if($('.chkfast').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtfastlumpsum").val()=="")
    {
        alert("Please enter the lump sum value");
        $("#ContentPlaceHolder1_txtfastlumpsum").focus();
        return false;
    } 
    else if($('.chkfast').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtfastinstallamt").val()=="")
    {
        alert("Please enter the instllment amount value");
        $("#ContentPlaceHolder1_txtfastinstallamt").focus();
        return false;
    } 
    else if($('.chkfast').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtfasttax").val()=="")
    {
        alert("Please enter the tax percentage");
        $("#ContentPlaceHolder1_txtfasttax").focus();
        return false;
    } 
    else if($('.chkfast').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_ddlfaststatus").val()=="")
    {
        alert("Please select status");
        $("#ContentPlaceHolder1_ddlfaststatus").focus();
        return false;
    }   
    else if($('.chknormal').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_ddlnormalduration").val()=="")
    {
        alert("Please select duration");
        $("#ContentPlaceHolder1_ddlnormalduration").focus();
        return false;
    } 
    else if($('.chknormal').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtnormalmaxinstall").val()=="")
    {
        alert("Please enter maximum number of installment");
        $("#ContentPlaceHolder1_txtnormalmaxinstall").focus();
        return false;
    } 
    else if($('.chknormal').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtnormallump").val()=="")
    {
        alert("Please enter the lump sum value");
        $("#ContentPlaceHolder1_txtnormallump").focus();
        return false;
    } 
    else if($('.chknormal').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtnormalinstallamt").val()=="")
    {
        alert("Please enter the instllment amount value");
        $("#ContentPlaceHolder1_txtnormalinstallamt").focus();
        return false;
    } 
    else if($('.chknormal').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_txtnormaltax").val()=="")
    {
        alert("Please enter the tax percentage");
        $("#ContentPlaceHolder1_txtnormaltax").focus();
        return false;
    } 
    else if($('.chknormal').find('input[type=checkbox]:checked').length > 0 && $("#ContentPlaceHolder1_ddlnormalstatus").val()=="")
    {
        alert("Please select status");
        $("#ContentPlaceHolder1_ddlnormalstatus").focus();
        return false;
    }
    else if (trim(document.getElementById("ContentPlaceHolder1_txtinitial_amount").value) == "") {
    document.getElementById("ContentPlaceHolder1_txtinitial_amount").value == "";
        alert('*Please Enter Initial Amount');
        document.getElementById("ContentPlaceHolder1_txtinitial_amount").focus();
        return false;
    } 
    else
    {
        return true;
    }
}

</script>
  <script type="text/javascript">
$(document).ready(function(){
if($('#ContentPlaceHolder1_chkfast').attr('checked')) {
    $(".fastdiv").slideDown(500);
} else {
   $(".fastdiv").slideUp(500);
} 
if($('#ContentPlaceHolder1_chknormal').attr('checked')) {
   $(".normaldiv").slideDown(500);
} else {
    $(".normaldiv").slideUp(500);
} 

$('#ContentPlaceHolder1_chkfast').click(function(){
if($('#ContentPlaceHolder1_chkfast').attr('checked')) {
   $(".fastdiv").slideDown(500);
} else {
    $(".fastdiv").slideUp(500);
} 
});
$('#ContentPlaceHolder1_chknormal').click(function(){
 if($('#ContentPlaceHolder1_chknormal').attr('checked')) {
    $(".normaldiv").slideDown(500);
} else {
    $(".normaldiv").slideUp(500);
} 

});

$('#ContentPlaceHolder1_chksameas').click(function(){
 if($('#ContentPlaceHolder1_chksameas').attr('checked')) { 
 $('#ContentPlaceHolder1_chknormal').attr('checked','true')
    $(".normaldiv").slideDown(500);
    $("#ContentPlaceHolder1_ddlnormalduration").val($("#ContentPlaceHolder1_ddlfastduration").val());
    $("#ContentPlaceHolder1_txtnormalmaxinstall").val($("#ContentPlaceHolder1_txtfastmaxinstall").val());
    $("#ContentPlaceHolder1_txtnormallump").val($("#ContentPlaceHolder1_txtfastlumpsum").val());
    $("#ContentPlaceHolder1_txtnormalinstallamt").val($("#ContentPlaceHolder1_txtfastinstallamt").val());
    $("#ContentPlaceHolder1_txtnormaltax").val($("#ContentPlaceHolder1_txtfasttax").val());
    $("#ContentPlaceHolder1_ddlnormalstatus").val($("#ContentPlaceHolder1_ddlfaststatus").val());
} else {
$('#ContentPlaceHolder1_chknormal').remove('checked')
    $(".normaldiv").slideUp(500);
    $("#ContentPlaceHolder1_ddlnormalduration").val("");
    $("#ContentPlaceHolder1_txtnormalmaxinstall").val("");
    $("#ContentPlaceHolder1_txtnormallump").val("");
    $("#ContentPlaceHolder1_txtnormalinstallamt").val("");
    $("#ContentPlaceHolder1_txtnormaltax").val("");
    $("#ContentPlaceHolder1_ddlnormalstatus").val("");
} 

});

 

 $("#ContentPlaceHolder1_rdbcheckall").click(function () {
        if ($("#ContentPlaceHolder1_rdbcheckall").is(':checked')) {
            $(".checkBoxClass input[type=checkbox]").each(function () {
                $(this).attr("checked", true);
            });

        } 
    });
 $("#ContentPlaceHolder1_rdbuncheck").click(function () {
        if ($("#ContentPlaceHolder1_rdbuncheck").is(':checked')) {
            $(".checkBoxClass input[type=checkbox]").each(function () {
                $(this).attr("checked", false);
            });
        }  
    });

});
</script>
<div class="title-cont">
    <h3 class="cont-title">Insert Course Fees</h3>
    
    <div class="clear"></div>
  </div>
    <div class="white-cont">
 
    
     <div class="form-cont">
            <ul>
              <li>
              <div align="center">
      <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>
      <asp:HiddenField ID="Hidn_centerloginid" runat="server" />
    </div>
    </li>
    <li>
                <label class="label-txt"> Centre</label>
       <asp:RadioButton ID="rdbcheckall" GroupName="ca" runat="server" Text="Check All" />
          &nbsp;
          <asp:RadioButton ID="rdbuncheck" GroupName="ca" runat="server" Text="UnCheck All"  />
          <asp:CheckBoxList ID="chk_centre" CssClass="checkBoxClass" RepeatDirection="Horizontal" RepeatColumns="4" runat="server"> </asp:CheckBoxList></li>
      <li>
                <label class="label-txt">Course</label>
       <asp:DropDownList ID="ddl_course" runat="server" CssClass="sele-txt"> </asp:DropDownList></li>
     
      <li>
                <label class="label-txt">Track</label>
                <div style="width:55%; float:left;">
                
                <asp:CheckBox ID="chkfast" Text="Fast" runat="server" CssClass="chkfast"/>
          <div class="fastdiv" style="display:block;">
          <ul>
            <li>
                <label class="label-txt" style="text-align:left; width:32%;">Duration</label>
                <asp:DropDownList ID="ddlfastduration" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1 Week">1 Week</asp:ListItem>
                    <asp:ListItem Value="2 Weeks">2 Weeks</asp:ListItem>
                    <asp:ListItem Value="3 Weeks">3 Weeks</asp:ListItem>
                    <asp:ListItem Value="1 Month">1 Month</asp:ListItem>
                    <asp:ListItem Value="2 Months">2 Months</asp:ListItem>
                    <asp:ListItem Value="3 Months">3 Months</asp:ListItem>
                    <asp:ListItem Value="4 Months">4 Months</asp:ListItem>
                    <asp:ListItem Value="5 Months">5 Months</asp:ListItem>
                    <asp:ListItem Value="6 Months">6 Months</asp:ListItem>
                    <asp:ListItem Value="7 Months">7 Months</asp:ListItem>
                    <asp:ListItem Value="8 Months">8 Months</asp:ListItem>
                    <asp:ListItem Value="9 Months">9 Months</asp:ListItem>
                    <asp:ListItem Value="10 Months">10 Months</asp:ListItem>
                    <asp:ListItem Value="11 Months">11 Months</asp:ListItem>
                    <asp:ListItem Value="12 Months">12 Months</asp:ListItem>
                    <asp:ListItem Value="13 Months">13 Months</asp:ListItem>
                    <asp:ListItem Value="14 Months">14 Months</asp:ListItem>
                    <asp:ListItem Value="15 Months">15 Months</asp:ListItem>
                    <asp:ListItem Value="16 Months">16 Months</asp:ListItem>
                    <asp:ListItem Value="17 Months">17 Months</asp:ListItem>
                    <asp:ListItem Value="18 Months">18 Months</asp:ListItem>
                    <asp:ListItem Value="19 Months">19 Months</asp:ListItem>
                    <asp:ListItem Value="20 Months">20 Months</asp:ListItem>
                    <asp:ListItem Value="21 Months">21 Months</asp:ListItem>
                    <asp:ListItem Value="22 Months">22 Months</asp:ListItem>
                    <asp:ListItem Value="23 Months">23 Months</asp:ListItem>
                    <asp:ListItem Value="24 Months">24 Months</asp:ListItem>
                    <asp:ListItem Value="25 Months">25 Months</asp:ListItem>
                    <asp:ListItem Value="26 Months">26 Months</asp:ListItem>
                    <asp:ListItem Value="27 Months">27 Months</asp:ListItem>
                    <asp:ListItem Value="28 Months">28 Months</asp:ListItem>
                    <asp:ListItem Value="29 Months">29 Months</asp:ListItem>
                    <asp:ListItem Value="30 Months">30 Months</asp:ListItem>
                  </asp:DropDownList>
                </li>
                <li>
                <label class="label-txt" style="text-align:left; width:32%;">Maximum no.of Installments</label>
                <asp:TextBox ID="txtfastmaxinstall" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
               </li>
              <li>
                <label class="label-txt" style="text-align:left; width:32%;">Lump Sum </label>
                <asp:TextBox ID="txtfastlumpsum" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
                </li>
              <li>
                <label class="label-txt" style="text-align:left; width:32%;">Installment amount </label>
                <asp:TextBox ID="txtfastinstallamt" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt" style="text-align:left; width:32%;">Tax</label>
               <asp:TextBox ID="txtfasttax" runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
                </li>
              <li>
                <label class="label-txt" style="text-align:left; width:32%;">Status</label>
               <asp:DropDownList ID="ddlfaststatus" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="1">Enable</asp:ListItem>
                    <asp:ListItem Value="0">Disable</asp:ListItem>
                  </asp:DropDownList>
                  <asp:CheckBox ID="chksameas" runat="server" Text="Same As For Normal" />
                </li>
             </ul>
          </div>
                
                
                
                <asp:CheckBox ID="chknormal" Text="Normal" runat="server" CssClass="chknormal"/>
          <div class="normaldiv" style="display:block;">
            <ul> <li>
                <label class="label-txt" style="text-align:left; width:32%;"> Duration</label>
                <asp:DropDownList ID="ddlnormalduration" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1 Week">1 Week</asp:ListItem>
                    <asp:ListItem Value="2 Weeks">2 Weeks</asp:ListItem>
                    <asp:ListItem Value="3 Weeks">3 Weeks</asp:ListItem>
                    <asp:ListItem Value="1 Month">1 Month</asp:ListItem>
                    <asp:ListItem Value="2 Months">2 Months</asp:ListItem>
                    <asp:ListItem Value="3 Months">3 Months</asp:ListItem>
                    <asp:ListItem Value="4 Months">4 Months</asp:ListItem>
                    <asp:ListItem Value="5 Months">5 Months</asp:ListItem>
                    <asp:ListItem Value="6 Months">6 Months</asp:ListItem>
                    <asp:ListItem Value="7 Months">7 Months</asp:ListItem>
                    <asp:ListItem Value="8 Months">8 Months</asp:ListItem>
                    <asp:ListItem Value="9 Months">9 Months</asp:ListItem>
                    <asp:ListItem Value="10 Months">10 Months</asp:ListItem>
                    <asp:ListItem Value="11 Months">11 Months</asp:ListItem>
                    <asp:ListItem Value="12 Months">12 Months</asp:ListItem>
                    <asp:ListItem Value="13 Months">13 Months</asp:ListItem>
                    <asp:ListItem Value="14 Months">14 Months</asp:ListItem>
                    <asp:ListItem Value="15 Months">15 Months</asp:ListItem>
                    <asp:ListItem Value="16 Months">16 Months</asp:ListItem>
                    <asp:ListItem Value="17 Months">17 Months</asp:ListItem>
                    <asp:ListItem Value="18 Months">18 Months</asp:ListItem>
                    <asp:ListItem Value="19 Months">19 Months</asp:ListItem>
                    <asp:ListItem Value="20 Months">20 Months</asp:ListItem>
                    <asp:ListItem Value="21 Months">21 Months</asp:ListItem>
                    <asp:ListItem Value="22 Months">22 Months</asp:ListItem>
                    <asp:ListItem Value="23 Months">23 Months</asp:ListItem>
                    <asp:ListItem Value="24 Months">24 Months</asp:ListItem>
                    <asp:ListItem Value="25 Months">25 Months</asp:ListItem>
                    <asp:ListItem Value="26 Months">26 Months</asp:ListItem>
                    <asp:ListItem Value="27 Months">27 Months</asp:ListItem>
                    <asp:ListItem Value="28 Months">28 Months</asp:ListItem>
                    <asp:ListItem Value="29 Months">29 Months</asp:ListItem>
                    <asp:ListItem Value="30 Months">30 Months</asp:ListItem>
                  </asp:DropDownList></li>
              <li>
                <label class="label-txt" style="text-align:left; width:32%;">Maximum no.of Installments</label>
                <asp:TextBox ID="txtnormalmaxinstall" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt"  runat="server"  MaxLength="25"></asp:TextBox>
                </li>
               <li>
                <label class="label-txt" style="text-align:left; width:32%;">Lump Sum</label>
               <asp:TextBox ID="txtnormallump" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
               </li>
              <li>
                <label class="label-txt" style="text-align:left; width:32%;">Installment amount</label>
                <asp:TextBox ID="txtnormalinstallamt" onKeyPress="return CheckNumeric(event)"  runat="server"  CssClass="text input-txt" MaxLength="25"></asp:TextBox>
                </li>
               <li>
                <label class="label-txt" style="text-align:left; width:32%;">Tax</label>
                <asp:TextBox ID="txtnormaltax" runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox>
                </li>
             <li>
                <label class="label-txt" style="text-align:left; width:32%;">Status</label>
                <asp:DropDownList ID="ddlnormalstatus" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="1">Enable</asp:ListItem>
                    <asp:ListItem Value="0">Disable</asp:ListItem>
                  </asp:DropDownList></li>
              </ul>
          </div>
          
          </div></li>
      <li>
                <label class="label-txt">Initial Amount</label>
                <asp:TextBox ID="txtinitial_amount" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt"  runat="server"  MaxLength="25"></asp:TextBox></li>
        
          <li style="text-align:center;">
                <div align="center" style="padding-bottom:25px;"><asp:Button ID="Btnsubmit" runat="server" CssClass="btnStyle1" OnClientClick="javascript:return validate();" Text="Submit" OnClick="Btnsubmit_Click" />
          <asp:Button ID="BtnReset" runat="server" class="btnStyle2"  Text="Reset" onclick="BtnReset_Click" />
        </div></li></ul>
        <div class="clear"></div></div></div>
     
     <div class="title-cont">
    <h3 class="cont-title">Search Course</h3>
    <div class="search-sec-cont">
      <ul>
        <li><div class="wth-1">Searchby centre</div>
          <div class="wth-2"><asp:DropDownList ID="ddl_centre_search" runat="server" CssClass="sele-txt"> </asp:DropDownList></div>
        </li>
        <li><div class="wth-1"> Searchby Region</div>
        <div class="wth-2">  <asp:DropDownList ID="ddl_region" runat="server" CssClass="sele-txt"> </asp:DropDownList></div>
        </li>
        <li><div class="wth-1">Searchby Course</div>
        <div class="wth-2">  <asp:DropDownList ID="ddl_course_search" runat="server" CssClass="sele-txt"> </asp:DropDownList></div>
        </li>
        <li><div class="wth-1">Keyword Search</div>
        <div class="wth-2">  <asp:TextBox ID="txt_keyword" runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox></div>
        </li>
        <li>
          <asp:Button ID="Button1" runat="server" CssClass="search-btn" Text="Search" OnClick="Button1_Click" OnClientClick="javascript:return SearchValidate();" />
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    
  </div>
   
    <div class="white-cont">
     <div style="padding:0px 10px 10px 10px">
      <asp:GridView ID="gvcourse" AllowPaging="true" PageSize="20" runat="server" CssClass="tbl-cont3" EmptyDataText="No Records Found" AutoGenerateColumns="false" Width="100%" onpageindexchanging="gvcourse_PageIndexChanging" onrowcommand="gvcourse_RowCommand">
        <Columns>
        <asp:BoundField DataField="program" HeaderText="Program">
          <itemstyle CssClass="no-bdr-rt"></itemstyle>
        </asp:boundfield>
        <asp:TemplateField HeaderText="Details" ItemStyle-Width="70%">
          <ItemTemplate> <%#Eval("coursedetails")%></ItemTemplate>
          <itemstyle CssClass="no-padd no-bdr"></itemstyle>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
          <ItemTemplate>
            <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("courseid")%>' CommandName="edt"><img src="layout/edit.png" alt="edit" /></asp:LinkButton>
            <asp:LinkButton ID="lnkdel" runat="server" CommandArgument='<%#Eval("courseid")%>' CommandName="del" OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
          </ItemTemplate>   
          <itemstyle CssClass="no-bdr-lt"></itemstyle>       
        </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
    </div>
    <div style="margin-bottom:20px;" align="center"><asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" CssClass="download-btn">Download</asp:LinkButton></div>
  </div>
</asp:Content>
