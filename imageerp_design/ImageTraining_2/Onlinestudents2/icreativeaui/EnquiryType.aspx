<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="EnquiryType.aspx.cs" Inherits="Onlinestudents2_superadmin_EnquiryType" Title="Enquiry Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!--Follow up  start-->
  <div class="title-cont">
    <h3 class="cont-title">Select The Enquiry Type</h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="enquirytype.aspx" class="last">Select The Enquiry Type</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>
  <div class="free-forms">
    <div class="white-cont">
     
      <div class="search-sec-cont2">
        <ul>
          <li>
            <div class="wth-2">
              <asp:Button ID="btnenquiry" runat="server" CssClass="btnStyle1" OnClick="btnenquiry_Click" Text="Walkin Enquiry" />
            </div>
          </li>
          <li>
            <div class="wth-2">
              <asp:Button ID="btnviewdetails" runat="server" CssClass="btnStyle1" OnClick="btnviewdetails_Click" Text="Tele Enquiry" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
</asp:Content>
