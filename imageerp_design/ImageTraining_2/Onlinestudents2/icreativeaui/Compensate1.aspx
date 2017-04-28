<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Compensate1.aspx.cs" Inherits="superadmin_ViewbatchDetails" Title="Compensate" %>
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
		
            <td style="width:30%">
                <asp:Label ID="Label1" runat="server" Text="Student ID"></asp:Label>
                <asp:TextBox ID="stuid" runat="server" Width="150px"></asp:TextBox></td>
            <td style="width:30%" >
               Module
                <asp:DropDownList ID="ddl_module" runat="server">
                </asp:DropDownList>
            </td>
     
            <td>
               
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" /></td>
				
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
                                 <asp:BoundField DataField="batchcode" HeaderText="BatchCode" />
                   
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
            </td>
        </tr>
       
          
           
    
    </table>
		</div>
  
  
   </asp:Content>

