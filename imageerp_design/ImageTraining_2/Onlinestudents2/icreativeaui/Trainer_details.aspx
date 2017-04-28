<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Trainer_details.aspx.cs" Inherits="Trainer_details" Title="NSDC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
      
        .input-lbl2
{
    
	font-size:16px;
float:right;
	
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
        width: 404px;
    }
          .style2
        {
            width: 400px;
        }
    .style3
    {
        width: 405px;
    }
    </style>
    <script type="text/javascript">
        function validation() {
            if (document.getElementById("<%=ddlcenter.ClientID %>").value == "") {
                alert("Please Select center");
                document.getElementById("<%=ddlcenter.ClientID %>").focus();
                return false;
           }
           if (document.getElementById("<%=txttrainerid.ClientID %>").value == "") {
                alert("Please Enter TrainerID");
                document.getElementById("<%=txttrainerid.ClientID %>").focus();
                return false;
                }

                if (document.getElementById("<%=txttrainername.ClientID %>").value == "") {
                alert("Please Enter Trainer Name");
                document.getElementById("<%=txttrainername.ClientID %>").focus();
                return false;
            }
            return true; 
        }
      </script>
      <div class="title-cont">
    <h3 class="cont-title">Trainer Details</h3>
    <div style="color:#1b70c5; font-size:14px; float:right; margin-top:30px">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="course_details.aspx">Course List</asp:HyperLink>&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="centre_details.aspx">Centre List</asp:HyperLink>&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Trainer_details.aspx">Trainer List</asp:HyperLink>
</div>
  </div> 
  
  <div class="white-cont">     
       
        <h4 class="cont-title2">Add Trainer</h4>
           <div class="form-cont">
            <ul>
              <li>
                <label class="label-txt">Centre Name</label>     
         <asp:DropDownList runat="server" ID="ddlcenter" CssClass="sele-txt"></asp:DropDownList></li>                     
 <li><label class="label-txt">Trainer ID</label>  <asp:TextBox runat="server" ID="txttrainerid" CssClass="text input-txt"></asp:TextBox></li>
<li><label class="label-txt">Trainer Name</label><asp:TextBox runat="server" ID="txttrainername"  CssClass="text input-txt"></asp:TextBox></li>
  <li style="text-align:center;"><div align="center" style="padding-bottom:25px;"><asp:Button  runat="server" ID="btnsubmit" Text="submit" OnClientClick="return validation();" 
        onclick="btnsubmit_Click" CssClass="btnStyle1"/></div></li></ul>
         <div class="clear"></div>
</div></div>
  
  <div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Centre</div>
        <div class="wth-2"> <asp:DropDownList runat="server" ID="ddlcenter_search" CssClass="sele-txt" Width="500px"></asp:DropDownList></div>
      </li>
        <li>  
        <asp:Button ID="btn_search" runat="server" CssClass="search-btn" Text="Search"  OnClick="btnsearch_Click" />      
    
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
     <asp:Label runat="server" ID="lblmsg"  ForeColor="Red"></asp:Label>
    </div>
    <div style="padding:0px 10px 10px 10px">
  <asp:GridView ID="GridView1" runat="server"    AutoGenerateColumns="false" OnRowCommand="GridView1_OnRowCommand"
        AllowPaging="true" EmptyDataText="No Records Found" PageSize="10" OnPageIndexChanging="OnPageIndexChanging" 
        CssClass="tbl-cont3"   CellPadding="3" CellSpacing="1" Width="65%" >
         
          <Columns>
        
       
        <asp:BoundField  DataField="Center_Name" HeaderText="Center Name"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>

        
        
        <asp:BoundField  DataField="TrainerID" HeaderText="Trainer Id" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField  DataField="TrainerName" HeaderText="Trainer Name" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
       
          <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
<asp:LinkButton ID="LnkBtnEdit"  CommandName ="CEdit" CommandArgument ='<%#Eval("TrainerID")+","+Eval("Center_Code")%>' runat="server" Font-Underline="True">Edit</asp:LinkButton>/
  <asp:LinkButton ID="lnkbtndel"  CommandName ="CDelete" CommandArgument ='<%#Eval("TrainerID")+","+Eval("Center_Code")%>' runat="server" Font-Underline="True" OnClientClick="javascript:return confirm('Do you want to delete this trainer detail?')">Delete</asp:LinkButton>

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