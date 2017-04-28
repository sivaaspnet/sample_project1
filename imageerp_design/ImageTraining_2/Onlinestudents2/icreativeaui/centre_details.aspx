<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="centre_details.aspx.cs" Inherits="centre_details" Title="NSDC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
     function validation() {
         if (document.getElementById("<%=ddlcenter.ClientID %>").value == "") {
             alert("Please Select center");
             document.getElementById("<%=ddlcenter.ClientID %>").focus();
             return false;
         }
         if (document.getElementById("<%=txt_sdms_centerid.ClientID %>").value == "") {
             alert("Please Enter SDMS CenterID");
             document.getElementById("<%=txt_sdms_centerid.ClientID %>").focus();
             return false;
         }
         if (document.getElementById("<%=ddltcstate.ClientID %>").value == "") {
             alert("Please Select TC State");
             document.getElementById("<%=ddltcstate.ClientID %>").focus();
             return false;
         }
         if (document.getElementById("<%=ddltcdistrict.ClientID %>").value == "") {
             alert("Please Select TC District");
             document.getElementById("<%=ddltcdistrict.ClientID %>").focus();
             return false;
         }
         return true;
     }
      </script>
    <style type="text/css">
       
        .input-lbl2
{
   
	font-size:16px;
float:right;
            margin-right: 16;
        }
.input-txt1{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 210px;
	
	font-size:14px;
	color:#666666;
    margin-left: 0px;
     
}
.input-txt1:focus
{
    background-color: #FFFFCC;
}
.input-ddl{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 225px;
	
	font-size:14px;
	color:#666666;
    margin-left: 0px;
    float:left;
}
.input-ddl:focus
{
    background-color: #FFFFCC;
}

        .style1
        {
            width: 439px;
        }
        .style3
        {
            width: 385px;
        }
        .style4
        {
            width: 382px;
        }
    </style>
 <div class="title-cont">
    <h3 class="cont-title">Centre Details</h3>
   <div style="color:#1b70c5; font-size:14px; float:right; margin-top:30px">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="course_details.aspx">Course List</asp:HyperLink>&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="centre_details.aspx">Centre List</asp:HyperLink>&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Trainer_details.aspx">Trainer List</asp:HyperLink>
</div>
  </div> 
<div class="white-cont">     
       
        <h4 class="cont-title2">Add Centre</h4>
           <div class="form-cont">
            <ul>
              <li>
                <label class="label-txt">Centre Name</label>     
         <asp:DropDownList runat="server" ID="ddlcenter" CssClass="sele-txt"></asp:DropDownList></li>        
 <li><label class="label-txt">SDMS CentreID</label> 
                 <asp:TextBox runat="server" ID="txt_sdms_centerid" CssClass="text input-txt"></asp:TextBox></li>                
 <li><label class="label-txt">TCState</label>  <asp:DropDownList runat="server" ID="ddltcstate" 
        onselectedindexchanged="ddltcstate_SelectedIndexChanged" AutoPostBack="true" CssClass="sele-txt"></asp:DropDownList></li>
<li><label class="label-txt">TCDistrict</label><asp:DropDownList runat="server" ID="ddltcdistrict" CssClass="sele-txt"></asp:DropDownList></li>
  <li style="text-align:center;"><div align="center" style="padding-bottom:25px;"><asp:Button  runat="server" ID="btnsubmit" Text="submit" OnClientClick="return validation();" 
        onclick="btnsubmit_Click" CssClass="btnStyle1"/></div></li></ul>
         <div class="clear"></div>
</div></div>

<div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Centre Name</div>
        <div class="wth-2"> <asp:TextBox runat="server" ID="txtcentre_name" CssClass="text input-txt" Width="500px"></asp:TextBox></div>
      </li>
        <li>  
        <asp:Button ID="btn_search" runat="server" CssClass="search-btn" Text="Search"  OnClick="btnsearch_Click" />      
    
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
     <asp:Label ID="lblmsg" runat="server" ForeColor="Red"> </asp:Label>
    </div>
    <div style="padding:0px 10px 10px 10px">
  <asp:GridView ID="GridView1" runat="server"    AutoGenerateColumns="false" OnRowCommand="GridView1_OnRowCommand"
        AllowPaging="true" EmptyDataText="No Records Found" PageSize="10" OnPageIndexChanging="OnPageIndexChanging" 
          CssClass="tbl-cont3"  CellPadding="3" CellSpacing="1" Width="100%" >
          <Columns>
        
       
        <asp:BoundField ItemStyle-Width="50px" DataField="Center_Name" HeaderText="Center_Name"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>

         <asp:BoundField ItemStyle-Width="150px" DataField="SDMS_CenterID" HeaderText="SDMS_CenterID" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
       
        
        <asp:BoundField ItemStyle-Width="50px" DataField="TCState" HeaderText="TCState" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="TCDistrict" HeaderText="TCDistrict" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
       
          <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
<asp:LinkButton ID="LnkBtnEdit"  CommandName ="CEdit" CommandArgument ='<%#Eval("Center_Code")%>' runat="server" Font-Underline="True">Edit</asp:LinkButton>/
  <asp:LinkButton ID="lnkbtndel"  CommandName ="CDelete" CommandArgument ='<%#Eval("Center_Code")%>' runat="server" Font-Underline="True" OnClientClick="javascript:return confirm('Do you want to delete this center?')">Delete</asp:LinkButton>

                                                                           </ItemTemplate>
         </asp:TemplateField>
        </Columns>
       <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        </asp:GridView>         </div>
     <div align="center" style="padding:0px 0px 15px 0px;">
           <asp:LinkButton ID="LinkButton1" onclick="btn_excel_Click" 
      runat="server" CssClass="download-btn">Download as Excel </asp:LinkButton>
          </div>
	</div>




 

        </asp:Content>