<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="AddInstallment.aspx.cs" Inherits="Onlinestudents2_superadmin_AddInstallment" Title="Add Installment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="TxtInvoice" runat="server"></asp:Label>
    <asp:Label ID="TxtCenterCode" runat="server"></asp:Label>
    <asp:Label ID="TxtCourseId" runat="server"></asp:Label>
  
    <script type="text/javascript">
    
     function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
	        
    function validate()
    {
         if(trim(document.getElementById("ContentPlaceHolder1_TxtStudentId").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_TxtStudentId").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter student id!';
                 document.getElementById("ContentPlaceHolder1_TxtStudentId").focus();
                 document.getElementById("ContentPlaceHolder1_TxtStudentId").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_TxtStudentId").style.backgroundColor="#e8ebd9";
                 return false;
                 }
    }
    
    </script>
<div class="free-forms">
    <table id="tblid"  style="margin:auto" class="common" width="100%" >
        <tr>
            <td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px; height: 45px;" align="center">
                <h4>
                    Add Installment</h4>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp;<asp:HiddenField ID="HdnSub" runat="server" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td >
                &nbsp;&nbsp; <strong>
                Student id&nbsp;</strong> &nbsp;<asp:TextBox ID="TxtStudentId" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td  colspan="1" style=" text-align:center;">
                <asp:Button ID="Btnsubmit" runat="server" CssClass="btnStyle1" OnClick="Btnsubmit_Click"
                    OnClientClick="javascript:return validate();" Text="Submit" />
                &nbsp; 
                <asp:Button ID="BtnReset" runat="server" class="btnStyle2" 
                    Text="Reset" /></td>
        </tr>
    </table>
    <br />
    <table width="100%" id="tblamountdisplay" class="common" runat="server">
        <tr>
            <td >
                <asp:Label ID="txtstuid" runat="server" Text="Student Id :" Font-Size="Medium" Font-Bold="True"></asp:Label>&nbsp;
                &nbsp;<asp:Label ID="lblshowstuid" runat="server" Font-Size="small" ForeColor="SteelBlue" Font-Bold="True"></asp:Label></td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Course Fees :&nbsp; </strong>
                Fess :
                <asp:Label ID="lblinitialview" runat="server" ForeColor="Brown" Font-Bold="True"></asp:Label></td>
            <td>
                Tax :<asp:Label ID="lbltaxview" runat="server" ForeColor="Brown" Font-Bold="True" ></asp:Label></td>
            <td>
                Total :
                <asp:Label ID="lbltotalview" runat="server" ForeColor="Brown" Font-Bold="True" ></asp:Label></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Received : &nbsp; &nbsp;&nbsp; </strong>Fees :
                <asp:Label ID="lblinitialPaidView" runat="server" ForeColor="Brown" Font-Bold="True"></asp:Label></td>
            <td>
                Tax :<asp:Label ID="lbltaxpaidview" runat="server" ForeColor="Brown" Font-Bold="True"></asp:Label></td>
            <td>
                Total :<asp:Label ID="lbltoatalPaidView" runat="server" ForeColor="Brown" Font-Bold="True"></asp:Label></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Balance : &nbsp; &nbsp; &nbsp; </strong>Fees :<asp:Label ID="lblbalancefeesview" runat="server" ForeColor="Brown" Font-Bold="True"></asp:Label></td>
            <td>
                Tax :<asp:Label ID="lblbalancetaxview" runat="server" ForeColor="Brown" Font-Bold="True" ></asp:Label></td>
            <td>
                Total :<asp:Label ID="lblbalancetotview" runat="server" ForeColor="Brown" Font-Bold="True" ></asp:Label></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 21px" align="center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging"
         PageSize="15" Width="100%" >
        <EmptyDataRowStyle ForeColor="Red" />
        <Columns>
            <asp:BoundField DataField="InvoiceId" HeaderText="Invoice No" />
            <asp:BoundField DataField="InstallNumber" HeaderText="Install Number" />
            <asp:BoundField DataField="initialamount" HeaderText="Initial Amount" />
            <asp:BoundField DataField="initialamounttax" HeaderText="Tax Amount" />
            <asp:BoundField DataField="totalinitialamount" HeaderText="Total Amount" />
            <asp:BoundField DataField="receiptNo" HeaderText="Receipt No" />
            <asp:BoundField DataField="amount" HeaderText="Receipt Initial" />
            <asp:BoundField DataField="taxamount" HeaderText="Receipt Tax" />
            <asp:BoundField DataField="totalamount" HeaderText="Receipt Total Amount" />
            <asp:BoundField DataField="Status" HeaderText="Receipt Status" />
            <asp:BoundField DataField="dateins" HeaderText="Receipt Date" />
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr align="center">
            <td align="center" colspan="5" style="height: 21px">
                <asp:Button ID="BtnSub" runat="server" CssClass="submit" Text="Add" OnClick="BtnSub_Click" /></td>
        </tr>
    </table>
</div>
</asp:Content>

