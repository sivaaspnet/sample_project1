using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ImageTraining_2_Onlinestudents2_superadmin_Extendnewcourse : System.Web.UI.Page
{
    string insertqry, qry;
    int count = 0;
    double totalamt = 0;
    double totalinstall = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        GetCoursefee();
        if (!IsPostBack)
        {
            fillcourse();
        }
    }
    protected void fillcourse()
    {
        qry = "select cd.course_id,cd.program,instal_amount,(cd.program +' ('+instal_amount + ')') as feeprogram from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and cd.status='active' and feed.status=1  and feed.centre_code='" + Session["SA_centre_code"].ToString() + "'";
        
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);

        ddlcourse.DataSource = dt;
        ddlcourse.DataValueField = "Course_Id";
        ddlcourse.DataTextField = "feeprogram";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("Select", ""));
    }
    private string generatecoursefee()
    {
        if (Session["SA_centre_code"] == "" || Session["SA_centre_code"] == null)
        {
            Response.Redirect("Login.aspx");
            return "";
        }
        else
        {
            string qry = "";
           
            qry = "select program,lump_sum,instal_amount,tax,noofinstall,track  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1 ";


            //Response.Write(qry);
            //Response.End();

            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(qry);
            string js = "";
            if (dt.Rows.Count > 0)
            {
                int i, normalval = 0, fastval = 0;
                js = "<script language='javascript' type='text/javascript'>\n";
                js += "var courseFeesfast=new Array();\n";
                js += "var courseFeesnormal=new Array();\n";
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["track"].ToString().ToLower() == "fast")
                    {
                        js += "courseFeesfast[" + fastval + "]=new Array();\n";
                        js += "courseFeesfast[" + fastval + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        fastval += 1;
                    }
                    if (dt.Rows[i]["track"].ToString().ToLower() == "normal")
                    {
                        js += "courseFeesnormal[" + normalval + "]=new Array();\n";
                        js += "courseFeesnormal[" + normalval + "]['lump_sum']='" + dt.Rows[i]["lump_sum"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['instal_amount']='" + dt.Rows[i]["instal_amount"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['tax']='" + dt.Rows[i]["tax"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesnormal[" + normalval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        normalval += 1;
                    }
                }
                js += "</script>";
            }
            return js;
        }
    }
    private void GetCoursefee()
    {
        string js = "";
        js = generatecoursefee();
        Page.RegisterClientScriptBlock("SubcategoryDetail", js);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string str1 = txtstartdate.Text;
        string[] split1 = str1.Split('-');
        string datestart = split1[2] + "-" + split1[1] + "-" + split1[0];
        qry = @"select count(studentId) from erp_invoicedetails where studentid='" + txtStudentId.Text + "' and centerCode='"+Session["SA_centre_code"]+"' and  datepart(month,dateins)=datepart(month,getdate()) and datepart(year,dateins)=datepart(year,getdate())";
        count= MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);
        if (count > 0)
        {
            try
            {
                qry = "select count(studentid) from erp_studentCourseDetails where studentid='"+txtStudentId.Text+"' and courseid='"+ddlcourse.SelectedValue+"' and centercode='"+Session["SA_centre_code"]+"' and status='1' ";
                //Response.Write(qry);
                //Response.End();
                count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);
                if (count > 0)
                {
                    lblerrormsg.Text = "This student alreaady doing this course";      
                }
                else
                {
                    
                    try
                    {
                        qry = "select cd.course_id,cd.program,instal_amount from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and feed.centre_code='" + Session["SA_centre_code"].ToString() + "' where cd.course_id='" + ddlcourse.SelectedValue + "'";
                        DataTable dt = new DataTable();
                        dt = MVC.DataAccess.ExecuteDataTable(qry);
                        if (dt.Rows.Count > 0)
                        {
                            hiddennewcoursefees.Value = dt.Rows[0]["instal_amount"].ToString();
                        }
                        qry = " select courseId,invoiceId,installNo,courseFees,taxpercentage from erp_invoicedetails where  studentid='" + txtStudentId.Text + "' and centerCode='" + Session["SA_centre_code"] + "' and status='active' ";
                        dt = MVC.DataAccess.ExecuteDataTable(qry);
                        if (dt.Rows.Count > 0)
                        {
                            hiddencourse.Value = dt.Rows[0]["courseId"].ToString();
                            hiddeninstall.Value = dt.Rows[0]["installNo"].ToString();
                            hiddeninvoice.Value = dt.Rows[0]["invoiceId"].ToString();
                            hiddencoursefees.Value = dt.Rows[0]["courseFees"].ToString();
                            hiddentax.Value = dt.Rows[0]["taxpercentage"].ToString();
                        }
                        qry = " select isnull(min(installnumber),0) as mininstall,sum(cast(initialamount as int))as totalinitial,isnull(max(installnumber),0) as maxinstall,(isnull(max(cast(installnumber as int)),0)-isnull(min(cast(installnumber as int)),0)) as pendinginstall from erp_installamountdetails ins inner join erp_invoicedetails inv on inv.studentid=ins.studentid and ins.centercode=inv.centercode and inv.studentid='" + txtStudentId.Text + "' and inv.centerCode='" + Session["SA_centre_code"] + "' and ins.invoiceno='" + hiddeninvoice.Value + "'  and ins.status='pending' ";
                        //Response.Write(qry);
                        //Response.End();
                        dt=MVC.DataAccess.ExecuteDataTable(qry);
                        if (dt.Rows.Count > 0)
                        {
                            hiddenstartinginstallno.Value = dt.Rows[0]["mininstall"].ToString();
                        }
                        double updatecoursefees = Convert.ToDouble(hiddennewcoursefees.Value) + Convert.ToDouble(hiddencoursefees.Value);
                        double installments = Math.Round( (Convert.ToDouble(hiddennewcoursefees.Value) / Convert.ToDouble(txtinstallnumber.Text)));
                        int installnumber = Convert.ToInt32(hiddeninstall.Value) + Convert.ToInt32(txtinstallnumber.Text);
                        int balanceinstallmentno = Convert.ToInt32(hiddeninstall.Value) - Convert.ToInt32(hiddenstartinginstallno.Value);
                        double coursetax =Math.Round( (installments * Convert.ToDouble(hiddentax.Value) / 100));
                        double totalcoursefee = Math.Round((installments + coursetax));
                        int leftinstallmentno = (Convert.ToInt32(hiddenstartinginstallno.Value) + Convert.ToInt32(txtinstallnumber.Text));
                        int  totam = 0;
                        double subval = 0;
                        double totval = 0;
                        double tottax = 0;
                        double totalupdatevalue = 0;
                        qry = " insert into erp_studentCourseDetails (studentId,centerCode,invoiceNo,courseId,courseFees,track,courseStartdate,batch,installnumber,status,dateins) values ('" + txtStudentId.Text + "','" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + ddlcourse.SelectedValue + "','" + hiddennewcoursefees.Value + "','" + ddltrack.SelectedValue + "','" + datestart + "','" + ddlbatch.SelectedValue + "','" + txtinstallnumber.Text + "','1',getdate())";
                        qry += " insert into erp_historyStudentCourseDetails (studentId,centerCode,invoiceNo,courseId,courseFees,track,courseStartdate,batch,installnumber,status,dateins,remarks) values ('" + txtStudentId.Text + "','" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + ddlcourse.SelectedValue + "','" + hiddennewcoursefees.Value + "','" + ddltrack.SelectedValue + "','" + datestart + "','" + ddlbatch.SelectedValue + "','" + txtinstallnumber.Text + "','1',getdate(),'Insert')";

                        qry += " update erp_invoicedetails set coursefees='" + updatecoursefees + "',installNo='" + installnumber + "' where   studentid='" + txtStudentId.Text + "' and centerCode='" + Session["SA_centre_code"] + "' and invoiceId='" + hiddeninvoice.Value + "'";
                        qry += " insert into erp_historyinvoicedetails([centerCode],[studentId],[invoiceId],[receiptNo],[track],[courseFees],[courseId],[installNo],[paymentType],[batchTime],[enteredBy],[taxPercentage],[remarks],[status],[dateIns],[historyRemarks]) select [centerCode],[studentId],[invoiceId],[receiptNo],[track],[courseFees],[courseId],[installNo],[paymentType],[batchTime],[enteredBy],[taxPercentage],[remarks],[status],[dateIns],'update' from erp_invoicedetails where studentId='" + txtStudentId.Text + "' and status='active'";
                     
                        int k = 0;
                        if (Convert.ToInt32(txtinstallnumber.Text) <= balanceinstallmentno)
                        {
                            for (int i = Convert.ToInt32(hiddenstartinginstallno.Value); i < (Convert.ToInt32(hiddenstartinginstallno.Value) + Convert.ToInt32(txtinstallnumber.Text)); i++)
                            {
                                qry += " update erp_installamountdetails set initialamount=initialamount+round('" + installments + "',0),initialamounttax=initialamounttax+round('" + coursetax + "',0),totalinitialamount=totalinitialamount+round('" + totalcoursefee + "',0) where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and invoiceno='" + hiddeninvoice.Value + "' and installnumber='" + i + "'";
                               // totam += installments;
                                k += 1;
                            }
                          
                           
                        }
                        else
                        {

                            for (int i = Convert.ToInt32(hiddenstartinginstallno.Value); i < Convert.ToInt32( hiddeninstall.Value); i++)
                            {
                                qry += " update erp_installamountdetails set initialamount=initialamount+round('" + installments + "',0),initialamounttax=initialamounttax+round('" + coursetax + "',0),totalinitialamount=totalinitialamount+round('" + totalcoursefee + "',0) where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and invoiceno='" + hiddeninvoice.Value + "' and installnumber='" + i + "'";
                               // totam += installments;
                                k += 1;
                            }
                            for (int i = (Convert.ToInt32(hiddeninstall.Value) + 1); i < leftinstallmentno; i++)
                            {
                                qry += " insert into erp_installamountdetails (centercode,invoiceno,studentid,installnumber,initialamount,initialamounttax,totalinitialamount,courseId,installdate,status,dateins) values ('" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + txtStudentId.Text + "','" + i + "',round('" + installments + "',0),round('" + coursetax + "',0),round('" + totalcoursefee + "',0),'" + ddlcourse.SelectedValue + "',DATEADD(month," + k + ",getdate()),'pending',getdate())";
                                qry += " insert into erp_historyInstallamountdetails (centercode,invoiceno,studentid,installnumber,initialamount,initialamounttax,totalinitialamount,courseId,installdate,status,dateins,historyRemarks) values ('" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + txtStudentId.Text + "','" + i + "',round('" + installments + "',0),round('" + coursetax + "',0),'" + totalcoursefee + "','" + ddlcourse.SelectedValue + "',DATEADD(month," + k + ",getdate()),'pending',getdate(),'Insert')";
                               // totam += installments;
                                k += 1;
                            }
                            
                        }
                        
                       
                        //Response.Write(qry);
                       MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                       qry = "select sum(cast(initialamount as int))as initialamount,max(ins.installnumber) as updinstall, max(coursefees) from erp_installamountdetails ins inner join erp_invoicedetails inv on inv.studentid=ins.studentid and inv.centercode=ins.centercode and inv.status='active' and ins.invoiceno='" + hiddeninvoice.Value + "' and inv.studentid='" + txtStudentId.Text + "'";
                       dt = MVC.DataAccess.ExecuteDataTable(qry);
                       int updinstall = 0;
                       if (dt.Rows.Count > 0)
                       {
                           updinstall = Convert.ToInt32(dt.Rows[0]["updinstall"]);
                           totam = Convert.ToInt32( dt.Rows[0]["initialamount"]);
                       }

                       subval = updatecoursefees - totam;
                        if (subval != 0)
                        {
                            totval = installments + subval;
                            tottax = Math.Round((subval * Convert.ToDouble(hiddentax.Value) / 100));
                            totalupdatevalue = totval + tottax;
                            qry = "update erp_installamountdetails set initialamount=cast(initialamount as int)+'" + subval + "' , initialamounttax=cast(initialamounttax as int)+'" + tottax + "' , totalinitialamount=cast(totalinitialamount as int)+'" + totalupdatevalue + "' where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and installNumber='" + updinstall + "' and invoiceno='" + hiddeninvoice.Value + "' ";
                            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                        }
                        lblerrormsg.Text = "successfully added the course";

                        //qry = "";
                    }
                    catch (Exception ex)
                    {
                        lblerrormsg.Text = ex.Message.ToString();
                    }     
                }
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = ex.Message.ToString();
            }
        }
        else
        {
            lblerrormsg.Text = "Please Enter StudentID Enrolled in Current Month..! ";
        }
    }

    private object DATEADD(object p, int p_2, DateTime dateTime)
    {
        throw new Exception("The method or operation is not implemented.");
    }
}
