<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master"   AutoEventWireup="true" CodeFile="StudentReportDetails.aspx.cs" Inherits="Onlinestudents2_superadmin_StudentReportDetails" Title="Student details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%--<style type="text/css">
        div.htmltooltip{
         background: none repeat scroll 0 0 ivory;
    border: 1px solid black;
    color: black;
margin-top:-900px;
    left:1000px;
    padding: 3px;
    position: absolute;
    z-index: 1000;
    margin-left:-10px;
	display:none
    

        }

        </style>--%>
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
   
   $(document).ready(function()
{
$('#ContentPlaceHolder1_txt_softwareid').keyup(function()
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
  <div>
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
  <td  class="student_reporttext" valign="middle">Student ID: </td>
  <td class="student_reporttext" valign="middle"><asp:Label ID="lblstudentid" runat="server" ForeColor="Maroon" ></asp:Label></td>
  <td  class="student_reporttext" valign="middle">Student Name:</td>
  <td class="student_reporttext" valign="middle"><asp:Label ID="lblstudentname" runat="server" ForeColor="Maroon" ></asp:Label></td>
  <td  class="student_reporttext" valign="middle">Course Name: </td>
  <td class="student_reporttext" valign="middle"><asp:Label ID="lblcoursename" runat="server" ForeColor="Maroon" ></asp:Label></td>
  </tr>
  <tr>
  <td  class="student_reporttext" style="width: 80px">Duration : </td>
  <td class="student_reportresult" ><asp:Label ID="lblduration" runat="server" ForeColor="Maroon" ></asp:Label></td>
  <td  class="student_reporttext" style="width: 80px">Paid Amount : </td>
  <td class="student_reportresult" ><asp:Label ID="lblpaidamount" runat="server" ForeColor="Maroon" ></asp:Label></td>
  <td  class="student_reporttext">Start Date : <asp:Label ID="lblstartdate" runat="server" ForeColor="Maroon" ></asp:Label></td>
  <td class="student_reporttext" >End Date : <asp:Label ID="lblenddate" runat="server" ForeColor="Maroon" ></asp:Label></td>
  </tr>
  </table>
  </div>
  <div style="text-align:center;">
  <asp:Label ID="lbl_error" runat="server"  ForeColor="Red" Font-Size="12pt"></asp:Label>
  </div> 
  <div id="report">
    <ul>
      <li><a href="#report1">Basic Information</a></li><li><a href="#report2">Course Details</a></li><li><a href="#assesment25">Project Details</a></li><li><a href="#report3">Leave Detalis</a></li><li><a runat="server" id="statuss" href="#report4">Status</a></li><li> </li>
    </ul>
    <div id="report1" class="studReportTab">
      <h6 class="headingStudinfo">Personal Information</h6>
      <div class="student_reportinfo" style="position:relative">
        <div class="ceal" style="position:absolute; right:10px; top:10px;">
          <asp:Image ID="Image2" runat="server" AlternateText="" Height="111px" ImageUrl="~/Onlinestudents2/layout/blank person.jpg" Width="100px"  />
          <asp:Image style="margin-top:10px"  ID="Image4" runat="server" Height="76px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/drop.png" Visible="False" Width="125px" />
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
         <!-- <tr id="tr1" runat="server">
            <td class="student_reporttext" style="width: 150px">Student Name</td>
            <td class="student_reportresult" style="width:200px"><asp:Label ID="LblSName" runat="server" ForeColor="Maroon" 

></asp:Label></td>
            <td class="student_reporttext" style="width: 150px">Student Id No</td>
            <td class="student_reportresult"><asp:Label ID="lblSId" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>-->
          <tr runat="server" id="Tr2">
            <td class="student_reporttext" style="width: 150px">D.O.B</td>
            <td class="student_reportresult"  style="width:200px"><asp:Label ID="lbldob" runat="server" ForeColor="Maroon" ></asp:Label></td>
            <td class="student_reporttext" style="width: 150px">Gender</td>
            <td class="student_reportresult"><asp:Label ID="lblgender" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
          <tr runat="server" id="Tr4">
            <td class="student_reporttext">Blood Group</td>
            <td class="student_reportresult"><asp:Label ID="lblblood" runat="server" ForeColor="Maroon" ></asp:Label></td>
            <td class="student_reporttext">Marital Status</td>
            <td class="student_reportresult"><asp:Label ID="lblmarital" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
          <tr runat="server" id="Tr9">
            <td class="student_reporttext no-borders">Nationality</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lblnation" runat="server" ForeColor="Maroon" ></asp:Label></td>
            <td class="student_reporttext no-borders">Mother Tongue</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lblmother" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
        </table>
      </div>
      <h6 class="headingStudinfo">Parents Information</h6>
      <div class="student_reportinfo">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="student_reporttext" style="width: 150px">Parent / Guardian's Name</td>
            <td class="student_reportresult" style="width: 200px"><asp:Label ID="lblfname" runat="server" ForeColor="Maroon" ></asp:Label></td>
            <td class="student_reporttext" style="width: 150px">Occupation</td>
            <td class="student_reportresult"><asp:Label ID="lblfoccupation" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
          <tr>
            <td class="student_reporttext no-borders"> Email ID</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lblfemail" runat="server" ForeColor="Maroon" 

></asp:Label></td>
            <td class="student_reporttext no-borders">Contact No</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lblfno" runat="server" ForeColor="Maroon" 

></asp:Label></td>
          </tr>
        </table>
      </div>
      <H6 class="headingStudinfo">Contact Information</H6>
      <div class="student_reportinfo">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="student_reporttext" style="width: 150px">Address</td>
            <td class="student_reportresult" style="width: 200px"><asp:Label ID="lbladdress" runat="server"  

ForeColor="Maroon"></asp:Label></td>
            <td class="student_reporttext" style="width: 150px">PhoneNumber </td>
            <td class="student_reportresult"><asp:Label ID="lbl_no" runat="server"  ForeColor="Maroon"></asp:Label></td>
          </tr>
          <tr>
            <td class="student_reporttext no-borders">Alternate Number</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lblano" runat="server"  

ForeColor="Maroon"></asp:Label></td>
            <td class="student_reporttext no-borders">Mail ID</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lbl_mail" runat="server"  ForeColor="Maroon"></asp:Label></td>
          </tr>
        </table>
      </div>
      
      <h6 class="headingStudinfo">Course Information</h6>
      <div class="student_reportinfo">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr runat="server">
            <td class="student_reporttext" style="width:150px"> Enrollment Date</td>
            <td class="student_reportresult" style="width:200px"><asp:Label ID="lblEnrDate" runat="server"  ForeColor="Maroon"></asp:Label></td>
            <td class="student_reporttext" style="width: 150px">Invoice No</td>
            <td class="student_reportresult"><asp:Label ID="lblInv" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
          <tr runat="server">
            <td class="student_reporttext">Course Name </td>
            <td class="student_reportresult"><asp:Label ID="lblCourse" runat="server"  ForeColor="Maroon"></asp:Label></td>
            <td class="student_reporttext"> Course Fees</td>
            <td class="student_reportresult"><asp:Label ID="lbl_coursefees" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
          <tr id="Tr12" runat="server" style="color: #000000">
            <td class="student_reporttext no-borders">Track</td>
            <td class="student_reportresult no-borders"><asp:Label ID="lblTrack" runat="server"  ForeColor="Maroon"></asp:Label></td>
          </tr>
        </table>
      </div>
      
      <h6 class="headingStudinfo">Fees Information</h6>
      <div class="student_reportinfo">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="student_reporttext" style="width:150px">Pending Amount</td>
            <td class="student_reportresult"><asp:Label ID="lbl_pendingamt" runat="server" ForeColor="Maroon" 

></asp:Label></td>
          </tr>
          <tr>
            <td class="student_reporttext">Pending Amount with tax</td>
            <td class="student_reportresult"><asp:Label ID="lbl_pendingwithtax" runat="server" ForeColor="Maroon" ></asp:Label></td>
          </tr>
          <tr>
            <td class="student_reporttext no-borders" colspan="3">
            <asp:LinkButton ID="lnk_inv" runat="server" OnClick="lnk_inv_Click"  ForeColor="Green">View Student Invoice</asp:LinkButton></td>
          </tr>
        </table>
      </div>
    </div>
    <div id="report2">
      <table class="common" width="100%">
        <tr>
          <td colspan="5" style="padding:0px; height: 14px;"></td>
        </tr>
        <tr>
          <td style=""><asp:Label ID="Label25" runat="server"  ForeColor="Maroon" Text="Find By : Software"></asp:Label>
            <asp:TextBox
                                ID="txt_softwareid" runat="server" CssClass="text" MaxLength="200" Width="303px"></asp:TextBox>
            &nbsp;&nbsp; </td>
        </tr>
        <tr>
          <td colspan="5" ><div style="overflow:auto; height:500px">
              <asp:GridView  ID="GridView1" Width="100%"  runat="server" AutoGenerateColumns="False" PageSize="25" CssClass="common" EmptyDataText="No Record Found">
                <Columns>
                <asp:TemplateField HeaderText="Module">
                  <ItemTemplate>
                    <asp:Label ID="Label26" runat="server" Text='<%#Eval("module_content")%>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Software">
                  <ItemTemplate> <a rel="modal" href="studentmodulebatch.aspx?studentid=<%#Eval("studentid")%>&moduleid=<%#Eval("moduleid")%>&softwareid=<%#Eval("software_id")%>&iframe=true&amp;width=500&amp;height=300" class="error"><%#Eval("software")%></a> </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Status" DataField="status" HtmlEncode="False" />
                <asp:BoundField HeaderText="Pending Class" DataField="content" HtmlEncode="False" />
                </Columns>
              </asp:GridView>
            </div></td>
        </tr>
        <tr>
          <td colspan="5" align="center" style=" text-align:center; height: 26px;" visible="false" runat="server" id="Td1"><input id="Button1" class="submit"   onclick="window.open('printstudentreport.aspx?StudentID=<%=lblSId.Text%>','PrintMe','height=500px,width=600px,scrollbars=1')" type="button"
                                value="Print" /></td>
        </tr>
      </table>
      <br />
    </div>
    <div id="assesment25">
      <asp:GridView ID="fillassesment" width="100%"  runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Record Found">
        <Columns>
        <asp:BoundField DataField="module" HeaderText="Module" />
        <asp:TemplateField HeaderText="ProjectName">
          <ItemTemplate> <a href=""  rel="htmltooltip" onclick="return false">
            <div   class="htmltooltip">
              <table border="1">
                <tr>
                  <td style="width: 100px"> Batchcode: </td>
                  <td style="width: 100px"><%#Eval("batchcode")%> </td>
                </tr>
                <tr>
                  <td style="width: 100px">Send Date </td>
                  <td style="width: 100px"><%#Eval("senddate")%> </td>
                </tr>
                <tr>
                  <td style="width: 100px">Mark </td>
                  <td style="width: 100px"><%#Eval("mark")%> </td>
                </tr>
                <tr>
                  <td style="width: 100px">Evaluated By </td>
                  <td style="width: 100px"><%#Eval("Evaluatedby")%> </td>
                </tr>
                <tr>
                  <td style="width: 100px">Evaluated Date </td>
                  <td style="width: 100px"><%#Eval("Evaluateddate")%> </td>
                </tr>
                <tr>
                  <td style="width: 100px">Remarks </td>
                  <td style="width: 100px"><%#Eval("remarks")%> </td>
                </tr>
                <tr>
                  <td style="width: 100px">Dispatch Date </td>
                  <td style="width: 100px"><%#Eval("Dispatchdate")%> </td>
                </tr>
              </table>
            </div>
            <%#Eval("projectname")%></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="projectguided_by" HeaderText="Project Guided By" />
        <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        <EmptyDataRowStyle BorderColor="#C00000" />
      </asp:GridView>
    </div>
    <div id="report3" style="width:100%">
      <TABLE class="common" width="100%">
        <TBODY>
          <TR>
            <TD 
style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px" 
colSpan=2><H4> Leave Details</H4></TD>
          </TR>
          <tr>
            <td colspan="2"><strong>Leave Request</strong></td>
          </tr>
          <TR>
            <TD colSpan=2 ><asp:GridView id="grdcentre" width="100%" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Leave Request" OnPageIndexChanging="grdcentre_PageIndexChanging" AllowPaging="True" OnRowCommand="grdcentre_RowCommand">
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
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkdecline"  CommandName="decline" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="status">
                  <ItemTemplate>
                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Eval("status_cen")%>'></asp:Label>
                    <asp:LinkButton ID="lnkapprove1" CommandName="approve1"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkdecline1"  CommandName="decline1" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast"  />
                <EmptyDataRowStyle ForeColor="Red"  />
              </asp:GridView>
              <hr />
            </TD>
          </TR>
          <tr>
            <td colspan="2"><strong>Leave History</strong></td>
          </tr>
          <tr>
            <td colspan="2" ><asp:GridView id="GridView2" width="100%" runat="server" AutoGenerateColumns="False" CssClass="common" EmptyDataText="No Leave Request" OnPageIndexChanging="grdcentre_PageIndexChanging" AllowPaging="True" OnRowCommand="grdcentre_RowCommand">
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
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkdecline"  CommandName="decline" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CentreManager">
                  <ItemTemplate>
                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Eval("status_cen")%>'></asp:Label>
                    <asp:LinkButton ID="lnkapprove1" CommandName="approve1"  CommandArgument='<%#Eval("id")%>' runat="server">Approve</asp:LinkButton>
                    &nbsp; &nbsp;
                    <asp:LinkButton ID="lnkdecline1"  CommandName="decline1" CommandArgument='<%#Eval("id")%>' runat="server">Decline</asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast"  />
                <EmptyDataRowStyle ForeColor="Red"  />
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td colspan="2"><hr />
              <asp:Label ID="Label9" runat="server"  ForeColor="Black" Text="Break Details"></asp:Label>
              <br />
              <asp:GridView width="100%" ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="common" EmptyDataText="No Records Found" OnRowCommand="GridView3_RowCommand1" >
                <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentid") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate> <%#Eval("studentid")%> </ItemTemplate>
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
        </TBODY>
      </TABLE>
    </div>
    <div id="report4" style="width:100%" >
      <center>
        <table class="common" runat="server" id="Table2" style=" height: 132px;" >
          <tr>
            <td align="center" style="font-size: 12px; color: blue; text-align: center; width: 42px;"><asp:Label ID="Label6" runat="server"  Font-Size="12pt"></asp:Label>
              <asp:Label ID="dropdate" runat="server"  ForeColor="#C00000" Visible="False"></asp:Label></td>
            <td align="center" style="font-size: 12px;  color: blue; 
                text-align: center; width: 228px;"><asp:Label ID="Label3" runat="server"  ForeColor="Red"></asp:Label></td>
          </tr>
          <tr>
            <td style="font-size: 12px; color: blue; width: 42px;"><asp:Image ID="Image1" runat="server" Height="67px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/alert.gif"
                    Width="59px" />
            </td>
            <td  align="center" style=" font-size: 12px;  color: blue; text-align:center; width: 228px;"><strong>
              <asp:Label ID="Label4" runat="server"  ForeColor="Red" Text="Are you sure ?"></asp:Label>
              <asp:Label ID="Label7" runat="server" Text="You are about to drop student from ERP System..!"></asp:Label>
              <asp:Image  ID="Image3" runat="server" Height="76px" ImageUrl="~/ImageTraining_2/Onlinestudents2/superadmin/layout/drop.png"
                    Visible="False" Width="125px" />
              </strong></td>
          </tr>
          <tr>
            <td align="left" style="height: 23px; width: 42px;"><asp:Label ID="Label5" runat="server"  ForeColor="Maroon" Text="Reason :"></asp:Label></td>
            <td align="left" style="height: 23px; width: 228px;"><asp:DropDownList ID="ddl_reason" runat="server" onChange="return chkval4()">
                <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="Higher studies">Higher studies</asp:ListItem>
                <asp:ListItem Value="Finance Problem">Finance Problem</asp:ListItem>
                <asp:ListItem Value="Others">Others</asp:ListItem>
              </asp:DropDownList>
              <asp:TextBox ID="TextBox1" style="display:none" runat="server" CssClass="text" > </asp:TextBox></td>
          </tr>
          <tr>
            <td align="left" style="width: 42px; height: 59px;"><strong style="color: maroon">Description</strong></td>
            <td align="left" style="HEIGHT: 59px; width: 228px;"><br />
              <asp:TextBox ID="txt_reason" runat="server" CssClass="text" TextMode="MultiLine" Width="289px"></asp:TextBox></td>
          </tr>
          <tr id="decline_reason" runat="server" style="display:none;">
            <td align="left" style="width: 42px"><asp:Label ID="Label8" runat="server"  ForeColor="Maroon" Text="Reason For Declining" Width="118px"></asp:Label></td>
            <td align="left" style="HEIGHT: 59px; width: 228px;"><br />
              <asp:TextBox  ID="txtdecline" runat="server" CssClass="text" MaxLength="250" TextMode="MultiLine" Width="287px"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="center" style="text-align: center; width: 42px; height: 31px;"></td>
            <td align="center"  style=" text-align:center; height: 31px; width: 228px;"><asp:Button ID="btn_req" runat="server" OnClientClick="javascript:return Validate1();"  CssClass="btnStyle1" OnClick="btn_req1"
                    Text="Request" />
              &nbsp;
              <asp:Button ID="btn_acc" runat="server" CssClass="btnStyle1" OnClick="btn_acc1"
                    Text="Accept" Visible="False" />
              &nbsp;
              <asp:Button ID="btn_dec" runat="server" CssClass="btnStyle1" OnClientClick="javascript:return decline();" OnClick="btn_dec1"
                    Text="Decline" /></td>
          </tr>
        </table>
      </center>
    </div>
  </div>
</asp:Content>
