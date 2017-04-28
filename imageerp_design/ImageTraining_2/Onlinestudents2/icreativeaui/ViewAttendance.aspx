<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="ViewAttendance.aspx.cs" Inherits="Onlinestudents2_superadmin_ViewAttendance" Title="View Attendance Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
        div.htmltooltip{
        background: none repeat scroll 0 0 #59B1E8;
    border: 1px solid #2781BA;
    color: black;
    left: -500px;
    padding: 3px;
    position: absolute;
    top: -1000px;
    z-index: 1000;
        }
        </style>

<script type="text/javascript">

function viewatnval1()
   { 



       
         
 }

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






</script>
 
 
 
		   <div class="free-forms">
    <table  class="common"  width="100%"  >
        <tr>
            <td colspan="8" >
            <h4 >
                 Batch Attendance<asp:Button ID="Button2" style="text-align:right;" runat="server" CssClass="back" Text="Back" OnClick="Button2_Click" /></h4>
            </td>
        </tr>
    
        <tr>
            <td colspan="1" style="height: 20px; text-align: center">
            </td>
            <td colspan="7" style="text-align: center; height: 20px;">
                <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
        <tr id="row1" runat="server" >
            <td class="w290 talignleft" style="height: 24px; width: 70px;" colspan="2">
                BatchCode</td>
            <td class="w290 talignleft" colspan="6" style="height: 24px">
                <asp:Label ID="ddlbatchcode" runat="server" Font-Bold="True" ForeColor="#0000C0"></asp:Label></td>
        </tr>
        <tr runat="server" id="row2" >
            <td class="w290 talignleft" colspan="2" style="width: 70px"  >
                Year</td>
            <td colspan="3"  >
                <asp:DropDownList ID="ddlyear" runat="server">
                    <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="2010">2010</asp:ListItem>
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
            <td class="w290 talignleft" colspan="1"  >
                Month</td>
            <td colspan="1" >
                <asp:DropDownList ID="ddlmonth" runat="server">
                    <asp:ListItem Value="">All</asp:ListItem>
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
                </asp:DropDownList></td>
            <td colspan="1" style="width: 151px; height: 26px">
                <asp:Button ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click"
                    OnClientClick="javascript:return viewatnval();" /></td>
        </tr>
        <tr>
            <td class="w290 talignleft" colspan="2" style="width: 70px">
            </td>
            <td colspan="3" style="width: 199px">
            </td>
            <td class="w290 talignleft" colspan="1" style="width: 33px">
            </td>
            <td colspan="2">
            </td>
        </tr>
    </table>
	</div>
    <br />   <div class="free-forms">
                                <table id="tblbatch" visible="false" class="common"  runat="server" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td colspan="3" rowspan="3"  >
                            Batch Track :</td>
                        <td colspan="1" rowspan="3" >
                            <asp:Label ID="txt_BatchTrack" runat="server" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                        <td colspan="1" rowspan="3" >
                            Module Name :</td>
                        <td colspan="1" rowspan="3" >
                            <asp:Label ID="txt_Module" runat="server" Font-Bold="True" ForeColor="Maroon"  ></asp:Label></td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" >
                            Faculty Name :</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_Faculty" runat="server" Font-Bold="True" ForeColor="Maroon"  
                              ></asp:Label></td>
                        <td colspan="1" rowspan="1" >
                            Lab Name :</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_Lab" runat="server" Font-Bold="True" ForeColor="Maroon"  
                                ></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" >
                            Batch Time :&nbsp; &nbsp;</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_BatchTime" runat="server" Font-Bold="True" ForeColor="Maroon" 
                                ></asp:Label></td>
                        <td colspan="1" rowspan="1" >
                            Batch Slot :</td>
                        <td colspan="1" rowspan="1">
                            <asp:Label ID="txt_BatchSlot" runat="server" Font-Bold="True" ForeColor="Maroon"  
                               ></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" >
                            Batch Start Date :</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_Bstart" runat="server" Font-Bold="True" ForeColor="Maroon"  
                                ></asp:Label></td>
                        <td colspan="1" rowspan="1" >
                            Batch End Date :</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_Bend" runat="server" Font-Bold="True" ForeColor="Maroon"  
                                ></asp:Label></td>
                    </tr>
                    <tr >
                        <td colspan="3" rowspan="1" >
                            Software Name :</td>
                        <td colspan="1" rowspan="1" >
                            <asp:Label ID="txt_software" runat="server"  
                                 Width="221px" Font-Bold="True" ForeColor="Maroon" ></asp:Label></td>
                        <td colspan="1" rowspan="1" >
                        </td>
                        <td colspan="1" rowspan="1" >
                        </td>
                    </tr>
                                    <tr>
                                        <td colspan="6" rowspan="1" style="width:10px;">
                                        </td>
                                    </tr>
                                    
                                </table>
								</div>
    <br />
	   <div class="">
    <table runat="server"  class="common" id="attendance" visible="false"  width="100%">
    <tr>
    <td style="text-align:center;">
         
    <br />
      <asp:Repeater ID="Repeater1" runat="server" Visible="False">
      <HeaderTemplate>
      <table border="" class="common" width="100%" >
      <tr>
    <th style=" background-color:#e1e1e1">Student ID</th>
    <th style=" background-color:#F0F8FB;padding-left:3px" >Student Name</th>
    <th style=" background-color:#F0F8FB;padding-left:3px" >Classes</th>
    <th style=" background-color:#e1e1e1;"  align="center" valign="middle">1</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">2</th>
    <th style=" background-color:#e1e1e1;"  align="center" valign="middle">3</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">4</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">5</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">6</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">7</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">8</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">9</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">10</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">11</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">12</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">13</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">14</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">15</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">16</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">17</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">18</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">19</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">20</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">21</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">22</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">23</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">24</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">25</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">26</th>
    <th style=" background-color:#e1e1e1;"   align="center" valign="middle">27</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">28</th>
    <th style=" background-color:#e1e1e1;" align="center" valign="middle">29</th>
    <th style=" background-color:#F0F8FB"  align="center" valign="middle">30</th>
    <th style=" background-color:#e1e1e1;" align="center" valign="middle">31</th>
    
  </tr>      
      </HeaderTemplate>
      
      <ItemTemplate>
      
      <tr>
    <td style=" background-color:#e1e1e1" align="center" valign="middle">
 <a rel="modal" href="studentbatchreport.aspx?studentid=<%#Eval("StudentID")%>&batchcode=<%= ddlbatchcode.Text%>&iframe=true&amp;width=600&amp;height=325" class="error"> <%#Eval("StudentID")%></a>
   </td>
    <td style=" background-color:#F0F8FB;padding-left:3px" align="left" class="w300" valign="middle"><%#Eval("StudentName")%></td>
        <td style=" background-color:#F0F8FB;padding-left:3px" align="left" class="w300" valign="middle"><%#Eval("pdays")%> / <%#Eval("tdays")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("one")%></td>
    <td style=" background-color:#F0F8FB"  align="center" valign="middle"><%#Eval("two")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("three")%></td>
    <td style=" background-color:#F0F8FB"  align="center" valign="middle"><%#Eval("four")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("five")%></td>
    <td style=" background-color:#F0F8FB"  align="center" valign="middle"><%#Eval("six")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("seven")%></td>
    <td style=" background-color:#F0F8FB"  align="center" valign="middle"><%#Eval("eight")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("nine")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("ten")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("eleven")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("twelve")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("thirteen")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("fourteen")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("fifteen")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("sixteen")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("seventeen")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("eighteen")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("ninteen")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("twenty")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("twentyone")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("twentytwo")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("twentythree")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("twentyfour")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("twentyfive")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("twentysix")%></td>
    <td style=" background-color:#e1e1e1;" align="center" valign="middle"><%#Eval("twentyseven")%></td>
    <td style=" background-color:#F0F8FB;" align="center" valign="middle"><%#Eval("twentyeight")%></td>
    <td style=" background-color:#e1e1e1;" visible="false" align="center" valign="middle"><%#Eval("twentynine")%></td>
    <td style=" background-color:#F0F8FB;" visible="false" align="center" valign="middle"><%#Eval("thirty")%></td>
    <td style=" background-color:#e1e1e1;" visible="false" align="center" valign="middle"><%#Eval("thirtyone")%></td>
    
  </tr>
      
      </ItemTemplate>
      
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>
    <br />
              

          </td></tr></table>  
		  </div>
               
            
    
</asp:Content>

