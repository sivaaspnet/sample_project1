<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Bookresponse.aspx.cs" Inherits="Onlinestudents2_Default2" Title="Book Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function val2()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value=="")
 {
    alert("Please select status");
    document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").focus();
    document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
    document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
    return false;
    
 }
 else
 if(document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value=="")
 {
    alert("Please enter reason");
    document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").focus();
    document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
    document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
    return false;  
 }
 else
 {
 return true;
 }
 }
</script>
<script language="javascript" type="text/javascript">
function val()
{

 if(document.getElementById("ctl00_ContentPlaceHolder1_txt_studentid").value=="")
 {
    alert("Please enter Student Id");
    document.getElementById("ctl00_ContentPlaceHolder1_txt_studentid").focus();
    document.getElementById("ctl00_ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
    document.getElementById("ctl00_ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9";
    return false;
 }
 else
 {
 return true;
 }
}


function val1()
{
var min = 1;  
     var select=0;	    
     var CHK = document.getElementById("ctl00_ContentPlaceHolder1_CheckBoxList1");   
     var checkbox = CHK.getElementsByTagName("input");
     for (var i=0;i<checkbox.length;i++)
     {             
        if (checkbox[i].checked)
        {
            select++;            
        }
     }
 if(min>select)
	{
	     alert("Please select atleast one book");
	     document.getElementById("ctl00_ContentPlaceHolder1_CheckBoxList1").focus();
         return false;	        
    }  
    else
    {
    return true;
    }

}
</script>

<script language="javascript" type="text/javascript">
function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
		return true; 
	} else {
		return false;
	}
}

function validate()
 {
 
 
 
 if(document.getElementById("ct100_ContentPlaceHolder1_txt_studentid").value=="")
 {
    alert("Please enter Student Id");
    document.getElementById("ct100_ContentPlaceHolder1_txt_studentid").focus();
    document.getElementById("ct100_ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
    document.getElementById("ct100_ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9"
    return false;
 }
 else
 {
 return true;
 }
 }



function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
		return true; 
	} else {
		return false;
	}
}



function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
function CheckNumeric(GetEvt)
  {
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
  }

 







 
 
  
 
 
   

     
 
 $(document).ready(function() {

    $("#ContentPlaceHolder1_txt_studentid").autocomplete('Handler2.ashx');
   // alert("check");  
    }); 
 
     
</script>
    
    
    <table width="100%" class="common">
        <tr>
            <td colspan="2" style=" padding:0px; height: 29px;">
               <h4>
                   Book Response</h4></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
            </td>
            <td style="width: 339px; height: 31px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
        <td colspan="2">
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record">
                <Columns>
                    <asp:BoundField DataField="studentid" HeaderText="Student_ID" />
                    <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                    <asp:BoundField DataField="program" HeaderText="Course Name" />
                    <asp:BoundField DataField="bookname" HeaderText="Book Name" />
                    <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                         <asp:ListItem Value="Pending">Pending</asp:ListItem>
                        <asp:ListItem Value="Issued">Issued</asp:ListItem>
                      
                        </asp:DropDownList>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("id") %>'>
                    </asp:HiddenField>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
  <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
            </center>
        </td>
        </tr>
        <tr>
        <td colspan="2">
        <center>
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="submit" OnClick="Button1_Click" />
        </center>
        </td>
        </tr>
    
    </table>
    
</asp:Content>

