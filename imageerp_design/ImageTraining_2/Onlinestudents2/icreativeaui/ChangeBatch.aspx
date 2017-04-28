<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="ChangeBatch.aspx.cs" Inherits="OnlineStudents_superadmin_ChangeBatch" Title="Change Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

var TargetBaseControl = null;
        
   window.onload = function()
   {
      try
      {
         //get target base control.
         TargetBaseControl = 
           document.getElementById('<%= this.Gridvw.ClientID %>');
      }
      catch(err)
      {
         TargetBaseControl = null;
      }
   }
        
   function TestCheckBox()
   {              
      if(TargetBaseControl == null) return false;
      
      //get target child control.
      var TargetChildControl = "CheckBox1";
            
      //get all the control of the type INPUT in the base control.
      var Inputs = TargetBaseControl.getElementsByTagName("input"); 
            
      for(var n = 0; n < Inputs.length; ++n)
      {
         if(Inputs[n].type == 'checkbox' && 
            Inputs[n].id.indexOf(TargetChildControl,0) >= 0 && 
            Inputs[n].checked)
            {
          var ii=1;
            }
      }
            if(ii==1)
            {
            document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML="";
           var res= confirm("Are you sure! You want to move?");
          if(res)
          {
          return true;
          }
          else
          {
           return false;
          }
            }
            else
            {
            document.getElementById("ContentPlaceHolder1_Gridvw_CheckBox1_0").focus();
            document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select studentid from the list!';
            return false;
            }
   }
    function changebatch()
    {
    if(document.getElementById("ContentPlaceHolder1_ddl_batchcode1").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").value=="";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").focus();
             document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode!';
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode1").style.backgroundColor="#e8ebd9";
             return false;
         }
      else if(document.getElementById("ContentPlaceHolder1_ddl_batchcode2").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").value=="";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").focus();
             document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML = '*Please select batchcode to view batch details!';
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_batchcode2").style.backgroundColor="#e8ebd9";
             return false;
         }
         
         else
         {
         TestCheckBox();
         if(document.getElementById("ContentPlaceHolder1_lblerrormsg").innerHTML == '*Please select studentid from the list!')
         {
         return false;
         }
         else
         {
         return true;
         }
         }
    }
</script>


<table class="common" style="width: 644px">
<tr><td style="padding:0px;"> <h4>Change Batch</h4></td></tr>
<tr><td style="text-align:center">
    <asp:Label ID="lblerrormsg" CssClass="error" runat="server" Text=''></asp:Label></td></tr> 
    <tr>
        <td style="text-align: center">
        
<table class="common" cellpadding="0" cellspacing="0">
<tr><td valign="Top" style="vertical-align:top;">
    <table class="common">
        <tr>
            <td colspan="2" style=" padding:0px;">
                <h2  style="margin:0px;">Select student from this batch</h2></td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td style="width: 89px" >
                Select batchcode</td>
            <td>
                <asp:DropDownList ID="ddl_batchcode1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode1_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 89px; height: 21px">
                Module</td>
            <td style="height: 21px">
                <asp:Label ID="lbl_Fmodule" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 89px">
                Track</td>
            <td>
                <asp:Label ID="lbl_ftrack" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 89px" >
                Select student</td>
            <td>
                <asp:GridView ID="Gridvw" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="common" EmptyDataText="No Student Records Found">
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
<%--                            <HeaderTemplate>
                                <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select" />
                            </HeaderTemplate>--%>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Id">
                            <ItemTemplate>
                                <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_StudentId").ToString())%>
                                <asp:Label ID="lbl_stdid" runat="server" Text='<%#Eval("Batch_StudentId")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Name").ToString())%>
                                <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Batch_Module_Content")%>'
                                    Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_Track" runat="server" Text='<%#Eval("Batch_Track")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Module">
                            <ItemTemplate>
                                <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Module_Content").ToString())%>
                                <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Batch_Module_Content")%>'
                                    Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Track">
                            <ItemTemplate>
                                <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Track").ToString())%>
                                <asp:Label ID="lbl_Track" runat="server" Text='<%#Eval("Batch_Track")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" style=" text-align:center;">
                <asp:Button ID="btn_Movestudent" runat="server" CssClass="submit" OnClientClick="javascript:return changebatch();" Text="Move>>" OnClick="btn_Movestudent_Click1"/>
                <asp:HiddenField ID="hdnModule" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
        </tr></table>
</td>
<td valign="top" style=" vertical-align:top;">
     <table class="common">
         <tr>
             <td colspan="2" style=" padding:0px;">
                 <h2  style="margin:0px;">Move student to this batch</h2></td>
         </tr>
         <tr>
             <td colspan="2">
             </td>
         </tr>
        <tr>
            <td style="width: 89px" >
                Select batchcode</td>
            <td>
                <asp:DropDownList ID="ddl_batchcode2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_batchcode2_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 89px">
                Track</td>
            <td>
                <asp:Label ID="lbltrack" runat="server" Text=''></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 89px">
                Time</td>
            <td>
                <asp:Label ID="lbltime" runat="server" Text=''></asp:Label></td>
        </tr>
         <tr>
             <td style="width: 89px">
                 Module</td>
             <td>
                 <asp:Label ID="lblsoftware" runat="server" Text=''></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 89px">
                 Slot</td>
             <td>
                 <asp:Label ID="lbl_slot" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 89px">
                 Lab</td>
             <td>
                 <asp:Label ID="lbl_lab" runat="server" Text=""></asp:Label></td>
         </tr>
         <tr>
             <td style="width: 89px">
                 Faculty</td>
             <td>
                 <asp:Label ID="lbl_Faculty" runat="server" Text=""></asp:Label></td>
         </tr>
        <tr><td style="width: 89px">
            Studentid</td><td><asp:GridView ID="grdB2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="common" EmptyDataText="No Student Records Found">
                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
                <Columns>
                    <asp:TemplateField HeaderText="Student Id">
                        <ItemTemplate>
                            <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_StudentId").ToString())%>
                            <asp:Label ID="lbl_stdid" runat="server" Text='<%#Eval("Batch_StudentId")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Name").ToString())%>
                            <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Batch_Module_Content")%>'
                                Visible="false"></asp:Label>
                                <asp:Label ID="lbl_Track" runat="server" Text='<%#Eval("Batch_Track")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <%--<asp:TemplateField HeaderText="Module">
                        <ItemTemplate>
                            <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Module_Content").ToString())%>
                            <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Batch_Module_Content")%>'
                                Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Track">
                        <ItemTemplate>
                            <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Track").ToString())%>
                            <asp:Label ID="lbl_Track" runat="server" Text='<%#Eval("Batch_Track")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            </td></tr></table>
</td></tr>
</table>
</td>
    </tr>
</table>
</asp:Content>

