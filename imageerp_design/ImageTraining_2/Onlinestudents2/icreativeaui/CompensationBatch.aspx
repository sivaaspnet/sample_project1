<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="compensationbatch.aspx.cs" Inherits="superadmin_ViewbatchDetails" Title="Compensate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_stuid").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
   
	<h4>Compensate</h4>
	<div class="gridSort" style="margin-top:10px;">
	<table class="common" id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
	<tr>
		
            <td >
                <asp:Label ID="Label1" runat="server" Text="Student ID"></asp:Label>
                <asp:TextBox ID="stuid" runat="server" ></asp:TextBox></td>
                 <td  >
               Faculty
                <asp:DropDownList ID="ddl_faculty" runat="server">
                </asp:DropDownList>
            </td>
            <td >
               Module
                <asp:DropDownList ID="ddl_module" runat="server">
                </asp:DropDownList>
            </td>
                   <td  >
              Slot
                <asp:DropDownList ID="ddl_slot" runat="server">
                       <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="MWF">MWF</asp:ListItem>
                    <asp:ListItem Value="TTS">TTS</asp:ListItem>
                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList>
            </td>
           
                   <td  >
             Timing
                <asp:DropDownList ID="ddl_timing" runat="server">
                        <asp:ListItem Value="">All</asp:ListItem>
                         <asp:ListItem Value="7AMto9Am">7AM to 9Am</asp:ListItem>
                         <asp:ListItem Value="9AMto11Am">9AM to 11Am</asp:ListItem>
                         <asp:ListItem Value="11AMto1PM">11AM to 1PM</asp:ListItem>
                         <asp:ListItem Value="1PMto3PM">1PM to 3PM</asp:ListItem>
                         <asp:ListItem Value="3PMto5PM">3PM to 5PM</asp:ListItem>
                         <asp:ListItem Value="5PMto7PM">5PM to 7PM</asp:ListItem>
                         <asp:ListItem Value="7PMto9PM">7PM to 9PM</asp:ListItem>
                </asp:DropDownList>
            </td>
     
            <td>
               
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" />
                  <br />
                    <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="stuid"></asp:CustomValidator>
                </td>
				
        </tr>
	</table>
	
	</div>
	<br />
	<div class="free-forms">
    <table class="common" id="Table2" width="100%"  >
        
        <tr>
            <td colspan="10">
            <asp:GridView CssClass="common"  ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" >
                <Columns>               
                    
                   
            
                    <asp:BoundField DataField="studentId" HeaderText="StudentId"  />
                    <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name"  />
                    <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name"  />
                    <asp:BoundField DataField="batchcode" HeaderText="BatchCode" />
                   <asp:BoundField DataField="batchTiming" HeaderText="Timing" />
                   <asp:BoundField DataField="slot" HeaderText="Slot" />
                    <asp:BoundField DataField="Module" HeaderText="Module"  />
                    <asp:BoundField DataField="Software_Name" HeaderText="Software" />
        <asp:BoundField DataField="Content" HeaderText="Class To Be Compensated"  />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                          <a  href="New_Popup.aspx?stuid=<%#Eval("studentId")%>&content=<%#Eval("subContentId")%>&module=<%#Eval("moduleid")%>&software=<%#Eval("Software_Id")%>&batchcode=<%#Eval("batchcode")%>&iframe=true&amp;width=270&amp;height=240"  rel="modal" onclick="return false"> Compensate  </a>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
            
            <p>
              &nbsp;<asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click">Download Excel</asp:LinkButton></p>
               <div style="display:none;">
                <asp:GridView CssClass="common"  ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="No Records Found" width="100%">
                <Columns>   
                    <asp:BoundField DataField="studentId" HeaderText="StudentId"  />
                    <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name"  />
                    <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name"  />
                    <asp:BoundField DataField="batchcode" HeaderText="BatchCode" />
                   <asp:BoundField DataField="batchTiming" HeaderText="Timing" />
                   <asp:BoundField DataField="slot" HeaderText="Slot" />
                    <asp:BoundField DataField="Module" HeaderText="Module"  />
                    <asp:BoundField DataField="Software_Name" HeaderText="Software" />
        <asp:BoundField DataField="Content" HeaderText="Class To Be Compensated"  />
                 
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
               </div>
            </td>
        </tr>
       
          
           
    
    </table>
		</div>

   </asp:Content>

