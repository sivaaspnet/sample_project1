<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewReport.aspx.cs" Inherits="superadmin_ViewReport" Title="View Report Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
function sortval()
{
clearValidation('ctl00_ContentPlaceHolder1_txtfromcalender~ctl00_ContentPlaceHolder1_txttocalender');
  if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender").value=="";   
             alert("Please select the From date");
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
           
             return false;
         }
   else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttocalender").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender").value=="";   
             alert("Please select the To date");
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddl_sa_cencode").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_sa_cencode").value=="";   
             alert("Please select centre code");
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_sa_cencode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_sa_cencode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_sa_cencode").style.backgroundColor="#e8ebd9";
             return false;
         }//ddl_sa_cencode
     else
     {
     return true;
     }
}
</script>

    <table cellpadding="1"  class="common">
        <tr>
            <td colspan="3" style=" padding:0px" >
            <h4>View Enquiry Student Report</h4>
            </td>
        </tr>
    <tr><td colspan="3" >
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr id="viewonly_to_sa" runat="server">
            <td colspan="3">
                Select centre code<br />
                <asp:DropDownList ID="ddl_sa_cencode" runat="server" OnSelectedIndexChanged="ddl_sa_cencode_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 212px" >
                From Date<br />
                <asp:TextBox ID="txtfromcalender" runat="server" CssClass="text datepicker" Width="92px" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                 
             
                </td>
            <td>
                To Date<br />
                <asp:TextBox ID="txttocalender" runat="server" CssClass="text datepicker" Width="92px" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                &nbsp; &nbsp;
                <asp:Button ID="btnsort" runat="server" Text="Sort" CssClass="submit" OnClick="btnsort_Click" OnClientClick="javascript:return sortval();" /></td>
        </tr>
        <tr>
            <td colspan="3">
                </td>
        </tr>
      
        <tr>
            <td colspan="3" style="height: 21px; text-align:center;">
                <a href="Droppedstudentdetails.aspx" class="error">Dropped Student Report</a></td>
        </tr>
             <tr>
                 <td colspan="3" style="height: 21px; text-align:center;">
                     <a href="Followingstudentdetails.aspx" class="error">Following Student Report</a></td>
        </tr> 
      
    </table>
     <br />
    <table class="common">
        <tr>
            <td style=" padding:0px; height: 29px;">
              <h4>Enquiry Details</h4>
            </td>
        </tr>
        <tr>
            <td >           
    
        <asp:GridView ID="GridView1" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" >
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
                     <a rel="modal" href="analysisview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=325"><img src="../layout/32.gif" alt="View" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closing Details">
               <ItemTemplate>
                 <a rel="modal" href="closingstatusview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=325"><img src="../layout/32.gif" alt="View" /></a>
            
               </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View More...">
                    <ItemTemplate>
                      <a rel="modal" href="personalview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlfollowstatus" runat="server" CssClass="select">
                          <asp:ListItem Value="Following">Following</asp:ListItem>
                          <asp:ListItem Value="Spot enrolled">Spot enrolled</asp:ListItem>
                          <asp:ListItem Value="Very propective">Very propective</asp:ListItem>
                          <asp:ListItem Value="Propective">Propective</asp:ListItem>
                          <asp:ListItem Value="Not propective">Not propective</asp:ListItem>
                          <asp:ListItem Value="Fake">Fake</asp:ListItem>
                          <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
                          <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>  
                        </asp:DropDownList>
                        <asp:Button ID="btnupd" runat="server"  ToolTip="Update" CssClass="update" OnClick="btnupd_Click" />
                       <asp:Label ID="hdnstatus" Visible="False" runat="server"  Text='<%# Eval("enq_enqstatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Followups">
                <ItemTemplate>
                    <asp:Label ID="lblhdnmsg" runat="server" Text='<%#Eval("enq_number")%>' Visible="false"></asp:Label>
                 <a href="followup.aspx?enqno=<%#Eval("enq_number")%>"><img src="../layout/text.gif" width="20px" height="20px" alt="Trace" /></a> || <a rel="modal[]" href="followupview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=1000&amp;height=500"><img src="../layout/32.gif" alt="View" /></a>
              
                    
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>

            </td>
        </tr>
    </table>
   
  
       <asp:HiddenField ID="hdnenqID" runat="server" Value='<%#Eval("enq_number")%>' />
       <table  class="common"><tr><td style="color: #ff3366" colspan="2">Key:  </td></tr>
        <tr><td><img src="../layout/text.gif" alt="Trace" />-Click on to Trace the Follow ups</td><td><img src="../layout/32.gif" alt="View" />-Click to View the Details</td></tr>
         <tr><td colspan="2">
             <asp:Label ID="Label1" runat="server" ForeColor="DarkGreen" CssClass="link" Text="Enquiry No"></asp:Label>---Click on Enquiry No to Reach the Admission form</td></tr>
        </table> 
    <br />
    <br />
        
        
        
   
</asp:Content>

