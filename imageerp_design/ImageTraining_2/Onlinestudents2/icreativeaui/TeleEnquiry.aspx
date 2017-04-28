<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="TeleEnquiry.aspx.cs" Inherits="superadmin_TeleEnquiry" Title="Tele Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">

  function trim(stringToTrim)
	{
		return stringToTrim.replace(/^\s+|\s+$/g,"");
    }
  

   function clearValidation(fieldList) 
   {	
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

    function CheckNumeric(GetEvt)
    {
	    var Char=(GetEvt.which) ? GetEvt.which : event.keyCode
    	
	    if(Char > 31 && (Char < 48 || Char >57))
		    return false;
		    return true;
    }

   function MaxLength(field, maxLength)
    {
        if (field.value.length >= maxLength)
            field.value = field.value.substring(0, maxLength - 1);
    }
      
    function councilvalidate()
     {
//clearValidation('ContentPlaceHolder1_txtcounselor_name~ContentPlaceHolder1_txtcounselor_id~ContentPlaceHolder1_txtcounselor_pwd~ContentPlaceHolder1_txtcounselor_repwd~ContentPlaceHolder1_txtcounselor_email')
          
             if(trim(document.getElementById("ContentPlaceHolder1_txtEnquiryName").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_txtEnquiryName").value=="";   
                 alert('Please Enter the type of EnquiryName!');
                 document.getElementById("ContentPlaceHolder1_txtEnquiryName").focus();
                 document.getElementById("ContentPlaceHolder1_txtEnquiryName").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtEnquiryName").style.backgroundColor="#e8ebd9";           
                 return false;
             }
//             else if(trim(document.getElementById("ContentPlaceHolder1_txtEmailID").value)=="")
//             {
//                 document.getElementById("ContentPlaceHolder1_txtEmailID").value=="";   
//                 alert('Please Enter the EmailID!');
//                 document.getElementById("ContentPlaceHolder1_txtEmailID").focus();
//                 document.getElementById("ContentPlaceHolder1_txtEmailID").style.border="#ff0000 1px solid";
//                 document.getElementById("ContentPlaceHolder1_txtEmailID").style.backgroundColor="#e8ebd9";
//                 return false;
//             }
//              else if(!Validate_Email(document.getElementById("ContentPlaceHolder1_txtEmailID").value))
//              {
//	                alert('Please Enter the Valid EmailId!');
//		            document.getElementById("ContentPlaceHolder1_txtEmailID").focus();
//                    document.getElementById("ContentPlaceHolder1_txtEmailID").style.border="#ff0000 1px solid";
//                    document.getElementById("ContentPlaceHolder1_txtEmailID").style.backgroundColor="#e8ebd9";
//		            return false;
//	          }
        
           else if((document.getElementById("ContentPlaceHolder1_txtMobile").value)=="" || document.getElementById("ContentPlaceHolder1_txtMobile").value.length<10)
             {             
                 document.getElementById("ContentPlaceHolder1_txtMobile").value=="";
                 alert('Please Enter the Mobile number!');
                 document.getElementById("ContentPlaceHolder1_txtMobile").focus();
                 document.getElementById("ContentPlaceHolder1_txtMobile").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtMobile").style.backgroundColor="#e8ebd9";
                 return false;
             }
//                else if(document.getElementById("ContentPlaceHolder1_txtPhone").value=="" || document.getElementById("ContentPlaceHolder1_txtPhone").value.length<10)
//             {                 
//                 document.getElementById("ContentPlaceHolder1_txtPhone").focus();
//                 document.getElementById("ContentPlaceHolder1_txtPhone").style.border="#ff0000 1px solid";
//                 document.getElementById("ContentPlaceHolder1_txtPhone").style.backgroundColor="#e8ebd9";
//                 alert('Please Enter the Phone number!');
//                 return false;
//             }
//                else if(trim(document.getElementById("ContentPlaceHolder1_txtAddr").value)=="")
//             {
//                 document.getElementById("ContentPlaceHolder1_txtAddr").value=="";
//                 alert( 'Please Enter Your Address!');
//                 document.getElementById("ContentPlaceHolder1_txtAddr").focus();
//                 document.getElementById("ContentPlaceHolder1_txtAddr").style.border="#ff0000 1px solid";
//                 document.getElementById("ContentPlaceHolder1_txtAddr").style.backgroundColor="#e8ebd9";
//                 return false;
//             }


  else if(trim(document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_ddl_aboutimage").value=="";
                 alert('Please Select the Sourse!');
                 document.getElementById("ContentPlaceHolder1_ddl_aboutimage").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_aboutimage").style.backgroundColor="#e8ebd9";
                 return false;
             }
            /*   else if(trim(document.getElementById("ContentPlaceHolder1_ddl_profile").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_ddlCourse").value=="";
                 alert('Please Select the profile!');
                 document.getElementById("ContentPlaceHolder1_ddl_profile").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_profile").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_profile").style.backgroundColor="#e8ebd9";
                 return false;
             }*/


                else if(trim(document.getElementById("ContentPlaceHolder1_ddlCourse").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_ddlCourse").value=="";
                 alert('Please Select the Coursename!');
                 document.getElementById("ContentPlaceHolder1_ddlCourse").focus();
                 document.getElementById("ContentPlaceHolder1_ddlCourse").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddlCourse").style.backgroundColor="#e8ebd9";
                 return false;
             }
//                 else if(trim(document.getElementById("ContentPlaceHolder1_txtVisitcentre").value)=="")
//             {
//                 document.getElementById("ContentPlaceHolder1_txtVisitcentre").value=="";
//                 alert('Please Enter the Visit Centre!');
//                 document.getElementById("ContentPlaceHolder1_txtVisitcentre").focus();
//                 document.getElementById("ContentPlaceHolder1_txtVisitcentre").style.border="#ff0000 1px solid";
//                 document.getElementById("ContentPlaceHolder1_txtVisitcentre").style.backgroundColor="#e8ebd9";
//                 return false;
//             }
                 else if(trim(document.getElementById("ContentPlaceHolder1_txtRemarks").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_txtRemarks").value=="";
                 alert('Please Enter your Remarks!');
                 document.getElementById("ContentPlaceHolder1_txtRemarks").focus();
                 document.getElementById("ContentPlaceHolder1_txtRemarks").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_txtRemarks").style.backgroundColor="#e8ebd9";
                 return false;
             }
              
                 else if(trim(document.getElementById("ContentPlaceHolder1_ddl_status").value)=="")
             {
                 document.getElementById("ContentPlaceHolder1_ddl_status").value=="";
                 alert('Please Select the Status!');
                 document.getElementById("ContentPlaceHolder1_ddl_status").focus();
                 document.getElementById("ContentPlaceHolder1_ddl_status").style.border="#ff0000 1px solid";
                 document.getElementById("ContentPlaceHolder1_ddl_status").style.backgroundColor="#e8ebd9";
                 return false;
             }
               
             else
             {
             return true;
             }   
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
    function btnreset_onclick() 
    {
        location.href="TeleEnquiry.aspx";
    }

</script>
  <div>
    <asp:Label ID="lblMsg" runat="server" CssClass="errmsg"></asp:Label>
  </div>
  <div class="free-forms">
    <asp:MultiView ID="MultiView1" runat="server">
      <asp:View ID="View1" runat="server">
        <div class="title-cont">
          <h3 class="cont-title">Add Enquiry Details</h3>
          <div class="breadcrumps">
            <ul>
              
              <li><a href="EnquiryType.aspx">Enquiry</a>/</li>
              <li><a href="#" class="last">Add Tele Enquiry</a></li>
            </ul>
          </div>
          <div class="clear"></div>
        </div>
        <div class="content-links" align="right">
          <asp:LinkButton ID="lnkManageProduct" runat="server" OnClick="lnkManageProduct_Click">Manage Enquiry</asp:LinkButton>
        </div>
        <div class="white-cont" style="padding:20px 10px 10px 10px;">
          <asp:Label ID="lblmsg1" runat="server" CssClass="error" Text=""></asp:Label>
          <div class="form-cont">
            <ul>
              <li>
                <label class="label-txt">Enquiry Name <span style="color: #ff0000">*</span></label>
                <asp:TextBox ID="txtEnquiryName" runat="server" CssClass="text input-txt" MaxLength="60" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Email ID</label>
                <asp:TextBox ID="txtEmailID" runat="server" CssClass="text input-txt" MaxLength="50" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Mobile No <span style="color: #ff0000">*</span></label>
                <asp:TextBox ID="txtMobile" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="10"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Phone No</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="text input-txt" onKeyPress="return CheckNumeric(event)" MaxLength="12"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Address</label>
                <asp:TextBox ID="txtAddr" runat="server" CssClass="text area-txt" onKeyPress="MaxLength(this,400);" TextMode="MultiLine" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt"> How did you know about IMAGE ? <span style="color:Red">*</span></label>
                <asp:DropDownList ID="ddl_aboutimage" runat="server" CssClass="select sele-txt" onChange="chkvl9()">
                  <asp:ListItem value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="image web/internet">image web/internet</asp:ListItem>
                  <asp:ListItem Value="Google">Google</asp:ListItem>
                  <asp:ListItem Value="Just Dial">Just Dial</asp:ListItem>
                  <asp:ListItem Value="Sulekha">Sulekha</asp:ListItem>
                  <asp:ListItem Value="ROPS(Reference of past Student)">ROPS(Reference of past Student)</asp:ListItem>
                  <asp:ListItem Value="ROCS(Reference of Current Student)">ROCS(Reference of Current Student)</asp:ListItem>
                  <asp:ListItem Value="ROS (Reference of Staff)">ROS (Reference of Staff)</asp:ListItem>
                  <asp:ListItem Value="Reference of enquiry">Reference of enquiry</asp:ListItem>
                  <asp:ListItem Value="WOM(Words of Mouth)">WOM(Words of Mouth)</asp:ListItem>
                  <asp:ListItem value="Board">Sign Board</asp:ListItem>
                  <asp:ListItem Value="Tv advertisement">Tv advertisement</asp:ListItem>
                  <asp:ListItem Value="Print advertisement">Print advertisement</asp:ListItem>
                  <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt"> Refered Name</label>
                <asp:TextBox ID="txtreferstudentname" runat="server" CssClass="text input-txt" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Enquiry Profile</label>
                <span class="file">
                <asp:DropDownList ID="ddl_profile" runat="server" CssClass="select sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="School student">School student</asp:ListItem>
                  <asp:ListItem Value="College student">College student</asp:ListItem>
                  <asp:ListItem Value="Employed">Employed/Salaried</asp:ListItem>
                  <asp:ListItem Value="SelfEmployed">Self-Employed</asp:ListItem>
                  <asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
                  <asp:ListItem Value="Housewife">Housewife</asp:ListItem>
                  <asp:ListItem Value="SrCitizen">Sr.Citizen</asp:ListItem>
                  <asp:ListItem Value="Multimedia Professional">Multimedia Professional</asp:ListItem>
                  <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                </asp:DropDownList>
                </span> </li>
              <li>
                <label class="label-txt">Course Interested <span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="select sele-txt"> </asp:DropDownList>
              </li>
              <li>
                <label class="label-txt">When He/She is going to visit the centre</label>
                <asp:TextBox ID="txtVisitcentre" runat="server" CssClass="text area-txt" onKeyPress="MaxLength(this,250);" TextMode="MultiLine"></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Remarks <span style="color: #ff0000">*</span></label>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="text area-txt" onKeyPress="MaxLength(this,300);" TextMode="MultiLine" ></asp:TextBox>
              </li>
              <li>
                <label class="label-txt">Status <span style="color: #ff0000">*</span></label>
                <asp:DropDownList ID="ddl_status" runat="server" CssClass="sele-txt">
                  <asp:ListItem Value="">--Select--</asp:ListItem>
                  <asp:ListItem Value="Spot enrolled">Spot Enrolled</asp:ListItem>
                  <asp:ListItem Value="Enrolled">Enrolled</asp:ListItem>
                  <asp:ListItem Value="Very propective">Very prospective</asp:ListItem>
                  <asp:ListItem Value="Propective">Prospective</asp:ListItem>
                  <asp:ListItem Value="Fake">Fake</asp:ListItem>
                  <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
                  <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>
                  <asp:ListItem Value="Not Reachable">Not Reachable</asp:ListItem>
                  <asp:ListItem Value="RNR">RNR</asp:ListItem>
                </asp:DropDownList>
              </li>
              <li>
                <div align="center">
                  <asp:Button ID="btnsubmit5" runat="server" CssClass="btnStyle1" OnClick="btnsubmit5_Click" OnClientClick="javascript:return councilvalidate();" Text="Save" />
                  <input ID="Reset2" class="reset-btn" onclick="return Reset2_onclick()"  title="Reset" type="reset" value="Reset" />
                </div>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
        </div>
      </asp:View>
      <asp:View ID="View2" runat="server">
        <div class="title-cont">
          <h3 class="cont-title">View Enquiry Details(
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            )</h3>
          <div class="breadcrumps">
            <ul>
               <li><a href="EnquiryType.aspx">Enquiry</a>/</li>
              <li><a href="#" class="last">View Tele Enquiry</a></li>
            </ul>
          </div>
          <div class="clear"></div>
        </div>
        <div class="content-links" align="right">
          <asp:LinkButton ID="lnkAddProduct" runat="server" OnClick="lnkAddProduct_Click">Add Enquiry</asp:LinkButton>
        </div>
        <div class="white-cont">
          <h4 class="cont-title3">View Enquiry Student Report</h4>
          <asp:Label ID="lblmessage" runat="server" CssClass="error" Text=""></asp:Label>
          <div class="search-sec-cont2">
            <ul>
              <li id="viewonly_to_sa" runat="server">
                <div class="wth-1">Select centre code</div>
                <div class="wth-2">
                  <asp:DropDownList ID="ddl_sa_cencode" runat="server" CssClass="sele-txt"> </asp:DropDownList>
                </div>
              </li>
              <li>
                <div class="wth-1">Keywords</div>
                <div class="wth-2">
                  <asp:TextBox ID="txtkeyword" runat="server" CssClass="text input-txt" ></asp:TextBox>
                </div>
              </li>
              <li>
                <div class="wth-1">Search By</div>
                <div class="wth-2">
                  <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="no-padd-tbl">
                    <asp:ListItem Value="Student Name">Name</asp:ListItem>
                    <asp:ListItem Value="About Image">Sourse</asp:ListItem>
                    <asp:ListItem Value="Profile">Profile</asp:ListItem>
                    <asp:ListItem Value="Mobile">ContactNo</asp:ListItem>
                    <asp:ListItem Value="Area">Area</asp:ListItem>
                  </asp:RadioButtonList>
                </div>
              </li>
              <li>
                <div class="wth-1">Status</div>
                <div class="wth-2">
                  <asp:DropDownList ID="ddlStatus" runat="server" CssClass="sele-txt" selectedvalue='<%#Eval("Status")%>'>
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Following">Following</asp:ListItem>
                    <asp:ListItem Value="Spot enrolled">Spot enrolled</asp:ListItem>
                    <asp:ListItem Value="Enrolled">Enrolled</asp:ListItem>
                    <asp:ListItem Value="Very propective">Very prospective</asp:ListItem>
                    <asp:ListItem Value="Propective">Prospective</asp:ListItem>
                    <asp:ListItem Value="Not propective">Not prospective</asp:ListItem>
                    <asp:ListItem Value="Fake">Fake</asp:ListItem>
                    <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
                    <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>
                  </asp:DropDownList>
                  <strong><span style="text-decoration: underline"> </span></strong> </span></div>
              </li>
              <li class="date-sec-cont">
                <div class="wth-1">Date From</div>
                <div class="wth-2 date-pick-cont">
                  <asp:TextBox ID="txtfromcalender" runat="server" CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false" onkeydown="return false"></asp:TextBox>
                </div>
                <div class="wth-3">To</div>
                <div class="wth-2 date-pick-cont">
                  <asp:TextBox ID="txttocalender" runat="server" CssClass="text datepicker date-input-txt" onpaste="return false" onKeyPress="return false" onkeydown="return false"></asp:TextBox>
                </div>
              </li>
              <li>
                <div align="center">
                  <asp:Button ID="btnsort" runat="server" CssClass="btnStyle1" OnClick="btnsort_Click" OnClientClick="javascript:return sortval();"  Text="Search"   />
                  <asp:CustomValidator ID="custSpecialValidator" runat="server" ForeColor="Red" ErrorMessage="Please enter valid characters." OnServerValidate="Validate_Special" ControlToValidate="txtkeyword"></asp:CustomValidator>
                </div>
              </li>
            </ul>
            <div class="clear"></div>
          </div>
        </div>
        <div class="white-cont" style="padding:10px;">
         <div style="padding:0px 10px 10px 10px">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="tbl-cont3"  EmptyDataText="No Records Found" OnPageIndexChanging="GridView1_PageIndexChanging">
              <EmptyDataRowStyle ForeColor="Red" />
              <Columns>
              <asp:TemplateField HeaderText="Name">
                <ItemTemplate> <%# MVC.CommonFunction.ReplaceTildWithQuote(Eval("Enquiryname").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Mobile No">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("MobileNo").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Course Interested">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("CourseInterested").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Date/Time">
                <ItemTemplate> <%#Eval("dateins")%> </ItemTemplate>
                <ItemStyle Width="12%" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Update On">
                <ItemTemplate> <%#Eval("DateMod")%> </ItemTemplate>
                <ItemStyle Width="12%" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Remarks").ToString())%> </ItemTemplate>
                <ItemStyle Width="35%"  />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Enquired By">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Enquired_By").ToString())%> </ItemTemplate>
                <ItemStyle Width="35%"  />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Reminder Date">
                <ItemTemplate> <%#Eval("reminderdate")%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="View More...">
                <ItemTemplate> <a href='Telepersonalview.aspx?enqno=<%#Eval("TeleEnquiryID")%>&TeleEnquiry=1&iframe=true&amp;width=1000&amp;height=700' rel="modal"> <img alt="View" title="Click here to view more details" src="../layout/32.gif" /></a> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                  <asp:DropDownList ID="ddlfollowstatus" selectedvalue='<%#Eval("Status")%>' runat="server"  CssClass="autowidth">
                    <asp:ListItem Value="Following">Following</asp:ListItem>
                    <asp:ListItem Value="Spot enrolled">Spot enrolled</asp:ListItem>
                    <asp:ListItem Value="Enrolled">Enrolled</asp:ListItem>
                    <asp:ListItem Value="Very propective">Very prospective</asp:ListItem>
                    <asp:ListItem Value="Propective">Prospective</asp:ListItem>
                    <asp:ListItem Value="Not propective">Not prospective</asp:ListItem>
                    <asp:ListItem Value="Fake">Fake</asp:ListItem>
                    <asp:ListItem Value="Dropped">Dropped</asp:ListItem>
                    <asp:ListItem Value="For ICAT">For ICAT</asp:ListItem>
                    <asp:ListItem Value="Not Reachable">Not Reachable</asp:ListItem>
                    <asp:ListItem Value="RNR">RNR</asp:ListItem>
                  </asp:DropDownList>
                  <asp:Label ID="hdnstatus" runat="server" Text='<%#Eval("Status")%>' Visible="false"></asp:Label>
                  <asp:Button ID="btnupd" runat="server" CssClass="update" OnClick="btnupd_Click" ToolTip="Update" />
                </ItemTemplate>
                <ItemStyle Width="22%" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Followups">
                <ItemTemplate>
                  <asp:Label ID="lblhdnmsg" runat="server" Text='<%#Eval("TeleEnquiryID")%>' Visible="false"></asp:Label>
                  <a rel="modal[]" href='followup.aspx?enqno=<%#Eval("TeleEnquiryID")%>&TeleEnquiry=1&iframe=true&width=1000&height=500'> <img alt="Trace" height="20" src="../layout/text.gif" width="20" title="Add follow ups"/></a> &nbsp; <a href='followupview.aspx?enqno=<%#Eval("TeleEnquiryID")%>&TeleEnquiry=1&iframe=true&width=1000&height=500' rel="modal[]" > <img alt="View" src="../layout/32.gif" title="View Follow ups" /></a> &nbsp; <a href='telethankyou.aspx?teleid=<%#Eval("TeleEnquiryID")%>'> <img alt="Trace" height="20" src="../layout/icon-9.png" width="20" title="Move to walkin/reg/express enrollment"/></a> </ItemTemplate>
                <ItemStyle Width="20%" />
              </asp:TemplateField>
              </Columns>
                 <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
            </asp:GridView>
          </div>
          <div class="dataGrid2" style="display:none">
            <asp:GridView ID="gvDownload" runat="server" AutoGenerateColumns="False" CssClass="common" Width="1300" EmptyDataText="No Records Found" >
              <EmptyDataRowStyle ForeColor="Red" />
              <Columns>
              <asp:TemplateField HeaderText="Name">
                <ItemTemplate> <%# MVC.CommonFunction.ReplaceTildWithQuote(Eval("Enquiryname").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Mobile No">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("MobileNo").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Course Interested">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("CourseInterested").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Source">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("sourse").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Profile">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("profile").ToString())%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Date/Time">
                <ItemTemplate> <%#Eval("dateins")%> </ItemTemplate>
                <ItemStyle Width="12%" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Update On">
                <ItemTemplate> <%#Eval("DateMod")%> </ItemTemplate>
                <ItemStyle Width="12%" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Remarks").ToString())%> </ItemTemplate>
                <ItemStyle Width="35%"  />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Enquired By">
                <ItemTemplate> <%#MVC.CommonFunction.ReplaceTildWithQuote(Eval("Enquired_By").ToString())%> </ItemTemplate>
                <ItemStyle Width="35%"  />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Reminder Date">
                <ItemTemplate> <%#Eval("reminderdate")%> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                  <asp:Label ID="hdnstatus" runat="server" Text='<%#Eval("Status")%>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="22%" />
              </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </div>
          <div class="file" align="center">
            <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" CssClass="download-btn">Download Excel</asp:LinkButton>
          </div>
        </div>
      </asp:View>
    </asp:MultiView>
  </div>
</asp:Content>
