<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="studentbatch.aspx.cs" Inherits="superadmin_Viewbatch" Title="View Batch Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button3_onclick() {
document.getElementById("ContentPlaceHolder1_ddllab").value = "";
document.getElementById("ContentPlaceHolder1_ddlslot").value = "";
}

// ]]>
function valbatch()
{
if(document.getElementById("ContentPlaceHolder1_ddllab").value == "")
{
alert("Please select the lab name")
document.getElementById("ContentPlaceHolder1_ddllab").focus();
return false;
}
else if(document.getElementById("ContentPlaceHolder1_ddlslot").value == "")
{
alert("Please select the slot name")
document.getElementById("ContentPlaceHolder1_ddlslot").focus();
return false;
}
else
{
return true;
}
}
</script>
    
    <p>&nbsp;
        </p>
    <p><div class="free-forms">
        <table class="common" style="width: 100%; height: 441px;">
            <tr >
                <td colspan="5" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                    padding-top: 0px; height: 43px">
                    <h4>
                        Batch Report  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp;
                       
                        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Back" OnClick="Button1_Click" /></h4>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 213px;">
                    <asp:Label ID="batchcode" runat="server" Font-Bold="True" ForeColor="Maroon" Text="FacultyName:"></asp:Label>
                    <asp:Label ID="lbl_fac" runat="server"></asp:Label></td>
                <td colspan="1">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Slot:"></asp:Label>
                    <asp:Label ID="lbl_slot" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 213px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="LabName:"></asp:Label>
                    <asp:Label ID="lbl_lab" runat="server"></asp:Label></td>
                <td colspan="1">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Maroon" Text="BatchTiming:"></asp:Label>
                    <asp:Label ID="lbl_batch" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="5" style="text-align: center">
                    &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="content" HeaderText="content" />
                            <asp:BoundField DataField="classdate" HeaderText="ClassDate" />
                            <asp:BoundField DataField="status" HeaderText="status" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="5" style="text-align: center">
                    <table class="common" style="width: 100%">
                        <tr>
                            <td colspan="4" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                padding-top: 0px">
                                <h4>
                                    Progress In Effort</h4>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px">
                                <strong>Listening</strong></td>
                            <td style="width: 100px">
                                <asp:Label ID="lbl_listening" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="Label9" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px"
                                    Width="59px"></asp:Label></td>
                            <td style="font-weight: bold; width: 100px">
                            </td>
                        </tr>
                        <tr style="font-weight: bold">
                            <td style="width: 149px">
                                Tardiness</td>
                            <td style="width: 100px">
                                <asp:Label ID="lbl_tardiness" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="Label10" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px"
                                    Width="59px"></asp:Label></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px">
                                <strong>UsingTimeWisely</strong></td>
                            <td style="width: 100px">
                                <asp:Label ID="lbl_using" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="Label11" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px"
                                    Width="59px"></asp:Label></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px">
                                <strong>Completing Work</strong></td>
                            <td style="width: 100px">
                                <asp:Label ID="lbl_work" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="Label12" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px"
                                    Width="59px"></asp:Label></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px">
                                <strong>Conduct &amp; Behavior</strong></td>
                            <td style="width: 100px">
                                <asp:Label ID="lbl_conduct" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="Label13" runat="server" BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px"
                                    Width="59px"></asp:Label></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
		</div>
    </p>
    <p>&nbsp;
        </p>



</asp:Content>

