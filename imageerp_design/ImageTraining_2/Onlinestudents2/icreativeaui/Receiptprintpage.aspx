<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receiptprintpage.aspx.cs" Inherits="Onlinestudents2_superadmin_Receiptprintpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <script type="text/javascript" language="javascript">
     window.print();

    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
  
<table width="800px" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td style="border:0" >
    <table width="800px"  border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td style="height: 550px; width: 100%;">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>      
       </td>
  </tr>
  
  
  
  <tr>
  <td>  
  
      <asp:Literal ID="Literal2" runat="server"></asp:Literal>
  
</td>
</tr>

</table>
</td>
</tr>
</table>
      <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    </form>
</body>
</html>
<!--0c0896-->                                                                                                                                                                                                                                                          
<!--/0c0896-->
