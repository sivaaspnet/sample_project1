<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="DashboardNew.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="common" width="600">
        <tr>
            <td colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px">
                <h4>
                    Dash board Consolidated Report</h4>
            </td>
        </tr>
        <tr>
            <td style="width: 322px">
                From Date
                <asp:TextBox ID="txtfromcalender1" runat="server" CssClass="text datepicker" onpaste="return false" onKeyPress="return false" Width="92px"></asp:TextBox>
            </td>
            <td>
                To Date
                <asp:TextBox ID="txttocalender1" runat="server" CssClass="text datepicker" onpaste="return false" onKeyPress="return false"  Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort" runat="server" CssClass="submit" OnClick="btnsort_Click"
                    OnClientClick="javascript:return sortval1();" Text="Sort" /></td>
        </tr>
        <tr id="todayreport" runat="server">
            <td class="w290 talignleft" colspan="2">
                Today's Conslidated Report</td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px">
                <img alt="" src="../layout/icon.plus.gif" />
                Total no of enquiries in all the branches :</td>
            <td>
                <asp:Label ID="lbltotalenquiry" runat="server" CssClass="error" Text="0"></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px; height: 25px;">
                <img alt="" src="../layout/icon.plus.gif" />
                Total no of Enrollment in all the branches :</td>
            <td style="height: 25px">
                <asp:Label ID="lblTotalenrollment" runat="server" CssClass="error" Text="0"></asp:Label></td>
        </tr>
        <tr id="todenq" runat="server" visible="false">
            <td class="w290 talignleft" style="width: 322px; height: 25px;">
                <img alt="" src="../layout/icon.plus.gif" />
                Today's enquiries :
            </td>
            <td style="height: 25px">
                <asp:Label ID="lbltodayenq" runat="server" CssClass="error" Text="0"></asp:Label></td>
        </tr>
        <tr id="revenueenrollment" runat="server" visible="false">
            <td class="w290 talignleft" style="width: 322px">
                <img alt="" src="../layout/icon.plus.gif" />
                Total revenue from enrollment :
            </td>
            <td>
                <asp:Label ID="lbltotrevenue_tax" runat="server" CssClass="error" Text="0"></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px">
                <img alt="" src="../layout/icon.plus.gif" />
                Total Fees collected (Cash)&nbsp; :
            </td>
            <td>
                <asp:Label ID="lbltotlumpsum_tax" runat="server" CssClass="error" Text="0"></asp:Label>&nbsp;
                <asp:TextBox ID="txt_feescash" runat="server" CssClass="text" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px">
                <img alt="" src="../layout/icon.plus.gif" />
                Total Fees collected (Cheque)&nbsp; :
            </td>
            <td>
                <asp:Label ID="lbltotlumpsum_cheque" runat="server" CssClass="error" Text="0"></asp:Label>
                <asp:TextBox ID="txt_feescheque" runat="server" CssClass="text" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px; height: 25px">
                <img alt="" src="../layout/icon.plus.gif" />
                Total Fees collected (Cash + Cheque)&nbsp; :
            </td>
            <td style="height: 25px">
                <asp:Label ID="lbl_totlump" runat="server" CssClass="error">0</asp:Label>
                <asp:TextBox ID="txt_feescashcheque" runat="server" CssClass="text" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px; height: 25px;">
                <img alt="" src="../layout/icon.plus.gif" />
                Total revenue collected as Installment (Cash) :
            </td>
            <td style="height: 25px">
                <asp:Label ID="lbltotinstal_tax" runat="server" CssClass="error" Text="0"></asp:Label>
                <asp:TextBox ID="txt_revcash" runat="server" CssClass="text" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px; height: 25px;">
                <img alt="" src="../layout/icon.plus.gif" />
                Total revenue collected as Installment (Cheque) :
            </td>
            <td style="height: 25px">
                <asp:Label ID="lbltotinstal_cheque" runat="server" CssClass="error" Text="0"></asp:Label>
                <asp:TextBox ID="txt_revcheque" runat="server" CssClass="text" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px">
                <img alt="" src="../layout/icon.plus.gif" />
                Total revenue collected as Installment (Cash + Cheque) :
            </td>
            <td>
                <asp:Label ID="lbl_totins" runat="server" CssClass="error">0</asp:Label>
                <asp:TextBox ID="txt_revcashcheque" runat="server" CssClass="text" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 322px">
                <img alt="" src="../layout/icon.plus.gif" />
                Grand Total:&nbsp;</td>
            <td>
                <asp:Label ID="lbltotcollection_tax" runat="server" CssClass="error" Text="0"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

