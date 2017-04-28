<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndividualRating.aspx.cs" Inherits="superadmin_Viewstudentpersonaldetails" %>

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
</head>
<body>
   <form id="form1" runat="server">
      
        <table class="common" > 
            <tr>
                <td colspan="3" style=" padding:0px; height: 43px;"><h4>
                    Individual Rating</h4>  
                </td>
            </tr>
            <tr>
            <td>
            <asp:GridView CssClass="common" ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                      <asp:BoundField DataField="communication" HeaderText="Communication Skill of the Faculty" />  
                          <asp:BoundField DataField="clarify" HeaderText="Ability to Clarify Doubts" />  
                            <asp:BoundField DataField="extra_assignments" HeaderText="Whether Extra Assignments Were Given" />  
                                         <asp:BoundField DataField="feedback_assignments" HeaderText="Whether Feedback for the Assignments has been Given" />  
                                               <asp:BoundField DataField="pace_class" HeaderText="Pace of Taking Class" />  
                                                          <asp:BoundField DataField="interaction" HeaderText="	Interaction in the Class" /> 
                                                                 <asp:BoundField DataField="examples" HeaderText="Were Enough Examples Used to Explain the Concepts" />  
                                                                    <asp:BoundField DataField="time" HeaderText="Usage of Class Time Effectively" /> 
                                                                      <asp:BoundField DataField="confidence_level" HeaderText="Your Confidence Level" /> 
                                                                      <asp:BoundField DataField="suggestion" HeaderText="Suggestions" />      
                                                                              
                </Columns>
        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" />
            </asp:GridView>
            
        
            </td>
            </tr>
        </table>

    
    </form>
</body>
</html>
