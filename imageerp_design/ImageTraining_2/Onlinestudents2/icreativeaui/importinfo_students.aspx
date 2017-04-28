<%@ Page Language="C#" MasterPageFile="~/ImageTraining_2/Onlinestudents2/icreativeaui/1imagemasterpage.master" AutoEventWireup="true" CodeFile="importinfo_students.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_icreativeaui_importinfo_students" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
        function validate() {
            var file = document.getElementById('<%=FileUpload1.ClientID%>');
            if (file.value == "" || file.value==null) {
                alert("Select file to upload");
                return false;
            }
        }
    </script>
<h4>Import Infotainment Student Details</h4>

<div class="free-forms">

 <table class="common" cellpadding="0" cellspacing="0" width="70%" > 
     <tr class="no-borders">
         <td colspan="3">
      <asp:Label ID="lbl_errormsg" runat="server" ForeColor="DarkRed"></asp:Label></td>
     </tr>
            
         
            
            <tr>
                <td colspan="3" style="text-align:center;" align="center" valign="middle">
                Select File:
                   <asp:FileUpload ID="FileUpload1" runat="server"/>
                   </td>
                     <td colspan="3" style="text-align:center;" align="center" valign="middle">
               <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="btnStyle1" OnClick="uploadexcel" OnClientClick="return validate();"  /></td>
            </tr>
        </table>

</div>
</asp:Content>

