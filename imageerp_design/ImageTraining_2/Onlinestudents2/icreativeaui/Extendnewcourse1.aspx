<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Extendnewcourse1.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Extendnewcourse" Title="Extend new course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txtStudentId").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
<script language="javascript" type="text/javascript">
function CheckNumeric(GetEvt)
  {
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
  }


 function validate()
 {
           if( document.getElementById("ContentPlaceHolder1_txtStudentId").value =="")
         {    
             alert("Please Enter Student ID");
             document.getElementById("ContentPlaceHolder1_txtStudentId").value == "";
             document.getElementById("ContentPlaceHolder1_txtStudentId").focus();
             document.getElementById("ContentPlaceHolder1_txtStudentId").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtStudentId").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if((document.getElementById("ContentPlaceHolder1_ddlcourse").value==""))
         {
              alert("Please select course name");
             document.getElementById("ContentPlaceHolder1_ddlcourse").value == "";
             document.getElementById("ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_ddltrack").value==""))
         {
              alert("Please select track");
             document.getElementById("ContentPlaceHolder1_ddltrack").value == "";
             document.getElementById("ContentPlaceHolder1_ddltrack").focus();
             document.getElementById("ContentPlaceHolder1_ddltrack").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddltrack").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_ddlbatch").value==""))
         {
              alert("Please select batch time");
             document.getElementById("ContentPlaceHolder1_ddlbatch").value == "";
             document.getElementById("ContentPlaceHolder1_ddlbatch").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_txtinstallnumber").value==""))
         {
              alert("Please enter installment number");
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").value == "";
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").focus();
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_txtstartdate").value==""))
         {
              alert("Please select course start date");
             document.getElementById("ContentPlaceHolder1_txtstartdate").value == "";
             document.getElementById("ContentPlaceHolder1_txtstartdate").focus();
             document.getElementById("ContentPlaceHolder1_txtstartdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtstartdate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
 }
 </script>
 	<div class="free-forms">
<table  class="common" width="100%" cellpadding="0" cellspacing="0">
    <tr>
	<td colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px">
	<h4> Extend to New Course</h4>
	</td>
	</tr>
  	<tr>
        <td colspan="2" style="padding:0">
            <asp:Label ID="lblerrormsg" runat="server" CssClass="error"></asp:Label></td>
        </tr>

      <tr>
        <td  class="formlabel">Student Id</td>
        <td><asp:TextBox ID="txtStudentId" runat="server" CssClass="text"></asp:TextBox></td>
      </tr>

      <tr>
        <td class="formlabel">Course Name</td>
        <td><asp:DropDownList ID="ddlcourse" runat="server">
            </asp:DropDownList>
            <asp:HiddenField ID="hiddennewcoursefees" runat="server" />
            
        </td>
      </tr>

      <tr>
            <td class="formlabel">
                Track</td>
            <td  style="height: 18px" valign="middle">
                <asp:DropDownList ID="ddltrack" runat="server">
                <asp:ListItem Value="Normal">Normal</asp:ListItem>
                <asp:ListItem Value="Fast">Fast</asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr>
            <td class="formlabel">
                Batch Time</td>
            <td>
                <asp:DropDownList ID="ddlbatch" runat="server">
                <asp:ListItem Value="7AM-9AM">7AM-9AM</asp:ListItem>
                <asp:ListItem Value="9AM-11AM">9AM-11AM</asp:ListItem>
                <asp:ListItem Value="11AM-1PM">11AM-1PM</asp:ListItem>
                <asp:ListItem Value="1PM-3PM">1PM-3PM</asp:ListItem>
                <asp:ListItem Value="3PM-5PM">3PM-5PM</asp:ListItem>
                <asp:ListItem Value="5PM-7PM">5PM-7PM</asp:ListItem>
                <asp:ListItem Value="7PM-9PM">7PM-9PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr>
            <td  class="formlabel">
                Total Install Number</td>
            <td>
               <asp:TextBox ID="txtinstallnumber" MaxLength="2" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="formlabel">
                Course start date</td>
            <td>
               <asp:TextBox ID="txtstartdate" runat="server" CssClass="datepicker text"></asp:TextBox></td>
        </tr>

      	<tr>
        	<td>
        	<asp:HiddenField ID="hiddenbalanceinitial" runat="server" />
            <asp:HiddenField ID="hiddencoursefees" runat="server" />
        	<asp:HiddenField ID="hiddentax" runat="server" />
            <asp:HiddenField ID="hiddencourse" runat="server" />
            <asp:HiddenField ID="hiddeninstall" runat="server" />
            <asp:HiddenField ID="hiddeninvoice" runat="server" />
            <asp:HiddenField ID="hiddenstartinginstallno" runat="server" />
        </td>
        <td  valign="middle">
           <asp:Button ID="btnSubmit" runat="server" Text="Sumbit" OnClientClick="javascript:return validate();"   CssClass="btnStyle1" OnClick="btnSubmit_Click" />
            </td>
      </tr>
</table>
</div>
</asp:Content>

