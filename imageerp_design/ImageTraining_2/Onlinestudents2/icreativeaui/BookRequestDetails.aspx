<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="BookRequestDetails.aspx.cs" Inherits="superadmin_BookRequestDetails" Title="Book Request Details Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
function sortval1()
{
clearValidation('ctl00_ContentPlaceHolder1_txtfromcalender1~ctl00_ContentPlaceHolder1_txttocalender1');

if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_centrcode").value=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_centrcode").value=="";   
             alert("Please select centre code");
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_centrcode").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").value=="";   
             alert("Please select Book Status");
             document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch").style.backgroundColor="#e8ebd9";
           
             return false;
         }
  else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value=="";   
             alert("Please select the From date");
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").style.backgroundColor="#e8ebd9";
           
             return false;
         }
   else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value=="";   
             alert("Please select the To date");
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").style.backgroundColor="#e8ebd9";
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
document.getElementById("ctl00_ContentPlaceHolder1_ddl_centrcode").value="";
document.getElementById("ctl00_ContentPlaceHolder1_txtfromcalender1").value="";
document.getElementById("ctl00_ContentPlaceHolder1_txttocalender1").value="";




  var liste = document.getElementById("ctl00_ContentPlaceHolder1_txtrolesearch");
                var howMany = liste.options.length;

                for(var i = 0; i < howMany; i++)
                {
                    if(liste[i].selected)
                    {
                    liste[i].selected=false;
                    }
                }    





}





</script>
    <table cellpadding="1" class="common">
        <tr>
            <td colspan="3" style=" padding:0px;"><h4>View Enrolled Student Report</h4>

            </td>
        </tr>
    <tr><td colspan="3" style="text-align:center">
        <asp:Label ID="lblmessage" CssClass="error" runat="server" Text=""></asp:Label></td></tr>
        <tr id="viewby_admin" runat="server">
            <td colspan="2">
                Select centre code&nbsp;
                <br />
                <asp:DropDownList ID="ddl_centrcode" runat="server">
                </asp:DropDownList></td>
            <td>
                &nbsp;Book Status<br />
                &nbsp;<asp:DropDownList ID="txtrolesearch" runat="server" Width="103px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                    <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                From Date &nbsp;<br />
                <asp:TextBox ID="txtfromcalender1" runat="server" CssClass="text datepicker" Width="92px" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                 
             
                </td>
            <td>
                To Date &nbsp;<br />
                <asp:TextBox ID="txttocalender1" runat="server" CssClass="text datepicker" Width="92px" onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
        </tr>
      
    </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
   <asp:Button ID="btnsort" runat="server" Text="Sort" CssClass="submit" OnClientClick="javascript:return sortval1();" OnClick="btnsort_Click" />
    &nbsp;&nbsp;
                <input id="Reset1" class="submit" onclick="javascript:return Reset();" type="button"
                    value="Reset" />&nbsp;
                <br />
    <br />
    <br />
    <table class="common">
    <tr><td style="padding:0px;">
      <h4>Student Details </h4></td></tr>
      <tr><td>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowCommand="GridView1_RowCommand" PageSize="25">
            <Columns>
                <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                <asp:TemplateField HeaderText="Course">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("student_id") %>'
                            CommandName="Course"><%#Eval("coursename")%></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="bookstatus" HeaderText="Book Status" />
            </Columns>
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
        &nbsp;</p></td></tr>
    </table>
        <table class="common" >
            <tr>
                <td colspan="2" style="color: #ff3366">
                    Key:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img alt="View" src="../layout/32.gif" />-Click to View the Details</td>
            </tr>
            
        </table>
    
</asp:Content>

