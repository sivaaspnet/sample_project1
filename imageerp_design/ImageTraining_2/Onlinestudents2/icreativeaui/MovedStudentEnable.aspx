<%@ Page Title="" Language="C#" MasterPageFile="~/ImageTraining_2/Onlinestudents2/icreativeaui/1imagemasterpage.master" AutoEventWireup="true" CodeFile="MovedStudentEnable.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_img_auth_Moveoldstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">


    function CheckNumeric(GetEvt) {
        var Char = (GetEvt.which) ? GetEvt.which : event.keyCode

        if (Char > 31 && (Char < 48 || Char > 57))
            return false;
        return true;
    }

    function vali() {


    }
</script>
  <div class="free-forms"> 


  <div id="vieww" >
        <table class="common" width="100%" id="">
        <tr>
            <td style="padding:0px;" colspan="2" > <h4>
      Old Student Details</h4></td>
        </tr>
        <tr>
            <td style="padding:0px;" > &nbsp;</td>
            <td>
                <asp:HiddenField ID="hdnid" runat="server" />
                <asp:Label ID="lblerror" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
            </td>
        </tr>
             </table>
   </div>



      <table class="common" width="100%">
       <tr>
            <td style="padding:0px;" > <h4>
   </h4>
            </td>
            <td></td>
            <td>
                <asp:LinkButton ID="LinkButton6" runat="server" 
                    PostBackUrl="~/ImageTraining_2/Onlinestudents2/icreativeaui/Moveoldstudent.aspx">Move Student To New Application.</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="padding:0px;" > <h4>
      Old Student Details</h4>
            </td>
            <td></td>
            <td>&nbsp;</td>
        </tr>
      <tr>
            <td style="padding:0px;" > 
            Student Id
            </td>
            <td>
                <asp:TextBox ID="txtsearchid" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click"  CssClass="btnStyle1" Text="Search" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
   </table>
    
    
    <asp:GridView ID="GridView1" runat="server"  CssClass="common" 
        AllowPaging="True" AutoGenerateColumns="False" 
        onpageindexchanging="GridView1_PageIndexChanging" 
          onrowcommand="GridView1_RowCommand" Width="976px">
        <Columns>
            <asp:BoundField DataField="Oldstudentid" HeaderText="Oldstudentid" />
             <asp:BoundField DataField="Studentname" HeaderText="Studentname" />


              <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
               <asp:BoundField DataField="Course" HeaderText="Course" />
 <asp:BoundField DataField="Invoiceid" HeaderText="Invoice No" />
  <asp:BoundField DataField="Coursefee" HeaderText="Coursefee" />
 <asp:BoundField DataField="Paidamt" HeaderText="Paidamt(Without Tax)" />

 <asp:BoundField DataField="Currentcoursefee" HeaderText="Currentcoursefee" />
 <asp:BoundField DataField="Centrecode" HeaderText="Centrecode" />
        
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>

                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="lnkhide" CommandArgument='<%#Eval("id")%>'>UnHide</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
    </asp:GridView>

 
    
   </div>
</asp:Content>

