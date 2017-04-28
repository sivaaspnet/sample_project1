<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="progress.aspx.cs" Inherits="superadmin_Attendancebatchcode" Title="Attendance Batch Code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

function batchcode()
{
   if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode").style.backgroundColor="#e8ebd9";
             alert("Please select batch code");
             return false;
         }  
}



</script>
<h4>
                    Progress In Effort</h4>
                        <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
           
    <tr>
        <td colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
            padding-top: 0px; text-align:center;">
      <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label></td>
    </tr>
            <tr>
                <td colspan="3" style="text-align:left;">
                    Select Batch Code
                    <asp:DropDownList ID="ddl_batchcode" runat="server" Width="308px">
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return batchcode();"/>&nbsp;</td>
            </tr>
			</table>
			</div>
			<table cellpadding="0" cellspacing="0" class="common" width="100%">
    <tr>
        <td colspan="3" style="text-align: center">
            <table id="head" runat="server" visible="false">
                <tr>
                    <td style="width: 110px; height: 25px;" align="right" >
                        No Of Class</td>
                    <td style="height: 25px" >
                        <asp:Label ID="lbl_noofclass" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                    <td style="height: 25px" >
                        No Of Student</td>
                    <td style="height: 25px" >
                        <asp:Label ID="lbl_noofstudent" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                        <td style="width: 110px; height: 25px;">
                        Batch Start Date</td>
                    <td style="width: 100px; height: 25px;">
                        <asp:Label ID="lbl_start" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                    <td style="width: 100px; height: 25px;">
                        Batch End Date</td>
                    <td style="width: 100px; height: 25px;">
                        <asp:Label ID="lbl_end" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                </tr>
                
               
            </table>
              <br />
        </td>
      
    </tr>
    <tr>
        <td colspan="3" style="text-align: center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common" OnRowCommand="GridView1_RowCommand" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="StudentID">
                            <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("studentid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="StudentName" />
                    <asp:BoundField HeaderText="Attendance" DataField="present" />
                    <asp:TemplateField HeaderText="Listening">
                        <ItemTemplate>
                            <asp:DropDownList ID="Listening" runat="server">
                             <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="poor">poor</asp:ListItem>
                                <asp:ListItem Value="fair">fair</asp:ListItem>
                                <asp:ListItem Value="good">good</asp:ListItem>
                                <asp:ListItem Value="very good">very good</asp:ListItem>
                                <asp:ListItem Value="excellent">excellent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Tardiness">
                        <ItemTemplate>
                            <asp:DropDownList ID="Tardiness" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="poor">poor</asp:ListItem>
                                <asp:ListItem Value="fair">fair</asp:ListItem>
                                <asp:ListItem Value="good">good</asp:ListItem>
                                <asp:ListItem Value="very good">very good</asp:ListItem>
                                <asp:ListItem Value="excellent">excellent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="UsingTimeWisely">
                        <ItemTemplate>
                            <asp:DropDownList ID="UsingTimeWisely" runat="server">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="poor">poor</asp:ListItem>
                                <asp:ListItem Value="fair">fair</asp:ListItem>
                                <asp:ListItem Value="good">good</asp:ListItem>
                                <asp:ListItem Value="very good">very good</asp:ListItem>
                                <asp:ListItem Value="excellent">excellent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Completing Work">
                        <ItemTemplate>
                            <asp:DropDownList ID="CompletingWork" runat="server">
                                  <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="poor">poor</asp:ListItem>
                                <asp:ListItem Value="fair">fair</asp:ListItem>
                                <asp:ListItem Value="good">good</asp:ListItem>
                                <asp:ListItem Value="very good">very good</asp:ListItem>
                                <asp:ListItem Value="excellent">excellent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Conduct &amp; Behavior">
                        <ItemTemplate>
                            <asp:DropDownList ID="Conduct" runat="server">
                             <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="poor">poor</asp:ListItem>
                                <asp:ListItem Value="fair">fair</asp:ListItem>
                                <asp:ListItem Value="good">good</asp:ListItem>
                                <asp:ListItem Value="very good">very good</asp:ListItem>
                                <asp:ListItem Value="excellent">excellent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="Button2" CommandName="rate" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' runat="server" CssClass="btnstyle1" Text="Rate" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
        </table>


</asp:Content>

