<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="EditSchedule.aspx.cs" Inherits="Onlinestudents2_superadmin_EditSchedule" Title="Edit Batch Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<%--<script type="text/javascript">


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
--%>
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

function Validate()
    {
    
    //clearValidation('ContentPlaceHolder1_txt_Reason')
    
    var str1 = document.getElementById("ContentPlaceHolder1_txt_Bstart").value;
    //alert(str1);
    var start_s = str1.split("-");
        //var end_s = end.split("-");

        var stDate = start_s[2]+start_s[1]+start_s[0];
    //alert(str1);
    var str3=document.getElementById("ContentPlaceHolder1_txt_Bend").value;
    //alert(str3);
    var end_s = str3.split("-");
        //var end_s = end.split("-");

        var edDate = end_s[2]+end_s[1]+end_s[0];
        
//        alert(stDate);
//        alert(edDate);
    
    var str2 = document.getElementById("ContentPlaceHolder1_txt_stratdate").value;
    
    var st_s = str2.split("-");
        //var end_s = end.split("-");

        var stsDate = st_s[2]+st_s[1]+st_s[0];
//     var dt1  = parseInt(str1.substring(0,2),10);
//    var mon1 = parseInt(str1.substring(3,5),10);
//    var yr1  = parseInt(str1.substring(6,10),10);
//     var dt2  = parseInt(str2.substring(0,2),10);
//    var mon2 = parseInt(str2.substring(3,5),10);
//    var yr2  = parseInt(str2.substring(6,10),10);
//    
//         var dt3  = parseInt(str3.substring(0,2),10);
//    var mon3 = parseInt(str3.substring(3,5),10);
//    var yr3  = parseInt(str3.substring(6,10),10);
//    //alert(yr1);
//     var date1 = new Date(yr1, mon1, dt1);
//    var date2 = new Date(yr2, mon2, dt2);
//    var date3=new Date(yr3, mon3, dt3);
//    alert(stDate);
//    alert(edDate);
//    alert(stsDate);
    if(document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="")
    {
                document.getElementById("ContentPlaceHolder1_txt_stratdate").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Please enter the date!';
             document.getElementById("ContentPlaceHolder1_txt_stratdate").focus();
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_stratdate").style.backgroundColor="#e8ebd9";
             return false;
    }
   
       else if(stsDate<stDate)
         {
             //document.getElementById("ContentPlaceHolder1_txt_Reason").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Class date cannot be lesser than Batch start date!';
             //document.getElementById("ContentPlaceHolder1_txt_Reason").focus();
             //document.getElementById("ContentPlaceHolder1_txt_Reason").style.border="#ff0000 1px solid";
             //document.getElementById("ContentPlaceHolder1_txt_Reason").style.backgroundColor="#e8ebd9";
             return false;
         } 
         else if(stsDate>edDate)
         {
             //document.getElementById("ContentPlaceHolder1_txt_Reason").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Class date cannot be greater than Batch end date!';
             //document.getElementById("ContentPlaceHolder1_txt_Reason").focus();
             //document.getElementById("ContentPlaceHolder1_txt_Reason").style.border="#ff0000 1px solid";
             //document.getElementById("ContentPlaceHolder1_txt_Reason").style.backgroundColor="#e8ebd9";
             return false;
         }
    
        else if(trim(document.getElementById("ContentPlaceHolder1_txt_Reason").value)=="")
         {
             document.getElementById("ContentPlaceHolder1_txt_Reason").value=="";
             document.getElementById("ContentPlaceHolder1_lblerror").innerHTML ='*Please enter the reason!';
             document.getElementById("ContentPlaceHolder1_txt_Reason").focus();
             document.getElementById("ContentPlaceHolder1_txt_Reason").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txt_Reason").style.backgroundColor="#e8ebd9";
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
            <td colspan="7" style="text-align: center">
                <asp:Label ID="lblerror" runat="server" CssClass="error" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td  colspan="7">
                <br />
                <table id="tblbatch" visible="true" runat="server" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="3" rowspan="3">
                            Batch Track</td>
                        <td colspan="1" rowspan="3">
                            <asp:TextBox ID="txt_BatchTrack" runat="server" CssClass="text" MaxLength="30"
                                ReadOnly="True" TextMode="SingleLine"></asp:TextBox></td>
                        <td colspan="1" rowspan="3">
                            Module Name</td>
                        <td colspan="1" rowspan="3">
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
                        <td colspan="6" rowspan="3" style="height: 50px">
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 26px">
                Software Name</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_Software" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Width="264px"></asp:TextBox></td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            Content</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_Content" runat="server" CssClass="text" MaxLength="30" ReadOnly="True"
                                TextMode="SingleLine" Width="229px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" style="height: 26px">
                            Class Date</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_stratdate" runat="server" CssClass="text datepicker" MaxLength="10"
                              onpaste="return false" onKeyPress="return false" ></asp:TextBox></td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            Reason</td>
                        <td colspan="1" rowspan="1" style="height: 26px">
                            <asp:TextBox ID="txt_Reason" runat="server" CssClass="text" MaxLength="30" TextMode="SingleLine"
                                Width="229px"></asp:TextBox></td>
                    </tr>
                    <tr>
            <td align="center"  colspan="8" style="height: 30px; text-align:center;" valign="middle">
                &nbsp;
                <asp:Button ID="btn_submit" runat="server" CssClass="submit" OnClick="btn_submit_Click"
                    OnClientClick="javascript:return Validate();" Text="Update" />&nbsp;
            </td>
        </tr>
                </table>
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

