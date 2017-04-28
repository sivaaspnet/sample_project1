<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="module_details.aspx.cs" Inherits="Onlinestudents2_superadmin_module_details" Title="Module Details" %>
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
    function moduleval()
    {
    
   // alert("test")
    
    clearValidation('ContentPlaceHolder1_listsoftwares~ContentPlaceHolder1_ddl_Module')
//      if(trim(document.getElementById("ContentPlaceHolder1_ddl_course").value)=="")
//         {
//             document.getElementById("ContentPlaceHolder1_ddl_course").value=="";
//             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Select the course name!';
//             document.getElementById("ContentPlaceHolder1_ddl_course").focus();
//             document.getElementById("ContentPlaceHolder1_ddl_course").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddl_course").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//     
//      else 
      if(trim(document.getElementById("ContentPlaceHolder1_listsoftwares").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_listsoftwares").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the Softwares!';
             document.getElementById("ContentPlaceHolder1_listsoftwares").focus();
             document.getElementById("ContentPlaceHolder1_listsoftwares").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_listsoftwares").style.backgroundColor="#e8ebd9";
             return false;
         } 
          else if(trim(document.getElementById("ContentPlaceHolder1_ddl_Module").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_Module").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the module name!';
             document.getElementById("ContentPlaceHolder1_ddl_Module").focus();
             document.getElementById("ContentPlaceHolder1_ddl_Module").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_Module").style.backgroundColor="#e8ebd9";
             return false;
         } 
//          else if(trim(document.getElementById("ContentPlaceHolder1_txtNoDays").value)=="")
//         {
//             document.getElementById("ContentPlaceHolder1_txtNoDays").value=="";
//             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the no of days!';
//             document.getElementById("ContentPlaceHolder1_txtNoDays").focus();
//             document.getElementById("ContentPlaceHolder1_txtNoDays").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txtNoDays").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
         else
         {
         return true;
         }
         
    } 
    
    
    
    
    
    
    function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_ddlsearchmodname").value=="")
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
document.getElementById("ContentPlaceHolder1_ddl_Module").value="";




  var liste = document.getElementById("ContentPlaceHolder1_listsoftwares");
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
    
<h4>
        Module Details</h4>
                    <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
    <tr>
        <td style="height: 25px; text-align:left" >
            &nbsp;Searchby Module name
            <br />
        <asp:DropDownList ID="ddlsearchmodname" runat="server" Width="350px">
        </asp:DropDownList>&nbsp;
        <asp:Button ID="btn_search" runat="server" CssClass="search" OnClick="btn_search_Click"/>
        </td>
    </tr>
    </table>
	</div>
    <br />
    
    <asp:GridView CssClass="common11"  ID="GridView1"  runat="server"  AutoGenerateColumns="False"  EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" >
                <Columns>
                    
                       <asp:TemplateField HeaderText="Software names" >
                    <ItemTemplate><%#Eval("software_name")%></ItemTemplate>
                    
                    </asp:TemplateField>            
               <asp:TemplateField HeaderText="Module name">
                    <ItemTemplate><%#Eval("module_content")%></ItemTemplate>
                    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("module_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> | <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("module_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
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
                   Add / Update Module Details</h4>
     <div class="free-forms">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td colspan="2" style="text-align:center; height: 8px;">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>

                 <tr>
                    <td class="formlabel">
                       Select Softwares</td>
                    <td >
                        <asp:ListBox ID="listsoftwares" runat="server" SelectionMode="Multiple" Height="227px" ></asp:ListBox>
                        &nbsp;&nbsp; &nbsp;</td>
                </tr>
                 <tr>
                    <td class="formlabel">
                        Module Name</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="ddl_Module" runat="server" CssClass="select">
                        </asp:DropDownList></td>
                </tr>
      <tr>
          <td  colspan="2" style=" text-align:center;">
              <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return moduleval();" />&nbsp; 
    <input id="Reset1" class="btnStyle2" onclick="javascript:return Reset();" type="button"
                            value="Reset" /><br />
              <br />
          </td>
      </tr>
            </table>
			</div>
    <br />
    <br />
    <br />
</asp:Content>

