<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="BookReq.aspx.cs" Inherits="Onlinestudents2_superadmin_BookReq" Title="Book Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript">
   
   function getCheckBoxListItemsChecked(elementId)
{
 var elementRef = document.getElementById(elementId);
 var checkBoxArray = elementRef.getElementsByTagName('input');
 var checkedValues = '';
 for (var i=0; i<checkBoxArray.length; i++)
 {
  var checkBoxRef = checkBoxArray[i];

  if ( checkBoxRef.checked == true )
  {
   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   // AFAIK, you cannot get the value property of a ListItem in a CheckBoxList.
   // You can only get the Text property, which will be in an HTML label element.
   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

   var labelArray = checkBoxRef.parentNode.getElementsByTagName('label');

   if ( labelArray.length > 0 )
   {
    if ( checkedValues.length > 0 )
     checkedValues += ', ';

    checkedValues += labelArray[0].innerHTML;
   }
  }
 }
 
 return checkedValues;
}
function readCheckBoxList()
{
 var checkedItems = getCheckBoxListItemsChecked('<%= CheckBoxList1.ClientID %>');
 //var checkBoxArray= getCheckBoxListItemsChecked('<%= CheckBoxList1.ClientID %>');
 //alert('Items checked: ' + checkedItems);
 var mytool_array=checkedItems.split(",");
 //alert('Items checked: ' + mytool_array.length);
 if(mytool_array.length>2)
 {
 alert("Please Select Only Two Books");
 return false;
 }
 if(checkedItems<1)
 {
 alert("Please Select Book");
 return false;
 }
}
 
    function chlvalidate(elementId)
    {
    var elementRef = document.getElementById(elementId);
    var checkBoxArray = elementRef.getElementsByTagName('input');
    alert(checkBoxArray.length);
    }
    
    </script>

    <table class="common" >
        <tr>
            <td colspan="2" style="text-align: center" valign="middle">
                <asp:Label ID="lblmsg" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 96px" >
                Student ID</td>
            <td >
                <asp:TextBox ID="txtstudentid" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 96px" >
                Student Name</td>
            <td >
                <asp:TextBox ID="txtstudentname" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 96px" >
                Course Name</td>
            <td >
                <asp:TextBox ID="txtCourse" runat="server" CssClass="text" Width="473px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr id="bookvis" runat="server" visible="false">
            <td style="width: 96px" >
                Books</td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td  style="text-align:center;"  colspan="2" valign="middle">
                <asp:Button ID="Btnadd" runat="server" CssClass="submit" OnClick="Btnadd_Click" OnClientClick="javascript:return readCheckBoxList();"
                    Text="Add" />&nbsp; &nbsp;<input id="Reset1" type="reset" value="Reset" class="submit" />
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2"  valign="middle">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="StudentId" HeaderText="Student ID" />
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                        <asp:BoundField DataField="SoftwareName" HeaderText="Software Name" />
                        <asp:BoundField Visible="False" DataField="Bookstatus" HeaderText="Book Status" />
                        <asp:TemplateField HeaderText="Book Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" Visible="false" runat="server">
                                    <asp:ListItem Value="Sent">Sent</asp:ListItem>
                                    <asp:ListItem Value="Received">Received</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblCourse" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblId" runat="server" Visible="False" Text='<%#Eval("Courseware_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProcessDate" HeaderText="Process Date/Time " />
                        <asp:BoundField DataField="SentDate" HeaderText="Sent Date/Time" />
                        <asp:BoundField DataField="ReceivedDate" HeaderText="Received Date/Time" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 30px; text-align:center;" valign="middle">               
                <asp:Button ID="Button2" Visible="false" runat="server" CssClass="submit" 
                    Text="Update Status" OnClick="Button2_Click" /></td>
        </tr>
    </table>
</asp:Content>

