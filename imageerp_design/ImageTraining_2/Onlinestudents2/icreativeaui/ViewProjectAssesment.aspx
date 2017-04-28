<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewProjectAssesment.aspx.cs" Inherits="superadmin_ViewProjectAssesment" Title="View Project Assesment" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
 <script language="javascript" type="text/javascript">
 
   function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  

function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}     
	        
	 function Validate()
     {
         if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Student ID!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Student Name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").style.backgroundColor="#e8ebd9";
             return false;
         }
    
      else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").value)=="")
         {
             
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the course!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").value=="")
         {
             
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the module!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").style.backgroundColor="#e8ebd9";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtproject").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Project Guide!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
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
function searchval()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").value=="" && document.getElementById("ctl00_ContentPlaceHolder1_txtsearchname").value=="" )
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").style.backgroundColor="#e8ebd9";
             return false;
         } 
        else
        {
        return true;
        }

}
function btnreset_onclick()
 {
  location.href="addcentre.aspx";
 }
</script>

    <table class="common">
        <tr>
            <td align="right" colspan="3" style=" padding:0px;">  <h4>
      Project Details</h4>
            </td>
        </tr>
        <tr>
    <td align="right" style="padding-bottom:0px;">
        <asp:Label ID="Label2" runat="server" Text="Searchby Module Name"></asp:Label></td>
            <td align="right" colspan="2" style="padding-bottom:0px;">
                <asp:Label ID="Label3" runat="server" Text="Searchby Centre"></asp:Label></td>
            </tr>
        <tr>
            <td align="right">
                <asp:DropDownList ID="ddlsearchmodname" runat="server">
        </asp:DropDownList></td>
            <td align="right" colspan="2">
                <asp:DropDownList ID="ddlCentre" runat="server">
                </asp:DropDownList>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3" style="padding-bottom:0px;">
                <asp:Label ID="Label4" runat="server" Text="Searchby Status"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <asp:DropDownList
                    ID="ddlstatus" runat="server">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Process</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                    <asp:ListItem>Rejected</asp:ListItem>
                </asp:DropDownList>&nbsp;
        <asp:Button ID="btnsearch" runat="server" CssClass="search"  OnClick="btnsearch_Click" /></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
    </tr></table>
    <br />
    <div style="max-height:350px; overflow:auto;">
    <asp:GridView ID="grdcentre" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="grdcentre_RowCommand" PageSize="100" OnPageIndexChanging="grdcentre_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Student ID">
             <ItemTemplate>
             <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("ProjectID") %>'
                        CommandName="Cmdview">
                        <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("StudentId").ToString())%>
                       </asp:LinkButton> 
             </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
             <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("StudentName").ToString())%>
             </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Centre Code">
             <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("CentreID").ToString())%>
             </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Module">
               <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Module").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Label ID="lblProject" Visible="false" runat="server" Text='<%#Eval("ProjectId") %>'></asp:Label>
                    <asp:Button ID="Button1" Visible="false" CssClass="submit" CommandName="Upd" CommandArgument='<%#Eval("ProjectId") %>' runat="server" OnClick="Button1_Click" Text="Process" />
                    <asp:Label ID="lblApprove" Visible="false" runat="server" Text="Completed"></asp:Label>
                    <asp:Label ID="lblProcess" Visible="false" runat="server" Text="Processed"></asp:Label>
                    <asp:Label ID="lblReject" Visible="false" runat="server" Text="Rejected"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>
    </div>
    <br />
    <br />
    <table id="tblvis" runat="server" cellpadding="0" cellspacing="0" class="common"
        visible="false">
        <tr>
            <td align="left" colspan="3" style="height: 5px" valign="middle">
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Student ID</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txt_StudentId" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                    Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Student name</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txt_StudentName" runat="server" CssClass="text" MaxLength="100"
                    ReadOnly="True" Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Course</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                    Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Module</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtModule" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                    Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Send Date</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtSenddate" runat="server" CssClass="text" MaxLength="20" Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>
                        <tr>
            <td class="w290 talignleft">
                Project Guided By</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtproject" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                    Width="318px"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="w290 talignleft">
                Dispatch Date</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtDispatchdate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                    Width="318px"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="w290 talignleft">
                Mark</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtmark" runat="server" CssClass="text" MaxLength="4" onkeypress="return CheckNumeric(event)"
                    Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr >
            <td class="w290 talignleft">
                Evaluated Date</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtEvalDate" runat="server" CssClass="text" MaxLength="4" onkeypress="return CheckNumeric(event)"
                    Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Evaluated By</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtEvaluatedBy" runat="server" CssClass="text" MaxLength="30" Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Remarks</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="text" MaxLength="200" Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="height: 5px" valign="middle">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnID1" runat="server" />

</asp:Content>

