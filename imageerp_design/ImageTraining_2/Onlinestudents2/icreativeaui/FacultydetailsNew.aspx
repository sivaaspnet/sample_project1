<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="FacultydetailsNew.aspx.cs" Inherits="Facultydetails" Title=":: Faculty Page ::" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
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
 function Validate_Email(Email)
           {
            var Str=Email
            var CheckExpression=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
            if(CheckExpression.test(Str))
            {
	            return true;
            }
            else
            {
	            return false;
            }
          }  
 function CheckNumeric(GetEvt)
{
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
}
function AllowAlphabet(e)
{
	isIE=document.all? 1:0
	keyEntry = !isIE? e.which:event.keyCode;
	if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
		return true; 
	} else {
		return false;
	}
}
function emptyValidation(fieldList)
 {
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	var cc="";
	for(i=0;i<field.length;i++)
        {
		    if(trim(document.getElementById(field[i]).value)=="")
              {
                document.getElementById(field[i]).focus();
			    document.getElementById(field[i]).style.border="#FF0000 1px solid";
			     document.getElementById(field[i]).style.backgroundColor="#e8ebd9";
			    counter++;
			    if(cc == "") {
			        cc = field[i];
			    }
	          } 
              else 
              {
	            document.getElementById(field[i]).style.border="#EFEFEF";	
			    document.getElementById(field[i]).style.backgroundColor="#FFFFFF";	
	          }
	    }
	if(counter>0)
        {
		alert('Please populate the required/highlighted fields.');
        if(cc!="")
         {
        document.getElementById(cc).focus();
         }
		return false;				
	}  
      else{ return true; }				
}
function Reset()
{
//alert("True");
location.href="FacultydetailsNew.aspx";
document.getElementById("ContentPlaceHolder1_txtfacultyname").value="";
var x=0;
    var radio = document.getElementsByName("ctl00$ContentPlaceHolder1$rbtnlistshift");

            for (var j = 0; j < radio.length; j++)
            {
                if (radio[j].checked)
                {
                    radio[j].checked=false;
                    x=x+1;
                }
            }
           
           
                var liste = document.getElementById("ContentPlaceHolder1_Lstbxspecialsation");
                var howMany = liste.options.length;

                for(var i = 0; i < howMany; i++)
                {
                    if(liste[i].selected)
                    {
                    liste[i].selected=false;
                    }
                }    
           document.getElementById("ContentPlaceHolder1_lblfacid").innerHTML="";

    //document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").value=0;

return true;

}
function checkValidation(fieldList)
{
	var field=new Array();
	field=fieldList.split("~");
	var counter=0;
	for(i=0;i<field.length;i++)
	{
		if(trim(document.getElementById(field[i]).value)=="")
		{
		counter++;
		} 
	}
	if(counter>0)
	{
		return counter;				
	} else { 
		return counter; 
	}				
} 

       	        
function faculty()
    {
   
       if(document.getElementById("ContentPlaceHolder1_txtfacultyname").value=="")
         {
             document.getElementById("ContentPlaceHolder1_txtfacultyname").value=="";
             alert("Please enter faculty name");
             document.getElementById("ContentPlaceHolder1_txtfacultyname").focus();
             document.getElementById("ContentPlaceHolder1_txtfacultyname").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtfacultyname").style.backgroundColor="#e8ebd9";
             return false;
         }
       
     if(document.getElementById("ContentPlaceHolder1_ddlDaily").value =="NIL")
     {
        if(document.getElementById("ContentPlaceHolder1_ddlMWF").value=="NIL")
         {
             
             alert("Please select time");
             document.getElementById("ContentPlaceHolder1_ddlMWF").focus();
             document.getElementById("ContentPlaceHolder1_ddlDaily").value=="NIL"
             document.getElementById("ContentPlaceHolder1_ddlMWF").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlMWF").style.backgroundColor="#e8ebd9";
             return false;
         }
           else if(document.getElementById("ContentPlaceHolder1_ddlTTS").value=="NIL")
         {
           
             alert("Please select time");
             document.getElementById("ContentPlaceHolder1_ddlTTS").focus();
             document.getElementById("ContentPlaceHolder1_ddlDaily").value=="NIL"
             document.getElementById("ContentPlaceHolder1_ddlTTS").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlTTS").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").value=="")
         {
            
             alert("Please Select specialsation");
            
             document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").focus();
             document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").style.backgroundColor="#e8ebd9";
             return false;
         }
     }
              else if(document.getElementById("ContentPlaceHolder1_ddlDaily").value=="NIL")
         {
             
             alert("Please select time");
             document.getElementById("ContentPlaceHolder1_ddlTTS").value=="NIL"
             document.getElementById("ContentPlaceHolder1_ddlMWF").value=="NIL"
             document.getElementById("ContentPlaceHolder1_ddlDaily").focus();
             document.getElementById("ContentPlaceHolder1_ddlDaily").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlDaily").style.backgroundColor="#e8ebd9";
             
             return false;
         }
         else if(document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").value=="")
         {
            
             alert("Please Select specialsation");
            
             document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").focus();
             document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_Lstbxspecialsation").style.backgroundColor="#e8ebd9";
             return false;
         }
          
         else
         {
         return true;
         }
         
  }
  
  function change()
  {
  if(document.getElementById("ContentPlaceHolder1_ddlDaily").value!="NIL")
         {
             document.getElementById("ContentPlaceHolder1_ddlTTS").value="NIL"
             document.getElementById("ContentPlaceHolder1_ddlMWF").value="NIL"
               
             return false;
         }
  }

 function change1()
  {
  if(document.getElementById("ContentPlaceHolder1_ddlTTS").value!="NIL")
         {
             document.getElementById("ContentPlaceHolder1_ddlDaily").value="NIL"
           
               
             return false;
         }
  }
  
 function change2()
  {
  if(document.getElementById("ContentPlaceHolder1_ddlMWF").value!="NIL")
         {
             document.getElementById("ContentPlaceHolder1_ddlDaily").value="NIL"
           
               
             return false;
         }
  }
