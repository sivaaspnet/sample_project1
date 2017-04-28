<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/Mainmasterpage.master" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="Onlinestudents2_Default" Title="Welcome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >


<div class="welcomecontent" runat="server" style="height:640px; width:100%;">
<center>
<table id="feedback" runat="server" visible="false" >
        <tr>
            <td rowspan="3" style="width: 100px">
                <asp:Image ID="Image1" runat="server" Height="209px" ImageUrl="~/ImageTraining_2/Onlinestudents2/layout/feedback.jpeg"
                    Width="214px" /></td>
            <td style="width: 100px">

    </td>
        </tr>
        <tr>
            <td style="width: 100px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" Width="456px" CssClass="common" Height="174px">
        <Columns>
        <asp:TemplateField HeaderText="Please fill the Feedback form for the below batch" >
        <ItemTemplate>
           <a style="font-size:small; " href="Student_Feedback.aspx?batchcode=<%#Eval("Batch_Code") %>"> <%#Eval("Batch_Code")%>  </a>
        </ItemTemplate>
            <ItemStyle ForeColor="#404040" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Font-Bold="True" Font-Size="Small" ForeColor="#FF8000" />
        </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 18px">
            </td>
        </tr>
    </table>

</center>
<div class="" runat="server"  style="overflow:hidden;"  >



</div>
<br />
<br />
<br />

</div>




</asp:Content>

