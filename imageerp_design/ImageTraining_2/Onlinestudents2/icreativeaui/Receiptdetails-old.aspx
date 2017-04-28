<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Receiptdetails.aspx.cs" Inherits="superadmin_Receiptdetails" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
 function Receipt()
 {
           if(trim(document.getElementById("ContentPlaceHolder1_txt_stuid").value)=="")
         {    
             alert("Please Enter Student ID");
             document.getElementById("ContentPlaceHolder1_txt_stuid").value == "";
             document.getElementById("ContentPlaceHolder1_txt_stuid").focus();
             document.getElementById("ContentPlaceHolder1_txt_stuid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stuid").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if((document.getElementById("ContentPlaceHolder1_ddl_instalnum")) && (document.getElementById("ContentPlaceHolder1_ddl_instalnum").value==""))
         {
              alert("Please select installment number");
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").value == "";
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").focus();
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_instalnum").style.backgroundColor="#e8ebd9";
             return false;
         }
         
 }
 function display()
 {
     document.getElementById("instal").style.display="none"
     document.getElementById("ContentPlaceHolder1_ddl_instalnum").style.display="none"
 }
function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txt_stuid").value="";
location.href="Receiptdetails.aspx";
}
</script>


 <table class="common"> 
            <tr>
                <td colspan="3" style="padding:0px" ><h4>
                    Receipt Details</h4>
                </td>
            </tr>
     <tr>
         <td colspan="3" style=" text-align:center;">
      <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label></td>
     </tr>
            <tr>
                <td style="width: 90px" >
                    Enter Student ID</td>
                <td  colspan="2">
                    <asp:TextBox ID="txt_stuid" CssClass="text" runat="server"></asp:TextBox></td>
            </tr>
     <tr id="studName" visible="false" runat="server">
         <td style="width: 90px">
             Student Name</td>
         <td colspan="2">
             <asp:Label ID="lblstudname" runat="server" Font-Bold="True"></asp:Label></td>
     </tr>
             <tr>
                <td  colspan="3">
                    <asp:GridView ID="GridView1" Width="600" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Instalment No">
                            <ItemTemplate><%#Eval("instal_number")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Receipts">
                            <ItemTemplate>
                            <a rel="modal[]" href="receiptprint.aspx?studid=<%#Eval("student_id")%>&recptno=<%#Eval("Receipt_no")%>&iframe=true&amp;width=100%&amp;height=100%"><%#Eval("Receipt_no")%></a>
                            
                           
                            
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td>
                
            </tr>
     <tr id="instalno" visible="false" runat="server">
         <td colspan="3">
             Number of pending instalments :
             <asp:Label ID="lbl_Instalmentno" runat="server" Font-Bold="True"></asp:Label></td>
     </tr>
     <tr id="Amounttot" visible="false" runat="server">
         <td colspan="3" style="height: 25px">
             Total Pending Amount :
             <asp:Label ID="lblAmount" runat="server" Font-Bold="True"></asp:Label>
             </td>
     </tr>
     <tr id="visfalsefees" runat="server" visible="false">
         <td colspan="3" style="height: 35px">
             <asp:Label ID="lblfeespaid" Font-Size="Large" runat="server" Visible="False" Font-Bold="True"></asp:Label></td>
     </tr>
            <tr id="instal" runat="server">
                <td colspan="3" >
                    <asp:Label ID="lblmsg" runat="server" Text="Select Installment Number"></asp:Label>&nbsp;<asp:DropDownList ID="ddl_instalnum" runat="server">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td  style="text-align:center;" colspan="3">
                   
                    <!--<script type="text/javascript">display();</script>-->
                    &nbsp;<asp:Button ID="btn_submit" runat="server" Text="Add/View Receipt" CssClass="submit" OnClientClick="javascript:return Receipt();" OnClick="btn_submit_Click" />&nbsp;
                    &nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                </td>
                    
            </tr>
        </table>


</asp:Content>

