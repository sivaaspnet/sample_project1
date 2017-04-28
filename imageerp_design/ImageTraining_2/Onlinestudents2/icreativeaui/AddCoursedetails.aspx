<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="AddCoursedetails.aspx.cs" Inherits="superadmin_AddCoursedetails" Title="Add Course Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
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
	        
function coursedet()
{
    clearValidation('ctl00_ContentPlaceHolder1_txt_courseprogarm~ctl00_ContentPlaceHolder1_txt_coursename')
        if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_courseprogarm").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_courseprogarm").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the program !';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_courseprogarm").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_courseprogarm").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_courseprogarm").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_coursename").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_coursename").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please Enter the course name !';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_coursename").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_coursename").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_coursename").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
  
}


// <!CDATA[
function btnreset_onclick() {
location.href="AddCoursedetails.aspx";
}
// ]]>
</script>

         <table class="common">
         <tr>
              <td style=" padding:0px;"><h4>Course Details</h4>
 </td>
         </tr><tr><td>
       <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Results Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="program" HeaderText="Program" />
                    <asp:BoundField DataField="coursename" HeaderText="Course name" />     
                             
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("course_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("course_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
           <PagerSettings Position="TopAndBottom" />
            </asp:GridView></td></tr>
    </table>
            <asp:HiddenField ID="Hidn_courseid" runat="server" />
    <br />
    <br />
            
          
    
    <table class="common" >
        <tr>
            <td colspan="2" style="padding:0px;">  <h4>Add Course Details</h4>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;s">
                <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label></td>
        </tr>
                
                <tr>
                    <td class="w290 talignleft" style="width: 76px">
                        Program</td>
                    <td>
                        <asp:TextBox ID="txt_courseprogarm" runat="server" MaxLength="30" CssClass="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="w290 talignleft" style="height: 37px; width: 76px;">Course Name </td>
                    <td style="height: 37px">
                        <asp:TextBox ID="txt_coursename" runat="server" CssClass="text" MaxLength="150" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            </table>
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="Btnupdate" OnClientClick="javascript:return coursedet();" CssClass="submit" runat="server" Text="Submit" OnClick="Btnupdate_Click" />
    &nbsp;
                        <input id="btnreset" type="button" class="submit" value="Reset" onclick="return btnreset_onclick()"/>&nbsp;
                        <br />
    <br />



</asp:Content>

