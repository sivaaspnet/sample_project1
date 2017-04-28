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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class superadmin_Receiptdetails : System.Web.UI.Page
{
    double totalamt = 0;
    double totalamt1 = 0;
    string _Qry,studentid;
    int insno;
    static int re = 0;
    int Invoice_no = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Response.Redirect("Invoiceedit.aspx?studid=" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "");
            re = 0;

            if (Request.QueryString["stud_Id"] == "" || Request.QueryString["stud_Id"] == null)
            {

            }
            else
            {
                txt_stuid.Text = Request.QueryString["stud_Id"].ToString();
                Submit();
            }
        }
        //re = 0;
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            if (txt_stuid.Text == null || txt_stuid.Text == "")
            {
                lblmsg.Visible = false;
                ddl_instalnum.Visible = false;
            }
            
        }
    }

    private void Submit()
    {
        instal.Visible = true;
        _Qry = "select Invoice_No from install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And centre_code='" + Session["SA_centre_code"] + "'";
        //Response.Write(_Qry);
        //Response.End();

        SqlDataReader dr123;
        dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        if (dr123.HasRows)
        {
            dr123.Read();

            Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

            dr123.Close();
        }

        if (Invoice_no > 0)
        {
            _Qry = "Select (enq_personal_name) as Name from adm_personalparticulars where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And centre_code='" + Session["SA_centre_code"] + "'";
            //Response.Write(_Qry);
            //Response.End();
            SqlDataReader dr;
            dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            if (dr.HasRows)
            {
                studName.Visible = true;
                dr.Read();

                lblstudname.Text = dr["Name"].ToString();

                dr.Close();
            }
            else
            {
                studName.Visible = false;
            }

            re = re + 1;
            string viewstud = "";
            if (re > 1)
            {
                if (ViewState["stud_id"] == "" || ViewState["stud_id"] == null)
                {

                }
                else
                {
                    viewstud = ViewState["stud_id"].ToString();
                    viewstud = Regex.Replace(viewstud, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                }
            }
            if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == viewstud)
            {
                if (re > 0 && re == 1)
                {
                    lbl_errormsg.Text = "";
                    if (txt_stuid.Text == null || txt_stuid.Text == "")
                    {
                        lblmsg.Visible = false;
                        ddl_instalnum.Visible = false;
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        ddl_instalnum.Visible = true;
                        GridView1.Visible = true;

                        _Qry = "select student_id from adm_studentid where centre_code='" + Session["SA_centre_code"] + "' and student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                        //Response.Write(_Qry);
                        //Response.End();
                        DataTable dt = new DataTable();
                        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (dt.Rows.Count > 0)
                        {
                            if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == dt.Rows[0]["student_id"].ToString())
                            {
                                studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                                fill();
                                fillgrid();
                                GridView1.Visible = true;
                                lblmsg.Visible = true;
                            }
                            else
                            {
                                lbl_errormsg.Text = "No Records Found";
                                ddl_instalnum.Visible = false;
                                GridView1.Visible = false;
                                lblmsg.Visible = false;
                            }
                        }
                        else
                        {
                            lbl_errormsg.Text = "No Records Found";
                            ddl_instalnum.Visible = false;
                            GridView1.Visible = false;
                            lblmsg.Visible = false;
                        }
                    }
                }
                else if (re > 1)
                {
                    if (txt_stuid.Text != "" && ddl_instalnum.SelectedValue != "")
                    {
                        //Response.End();
                        //student_id  & install nm
                        if (re > 0 && re > 1)
                        {
                            if (lblAmount.Text.Length > 1)
                            {
                                if (lbl_Instalmentno.Text == "0")
                                {

                                }
                                else
                                {
                                   Response.Redirect("Receiptedit.aspx?studid=" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "&instlno=" + ddl_instalnum.SelectedValue + "");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                lbl_errormsg.Text = "";
                if (txt_stuid.Text == null || txt_stuid.Text == "")
                {
                    lblmsg.Visible = false;
                    ddl_instalnum.Visible = false;
                    GridView1.Visible = false;
                }
                else
                {
                    lblmsg.Visible = true;
                    ddl_instalnum.Visible = true;
                    GridView1.Visible = true;

                    _Qry = "select student_id from adm_studentid where centre_code='" + Session["SA_centre_code"] + "' and student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dt = new DataTable();
                    dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                    if (dt.Rows.Count > 0)
                    {
                        if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == dt.Rows[0]["student_id"].ToString())
                        {
                            studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                            fill();
                            fillgrid();
                            GridView1.Visible = true;
                            lblmsg.Visible = true;
                        }
                        else
                        {
                            lbl_errormsg.Text = "No Records Found";
                            ddl_instalnum.Visible = false;
                            GridView1.Visible = false;
                            lblmsg.Visible = false;
                        }
                    }
                    else
                    {
                        lbl_errormsg.Text = "No Records Found";
                        ddl_instalnum.Visible = false;
                        GridView1.Visible = false;
                        lblmsg.Visible = false;
                    }
                }
            }
            ViewState["stud_id"] = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "").ToString();

            //_Qry = "Select sum(tatamtpaidwithtax) as Amount From install_amountdetails WHERE Receipt_no IS NOT NULL And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";";


            _Qry = "Select tatamtpaidwithtax as Amount From install_amountdetails WHERE Receipt_no>0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

            DataTable dttotal = new DataTable();
            dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
            totalamt = 0;
            for (int i = 0; i < dttotal.Rows.Count; i++)
            {
                if (totalamt == 0)
                {
                    totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                }
                else
                {
                    double dbval = 0;
                    dbval = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                    totalamt = totalamt + dbval;
                    //Response.Write(totalamt);
                    //Response.End();
                }
            }

            _Qry = "Select Round(totalcourse_fees,0) as Amount From install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dttotal11 = new DataTable();
            dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
            totalamt1 = 0;
            //for (int i = 0; i < dttotal11.Rows.Count; i++)
            //{
            //    if (totalamt1 == 0)
            //    {
            //        totalamt1 = Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
            //    }
            //    else
            //    {
            //        totalamt1 = totalamt1 + Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
            //    }
            //}
            totalamt1 = Convert.ToDouble(dttotal11.Rows[0]["Amount"].ToString());

            //Response.Write("14totalamt:" + totalamt);
            //Response.Write("14totalamt1:" + totalamt1);
            //Response.End();

            double fillamt = Convert.ToDouble(totalamt1) - Convert.ToDouble(totalamt);

            if (fillamt >= 10000000)
            {
                lblAmount.Text = fillamt.ToString("##\",\"00\",\"00\",\"000");
            }
            else if (fillamt >= 100000)
            {
                lblAmount.Text = fillamt.ToString("##\",\"00\",\"000");
            }
            else if (fillamt >= 1000)
            {
                lblAmount.Text = fillamt.ToString("#,000");
            }
            else if (fillamt >= 1)
            {
                lblAmount.Text = Convert.ToString(Math.Round(fillamt, 0));;
            }
            else
            {
                lblAmount.Text = "0";
            }

            if (lblAmount.Text == "0")
            {
                visfalsefees.Visible = true;
                lblfeespaid.Text = "Fees Fully Paid";
                lblfeespaid.Visible = true;
                instal.Visible = false;
            }
            else
            {
                instal.Visible = true;
                visfalsefees.Visible = false;
                lblfeespaid.Text = "";
                lblfeespaid.Visible = false;
            }

            _Qry = "select Count (instal_number) as [NoOfInstallment],Sum(initialamount) as Amount From  install_amountdetails WHERE Receipt_no IS NULL And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
            //Response.Write(_Qry);
            //Response.End();
            DataTable dtins = new DataTable();
            dtins = MVC.DataAccess.ExecuteDataTable(_Qry);

            if (dtins.Rows.Count > 0)
            {
                instalno.Visible = true;
                Amounttot.Visible = true;
                lbl_Instalmentno.Text = dtins.Rows[0]["NoOfInstallment"].ToString();
                //lblAmount.Text = dtins.Rows[0]["Amount"].ToString();
                //if (Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == "" || Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == null)
                //{
                //    lblAmount.Text = "0";
                //}
                //else
                //{
                //    double lblamountd = Convert.ToDouble(dtins.Rows[0]["Amount"]);

                //    //if (lblamountd >= 10000000)
                //    //{
                //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"00\",\"000");
                //    //}
                //    //else if (lblamountd >= 100000)
                //    //{
                //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"000");
                //    //}
                //    //else if (lblamountd >= 1000)
                //    //{
                //    //    lblAmount.Text = lblamountd.ToString("#,000");
                //    //}
                //    //else
                //    //{
                //    //    lblAmount.Text = "0";
                //    //}
                //}
            }
            else
            {
                instalno.Visible = false;
                Amounttot.Visible = false;
            }
        }
        else
        {
            int CENTER_CODE = 0;

            _Qry = "select * from old_student_manual where center_code='" + Session["SA_centre_code"].ToString() + "' ";
            DataTable dt89 = new DataTable();
            dt89 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt89.Rows.Count > 0)
            {
                string val = dt89.Rows[0]["center_code"].ToString();
                if (Session["SA_centre_code"].ToString() == val)
                {
                    CENTER_CODE = Convert.ToInt32(dt89.Rows[0]["manual_code"].ToString());
                }
            }


            _Qry = "Select count(*) From OldEnrolled_Details where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";
            int checount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (checount > 0)
            {

               
                _Qry = "Select (enq_name) as Name from OldEnquiry_Details where Enquiry_no=(Select top 1 Enquiry_no From OldEnrolled_Details where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "') And Center_Code='" + CENTER_CODE + "'";
                //Response.Write(_Qry);
                //Response.End();
                SqlDataReader dr;
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    studName.Visible = true;
                    dr.Read();

                    lblstudname.Text = dr["Name"].ToString();

                    dr.Close();
                }
                else
                {
                    studName.Visible = false;
                }

                re = re + 1;
                string viewstud = "";
                if (re > 1)
                {
                    if (ViewState["stud_id"] == "" || ViewState["stud_id"] == null)
                    {

                    }
                    else
                    {
                        viewstud = ViewState["stud_id"].ToString();
                        viewstud = Regex.Replace(viewstud, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                    }
                }
                //Response.Write("Student Name:" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", ""));
                //Response.Write("View Stud:" + viewstud);
                //Response.End();
                if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == viewstud)
                {
                    if (re > 0 && re == 1)
                    {
                        lbl_errormsg.Text = "";
                        if (txt_stuid.Text == null || txt_stuid.Text == "")
                        {
                            lblmsg.Visible = false;
                            ddl_instalnum.Visible = false;
                            GridView1.Visible = false;
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            ddl_instalnum.Visible = true;
                            GridView1.Visible = true;

                            studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                            fill();
                            fillgrid();
                            GridView1.Visible = true;
                            lblmsg.Visible = true;
                        }
                    }
                    else if (re > 1)
                    {
                        if (txt_stuid.Text != "" && ddl_instalnum.SelectedValue != "")
                        {
                            //Response.End();
                            //student_id  & install nm
                            if (re > 0 && re > 1)
                            {
                                if (lblAmount.Text.Length > 1)
                                {
                                    if (lbl_Instalmentno.Text == "0")
                                    {

                                    }
                                    else
                                    {
                                        Response.Redirect("Receiptedit.aspx?studid=" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "&instlno=" + ddl_instalnum.SelectedValue + "");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    lbl_errormsg.Text = "";
                    if (txt_stuid.Text == null || txt_stuid.Text == "")
                    {
                        lblmsg.Visible = false;
                        ddl_instalnum.Visible = false;
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        ddl_instalnum.Visible = true;
                        GridView1.Visible = true;



                        studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                        fill();
                        fillgrid();
                        GridView1.Visible = true;
                        lblmsg.Visible = true;


                    }
                }
                ViewState["stud_id"] = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "").ToString();
                if (Invoice_no > 0)
                {
                    _Qry = "Select tatamtpaidwithtax as Amount From install_amountdetails WHERE Receipt_no>0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                    DataTable dttotal = new DataTable();
                    dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
                    totalamt = 0;
                    for (int i = 0; i < dttotal.Rows.Count; i++)
                    {
                        if (totalamt == 0)
                        {
                            totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                        }
                        else
                        {

                            totalamt = totalamt + Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                            //Response.Write(totalamt);
                            //Response.End();
                        }
                    }

                    _Qry = "Select Round(totalcourse_fees,0) as Amount From install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                    DataTable dttotal11 = new DataTable();
                    dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    totalamt1 = 0;
                    totalamt1 = Convert.ToDouble(dttotal11.Rows[0]["Amount"].ToString());
                    //for (int i = 0; i < dttotal11.Rows.Count; i++)
                    //{
                    //    if (totalamt1 == 0)
                    //    {
                    //        totalamt1 = Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
                    //    }
                    //    else
                    //    {
                    //        totalamt1 = totalamt1 + Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
                    //    }
                    //}
                    //Response.Write("123totalamt:" + totalamt);
                    //Response.Write("123totalamt1:" + totalamt1);
                    //Response.End();
                    double fillamt = Convert.ToDouble(totalamt1) - Convert.ToDouble(totalamt);

                    if (fillamt >= 10000000)
                    {
                        lblAmount.Text = fillamt.ToString("##\",\"00\",\"00\",\"000");
                    }
                    else if (fillamt >= 100000)
                    {
                        lblAmount.Text = fillamt.ToString("##\",\"00\",\"000");
                    }
                    else if (fillamt >= 1000)
                    {
                        lblAmount.Text = fillamt.ToString("#,000");
                    }
                    else if (fillamt >= 1)
                    {
                        lblAmount.Text = Convert.ToString(Math.Round(fillamt, 0));;
                    }
                    else
                    {
                        lblAmount.Text = "0";
                    }
                    if (lblAmount.Text == "0")
                    {
                        visfalsefees.Visible = true;
                        lblfeespaid.Text = "Fees Fully Paid";
                        lblfeespaid.Visible = true;
                        instal.Visible = false;
                    }
                    else
                    {
                        instal.Visible = true;
                        visfalsefees.Visible = false;
                        lblfeespaid.Text = "";
                        lblfeespaid.Visible = false;
                    }
                    _Qry = "select Count (instal_number) as [NoOfInstallment],Sum(initialamount) as Amount From  install_amountdetails WHERE Receipt_no IS NULL And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                    DataTable dtins = new DataTable();
                    dtins = MVC.DataAccess.ExecuteDataTable(_Qry);

                    if (dtins.Rows.Count > 0)
                    {
                        instalno.Visible = true;
                        Amounttot.Visible = true;
                        lbl_Instalmentno.Text = dtins.Rows[0]["NoOfInstallment"].ToString();
                        //lblAmount.Text = dtins.Rows[0]["Amount"].ToString();
                        //if (Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == "" || Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == null)
                        //{
                        //    lblAmount.Text = "0";
                        //}
                        //else
                        //{
                        //    double lblamountd = Convert.ToDouble(dtins.Rows[0]["Amount"]);

                        //    //if (lblamountd >= 10000000)
                        //    //{
                        //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"00\",\"000");
                        //    //}
                        //    //else if (lblamountd >= 100000)
                        //    //{
                        //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"000");
                        //    //}
                        //    //else if (lblamountd >= 1000)
                        //    //{
                        //    //    lblAmount.Text = lblamountd.ToString("#,000");
                        //    //}
                        //    //else
                        //    //{
                        //    //    lblAmount.Text = "0";
                        //    //}
                        //}
                    }
                    else
                    {
                        instalno.Visible = false;
                        Amounttot.Visible = false;
                    }
                }
                else
                {
                    int Ins_Coursefees = 0;

                    _Qry = "Select Replace(Round(Course_Fees,0),'.00','') as Course_Fees from Old_install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    SqlDataReader dr1;
                    dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                    if (dr1.HasRows)
                    {
                        dr1.Read();

                        Ins_Coursefees = Convert.ToInt32(dr1["Course_Fees"].ToString());

                        dr1.Close();
                    }

                    int Ins_Amount = 0;

                    _Qry = "select Replace(Replace(Round(Sum(Install_Amount),0),'.00',''),'-','') as Amount From  Old_install_amountdetails WHERE Receipt_no!=0 And status='completed' And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";

                    SqlDataReader dr2;
                    dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                    {
                        dr2.Read();
                        if (dr2["Amount"].ToString() == "" || dr2["Amount"].ToString() == null)
                        {
                            Ins_Amount = 0;
                        }
                        else
                        {
                            Ins_Amount = Convert.ToInt32(dr2["Amount"].ToString());
                        }
                        dr2.Close();
                    }

                    _Qry = "Select total_install_amount as Amount From Old_install_amountdetails WHERE Receipt_no>0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                    DataTable dttotal = new DataTable();
                    dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
                    totalamt = 0;
                    for (int i = 0; i < dttotal.Rows.Count; i++)
                    {
                        if (totalamt == 0)
                        {
                            totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                        }
                        else
                        {
                            //double dbval = 0;
                            //dbval = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                            totalamt = totalamt + Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                            //Response.Write(totalamt);
                            //Response.End();
                        }
                    }
                    _Qry = "Select Round(total_course_fees,0) as Amount From Old_install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                    DataTable dttotal11 = new DataTable();
                    dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    totalamt1 = 0;
                    totalamt1 = Convert.ToDouble(dttotal11.Rows[0]["Amount"].ToString());

                    //_Qry = "Select install_amount,install_amount_tax From Old_install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                    //DataTable dttotal11 = new DataTable();
                    //dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    //totalamt1 = 0;
                    //double totalamt2 = 0;
                    //for (int i = 0; i < dttotal11.Rows.Count; i++)
                    //{
                    //    if (totalamt1 == 0)
                    //    {
                    //        totalamt1 = Convert.ToDouble(dttotal11.Rows[i]["install_amount"].ToString());
                    //    }
                    //    else
                    //    {
                    //        totalamt1 = totalamt1 + Convert.ToDouble(dttotal11.Rows[i]["install_amount"].ToString());
                    //    }
                    //    if (totalamt2 == 0)
                    //    {
                    //        totalamt2 = Convert.ToDouble(dttotal11.Rows[i]["install_amount_tax"].ToString());
                    //    }
                    //    else
                    //    {
                    //        totalamt2 = totalamt2 + Convert.ToDouble(dttotal11.Rows[i]["install_amount_tax"].ToString());
                    //    }
                    //}

                    //Response.Write("TotAmt:" + totalamt);
                    //Response.Write("TotAmt1:" + totalamt1);
                    ////Response.Write("TotAmt2:" + totalamt2);
                    //Response.End();

                    double fillamt = Convert.ToDouble(totalamt1) - Convert.ToDouble(totalamt);

                    if (fillamt >= 10000000)
                    {
                        lblAmount.Text = fillamt.ToString("##\",\"00\",\"00\",\"000");
                    }
                    else if (fillamt >= 100000)
                    {
                        lblAmount.Text = fillamt.ToString("##\",\"00\",\"000");
                    }
                    else if (fillamt >= 1000)
                    {
                        lblAmount.Text = fillamt.ToString("#,000");
                    }
                    else if (fillamt >= 1)
                    {
                        lblAmount.Text = Convert.ToString(Math.Round(fillamt, 0));
                    }
                    else
                    {
                        lblAmount.Text = "0";
                    }
                    if (lblAmount.Text == "0")
                    {
                        visfalsefees.Visible = true;
                        lblfeespaid.Text = "Fees Fully Paid";
                        lblfeespaid.Visible = true;
                        instal.Visible = false;
                    }
                    else
                    {
                        visfalsefees.Visible = false;
                        lblfeespaid.Text = "";
                        lblfeespaid.Visible = false;
                    }
                    _Qry = "select Count (install_number) as [NoOfInstallment],Sum(Install_Amount) as Amount From  Old_install_amountdetails WHERE Receipt_no=0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    DataTable dtins = new DataTable();
                    dtins = MVC.DataAccess.ExecuteDataTable(_Qry);

                    if (dtins.Rows.Count > 0)
                    {
                        instalno.Visible = true;
                        Amounttot.Visible = true;
                        lbl_Instalmentno.Text = dtins.Rows[0]["NoOfInstallment"].ToString();

                        //if (Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == "" || Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == null)
                        //{
                        //    lblAmount.Text = "0";
                        //}
                        //else
                        //{
                        //    double lblamountd = Ins_Coursefees - Ins_Amount;

                        //    if (lblamountd >= 10000000)
                        //    {
                        //        lblAmount.Text = lblamountd.ToString("##\",\"00\",\"00\",\"000");
                        //    }
                        //    else if (lblamountd >= 100000)
                        //    {
                        //        lblAmount.Text = lblamountd.ToString("##\",\"00\",\"000");
                        //    }
                        //    else if (lblamountd >= 1000)
                        //    {
                        //        lblAmount.Text = lblamountd.ToString("#,000");
                        //    }
                        //    else
                        //    {
                        //        lblAmount.Text = "0";
                        //    }
                        //}
                    }
                    else
                    {
                        instalno.Visible = false;
                        Amounttot.Visible = false;
                    }
                }
            }
            else
            {
                studName.Visible = false;
                instalno.Visible = false;
                Amounttot.Visible = false;
                visfalsefees.Visible = false;
                lblmsg.Visible = false;
                ddl_instalnum.Visible = false;
                GridView1.Visible = false;
                lbl_errormsg.Text = "Student Record Not Found";
            }
        }
    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        instal.Visible = true;
            _Qry = "select Invoice_No from install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And centre_code='" + Session["SA_centre_code"] + "'";
            //Response.Write(_Qry);
            //Response.End();

            SqlDataReader dr123;
            dr123 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
            if (dr123.HasRows)
            {
                dr123.Read();

                Invoice_no = Convert.ToInt32(dr123["Invoice_No"].ToString());

                dr123.Close();
            }

            if (Invoice_no > 0)
            {
                _Qry = "Select (enq_personal_name) as Name from adm_personalparticulars where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And centre_code='" + Session["SA_centre_code"] + "'";
                //Response.Write(_Qry);
                //Response.End();
                SqlDataReader dr;
                dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                if (dr.HasRows)
                {
                    studName.Visible = true;
                    dr.Read();

                    lblstudname.Text = dr["Name"].ToString();

                    dr.Close();
                }
                else
                {
                    studName.Visible = false;
                }

                re = re + 1;
                string viewstud = "";
                if (re > 1)
                {
                    if (ViewState["stud_id"] == "" || ViewState["stud_id"] == null)
                    {

                    }
                    else
                    {
                        viewstud = ViewState["stud_id"].ToString();
                        viewstud = Regex.Replace(viewstud, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                    }
                }
                if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == viewstud)
                {
                    if (re > 0 && re == 1)
                    {
                        lbl_errormsg.Text = "";
                        if (txt_stuid.Text == null || txt_stuid.Text == "")
                        {
                            lblmsg.Visible = false;
                            ddl_instalnum.Visible = false;
                            GridView1.Visible = false;
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            ddl_instalnum.Visible = true;
                            GridView1.Visible = true;

                            _Qry = "select student_id from adm_studentid where centre_code='" + Session["SA_centre_code"] + "' and student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                            //Response.Write(_Qry);
                            //Response.End();
                            DataTable dt = new DataTable();
                            dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                            if (dt.Rows.Count > 0)
                            {
                                if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == dt.Rows[0]["student_id"].ToString())
                                {
                                    studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                                    fill();
                                    fillgrid();
                                    GridView1.Visible = true;
                                    lblmsg.Visible = true;
                                }
                                else
                                {
                                    lbl_errormsg.Text = "No Records Found";
                                    ddl_instalnum.Visible = false;
                                    GridView1.Visible = false;
                                    lblmsg.Visible = false;
                                }
                            }
                            else
                            {
                                lbl_errormsg.Text = "No Records Found";
                                ddl_instalnum.Visible = false;
                                GridView1.Visible = false;
                                lblmsg.Visible = false;
                            }
                        }
                    }
                    else if (re > 1)
                    {
                        if (txt_stuid.Text != "" && ddl_instalnum.SelectedValue != "")
                        {
                            //Response.End();
                            //student_id  & install nm
                            if (re > 0 && re > 1)
                            {
                                if (lblAmount.Text.Length > 1)
                                {
                                    if (lbl_Instalmentno.Text == "0")
                                    {

                                    }
                                    else
                                    {
                                       Response.Redirect("Receiptedit.aspx?studid=" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "&instlno=" + ddl_instalnum.SelectedValue + "");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    lbl_errormsg.Text = "";
                    if (txt_stuid.Text == null || txt_stuid.Text == "")
                    {
                        lblmsg.Visible = false;
                        ddl_instalnum.Visible = false;
                        GridView1.Visible = false;
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        ddl_instalnum.Visible = true;
                        GridView1.Visible = true;

                        _Qry = "select student_id from adm_studentid where centre_code='" + Session["SA_centre_code"] + "' and student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                        //Response.Write(_Qry);
                        //Response.End();
                        DataTable dt = new DataTable();
                        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (dt.Rows.Count > 0)
                        {
                            if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == dt.Rows[0]["student_id"].ToString())
                            {
                                studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                                fill();
                                fillgrid();
                                GridView1.Visible = true;
                                lblmsg.Visible = true;
                            }
                            else
                            {
                                lbl_errormsg.Text = "No Records Found";
                                ddl_instalnum.Visible = false;
                                GridView1.Visible = false;
                                lblmsg.Visible = false;
                            }
                        }
                        else
                        {
                            lbl_errormsg.Text = "No Records Found";
                            ddl_instalnum.Visible = false;
                            GridView1.Visible = false;
                            lblmsg.Visible = false;
                        }
                    }
                }
                ViewState["stud_id"] = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "").ToString();

                //_Qry = "Select sum(tatamtpaidwithtax) as Amount From install_amountdetails WHERE Receipt_no IS NOT NULL And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";";


                _Qry = "Select tatamtpaidwithtax as Amount From install_amountdetails WHERE Receipt_no>0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                DataTable dttotal = new DataTable();
                dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
                totalamt = 0;
                for (int i = 0; i < dttotal.Rows.Count; i++)
                {
                    if (totalamt == 0)
                    {
                        totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                    }
                    else
                    {
                        double dbval = 0;
                        dbval = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                        totalamt = totalamt + dbval;
                        //Response.Write(totalamt);
                        //Response.End();
                    }
                }

                _Qry = "Select Round(totalcourse_fees,0) as Amount From install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dttotal11 = new DataTable();
                dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                totalamt1 = 0;
                //for (int i = 0; i < dttotal11.Rows.Count; i++)
                //{
                //    if (totalamt1 == 0)
                //    {
                //        totalamt1 = Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
                //    }
                //    else
                //    {
                //        totalamt1 = totalamt1 + Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
                //    }
                //}
                totalamt1 = Convert.ToDouble(dttotal11.Rows[0]["Amount"].ToString());

                //Response.Write("14totalamt:" + totalamt);
                //Response.Write("14totalamt1:" + totalamt1);
                //Response.End();

                double fillamt = Convert.ToDouble(totalamt1) - Convert.ToDouble(totalamt);

                if (fillamt >= 10000000)
                {
                    lblAmount.Text = fillamt.ToString("##\",\"00\",\"00\",\"000");
                }
                else if (fillamt >= 100000)
                {
                    lblAmount.Text = fillamt.ToString("##\",\"00\",\"000");
                }
                else if (fillamt >= 1000)
                {
                    lblAmount.Text = fillamt.ToString("#,000");
                }
                else if (fillamt >= 1)
                {
                    lblAmount.Text = Convert.ToString(Math.Round(fillamt, 0));;
                }
                else
                {
                    lblAmount.Text = "0";
                }

                if (lblAmount.Text == "0")
                {
                    visfalsefees.Visible = true;
                    lblfeespaid.Text = "Fees Fully Paid";
                    lblfeespaid.Visible = true;
                    instal.Visible = false;
                }
                else
                {
                    instal.Visible = true;
                    visfalsefees.Visible = false;
                    lblfeespaid.Text = "";
                    lblfeespaid.Visible = false;
                }

                _Qry = "select Count (instal_number) as [NoOfInstallment],Sum(initialamount) as Amount From  install_amountdetails WHERE Receipt_no IS NULL And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                //Response.Write(_Qry);
                //Response.End();
                DataTable dtins = new DataTable();
                dtins = MVC.DataAccess.ExecuteDataTable(_Qry);

                if (dtins.Rows.Count > 0)
                {
                    instalno.Visible = true;
                    Amounttot.Visible = true;
                    lbl_Instalmentno.Text = dtins.Rows[0]["NoOfInstallment"].ToString();
                    //lblAmount.Text = dtins.Rows[0]["Amount"].ToString();
                    //if (Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == "" || Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == null)
                    //{
                    //    lblAmount.Text = "0";
                    //}
                    //else
                    //{
                    //    double lblamountd = Convert.ToDouble(dtins.Rows[0]["Amount"]);

                    //    //if (lblamountd >= 10000000)
                    //    //{
                    //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"00\",\"000");
                    //    //}
                    //    //else if (lblamountd >= 100000)
                    //    //{
                    //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"000");
                    //    //}
                    //    //else if (lblamountd >= 1000)
                    //    //{
                    //    //    lblAmount.Text = lblamountd.ToString("#,000");
                    //    //}
                    //    //else
                    //    //{
                    //    //    lblAmount.Text = "0";
                    //    //}
                    //}
                }
                else
                {
                    instalno.Visible = false;
                    Amounttot.Visible = false;
                }
            }
            else
            {
                _Qry = "Select count(*) From OldEnrolled_Details where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                int checount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

                if (checount > 0)
                {

                    int CENTER_CODE = 0;

                    _Qry = "select * from old_student_manual where center_code='" + Session["SA_centre_code"].ToString() + "' ";
                    DataTable dt86 = new DataTable();
                    dt86 = MVC.DataAccess.ExecuteDataTable(_Qry);
                    if (dt86.Rows.Count > 0)
                    {
                        string val = dt86.Rows[0]["center_code"].ToString();
                        if (Session["SA_centre_code"].ToString() == val)
                        {
                            CENTER_CODE = Convert.ToInt32(dt86.Rows[0]["manual_code"].ToString());
                        }
                    }


                    _Qry = "Select (enq_name) as Name from OldEnquiry_Details where Enquiry_no=(Select Enquiry_no From OldEnrolled_Details where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "') And Center_Code='" + CENTER_CODE + "'";
                    //Response.Write(_Qry);
                    //Response.End();
                    SqlDataReader dr;
                    dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                    if (dr.HasRows)
                    {
                        studName.Visible = true;
                        dr.Read();

                        lblstudname.Text = dr["Name"].ToString();

                        dr.Close();
                    }
                    else
                    {
                        studName.Visible = false;
                    }

                    re = re + 1;
                    string viewstud = "";
                    if (re > 1)
                    {
                        if (ViewState["stud_id"] == "" || ViewState["stud_id"] == null)
                        {

                        }
                        else
                        {
                            viewstud = ViewState["stud_id"].ToString();
                            viewstud = Regex.Replace(viewstud, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                        }
                    }
                    //Response.Write("Student Name:" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", ""));
                    //Response.Write("View Stud:" + viewstud);
                    //Response.End();
                    if (Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") == viewstud)
                    {
                        if (re > 0 && re == 1)
                        {
                            lbl_errormsg.Text = "";
                            if (txt_stuid.Text == null || txt_stuid.Text == "")
                            {
                                lblmsg.Visible = false;
                                ddl_instalnum.Visible = false;
                                GridView1.Visible = false;
                            }
                            else
                            {
                                lblmsg.Visible = true;
                                ddl_instalnum.Visible = true;
                                GridView1.Visible = true;

                                studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                                fill();
                                fillgrid();
                                GridView1.Visible = true;
                                lblmsg.Visible = true;
                            }
                        }
                        else if (re > 1)
                        {
                            if (txt_stuid.Text != "" && ddl_instalnum.SelectedValue != "")
                            {
                                //Response.End();
                                //student_id  & install nm
                                if (re > 0 && re > 1)
                                {
                                    if (lblAmount.Text.Length > 1)
                                    {
                                        if (lbl_Instalmentno.Text == "0")
                                        {

                                        }
                                        else
                                        {
                                            Response.Redirect("Receiptedit.aspx?studid=" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "&instlno=" + ddl_instalnum.SelectedValue + "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lbl_errormsg.Text = "";
                        if (txt_stuid.Text == null || txt_stuid.Text == "")
                        {
                            lblmsg.Visible = false;
                            ddl_instalnum.Visible = false;
                            GridView1.Visible = false;
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            ddl_instalnum.Visible = true;
                            GridView1.Visible = true;



                            studentid = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "");
                            fill();
                            fillgrid();
                            GridView1.Visible = true;
                            lblmsg.Visible = true;


                        }
                    }
                    ViewState["stud_id"] = Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "").ToString();
                    if (Invoice_no > 0)
                    {
                        _Qry = "Select tatamtpaidwithtax as Amount From install_amountdetails WHERE Receipt_no>0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                        DataTable dttotal = new DataTable();
                        dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
                        totalamt = 0;
                        for (int i = 0; i < dttotal.Rows.Count; i++)
                        {
                            if (totalamt == 0)
                            {
                                totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                            }
                            else
                            {

                                totalamt = totalamt + Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                                //Response.Write(totalamt);
                                //Response.End();
                            }
                        }

                        _Qry = "Select Round(totalcourse_fees,0) as Amount From install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                        DataTable dttotal11 = new DataTable();
                        dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                        totalamt1 = 0;
                        totalamt1 = Convert.ToDouble(dttotal11.Rows[0]["Amount"].ToString());
                        //for (int i = 0; i < dttotal11.Rows.Count; i++)
                        //{
                        //    if (totalamt1 == 0)
                        //    {
                        //        totalamt1 = Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
                        //    }
                        //    else
                        //    {
                        //        totalamt1 = totalamt1 + Convert.ToDouble(dttotal11.Rows[i]["Amount"].ToString());
                        //    }
                        //}
                        //Response.Write("123totalamt:" + totalamt);
                        //Response.Write("123totalamt1:" + totalamt1);
                        //Response.End();
                        double fillamt = Convert.ToDouble(totalamt1) - Convert.ToDouble(totalamt);

                        if (fillamt >= 10000000)
                        {
                            lblAmount.Text = fillamt.ToString("##\",\"00\",\"00\",\"000");
                        }
                        else if (fillamt >= 100000)
                        {
                            lblAmount.Text = fillamt.ToString("##\",\"00\",\"000");
                        }
                        else if (fillamt >= 1000)
                        {
                            lblAmount.Text = fillamt.ToString("#,000");
                        }
                        else if (fillamt >= 1)
                        {
                            lblAmount.Text = Convert.ToString(Math.Round(fillamt, 0));;
                        }
                        else
                        {
                            lblAmount.Text = "0";
                        }
                        if (lblAmount.Text == "0")
                        {
                            visfalsefees.Visible = true;
                            lblfeespaid.Text = "Fees Fully Paid";
                            lblfeespaid.Visible = true;
                            instal.Visible = false;
                        }
                        else
                        {
                            instal.Visible = true;
                            visfalsefees.Visible = false;
                            lblfeespaid.Text = "";
                            lblfeespaid.Visible = false;
                        }
                        _Qry = "select Count (instal_number) as [NoOfInstallment],Sum(initialamount) as Amount From  install_amountdetails WHERE Receipt_no IS NULL And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                        DataTable dtins = new DataTable();
                        dtins = MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (dtins.Rows.Count > 0)
                        {
                            instalno.Visible = true;
                            Amounttot.Visible = true;
                            lbl_Instalmentno.Text = dtins.Rows[0]["NoOfInstallment"].ToString();
                            //lblAmount.Text = dtins.Rows[0]["Amount"].ToString();
                            //if (Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == "" || Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == null)
                            //{
                            //    lblAmount.Text = "0";
                            //}
                            //else
                            //{
                            //    double lblamountd = Convert.ToDouble(dtins.Rows[0]["Amount"]);

                            //    //if (lblamountd >= 10000000)
                            //    //{
                            //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"00\",\"000");
                            //    //}
                            //    //else if (lblamountd >= 100000)
                            //    //{
                            //    //    lblAmount.Text = lblamountd.ToString("##\",\"00\",\"000");
                            //    //}
                            //    //else if (lblamountd >= 1000)
                            //    //{
                            //    //    lblAmount.Text = lblamountd.ToString("#,000");
                            //    //}
                            //    //else
                            //    //{
                            //    //    lblAmount.Text = "0";
                            //    //}
                            //}
                        }
                        else
                        {
                            instalno.Visible = false;
                            Amounttot.Visible = false;
                        }
                    }
                    else
                    {
                        int Ins_Coursefees = 0;

                        _Qry = "Select Replace(Round(Course_Fees,0),'.00','') as Course_Fees from Old_install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";
                        //Response.Write(_Qry);
                        //Response.End();
                        SqlDataReader dr1;
                        dr1 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);

                        if (dr1.HasRows)
                        {
                            dr1.Read();

                            Ins_Coursefees = Convert.ToInt32(dr1["Course_Fees"].ToString());

                            dr1.Close();
                        }

                        int Ins_Amount = 0;

                        _Qry = "select Replace(Replace(Round(Sum(Install_Amount),0),'.00',''),'-','') as Amount From  Old_install_amountdetails WHERE Receipt_no!=0 And status='completed' And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";

                        SqlDataReader dr2;
                        dr2 = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
                        {
                            dr2.Read();
                            if (dr2["Amount"].ToString() == "" || dr2["Amount"].ToString() == null)
                            {
                                Ins_Amount = 0;
                            }
                            else
                            {
                                Ins_Amount = Convert.ToInt32(dr2["Amount"].ToString());
                            }
                            dr2.Close();
                        }

                        _Qry = "Select total_install_amount as Amount From Old_install_amountdetails WHERE Receipt_no>0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                        DataTable dttotal = new DataTable();
                        dttotal = MVC.DataAccess.ExecuteDataTable(_Qry);
                        totalamt = 0;
                        for (int i = 0; i < dttotal.Rows.Count; i++)
                        {
                            if (totalamt == 0)
                            {
                                totalamt = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                            }
                            else
                            {
                                //double dbval = 0;
                                //dbval = Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                                totalamt = totalamt + Convert.ToDouble(dttotal.Rows[i]["Amount"].ToString());
                                //Response.Write(totalamt);
                                //Response.End();
                            }
                        }
                        _Qry = "Select Round(total_course_fees,0) as Amount From Old_install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
                        DataTable dttotal11 = new DataTable();
                        dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                        totalamt1 = 0;
                        totalamt1 = Convert.ToDouble(dttotal11.Rows[0]["Amount"].ToString());

                        //_Qry = "Select install_amount,install_amount_tax From Old_install_amountdetails WHERE Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";

                        //DataTable dttotal11 = new DataTable();
                        //dttotal11 = MVC.DataAccess.ExecuteDataTable(_Qry);
                        //totalamt1 = 0;
                        //double totalamt2 = 0;
                        //for (int i = 0; i < dttotal11.Rows.Count; i++)
                        //{
                        //    if (totalamt1 == 0)
                        //    {
                        //        totalamt1 = Convert.ToDouble(dttotal11.Rows[i]["install_amount"].ToString());
                        //    }
                        //    else
                        //    {
                        //        totalamt1 = totalamt1 + Convert.ToDouble(dttotal11.Rows[i]["install_amount"].ToString());
                        //    }
                        //    if (totalamt2 == 0)
                        //    {
                        //        totalamt2 = Convert.ToDouble(dttotal11.Rows[i]["install_amount_tax"].ToString());
                        //    }
                        //    else
                        //    {
                        //        totalamt2 = totalamt2 + Convert.ToDouble(dttotal11.Rows[i]["install_amount_tax"].ToString());
                        //    }
                        //}

                        //Response.Write("TotAmt:" + totalamt);
                        //Response.Write("TotAmt1:" + totalamt1);
                        ////Response.Write("TotAmt2:" + totalamt2);
                        //Response.End();

                        double fillamt = Convert.ToDouble(totalamt1) - Convert.ToDouble(totalamt);

                        if (fillamt >= 10000000)
                        {
                            lblAmount.Text = fillamt.ToString("##\",\"00\",\"00\",\"000");
                        }
                        else if (fillamt >= 100000)
                        {
                            lblAmount.Text = fillamt.ToString("##\",\"00\",\"000");
                        }
                        else if (fillamt >= 1000)
                        {
                            lblAmount.Text = fillamt.ToString("#,000");
                        }
                        else if (fillamt >= 1)
                        {
                            lblAmount.Text = Convert.ToString(Math.Round(fillamt, 0));;
                        }
                        else
                        {
                            lblAmount.Text = "0";
                        }
                        if (lblAmount.Text == "0")
                        {
                            visfalsefees.Visible = true;
                            lblfeespaid.Text = "Fees Fully Paid";
                            lblfeespaid.Visible = true;
                            instal.Visible = false;
                        }
                        else
                        {
                            visfalsefees.Visible = false;
                            lblfeespaid.Text = "";
                            lblfeespaid.Visible = false;
                        }
                        _Qry = "select Count (install_number) as [NoOfInstallment],Sum(Install_Amount) as Amount From  Old_install_amountdetails WHERE Receipt_no=0 And Student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' And Center_Code='" + CENTER_CODE + "'";
                        //Response.Write(_Qry);
                        //Response.End();
                        DataTable dtins = new DataTable();
                        dtins = MVC.DataAccess.ExecuteDataTable(_Qry);

                        if (dtins.Rows.Count > 0)
                        {
                            instalno.Visible = true;
                            Amounttot.Visible = true;
                            lbl_Instalmentno.Text = dtins.Rows[0]["NoOfInstallment"].ToString();

                            //if (Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == "" || Regex.Replace(dtins.Rows[0]["Amount"].ToString(), "^[ \t\r\n]+|[ \t\r\n]+$", "") == null)
                            //{
                            //    lblAmount.Text = "0";
                            //}
                            //else
                            //{
                            //    double lblamountd = Ins_Coursefees - Ins_Amount;

                            //    if (lblamountd >= 10000000)
                            //    {
                            //        lblAmount.Text = lblamountd.ToString("##\",\"00\",\"00\",\"000");
                            //    }
                            //    else if (lblamountd >= 100000)
                            //    {
                            //        lblAmount.Text = lblamountd.ToString("##\",\"00\",\"000");
                            //    }
                            //    else if (lblamountd >= 1000)
                            //    {
                            //        lblAmount.Text = lblamountd.ToString("#,000");
                            //    }
                            //    else
                            //    {
                            //        lblAmount.Text = "0";
                            //    }
                            //}
                        }
                        else
                        {
                            instalno.Visible = false;
                            Amounttot.Visible = false;
                        }
                    }
                }
                else
                {
                    studName.Visible = false;
                    instalno.Visible = false;
                    Amounttot.Visible = false;
                    visfalsefees.Visible = false;
                    lblmsg.Visible = false;
                    ddl_instalnum.Visible = false;
                    GridView1.Visible = false;
                    lbl_errormsg.Text = "Student Record Not Found";
                }
            }
    }
   
   private void fill()
    {
        if (Invoice_no > 0)
        {
            _Qry = "select Top 1 instal_number from install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' and centre_code='" + Session["SA_centre_code"] + "' and ISNULL(Receipt_no,0)=0 ";
            //_Qry = "select instal_number from install_amountdetails where student_id='" + txt_stuid.Text + "' and centre_code='" + Session["SA_centre_code"] + "' and Receipt_no = '' ";
            //Response.Write("<br/>"+_Qry);
            DataTable dt = new DataTable();

            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                ddl_instalnum.DataSource = dt;

                ddl_instalnum.DataValueField = "instal_number";
                ddl_instalnum.DataTextField = "instal_number";
                ddl_instalnum.DataBind();
            }
            else
            {
                instal.Visible = false;
            }
        }
        else
        {
            _Qry = "Select count(*) From OldEnrolled_Details where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "'";
            int checount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);

            if (checount > 0)
            {
                int centre_code = 0;

                _Qry = "select * from old_student_manual where center_code='" + Session["SA_centre_code"].ToString() + "' ";
                DataTable dt8 = new DataTable();
                dt8 = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt8.Rows.Count > 0)
                {
                    string val = dt8.Rows[0]["center_code"].ToString();
                    if (Session["SA_centre_code"].ToString() == val)
                    {
                        centre_code = Convert.ToInt32(dt8.Rows[0]["manual_code"].ToString());
                    }
                }


                _Qry = "select Top 1 install_number from Old_install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' and center_code='" + centre_code + "' and ISNULL(Receipt_no,0)=0 order by install_number asc";
                //_Qry = "select instal_number from install_amountdetails where student_id='" + txt_stuid.Text + "' and centre_code='" + Session["SA_centre_code"] + "' and Receipt_no = '' ";
                //Response.Write("<br/>" + _Qry);
                //Response.End();
                DataTable dt = new DataTable();

                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dt.Rows.Count > 0)
                {
                    ddl_instalnum.DataSource = dt;

                    ddl_instalnum.DataValueField = "install_number";
                    ddl_instalnum.DataTextField = "install_number";
                    ddl_instalnum.DataBind();
                }
                else
                {
                    instal.Visible = false;
                }
            }
            else
            {
                studName.Visible = false;
                instalno.Visible = false;
                Amounttot.Visible = false;
                visfalsefees.Visible = false;
                lblmsg.Visible = false;
                ddl_instalnum.Visible = false;
                GridView1.Visible = false;
                lbl_errormsg.Text = "Student Record Not Found";
            }
        }
    }
    private void fillgrid()
    {
        int centre_code = 0;

        _Qry = "select * from old_student_manual where center_code='" + Session["SA_centre_code"].ToString() + "' ";
        DataTable dt83 = new DataTable();
        dt83 = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt83.Rows.Count > 0)
        {
            string val = dt83.Rows[0]["center_code"].ToString();
            if (Session["SA_centre_code"].ToString() == val)
            {
                centre_code = Convert.ToInt32(dt83.Rows[0]["manual_code"].ToString());
            }
        }
        if (Invoice_no > 0)
        {
            _Qry = "select Receipt_no,instal_number,student_id from install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' and centre_code='" + Session["SA_centre_code"] + "' and Receipt_no <> ''";
            //Response.Write("<br/>" +_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            _Qry = "select Receipt_no,install_number as instal_number,student_id from Old_install_amountdetails where student_id='" + Regex.Replace(txt_stuid.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "") + "' and Receipt_no <> 0 and center_code='" + centre_code + "' Order by install_number";
            //Response.Write("<br/>" +_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Receiptdetails.aspx");
    //}
}
