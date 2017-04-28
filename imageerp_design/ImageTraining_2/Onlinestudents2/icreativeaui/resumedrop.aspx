<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="resumedrop.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReport" Title="Student Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function Validate()
     {
  
         if(document.getElementById("ContentPlaceHolder1_txt_studentid").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_studentid").value=="";   
             document.getElementById("ContentPlaceHolder1_lbl_error").innerHTML ='*Please Enter the StudentID!';
             document.getElementById("ContentPlaceHolder1_txt_studentid").focus();
             document.getElementById("ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9";
             return false;
         }
        else
        {
        return true;
        }
       
        
  }

</script>
    <br />
    <table class="common" id="Table2" >
        <tr>
            <td align="center" bgcolor="#666666" colspan="3" style="padding-right: 0pc; padding-left: 0pc;
                padding-bottom: 0pc; padding-top: 0pc; height: 47px; text-align: center" valign="middle">
                  <h4>
                      View Dropped Student &nbsp;</h4>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="text-align: center">
                <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 10px; height: 32px">
            </td>
            <td align="left" style="height: 32px; width: 122px;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="StudentID : "></asp:Label>
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return Validate();"  CssClass="search" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td align="center" style="width: 10px; text-align: center">
            </td>
            <td align="center" style=" text-align:center;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" EmptyDataText="No Record ">
                    <Columns>
                        <asp:BoundField DataField="student_id" HeaderText="StudentID" />
                        <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                        <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        <asp:TemplateField HeaderText="Resume">
                        <ItemTemplate>
                          <asp:LinkButton ID="lnkedit" CommandName="lnkedit" CommandArgument='<%#Eval("student_id")%>' runat="server"><img src="layout/refresh_icon.gif" /></asp:LinkButton> 
                        </ItemTemplate>
                          </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div style=" max-height:400px; overflow:auto;">      &nbsp;</div>

</asp:Content>

