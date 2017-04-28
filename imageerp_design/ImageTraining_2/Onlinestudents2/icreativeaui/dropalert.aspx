<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dropalert.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_dropalert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all"/>
    <link rel="stylesheet" href="nivo-slider/themes/default/default.css"  type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/pascal/pascal.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/themes/orman/orman.css"type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/nivo-slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="nivo-slider/demo/style.css" type="text/css" media="screen" />
    <link rel="shortcut icon" type="image/x-icon" href="../layout/logo.png"/>
        <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">


function validate()
{
if (document.getElementById("DropDownList1").value=="" )
          {
             document.getElementById("DropDownList1").value=="";   
             alert("Please Enter Reason..!");
             document.getElementById("DropDownList1").focus();
             document.getElementById("DropDownList1").style.border="#ff0000 1px solid";
             document.getElementById("DropDownList1").style.backgroundColor="#e8ebd9";
             return false;
         }
    
          else if (document.getElementById("TextBox1").value=="" )
          {
            alert("Please Enter Reason....!");
             document.getElementById("TextBox1").value=="";
             document.getElementById("TextBox1").focus();
             document.getElementById("TextBox1").style.border="#ff0000 1px solid";
             document.getElementById("TextBox1").style.backgroundColor="#e8ebd9";
            
             return false;
         }
         else
         
         {
         return true;
         }
}

function validate1()
{
if (document.getElementById("DropDownList2").value=="" )
          {
             document.getElementById("DropDownList2").value=="";   
             alert("Please Enter Reason..!");
             document.getElementById("DropDownList2").focus();
             document.getElementById("DropDownList2").style.border="#ff0000 1px solid";
             document.getElementById("DropDownList2").style.backgroundColor="#e8ebd9";
             return false;
         }
    
          else if (document.getElementById("TextBox1").value=="" )
          {
            alert("Please Enter Reason....!");
             document.getElementById("TextBox1").value=="";
             document.getElementById("TextBox1").focus();
             document.getElementById("TextBox1").style.border="#ff0000 1px solid";
             document.getElementById("TextBox1").style.backgroundColor="#e8ebd9";
            
             return false;
         }
         else
         
         {
         return true;
         }
}
function val()
{
  
  if (document.getElementById("DropDownList1").value=="Others" )
          {
            document.getElementById("TextBox1").value=="";
             document.getElementById("TextBox1").style.display='block';
             return false;
         }
         else if (document.getElementById("DropDownList1").value!="Others" )
          {document.getElementById("TextBox1").value = document.getElementById("DropDownList1").value;
             document.getElementById("TextBox1").style.display='none';
          }
          else
         {
      
          
         return true;
         }
      

}

function val1()
{

  if (document.getElementById("DropDownList2").value=="Others" )
          {
            document.getElementById("TextBox1").value=="";
             document.getElementById("TextBox1").style.display='block';
             return false;
         }
           else if (document.getElementById("DropDownList2").value!="Others" )
          {document.getElementById("TextBox1").value = document.getElementById("DropDownList2").value;
             document.getElementById("TextBox1").style.display='none';
          }
         else
         
         {
          document.getElementById("TextBox1").style.display='none';
         

         return true;
         }
       
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="common">
            <tr>
                <td align="center" style="width: 100px; height: 1px" valign="middle">
                </td>
                <td style="width: 100px; height: 1px">
                </td>
                <td style="width: 100px; height: 1px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="center" valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="Reason" Font-Bold="True"></asp:Label><br />
                    <br />
                </td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DropDownList1" onchange="val();" runat="server" Width="154px" Visible="False">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="Time Change">Time Change</asp:ListItem>
                        <asp:ListItem Value="Less Strength">Less Strength</asp:ListItem>
                        <asp:ListItem Value="Faculty Unavailable">Faculty Unavailable</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList onchange="val1();" ID="DropDownList2" runat="server" Visible="False">
                     <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="Higher Studies">Higher Studies</asp:ListItem>
                        <asp:ListItem Value="Timing Problem">Timing Problem</asp:ListItem>
                        <asp:ListItem Value="Fees Problem">Fees Problem</asp:ListItem>
                       <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox style="display:none;" ID="TextBox1" runat="server" Height="15px" Width="151px" MaxLength="25" CssClass="text"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" CssClass="submit" OnClientClick="return validate();" OnClick="Button1_Click"
                        Text="Suspend" Visible="False" />
                    <asp:Button ID="Button2" runat="server" OnClientClick="return validate1();"  CssClass="submit" OnClick="Button2_Click"
                        Text="suspend" Visible="False" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
