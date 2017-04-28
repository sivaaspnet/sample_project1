<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/imagemasterpage.master"   AutoEventWireup="true" CodeFile="StudentReportDetails.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReportDetails" Title="Student details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
jQuery(document).ready(function(){

		
});

function onFileLoad(e) { 

    $('#preview').html('<img height="100px" width="100px" src="'+e.target.result +'"/>'); 
 
}

function displayPreview(files) 
{
    var reader = new FileReader();
    reader.onload = onFileLoad;
    reader.readAsDataURL(files[0]);
    validate1();
    
   
}
function decline() {
 document.getElementById("ContentPlaceHolder1_decline_reason").style.display='';


         if(document.getElementById("ContentPlaceHolder1_txtdecline").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txtdecline").value=="";   
             alert("please provide reason for declining..!");
             document.getElementById("ContentPlaceHolder1_txtdecline").focus();
             document.getElementById("ContentPlaceHolder1_txtdecline").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtdecline").style.backgroundColor="#e8ebd9";
             return false;
         }
        else
        {
        return true;
        }
}

function validate1() {
var fup = document.getElementById('ContentPlaceHolder1_FileUpload1');
var fileName = fup.value;
var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
if(ext == "gif" || ext == "GIF" || ext == "JPEG" || ext == "jpeg" || ext == "jpg" || ext == "JPG" || ext == "png")
{
return true;
} 
else
{
document.getElementById("ContentPlaceHolder1_FileUpload1").value=""
alert("Upload Gif or Jpg images only");
fup.focus();
return false;
}
}
function Validate()
     {
  
         if(document.getElementById("ContentPlaceHolder1_FileUpload1").value=="")
         {
             document.getElementById("ContentPlaceHolder1_FileUpload1").value=="";   
             document.getElementById("ContentPlaceHolder1_lbl_error").innerHTML ='*Please Select Student photo!';
             document.getElementById("ContentPlaceHolder1_FileUpload1").focus();
             document.getElementById("ContentPlaceHolder1_FileUpload1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_FileUpload1").style.backgroundColor="#e8ebd9";
             return false;
         }
        else
        {
        return true;
        }
       
        
  }
  function Validate1()
     {
  
         if(document.getElementById("ContentPlaceHolder1_ddl_reason").value=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_reason").value=="";   
             document.getElementById("ContentPlaceHolder1_lbl_error").innerHTML ='*Please Select reason!';
             document.getElementById("ContentPlaceHolder1_ddl_reason").focus();
             document.getElementById("ContentPlaceHolder1_ddl_reason").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_reason").style.backgroundColor="#e8ebd9";
             return false;
         }
        else
        {
        return true;
        }
       
        
  }
  
  function chkval4()
   {
  
          if(document.getElementById("ContentPlaceHolder1_ddl_reason").value=="Others")
           {
              document.getElementById("ContentPlaceHolder1_TextBox1").value="";
              document.getElementById("ContentPlaceHolder1_TextBox1").style.display='';
           }
           else if(document.getElementById("ContentPlaceHolder1_ddl_reason").value=="")
           {
           document.getElementById("ContentPlaceHolder1_TextBox1").style.display='none';
           }
           else
           {
           document.getElementById("ContentPlaceHolder1_TextBox1").style.display='none';
           }
           document.getElementById("ContentPlaceHolder1_TextBox1").value=document.getElementById("ContentPlaceHolder1_ddl_reason").value;
   }

