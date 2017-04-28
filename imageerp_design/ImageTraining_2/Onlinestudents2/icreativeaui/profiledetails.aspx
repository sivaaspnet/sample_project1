<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="profiledetails.aspx.cs" Inherits="superadmin_profiledetails" Title="Add Profile Details" %>
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


onKeyPress="return CheckNumeric(event)"       
	        
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
    function lab()
    {
    clearValidation('ContentPlaceHolder1_txt_Modulename')
      if(trim(document.getElementById("ContentPlaceHolder1_txt_Modulename").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_Modulename").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the profile name';
             document.getElementById("ContentPlaceHolder1_txt_Modulename").focus();
             document.getElementById("ContentPlaceHolder1_txt_Modulename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_Modulename").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_ddlstatus").value)=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the status';
             document.getElementById("ContentPlaceHolder1_ddlstatus").focus();
             document.getElementById("ContentPlaceHolder1_ddlstatus").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlstatus").style.backgroundColor="#e8ebd9";
             return false;
         }
//       else if(trim(document.getElementById("ContentPlaceHolder1_DDlSoftwareStatus").value)=="")
//         {
//             document.getElementById("ContentPlaceHolder1_DDlSoftwareStatus").value=="";
//             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the status';
//             document.getElementById("ContentPlaceHolder1_DDlSoftwareStatus").focus();
//             document.getElementById("ContentPlaceHolder1_DDlSoftwareStatus").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_DDlSoftwareStatus").style.backgroundColor="#e8ebd9";
//             return false;
//         }
         else
         {
         return true;
         }
         
    } 
    
function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_txtsearchname").value=="")
         {
         
            
             document.getElementById("ContentPlaceHolder1_txtsearchname").focus();
             document.getElementById("ContentPlaceHolder1_txtsearchname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsearchname").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_txt_Modulename").value="";
document.getElementById("ContentPlaceHolder1_ddlstatus").value="";
}

</script>

 <h4>
    Profile Details</h4>
       <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
    <td >               
       <asp:Label ID="Label1" runat="server" Text="Searchby Profile Name"></asp:Label>
        <br />     
        <asp:TextBox ID="txtsearch" runat="server" style="width:200px;"></asp:TextBox>
        &nbsp;&nbsp; &nbsp;<asp:Button ID="btn_search" runat="server"
                CssClass="search" OnClick="btn_search_Click"
                 />
        </td>
            </tr></table>
			</div>
    <br />
    
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                <Columns>
                    <asp:BoundField DataField="profilename" HeaderText="Profile Name" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                                   
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("profileid")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("profileid")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
         <asp:HiddenField ID="hiddn_id" runat="server" />
         <center> 
             <asp:LinkButton ID="Linkdownload" runat="server" OnClick="Linkdownload_Click">Download Excel</asp:LinkButton></center>
    <br />
            
            
<h4>
        Add Profile Details  </h4>
         <div class="free-forms">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td colspan="2" style="text-align:center; padding:0px;">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="formlabel">
                        Profile Name</td>
                    <td style="height: 36px">
                        <asp:TextBox ID="txt_Modulename" runat="server" MaxLength="100" CssClass="text" ></asp:TextBox>
                     
                    </td>
                </tr>
        <tr>
            <td class="formlabel">
                Profile Status</td>
            <td>
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="0">Deactive</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
         <td colspan="2" style=" text-align:center;">
                        <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" />
    &nbsp; &nbsp;<input id="Reset1" class="btnStyle2" title="Reset" onclick="javascript:return Reset();" type="button"
                            value="Reset" /><br />
            </td>
        </tr>
            </table>
			</div>
    <br />
    <br />
    <br />
</asp:Content>

