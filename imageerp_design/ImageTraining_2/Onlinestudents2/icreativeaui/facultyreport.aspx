<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="facultyreport.aspx.cs" Inherits="Onlinestudents2_superadmin_facultyreport" Title="StaffReport" %>
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
			 <div class="free-forms" style="width: 1000px; overflow-x:scroll">
			 
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr align="center">
                <td colspan="4" style="padding:0px; height: 29px;">
                <h4>Faculty Report</h4>
                </td>
            </tr>
            <tr align="center">
                <td >
                    FacultyName:<asp:DropDownList ID="ddl_fac" runat="server" Width="200px">
                    </asp:DropDownList></td>
                <td >
                    StartDate:<asp:TextBox ID="txtfromdate" runat="server" CssClass="text datepicker" MaxLength="20"
                        Width="100px" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></td>
                <td >
                    EndDate:<asp:TextBox ID="txttodate" runat="server" CssClass="text datepicker" MaxLength="20"
                        Width="100px" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
                    
                    <asp:Button ID="submit" runat="server"  OnClientClick="javascript:return selectdate()" CssClass="btnStyle1" OnClick="submit_Click" Text="Submit" /></td>
                    <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 66px; text-align:center;"   >
                     <div class="dataGrid small-fonts">
                    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" BorderColor="#C00000" EmptyDataText="No Record" Width="100%">
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
                    <br />
                    
                    
                 <asp:Repeater id="rpfac" runat="server">

<HeaderTemplate>
	 
	
<table  border="0" cellpadding="0" cellspacing="0"  width="100%">
<%--<tr>
<th><%#Eval("facultyname")%></th>
<th colspan="2" >7AM TO 9AM</th>
<th colspan="2">9AM TO 11AM</th>
<th colspan="2">11AM TO 1PM</th>
<th colspan="2">1PM TO 3PM</th>
<th colspan="2">3PM TO 5PM</th>
<th colspan="2">5PM TO 7PM</th>
<th colspan="2">7PM TO 9PM</th>
</tr>
<tr>
<th ></th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
</tr>--%>
</HeaderTemplate>
<ItemTemplate>
<tr><td colspan="15" style="text-align:center; font-size:16px; color:#fff; font-weight:bold; background-color:Gray; "><span style=" color:#000; font-size:16px; font-weight:bold;">Faculty :</span>  <%#Eval("facultyname")%></td></tr>
<tr>
<th rowspan="2"></th>
<th colspan="2">7AM TO 9AM</th>
<th colspan="2">9AM TO 11AM</th>
<th colspan="2">11AM TO 1PM</th>
<th colspan="2">1PM TO 3PM</th>
<th colspan="2">3PM TO 5PM</th>
<th colspan="2">5PM TO 7PM</th>
<th colspan="2">7PM TO 9PM</th>
</tr>
<tr> 
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
<th >MWF</th>
<th >TTS</th>
</tr>
<tr>
<th style=" background-color:#CCCCCC"  align="center" valign="middle">BatchCode</th>
<td><%#Eval("sevenmwfbc")%> </td>
<td><%#Eval("seventtsbc")%> </td>
<td  style="background:#f7f7f7"><%#Eval("ninemwfbc")%> </td>
<td style="background:#f7f7f7"> <%#Eval("ninettsbc")%></td>
<td><%#Eval("elevenmwfbc")%> </td>
<td><%#Eval("eleventtsbc")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmmwfbc")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmttsbc")%> </td>
<td><%#Eval("threepmmwfbc")%> </td>
<td><%#Eval("threepmttsbc")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmmwfbc")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmttsbc")%> </td>
<td><%#Eval("sevenpmmwfbc")%> </td>
<td><%#Eval("sevenpmttsbc")%> </td>
</tr>
<tr>
<th style=" background-color:#CCCCCC"  align="center" valign="middle">Batch Start Date</th>
<td><%#Eval("sevenmwfsd")%> </td>
<td><%#Eval("seventtssd")%> </td>
<td style="background:#f7f7f7"><%#Eval("ninemwfsd")%> </td>
<td style="background:#f7f7f7"><%#Eval("ninettssd")%> </td>
<td><%#Eval("elevenmwfsd")%> </td>
<td><%#Eval("eleventtssd")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmmwfsd")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmttssd")%> </td>
<td><%#Eval("threepmmwfsd")%> </td>
<td><%#Eval("threepmttssd")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmmwfsd")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmttssd")%> </td>
<td><%#Eval("sevenpmmwfsd")%> </td>
<td><%#Eval("sevenpmttssd")%> </td>
</tr>

<tr>
<th style=" background-color:#CCCCCC"  align="center" valign="middle">No. Of Student</th>
<td><%#Eval("sevenmwfnos")%>  </td>
<td><%#Eval("seventtsnos")%>  </td>
<td style="background:#f7f7f7"><%#Eval("ninemwfnos")%>  </td>
<td style="background:#f7f7f7"> <%#Eval("ninettsnos")%> </td>
<td><%#Eval("elevenmwfnos")%> </td>
<td><%#Eval("eleventtsnos")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmmwfnos")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmttsnos")%> </td>
<td><%#Eval("threepmmwfnos")%> </td>
<td><%#Eval("threepmttsnos")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmmwfnos")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmttsnos")%> </td>
<td><%#Eval("sevenpmmwfnos")%> </td>
<td><%#Eval("sevenpmttsnos")%> </td>
</tr>
<tr>
<th style=" background-color:#CCCCCC"  align="center" valign="middle">Lab</th>
<td><%#Eval("sevenmwfln")%></td>
<td><%#Eval("seventtsln")%>  </td>
<td style="background:#f7f7f7"><%#Eval("ninemwfln")%>  </td>
<td style="background:#f7f7f7"><%#Eval("ninettsln")%>  </td>
<td><%#Eval("elevenmwfln")%> </td>
<td><%#Eval("eleventtsln")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmmwfln")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmttsln")%> </td>
<td><%#Eval("threepmmwfln")%> </td>
<td><%#Eval("threepmttsln")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmmwfln")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmttsln")%> </td>
<td><%#Eval("sevenpmmwfln")%> </td>
<td><%#Eval("sevenpmttsln")%> </td>
</tr>
<tr>
<th style=" background-color:#CCCCCC"  align="center" valign="middle">Batch End Date</th>
<td><%#Eval("sevenmwfed")%> </td>
<td><%#Eval("seventtsed")%> </td>
<td style="background:#f7f7f7"><%#Eval("ninemwfed")%> </td>
<td style="background:#f7f7f7"><%#Eval("ninettsed")%> </td>
<td><%#Eval("elevenmwfed")%> </td>
<td><%#Eval("eleventtsed")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmmwfed")%> </td>
<td style="background:#f7f7f7"><%#Eval("onepmttsed")%> </td>
<td><%#Eval("threepmmwfed")%> </td>
<td><%#Eval("threepmttsed")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmmwfed")%> </td>
<td style="background:#f7f7f7"><%#Eval("fivepmttsed")%> </td>
<td><%#Eval("sevenpmmwfed")%> </td>
<td><%#Eval("sevenpmttsed")%> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>

</FooterTemplate>

</asp:Repeater>
                  </div>
                    <asp:LinkButton ID="lnkdownload" runat="server" Visible="False" OnClick="lnkdownload_Click">Download Excel</asp:LinkButton>&nbsp;
                    <asp:Literal ID="literals1" runat="server" Visible="False"></asp:Literal></td>
            </tr>
        </table>
		</div>
  
</asp:Content>

