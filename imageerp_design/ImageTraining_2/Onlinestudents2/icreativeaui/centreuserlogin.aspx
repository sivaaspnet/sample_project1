<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="centreuserlogin.aspx.cs" Inherits="centreuserlogin" Title="User Login Page" %>

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
function userloginval()

  {
  clearValidation('ctl00_ContentPlaceHolder1_txtname~ctl00_ContentPlaceHolder1_txtusername~ctl00_ContentPlaceHolder1_txtpassword~ctl00_ContentPlaceHolder1_txtconfirmpassword')
         if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtname").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtname").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Edit the Name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtname").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtusername").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtusername").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Edit the UserName!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtusername").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtusername").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtusername").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Edit the Password!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Confirm your password!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").value != document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").value)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML =' *Password Missmatch!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").style.backgroundColor="#e8ebd9";
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
     }



function SearchValidate()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").value=="" && document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").value=="" )
         {
         
            
             document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtnamesearch").style.backgroundColor="#e8ebd9";
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
document.getElementById("ctl00_ContentPlaceHolder1_txtname").value="";
document.getElementById("ctl00_ContentPlaceHolder1_txtusername").value="";

document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").value="";
document.getElementById("ctl00_ContentPlaceHolder1_txtconfirmpassword").value="";


}


function TABLE1_onclick() {

}

</script>
  <div class="free-forms" style="overflow:auto;">
    <h4> Centre Details</h4>
    <div class="search-sec-cont">
      <ul>
        <li><span>Searchby Name</span>
          <asp:TextBox ID="txtsearchlocation"
                    runat="server" CssClass="text input-txt"></asp:TextBox>
        </li>
        <li><span>Searchby Location</span>
          <asp:TextBox ID="txtsearchname" runat="server" CssClass="text input-txt"></asp:TextBox>
        </li>
        <li>
          <asp:Button ID="btnsearch" runat="server" CssClass="search-btn" OnClick="btnsearch_Click" Text="Search" />
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="white-cont">
    <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>
    <div class="dataGrid" style="padding:10px">
      <asp:GridView ID="grdcentre" runat="server" AllowPaging="True" AutoGenerateColumns="False" width="100%"
        CssClass="common2" EmptyDataText="No Records Found" OnPageIndexChanging="grdcentre_PageIndexChanging"
        PageSize="15">
        <PagerSettings Mode="NumericFirstLast" />
        <EmptyDataRowStyle ForeColor="Red" />
        <Columns>
        <asp:TemplateField HeaderText="Centre Code">
          <ItemTemplate> <%#removetilde(Eval("centre_code").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Centre Location">
          <ItemTemplate> <%#removetilde(Eval("centre_location").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Centre Region">
          <ItemTemplate> <%#removetilde(Eval("centre_region").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Centre Managername">
          <ItemTemplate> <%#removetilde(Eval("username").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Manager Email-id">
          <ItemTemplate> <%#removetilde(Eval("centre_useremail").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="userid" HeaderText="User id" />
        <asp:TemplateField HeaderText="Password">
          <ItemTemplate> <span ><%#maskpasswordcharacters(Eval("password").ToString())%></span> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Master Password">
          <ItemTemplate> <span ><%#maskpasswordcharacters(Eval("masterPassword").ToString())%></span> </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
      </asp:GridView>
    </div>
    <center>
      <asp:LinkButton ID="Linkdownload" runat="server" CssClass="download-btn" OnClick="Linkdownload_Click">Download Excel</asp:LinkButton>
    </center>
    <asp:HiddenField ID="Hidncenterloginid" runat="server" />
    &nbsp;&nbsp;<br />
    </div>
  </div>
</asp:Content>
