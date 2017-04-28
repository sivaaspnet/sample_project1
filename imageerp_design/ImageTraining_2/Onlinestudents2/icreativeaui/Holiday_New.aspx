<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Holiday_New.aspx.cs" Inherits="superadmin_Holiday_New" Title="Holiday New" %>

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
    function HolidayValidate()
    {
        clearValidation('<%=txt_Reason.ClientID%>');
      if(trim(document.getElementById("<%=txt_holidate.ClientID%>").value)=="")
         {
             document.getElementById("<%=txt_holidate.ClientID%>").value=="";
             document.getElementById("<%=lblmsg1.ClientID%>").innerHTML ='*Please select the date!';
             document.getElementById("<%=txt_holidate.ClientID%>").focus();
             document.getElementById("<%=txt_holidate.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=txt_holidate.ClientID%>").style.backgroundColor="#e8ebd9";
             return false;
         }
        else if(trim(document.getElementById("<%=txt_Reason.ClientID%>").value)=="")
         {
             document.getElementById("<%=txt_Reason.ClientID%>").value=="";
             document.getElementById("<%=lblmsg1.ClientID%>").innerHTML ='*Please enter the reason!';
             document.getElementById("<%=txt_Reason.ClientID%>").focus();
             document.getElementById("<%=txt_Reason.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=txt_Reason.ClientID%>").style.backgroundColor="#e8ebd9";
             return false;
         }
//       else if(trim(document.getElementById("ddl_Status").value)=="")
//         {
//             document.getElementById("ddl_Status").value=="";
//             document.getElementById("lblmsg1").innerHTML ='*Please Select the status!';
//             document.getElementById("ddl_Status").focus();
//             document.getElementById("ddl_Status").style.border="#ff0000 1px solid";
//             document.getElementById("ddl_Status").style.backgroundColor="#e8ebd9";
//             return false;
//         }
         else
         {
         return true;
         }  
    } 
    
function SearchValidate()
{
if(document.getElementById("<%=DDlSearchbyyear.ClientID%>").value=="" && document.getElementById("<%=Txt_search_reason.ClientID%>").value=="" )
         {
    
             document.getElementById("<%=DDlSearchbyyear.ClientID%>").focus();
             document.getElementById("<%=DDlSearchbyyear.ClientID%>").style.border="#ff0000 1px solid";
             document.getElementById("<%=DDlSearchbyyear.ClientID%>").style.backgroundColor="#e8ebd9";
             return false;
         } 
      
        else
        {
        return true;
        }

}

function Reset()
{
//alert("True");
document.getElementById("<%=txt_holidate.ClientID%>").value="";
document.getElementById("<%=txt_Reason.ClientID%>").value="";

}




</script>
  <div class="title-cont">
    <h3 class="cont-title"> Holiday Details</h3>
    <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Acadamic</a>/</li>
        <li><a href="Holiday_New.aspx" class="last">Holiday Details</a></li>
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <div class="search-sec-cont">
    <ul>
      <li>
        <div class="wth-1">Searchby holiday year</div>
        <div class="wth-2">
          <asp:DropDownList
           ID="DDlSearchbyyear" runat="server" CssClass=" sele-txt">
            <asp:ListItem Value="">Select</asp:ListItem>
            <asp:ListItem>2010</asp:ListItem>
            <asp:ListItem>2011</asp:ListItem>
            <asp:ListItem>2012</asp:ListItem>
            <asp:ListItem>2013</asp:ListItem>
            <asp:ListItem>2014</asp:ListItem>
            <asp:ListItem>2015</asp:ListItem>
            <asp:ListItem>2016</asp:ListItem>
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
          </asp:DropDownList>
        </div>
      </li>
      <li>
        <div class="wth-1">Search by reason</div>
        <div class="wth-2">
          <asp:TextBox ID="Txt_search_reason" runat="server" CssClass="text input-txt"></asp:TextBox>
        </div>
      </li>
      <li>
        <asp:Button ID="btn_search" runat="server"  CssClass="search-btn"  Text="Search"  OnClick="btn_search_Click" />
      </li>
    </ul>
    <div class="clear"></div>
    <div align="center">
      <asp:Label ID="lblmsg1" CssClass="error" runat="server" Text=""></asp:Label>
      <asp:Label ID="Lblfree" runat="server" Visible="False"></asp:Label>
    </div>
  </div>
  <div class="white-cont">
    <div style="padding:0px 10px 10px 10px">
      <asp:GridView CssClass="tbl-cont3" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%">
        <Columns>
        <asp:BoundField DataField="Hoilday_date" HeaderText="Holiday Date" />
        <asp:BoundField DataField="Holiday_reason" HeaderText="Reason" />
        <asp:TemplateField HeaderText="Action">
          <ItemTemplate>
            <asp:LinkButton ID="lnkedit" runat="server" CommandName="edt" CommandArgument='<%#Eval("Holiday_Id")%>'><img src="layout/edit.png" alt="edit" /></asp:LinkButton>
            |
            <asp:LinkButton ID="lnkdelete" runat="server" CommandName="del" CommandArgument='<%#Eval("Holiday_Id")%>' OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
     <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
        <EmptyDataRowStyle ForeColor="Red" />
      </asp:GridView>
    </div>
  </div>
  <asp:HiddenField ID="hiddn_id" runat="server" />
  <div class="white-cont">
    <h4 class="cont-title2">Add Holiday Details</h4>
    <div class="form-cont">
      <ul>
        <li>
          <label class="label-txt"> Holiday Date </label>
          <span class="date-pick-cont">
            <asp:TextBox ID="txt_holidate" runat="server" CssClass="text datepicker  date-input-txt " onpaste="return false" onKeyPress="return false" ></asp:TextBox>
          </span> </li>
        <li>
          <label class="label-txt">Reason </label>
          <asp:TextBox ID="txt_Reason" runat="server" CssClass="text input-txt" MaxLength="100" ></asp:TextBox>
        </li>
        <li style="text-align:center;">
          <div align="center" style="padding-bottom:25px;">
            <asp:Button ID="Button2" CssClass="btnStyle1" runat="server" OnClick="Button1_Click" Text="Add" OnClientClick="javascript:return HolidayValidate();" />
            <input id="Reset1" class="reset-btn" onclick="javascript:return Reset();" type="button"  value="Reset-btn" />
          </div>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
  </div>
</asp:Content>
