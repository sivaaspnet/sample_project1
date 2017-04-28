<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="CourseWare.aspx.cs" Inherits="Onlinestudents2_superadmin_CourseWare" Title="CourseWare Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">


function SearchValidate()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").value=="" && document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").value=="" )
         {
         
            
             document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").style.backgroundColor="#e8ebd9";
             return false;
         } 
      
        else
        {
        return true;
        }

}

</script>


    <br />
    
    <br />
    <table class="common">
        <tr>
            <td colspan="2" style="padding:0px;"><h4>CourseWare Details</h4>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Searchby Name"></asp:Label>    <br />                
                <asp:TextBox ID="txtnamesearch" runat="server" CssClass="text"></asp:TextBox>&nbsp;</td>
                <td>
                <asp:Label ID="Label2" runat="server" Text="Searchby Book Status"></asp:Label><br />
                <asp:DropDownList ID="txtrolesearch" runat="server" Width="121px">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                    <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Button ID="btnsearch" runat="server" CssClass="search" OnClientClick="javascript:return SearchValidate();" OnClick="btnsearch_Click" />&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="common" EmptyDataText="No Results Found" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnRowCommand="GridView1_RowCommand" PageSize="25">
        <Columns>
            <asp:BoundField DataField="student_id" HeaderText="Student ID" />
            <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
            <asp:TemplateField HeaderText="Course">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("student_id") %>'
                        CommandName="Course"><%#Eval("coursename")%></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="bookstatus" HeaderText="Book Status" />
            
        </Columns>
        <PagerSettings Position="TopAndBottom" />
        <EmptyDataRowStyle ForeColor="Red" />
    </asp:GridView>
    <br />
    <br />
    <br />
</asp:Content>

