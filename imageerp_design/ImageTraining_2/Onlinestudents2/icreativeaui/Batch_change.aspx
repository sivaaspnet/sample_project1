<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Batch_change.aspx.cs" Inherits="Onlinestudents2_superadmin_Batch_change" Title="Change Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function changebatch()
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
     else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_softlist").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softlist").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softlist").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select module!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softlist").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_softlist").style.backgroundColor="#e8ebd9";
             return false;
         } 
      
      else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode1").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode1").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode1").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode1").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode1").style.backgroundColor="#e8ebd9";
             return false;
         }
      else if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode2").value=="")
         {    
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode2").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode2").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode to view batch details!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode2").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_batchcode2").style.backgroundColor="#e8ebd9";
             return false;
         }
          
         var listBoxRef = document.getElementById("ctl00_ContentPlaceHolder1_lbox1");
         var listBox2len = document.getElementById("ctl00_ContentPlaceHolder1_lbox2").options.length;
         var st=0;
         for (var i=0; i<listBoxRef.options.length; i++)
         {
              if ( listBoxRef.options[i].selected )
              { 
                st=st+1;
              }
          }
          if(st==0)
          {
            document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select studentid from the list!';
            document.getElementById("ctl00_ContentPlaceHolder1_lbox1").style.border="#ff0000 1px solid";
            document.getElementById("ctl00_ContentPlaceHolder1_lbox1").style.backgroundColor="#e8ebd9";
            return false;
          }
          
          var totstud = parseInt(st) + parseInt(listBox2len);
//          if(totstud > 8)
//           {
//            var remain = 8 - parseInt(listBox2len);
//            if(remain > 0)
//            document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*You can select only '+remain+' student from the list!';
//            else
//            document.getElementById("ctl00_ContentPlaceHolder1_lblerrormsg").innerHTML = '*This batch is full';
//            
//            return false;
//           }
          var res= confirm("Are you sure! You want to move?");
          if(res)
          {
          return true;
          }
          else
          {
           return false;
          }
    }
function H2_1_onclick() {

}

</script>


<table class="common">
<tr>
    <td colspan="3" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
        padding-top: 0px">
        <h4>Change Batch</h4>
    </td>
</tr>
<tr>
    <td colspan="3" style="text-align: center">
    <asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label></td>
</tr> 
    <tr>
        <td colspan="2" style="text-align: center; width: 207px;" >
    <table class="common" >
        <tr>
            <td colspan="2" style="padding:0px;">
                <h2>Select student from this batch</h2></td>
        </tr>
        <tr>
            <td >
                Select Track</td>
            <td>
                <asp:DropDownList ID="ddl_track" runat="server">
                <asp:ListItem Value="">--Select--</asp:ListItem>
                 <asp:ListItem Value="Fast">Fast</asp:ListItem>
                 <asp:ListItem Value="Normal">Normal</asp:ListItem>
                 <asp:ListItem Value="Zip">Zip</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td >
                Select Module</td>
            <td>
                <asp:DropDownList ID="ddl_softlist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_softlist_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td >
                Select batchcode</td>
            <td>
                <asp:DropDownList ID="ddl_batchcode1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode1_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Select student</td>
            <td>
                <asp:ListBox ID="lbox1" runat="server" SelectionMode="Multiple"></asp:ListBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <br />
                <asp:Button ID="btn_Movestudent" runat="server" CssClass="submit" OnClientClick="javascript:return changebatch();" Text="Move>>" OnClick="btn_Movestudent_Click1"/><br />
            </td>
        </tr>
        </table>
                 </td>
        <td colspan="1" style="height: 21px ; text-align:center;">
            <br />
     <table class="common">
         <tr>
             <td colspan="2" style="padding:0px;">
                 <h2 id="H2_1" language="javascript" onclick="return H2_1_onclick()">Move student to this batch</h2></td>
         </tr>
        <tr>
            <td style="width: 91px; height: 39px"  >
                Select batchcode</td>
            <td style="height: 39px" >
                <asp:DropDownList ID="ddl_batchcode2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode2_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 91px"  >
                Track</td>
            <td>
                <asp:Label ID="lbltrack" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 91px"  >
                Time</td>
            <td >
                <asp:Label ID="lbltime" runat="server" Text=''></asp:Label></td>
        </tr>
         <tr>
             <td style="width: 91px"  >
                 Current s/w</td>
             <td>
                 <asp:Label ID="lblsoftware" runat="server" Text=''></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 91px"  >
                 Slot</td>
             <td>
                 <asp:Label ID="lbl_slot" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 91px"  >
                 Lab</td>
             <td >
                 <asp:Label ID="lbl_lab" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 91px" >
                 Faculty</td>
             <td>
                 <asp:Label ID="lbl_Faculty" runat="server" Text=""></asp:Label></td>
         </tr>
        <tr><td style="width: 91px" >
            Studentid</td><td>
            <asp:ListBox ID="lbox2" runat="server"></asp:ListBox></td></tr></table>
        </td>
    </tr>
</table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

