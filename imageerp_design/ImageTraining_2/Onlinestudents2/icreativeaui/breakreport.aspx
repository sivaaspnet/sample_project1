<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="breakreport.aspx.cs" Inherits="superadmin_Droppedstudentdetails" Title="Breakreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_TextBox2").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_TextBox2").autocomplete('Handler4.ashx');
   // alert("check");  
    });  
</script>
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	   {
	     return stringToTrim.replace(/^\s+|\s+$/g,"");
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
function sortval()
{
clearValidation('ContentPlaceHolder1_txtfromcalender~ContentPlaceHolder1_txttocalender');
  if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
             return false;
         }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalender").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender").style.backgroundColor="#e8ebd9";
             return false;
         }
     else
     {
     return true;
     }
}

function val()

{

if(trim(document.getElementById("ContentPlaceHolder1_TextBox2").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_TextBox2").value=="";   
             alert("Enter Student Name");
             document.getElementById("ContentPlaceHolder1_TextBox2").focus();
             document.getElementById("ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
             return false;
         }
  
     else
     {
     return true;
     }
}
</script>


     <h4>Student Break Report</h4>      
         <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
    <tr><td >
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr>
            <td >
                &nbsp;
               From Date<br />
                &nbsp;
                <asp:TextBox ID="txtfromcalender" runat="server" CssClass="text datepicker" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>                </td>
           
            <td >
               &nbsp;
                To Date<br />
                &nbsp;<asp:TextBox ID="txttocalender" runat="server" CssClass="text datepicker" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
                &nbsp;<asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="btnStyle1" onclientclick="javascript:return sortval();" OnClick="btnsort_Click" /><br />
                &nbsp; &nbsp;
				</td>
        </tr>
    </table>
  </div>
    <br />
 <div class="free-forms">
    <table class="common" width="100%"><tr><td style=" padding:0px;">
 <h4>Student Break Details</h4></td></tr>
    <tr>
        <td>
            Student ID/Name :
            <asp:TextBox ID="TextBox2" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>&nbsp;<asp:Button
                ID="Button1" runat="server"  CssClass="search" OnClick="Button1_Click" />
                 <br />
                <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="TextBox2"></asp:CustomValidator>
                </td>
    </tr>
 <tr><td>
    <p>
	<div class="dataGrid">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="grdcentre_PageIndexChanging"
            OnRowCommand="grdcentre_RowCommand" width="100%">
            <Columns>
               <asp:TemplateField HeaderText="Student ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                    </EditItemTemplate>
                   <ItemTemplate>
                    <a class="error" href='studentreportdetails.aspx?StudentID=<%#Eval("studentid")%>'>
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                <asp:BoundField DataField="breakdate" HeaderText="Break Date" />
                <asp:BoundField DataField="reason" HeaderText="Reason" />
           <asp:TemplateField HeaderText="Resume">
                        <ItemTemplate>
                          <asp:LinkButton ID="lnkedit" CommandName="lnkedit" CommandArgument='<%#Eval("studentid")%>' runat="server" ToolTip="Resume Student"><img src="layout/refresh_icon.gif" /></asp:LinkButton> 
                        </ItemTemplate>
                          </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" />
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
        &nbsp;</div></p></td></tr></table></div>
    <br />






</asp:Content>

