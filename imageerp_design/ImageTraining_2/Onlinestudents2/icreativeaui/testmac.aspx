<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="testmac.aspx.cs" Inherits="Onlinestudents2_testmac" Title="Welcome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
 <script language="javascript" type="text/javascript">

<script type = "text/javascript">
    function computeCorrectValue(type parameter)
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


<div class="welcomecontent" runat="server" style="height:550px; width:100%;">
<div class="" runat="server" style="text-align:center; padding-top:40px; height:92%; width:100%; background-color: #8a2c7a;">
<img src="../layout/backs.JPG" alt="welcome" /> </div>
</div>




</asp:Content>

