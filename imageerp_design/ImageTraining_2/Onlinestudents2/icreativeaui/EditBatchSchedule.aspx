<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="EditBatchSchedule.aspx.cs" Inherits="Onlinestudents2_superadmin_EditBatchSchedule" Title="Edit Batch Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript">


 function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	   
	        }


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

function viewatnval()
    {
    
    clearValidation('ContentPlaceHolder1_ddlbatchcode~ContentPlaceHolder1_ddlsoftwre')
    
      if(trim(document.getElementById("ContentPlaceHolder1_ddlbatchcode").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Please select batch code!';
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatchcode").style.backgroundColor="#e8ebd9";
             return false;
         } 
     
      else if(trim(document.getElementById("ContentPlaceHolder1_ddlsoftwre").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Please select software!';
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").focus();
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlsoftwre").style.backgroundColor="#e8ebd9";
             return false;
         } 
          
         else
         {
         return true;
         }
         
    } 
 

</script>

    <table class="common">
        <tr>
            <td colspan="7" style="padding:0px;">
                <h4>
                    Edit Batch Schedule</h4>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 49px">
                Batch Code<br />
                <asp:DropDownList ID="ddlbatchcode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlbatchcode_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td colspan="2" style="height: 49px">
                Software name<br />
                <asp:DropDownList ID="ddlsoftwre" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="search" OnClick="Button1_Click"
                    OnClientClick="javascript:return viewatnval();" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align:center;">
                <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
    </table>
    <br />
                <table id="tblbatch" visible="false" runat="server"  width="700px" class="common"  cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="3" rowspan="3" style="height: 37px">
                            Batch Track</td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                            <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30"
                                ReadOnly="True" TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                            Module Name</td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                            <asp:TextBox ID="txt_Module" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1">
                            Faculty Name</td>
                        <td colspan="1" rowspan="1">
                            <asp:TextBox ID="txt_Faculty" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1">
                            Lab Name</td>
                        <td colspan="1" rowspan="1">
                            <asp:TextBox ID="txt_Lab" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1">
                            Batch Time</td>
                        <td colspan="1" rowspan="1">
                            <asp:TextBox ID="txt_BatchTime" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1">
                            Batch Slot</td>
                        <td colspan="1" rowspan="1">
                            <asp:TextBox ID="txt_BatchSlot" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 26px">
                            Batch Start Date</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_Bstart" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            Batch End Date</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_Bend" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 26px">
                            Software Name</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_software" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Width="234px"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                        </td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" rowspan="1" style="height: 26px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                CssClass="common" EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">
                                <EmptyDataRowStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
                                <Columns>
                                    <asp:BoundField HeaderText="Content" DataField="Content" />
                                    <asp:BoundField HeaderText="Scheduled Date" DataField="ScheduledDate" />
                                    <asp:BoundField HeaderText="Schedule Changed Date" DataField="ScheduleChangedDate" />
                                    <asp:BoundField HeaderText="Class Held" DataField="ClassHeld" />
                                    <asp:BoundField HeaderText="Schedule Changed Reason" DataField="ScheduleChangedReason" />
                                    <asp:BoundField HeaderText="Reason For Cancellation" DataField="Reason" />
                                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" CommandName="Edt" Visible="false" CommandArgument='<%#Eval("Schedule_Id") %>' runat="server">Edit</asp:LinkButton>
                            <asp:Label ID="lblClassHeld" runat="server" Visible="False" Text='<%#Eval("ClassHeld") %>'></asp:Label>
                            <asp:Label ID="lblBatStatus" runat="server" Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
    <br />
    <table class="common"  visible="false" runat="server" id="Table1">
        <tr>
            <td >
                &nbsp;</td>
        </tr>
    </table>
    <br />
</asp:Content>

