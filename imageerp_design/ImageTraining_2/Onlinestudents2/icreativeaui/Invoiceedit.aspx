<%@ Page Language="C#" MasterPageFile="Ipadmasterpage.master" AutoEventWireup="true" CodeFile="Invoiceedit.aspx.cs" Inherits="superadmin_Invoiceedit" Title="Invoice Edit Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function fun(e,fcheck)   
  {   
  	  var unicode=e.charCode? e.charCode : e.keyCode
	  var check = fcheck;
	  if (unicode!=8) {
		  if(unicode<48 || unicode>58 || (check.length==0 && unicode==48))   
		  return false; 
	  }
  }
  function Gridval()
  {
  //alert("True");
     var count=0;
     var count1=0;
     var lengthcount=parseInt(document.getElementById("ContentPlaceHolder1_Hidden2").value)+2;
     
     var amountentered=0;
   for(var i=1;i<lengthcount;i++)
   {
     var mon =  (i < 10 ? '' : '') + i 
     //alert(mon);
       count=count+1;
//      alert(document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").value);
//      return false;
//       alert(document.getElementById("ContentPlaceHolder1_lblcoursefee").innerHTML);
    if(document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").value == "")
      {
         alert("Please Enter the amount");
         document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").focus();
         return false;
       }
            
   else if(parseInt(document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").value) < 1)
      {
         alert("Installment amount cannot be zero or lessthan zero delete that installment");
         document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").focus();
         return false;
       }
       else if(parseInt(document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").value) > parseInt(document.getElementById("ContentPlaceHolder1_lblcoursefee").innerHTML))
      {
         alert("Installment amount cannot be greateer than course fees");
         document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").focus();
         return false;
       }
     else
       {
        // amountentered=amountentered+(parseInt(document.getElementById("ContentPlaceHolder1_GridView1_txtupdinstal_"+mon+"").value);
         
         count1=count1+1;
        } 
        
       
   
   }
  
  }
  
  
          </script>


    <input id="Hidden1" type="hidden" runat="server" />
      <input id="Hidden2" type="hidden" runat="server" />
<table class="common" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid black; margin: 12px auto;">
	<tr>
	<td>
	<table  class="common"  border="0"  cellpadding="0" cellspacing="0">
	 
	  <tr>
		<td  style="text-align:center; padding:0px; font-size:22px; height: 21px;"><h3 style="font-size: 20px; margin:0px;  color:white">   
            INVOICE</h3></td>
	  </tr>
	  <tr>
		<td style="text-align: center; padding-top:10px;">
           
            <img src="../layout/image_logo.jpg" alt="Image" width="178" height="90" /></td>
	  </tr>
	    <tr>
		<td><table style="margin:auto; width:286px;" >
		<tr><td ><div style="color: blue;"><span style="font-size:22px;">Image Infotainment Limited</span> </div></td>
		</tr><tr><td ><div>Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.</div></td></tr><tr><td ><div style="text-align:center;">Phone:044-24661682/24670229</div></td></tr></table>		</td>
	  </tr>
	
	  <tr><td>

	  <table >
	   <tr><td colspan="4" style="text-align: center;" ><b>
           <asp:Label ID="lblerrmsg" CssClass="error" runat="server" Text=''></asp:Label></b></td>
	  </tr> 
	    <tr><td style="width: 110px" >Student Name:</td>
	  <td  colspan="3"><b>
          <asp:Label ID="lblstudname" runat="server" Text=''></asp:Label></b></td>
	  </tr> <tr>
    <td style="width: 110px">Address :</td>
    <td colspan="3">
        <asp:Label ID="lbladdress" runat="server" Text=''></asp:Label></td>
  </tr>
         
          <tr>
              <td style="width: 110px">
                  Course Name:
              </td>
              <td>
                  <asp:Label ID="lblcoursecode" runat="server" Text=''></asp:Label></td>
              <td style="width: 158px">
                  Track:</td>
              <td>
              <asp:Label ID="lbltrack" runat="server" Text=''></asp:Label>
              </td>
          </tr>
          <tr>
              <td style="width: 110px">
                  Course ID :</td>
              <td>
                  <asp:Label ID="lblcourse_id" runat="server" Text=''></asp:Label></td>
              <td style="width: 158px">
                  Batch Time:</td>
              <td>
                  <asp:Label ID="lblbatchtime" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 110px">
                  Center:</td>
              <td>
                  <asp:Label ID="lblcentre" runat="server" Text=''></asp:Label></td>
              <td style="width: 158px">
                  Course Fees:</td>
              <td>
                  <asp:Label ID="lblcoursefee" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 110px">
                  Student ID No. :</td>
              <td>
                  <asp:Label ID="lblstudid" runat="server" Text=''></asp:Label></td>
              <td style="width: 158px">
                  No of Installments:</td>
              <td>
                  <asp:Label ID="lblnoofinstal" runat="server" Text=''></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 110px">
                  Invoice Number</td>
              <td>
                  <asp:Label ID="lblinvoiceno" runat="server" Text=''></asp:Label></td>
              <td style="width: 158px">Payment pattern
              </td>
              <td><asp:Label ID="lblpaymentpattern" runat="server" Text=''></asp:Label>
              </td>
          </tr>
      </table></td></tr>
	   <tr><td style=" text-align:center">
	    <asp:GridView   ID="GridView1" runat="server"  AutoGenerateColumns="False" BorderColor="#AEAEAE" BorderWidth="1px" BorderStyle="Solid" OnRowCommand="GridView1_RowCommand">
               <Columns>
                   <asp:TemplateField HeaderText="Installment no"><ItemTemplate>
                    <%#Eval("instal_number")%>
                   </ItemTemplate></asp:TemplateField>
                   <asp:TemplateField HeaderText="Installment date" ><ItemTemplate> <%#Eval("install_date")%></ItemTemplate></asp:TemplateField>
                   <asp:TemplateField HeaderText="Amount to be paid"><ItemTemplate>
                       <asp:TextBox ID="txtupdinstal" Width="60px" runat="server" onkeypress="return fun(event,this.value);" MaxLength="6" Text='<%#Eval("initialamount")%>'></asp:TextBox><asp:Label
                           ID="hdnAdjuststatus" Visible="false" runat="server" Text='<%#Eval("initialamount")%>'></asp:Label></ItemTemplate></asp:TemplateField>
                   <asp:TemplateField HeaderText="Tax"><ItemTemplate><%#Eval("initialamout_tax")%></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Totalamount"><ItemTemplate><%#Eval("totinitialamt_tax")%></ItemTemplate></asp:TemplateField>
                   <asp:TemplateField HeaderText="Receipt No"><ItemTemplate><%#Eval("Receipt_no")%></ItemTemplate></asp:TemplateField>
                   <asp:TemplateField HeaderText="Amount Paid"><ItemTemplate><%#Eval("tatamtpaidwithtax")%>
                       <asp:Label ID="hdnamtpaid" Visible="false" runat="server" Text='<%#Eval("tatamtpaidwithtax")%>'></asp:Label></ItemTemplate></asp:TemplateField>
                   <asp:TemplateField HeaderText="Action"><ItemTemplate>
                     
                       <asp:LinkButton ID="lnkdelete" CommandArgument='<%#Eval("instal_number")%>' CommandName='lnkdel' OnClientClick="javascript:return confirm('Are you sure of Deleting the Installment')" runat="server"><img src="../layout/delete.png" alt="Delete" /></asp:LinkButton>   
                       <asp:Label ID="hdnlbl" runat="server" Visible="False" Text='<%#Eval("instal_number")%>'></asp:Label>
                   </ItemTemplate></asp:TemplateField>
                   
                  
               </Columns>
           </asp:GridView>
        
          
	</td></tr>
	<tr><td>
        </td></tr>
	  <tr>
	    <td><table class="common" cellpadding="0" cellspacing="0" align="center">
          <tr>
            <td colspan="8"><table  border="0"  cellspacing="0" >
                <tr>
                  <td><table  border="0"cellpadding="0">
                      <tr>
                        <td>
                            <table border="0" cellspacing="0">
                              <tr>
                                <td><table>
                                </table></td>
                              </tr>
                              <tr>
                                <td></td>
                              </tr>
                              <tr>
                                <td></td>
                              </tr>
                              <tr>
                                <td><strong>Student  Signature</strong></td>
                              </tr>
                          </table>
                            &nbsp;</td>
                        <td style="width: 310px"></td>
                        <td style="text-align:right"><table border="0" cellspacing="0">
                            <tr>
                              <td>For <strong>Image Infotainment Limited</strong>
                                  <table>
                                </table></td>
                            </tr>
                            <tr>
                              <td></td>
                            </tr>
                            <tr>
                              <td><strong>Authorised Signatory</strong></td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                </tr>
            </table>
                <table  class="common" border="0" >
                    <tr>
                        <td style="text-align: center;">
                            <asp:Button ID="Button1" runat="server" CssClass="submit" OnClick="Button1_Click"
                                Text="Insert Installments" />&nbsp;<asp:Button ID="Button3" OnClientClick="javascript:return Gridval();" runat="server" CssClass="submit"
                                    OnClick="Button3_Click1" Text="Update" />
                            <asp:Button ID="Button2" runat="server" CssClass="submit" Text="Continue" OnClientClick="javascript:return Gridval();" OnClick="Button2_Click"  /></td>
                    </tr>
                </table>
            </td>
          </tr>
        </table></td>
	  </tr>
	</table>
        <asp:HiddenField ID="hdninvoiceID" runat="server" />
	</td>
	</tr>
</table>
</asp:Content>

