<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="CreateNSDCManager.aspx.cs" Inherits="superadmin_CreateManager" Title="Create Mangager" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
	        
	 function Validate()
     {
     var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
        clearValidation('ContentPlaceHolder1_ddl_CentreCode~ContentPlaceHolder1_txtc_managername~ContentPlaceHolder1_ddrole~ContentPlaceHolder1_ddc_region~ContentPlaceHolder1_ddc_region~ContentPlaceHolder1_txtc_managerid~ContentPlaceHolder1_txtc_managerpwd~ContentPlaceHolder1_txtc_manager_repwd~ContentPlaceHolder1_txt_manager_mailid');
         if(trim(document.getElementById("ContentPlaceHolder1_ddl_CentreCode").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_CentreCode").value=="";   
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Centre Code!';
             document.getElementById("ContentPlaceHolder1_ddl_CentreCode").focus();
             document.getElementById("ContentPlaceHolder1_ddl_CentreCode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_CentreCode").style.backgroundColor="#e8ebd9";
           
             return false;
         }
       
            else if(trim(document.getElementById("ContentPlaceHolder1_txtc_managername").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtc_managername").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Centre Manager Name!';
             document.getElementById("ContentPlaceHolder1_txtc_managername").focus();
             document.getElementById("ContentPlaceHolder1_txtc_managername").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_managername").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_ddrole").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddrole").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Select the Role!';
             document.getElementById("ContentPlaceHolder1_ddrole").focus();
             document.getElementById("ContentPlaceHolder1_ddrole").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddrole").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_ddc_region").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddc_region").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Select the Region!';
             document.getElementById("ContentPlaceHolder1_ddc_region").focus();
             document.getElementById("ContentPlaceHolder1_ddc_region").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddc_region").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txtc_managerid").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtc_managerid").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Userid!';
             document.getElementById("ContentPlaceHolder1_txtc_managerid").focus();
             document.getElementById("ContentPlaceHolder1_txtc_managerid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_managerid").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ContentPlaceHolder1_txt_masterpass").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_masterpass").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the MasterPassword!';
             document.getElementById("ContentPlaceHolder1_txt_masterpass").focus();
             document.getElementById("ContentPlaceHolder1_txt_masterpass").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_masterpass").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(!re.test(document.getElementById("ContentPlaceHolder1_txt_masterpass").value))
         {
             document.getElementById("ContentPlaceHolder1_txt_masterpass").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_txt_masterpass").focus();
             document.getElementById("ContentPlaceHolder1_txt_masterpass").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_masterpass").style.backgroundColor="#e8ebd9";
             return false;
         }
             else if(trim(document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Password!';
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").focus();
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.backgroundColor="#e8ebd9";
             return false;
         }
                else if(!re.test(document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value))
         {
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = 'Error: Password must contain at least six characters that are one number, one lowercase and one uppercase letter!';
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").focus();
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.backgroundColor="#e8ebd9";
             return false;
         }
         
               else if(trim(document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value)==(document.getElementById("ContentPlaceHolder1_txt_masterpass").value))
         {
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Login Password  and Master password are same';
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").focus();
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.backgroundColor="#e8ebd9";
             return false;
         }
         
                    else if(trim(document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Re-Enter the Password!';
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").focus();
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         
              else if(document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value != document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").value)
         {
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML =' *Password Missmatch!';
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").focus();
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_managerpwd").style.backgroundColor="#e8ebd9";
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").focus();
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").style.backgroundColor="#e8ebd9";
             return false;
         }
         
        
             else if(trim(document.getElementById("ContentPlaceHolder1_txt_manager_mailid").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_manager_mailid").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Emailid!';
             document.getElementById("ContentPlaceHolder1_txt_manager_mailid").focus();
             document.getElementById("ContentPlaceHolder1_txt_manager_mailid").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_manager_mailid").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txt_manager_mailid").value))
          {
	            document.getElementById("ContentPlaceHolder1_lblmsg").innerHTML = '* Please Enter a Valid EmailId!';
		        document.getElementById("ContentPlaceHolder1_txt_manager_mailid").focus();
                document.getElementById("ContentPlaceHolder1_txt_manager_mailid").style.border="#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txt_manager_mailid").style.backgroundColor="#e8ebd9";
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
	var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    //var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

	if(CheckExpression.test(Str))// test Method to check for Regular Expression
	{
		return true;
	}
	else
	{
		return false
	}
}
function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_txtsearchlocation").value=="" && document.getElementById("ContentPlaceHolder1_txtsearchname").value=="" )
         {
         
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").focus();
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsearchlocation").style.backgroundColor="#e8ebd9";
             return false;
         } 
      
        else
        {
        return true;
        }

}




function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txtc_code").value="";
document.getElementById("ContentPlaceHolder1_txtc_location").value="";
document.getElementById("ContentPlaceHolder1_txtc_managerid").value="";
document.getElementById("ContentPlaceHolder1_txt_manager_mailid").value="";
document.getElementById("ContentPlaceHolder1_txtc_managername").value="";
document.getElementById("ContentPlaceHolder1_txtcentrecat").value="";

document.getElementById("ContentPlaceHolder1_txtc_managerpwd").value="";
document.getElementById("ContentPlaceHolder1_txtc_manager_repwd").value="";


  var liste = document.getElementById("ContentPlaceHolder1_ddc_region");
                var howMany = liste.options.length;

                for(var i = 0; i < howMany; i++)
                {
                    if(liste[i].selected)
                    {
                    liste[i].selected=false;
                    }
                }    


}



 


