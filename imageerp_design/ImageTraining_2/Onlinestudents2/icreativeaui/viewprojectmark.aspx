<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewprojectmark.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_viewprojectmark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Project Mark</title>
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
        <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="nivo-slider/themes/default/default.css"  type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/pascal/pascal.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/orman/orman.css"type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/demo/style.css" type="text/css" media="screen" />
       <link rel="shortcut icon" type="image/x-icon" href="layout/logo.png"/>
</head>
<body>
    <form id="form1" runat="server">
    
    
        <asp:DataList ID="DataList1" runat="server">
        <HeaderTemplate>
          
                              <table width="100%" border="0" class="common">
                                <div class="gridSort">  
                              </HeaderTemplate>
                              <ItemTemplate>
        <tr>
            <td >
            Batchcode:
            </td>
            <td ><%#Eval("batchCode")%>
            </td>
        </tr>
        <tr>
            <td >Send Date
            </td>
            <td ><%#Eval("senddate")%>
            </td>
        </tr>
        <tr>
            <td >Mark
            </td>
            <td ><%#Eval("mark")%>
            </td>
        </tr>
        <tr>
            <td >Evaluated By
            </td>
            <td ><%#Eval("Evaluatedby")%>
            </td>
        </tr>
        <tr>
            <td >Evaluated Date
            </td>
            <td ><%#Eval("EvaluatedDate")%>
            </td>
        </tr>
        <tr>
            <td >Remarks
            </td>
            <td ><%#Eval("remarks")%>
            </td>
        </tr>
         <tr>
            <td >Dispatch Date
            </td>
            <td ><%#Eval("Dispatchdate")%>
            </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </div>
    </table>
    </FooterTemplate>
        </asp:DataList>
    

    </form>
</body>
</html>
