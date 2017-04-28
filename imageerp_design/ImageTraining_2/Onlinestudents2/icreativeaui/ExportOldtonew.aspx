<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ExportOldtonew.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_ExportOldtonew" Title="Dump Old Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

   
function validate()
{
if(document.getElementById('ContentPlaceHolder1_txtStudentId').value=="")
{
 alert("please enter studentid");
             document.getElementById("ContentPlaceHolder1_txtStudentId").focus();
             document.getElementById("ContentPlaceHolder1_txtStudentId").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtStudentId").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_TxtInstallNo').value=="")
{
 alert("please enter no of installment");
             document.getElementById("ContentPlaceHolder1_TxtInstallNo").focus();
             document.getElementById("ContentPlaceHolder1_TxtInstallNo").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TxtInstallNo").style.backgroundColor="#e8ebd9";
             return false;
}
else
{
return true;
}
}

   function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
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
    

function validate1()
{
if(document.getElementById('ContentPlaceHolder1_txt_name').value=="")
{
 alert("please enter student name");
             document.getElementById("ContentPlaceHolder1_txt_name").focus();
             document.getElementById("ContentPlaceHolder1_txt_name").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_name").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txttax').value=="")
{
 alert("please enter tax value");
             document.getElementById("ContentPlaceHolder1_txttax").focus();
             document.getElementById("ContentPlaceHolder1_txttax").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txttax").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txtinvoice').value=="")
{
 alert("please enter invoice no");
             document.getElementById("ContentPlaceHolder1_txtinvoice").focus();
             document.getElementById("ContentPlaceHolder1_txtinvoice").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinvoice").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txtinstalltype').value=="")
{
 alert("please enter installment type");
             document.getElementById("ContentPlaceHolder1_txtinstalltype").focus();
             document.getElementById("ContentPlaceHolder1_txtinstalltype").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstalltype").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txtcentercode').value=="")
{
 alert("please enter centrecode");
             document.getElementById("ContentPlaceHolder1_txtcentercode").focus();
             document.getElementById("ContentPlaceHolder1_txtcentercode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcentercode").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_ddlcourse').value=="")
{
 alert("please select course");
             document.getElementById("ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txtcoursefees').value=="")
{
 alert("please enter course fees");
             document.getElementById("ContentPlaceHolder1_txtcoursefees").focus();
             document.getElementById("ContentPlaceHolder1_txtcoursefees").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtcoursefees").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txtinstall').value=="")
{
 alert("please enter no of installment");
             document.getElementById("ContentPlaceHolder1_txtinstall").focus();
             document.getElementById("ContentPlaceHolder1_txtinstall").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstall").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_ddltrack').value=="")
{
 alert("please select track");
             document.getElementById("ContentPlaceHolder1_ddltrack").focus();
             document.getElementById("ContentPlaceHolder1_ddltrack").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddltrack").style.backgroundColor="#e8ebd9";
             return false;
}
else
if(document.getElementById('ContentPlaceHolder1_txtenqno').value=="")
{
 alert("please enter enquiry no");
             document.getElementById("ContentPlaceHolder1_txtenqno").focus();
             document.getElementById("ContentPlaceHolder1_txtenqno").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtenqno").style.backgroundColor="#e8ebd9";
             return false;
}
else
 {
    aa();
    return false;
 }

}



function aa()
{

var grid = document.getElementById('ContentPlaceHolder1_GridView1');
 if(grid!=null) 
  {
  var Inputs = grid.getElementsByTagName("input"); 
  var s=Inputs.length;
        for(i = 0; i < Inputs.length; i++) 
         {
              if(Inputs[i].type == 'text' ) 
               {
            
                   if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox61_'+i+'').value == "") 
                     {
                             alert("Please Enter amount");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox61_'+i+'').focus();
                             return false;
                     }
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox62_'+i+'').value == "")
                     {
                             alert("Please enter Tax");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox62_'+i+'').focus();
                             return false;  
                     }
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox63_'+i+'').value == "")
                     {
                             alert("Please enter Total");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox63_'+i+'').focus();
                             return false;  
                     }
                     
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox64_'+i+'').value == "")
                     {
                             alert("Please select date");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox64_'+i+'').focus();
                             return false;  
                     }
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox65_'+i+'').value == "") 
                     {
                             alert("Please Enter amount");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox65_'+i+'').focus();
                             return false;
                     }
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox66_'+i+'').value == "")
                     {
                             alert("Please enter Tax");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox66_'+i+'').focus();
                             return false;  
                     }
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox67_'+i+'').value == "")
                     {
                             alert("Please enter Total");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox67_'+i+'').focus();
                             return false;  
                     }
                     else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox68_'+i+'').value == "")
                     {
                             alert("Please enter Receipt number");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox68_'+i+'').focus();
                             return false;  
                     }
                      else if (document.getElementById('ContentPlaceHolder1_GridView1_TextBox69_'+i+'').value == "")
                     {
                             alert("Please select date");
                             document.getElementById('ContentPlaceHolder1_GridView1_TextBox69_'+i+'').focus();
                             return false;  
                     }
                     
                     else if(s==i-1)
                     {
                        return true;
                     }
                    
              }
         }
   }
}
  
</script>
  <div class="free-forms">
    <table width="100%" class="common">
      <tr>
        <td align="left" valign="middle" style="height: 122px" class="no-borders"><table border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Small" Font-Strikeout="False"
                        ForeColor="#C00000"></asp:Label></td>
            </tr>
          <tr>
            <td width="35%"><b>Student Id</b></td>
            <td width="65%"><asp:TextBox ID="txtStudentId" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td><b>No. of Installment</b></td>
            <td align="left" valign="middle"><asp:TextBox ID="TxtInstallNo" onKeyPress="return CheckNumeric(event)" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="no-borders" style="height: 33px"></td>
            <td align="left" valign="middle" class="no-borders" style="height: 33px"><asp:Button ID="btnSubmit" runat="server" Text="Sumbit" OnClientClick="return validate()" OnClick="btnSubmit_Click" CssClass="btnStyle1" />
            </td>
          </tr>
        </table></td>
      </tr>
      <tr runat="server" visible="false" id="showtablehead">
        <td align="center" valign="middle" style=" padding:0px;"><h4 class="no-borders">Export the Old Student Details to New System</h4></td>
      </tr>
      <tr>
        <td align="center" valign="middle" class="no-borders" contenteditable="" ><asp:Label ID="lblerrormsg" runat="server" CssClass="error"></asp:Label></td>
      </tr>
      <tr>
        <td align="center" valign="middle" class="no-borders"><table width="100%" border="0" cellpadding="2" cellspacing="2" runat="server" id="showtable" visible="false">
          <tr>
            <td><b>Student Name</b></td>
            <td ><asp:TextBox ID="txt_name" runat="server"></asp:TextBox></td>
            <td><b>Course Name</b></td>
            <td><asp:DropDownList ID="ddlcourse" runat="server"> </asp:DropDownList>
            </td>
            <td><asp:Label ID="lblcourse" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td><b>Tax</b></td>
            <td><asp:TextBox ID="txttax" runat="server">12.36</asp:TextBox></td>
            <td><b>Course Fees</b></td>
            <td><asp:TextBox ID="txtcoursefees" runat="server"></asp:TextBox></td>
            <td></td>
          </tr>
          <tr>
            <td><b>Invoice No</b></td>
            <td style=""><asp:TextBox ID="txtinvoice" runat="server" onKeyPress="return CheckNumeric(event)"></asp:TextBox></td>
            <td><b>No. Installment</b></td>
            <td><asp:TextBox ID="txtinstall" onKeyPress="return CheckNumeric(event)" runat="server" ReadOnly="true"></asp:TextBox></td>
            <td></td>
          </tr>
          <tr>
            <td ><b> Installment Type</b></td>
            <td><asp:DropDownList ID="txtinstalltype"  runat="server">
                <asp:ListItem Value="">--Select--</asp:ListItem>
                <asp:ListItem Value="Lump sum">Lump sum</asp:ListItem>
                <asp:ListItem Value="Installment">Installment</asp:ListItem>
                </asp:DropDownList></td>
            <td><b> Track</b></td>
            <td><asp:DropDownList ID="ddltrack" runat="server" Enabled="false">
              <asp:ListItem Value="">select</asp:ListItem>
              <asp:ListItem Value="Fast">Fast</asp:ListItem>
              <asp:ListItem Value="Normal" Selected="True">Normal</asp:ListItem>
            </asp:DropDownList></td>
            <td></td>
          </tr>
          <tr>
            <td><b>Centre Code</b></td>
            <td ><asp:TextBox ID="txtcentercode" runat="server" ReadOnly="True"></asp:TextBox></td>
            <td><b>Enq. No.</b></td>
            <td><asp:TextBox ID="txtenqno" runat="server" ReadOnly="true"></asp:TextBox></td>
            <td ></td>
          </tr>
          <tr>
            <td><strong>Batch time</strong></td>
            <td><asp:DropDownList ID="txtbatch" runat="server" Enabled="false">
                         <asp:ListItem Value="7AMto9Am" Selected="True">7AM to 9Am</asp:ListItem>
                         <asp:ListItem Value="9AMto11Am">9AM to 11Am</asp:ListItem>
                         <asp:ListItem Value="11AMto1PM">11AM to 1PM</asp:ListItem>
                         <asp:ListItem Value="1PMto3PM">1PM to 3PM</asp:ListItem>
                         <asp:ListItem Value="3PMto5PM">3PM to 5PM</asp:ListItem>
                         <asp:ListItem Value="5PMto7PM">5PM to 7PM</asp:ListItem>
                         <asp:ListItem Value="7PMto9PM">7PM to 9PM</asp:ListItem>
                     </asp:DropDownList></td>
            <td></td>
            <td ></td>
            <td></td>
          </tr>
          <tr>
            <td><b>Temp.Address</b></td>
            <td><asp:TextBox ID="txttempaddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td><b>Perm.Address</b></td>
            <td><asp:TextBox ID="txtpermaddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td></td>
          </tr>
          <tr>
            <td><b>Mobile</b></td>
            <td><asp:TextBox ID="txtmobile" onKeyPress="return CheckNumeric(event)" runat="server"></asp:TextBox></td>
            <td><b>E mail</b></td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
            <td></td>
          </tr>
          <tr>
            <td colspan="5" style=" padding:0px;"><h4>Installment And Receipt Details</h4></td>
          </tr>
          <tr>
            <td colspan="5" class="no-borders" ><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                Width="100%">
              <columns>
                <asp:TemplateField HeaderText="Installment Number">
                  <itemtemplate>
                      <asp:Label ID="TextBox60" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                   
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Installment(Amt)">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox61" onKeyPress="return CheckNumeric(event)" runat="server" Width="50px" Text='<%# Eval("initamt") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox61"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Installment(Tax)">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox62" onKeyPress="return CheckNumeric(event)" runat="server" Width="50px" Text='<%# Eval("init_tax") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox62"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Installment(Tot)">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox63" onKeyPress="return CheckNumeric(event)" runat="server" Width="50px" Text='<%# Eval("totalinstal_tax") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox63"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Installment Date">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox64" runat="server" Width="78px"  Text='<%# Eval("install_date") %>' CssClass="datepicker"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox64"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid(Amt)">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox65" onKeyPress="return CheckNumeric(event)" runat="server" Width="50px" Text='<%# Eval("initamt") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox65"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid(tax)">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox66" onKeyPress="return CheckNumeric(event)" runat="server" Width="50px" Text='<%# Eval("init_tax") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox66"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid(tot)">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox67" onKeyPress="return CheckNumeric(event)" runat="server" Width="50px" Text='<%# Eval("tamtpaid") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox67"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt Number">
                  <itemtemplate>
                    <asp:TextBox onKeyPress="return CheckNumeric(event)" ID="TextBox68" runat="server" Width="50px" Text='<%# Eval("Receipt_no") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox68"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt date">
                  <itemtemplate>
                    <asp:TextBox ID="TextBox69" runat="server" Width="78px" Text='<%# Eval("dateins") %>' CssClass="datepicker" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox69"
                          ErrorMessage="*" ValidationGroup="gridvalid"></asp:RequiredFieldValidator>
                  </itemtemplate>
                </asp:TemplateField>
                </columns>
            </asp:GridView>
            </td>
          </tr>
          <tr style="display:none;">
            <td align="center" valign="middle"><strong>Total installment amounts</strong></td>
            <td align="center" valign="middle"><asp:TextBox ID="totalinstallamts" onKeyPress="return CheckNumeric(event)" runat="server" ReadOnly="True"></asp:TextBox></td>
            <td align="center" valign="middle"><strong>Total paid amount</strong></td>
            <td align="center" valign="middle"><asp:TextBox ID="totalpaidamount" runat="server" onKeyPress="return CheckNumeric(event)" ReadOnly="True"></asp:TextBox></td>
            <td align="center" colspan="1"  valign="middle"></td>
          </tr>
          <tr>
            <td style="text-align:center; height: 33px;" align="center" colspan="5" valign="middle" class="no-borders"><asp:Button
                ID="Button1" runat="server" Text="Check" CssClass="btnStyle1" OnClick="Button1_Click" OnClientClick="return validate1()" ValidationGroup="gridvalid" />
                  <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" OnClientClick="return validate1()" CssClass="btnStyle1" ValidationGroup="gridvalid" /></td>
          </tr>
        </table></td>
      </tr>
    </table>
  </div>
</asp:Content>
