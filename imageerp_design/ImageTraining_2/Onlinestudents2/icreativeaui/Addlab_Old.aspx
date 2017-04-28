<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Addlab_Old.aspx.cs" Inherits="superadmin_Addlab" Title="Add lab" %>
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
    clearValidation('ctl00_ContentPlaceHolder1_txt_labname~ctl00_ContentPlaceHolder1_txt_systems')
      if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the lab name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_labname").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter number of systems!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_systems").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
    
function Reset1_onclick() {
location.href="Addlab.aspx";
}

</script>
    <table class="common">
        <tr>
            <td style=" padding:0px;"><h4>Lab Details</h4>

            </td>
        </tr>
        <tr>
    <td style="text-align:center;">
       <asp:Label ID="Label1" runat="server" Text="Searchby Lab Name"></asp:Label>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
      
       <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text"></asp:TextBox>&nbsp; &nbsp;<asp:Button ID="btn_search" runat="server" CssClass="search" OnClick="btn_search_Click" />&nbsp;
        </td>
            </tr><tr><td style="text-align:center"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
    </tr></table>
    
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" EmptyDataText="No Results Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="lab_name" HeaderText="Lab Name" />
                    <asp:BoundField DataField="sys_count" HeaderText="Number of Systems" />
                   
                                   
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("lab_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("lab_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
           <PagerSettings Position="TopAndBottom" />
            </asp:GridView>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <br />
            
         
    
    <table  class="common">
        <tr>
            <td colspan="2" style="padding:0px;">   <h4>Add Lab Details</h4>
            </td>
        </tr>
                
                <tr>
                    <td class="w290 talignleft" style="width: 98px">
                        LabName</td>
                    <td>
                        <asp:TextBox ID="txt_labname" runat="server" MaxLength="40" CssClass="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 98px">
                        Number of systems</td>
                    <td>
                        <asp:TextBox ID="txt_systems" runat="server" MaxLength="3" CssClass="text" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
                </tr>
            </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                       <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" />
    &nbsp; &nbsp;<input id="Reset1" type="reset" value="Reset" class="submit" onclick="return Reset1_onclick()" />&nbsp;&nbsp;
                        <br />
    <br />
</asp:Content>

