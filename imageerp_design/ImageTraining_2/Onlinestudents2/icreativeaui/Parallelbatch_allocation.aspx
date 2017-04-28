<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Parallelbatch_allocation.aspx.cs" Inherits="Onlinestudents2_superadmin_Parallelbatch_allocation" Title="Parallel batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
  function parallelbatch()
  {
      if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_track").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_track").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_track").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select track!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_track").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_track").style.backgroundColor="#e8ebd9";
             return false;
         } 
      else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_softwarelist").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softwarelist").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softwarelist").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select software!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softwarelist").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softwarelist").style.backgroundColor="#e8ebd9";
             return false;
         } 
      else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_studentlist").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_studentlist").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_studentlist").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select student id!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_studentlist").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_studentlist").style.backgroundColor="#e8ebd9";
             return false;
         }
        
       else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_parallel_batchcode").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_parallel_batchcode").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_parallel_batchcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_parallel_batchcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_parallel_batchcode").style.backgroundColor="#e8ebd9";
             return false;
         } 
         var listBox2len = document.getElementById("ctl00_ContentPlaceHolder1_lbox2").options.length;
         if(listBox2len == 8)
         {
          document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Batch is full!';
          return false;
         }
         var res= confirm("Are you sure! You want to allocate parallel batch?");
          if(res)
          {
          return true;
          }
        else
         {
         return true;
         } 
    }
</script>

<table class="common" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" style="padding:0px;"><h4>Parallel Batch Allocation</h4>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center"><asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label>
        </td>
    </tr>
<tr><td valign="top" style="vertical-align:top;width:50%">
    <table class="common">
        <tr>
        
            <td colspan="2">
                <h2>Select student from this batch</h2></td>
        </tr>
        
        <tr>
            <td style="width: 113px">
                Select Track</td>
            <td>
                <asp:DropDownList ID="ddl_track" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_track_SelectedIndexChanged">
                <asp:ListItem Value="">--Select--</asp:ListItem>
                 <asp:ListItem Value="Fast">Fast</asp:ListItem>
                 <asp:ListItem Value="Normal">Normal</asp:ListItem>
                 <asp:ListItem Value="Zip">Zip</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 113px">
                Select Software</td>
            <td>
                <asp:DropDownList ID="ddl_softwarelist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_softwarelist_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 113px">
                Select Student</td>
            <td>
                <asp:DropDownList ID="ddl_studentlist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_studentlist_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 113px">
                Student current batch</td>
            <td>
                <asp:Label ID="lbl_bc1" runat="server" Text=''></asp:Label>
              
                </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btn_Movestudent" runat="server" CssClass="submit" OnClientClick="javascript:return parallelbatch();" Text="Allocate>>" OnClick="btn_Movestudent_Click" /></td>
        </tr></table>
</td>
<td>
     <table class="common">
         <tr>
             <td colspan="2">
                 <h2>
                     Allocate parallel batch to student</h2></td>
         </tr>
        <tr>
            <td style="width:97px">
                Select batchcode</td>
            <td>
                <asp:DropDownList ID="ddl_parallel_batchcode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_parallel_batchcode_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 97px">
                Track</td>
            <td>
                <asp:Label ID="lbl_parallel_track" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 97px">
                Time</td>
            <td>
                <asp:Label ID="lbl_parallel_time" runat="server" Text=''></asp:Label></td>
        </tr>
         <tr>
             <td style="width: 97px">
                 Slot</td>
             <td>
                 <asp:Label ID="lbl_slot" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 97px">
                 Lab</td>
             <td>
                 <asp:Label ID="lbl_lab" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 97px">
                 Faculty</td>
             <td>
                 <asp:Label ID="lbl_Faculty" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 97px">
                 Start date</td>
             <td>
                 <asp:Label ID="lbl_parallel_startdate" runat="server" Text=''></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 97px">
                 End date</td>
             <td>
                 <asp:Label ID="lbl_parallel_enddate" runat="server" Text=''></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 97px">
                 Current s/w</td>
             <td>
                 <asp:Label ID="lbl_parallel_software" runat="server" Text=''></asp:Label></td>
         </tr>
        <tr><td style="width: 97px">
            Studentid</td><td>
            <asp:ListBox ID="lbox2" runat="server"></asp:ListBox></td></tr></table>
</td></tr>
</table>



</asp:Content>

