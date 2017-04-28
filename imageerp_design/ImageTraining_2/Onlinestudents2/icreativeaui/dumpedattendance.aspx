<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="dumpedattendance.aspx.cs" Inherits="Onlinestudents2_dumpedattendance" Title="Attendance Details" %>
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
 

    </script>           
    
    <table id="tblatt"  runat="server" class="common" >
     <tr><td colspan="3" style="padding:0px;"><h4>
        Attendance Details</h4></td></tr>
        <tr>
            <td colspan="3" style="text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                Select Batch Code
                <asp:DropDownList ID="ddlbatchcode" runat="server">
                </asp:DropDownList>&nbsp;
                <asp:Button ID="btnselectbatch" runat="server" Text="Submit" CssClass="submit" OnClick="btnselectbatch_Click" /></td>
        </tr>
    <tr><td colspan="3" style="text-align:center"><asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=''></asp:Label></td>
    </tr>
               <tr><td colspan="3"> 
                   <table id="tblbatch" runat="server" align="center"  cellpadding="0" cellspacing="0" class="common" visible="false" >
                       <tr>
                           <td colspan="3" rowspan="3" style="height: 37px; width: 119px;">
                               &nbsp;Batch Track</td>
                           <td colspan="1" rowspan="3" style="height: 37px; width: 225px;">
                <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="3" style="height: 37px; width: 94px;">
                               &nbsp;Module Name</td>
                           <td colspan="1" rowspan="3" style="height: 37px">
                        <asp:TextBox ID="txt_modulecontent" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>
                       </tr>
                       <tr>
                       </tr>
                       <tr>
                           <td colspan="3" rowspan="1" style="width: 119px">
                               &nbsp;Faculty Name</td>
                           <td colspan="1" rowspan="1" style="width: 225px">
                <asp:TextBox ID="txt_Faculty" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="width: 94px" >
                               &nbsp;Lab Name</td>
                           <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_Lab" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="236px" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td colspan="3" rowspan="1" style="width: 119px">
                               &nbsp;Batch Time</td>
                           <td colspan="1" rowspan="1" style="width: 225px">
                <asp:TextBox ID="txt_BatchTime" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="width: 94px" >
                               &nbsp;Batch Slot</td>
                           <td colspan="1" rowspan="1">
                <asp:TextBox ID="txt_BatchSlot" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" ReadOnly="True"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td colspan="3" rowspan="1" style="height: 26px; width: 119px;">
                               &nbsp;Batch Start Date</td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 225px;">
                               <asp:TextBox ID="txt_startdate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                   TextMode="SingleLine"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 94px;">
                               &nbsp;Batch End Date</td>
                           <td colspan="1" rowspan="1" style="height: 26px">
                               <asp:TextBox ID="txt_enddate" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                   TextMode="SingleLine"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td colspan="3" rowspan="1" style="height: 26px; width: 119px;">
                               &nbsp;Batch Code</td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 225px;">
                <asp:TextBox ID="txt_BatchCode" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="223px" ReadOnly="True"></asp:TextBox></td>
                           <td colspan="1" rowspan="1" style="height: 26px; width: 94px;">
                        </td>
                           <td colspan="1" rowspan="1" style="height: 26px">
                <asp:TextBox ID="txt_Course" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine" Width="235px" ReadOnly="True" Visible="False"></asp:TextBox></td>
                       </tr>
                   </table>
               </td></tr>
               <tr>
               <td>
               </td>
               </tr> 
        
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server"   CssClass="common"
                    EmptyDataText="No Records Found" AutoGenerateColumns="False" >
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:TemplateField HeaderText="Class Content">
                            <ItemTemplate>
                                <asp:Label ID="lblsubid" Visible="false" runat="server" Text='<%# Eval("subcontent_id") %>'></asp:Label>
                                <asp:Label ID="lblsubcontent" runat="server" Text='<%# Eval("content") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="scheduledate" HeaderText="Schedule Date" />
                        <asp:TemplateField HeaderText="Class held date">
                            <ItemTemplate>
                                <asp:TextBox ID="txtdate" CssClass="text datepicker" runat="server" onpaste="return false" onKeyPress="return false" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="btnpost" runat="server" Text="Post Attendance" Visible="false" CssClass="submit" OnClick="btnpost_Click" /></td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Label ID="lbl_Centrecode" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_batchslot" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_BatchTime" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_BatchTrack" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Lab" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Faculty" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbl_Batchcode" runat="server" Visible="false"></asp:Label>
                <asp:HiddenField ID="hdnReason" runat="server" />
                <asp:HiddenField ID="hiddenmoduleid" runat="server" />
                <asp:HiddenField ID="hiddencontentid" runat="server" />
                <asp:Literal ID="ltrl" runat="server"></asp:Literal>
            </td>
        </tr>
            </table>
</asp:Content>

