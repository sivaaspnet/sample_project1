<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master"  EnableEventValidation="False" AutoEventWireup="true" CodeFile="coursesummary.aspx.cs" Inherits="superadmin_coursesummary" Title="Course Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"  >
<script type="text/javascript">
 

</script>
 
<div class="title-cont">
    <h3 class="cont-title">Course Summary</h3>
    <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="coursesummary.aspx" class="last">Course Summary</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
 <div class="search-sec-cont">
  <ul>
        <li>
          <div class="wth-1">Select Course Name :</div>
          <div class="wth-2"> <asp:DropDownList ID="ddlcourse" runat="server" CssClass="menu-sele" Width='500px' AutoPostBack="True" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged">  </asp:DropDownList>      
 </div></li></ul>
 <div class="clear"></div>
 </div>
<div id="divSummary" runat="Server" class="free-forms">
<table class="common" width="100%">
 <tr>
   <td colspan="2">
        <h4 class="headingStudinfo">Code</h4>
        <br />
        <asp:Label ID="lblprogramcode" ForeColor="Maroon" runat="Server" /> 
     </td>   
     <td  colspan="2">
        <h4 class="headingStudinfo">Course Name</h4>
        <br />
        <asp:Label ID="lblcourse" runat="server" ForeColor="Maroon"  /> 
     </td > 
 </tr>
 <tr>
 <td colspan="2">
 <h4 class="headingStudinfo">Track </h4>
 <table>
   <tr>
 <td style="width: 106px">Track Type: </td>
 <td style="text-align: left;"><asp:Label ID="lbltrack" ForeColor="Maroon" runat="Server" /></td>
 <td style="text-align: left;">Duraton :
 </td>
 <td style="text-align: left;"><asp:Label ID="lblduration" ForeColor="Maroon" runat="Server" /></td>
 </tr>
 
  <tr>
 <td >Track Type: </td>
 <td >
     <asp:Label ID="lbltrackfast" ForeColor="Maroon" runat="Server" /></td>
     <td >Duraton :</td>
 <td>    <asp:Label ID="lbldurationfast" ForeColor="Maroon" runat="Server" /></td>
 </tr> 
 </table>
 </td>
  <td colspan="2" style="vertical-align:top">
  <h4 class="headingStudinfo">Fees </h4>
   <table> 
  <tr>
 <td >Lump Sum Fees : </td>
 <td ><asp:Label ID="lbllumpsum" ForeColor="Maroon" runat="Server" /></td>
 </tr>
 <tr> 
 <td >Installment Fees : </td>
 <td> <asp:Label ID="lblinstallment" ForeColor="Maroon" runat="Server" /></td>
 </tr>
  </table>
  </td>
  </tr>
</table>

 
	<div class="dataGrid" style="padding:0px 10px;display:inline;text-align:center;" >
	 
	<div style="float:left; padding:0 10 0 10px; width: 315px;" align="center">
	<h4 class="headingStudinfo">Module Details</h4>
        <asp:GridView ID="gvCourseModule" runat="server" CssClass="common" AutoGenerateColumns="False"   EmptyDataText="No Modules Found"  style="float:left;padding:0 0 0 10px;">
           <Columns>
           <asp:TemplateField HeaderText="Modules">
                  <ItemTemplate> 
                  <asp:HiddenField ID="csid" runat="Server" Value='<%#Eval("coursesoftware_id")%>' /> 
                   <%#Eval("module_content")%>
                  </ItemTemplate>
               </asp:TemplateField>              
           </Columns>
        <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
        </div>       
        <div style="float:left; padding:0 10 0 10px; margin-left:15px; margin-bottom:10px; width: 315px;"   align="center">
        <h4 class="headingStudinfo">Project Details</h4>
      <asp:GridView ID="gvModuleProject" runat="server" CssClass="common" AutoGenerateColumns="False" EmptyDataText="No Projects Found">
           <Columns>
           <asp:BoundField DataField="module_content" HeaderText="Module" />
           <asp:BoundField DataField="projectname" HeaderText="Project Name" />
           </Columns>
        <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
        </div>
         <div style="float:left; margin-left:15px; padding:0 10 0 10px; width: 315px;" align="center">
        <h4 class="headingStudinfo">Book Details</h4>
        <asp:GridView ID="gvCourseBook" runat="server" CssClass="common" AutoGenerateColumns="False"   EmptyDataText="No Books Found"  style="float:left;padding:0 0 0 10px;">
           <Columns>
           <asp:TemplateField HeaderText="Books">
                  <ItemTemplate>                  
                   <%#Eval("book_content")%>
                  </ItemTemplate>
               </asp:TemplateField>              
           </Columns>
        <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
        </div>
        <div style="overflow:auto;max-height:400px; clear:both; display:block">
        <h4 class="headingStudinfo">Content Details [<asp:Label ID="Label5" runat="server"></asp:Label>
            ]</h4>
        <asp:GridView CssClass="common" ID="gvCourseContent" runat="server" AutoGenerateColumns="False"  EmptyDataText="No Contents Found"   Width="100%" style="float:left;">
                <Columns> 
                    <asp:BoundField DataField="Module" HeaderText="Module" />
                    <asp:BoundField DataField="Software" HeaderText="Software" />
                    <asp:BoundField DataField="Content" HeaderText="Content" />             
                </Columns>
                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
        </asp:GridView>
       </div>
       </div> 
</div>
   <asp:LinkButton ID="LinkButton1"   runat="server" OnClick="LinkButton1_Click">Download Excel</asp:LinkButton>  
</asp:Content>

