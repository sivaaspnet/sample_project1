<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ProjectAssesment.aspx.cs" Inherits="superadmin_ProjectAssesment" Title="Project Assesment" %>

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
            <td align="right" style="padding:0px" colspan="2">
              <h4>
      Project Details</h4>

            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label2" runat="server" Text="Searchby Module Name"></asp:Label></td>
            <td >
                <asp:Label ID="Label3" runat="server" Text="Searchby Status" Width="145px"></asp:Label></td>
        </tr>
        <tr>
    <td >
                <asp:DropDownList ID="ddlsearchmodname" runat="server">
        </asp:DropDownList>
    </td>
        <td >
                <asp:DropDownList
                    ID="ddlstatus" runat="server">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Process</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                    <asp:ListItem>Rejected</asp:ListItem>
                </asp:DropDownList>&nbsp;
            <asp:Button ID="btnsearch" runat="server"  CssClass="search"  OnClick="btnsearch_Click" /></td>
            </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
    </table>
    <br />
    
    <asp:GridView ID="grdcentre" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="grdcentre_RowCommand" OnPageIndexChanging="grdcentre_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Student ID">
             <ItemTemplate>
             <asp:LinkButton ID="LinkButton1" CommandName="Cmdview" CommandArgument='<%#Eval("ProjectID") %>' runat="server">
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("StudentId").ToString())%>
             </asp:LinkButton>
             </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Student Name">
             <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("StudentName").ToString())%>
             </ItemTemplate>
                </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Course">
             <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Course").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Module">
               <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Module").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
             <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Status").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>
    <br />
    <table id="tblvis" runat="server" cellpadding="0" cellspacing="0" class="common"
        visible="false">
        <tr>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td >
                                Student ID</td>
            <td  colspan="2" valign="middle" >
                <asp:TextBox ID="txt_StudentId" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                    Width="200px"></asp:TextBox></td>
            <td  colspan="1"  >
                Dispatch Date</td>
            <td  colspan="1" >
                <asp:TextBox ID="txtDispatchdate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                    Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td >
                                Student name</td>
            <td  colspan="2" >
                <asp:TextBox ID="txt_StudentName" runat="server" CssClass="text" MaxLength="100"
                    ReadOnly="True" Width="200px"></asp:TextBox></td>
            <td  colspan="1" >
                Mark</td>
            <td align="left" colspan="1" style="width: 335px" valign="middle">
                <asp:TextBox ID="txtmark" runat="server" CssClass="text" MaxLength="4" onkeypress="return CheckNumeric(event)"
                    Width="200px" ReadOnly="True" OnTextChanged="txtmark_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td >
                                Course</td>
            <td  colspan="2" >
                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                    Width="200px"></asp:TextBox></td>
            <td colspan="1" >
                Evaluated Date</td>
            <td colspan="1" >
                <asp:TextBox ID="txtEvalDate" runat="server" CssClass="text" MaxLength="4" onkeypress="return CheckNumeric(event)"
                    Width="200px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td >
                                Module</td>
            <td  colspan="2" >
                <asp:TextBox ID="txtModule" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                    Width="200px"></asp:TextBox></td>
            <td  colspan="1" >
                Evaluated By</td>
            <td colspan="1" >
                <asp:TextBox ID="txtEvaluatedBy" runat="server" CssClass="text" MaxLength="30" Width="200px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td >
                Send Date</td>
            <td  colspan="2">
                <asp:TextBox ID="txtSenddate" runat="server" CssClass="text" MaxLength="20" Width="200px" ReadOnly="True"></asp:TextBox></td>
            <td  colspan="1" >
                Remarks</td>
            <td  colspan="1" >
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="text" MaxLength="200" Width="200px" ReadOnly="True"></asp:TextBox></td>
        </tr>
                        <tr>
            <td >
                Project Guided By</td>
            <td  colspan="2" >
                <asp:TextBox ID="txtproject" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                    Width="200px"></asp:TextBox></td>
                            <td colspan="1">
                            </td>
                            <td colspan="1">
                            </td>
        </tr>
        <tr>
            <td  colspan="5" >
                </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnID1" runat="server" />

</asp:Content>

