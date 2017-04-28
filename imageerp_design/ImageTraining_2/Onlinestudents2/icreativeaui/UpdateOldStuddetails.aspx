<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="UpdateOldStuddetails.aspx.cs" Inherits="superadmin_UpdateOldStuddetails" Title="Student Details" %>
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




 function Search()
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
         
         
 }




function validateupdate()
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
          if(trim(document.getElementById("ContentPlaceHolder1_txt_studname").value)=="")
         {    
             alert("Please Enter Student Name");
             document.getElementById("ContentPlaceHolder1_txt_studname").value == "";
             document.getElementById("ContentPlaceHolder1_txt_studname").focus();
             document.getElementById("ContentPlaceHolder1_txt_studname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_studname").style.backgroundColor="#e8ebd9";
             return false;
         }
          if(trim(document.getElementById("ContentPlaceHolder1_txt_addr").value)=="")
         {    
             alert("Please Enter the address");
             document.getElementById("ContentPlaceHolder1_txt_addr").value == "";
             document.getElementById("ContentPlaceHolder1_txt_addr").focus();
             document.getElementById("ContentPlaceHolder1_txt_addr").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_addr").style.backgroundColor="#e8ebd9";
             return false;
         }
          if(trim(document.getElementById("ContentPlaceHolder1_txt_mob").value)=="")
         {    
             alert("Please Enter the mobile no");
             document.getElementById("ContentPlaceHolder1_txt_mob").value == "";
             document.getElementById("ContentPlaceHolder1_txt_mob").focus();
             document.getElementById("ContentPlaceHolder1_txt_mob").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_mob").style.backgroundColor="#e8ebd9";
             return false;
         }
          if(trim(document.getElementById("ContentPlaceHolder1_ddlCourse_Id").value)=="")
         {    
             alert("Please select course id");
             document.getElementById("ContentPlaceHolder1_ddlCourse_Id").value == "";
             document.getElementById("ContentPlaceHolder1_ddlCourse_Id").focus();
             document.getElementById("ContentPlaceHolder1_ddlCourse_Id").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlCourse_Id").style.backgroundColor="#e8ebd9";
             return false;
         }
          if(trim(document.getElementById("ContentPlaceHolder1_txt_coursefees").value)=="")
         {    
             alert("Please enter the course fees");
             document.getElementById("ContentPlaceHolder1_txt_coursefees").value == "";
             document.getElementById("ContentPlaceHolder1_txt_coursefees").focus();
             document.getElementById("ContentPlaceHolder1_txt_coursefees").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_coursefees").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         
 }
</script>


 <table class="common" width="600px"> 
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
                    Student ID</td>
                <td  colspan="2">
                    <asp:TextBox ID="txt_stuid" CssClass="text" MaxLength="20" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClientClick="javascript:return Search();" Text="Search" CssClass="submit" OnClick="Button1_Click" /></td>
            </tr>
     <tr>
         <td style="width: 90px">
             Center Code</td>
         <td colspan="2">
             <asp:TextBox ID="txt_Centercode" runat="server" CssClass="text" MaxLength="20"></asp:TextBox></td>
     </tr>
     <tr >
         <td style="width: 90px">
             Student Name</td>
         <td colspan="2">
             <asp:TextBox ID="txt_studname" runat="server" MaxLength="75" CssClass="text"></asp:TextBox></td>
     </tr>
     <tr>
         <td style="width: 90px">
             Address</td>
         <td colspan="2">
             <asp:TextBox ID="txt_addr" runat="server" MaxLength="500" CssClass="text" Height="93px" TextMode="MultiLine"
                 Width="281px"></asp:TextBox></td>
     </tr>
     <tr >
         <td style="width: 90px">
             Mobile</td>
         <td colspan="2">
             <asp:TextBox ID="txt_mob" runat="server" MaxLength="12" onKeyPress="return CheckNumeric(event)" CssClass="text"></asp:TextBox></td>
     </tr>
     <tr >
         <td style="width: 90px">
             Course ID</td>
         <td colspan="2">
             <asp:DropDownList ID="ddlCourse_Id" runat="server">
             </asp:DropDownList></td>
     </tr>
     <tr >
         <td style="width: 90px">
             Course Fees</td>
         <td colspan="2">
             <asp:TextBox ID="txt_coursefees" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text" MaxLength="20"></asp:TextBox></td>
     </tr>
             <tr>
                <td  colspan="3">
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td  style="text-align:center;" colspan="3">
                   
                    <!--<script type="text/javascript">display();</script>-->
                    &nbsp;<asp:Button ID="btn_submit"  runat="server" Text="Update" CssClass="submit" OnClientClick="javascript:return validateupdate();" OnClick="btn_submit_Click" />&nbsp;
                    &nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                </td>
                    
            </tr>
        </table>


</asp:Content>

