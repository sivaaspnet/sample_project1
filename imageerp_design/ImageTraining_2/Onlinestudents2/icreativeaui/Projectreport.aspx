<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Projectreport.aspx.cs" Inherits="superadmin_ProjectAssesment" Title="Project Assesment" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
	        
	 function Validate()
     {
         if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Student ID!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentId").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").value=="";   
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Enter the Student Name!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_StudentName").style.backgroundColor="#e8ebd9";
             return false;
         }
    
      else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").value)=="")
         {
             
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the course!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").value=="")
         {
             
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML ='*Please Select the module!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").style.backgroundColor="#e8ebd9";
             document.getElementById("ctl00_ContentPlaceHolder1_ddlmodname").style.backgroundColor="#e8ebd9";
             return false;
         }
            else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtproject").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg").innerHTML = '*Please Enter the Project Guide!';
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtproject").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }   
     }
       function Validate_Email(Email)
{
	var Str=Email
	//var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

	if(CheckExpression.test(Str))// test Method to check for Regular Expression
	{
		return true;
	}
	else
	{
		return false
	}
}
function searchval()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").value=="" && document.getElementById("ctl00_ContentPlaceHolder1_txtsearchname").value=="" )
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").style.backgroundColor="#e8ebd9";
             return false;
         } 
        else
        {
        return true;
        }

}
function btnreset_onclick()
 {
  location.href="addcentre.aspx";
 }
</script>

 


        &nbsp;<table class="common">
            <tr>
                <td colspan="3">
                    <table class="common">
                        <tr>
                            <td align="right" colspan="2" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                                padding-top: 0px">
                                <h4>
                                    Project Report</h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Searchby Module Name"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Searchby Status" Width="145px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlsearchmodname" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlstatus" runat="server">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                    <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                    <asp:ListItem  Value="Rejected">Rejected</asp:ListItem>
                                </asp:DropDownList>&nbsp;
                                <asp:Button ID="btnsearch" runat="server" CssClass="search" OnClick="btnsearch_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Label ID="Label1" runat="server" CssClass="error" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 17px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record Found" Enabled="False">
                        <Columns>
                            <asp:BoundField DataField="studentid" HeaderText="studentID" />
                            <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                            <asp:BoundField DataField="module" HeaderText="Module" />
                            <asp:BoundField DataField="projectguided_by" HeaderText="Project Guided By" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                        </Columns>
                        <EmptyDataRowStyle BorderColor="#C00000" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    

    

</asp:Content>

