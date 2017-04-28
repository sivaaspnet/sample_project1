<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="regionhead.aspx.cs" Inherits="superadmin_TechnicalHead" Title="Region Head Details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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
    clearValidation('ctl00_ContentPlaceHolder1_txttech_name~ctl00_ContentPlaceHolder1_txttech_userid~ctl00_ContentPlaceHolder1_txttech_password~ctl00_ContentPlaceHolder1_txttech_comfirmpassword~ctl00_ContentPlaceHolder1_txttech_emailid')
    
    if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddc_region").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddc_region").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Select Region..!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddc_region").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddc_region").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddc_region").style.backgroundColor="#e8ebd9";
             return false;
         }
    
    else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttech_name").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_name").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Technical head Name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_name").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_name").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_name").style.backgroundColor="#e8ebd9";
             return false;
         }
     else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttech_userid").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_userid").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Userid!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_userid").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_userid").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_userid").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Password!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").style.backgroundColor="#e8ebd9";
             return false;
         }
                   else if(!re.test(document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").value))
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Re-Enter the Password!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").value!= document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").value)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML =' *Password Missmatch!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_password").style.backgroundColor="#e8ebd9";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_comfirmpassword").style.backgroundColor="#e8ebd9";
             return false;
         } 
         else if (trim(document.getElementById("ctl00_ContentPlaceHolder1_txttech_masterpassword").value) == "") {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_masterpassword").value == "";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML = '*Please Enter the Master Password!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_masterpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_masterpassword").style.border = "#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_masterpassword").style.backgroundColor = "#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the Email-id!';
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(!Validate_Email(document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").value))
          {
	            document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML = '* Please Enter a Valid EmailId!';
		        document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").focus();
                document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").style.border="#ff0000 1px solid";
                document.getElementById("ctl00_ContentPlaceHolder1_txttech_emailid").style.backgroundColor="#e8ebd9";
		        return false;
	      }
   
 }
// <!CDATA[
function btnreset_onclick() {
location.href="TechnicalHead.aspx";
}
// ]]>
</script>
<style type="text/css">
    .tableBackground
{
	background-color:silver;
	opacity:0.7;
}

</style>
<ajax:ToolkitScriptManager ID="ScriptManager1" runat="server">
</ajax:ToolkitScriptManager>
 <div class="title-cont">
    <h3 class="cont-title">Region Head Details</h3>
    </div>
        
        <div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Region Head's Name</div>
        <div class="wth-2">   <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text input-txt"></asp:TextBox></div>
      </li>
        <li>
      
    
        
       <asp:Button ID="btn_search" runat="server" CssClass="search-btn" Text="Search"  OnClick="btnsearch_Click" />
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
      <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label> 
    </div>
	
    <div style="padding:0px 10px 10px 10px">
       <asp:GridView CssClass="tbl-cont3" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" EmptyDataText="No Results Found" OnRowCommand="GridView1_RowCommand" width="100%" OnPageIndexChanging="GridView1_pageindexchanging">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="Region Head Name" />
                    <asp:BoundField DataField="userid" HeaderText="Username" />                     
                    <asp:TemplateField HeaderText="Password">
                  <ItemTemplate> 
                  <span ><%#maskpasswordcharacters(Eval("password").ToString())%></span>
                  </ItemTemplate>
                  </asp:TemplateField>    
                 <asp:TemplateField HeaderText="Master Password">
                  <ItemTemplate> 
                  <span ><%#maskpasswordcharacters(Eval("masterpassword").ToString())%></span>
                  </ItemTemplate>
                 </asp:TemplateField>   
                    <asp:BoundField DataField="centre_useremail" HeaderText="Email ID" />               
                   <asp:TemplateField HeaderText="Status" >
 <ItemTemplate>
 <asp:Label runat="server" ID="lblstatus" ForeColor="Red" Text='<%#Eval("login_status") %>'></asp:Label>
 <asp:LinkButton runat="server" ID="lnkstatus" CommandName="lnkstatus" CommandArgument='<%#Eval("centrelogin_id")+","+Eval("login_status") %>' >Modify </asp:LinkButton>
 </ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("centrelogin_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                              <asp:LinkButton ID="lnkAssign" runat="server" CommandArgument='<%# Eval("centrelogin_id")+","+Eval("username") %>' CommandName="ASGN" >Assign Centres</asp:LinkButton>|
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("centrelogin_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
          <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
            </asp:GridView>
  </div></div>
            <asp:HiddenField ID="Hidn_centerloginid" runat="server" />
    
    <div class="white-cont">
            <h4  class="cont-title2">
                Create Region Head</h4>
				      <div align="center">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></div>

       <div class="form-cont">
        <ul>
                 
       <li>
            <label class="label-txt">
                Region</label>           
                <asp:DropDownList ID="ddc_region" runat="server" CssClass="sele-txt">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Tamilnadu">Tamilnadu</asp:ListItem>
                    <asp:ListItem Value="Andrapradesh">Andra pradesh</asp:ListItem>
                    <asp:ListItem Value="karnataka">Karnataka</asp:ListItem>
                    <asp:ListItem Value="kerala">Kerala</asp:ListItem>
                </asp:DropDownList></li>
       <li>
            <label class="label-txt">
                        Region Head Name</label>
                 <asp:TextBox ID="txttech_name" runat="server" MaxLength="25" CssClass="text input-txt"></asp:TextBox></li>
                 
             <li>
            <label class="label-txt">           Region Head Userid</label>
                  
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
                        Master Password</label>
                      <asp:TextBox ID="txttech_masterpassword" runat="server" MaxLength="20" 
                            TextMode="Password" CssClass="text input-txt"  Width="260px" ></asp:TextBox></li>
              <li>
            <label class="label-txt">
                        Region Head Email-id</label>                   
                        <asp:TextBox ID="txttech_emailid" runat="server" TextMode="SingleLine" MaxLength="30" CssClass="text input-txt"></asp:TextBox></li>
              <li>
            <label class="label-txt"> Status</label>                           
<asp:DropDownList runat="server" ID="ddlloginstatus" CssClass="sele-txt" >
<asp:ListItem Value="Enable" Text="Enable"></asp:ListItem>
<asp:ListItem Value="Disable" Text="Disable"></asp:ListItem></asp:DropDownList></li>
                         <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">        
                        <asp:Button ID="Btnupdate" CssClass="btnStyle1" runat="server" Text="Submit" OnClick="Btnupdate_Click1" OnClientClick="javascript:return Techeadvalidate();" />
                        <input id="btnreset" type="button" class="reset-btn" value="Reset" onclick="return btnreset_onclick()" /></div></li>
     </ul>
     <div class="clear"></div>
 </div></div>

<asp:Button ID="modelPopupView" runat="server" style="display:none" />
<ajax:ModalPopupExtender ID="ModalPopupExtenderView" runat="server" TargetControlID="modelPopupView" PopupControlID="updatepanelView"
CancelControlID="btncancelView" BackgroundCssClass="tableBackground">
</ajax:ModalPopupExtender>

<asp:Panel ID="updatepanelView" runat="server" BackColor="White" Height="670px" Width="850px" style="display:none">
 <h4  class="cont-title2">
               Assign Centres</h4>
				    
 <div class="form-cont">
 
        <ul>
                 
       <li>
            <label class="label-txt">
User Name:</label>
<asp:TextBox runat="server" ID="txtuser" Width="150px" ReadOnly="true" CssClass="text input-txt"></asp:TextBox></li>
 <li>
            <label class="label-txt">Assign Centres</label>

<asp:CheckBoxList runat="server" ID="chklistbranch" CssClass="chkBranch" RepeatLayout="Table" RepeatColumns="3" RepeatDirection="Vertical">
</asp:CheckBoxList></li>
		 
	 <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">        
		<asp:Button ID="btncancelView" runat="server" Text="Cancel" />
		<asp:Button ID="btnassign" runat="server" Text="Submit" onclick="btnAssign_Click" Width="100px"  OnClientClick=" return validateAssign()"/>
		</div></li></ul>
		<div class="clear"></div>
	</div>
</asp:Panel>
</asp:Content>

