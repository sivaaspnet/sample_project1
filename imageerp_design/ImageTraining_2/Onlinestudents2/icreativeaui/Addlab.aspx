<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Addlab.aspx.cs" Inherits="superadmin_Addlab" Title="Add lab" %>
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
    clearValidation('ContentPlaceHolder1_txt_labname~ContentPlaceHolder1_txtLabcode~ContentPlaceHolder1_txt_systems')
      if(trim(document.getElementById("ContentPlaceHolder1_txt_labname").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_labname").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the lab name!';
             document.getElementById("ContentPlaceHolder1_txt_labname").focus();
             document.getElementById("ContentPlaceHolder1_txt_labname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_labname").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtLabcode").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtLabcode").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the lab code!';
             document.getElementById("ContentPlaceHolder1_txtLabcode").focus();
             document.getElementById("ContentPlaceHolder1_txtLabcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtLabcode").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ContentPlaceHolder1_txt_systems").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_systems").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter number of systems!';
             document.getElementById("ContentPlaceHolder1_txt_systems").focus();
             document.getElementById("ContentPlaceHolder1_txt_systems").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_systems").style.backgroundColor="#e8ebd9";
             return false;
         }
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
document.getElementById("ContentPlaceHolder1_txt_labname").value="";
document.getElementById("ContentPlaceHolder1_txt_systems").value="";
document.getElementById("ContentPlaceHolder1_txtLabcode").value="";
document.getElementById("ContentPlaceHolder1_hiddn_id").value="";

}

</script>
    <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label>
	 <div class="free-forms">
    <table class="common" width="100%">
        <tr>
            <td style=" padding:0px;"><h4>Lab Details</h4>

            </td>
        </tr>
        <tr 
class="no-borders">
    <td >
       <asp:Label ID="Label1" runat="server" Text="Searchby Lab Name"></asp:Label>&nbsp;<asp:DropDownList ID="ddl_labname" runat="server">
        </asp:DropDownList>&nbsp;
        <asp:Button ID="btn_search" runat="server" CssClass="search" OnClick="btn_search_Click" /><br />
        
        </td>
            </tr></table>
			</div>
    <br />
<div style="padding:10px">
    <asp:GridView CssClass="common11" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Labname" HeaderText="Lab Name" />
                    <asp:BoundField DataField="Labcode" HeaderText="Lab Code" />
                    <asp:BoundField DataField="System" HeaderText="Number of Systems" />
                    <asp:BoundField DataField="7amto9am" HeaderText="7am to 9am" HtmlEncode="False" HtmlEncodeFormatString="False" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="9am to 11am">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("9amto11am") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("9amto11am") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="11amto1pm" HeaderText="11am to  pm" HtmlEncode="False" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                    <asp:BoundField DataField="1pmto3pm" HeaderText="1pm to 3pm" HtmlEncode="False" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                    <asp:BoundField DataField="3pmto5pm" HeaderText="3pm to 5pm" HtmlEncode="False" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                    <asp:BoundField DataField="5pmto7pm" HeaderText="5pm to 7pm" HtmlEncode="False" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                    <asp:BoundField DataField="7pmto9pm" HeaderText="7pm to 9pm" HtmlEncode="False" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                   
                                   
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                         <center>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("LabId")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> 
                             <asp:LinkButton ID="lnkdelete" Visible="false" runat="server" CommandName="del" CommandArgument='<%#Eval("LabId")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton></center>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
			</div>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <br />
            
          
    
   <div class="free-forms">
    <table class="common" width="100%">
        <tr>
            <td colspan="2" style="padding:0px;">  <h4>Add Lab Details</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; ">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="formlabel">
                        LabName</td>
                    <td>
                        <asp:TextBox ID="txt_labname" runat="server" MaxLength="40" CssClass="text"></asp:TextBox></td>
                </tr>
        <tr>
            <td class="formlabel">
                Lab Code</td>
            <td>
                <asp:TextBox ID="txtLabcode" runat="server" CssClass="text" MaxLength="3"></asp:TextBox></td>
        </tr>
                <tr>
                    <td class="formlabel">
                        Number of systems</td>
                    <td>
                        <asp:TextBox ID="txt_systems" onpaste="return false" runat="server" MaxLength="3" CssClass="text" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
                </tr>
        <tr>
            <td colspan="2" style="text-align:center">
    <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" />&nbsp;
                        <input id="Reset1" class="btnStyle2" onclick="javascript:return Reset();" value="Reset" type="button"
                            /></td>
        </tr>
            </table>
			</div>

                     
</asp:Content>

