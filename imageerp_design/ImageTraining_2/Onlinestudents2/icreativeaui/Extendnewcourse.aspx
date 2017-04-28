<%@ Page Language="C#" MasterPageFile="imagemasterpage.master" AutoEventWireup="true" CodeFile="Extendnewcourse.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Extendnewcourse" Title="Extend new course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
$(document).ready(function() {

    $("#ContentPlaceHolder1_txtStudentId").autocomplete('Handler2.ashx');
   // alert("check");  
    });  
</script>
  <script language="javascript" type="text/javascript">
function CheckNumeric(GetEvt)
  {
	var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
	
	if(Char > 31 && (Char < 48 || Char >57))
		return false;
		return true;
  }


 function validate()
 {
           if( document.getElementById("ContentPlaceHolder1_txtStudentId").value =="")
         {    
             alert("Please Enter Student ID");
             document.getElementById("ContentPlaceHolder1_txtStudentId").value == "";
             document.getElementById("ContentPlaceHolder1_txtStudentId").focus();
             document.getElementById("ContentPlaceHolder1_txtStudentId").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtStudentId").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if((document.getElementById("ContentPlaceHolder1_ddlcourse").value==""))
         {
              alert("Please select course name");
             document.getElementById("ContentPlaceHolder1_ddlcourse").value == "";
             document.getElementById("ContentPlaceHolder1_ddlcourse").focus();
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlcourse").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_ddltrack").value==""))
         {
              alert("Please select track");
             document.getElementById("ContentPlaceHolder1_ddltrack").value == "";
             document.getElementById("ContentPlaceHolder1_ddltrack").focus();
             document.getElementById("ContentPlaceHolder1_ddltrack").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddltrack").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_ddlbatch").value==""))
         {
              alert("Please select batch time");
             document.getElementById("ContentPlaceHolder1_ddlbatch").value == "";
             document.getElementById("ContentPlaceHolder1_ddlbatch").focus();
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlbatch").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if((document.getElementById("ContentPlaceHolder1_txtinstallnumber").value==""))
         {
              alert("Please enter installment number");
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").value == "";
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").focus();
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtinstallnumber").style.backgroundColor="#e8ebd9";
             return false;
         }
          else if(parseInt(document.getElementById("ContentPlaceHolder1_txtinstallnumber").value)>parseInt(document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML))
        {
            alert(" Please enter less than or equal to (maximum number of installments)");
            document.getElementById("ContentPlaceHolder1_txtinstallnumber").value=="";
            document.getElementById("ContentPlaceHolder1_txtinstallnumber").focus();
            document.getElementById("ContentPlaceHolder1_txtinstallnumber").style.border="#ff0000 1px solid";
            document.getElementById("ContentPlaceHolder1_txtinstallnumber").style.backgroundColor="#e8ebd9"
            return false;
        }
          else if((document.getElementById("ContentPlaceHolder1_txtstartdate").value==""))
         {
              alert("Please select course start date");
             document.getElementById("ContentPlaceHolder1_txtstartdate").value == "";
             document.getElementById("ContentPlaceHolder1_txtstartdate").focus();
             document.getElementById("ContentPlaceHolder1_txtstartdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtstartdate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else
         {
         return true;
         }
         
 }
 
 
function setFees(programId,track)
{
    var res=0;
    var i;
    var inset=0; 
    if(track=="fast")
    {
        var arraylength=courseFeesfast.length; 
        for(i=0;i<arraylength;i++)
        {
            if(parseInt(courseFeesfast[i]["program"]) == parseInt(programId))
            {               
                document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesfast[i]["noofinstall"];
            }
        }
    }
    else if(track=="normal")
    {
        var arraylength=courseFeesnormal.length; 
        for(i=0;i<arraylength;i++)
        {
            if(parseInt(courseFeesnormal[i]["program"]) == parseInt(programId))
            {     
                document.getElementById("ContentPlaceHolder1_lblmaxinstallnumber").innerHTML=courseFeesnormal[i]["noofinstall"];
            }
        }
    }      
    return res;    
}
function setFees1()
{
    var programFees=setFees(document.getElementById("ContentPlaceHolder1_ddlcourse").value,document.getElementById("ContentPlaceHolder1_ddltrack").value.toLowerCase());
}

 </script>
  <div class="title-cont">
    <h3 class="cont-title">Extend to New Course</h3>
   <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a href="Extendnewcourse.aspx" class="last">Extend to New Course</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
  <div class="white-cont">
    <div class="free-forms">
      <div class="form-cont" style="padding-top:20px;">
        <ul>
          <li>
            <div align="center">
              <asp:Label ID="lblerrormsg" runat="server" CssClass="error"></asp:Label>
            </div>
          </li>
          <li>
            <label class="label-txt">Student Id</label>
            <asp:TextBox ID="txtStudentId" runat="server" CssClass="text input-txt"></asp:TextBox>
          </li>
          <li>
            <label class="label-txt">Course Name</label>
            <asp:DropDownList ID="ddlcourse" onchange="setFees1();" runat="server" CssClass="sele-txt"> </asp:DropDownList>
            <asp:HiddenField ID="hiddennewcoursefees" runat="server" />
          </li>
          <li>
            <label class="label-txt"> Track</label>
            <asp:DropDownList ID="ddltrack" onchange="setFees1();" runat="server" CssClass="sele-txt">
              <asp:ListItem Value="Normal">Normal</asp:ListItem>
              <asp:ListItem Value="Fast">Fast</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <label class="label-txt"> Batch Time</label>
            <asp:DropDownList ID="ddlbatch" runat="server" CssClass="sele-txt">
              <asp:ListItem Value="7AM-9AM">7AM-9AM</asp:ListItem>
              <asp:ListItem Value="9AM-11AM">9AM-11AM</asp:ListItem>
              <asp:ListItem Value="11AM-1PM">11AM-1PM</asp:ListItem>
              <asp:ListItem Value="1PM-3PM">1PM-3PM</asp:ListItem>
              <asp:ListItem Value="3PM-5PM">3PM-5PM</asp:ListItem>
              <asp:ListItem Value="5PM-7PM">5PM-7PM</asp:ListItem>
              <asp:ListItem Value="7PM-9PM">7PM-9PM</asp:ListItem>
            </asp:DropDownList>
          </li>
          <li>
            <div class="wth-1">
              <label class="label-txt3"> Total Install Number</label>
            </div>
            <div class="wth-2">
              <asp:TextBox ID="txtinstallnumber" MaxLength="2" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text input-txt"></asp:TextBox>
              <br />
              Maximum  number of installments :
              <asp:Label ID="lblmaxinstallnumber" runat="server" Text="0" CssClass="error"></asp:Label>
            </div>
          </li>
          <li>
            <label class="label-txt"> Course start date</label>
            <span class="date-pick-cont"><asp:TextBox ID="txtstartdate" runat="server" CssClass="datepicker text date-input-txt"></asp:TextBox></span>
          </li>
          <li>
            <asp:HiddenField ID="hiddenbalanceinitial" runat="server" />
            <asp:HiddenField ID="hiddencoursefees" runat="server" />
            <asp:HiddenField ID="hiddentax" runat="server" />
            <asp:HiddenField ID="hiddencourse" runat="server" />
            <asp:HiddenField ID="hiddeninstall" runat="server" />
            <asp:HiddenField ID="hiddeninvoice" runat="server" />
            <asp:HiddenField ID="hiddenstartinginstallno" runat="server" />
          </li>
          <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">
              <asp:Button ID="btnSubmit" runat="server" Text="Sumbit" OnClientClick="javascript:return validate();" CssClass="btnStyle1" OnClick="btnSubmit_Click" />
            </div>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
</asp:Content>
