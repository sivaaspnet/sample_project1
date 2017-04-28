<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="icat.aspx.cs" Inherits="superadmin_addcentre" Title="ICAT Centre" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
 <script language="javascript" type="text/javascript">
        
	 function Validate()
     {
    
        
       var start = document.getElementById("ContentPlaceHolder1_TextBox2").value;
        //var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;
 
        var start_s = start.split("-");
        //var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
        //var enDate = end_s[2]+end_s[1]+end_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
//        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        //var compDate = enDate - stDate;
        var csDate = stDate - toDate; 
        
        
        if(document.getElementById("ContentPlaceHolder1_TextBox2").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_TextBox2").value=="";
             document.getElementById("ContentPlaceHolder1_TextBox2").focus();
             document.getElementById("ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
             alert("Please select Install date");
             return false;
         }
         else if(csDate < 0)
         {
             document.getElementById("ContentPlaceHolder1_TextBox2").value=="";
              alert("Invalid Install date");
             document.getElementById("ContentPlaceHolder1_TextBox2").focus();
             document.getElementById("ContentPlaceHolder1_TextBox2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_TextBox2").style.backgroundColor="#e8ebd9";
             return false;
        }
        
        
             
     }
  
  
  


</script>
    <br />
    &nbsp;<br />
    &nbsp;
    <br />
    <table class="common" >
        <tr>
            <td colspan="4" >
               <h4> Invoice Installment Date update</h4></td>
        </tr>
        <tr>
            <td style="width: 114px;" >
            </td>
            <td style="width: 213px;" >
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon" Font-Size="12pt"></asp:Label></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr id="studentid" runat="server">
            <td style="width: 114px" >
                <strong>Student Id</strong></td>
            <td style="width: 213px" >
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="50" CssClass="text"></asp:TextBox></td>
            <td >
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="submit" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 114px; height: 11px;" >
            </td>
            <td style="width: 213px; height: 11px;" >
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Maroon"></asp:Label>&nbsp;
            </td>
            <td style="height: 11px" >
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td style="height: 11px">
            </td>
        </tr>
        <tr id="date" runat="server" visible="false">
            <td style="width: 114px; height: 45px" >
                <strong>Install Date</strong></td>
            <td style="width: 213px; height: 45px" >
                <asp:TextBox ID="TextBox2" runat="server" CssClass="text datepicker" onpaste="return false" onKeyPress="return false" ></asp:TextBox><br />
                </td>
            <td style="height: 45px" >
                <strong>&nbsp;Batch Timing </strong>
                </td>
            <td style="height: 45px">
                <asp:TextBox ID="txt_time" runat="server" CssClass="text" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr id="amount" runat="server" visible="false">
            <td style="width: 114px" >
                <strong>Amount To Be Paid</strong></td>
            <td style="width: 213px" >
                <asp:TextBox ID="txt_amount" runat="server" CssClass="text" MaxLength="15"></asp:TextBox></td>
            <td >
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txt_track" runat="server" CssClass="text" MaxLength="50" Visible="False"></asp:TextBox></td>
        </tr>
        <tr id="update" runat="server" visible="false">
            <td style="width: 114px" >
            </td>
            <td style="width: 213px" >
                <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return Validate();"  OnClick="Button2_Click"  Text="Update" CssClass="submit" /></td>
            <td >
            </td>
            <td>
            </td>
        </tr>
        <tr runat="server" visible="false" id="Tr1">
            <td style="width: 114px">
            </td>
            <td style="width: 213px" >
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="text-align: center">
                <asp:GridView ID="GridView1" CssClass="common"  runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="493px">
                    <Columns>
                        <asp:BoundField DataField="installNumber" HeaderText="Install NO" />
                        <asp:BoundField DataField="installdate" HeaderText="InstallDate" />
                        <asp:BoundField DataField="initialamount" HeaderText="Amount To Be Paid" />
                        <asp:BoundField DataField="initialamounttax" HeaderText="Tax" />
                        <asp:TemplateField HeaderText="Action">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="edt"><img src="layout/edit.png" alt="edit" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />

</asp:Content>

