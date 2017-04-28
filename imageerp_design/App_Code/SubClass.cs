using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
/// <summary>
/// Summary description for SubClass
/// </summary>
/// 
namespace SubMVC
{
    public class SubClass
    {
        public SubClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }



    public static class ERP_Ashok
    {
        public static void AccessDenied()
        {
            // HttpContext.Current.Request;


            // Get request.
            HttpRequest request = HttpContext.Current.Request;

            // Get UserHostAddress property.
            string address = request.UserHostAddress;



            // Write to response.
            //Response.Write(address);

            //HttpContext.Current.Response.Write(address);
            //HttpContext.Current.Response.End();

            // Done.
            string no = "118.102.129.218";
            string no1 = "122.183.188.162";



            if (no != address || no1 != address)
            {


                //Response.Redirect("Default2.aspx");
                HttpContext.Current.Response.Redirect("WrongEntry.aspx?unauthorized=yes");
            }

        }
        public static void page_restriction()
        {



            ArrayList SuperAdminLinks = new ArrayList();


            //string path;

            //path = HttpContext.Current.Request.Url.AbsolutePath;

            //string pagename = path.ToString();

            //string[] strSplitArr = pagename.Split('/');

            //string first = strSplitArr[0].ToString();
            //string second = strSplitArr[1].ToString();
            //string third = strSplitArr[2].ToString();
            //string fourth = strSplitArr[3].ToString();
            //string fifth = strSplitArr[4].ToString();


            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);

            string CurrentPageName = oInfo.Name;


            //HttpContext.Current.Response.Write(CurrentPageName);
            //HttpContext.Current.Response.End();


