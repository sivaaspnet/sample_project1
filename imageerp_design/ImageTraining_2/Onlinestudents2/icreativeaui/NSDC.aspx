<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/imagemasterpage.master" AutoEventWireup="true" CodeFile="NSDC.aspx.cs" Inherits="NSDC" Title="NSDC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <h1>NSDC REGISTRATION</h1>
   
    
     <table >
    <tr>
    <td align="right" class="style3"><asp:Button ID="Button1" runat="server" 
            onclick="btn_add_Click" Text="ADD" Width="101px" />
              &nbsp;   ||</td>
              <td align="left">
                  <asp:Button ID="Button2" runat="server" onclick="btn_view_Click" 
        Text="VIEW" style="margin-left: 11px" Width="89px" />&nbsp;
                 </td>
    </tr></table>
</asp:Content>

