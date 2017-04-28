<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="coursefeesinsertnewold.aspx.cs" Inherits="coursefeesinsertnewold" Title="Course Fees Insert" %>
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
    else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddl_course").value)=="")
    {
        document.getElementById("ctl00_ContentPlaceHolder1_ddl_course").value=="";
        alert("Please select course");
        document.getElementById("ctl00_ContentPlaceHolder1_ddl_course").focus();
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

 

 /*
  check all and un check all for centre
  
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
    */

});
</script>
   <div class="free-forms">

    <table class="common" width="100%">
        <tr>
            <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px">
                <h4>
                    Insert Course Fees
                    <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>
                    <asp:HiddenField ID="Hidn_centerloginid" runat="server" />
                </h4>
            </td>
        </tr> 
        <tr>
            <td  style="">
                Centre</td>
            <td align="left" style="height: 29px" valign="middle">
                <asp:CheckBoxList ID="chk_centre" CssClass="checkBoxClass" RepeatDirection="Horizontal" RepeatColumns="4" runat="server">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td  style="">
                Course</td>
            <td align="left" valign="middle">
                &nbsp;<asp:DropDownList ID="ddl_course" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr> <td  style="">
                Track</td>
            <td align="left" valign="middle">
                &nbsp; 
                <asp:CheckBox ID="chkfast" Text="Fast" runat="server" CssClass="chkfast"/>
                <div class="fastdiv" style="display:none;"> 
                <table class="common" width="85%">
                <tr><td> Duration </td><td><asp:DropDownList ID="ddlfastduration" runat="server">
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
                </asp:DropDownList> </td></tr>
                <tr><td> Maximum no.of Installments </td><td><asp:TextBox ID="txtfastmaxinstall" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td> Lump Sum </td><td><asp:TextBox ID="txtfastlumpsum" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td> Installment amount </td><td><asp:TextBox ID="txtfastinstallamt" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td> Tax </td><td><asp:TextBox ID="txtfasttax" runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td  style="">Status</td><td align="left" style="height: 25px" valign="middle">
                <asp:DropDownList ID="ddlfaststatus" runat="server">
                    <asp:ListItem Value="1">Enable</asp:ListItem>
                    <asp:ListItem Value="0">Disable</asp:ListItem>
                </asp:DropDownList> 
                    <asp:CheckBox ID="chksameas" runat="server" Text="Same As For Normal" /> </td> </tr>
                </table>
                </div>
                </td></tr>
        <tr><td  style="">
                </td>
            <td align="left" valign="middle">
                &nbsp; 
                <asp:CheckBox ID="chknormal" Text="Normal" runat="server" CssClass="chknormal"/>
                <div class="normaldiv" style="display:none;"> 
                <table class="common" width="75%">
                <tr><td> Duration </td><td> <asp:DropDownList ID="ddlnormalduration" runat="server">
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
                </asp:DropDownList></td></tr>
                <tr><td> Maximum no.of Installments </td><td><asp:TextBox ID="txtnormalmaxinstall" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td> Lump Sum </td><td><asp:TextBox ID="txtnormallump" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td> Installment amount </td><td><asp:TextBox ID="txtnormalinstallamt" onKeyPress="return CheckNumeric(event)"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td> Tax </td><td><asp:TextBox ID="txtnormaltax" runat="server" CssClass="text" MaxLength="25"></asp:TextBox>  </td></tr>
                <tr><td  style="">Status</td><td align="left" style="height: 25px" valign="middle">
                <asp:DropDownList ID="ddlnormalstatus" runat="server">
                    <asp:ListItem Value="1">Enable</asp:ListItem>
                    <asp:ListItem Value="0">Disable</asp:ListItem>
                </asp:DropDownList></td> </tr>
                </table>
                </div>
                </td></tr>         
        
        
        <tr>
            <td  colspan="2" style="text-align: center">
                &nbsp;<asp:Button ID="Btnsubmit" runat="server" CssClass="btnStyle1" 
                    OnClientClick="javascript:return validate();" Text="Submit" OnClick="Btnsubmit_Click" />&nbsp; &nbsp;<asp:Button
                        ID="BtnReset" runat="server" class="btnStyle2"  Text="Reset" 
                    onclick="BtnReset_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table class="common" width="100%">
        <tr>
            <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px; height: 43px">
                <h4>
                    Search Course</h4>
            </td>
        </tr>
        <tr>
            <td>
                Searchby centre<br />
                <asp:DropDownList ID="ddl_centre_search" runat="server" CssClass="select" Width="150px" >
                </asp:DropDownList>
            </td>
            <td>
                Searchby Region<br /><asp:DropDownList ID="ddl_region" runat="server" CssClass="select"  Width="150px">
                </asp:DropDownList></td>
            <td>
                Searchby Course<br />
                <asp:DropDownList ID="ddl_course_search" runat="server" CssClass="select"  Width="150px">
                </asp:DropDownList>
               
            </td>       
            <td>
                Keyword Search<br />
                <asp:TextBox ID="txt_keyword" runat="server" CssClass="text" MaxLength="25" Width="150px"></asp:TextBox> <asp:Button ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click"
                    OnClientClick="javascript:return SearchValidate();" /></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
     
        <asp:GridView ID="gvcourse" AllowPaging="true" PageSize="20" runat="server"  
           CssClass="common" EmptyDataText="No Records Found" AutoGenerateColumns="false" 
           Width="100%" onpageindexchanging="gvcourse_PageIndexChanging" 
           onrowcommand="gvcourse_RowCommand">
        <Columns>
        <asp:BoundField DataField="program" HeaderText="Program" />
        <asp:TemplateField HeaderText="Details" ItemStyle-Width="70%">
        <ItemTemplate> <%#Eval("coursedetails")%></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
        <ItemTemplate> 
            <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("courseid")%>' CommandName="edt"><img src="layout/edit.png" alt="edit" /></asp:LinkButton> 
            <asp:LinkButton ID="lnkdel" runat="server" CommandArgument='<%#Eval("courseid")%>' CommandName="del"
                            OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>   
     
      
       <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click"><span class="file"><span class="file"><span class="file"><span class="file">Download</span></span></span></span></asp:LinkButton>
    </div>
    <br />
</asp:Content>

