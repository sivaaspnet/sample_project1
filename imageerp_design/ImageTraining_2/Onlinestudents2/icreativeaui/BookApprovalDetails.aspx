<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="BookApprovalDetails.aspx.cs" Inherits="Onlinestudents2_superadmin_BookApprovalDetails" Title="Book Approval Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    
    
    function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}
    
    
     function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
    
    function ValidateBookApproval()
    {
    
 
        if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtCourier").value)=="")
            {
                alert("Enter the Courier Company Name");    
                document.getElementById("ctl00_ContentPlaceHolder1_txtCourier").focus();
                return false;
                
            }
        else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtTracking").value)=="")
            {
                alert("Enter the Tracking ID");
                document.getElementById("ctl00_ContentPlaceHolder1_txtTracking").focus();
                return false;    
            }
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtContact").value)=="")
            {
                alert("Enter the Contact Person Name");
                document.getElementById("ctl00_ContentPlaceHolder1_txtContact").focus();
                return false;    
            }
            else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value)=="")
			{
				alert("Enter your mobile number");
				document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").focus();
				return false;
			}
			
    		else if(document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value.length<10)
 		  	{
				 alert("You have enter less than 10 number");
				 document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").focus();
	 			return false;
			} 
		    
			 else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").value)=="")
			{
				alert("Enter the Description");
				document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").focus();
				return false;
			}
    }
    
  

    </script>
    <table class="common" >
        <tr>
            <td colspan="2" style="text-align: center" valign="middle">
                <asp:Label ID="lblmsg" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
        <%--<tr>
            <td class="w290 talignleft" style="width: 150px">
                Student ID</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtstudentid" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px">
                Student Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtstudentname" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 29px;">
                Course Name</td>
            <td style="width: 100px; height: 29px;">
                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" Width="473px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Book</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtBook" runat="server" CssClass="text" Width="473px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Courier Company Name</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtCourier" runat="server" CssClass="text" Width="288px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Tracking ID</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtTracking" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Contact Person Name</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtContact" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Mobile
            </td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 150px; height: 23px">
                Description</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="text" Width="290px"></asp:TextBox></td>
        </tr>--%>
        
        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Student ID</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtstudentid" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Student Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtstudentname" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 29px;">
                Course Name</td>
            <td style="width: 100px; height: 29px;">
                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" Width="473px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 23px">
                Book</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtBook" runat="server" CssClass="text" Width="473px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 23px">
                Courier Company Name</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtCourier" runat="server" MaxLength="50" CssClass="text" Width="288px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 23px">
                Tracking ID</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtTracking" runat="server" MaxLength="10" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 23px">
                Contact Person Name</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtContact" runat="server" MaxLength="50" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 23px">
                Mobile
            </td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="text" MaxLength="10" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px; height: 23px">
                Description</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="text" Width="290px"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;
                <asp:Button ID="Button2" runat="server" CssClass="submit" 
                    Text="Back" OnClick="Button2_Click" />&nbsp;
                &nbsp;
                <asp:Button ID="Btnadd" runat="server" CssClass="submit" OnClick="Btnadd_Click" OnClientClick="javascript:return ValidateBookApproval();"
                    Text="Add" />
    &nbsp;
    <input id="Reset1" type="reset" value="Reset" class="submit" />
    &nbsp;&nbsp;
    <br />
    <br />
</asp:Content>

