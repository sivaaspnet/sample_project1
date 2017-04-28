<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Counselordetails.aspx.cs" Inherits="superadmin_Counselordetails" Title="Counselor Details" %>
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
         else if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").value)=="")
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Master Password!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(!re.test(document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").value))
         {
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").value)==document.getElementById("ContentPlaceHolder1_txtcounselor_pwd").value)
         {
             
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Login Password and Master Password are same';
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").focus();
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcounselor_pwd0").style.backgroundColor="#e8ebd9";
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
location.href="Counselordetails.aspx";
}

</script>
   <div class="title-cont">
    <h3 class="cont-title">Counsellor Details</h3>
    </div>
    
    <div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Counselor Name</div>
        <div class="wth-2">    <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text input-txt"></asp:TextBox></div>
      </li>
        <li>      
       <asp:Button ID="btn_search" runat="server" CssClass="search-btn" Text="Search"  OnClick="btnsearch_Click" />
        <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtsearchname"></asp:CustomValidator>
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
      <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label> 
    </div>
    
    
      
			  <div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="grdcounselor" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" OnRowCommand="grdcounselor_RowCommand" AllowPaging="True" EmptyDataText="No Results Found" OnPageIndexChanging="grdcounselor_PageIndexChanging" PageSize="5" width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Counselor Name">
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
                  <%#maskpasswordcharacters(removetilde(Eval("password").ToString()))%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MasterPassword">
                 <ItemTemplate>
                  <%#maskpasswordcharacters(removetilde(Eval("masterPassword").ToString()))%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email ID">
                 <ItemTemplate>
                  <%#removetilde(Eval("centre_useremail").ToString())%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" >
 <ItemTemplate>
 <asp:Label runat="server" ID="lblstatus" ForeColor="Red" Text='<%#Eval("login_status") %>'></asp:Label>
 <asp:LinkButton runat="server" ID="lnkstatus" CommandName="lnkstatus" CommandArgument='<%#Eval("centrelogin_id")+","+Eval("login_status") %>' >Modify </asp:LinkButton>
 </ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                       <center> <asp:LinkButton ID="lnkedit" runat="server" CommandName="lnkedit" CommandArgument='<%#Eval("centrelogin_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> 
                        <asp:LinkButton ID="lnkdelete" Visible="false" runat="server" CommandName="lnkdel" CommandArgument='<%#Eval("centrelogin_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton></center>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView>
		</div>
     </div>
      <div class="white-cont">
            <h4  class="cont-title2">
                Create Counsellor</h4>
                <div align="center">
				     <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></div>

       <div class="form-cont">
        <ul>
                
            <li>
            <label class="label-txt">
                    Couselor Name</label>
                    <asp:TextBox ID="txtcounselor_name" runat="server" CssClass="text input-txt" MaxLength="25"></asp:TextBox></li>
            <li>
            <label class="label-txt">
                    Counselor User ID</label>
             <asp:TextBox ID="txtcounselor_id" runat="server" CssClass="text input-txt" MaxLength="20"></asp:TextBox>
                 </li>
            <li>
            <label class="label-txt">
                    Password</label>
             <asp:TextBox ID="txtcounselor_pwd" runat="server" MaxLength="20" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
            <li>
            <label class="label-txt">
                   Confirm Password</label>
              <asp:TextBox ID="txtcounselor_repwd" runat="server" MaxLength="20" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
            <li>
            <label class="label-txt">
                    Master Password</label>
               <asp:TextBox ID="txtcounselor_pwd0" runat="server" MaxLength="20" 
                        TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
           <li>
            <label class="label-txt">
                    Counselor Email ID</label>
            <asp:TextBox ID="txtcounselor_email" runat="server" CssClass="text input-txt" MaxLength="30"></asp:TextBox></li>
           <li>
            <label class="label-txt">Status</label>
                          <asp:DropDownList runat="server" ID="ddlloginstatus" CssClass="sele-txt" >
<asp:ListItem Value="Enable" Text="Enable"></asp:ListItem>
<asp:ListItem Value="Disable" Text="Disable"></asp:ListItem></asp:DropDownList> </li>
                          <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">  
                       <asp:Button ID="Button_submit" CssClass="btnStyle1" runat="server" Text="Submit" OnClientClick="javascript:return councilvalidate();" OnClick="Button_submit_Click" />&nbsp;
    <input id="btnreset" type="button" value="Reset" class="btnStyle2" onclick="return btnreset_onclick()"/></td>
           </div></li></ul>
           <div class="clear"></div>
    <asp:HiddenField ID="hdnID" runat="server" />
    
  </div>
  
</asp:Content>