</script>

    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;

       
             <asp:Label ID="lbl_error" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="12pt"></asp:Label>
            
            <div id="report">
	<ul>
		<li><a href="#report1">Basic Information</a></li><li><a href="#report2">Course Details</a></li><li><a href="#report3">Leave Detalis</a></li><li><a runat="server" id="statuss" href="#report4">Status</a></li><li>
         
         </li>
         </ul>
         
          <div id="report1" class="studReportTab">
            <table >
                <tr>
                    <td style="width: 143px; height: 18px">
                         <h6 class="headingStudinfo">Personal Information</h6></td>
                    <td style="width: 25px; height: 18px">
                    </td>
                    <td style="width: 101px; height: 18px">
                         <h6 class="headingStudinfo"> Course Information</h6></td>
                    <td style="width: 24px; height: 18px">
                    </td>
                    <td style="width: 100px; height: 18px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 143px; height: 18px;">
                  
	<table style="WIDTH: 271px; height: 196px;" class="studReport">
		<tr id="tr1" runat="server">
        <td align="left" valign="middle" style="width: 176px; height: 7px;">
            <strong>Student Name : </strong>
            </td>
        <td align="left" valign="middle" style="height: 7px; width: 209px;">
            <asp:Label ID="LblSName" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            <td align="left" colspan="4" rowspan="9" valign="middle" style="color: #000000">
                &nbsp;</td>
      </tr>
            <tr id="Tr7" runat="server">
                <td align="left" style="width: 176px; height: 10px" valign="middle">
                    Student I<strong>d No &nbsp;: </strong>&nbsp;</td>
                <td align="left" style="width: 209px; height: 10px" valign="middle">
            <asp:Label ID="lblSId" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            </tr>
        <tr runat="server" id="Tr2">
            <td align="left" style="height: 20px" valign="middle">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="D.O.B :"></asp:Label>
            </td>
            <td align="left" style="width: 209px; height: 20px" valign="middle">
                <asp:Label ID="lbldob" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr runat="server" id="Tr3">
            <td align="left" style="height: 18px" valign="middle">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Gender :"></asp:Label></td>
            <td align="left" style="width: 209px; height: 18px" valign="middle">
                <asp:Label ID="lblgender" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr runat="server" id="Tr4">
            <td align="left" style="height: 18px" valign="middle">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Blood Group :"></asp:Label></td>
            <td align="left" style="width: 209px; height: 18px" valign="middle">
                <asp:Label ID="lblblood" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr runat="server" id="Tr8">
            <td align="left" style="height: 18px" valign="middle">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Marital Status :"></asp:Label></td>
            <td align="left" style="width: 209px; height: 18px" valign="middle">
                <asp:Label ID="lblmarital" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr runat="server" id="Tr9">
            <td align="left" style="height: 18px" valign="middle">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Nationality :"></asp:Label></td>
            <td align="left" style="width: 209px; height: 18px" valign="middle">
                <asp:Label ID="lblnation" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr runat="server" id="Tr10">
            <td align="left" style="height: 18px" valign="middle">
                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Mother Tongue:"></asp:Label></td>
            <td align="left" style="width: 209px; height: 18px" valign="middle">
                <asp:Label ID="lblmother" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
        </tr>
            <tr id="Tr11" runat="server">
                <td align="left" style="width: 176px; height: 10px" valign="middle">
                    </td>
                <td align="left" style="width: 209px; height: 10px" valign="middle">
            </td>
            </tr>
       </table>
                    </td>
                    <td style="width: 25px; height: 18px">
                    </td>
                    <td style="width: 101px; height: 18px;">
                   
     	<table style="WIDTH: 271px; height: 196px;" class="studReport"> 
            <tr id="Tr5" runat="server" style="font-weight: bold">
                <td align="left" style="width: 176px; height: 10px" valign="middle">
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Invoice No :"></asp:Label></td>
                <td align="left" style="width: 148px; height: 10px" valign="middle">
            <asp:Label ID="lblInv" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
                <td align="left" colspan="3" style="height: 10px; width: 11px; color: #000000;" valign="middle">
                </td>
            </tr>
        <tr runat="server" style="font-weight: bold" id="Tr6">
            <td align="left" style="width: 176px; height: 10px" valign="middle">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Course Name :"></asp:Label></td>
            <td align="left" style="width: 148px; height: 10px" valign="middle">
            <asp:Label ID="lblCourse" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td align="left" colspan="3" style="width: 11px; color: #000000; height: 10px" valign="middle">
            </td>
        </tr>
            <tr id="Tr12" runat="server" style="color: #000000">
                <td align="left" style="width: 176px; height: 22px" valign="middle">
                    <strong>Track : </strong>
                </td>
                <td align="left" style="width: 148px; height: 22px" valign="middle">
                  <asp:Label ID="lblTrack" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                <td align="left" colspan="3" style="height: 22px; width: 11px; color: #000000;" valign="middle">
                </td>
            </tr>
        <tr runat="server" style="color: #000000" id="Tr13">
            <td align="left" style="width: 176px; height: 22px" valign="middle">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Course Fees :"></asp:Label></td>
            <td align="left" style="width: 148px; height: 22px" valign="middle">
                <asp:Label ID="lbl_coursefees" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            <td align="left" colspan="3" style="width: 11px; color: #000000; height: 22px" valign="middle">
            </td>
        </tr>
        <tr runat="server" style="color: #000000" id="Tr14">
            <td align="left" style="width: 176px; height: 22px" valign="middle">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Enrollment Date :"></asp:Label></td>
            <td align="left" style="width: 148px; height: 22px" valign="middle">
              <asp:Label ID="lblEnrDate" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td align="left" colspan="3" style="width: 11px; color: #000000; height: 22px" valign="middle">
            </td>
        </tr>
      <tr>
        <td style="width: 176px; height: 25px;"></td>
        <td style="width: 148px; height: 25px;"></td>
        <td style="height: 25px;" colspan="2"></td>
        <td style="height: 25px">&nbsp;</td>
      </tr>
             <tr>
                 <td style="width: 176px; height: 25px">
                 </td>
                 <td style="width: 148px; height: 25px">
                 </td>
                 <td colspan="2" style="height: 25px">
                 </td>
                 <td style="height: 25px">
                 </td>
             </tr>
             <tr>
                 <td style="width: 176px; height: 25px">
                 </td>
                 <td style="width: 148px; height: 25px">
                 </td>
                 <td colspan="2" style="height: 25px">
                 </td>
                 <td style="height: 25px">
                 </td>
             </tr>
      </table>
                    </td>
                    <td style="width: 24px; height: 18px">
                    </td>
                    <td style="width: 100px; height: 18px;">
                <asp:Image ID="Image2" runat="server" AlternateText="studentphoto" Height="147px"
                    ImageUrl="~/Onlinestudents2/layout/blank person.jpg" Width="132px" /><asp:Image  ID="Image4" runat="server" Height="76px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/drop.png"
                    Visible="False" Width="125px" /></td>
                </tr>
                <tr>
                    <td style="width: 143px; height: 32px;">
                       <h6 class="headingStudinfo">Contact Information</h6></td>
                    <td style="width: 25px; height: 32px;">
                    </td>
                    <td style="width: 101px; height: 32px;">
                           <h6 class="headingStudinfo"> Parents Information</h6></td>
                    <td style="width: 24px; height: 32px;">
                    </td>
                    <td style="width: 100px; height: 32px;">
                         <h6 class="headingStudinfo">
            Fees Information
            </h6></td>
                </tr>
                <tr>
                    <td style="width: 143px">
                    
      
   
      <table style="WIDTH: 271px; height: 196px;" class="studReport">
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Address :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lbladdress" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td colspan="2" style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="lbl_phone" runat="server" Font-Bold="True" Text="PhoneNumber :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lbl_no" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td colspan="2" style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Alternate Number :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lblano" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td colspan="2" style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Mail ID :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lbl_mail" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
            <td colspan="2" style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
            </td>
            <td style="width: 148px; height: 25px">
            </td>
            <td colspan="2" style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
          <tr>
              <td style="width: 176px; height: 25px">
              </td>
              <td style="width: 148px; height: 25px">
              </td>
              <td colspan="2" style="height: 25px">
              </td>
              <td style="height: 25px">
              </td>
          </tr>
        </table>
                    </td>
                    <td style="width: 25px">
                    </td>
                    <td style="width: 101px">
                  
        <table style="WIDTH: 271px; height: 196px;" class="studReport">
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Parent / Guardian's Name  :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lblfname" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            <td colspan="2" style="height: 25px; width: 6px;">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Occupation :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lblfoccupation" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            <td colspan="2" style="height: 25px; width: 6px;">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Email ID :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lblfemail" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            <td colspan="2" style="height: 25px; width: 6px;">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Contact No :"></asp:Label></td>
            <td style="width: 148px; height: 25px">
                <asp:Label ID="lblfno" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
            <td colspan="2" style="height: 25px; width: 6px;">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 176px; height: 25px">
            </td>
            <td style="width: 148px; height: 25px">
            </td>
            <td colspan="2" style="height: 25px; width: 6px;">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
            <tr>
                <td style="width: 176px; height: 25px">
                </td>
                <td style="width: 148px; height: 25px">
                </td>
                <td colspan="2" style="width: 6px; height: 25px">
                </td>
                <td style="height: 25px">
                </td>
            </tr>
        </table>
                    </td>
                    <td style="width: 24px">
                    </td>
                    <td style="width: 100px">
                   
        <table style="WIDTH: 271px; height: 196px;" class="studReport">
        <tr>
            <td style="width: 176px; height: 25px">
                <asp:LinkButton ID="lnk_inv" runat="server" OnClick="lnk_inv_Click" Font-Bold="True" ForeColor="Green" Width="125px">View Student Invoice</asp:LinkButton></td>
            <td style="width: 148px; height: 25px">
            </td>
            <td colspan="2" style="height: 25px">
            </td>
            <td style="height: 25px">
            </td>
        </tr>
                <tr>
                    <td style="width: 176px; height: 25px">
                        Pending Amount :</td>
                    <td style="width: 148px; height: 25px">
                        <asp:Label ID="lbl_pendingamt" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
                    <td colspan="2" style="height: 25px">
                    </td>
                    <td style="height: 25px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 176px; height: 25px">
                        <strong>Pending Amount with tax:</strong>&nbsp;</td>
                    <td style="width: 148px; height: 25px">
                        <asp:Label ID="lbl_pendingwithtax" runat="server"
                    ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
                    <td colspan="2" style="height: 25px">
                    </td>
                    <td style="height: 25px">
                    </td>
                </tr>
            <tr>
                <td style="width: 176px; height: 25px">
                </td>
                <td style="width: 148px; height: 25px">
                </td>
                <td colspan="2" style="height: 25px">
                </td>
                <td style="height: 25px">
                </td>
            </tr>
            <tr>
                <td style="width: 176px; height: 25px">
                </td>
                <td style="width: 148px; height: 25px">
                </td>
                <td colspan="2" style="height: 25px">
                </td>
                <td style="height: 25px">
                </td>
            </tr>
            <tr>
                <td style="width: 176px; height: 25px">
                </td>
                <td style="width: 148px; height: 25px">
                </td>
                <td colspan="2" style="height: 25px">
                </td>
                <td style="height: 25px">
                </td>
            </tr>
            </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 143px">
                    </td>
                    <td style="width: 25px">
                    </td>
                    <td style="width: 101px">
                    </td>
                    <td style="width: 24px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
            </table>
           
	
	
	
     
       
           
    
	</div>

	<div id="report2">
	<table class="common">
		  
            <tr>
                <td colspan="5" style="padding:0px; height: 14px;">
                    </td>
            </tr>
            <tr>
                <td colspan="5" >
        <asp:GridView  ID="GridView1"  runat="server" AutoGenerateColumns="False" Width="791px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25" CssClass="common">
            <Columns>
                <asp:TemplateField HeaderText="Module">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("module") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                     <a rel="modal" href="studentmodulebatch.aspx?studentid=<%#Eval("studentid")%>&moduleid=<%#Eval("moduleid")%>&iframe=true&amp;width=500&amp;height=300" class="error"><%#Eval("module")%></a>
                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="status" HeaderText="Status" HtmlEncode="False" />
                <asp:BoundField HeaderText="Content Status" DataField="content" HtmlEncode="False" />
            
            </Columns>
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center" style=" text-align:center; height: 26px;" visible="false" runat="server" id="Td1">
                   <input id="Button1" class="submit"   onclick="window.open('printstudentreport.aspx?StudentID=<%=lblSId.Text%>','PrintMe','height=500px,width=600px,scrollbars=1')" type="button"
                                value="Print" /></td>
            </tr>	
            
            </table>
      
        <br />
	</div>
	
	
	
	
	
	<div id="report3">
	
	
	
	<TABLE class="common"><TBODY><TR><TD 
