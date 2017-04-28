<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="BatchSchedule.aspx.cs" Inherits="Onlinestudents2_BatchSchedule" Title="Batch Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	   
	        }
 function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}


onKeyPress="return CheckNumeric(event)"       
	        
   function clearValidation(fieldList)
    {
	
	    var field=new Array();
	    field=fieldList.split("~");
	    var counter=0;
	    for(i=0;i<field.length;i++)
	     {
		    if(document.getElementById(field[i]).value!="") 
		    {
			    document.getElementById(field[i]).style.border="#999999 1px solid";
			    document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		    }
		}
    } 
    function moduleval()
    {
    var start = document.getElementById("ctl00_ContentPlaceHolder1_txt_startdate").value;
    var end = document.getElementById("ctl00_ContentPlaceHolder1_txt_enddate").value;
    var classdate=document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").value;
    
    var start_s = start.split("/");
        var end_s = end.split("/");
        var class_s=classdate.split("-");

        var stDate = start_s[0]+start_s[1]+start_s[2];
        var enDate = end_s[0]+end_s[1]+end_s[2];
        var clDate=class_s[2]+class_s[1]+class_s[0];

        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var mon =  (curr_month < 10 ? '0' : '') + curr_month
        //var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        if(curr_date<10)
        {
        var toDate = parseInt(curr_year +''+ mon +''+'0'+ curr_date);
        }
        else
        {
        var toDate = parseInt(curr_year +''+ mon +''+ curr_date);
        }
        var cmpcsdate=clDate-stDate;
        var cmpendate=enDate-clDate;
        
//        alert(stDate);
//        alert(enDate);
//        alert(clDate);
//        alert(cmpcsdate);
//        alert(cmpendate);
//        return false;
    
    clearValidation('ctl00_ContentPlaceHolder1_ddl_Content~ctl00_ContentPlaceHolder1_txt_classdate')
    if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddl_software").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_software").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the software!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_software").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_software").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_software").style.backgroundColor="#e8ebd9";
             return false;
         }
         
     else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_ddl_Content").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Content").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please enter the content!';
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Content").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Content").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_ddl_Content").style.backgroundColor="#e8ebd9";
             return false;
         } 
     
      else if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the date of class!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").style.backgroundColor="#e8ebd9";
             return false;
         } 
         else if(cmpcsdate<0)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the valid date of class!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(cmpendate<0)
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").value=="";
             document.getElementById("ctl00_ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select the valid date of class!';
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txt_classdate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
function Button2_onclick() {

}

    </script>
<table class="common">
    <tr>
        <td colspan="4" style="padding:0px;">
            <h4>
        Batch Scheduling</h4>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label></td>
    </tr>
        <tr>
            <td colspan="3">
                <table id="tblbatch" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
                    class="common" visible="false">
                    <tr>
                        <td colspan="3" rowspan="3" style="height: 37px">
                            &nbsp;Batch Track</td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                            &nbsp;Module Name</td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                        <asp:TextBox ID="txt_modulecontent" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True" Width="188px"></asp:TextBox></td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1">
                            &nbsp;Faculty Name</td>
                        <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_Faculty" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True" Width="250px"></asp:TextBox></td>
                        <td colspan="1" rowspan="1">
                            &nbsp;Lab Name</td>
                        <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_Lab" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="236px" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1">
                            &nbsp;Batch Time</td>
                        <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_BatchTime" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                        <td colspan="1" rowspan="1">
                            &nbsp;Batch Slot</td>
                        <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_BatchSlot" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 26px">
                            &nbsp;Batch Start Date</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                <asp:TextBox ID="txt_startdate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                    TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            &nbsp;Batch End Date</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                <asp:TextBox ID="txt_enddate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                    TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 26px">
                            &nbsp;Batch Code</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                <asp:TextBox ID="txt_BatchCode" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="239px" ReadOnly="True"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                        </td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                <asp:TextBox ID="txt_Course" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="348px" ReadOnly="True" Visible="False"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 84px">
                Software Name</td>
            <td>
                <asp:DropDownList ID="ddl_software" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_software_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 84px">
                Content</td>
            <td>
                &nbsp;<asp:DropDownList ID="ddl_Content" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="w290 talignleft" style="width: 84px">
                Date Of Class</td>
            <td>
                <asp:TextBox ID="txt_classdate" onpaste="return false" onKeyPress="return false"  runat="server" CssClass="text datepicker" MaxLength="10"></asp:TextBox></td>
        </tr>
                <tr>
                    <td colspan="2"  style=" text-align:center;">
                        <br />
                        <asp:Button ID="Button1" CssClass="submit" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return moduleval();" />
                        &nbsp;<asp:Button ID="btnReset" CssClass="submit" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <br />
                     
                        
                        </td>
                </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="common"
                    EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField DataField="software_name" HeaderText="SoftwareName" />
                        <asp:BoundField DataField="Content" HeaderText="Content" />
                        <asp:BoundField DataField="Dateofclass" HeaderText="Class Date" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnledt" CommandName="Edt" CommandArgument='<%#Eval("Schedule_ID") %>' runat="server"><img src="layout/edit.png" alt="edit" /></asp:LinkButton>&nbsp; ||&nbsp;
                                <asp:LinkButton ID="lnkdel" CommandName="Del" CommandArgument='<%#Eval("Schedule_ID") %>' OnClientClick="javascript:return confirm('Do you want to delete?');" runat="server"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lbl_Centrecode" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_batchslot" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_BatchTime" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_BatchTrack" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_Lab" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_Faculty" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_Batchcode" runat="server" Visible="false"></asp:Label>&nbsp;<br />
                <asp:Label ID="lbl_ScheduleID" runat="server" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td class="w290 talignleft" colspan="2">
            </td>
        </tr>
            </table>
</asp:Content>

