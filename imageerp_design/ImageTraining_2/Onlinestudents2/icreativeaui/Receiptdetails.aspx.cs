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
    double pendingamt = 0;
    string Qry;
    int countincre;
    protected void Page_Load(object sender, EventArgs e)
    {
   
 
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Home.aspx");
        }
        if (Request.QueryString["val"] == "1")
        {
            Submit();
        }
      
       
    }

    private string amts(double amountvalue)
    {
        string words;
        if (amountvalue >= 10000000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"00\",\"000");
        }
        else if (amountvalue >= 100000)
        {
            words = "Rs " + amountvalue.ToString("##\",\"00\",\"000");
        }
        else
        {
            words = "Rs " + amountvalue.ToString("#,000");
        }
        return words;
    }

    private void Submit()
    {
        _Qry = "select count(studentId) from erp_receiptdetails where studentId='" + txt_stuid.Text.Trim() + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
        int count = 0;
        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString,_Qry);
        if (count > 0)
        {           

            studName.Visible = true;
            instalno.Visible = true;
            Amounttot.Visible = true;
            visfalsefees.Visible = true;
            instal.Visible = true;

            double coursefee = 0;
            double coursetax = 0;
            double totalcoursefee = 0;
            double paidamount = 0;
            double pendingwithouttax = 0;
            int buttonclick = 0;

            _Qry = "select * from spreceipttaxalter('" + txt_stuid.Text.Trim() + "') order by invoiceid asc";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                GridView2.DataSource = dt1;
                GridView2.DataBind();
            }
            else
            {
                GridView2.Visible = false;
            }
            //_Qry = "select per.enq_personal_name,rec.studentId,rec.amount,rec.taxAmount,rec.totalAmount,rec.receiptNo,rec.installNo from erp_receiptDetails rec inner join erp_installAmountDetails ins on rec.studentId=ins.student_id inner join adm_personalparticulars per on per.student_id=rec.studentId where rec.studentId='"+txt_stuid.Text+"'";
            _Qry = "select * from spreceipttax('" + txt_stuid.Text.Trim() + "') order by installno asc";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                lblstudname.Text = dt.Rows[0]["studentname"].ToString();
                coursefee = Convert.ToDouble(dt.Rows[0]["coursefees"]);
                coursetax = Convert.ToDouble(dt.Rows[0]["coursetax"]);
                lbl_Instalmentno.Text = dt.Rows[0]["pendinginstallment"].ToString();
                ddl_instalnum.Visible = false;
                if (dt.Rows[0]["invstatus"].ToString().ToLower() == "np")
                {
                    lbl_errormsg.Text = "This Student does not paid previous months installments. Please contact admin";
                    instal.Visible = false;
                    btn_submit.Visible = false;
                    Button1.Visible = false;
                }
                if (dt.Rows[0]["nextInstallment"].ToString() != "0")
                {
                    ddl_instalnum.Items.Clear();
                    if (dt.Rows[0]["invstatus"].ToString().ToLower() == "active")
                    {
                        ddl_instalnum.Items.Add(new ListItem("select", ""));
                        ddl_instalnum.Items.Add(new ListItem(dt.Rows[0]["nextInstallment"].ToString() + " - " + dt.Rows[0]["monthinstall"].ToString(), dt.Rows[0]["nextInstallment"].ToString()));
                        ddl_instalnum.Visible = true;
                    }
                    else if (dt.Rows[0]["invstatus"].ToString().ToLower() == "np")
                    {
                        lbl_errormsg.Text = "This Student does not paid previous months installments. Please contact admin";
                        instal.Visible = false;
                        btn_submit.Visible = false;
                        Button1.Visible = false;
                    }
                }
                else if (dt.Rows[0]["nextInstallment"].ToString() != "0" && ddl_instalnum.SelectedValue != "")
                {
                    Response.Redirect("Receiptedit.aspx?studid=" + txt_stuid.Text.Trim() + "&instlno=" + ddl_instalnum.SelectedValue + "&balance=" + pendingamt + "");
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (paidamount == 0)
                {
                    paidamount = Convert.ToDouble(dt.Rows[i]["paidamt"]);
                }
                else
                {
                    paidamount = paidamount + Convert.ToDouble(dt.Rows[i]["paidamt"]);
                }
            }
            pendingwithouttax = coursefee - paidamount;
          // Response.Write("pendingwithouttax " + pendingwithouttax);
          //  Response.Write("Course fee " + coursefee + " paid " + paidamount + "");
          // pendingamt = (coursefee + (coursefee * coursetax / 100)) - (paidamount + (paidamount * coursetax / 100));
            // commented for test
            pendingamt = pendingwithouttax + (pendingwithouttax * coursetax / 100);  
            hdnpending.Value = Convert.ToString( Math.Round(pendingamt,0));
            lblAmount.Text = amts(pendingamt);
           
            if (pendingamt <= 0)
            {
                instal.Visible = false;
                btn_submit.Visible = false;
                Button1.Visible = false;
            }
            else
            {
                //Button1.Visible = true;
            }
        }
        else
        {
            lbl_errormsg.Text = "No Receipts found";
        }

    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (ddl_instalnum.SelectedValue != "")
            {
                Server.Transfer("Receiptedit.aspx?studid=" + txt_stuid.Text.Trim() + "&instlno=" + ddl_instalnum.SelectedValue + "&balance=" + hdnpending.Value + "");
            }
            else
            {


                Qry = "select count(ins.status) from erp_installAmountDetails ins inner join erp_invoicedetails inv on ins.studentid=inv.studentid  and inv.status='active' and ins.invoiceNo=inv.invoiceId where ins.studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_stuid.Text.Trim()) + " ' and ins.status='pending' and ins.centerCode='" + Session["SA_centre_code"] + "'";
                int counta1;
                counta1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
                if (counta1 > 0)
                {
                    Button1.Visible = false;
                    // lbl_errormsg.Text = "You Have pending installments";
                }
                else
                {
                    Qry = "select inv.studentid,max(coursefees) as coursefee,sum(amount) as Paidamount,max(coursefees)-sum(amount) as balance,max(inv.invoiceid) as invoiceno,max(inv.courseid) as courseid from erp_invoicedetails inv inner join erp_receiptdetails rec on rec.studentid=inv.studentid and rec.invoiceNo=inv.invoiceId and rec.centercode=inv.centercode  and inv.centercode='" + Session["SA_centre_code"] + "' where inv.studentid='" + txt_stuid.Text.Trim() + "' and inv.status='active' and  inv.centerCode='" + Session["SA_centre_code"] + "'  group by inv.studentid";
                    DataTable dt11 = new DataTable();
                    dt11 = MVC.DataAccess.ExecuteDataTable(Qry);
                    if (dt11.Rows.Count > 0)
                    {
                        if (Convert.ToInt64(dt11.Rows[0]["Paidamount"]) > 0)
                        {
                            Button1.Visible = true;
                        }


                    }
                }
                Submit();


            }
        }
    }
    protected void Validate_Special(object sender, ServerValidateEventArgs e)
    {
        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^[^'\"`~=]+$");
        e.IsValid = rx.IsMatch(txt_stuid.Text);
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        Submit();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Qry = "select count(ins.status) from erp_installAmountDetails ins inner join erp_invoicedetails inv on ins.studentid=inv.studentid  and inv.status='active' and ins.invoiceNo=inv.invoiceId where ins.studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_stuid.Text.Trim()) + " ' and ins.status='pending' and ins.centerCode='" + Session["SA_centre_code"] + "'"; 
        int counta;
        counta = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
        if (counta > 0)
        {
            lbl_errormsg.Text = "You Have pending installments";
        }
        else
        {


            Qry = "select count(studentid) from erp_installAmountDetails where studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_stuid.Text.Trim()) + "' and centerCode='" + Session["SA_centre_code"] + "'";

            int counta1;
            counta1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
            if (counta1 > 0)
            {

                Qry = "select top 1 installnumber from erp_installAmountDetails ins inner join erp_invoicedetails inv on ins.studentid=inv.studentid and inv.status='active' and inv.invoiceid=ins.invoiceno  where ins.studentid='" + txt_stuid.Text.Trim() + "' and ins.centerCode='" + Session["SA_centre_code"] + "' order by installnumber desc";
                int instnumbercount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
                //if (instnumbercount.ToString() == "1")
                //{

                //     countincre = count + 1 ;
                //}
                //else if (instnumbercount.ToString() == "0")
                //{
                //    countincre = count;
                //}
                countincre = instnumbercount + 1;
                //Response.Write(countincre);
                //Response.End();
                Qry = "select inv.studentid,max(coursefees) as coursefee,sum(amount) as Paidamount,max(coursefees)-sum(amount) as balance,max(inv.invoiceid) as invoiceno,max(inv.courseid) as courseid from erp_invoicedetails inv inner join erp_receiptdetails rec on rec.studentid=inv.studentid and rec.centercode=inv.centercode and rec.invoiceno=inv.invoiceid and inv.centercode='" + Session["SA_centre_code"] + "' where inv.studentid='" + txt_stuid.Text.Trim() + "' and  inv.status='active' and inv.centerCode='" + Session["SA_centre_code"] + "'  group by inv.studentid";
                DataTable dt1 = new DataTable();
                dt1 = MVC.DataAccess.ExecuteDataTable(Qry);
                if (dt1.Rows.Count > 0)
                {
                    //TxtCenterCode.Text = dt1.Rows[0]["centercode"].ToString();
                   string invno = dt1.Rows[0]["invoiceno"].ToString();
                    string courseid1 = dt1.Rows[0]["CourseId"].ToString();


                    if (Convert.ToInt64(dt1.Rows[0]["Paidamount"]) > 0)
                    {

                        //Response.Redirect("receiptconfirmation.aspx?studentid="+txt_stuid.Text.Trim()+"");
                        Qry += " INSERT INTO erp_installAmountDetails (centercode,invoiceno,studentId,installNumber,initialAmount,initialAmountTax,totalInitialAmount,courseId,status,installDate) values('" + Session["SA_centre_code"] + "','" + invno + "','" + txt_stuid.Text.Trim() + "','" + countincre + "','0','0','0','" + courseid1 + "','pending',getdate())";
                            countincre = countincre + 1;
                        //}
                        //Response.Write(_Qry2);
                        //Response.End();

                        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, Qry);
                        //fillgrid();
                        lbl_errormsg.Text = "Installment Added sucessfully";
                        Submit();
                    }
                    else
                    {
                        lbl_errormsg.Text = "Already Paid full amount1";
                    }
                   // refersh();
                }
                else
                {
                    lbl_errormsg.Text = "Already Paid full amount";
                }


            }

            else
            {
                lbl_errormsg.Text = "No record Found";
            }
        }
    }
}
