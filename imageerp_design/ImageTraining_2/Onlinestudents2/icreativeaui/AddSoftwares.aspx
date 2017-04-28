<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="AddSoftwares.aspx.cs" Inherits="Onlinestudents2_superadmin_AddSoftwares" Title="Add Softwares" %>
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
    
    function chkval1()
    {
          if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").value=="Others")
           {
            document.getElementById("ctl00_ContentPlaceHolder1_txt_company").style.display='';       
           }
           else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").value=="")
           {
            document.getElementById("ctl00_ContentPlaceHolder1_txt_company").style.display='none';
           }
           else
           {
            document.getElementById("ctl00_ContentPlaceHolder1_txt_company").style.display='none';
           }     
    }
    
    function softwareval()
    {
    //ddl_compnames
    clearValidation('ctl00_ContentPlaceHolder1_ddl_compnames~ctl00_ContentPlaceHolder1_txt_company~ctl00_ContentPlaceHolder1_txt_softwarename~ctl00_ContentPlaceHolder1_txt_softcode~ctl00_ContentPlaceHolder1_txt_version')
    if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the Company name!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_compnames").value=="Others" && document.getElementById("ctl00_ContentPlaceHolder1_txt_company").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_company").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Company name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_company").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_company").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_company").style.backgroundColor="#e8ebd9";
             return false;
         }     
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_softwarename").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softwarename").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Software name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softwarename").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softwarename").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softwarename").style.backgroundColor="#e8ebd9";
             return false;
         } 
       else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_softcode").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softcode").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Software code!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_softcode").style.backgroundColor="#e8ebd9";
             return false;
         } 
      else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_version").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_version").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Software version!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_version").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_version").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_version").style.backgroundColor="#e8ebd9";
             return false;
         } 
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtclasess").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtclasess").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the number of classes!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtclasess").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtclasess").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtclasess").style.backgroundColor="#e8ebd9";
             return false;
         } 
         else
         {
         return true;
         }
         
    } 
    </script>
    <table class="common">
    <tr><td style="text-align:center; padding:0px"><h4>
        Software Details</h4></td></tr>
    <tr>
    <td style="text-align:center;">
       <asp:Label ID="Label1" runat="server" Text="Searchby Software name"></asp:Label>&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
      
       <asp:TextBox ID="txtsearchname"
            runat="server" CssClass="text"></asp:TextBox>&nbsp;
        <asp:Button ID="btn_search" runat="server"  CssClass="search" OnClick="btn_search_Click" />
        </td>
            </tr></table>
    
    <asp:GridView CssClass="common" ID="GridView1"  runat="server" AutoGenerateColumns="False"  EmptyDataText="No Results Found" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Company">
                    <ItemTemplate><%#Eval("Company_name")%></ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Software names">
                    <ItemTemplate><%#Eval("software_name") %></ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Software Code">
                    <ItemTemplate><%#Eval("software_code")%></ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Version">
                    <ItemTemplate><%#Eval("version")%></ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Number of classes">
                    <ItemTemplate><%#Eval("Noofclasses")%></ItemTemplate>
                    </asp:TemplateField>
            
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("software_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("software_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
           <PagerSettings Position="TopAndBottom" />
            </asp:GridView>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <asp:HiddenField ID="hiddn_softname" runat="server" />
    <br />
    <br />
            
           
    
    <table class="common" >
               <tr><td colspan="3" style="padding:0px;"> <h4>
                   Add / Update Software Details</h4></td></tr> 
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 102px">
                Company name</td>
            <td>
                <asp:DropDownList ID="ddl_compnames" runat="server" onChange="chkval1()">
                <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="Adobe">Adobe</asp:ListItem>
                
                <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                
                <asp:TextBox ID="txt_company" CssClass="text" style="display:none" MaxLength="100" runat="server"></asp:TextBox>
                <script type="text/javascript">chkval1();</script>
                </td>
                
        </tr>
                <tr>
                    <td class="w290 talignleft" style="width: 102px">
                        Software name</td>
                    <td>
                        <asp:TextBox ID="txt_softwarename" runat="server" MaxLength="40" CssClass="text"></asp:TextBox></td>
                </tr>
        <tr>
            <td class="w290 talignleft" style="width: 102px">
                Software code</td>
            <td>
                <asp:TextBox ID="txt_softcode" runat="server" MaxLength="15" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 102px">
                Version</td>
            <td>
                <asp:TextBox ID="txt_version" CssClass="text" MaxLength="20" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 102px">
                No. of classes</td>
            <td>
                <asp:TextBox ID="txtclasess" onKeyPress="return CheckNumeric(event)" runat="server" MaxLength="2" CssClass="text"></asp:TextBox></td>
        </tr>
            </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return softwareval();" />
    &nbsp; &nbsp;&nbsp;
                        <input id="Reset1" type="reset" value="Reset" class="submit" />
    &nbsp;&nbsp;
    <br />
    <br />
</asp:Content>

