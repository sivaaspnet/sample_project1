<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Facultydetails.aspx.cs" Inherits="superadmin_Facultydetails" Title="Faculty Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
       function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
	        
	   function clearValidation(fieldList)
           {
	            var field=new Array();
	            field=fieldList.split("~");
	            var counter=0;
	            for(i=0;i<field.length;i++)
	     {
		    if(document.getElementById(field[i]).value!="") 
		    {
			    document.getElementById(field[i]).style.border="#999999 1px solid";
			    document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		    }
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
         
         
      function validate()
         {
         var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
            clearValidation('ContentPlaceHolder1_ddl_facultyname~ContentPlaceHolder1_txtfaculty_id~ContentPlaceHolder1_txtfaculty_pwd~ContentPlaceHolder1_txtfaculty_repwd~ContentPlaceHolder1_txtfaculty_email')

            if(trim(document.getElementById("ContentPlaceHolder1_ddl_facultyname").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the Faculty Name!';
                 document.getElementById("ContentPlaceHolder1_ddl_facultyname").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.backgroundColor="#e8ebd9";
                 return false;
                 }
             else if(trim(document.getElementById("ContentPlaceHolder1_txtfaculty_id").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txtfaculty_id").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Userid!';
                 document.getElementById("ContentPlaceHolder1_txtfaculty_id").focus();
                 document.getElementById("ContentPlaceHolder1_txtfaculty_id").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_id").style.backgroundColor="#e8ebd9";
                 return false;
                 }
             else if(trim(document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Password!';
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").focus();
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").style.backgroundColor="#e8ebd9";
                 return false;
                 }
                           else if(!re.test(document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").value))
         {
             document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").focus();
             document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").style.backgroundColor="#e8ebd9";
             return false;
         }
              else if(trim(document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").value)=="")
                 {
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Re-enter the Password!';
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").focus();
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").style.backgroundColor="#e8ebd9";
                 return false;
                 }
             
              else if(document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").value!= document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").value)
                 {
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML =' *Password Missmatch!';
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").focus();
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_pwd").style.backgroundColor="#e8ebd9";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").focus();
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_repwd").style.backgroundColor="#e8ebd9";
                 return false;
                 }
             else if(trim(document.getElementById("ContentPlaceHolder1_txtfaculty_email").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_txtfaculty_email").value=="";
                 document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter your Email id!';
                 document.getElementById("ContentPlaceHolder1_txtfaculty_email").focus();
                 document.getElementById("ContentPlaceHolder1_txtfaculty_email").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtfaculty_email").style.backgroundColor="#e8ebd9";
                 return false;
             }
             else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txtfaculty_email").value))
             {
	            document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = '* Please Enter a Valid EmailId!';
		        document.getElementById("ContentPlaceHolder1_txtfaculty_email").focus();
                document.getElementById("ContentPlaceHolder1_txtfaculty_email").style.border="#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txtfaculty_email").style.backgroundColor="#e8ebd9";
		        return false;
	          }
	          else
	          {
	           return true;
	          }
         
         }



function Reset()
{

document.getElementById("ContentPlaceHolder1_ddl_facultyname").value="";
document.getElementById("ContentPlaceHolder1_txtfaculty_id").value="";
document.getElementById("ContentPlaceHolder1_txtfaculty_email").value="";

}

function ResetSearch()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txtsearchname").value="";


}




</script>
<h4>Faculty Details</h4>

 <div class="free-forms">
    <table class="common" width="100%">
        <tr class="no-borders">
    <td>
    	<asp:Label ID="Label1" runat="server" Text="Searchby FacultyName"></asp:Label>
       	<asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text"></asp:TextBox>
        <asp:Button ID="Button2" runat="server"  OnClientClick="javascript:return SearchValidate();" CssClass="search" OnClick="Button2_Click" />
        </td>
            </tr>
            
            <tr class="no-borders"><td style="text-align:center"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
    </tr></table>
	</div>
	<div style="padding:10px">
        <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" width="100%">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="Faculty Name" />
                    <asp:BoundField DataField="userid" HeaderText="Username" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                     <asp:BoundField DataField="masterPassword" HeaderText="MasterPassword" />
                    <asp:BoundField DataField="centre_useremail" HeaderText="Email ID" />               
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("centrelogin_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> 
                             <asp:LinkButton ID="lnkdelete" Visible="false" runat="server" CommandName="del" CommandArgument='<%#Eval("centrelogin_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
            </asp:GridView>
			</div>
            <asp:HiddenField ID="Hidn_centerloginid" runat="server" />
    <br />
     
     
   <div class="free-forms" style="border:none">
    <table class="common" width="100%">
            <tr>
                <td  colspan="3"  style="padding:0px;">
                <h4>Add Faculty Details</h4>
                </td>
            </tr>
            <tr>
                <td class="formlabel">
                    Faculty Name</td>
                <td colspan="2" align="left" valign="middle">
                    <asp:DropDownList ID="ddl_facultyname" runat="server">
                     
                     
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="formlabel">
                    Faculty User ID</td>
                <td colspan="2" align="left" valign="middle" style="height: 25px">
                    <asp:TextBox ID="txtfaculty_id" runat="server" MaxLength="20" CssClass="text"></asp:TextBox>
                    eg:sri_k</td>
            </tr>
            <tr>
                <td class="formlabel">
                    Password</td>
                <td colspan="2" align="left" valign="middle">
                    <asp:TextBox ID="txtfaculty_pwd" runat="server" MaxLength="20" TextMode="Password" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="formlabel">
                   Confirm Password</td>
                <td colspan="2" align="left" valign="middle">
                    <asp:TextBox ID="txtfaculty_repwd" runat="server" MaxLength="20" TextMode="Password" CssClass="text"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="formlabel">
                    Faculty Email ID</td>
                <td colspan="2" align="left" valign="middle">
                    <asp:TextBox ID="txtfaculty_email" runat="server" MaxLength="30" CssClass="text"></asp:TextBox></td>
            </tr>
               <tr>
                   <td style=" text-align:center" class="w290 talignleft" colspan="3">
                       <asp:Button ID="Btnsubmit" runat="server" Text="Submit" OnClientClick="javascript:return validate();" CssClass="btnStyle1" OnClick="Btnsubmit_Click" />&nbsp;
                       <input id="Reset1" class="btnStyle2" onclick="javascript:return Reset();" type="button"
                            value="Reset" />
                      </td>
                        </tr>
        </table>
		</div>
    <asp:HiddenField ID="hdn_ID" runat="server" />
    <br />
    <br />
</asp:Content>

