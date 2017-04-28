<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="AddProjectAssesment.aspx.cs" Inherits="superadmin_AddProjectAssesment" Title="Add Project Assesment" %>

<asp:Content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
            if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").value)=="")
             {
                 document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").value=="";   
                 alert("*Please Enter the Project guide!");
                 document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").focus();
                 document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").style.border="#ff0000 1px solid";
                 document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").style.backgroundColor="#e8ebd9";
               
                 return false;
             }
             else
             {
             return true;
             }
            }
            else
            {
            document.getElementById("ctl00_ContentPlaceHolder1_Gridvw_ctl01_cbSelectAll").focus();
      alert('Select at least one checkbox!');
      return false;
            }
   }

 
   function trim(stringToTrim)
	        {
			return stringToTrim.replace(/^\s+|\s+$/g,"");
	        }
  

function clearValidation(fieldList) {
	
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++) {
		if(document.getElementById(field[i]).value!="") {
			document.getElementById(field[i]).style.border="#999999 1px solid";
			document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
		}
	}
		
}     
	        
	 function Validate()
     {
         if(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").value)=="")
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").value=="";   
             alert("*Please Enter the Project guide!");
             document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtProjectGuide").style.backgroundColor="#e8ebd9";
           
             return false;
         }
         else
         {
         return true;
         }   
     }
       function Validate_Email(Email)
{
	var Str=Email
	//var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@imageil.([a-z]{2,6}(?:\.[a-z]{2})?)$/i

	if(CheckExpression.test(Str))// test Method to check for Regular Expression
	{
		return true;
	}
	else
	{
		return false
	}
}
function searchval()
{
if(document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").value=="" && document.getElementById("ctl00_ContentPlaceHolder1_txtsearchname").value=="" )
         {
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").focus();
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").style.border="#ff0000 1px solid";
             document.getElementById("ctl00_ContentPlaceHolder1_txtsearchlocation").style.backgroundColor="#e8ebd9";
             return false;
         } 
        else
        {
        return true;
        }

}
function btnreset_onclick()
 {
  location.href="addcentre.aspx";
 }
 
 function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%= Gridvw.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            
            if (grid.rows.length > 0)
            {
                //loop starts from 1. rows[0] points to the header.
                for (i=1; i<grid.rows.length; i++)
                {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];
                    
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox")
                        {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

</script>
 
    <table class="common" >
        <tr>
            <td align="right" style="padding:0px;"> <h4>
      Project Details</h4>
            </td>
        </tr>
        <tr>
    <td align="right">
        <asp:Label ID="Label1" runat="server" Text="Searchby Batch Code"></asp:Label>&nbsp;<asp:DropDownList ID="ddlsearchBatch" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;<asp:Button ID="btnsearch" runat="server" CssClass="search"  OnClick="btnsearch_Click" /></td>
            </tr><tr><td style="text-align:center"><asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label></td>
    </tr>
        <tr>
            <td style="text-align: center">
                <table id="tblbatch" runat="server" border="0" cellpadding="0" cellspacing="0" visible="false"
                    >
                    <tr>
                        <td colspan="3" rowspan="3" style="height: 37px">
                            Batch Track</td>
                        <td colspan="1" rowspan="3" style="height: 37px">
                            <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine"></asp:TextBox></td>
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
                        <td colspan="6" rowspan="1" style="height: 26px" align="center" valign="middle">
                            &nbsp;
                            <div style=" max-height:400px; overflow:auto;">
        <asp:GridView ID="Gridvw" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="common" EmptyDataText="No Student Records Found"
            OnRowDataBound="Gridvw_RowDataBound" PageSize="100" OnPageIndexChanging="Gridvw_PageIndexChanging" >
            <Columns>
                <asp:TemplateField HeaderText="Select">
                <HeaderTemplate>

                <asp:CheckBox ID="cbSelectAll" runat="server" Text="SelectAll"/>

                </HeaderTemplate>
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
                <asp:TemplateField HeaderText="Student Name">
                    <ItemTemplate>
                        <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("StudentName").ToString())%>
                        <asp:Label ID="lbl_stdname" runat="server" Text='<%#Eval("StudentName")%>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Module">
                    <ItemTemplate>
                        <%# MVC.CommonFunction.ReplaceTildWithQuote(Eval("Batch_Module_Content").ToString())%>
                        <asp:Label ID="lbl_Module" runat="server" Text='<%#Eval("Batch_Module_Content")%>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course Name">
                    <ItemTemplate>
                        <%# MVC.CommonFunction.ReplaceTildWithQuote(Eval("Course").ToString())%>
                        <asp:Label ID="lbl_coursename" runat="server" Text='<%#Eval("Course")%>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
        </asp:GridView>
        </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <div style="overflow:auto;">
        &nbsp;<br />
        &nbsp;</div>
    <table class="common" id="provis" runat="server" visible="false">
        <tr>
            <td colspan="2" style="height:10px;">
            </td>
        </tr>
        <tr>
            <td class="w290 talignleft">
                Project Guided By</td>
            <td >
                <asp:TextBox ID="txtProjectGuide" CssClass="text" runat="server" Width="308px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="middle" style="text-align:center;">
        <asp:Button ID="btnstudents" runat="server" Text="Add Students" CssClass="submit"  Visible="False" OnClientClick="javascript:return TestCheckBox();" OnClick="btnstudents_Click" /><br />
            </td>
        </tr>
    </table>
    
    <p>
        &nbsp;</p>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnID1" runat="server" />

</asp:Content>

