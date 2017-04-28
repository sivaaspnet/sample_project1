<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Menus.aspx.cs" Inherits="superadmin_Menus" Title="Menu Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<% if (Session["SA_Centrerole"] .ToString() == "Counselor" || Session["SA_Centrerole"] .ToString() == "CentreManager")
   {
       %>
  <table class="common"><tr><td  style=" padding:0px;"><h4>Course Details</h4></td></tr> 
     <tr><td>

<asp:GridView ID="Gridviewcourse" Width="500" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Results Found" PageSize="10" OnPageIndexChanging="Gridviewcourse_PageIndexChanging" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField HeaderText="Program">
                 <ItemTemplate>
                     <a rel="modal" href="view_softwareversion.aspx?cou_id=<%#Eval("course_id")%>&iframe=true&amp;width=600&amp;height=500"><%#Eval("program")%></a>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Duration">
                 <ItemTemplate>
                   <%#Eval("duration")%>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Track">
                 <ItemTemplate>
                   <%#Eval("track")%>
                 </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Lump Sum">
                 <ItemTemplate>
                   <%#Eval("lump_sum")%>
                 </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Installment Amount">
                 <ItemTemplate>
                   <%#Eval("instal_amount")%>
                 </ItemTemplate>
                </asp:TemplateField>       
            </Columns>
        </asp:GridView>
        </td></tr>
        </table>
    <br />
        <%} %>   
    <% if (Session["SA_Centrerole"] .ToString() == "Technical Head")
    {
    %>
  <table class="common"><tr><td  style=" padding:0px;"><h4>Course Details</h4></td></tr> 
     <tr><td>
<asp:GridView ID="GriDVTECH" Width="500" runat="server" CssClass="common" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Results Found" PageSize="10" HorizontalAlign="Center" OnPageIndexChanging="GriDVTECH_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Program">
                 <ItemTemplate>
                           <a rel="modal" href="view_softwareversion.aspx?cou_id=<%#Eval("course_id")%>&iframe=true&amp;width=600&amp;height=500"><%#Eval("program")%></a>
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Duration">
                 <ItemTemplate>
                  <%#Eval("duration")%>
                 </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Track">
                 <ItemTemplate>
                  <%#Eval("track")%>
                 </ItemTemplate>
                </asp:TemplateField>
                 
            </Columns>
        </asp:GridView>
        </td></tr>
        </table>
    <br />
        <%} %>
        
         <%if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
         {
         %>
   <table width="500" class="common">
        <tr>
            <td colspan="3" style=" padding:0px"><h4>
                Dash board Consolidated Report</h4>
            </td>
        </tr>
        <tr>
       <td class="w290 talignleft"> <img src="../layout/icon.plus.gif" alt="" />    
                Total no of enquiries in all the branches  :</td>
            <td>
                <asp:Label ID="lbltotalenquiry" CssClass="error" runat="server" Text=''></asp:Label></td>
              
        </tr>
        <tr>
            <td class="w290 talignleft"><img src="../layout/icon.plus.gif" alt="" />  Today's enquiries  :
            </td>
            <td>
                <asp:Label ID="lbltodayenq" CssClass="error" runat="server" Text=''></asp:Label></td>
               
        </tr>
          <tr>
            <td class="w290 talignleft"><img src="../layout/icon.plus.gif" alt="" />  Total revenue from enrollment :
            </td>
          
                 <td>
                     <asp:Label ID="lbltotrevenue_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
          <tr>
            <td class="w290 talignleft"><img src="../layout/icon.plus.gif" alt="" />  Total revenue collected as Lump sum :
            </td>
         
                 <td><asp:Label ID="lbltotlumpsum_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
          <tr>
            <td class="w290 talignleft"><img src="../layout/icon.plus.gif" alt="" />  Total revenue collected as  Installment :
            </td>
           
                 <td><asp:Label ID="lbltotinstal_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
         <tr>
            <td class="w290 talignleft"><img src="../layout/icon.plus.gif" alt="" />  Fees collected for Today :
            </td>
          
                 <td><asp:Label ID="lbltotcollection_tax" CssClass="error" runat="server" Text=''></asp:Label></td>
        </tr>
    </table>
    <br />
     <table width="500" class="common">
        <tr>
            <td colspan="2" style=" padding:0px"><h4>
                View Centrewise Report</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <br />
            &nbsp;Sortby Centre name&nbsp;
                <asp:DropDownList ID="ddl_cencode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_cencode_SelectedIndexChanged" ToolTip="Select the centre code">
                </asp:DropDownList></td>
        </tr>
            <tr><td colspan="2" style="text-align:center" align="center">
             
                        <table style="width:500px" align="center" runat="server" id="individualtable">
                            <tr>
                                <td>
                                    Centre Code</td>
                                <td>
                                    <asp:Label ID="lbl_cen_code" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                          <tr>
                                <td>
                                    Centre name</td>
                                <td>
                                    <asp:Label ID="lbl_cen_name" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            
                            <tr>
                                <td>
                                    Total no of enquiries</td>
                                <td >
                                    <asp:Label ID="lbl_tot_enq" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td>  <a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Enq=1&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" title="Click to View the Enquiry" /></a></td>
                            </tr>
                            <tr>
                                <td>
                                    Today's Enquiries</td>
                                <td>
                                    <asp:Label ID="lbl_today_enq" CssClass="error" runat="server" Text=""></asp:Label></td><td></td>
                            </tr>
                            <tr>
                                <td>
                                    Total no of students enrolled</td>
                                <td>
                                    <asp:Label ID="lbl_no_enroll" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td> <a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Adm=1&iframe=true&amp;width=1000&amp;height=700"><img src="../layout/32.gif" alt="View" title="Click to view the Enrolment Detail" /></a></td>
                            </tr>
                            <tr>
                                <td>
                                    Total no of batches in Progress&nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_no_batch" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td><a rel="modal" href="view_superadmin.aspx?cencod=<%=lbl_cen_code.Text%>&Batch=1&iframe=true&amp;width=1600&amp;height=850"><img src="../layout/32.gif" alt="View" title="Click to View the batch detail" /></a></td>
                            </tr>
                            <tr>
                                <td style="height: 25px">
                                    Total Revenue Collected as Lumpsum</td>
                                <td style="height: 25px">
                                    <asp:Label ID="lbl_tot_lusum" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td style="height: 25px"></td>
                            </tr>
                            <tr>
                                <td>
                                    Total Revenue collected as Installment</td>
                                <td>
                                    <asp:Label ID="lbl_tot_insamt" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                            <tr>
                                <td>
                                    Fees collected for today</td>
                                <td>
                                    <asp:Label ID="lbl_fees_today" CssClass="error" runat="server" Text=""></asp:Label></td>
                                    <td></td>
                            </tr>
                          
                        </table>
             
                  </td></tr>    
                 <tr id="View1" runat="server"><td colspan="2">
                 <img src="../layout/32.gif" alt="View" /> ---- Click on to View the Information
                 </td></tr> 
        </table>
         
         
         
         <%} %>
</asp:Content>

