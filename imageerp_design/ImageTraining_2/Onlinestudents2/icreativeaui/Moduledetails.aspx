<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Moduledetails.aspx.cs" Inherits="superadmin_Moduledetails" Title="Moduledetails" %>
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
    clearValidation('ContentPlaceHolder1_ddl_course~ContentPlaceHolder1_Listbox_Software')
      if(trim(document.getElementById("ContentPlaceHolder1_ddl_course").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_course").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select course name!';
             document.getElementById("ContentPlaceHolder1_ddl_course").focus();
             document.getElementById("ContentPlaceHolder1_ddl_course").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_course").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ContentPlaceHolder1_Listbox_Software").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_Listbox_Software").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select software name!';
             document.getElementById("ContentPlaceHolder1_Listbox_Software").focus();
             document.getElementById("ContentPlaceHolder1_Listbox_Software").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_Listbox_Software").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
    
    function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_ddlsearchcourse").value=="" && document.getElementById("ContentPlaceHolder1_txtsoftsearch").value=="" )
         {
         
            
             document.getElementById("ContentPlaceHolder1_ddlsearchcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlsearchcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlsearchcourse").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_ddl_course").value="";



  var liste = document.getElementById("ContentPlaceHolder1_Listbox_Software");
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

<h4>Module Details</h4>
        <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td style="padding:0px; height: 16px;" >
                &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Searchby Course Name"></asp:Label>
                &nbsp;   &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; 
                <asp:Label ID="lblsearchsoftware" runat="server" Text="Searchby Module Name"></asp:Label></td>
        </tr>
        <tr>
    <td style="padding-bottom:0px; height: 24px;" >
       &nbsp;
        <asp:DropDownList ID="ddlsearchcourse" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlsearchcourse_SelectedIndexChanged">
        </asp:DropDownList>
      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddl_module" runat="server" Width="350px">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="btnsoftsearch" runat="server"   CssClass="search" OnClick="btnsoftsearch_Click"  />
        </td>
            </tr><tr><td style="text-align:center; padding:0px;">
                &nbsp;<asp:Label ID="lblsoftname" runat="server" Visible="False"></asp:Label></td>
    </tr></table>
	</div>
    <br />
    
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                <Columns>
                    <asp:BoundField DataField="coursename" HeaderText="Course" />
                    <asp:BoundField DataField="module_content" HeaderText="Module Name" />              
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("CourseSoftware_Id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("CourseSoftware_Id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
            </asp:GridView>
            <center>
                <asp:LinkButton ID="Linkdownload" runat="server" OnClick="Linkdownload_Click">Download Excel</asp:LinkButton>
            </center>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    &nbsp;&nbsp;
	<h4>Add/Update Module Details</h4>
	          <div class="free-forms">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td colspan="2" style="text-align:center;">
    <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="formlabel">
                        Course</td>
                    <td>
                        <asp:DropDownList ID="ddl_course" runat="server" CssClass="select" onChange="chkval4()">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formlabel">
                        Module</td>
                    <td>
                        <asp:ListBox ID="Listbox_Software" runat="server" Height="352px" SelectionMode="Multiple" >
                        </asp:ListBox>
                    </td>
                </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                        <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" />&nbsp;
    &nbsp;<input id="Reset1" class="btnStyle2" title="Reset" onclick="javascript:return Reset();" type="button"
                            value="Reset" /><br />
                <br />
            </td>
        </tr>
            </table>
			</div>
    <br />
    <br />
</asp:Content>

