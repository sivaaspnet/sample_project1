<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Add_Bookdetails.aspx.cs" Inherits="superadmin_Add_Moduledetails" Title="Add_Bookdetails" %>
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
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Module name';
             document.getElementById("ContentPlaceHolder1_txt_Modulename").focus();
             document.getElementById("ContentPlaceHolder1_txt_Modulename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_Modulename").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_ddlstatus").value)=="")
         {
             //document.getElementById("ContentPlaceHolder1_ddlstatus").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the exam status';
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
                Book Details</h4>
                   <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
    <td >               
       <asp:Label ID="Label1" runat="server" Text="Searchby Book Name"></asp:Label>
        <br />       
       <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text"></asp:TextBox>&nbsp; &nbsp;<asp:Button ID="btn_search" runat="server"
                CssClass="search" OnClick="btn_search_Click"
                 />
        </td>
            </tr></table>
			</div>
    <br />
    
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                <Columns>
                    <asp:BoundField DataField="bookname" HeaderText="Book Name" />
                    <asp:BoundField DataField="status" HeaderText="Book Status" />
                                   
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("bookid")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("bookid")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <br />
            
            
  <h4>
        Add Book Details  </h4>
          <div class="free-forms">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td colspan="2" style="height: 7px; text-align:center">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="formlabel">
                        Book Name</td>
                    <td>
                        <asp:TextBox ID="txt_Modulename" runat="server" MaxLength="100" CssClass="text" ></asp:TextBox>
                        &nbsp;&nbsp;
                    </td>
                </tr>
        <tr>
            <td class="formlabel">
                Book Status</td>
            <td>
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Enable">Enable</asp:ListItem>
                    <asp:ListItem Value="Disable">Disable</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
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

