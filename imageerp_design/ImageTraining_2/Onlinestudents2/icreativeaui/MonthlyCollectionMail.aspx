<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyCollectionMail.aspx.cs" Inherits="MonthlyCollectionMail"  EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
 
</head>
<body>
    <form id="form1" runat="server">
     <div class="free-forms">
    </div>
    
    <div class="free-forms">
    <table class="common" id="collectiongrid" runat="server" visible="false" style="width: 100%">
        
        <tr>
            <td>
                <p>
                    
    </p>
          <p>
              &nbsp;&nbsp;</p>
                <p>
       <asp:GridView ID="Gridview_admission"  runat="server" AllowPaging="false" CssClass="common"  AutoGenerateColumns="False" OnPageIndexChanging="Gridview_admission_PageIndexChanging" PageSize="20" EmptyDataText="No records Found" Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <%#Eval("student_id")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                  <ItemTemplate>
                       <%#Eval("student_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt No">
                    <ItemTemplate>
                        <%#Eval("Receipt_no")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Course">
                    <ItemTemplate>
                        <%#Eval("program")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <%#Eval("Amount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tax">
                    <ItemTemplate>
                        <%#Eval("Tax")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <%#Eval("Total")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <%#Eval("Date_ins")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Receipt cut by">
                    <ItemTemplate>
                        <%#Eval("receiptcutby")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        &nbsp;</p>
                <p>&nbsp;
                    </p>
                <p>
                <p>
                <div style="display:none;">
                    </div>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
   </div>

    </form>
</body>
</html>
