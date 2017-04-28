<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Printingdepartment.aspx.cs" Inherits="superadmin_Counselordetails" Title="Printing Department Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
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
function councilvalidate()
{
 var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
clearValidation('ContentPlaceHolder1_txtcounselor_name~ContentPlaceHolder1_txtcounselor_id~ContentPlaceHolder1_txtcounselor_pwd~ContentPlaceHolder1_txtcounselor_repwd~ContentPlaceHolder1_txtcounselor_email')
if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_name").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_name").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Counselor Name!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_name").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_name").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_name").style.backgroundColor="#e8ebd9";
             return false;
         }
else if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_id").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_id").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the UserID!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_id").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_id").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_id").style.backgroundColor="#e8ebd9";
             return false;
         }
else if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Password!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(!re.test(document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").value))
         {
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").style.backgroundColor="#e8ebd9";
             return false;
         }
else if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Re-Enter the Password!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").style.backgroundColor="#e8ebd9";
             return false;
         }
else if(document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").value!= document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").value)
         {
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML =' *Password Missmatch!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").style.backgroundColor="#e8ebd9";
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_repwd").style.backgroundColor="#e8ebd9";
             return false;
         }
else if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_email").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_email").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter Email Id!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_email").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_email").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_email").style.backgroundColor="#e8ebd9";
             return false;
         }
else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txtcounselor_email").value))
          {
	            document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = '* Please Enter a Valid EmailId!';
		        document.getElementById("ContentPlaceHolder1_txtcounselor_email").focus();
                document.getElementById("ContentPlaceHolder1_txtcounselor_email").style.border="#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txtcounselor_email").style.backgroundColor="#e8ebd9";
		        return false;
	      }
else
          {
          return true;
          }
}
     function Validate_Email(Email)
{
	var Str=Email
	//var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

	if(CheckExpression.test(Str))// test Method to check for Regular Expression
	{
		return true;
	}
	else
	{
		return false
	}
}
function btnreset_onclick() {
location.href="RandD.aspx";
}

</script>
<div class="free-forms">
    <table class="common" width="100%">
        <tr>
            <td style=" padding:0px; height: 29px;"><h4>
                Printing Department Details</h4>

            </td>
        </tr>
        <tr>
    <td>
       <asp:Label ID="Label1" runat="server" Text="Searchby Name"></asp:Label>
      
       <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnsearch" runat="server"  CssClass="search" OnClick="btnsearch_Click"/>&nbsp;
         <br />
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special2" ControlToValidate="txtsearchname"></asp:CustomValidator>
                    
    </td>
            </tr></table>
    <br />
        <asp:GridView ID="grdcounselor" runat="server" CssClass="common" AutoGenerateColumns="False" OnRowCommand="grdcounselor_RowCommand" AllowPaging="True" EmptyDataText="No Results Found" OnPageIndexChanging="grdcounselor_PageIndexChanging" PageSize="5" width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                  <%#removetilde(Eval("username").ToString())%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User ID">
                 <ItemTemplate>
                  <%#removetilde(Eval("userid").ToString())%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                 <ItemTemplate>                  
                  <span ><%#maskpasswordcharacters(removetilde(Eval("password").ToString()))%></span>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email ID">
                 <ItemTemplate>
                  <%#removetilde(Eval("centre_useremail").ToString())%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" CommandName="lnkedit" CommandArgument='<%#Eval("centrelogin_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                        <asp:LinkButton ID="lnkdelete" runat="server" CommandName="lnkdel" CommandArgument='<%#Eval("centrelogin_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Position="TopAndBottom" />
        </asp:GridView>
     <br />
   
        <table class="common" width="100%">
            <tr>
                <td  colspan="3" style="padding:0px;" > <h4>Add Printing Department Details</h4>
                </td>
            </tr>
            <tr>
                <td  style="text-align:center;" colspan="3">
                    <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td >
                    Name</td>
                <td colspan="2" align="left" valign="middle" style="height: 31px">
                    <asp:TextBox ID="txtcounselor_name" runat="server" CssClass="text" MaxLength="25"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    User ID</td>
                <td colspan="2" align="left" valign="middle" style="height: 25px">
                    <asp:TextBox ID="txtcounselor_id" runat="server" CssClass="text" MaxLength="20"></asp:TextBox>
                    eg: sri_k</td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td colspan="2" align="left" valign="middle">
                    <asp:TextBox ID="txtcounselor_pwd" runat="server" MaxLength="20" TextMode="Password" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                   Confirm Password</td>
                <td colspan="2" align="left" valign="middle">
                    <asp:TextBox ID="txtcounselor_repwd" runat="server" MaxLength="20" TextMode="Password" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Email ID</td>
                <td colspan="2" align="left" valign="middle" style="height: 29px">
                    <asp:TextBox ID="txtcounselor_email" runat="server" CssClass="text" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" colspan="3"  style="height: 29px; text-align:center;" valign="middle">
                    <br />
                       <asp:Button ID="Button_submit" CssClass="btnStyle1" runat="server" Text="Submit" OnClientClick="javascript:return councilvalidate();" OnClick="Button_submit_Click" />&nbsp;
    <input id="btnreset" type="button" value="Reset" class="btnStyle2" onclick="return btnreset_onclick()"/></td>
            </tr>
        </table>
    <asp:HiddenField ID="hdnID" runat="server" />
  </div>
  
</asp:Content>

