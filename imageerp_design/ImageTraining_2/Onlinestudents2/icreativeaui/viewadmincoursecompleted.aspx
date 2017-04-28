<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="viewadmincoursecompleted.aspx.cs" Inherits="Onlinestudents2_Default2" Title="Admin Course Completed Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
     <script type="text/javascript">
    $(document).ready(function() {
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(evt, args) {
        	jQuery(".datepicker").datepicker({showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });

    });
     });
</script>

<script language="javascript" type="text/javascript">
function val2()
{
if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="")
 {
    alert("Please select status");
    document.getElementById("ContentPlaceHolder1_DropDownList1").focus();
    document.getElementById("ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
    return false;
    
 }
 else
 if(document.getElementById("ContentPlaceHolder1_TextBox2").value=="")
 {
    alert("Please enter reason");
    document.getElementById("ContentPlaceHolder1_TextBox2").focus();
    document.getElementById("ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
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

 if(document.getElementById("ContentPlaceHolder1_txt_studentid").value=="")
 {
    alert("Please enter Student Id");
    document.getElementById("ContentPlaceHolder1_txt_studentid").focus();
    document.getElementById("ContentPlaceHolder1_txt_studentid").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9";
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
     var CHK = document.getElementById("ContentPlaceHolder1_CheckBoxList1");   
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
	     document.getElementById("ContentPlaceHolder1_CheckBoxList1").focus();
         return false;	        
    }
    else
    if(document.getElementById("ContentPlaceHolder1_TextBox1").value=="")
    {
    alert("Please enter date");
     document.getElementById("ContentPlaceHolder1_TextBox1").focus();
    document.getElementById("ContentPlaceHolder1_TextBox1").style.border="#ff0000 1px solid";
    document.getElementById("ContentPlaceHolder1_TextBox1").style.backgroundColor="#e8ebd9";
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
    document.getElementById("ct100_ContentPlaceHolder1_txt_studentid").style.backgroundColor="#e8ebd9";
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

<script type="text/javascript">

$(document).ready(function()
{
$('#ContentPlaceHolder1_searchbox').keyup(function()
{
searchTable($(this).val());
});
});
function searchTable(inputVal)
{
var table = $('#ContentPlaceHolder1_GridView1');
table.find('tr').each(function(index, row)
{
var allCells = $(row).find('td');
if(allCells.length > 0)
{
var found = false;
allCells.each(function(index, td)
{
var regExp = new RegExp(inputVal, 'i');
if(regExp.test($(td).text()))
{
found = true;
return false;
}
});
if(found == true)$(row).show();else $(row).hide();
}
});
}
</script>

    <table width="100%"  class="common" id="tab1" runat="server"   language="javascript" onclick="return TABLE1_onclick()" >
        <tr>
            <td colspan="2" style=" padding:0px; height: 29px;">
               <h4>
                   Admin software completed student list.</h4></td>
        </tr>
            <tr>
    <td colspan="2">
    <div class="notification free-forms">

    <div id="View" class="free-forms">

    <table id="Table1" runat="server" class="common" language="javascript" onclick="return TABLE1_onclick()">
        <tr>
        <td style="display:none;">From Date 
            <asp:TextBox ID="txtfromdate" CssClass="text datepicker" style="width:95px;" runat="server"></asp:TextBox></td>
          <td style="display:none;"> To Date 
            <asp:TextBox ID="txttodate" CssClass="text datepicker" style="width:95px;" runat="server"></asp:TextBox> </td>
      </tr>
       <tr>
       <td colspan="4"> 
           <div style="max-height:600px; overflow:auto; margin:auto;">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record">
               <Columns>
                   <asp:BoundField DataField="studentid" HeaderText="StudentId" />
                   <asp:BoundField DataField="Module_Name" HeaderText="Module Name" />
                   <asp:BoundField DataField="Software_Name" HeaderText="software Name" />
                
                   <asp:BoundField DataField="softwarestatus" HeaderText="Status" />
                  
               </Columns>
                                <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
           </asp:GridView></div><br />
         
       </td>
       </tr>
    </table>  <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click">Download Excel</asp:LinkButton>
    </div>
   
		</div>
    </td>
    </tr>
    </table>
    
    
    </asp:Content>

