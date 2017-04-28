<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="Onlinestudents2_Default" Title="Welcome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
 <script language="javascript" type="text/javascript">

<script type = "text/javascript">
    
if(document.getElementById("ContentPlaceHolder1_HiddenField1").value!="SuperAdmin")
{
            $(document).ready(function() {
            $("#message").fadeIn("slow");
            $("#message a.close-notify").click(function() {
                $("#message").fadeOut("slow");
                return false;
            });
        });


    }    
</script>


<div runat="server" style="overflow:hidden;"  >
<%--<img  src="../layout/welcome.JPG" alt="welcome" /> --%></div>
    <asp:HiddenField ID="HiddenField1" runat="server" />





</asp:Content>

