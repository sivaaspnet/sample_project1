<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Reportfac.aspx.cs" Inherits="Onlinestudents2_superadmin_staff" Title="StaffReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript">
 
     
         
         
         function selectdate()
{
 var start = document.getElementById("ContentPlaceHolder1_txtfromdate").value;
        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

        var start_s = start.split("-");
        //var end_s = end.split("-");

        var stDate = start_s[1]+"/"+start_s[0]+"/"+start_s[2];
        var todate = document.getElementById("ContentPlaceHolder1_txttodate").value;
        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

        var todate_s = todate.split("-");
        //var end_s = end.split("-");

        var toDates = todate_s[1]+"/"+todate_s[0]+"/"+todate_s[2];
     var extdate = Date.parse(stDate);
     var enddate = Date.parse(toDates);

    if(document.getElementById("ContentPlaceHolder1_txtfromdate").value=="")
    {
        document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
        alert("Please select from date");
        document.getElementById("ContentPlaceHolder1_txtfromdate").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtfromdate").style.backgroundColor="#e8ebd9";
        return false;
    } 
    else if(document.getElementById("ContentPlaceHolder1_txttodate").value=="")
    {
        document.getElementById("ContentPlaceHolder1_txttodate").focus();
        alert("Please select to date");
        document.getElementById("ContentPlaceHolder1_txttodate").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txttodate").style.backgroundColor="#e8ebd9";
        return false;
    } 
    else if(new Date(extdate)>new Date(enddate))
	{
		alert("Please select the valid to date")
		document.getElementById("ContentPlaceHolder1_txttodate").value="";
		document.getElementById("ContentPlaceHolder1_txttodate").focus();
		return false;
	}
	
    else
    { 
        return true;
    }
}
 </script>
    <div>
        &nbsp;&nbsp;
        <br />
        <br />
        <table style="width: 80%" class="common">
            <tr align="center">
                <td colspan="4" style="padding:0px; height: 29px;">
                <h4>Staff Report</h4>
                </td>
            </tr>
            <tr align="center">
                <td >
                    FacultyName:<asp:DropDownList ID="ddl_fac" runat="server">
                    </asp:DropDownList></td>
                <td >
                    StartDate:<asp:TextBox ID="txtfromdate" runat="server" onpaste="return false" onKeyPress="return false" CssClass="text datepicker" MaxLength="20"
                        Width="100px"></asp:TextBox></td>
                <td >
                    EndDate:<asp:TextBox ID="txttodate" runat="server" onpaste="return false" onKeyPress="return false" CssClass="text datepicker" MaxLength="20"
                        Width="100px"></asp:TextBox>
                    </td>
                <td>
                    <asp:Button ID="submit" runat="server"  OnClientClick="javascript:return selectdate()" CssClass="submit" OnClick="submit_Click" Text="Submit" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 66px; text-align:center;"   >
                    &nbsp;<br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#C00000" EmptyDataText="No Record" Width="833px">
                        <Columns>
                            <asp:TemplateField HeaderText="Batchcode">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("batchcode") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <ItemTemplate>
                 <a rel="modal" href="batchrep.aspx?batchcode=<%#Eval("batchcode")%>&iframe=true&amp;width=750&amp;height=500"><%# Eval("batchcode") %></a>
                
               </ItemTemplate>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="slot" HeaderText="Slot" />
                            <asp:BoundField DataField="batchtiming" HeaderText="BatchTiming" />
                            <asp:BoundField DataField="module_content" HeaderText="Module" />
                            <asp:BoundField DataField="labname" HeaderText="Lab" />
                            <asp:BoundField DataField="facultyname" HeaderText="Faculty" />
                            <asp:BoundField DataField="startdate" HeaderText="StartDate" />
                            <asp:BoundField DataField="enddate" HeaderText="EndDate" />
                            <asp:BoundField DataField="noofstudent" HeaderText="NoOfStudent" />
                            <asp:BoundField DataField="Content" HeaderText="Content Status" HtmlEncode="False" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                        </Columns>
                        <EmptyDataRowStyle BorderColor="Maroon" Font-Bold="True" Font-Size="Larger" ForeColor="Red"
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                    <asp:Label ID="lbl_error" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:LinkButton ID="lnkdownload" runat="server" Visible="false" OnClick="lnkdownload_Click">Download Excel</asp:LinkButton></td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
        </div>
  
</asp:Content>

