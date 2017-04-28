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
using System.IO;
using System.Text;
using System.Data.SqlClient;


public partial class superadmin_outstandingreport : System.Web.UI.Page
{
    string _Qry; double balanamt = 0; double balantax = 0; double totbalan = 0;
   
    DataTable dtname = new DataTable();
    DataTable dtamt = new DataTable();
    DataTable finalDt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        // showdownload();
        if (!IsPostBack)
        {

            ddlmonth.SelectedValue = String.Format("{0:M }", DateTime.Now).Trim();
            ddlyear.SelectedValue = string.Format("{0:yyyy}", DateTime.Now).Trim();
            fillgrid();
            //getInstalmentDetails();
        }
         
        
    }


    public void ExportTableData(DataTable dtdata)
    {
        //string fname = "Monthlycollection of " + Session["SA_Location"] + " centre.xls";
        //string attach = "attachment;filename="+fname+" ";
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", attach);
        //Response.ContentType = "application/ms-excel";

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=Balancereport-of-" + Session["SA_Location"] + "-center.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";

        if (dtdata != null)
        {
            //foreach (DataColumn dc in dtdata.Columns)
            //{
                for (int i = 0; i < dtdata.Columns.Count - 1; i++)
                {
                    Response.Write(dtdata.Columns[i].ToString() + "\t");
                }
                //sep = ";";
           // }
            Response.Write(System.Environment.NewLine);
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count-1; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }

   private void fillgrid()
    {
        try
        {
           string headCentrecode = ConfigurationManager.AppSettings["Ipadcentrecode"].ToString();

           if (Session["SA_centre_code"].ToString() == headCentrecode)
            {

                _Qry = _Qry + " and b.centre_code in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode + "')";
            }
            



            _Qry = @"select inv.studentid,inv.invoiceid,per.enq_personal_name as Name,enq_personal_mobile as Phone,course.program from erp_invoicedetails inv inner join
adm_personalparticulars per on inv.studentid=per.student_id and per.centre_code=inv.centercode and inv.status='active' and ";

            if (Session["SA_centre_code"].ToString() == headCentrecode)
            {

                _Qry = _Qry + " inv.centercode in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode + "')";
            }
            else
            {
                _Qry = _Qry + " inv.centercode='" + Session["SA_centre_code"] + "'";
            }
      
          _Qry = _Qry + @"  inner join 
img_enquiryform enq on enq.enq_number=per.enq_number and enq.centre_code=inv.centerCode inner join 
img_coursedetails course on inv.courseid=course.course_id  ";
            dtname = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

            _Qry = @"select inv.centercode,inv.studentid,inv.installno,convert(varchar,ins.installdate,103) as installdate,inv.coursefees,inv.invoiceid,fee.tax,round(ins.initialamount,0) as initialamount,round(ins.initialamounttax,0) as initialamounttax,round(ins.totalinitialamount,0) as totalinitialamount,ins.installnumber,convert(varchar,round(isnull(receipt.amount,0),0),0) as paidamount,round(isnull(receipt.taxamount,0),0) as paidtax,round(isnull(receipt.totalamount,0),0) as paidtotal,receipt.installno  from erp_invoicedetails inv inner join 
erp_installamountdetails ins on inv.studentid=ins.studentid and inv.invoiceid=ins.invoiceno and inv.status='active'  and ";
            if (Session["SA_centre_code"].ToString() == headCentrecode)
            {

                _Qry = _Qry + " inv.centercode in(select distinct centre_code from img_centre_coursefee_details where runningInvoiceCentrecode='" + headCentrecode + "')";
            }
            else
            {
                _Qry = _Qry + " inv.centercode='" + Session["SA_centre_code"] + "'";
            }

            _Qry = _Qry + @"   inner join
img_centre_coursefee_details fee on fee.program=inv.courseid and inv.centercode=fee.centre_code and inv.track=fee.track left join 
erp_receiptDetails receipt on  receipt.studentId=inv.studentId  and ins.invoiceno=receipt.invoiceno and receipt.installNo=ins.installNumber  where inv.coursefees>(select sum(amount) from erp_receiptdetails  where studentid=inv.studentId and invoiceno=inv.invoiceId)   and month(ins.installdate)<='" +ddlmonth.SelectedValue+"' and year(ins.installdate)<='"+ddlyear.SelectedValue+"' ";
            dtamt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString, _Qry);

           

           // Response.Write(_Qry);


           
            finalDt.Columns.Add(new DataColumn("StudentId",System .Type .GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Program", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("Phone", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("balanceamount", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("balancetax", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("totalbalance", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("lastdate", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("invoice", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("noofinstallment", System.Type.GetType("System.String")));
            finalDt.Columns.Add(new DataColumn("detailsinfo", System.Type.GetType("System.String")));
          //  finalDt.Columns.Add(new DataColumn("tax", System.Type.GetType("System.Double")));



            DataRow dr = finalDt.NewRow();
            
            DataTable dt2 = new DataTable();
           // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] args=new string[3];
            args[0] = "studentId";
            args[1] = "invoiceid";
            args[2] = "tax";

            dt2 = dtamt.DefaultView.ToTable(true, args);
            foreach(DataRow drs in dt2.Rows)
            {
                
                double balacneAmt = getBalanceAmt(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'");
                double taxAmt =Math.Round( balacneAmt*(Convert.ToDouble(drs["tax"]) / 100));
                //double taxAmt = 0;//Convert.ToDouble(drs["tax"].ToString());
                double totalAmt =Math.Round( balacneAmt + taxAmt);
                string[] info = new string[0];
                if (balacneAmt > 0)
                {
                    info=getInstalmentDetails(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'");
                    dr = finalDt.NewRow();
                    dr["StudentId"] = drs["studentid"];
                    dr["Program"] = getValues(dtname, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "program");
                    dr["Name"] = getValues(dtname, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "Name");
                    dr["Phone"] = getValues(dtname, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'", "Phone");
                    dr["invoice"] = drs["invoiceid"];
                    dr["lastdate"] = getinstalldate(dtamt,"studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'");
                    dr["noofinstallment"] = info[0]; //getCount1(dtamt, "studentid='" + drs["studentid"].ToString() + "' and invoiceid='" + drs["invoiceid"].ToString() + "'");
                    dr["balanceamount"] = balacneAmt.ToString();
                    dr["balancetax"] = taxAmt.ToString();
                    dr["totalbalance"] = totalAmt.ToString();
                    dr["detailsinfo"] = info[1];
                    finalDt.Rows.Add(dr);
                    balanamt += Convert.ToDouble(dr["balanceamount"]);
                    balantax += Convert.ToDouble(dr["balancetax"]);
                    totbalan += Convert.ToDouble(dr["totalbalance"]);
                }
            }
            lblAmount.Text = amts(balanamt);
            lblTax.Text = amts(balantax);
            lbltotalAmt.Text = amts(totbalan);
            //_Qry = "Select '' as studentId,'' as courseName";

            



          //   string    centreCode = Session["SA_centre_code"].ToString();
            

          //// _Qry = "exec [spBalanceReport] " + ddlmonth.SelectedValue + "," + ddlyear.SelectedValue + ",'" + centreCode + "'";
          //  DataTable dt = new DataTable();
          //  dt = MVC.DataAccess.ExecuteDataTable(MVC.DataAccess.ConnectionString,_Qry);
          //  int balanceAmt = 0;
          //  int balanceTax = 0;
          //  int totalbalance = 0;
          //  for (int i = 0; i < dt.Rows.Count; i++)
          //  {
          //      balanceAmt += Convert.ToInt32(dt.Rows[i]["balanceamount"]);
          //      balanceTax += Convert.ToInt32(dt.Rows[i]["balancetax"]);
          //      totalbalance += Convert.ToInt32(dt.Rows[i]["totalbalance"]);
          //  }
          //  lblAmount.Text = amts(Convert.ToInt32(balanceAmt));
          //  lblTax.Text = amts(Convert.ToInt32(balanceTax));
          //  lbltotalAmt.Text = amts(Convert.ToInt32(totalbalance));
          //  Gridview_admission.DataSource = dt;
          //  Gridview_admission.DataBind();
          //  LinkButton1.Visible = true;

            Gridview_admission.DataSource = finalDt;
            Gridview_admission.DataBind();
            LinkButton1.Visible = true;
            foreach(GridViewRow gr in Gridview_admission.Rows)
            {
                //lit
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
            Response.Write("Pleae Contact Admin");
        }
    }
    string getValues(DataTable dt, string expression,string column)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            res = dr[0][column].ToString();
        }
        return res;
    }
    string getCount(DataTable dt, string expression)
    {
        string res = "";
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {

            res = dr.Length.ToString();
        }

        return res;
    }
    string getCount1(DataTable dt, string expression)
    {
        string  res = "";

        int installno = 0;
            double paidAmt = 0;
            double amt = 0;
           
            DataRow[] dr = new DataRow[100];
            dr = dt.Select(expression);
            if (dr.Length > 0)
            {
                //res = dr.Length.ToString();
                foreach (DataRow val in dr)
                {
                    paidAmt += Convert.ToDouble(val["paidamount"].ToString());
                    amt += Convert.ToDouble(val["initialamount"].ToString());
                  
                    if (amt > paidAmt)
                    {
                        installno = installno + 1;
                    }
                    else if (amt < paidAmt)
                    {
                        installno = installno - 1;
                    }
                    else
                    {
                        installno = 0;
                    }
                }
                 
            }           
             

            return installno.ToString() ;
    }
    string getinstalldate(DataTable dt, string expression)
    {
        string installdate = "";
        int res = 0;
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            res = dr.Length - 1;
            installdate=dr[res]["installdate"].ToString();
        }
        return installdate;
    }
    string[] getInstalmentDetails(DataTable dt,string expression)
    {
        DataTable tempdt = new DataTable();

        tempdt.Columns.Add(new DataColumn("installno",System.Type.GetType("System.String")));
        tempdt.Columns.Add(new DataColumn("Amount",System.Type.GetType("System.String")));
        tempdt.Columns.Add(new DataColumn("PaidAmt",System.Type.GetType("System.String")));
        tempdt.Columns.Add(new DataColumn("status", System.Type.GetType("System.String")));
        tempdt.Columns.Add(new DataColumn("balance", System.Type.GetType("System.String")));

        // IF status=1 -> Paid fees is grater than amount, else 0



        int installmentnumber = 0;

        double installamount = 0;
        double paidamount = 0;
        double extraAmount = 0;
        double balanceAmt = 0;
 

        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
      
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                installamount = Convert.ToDouble(val["initialamount"]);
                paidamount = Convert.ToDouble(val["paidamount"]);

                DataRow tempdr = tempdt.NewRow();
                tempdr["installno"] = val["installnumber"];
                tempdr["Amount"] = val["initialamount"];
                tempdr["PaidAmt"] = val["paidamount"];
                tempdr["balance"] = Convert.ToString(installamount - paidamount);
                tempdr["status"] = "1";
                if (installamount > paidamount)
                {
                    tempdr["status"] = "0";
                }
                else
                {
                    extraAmount += (paidamount - installamount);
                }
               
                tempdt.Rows.Add(tempdr);

            }


        }
        installmentnumber = 0;
        string[] installdetails = new string[2];
       installdetails[1] = "<table border='1'><tr class='tooltip' style='height:22px;'><th>Installno </th><th>Installamounts</th><th>Paidamount</th><th>Balance</th></tr>";

        foreach (DataRow dr1 in tempdt.Rows)
        {
            
            installamount = Convert.ToDouble(dr1["Amount"].ToString());
            paidamount = Convert.ToDouble(dr1["PaidAmt"].ToString());

            balanceAmt =installamount - paidamount;
            //-10   20
            if (extraAmount > 0 && dr1["status"]=="0")
            {
                if (extraAmount > balanceAmt)
                {
                    extraAmount -= balanceAmt;
                   dr1["status"] = "1";
                }
                else if (extraAmount < balanceAmt)
                {
                    dr1["PaidAmt"] =Convert .ToString( paidamount + extraAmount);
                    balanceAmt -= extraAmount;
                    extraAmount -= balanceAmt;
                    
                    dr1["status"] = "0";
                }
                else
                {
                    extraAmount -= balanceAmt;
                    dr1["status"] = "0";
                }
               
            }
            //installdetails += "<tr class='tooltip'><td>" + dr1["installno"].ToString() + "</td><td>" + dr1["Amount"].ToString() + "</td><td>" + dr1["PaidAmt"].ToString() + "</td><td>" + balanceAmt.ToString() + "-" + extraAmount.ToString() + "</td></tr>";
   
           
            if (dr1["status"] == "0")
            {
                installdetails[1] += "<tr class='tooltip'><td>" + dr1["installno"].ToString() + "</td><td>" + dr1["Amount"].ToString() + "</td><td>" + dr1["PaidAmt"].ToString() + "</td><td>" + balanceAmt.ToString() + "</td></tr>";
                 installmentnumber += 1;
               
            }
          
        }
               //installamount += Convert.ToDouble(val["initialamount"].ToString());
                //paidamount += Convert.ToDouble(val["paidamount"].ToString());
                //if (installamount > paidamount)
                //{
                //    installdetails += "<tr><td>" + val["installnumber"].ToString() + "</td><td>" + val["initialamount"].ToString() + "</td><td>" + val["paidamount"].ToString() + "</td><td>" + (Convert.ToDouble(val["initialamount"].ToString()) - Convert.ToDouble(val["paidamount"].ToString())) + "</td></tr>";
                //}

        installdetails[1] += "</table>";
        installdetails[0] = installmentnumber.ToString();
        return installdetails;
            
    }
    double  getBalanceAmt(DataTable dt, string expression)
    {
        double res = 0;
        double paidAmt = 0;
        double amt = 0;
        DataRow[] dr = new DataRow[100];
        dr = dt.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach(DataRow val in dr)
            {
                paidAmt += Convert.ToDouble(val["paidamount"].ToString());
                amt += Convert.ToDouble(val["initialamount"].ToString());
            }
        }
        res = amt - paidAmt;
    
        return res;
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
    protected void Gridview_admission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview_admission.PageIndex = e.NewPageIndex;
        fillgrid();
    }   
   
   
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        fillgrid();
        ExportTableData(finalDt);
        //if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        //{
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=Imagedoc.xls");
        //    Response.Charset = "";
        //    // If you want the option to open the Excel file without saving than
        //    // comment out the line below
        //    // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/vnd.xls";
        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //    Gridview_admission.RenderControl(htmlWrite);

        //    Response.Write(stringWrite.ToString());
        //    Response.End();
        //}
        //else
        //{
        //    lblmessage.Text = "Please Contact Admin";
        //}
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void view_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
