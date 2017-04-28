<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="GetCentreDetails.aspx.cs" Inherits="Onlinestudents2_superadmin_GetCentreDetails" Title="Get Centre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">



</script>

    <div class="login" style="left: 38%; top: 35%">
      <%--  <h2>
            Centre Details</h2>--%>
        <table class="login_table" style="width: 313px">
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="lblerrmsg" runat="server" CssClass="error" Text=""></asp:Label></td>
            </tr>
            <tr id="visfalse" visible="false" runat="server">
                <td class="userlogin" style=" padding-bottom:0px;" colspan="2">
                    <label for="username">
                        &nbsp;
                        Centre Name &nbsp;
                    <asp:DropDownList ID="ddl_Centre" runat="server">
                    </asp:DropDownList>&nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="search" OnClientClick="javascript:return loginval();"
                         OnClick="btnSearch_Click" />
                    </label>
                </td>
            </tr>
        </table>
        &nbsp;<!--login end--></div>
</asp:Content>

