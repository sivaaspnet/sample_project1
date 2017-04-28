<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="classreport.aspx.cs" Inherits="superadmin_ViewbatchDetails" Title="Class Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%-- <style type="text/css">
        div.htmltooltip{
       background: none repeat scroll 0 0 ivory;
    border: 1px solid black;
    color: black;
    left: -1000px;
    padding: 3px;
    position: absolute;
    top: -1000px;
    z-index: 1000;
        }
        </style>--%>
 <script language="javascript" type="text/javascript">

    function getrack()
      {
      //document.getElementById("ContentPlaceHolder1_ddl_Track").selected ="Normal"
      //alert(document.getElementById("ContentPlaceHolder1_ddl_Track").selected);
          if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Fast")
          {
            document.getElementById("ContentPlaceHolder1_ddl_Track").value="Fast";
            document.getElementById("ContentPlaceHolder1_ddl_Track").selected ="Fast"
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='';
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='none';
          }
          else if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Normal")
          {
            document.getElementById("ContentPlaceHolder1_ddl_Track").value="Normal";
            document.getElementById("ContentPlaceHolder1_ddl_Track").selected ="Normal"
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='';
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='none';
          }
          else if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Zip")
          {
            document.getElementById("ContentPlaceHolder1_ddl_Track").value="Zip";
            document.getElementById("ContentPlaceHolder1_ddl_Track").selected ="Normal"
            document.getElementById("ContentPlaceHolder1_ddl_slotzip").style.display='';
            document.getElementById("ContentPlaceHolder1_ddl_slotfast").style.display='none';
            document.getElementById("ContentPlaceHolder1_ddl_slotnormal").style.display='none';
          }
      }

 function TestCheckBox()
   { 
        //Start and end date check
//        var start = document.getElementById("ContentPlaceHolder1_txt_stratdate").value;
//        var end = document.getElementById("ContentPlaceHolder1_txt_enddate").value;

//        var start_s = start.split("-");
//        var end_s = end.split("-");

//        var stDate = start_s[2]+start_s[1]+start_s[0];
//        var enDate = end_s[2]+end_s[1]+end_s[0];

//        var d = new Date();
//        var curr_date = d.getDate();
//        var curr_month = d.getMonth();
//        curr_month++;
//        var curr_year = d.getFullYear();
//        var mon =  (curr_month < 10 ? '0' : '') + curr_month
//        if(curr_date<10)
//        {
//        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
//        }
//        else
//        {
//        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
//        }
//        
//        var compDate = enDate - stDate;
//        var csDate = stDate - toDate;     
   
//        alert(stDate);
//        alert(enDate);
//        alert(toDate);
//        alert(compDate);
//        alert(csDate);
//        return false;

        if(document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select")
         {    
        
             document.getElementById("ContentPlaceHolder1_ddl_Track").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select track!';
             document.getElementById("ContentPlaceHolder1_ddl_Track").focus();
             document.getElementById("ContentPlaceHolder1_ddl_Track").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_Track").style.backgroundColor="#e8ebd9";
             //alert("Please select track");
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_DropDownList1").value=="Select")
         {    
        
             document.getElementById("ContentPlaceHolder1_DropDownList1").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select batch timing!';
             document.getElementById("ContentPlaceHolder1_DropDownList1").focus();
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_DropDownList1").style.backgroundColor="#e8ebd9";
             //alert("Please select track");
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_ddl_labname").value=="")
         {    
        
             document.getElementById("ContentPlaceHolder1_ddl_labname").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select lab!';
             document.getElementById("ContentPlaceHolder1_ddl_labname").focus();
             document.getElementById("ContentPlaceHolder1_ddl_labname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_labname").style.backgroundColor="#e8ebd9";
             //alert("Please select track");
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="")
         {    
        
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").value=="Select";
             document.getElementById("ContentPlaceHolder1_Label1").innerHTML = '*Please select faculty!';
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").focus();
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_facultyname").style.backgroundColor="#e8ebd9";
             //alert("Please select track");
             return false;
         }
         
//          if(document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="") 
//         {    
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label3").innerHTML = '*Please select start date!';
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//          else if(csDate < 0)
//         {
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label3").innerHTML = '*Invalid start date!';
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
//             return false;
//        }
//        
//         else if(document.getElementById("ContentPlaceHolder1_txt_enddate").value=="") 
//         {    
//             document.getElementById("ContentPlaceHolder1_txt_enddate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label3").innerHTML = '*Please select end date!';
//             document.getElementById("ContentPlaceHolder1_txt_enddate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
//             return false;
//         }
//        else if(csDate < 0)
//         {
//             document.getElementById("ContentPlaceHolder1_txt_enddate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label3").innerHTML = '*Invalid end date!';
//             document.getElementById("ContentPlaceHolder1_txt_enddate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
//             return false;
//        }
//        else if(compDate < 0)
//        {
//             document.getElementById("ContentPlaceHolder1_txt_enddate").value=="";
//             document.getElementById("ContentPlaceHolder1_Label3").innerHTML = '*Invalid end date!';
//             document.getElementById("ContentPlaceHolder1_txt_enddate").focus();
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_txt_enddate").style.backgroundColor="#e8ebd9";
//             return false;
//        }
         else 
         {
          return true;
         }
   }
   
function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_txtsearchname").value=="")
         {
         
            
             document.getElementById("ContentPlaceHolder1_txtsearchname").focus();
             document.getElementById("ContentPlaceHolder1_txtsearchname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtsearchname").style.backgroundColor="#e8ebd9";
             return false;
         } 
      
        else
        {
        return true;
        }

}






function TABLE1_onclick() {

}

 </script>
                <h4>
                    Class Report</h4>
     <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
            <td >
                <asp:Label ID="Label1" runat="server" Text="Faculty Name"></asp:Label></td>
            <td >
                <asp:DropDownList ID="ddl_fac" runat="server" Width="97px">
                </asp:DropDownList></td>
                 <td >
                <asp:Label ID="Label2" runat="server" Text="Module"></asp:Label></td>
            <td >
                <asp:DropDownList ID="ddl_module" runat="server" Width="97px">
                </asp:DropDownList></td>

            <td >
                Slot</td>
            <td>
                <asp:DropDownList ID="ddl_slot" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="MWF">MWF</asp:ListItem>
                    <asp:ListItem Value="TTS">TTS</asp:ListItem>
                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList>
           </td>
           <td>
            
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
		  </table>
    </div>
	<div style="padding:0px 10px;">
    <table cellpadding="0" cellspacing="0" width="100%" >
        <tr>
            <td >
			<div class="dataGrid">
            <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" EmptyDataText="No Records Found" width="100%" >
                <Columns>
                    
                    
                    <asp:TemplateField HeaderText="Batch Code">
                    
                    <ItemTemplate>
                    
                    <a href="Viewattendance.aspx?batchcode=<%#Eval("BatchCode") %>"> <%#Eval("BatchCode") %>  </a>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Module">
                    <ItemTemplate>
                 <%--    <a href="" rel="htmltooltip" onclick="return false">
                             <div id="t1"  class="htmltooltip">
                          <%#Eval("Software")%></div> 
                          
                          <%#Eval("module_content")%></a>--%>
                          <%#Eval("module_content")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="slot" HeaderText="Slot" HtmlEncode="False" />
                    <asp:BoundField DataField="batchtiming" HeaderText="Time" HtmlEncode="False" />
                    <asp:BoundField DataField="labname" HeaderText="Labname" HtmlEncode="False" />
                    <asp:BoundField DataField="facultyname" HeaderText="Faculty" HtmlEncode="False" />
                    <asp:BoundField DataField="startdate" HeaderText="Startdate" />
                    <asp:BoundField DataField="enddate" HeaderText="Enddate" />
                     <asp:BoundField DataField="Pending" HeaderText="No of Days not posted" />
                </Columns>
        <EmptyDataRowStyle  Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
			  </div>
			         <%--  <p style="padding:10px 0px;">               
					   <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click" Visible="False">Download excel</asp:LinkButton></p>--%>
					   
            </td>
        </tr>
		  </table>
     </div>   
       
 
    <br />
         <asp:HiddenField ID="hiddn_id" runat="server" />
  
   </asp:Content>

