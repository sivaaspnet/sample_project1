<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Insertinvoice.aspx.cs" Inherits="superadmin_Insertinvoice" Title="Insert Invoice Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}
function checktxt()
{
    document.getElementById("ContentPlaceHolder1_lbltotinstal_tax").innerHTML ="Click on to calculate";
    document.getElementById("ContentPlaceHolder1_lblamountpaid").innerHTML ="";
}

function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}     
function createinsvalidate()
{

    clearValidation('ContentPlaceHolder1_ddlnoofinstal~ContentPlaceHolder1_txtinstallmentamt~ContentPlaceHolder1_txtinstal_tax');
         if(trim(document.getElementById("ContentPlaceHolder1_ddlnoofinstal").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddlnoofinstal").value=="";   
             document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML ='*Please Select the No of Installments!';
             document.getElementById("ContentPlaceHolder1_ddlnoofinstal").focus();
             document.getElementById("ContentPlaceHolder1_ddlnoofinstal").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlnoofinstal").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txtinstallmentamt").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtinstallmentamt").value=="";   
             document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML ='*Please Enter the Installment Amount!';
             document.getElementById("ContentPlaceHolder1_txtinstallmentamt").focus();
             document.getElementById("ContentPlaceHolder1_txtinstallmentamt").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstallmentamt").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_lbltotinstal_tax").innerHTML)=='Click on to calculate')
         {
             document.getElementById("ContentPlaceHolder1_lblerrmsg").innerHTML ='*Please click on calculate button!';
           
             return false;
         }
       else
       {
       return true;
       
       }



}
</script>
    <table  class="common">
        <tr>
            <td colspan="3" style="padding:0px;"><h4>Create Installments</h4>
            </td>
            
        </tr>
        <tr>
            <td colspan="3" style="text-align: center;">
                <asp:Label ID="lblerrmsg"  runat="server" Text='' CssClass="error"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 179px">
                No of Installments to be added</td>
            <td colspan="2">
                <asp:DropDownList CssClass="select" ID="ddlnoofinstal" runat="server">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                   
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 179px">
                Centre Code</td>
            <td colspan="2">
                <asp:Label ID="lblcentrecode" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 179px">
                Invoice no</td>
            <td colspan="2">
                <asp:Label ID="lblinvoiceno" runat="server" Text=''></asp:Label></td>
        </tr>
            <tr>
            <td class="w290 talignleft" style="width: 179px">
                Student ID</td>
            <td colspan="2">
                <asp:Label ID="lblstudentid" runat="server" Text=''></asp:Label></td>
        </tr>
            <tr>
            <td class="w290 talignleft" style="width: 179px">
                Course ID</td>
            <td colspan="2">
                <asp:Label ID="lblcourseid" runat="server" Text=''></asp:Label></td>
        </tr>
            <tr>
            <td class="w290 talignleft" style="width: 179px">
                Monthly
                Installment amount</td>
            <td colspan="2">
                <asp:TextBox ID="txtinstallmentamt" onKeyPress="return CheckNumeric(event);" onKeyUp="checktxt()" CssClass="text"  runat="server" MaxLength="5"></asp:TextBox></td>
        </tr>
            <tr>
            <td class="w290 talignleft" style="width: 179px">
                Tax</td>
            <td colspan="2">
                <asp:Label ID="txtinstal_tax" runat="server" Text="10.3"></asp:Label>
                <asp:Label ID="hdntaxamt" runat="server" Visible="false" Text=''></asp:Label>
               </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 179px">
                Total Installment Amount</td>
            <td colspan="2">
                <asp:Label ID="lbltotinstal_tax" runat="server" Text='Click on to calculate'></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" CssClass="submit" OnClick="Button3_Click"
                    Text="calculate" /></td>
        </tr>
         
        <tr>
            <td class="w290 talignleft" style="width: 179px">
               Total Amount paid</td>
            <td colspan="2">
                <asp:Label ID="lblamountpaid" runat="server" Text=''></asp:Label>
               </td>
        </tr>
        <tr>
            <td class="w290 talignleft" colspan="3">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
                <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Add" OnClick="Button1_Click" OnClientClick="javascript:return createinsvalidate();" />&nbsp;&nbsp;
<%--                <input id="Reset1" class="submit" visible="false" type="reset" value="Reset" />&nbsp;&nbsp;
--%>                <asp:Button ID="Button2" runat="server" CssClass="submit" Text="Back" OnClick="Button2_Click" /></td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

