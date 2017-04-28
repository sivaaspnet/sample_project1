<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_softwareversion.aspx.cs" Inherits="Onlinestudents2_superadmin_View_softwareversion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Software Version</title>
    
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/jquery-ui-1.8.2.custom.css" />    
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="scripts/main.js"></script> 
    <script type="text/javascript" src="scripts/jquery.rotatingMenu.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   
     <table align="center" class="common"><tr><td colspan="2" style=" padding:0px" align="center"><h4>Software Version</h4></td></tr> 
     <tr><td style="text-align:center;">
         <asp:Label ID="lblerrormsg" runat="server" CssClass="error" Text=''></asp:Label></td></tr>
     <tr><td>

<asp:GridView ID="Gridviewsoftware" Width="500" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Results Found" PageSize="10" HorizontalAlign="Center" OnPageIndexChanging="Gridviewsoftware_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Software Name">
                 <ItemTemplate>
                 <%#Eval("software_name")%>
                 </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Version">
                 <ItemTemplate>
                  <%#Eval("version")%>
                 </ItemTemplate>
                </asp:TemplateField>--%>
                
            </Columns>
        </asp:GridView>
        </td></tr>
        </table>
 
    </form>
</body>
</html>
