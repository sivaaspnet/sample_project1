<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master"   AutoEventWireup="true" CodeFile="notification.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReportDetails" Title="Student details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

 <div class="notification">
	<ul>
	
		<li><a runat="server" id="a1" href="#Drop">Drop Request</a></li>
		<li><a runat="server" id="a2" href="#Leave">Leave Request</a></li>
		<li><a runat="server" id="a3" href="#Assesment">Assesment Request</a></li>
		<li><a runat="server" id="a4" href="#Recommened">Recommened To Update</a></li>
       <li><a runat="server" id="a5" href="#transfer">Student Transfer</a></li>
       <li><a runat="server" id="a6"  href="#test">Book Indent Request</a></li>
   

   
   </ul>
	
	<div id="Drop" style="width:100%">
	
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand"
        Style="margin-left:-13px" EmptyDataText="No Request Found" CssClass="common" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="StudentID">
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
            <asp:BoundField DataField="reason" HeaderText="Reason" />
            <asp:BoundField DataField="requesteddate" HeaderText="Requested Date" />
            <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("studentid") %>'
                        CommandName="lnkedit" OnClick="LinkButton1_Click">Remove</asp:LinkButton>&nbsp;
                    <asp:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("studentid") %>'
                        CommandName="drop1" OnClientClick="javascript:return confirm('Do you want to Drop the Student?');" runat="server">Drop</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BorderColor="#C00000" BorderStyle="Solid" />
        <EmptyDataRowStyle BorderColor="ControlDark" BorderStyle="Solid" />
    </asp:GridView>
           
	</div>
	
	
	
	
	
	
	
	
	<div id="Leave" style="width:100%" >
<asp:GridView id="grleave" runat="server" CssClass="common"  AutoGenerateColumns="False" OnRowCommand="grdcentre_RowCommand" EmptyDataText="No Leave Request" Style="margin-left:-11px" Width="100%">
        <Columns>
               <asp:TemplateField HeaderText="StudentID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a class="error" href='studentreportdetails.aspx?StudentID=<%#Eval("studentid")%>'>
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="enq_personal_name" HeaderText="Name" ></asp:BoundField>
            <asp:BoundField DataField="fromdate" HeaderText="From Date" ></asp:BoundField>
            <asp:BoundField DataField="todate" HeaderText="To Date" ></asp:BoundField>
            <asp:BoundField DataField="noofdays" HeaderText="No Of Days" ></asp:BoundField>
            <asp:BoundField DataField="reason" HeaderText="Reason" ></asp:BoundField>
             <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove" CommandName="approve"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> 
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline"  CommandName="decline" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>                 
            </asp:TemplateField>
            <asp:TemplateField HeaderText="status">
            <ItemTemplate>
                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Eval("status_cen")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove1" CommandName="approve1"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> |
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline1"  CommandName="decline1" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>       
            
            
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast"   />
        <EmptyDataRowStyle ForeColor="Red"   />
    </asp:GridView>
	</div>
	
	
	
	
	
	
	
	<div id="Assesment" style="width:100%"  >



