<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Followingstudentdetails.aspx.cs" Inherits="superadmin_Followingstudentdetails" Title="Following Student Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
clearValidation('ContentPlaceHolder1_txtfromcalenderf~ContentPlaceHolder1_txttocalenderf');
  if(trim(document.getElementById("ContentPlaceHolder1_txtfromcalenderf").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalenderf").value=="";   
             alert("Please select the From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalenderf").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalenderf").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalenderf").style.backgroundColor="#e8ebd9";
             return false;
         }
   else if(trim(document.getElementById("ContentPlaceHolder1_txttocalenderf").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txttocalenderf").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalenderf").focus();
             document.getElementById("ContentPlaceHolder1_txttocalenderf").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalenderf").style.backgroundColor="#e8ebd9";
             return false;
         }
     else
     {
     return true;
     }
}
</script>

<div class="free-forms">

    <table cellpadding="1" width="100%"  class="common">
        <tr>
            <td colspan="3" style="padding:0px;">
            <h4>Followed Student Report<asp:Button ID="btnback" runat="server" Text="Back" CssClass="back" OnClick="btnback_Click" /></h4>

            </td>
        </tr>
       
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
        <tr>
            <td colspan="2" style="width: 52px">
                From Date<br />
                <asp:TextBox ID="txtfromcalenderf" Width="233px" runat="server" CssClass="text datepicker" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                 
             
                </td>
            <td>
                To Date<br />
                <asp:TextBox ID="txttocalenderf" runat="server" Width="233px" CssClass="text datepicker" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return sortval();" OnClick="btnsort_Click1" /></td>
        </tr>
      
    </table>
    <table class="common" width="100%">
        <tr>
            <td  style="padding:0px;" >
            <h4>Followed student Details</h4>
            </td>
        </tr>
        <tr>
            <td >
             <asp:GridView Width="100%" ID="GridView1" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Enquiry No">
                    <ItemTemplate>
                   <%#Eval("enqno")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Date/Time">
                <ItemTemplate>
                    <%#Eval("dateins")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                       <%#Eval("enq_personal_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Analysis Details">
                    <ItemTemplate>
                     <%#Eval("Created_By") %>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField HeaderText="Analysis Details">
                    <ItemTemplate>
                     <a rel="modal" href="analysisview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=325"><img src="../layout/32.gif" title="Click here to view the analysis details" alt="View" /></a>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Closing Details">
               <ItemTemplate>
                 <a rel="modal" href="closingstatusview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=325"><img src="../layout/32.gif" title="Click here to view the closing details" alt="View" /></a>
               </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View More...">
                    <ItemTemplate>
                      <a rel="modal" href="personalview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" title="Click here to view the personal details" alt="View" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="View FollowUp...">
                    <ItemTemplate>
                      <a style="margin-left:15px;"  rel="modal[]" href="followupview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=1000&amp;height=500"><img src="../layout/32.png" title="Click here to view the followup details" alt="View" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
       
            </td>
        </tr>
    </table>
    <br />

 
    
       
 <table width="100%"  class="common"><tr><td style="color: #ff3366" colspan="2">Key:  </td></tr>
        <tr><td colspan="2"><img src="../layout/32.gif" alt="View" />-Click to View the Details</td></tr>
         <tr><td colspan="2">
             <asp:Label ID="Label1" runat="server" ForeColor="DarkGreen" CssClass="link" Text="Enquiry No"></asp:Label>---Click on Enquiry No to Reach the Admission form</td></tr>
        </table> 
    <br />
    <br />
    <br />


</div>






</asp:Content>

