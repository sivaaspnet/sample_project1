<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="SiteStatus.aspx.cs" Inherits="superadmin_SiteStatus" Title="Site Status" %>
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
           // clearValidation('ContentPlaceHolder1_ddlcentrename~ContentPlaceHolder1_ddlCentreStatus~ContentPlaceHolder1_txtmessage')

          //alert("test")
               if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddlcentrename").value)=="")
                 {
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlcentrename").value=="";
                 document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select centre!';
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlcentrename").focus();
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlcentrename").style.border="#ff0000 1px solid";
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlcentrename").style.backgroundColor="#e8ebd9";
                 return false;
                 }
            else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddlCentreStatus").value)=="")
                 {
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlCentreStatus").value=="";
                 document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select status!';
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlCentreStatus").focus();
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlCentreStatus").style.border="#ff0000 1px solid";
                 document.getElementById("ctl00_ContentPlaceHolder1_ddlCentreStatus").style.backgroundColor="#e8ebd9";
                 return false;
                 }
	       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtmessage").value)=="")
                 {
                 document.getElementById("ctl00_ContentPlaceHolder1_txtmessage").value=="";
                 document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the message!';
                 document.getElementById("ctl00_ContentPlaceHolder1_txtmessage").focus();
                 document.getElementById("ctl00_ContentPlaceHolder1_txtmessage").style.border="#ff0000 1px solid";
                 document.getElementById("ctl00_ContentPlaceHolder1_txtmessage").style.backgroundColor="#e8ebd9";
                 return false;
                 }
              
	          else
	          {
	           return true;
	          }
         
         }



function Reset()
{

document.getElementById("ContentPlaceHolder1_ddlcentrename").value="";
document.getElementById("ContentPlaceHolder1_ddlCentreStatus").value="";
document.getElementById("ContentPlaceHolder1_txtmessage").value="";

}

function ResetSearch()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_txtsearchname").value="";


}




</script>

     <div class="title-cont">
 <h3 class="cont-title">Make Offline</h3>
</div>
     <div class="white-cont">
     
    <h4  class="cont-title2">
                Add Site Status</h4>
                   
    &nbsp;<asp:HiddenField ID="Hidn_centerloginid" runat="server" />
    
                 <div align="center">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label>
          </div>
         <div class="form-cont">
        <ul>
                  
   <li>
            <label class="label-txt"> 
                    Select Centre             </label>
                    <asp:DropDownList ID="ddlcentrename" runat="server" CssClass="sele-txt">
                    </asp:DropDownList></li>
           <li>
            <label class="label-txt">
                    Status</label>
                    <asp:DropDownList ID="ddlCentreStatus" runat="server" CssClass="sele-txt">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="0">Offline</asp:ListItem>
                        <asp:ListItem Value="1">Online</asp:ListItem>                  
                    </asp:DropDownList></li>
           <li>
            <label class="label-txt">
                    Message</label>
            <asp:TextBox ID="txtmessage" runat="server" MaxLength="20" CssClass="text input-txt" Height="57px" TextMode="MultiLine" Width="260px"></asp:TextBox>
           </li>
            <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">  
                       <asp:Button ID="Btnsubmit" runat="server" Text="Submit" OnClientClick="javascript:return validate();" CssClass="btnStyle1" OnClick="Btnsubmit_Click" />&nbsp;
                      <asp:Button ID="BtnReset" runat="server" Text="Reset" class="btnStyle2" OnClick="BtnReset_Click" />
                      </div></li>
    <asp:HiddenField ID="hdn_ID" runat="server" /></ul>
    <div class="clear"></div>
    </div></div>
    <div class="white-cont">
  <div style="padding:0px 10px 10px 10px">
  
        <asp:GridView CssClass="tbl-cont3" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" width="100%">
                <Columns>
                    <asp:BoundField DataField="centre_location" HeaderText="Centre  Name" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Message" HeaderText="Message" />
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("StatusId")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("StatusId")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
                  <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
            <EmptyDataRowStyle ForeColor="Red" />
            </asp:GridView>
   </div></div>
</asp:Content>

