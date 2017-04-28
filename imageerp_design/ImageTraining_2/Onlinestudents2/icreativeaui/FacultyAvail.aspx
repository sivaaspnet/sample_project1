<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="FacultyAvail.aspx.cs" Inherits="superadmin_FacultyAvail" Title="Faculty Availability" %>
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
    clearValidation('ContentPlaceHolder1_txt_labname~ContentPlaceHolder1_txt_systems')
      if(trim(document.getElementById("ContentPlaceHolder1_txt_labname").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_labname").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the lab name!';
             document.getElementById("ContentPlaceHolder1_txt_labname").focus();
             document.getElementById("ContentPlaceHolder1_txt_labname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_labname").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ContentPlaceHolder1_txt_systems").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_systems").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter number of systems!';
             document.getElementById("ContentPlaceHolder1_txt_systems").focus();
             document.getElementById("ContentPlaceHolder1_txt_systems").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_systems").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
    
function Reset1_onclick() {
location.href="Addlab.aspx";
}


function selectdate()
{

var start1 = document.getElementById("ContentPlaceHolder1_txtfromdate").value;
        var start_s1 = start1.split("-");
        var stDate1 = parseInt(start_s1[2]+start_s1[1]+start_s1[0]);
        
        var d1 = new Date();
        var curr_date1 = d1.getDate();
        var curr_month1 = d1.getMonth();
        curr_month1++;
        var curr_year1 = d1.getFullYear();
        var mon1 =  (curr_month1 < 10 ? '0' : '') + curr_month1
        var dday1 =  (curr_date1 < 10 ? '0' : '') + curr_date1
        var toDate1 = parseInt(curr_year1 +''+ mon1 +''+ dday1);
        //var csDate = stDate - toDate;
        var csDate1 = parseInt(stDate1 - toDate1);


 var start = document.getElementById("ContentPlaceHolder1_txtfromdate").value;
        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

        var start_s = start.split("-");
        //var end_s = end.split("-");

        var stDate = start_s[1]+"/"+start_s[0]+"/"+start_s[2];
        var todate = document.getElementById("ContentPlaceHolder1_txttodate").value;
        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

        var todate_s = todate.split("-");
        //var end_s = end.split("-");

        var toDates = todate_s[1]+"/"+todate_s[0]+"/"+todate_s[2];
     var extdate = Date.parse(stDate);
     var enddate = Date.parse(toDates);

    if(document.getElementById("ContentPlaceHolder1_txtfromdate").value=="")
    {
        document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
        alert("Please select from date");
        document.getElementById("ContentPlaceHolder1_txtfromdate").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txtfromdate").style.backgroundColor="#e8ebd9";
        return false;
    } 
    else if(csDate1 < 0)
          {
             document.getElementById("ContentPlaceHolder1_txtfromdate").value=="";
             alert("Invalid start date");
             document.getElementById("ContentPlaceHolder1_txtfromdate").focus();
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfromdate").style.backgroundColor="#e8ebd9";
             return false;
          }
    else if(document.getElementById("ContentPlaceHolder1_txttodate").value=="")
    {
        document.getElementById("ContentPlaceHolder1_txttodate").focus();
        alert("Please select to date");
        document.getElementById("ContentPlaceHolder1_txttodate").style.border="#ff0000 1px solid";
        document.getElementById("ContentPlaceHolder1_txttodate").style.backgroundColor="#e8ebd9";
        return false;
    } 
    else if(new Date(extdate)>new Date(enddate))
	{
		alert("Please select the valid to date")
		document.getElementById("ContentPlaceHolder1_txttodate").value="";
		document.getElementById("ContentPlaceHolder1_txttodate").focus();
		return false;
	}
    else
    { 
        return true;
    }
}

</script>
<div class="free-forms">
    <table width="100%" cellpadding="0" cellspacing="0">

<tr><td class="formlabel">
    <strong>From Date : </strong>
</td>
  <td class="formlabel"><strong>To Date : </strong></td>
  <td class="formlabel">&nbsp;</td></tr>
<tr 
class="no-borders"><td>
    <asp:TextBox ID="txtfromdate"  CssClass="text datepicker" Width="150px" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" > </asp:TextBox> </td>
  <td><asp:TextBox ID="txttodate" CssClass="text datepicker"  Width="150px"  runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox></td>
  <td>&nbsp;
    <asp:Button ID="Button1" runat="server" CssClass="search"   OnClientClick="javascript:return selectdate()"  OnClick="Button1_Click1" />    </td></tr></table>
  </div>


    <table width="100%" id="avail" runat="server" visible="false">
        <tr>
            <td style="padding:0px;"><h4>
    Faculty Availabilty</h4>

            </td>
        </tr>
        <tr><td >
    <div class="dataGrid small-fonts">
    <asp:GridView CssClass="common" width="100%" ID="GridView1" runat="server"  Visible="false" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                <asp:TemplateField HeaderText="Faculty Name">
                    
                    <ItemTemplate>
                    
                    <a href="FacultyBatchDetails.aspx?FacultyName=<%#Eval("FacultyName") %>"> <%#Eval("FacultyName")%>  </a>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />--%>
                    <asp:BoundField DataField="MWF" HeaderText="MWF" />
                        <asp:BoundField DataField="TTS" HeaderText="TTS" />
                        <asp:BoundField DataField="Daily" HeaderText="Daily" />
                    <%--<asp:BoundField DataField="Specialisation" HeaderText="Specialisation" />--%>
                    <asp:BoundField DataField="7amto9am" HeaderText="7am to 9am" />
                    <asp:BoundField DataField="9amto11am" HeaderText="9am to 11am" />
                    <asp:BoundField DataField="11amto1pm" HeaderText="11am to 1pm" />
                    <asp:BoundField DataField="1pmto3pm" HeaderText="1pm to 3pm" />
                    <asp:BoundField DataField="3pmto5pm" HeaderText="3pm to 5pm" />
                    <asp:BoundField DataField="5pmto7pm" HeaderText="5pm to 7pm" />
                    <asp:BoundField DataField="7pmto9pm" HeaderText="7pm to 9pm" />
                </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
           
            
             <asp:Repeater id="rpfac" runat="server">

<HeaderTemplate>

<table border="0" width="100%" cellpadding="0" cellspacing="0" >
<tr>
<th rowspan="2">Faculty Name</th>
<th colspan="2">7AM - 9AM</th>
<th colspan="2">9AM - 11AM</th>
<th colspan="2">11AM - 1PM</th>
<th colspan="2">1PM - 3PM</th>
<th colspan="2">3PM - 5PM</th>
<th colspan="2">5PM - 7PM</th>
<th colspan="2">7PM - 9PM</th>
</tr>
<th style="background:#d7dadd">MWF</th>
<th style="background:#d7dadd">TTS</th>
<th style="background:#d3d6d9">MWF</th>
<th style="background:#d3d6d9">TTS</th>
<th style="background:#d7dadd">MWF</th>
<th style="background:#d7dadd">TTS</th>
<th style="background:#d3d6d9">MWF</th>
<th style="background:#d3d6d9">TTS</th>
<th style="background:#d7dadd">MWF</th>
<th style="background:#d7dadd">TTS</th>
<th style="background:#d3d6d9">MWF</th>
<th style="background:#d3d6d9">TTS</th>
<th style="background:#d7dadd">MWF</th>
<th style="background:#d7dadd">TTS</th>
 <tr>

 </tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td><%#Eval("facultyname1")%> </td>
<td style="background:#f7f7f7"><%#Eval("sevenmwf")%> </td>
<td style="background:#f7f7f7"><%#Eval("seventts")%> </td>
<td><%#Eval("ninemwf")%> </td>
<td><%#Eval("ninetts")%> </td>
<td style="background:#f7f7f7"><%#Eval("elevenmwf")%> </td>
<td style="background:#f7f7f7"><%#Eval("eleventts")%> </td>
<td><%#Eval("onepmmwf")%> </td>
<td><%#Eval("onepmtts")%> </td>
<td style="background:#f7f7f7"><%#Eval("threepmmwf")%> </td>
<td style="background:#f7f7f7"><%#Eval("threepmtts")%> </td>
<td><%#Eval("fivepmmwf")%> </td>
<td><%#Eval("fivepmtts")%> </td>
<td style="background:#f7f7f7"><%#Eval("sevenpmmwf")%> </td>
<td style="background:#f7f7f7"><%#Eval("sevenpmtts")%> </td>
</tr>
</ItemTemplate>

<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>

 <div class="free-forms" style="margin:10px 0px">
  <table class="common" width="100%" cellpadding="0" cellspacing="0">
            <tr>
            	<td> 
                <strong>- </strong>
            	</td>
            	<td align="left" style="text-align:left">The Faculty does not have shift in that time  </td>
            </tr>
            <tr>
            	<td>
                	<span style="color: #008000; font-weight:bold;">F</span>
				</td>
                <td align="left" style="text-align:left">The Faculty free in that time </td>
			</tr>
            
            <tr>
            	<td>
                	<span style="color: #ff0000; font-weight:bold;">B</span>
				</td>
                <td align="left" style="text-align:left">The Faculty alloted another batch in that time </td>
			</tr>
            </table>
         </td>
    </tr></table>
</div>
        <asp:HiddenField ID="hiddn_id" runat="server" />
</asp:Content>

