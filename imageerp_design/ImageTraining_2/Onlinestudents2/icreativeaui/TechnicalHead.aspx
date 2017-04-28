<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="TechnicalHead.aspx.cs" Inherits="superadmin_TechnicalHead" Title="Technical Head Details" %>
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
 function Techeadvalidate()
 {
 
  var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
    clearValidation('ContentPlaceHolder1_txttech_name~ContentPlaceHolder1_txttech_userid~ContentPlaceHolder1_txttech_password~ContentPlaceHolder1_txttech_comfirmpassword~ContentPlaceHolder1_txttech_emailid')
    if(trim(document.getElementById("ContentPlaceHolder1_txttech_name").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttech_name").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Technical head Name!';
             document.getElementById("ContentPlaceHolder1_txttech_name").focus();
             document.getElementById("ContentPlaceHolder1_txttech_name").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_name").style.backgroundColor="#e8ebd9";
             return false;
         }
     else if(trim(document.getElementById("ContentPlaceHolder1_txttech_userid").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttech_userid").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Userid!';
             document.getElementById("ContentPlaceHolder1_txttech_userid").focus();
             document.getElementById("ContentPlaceHolder1_txttech_userid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_userid").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txttech_password").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttech_password").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Password!';
             document.getElementById("ContentPlaceHolder1_txttech_password").focus();
             document.getElementById("ContentPlaceHolder1_txttech_password").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_password").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(!re.test(document.getElementById("ContentPlaceHolder1_txttech_password").value))
         {
             document.getElementById("ContentPlaceHolder1_txttech_password").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_txttech_password").focus();
             document.getElementById("ContentPlaceHolder1_txttech_password").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_password").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Re-Enter the Password!';
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").focus();
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_txttech_password").value!= document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").value)
         {
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML =' *Password Missmatch!';
             document.getElementById("ContentPlaceHolder1_txttech_password").focus();
             document.getElementById("ContentPlaceHolder1_txttech_password").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_password").style.backgroundColor="#e8ebd9";
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").focus();
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_comfirmpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(trim(document.getElementById("ContentPlaceHolder1_txttech_masterpassword").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Master Password!';
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").focus();
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_txttech_password").value == document.getElementById("ContentPlaceHolder1_txttech_masterpassword").value)
         {
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML =' * Login Password and Master Password are same!';
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").focus();
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_masterpassword").style.backgroundColor="#e8ebd9";
            
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txttech_emailid").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttech_emailid").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Email-id!';
             document.getElementById("ContentPlaceHolder1_txttech_emailid").focus();
             document.getElementById("ContentPlaceHolder1_txttech_emailid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttech_emailid").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txttech_emailid").value))
          {
	            document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML = '* Please Enter a Valid EmailId!';
		        document.getElementById("ContentPlaceHolder1_txttech_emailid").focus();
                document.getElementById("ContentPlaceHolder1_txttech_emailid").style.border="#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txttech_emailid").style.backgroundColor="#e8ebd9";
		        return false;
	      }
   
 }
// <!CDATA[
function btnreset_onclick() {
location.href="TechnicalHead.aspx";
}
// ]]>
</script>

 <div class="title-cont">
    <h3 class="cont-title">Technical Head Details</h3>
    </div>
     <div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Technical Head's Name</div>
        <div class="wth-2">    <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text input-txt"></asp:TextBox></div>
      </li>
        <li>      
       <asp:Button ID="btn_search" runat="server" CssClass="search-btn" Text="Search"  OnClick="btnsearch_Click" />
        
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
      <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label> 
    </div>
    
    
    

	 <div style="padding:0px 10px 10px 10px">
       <asp:GridView CssClass="tbl-cont3" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" EmptyDataText="No Results Found" OnRowCommand="GridView1_RowCommand" width="100%">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="Technical Head Name" />
                    <asp:BoundField DataField="userid" HeaderText="Username" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                    <asp:BoundField DataField="masterPassword" HeaderText="MasterPassword" />
                    <asp:BoundField DataField="centre_useremail" HeaderText="Email ID" />               
                   <asp:TemplateField HeaderText="Status" >
 <ItemTemplate>
 <asp:Label runat="server" ID="lblstatus" ForeColor="Red" Text='<%#Eval("login_status") %>'></asp:Label>
 <asp:LinkButton runat="server" ID="lnkstatus" CommandName="lnkstatus" CommandArgument='<%#Eval("centrelogin_id")+","+Eval("login_status") %>' >Modify </asp:LinkButton>
 </ItemTemplate></asp:TemplateField>
  <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                            <center> <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("centrelogin_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> 
                             <asp:LinkButton ID="lnkdelete" Visible="false" runat="server" CommandName="del" CommandArgument='<%#Eval("centrelogin_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton></center>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
          <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
            </asp:GridView>
			</div>
   </div>
            <asp:HiddenField ID="Hidn_centerloginid" runat="server" />
   <div class="white-cont">
            <h4  class="cont-title2">
                Create Technical Head</h4>
				    
 <div align="center">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></div>
       <div class="form-cont">
        <ul>
                 
        <li>
            <label class="label-txt">
                        Technical Head Name</label>
                  <asp:TextBox ID="txttech_name" runat="server" MaxLength="25" CssClass="text input-txt"></asp:TextBox></li>
                <li>
            <label class="label-txt">Technical Head Userid</label>
               <asp:TextBox ID="txttech_userid" runat="server" MaxLength="20" CssClass="text input-txt"></asp:TextBox>
        </li>
               <li>
            <label class="label-txt">
                        Password</label>
        <asp:TextBox ID="txttech_password" runat="server" MaxLength="20" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
                 <li>
            <label class="label-txt">
                        Confirm password</label>
           <asp:TextBox ID="txttech_comfirmpassword" runat="server" MaxLength="20" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
                <li>
            <label class="label-txt">
                        Master password</label>
                <asp:TextBox ID="txttech_masterpassword" runat="server" MaxLength="20" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
               <li>
            <label class="label-txt">
                         Technical Head Email-id</label>
          <asp:TextBox ID="txttech_emailid" runat="server" TextMode="SingleLine" MaxLength="30" CssClass="text input-txt"></asp:TextBox></li>
              <li>
            <label class="label-txt"> Status</label>
 <asp:DropDownList runat="server" ID="ddlloginstatus" CssClass="sele-txt" >
<asp:ListItem Value="Enable" Text="Enable"></asp:ListItem>
<asp:ListItem Value="Disable" Text="Disable"></asp:ListItem></asp:DropDownList> </li>
                        <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;"> 
                        <asp:Button ID="Btnupdate" CssClass="btnStyle1" runat="server" Text="Submit" OnClick="Btnupdate_Click1" OnClientClick="javascript:return Techeadvalidate();" />&nbsp;
                        <input id="btnreset" type="button" class="btnStyle2" value="Reset" onclick="return btnreset_onclick()" /></div></li>
      </ul>
      <div class="clear"></div>
</div>
</div>
</asp:Content>

