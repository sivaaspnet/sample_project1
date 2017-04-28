<%@ Page Title="Old Students" Language="C#" MasterPageFile="1imagemasterpage.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="Moveoldstudent.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_img_auth_Moveoldstudent"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">

        function checkZero() {
            if (document.getElementById("ContentPlaceHolder1_txtinitialamt").value == 0) {
                document.getElementById("ContentPlaceHolder1_txtinitialamt").value = "";
            }

        }
    function CheckNumeric(GetEvt) {
        var Char = (GetEvt.which) ? GetEvt.which : event.keyCode

        if (Char > 31 && (Char < 48 || Char > 57))
            return false;
        return true;
    }

    function vali() {


    }
</script>

<div class="title-cont">
    <h3 class="cont-title"> Old Student Details</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Alteration</a>/</li>
        <li><a href="Moveoldstudent.aspx" class="last">Move Old Student To New System</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>

      <div class="white-cont">
        <div class="form-cont"> 
      <ul>
           <li>
         
           <asp:HiddenField ID="hdnid" runat="server" />
                <asp:Label ID="lblerror" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
            
                <asp:LinkButton ID="LinkButton1" runat="server" 
                    PostBackUrl="~/ImageTraining_2/Onlinestudents2/icreativeaui/MovedStudentEnable.aspx">Enable Hided Student</asp:LinkButton> 
                <asp:Label ID="Label1" runat="server" ></asp:Label>
           <li>
          <li>
            <label class="label-txt">  Student ID </label>
          <asp:Label ID="lblstudentid" runat="server" Text="" CssClass="label-txt2"></asp:Label> </li>

          
           <li>
            <label class="label-txt"> Student Name </label>
           <asp:Label ID="lblstudentname"  CssClass="label-txt2" runat="server" Text=""></asp:Label>
           </li>
            <li>
            <label class="label-txt"> Current course Fee </label>
             <asp:TextBox ID="txtcurrentcoursefee" CssClass="input-txt"
                    runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtcurrentcoursefee" ErrorMessage="*" 
                    ValidationGroup="v"></asp:RequiredFieldValidator>
           </li>
  <li>
            <label class="label-txt"> Initial Amount </label>
                 <asp:TextBox ID="txtinitialamt" CssClass="input-txt"
                    runat="server" onkeypress="return CheckNumeric(event)" onKeyUp="return checkZero()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  
                 ControlToValidate="txtinitialamt"   ErrorMessage="*" ValidationGroup="v"></asp:RequiredFieldValidator>
           </li>

          
           <li>
            <label class="label-txt">No of Installment </label>
           <asp:TextBox ID="txtnoinstallment" CssClass="input-txt"
                    runat="server" onkeypress="return CheckNumeric(event)" onKeyUp="return checkZero()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  
                  ControlToValidate="txtnoinstallment"    ErrorMessage="*" ValidationGroup="v"></asp:RequiredFieldValidator>
           </li>

           <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">  <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" 
                    onclick="btnsubmit_Click" ValidationGroup="v" />     </div></li>

</ul>
            </div>
 </div>


    <div class="search-sec-cont">
    <ul>
    <li>
        <div class="wth-1"> Student Id</div>
         <div class="wth-2"> <asp:TextBox ID="txtsearchid" runat="server" CssClass="input-txt"></asp:TextBox></div>
    </li>
     <li> 
       <asp:Button ID="Button1" runat="server" onclick="Button1_Click"  CssClass="search-btn" Text="Search" /></li>
 </ul>
        <div class="clear"></div>
        </div>
    
   
      <div class="white-cont">
   
   <div style="padding:0px 10px 10px 10px">
        <asp:GridView ID="GridView1" runat="server"  CssClass="tbl-cont3" 
        AllowPaging="True" AutoGenerateColumns="False" 
        onpageindexchanging="GridView1_PageIndexChanging" 
          onrowcommand="GridView1_RowCommand" Width="100%">
        <Columns>
            <asp:BoundField DataField="Oldstudentid" HeaderText="Oldstudentid" />
             <asp:BoundField DataField="Studentname" HeaderText="Studentname" />


              <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
               <asp:BoundField DataField="Course" HeaderText="Course" />
 <asp:BoundField DataField="Invoiceid" HeaderText="Invoice No" />
  <asp:BoundField DataField="Coursefee" HeaderText="Coursefee" />
 <asp:BoundField DataField="Paidamt" HeaderText="Paidamt(Without Tax)" />

 <asp:BoundField DataField="Currentcoursefee" HeaderText="Currentcoursefee" />
 <asp:BoundField DataField="Centrecode" HeaderText="Centrecode" />
        
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
             
                
                <asp:LinkButton   ID="LinkButton4" runat="server" CommandName="lnkactivate" CommandArgument='<%#Eval("id")%>' >Activate</asp:LinkButton>
                    &nbsp;||
                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="lnkhide" CommandArgument='<%#Eval("id")%>'>Hide</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
               <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        <EmptyDataRowStyle ForeColor="Red" />
    </asp:GridView>

        </div>
           <center style="padding:0px 0px 12px 0px;">             <asp:LinkButton ID="btndownload" runat="server" Text="Download Excel" 
                    CssClass="download-btn" onclick="btndownload_Click"/></center>
           </div>
          
  
      

 
    
  

   <div style="display:none">
   <asp:GridView ID="GridView2" runat="server"  CssClass="common" 
        AutoGenerateColumns="False" 
        runat="server"  >
        <Columns>
            <asp:BoundField DataField="Oldstudentid" HeaderText="Oldstudentid" />
             <asp:BoundField DataField="Studentname" HeaderText="Studentname" />


              <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
               <asp:BoundField DataField="Course" HeaderText="Course" />
 <asp:BoundField DataField="Invoiceid" HeaderText="Invoice No" />
  <asp:BoundField DataField="Coursefee" HeaderText="Coursefee" />
 <asp:BoundField DataField="Paidamt" HeaderText="Paidamt(Without Tax)" />

 <asp:BoundField DataField="Currentcoursefee" HeaderText="Currentcoursefee" />
 <asp:BoundField DataField="Centrecode" HeaderText="Centrecode" />
   <asp:BoundField DataField="status" HeaderText="status" />      
            
        
        </Columns>
    </asp:GridView>
   
   
   </div>

</asp:Content>

