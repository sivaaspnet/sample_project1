<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentbatchreport.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_studentbatchreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Batch Attendance Report</title>
        <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
     <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="common" width="100%">
        <tr>
        <td style="padding:0">
        <h4>Student Attendance Report</h4>
        </td>
        </tr>
            <tr id="t1" runat="server">
                <td>
                    <b>Student ID : </b><asp:Label ID="studentid" runat="server" Text="" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Maroon"></asp:Label>&nbsp;</td>
            </tr>
            <tr id="t2" runat="server">
                <td>
                    <b>Student Name :</b> <asp:Label ID="studentname" runat="server" Text="" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Maroon"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td >
        <asp:GridView ID="GridView1" CssClass="common" EmptyDataText="No Results Found"  Width="100%" runat="server" 
                        AutoGenerateColumns="False" onpageindexchanging="GridView1_PageIndexChanging">
            <EmptyDataRowStyle Font-Bold="True"  />
            <Columns>
            
                <asp:BoundField DataField="Date_Attendance" HeaderText="Class Date" >
                    <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" />
                   
                </asp:BoundField>
                 <asp:BoundField DataField="class_content" HeaderText="Class Content" >
                    <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" />
                     </asp:BoundField>
                <asp:BoundField DataField="Attendance_Status" HeaderText="Attendance Status" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Student_Reason" HeaderText="Reason" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
