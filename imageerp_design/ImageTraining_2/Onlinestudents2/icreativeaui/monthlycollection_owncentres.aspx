<%@ Page Language="C#" MasterPageFile="1imagemasterpage.master" AutoEventWireup="true" CodeFile="monthlycollection_owncentres.aspx.cs" Inherits="monthlycollection_owncentres" Title="Centerwise Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }
        function clearValidation(fieldList) {

            var field = new Array();
            field = fieldList.split("~");
            var counter = 0;
            for (i = 0; i < field.length; i++) {
                if (document.getElementById(field[i]).value != "") {
                    document.getElementById(field[i]).style.border = "#999999 1px solid";
                    document.getElementById(field[i]).style.backgroundColor = "#e8ebd9";
                }
            }

        }

        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (String.fromCharCode(keyEntry).match(/^[a-zA-Z]+$/) || keyEntry == 8 || keyEntry == 32 || keyEntry == 0) {
                return true;
            }
            else {
                return false;
            }
        }

        function sortval1() {

            var start = document.getElementById("ContentPlaceHolder1_txtfromcalender1").value;
            var end = document.getElementById("ContentPlaceHolder1_txttocalender1").value;

            var start_s = start.split("-");
            var end_s = end.split("-");

            //        if(start_s[0]<10)
            //        {
            //        start_s[0]=0+start_s[0];
            //        }

            var stDate = start_s[2] + start_s[1] + start_s[0];
            //        if(end_s[0]<10)
            //        {
            //        end_s[0]=0+end_s[0];
            //        }
            var enDate = end_s[2] + end_s[1] + end_s[0];

            var d = new Date();
            var curr_date = d.getDate();

            //alert(curr_date);
            if (curr_date < 10) {
                curr_date = '0' + curr_date;
            }

            var curr_month = d.getMonth();
            curr_month++;
            var curr_year = d.getFullYear();
            var mon = (curr_month < 10 ? '0' : '') + curr_month
            var toDate = parseInt(curr_year + '' + mon + '' + curr_date);

            var compDate = enDate - stDate;
            var csDate = stDate - toDate;
            //alert(stDate);
            //alert(toDate);
            //alert(csDate);
            //clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


            if (trim(document.getElementById("ContentPlaceHolder1_txtfromcalender1").value) == "") {
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").value == "";
                alert("Please select the From date");
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor = "#e8ebd9";

                return false;
            }
            else if (csDate > 0) {
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").value == "";
                alert("Please select valid From date");
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").focus();
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txtfromcalender1").style.backgroundColor = "#e8ebd9";
                return false;
            }
            else if (trim(document.getElementById("ContentPlaceHolder1_txttocalender1").value) == "") {
                document.getElementById("ContentPlaceHolder1_txttocalender1").value == "";
                alert("Please select the To date");
                document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
                document.getElementById("ContentPlaceHolder1_txttocalender1").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor = "#e8ebd9";
                return false;
            }
            else if (compDate < 0) {
                document.getElementById("ContentPlaceHolder1_txttocalender1").value == "";
                alert("Please select valid To date");
                document.getElementById("ContentPlaceHolder1_txttocalender1").focus();
                document.getElementById("ContentPlaceHolder1_txttocalender1").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txttocalender1").style.backgroundColor = "#e8ebd9";
                return false;
            }
            else if (document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "") {
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "";
                alert("Please select centre code");
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor = "#e8ebd9";
                return false;
            }
            //          else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
            //         {
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
            //             alert("Please select centre code");
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
            //             return false;
            //         }
            else {
                return true;
            }
        }

        function sortval2() {

            var start = document.getElementById("ContentPlaceHolder1_txtfromcalender2").value;
            var end = document.getElementById("ContentPlaceHolder1_txttocalender2").value;

            var start_s = start.split("-");
            var end_s = end.split("-");

            var stDate = start_s[2] + start_s[1] + start_s[0];
            var enDate = end_s[2] + end_s[1] + end_s[0];

            var d = new Date();
            var curr_date = d.getDate();
            if (curr_date < 10) {
                curr_date = '0' + curr_date;
            }
            var curr_month = d.getMonth();
            curr_month++;
            var curr_year = d.getFullYear();
            var mon = (curr_month < 10 ? '0' : '') + curr_month
            var toDate = parseInt(curr_year + '' + mon + '' + curr_date);

            var compDate = enDate - stDate;
            var csDate = stDate - toDate;
            //alert(csDate);
            //clearValidation('ContentPlaceHolder1_txtfromcalender1~ContentPlaceHolder1_txttocalender1');


            if (trim(document.getElementById("ContentPlaceHolder1_txtfromcalender2").value) == "") {
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").value == "";
                alert("Please select the From date");
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor = "#e8ebd9";

                return false;
            }
            else if (csDate > 0) {
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").value == "";
                alert("Please select valid From date");
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").focus();
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txtfromcalender2").style.backgroundColor = "#e8ebd9";
                return false;
            }
            else if (trim(document.getElementById("ContentPlaceHolder1_txttocalender2").value) == "") {
                document.getElementById("ContentPlaceHolder1_txttocalender2").value == "";
                alert("Please select the To date");
                document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
                document.getElementById("ContentPlaceHolder1_txttocalender2").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor = "#e8ebd9";
                return false;
            }
            else if (compDate < 0) {
                document.getElementById("ContentPlaceHolder1_txttocalender2").value == "";
                alert("Please select valid To date");
                document.getElementById("ContentPlaceHolder1_txttocalender2").focus();
                document.getElementById("ContentPlaceHolder1_txttocalender2").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_txttocalender2").style.backgroundColor = "#e8ebd9";
                return false;
            }
            else if (document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "") {
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").value == "";
                alert("Please select centre code");
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border = "#ff0000 1px solid";
                document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor = "#e8ebd9";
                return false;
            }
            //          else if(document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="")
            //         {
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").value=="";   
            //             alert("Please select centre code");
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").focus();
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.border="#ff0000 1px solid";
            //             document.getElementById("ContentPlaceHolder1_ddl_centrcode").style.backgroundColor="#e8ebd9";
            //             return false;
            //         }
            else {
                return true;
            }
        }



    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                jQuery(".datepicker1").datepicker({ showOn: 'both', buttonImage: 'layout/calendar.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'dd-mm-yy', yearRange: '1970:2020' });
            }

        });
    </script>

    <style type="text/css">
        .overlay
        {
          position: fixed;
          z-index: 98;
          top: 0px;
          left: 0px;
          right: 0px;
          bottom: 0px;
            background-color: #fff;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .overlayContent
        {
          z-index: 99;
          margin: 250px auto;
          width: 80px;
          height:80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        
        .style1
        {
            width: 83px;
        }
        .tbl {
    border-collapse: collapse;
    width:100%;
}

.tbl td {
    border: 1px solid black;
    text-align: center;
}
.tbl th {
    border: 1px solid black;
}
    </style>
     <div class="title-cont">
    <h3 class="cont-title">
                
                        View Monthly Collection Report(Own Centres) </h3>
          <%-- <div class="breadcrumps">
      <ul>
        <li><a href="DashboardV2.aspx">Dashboard</a>/</li>
        <li><a>Reports</a>/</li>
        <li><a href="monthlycollection_owncentres.aspx" class="last">View Monthly Collection Report</a></li>
      </ul>
    </div>
    <div class="clear"></div>--%>
  </div>
    <div class="search-sec-cont">
         <ul>
             <li  class="date-sec-cont">
<div class="wth-1">Date From</div>
        <div class="wth-2">  <span class="date-pick-cont"> <asp:TextBox ID="txtfromcalender2" onkeypress="return false" onkeydown="return false"
                        onpaste="return false" runat="server" Width="92px" CssClass="text datepicker date-input-txt"></asp:TextBox></span>
            </div>
                
           
               
              
             
<div class="wth-3"> To</div>
        <div class="wth-2">  <span class="date-pick-cont"><asp:TextBox ID="txttocalender2" onkeypress="return false" onkeydown="return false"
                        onpaste="return false" runat="server" Width="92px" CssClass="text datepicker date-input-txt"></asp:TextBox> </span>
            </div>
                
           
               
             
                  
              </li>       

                   
                <li>    

                    <asp:Button ID="btnsort1" OnClick="btnsort1_Click" runat="server" Text="Search" CssClass="search-btn" 
                        OnClientClick="javascript:return sortval2();"></asp:Button>
 
                </li>
             </ul>
    
      <div class="clear"></div>
    <div align="center">
             
        </div>



  </div>
        <div class="white-cont" >       
            <div  id="wrap" runat="server" width="100%">
                <table  class="tbl-cont3" width="100%">
                    <tbody>
                        <tr >
                        <th>
                                S.No
                            </th>
                            <th>
                                Centre Name
                            </th>
                         <th>
                                Fresh Collection
                            </th> 
                            <th>
                                Registration
                            </th> 
                            <th>
                                Regular Collection
                            </th> 
                            <th>
                                Others(Late,Break etc)
                            </th>
                            <th>
                                Total amount
                            </th>
                        </tr>
                       
                        <%=getfeesdetails()%>
                    </tbody>
                </table>
                </div>
             <div align="center" style="padding:10px 10px 0px 10px;">  
             <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="download-btn" runat="server">Download Excel</asp:LinkButton>
             </div>
        </div>
     
 
  
  
       
   
</asp:Content>

