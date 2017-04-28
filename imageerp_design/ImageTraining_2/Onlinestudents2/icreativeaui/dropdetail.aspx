<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="dropdetail.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReport" Title="Student Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function Validate()
     {
  
         if(document.getElementById("ContentPlaceHolder1_ddl_reason").value=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_reason").value=="";   
             document.getElementById("ContentPlaceHolder1_lbl_error").innerHTML ='*Please Select Reason For Dropping Student!';
             document.getElementById("ContentPlaceHolder1_ddl_reason").focus();
             document.getElementById("ContentPlaceHolder1_ddl_reason").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_reason").style.backgroundColor="#e8ebd9";
             return false;
         }
        else
        {
        return true;
        }
       
        
  }

</script>
    <br />
    
    
    <table class="common" id="Table2" style="width: 419px" >
        <tr>
            <td align="center" style="font-size: 12px; color: blue; text-align: center">
            </td>
            <td align="center" style="font-size: 12px;  color: blue; 
                text-align: center">
                <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="font-size: 12px; color: blue">
                <asp:Image ID="Image1" runat="server" Height="67px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/warning_48.png"
                    Width="59px" /></td>
            <td  style=" font-size: 12px;  color: blue; ">
                <strong>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="Are you sure ?"></asp:Label>
                    You want to drop the student from ERP system.by clicking drop
                    button student will be dropped from ERP system.you wont be able to cut receipts,allocate
                    batch for the student.</strong></td>
        </tr>
        <tr>
            <td align="left" style="height: 23px">
            </td>
            <td align="left" style="height: 23px">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View Student Report</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" style="height: 23px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Reason :"></asp:Label></td>
            <td align="left" style="height: 23px">
                <asp:DropDownList ID="ddl_reason" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_reason_SelectedIndexChanged">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Higher studies">Higher studies</asp:ListItem>
                    <asp:ListItem Value="Finance Problem">Finance Problem</asp:ListItem>
                    <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="text" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left" style="">
                <br />
                <asp:TextBox ID="txt_reason" runat="server" CssClass="text" TextMode="MultiLine" Width="343px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center" style="text-align: center">
            </td>
            <td align="center"  style=" text-align:center;">
                <asp:Button ID="Button1" runat="server" OnClientClick="javascript:return Validate();"  CssClass="submit" OnClick="Button1_Click1"
                    Text="Request" />&nbsp;
                <asp:Button ID="Button3" runat="server" CssClass="submit" OnClick="Button3_Click"
                    Text="Accept" Visible="False" />&nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="submit" OnClick="Button2_Click"
                    Text="Decline" /></td>
        </tr>
    </table>
    <br />
    <br />
    <div style=" max-height:400px; overflow:auto;">      &nbsp;</div>

</asp:Content>

