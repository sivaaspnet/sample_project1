<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="receiptconfirmation.aspx.cs" Inherits="superadmin_Receiptdetails" Title="Receipt Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
	        	             
 function chkval()
   {
       if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "Cash")
          {
            document.getElementById("ContentPlaceHolder1_txt_ddcc").value=""
            document.getElementById("ContentPlaceHolder1_txt_bankname").value=""
          }
   }
    function losefocus(obj)
    {
       if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "Cash")
         {
          obj.value="";
          obj.blur()
         }
    }
   
 function Receipt()
 {

        if(document.getElementById("ContentPlaceHolder1_ddl_month").value=="")
         {    
             alert("Please select Month");
             document.getElementById("ContentPlaceHolder1_ddl_month").value = "";
             document.getElementById("ContentPlaceHolder1_ddl_month").focus();
             document.getElementById("ContentPlaceHolder1_ddl_month").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_month").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value=="")
         {    
             alert("Please Select Payment mode");
             document.getElementById("ContentPlaceHolder1_ddl_paymode").value == "";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_paymode").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_ddcc").value == "")
         {    
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_dddate").value == "")
         {    
             alert("Please enter cheque number");
             document.getElementById("ContentPlaceHolder1_txt_ddcc").value = "";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").focus();
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_ddcc").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(document.getElementById("ContentPlaceHolder1_ddl_paymode").value!="Cash" && document.getElementById("ContentPlaceHolder1_txt_bankname").value == "")
         {    
             alert("Please enter Bank name");
             document.getElementById("ContentPlaceHolder1_txt_bankname").value = "";
             document.getElementById("ContentPlaceHolder1_txt_bankname").focus();
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_bankname").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else
         {
        
         return true;
         }
         
 }

</script>


 <table class="common" style="width: 356px"> 
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
         <td colspan="3" style="height: 25px">
             <strong style="color: blue">
                 <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/warning_48.png" />
                 &nbsp;&nbsp; Note : Receipt will be generated for the amount &nbsp;<asp:Label ID="Label2"
                     runat="server" ForeColor="#C00000"></asp:Label>
                 with tax</strong></td>
     </tr>
     <tr>
         <td colspan="1" style="height: 25px; width: 151px;">
             <strong>Invoice No</strong></td>
         <td colspan="3" style="height: 25px; width: 227px;">
             &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
     </tr>
            <tr>
                <td colspan="1" style="height: 25px; width: 151px;">
                    <strong>Receipt With Amount : </strong>
                </td>
                <td colspan="3" style="height: 25px; width: 227px;">
                    <asp:Label ID="lbl_amt" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            </tr>
     <tr runat="server" >
         <td style="width: 151px; height: 29px">
             <strong>Month Installment :</strong></td>
         <td colspan="2" style="width: 20px; height: 29px">
             <asp:DropDownList ID="ddl_month" runat="server">
                 <asp:ListItem Value="">--Select--</asp:ListItem>
                 <asp:ListItem Value="Jan">Jan</asp:ListItem>
                 <asp:ListItem Value="Feb">Feb</asp:ListItem>
                 <asp:ListItem Value="Mar">Mar</asp:ListItem>
                 <asp:ListItem Value="Apr">Apr</asp:ListItem>
                 <asp:ListItem Value="May">May</asp:ListItem>
                 <asp:ListItem Value="Jun">Jun</asp:ListItem>
                 <asp:ListItem Value="Jul">Jul</asp:ListItem>
                 <asp:ListItem Value="Aug">Aug</asp:ListItem>
                 <asp:ListItem Value="Sep">Sep</asp:ListItem>
                 <asp:ListItem Value="Oct">Oct</asp:ListItem>
                 <asp:ListItem Value="Nov">Nov</asp:ListItem>
                 <asp:ListItem Value="Dec">Dec</asp:ListItem>
             </asp:DropDownList></td>
     </tr>
     <tr id="studName"  runat="server">
         <td style="width: 151px; height: 29px;">
             <strong>Payment Mode :</strong></td>
         <td colspan="2" style="width: 20px; height: 29px;">
                    <asp:DropDownList ID="ddl_paymode" runat="server" onChange="chkval()">
                 <asp:ListItem Value="">--Select--</asp:ListItem>
                 <asp:ListItem Value="Cash">Cash</asp:ListItem>
                 <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                 <asp:ListItem Value="D.D">D.D</asp:ListItem>
                 <asp:ListItem Value="C.C">C.C</asp:ListItem>
             </asp:DropDownList>
             </td>
     </tr>
     <tr runat="server" >
         <td style="width: 151px; height: 29px">
             <strong>Cheque / D.D No / C.C No</strong></td>
         <td colspan="2" style="width: 20px; height: 29px">
             <asp:TextBox ID="txt_ddcc" runat="server" CssClass="text" MaxLength="20" onfocus="losefocus(this)"></asp:TextBox></td>
     </tr>
     <tr runat="server" >
         <td style="width: 151px; height: 29px">
             <strong>checque/D.D&nbsp; Date</strong></td>
         <td colspan="2" style="width: 20px; height: 29px">
             <asp:TextBox ID="dddate" runat="server" CssClass="text datepicker" Width="123px" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
     </tr>
     <tr runat="server" >
         <td style="width: 151px; height: 29px">
             <strong>Bank Name</strong></td>
         <td colspan="2" style="width: 20px; height: 29px">
             <asp:TextBox ID="txt_bankname" runat="server" CssClass="text" MaxLength="30" onfocus="losefocus(this)"></asp:TextBox></td>
     </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button
                        ID="Button1" runat="server" CssClass="submit" OnClientClick="javascript:return Receipt();" OnClick="Button1_Click" Text="Generate Receipt" />
                    <asp:Button ID="Button2" runat="server" CssClass="submit" OnClick="Button2_Click"
                        Text="Cancel" /><!--<script type="text/javascript">display();</script>-->
                    &nbsp; &nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                </td>
                    
            </tr>
        </table>


</asp:Content>

