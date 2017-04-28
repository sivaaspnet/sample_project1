<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Counselorcoursedetails.aspx.cs" Inherits="superadmin_Counselorcoursedetails" Title="Course Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">



function SearchValidate()
{

if(document.getElementById("ContentPlaceHolder1_ddlcourse").value=="" && document.getElementById("ContentPlaceHolder1_ddduration").value=="" && document.getElementById("ContentPlaceHolder1_ddtrack").value=="")
         {
         
            
             document.getElementById("ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
         } 
      
        else
        {
        return true;
        }

}




</script>
<div class="title-cont">
    <h3 class="cont-title">Course Fees Details</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="Counselorcoursedetails.aspx" class="last">Course Details</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
 <div class="gridSort">
 <div class="search-sec-cont">
<ul>
        <li>
          <div class="wth-1">Searchby Course:</div>
          <div class="wth-2">
     <asp:DropDownList ID="ddlcourse" runat="server" CssClass="menu-sele"> 
        </asp:DropDownList>
     </div></li>   
      
        <li>
          <div class="wth-1">Searchby Duration:</div>
          <div class="wth-2">            
        <asp:DropDownList ID="ddduration" runat="server" CssClass="menu-sele"> 
        </asp:DropDownList>
       </div></li>       
        <li>
          <div class="wth-1">Searchby Track:</div>
          <div class="wth-2">
            <asp:DropDownList ID="ddtrack" runat="server" CssClass="menu-sele">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                        <asp:ListItem Value="Fast">Fast</asp:ListItem>
                        <asp:ListItem Value="Normal">Normal</asp:ListItem>
                        <asp:ListItem Value="Zip">Zip</asp:ListItem>
                    </asp:DropDownList>
             </div></li>
             <li><asp:Button ID="btnsort" runat="server" Text="Apply" CssClass="btnStyle1" OnClientClick="javascript:return SearchValidate();" OnClick="Button1_Click" />
                    
       </li>
       </ul>
        <div class="clear"></div>
</div>
</div>

	 <div class="white-cont">
    <h4 class="cont-title2">Course Details</h4>
  
      <div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="Gridviewcourse" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" PageSize="10" OnPageIndexChanging="Gridviewcourse_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Course Name">
                <ItemTemplate>
                <%--<a rel="modal" class="error" href="view_softwareversion.aspx?cou_id=<%#Eval("course_id")%>&iframe=true&amp;width=600&amp;height=400"><%#Eval("coursename")%></a>--%>
                 <%#Eval("coursename")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Program">
                 <ItemTemplate>
                 <%#Eval("program")%>
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
    <EmptyDataRowStyle ForeColor="Red" />
             <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView>
         <div align="center" style="padding:10px 10px 0px 10px;">
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="download-btn" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton>
    </div>
    </div>
   
   </div>
</asp:Content>

