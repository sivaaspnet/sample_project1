<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<title>Franchisee | IMAGE - Institute of Multimedia Arts &amp; Graphic Effects</title>
<meta name="description" content="IMAGE offers Degree in Multimedia Diploma / Certificate programs in 3D animation, Visual Effects, E-learning and Mobile Gaming." />
<meta name="keywords" content="franchise opportunities, business franchise opportunities, top 10 best franchises, new franchise opportunities, small business franchise opportunities, computer franchise opportunities, top franchise opportunities, international franchise opportunity, best franchise opportunities, franchise opportunity, franchise opportunities guide, best franchise opportunity, small business franchise opportunity, build online business, how to build a business online, build your business online, how to take a franchise, how to take franchise, internet business franchise, small business franchise opportunities, small business franchise, business franchises, business to business franchise, business opportunity in india, who to start a business, starting business in india, new business in india, business opportunity, business opportunities, small business opportunities, franchise business opportunity, new franchise business opportunity, franchise businesses, franchise business for sale, best franchise business, franchise business financing, franchising business, buy a franchise, franchise trade shows, purchase franchise, education franchise, technology franchise, design franchise, educational franchise, information technology franchise," />
<!-- #include file="includes/scripts.asp" -->
<style>
.right_courses {
    width: 260px;
}
.w180 {
    width: 205px;
}
input[type="text"], input[type="password"], select, textarea, input[type="submit"] {
    margin-left: 12px !important;

}
.enqCourses .trow {
    padding: 0 10px;
}
</style>
<script type="text/javascript">
function RefreshImage(valImageId) {
	var objImage = document.images[valImageId];
	if (objImage == undefined) {
		return;
	}
	var now = new Date();
	objImage.src = objImage.src.split('?')[0] + '?x=' + now.toUTCString();
	return false;
}
function getHTTPObject()
{
	if (window.ActiveXObject) 
		return new ActiveXObject("Microsoft.XMLHTTP");
	else if (window.XMLHttpRequest) 
		return new XMLHttpRequest();
	else 
	{
		alert("Your browser does not support AJAX.");
		return null;
	}
}
function doWork()
{
	httpObject = getHTTPObject();
	if (httpObject != null) 
	{
		var date=new Date();
		httpObject.open("GET", "chkCaptcha.asp?datetime="+date + "&vCode="+document.getElementById('txtVcode').value, true);
		httpObject.send(null);
		httpObject.onreadystatechange = setOutput;
	}
}
function setOutput()
{

	if(httpObject.readyState == 4)
	{
		var res=httpObject.responseText;
		
		if(res=="T")
		{
		    
			
			document.frm.action="franchisee_new.asp"
			document.frm.submit();
		}
		else
		{
			RefreshImage('imgCaptcha');
			alert("Invalid verification code");
			document.frm.txtVcode.value="";
			document.frm.txtVcode.focus();
			return false;
		}
		
	}
	
	
}






function validate()
{
  	var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
	var ee=document.getElementById('email').value;
	if((document.getElementById('name').value=="*Name")||(document.getElementById('name').value==""))
	{
		alert("Name Required");
		document.getElementById('name').focus();
		document.getElementById('name').value="";
		return false;
	}
	else if((document.getElementById('email').value=="*Email ID")||(document.getElementById('email').value==""))
	{
		alert("Email Required");
		document.getElementById('email').focus();
		document.getElementById('email').value="";
		return false;
	}
	else if(document.getElementById('email').value!="" && ee.search(emailRegEx) == -1)
	{
	
	
	
		alert("Please enter a valid email address.");
		document.getElementById('email').focus();
		document.getElementById('email').value="";
		return false;
	
	}	
	
	else if((document.getElementById('contact').value=="*Contact Number")||(document.getElementById('contact').value==""))
	{
		alert("Contact no Required");
		document.getElementById('contact').focus();
		document.getElementById('contact').value="";
		return false;
	}
	else  if(document.getElementById('contact').value!="" && isNaN(document.getElementById('contact').value))
	{
	 
		alert("Must be Valid Contact number");
		document.getElementById('contact').focus();
		document.getElementById('contact').value="";
		return false;
	} 
	else if((document.getElementById('city').value=="*City")||(document.getElementById('city').value==""))
	{
		alert("City Required");
		document.getElementById('city').focus();
		document.getElementById('city').value="";
		return false;
	}
	else if((document.getElementById('state').value=="*State")||(document.getElementById('state').value==""))
	{
		alert("State Required");
		document.getElementById('state').focus();
		document.getElementById('state').value="";
		return false;
	}
	
	else if((document.getElementById('organization').value=="*Organization")||(document.getElementById('organization').value==""))
	{
		alert("Organization Required");
		document.getElementById('organization').focus();
		document.getElementById('organization').value="";
		return false;
	}
	else  if((document.getElementById('designation').value=="*Designation")||(document.getElementById('designation').value==""))
	{
		alert("designation Required");
		document.getElementById('designation').focus();
		document.getElementById('designation').value="";
		return false;
	}
	
	else if((document.getElementById('txtVcode').value==""))
	{
		alert("Captcha Required");
		document.getElementById('txtVcode').focus();
		document.getElementById('txtVcode').value="";
		return false;
	}
	
	else
	{
		doWork();
  	return false;
	}
return false;
}

