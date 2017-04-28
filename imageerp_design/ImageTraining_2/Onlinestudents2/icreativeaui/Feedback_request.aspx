<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Feedback_request.aspx.cs" Inherits="superadmin_ViewbatchDetails" Title="Feedback Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">
 
 var TargetBaseControl = null;
        
   window.onload = function()
   {
      try
      {
         //get target base control.
         TargetBaseControl = document.getElementById('<%= this.GridView1.ClientID %>');
      }
      catch(err)
      {
         TargetBaseControl = null;
      }
   }
        
   function tt()
   { 
   
                
      if(TargetBaseControl == null) 
      
      return false;
      
      //get target child control.
      var TargetChildControl = "CheckBox1";
            
      //get all the control of the type INPUT in the base control.
      var Inputs = TargetBaseControl.getElementsByTagName("input"); 
            
      for(var n = 0; n < Inputs.length; ++n)
         if(Inputs[n].type == 'checkbox' && 
            Inputs[n].id.indexOf(TargetChildControl,0) >= 0 && 
            Inputs[n].checked)
          return true;        
            
     alert('Select atleast one batch');
      return false;
   }
 
 </script>
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
                    Feedback Request</h4>
                        <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
   
      
        <tr>
            <td >
                <a href="batchfeed.aspx&iframe=true&amp;width=750&amp;height=600" rel="modal"> View Sent Feedback</a><br /></td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
           
            <td ></td>
        </tr>
   
      
        <tr>
            <td >
                <asp:Label ID="Label1" runat="server" Text="Faculty Name"></asp:Label></td>
            <td >
                <asp:DropDownList ID="ddl_fac" runat="server" Width="97px">
                </asp:DropDownList></td>
            <td >
                Slot</td>
            <td >
                <asp:DropDownList ID="ddl_slot" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="MWF">MWF</asp:ListItem>
                    <asp:ListItem Value="TTS">TTS</asp:ListItem>
                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                </asp:DropDownList></td>
            <td >
                Select Month</td>
            <td >
                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="text">
          
                <asp:ListItem Value="01">January</asp:ListItem>
                <asp:ListItem Value="02">February</asp:ListItem>
                <asp:ListItem Value="03">March</asp:ListItem>
                <asp:ListItem Value="04">April</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">June</asp:ListItem>
                <asp:ListItem Value="07">July</asp:ListItem>
                <asp:ListItem Value="08">August</asp:ListItem>
                <asp:ListItem Value="09">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList></td>
            <td >
                Select Year</td>
            <td >
                <asp:DropDownList ID="ddlyear" runat="server" CssClass="text">
                  
                <asp:ListItem Value="2011">2011</asp:ListItem>
                <asp:ListItem Value="2012">2012</asp:ListItem>
                <asp:ListItem Value="2013">2013</asp:ListItem>
                <asp:ListItem Value="2014">2014</asp:ListItem>
                <asp:ListItem Value="2015">2015</asp:ListItem>
                <asp:ListItem Value="2016">2016</asp:ListItem>
                <asp:ListItem Value="2017">2017</asp:ListItem>
                <asp:ListItem Value="2018">2018</asp:ListItem>
                <asp:ListItem Value="2019">2019</asp:ListItem>
                </asp:DropDownList>&nbsp;
                </td>
           
            <td >
                &nbsp;<asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
		</table>
		</div>
    
            <asp:GridView CssClass="common" Visible="false" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" width="100%" >
                <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Batch Code">
                    
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("BatchCode") %>'></asp:Label>
        
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                
                    
                    
                  
            
                    <asp:BoundField DataField="slot" HeaderText="Slot" HtmlEncode="False" />
                    <asp:BoundField DataField="batchtiming" HeaderText="Time" HtmlEncode="False" />
                   
                    <asp:BoundField DataField="facultyname" HeaderText="Faculty" HtmlEncode="False" />
                    <asp:BoundField DataField="startdate" HeaderText="Startdate" />
                    <asp:BoundField DataField="enddate" HeaderText="Enddate" />
                  
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
			<div>
        <table width="100%">
        <tr>
            <td colspan="1" style="width: 80px; text-align: center">
            </td>
            <td colspan="1" style="width: 11px; text-align: center">
            </td>
            <td colspan="1" style="width: 30px; text-align: center">
            </td>
            <td colspan="4"  align="center" >
                <asp:Button ID="Button1" runat="server" Text="Send Feedback" CssClass="btnStyle1" OnClientClick="return tt();" OnClick="Button1_Click" />
               </td>
            <td colspan="1" style="text-align: center">
            </td>
            <td colspan="1" style="text-align: center">
            </td>
              </tr>
    </table>
    </div>
         <asp:HiddenField ID="hiddn_id" runat="server" /><br />  
  
   </asp:Content>

