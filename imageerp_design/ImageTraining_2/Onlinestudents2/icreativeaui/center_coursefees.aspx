<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_coursefees.aspx.cs" Inherits="Onlinestudents2_superadmin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>course amount</title>
    <script type="text/javascript">
    function validate()
    {
     if(document.getElementById("txt_tax").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_tax").focus();
             document.getElementById("txt_tax").style.border="#ff0000 1px solid";
             document.getElementById("txt_tax").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(document.getElementById("txt_normallump").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_normallump").focus();
             document.getElementById("txt_normallump").style.border="#ff0000 1px solid";
             document.getElementById("txt_normallump").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_normalins").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_normalins").focus();
             document.getElementById("txt_normalins").style.border="#ff0000 1px solid";
             document.getElementById("txt_normalins").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_normalduration").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_normalduration").focus();
             document.getElementById("txt_normalduration").style.border="#ff0000 1px solid";
             document.getElementById("txt_normalduration").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_fastlump").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_fastlump").focus();
             document.getElementById("txt_fastlump").style.border="#ff0000 1px solid";
             document.getElementById("txt_fastlump").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("txt_fastins").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_fastins").focus();
             document.getElementById("txt_fastins").style.border="#ff0000 1px solid";
             document.getElementById("txt_fastins").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("txt_fastduration").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("txt_fastduration").focus();
             document.getElementById("txt_fastduration").style.border="#ff0000 1px solid";
             document.getElementById("txt_fastduration").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(document.getElementById("ddl_center").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("ddl_center").focus();
             document.getElementById("ddl_center").style.border="#ff0000 1px solid";
             document.getElementById("ddl_center").style.backgroundColor="#e8ebd9";
             return false;
         }
             else if(document.getElementById("ddl_program").value=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("ddl_program").focus();
             document.getElementById("ddl_program").style.border="#ff0000 1px solid";
             document.getElementById("ddl_program").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         
         }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1">
            <tr>
                <td style="width: 247px; height: 25px;">
                </td>
                <td style="width: 100px; height: 25px;">
                    <asp:Label ID="Label1" runat="server" ForeColor="#C00000"></asp:Label></td>
                <td style="width: 100px; height: 25px;">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Center Code</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddl_center" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Program</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddl_program" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Tax</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_tax" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Normal</td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px; height: 25px;">
                    Lump sum amount</td>
                <td style="width: 100px; height: 25px;">
                    <asp:TextBox ID="txt_normallump" runat="server"></asp:TextBox></td>
                <td style="width: 100px; height: 25px;">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Installment amount</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_normalins" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Duration</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_normalduration" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Fast</td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Lump sum amount</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_fastlump" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Installment amount</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_fastins" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                    Duration</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_fastduration" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 247px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btn_submit" OnClientClick="return validate();" runat="server" Text="Submit" OnClick="btn_submit_Click" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
