<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Course_New.aspx.cs" Inherits="superadmin_Course_New" Title="Course New" %>
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
    clearValidation('<%=txt_Coursename.ClientID%>~<%=txt_Coursecode.ClientID%>')
      if(trim(document.getElementById("<%=txt_Coursename.ClientID%>").value)=="")
         {
             document.getElementById("<%=txt_Coursename.ClientID%>").value=="";
             document.getElementById("<%=lblmsg1.ClientID%>").innerHTML ='*Please enter the Course name!';
             document.getElementById("<%=txt_Coursename.ClientID%>").focus();
             document.getElementById("<%=txt_Coursename.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=txt_Coursename.ClientID%>").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("<%=txt_Coursecode.ClientID%>").value)=="")
         {
             document.getElementById("<%=txt_Coursecode.ClientID%>").value=="";
             document.getElementById("<%=lblmsg1.ClientID%>").innerHTML ='*Please enter the Course Code!';
             document.getElementById("<%=txt_Coursecode.ClientID%>").focus();
             document.getElementById("<%=txt_Coursecode.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=txt_Coursecode.ClientID%>").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(trim(document.getElementById("<%=txtCourseType.ClientID%>").value)=="")
         {
             document.getElementById("<%=txtCourseType.ClientID%>").value=="";
             document.getElementById("<%=lblmsg1.ClientID%>").innerHTML ='*Please enter the Course Type!';
             document.getElementById("<%=txtCourseType.ClientID%>").focus();
             document.getElementById("<%=txtCourseType.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=txtCourseType.ClientID%>").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("<%=ddlyear.ClientID%>").value)=="")
         {
             document.getElementById("<%=ddlyear.ClientID%>").value=="";
             document.getElementById("<%=lblmsg1.ClientID%>").innerHTML ='*Please select the year!';
             document.getElementById("<%=ddlyear.ClientID%>").focus();
             document.getElementById("<%=ddlyear.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=ddlyear.ClientID%>").style.backgroundColor="#e8ebd9";
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
document.getElementById("<%=txt_Coursename.ClientID%>").value="";
document.getElementById("<%=txt_Coursecode.ClientID%>").value="";





}



</script>
    <div class="title-cont">
    <h3 class="cont-title">Course Details</h3>
    <%--<div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Acadamic</a>/</li>
        <li><a href="Course_New.aspx" class="last">Course Details</a></li>
      </ul>
    </div>--%>
    <div class="clear"></div>
  </div>
 
     <div class="search-sec-cont">
 <ul>
      <li><div class="wth-1">Searchby Course Name</div>
        <div class="wth-2"> <asp:DropDownList ID="ddl_Module" runat="server" Width="500px" CssClass="sele-txt" >
         </asp:DropDownList></div>
      </li>
        <li>
      
    
        
       <asp:Button ID="btn_search" runat="server" CssClass="search-btn" Text="Search"  OnClick="btn_search_Click" />
            </li>
		</ul>
        <div class="clear"></div>
    <div align="center">
      <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label> 
    </div>
	</div>
 
     <div class="white-cont">
      <div style="padding:0px 10px 10px 10px">
    <asp:GridView CssClass="tbl-cont3" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
                <Columns>
                    <asp:BoundField DataField="coursename" HeaderText="Course Name" />
                    <asp:BoundField DataField="program" HeaderText="Program" />
                    <asp:BoundField DataField="Coursetype" HeaderText="CourseType" />
                    <asp:BoundField DataField="Coursesegment" HeaderText="CourseSeparation" />
                    <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("course_id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton> |
                             <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("course_id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                         </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
       
                <PagerSettings Mode="NumericFirstLast" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        <EmptyDataRowStyle ForeColor="Red" />
            </asp:GridView>
         </div>
           <center style="padding:12px;">
                <asp:LinkButton ID="Linkdownload" CssClass="download-btn" runat="server" OnClick="Linkdownload_Click">Download Excel</asp:LinkButton>
            </center>
         </div>
          
 
    <div style="height:10px;"></div>
            <asp:HiddenField ID="hiddn_id" runat="server" />
  <div class="white-cont">
            <h4  class="cont-title2">
                Add Course Details</h4>
				    

       <div class="form-cont">
        <ul>
                  <li>
            <div style="padding:0px; text-align:left"></div>
            <div align="center">
             <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label>
            </div>
          </li>
             <li>
            <label class="label-txt"> Course Name</label>
           <asp:TextBox ID="txt_Coursename" runat="server" MaxLength="200" CssClass="text input-txt" OnTextChanged="txt_Coursename_TextChanged"></asp:TextBox>
          </li>
    <li>
            <label class="label-txt">  Course Code</label>
            <asp:TextBox ID="txt_Coursecode" runat="server" CssClass="text input-txt" MaxLength="40" ></asp:TextBox>
          </li>

        <li>
            <label class="label-txt">  year</label>
            <asp:DropDownList ID="ddlyear" CssClass="sele-txt" runat="server">
                    <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="1">1st year</asp:ListItem>
                    <asp:ListItem Value="2">2nd year</asp:ListItem>
                    <asp:ListItem Value="3">3rd year</asp:ListItem>
                </asp:DropDownList>
          </li>
 
   <li>
            <label class="label-txt">  Course Separation</label>
           <asp:TextBox ID="txtCourseType" runat="server" CssClass="text input-txt"></asp:TextBox>
          </li>
         <li>
            <label class="label-txt"> Course Type</label>
          <asp:DropDownList ID="ddlCourseSep" runat="server"  CssClass="sele-txt">
                    <asp:ListItem Value="">select</asp:ListItem>
                    <asp:ListItem Value="Certificate">Certificate</asp:ListItem>
                     <asp:ListItem Value="Higher Certificate">Higher Certificate</asp:ListItem>
                    <asp:ListItem Value="Diploma">Diploma</asp:ListItem>                   
                    <asp:ListItem Value="Higher Diploma">Higher Diploma</asp:ListItem>
                </asp:DropDownList>
          </li>
             <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">         
 
       

                        <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return lab();" />&nbsp;&nbsp;
                        <input id="Reset1" class="reset-btn" title="Reset" onclick="javascript:return Reset();" type="button"
                            value="Reset" /> </div>
                 </li>
            </ul>
          <div class="clear"></div> 
		 

  </div>
</asp:Content>

