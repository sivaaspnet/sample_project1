<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="schedulebatch.aspx.cs" Inherits="Onlinestudents2_superadmin_schedulebatch" Title="Batch Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript">



 function viewatnval()
   { 
      // alert("test")

        if(document.getElementById("ContentPlaceHolder1_ddlbatchcode").value=="")
         {    
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML = '*Please select batch code!';
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").style.backgroundColor="#e8ebd9";
             
             return false;
         }
         
         
//        else if(document.getElementById("ContentPlaceHolder1_ddlsoftwre").value=="")
//         {    
//        
//             document.getElementById("ContentPlaceHolder1_ddlsoftwre").value=="";
//             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML = '*Please select software name!';
//             document.getElementById("ContentPlaceHolder1_ddlsoftwre").focus();
//             document.getElementById("ContentPlaceHolder1_ddlsoftwre").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddlsoftwre").style.backgroundColor="#e8ebd9";
//             //alert("Please select track");
//             return false;
//         }
         
//         else if(document.getElementById("ContentPlaceHolder1_ddlyear").value=="")
//         {    
//             document.getElementById("ContentPlaceHolder1_ddlyear").value=="";
//             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML = '*Please select year!';
//             document.getElementById("ContentPlaceHolder1_ddlyear").focus();
//             document.getElementById("ContentPlaceHolder1_ddlyear").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddlyear").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
//       
//         else if(document.getElementById("ContentPlaceHolder1_ddlmonth").value=="")
//         {    
//             document.getElementById("ContentPlaceHolder1_ddlmonth").value=="Select";
//             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML = '*Please select month!';
//             document.getElementById("ContentPlaceHolder1_ddlmonth").focus();
//             document.getElementById("ContentPlaceHolder1_ddlmonth").style.border="#ff0000 1px solid";
//             document.getElementById("ContentPlaceHolder1_ddlmonth").style.backgroundColor="#e8ebd9";
//             return false;
//         } 
    
        
         else 
         {
          return true;
         }

}




function Reset()
{
//alert("True");
document.getElementById("ContentPlaceHolder1_ddlbatchcode").value="";
document.getElementById("ContentPlaceHolder1_ddlsoftwre").value="";



 


  var liste = document.getElementById("ContentPlaceHolder1_ddlyear");
                var howMany = liste.options.length;

                for(var i = 0; i < howMany; i++)
                {
                    if(liste[i].selected)
                    {
                    liste[i].selected=false;
                    }
                }    

  var liste = document.getElementById("ContentPlaceHolder1_ddlmonth");
                var howMany = liste.options.length;

                for(var i = 0; i < howMany; i++)
                {
                    if(liste[i].selected)
                    {
                    liste[i].selected=false;
                    }
                }   



}


function onchangeddl()
{

 document.getElementById('ContentPlaceHolder1_tblbatch').style.display="none";
 document.getElementById('ContentPlaceHolder1_attendance').style.display="none";
}



