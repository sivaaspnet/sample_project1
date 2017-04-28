<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatepreviousattendance.aspx.cs" Inherits="superadmin_updatepreviousattendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Closing status</title>
    
    <link href="../styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/jquery-ui-1.8.2.custom.css" />    
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="scripts/main.js"></script> 
    <script type="text/javascript" src="scripts/jquery.rotatingMenu.js"></script>
    
   
   
</head>
<body>
    <form id="form1" runat="server">
   <div class="content_place">
	
    <table width="100%" class="common" >
    <tr><td colspan="2" style="padding:0px"><h4>
        Update Previous Class Attendance</h4></td></tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="gvclasscontent" runat="server" AutoGenerateColumns="False">
                    <Columns>
                    <asp:BoundField HeaderText="Student Name" DataField="enq_personal_name" />
                    <asp:BoundField HeaderText="Student Id" DataField="studentid" />
                    <asp:BoundField HeaderText="Class Date" DataField="clsdate" />
                    <asp:BoundField HeaderText="Software" DataField="software_name" />
                    <asp:BoundField HeaderText="Content" DataField="class_content" /> 
                        <asp:TemplateField HeaderText="Reason">
                         <ItemTemplate>
                             <asp:HiddenField ID="hdnattendanceid" runat="server" Value='<%#Eval("attendance_id") %>' />
                             <asp:TextBox ID="txtreason" runat="server" CssClass="text"></asp:TextBox>                
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td  colspan="2"  style="text-align: center">          
                <asp:Button ID="btnupdate" CssClass="submit" runat="server" Text="Update" OnClick="btnupdate_Click" /></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
