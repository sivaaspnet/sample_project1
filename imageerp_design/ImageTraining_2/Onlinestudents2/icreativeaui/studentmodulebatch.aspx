<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentmodulebatch.aspx.cs" Inherits="Onlinestudents2_superadmin_home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>Batch</title>
   <!-- slider style starts-->
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="nivo-slider/themes/default/default.css"  type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/pascal/pascal.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/orman/orman.css"type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/demo/style.css" type="text/css" media="screen" />
    <link rel="shortcut icon" type="image/x-icon" href="../layout/logo.png"/>
 <!-- slider style ends-->
 
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
         <script type="text/javascript" src="nivo-slider/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
    $(window).load(function() {
        $('#slider').nivoSlider();
    });
    </script>
     <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <script language="javascript" type="text/javascript">
    function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}    
    function loginval()
    {
    clearValidation('txtusername~txtpassword');
    if(trim(document.getElementById("txtusername").value)=="")
    {
       document.getElementById("txtusername").value=="";
       document.getElementById("lblerrmsg").innerHTML = '*Please Enter the User name!';
       document.getElementById("txtusername").focus();
       document.getElementById("txtusername").style.border="#fff 1px solid";
       document.getElementById("txtusername").style.backgroundColor="#e8ebd9";
       return false;
    }    
    else if(trim(document.getElementById("txtpassword").value)=="")
      {
       document.getElementById("txtpassword").value=="";
       document.getElementById("lblerrmsg").innerHTML = '*Please Enter the Password!';
       document.getElementById("txtpassword").focus();
       document.getElementById("txtpassword").style.border="#fff 1px solid";
       document.getElementById("txtpassword").style.backgroundColor="#e8ebd9";
       return false;
       }   
       else
       {
       return true;
       }
     } 
    </script>
  <script type="text/javascript"> 
$(document).ready(function(){
$("#loginlogo").click(function(){
    $("#popup_name").slideDown();
  });
});
function TABLE1_onclick() {

}

</script>
  


</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<table border="1"  style=" margin:auto;">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="error" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Maroon"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 151px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="1px" Width="399px">
            <Columns>
                <asp:TemplateField HeaderText="BatchCode">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("batchcode") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                       <a target="_parent" href="studentbatch.aspx?studentid=<%#Eval("studentid")%>&softwareid=<%#Eval("Software_id")%>&batchcode=<%#Eval("batchcode")%>" class="error"><%#Eval("batchcode")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 18px;">
                    <table class="common" style="width: 405px">
                        <tr>
                            <td colspan="2" style="color: #ff3366; height: 25px">
                                Key:
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Click on to BatchCode To know Student Progress In Effort</td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;
  
    </form>
</body>
</html>
