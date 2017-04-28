<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="breakage.aspx.cs" Inherits="Onlinestudents2_superadmin_Default" Title="breakage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="title-cont">
    <h3 class="cont-title">Breakage Details</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="breakage.aspx" class="last">Breakage Details</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
  <div id="parent">
    <ul>
      <li><a href="#tabs-5">Fine</a></li>
      <li><a href="#tabs-6">Breakage</a></li>
    </ul>
    <div class="clear"></div>
    <div class="white-cont">
      <div id="tabs-5">
        <div class="free-forms" style="padding:10px;">
          <table class="common" border="0" style="border:0px !important;">
            <tr>
              <td style="width: 100px; border:0px;"><asp:Button ID="Button3" runat="server" CssClass="btnStyle1" Text="Add Fine Details" OnClick="Button3_Click" />
              </td>
              <td style="width: 100px; border:0px;"><asp:Button ID="Button4" runat="server" CssClass="btnStyle1" Text="View Fine Details" OnClick="Button4_Click" />
              </td>
            </tr>
          </table>
        </div>
      </div>
      <div id="tabs-6">
        <div class="free-forms" style="padding:10px;">
          <table class="common" border="0" style="border:0px !important;">
            <tr></tr>
            <tr>
              <td style="width: 100px; border:0px;"><asp:Button ID="Button1" runat="server" CssClass="btnStyle1" OnClick="Button1_Click" Text="Add Breakage Details" /></td>
              <td style="width: 100px; border:0px;"><asp:Button ID="Button2" runat="server" CssClass="btnStyle1" OnClick="Button2_Click" Text="View Breakage Details" /></td>
            </tr>
          </table>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
