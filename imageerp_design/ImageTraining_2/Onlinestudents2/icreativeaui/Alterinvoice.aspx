<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="Alterinvoice.aspx.cs" Inherits="ImageTraining_2_Onlinestudents2_superadmin_Alterinvoice" Title="Alter Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
         if( document.getElementById("ContentPlaceHolder1_ddlAlterYear").value =="")
         {    
             alert("Please Select Academic Year");
             document.getElementById("ContentPlaceHolder1_ddlAlterYear").value == "";
             document.getElementById("ContentPlaceHolder1_ddlAlterYear").focus();
             document.getElementById("ContentPlaceHolder1_ddlAlterYear").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_ddlAlterYear").style.backgroundColor="#e8ebd9";
             return false;
         }
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
              alert("Please select Next Installment date");
             document.getElementById("ContentPlaceHolder1_txtstartdate").value == "";
             document.getElementById("ContentPlaceHolder1_txtstartdate").focus();
             document.getElementById("ContentPlaceHolder1_txtstartdate").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtstartdate").style.backgroundColor="#e8ebd9";
             return false;
         }
         else if((document.getElementById("ContentPlaceHolder1_txtreason").value==""))
         {
              alert("Please enter the reason for change the invoice");
             document.getElementById("ContentPlaceHolder1_txtreason").value == "";
             document.getElementById("ContentPlaceHolder1_txtreason").focus();
             document.getElementById("ContentPlaceHolder1_txtreason").style.border="#ff0000 1px solid";
             document.getElementById("ContentPlaceHolder1_txtreason").style.backgroundColor="#e8ebd9";
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
                if(inset==0)
                {
                    createInstallmentNumbers(courseFeesfast[i]["noofinstall"]);
                    inset=1;
                } 
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
                if(inset==0)
                {
                    createInstallmentNumbers(courseFeesnormal[i]["noofinstall"]);
                    inset=1;
                }
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
    <h3 class="cont-title">Alter Invoice</h3>
    </div>
  <div class="white-cont">
        <div class="form-cont">
        <ul class="no-borders">                
            <li>
            <label class="label-txt"> Select Academic Year :</label>
            <asp:DropDownList ID="ddlAlterYear" runat="Server"  CssClass="sele-txt"></asp:DropDownList></li>
            <li>
            <div align="center">
            <asp:Label ID="lblerrormsg" runat="server" CssClass="error"></asp:Label></div></li>
         <li>
            <label class="label-txt"><b>Student Id</b></label>
       <asp:TextBox ID="txtStudentId" runat="server" CssClass="text input-txt"></asp:TextBox>
         <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters."
    OnServerValidate="Validate_Special" ControlToValidate="txtStudentId"></asp:CustomValidator></li>
    <li>  <label class="label-txt"></label>
    <asp:Button runat="server" ID="btninvoice" Text ="submit"  OnClick="showinvoices" /></li>      
      
        <li runat="server" id="invoiceDetails" visible="false">
            <label class="label-txt"><b>Invoice</b></label>       
           <asp:GridView ID="grdinvoices" runat="server" CssClass="tbl-cont3" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField HeaderText="Invoice" ItemStyle-Width="100px">
            <ItemTemplate>
            <asp:CheckBox runat="server" ID="chk" />
            <asp:HiddenField runat="server" ID="hdninvoice"  Value='<%#Eval("invoiceid") %>'/>
             <asp:HiddenField runat="server" ID="hdncourseid"  Value='<%#Eval("courseid") %>'/>
          <%#Eval("invoiceid") %>
            </ItemTemplate>
            </asp:TemplateField>              
                <asp:BoundField HeaderText="Course" DataField="program" ItemStyle-Width="200px" />
                 <asp:TemplateField HeaderText="Course to be changed" ItemStyle-Width="200px">
            <ItemTemplate>
           <asp:DropDownList runat="server" ID="ddlcoursealter" Width="150px" ></asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView></li>
       <li>
            <label class="label-txt">
       <b>Course Name</b></label>
        <asp:DropDownList  CssClass="sele-txt"
                ID="ddlcourse" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlcourse_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:HiddenField ID="hiddennewcoursefees" runat="server" />
      </li>      
      
      <li>
            <label class="label-txt">Courses Fees</label>
      <asp:TextBox ID="coursefee" runat="server" CssClass="text input-txt"></asp:TextBox>
       </li>
        <li>
            <label class="label-txt">
                <strong>Track</strong></label>
          
                <asp:DropDownList ID="ddltrack" runat="server" onchange="setFees1();" CssClass="sele-txt">
                <asp:ListItem Value="Normal">Normal</asp:ListItem>
                <asp:ListItem Value="Fast">Fast</asp:ListItem>
                </asp:DropDownList></li>
        <li>
            <label class="label-txt">
                <strong>Batch Time</strong></label>
          <asp:DropDownList ID="ddlbatch" runat="server" CssClass="sele-txt">
                <asp:ListItem Value="7AM-9AM">7AM-9AM</asp:ListItem>
                <asp:ListItem Value="9AM-11AM">9AM-11AM</asp:ListItem>
                <asp:ListItem Value="11AM-1PM">11AM-1PM</asp:ListItem>
                <asp:ListItem Value="1PM-3PM">1PM-3PM</asp:ListItem>
                <asp:ListItem Value="3PM-5PM">3PM-5PM</asp:ListItem>
                <asp:ListItem Value="5PM-7PM">5PM-7PM</asp:ListItem>
                <asp:ListItem Value="7PM-9PM">7PM-9PM</asp:ListItem>
                </asp:DropDownList></li>
        <li>
            <label class="label-txt">
                <strong>Initial Payment</strong></label>       
                <asp:TextBox ID="txtinitialpayment" runat="server" CssClass="text input-txt"></asp:TextBox></li>
        <li>
            <label class="label-txt">
                <strong>Total Install Number</strong></label>
          <asp:TextBox ID="txtinstallnumber" MaxLength="2" onKeyPress="return CheckNumeric(event)" runat="server" CssClass="text input-txt"></asp:TextBox><br />
         <div  style="margin-left:320px"> Maximum  number of installments : <asp:Label ID="lblmaxinstallnumber" runat="server" Text="0" CssClass="error"></asp:Label></div> </li>
        <li>
            <label class="label-txt">
                <strong>Next Installment Date</strong></label>
                <span class="date-pick-cont">
          <asp:TextBox ID="txtstartdate" runat="server" CssClass="text datepicker date-input-txt" Width="125px" onkeypress="return false" onkeydown="return false" onpaste="return false" ></asp:TextBox>
          </span>
          </li>
        <li>
            <label class="label-txt">
                Reason</label>
        <asp:TextBox ID="txtreason" TextMode="MultiLine" runat="server" CssClass="text input-txt" Width="260px"></asp:TextBox>
        <asp:HiddenField ID="hiddenpaidinitial" runat="server" />
            <asp:HiddenField ID="hiddencoursefees" runat="server" />
        <asp:HiddenField ID="hiddentax" runat="server" />
            <asp:HiddenField ID="hiddencourse" runat="server" />
            <asp:HiddenField ID="hiddeninstall" runat="server" />
            <asp:HiddenField ID="hiddeninvoice" runat="server" />
            <asp:HiddenField ID="hiddenstartinginstallno" runat="server" />
        <asp:HiddenField ID="hiddenrunningreceipt" runat="server" />
            <asp:HiddenField ID="hiddenrunningcenter" runat="server" />
        </li>
     
              <li style="text-align:center;">
            <div align="center" style="padding-bottom:25px;">
           <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="javascript:return validate();"   CssClass="btnStyle1" OnClick="btnSubmit_Click" />
           </div></li>
    </ul>
    <div class="clear"></div>
       </div>
       </div>
</asp:Content>