</script>
 <div class="title-cont">
 <h3 class="cont-title">NSDC Manager Details</h3>
</div>
<div class="white-cont">
  <div style="padding:0px 10px 10px 10px">
  <div style="text-align:center">
    <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>
</div>
    <asp:GridView ID="grdcentre" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" OnRowCommand="grdcentre_RowCommand" AllowPaging="True" OnPageIndexChanging="grdcentre_PageIndexChanging" PageSize="20" EmptyDataText="No Records Found" width="100%" OnRowDataBound="grdcentre_RowDataBound">
        <Columns> 
            <asp:BoundField DataField="centre_location" HeaderText="Centre" />
            <asp:BoundField DataField="centre_region" HeaderText="Region" />
            <asp:TemplateField HeaderText="Centre Manager">
             <ItemTemplate>
             <%#removetilde(Eval("username").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
         
            <asp:BoundField DataField="userid" HeaderText="User Id" />            
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
            <asp:TemplateField HeaderText="Manager Email-id">
             <ItemTemplate>
             <%#removetilde(Eval("centre_useremail").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" ItemStyle-Width="150px">
 <ItemTemplate>
 <asp:Label runat="server" ID="lblstatus" ForeColor="Red" Text='<%#Eval("login_status") %>'></asp:Label>
 <asp:LinkButton runat="server" ID="lnkstatus" CommandName="lnkstatus" CommandArgument='<%#Eval("centrelogin_id")+","+Eval("login_status") %>' >Modify </asp:LinkButton>
 </ItemTemplate></asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-Width="75px">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkedit" CommandName="lnkedit" CommandArgument='<%#Eval("centrelogin_id")%>' runat="server"><img src="layout/edit.png" alt="edit"/></asp:LinkButton> | 
                    <asp:LinkButton ID="lnkdelete" CommandName="lnkdel" CommandArgument='<%#Eval("centrelogin_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');" runat="server"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
               
                   </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
    </asp:GridView>
   </div></div>
     
        
   <div class="white-cont">
    <h4  class="cont-title2">
                Create NSDC Manager</h4>
                 <div align="center">
           <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label>
            </div>
         <div class="form-cont">
        <ul>
                 
   <li>
            <label class="label-txt"> 
                Centre</label>           
                <asp:DropDownList ID="ddl_CentreCode" runat="server" CssClass="sele-txt">
                </asp:DropDownList></li>
      <li><label class="label-txt">  Centre Managername</label>                           
                                <asp:TextBox ID="txtc_managername" runat="server"  CssClass="text input-txt" MaxLength="50"></asp:TextBox>
                                </li>
                          <li>
            <label class="label-txt">  Role</label>
                           
                                <asp:DropDownList ID="ddrole" runat="server"  CssClass="sele-txt" >
                                    <asp:ListItem Value="CentreManager" >Centre Manager</asp:ListItem>    
                                </asp:DropDownList></li>
                       <li>
            <label class="label-txt">  Centre Region</label>
           
                <asp:DropDownList ID="ddc_region" runat="server"  CssClass="sele-txt">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="Tamilnadu">Tamilnadu</asp:ListItem>
                    <asp:ListItem Value="Andrapradesh">Andra pradesh</asp:ListItem>
                    <asp:ListItem Value="karnataka">Karnataka</asp:ListItem>
                    <asp:ListItem Value="kerala">Kerala</asp:ListItem>
                </asp:DropDownList></li>
        <li>
            <label class="label-txt"> Center Manager User ID</label>
                          <asp:TextBox ID="txtc_managerid" runat="server" CssClass="text input-txt" MaxLength="25"  ></asp:TextBox>
                       </li>
       <li>
            <label class="label-txt">  Master Password</label>
            <asp:TextBox ID="txt_masterpass" runat="server" CssClass="text input-txt" MaxLength="15" TextMode="Password" Width="260px"></asp:TextBox>
       </li>
                     <li>
            <label class="label-txt">  Manager Password</label>
         <asp:TextBox ID="txtc_managerpwd" runat="server" MaxLength="15" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox>
                        </li>
                       <li>
            <label class="label-txt">  Confirm Password</label>
             <asp:TextBox ID="txtc_manager_repwd" runat="server" MaxLength="15" TextMode="Password" CssClass="text input-txt" Width="260px"></asp:TextBox></li>
                       <li>
            <label class="label-txt">  Manager Email ID</label>
                          <asp:TextBox ID="txt_manager_mailid" runat="server" MaxLength="30" CssClass="text input-txt"></asp:TextBox>
                       </li>
                       <li>
            <label class="label-txt"> 
                       Status</label>
<asp:DropDownList runat="server" ID="ddlloginstatus"  CssClass="sele-txt" >
<asp:ListItem Value="Enable" Text="Enable"></asp:ListItem>
<asp:ListItem Value="Disable" Text="Disable"></asp:ListItem></asp:DropDownList>                                </td>
                      </li>
          <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">          
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return Validate();" OnClick="btnsubmit_Click"/>&nbsp;
                                <input id="Reset1" class="reset-btn" value="Reset" onclick="javascript:return Reset();" type="button"
                                     title="Reset" /></div>
              
           </li></ul>
         <div class="clear"></div>
         </div></div>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnID1" runat="server" />

</asp:Content>

