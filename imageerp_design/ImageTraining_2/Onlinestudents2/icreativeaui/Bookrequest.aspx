<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Bookrequest.aspx.cs" Inherits="Onlinestudents2_Default2" Title="Book Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
 <asp:ScriptManager runat="server" id="script1">
    </asp:ScriptManager>
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
                   Book Request</h4></td>
        </tr>
            <tr>
    <td colspan="2">
    <div class="notification free-forms">
	<ul>
	
		<li><a runat="server" id="a1" href="#Send">Send Request</a></li><li><a runat="server" id="a2" href="#View">View Request</a></li></ul>
		<div id="Send">
    <table class="common" width="100%">
        <tr>
            <td style="width: 100px; height: 31px">
            </td>
            <td style="width: 339px; height: 31px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>

      
        <tr>
            <td style="width: 100px; height: 31px">
                <strong>Student Id </strong><span style="color: #ff0000">*</span></td>
            <td style="width: 339px; height: 31px">
                <asp:TextBox ID="txt_studentid" runat="server" CssClass="text" MaxLength="20"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" CssClass="submit" OnClientClick="return val()" OnClick="Button2_Click"
                    Text="submit" />
                     <br />
                    <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txt_studentid"></asp:CustomValidator>
                    </td>
        </tr>
     
      
        <tr id="tr1" runat="server" visible="false" >
      
            <td>
                <strong>Student Name</strong></td>
        <td >
            <asp:Label ID="Label4" runat="server"></asp:Label></td>
         
        </tr>
        <tr id="tr2" runat="server" visible="false">
    
            <td >
            <asp:Label ID="Label9" runat="server" Text="Course Name" Font-Bold="True"></asp:Label></td>
                <td>
        <asp:Label ID="Label14" runat="server"></asp:Label>
        </td>
        
        </tr>
            <tr id="tr3" runat="server" visible="false">
                <td>
            <asp:Label ID="Label8" runat="server" Text="Invoice No" Font-Bold="True"></asp:Label></td>
                <td>
                                       
             <a id="link1" runat="server" style="color:Blue"><asp:Label ID="invoice" runat="server" Text=""></asp:Label></a>
             </td>
               
            </tr>
       
      
            <tr id="t4" runat="server" visible="false">
                <td style="width: 100px; height: 31px">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Select Book"></asp:Label></td>
                <td style="width: 339px; height: 31px">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                        </td>
            </tr>
        <tr id="t5" runat="server" visible="false">
            <td style="width: 100px; height: 29px;" >
                <strong>Requested Date</strong></td>
            <td style="width: 339px; height: 29px;" >
                <asp:TextBox ID="TextBox1" CssClass="text datepicker" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false"  ></asp:TextBox>
               </td>
        </tr>
        
      
        <tr id="t6" runat="server" visible="false">
            <td style="width: 100px; height: 31px;">
            </td>
            <td style="width: 339px; height: 31px;">
                <asp:Button ID="btnsubmit5" runat="server" CssClass="submit"  OnClientClick="return val1()"
               Text="Submit" OnClick="btnsubmit5_Click"   />
                </td>
        </tr>
    </table>
    </div>
    
    <div id="View" class="free-forms">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
    <contenttemplate>
    <table id="Table1" runat="server" class="common" language="javascript" onclick="return TABLE1_onclick()">
        <tr>
        <td>From Date 
            <asp:TextBox ID="txtfromdate" CssClass="text datepicker" style="width:95px;" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false"  ></asp:TextBox></td><td> To Date 
            <asp:TextBox ID="txttodate" CssClass="text datepicker" style="width:95px;" runat="server" onkeypress="return false" onkeydown="return false" onpaste="return false"  ></asp:TextBox> </td>
     <td>Keywords 
           <asp:TextBox ID="searchbox" runat="server" style="width:110px;" CssClass="text"></asp:TextBox></td><td>
               <asp:Button ID="btnsearch" runat="server" CssClass="search" Text="" OnClick="btnsearch_Click" />
               <br />
                    <asp:CustomValidator ID="custSpecialValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special2" ControlToValidate="searchbox"></asp:CustomValidator>
                </td></tr>
       <tr>
       <td colspan="4"> 
           <div style="max-height:600px; overflow:auto;">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record">
               <Columns>
                   <asp:BoundField DataField="studentid" HeaderText="StudentId" />
                   <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                   <asp:BoundField DataField="program" HeaderText="Course" />
                   <asp:BoundField DataField="bookname" HeaderText="Books" />
                   <asp:BoundField DataField="requested_date" HeaderText="Requested Date" />
                   <asp:BoundField DataField="status" HeaderText="Status" />
                  
               </Columns>
                                <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
           </asp:GridView></div><br />
         
       </td>
       </tr>
    </table> </contenttemplate>
                           </asp:UpdatePanel>  <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click">Download Excel</asp:LinkButton>
    </div>
   
		</div>
    </td>
    </tr>
    </table>
    
    
    <table  class="common" runat="server" visible="false"   id="tab2" language="javascript" onclick="return TABLE1_onclick()" >
        <tr>
            <td colspan="2" style=" padding:0px; height: 29px;">
               <h4>
                   Book Request</h4></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 31px">
            </td>
            <td style="width: 339px; height: 31px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
    
       
        <tr>
            <td style="width: 100px; height: 31px">
                <strong>Student Id </strong></td>
            <td style="width: 339px; height: 31px">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>&nbsp;
               </td>
        </tr>
     
      
        <tr id="tr4" runat="server"  >
      
            <td>
                <strong>Student Name</strong></td>
        <td >
            <asp:Label ID="Label3" runat="server"></asp:Label></td>
         
        </tr>
        <tr id="tr5" runat="server" >
    
            <td >
            <asp:Label ID="Label5" runat="server" Text="Course Name" Font-Bold="True"></asp:Label></td>
                <td>
        <asp:Label ID="Label7" runat="server"></asp:Label>
        </td>
        
        </tr>
       
       
      
            <tr id="Tr7" runat="server" >
                <td style="width: 100px; height: 31px">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text=" Book(s)"></asp:Label></td>
                <td style="width: 339px; height: 31px">
                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                    <asp:HiddenField ID="HiddenField5" runat="server" />
                    <asp:HiddenField ID="HiddenField6" runat="server" />
                        </td>
            </tr>
        <tr id="Tr8" runat="server" >
            <td style="width: 100px; height: 29px;" >
                <strong>Requested Date</strong></td>
            <td style="width: 339px; height: 29px;" >
                <asp:Label ID="Label10" runat="server"></asp:Label>
               
               </td>
        </tr>
             <tr id="Tr6" runat="server" >
            <td style="width: 100px; height: 29px;" >
                <strong>Status</strong></td>
            <td style="width: 339px; height: 29px;" >
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem  Value="">Select</asp:ListItem>
                <asp:ListItem  Value="Approved">Approved</asp:ListItem>
                 <asp:ListItem  Value="Rejected">Rejected</asp:ListItem>
                </asp:DropDownList>
               
               </td>
        </tr>          
        <tr id="tr10" visible="false" runat="server">
            <td style="width: 100px; height: 29px">
             <strong>Reason</strong></td>
           
            <td style="width: 339px; height: 29px">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr id="Tr9" runat="server" >
            <td style="width: 100px">
            </td>
            <td style="width: 339px">
                <asp:Button ID="Button6" runat="server" CssClass="submit"  OnClientClick="return val2()" 
               Text="Submit" OnClick="Button6_Click"   />
                </td>
        </tr>
       
    </table>
    
</asp:Content>