</script>

 <table class="common" id="tblstudent" visible="false" runat="server" width="100%" >
                    <tr>
                        <td colspan="8" style="padding:0px; height: 29px;" >
                            <h4>
                    Batch details</h4>
                        </td>
                    </tr>
     <tr>
        
         <td colspan="4">
                <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
        
     </tr>
             <tr>
            <td >
                Faculty Name<br />
                <asp:DropDownList ID="ddl_fac" runat="server">
                </asp:DropDownList><br />
                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                 <td>
                     Slot<br />
                     <asp:DropDownList ID="ddl_slot" runat="server">
                         <asp:ListItem Value="">All</asp:ListItem>
                         <asp:ListItem Value="MWF">MWF</asp:ListItem>
                         <asp:ListItem Value="TTS">TTS</asp:ListItem>
                         <asp:ListItem Value="Daily">Daily</asp:ListItem>
                     </asp:DropDownList></td>
            <td>
                Select Month<br />
                <asp:DropDownList ID="ddlmonth1" runat="server" CssClass="text">
                <asp:ListItem Value="">All</asp:ListItem>
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
                <asp:DropDownList ID="ddlyear1" runat="server" CssClass="text" >
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
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnStyle1" Text="Submit" OnClick="btnsubmit_Click"  /></td>
        </tr>
        </table>
		
    <table class="common" id="t1" width="100%" runat="server" visible="false">
        <tr>
            <td colspan="7" style="padding:0px;">
                <h4>
                 Batch Schedule</h4>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: center; height: 25px;">
                </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="height: 24px; width: 59px;" colspan="2">
                BatchCode</td>
            <td style="height: 24px; width: 178px;" colspan="3">
                <asp:DropDownList ID="ddlbatchcode" runat="server" OnChange="javascript:return onchangeddl(this)" Width="265px">
                </asp:DropDownList>
                &nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click"
                    OnClientClick="javascript:return viewatnval();" /></td>
                <td style="height: 24px; width: 76px;" class="w290 talignleft" colspan="1">
                 </td>
            <td colspan="1" style="height: 24px">
                <asp:DropDownList ID="ddlsoftwre" runat="server" Visible="false">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="w290 talignleft" colspan="2" style="width: 59px"  >
                </td>
            <td colspan="3" style="width: 178px" >
                <asp:DropDownList ID="ddlyear" runat="server" Visible="false">
                    <asp:ListItem Value="2011">2011</asp:ListItem>
                    <asp:ListItem Value="2012">2012</asp:ListItem>
                    <asp:ListItem Value="2013">2013</asp:ListItem>
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                </asp:DropDownList></td>
            <td class="w290 talignleft" colspan="1" style="width: 76px" >
                </td>
            <td colspan="1">
                <asp:DropDownList ID="ddlmonth" runat="server"  Visible="false">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>&nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" colspan="7">
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
      <tr>
                                        <td colspan="6" rowspan="1" style="width:10px; text-align:left; height: 22px;">
                                            <asp:Button ID="Button2" runat="server" CssClass="back" OnClick="Button2_Click"
                                                Text="Back" /></td>
                                    </tr>
    </table>
    
    <div id='parent' runat="server">
  
                     <div class="free-forms">          
                      <table id="tblbatch" class="common" visible="false" runat="server" border="0" cellpadding="0" cellspacing="0" >
                                  
                    <tr>
                    
                       <td colspan="1"  >
                            Batch Track :</td>
                        <td colspan="3" >
                            <asp:Label ID="txt_BatchTrack" runat="server"  MaxLength="30"
                                ReadOnly="True" TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                        <td colspan="1" >
                            Module Name :</td>
                        <td colspan="1" >
                            <asp:Label ID="txt_Module" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="1" >
                            Faculty Name :</td>
                        <td colspan="3" >
                            <asp:Label ID="txt_Faculty" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                        <td colspan="1" >
                            Lab Name :</td>
                        <td colspan="1" >
                            <asp:Label ID="txt_Lab" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="1" rowspan="1" >
                            Batch Time :&nbsp; &nbsp;</td>
                        <td colspan="3" rowspan="1" >
                            <asp:Label ID="txt_BatchTime" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                        <td colspan="1" rowspan="1" >
                            Batch Slot :</td>
                        <td colspan="1" rowspan="1">
                            <asp:Label ID="txt_BatchSlot" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="1" rowspan="1" >
                            Batch Start Date :</td>
                        <td colspan="3" rowspan="1" >
                            <asp:Label ID="txt_Bstart" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                        <td colspan="1" rowspan="1" >
                            Batch End Date :</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_Bend" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="1" rowspan="1" >
                            Software Name :</td>
                        <td colspan="3" rowspan="1" >
                            <asp:Label ID="txt_software" runat="server"  MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Width="221px" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                                 <td colspan="1" rowspan="1" >
                           </td>
                             <td colspan="1" rowspan="1" >
                            </td>
                    </tr>
                                    <tr >
                                        <td colspan="1" rowspan="1">
                                            Completed class :</td>
                                        <td colspan="1" rowspan="1">
                                            <asp:Label ID="lbl_completed" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>/<asp:Label
                                                ID="lbl_totalclass" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                                        <td colspan="1" rowspan="1">
                                            <asp:Label ID="lbl_reason" runat="server" Font-Bold="False" ForeColor="Black" Visible="False"></asp:Label></td>
                                        <td colspan="1" rowspan="1">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label></td>
                                    </tr>
                                    
                                </table></div>
	<div class="free-forms">
    <table runat="server"  width="100%" class="common" id="attendance" visible="false">
    <tr class="no-borders"><td style="padding:0px;">
                <h4>
                  Class Details</h4></td></tr>
    <tr>
    <td style="text-align:center;">
<div style="max-height:500px;overflow:auto">
        <asp:GridView ID="gvclassdetails"  CssClass="common" runat="server" 
            PageSize="15"  AutoGenerateColumns="False" 
            OnPageIndexChanging="gvclassdetails_PageIndexChanging" 
            EmptyDataText="No Record Found" OnRowDataBound="gvclassdetails_RowDataBound" 
            width="100%" >
        <Columns>
        <asp:BoundField HeaderText="Software" DataField="software" />
        <asp:BoundField HeaderText="Class Content" DataField="content" />
        <asp:BoundField HeaderText="Schedule date" DataField="scheduledate" />
        <asp:BoundField HeaderText="Held date" DataField="classheld" />
         <asp:BoundField HeaderText="Reason" DataField="Reason" />
        </Columns>
     
            <EmptyDataRowStyle   BorderWidth="1px" Font-Bold="True" />
        </asp:GridView>
              
</div>
          </td></tr>
    <tr>
    <td style="text-align:center;">

        
              

          </td></tr></table>
               </div>
       
   </div>
   <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click"><span class="file"><span class="file"><span class="file"><span class="file">Download</span></span></span></span></asp:LinkButton>
</asp:Content>

