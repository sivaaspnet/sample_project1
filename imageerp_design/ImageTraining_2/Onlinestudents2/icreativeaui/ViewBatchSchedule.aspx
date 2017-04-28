<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewBatchSchedule.aspx.cs" Inherits="Onlinestudents2_superadmin_ViewBatchSchedule" Title="View Batch Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript">


 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	   
	        }


function clearValidation(fieldList)
    {
	
	    var field=new Array();
	    field=fieldList.split("~");
	    var counter=0;
	    for(i=0;i<field.length;i++)
	     {
		    if(document.getElementById(field[i]).value!="") 
		    {
			    document.getElementById(field[i]).style.border="#999999 1px solid";
			    document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		    }
		}
    } 

function viewatnval()
    {
    
    clearValidation('ContentPlaceHolder1_ddlbatchcode~ContentPlaceHolder1_ddlsoftwre')
    
      if(trim(document.getElementById("ContentPlaceHolder1_ddlbatchcode").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Please select batch code!';
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").style.backgroundColor="#e8ebd9";
             return false;
         } 
     
      else if(trim(document.getElementById("ContentPlaceHolder1_ddlsoftwre").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Please select software!';
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").focus();
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").style.backgroundColor="#e8ebd9";
             return false;
         } 
          
         else
         {
         return true;
         }
         
    } 
 
 
 
 
 
 
function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_ddlbatchcode").value="";
document.getElementById("ContentPlaceHolder1_ddlsoftwre").value="";



}
 

function TABLE1_onclick() {

}

</script>

    <table class="common"  id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
        <tr>
            <td colspan="7" style="padding:0px;">
                <h4>
                    View Batch Schedule</h4>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="width: 13px">
                &nbsp;Batch Code<br />
                <asp:DropDownList ID="ddlbatchcode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbatchcode_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td colspan="2">
                Software name<br />
                <asp:DropDownList ID="ddlsoftwre" runat="server">
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click"
                    OnClientClick="javascript:return viewatnval();" /></td>
        </tr>
        <tr>
            <td colspan="7" style=" text-align:center;" >
                <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
    </table>
    <br />
                <table id="tblbatch" visible="false" runat="server"  class="common" cellpadding="0" cellspacing="0"  >
                    <tr>
                        <td colspan="3" rowspan="1">
                        </td>
                        <td colspan="1" rowspan="1">
                        </td>
                        <td colspan="1" rowspan="1">
                        </td>
                        <td colspan="1" rowspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="3"  >
                            
                            Batch Track</td>
                        <td colspan="1" rowspan="3"  >
                            
                            <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30"
                                ReadOnly="True" TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="3" >
                            
                            Module Name</td>
                        <td colspan="1" rowspan="3" >
                            
                            <asp:TextBox ID="txt_Module" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" >
                            Faculty Name</td>
                        <td colspan="1" rowspan="1" >
                            <asp:TextBox ID="txt_Faculty" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" >
                            Lab Name</td>
                        <td colspan="1" rowspan="1" >
                            <asp:TextBox ID="txt_Lab" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" >
                            Batch Time</td>
                        <td colspan="1" rowspan="1" >
                            <asp:TextBox ID="txt_BatchTime" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" >
                            Batch Slot</td>
                        <td colspan="1" rowspan="1" >
                            <asp:TextBox ID="txt_BatchSlot" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1"  >
                            Batch Start Date</td>
                        <td colspan="1" rowspan="1"  >
                            <asp:TextBox ID="txt_Bstart" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1"  >
                            Batch End Date</td>
                        <td colspan="1" rowspan="1" >
                            <asp:TextBox ID="txt_Bend" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1"  >
                            Software name</td>
                        <td colspan="3" rowspan="1"  >
                            <asp:TextBox ID="txt_software" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6" rowspan="1" >
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                </table>
    <br />
</asp:Content>

