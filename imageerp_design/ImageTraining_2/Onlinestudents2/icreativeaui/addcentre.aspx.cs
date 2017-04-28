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

public partial class superadmin_addcentre : System.Web.UI.Page
{
    string _Qry, _Qry1, _Qry2, _Qry3, _Qry4, _Qry5, _Qry6,centreid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }  
        if (!IsPostBack)
        {
            txtc_code.ReadOnly = false;
            fillgrid();
            hdnID.Value = "";
        }
       
    }
    public string removetilde(string str)
    {
        return MVC.CommonFunction.ReplaceTildWithQuote(str);
      
    }
    private void fillgrid()
    {

        // _Qry = "select b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code,b.centre_region,b.centre_category from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.role='CentreManager' and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchlocation.Text) + "%' and a.username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txtsearchname.Text) + "%' order by centre_id desc";

        //_Qry = "select b.centre_location,a.centrelogin_id,a.username,a.centre_useremail,a.role,b.centre_id,b.centre_code,b.centre_region,b.centre_category from img_centredetails b inner join img_centrelogin a on a.centre_code=b.centre_code where a.role='CentreManager' and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchlocation.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' and a.username like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txtsearchname.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centre_id desc";

        _Qry = "select center_address,insititueName,address1,address2,For_institute,cd.centre_id,cd.centre_code,centre_location,centre_region,Enquiry_Count,Rec_Total,InvoiceCount,IncentiveCount from img_centredetails cd inner join Receipt_Total_No rd on rd.Centre_Code=cd.centre_code inner join Invoice_Count ic on ic.Centre_Code=cd.Centre_Code inner join Incentive_Count iv on iv.Centre_Code=cd.Centre_Code  where cd.centre_code  like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txt_searchcode.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' and centre_location like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txt_searchlocation.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' order by centre_id desc";


        //Response.Write(_Qry);
        //Response.End();
        DataTable dt = new DataTable();
        dt=MVC.DataAccess.ExecuteDataTable(_Qry);
        grdcentre.DataSource = dt;
        grdcentre.DataBind();

    }
    private void insertcentre()
    {
        string centretemplate = "<table width=''800'' border=''0'' align=''center'' cellpadding=''0'' cellspacing=''0''>  <tr> <td class=''menu_text''></td></tr><tr>  <td bgcolor=''#000000''></td></tr></table><table width=''800'' border=''1'' align=''center'' cellpadding=''0'' cellspacing=''0'' bordercolor=''#000000''><tr><td ><table  border=''0'' align=''center'' cellpadding=''0'' cellspacing=''0'' bordercolor=''#000000'' style=''width: 750px''><tr><td width=''700px'' style=''height: 600px''><table width=''700px''  border=''0''><tr><td width=''200'' >##logo##</td><td width=''500px''><table width=''100%'' align=''CENTER''><tr><td class=''style3 style5''><div align='''' class=''style5 style1''><strong>&nbsp;&nbsp;&nbsp;&nbsp;## institue name##</strong></div></td></tr><tr ><td class=''style3''><div align=''''>&nbsp;&nbsp;&nbsp; ##address 1##</div></td></tr> <tr ><td class=''style3''><div align=''''>&nbsp;&nbsp;&nbsp;&nbsp;##address 2## </div></td></tr></table></td></tr></table><table width=''700px''><tr><td width=''140''><table><tr><td width=''48''>R.No<strong>:</strong></td><td width=''80'' height=''26''><table width=''80''  cellpadding=''0'' cellspacing=''0'' style=''border-bottom:1px solid #333;'' ><tr>  <td style=''height: 19px''><b>##Receiptnumber##</b></td> </tr></table></td> </tr><tr><td>Inv.No<strong>:</strong></td><td height=''26''><table width=''80'' cellpadding=''0'' cellspacing=''0'' style=''border-bottom:1px solid #333;''><tr>  <td style=''height: 25px''><b>##Invoicenumber##</b></td></tr></table></td></tr><tr><td>Stu.Id <strong>:</strong></td><td height=''26''><table width=''80'' cellpadding=''0'' cellspacing=''0'' style=''border-bottom:1px solid #333;''><tr>  <td style=''height: 25px''><b>##lblstudid##</b></td></tr></table></td></tr></table></td><td width=''282'' align=''center''><strong><u>RECEIPT</u></strong></td><td width=''286''><table width=''283''><tr><td width=''98''>Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>:</strong></td><td width=''127'' height=''26''><table width=''140'' height=''25'' border=''0'' cellpadding=''0'' cellspacing=''0''><tr>  <td>  ##Receiptdate##</td></tr></table></td></tr><tr><td>Course Code <strong>:</strong> </td><td height=''26''><table width=''140'' height=''25'' border=''0'' cellpadding=''0'' cellspacing=''0'' class=''border''><tr>  <td>##Coursecode##</td></tr></table></td></tr></table></td> </tr><tr><td colspan=''3'' style=''height: 30px'' valign=''middle''> <strong>RECEIVED</strong> with thanks from Mr. / Mrs. / Ms&nbsp;<b>##Studentname##</b> the sum of Rs. ##sum##&nbsp;  /-(Rupees</td></tr><tr><td colspan=''3'' style=''height: 30px'' valign=''middle''><b> ##Amountinwords## </b>)&nbsp; through  ##DDnumber##  </td></tr><tr><td colspan=''3'' style=''height: 30px'' valign=''middle''> ##Bank## ##BankName## being payment towards ##Paymenttowards##&nbsp; &nbsp;for the Month of ##Monthinstallment##</td></tr>  </table> <table border=''0'' cellpadding=''0'' cellspacing=''0''><tr>  <td><strong>Payment Details :- </strong></td></tr> </table> <table width=''700px'' style=''height:150px;'' border=''0'' cellpadding=''0'' cellspacing=''0''> <tr><td width=''200'' style=''height:150px;''><table width=''191'' height=''97'' border=''1'' cellpadding=''0'' cellspacing=''0'' bordercolor=''#000000''><tr><td width=''187'' height=''95''><table width=''176'' height=''79'' border=''0'' cellspacing=''0'' align=''center'' ><tr>  <td height=''23''><strong>Fees Rs. </strong></td>  <td width=''106''><table width=''100'' height=''25'' border=''0'' cellpadding=''0'' cellspacing=''0'' class=''border''><tr>  <td style=''height: 25px''>##FeesAmount##</td></tr>  </table></td></tr><tr>  <td width=''74'' height=''29''><strong>Tax&nbsp; </strong></td>  <td width=''106''><table width=''100'' height=''25'' border=''0'' cellpadding=''0'' cellspacing=''0''><tr>  <td>##Tax##</td></tr>  </table></td></tr><tr>  <td><strong>Total Rs. </strong> </td>  <td width=''106''><table width=''100'' height=''25'' border=''0'' cellpadding=''0'' cellspacing=''0'' class=''border''><tr>  <td>##Totalamount##</td></tr>  </table></td></tr></table></td></tr></table></td><td width=''510'' style=''height: 150px'' ><table width=''357'' height=''116'' border=''0'' cellspacing=''0'' align=''right'' ><tr><td align=''center''>For <strong>##Image Infotainment Limited##</strong><table width='''' align=''right''> </table></td></tr><tr><td width=''355'' height=''37''>&nbsp;</td></tr><tr><td align=''center''>Authorized Signatory</td></tr></table></td> </tr></table> <table><tr><td>*Cheque Subject to realization</td></tr> <tr><td>*Fees Once Paid will not be refunded </td> </tr> </table>  <tr> <td align=''left''> <b> ##CentreAddress##</b></td></tr><tr><td align=''center'' valign=''middle''> </td></tr></table> </tr>  <tr> <td > </tr></table>";
        string address1 = " Regd. Office : 32,T.T.K Road,Alwarpet,Chennai-600018.";
        string address2 = " Phone:044-24661682/24670229 Fax:044-42737755 ";
        if ((hdnID.Value == "" || hdnID.Value == null))
        {
            _Qry = "select count(centre_id) from img_centredetails where centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text.Trim()) + "'";
            //Response.Write(_Qry);
            //Response.End();
            int count;
            count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            if (count > 0)
            {
                lblmsg1.Text = "The Centre Code Already Exist";

            }
            //else
            //{
            //    _Qry1 = "select count(centrelogin_id) from img_centrelogin where userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "' or centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_manager_mailid.Text) + "'";
            //    //Response.Write(_Qry1);
            //    int count1;
            //    count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry1);
            //    if (count1 > 0)
            //    {
            //        lblmsg1.Text = "Manager UserID or EmailId Already Exist";
            //    }

                else
                {
                    _Qry = "insert into img_centredetails(centre_code,centre_location,receiptTemplate,centre_region,centre_createdby,centre_updatedby,runningStudentIdType,Enquiry_Count,centre_dateins,centre_dateupd,For_institute,address1,address2,insititueName)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_location.Text) + "','" + centretemplate + "','" + ddc_region.SelectedValue + "','" + Session["SA_Username"] + "','Notupdated','month','" + txt_enquirycount.Text + "',getdate(),getdate(),'Image Infotainment Limited','" + address1 + "','" + address2 + "','Image Infotainment Limited')";

                    //Response.Write(_Qry);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

                  _Qry1 = "insert into Receipt_Total_No(Rec_Total,Centre_Code)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_receiptcount.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "')";

                    //Response.Write(_Qry1);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);

                  _Qry3 = "insert into Invoice_Count(InvoiceCount,Centre_Code)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_invoicecount.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "')";

                    //Response.Write(_Qry3);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry3);

                    _Qry4 = "insert into Incentive_Count(incentivecount,Centre_Code)values('" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_incentivecount.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "')";

                    //Response.Write(_Qry4);
                    //Response.End();
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry4);

                    //_Qry1 = "SELECT Top 1 centre_id FROM img_centredetails ORDER BY centre_id DESC";
                    ////Response.Write(_Qry);
                    //DataTable dt = new DataTable();
                    //dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
                    //centreid = dt.Rows[0][0].ToString();

                    //_Qry1 = "insert into img_centrelogin(centre_id,centre_category,username,userid,password,role,centre_code,centre_region,centre_useremail,createdby,updatedby,dateins,dateupd)values(" + centreid + ",'" + txtcentrecat.SelectedValue + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managername.Text) + "','" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "','" + txtc_managerpwd.Text + "','" + ddrole.SelectedValue + "','" + txtc_code.Text + "','" + ddc_region.SelectedValue + "','" + txt_manager_mailid.Text + "','" + Session["SA_Username"] + "','Not Updated',getdate(),getdate())";
                    ////Response.Write(_Qry1);
                    //// Response.End();
                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                    //fillgrid();

                    //_Qry3 = "select count(cat_id) from img_categories where centre_category='" + txtcentrecat.SelectedValue + "'";
                    ////Response.Write(_Qry);
                    //int count3;
                    //count3 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry3);
                    //if (count3 > 0)
                    //{
                    //    lblmsg1.Text = "";
                    //}
                    //else
                    //{
                    //    _Qry = "insert into img_categories(centre_category)values('" + txtcentrecat.SelectedValue + "')";
                    //    //Response.Write(_Qry);
                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //}

                    //_Qry2 = "insert into img_batch_count(centre_code,batch_code,student_code,invoice_code,receipt_code)values('" + txtc_code.Text + "','0','0','0','0')";
                    ////Response.Write(_Qry);
                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry2);
                    lblmsg1.Text = "Centre Inserted Successfully";

                    fillgrid();

               // }
            }

        }
        
    }
    
   
    private void refresh()
    {
        txtc_code.Text = "";

        txtc_location.Text = "";
        ddc_region.SelectedValue = "";

        txt_enquirycount.Text = "";
        txt_receiptcount.Text = "";
        txt_invoicecount.Text = "";
        hdnID.Value = "";
       
        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        centreupdate();
        insertcentre();
        refresh();
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "lnkedit")
        {
            _Qry = "select center_address,insititueName,address1,address2,For_institute,cd.centre_id,cd.centre_code,centre_location,centre_region,Enquiry_Count,Rec_Total,InvoiceCount,incentivecount from img_centredetails cd inner join Receipt_Total_No rd on rd.Centre_Code=cd.centre_code inner join Invoice_Count ic on ic.Centre_Code=cd.Centre_Code inner join incentive_count iv on iv.centre_code=cd.centre_code where cd.centre_id=" + e.CommandArgument.ToString() + "";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                txtc_code.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centre_code"].ToString());
                txtc_location.Text = MVC.CommonFunction.ReplaceQuoteWithTild(dt.Rows[0]["centre_location"].ToString());
                ddc_region.SelectedValue = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["centre_region"].ToString());
                txt_enquirycount.Text = dt.Rows[0]["Enquiry_Count"].ToString();
                txt_receiptcount.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["Rec_Total"].ToString());
                txt_invoicecount.Text = dt.Rows[0]["InvoiceCount"].ToString();
                txt_incentivecount.Text = dt.Rows[0]["incentivecount"].ToString();
                hdnID.Value = dt.Rows[0]["centre_id"].ToString();


                txtforins.Text = dt.Rows[0]["For_institute"].ToString();
                txtcentreaddress.Text = MVC.CommonFunction.ReplaceTildWithQuote(dt.Rows[0]["center_address"].ToString());
                txtinstitute.Text = dt.Rows[0]["insititueName"].ToString();
                txtadd1.Text = dt.Rows[0]["address1"].ToString();
                txtadd2.Text = dt.Rows[0]["address2"].ToString();

        
                lblmsg1.Text = "";
                txtc_code.ReadOnly = true;
                

            }

           // txt_enquirycount.ReadOnly = true;
           // txt_invoicecount.ReadOnly = true;
           // txt_receiptcount.ReadOnly = true;


        }
    }
    private void centreupdate()
    {
        if (hdnID.Value != "")
        {
            //_Qry = "select count(centre_id) from img_centredetails where centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "' and centre_id <> " + hdnID.Value + " ";
            ////Response.Write(_Qry);
            ////Response.End();
            //int count;
            //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
            //if (count > 0)
            //{
            //    lblmsg1.Text = "The Centre Code already Exist";
            //}
            //else
            //{
            //    _Qry1 = "select count(centrelogin_id) from img_centrelogin where (userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "' or centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_manager_mailid.Text) + "') and centrelogin_id <> " + hdnID1.Value + "";
            //    //Response.Write(_Qry1);
            //    int count1;
            //    count1 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry1);
            //    if (count1 > 0)
            //    {
            //        lblmsg1.Text = "Manager UserID or EmailId Already Exist";
            //    }
            //    else
            //    {
            _Qry = "update img_centredetails set  center_address='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtcentreaddress.Text) + "',insititueName='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtinstitute.Text) + "',address1='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtadd1.Text) + "',address2='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtadd2.Text) + "',For_institute='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtforins.Text) + "',      centre_code='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_code.Text) + "',centre_location='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_location.Text) + "',centre_region='" + ddc_region.SelectedValue + "',centre_updatedby='" + Session["SA_Username"] + "',centre_dateupd=getdate() where centre_id=" + hdnID.Value + "";
                    //Response.Write(_Qry);
                    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);



                    //_Qry1 = "update img_centrelogin set username='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managername.Text) + "',userid='" + MVC.CommonFunction.ReplaceQuoteWithTild(txtc_managerid.Text) + "',password='" + txtc_managerpwd.Text + "',centre_code='" + txtc_code.Text + "',centre_region='" + ddc_region.SelectedValue + "',role='" + ddrole.SelectedValue + "',centre_useremail='" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_manager_mailid.Text) + "',updatedby='" + Session["SA_Username"] + "',dateupd=getdate() where centrelogin_id=" + hdnID1.Value + "";
                    ////Response.Write(_Qry);
                    //MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry1);
                    //fillgrid();


                    //_Qry3 = "select count(cat_id) from img_categories where centre_category='" + txtcentrecat.SelectedValue + "'";
                    ////Response.Write(_Qry);
                    //int count3;
                    //count3 = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry3);
                    //if (count3 > 0)
                    //{
                    //    lblmsg1.Text = "";
                    //}
                    //else
                    //{
                    //    _Qry = "insert into img_categories(centre_category)values('" + txtcentrecat.SelectedValue + "')";
                    //    //Response.Write(_Qry);
                    //    MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                    //}

                    lblmsg1.Text = "The Centre Updated Successfully";
                    fillgrid();
                //}
            //}

        }
       

    }
    protected void grdcentre_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcentre.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        fillgrid();

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        refresh();
    }
}
