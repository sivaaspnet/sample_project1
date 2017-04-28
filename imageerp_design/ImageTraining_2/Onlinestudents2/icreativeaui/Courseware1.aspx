<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="imagemasterpage.master" CodeFile="Courseware1.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_Courseware" EnableEventValidation = "false"%>
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
    function lab()
    {
    clearValidation('ContentPlaceHolder1_ddl_course~ContentPlaceHolder1_Listbox_Software')
      if(trim(document.getElementById("ContentPlaceHolder1_ddl_course").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_ddl_course").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select course name!';
             document.getElementById("ContentPlaceHolder1_ddl_course").focus();
             document.getElementById("ContentPlaceHolder1_ddl_course").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddl_course").style.backgroundColor="#e8ebd9";
             return false;
         }
       else if(trim(document.getElementById("ContentPlaceHolder1_Listbox_Software").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_Listbox_Software").value=="";
             document.getElementById("ContentPlaceHolder1_lblmsg1").innerHTML ='*Please select software name!';
             document.getElementById("ContentPlaceHolder1_Listbox_Software").focus();
             document.getElementById("ContentPlaceHolder1_Listbox_Software").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_Listbox_Software").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
    } 
    
    function SearchValidate()
{
if(document.getElementById("ContentPlaceHolder1_ddlsearchcourse").value=="" && document.getElementById("ContentPlaceHolder1_txtsoftsearch").value=="" )
         {
         
            
             document.getElementById("ContentPlaceHolder1_ddlsearchcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlsearchcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlsearchcourse").style.backgroundColor="#e8ebd9";
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
document.getElementById("ContentPlaceHolder1_ddl_course").value="";



  var liste = document.getElementById("ContentPlaceHolder1_Listbox_Software");
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

   

<h4>
                Course Details</h4>
				
                          <div class="gridSort" style="margin-top:10px">
    <table cellpadding="0" cellspacing="0" class="common" width="100%">
        <tr>
    <td style="height: 31px"  >
       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Searchby Course Name" Width="127px"></asp:Label></td>
                <td style="width: 100px">
                <asp:Label ID="lblsearchsoftware" runat="server" Text="Searchby Module Name" Width="135px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" Text="Searchby Software Name" Width="154px"></asp:Label></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:DropDownList ID="ddlsearchcourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsearchcourse_SelectedIndexChanged">
        </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlsearchmodule"
            runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsearchmodule_SelectedIndexChanged">
        </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddl_software" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 100px">
       
        <asp:Button ID="btnsoftsearch" runat="server"   CssClass="search" OnClick="btnsoftsearch_Click"  /></td>
            </tr>
        </table>
        </td>
            </tr><tr><td style="text-align:center; padding:0px; height: 16px;">
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               </td>
    </tr>
    </table>
	</div>
    <br />
  
    <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Records Found"  OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" >
                <Columns>
                    <asp:BoundField DataField="program" HeaderText="Course" />
                    <asp:BoundField DataField="Module" HeaderText="Module Name" />
                   <asp:BoundField DataField="Software" HeaderText="Software" />
                      <asp:BoundField DataField="Content" HeaderText="Content" />             
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
            </asp:GridView>
                      
                   <td>
                   <center> <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Download Excel" OnClick="Button1_Click" />
                   </center>
                   </td>
                      
              
                
    <br />
    <br />
</asp:Content>

