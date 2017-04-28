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

public partial class ImageTraining_2_Onlinestudents2_superadmin_Alterinvoice : System.Web.UI.Page
{
    string insertqry, qry;
    int count = 0;
    double totalamt = 0;
    double totalinstall = 0;

    private DateTime currentDate = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        } 
        if (!IsPostBack)
        {
            ddlAlterYear.Items.Add(new ListItem("Select",""));
            ddlAlterYear.Items.Add(new ListItem((currentDate.AddYears(-4).Year.ToString()), (currentDate.AddYears(-4).Year.ToString())));
            ddlAlterYear.Items.Add(new ListItem((currentDate.AddYears(-3).Year.ToString()), (currentDate.AddYears(-3).Year.ToString())));
            ddlAlterYear.Items.Add(new ListItem((currentDate.AddYears(-2).Year.ToString()), (currentDate.AddYears(-2).Year.ToString())));
            ddlAlterYear.Items.Add(new ListItem((currentDate.AddYears(-1).Year.ToString()), (currentDate.AddYears(-1).Year.ToString())));
            ddlAlterYear.Items.Add(new ListItem((currentDate.Year.ToString()), (currentDate.Year.ToString())));
            ddlAlterYear.Items.Add(new ListItem((currentDate.AddYears(+1).Year.ToString()), (currentDate.AddYears(+1).Year.ToString())));
            fillcourse();
        }
        GetCoursefee();
        //string strIP;
        //strIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        ////Response.Write(strIP);
        //if (strIP != "118.102.129.218")
        //{
        //    Response.Redirect("WrongEntry.aspx?unauthorized=yes");
        //}
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txtStudentId.Text);
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
            if (Session["SA_centre_code"].ToString() == "ICH-106" || Session["SA_centre_code"].ToString() == "ICH-103" || Session["SA_centre_code"].ToString() == "ICH-102" || Session["SA_centre_code"].ToString() == "ICH-101")
            {
                qry = "SElect program,lump_sum,instal_amount,tax from img_centre_coursefee_details where centre_code='ICH-101'";
            }
            else
            {
                qry = "SElect program,lump_sum,instal_amount,tax,noofinstall  from img_centre_coursefee_details where centre_code='" + Session["SA_centre_code"].ToString() + "' and status=1";
            }
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
                        js += "courseFeesfast[" + fastval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['noofinstall']='" + dt.Rows[i]["noofinstall"].ToString() + "'\n";
                        js += "courseFeesfast[" + fastval + "]['track']='" + dt.Rows[i]["track"].ToString() + "'\n";
                        fastval += 1;
                    }
                    if (dt.Rows[i]["track"].ToString().ToLower() == "normal")
                    {
                        js += "courseFeesnormal[" + normalval + "]=new Array();\n";
                        js += "courseFeesnormal[" + normalval + "]['program']='" + dt.Rows[i]["program"].ToString() + "'\n";
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
    protected void showinvoices(object sender, EventArgs e)
    {
        if (txtStudentId.Text.Trim() != "")
        {
            qry = "select cd.course_id,cd.program,instal_amount,(cd.program +' ('+instal_amount + ')') as feeprogram from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and cd.status='active' and feed.status=1  and feed.centre_code='" + Session["SA_centre_code"].ToString() + "'";
            DataTable dtcourses = new DataTable();
            dtcourses = MVC.DataAccess.ExecuteDataTable(qry);
            invoiceDetails.Visible = true;
            qry = @"select inv.invoiceid,cou.program,inv.courseid from erp_invoicedetails inv inner join img_coursedetails cou on inv.courseid=cou.course_id 
            where inv.studentid='" + txtStudentId.Text.Trim() + "' and inv.centerCode='" + Session["SA_centre_code"] + "' and inv.status='deactive'";
            DataTable  dt = MVC.DataAccess.ExecuteDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                grdinvoices.DataSource = dt;
                grdinvoices.DataBind();
            }
            foreach (GridViewRow gr in grdinvoices.Rows)
            {
                DropDownList ddlcoursealter = gr.FindControl("ddlcoursealter") as DropDownList;
                ddlcoursealter.DataSource = dtcourses;
                ddlcoursealter.DataValueField = "Course_Id";
                ddlcoursealter.DataTextField = "feeprogram";
                ddlcoursealter.DataBind();
                ddlcoursealter.Items.Insert(0, new ListItem("Select", ""));
            }
           
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string str1 = txtstartdate.Text;
            string[] split1 = str1.Split('-');
            string datestart = split1[2] + "-" + split1[1] + "-" + split1[0];
            qry = "select count(studentId) from erp_invoicedetails where studentid='" + txtStudentId.Text + "' and centerCode='" + Session["SA_centre_code"] + "'";
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);
            if (count > 0)
            {

                //try
                //{
                    qry = "select count(studentid) from erp_studentCourseDetails where studentid='" + txtStudentId.Text + "' and courseid='" + ddlcourse.SelectedValue + "' and centercode='" + Session["SA_centre_code"] + "' and status='1' ";
                    //Response.Write(qry);
                    //Response.End();
                    count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);
                    if (1 == 2)
                    {
                        lblerrormsg.Text = "This student alreaady doing this course";
                    }
                    else
                    {
                        //try
                        //{
                            qry = "select cd.course_id,cd.program,instal_amount,tax from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and feed.centre_code='" + Session["SA_centre_code"].ToString() + "' where cd.course_id='" + ddlcourse.SelectedValue + "'";
                            DataTable dt = new DataTable();
                            dt = MVC.DataAccess.ExecuteDataTable(qry);
                            if (dt.Rows.Count > 0)
                            {
                                hiddennewcoursefees.Value = coursefee.Text;
                                hiddentax.Value = dt.Rows[0]["tax"].ToString();
                            }
                            qry = " select courseId,invoiceId,installNo,courseFees,taxpercentage from erp_invoicedetails where  studentid='" + txtStudentId.Text + "' and centerCode='" + Session["SA_centre_code"] + "' and status='active' ";
                            dt = MVC.DataAccess.ExecuteDataTable(qry);
                            if (dt.Rows.Count > 0)
                            {
                                hiddencourse.Value = dt.Rows[0]["courseId"].ToString();
                                hiddeninstall.Value = dt.Rows[0]["installNo"].ToString();
                                hiddeninvoice.Value = dt.Rows[0]["invoiceId"].ToString();
                                hiddencoursefees.Value = dt.Rows[0]["courseFees"].ToString();
                            }
                            int candoalter = 0;
                            string sAcademicStartYear = "4/1/" + ddlAlterYear.SelectedValue + "";

                            qry = "select count(id) from erp_studentCourseDetails where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and invoiceNo='" + hiddeninvoice.Value + "' and courseid='" + hiddencourse.Value + "' and coursestartdate>='" + sAcademicStartYear + "'";
                            // Response.Write(qry);
                            // Response.End();
                            candoalter = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, qry);
                            if (candoalter > 0)
                            {
                                qry = "update erp_installamountdetails set initialamount=round(((cast(totalinitialamount as float)*100)/(100+" + Convert.ToDouble(hiddentax.Value) + ")),0),initialamounttax=round((cast(totalinitialamount as float)-((cast(totalinitialamount as float)*100)/(100+" + Convert.ToDouble(hiddentax.Value) + "))),0)  where status='completed' and  studentid='" + txtStudentId.Text + "' and centerCode='" + Session["SA_centre_code"] + "' and invoiceno='" + hiddeninvoice.Value + "' ";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                                qry = "update erp_receiptdetails set amount=round(((cast(totalamount as float)*100)/(100+" + Convert.ToDouble(hiddentax.Value) + ")),0),taxamount=round((cast(totalamount as float)-((cast(totalamount as float)*100)/(100+" + Convert.ToDouble(hiddentax.Value) + "))),0) where studentid='" + txtStudentId.Text + "' and centerCode='" + Session["SA_centre_code"] + "' and invoiceno='" + hiddeninvoice.Value + "' ";
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                                qry = " select isnull(min(installnumber),0) as mininstall,sum(cast(initialamount as float))as totalinitial,isnull(max(installnumber),0) as maxinstall,(isnull(max(cast(installnumber as int)),0)-isnull(min(cast(installnumber as int)),0)) as pendinginstall from erp_installamountdetails ins inner join erp_invoicedetails inv on inv.studentid=ins.studentid and ins.centercode=inv.centercode and inv.studentid='" + txtStudentId.Text + "' and inv.centerCode='" + Session["SA_centre_code"] + "' and ins.invoiceno='" + hiddeninvoice.Value + "'   and inv.status='active'   and ins.status='completed' ";

                                qry = "select sum(cast(amount as float)) as totalinitial,max(installno) as maxinstall from erp_receiptdetails where studentid='" + txtStudentId.Text + "'  and invoiceno='" + hiddeninvoice.Value + "' group by studentid,invoiceno";
                                //Response.Write(qry);
                                //Response.End();
                                dt = MVC.DataAccess.ExecuteDataTable(qry);
                                if (dt.Rows.Count > 0)
                                {
                                    hiddenpaidinitial.Value = dt.Rows[0]["totalinitial"].ToString();
                                    hiddenstartinginstallno.Value = dt.Rows[0]["maxinstall"].ToString();
                                }
                                double coursetax = ((Convert.ToDouble(hiddennewcoursefees.Value)) * (Convert.ToDouble(hiddentax.Value)) / 100);
                                double coursefeeswithtax = Convert.ToDouble(hiddennewcoursefees.Value) + coursetax;
                                double totalinstallnumber = Convert.ToDouble(hiddenstartinginstallno.Value) + Convert.ToDouble(txtinstallnumber.Text);
                                double installamt = (Convert.ToDouble(hiddennewcoursefees.Value) - (Convert.ToDouble(hiddenpaidinitial.Value))) / Convert.ToDouble(txtinstallnumber.Text);
                                double newtaxval = installamt * (Convert.ToDouble(hiddentax.Value)) / 100;
                                double totinstlallamt = installamt + newtaxval;
                                qry = " update erp_studentCourseDetails set status='0' where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and invoiceNo='" + hiddeninvoice.Value + "' and courseid='" + hiddencourse.Value + "' ";
                                qry += " Insert into erp_studentCourseDetails (studentid,centercode,invoiceno,courseid,coursefees,track,coursestartdate,batch,installnumber,status,dateins ) values ('" + txtStudentId.Text + "','" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + ddlcourse.SelectedValue + "','" + hiddennewcoursefees.Value + "','" + ddltrack.SelectedValue + "','" + datestart + "','" + ddlbatch.SelectedValue + "','" + txtinstallnumber.Text + "','1',getdate())";
                                qry += " Insert into erp_historyStudentCourseDetails (studentid,centercode,invoiceno,courseid,coursefees,track,coursestartdate,batch,installnumber,status,dateins,remarks ) values ('" + txtStudentId.Text + "','" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + ddlcourse.SelectedValue + "','" + hiddennewcoursefees.Value + "','" + ddltrack.SelectedValue + "','" + datestart + "','" + ddlbatch.SelectedValue + "','" + txtinstallnumber.Text + "','1',getdate(),'Insert')";
                                qry += " update erp_invoicedetails set remarks='" + MVC.CommonFunction.ReplaceTildWithQuote(txtreason.Text) + "',taxpercentage='" + hiddentax.Value + "',courseid='" + ddlcourse.SelectedValue + "', coursefees='" + Convert.ToInt32(hiddennewcoursefees.Value) + "',track='" + ddltrack.SelectedValue + "',batchtime='" + ddlbatch.SelectedValue + "',installNo='" + totalinstallnumber + "' where studentid='" + txtStudentId.Text + "' and invoiceid='" + hiddeninvoice.Value + "' and centercode='" + Session["SA_centre_code"] + "'";
                                qry += " update adm_generalinfo set coursename='" + ddlcourse.SelectedValue + "', payment_coursefee='" + Convert.ToInt32(hiddennewcoursefees.Value) + "' where student_id='" + txtStudentId.Text + "' and centre_code='" + Session["SA_centre_code"] + "'";
                                qry += " delete from erp_installamountdetails where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and invoiceno='" + hiddeninvoice.Value + "' and installnumber>'" + Convert.ToInt32(hiddenstartinginstallno.Value) + "'";
                                qry += " insert into erp_alterinvoicereason(centercode,studentid,invoiceid,courseold,coursenew,alterreason,dateins) values('" + Session["SA_centre_code"] + "' ,'" + txtStudentId.Text.Trim() + "','" + hiddeninvoice.Value + "','" + hiddencourse.Value + "','" + Convert.ToInt32(hiddennewcoursefees.Value) + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtreason.Text) + "',getdate())";
                                string[] txtstart = txtstartdate.Text.Split('-');//29-09-2016
                                string installmentdate = txtstart[1] + "/" + txtstart[0] + "/" + txtstart[2];    // "09/29/2016";
                                if (Convert.ToDouble(hiddenpaidinitial.Value) <= Convert.ToDouble(hiddencoursefees.Value))
                                {
                                    int k = 0;
                                    for (int i = Convert.ToInt32(hiddenstartinginstallno.Value) + 1; i < Convert.ToDouble(hiddenstartinginstallno.Value) + totalinstallnumber; i++)
                                    {
                                        qry += " insert into erp_installamountdetails (centercode,invoiceno,studentid,installnumber,initialamount,initialamounttax,totalinitialamount,courseid,installdate,status,dateins) values ('" + Session["SA_centre_code"] + "','" + hiddeninvoice.Value + "','" + txtStudentId.Text + "','" + i + "',round('" + installamt + "',0),round('" + newtaxval + "',0),round('" + totinstlallamt + "',0),'" + ddlcourse.SelectedValue + "',DATEADD(month," + k + ",'" + installmentdate + "'),'pending',getdate())";
                                        k += 1;
                                    }
                                }
                               
                                //Response.Write(qry);
                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);

                                #region update deactivated invoice
                                qry = "";
                                foreach (GridViewRow gr in grdinvoices.Rows)
                                {
                                    CheckBox chk = gr.FindControl("chk") as CheckBox;
                                    DropDownList ddlcoursealter = gr.FindControl("ddlcoursealter") as DropDownList;
                                    if (chk.Checked && ddlcoursealter.SelectedValue!="" )
                                    {
                                        string invoiceid = (gr.FindControl("hdninvoice") as HiddenField).Value;
                                        string courseid = (gr.FindControl("hdncourseid") as HiddenField).Value;
                                        qry = " update erp_studentCourseDetails set status='0' where studentid='" + txtStudentId.Text.Trim() + "' and centercode='" + Session["SA_centre_code"] + "' and invoiceNo='" + invoiceid + "' and courseid='" + courseid + "' ";
                                        qry += " Insert into erp_studentCourseDetails (studentid,centercode,invoiceno,courseid,coursefees,track,coursestartdate,batch,installnumber,status,dateins ) values ('" + txtStudentId.Text.Trim() + "','" + Session["SA_centre_code"] + "','" + invoiceid + "','" + ddlcoursealter.SelectedValue + "','" + hiddennewcoursefees.Value + "','" + ddltrack.SelectedValue + "','" + datestart + "','" + ddlbatch.SelectedValue + "','" + txtinstallnumber.Text + "','1',getdate())";
                                        qry += " Insert into erp_historyStudentCourseDetails (studentid,centercode,invoiceno,courseid,coursefees,track,coursestartdate,batch,installnumber,status,dateins,remarks ) values ('" + txtStudentId.Text.Trim() + "','" + Session["SA_centre_code"] + "','" + invoiceid + "','" + ddlcoursealter.SelectedValue + "','" + hiddennewcoursefees.Value + "','" + ddltrack.SelectedValue + "','" + datestart + "','" + ddlbatch.SelectedValue + "','" + txtinstallnumber.Text + "','1',getdate(),'Insert')";
                                        qry += " update erp_invoicedetails set remarks='" + MVC.CommonFunction.ReplaceTildWithQuote(txtreason.Text) + "',courseid='" + ddlcoursealter.SelectedValue + "' where studentid='" + txtStudentId.Text.Trim() + "' and invoiceid='" + invoiceid + "' and centercode='" + Session["SA_centre_code"] + "'";
                                        qry += " insert into erp_alterinvoicereason(centercode,studentid,invoiceid,courseold,coursenew,alterreason,dateins) values('" + Session["SA_centre_code"] + "' ,'" + txtStudentId.Text.Trim() + "','" + invoiceid + "','" + courseid + "','" + Convert.ToInt32(ddlcoursealter.SelectedValue) + "','" + MVC.CommonFunction.ReplaceTildWithQuote(txtreason.Text) + "',getdate())";
                                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);
                                    }
                                };
                                #endregion
                                //qry = " select sum(round(cast(initialamount as float),0))as initialamount,sum(round(cast(initialamounttax as float),0))as tax,sum(round(cast(totalinitialamount as float),0))as total,max(ins.installnumber) as updinstall, max(coursefees) from erp_installamountdetails ins inner join erp_invoicedetails inv on inv.studentid=ins.studentid and inv.centercode=ins.centercode and inv.status='active' and ins.invoiceno='" + hiddeninvoice.Value + "' and inv.studentid='" + txtStudentId.Text + "'";
                                //Response.Write(qry);
                                //dt = MVC.DataAccess.ExecuteDataTable(qry);
                                //int updinstall = 0;
                                //double totam = 0;
                                //double tottax = 0;
                                //double totfullamt = 0;
                                //if (dt.Rows.Count > 0)
                                //{
                                //    updinstall = Convert.ToInt32(dt.Rows[0]["updinstall"]);
                                //    totam = Convert.ToDouble(dt.Rows[0]["initialamount"]);
                                //    tottax = Convert.ToDouble(dt.Rows[0]["tax"]);
                                //    totfullamt = Convert.ToDouble(dt.Rows[0]["total"]);

                                //    double roundfee = Math.Round(Convert.ToDouble(hiddennewcoursefees.Value)) - Math.Round((totam));
                                //    double roundtax = Math.Round((coursetax)) - Math.Round((tottax));
                                //    double roundtotal = Math.Round((coursefeeswithtax)) - Math.Round((totfullamt));

                                //    qry = "update erp_installamountdetails set initialamount=(cast(initialamount as int))+'" + roundfee + "' , initialamounttax=(cast(initialamounttax as int))+'" + roundtax + "' , totalinitialamount=(cast(totalinitialamount as int))+'" + roundtotal + "' where studentid='" + txtStudentId.Text + "' and centercode='" + Session["SA_centre_code"] + "' and installNumber='" + updinstall + "' and invoiceno='" + hiddeninvoice.Value + "' ";
                                //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, qry);

                                //}
                                if (txtinitialpayment.Text == "")
                                {
                                    txtinitialpayment.Text = "0";
                                }
                                if (Convert.ToInt32(txtinitialpayment.Text) > 0)
                                {
                                    try
                                    {
                                        SqlConnection Conn = new SqlConnection(MVC.DataAccess.ConnectionString);
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.Connection = Conn;
                                        cmd.CommandText = "[spReceiptEdit]";
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("centerCode", Session["SA_centre_code"]);
                                        cmd.Parameters.AddWithValue("invoiceNo", hiddeninvoice.Value);
                                        cmd.Parameters.AddWithValue("totalAmount", txtinitialpayment.Text);
                                        cmd.Parameters.AddWithValue("paymentMode", "cash");
                                        cmd.Parameters.AddWithValue("bankName", ' ');
                                        cmd.Parameters.AddWithValue("ddNo", ' ');
                                        cmd.Parameters.AddWithValue("ddDate", ' ');
                                        cmd.Parameters.AddWithValue("paymentTowards", "Image infotainment limited ");
                                        cmd.Parameters.AddWithValue("studentId", txtStudentId.Text);
                                        cmd.Parameters.AddWithValue("monthInstall", ' ');
                                        cmd.Parameters.AddWithValue("installNo", (Convert.ToInt32(hiddenstartinginstallno.Value) + 1));
                                        cmd.Parameters.AddWithValue("receiptCutBy", Session["SA_UserID"]);
                                        cmd.Parameters.Add("@receiptNo", SqlDbType.VarChar, 50);
                                        cmd.Parameters["@receiptNo"].Direction = ParameterDirection.Output;
                                        Conn.Open();
                                        cmd.ExecuteNonQuery();
                                        string receiptNo = "";
                                        receiptNo = (string)cmd.Parameters["@receiptNo"].Value;
                                        Conn.Close();
                                        if (receiptNo == "E1")
                                        {
                                            lblerrormsg.Text = "Receipt No Already Exist";
                                        }
                                        else if (receiptNo == "E2")
                                        {
                                            lblerrormsg.Text = "No course tax in master table";
                                        }
                                        else
                                        {
                                            Response.Redirect("receiptprint.aspx?recptno=" + receiptNo + "&studid=" + txtStudentId.Text + "&invoiceno=" + hiddeninvoice.Value);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        lblerrormsg.Text = "Input Data is Not in correct Format";
                                        lblerrormsg.Text = ex.Message.ToString();
                                    }
                                    //int initialamounttax=Convert.ToInt32(txtinitialpayment.Text)*( );
                                    //string _Qry = "select rec_total+1 as runningreceipt,runningReceiptCentreCode  from erp_invoicedetails as invoice inner join img_centre_coursefee_details as course on course.program=invoice.courseId and course.track=invoice.track and invoice.studentId='" + txtStudentId.Text + "' and invoice.status='active'  inner join  Receipt_Total_No as runningreceipt on runningreceipt.centre_code=course.runningreceiptcentrecode and runningreceipt.centre_code=invoice.centercode";
                                    //dt = MVC.DataAccess.ExecuteDataTable(qry);
                                    //if (dt.Rows.Count > 0)
                                    //{
                                    //    hiddenrunningcenter.Value = dt.Rows[0]["runningReceiptCentreCode"].ToString();
                                    //    hiddenrunningreceipt.Value = dt.Rows[0]["runningreceipt"].ToString();
                                    //}
                                    //_Qry = "insert into erp_receiptdetails ([centerCode],[receiptNo],[invoiceNo],[amount],[taxAmount],[totalAmount],[paymentMode],[bankName],[ddNo],[ddDate],[paymentTowards],[studentId],[monthInstall],[installNo],[paymentWords],[dateIns],[receiptCutBy],[receiptType],[remarks],[status],[datemod]) values ('" + Session["SA_centre_code"] + "','" + hiddenrunningreceipt.Value + "','"+hiddeninvoice.Value+"',)";
                                }

                                lblerrormsg.Text = "successfully added the course";

                                //qry = "";
                            }
                            else
                            {
                                lblerrormsg.Text = "Course date exceed cannot alter invoice";
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    lblerrormsg.Text = ex.Message.ToString();
                        //}
                    }
                //}
                //catch (Exception ex)
                //{
                //    lblerrormsg.Text = ex.Message.ToString();
                //}

            }
            else
            {
                lblerrormsg.Text = "Please enroll the student";
            }
        }
    }
    private object DATEADD(object p, int p_2, DateTime dateTime)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        qry = " select instal_amount,noofinstall from img_centre_coursefee_details as feed inner join img_coursedetails as cd on feed.program=cd.course_id and track='Normal' and feed.centre_code='" + Session["SA_centre_code"].ToString() + "' and cd.course_id='" + ddlcourse.SelectedValue.ToString() +"'";
        //Response.Write(qry);
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(qry);
        coursefee.Text = dt.Rows[0]["instal_amount"].ToString();
        lblmaxinstallnumber.Text = dt.Rows[0]["noofinstall"].ToString();
    }
}
