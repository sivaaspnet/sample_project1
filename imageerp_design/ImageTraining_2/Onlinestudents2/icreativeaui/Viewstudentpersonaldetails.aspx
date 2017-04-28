<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewstudentpersonaldetails.aspx.cs" Inherits="superadmin_Viewstudentpersonaldetails" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Student Info</title>
<link href="styles/main.css" type="text/css" rel="stylesheet" media="all" />
<script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" src="scripts/jquery.prettyPhoto.js"></script>
<script type="text/javascript">
function onFileLoad(e) { 

    jQuery('#preview').html('<img height="100px" width="100px" src="'+e.target.result +'"/>'); 
 
}
function displayPreview(files) 
{
    var reader = new FileReader();
    reader.onload = onFileLoad;
    reader.readAsDataURL(files[0]);

}
</script>
<style>
.form-cont ul li .label-txt {
	width:29%;
}
</style>
</head>
<body>
<div class="white-cont2">
  <form id="form1" runat="server">
    <h4 class="cont-title4 no-mrg">Student Information</h4>
    <div class="form-cont" style="padding:12px;">
      <div class="pro-img">
        <asp:Image ID="Image1" runat="server"/>
      </div>
      <ul style="padding:20px 0px 0px 0px;">
        <li>
          <label class="label-txt">Student Name:</label>
          <asp:Label ID="lblstu_name" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt">Mobile:</label>
          <asp:Label ID="lbl_stumobile" runat="server" CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt">E-Mail:</label>
          <asp:Label ID="lbl_stuemail" runat="server" CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <asp:Label ID="Label1" runat="server" Text="Student Photo:" CssClass="label-txt"></asp:Label>
          <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="#d1d1d1" BorderStyle="Solid" BorderWidth="1px" CssClass="input-txt" onchange="displayPreview(this.files);" Width="180px" />
          &nbsp;
          <asp:Button ID="Button1" runat="server" CssClass="btnStyle5" OnClick="Button1_Click" Text="Upload" />
          <br />
          <span id="preview">
          <asp:Label ID="Label2" runat="server" Visible="False" CssClass="label-txt2"></asp:Label>
          </span></li>
        <li>
          <label class="label-txt">Qualification Details:</label>
          <div class="dataGrid fl-lt" style="width:50%">
            <table border="1">
              <tr>
                <th>Highest Qualification</th>
                <th>Institution</th>
                <th>City</th>
                <th>State</th>
              </tr>
              <tr>
                <td><asp:Label ID="lblprimary" runat="server" Text=''></asp:Label></td>
                <td><asp:Label ID="lblstu_tenthinsti" runat="server" Text=''></asp:Label></td>
                <td><asp:Label ID="lblstu_tenthcity" runat="server" Text=''></asp:Label></td>
                <td><asp:Label ID="lblstate" runat="server" Text=''></asp:Label></td>
              </tr>
            </table>
          </div>
        </li>
        <li>
          <label class="label-txt">Parent/Gaurdian Name:</label>
          <asp:Label ID="lblstu_parent_name" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt">Relationship:</label>
          <asp:Label ID="lblstu_parent_relation" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt">Contact Number:</label>
          <asp:Label ID="lblstu_parent_mobile" runat="server" Text='' CssClass="label-txt2"></asp:Label>
        </li>
        <li>
          <label class="label-txt">Contact Address:</label>
          <div class="dataGrid fl-lt" style="width:50%">
            <table border="1">
              <tr>
                <td style="background:#f5f5f5; width:45px;">Address</td>
                <td><asp:Label ID="lbl_stu_addr" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr>
                <td style="background:#f5f5f5;">District</td>
                <td><asp:Label ID="lbl_stu_dist" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr>
                <td style="background:#f5f5f5;">City</td>
                <td><asp:Label ID="lbl_city" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr>
                <td style="background:#f5f5f5;">State</td>
                <td><asp:Label ID="lbl_stu_state" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr>
                <td style="background:#f5f5f5;">Pin</td>
                <td><asp:Label ID="lbl_stu_pin" runat="server" Text=''></asp:Label></td>
              </tr>
            </table>
          </div>
        </li>
        <li>
          <label class="label-txt">Student type:</label>
          <div class="dataGrid fl-lt" style="width:50%">
            <table border="1">
              <tr>
                <td id="ctyname" visible="true" runat="server" style="background:#f5f5f5; width:45px;"> Country</td>
                <td><asp:Label ID="lbl_Country" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr id="ctyres" visible="false" runat="server">
                <td style="background:#f5f5f5;"><span id="ctl00_ContentPlaceHolder1_lblcountry">Country of residence</span></td>
                <td><asp:Label ID="lbl_Countryresidence" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr id="ctypass" visible="false" runat="server">
                <td style=" background:#f5f5f5;"> Passport No</td>
                <td><asp:Label ID="lblPassport" runat="server" Text=''></asp:Label></td>
              </tr>
              <tr id="ctyplace" visible="false" runat="server">
                <td style="background:#f5f5f5;"><span id="ctl00_ContentPlaceHolder1_lblplace">Place of Issue</span></td>
                <td><asp:Label ID="lblplace" runat="server" Text=''></asp:Label></td>
              </tr>
            </table>
          </div>
        </li>
      </ul>
      <div class="clear"></div>
    </div>
    <asp:HiddenField ID="hdnENQID" runat="server" />
  </form>
</div>
</body>
</html>