</script>
  
 <div class="free-forms">
    <table class="common" width="100%">
   <tr>
        <td colspan="8"  style="padding:0px;">
           <h4>
             Add Faculty Details</h4>
            
        </td>
    </tr>
        <tr>
            <td align="left" colspan="8" style="text-align: center">
                <asp:Label ID="lbl_errormsg" CssClass="error" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblfree" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblfacid" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td class="formlabel">
                Faculty Name
            </td>
            <td align="left" valign="top" colspan="7" style="height: 29px">
                <asp:TextBox ID="txtfacultyname" CssClass="text" runat="server" MaxLength="75" onkeypress="return AllowAlphabet(event)" ></asp:TextBox></td>
        </tr>
    <tr>
      <td class="formlabel">
        MWF</td>
      <td  align="left" valign="top" colspan="7" >
          <asp:DropDownList onChange="return change2();" ID="ddlMWF" runat="server">
              <asp:ListItem Value="NIL">Select</asp:ListItem>
              <asp:ListItem Value="7Amto5Pm">7Amto5Pm</asp:ListItem>
              <asp:ListItem Value="9Amto7Pm">9Amto7Pm</asp:ListItem>
              <asp:ListItem Value="11Amto9Pm">11Amto9Pm</asp:ListItem>
          </asp:DropDownList></td>
        
    </tr>
        <tr>
            <td class="formlabel">
              TTS</td>
            <td align="left" colspan="7" valign="top">
               <asp:DropDownList onChange="return change1();" ID="ddlTTS" runat="server">
                    <asp:ListItem Value="NIL">Select</asp:ListItem>
                    <asp:ListItem Value="7Amto5Pm">7Amto5Pm</asp:ListItem>
              <asp:ListItem Value="9Amto7Pm">9Amto7Pm</asp:ListItem>
              <asp:ListItem Value="11Amto9Pm">11Amto9Pm</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formlabel">
                 Daily</td>
            <td align="left" colspan="7" valign="top">
                <asp:DropDownList onChange="return change();" ID="ddlDaily" runat="server">
                    <asp:ListItem Value="NIL">Select</asp:ListItem>
                    <asp:ListItem Value="7Amto5Pm">7Amto5Pm</asp:ListItem>
              <asp:ListItem Value="9Amto7Pm">9Amto7Pm</asp:ListItem>
              <asp:ListItem Value="11Amto9Pm">11Amto9Pm</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    <tr>
    <td class="formlabel">
               Specialisation</td>
        <td align="left" colspan="7" valign="top">
               <asp:ListBox ID="Lstbxspecialsation" runat="server" Height="139px">
                    <asp:ListItem>Dpro</asp:ListItem>
                    <asp:ListItem>Premiere</asp:ListItem>
                    <asp:ListItem>3dsMax</asp:ListItem>
                    <asp:ListItem>VFX</asp:ListItem>
                    <asp:ListItem>Maya</asp:ListItem>
                    <asp:ListItem>Visual Design</asp:ListItem>
                    <asp:ListItem>2d Animation</asp:ListItem>
                    <asp:ListItem>Script/Mobile Gaming</asp:ListItem>
                </asp:ListBox></td>
    </tr>
  
       
   
    <tr 
class="no-borders">
        <td colspan="8"   style="text-align:center">
            <asp:HiddenField ID="HiddenField1" runat="server" />
           <asp:Button ID="btn_add" runat="server" Text="Submit" CssClass="btnStyle1" OnClientClick="javascript:return faculty();" OnClick="btn_add_Click" />&nbsp;&nbsp;&nbsp;
            <input id="Reset1" type="button" class="btnStyle2" onclick="javascript:return Reset();" value="Reset" /></td>
    </tr>
</table>
</div>
   <br />
   <div style="padding:10px">
    <asp:GridView width="100%" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                     EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" PageSize="15" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />
                        <asp:BoundField DataField="MWF" HeaderText="MWF" />
                        <asp:BoundField DataField="TTS" HeaderText="TTS" />
                        <asp:BoundField DataField="Daily" HeaderText="Daily" />
                        <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("Faculty_ID")%>'
                                    CommandName="edt"><img src="layout/edit.png" alt="edit" /></asp:LinkButton>
                                
                                <asp:LinkButton ID="lnkdelete" runat="server"  CommandArgument='<%#Eval("Faculty_ID")%>'
                                    CommandName="del" OnClientClick="javascript:return confirm('Do you want to delete?');"><img src="layout/delete.png" alt="delete" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
 
</div>
  </asp:Content>

