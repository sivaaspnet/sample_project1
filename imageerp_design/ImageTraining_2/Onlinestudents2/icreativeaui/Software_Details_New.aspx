<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Software_Details_New.aspx.cs" Inherits="superadmin_Software_Details_New" Title="Software Details" EnableEventValidation = "false" %>
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
    clearValidation('ContentPlaceHolder1_txt_SoftwareName')
      if(trim(document.getElementById("ContentPlaceHolder1_txt_SoftwareName").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_SoftwareName").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the software name';
             document.getElementById("ContentPlaceHolder1_txt_SoftwareName").focus();
             document.getElementById("ContentPlaceHolder1_txt_SoftwareName").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_SoftwareName").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ContentPlaceHolder1_txtNoDays").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtNoDays").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the no of days!';
             document.getElementById("ContentPlaceHolder1_txtNoDays").focus();
             document.getElementById("ContentPlaceHolder1_txtNoDays").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtNoDays").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_txt_SoftwareName").value="";
document.getElementById("ContentPlaceHolder1_txtNoDays").value="";



}




function TABLE1_onclick() {

}

function TABLE2_onclick() {

}

</script>


    <h4>
    Software Details</h4>
        <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td  >
              
                <asp:Label ID="Label2" runat="server" Text="Searchby Module Name" ></asp:Label>
      
            </td>
            <td  >
        
                <asp:Label ID="Label1" runat="server" Text="Searchby Software Name" Width="151px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width:320px;" >
            <asp:DropDownList ID="ddlsearchmodname" runat="server" Width="230px">
        </asp:DropDownList></td>
    <td >
        <asp:DropDownList ID="ddl_software" runat="server" Width="350px">
        </asp:DropDownList>
     
    
        <asp:Button ID="btn_search" runat="server" CssClass="search" OnClick="btn_search_Click" />
       </td>
            </tr></table>
			</div>
    <br />
    
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Software_Name" HeaderText="Software Name" />
                   <asp:BoundField DataField="Noofdays" HeaderText="No Of Days" />
                                   
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("Software_Id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("Software_Id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
            <center>
                <asp:LinkButton ID="Linkdownload" runat="server" OnClick="Linkdownload_Click">Download Excel</asp:LinkButton> </center>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <br />
            
           
   <h4>
                Add Software Details</h4>
      <div class="free-forms">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
      
        <tr>
           <td colspan="2" style="text-align:center; padding:0px;">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="formlabel">
                        Software</td>
                    <td style="height: 36px">
                        <asp:TextBox ID="txt_SoftwareName" runat="server" MaxLength="180" CssClass="text"></asp:TextBox>
                      
                    </td>
                </tr>
                <tr>
            <td class="formlabel">
                Number Of Days</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtNoDays" runat="server" CssClass="text" MaxLength="4" TextMode="SingleLine" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" />
    &nbsp;&nbsp;
                        <input id="Reset1" class="btnStyle2" title="Reset" onclick="javascript:return Reset();" type="button"
                            value="Reset" /><br />
            </td>
        </tr>
            </table>
			</div>
    &nbsp;<br />
    &nbsp; &nbsp; 
    <br />
    <br />
</asp:Content>

