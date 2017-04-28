<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CourseFeesInsert.aspx.cs" Inherits="Onlinestudents2_superadmin_CourseFeesInsert" Title="Course Fees Insert" %>
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
           // clearValidation('ContentPlaceHolder1_ddlcentrename~ContentPlaceHolder1_ddlCentreStatus~ContentPlaceHolder1_txtmessage')

         // alert("test")
               if(document.getElementById("ContentPlaceHolder1_ddl_centre").value=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_centre").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select centre!';
                 document.getElementById("ContentPlaceHolder1_ddl_centre").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_centre").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_centre").style.backgroundColor="#e8ebd9";
                 return false;
                 }
            else if(trim(document.getElementById("ContentPlaceHolder1_ddl_course").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_course").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select course!';
                 document.getElementById("ContentPlaceHolder1_ddl_course").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_course").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_course").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                  else if(trim(document.getElementById("ContentPlaceHolder1_ddl_duration").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_duration").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select duration!';
                 document.getElementById("ContentPlaceHolder1_ddl_duration").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_duration").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_duration").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                 
                 else if(trim(document.getElementById("ContentPlaceHolder1_txt_lumpsum").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_lumpsum").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the lumpsum!';
                 document.getElementById("ContentPlaceHolder1_txt_lumpsum").focus();
                 document.getElementById("ContentPlaceHolder1_txt_lumpsum").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_lumpsum").style.backgroundColor="#e8ebd9";
                 return false;
                 }
	       else if(trim(document.getElementById("ContentPlaceHolder1_txt_installamount").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_installamount").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the install amount!';
                 document.getElementById("ContentPlaceHolder1_txt_installamount").focus();
                 document.getElementById("ContentPlaceHolder1_txt_installamount").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_installamount").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                  else if(trim(document.getElementById("ContentPlaceHolder1_txt_tax").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_tax").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the tax!';
                 document.getElementById("ContentPlaceHolder1_txt_tax").focus();
                 document.getElementById("ContentPlaceHolder1_txt_tax").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_tax").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                   else if(trim(document.getElementById("ContentPlaceHolder1_ddl_runninginvoice").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_runninginvoice").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select running invoice centre code!';
                 document.getElementById("ContentPlaceHolder1_ddl_runninginvoice").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_runninginvoice").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_runninginvoice").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                  else if(trim(document.getElementById("ContentPlaceHolder1_ddl_runningreceipt").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_runningreceipt").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select running receipt centre code!';
                 document.getElementById("ContentPlaceHolder1_ddl_runningreceipt").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_runningreceipt").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_runningreceipt").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                  else if(trim(document.getElementById("ContentPlaceHolder1_ddl_status").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_status").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select status';
                 document.getElementById("ContentPlaceHolder1_ddl_status").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_status").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_status").style.backgroundColor="#e8ebd9";
                 return false;
                 }
              
	          else
	          {
	           return true;
	          }
         
         }

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
                <asp:DropDownList ID="ddl_centre" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td  style="">
                Course</td>
            <td align="left" valign="middle">
                &nbsp;<asp:DropDownList ID="ddl_course" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td  style="">
                Duration</td>
            <td align="left" style="height: 25px" valign="middle">
                &nbsp;<asp:DropDownList ID="ddl_duration" runat="server">
                    <asp:ListItem Value="">Select</asp:ListItem>
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
                <asp:Label ID="lbltrack" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td  style="">
                Maximum No.of.Installments</td>
            <td align="left" style="height: 25px" valign="middle">
                <span class="file">
                <asp:TextBox ID="txtmaxinstall" onKeyPress="return CheckNumeric(event)" 
                    runat="server" CssClass="text" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td  style="">
                lump sum</td>
            <td align="left" style="height: 25px" valign="middle">
                <asp:TextBox ID="txt_lumpsum" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td  style="">
                Install amount</td>
            <td align="left" style="height: 25px" valign="middle">
                <asp:TextBox ID="txt_installamount" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td  style="">
                Tax</td>
            <td align="left" style="height: 25px" valign="middle">
                <asp:TextBox ID="txt_tax"  runat="server" CssClass="text" MaxLength="25"></asp:TextBox></td>
        </tr>
        <tr>
            <td  style="">
                Running Invoice CentreCode</td>
            <td align="left" style="height: 25px" valign="middle">
                <asp:DropDownList ID="ddl_runninginvoice" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td  style="">
                Running Receipt CentreCode</td>
            <td align="left" style="height: 25px" valign="middle">
                <asp:DropDownList ID="ddl_runningreceipt" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td  style="">
                Status</td>
            <td align="left" style="height: 25px" valign="middle">
                <asp:DropDownList ID="ddl_status" runat="server">
                    <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">Enable</asp:ListItem>
                    <asp:ListItem Value="0">Disable</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td  colspan="2" style="text-align: center">
                &nbsp;<asp:Button ID="Btnsubmit" runat="server" CssClass="btnStyle1" 
                    OnClientClick="javascript:return validate();" Text="Submit" OnClick="Btnsubmit_Click" />&nbsp; &nbsp;<asp:Button
                        ID="BtnReset" runat="server" class="btnStyle2"  Text="Reset" />
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
                    OnClientClick="javascript:return SearchValidate();" />
                    
                     <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_keyword"></asp:CustomValidator>
                    </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <div style="height:500px;overflow:auto;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        CssClass="common" EmptyDataText="No Records Found" 
         PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" 
           OnRowCommand="GridView1_RowCommand">
        <EmptyDataRowStyle ForeColor="Red"  width="100%"/>
        <Columns>
            <asp:BoundField DataField="centre_location" HeaderText="Centre Name" />
            <asp:BoundField DataField="program" HeaderText="Program" />
            <asp:BoundField DataField="duration" HeaderText="Duration" />
            <asp:BoundField DataField="noofinstall" HeaderText="Max.Install" />
            <asp:BoundField DataField="track" HeaderText="Track" />
            <asp:BoundField DataField="lump_sum" HeaderText="Lump Sum" />
            <asp:BoundField DataField="instal_amount" HeaderText="Install Amount" />
            <asp:BoundField DataField="tax" HeaderText="Tax" />
            <asp:BoundField DataField="runningInvoiceCentreCode" HeaderText="Running invoice Centre Code" />
            <asp:BoundField DataField="runningReceiptCentreCode" HeaderText="Running Receipt Centre Code" />
            <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("centrecourse_id")%>'
                        CommandName="edt"><img src="layout/edit.png" alt="edit" /></asp:LinkButton>&nbsp;
                    <asp:LinkButton
                            ID="lnkdelete" runat="server" CommandArgument='<%#Eval("centrecourse_id")%>' CommandName="del"
                            OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>
      
       <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click"><span class="file"><span class="file"><span class="file"><span class="file">Download</span></span></span></span></asp:LinkButton>
    </div>
    <br />
</asp:Content>