<%if (Session["Centrerole"].ToString() == "R&D")
          {
         %>
        <center><h3><b>Assessment Request</b></h3></center>
    <div class="gridSort" style="margin-top:10px" runat="server" id="gridSort">
         <table  class="common" id="assesment_search" runat="server" visible="false" >
            <tr>
                <td style="width: 70px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Cetre Code"></asp:Label></td>
                <td style="width: 105px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click" /></td>
            </tr>
        </table>
        </div>
<%}%>

           <asp:GridView ID="gridassesment" runat="server" AutoGenerateColumns="False" EmptyDataText="No request found" Width="100%" CssClass="common">
                 <Columns>
            <asp:TemplateField HeaderText="StudentID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a class="error" href='Assesment.aspx?StudentID=<%#Eval("studentid")%>&&Projectid=<%#Eval("projectid")%>&&centrecode=<%#Eval("centrecode")%>#Assesment'>
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
                     <asp:BoundField DataField="enq_personal_name" HeaderText="Name" />
                     <asp:BoundField DataField="projectname" HeaderText="Project" />
                     <asp:BoundField DataField="module" HeaderText="Module" />
          
        </Columns>
                    <EditRowStyle BorderColor="Black" BorderStyle="Solid" />
                    <EmptyDataRowStyle BorderColor="ControlDark" BorderStyle="Solid" ForeColor="#C00000" />
                
                </asp:GridView>



	</div>
	
	
	
	
	
	
	
	
	
	<div id="Recommened" style="width:100%" runat="server">
	<div style ="max-height:400px;overflow:auto;">
	<asp:GridView id="GridView1" runat="server"  AutoGenerateColumns="False" CssClass="common" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Student ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("student_id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                 <asp:HiddenField ID="HdnExpressSt" Value='<%#Eval("ExpressEnrollSt")%>' runat="server"  />
                      <asp:HiddenField ID="hdnEnqid" runat="server" Value='<%#Eval("enq_number")%>'  />
                    <asp:Label ID="lblStudId" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Student Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("enq_personal_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("enq_personal_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
	</div>
	</div>
	
	
	
	
	
	
	
	
	<div id="transfer" runat="server">
	        <%if (Session["Centrerole"].ToString() == "SuperAdmin")
          {
         %>
       <center><h3><b>Transfer Request</b></h3></center><%}%>
	
     <div class="gridSort" style="margin-top:10px" runat="server" id="dd2" visible="false">
     
         <table  class="common" id="transfer_search" runat="server"  >
            <tr>
                <td style="width: 70px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="StudentId"></asp:Label></td>
                <td style="width: 105px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Button ID="Button2" runat="server" CssClass="search" OnClick="Button2_Click" /></td>
            </tr>
        </table>
        </div> 
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="common" Width="100%" EmptyDataText="No Transfer Request" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView3_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="StudentID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a class="error" href='ExportOldtonew.aspx?StudentID=<%#Eval("studentid")%>' >
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
           
                <asp:BoundField DataField="reason" HeaderText="Reason" />
                <asp:BoundField DataField="transferedto" HeaderText="Transferedto" />
                <asp:BoundField DataField="transferedfrom" HeaderText="TransferedFrom" />
            </Columns>
        </asp:GridView>
       
	
	
	</div>
	
	
	
	
	
	<div id="test">
	<asp:GridView ID="GridView4" style="width:100%;border-collapse:collapse;" runat="server" AutoGenerateColumns="False" CssClass="common">
        <Columns>
         <asp:TemplateField HeaderText="StudentID">
               
                <ItemTemplate>
                    <a class="error" href='Bookrequest.aspx?StudentID=<%#Eval("studentid")%>&course=<%#Eval("courseid")%>&request=<%#Eval("requested_date")%>' >
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="enq_personal_name" HeaderText="Name" />
                  <asp:BoundField DataField="requested_date" HeaderText="Requested Date" />
                  <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        </asp:GridView>
        
        <asp:GridView ID="GridView5" style="width:100%;border-collapse:collapse;" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record">
        <Columns>
            <asp:BoundField DataField="centre_location" HeaderText="Centre" />
         <asp:TemplateField HeaderText="StudentID">
               
                <ItemTemplate>
                    <a class="error" href='Bookresponse.aspx?StudentID=<%#Eval("studentid")%>&course=<%#Eval("courseid")%>&request=<%#Eval("requested_date")%>' >
                        <%#Eval("studentid")%>
                    </a>
                </ItemTemplate>
                 </asp:TemplateField>
                  <asp:BoundField DataField="enq_personal_name" HeaderText="Name" />
                  <asp:BoundField DataField="requested_date" HeaderText="Requested Date" />
                    <asp:BoundField DataField="approved_date" HeaderText="Approved Date" />
                  <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
        </asp:GridView>
	
	
	</div>
	
	
	
	
	
	
	
	<div id="book">
	
	
        
        
        
        
        
        
        
        
	</div>
	
	
	
	
	
	
	
	
	
	
	</div>
  
  
</asp:Content>

