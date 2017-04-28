<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Ipad-ViewEnquiry.aspx.cs" Inherits="superadmin_ViewEnquiry" Title="View Enquiry Page" EnableEventValidation = "false"  %>
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
var start = document.getElementById("ContentPlaceHolder1_txtfromcalender").value;
        var end = document.getElementById("ContentPlaceHolder1_txttocalender").value;

        var start_s = start.split("-");
        var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
        var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        if(curr_date<10)
        {
        curr_date='0'+curr_date;
        }
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        
        var compDate = enDate - stDate;
        var csDate = stDate - toDate;
        
        
         if(trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="" && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)==""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txtkeyword").value=="";   
             alert("Please enter the keywords");
             document.getElementById("ContentPlaceHolder1_txtkeyword").focus();
             document.getElementById("ContentPlaceHolder1_txtkeyword").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtkeyword").style.backgroundColor="#e8ebd9";
           
             return false;
         }
        else if ((trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)!=""  && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)=="")
          {
             document.getElementById("ContentPlaceHolder1_txttocalender").value=="";   
             alert("Please select the To date");
             document.getElementById("ContentPlaceHolder1_txttocalender").focus();
             document.getElementById("ContentPlaceHolder1_txttocalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttocalender").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if ((trim(document.getElementById("ContentPlaceHolder1_txtkeyword").value)=="") && trim(document.getElementById("ContentPlaceHolder1_txttocalender").value)!=""  && trim(document.getElementById("ContentPlaceHolder1_txtfromcalender").value)=="")
          {
           document.getElementById("ContentPlaceHolder1_txtfromcalender").value=="";
             alert("!Invalid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
             return false;
          }
         else if(csDate > 0)
         {
             document.getElementById("ContentPlaceHolder1_txtfromcalender").value=="";
             alert("!Invalid From date");
             document.getElementById("ContentPlaceHolder1_txtfromcalender").focus();
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromcalender").style.backgroundColor="#e8ebd9";
             return false;
        }
 
     else
     {
     return true;
     }}





function IMG1_onclick() {

}

</script>

    <table cellpadding="1" class="common" style="width: 484px">
        <tr>
            <td colspan="3" style=" padding:0px;"><h4>View Enquiry Student Report</h4>

            </td>
        </tr>
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr id="viewonly_to_sa" runat="server">
            <td colspan="3" style="text-align:left">
                Select centre code<br />
                <asp:DropDownList ID="ddl_sa_cencode" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="3" rowspan="1">
                <strong>Keywords : </strong>
                <br />
                <asp:TextBox ID="txtkeyword" runat="server"></asp:TextBox><br />
                <strong>(Enquiry No / Student Name)</strong></td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2">
                <strong>
                From Date<br />
                </strong>
                <asp:TextBox ID="txtfromcalender" onpaste="return false" runat="server" CssClass="text datepicker" Width="92px"></asp:TextBox>
            </td>
            <td rowspan="2">
                <strong>
                To Date<br />
                </strong>
                <asp:TextBox ID="txttocalender" runat="server" onpaste="return false" CssClass="text datepicker" Width="92px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnsort" runat="server" Text="Submit" CssClass="submit" OnClick="btnsort_Click" OnClientClick="javascript:return sortval();" />
            </td>
        </tr>
        <tr>
        </tr>
             <%--<tr>
                 <td style=" text-align:center;">
                     <a href="Followingstudentdetails.aspx" class="error">Following Student Report</a></td>
        </tr> --%>
      
    </table>
    <br />
    <table class="common"><tr><td style="padding:0px;">
    <h4>Enquiry Details</h4></td></tr>
    <tr><td>
    <p>

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
                
                <asp:TemplateField HeaderText="Enquired By">
                    <ItemTemplate>
                     <%#Eval("Created_By") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closing Details">
               <ItemTemplate>
                 <a rel="modal" href="closingstatusview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=600&amp;height=325"><img src="../layout/32.gif" title="Click here to view the closing details" alt="View" /></a>
                
               </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View More...">
                    <ItemTemplate>
                      <a rel="modal" href='personalview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&width=1000&height=700'><img src="../layout/32.gif" title="Click here to view the personal details" alt="View" id="IMG1" language="javascript" onclick="return IMG1_onclick()" /></a>
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
                        </asp:DropDownList><asp:Label ID="hdnstatus" Visible="false" runat="server"  Text='<%#Eval("enq_enqstatus")%>'></asp:Label>
                        <asp:Button ID="btnupd" runat="server"  CssClass="update" ToolTip="Update" OnClick="btnupd_Click"   />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Followups">
                <ItemTemplate>
                    <asp:Label ID="lblhdnmsg" runat="server" Text='<%#Eval("enq_number")%>' Visible="false"></asp:Label>
                 <a href="followup.aspx?enqno=<%#Eval("enq_number")%>"><img src="layout/text.gif" title="Click on to trace the follow ups" width="20px" height="20px" alt="Trace" /></a> || <a rel="modal[]" href="followupview.aspx?enqno=<%#Eval("enq_number")%>&iframe=true&amp;width=1000&amp;height=500"><img src="../layout/32.gif" title="Click here to view the followup details" alt="View" /></a>
              
                    
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView></p>
        <asp:LinkButton ID="LnkDownlaodExcel" runat="server" OnClick="LnkDownlaodExcel_Click">Download Excel</asp:LinkButton><br />
       <div style="display:none;">
        <asp:GridView ID="GridView2" runat="server" CssClass="common" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" >
            <EmptyDataRowStyle ForeColor="Red" />
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
                <asp:TemplateField HeaderText="Enquired By">
                    <ItemTemplate>
                        <%#Eval("Created_By") %>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Personal Number">
                    <ItemTemplate>
                        <%#Eval("enq_personal_mobile")%>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%#Eval("enq_personal_email")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="program" HeaderText="Course" />
                <asp:BoundField DataField="dateins" HeaderText="Expected Enrollment Date" />
            </Columns>
        </asp:GridView>
        </div>
    </td></tr>
        </table>
        
    <asp:HiddenField ID="hdnenqID" runat="server" Value='<%#Eval("enq_number")%>' />
    <br />
       <table class="common"><tr><td style="color: #ff3366" colspan="2">Key:  </td></tr>
        <tr><td><img src="../layout/text.gif"  alt="Trace" />-Click on to Trace the Follow ups</td><td><img src="../layout/32.gif" alt="View" />-Click to View the Details</td></tr>
        </table> 
    <br />
    <br />
        
        
        
   
</asp:Content>

