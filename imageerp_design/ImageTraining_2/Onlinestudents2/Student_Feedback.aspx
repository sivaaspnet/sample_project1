<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/Mainmasterpage.master" AutoEventWireup="true" CodeFile="Student_Feedback.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_Student_Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
     function valid()
     {
      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList1.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	     else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList2.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	   else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList3.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }   
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList4.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList5.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList6.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList7.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList8.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList9.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
	      else
	     
	      var min = 1;  
     var select=0;	    
     var CHK = document.getElementById('<%=this.RadioButtonList10.ClientID%>');   
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
	     alert("Please answer all the questions");
	     return false;
	     }
else

if(document.getElementById('ContentPlaceHolder1_t1').value=="")
{
alert("Please give comments/suggestions");
 document.getElementById("ContentPlaceHolder1_t1").focus();
 document.getElementById("ContentPlaceHolder1_t1").style.border="#ff0000 1px solid";
 document.getElementById("ContentPlaceHolder1_t1").style.backgroundColor="#e8ebd9";
 return false;
}
     else
     {
     return true;
     }
     }
     </script>




<style type="text/css"> 
p.flip{}
div.panel{}
div.panel a{}
div.panel a:Hover{}  
.headingFeedback{font-size:24px;color:#2d6ca1;font-family:Tahoma;font-weight:normal;padding:10px 35px;}
.feedbackTop input{border:1px solid #B9C7D3;}
.feedbackTop td{padding-bottom:7px;padding-top:7px;}
.feedbackTop{background:#fcfefe;border:1px solid #e0e6e8;width:100%}
.fieldLeft{text-align:right;padding-right:14px;color:#323d40;}
.fieldRight{text-align:left;padding-left:14px;}
.feedBackinner{width:640px;margin:0 auto;}
.innerfbHeading{font-size:12px;color:#748586;font-weight:bold;text-decoration:underline;letter-spacing:1px;color:#3b484c;}  
.quesPara{color:#033548;font-weight:bold;font-family:Tahoma;padding:2px 0 8px;}
.fbInnerform{color:#323d40;}
.fbInnerform td{}
.fbRadio{margin:3px 9px 1px 0px;vertical-align:middle;}
.textArea{width:90%;}
</style>
<div class="content_place" style="width:100%">
<table id="tblclass" runat="server" class="common" width="100%">
                    <tr>
                        <td  style=" padding:0px;">
                            <h4>
                               Students Feedback Form</h4>
                        </td>
                    </tr>
                    <tr>
                    <td>
<table class="feedbackTop"  cellspacing="0" cellpadding="0" border="0">
<tbody>
<tr>
<td height="9px;"></td>
<td></td>
<td></td>
<td></td>
    <td>
    </td>
    <td>
    </td>
</tr>
<tr>
<td class="fieldLeft" style="height: 20px">Student Reg No :</td>
<td class="fieldRight" style="height: 20px">
    &nbsp;<asp:Label ID="lbl_no" runat="server" Text="" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
 <td class="fieldLeft" style="height: 20px">Student Name:</td>
<td class="fieldRight" style="height: 20px">
    &nbsp;<asp:Label ID="lbl_sname" runat="server" Text="" Font-Bold="True" ForeColor="Maroon"></asp:Label></td> 
       <td class="fieldLeft" style="height: 20px">Date :</td>
  <td class="fieldRight" style="height: 20px">
    <asp:Label ID="lbl_Date" runat="server" Text="" Font-Bold="True" ForeColor="Maroon"></asp:Label></td> 
 

</tr>
<tr>
<td class="fieldLeft" style="height: 20px">Trainer's Name :</td>
<td class="fieldRight" style="height: 20px">
    &nbsp;<asp:Label ID="lbl_Name" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
<td class="fieldLeft" style="height: 20px">Batch Timing :</td>
<td class="fieldRight" style="height: 20px">
    <asp:Label ID="lbl_Timing" runat="server" Text="" Font-Bold="True" ForeColor="Maroon"></asp:Label>

</td>

 
    <td class="fieldLeft" style="height: 20px">Track :</td>
    <td class="fieldRight" style="height: 20px">
    <asp:Label ID="lbl_Track" runat="server" Text="" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
</tr>
<tr>
<td class="fieldLeft" style="height: 20px">Software Taught :</td>
<td class="fieldRight" style="height: 20px" colspan="5">
    &nbsp;<asp:Label ID="lbl_Software" runat="server" Text="" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
</tr>
<tr>
<td height="9px;"></td>
<td></td>
<td></td>
<td></td>
    <td>
    </td>
    <td>
    </td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr><td>
<div >
<table  width="100%" cellspacing="0" cellpadding="0">
<tbody>

<tr>
<td class="quesPara" colspan="6" style="height: 25px">1. Communication Skill of the Faculty </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
    </tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">2. Ability to Clarify Doubts </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">3. Whether Extra Assignments Were Given </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Width="200px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" >
    <asp:ListItem Value="Yes">Yes</asp:ListItem>
    <asp:ListItem Value="No">No</asp:ListItem>
    
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">4. Whether Feedback for the Assignments has been Given </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" Width="200px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Yes">Yes</asp:ListItem>
    <asp:ListItem Value="No">No</asp:ListItem>
   
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">5.Pace of Taking Class </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">6.Interaction in the Class </td>
</tr>
<tr>
<td colspan="6">
   <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">7.Were Enough Examples Used to Explain the Concepts </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" Width="200px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Yes">Yes</asp:ListItem>
    <asp:ListItem Value="No">No</asp:ListItem>
    
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6"> 8.Usage of Class Time Effectively </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
     <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">9.Your Confidence Level in Working in a Project for the Skills Taught </td>
</tr>
<tr>
<td colspan="6">
    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
     <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="quesPara" colspan="6">10.Overall Rating</td>
</tr>
<tr>
<td colspan="6">
   <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" Width="99%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
    <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
    <asp:ListItem Value="Good" >Good</asp:ListItem>
    <asp:ListItem Value="Average">Average</asp:ListItem>
    <asp:ListItem Value="Below Average"> Below Average</asp:ListItem>
    <asp:ListItem Value="Poor">Poor</asp:ListItem>
    <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>

<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="6">
<p class="innerfbHeading">Any other comments/Suggestions </p>
</td>
</tr>
<tr>
<td height="12"></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td colspan="6">
    <asp:TextBox ID="t1" Width="970px"  runat="server" TextMode="MultiLine" CssClass="text"></asp:TextBox>

</td>
</tr>
<tr>
<td colspan="6" style="height: 12px">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
</td>
</tr>


<tr>
<td align="center" style="width:100%">
    <asp:Button ID="Button1" CssClass="btnStyle1" runat="server" OnClientClick="return valid();" Text="Submit Feedback" OnClick="Button1_Click" />&nbsp;&nbsp;
    &nbsp;
    <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btnStyle2" OnClick="Button2_Click" />
  
</td>
<td>
  </td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
</tbody>
</table>
</div>
</td></tr>
</table>
</div>


</asp:Content>

