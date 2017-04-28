<%@ Page Language="C#" MasterPageFile="Mainmasterpage.master" AutoEventWireup="true" CodeFile="attendance.aspx.cs" Inherits="Onlinestudents2_Attendance" Title="Attendance Details" %>
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
    function moduleval()
    {
    //clearValidation('ContentPlaceHolder1_txt_Reason~ContentPlaceHolder1_ddlcoursename~ContentPlaceHolder1_txt_modulecontent~ContentPlaceHolder1_listsoftwares')
    if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter reason for absent!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_Reason").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
function Button2_onclick() {
 }

    </script>
         <asp:HiddenField ID="hiddn_id" runat="server" />
    <asp:Label ID="lbl_Centrecode" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_batchslot" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_BatchTime" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_BatchTrack" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Lab" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Faculty" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Batchcode" runat="server" Visible="false"></asp:Label>
            
           
    
    <table id="tblvis" visible="false" runat="server" class="common">
    <tr><td  style="padding:0px; height: 29px;">  <h4>
        Attendance Details</h4></td></tr>
    <tr><td>
    <table class="common" width="600px">
        <tr>
            <td colspan="3" >
          
            </td>
        </tr>
               <tr><td colspan="3" style="text-align:center"> <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label></td></tr>
   
                               <tr>
                    <td >
                        Student ID</td>
                    <td>
                        <asp:TextBox ID="txt_StudentId" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True" Width="255px"></asp:TextBox></td>
                </tr>
        <tr>
            <td style="height: 31px" >
                Student Name</td>
            <td style="height: 31px">
                <asp:TextBox ID="txt_StudentName" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True" Width="255px"></asp:TextBox></td>
        </tr>
        <tr id="courvis" visible="false" runat="server">
            <td >
                        Course Name</td>
            <td>
                <asp:TextBox ID="txt_Course" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="479px" ReadOnly="True" OnTextChanged="txt_Course_TextChanged"></asp:TextBox></td>
        </tr>
                 <tr>
                    <td >
                        Module Name</td>
                    <td>
                        <asp:TextBox ID="txt_modulecontent" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True" Width="252px"></asp:TextBox></td>
                </tr>
              
                     <tr id="Tr1" runat="server">
            <td colspan="2">
            <br />
                <asp:GridView ID="gvattendance" runat="server" AutoGenerateColumns="False"   width="850px">
                    <Columns>
                        <asp:TemplateField HeaderText="Software">
                            <ItemTemplate>
                                <asp:TextBox ID="txtsoft" runat="server" ReadOnly="true" Text='<%# Eval("Software_Name") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Content">
                            <ItemTemplate>
                                <asp:TextBox ID="txtcont" runat="server" ReadOnly="true"  Text='<%# Eval("Class_Content") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Class date">
                            <ItemTemplate>
                                <asp:TextBox ID="txtclass" runat="server"  ReadOnly="true" Text='<%# Eval("Class_Date") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason">
                            <ItemTemplate>
                                <asp:TextBox ID="txtrea" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        </table>
        </td></tr>
        
        
        
        <tr><td>
        <table  id="todayclass" runat="server" visible="false" class="common"  width="600px">
        <tr><td> 
            <br />
            <table><tr><td >Content </td> <td>
                <asp:TextBox ID="txtconten" runat="server"></asp:TextBox> </td></tr>
            <tr><td> Class Date</td> <td> 
                <asp:TextBox ID="txtclassdate" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td>
                        Software
                    </td>
                    <td>
                        <asp:TextBox ID="txtsoft" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <table>
        <tr>
            <td align="center" colspan="2" valign="middle">
                <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    How Was Your Class Today?</strong></td>
        </tr>
            <tr>
                <td colspan="2" rowspan="2">
                </td>
            </tr>
            <tr>
            </tr>
        <tr>
            <td >
                A. The faculty is able to explain the concept clearly</td>
            <td>
                <asp:DropDownList ID="ddl_Concept" runat="server" CssClass="text" Width="150px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td >
                B. Satisfied with the quality of subject</td>
            <td>
                <asp:DropDownList ID="ddl_quality" runat="server" CssClass="text"  Width="150px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td >
                C. Experiences in the class were interesting</td>
            <td>
                <asp:DropDownList ID="ddl_Experience" runat="server" CssClass="text" Width="150px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                D. The Faculty appeared to be well prepared and presented in a well organised manner
            </td>
            <td>
                <asp:DropDownList ID="ddl_faculty" runat="server" CssClass="text" Width="150px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        </table></td></tr>
                <tr>
                    <td colspan="2"  >
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
                </tr>
                </table>
                
                </td></tr>
        <tr>
            <td style="text-align:center;">
                        <asp:Button ID="Button1" CssClass="submit" runat="server"  OnClientClick="javascript:return moduleval();" OnClick="Button1_Click" Text="Post" />&nbsp;
                        <input id="Button2" type="button" value="Reset"  class="submit" onclick="return Button2_onclick()"/></td>
        </tr>
                
                
            </table>
    <br />
    <table class="common" id="noclass" runat="server" visible="false"> 
    <tr><td style="text-align:center;color:Red;">
        <strong>Today no class </strong></td></tr>
    </table>
</asp:Content>