function statechange()
{
document.getElementById("fstate").value=document.getElementById("select1").value;

}




function franchisee()
{
		document.getElementById("frachisee").style.display="none";
		document.getElementById("ostate").style.display="none";
		
	if(document.frm.Select_Course[0].checked==true)
	{

		document.getElementById("ostate").style.display="block";
		document.getElementById("frachisee").style.display="none";
		document.getElementById("fcountry").value="India"
		 
	}
	else if(document.frm.Select_Course[1].checked==true)
	{
	
		document.getElementById("frachisee").style.display="block";
		document.getElementById("ostate").style.display="none";
		document.getElementById("fcountry").value=""
	}
	
	else
	{
		

	 
	}
}

</script>

</head>
<body>
<div class="wrapper">
  <!-- #include file="includes/header.asp" -->
  <!-- #include file="includes/menu.asp" -->
  <div class="container">
    <div class="section">
      <div class="left">
        <div class="breadcrumbs"> <a href="index.asp">Home</a> <a class="current">Franchise</a> </div>
        <h3 class="section_title">Franchise</h3>
        <img src="images/franchisee.jpg" alt="" class="imgStyle" />
        <p class="text_big">Welcome to Own an Image Digital Media Training Center!</p>
        <p>Image believes that growth can be successfully achieved through partnership and alliances. It offers unique partnership opportunity to those interested in making a successful and profitable future.</p>
        <p><strong>Come join hands, to</strong>:</p>
        <ul class="list_tick left10">
          <li>Be an entrepreneur</li>
          <li>Hold personal independence</li>
          <li>Gain superior earning potential</li>
          <li>Shape the careers of aspiring individuals</li>
        </ul>
        <div class="blank_space"></div>
        <h3 class="blue_text">Why Invest in Creative Media Industry:</h3>
        <ul class="list_dot left10">
          <li>One of the fastest Growing Industry</li>
          <li>Creative Industry required around 30 lakh people by 2022 </li>
          <li>The Media and Entertainment Market expected to grow to 1.2 lakh Crores by 2015 growing at 13.2%  p.a. </li>
          <li>Creative courses are well recognized by the students and unemployed people community.</li>
          <li>It is immediate alterative to IT and ITES. </li>
          <li>Well balanced reputed and legitimate career for unemployed youth.</li>
        </ul>
        <div class="blank_space"></div>
 
        
        
        <h3 class="blue_text">Product Portfolio</h3>
        <ul class="list_tick">
            <li class="menu_title"><a href="courses-bsc-multimedia.asp">U.G. Courses</a></li>
            <li class="menu_title"><a href="courses-diploma-programs.asp">Diploma Courses</a></li>
            <li><a href="courses-certificate-courses.asp">Certificate Courses</a></li>
            <li><a href="corporate-training.asp">Corporate Training</a></li>
          </ul>
        
        </div>
      <div class="right">
        <form  method="post" name="frm" onSubmit="return validate()">
  <div class="right_courses">
    <div class="box enqCourses" style="border:1px solid #ccc;">
      <h3 class="box_title">Enquiry Form</h3>
      <div class="trow">
        <input name="name" type="text" id="name" class="round_corner w180" Placeholder="Name*" />
      </div>
      <div class="trow">
        <input name="email" type="text" id="email" class="round_corner w180" Placeholder="Email ID*"/>
      </div>
      <div class="trow">
        <input name="contact" id="contact" onKeyPress="return CheckNumeric(event)" type="text" class="round_corner w180" maxlength="13" Placeholder="Contact Number*"/>
      </div>
      <div class="trow">
        <input name="city" id="city"  type="text" class="round_corner w180" Placeholder="City*"/>
      </div>
      <div class="trow">
        <input name="state" id="state"  type="text" class="round_corner w180" Placeholder="State*"/>
      </div>
      <div class="trow">
        <input name="organization" id="organization"  type="text" class="round_corner w180" Placeholder="Organisation*"/>
      </div>
      <div class="trow">
        <input name="designation" id="designation"  type="text" class="round_corner w180" Placeholder="Designation*"/>
      </div>
      
      <div class="trow" style="padding-left:14px;">
