<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ManageIncentive.aspx.cs" Inherits="Onlinestudents2_superadmin_ManageIncentive" Title="Incentive Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--Follow up  start-->
<div class="title-cont">
    <h3 class="cont-title">Incentive Details</h3>
  
    <div class="clear"></div>
  </div>   
  <div class="free-forms">
    <div class="white-cont">
     
      <div class="search-sec-cont2">
        <ul>
          <li>
            <div class="wth-2">
              <asp:Button ID="btnaddincentive" runat="server" CssClass="btnStyle1"  
                        Text="Add Incentive" OnClick="btnaddincentive_Click" />
            </div>
          </li>
          <li>
            <div class="wth-2">
               <asp:Button ID="btnviewincentive" runat="server" CssClass="btnStyle1"  
                        Text="View Incentive" Width="126px" OnClick="btnviewincentive_Click" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  
  
     

</asp:Content>

