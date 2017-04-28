<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Submodule_Details_New.aspx.cs" Inherits="superadmin_Submodule_Details_New" Title="Submodule Details" %>
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
    clearValidation('ContentPlaceHolder1_DDlModule~ContentPlaceHolder1_DDlSoftware')
      if(trim(document.getElementById("ContentPlaceHolder1_DDlModule").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_DDlModule").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the module name';
             document.getElementById("ContentPlaceHolder1_DDlModule").focus();
             document.getElementById("ContentPlaceHolder1_DDlModule").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DDlModule").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ContentPlaceHolder1_DDlSoftware").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_DDlSoftware").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the software name';
             document.getElementById("ContentPlaceHolder1_DDlSoftware").focus();
             document.getElementById("ContentPlaceHolder1_DDlSoftware").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DDlSoftware").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_TxtContent").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_TxtContent").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the content';
             document.getElementById("ContentPlaceHolder1_TxtContent").focus();
             document.getElementById("ContentPlaceHolder1_TxtContent").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TxtContent").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
    
    
    function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_ddlsearchmodname").value=="" && document.getElementById("ContentPlaceHolder1_txtsearchname").value=="" )
         {
         
            
             document.getElementById("ContentPlaceHolder1_ddlsearchmodname").focus();
             document.getElementById("ContentPlaceHolder1_ddlsearchmodname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlsearchmodname").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_DDlModule").value="";
document.getElementById("ContentPlaceHolder1_DDlSoftware").value="";
document.getElementById("ContentPlaceHolder1_TxtContent").value="";


}


</script>

    <h4>
    SubModule Details</h4>
                                <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
    <td style="padding-bottom:0px; width:355px" >
        <asp:Label ID="lblModuleId" runat="server"></asp:Label>
        &nbsp;Searchby Module name </td>
        <td style="padding-bottom:0px;">
       <asp:Label ID="Label1" runat="server" Text="Searchby Software Name"></asp:Label>
        &nbsp;&nbsp;
        </td>
            </tr><tr><td >
        <asp:DropDownList ID="ddlsearchmodname" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlsearchmodname_SelectedIndexChanged">
        </asp:DropDownList></td>
      <td>
          <asp:DropDownList ID="ddl_software" runat="server" Width="250px">
          </asp:DropDownList>
      &nbsp;
        <asp:Button ID="btn_search" runat="server"   CssClass="search" OnClick="btn_search_Click" />&nbsp;</td>
    </tr></table>
	</div>
    <br />
    
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Module" HeaderText="Module" />
                    <asp:BoundField DataField="Software" HeaderText="Software" />
                    <asp:BoundField DataField="Content" HeaderText="Content" />
                   
                                   
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("Submodule_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("Submodule_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
            <center>
                <asp:LinkButton ID="Linkdownload" runat="server" OnClick="Linkdownload_Click">Download Excel</asp:LinkButton>
            </center>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <br />
           
    

            <h4>
        Add Software Details 
    </h4>
     <div class="free-forms">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td colspan="2" style="text-align:center; ">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="formlabel">
                        Module</td>
                    <td >
                        <asp:DropDownList ID="DDlModule" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDlModule_SelectedIndexChanged" >
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formlabel">
                        Software</td>
                    <td >
                        <asp:DropDownList ID="DDlSoftware" CssClass="text" runat="server" >
                        </asp:DropDownList></td>
                </tr>
        <tr>
            <td class="formlabel">
                Content</td>
            <td >
                <asp:TextBox ID="TxtContent" CssClass="text" runat="server" ></asp:TextBox>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                        <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" /> &nbsp;&nbsp;
                        <input id="Reset1" class="btnStyle2" onclick="javascript:return Reset();" type="button"
                            value="Reset" title="Reset" /><br />
                <br />
            </td>
        </tr>
            </table>
			</div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />
    <br />
</asp:Content>

