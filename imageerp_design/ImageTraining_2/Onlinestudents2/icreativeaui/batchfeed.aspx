<%@ Page Language="C#" AutoEventWireup="true" CodeFile="batchfeed.aspx.cs" Inherits="superadmin_Viewstudentcoursedetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <title> Student Course details</title>
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    
</head>
<body>
    <form id="form1" runat="server">
   
        <table class="common" > 
            <tr>
                <td style="padding:0px;"><h4>View Sent FeedBack Batch Details</h4>
                </td>
            </tr>
            <tr>
            <td>
            <table cellpadding="0" cellspacing="0" class="common" width="100%">
   
      
        <tr>
            <td >
                <asp:Label ID="Label2" runat="server" Text="Faculty Name"></asp:Label></td>
            <td >
                <asp:DropDownList ID="ddl_fac" runat="server" Width="97px">
                </asp:DropDownList></td>
            <td >
                Slot</td>
            <td >
                <asp:DropDownList ID="ddl_slot" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="MWF">MWF</asp:ListItem>
                    <asp:ListItem Value="TTS">TTS</asp:ListItem>
                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList></td>
            <td >
                Select Month</td>
            <td >
                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="text">
          
                <asp:ListItem Value="01">January</asp:ListItem>
                <asp:ListItem Value="02">February</asp:ListItem>
                <asp:ListItem Value="03">March</asp:ListItem>
                <asp:ListItem Value="04">April</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">June</asp:ListItem>
                <asp:ListItem Value="07">July</asp:ListItem>
                <asp:ListItem Value="08">August</asp:ListItem>
                <asp:ListItem Value="09">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList></td>
            <td >
                Select Year</td>
            <td >
                <asp:DropDownList ID="ddlyear" runat="server" CssClass="text">
                  
                <asp:ListItem Value="2011">2011</asp:ListItem>
                <asp:ListItem Value="2012">2012</asp:ListItem>
                <asp:ListItem Value="2013">2013</asp:ListItem>
                <asp:ListItem Value="2014">2014</asp:ListItem>
                <asp:ListItem Value="2015">2015</asp:ListItem>
                <asp:ListItem Value="2016">2016</asp:ListItem>
                <asp:ListItem Value="2017">2017</asp:ListItem>
                <asp:ListItem Value="2018">2018</asp:ListItem>
                <asp:ListItem Value="2019">2019</asp:ListItem>
                </asp:DropDownList>&nbsp;
                </td>
           
            <td >
                &nbsp;<asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
		</table>
            </td>
            </tr>
            <tr>
                <td  align="center">
                   Total Feedback Sent : <asp:Label ID="Label1" runat="server" Text="Label" 
                        Font-Bold="True" Font-Size="Small" ForeColor="#990000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  align="center">
         
                    <asp:GridView ID="GridView1" CssClass="common" Width="100%" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="batchcode" HeaderText="BatchCode" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FacultyName" HeaderText="Faculty" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="slot" HeaderText="Slot" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="batchTiming" HeaderText="Time" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td> 
                <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click">Download Excel</asp:LinkButton></td></tr>
            </table>
    
    </form>
</body>
</html>
