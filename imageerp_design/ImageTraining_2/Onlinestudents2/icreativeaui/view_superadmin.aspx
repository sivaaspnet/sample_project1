<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_superadmin.aspx.cs" Inherits="Onlinestudents2_superadmin_view_superadmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View</title>
    <link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/prettyPhoto.css" />
    <link type="text/css" rel="stylesheet" media="screen" href="styles/jquery-ui-1.8.2.custom.css" />    
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="scripts/main.js"></script> 
    <script type="text/javascript" src="scripts/jquery.rotatingMenu.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="common" id="enqtable" runat="server">
    <tr>
    <td style=" padding:0px">
          <h4>Enquiry Details</h4>
    <p>
    
        <asp:GridView ID="GridView1" runat="server" CssClass="common"  EmptyDataText="No Records Found" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging">
          
            <Columns>
                <asp:TemplateField HeaderText="Enquiry No">
                    <ItemTemplate>
                    
                    
             <%#Eval("enq_number")%>
                   
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                       <%#Eval("enq_personal_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date/Time">
                <ItemTemplate>
                    <%#Eval("dateins")%>
                    </ItemTemplate>
                </asp:TemplateField>
              
                  <asp:TemplateField HeaderText="Enquiry Status">
                <ItemTemplate>
                       <%#Eval("enq_enqstatus")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></p>
        </td>
    </tr>
    <tr><td>
        <asp:Button ID="Button4" runat="server" Text="Export Excel" CssClass="submit" OnClick="Button4_Click" /></td></tr>
    </table>
    <table id="admtable" runat="server" class="common">
    <tr>
    <td style=" padding:0px">
     <h4>Student Details </h4>
    <p>
        <asp:GridView ID="Gridview_admission" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No records Found" OnPageIndexChanging="Gridview_admission_PageIndexChanging">
            <PagerSettings Position="TopAndBottom" />
            <Columns>
                <asp:TemplateField HeaderText="Student ID">
                  <ItemTemplate>
                       <%#Eval("student_id")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name ">
                    <ItemTemplate>
                        <%#Eval("enq_personal_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course">
                    <ItemTemplate>
                    <%#Eval("coursename")%>
                       
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        &nbsp;</p>
    </td>
    </tr>
     <tr><td>
        <asp:Button ID="Button5" runat="server" Text="Export Excel" CssClass="submit" OnClick="Button5_Click"/></td></tr>
    </table>
      <table id="Table1" runat="server" class="common">
    <tr>
    <td style=" padding:0px">
     <h4>Batch Details </h4>
    <p>
        <asp:GridView ID="Gridview2" runat="server" CssClass="common" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No records Found" OnPageIndexChanging="Gridview2_PageIndexChanging" OnRowCommand="Gridview2_RowCommand">
            <PagerSettings Position="TopAndBottom" />
            <Columns>
                <asp:TemplateField HeaderText="Batch code">
                  <ItemTemplate>
                       <%#Eval("batch_code")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Track">
                    <ItemTemplate>
                        <%#Eval("batch_track")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Slot">
                    <ItemTemplate>
                    <%#Eval("batch_slot")%>
                       
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Time">
                    <ItemTemplate>
                    <%#Eval("batch_time")%>
                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Faculty name">
                    <ItemTemplate>
                    <%#Eval("batch_faculty")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Batch start date">
                    <ItemTemplate>
                        <%#Eval("batch_startdate")%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Batch end date">
                    <ItemTemplate>
                        <%#Eval("batch_enddate")%>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Software name">
                    <ItemTemplate>
                        <%#Eval("batch_softwarename")%>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="No of students">
                    <ItemTemplate>
                        <asp:Label ID="hdnlblfac" Visible="false" runat="server" Text='<%#Eval("batch_facultyid")%>'></asp:Label>
                        <asp:LinkButton ID="LinkButton1" CommandName="stud" CssClass="error" CommandArgument='<%#Eval("batch_code")%>' runat="server" ><%#Eval("noofstudents")%></asp:LinkButton>                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                
            </Columns>
        </asp:GridView>
        &nbsp;</p>
    </td>
    </tr>
   <tr><td>Click on the no of students to view the students name and register no</td></tr>
   
   <tr><td>
       <asp:Button ID="Button2" runat="server" Text="Export Excel" CssClass="submit" OnClick="Button2_Click" />
       <asp:HyperLink ID="HyperLink2" CssClass="error" runat="server"></asp:HyperLink>
       </td></tr>
    </table>
    <table id="tablestudent" runat="server" class="common">
    <tr>
    <td style=" padding:0px">
     <h4>Students in Batch</h4></td></tr>
    
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="submit" OnClick="Button1_Click" />
    </td>
    </tr>
    <tr><td>Batch Code  -   <%=Request.QueryString["bthcode"] %></td></tr>
    <tr><td>
      <asp:GridView ID="GridView3" CssClass="common" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="8">
                        <Columns>
                            <asp:TemplateField HeaderText="Student ID">
                           <ItemTemplate><%#Eval("StudentId")%>
                             </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student name">
                            <ItemTemplate><%#Eval("Studentname")%> </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td></tr>
                     <tr><td>
               <asp:Button ID="Button3" runat="server" Text="Export Excel" CssClass="submit" OnClick="Button3_Click" />
      <asp:HyperLink ID="HyperLink1" CssClass="error" runat="server"></asp:HyperLink></td></tr>
      <tr><td>
          <asp:GridView ID="GridView4" runat="server"  AutoGenerateColumns="False"  Visible="False">
              <Columns>
                  <asp:TemplateField HeaderText="Batch Code">
                   <ItemTemplate><%#Eval("BatchCode")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Student ID">
                   <ItemTemplate><%#Eval("StudentId")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Student name">
                   <ItemTemplate><%#Eval("Studentname")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Software name">   
                   <ItemTemplate><%#Eval("Softwarename")%>
                             </ItemTemplate></asp:TemplateField>
                  <asp:TemplateField HeaderText="Track">    
                  <ItemTemplate><%#Eval("Track")%>
                             </ItemTemplate></asp:TemplateField>
                  <asp:TemplateField HeaderText="Slot">
                      <ItemTemplate><%#Eval("Slot")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Time">
                      <ItemTemplate><%#Eval("BatchTime")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Faculty name">
                      <ItemTemplate><%#Eval("Facultyname")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Batch start date">
                      <ItemTemplate><%#Eval("Batchstartdate")%>
                             </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Batch End date">
                      <ItemTemplate><%#Eval("Batchenddate")%>
                             </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      </td></tr>
                    </table>
    </div>
    </form>
</body>
</html>