            if (HttpContext.Current.Session["Centrerole"] != null)
            {
                if (HttpContext.Current.Session["Centrerole"].ToString() == "SuperAdmin")
                {


                    SuperAdminLinks.Add("welcome.aspx");
                    SuperAdminLinks.Add("QuickAdmission.aspx");
                    SuperAdminLinks.Add("expressupdate.aspx");
                    SuperAdminLinks.Add("QuickEnquiry.aspx");
                    SuperAdminLinks.Add("LabDetails.aspx.aspx");
                    SuperAdminLinks.Add("ViewAdmission.aspx");
                    SuperAdminLinks.Add("Course_New.aspx");
                    SuperAdminLinks.Add("Software_Details_New.aspx");
                    SuperAdminLinks.Add("Add_Moduledetails.aspx");
                    SuperAdminLinks.Add("module_details.aspx");
                    SuperAdminLinks.Add("Moduledetails.aspx");
                    SuperAdminLinks.Add("Holiday_New.aspx");
                    SuperAdminLinks.Add("centreuserlogin.aspx");
                    SuperAdminLinks.Add("addcentre.aspx");
                    SuperAdminLinks.Add("centreuserlogin.aspx");
                    SuperAdminLinks.Add("Dashboard.aspx ");
                    SuperAdminLinks.Add("ViewEnquiry.aspx");
                    SuperAdminLinks.Add("Submodule_Details_New.aspx");
                    SuperAdminLinks.Add("ViewbatchDetails.aspx");
                    SuperAdminLinks.Add("viewbatchschedule.aspx");
                    SuperAdminLinks.Add("ViewAttendance.aspx");
                    SuperAdminLinks.Add("LabAvail.aspx");
                    SuperAdminLinks.Add("FacultyAvail.aspx");
                    SuperAdminLinks.Add("SiteStatus.aspx");
                    SuperAdminLinks.Add("balancereport.aspx");
                    SuperAdminLinks.Add("StudentReport.aspx");
                    SuperAdminLinks.Add("StudentReportDetails.aspx");
                    SuperAdminLinks.Add("outstandingreport.aspx");
                    SuperAdminLinks.Add("balancereport_old.aspx");
                    SuperAdminLinks.Add("MonthlyCollection.aspx");
                    SuperAdminLinks.Add("Dashboard.aspx");
                    SuperAdminLinks.Add("Centerwisereport.aspx");
                    //HiddenField1.Value = "Admission.aspx?Test=1";
                    //setlink.HRef = "Admission.aspx?Test=1";
                    SuperAdminLinks.Add("FacultyBatchDetails.aspx");
                    SuperAdminLinks.Add("AddInstallment.aspx");
                    SuperAdminLinks.Add("extendnewcourse.aspx");
		    SuperAdminLinks.Add("initialmonthlycollection.aspx");
            SuperAdminLinks.Add("Attendance_details.aspx");
                    //added by siva

                    SuperAdminLinks.Add("ExportOldtonew.aspx");
                    SuperAdminLinks.Add("Recommend.aspx");

                    //added by ashok

                    SuperAdminLinks.Add("CourseFeesInsert.aspx");
                    SuperAdminLinks.Add("changeoldinvoice.aspx");

                     //added by ashok

                    SuperAdminLinks.Add("Change_Receipt_Status.aspx");
                    SuperAdminLinks.Add("CreateManager.aspx");

                    //added by ashok (7_3_2012)

                    SuperAdminLinks.Add("WrongEntry.aspx");

                    //added by ashok (8_3_2012)
                    SuperAdminLinks.Add("Extendnewcourse.aspx");
                    SuperAdminLinks.Add("Dualinvoice.aspx");
                  
                   

                }
                else if (HttpContext.Current.Session["Centrerole"].ToString() == "CentreManager")
                {

                    SuperAdminLinks.Add("Recommend.aspx");
                    SuperAdminLinks.Add("Extendnewcourse.aspx");
                    SuperAdminLinks.Add("welcome.aspx");
                    SuperAdminLinks.Add("expressupdate.aspx");
                    SuperAdminLinks.Add("QuickAdmission.aspx");
                    SuperAdminLinks.Add("ViewAdmission.aspx");
                    SuperAdminLinks.Add("EnquiryType.aspx ");
                    SuperAdminLinks.Add("ViewEnquiry.aspx");
                    SuperAdminLinks.Add("AddEnquiry.aspx");
                    SuperAdminLinks.Add("TeleEnquiry.aspx");
                    SuperAdminLinks.Add("ViewAdmission.aspx");
                    SuperAdminLinks.Add("InvoiceMenu.aspx");
                    SuperAdminLinks.Add("UpdateOldStuddetails.aspx");
                    SuperAdminLinks.Add("Counselorcoursedetails.aspx");
                    SuperAdminLinks.Add("NewBatchCreation.aspx");
                    SuperAdminLinks.Add("ViewbatchDetails.aspx");
                    SuperAdminLinks.Add("AllocateBatch.aspx");
                    SuperAdminLinks.Add("ChangeBatch.aspx");
                    SuperAdminLinks.Add("Parallel_Batch.aspx ");
                    SuperAdminLinks.Add("viewbatchschedule.aspx");
                    SuperAdminLinks.Add("Editbatchschedule.aspx");
                    SuperAdminLinks.Add("LabAvail.aspx");
                    SuperAdminLinks.Add("Counselordetails.aspx");
                    SuperAdminLinks.Add("TechnicalHead.aspx");
                    SuperAdminLinks.Add("FacultydetailsNew.aspx");
                    SuperAdminLinks.Add("Facultydetails.aspx");
                    SuperAdminLinks.Add("FacultyAvail.aspx");
                    SuperAdminLinks.Add("Addlab.aspx");
                    SuperAdminLinks.Add("LabAvail.aspx");
                    SuperAdminLinks.Add("balancereport.aspx");
                    SuperAdminLinks.Add("outstandingreport.aspx");
                    SuperAdminLinks.Add("MonthlyCollection.aspx");
                    SuperAdminLinks.Add("Dashboard.aspx");
                    SuperAdminLinks.Add("balancereport_old.aspx");
                    SuperAdminLinks.Add("Centerwisereport.aspx");
                    SuperAdminLinks.Add("StudentReport.aspx");
                    SuperAdminLinks.Add("EnquiryType.aspx");
                    SuperAdminLinks.Add("Receiptdetails.aspx");
                    SuperAdminLinks.Add("breakage.aspx");
                    SuperAdminLinks.Add("breakageinvoice.aspx");
                    SuperAdminLinks.Add("breakageview.aspx");
                    SuperAdminLinks.Add("ViewAttendance.aspx");
                    SuperAdminLinks.Add("Parallel_Batch.aspx");
                    SuperAdminLinks.Add("LabDetails.aspx.aspx");

                    SuperAdminLinks.Add("StudentReportDetails.aspx");
		    SuperAdminLinks.Add("initialmonthlycollection.aspx");

                    SuperAdminLinks.Add("Invoiceprint.aspx");
                    SuperAdminLinks.Add("expressupdate.aspx");
                    SuperAdminLinks.Add("QuickEnquiry.aspx");
                    SuperAdminLinks.Add("Receiptprint.aspx");
                    SuperAdminLinks.Add("Receiptedit.aspx");
                    SuperAdminLinks.Add("InvoiceMenu.aspx");
                    SuperAdminLinks.Add("Breakageinvoice.aspx");
                    SuperAdminLinks.Add("Breakagereceipt.aspx");
                    SuperAdminLinks.Add("MonthlyCollection.aspx");
                    SuperAdminLinks.Add("balancereport.aspx");
                    SuperAdminLinks.Add("balancereport_old.aspx");
                    SuperAdminLinks.Add("TechnicalHead.aspx");
                    SuperAdminLinks.Add("FacultydetailsNew.aspx");
                    SuperAdminLinks.Add("Parallel_Batch.aspx");
                    SuperAdminLinks.Add("FacultyBatchDetails.aspx");
                    SuperAdminLinks.Add("Viewbatch.aspx");
                    SuperAdminLinks.Add("UpdateEnquiry.aspx");
                    SuperAdminLinks.Add("Thankyou.aspx");
                    SuperAdminLinks.Add("ExportOldtonew.aspx");
                    SuperAdminLinks.Add("Attendance_details.aspx");


                    SuperAdminLinks.Add("Admission.aspx");
                    SuperAdminLinks.Add("preInvoicedetail.aspx");

                    //added by ashok (7_3_2012)

                    SuperAdminLinks.Add("WrongEntry.aspx");

                    //added by ashok (8_3_2012)

                    SuperAdminLinks.Add("Dualinvoice.aspx");

                }

                else if (HttpContext.Current.Session["Centrerole"].ToString() == "Counselor")
                {

                    SuperAdminLinks.Add("Recommend.aspx");
                    SuperAdminLinks.Add("Extendnewcourse.aspx");
                    SuperAdminLinks.Add("welcome.aspx");
                    SuperAdminLinks.Add("expressupdate.aspx");
                    SuperAdminLinks.Add("QuickAdmission.aspx");
                    SuperAdminLinks.Add("EnquiryType.aspx");
                    SuperAdminLinks.Add("AddEnquiry.aspx");
                    SuperAdminLinks.Add("TeleEnquiry.aspx");
                    SuperAdminLinks.Add("ViewEnquiry.aspx");
                    SuperAdminLinks.Add("ViewAdmission.aspx");
                    SuperAdminLinks.Add("Receiptdetails.aspx ");
                    SuperAdminLinks.Add("InvoiceMenu.aspx");
                    SuperAdminLinks.Add("Counselorcoursedetails.aspx");
                    SuperAdminLinks.Add("UpdateOldStuddetails.aspx");
                    SuperAdminLinks.Add("QuickEnquiry.aspx");
                    SuperAdminLinks.Add("Admission.aspx");
                    SuperAdminLinks.Add("preInvoicedetail.aspx");
                    SuperAdminLinks.Add("LabDetails.aspx.aspx");
                    SuperAdminLinks.Add("Attendance_details.aspx");

                    //added by ashok (8_3_2012)

                    SuperAdminLinks.Add("Dualinvoice.aspx");




                }
                else if (HttpContext.Current.Session["Centrerole"].ToString() == "Technical Head")
                {

                    SuperAdminLinks.Add("welcome.aspx");
                    SuperAdminLinks.Add("ViewAdmission.aspx");
                    SuperAdminLinks.Add("ViewAttendance.aspx");
                    SuperAdminLinks.Add("Extendnewcourse.aspx");
                    SuperAdminLinks.Add("NewBatchCreation.aspx");
                    SuperAdminLinks.Add("ViewbatchDetails.aspx");
                    SuperAdminLinks.Add("AllocateBatch.aspx");
                    SuperAdminLinks.Add("ChangeBatch.aspx");
                    SuperAdminLinks.Add("Parallel_Batch.aspx");
                    SuperAdminLinks.Add("Editbatchschedule.aspx");
                    SuperAdminLinks.Add("FacultydetailsNew.aspx");
                    SuperAdminLinks.Add("Facultydetails.aspx");
                    SuperAdminLinks.Add("FacultyAvail.aspx");
                    SuperAdminLinks.Add("Addlab.aspx");
                    SuperAdminLinks.Add("LabAvail.aspx");
                    SuperAdminLinks.Add("Editbatchschedule.aspx");
                    SuperAdminLinks.Add("Recommend.aspx");



                    SuperAdminLinks.Add("Breakageinvoice.aspx");
                    SuperAdminLinks.Add("Breakagereceipt.aspx");
                    SuperAdminLinks.Add("MonthlyCollection.aspx");
                    SuperAdminLinks.Add("balancereport.aspx");
                    SuperAdminLinks.Add("balancereport_old.aspx");
                    SuperAdminLinks.Add("TechnicalHead.aspx");
                    SuperAdminLinks.Add("FacultydetailsNew.aspx");
                    SuperAdminLinks.Add("Parallel_Batch.aspx");
                    SuperAdminLinks.Add("FacultyBatchDetails.aspx");
                    SuperAdminLinks.Add("Viewbatch.aspx");
                    SuperAdminLinks.Add("Admission.aspx");
                    SuperAdminLinks.Add("preInvoicedetail.aspx");
                    SuperAdminLinks.Add("LabDetails.aspx.aspx");
                    SuperAdminLinks.Add("Attendance_details.aspx");

                    //added by ashok (8_3_2012)

                    SuperAdminLinks.Add("Dualinvoice.aspx");

                }
                else if (HttpContext.Current.Session["Centrerole"].ToString() == "Faculty")
                {

                    SuperAdminLinks.Add("welcome.aspx");
                    SuperAdminLinks.Add("ViewAttendance.aspx");
                    SuperAdminLinks.Add("Attendancebatchcode.aspx");
                    SuperAdminLinks.Add("LabDetails.aspx.aspx");
                    SuperAdminLinks.Add("Attendance_details.aspx");
                    SuperAdminLinks.Add("Recommend.aspx");


                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("home.aspx");
            }


            callval(SuperAdminLinks, CurrentPageName);
        }

        public static void callval(ArrayList SuperAdminLinks, string CurrentPageName)
        {

            int st = 0;

            for (int i = 0; i < SuperAdminLinks.Count; i++)
            {


                if (SuperAdminLinks[i].ToString().ToLower() == CurrentPageName.ToString().ToLower())
                {
                    st = 1;



                }



            }
            if (st == 0)
            {
                HttpContext.Current.Response.Redirect("WrongEntry.aspx?PageRestrict=yes");



            }

        }
    }
}
