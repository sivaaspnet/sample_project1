l<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Viewbookindent.aspx.cs" Inherits="superadmin_Course_New" Title="Course New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
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


onKeyPress="return CheckNumeric(event)"       
	        
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
    function lab()
    {
    clearValidation('ContentPlaceHolder1_txt_Coursename~ContentPlaceHolder1_txt_Coursecode')
      if(trim(document.getElementById("ContentPlaceHolder1_txt_Coursename").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_Coursename").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Course name!';
             document.getElementById("ContentPlaceHolder1_txt_Coursename").focus();
             document.getElementById("ContentPlaceHolder1_txt_Coursename").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_Coursename").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("ContentPlaceHolder1_txt_Coursecode").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_Coursecode").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the Course Code!';
             document.getElementById("ContentPlaceHolder1_txt_Coursecode").focus();
             document.getElementById("ContentPlaceHolder1_txt_Coursecode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_Coursecode").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ContentPlaceHolder1_ddlyear").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddlyear").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the year!';
             document.getElementById("ContentPlaceHolder1_ddlyear").focus();
             document.getElementById("ContentPlaceHolder1_ddlyear").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlyear").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }  
    } 
    
function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_txtsearchname").value=="")
         {
         
            
             document.getElementById("ContentPlaceHolder1_txtsearchname").focus();
             document.getElementById("ContentPlaceHolder1_txtsearchname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsearchname").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_txt_Coursename").value="";
document.getElementById("ContentPlaceHolder1_txt_Coursecode").value="";





}



</script>
    <table class="common" style="width:100%">
        <tr>
            <td style="padding:0px; height: 1px;"><h4>
                Request Book Indent Details</h4>

            </td>
        </tr>
        <tr>
    <td style="text-align:center; padding:0px;">
        <br />
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Select Centre:"></asp:Label>
    &nbsp; &nbsp; 
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>&nbsp;
        
        </td>
            </tr><tr><td style="text-align:center; padding:0px;">
                &nbsp;<asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label></td>
    </tr></table>
    <br />
    
    <asp:GridView CssClass="common" ID="GridView1" style="width:100%" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found">
                <Columns>
                    <asp:BoundField DataField="bookname" HeaderText="Book Name" />
                    <asp:BoundField DataField="bookcount" HeaderText="Total No of Request" />
             <asp:BoundField DataField="bookissued" HeaderText="Issued" />
               <asp:BoundField DataField="bookpending" HeaderText="Pending" />
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <br />
            
               
    <table  class="common" style="width:100%">
        <tr>
            <td colspan="9" style="padding:0px;"> <h4>
                Student Wise Details</h4>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Student ID/Name:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Book Name:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="datepicker"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Status"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="">Select</asp:ListItem>
            <asp:ListItem Value="Issued">Issued</asp:ListItem>
            <asp:ListItem Value="Pending">Pending</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server"  CssClass="search" OnClick="Button1_Click" />
        </td>
        </tr>
       <tr>
       <td colspan="9" style="padding:0px;">
       <center>
           <asp:GridView CssClass="common" Width="100%" ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found">
               <Columns>
                   <asp:BoundField DataField="studentid" HeaderText="Student ID" />
                   <asp:BoundField DataField="enq_personal_name" HeaderText="Name" />
                   <asp:BoundField DataField="program" HeaderText="Course" />
                        <asp:BoundField DataField="bookname" HeaderText="Books" />
                   <asp:BoundField DataField="bookcount" HeaderText="No of Books" />
                   <asp:BoundField DataField="pending" HeaderText="No of Pending" />
                    <asp:BoundField DataField="requested_date" HeaderText="Requested Date" />
                          <asp:BoundField DataField="approved_date" HeaderText="Approved Date" />
               </Columns>
                 <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
           </asp:GridView>
           </center>
       </td>
       </tr>
            </table>
    <br />
                        <br />
    <br />
</asp:Content>