<h3 class="blue_text" style="border-bottom:1px groove #999999;padding-bottom:0;font-size:12px;">Franchise location</h3>


 </div>
      
      
      
      <div class="trow" style="padding-left:25px;">
        <input type="radio" class="checkbox" checked="checked"  onClick="franchisee();" value="INDIA" id="" name="Select_Course">
        
India&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" class="checkbox" onClick="franchisee();" value="Other region" id="" name="Select_Course">Other region </div>
      
      
      
      <div class="trow" id="ostate" >
        <div id="Diploma_Course_Display">
          <div>
          <select class="select_default" name="states" id="select1" onchange="statechange()" style="width:213px;">
                    <option value="">Select State</option>
                <option value="Andra Pradesh">Andra Pradesh</option>
                <option value="Arunachal Pradesh">Arunachal Pradesh</option>
                <option value="Assam">Assam</option>
                <option value="Bihar">Bihar</option>
                <option value="Chhattisgarh">Chhattisgarh</option>
                <option value="Goa">Goa</option>
                <option value="Gujarat">Gujarat</option>
                <option value="Haryana">Haryana</option>
                <option value="Himachal Pradesh">Himachal Pradesh</option>
                <option value="Jammu and Kashmir">Jammu and Kashmir</option>
                <option value="Jharkhand">Jharkhand</option>
                <option value="Karnataka">Karnataka</option>
                <option value="Kerala">Kerala</option>
                <option value="Madya Pradesh">Madya Pradesh</option>
                <option value="Maharashtra">Maharashtra</option>
                <option value="Manipur">Manipur</option>
                <option value="Meghalaya">Meghalaya</option>
                <option value="Mizoram">Mizoram</option>
                <option value="Nagaland">Nagaland</option>
                <option value="Orissa">Orissa</option>
                <option value="Punjab">Punjab</option>
                <option value="Rajasthan">Rajasthan</option>
                <option value="Sikkim">Sikkim</option>
                <option value="Tamil Nadu">Tamil Nadu</option>
                <option value="Tripura">Tripura</option>
                <option value="Uttaranchal">Uttaranchal</option>
                <option value="Uttar Pradesh">Uttar Pradesh</option>
                <option value="West Bengal">West Bengal</option>
                <option value="Andaman and Nicobar Islands">Andaman and Nicobar Islands</option>
                <option value="Chandigarh">Chandigarh</option>
                <option value="Dadar and Nagar Haveli">Dadar and Nagar Haveli</option>
                <option value="Daman and Diu">Daman and Diu</option>
                <option value="Delhi ">Delhi </option>
                <option value="Lakshadeep">Lakshadeep</option>
                <option value="Pondicherry">Pondicherry</option>
              </select>
              
              
              
              
            
          </div>
        </div>
        
        
      </div>
	  <div id="frachisee" style="display:none">
      <div class="trow">
        <input name="fcountry" id="fcountry"  type="text" class="round_corner w180" Placeholder="country"/>
      </div>
	  <div class="trow">
        <input name="fstate" id="fstate"  type="text" class="round_corner w180" Placeholder="state"/>
      </div>
     
      </div>
	   
	  
      <div class="trow">
        <input name="cities" id="cities"  type="text" class="round_corner w180" Placeholder="City"/>
      </div>
      <div class="trow"> <img src="captcha.asp" id="imgCaptcha" alt="Captcha" style="margin-left:12px;"/> </div>
      <div class="trow">
        <input name="txtVcode" id="txtVcode" type="text" class="round_corner w150" Placeholder="Verficiation code*"/>
      </div>
      <div class="trow">
        <input name="" value="Apply now" type="submit" class="btn_green float-left round_corner" style="margin-left:84px !important;margin-top:12px;"/>
      </div>
    </div>
    <!--<div class="box topMargin10 grey_border" style="width:208px">
      <h3 class="box_title">Career Support</h3>
      <ul class="list_tick">
        <li>100% Placement Assistance</li>
        <li>Industry interaction</li>
        <li>Job fairs</li>
        <li>Studio tours</li>
      </ul>
    </div>-->
    
  </div>
</form>
        <div class="box topMargin10">
          <h3 class="box_title">Why Hold a Franchisee with Image?</h3>
          <ul class="list_dot grey_border">
            <li>Well Recognized Brand</li>
            <li>Excellent Return on Investment</li>
            <li>Marketing support</li>
            <li>Expert guidance to run business</li>
            <li>Guidance in faculty recruitment</li>
            <li>Guidance in training</li>
            <li>Well-designed Courseware</li>
            <li>Centralized evaluation of students</li>
            <li>Excellent placement for students</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
  <!-- #include file="includes/footer.asp" -->
</div>
</body>
</html>
