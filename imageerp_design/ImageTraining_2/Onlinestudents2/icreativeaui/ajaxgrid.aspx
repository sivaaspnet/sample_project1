<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ajaxgrid.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_ajaxgrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
 <style type="text/css">
        .overlay
        {
          position: fixed;
          z-index: 98;
          top: 0px;
          left: 0px;
          right: 0px;
          bottom: 0px;
            background-color: #aaa;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .overlayContent
        {
          z-index: 99;
          margin: 250px auto;
          width: 80px;
          height:80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        .overlayContent img
        {
          width: 180px;
          height: 180px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        
        </asp:ScriptManager>
          <script type="text/javascript">
   Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(InitializeRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        var postBackElement;
        function InitializeRequest(sender, args) {
            $get(args._postBackElement.id).disabled = true;
            postBackElement = args.get_postBackElement();
        }
        function EndRequest(sender, args) {
            if (postBackElement.id == 'LinkButton1') {
                $get('UpdateProgress1').style.display = 'none';
            }
            $get(postBackElement.id).disabled = false;
        }
   </script>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
                    <ProgressTemplate>
      <div class="overlay" />
            <div class="overlayContent">

<img src="http://www.google-page-rank-check.com/img/loading.gif" />
</DIV>
         </div>           
                    
                        
                    </ProgressTemplate>
                </asp:UpdateProgress>
                &nbsp;
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="test">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="1" />
                    </Columns>
                </asp:GridView>
    <asp:GridView id="GridView1" runat="server"  CssClass="common" AutoGenerateColumns="False">
                <Columns>
                    
                    
                    <asp:TemplateField HeaderText="Batch Code">
                    
                    <ItemTemplate>
                    
                    <a href='Viewbatch.aspx?batchcode=<%#Eval("BatchCode") %>'> <%#Eval("BatchCode") %>  </a>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Module">
                    
                    <ItemTemplate>
                    
                           <%--  <a href="" rel="htmltooltip" onclick="return false">
                             <div id="t1"  class="htmltooltip">
                          <%#Eval("Software")%></div> 
                          
                          <%#Eval("module_content")%></a>--%>
                          <%#Eval("module_content")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="slot" HeaderText="Slot" HtmlEncode="False" ></asp:BoundField>
                    <asp:BoundField DataField="batchtiming" HeaderText="Time" HtmlEncode="False" ></asp:BoundField>
                    <asp:BoundField DataField="labname" HeaderText="Labname" HtmlEncode="False" ></asp:BoundField>
                    <asp:BoundField DataField="facultyname" HeaderText="Faculty" HtmlEncode="False" ></asp:BoundField>
                    <asp:BoundField DataField="startdate" HeaderText="Startdate" ></asp:BoundField>
                    <asp:BoundField DataField="enddate" HeaderText="Enddate" ></asp:BoundField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                          <a  href='schedulebatch.aspx?batchcode=<%#Eval("BatchCode") %>' class="error"> <%#Eval("status")%>  </a>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red"  />
            </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    </form>
</body>
</html>