style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px" 
colSpan=2><H4>
    Leave Details</H4></TD></TR>
        <tr>
            <td colspan="2">
                <strong>Leave Request</strong></td>
        </tr>
        <TR><TD colSpan=2 >
    <asp:GridView id="grdcentre" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Leave Request" OnPageIndexChanging="grdcentre_PageIndexChanging" AllowPaging="True" OnRowCommand="grdcentre_RowCommand">
        <Columns>
             <asp:BoundField DataField="studentid" HeaderText="Student Id" ></asp:BoundField>
            <asp:BoundField DataField="enq_personal_name" HeaderText="Name" ></asp:BoundField>
            <asp:BoundField DataField="fromdate" HeaderText="From Date" ></asp:BoundField>
            <asp:BoundField DataField="todate" HeaderText="To Date" ></asp:BoundField>
            <asp:BoundField DataField="noofdays" HeaderText="No Of Days" />
            <asp:BoundField DataField="reason" HeaderText="Reason" ></asp:BoundField>
             <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove" CommandName="approve"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> 
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline"  CommandName="decline" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>                 
            </asp:TemplateField>
            <asp:TemplateField HeaderText="status">
            <ItemTemplate>
                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Eval("status_cen")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove1" CommandName="approve1"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> 
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline1"  CommandName="decline1" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>       
            
            
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast"  />
        <EmptyDataRowStyle ForeColor="Red"  />
    </asp:GridView>
     <hr />
     </TD></TR>
        <tr>
            <td colspan="2">
                <strong>Leave History</strong></td>
        </tr>
        <tr>
            <td colspan="2" >
           
             <asp:GridView id="GridView2" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Leave Request" OnPageIndexChanging="grdcentre_PageIndexChanging" AllowPaging="True" OnRowCommand="grdcentre_RowCommand">
        <Columns>
             <asp:BoundField DataField="studentid" HeaderText="Student Id" ></asp:BoundField>
            <asp:BoundField DataField="enq_personal_name" HeaderText="Name" ></asp:BoundField>
            <asp:BoundField DataField="fromdate" HeaderText="From Date" ></asp:BoundField>
            <asp:BoundField DataField="todate" HeaderText="To Date" ></asp:BoundField>
            <asp:BoundField DataField="noofdays" HeaderText="No Of Days" />
            <asp:BoundField DataField="reason" HeaderText="Reason" ></asp:BoundField>
             <asp:TemplateField HeaderText="Technical Head">
                <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove" CommandName="approve"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> 
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline"  CommandName="decline" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>                 
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CentreManager">
            <ItemTemplate>
                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Eval("status_cen")%>'></asp:Label>
                  <asp:LinkButton ID="lnkapprove1" CommandName="approve1"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton> 
                  &nbsp; &nbsp;<asp:LinkButton ID="lnkdecline1"  CommandName="decline1" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton> 

                     </ItemTemplate>       
            
            
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast"  />
        <EmptyDataRowStyle ForeColor="Red"  />
    </asp:GridView>
            
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <hr />
                <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Black" Text="Break Details"></asp:Label><br />
                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="common" EmptyDataText="No Records Found" OnRowCommand="GridView3_RowCommand1" >
                    <Columns>
                        <asp:TemplateField HeaderText="Student ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                
                                    <%#Eval("studentid")%>
                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="enq_personal_name" HeaderText="Student Name" />
                        <asp:BoundField DataField="breakdate" HeaderText="Break Date" />
                        <asp:BoundField DataField="reason" HeaderText="Reason" />
                        <asp:TemplateField HeaderText="Resume">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("studentid")%>'
                                    CommandName="lnkedit" ToolTip="Resume Student"><img src="layout/refresh_icon.gif" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                    <EmptyDataRowStyle ForeColor="Red" />
                </asp:GridView>
            </td>
        </tr>
    </TBODY></TABLE>
	
	
	
	
	
	
	
	
	
	
	
	
    </div>
    
    	<div id="report4" >
	 <table class="common" runat="server" id="Table2" style="width: 232px; height: 132px;" >
        <tr>
            <td align="center" style="font-size: 12px; color: blue; text-align: center; width: 42px;">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="12pt"></asp:Label>
                <asp:Label ID="dropdate" runat="server" Font-Bold="True" ForeColor="#C00000" Visible="False"></asp:Label></td>
            <td align="center" style="font-size: 12px;  color: blue; 
                text-align: center; width: 228px;">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="font-size: 12px; color: blue; width: 42px;">
                <asp:Image ID="Image1" runat="server" Height="67px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/alert.gif"
                    Width="59px" />
                </td>
            <td  align="center" style=" font-size: 12px;  color: blue; text-align:center; width: 228px;">
                <strong>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Text="Are you sure ?"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text="You are about to drop student from ERP System..!"></asp:Label>
                <asp:Image  ID="Image3" runat="server" Height="76px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/drop.png"
                    Visible="False" Width="125px" /></strong></td>
        </tr>
        <tr>
            <td align="left" style="height: 23px; width: 42px;">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Reason :"></asp:Label></td>
            <td align="left" style="height: 23px; width: 228px;">
                <asp:DropDownList ID="ddl_reason" runat="server" onChange="return chkval4()">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Higher studies">Higher studies</asp:ListItem>
                    <asp:ListItem Value="Finance Problem">Finance Problem</asp:ListItem>
                    <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" style="display:none" runat="server" CssClass="text" > </asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="width: 42px; height: 59px;">
                <strong style="color: maroon">Description</strong></td>
            <td align="left" style="HEIGHT: 59px; width: 228px;">
                <br />
                <asp:TextBox ID="txt_reason" runat="server" CssClass="text" TextMode="MultiLine" Width="289px"></asp:TextBox></td>
        </tr>
         <tr id="decline_reason" runat="server" style="display:none;">
             <td align="left" style="width: 42px">
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Reason For Declining" Width="118px"></asp:Label></td>
             <td align="left" style="HEIGHT: 59px; width: 228px;">
             <br />
                 <asp:TextBox  ID="txtdecline" runat="server" CssClass="text" MaxLength="250" TextMode="MultiLine" Width="287px"></asp:TextBox></td>
         </tr>
        <tr>
            <td align="center" style="text-align: center; width: 42px; height: 31px;">
              
                </td>
            <td align="center"  style=" text-align:center; height: 31px; width: 228px;">
                <asp:Button ID="btn_req" runat="server" OnClientClick="javascript:return Validate1();"  CssClass="submit" OnClick="btn_req1"
                    Text="Request" />&nbsp;
                <asp:Button ID="btn_acc" runat="server" CssClass="submit" OnClick="btn_acc1"
                    Text="Accept" Visible="False" />&nbsp;
                <asp:Button ID="btn_dec" runat="server" CssClass="submit" OnClientClick="javascript:return decline();" OnClick="btn_dec1"
                    Text="Decline" /></td>
        </tr>
    </table>
    </div>
            
            
            
            
</div>

 
   
</asp:Content>

