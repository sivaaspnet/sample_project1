<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewbatchDetails.aspx.cs" Inherits="superadmin_ViewbatchDetails" Title="View Batch Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

// Extended Tooltip Javascript
// copyright 9th August 2002, 3rd July 2005, 24th August 2008
// by Stephen Chapman, Felgall Pty Ltd

// permission is granted to use this javascript provided that the below code is not altered
function pw() {return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth}; function mouseX(evt) {return evt.clientX ? evt.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft) : evt.pageX;} function mouseY(evt) {return evt.pageY ? evt.pageY : evt.clientY + (document.documentElement.scrollTop || document.body.scrollTop)} function popUp(evt,oi) {if (document.getElementById) {var wp = pw(); dm = document.getElementById(oi); ds = dm.style; st = ds.visibility; if (dm.offsetWidth) ew = dm.offsetWidth; else if (dm.clip.width) ew = dm.clip.width; if (st == "visible" || st == "show") { ds.visibility = "hidden"; } else {tv = mouseY(evt) - 220; lv = mouseX(evt) - (ew/4); if (lv < 2) lv = 2; else if (lv + ew > wp) lv -= ew/2; lv += 'px';tv += 'px';  ds.left = lv; ds.top = tv; ds.visibility = "visible";}}}


</script>
 <%--<style type="text/css">
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
	<h4>Batch Details</h4>
	<div class="gridSort" style="margin-top:10px;">
	<table class="common" id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
	<tr>
		
            <td >
                <asp:Label ID="Label1" runat="server" Text="Faculty Name"></asp:Label><br />
                <asp:DropDownList ID="ddl_fac" runat="server" Width="97px">
                </asp:DropDownList></td>
            <td >
                Slot<br />
                <asp:DropDownList ID="ddl_slot" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="MWF">MWF</asp:ListItem>
                    <asp:ListItem Value="TTS">TTS</asp:ListItem>
                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                    <asp:ListItem Value="ZIP">ZIP</asp:ListItem>
                    <asp:ListItem Value="WEEKEND">WEEKEND</asp:ListItem>
                    <asp:ListItem Value="WEEKEND 2Hr">WEEKEND 2Hr</asp:ListItem>
                    <asp:ListItem Value="Custom">Custom</asp:ListItem>
                    
                </asp:DropDownList></td>
            <td>
                Select Month<br />
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
            <td>
                Select Year<br />
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
            <td>
                Status<br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="pending">Inprogress</asp:ListItem>
                    <asp:ListItem Value="Completed">Completed</asp:ListItem>
                    <asp:ListItem Value="Dropped">Suspend</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click" /></td>
				
        </tr>
	</table>
	</div>
	
	<div class="free-forms">
    <table class="common" id="Table2" width="100%"  language="javascript" onclick="return TABLE1_onclick()" >
        
        <tr>
            <td colspan="10">
            <asp:GridView CssClass="common"  Visible="false" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" >
                <Columns>
                    
                    
                    <asp:TemplateField HeaderText="Batch Code">
                    
                    <ItemTemplate>
                    
                    <a href="Viewbatch.aspx?batchcode=<%#Eval("BatchCode") %>"> <%#Eval("BatchCode") %>  </a>
                    
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
            
                    <asp:BoundField DataField="slot" HeaderText="Slot" HtmlEncode="False" />
                    <asp:BoundField DataField="slotday" HeaderText="SlotDay" HtmlEncode="False" />
                    <asp:BoundField DataField="batchtiming" HeaderText="Time" HtmlEncode="False" />
                    <asp:BoundField DataField="labname" HeaderText="Labname" HtmlEncode="False" />
                    <asp:BoundField DataField="facultyname" HeaderText="Faculty" HtmlEncode="False" />
                    <asp:BoundField DataField="startdate" HeaderText="Startdate" />
                    <asp:BoundField DataField="enddate" HeaderText="Enddate" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                          <a  href="schedulebatch.aspx?batchcode=<%#Eval("BatchCode") %>" class="error"> <%#Eval("status")%>  </a>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:GridView>
            </td>
        </tr>
        <tr>
          
            <td colspan="4" style="text-align:center; height: 25px;" >
			<div style="width:88%">
                <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click" Visible="False">Download excel</asp:LinkButton>
				</div>
				</td>
           
              </tr>
        <tr>
            <td colspan="10" align="center">
			
                <table  align="center" class="common" width="100%" style="background-color: rgb(239, 241, 231);">
                    <tr>
                        <td style="font-size: x-small; width: 15px;">
                            <strong>Note:</strong></td>
							
                        <td style=" height: 25px; width: 162px;">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Blue"
                                Text="'Inprocess':" Font-Size="X-Small"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Font-Size="X-Small"  Text="Batch is Ongoing"></asp:Label></td>
								
                        <td style=" height: 25px;width: 180px;">
                            <asp:Label ID="Label3" runat="server" Font-Size="X-Small" Font-Bold="True" Font-Underline="True" ForeColor="Green"
                                Text="'Completed':"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Font-Size="X-Small"  Text="Batch Is Completed"></asp:Label></td>
                                <td style="height: 25px;width: 255px;">
                            <asp:Label ID="Label6" runat="server" Font-Size="X-Small" Font-Bold="True" Font-Underline="True" ForeColor="#C00000"
                                Text="'Suspend':"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Font-Size="X-Small"  Text="Batch Suspended due to some reason"></asp:Label></td>
							</tr>
                </table>
			
            </td>
        </tr>
    </table>
		</div>
    <br />
         <asp:HiddenField ID="hiddn_id" runat="server" /><br />  
  
   </asp:Content>

