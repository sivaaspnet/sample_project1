<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Feedback_view.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Feedback_view" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
 <asp:GridView CssClass="common"  ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found"  width="100%" >
                <Columns>
                  
                    <asp:TemplateField HeaderText="Batch Code">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("BatchCode") %>'></asp:Label>
        
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                
                    
                    
                  
            
                    <asp:BoundField DataField="slot" HeaderText="Slot" HtmlEncode="False" />
                    <asp:BoundField DataField="batchtiming" HeaderText="Time" HtmlEncode="False" />
                   
                    <asp:BoundField DataField="facultyname" HeaderText="Faculty" HtmlEncode="False" />
                     <asp:BoundField DataField="totalstudents" HeaderText="Total Students" HtmlEncode="False" />
                      <asp:BoundField DataField="completed" HeaderText="Total no of Completed Feedback" HtmlEncode="False" />
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
</div>
</asp:Content>

