<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="LabAvail.aspx.cs" Inherits="superadmin_LabAvail" Title="Lab Availability" %>
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

function selectdate()
{
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
 <h4>Lab Availabilty</h4>
    <table class="common" width="100%">
		<tr class="no-borders">
        	<td>
    			From Date<br />
    			<asp:TextBox ID="txtfromdate" style="width:160px" CssClass="text datepicker" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false"></asp:TextBox>
			</td>
            
            <td> 
    			To Date<br />
    			<asp:TextBox ID="txttodate" style="width:160px"  CssClass="text datepicker" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false"></asp:TextBox>
			</td>
            
            <td>
            	<asp:Label ID="Label1" runat="server" Text="Searchby Lab Name"></asp:Label><br />
                <asp:DropDownList ID="ddl_labname" runat="server" style="width:160px" ></asp:DropDownList>
            </td>
    		
            <td valign="middle">
        		<asp:Button ID="Button1" runat="server" CssClass="search"  OnClientClick="javascript:return selectdate()"  OnClick="Button1_Click1"/>
			</td>
    </tr>
</table>
    </div>
 
       <div class="dataGrid small-fonts">
    	<asp:GridView CssClass="common" Visible="false" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" width="100%">
                <Columns>
                <asp:TemplateField HeaderText="Lab Name">
                    
                    <ItemTemplate>
                    
                    <a href="LabDetails.aspx?LabName=<%#Eval("Labname") %>"> <%#Eval("Labname") %>  </a>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                    <asp:BoundField DataField="System" HeaderText="Number of Systems" />
                    
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
            <div style="overflow:auto" >
            
               <asp:Repeater id="rplab" runat="server">

<HeaderTemplate>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<th rowspan="2">LAB</th>
<th rowspan="2">No. Of. System</th>
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
<td><%#Eval("labname1")%> </td>
<td><%#Eval("Noofsys")%> </td>
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
</div>
</div>
         <asp:HiddenField ID="hiddn_id" runat="server" />
         
        <div id="note" runat="server" visible="false"> <p style="color:#000"><span style='color:#ff0000; font-weight:bold'>Red</span> - Batched, &nbsp;&nbsp; <span style='color:green; font-weight:bold'>Green</span> - Free</p></div>
         
</asp:Content>

