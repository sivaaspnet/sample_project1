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

public partial class Onlinestudents2_superadmin_StudentReportDetails : System.Web.UI.Page
{
    string _Qry;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["SA_Centrerole"] .ToString() == "Printing Department")
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = true;
            GridView4.Visible = false;
            GridView5.Visible = true;
         
            
        }
        if (Session["SA_Centrerole"] .ToString() == "R&D")
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
          
            GridView1.Visible = false;
            gridassesment.Visible = true;
        }
        if (Session["SA_Centrerole"] .ToString() == "Counselor")
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = true;
            a5.Visible = false;
            a6.Visible = false;
          
         
        }
        if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
          
            gridSort.Visible = false;
            GridView1.Visible = false;
            dd2.Visible = true;
        }
        if (Session["SA_Centrerole"] .ToString() == "CentreManager")
        {
            a6.Visible = true;
           
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            GridView5.Visible = false;
            GridView4.Visible = true;
            gridSort.Visible = false;
            GridView1.Visible = false;
            gridassesment.Visible = true;
            assesment_search.Visible = true;
           
        }
        if (Session["SA_Centrerole"] .ToString() == "Technical Head")
        {

            a4.Visible = false;
            a5.Visible = false;
            gridSort.Visible = false;
            GridView1.Visible = false;
            gridassesment.Visible = true;
            assesment_search.Visible = true;
            a6.Visible = false;
          

        }
        if (!IsPostBack)
        {
            fillcentre();
            filldrop();
            fillbook();
            fillbook1();
           fillassesment();
            expressupdate();
            fillgrid1();
            
            if (Session["SA_Centrerole"] .ToString() == "SuperAdmin")
            {
                if (Session["SA_centre_code"] == null || Session["SA_centre_code"] == "" || Session["SA_centre_code"].ToString() == "11")
                {

                    _Qry = "select * from erp_studenttransfer where newstudentid is null";
                    DataTable dtt = new DataTable();
                    dtt = MVC.DataAccess.ExecuteDataTable(_Qry);
                    GridView3.DataSource = dtt;
                    GridView3.DataBind();

                }
                else
                {

                    filltransfer();
                }
            }
        }
        
    }
    
    private void fillcentre()
    {
        _Qry = "Select replace(Centre_location,'~','''') as Centre_location,Centre_Code from img_centredetails";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Centre_location";
        DropDownList1.DataValueField = "Centre_Code";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select", ""));
    }
    private void expressupdate()
    {
        _Qry = "select a.student_id,Enrolled_By,a.enq_personal_name,b.coursename,b.enq_number,isnull(a.student_lastname,'.*.') as ExpressEnrollSt from adm_personalparticulars a inner join adm_generalinfo b on a.student_id=b.student_id where a.Admission_id>0 and studentstatus='active'  and isnull(a.student_lastname,'.*.')='.*.'";


        if (Session["SA_centre_code"].ToString() != "" && Session["SA_centre_code"].ToString() != null && Session["SA_centre_code"].ToString() != "11")
        {
            _Qry = _Qry + "and b.centre_code like '%" + Session["SA_centre_code"].ToString() + "%'";
        }
        _Qry = _Qry + " Order by a.Admission_id desc";
  
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        GridView1.DataSource = dt;
        GridView1.DataBind();



        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl = new Label();
            HiddenField hdn = new HiddenField();

            lbl = (Label)gr.FindControl("lblStudId");
            hdn = (HiddenField)gr.FindControl("HdnExpressSt");
            HiddenField hdn1 = new HiddenField();
            hdn1 = (HiddenField)gr.FindControl("hdnEnqid");
            if (hdn.Value == ".*.")
            {
                lbl.Text = "<a href='expressupdate.aspx?end_id=" + hdn1.Value + "'>" + lbl.Text + "</a>";
                lbl.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            }

        }
       
       
    }
    private void filldrop()
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
        {

            _Qry = @"select distinct studentid,enq_personal_name,status,convert(varchar,requesteddate,103) as requesteddate,reason from erp_studentdrop inner join adm_personalparticulars
on studentid=student_id where status='Requested' and centercode='" + Session["SA_centre_code"].ToString() + "'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
           // Label5.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count <= 0)
            {
                //notification.Visible = false;
            }
            else
            {
              //  Label7.Text = "Technical Head  requested to Drop the following Student";
               // Label7.Visible = true;
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();

            foreach (GridViewRow gr in GridView2.Rows)
            {
                LinkButton remove = new LinkButton();
                remove = (LinkButton)gr.FindControl("LinkButton1");
                remove.Visible = false;
            }
            //if (GridView2.Columns.Count > 0)
            //{
            //    GridView2.Columns[4].Visible = false;
            //}
            //else
            //{
            //    GridView2.HeaderRow.Cells[4].Visible = false;
            //    foreach (GridViewRow gvr in GridView2.Rows)
            //    {
            //        gvr.Cells[4].Visible = false;
            //    }
            //}

            //_Qry = "select convert(varchar,requestdate,103) as requestdate,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave inner join adm_personalparticulars on studentid=student_id where centercode ='" + Session["SA_centre_code"] + "' and status_cen='Pending'";
            //DataTable d1 = new DataTable();
            //d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            //grleave.DataSource = d1;
            //grleave.DataBind();
           }
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
        {

              // Label7.Text = "CentreManager Approved your Request for the Following student";
              //Label7.Visible = true;
            _Qry = @"select distinct studentid,enq_personal_name,status,convert(varchar,requesteddate,103) as requesteddate,reason from erp_studentdrop inner join adm_personalparticulars
on studentid=student_id where (status='Dropped' or status='Declined') and action='active' and centercode='" + Session["SA_centre_code"].ToString() + "' ";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
             //  Label5.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count <= 0)
            {
                //notification.Visible = false;
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            foreach (GridViewRow gr in GridView2.Rows)
            {
                LinkButton drop = new LinkButton();
                drop = (LinkButton)gr.FindControl("LinkButton2");
                drop.Visible = false;              
            }

            //_Qry = "select convert(varchar,requestdate,103) as requestdate,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave inner join adm_personalparticulars on studentid=student_id where centercode ='" + Session["SA_centre_code"] + "' and status='Pending'";
            //DataTable d1 = new DataTable();
            //d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            //grleave.DataSource = d1;
            //grleave.DataBind();
           


        }
    }

    private void fillgrid1()
    {

        //leavegrid();
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" || Session["SA_Centrerole"] .ToString() == "Technical Head")
        {
            int leave = 0;
            _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where  centercode='" + Session["SA_centre_code"].ToString() + "' and (status='Pending' or status_cen='pending') ";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                leave = Convert.ToInt32(dt1.Rows[0]["noofdays"]);
            }
            else
            {
                leave = 0;
            }

            if (leave < 4)
            {
                _Qry = " update erp_studentleave set status_cen='Approved' where centercode='" + Session["SA_centre_code"].ToString() + "' and  status_cen='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where  centercode='" + Session["SA_centre_code"].ToString() + "' and status='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                grleave.DataSource = dt;
                grleave.DataBind();
                foreach (GridViewRow gr in grleave.Rows)
                {
                    Label lbl = new Label();
                    lbl = (Label)gr.FindControl("lblstatus");
                    LinkButton lnkapprove = new LinkButton();
                    lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
                    LinkButton lnkdecline = new LinkButton();
                    lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
                    if (lbl.Text == "Pending")
                    {
                        lnkapprove.Visible = true;
                        lnkdecline.Visible = true;
                        lbl.Visible = false;
                    }
                    else
                    {
                        lnkapprove.Visible = false;
                        lnkdecline.Visible = false;
                        lbl.Visible = true;
                    }
                }


            }
            else
            {
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where  centercode='" + Session["SA_centre_code"].ToString() + "' and status='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                grleave.DataSource = dt;
                grleave.DataBind();
                foreach (GridViewRow gr in grleave.Rows)
                {
                    Label lbl = new Label();
                    lbl = (Label)gr.FindControl("lblstatus");
                    LinkButton lnkapprove = new LinkButton();
                    lnkapprove = (LinkButton)gr.FindControl("lnkapprove");
                    LinkButton lnkdecline = new LinkButton();
                    lnkdecline = (LinkButton)gr.FindControl("lnkdecline");
                    if (lbl.Text == "Pending")
                    {
                        lnkapprove.Visible = true;
                        lnkdecline.Visible = true;
                        lbl.Visible = false;
                    }
                    else
                    {
                        lnkapprove.Visible = false;
                        lnkdecline.Visible = false;
                        lbl.Visible = true;
                    }
                }

            }


            if (grleave.Columns.Count > 0)
            {
                grleave.Columns[7].Visible = false;
            }
            else
            {
                grleave.HeaderRow.Cells[7].Visible = false;
                foreach (GridViewRow gvr in grleave.Rows)
                {
                    gvr.Cells[7].Visible = false;
                }
            }
        }

        if (Session["SA_Centrerole"] .ToString() == "CentreManager" || Session["SA_Centrerole"] .ToString() == "centremanager")
        {
            int leave = 0;
            _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where  centercode='" + Session["SA_centre_code"].ToString() + "' and (status='Pending' or status_cen='pending') ";
            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt1.Rows.Count > 0)
            {
                leave = Convert.ToInt32(dt1.Rows[0]["noofdays"]);
            }
            else
            {
                leave = 0;
            }

            if (leave < 4)
            {
                _Qry = " update erp_studentleave set status_cen='Approved' where  centercode='" + Session["SA_centre_code"].ToString() + "' and  status_cen='Pending'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where centercode='" + Session["SA_centre_code"].ToString() + "' and status_cen='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                //  lnkapprove1.Visible = false;
                //  lnkdecline1.Visible = false;
                grleave.DataSource = dt;
                grleave.DataBind();

                foreach (GridViewRow gr in grleave.Rows)
                {
                    Label lbl1 = new Label();
                    lbl1 = (Label)gr.FindControl("lblstatus1");
                    LinkButton lnkapprove1 = new LinkButton();
                    lnkapprove1 = (LinkButton)gr.FindControl("lnkapprove1");
                    LinkButton lnkdecline1 = new LinkButton();
                    lnkdecline1 = (LinkButton)gr.FindControl("lnkdecline1");
                    if (lbl1.Text == "Pending")
                    {
                        lnkapprove1.Visible = true;
                        lnkdecline1.Visible = true;
                        lbl1.Visible = false;
                    }
                    else
                    {
                        lnkapprove1.Visible = false;
                        lnkdecline1.Visible = false;
                        lbl1.Visible = true;
                    }
                }


            }
            else
            {
                _Qry = " select leave.id,enq_personal_name,studentid,centercode,DATEDIFF(day,fromdate,todate) + 1 as noofdays ,convert(varchar,fromdate,103) as fromdate,convert(varchar,todate,103) as todate,reason,convert(varchar,approvedate,103) as approvedate,status,status_cen from erp_studentleave leave inner join adm_personalparticulars p on p.student_id=leave.studentid where centercode='" + Session["SA_centre_code"].ToString() + "' and status_cen='Pending'";
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);
                grleave.DataSource = dt;
                grleave.DataBind();
                foreach (GridViewRow gr in grleave.Rows)
                {
                    Label lbl1 = new Label();
                    lbl1 = (Label)gr.FindControl("lblstatus1");
                    LinkButton lnkapprove1 = new LinkButton();
                    lnkapprove1 = (LinkButton)gr.FindControl("lnkapprove1");
                    LinkButton lnkdecline1 = new LinkButton();
                    lnkdecline1 = (LinkButton)gr.FindControl("lnkdecline1");
                    if (lbl1.Text == "Pending")
                    {
                        lnkapprove1.Visible = true;
                        lnkdecline1.Visible = true;
                        lbl1.Visible = false;
                    }
                    else
                    {
                        lnkapprove1.Visible = false;
                        lnkdecline1.Visible = false;
                        lbl1.Visible = true;
                    }
                }



            }


            if (grleave.Columns.Count > 0)
            {
                grleave.Columns[6].Visible = false;
            }
            else
            {
                grleave.HeaderRow.Cells[6].Visible = false;
                foreach (GridViewRow gvr in grleave.Rows)
                {
                    gvr.Cells[6].Visible = false;
                }
            }
        }


    }




    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            _Qry = "update erp_studentdrop set action='Deactive' where studentid='" + e.CommandArgument.ToString() + "' and centercode='" + Session["SA_centre_code"].ToString() + "'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
            //Label6.Text = "Removed";

            filldrop();
           Response.Redirect("notification.aspx#Drop");


        }

        if (e.CommandName == "drop1")
        {

            _Qry = "select * from erp_studentdrop where studentid='" + e.CommandArgument.ToString() + "'  and centercode='" + Session["SA_centre_code"] + "' and status ='Requested'";
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            if (dt.Rows.Count > 0)
            {
                //txt_reason.Text = dt.Rows[0]["reason"].ToString();

                _Qry = "update adm_personalparticulars set studentstatus='Dropped' where student_id='" + e.CommandArgument.ToString() + "' and centre_code='" + Session["SA_centre_code"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry = "update erp_batchschedule set batchstatus='Dropped' where studentid='" + e.CommandArgument.ToString() + "' and centrecode='" + Session["SA_centre_code"] + "' and  classdate > getdate()";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry = "update erp_studentdrop set droppeddate=getdate(),status='Dropped' where studentid='" + e.CommandArgument.ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                _Qry += "update erp_invoicedetails set status='deactive',studentstatus='deactive' where studentid='" + e.CommandArgument.ToString() + "' and centercode='" + Session["SA_centre_code"] + "'";
                MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
                if (dt.Rows[0]["status"].ToString() == "Dropped")
                {
                    showBox("student already dropped...!");

                }
                else if (dt.Rows[0]["status"].ToString() == "Declined")
                {
                    showBox("You already declined...!");

                }
                else
                {
                    showBox("Student Successfully Dropped From ERP System...!");
                    Response.Redirect("notification.aspx" + "#Drop");
                }


            }
            else
            {
                showBox("You can't drop student without getting request...!");

            }
        }



    }

    private void filltransfer()

    {
       
   
    
            _Qry = " select * from erp_studenttransfer where newstudentid is null and transferedfrom ='" + Session["SA_centre_code"].ToString() + "'";

            if (TextBox3.Text != "")
            {
                _Qry += " and studentid like '%" + TextBox3.Text.ToString() + "%'";
            }
            DataTable dtt = new DataTable();
            dtt = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView3.DataSource = dtt;
            GridView3.DataBind();
          
        
        
        

    }
    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }

    private void fillassesment()
    {
        if (Session["SA_Centrerole"] .ToString() == "Technical Head" )
        {
            _Qry = @"
SELECT  distinct   erp_studentprogress.centrecode,erp_studentprogress.projectid, projectdetails.projectname, adm_personalparticulars.enq_personal_name, erp_studentprogress.studentid, 
                      Submodule_details_new.Module, erp_studentprogress.moduleid
FROM         projectdetails INNER JOIN
                      erp_studentprogress ON projectdetails.projectid = erp_studentprogress.projectid INNER JOIN
                      adm_personalparticulars ON erp_studentprogress.studentid = adm_personalparticulars.student_id INNER JOIN
                      Submodule_details_new ON erp_studentprogress.moduleid = Submodule_details_new.ModuleId where erp_studentprogress.senddate is null and erp_studentprogress.centrecode='" + Session["SA_centre_code"].ToString() + "'";
            DataTable d1 = new DataTable();
            d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            gridassesment.DataSource = d1;
            gridassesment.DataBind();
        }


        if (Session["SA_Centrerole"] .ToString() == "R&D")
        {
            assesment_search.Visible = true;
            _Qry = @"
SELECT  distinct   erp_studentprogress.centrecode,erp_studentprogress.projectid, projectdetails.projectname, adm_personalparticulars.enq_personal_name, erp_studentprogress.studentid, 
                      Submodule_details_new.Module, erp_studentprogress.moduleid
FROM         projectdetails INNER JOIN
                      erp_studentprogress ON projectdetails.projectid = erp_studentprogress.projectid INNER JOIN
                      adm_personalparticulars ON erp_studentprogress.studentid = adm_personalparticulars.student_id INNER JOIN
                      Submodule_details_new ON erp_studentprogress.moduleid = Submodule_details_new.ModuleId where erp_studentprogress.mark is null and erp_studentprogress.senddate is not null";
            
            if(DropDownList1.SelectedValue!="")
            {
                _Qry+= " and centrecode='"+DropDownList1.SelectedValue+"'";
            }
            
            DataTable d1 = new DataTable();
            d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            gridassesment.DataSource = d1;
            gridassesment.DataBind();
        }

        if (Session["SA_Centrerole"] .ToString() == "Certificate")
        {
            assesment_search.Visible = true;
            _Qry = @"
SELECT  distinct   erp_studentprogress.centrecode,erp_studentprogress.projectid, projectdetails.projectname, adm_personalparticulars.enq_personal_name, erp_studentprogress.studentid, 
                      Submodule_details_new.Module, erp_studentprogress.moduleid
FROM         projectdetails INNER JOIN
                      erp_studentprogress ON projectdetails.projectid = erp_studentprogress.projectid INNER JOIN
                      adm_personalparticulars ON erp_studentprogress.studentid = adm_personalparticulars.student_id INNER JOIN
                      Submodule_details_new ON erp_studentprogress.moduleid = Submodule_details_new.ModuleId where erp_studentprogress.dispatchdate is null and erp_studentprogress.senddate is not null";

            if (DropDownList1.SelectedValue != "")
            {
                _Qry += " and centrecode='" + DropDownList1.SelectedValue + "'";
            }
            DataTable d1 = new DataTable();
            d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            gridassesment.DataSource = d1;
            gridassesment.DataBind();
        }


    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridView1.PageIndex = e.NewPageIndex;
        expressupdate();
      //  Response.Redirect("notification.aspx#Recommened");
     
       
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        filltransfer();
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void grdcentre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "approve1")
        {
            _Qry = " update erp_studentleave set status_cen='Approved',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status_cen='Pending'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);

        }
        else if (e.CommandName == "decline1")
        {
            _Qry = " update erp_studentleave set status_cen='Rejected',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status_cen='Pending'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        if (e.CommandName == "approve")
        {
            _Qry = " update erp_studentleave set status='Approved',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status='Pending'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        else if (e.CommandName == "decline")
        {
            _Qry = " update erp_studentleave set status='Rejected',approvedate=getdate() where id='" + e.CommandArgument.ToString() + "' and status='Pending'";
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, _Qry);
        }
        fillgrid1();
        Response.Redirect("notification.aspx"+"#Leave");
    }
    public void fillbook()
    {
        if (Session["SA_Centrerole"] .ToString() == "CentreManager")
        {
            _Qry = @"select distinct br.studentid,br.courseid,convert(varchar,br.requested_date,103)as requested_date ,br.status,adm.enq_personal_name from book_request br inner join
adm_personalparticulars adm on adm.student_id=br.studentid where br.status='Pending' and br.centrecode='" + Session["SA_centre_code"].ToString() + "'";
            DataTable d1 = new DataTable();
            d1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            GridView4.DataSource = d1;
            GridView4.DataBind();
        }
    }

    public void fillbook1()
    {

        if (Session["SA_Centrerole"] .ToString() == "Printing Department")
        {


            _Qry = @"select distinct br.studentid,br.courseid,convert(varchar,br.requested_date,103)as requested_date ,convert(varchar,br.approved_date,103)as approved_date,br.status,b.centre_location,adm.enq_personal_name from book_request br inner join img_centredetails b on br.centrecode=b.centre_code inner join
adm_personalparticulars adm on adm.student_id=br.studentid where status='Approved' and br.bookstatus='Pending' ";
            DataTable dtab = new DataTable();
            dtab = MVC.DataAccess.ExecuteDataTable(_Qry);  
                GridView5.DataSource = dtab;
                GridView5.DataBind();
            

        }
       

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        fillassesment();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        filltransfer();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
