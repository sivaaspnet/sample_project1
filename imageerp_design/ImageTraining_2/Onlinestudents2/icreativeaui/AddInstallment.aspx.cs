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

public partial class Onlinestudents2_superadmin_AddInstallment : System.Web.UI.Page
{

    string Qry,_Qry, _Qry1, _Qry2, _Qry3;


    int val1, val2, val3, val4, val5, val6, Result1, Result2, Result3, countnot, countincre;

    string sinitial, stax, stotamount, sinitipaid, staxpaid, stotpaid,sval1,sval2,sval3;

    double dinitial, dtax, dtotamount, dinitipaid, dtaxpaid, dtotpaid;
   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        
        
        if (HdnSub.Value == "")
        {
           // Btnsubmit.Visible = true;
            BtnSub.Visible = false;
            tblamountdisplay.Visible=false;

           
        }
        else if (HdnSub.Value == "2")
        {
            //Btnsubmit.Visible = false;
            BtnSub.Visible = true;
            tblamountdisplay.Visible = true;

           
           
        }
      
    }


   private void fillgrid()
    {

        // _Qry = "select replace(username,'~','''')as username,replace(userid,'~','''')as userid,replace(password,'~','''')as password,replace(centre_useremail,'~','''')as centre_useremail,centrelogin_id from img_centrelogin where role='Faculty' and centre_code='" + Session["SA_centre_code"] + "' and username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centrelogin_id desc";


       /// _Qry = "select id.studentid as stuid,id.invoiceid,id.coursefees,ia.initialamount,ia.initialamounttax,ia.totalinitialamount,rd.amount,rd.taxamount,rd.totalamount,rd.amount,rd.receiptno,rd.taxamount,rd.dateins,rd.totalamount,case rd.Status when 1 then 'Completed' when 0 then 'Pending' end as Status from erp_invoicedetails id inner join erp_receiptdetails rd on rd.studentid=id.studentid inner join erp_installAmountDetails ia on ia.studentid=id.studentid  and ia.installNumber=rd.installNo  where ia.studentid='" + TxtStudentId.Text + "'";


        _Qry = "select ia.installnumber,ia.status,id.studentid as stuid,id.invoiceid,id.coursefees,ia.initialamount,ia.initialamounttax,ia.totalinitialamount,rd.receiptno,convert(varchar(20),isnull(rd.amount,0),1) as amount,convert(varchar(20),isnull(rd.taxamount,0),1) as taxamount,convert(varchar(20),isnull(rd.totalamount,0),1) as totalamount,convert(varchar, rd.dateins, 103) as dateins,rd.totalamount from erp_installamountdetails ia inner join erp_invoicedetails id on id.studentid=ia.studentid and id.invoiceid=ia.invoiceno and id.status='active' and id.centercode=ia.centercode left join erp_receiptdetails rd on rd.studentid=id.studentid and id.invoiceid=rd.invoiceno and ia.installNumber=rd.installNo where ia.studentid='" + TxtStudentId.Text.Trim() + "'";

        //Response.Write(_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

            for (int i=0; i < dt.Rows.Count;i++ )
            {

                lblshowstuid.Text = dt.Rows[i]["stuid"].ToString();

                
                //dinitial = iinitial + (Math.Truncate(Double.Parse(dt.Rows[i]["initialamount"].ToString()) * 1) / 1);

                //iinitial = Convert.ToInt32(dinitial);

                //PotSavTon = test + (Math.Truncate(Double.Parse(dt.Rows[i]["initialamounttax"].ToString()) * 1) / 1);

                //test=Convert.ToInt32(PotSavTon);

              


                dinitial +=Convert.ToDouble( dt.Rows[i]["initialamount"].ToString());
                dtax += Convert.ToDouble(dt.Rows[i]["initialAmountTax"].ToString());
                dtotamount += Convert.ToDouble(dt.Rows[i]["totalInitialAmount"].ToString());
                dinitipaid += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                dtaxpaid += Convert.ToDouble(dt.Rows[i]["taxamount"].ToString());
                dtotpaid += Convert.ToDouble(dt.Rows[i]["totalamount"].ToString());
                

               

                if (dt.Rows[i]["amount"].ToString() == "0.00")
                {
                    dt.Rows[i]["amount"] = "";
                }

                if (dt.Rows[i]["taxamount"].ToString() == "0.00")
                {
                    dt.Rows[i]["taxamount"] = "";
                }

                if (dt.Rows[i]["totalamount"].ToString() == "0.00")
                {
                    dt.Rows[i]["totalamount"] = "";
                }
                
            }



            lblinitialview.Text =Convert.ToString(dinitial);
            lbltaxview.Text = Convert.ToString(dtax);
            lbltotalview.Text = Convert.ToString(dtotamount);
            lblinitialPaidView.Text = Convert.ToString(dinitipaid);
            lbltaxpaidview.Text = Convert.ToString(dtaxpaid);
            lbltoatalPaidView.Text = Convert.ToString(dtotpaid);

            val1 = Convert.ToInt32(dinitial);
            val2 = Convert.ToInt32(dinitipaid);

            Result1 = val1 - val2;

            val3 = Convert.ToInt32(dtax);
            val4 = Convert.ToInt32(dtaxpaid);

            Result2 = val3 - val4;


            val5 = Convert.ToInt32(dtotamount);
            val6 = Convert.ToInt32(dtotpaid);

            Result3 = val5 - val6;

            //Response.Write(val3);
            //Response.End();

            lblbalancefeesview.Text = Convert.ToString(Result1);

            lblbalancetaxview.Text = Convert.ToString(Result2);

            lblbalancetotview.Text = Convert.ToString(Result3);

            GridView1.DataSource = dt;
            GridView1.DataBind();
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)

    {
        int val=2;

        HdnSub.Value =Convert.ToString( val);

       // Response.Write(HdnSub.Value);
        //Response.End();

        if (HdnSub.Value == "")
        {
            //Btnsubmit.Visible = true;
            BtnSub.Visible = false;
            tblamountdisplay.Visible = false;

           

        }
        else if (HdnSub.Value == "2")
        {
            //Btnsubmit.Visible = false;
            BtnSub.Visible = true;
            tblamountdisplay.Visible = true;

           

        }

        fillgrid();
       

    }


    private void refersh()
    {
        TxtCenterCode.Text ="";
        TxtInvoice.Text = "";
        TxtCourseId.Text = "";

        
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void BtnSub_Click(object sender, EventArgs e)
    {

        Qry = "select count(ins.status) from erp_installAmountDetails ins inner join erp_invoicedetails s on ins.invoiceNo=s.invoiceId and s.status='active' where ins.studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(TxtStudentId.Text.Trim()) + " ' and ins.status='pending' and ins.centerCode='" + Session["SA_centre_code"] + "'";


                int counta;
                counta = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, Qry);
                if (counta > 0)
                {
                    lblmsg1.Text = "You Have pending installments";
                }
                else
                {


                    _Qry3 = "select count(studentid) from erp_installAmountDetails where studentid='" + MVC.CommonFunction.ReplaceQuoteWithTild(TxtStudentId.Text.Trim()) + "' and centerCode='" + Session["SA_centre_code"] + "'";

                    int counta1;
                    counta1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry3);
                    if (counta1 > 0)
                    {

                        _Qry = "select top 1 installnumber from erp_installAmountDetails where studentid='" + TxtStudentId.Text.Trim() + "' and centerCode='" + Session["SA_centre_code"] + "' order by installnumber desc";
                        int instnumbercount = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
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
                       _Qry1 = "select inv.studentid,max(coursefees) as coursefee,sum(amount) as Paidamount,max(coursefees)-sum(amount) as balance,max(inv.invoiceid) as invoiceno,max(inv.courseid) as courseid from erp_invoicedetails inv inner join erp_receiptdetails rec on rec.studentid=inv.studentid and rec.centercode=inv.centercode and inv.centercode='" + Session["SA_centre_code"] + "' where inv.studentid='" + TxtStudentId.Text.Trim() + "' and inv.centerCode='" + Session["SA_centre_code"] + "'  group by inv.studentid";
                       DataTable dt1 = new DataTable();
                        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry1);
                        if (dt1.Rows.Count > 0)
                        {
                            //TxtCenterCode.Text = dt1.Rows[0]["centercode"].ToString();
                            TxtInvoice.Text = dt1.Rows[0]["invoiceno"].ToString();
                            TxtCourseId.Text = dt1.Rows[0]["CourseId"].ToString();


                            if ( Convert.ToInt64(dt1.Rows[0]["Paidamount"]) > 0)
                            {

                                _Qry2 += " INSERT INTO erp_installAmountDetails (centercode,invoiceno,studentId,installNumber,initialAmount,initialAmountTax,totalInitialAmount,courseId,status,installDate) values('" + Session["SA_centre_code"] + "','" + TxtInvoice.Text + "','" + TxtStudentId.Text + "','" + countincre + "','0','0','0','" + TxtCourseId.Text + "','pending',getdate())";
                                //    countincre = countincre + 1;
                                //}
                                //Response.Write(_Qry2);
                                //Response.End();

                                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
                                fillgrid();
                                lblmsg1.Text = "Installment Added sucessfully";
                            }
                            else
                            {
                                lblmsg1.Text = "Already Paid full amount";
                            }
                            refersh();
                        }
                        else
                        {
                            lblmsg1.Text = "Already Paid full amount";
                        }
                        

                    }

                    else
                    {
                        lblmsg1.Text = "No record Found";
                    }
                }
    }
    
}
