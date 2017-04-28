
<%@ Page Language="C#" MasterPageFile="~/Onlinestudents2/1imagemasterpage.master" AutoEventWireup="true" CodeFile="NSDC_candidatelist.aspx.cs" Inherits="NSDC_candidatelist" Title="NSDC Candidates " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.input-lbl2
{
    font-family:Arial, Helvetica, sans-serif;
	font-size:16px;	
}
.input-txt1{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 150px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	color:#666666;
    margin-left: 0px;
     
}
.input-ddl1{
	border: 1px solid #cecece;	
    border-radius: 5px;
    box-shadow: 0 3px 0 0 rgba(0, 0, 0, 0.1) inset;
    height: 30px;
    padding: 0 5px;
    width: 165px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	color:#666666;
    margin-left: 0px;
   
}
</style>
<h4>NSDC CANDIDATES</h4>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="NSDC.aspx" Font-Bold="True" >NSDC</asp:HyperLink><br />
  <asp:Label ID="Label3"  CssClass="input-lbl2" runat="server" Text="SEARCH BY:" Font-Bold="true" ></asp:Label>&nbsp;	&nbsp;&nbsp;																																																																																		
   <asp:Label ID="Label1"  CssClass="input-lbl2" runat="server" Text="Student name:" ></asp:Label>																																																																																			
   <asp:TextBox ID="txt_student_name" runat="server" CssClass="input-txt1"></asp:TextBox>																																																																																			
   <asp:Label ID="Label2"  CssClass="input-lbl2" runat="server" Text="Enrollment number:" ></asp:Label>																																																																																			
   <asp:TextBox ID="txt_enroll_no" runat="server" CssClass="input-txt1"></asp:TextBox>																																																																																	
   <asp:Label ID="Label4"  CssClass="input-lbl2" runat="server" Text="Course:" ></asp:Label>																																																																																			
  <asp:DropDownList ID="ddl_course" width='136px' runat="server" CssClass="input-ddl1"></asp:DropDownList>&nbsp;	&nbsp;&nbsp;&nbsp;	&nbsp;&nbsp; 																																																				<br>										<br>																					

     
  <asp:Button  runat="server" ID="btn_search" CssClass="btnStyle1" 
        Text="search" OnClick="btn_search_Click" />
   <asp:Button  runat="server" ID="btn_excel" CssClass="btnStyle1" 
        Text="Download as Excel" onclick="btn_excel_Click" Width="196px"  />
             
       <br>
  <br>  
 <div class="dataGrid" style="padding:10px;width:100%;overflow:auto;height: 600px;">
             
         
        <asp:GridView ID="GridView1" runat="server" CssClass="common" AlternatingRowStyle-CssClass="alt"  AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand"
        AllowPaging="true" EmptyDataText="No Records Found" PageSize="500" OnPageIndexChanging="OnPageIndexChanging" CellPadding="3" CellSpacing="1" OnRowDataBound="GridView1_DataBound">
         
          <Columns>
        
     
        <asp:BoundField ItemStyle-Width="50px" DataField="enrollment_no" HeaderText="Enrollment number"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>

         <asp:BoundField ItemStyle-Width="150px" DataField="salutation" HeaderText="Salutation" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
       <asp:TemplateField HeaderText="First Name Candidate">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkBtnEdit_name"  CommandName ="CEdit_name" CommandArgument ='<%#Eval("enrollment_no")%>' runat="server" Font-Underline="False"><%# Eval("first_name") %></asp:LinkButton>
                                       </ItemTemplate>
         </asp:TemplateField>
        
        <asp:BoundField ItemStyle-Width="50px" DataField="last_name" HeaderText="Last Name Candidate" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="guardian_type" HeaderText="Guardian Type" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="date_birth" HeaderText="Date of Birth"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="place_birth" HeaderText="Place of Birth" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="firstname_guardian" HeaderText="First Name of Father/Guardian" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="lastname_guardian" HeaderText="Last Name of Father/Guardian"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="mother_name" HeaderText="Mother’s Maiden Name" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="aadhar_enrollno" HeaderText="Aadhar Enrolment Number" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="aadhar_no" HeaderText="Aadhar Number"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="ration_cardno" HeaderText="Ration Card Number" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="gender" HeaderText="Gender" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="caste" HeaderText="Caste Category"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="disability" HeaderText="Disability" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="religion" HeaderText="Religion" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="trainee_address" HeaderText="Trainee Address"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="tc_state" HeaderText="Tc State" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="tc_district" HeaderText="Tc District" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="tc_pincode" HeaderText="PINCode"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="trainee_mobile" HeaderText="Contact number of Trainee" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="trainee_type_mobile" HeaderText="Type of Mobile" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="trainee_emailid" HeaderText="E-mailID of Trainee"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="pretraining_status" HeaderText="Pre Training Status" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="experience_year" HeaderText="No of years of previous experience" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="experience_month" HeaderText="No of months of previous experience"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="education_level" HeaderText="Education Level" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="technical_education" HeaderText="Technical Education" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="sector_covered" HeaderText="Sector Covered"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Course Enrolled">
        <ItemTemplate>
        <asp:Label runat="server" ID="lbl_course" Text='<%#Eval("courseID")%>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField ItemStyle-Width="150px" DataField="course_fee" HeaderText="Course Fee" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="trainerID" HeaderText="Trainer Id"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="fee_paidby" HeaderText="Fee Paid By" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="batch_start_date" HeaderText="Batch Start Date" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="batch_end_date" HeaderText="Batch End Date">
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="training_status" HeaderText="Training Status" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="data_month" HeaderText="Data submit for Month" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="data_year" HeaderText="Data Submit for Year"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="attendance" HeaderText="Attendance(in%)" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="passedout_date" HeaderText="Passing out Date" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="grade" HeaderText="Grade"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="certified" HeaderText="Certified" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="certification_date" HeaderText="Certification Date" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="certificate_name" HeaderText="Certificate name / Award"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="certificate_no" HeaderText="Certificate Number" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="assesment_date" HeaderText="Assessment Date" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="agency" HeaderText="Agency"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="assessor" HeaderText="Assessor" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="certifying_Agency" HeaderText="Certifying Agency" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Placement Status">
        <ItemTemplate>
        <asp:Label runat="server" ID="lbl_placement" Text='<%#Eval("placement_status")%>' ></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="50px" DataField="employment_type" HeaderText="Employment Type" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="apprenticeship" HeaderText="Apprenticeship" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="undertaking_selfemployed" HeaderText="Undertaking for self-employed collected from the trainee"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="proof_upskill" HeaderText="Proof of upskilling provided" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="proof_type" HeaderText="Type of proof" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="joining_date" HeaderText="Date of Joining"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="employer_name" HeaderText="Employer Name Or Self-Employed" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="employer_person_name" HeaderText="Employer Contact Person Name" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="employer_person_designation" HeaderText="Employer Contact Person Designation"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="employer_contactno" HeaderText="Employer contact number" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="employer_state" HeaderText="Location of Employer State" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="employer_district" HeaderText="Location of Employer District"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="employer_feedback" HeaderText="Feedback Collected from Employer" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="employer_freq_feedback" HeaderText="Frequency of feedback" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="work_state" HeaderText="State of placement/work"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="work_district" HeaderText="District of placement / work" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="CTC_before_training" HeaderText="Monthly Earning/CTC before Training" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="current_CTC" HeaderText="Monthly Current CTC / earning
"   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="poverty_line" HeaderText="Below Poverty Line" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="annual_income" HeaderText="Annual Household income" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="passport_no" HeaderText="Passport Number"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="passport_validity" HeaderText="Validity Date" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="skilling_category" HeaderText="Skilling Category " >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="fund_source" HeaderText="Source of Funding "   >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="bank_name" HeaderText="Bank Name" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
         <asp:BoundField ItemStyle-Width="150px" DataField="bank_branch_name" HeaderText="Branch Address" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="ifsc_code" HeaderText="IFSC Code"    >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="50px" DataField="bank_account_no" HeaderText="Bank Account Number" >       
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
          <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkBtnEdit"  CommandName ="CEdit" CommandArgument ='<%#Eval("enrollment_no")%>' runat="server" Font-Underline="True">Edit</asp:LinkButton>
                                       </ItemTemplate>
         </asp:TemplateField>
        </Columns>
       
    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        </asp:GridView>
        </div>
        <i style="font-style: normal">You are viewing page 
        <%=GridView1.PageIndex + 1%> of  <%=GridView1.PageCount%>
        </i>
       
    <asp:HiddenField  ID="hf_centreID" runat="server"/>
   </asp:Content>
