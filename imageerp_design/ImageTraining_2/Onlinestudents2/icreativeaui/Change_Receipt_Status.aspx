<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Change_Receipt_Status.aspx.cs" Inherits="Onlinestudents2_superadmin_Change_Receipt_Status" Title="Update Receipt Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
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

          //alert("test")
               if(trim(document.getElementById("ContentPlaceHolder1_txt_receiptno").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_receiptno").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter receipt no!';
                 document.getElementById("ContentPlaceHolder1_txt_receiptno").focus();
                 document.getElementById("ContentPlaceHolder1_txt_receiptno").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_receiptno").style.backgroundColor="#e8ebd9";
                 return false;
                 }
            else if(trim(document.getElementById("ContentPlaceHolder1_txt_invoieno").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_invoieno").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter invoice no!';
                 document.getElementById("ContentPlaceHolder1_txt_invoieno").focus();
                 document.getElementById("ContentPlaceHolder1_txt_invoieno").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_invoieno").style.backgroundColor="#e8ebd9";
                 return false;
                 }
	       else if(trim(document.getElementById("ContentPlaceHolder1_txt_installno").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_installno").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter install no!';
                 document.getElementById("ContentPlaceHolder1_txt_installno").focus();
                 document.getElementById("ContentPlaceHolder1_txt_installno").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_installno").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                  else if(trim(document.getElementById("ContentPlaceHolder1_ddl_receiptstatus").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_receiptstatus").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select status!';
                 document.getElementById("ContentPlaceHolder1_ddl_receiptstatus").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_receiptstatus").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_receiptstatus").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                  else if(trim(document.getElementById("ContentPlaceHolder1_txt_remarks").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txt_remarks").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the remarks!';
                 document.getElementById("ContentPlaceHolder1_txt_remarks").focus();
                 document.getElementById("ContentPlaceHolder1_txt_remarks").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txt_remarks").style.backgroundColor="#e8ebd9";
                 return false;
                 }
              
	          else
	          {
	           return true;
	          }
         
         }

</script>
<div class="title-cont">
 <h3 class="cont-title">Update Receipt Status</h3>
</div>
<asp:HiddenField ID="Hdn_ReceiptId" runat="server" />
<div class="white-cont">  
                 <div align="center">
                    <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></div>
          <div class="form-cont">
        <ul>     
        <li></li>             
   <li>            <label class="label-txt"> 
                Receipt No</label>
        <asp:TextBox ID="txt_receiptno" runat="server" onKeyPress="return CheckNumeric(event)" CssClass="text input-txt" ReadOnly="True"></asp:TextBox></li>
       <li>            <label class="label-txt"> 
             Invoice No</label>
         <asp:TextBox ID="txt_invoieno" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text input-txt" ReadOnly="True"></asp:TextBox></li>
      <li>            <label class="label-txt"> 
                Install No</label>
           <asp:TextBox ID="txt_installno" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text input-txt" ReadOnly="True"></asp:TextBox></li>
        <li>            <label class="label-txt"> 
                Status</label>
             &nbsp;<asp:DropDownList ID="ddl_receiptstatus" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="0">Deactive</asp:ListItem>
                </asp:DropDownList></li>
        <li>            <label class="label-txt"> 
                Remarks</label>
          <asp:TextBox ID="txt_remarks" runat="server" CssClass="text input-txt" Height="57px" MaxLength="20" Width="260px"
                    TextMode="MultiLine"></asp:TextBox></li>
         <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">  
                &nbsp;<asp:Button ID="Btnsubmit" runat="server" CssClass="btnStyle1" 
                     Text="Submit" OnClick="Btnsubmit_Click" OnClientClick="javascript:return validate();"/>&nbsp; &nbsp; &nbsp;
                <asp:Button ID="BtnReset" runat="server" class="reset-btn" 
                    Text="Reset" /></div></li>
       </ul>
       <div class="clear"></div></div>
       </div>
        <div class="white-cont">
  <div style="padding:0px 10px 10px 10px">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="tbl-cont3" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging"
         PageSize="15" OnRowCommand="GridView1_RowCommand" width="100%">
        <EmptyDataRowStyle ForeColor="Red" />
        <Columns>
            <asp:BoundField DataField="receiptNo" HeaderText="Receipt No" />
            <asp:BoundField DataField="invoiceNo" HeaderText="Invoice No" />
            <asp:BoundField DataField="installNo" HeaderText="Install No" />
            <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("Id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
    </asp:GridView>
	</div></div>
</asp:Content>

