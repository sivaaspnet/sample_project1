<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ProjectEvaluation.aspx.cs" Inherits="superadmin_ProjectEvaluation" Title="Project Evaluation" %>

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
	    function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}     
	 function Validate()
     {
     if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtproject").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the project guide!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").style.backgroundColor="#e8ebd9";
           
             return false;
         }
        else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtmark").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtmark").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Mark!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtmark").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtmark").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtmark").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtEvaluatedBy").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtEvaluatedBy").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Project Evaluated By!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtEvaluatedBy").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtEvaluatedBy").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtEvaluatedBy").style.backgroundColor="#e8ebd9";
             return false;
         }
    
        else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Remarks!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddlstatus").value)=="Select")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddlstatus").value=="Select";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the status!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddlstatus").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddlstatus").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlstatus").style.backgroundColor="#e8ebd9";
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
            <td  style="padding:0px;" colspan="2"> <h4>
      Project Details</h4>
            </td>
        </tr>
        <tr style="padding-bottom:0px;">
    <td align="right" style=" padding-bottom:0px;">
        <asp:Label ID="Label2" runat="server" Text="Searchby Module Name"></asp:Label>
        &nbsp; &nbsp;&nbsp;
    </td>
        <td align="right" style="padding-bottom:0px;">
                <asp:Label ID="Label3" runat="server" Text="Searchby Centre"></asp:Label></td>
            </tr>
        <tr style="padding:0px;">
            <td align="right" >
                <asp:DropDownList ID="ddlsearchmodname" runat="server">
        </asp:DropDownList></td>
            <td align="right">
                <asp:DropDownList
                    ID="ddlCentre" runat="server">
                </asp:DropDownList>&nbsp; 
        <asp:Button ID="btnsearch" runat="server"  CssClass="search"  OnClick="btnsearch_Click" /></td>
        </tr>
        <tr><td style="text-align:center" colspan="2"><asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
    </tr></table>
    <br />
    
    <asp:GridView ID="grdcentre" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="grdcentre_RowCommand" PageSize="15" OnPageIndexChanging="grdcentre_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Student ID">
             <ItemTemplate>
             <asp:LinkButton ID="lnkView" CommandName="Cmdview" CommandArgument='<%#Eval("ProjectID") %>' runat="server">
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
            <asp:TemplateField HeaderText="Status">
             <ItemTemplate>
             <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Status").ToString())%>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CommandName="cmdApprove" Visible="false" CommandArgument='<%#Eval("ProjectId") %>' runat="server">Approve</asp:LinkButton>
                    <asp:Label ID="lblApprove" Visible="false" runat="server" Text="Approved"></asp:Label>
                    <asp:Label ID="lblStatus" Visible="false" runat="server" Text='<%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Status").ToString())%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
    </asp:GridView>
    <br />
    <table id="tblvis" runat="server" visible="false" cellspacing="0" cellpadding="0" class="common">
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="error"></asp:Label></td></tr>
                        <tr>
                            <td class="w290 talignleft" style="width: 118px">
                                Student ID</td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:TextBox ID="txt_StudentId" runat="server"  CssClass="text" MaxLength="20" ReadOnly="True" Width="318px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="w290 talignleft" style="width: 118px">
                                Student name</td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:TextBox ID="txt_StudentName" runat="server" CssClass="text" MaxLength="100" ReadOnly="True" Width="318px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="w290 talignleft" style="width: 118px">
                                Course</td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                                    Width="318px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="w290 talignleft" style="width: 118px">
                                Module</td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:TextBox ID="txtModule" runat="server" CssClass="text" MaxLength="20" ReadOnly="True"
                                    Width="318px"></asp:TextBox></td>
                        </tr>
                                <tr>
            <td class="w290 talignleft" style="width: 118px">
                Send Date</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtSenddate" runat="server" CssClass="text" MaxLength="20" Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>
                <tr>
            <td class="w290 talignleft" style="width: 118px">
                Project Guided By</td>
            <td align="left" colspan="2" valign="middle">
                                <asp:TextBox ID="txtproject" runat="server" MaxLength="30" CssClass="text" Width="318px" ReadOnly="True"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Dispatch Date</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtDispatchdate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True" Width="318px"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Mark</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtmark" runat="server" CssClass="text" MaxLength="100" Width="318px"></asp:TextBox></td>
        </tr>
                <tr id="evaldate" runat="server" visible="false">
            <td class="w290 talignleft" style="width: 118px">
                Evaluated Date</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtEvalDate" runat="server" CssClass="text" MaxLength="4" onkeypress="return CheckNumeric(event)"
                    Width="318px"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Evaluated By</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtEvaluatedBy" runat="server" CssClass="text" MaxLength="30" Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Remarks</td>
            <td align="left" colspan="2" valign="middle">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="text" MaxLength="200" Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 118px">
                Status</td>
            <td align="left" colspan="2" valign="middle">
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                    <asp:ListItem>Rejected</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
                      
                        <tr id="btnvis" visible="false" runat="server">
                            <td style="height:30px; text-align:center;" class="w290 talignleft" colspan="3">
                                &nbsp;
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="submit" OnClientClick="javascript:return Validate();" OnClick="btnsubmit_Click"/></td>
                        </tr>
                    </table>
    <asp:HiddenField ID="hdnID" runat="server" />
    &nbsp;
    <asp:Label ID="lblProjectId" runat="server" Visible="False"></asp:Label>
    <asp:HiddenField ID="hdnID1" runat="server" />
    <br />

</asp:Content>

