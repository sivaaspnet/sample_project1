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

public partial class superadmin_modulewise : System.Web.UI.Page

{
    string _Qry;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if(!IsPostBack)
        {
            displaycourseonload();
        }

    }
    private void displaycourseonload()
    {
        _Qry = "SELECT Module_Id,Replace(Module_Content,'~','''') as Module_Content from Module_Details ORDER by Module_Id";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_module.DataSource = dt;
        ddl_module.DataValueField = "Module_Id";
        ddl_module.DataTextField = "Module_Content";
        ddl_module.DataBind();
       //ddl_module.Items.Insert(0, new ListItem("Select", ""));
    }

    private void displaysoftwareonload()
    {
        _Qry = "select * from Onlinestudent_Software ORDER by Software_Id";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_module.DataSource = dt;
        ddl_module.DataValueField = "Software_Id";
        ddl_module.DataTextField = "Software_Name";
        ddl_module.DataBind();
       //ddl_module.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
        count.Visible = true;
        

    }
    private void fillgrid()
    {
        
        if (RadioButtonList1.SelectedValue == "Module")
        {
             fillsoft();
             GridView1.Visible = true;
             _Qry = @"select  distinct inv.studentid,enq_personal_name,program,moduleid from erp_batchschedule bat 
inner join adm_personalparticulars on 
student_id=studentid   inner join erp_invoicedetails as inv on student_id=inv.studentid
inner join img_coursedetails on course_id=courseid   where 1=1 and moduleid='" +ddl_module.SelectedValue+"' and centrecode='" + Session["SA_centre_code"] + "'";
          
            
            if (ddl_status.SelectedValue == "pending")
            {
                _Qry += " and 0!=(select count(status) from erp_batchschedule a where (a.status ='pending' or a.status ='repending') and studentid=bat.studentid   and moduleid=bat.moduleid )";
            }
            if (ddl_status.SelectedValue == "completed")
            {
                _Qry += " and 0=(select count(status) from erp_batchschedule a where (a.status ='pending' or a.status ='repending') and  studentid=bat.studentid  and moduleid=bat.moduleid )";
            }
            
            DataTable dt = new DataTable();
 
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            _Qry = "select studentid,status,moduleid from erp_batchschedule bat where centrecode='" + Session["SA_centre_code"] + "' and moduleid='" + ddl_module.SelectedValue + "'";
            if (ddl_status.SelectedValue == "pending")
            {
                _Qry += " and 0!=(select count(status) from erp_batchschedule a where (a.status ='pending' or a.status ='repending') and  studentid=bat.studentid  and moduleid=bat.moduleid )";
            }
            if (ddl_status.SelectedValue == "completed")
            {
                _Qry += " and 0=(select count(status) from erp_batchschedule a where (a.status ='pending' or a.status ='repending') and  studentid=bat.studentid  and moduleid=bat.moduleid )";
            }

            DataTable dt1 = new DataTable();
            dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
            DataTable sta =new DataTable();
                sta.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
                sta.Columns.Add(new DataColumn("enq_personal_name", System.Type.GetType("System.String")));
                sta.Columns.Add(new DataColumn("program", System.Type.GetType("System.String")));
                sta.Columns.Add(new DataColumn("status1", System.Type.GetType("System.String")));
                sta.Columns.Add(new DataColumn("moduleid", System.Type.GetType("System.String")));
                DataRow dr = sta.NewRow();


                string[] args = new string[3];

                args[0] = "studentid";
                args[1] = "enq_personal_name";
                args[2] = "moduleid";

                DataTable dt2 = new DataTable();
                dt2 = dt.DefaultView.ToTable(true, args);

                foreach (DataRow drs in dt2.Rows)
                {
                    dr = sta.NewRow();
                    dr["studentid"] = drs["studentid"];
                    dr["enq_personal_name"] = drs["enq_personal_name"];
                    dr["program"] = getcourse(dt, "studentid='" + drs["studentid"] + "' and moduleid='" + drs["moduleid"] + "'");
                    dr["moduleid"] = drs["moduleid"];
                    dr["status1"] = getstatus(dt1, "studentid='" + drs["studentid"] + "' and moduleid='" + drs["moduleid"] + "'");
                    sta.Rows.Add(dr);
                }
            lbl_count.Text = dt2.Rows.Count.ToString();
            GridView1.DataSource = sta;
            GridView1.DataBind();
            GridView2.Visible = true;

        }

        else
        {
            GridView1.Visible = true;
            GridView2.Visible =false;
            _Qry = @"select  distinct inv.studentid,b.enq_personal_name,program,d.software_name,a.moduleid,a.software_id from erp_batchschedule a
inner join adm_personalparticulars b on 
b.student_id=a.studentid   inner join erp_invoicedetails as inv on b.student_id=inv.studentid
inner join img_coursedetails c  on c.course_id= inv.courseid inner join Onlinestudent_Software d on d.software_id=a.software_id  where 1=1 and centrecode='" + Session["SA_centre_code"] + "' and a.software_id='"+ddl_module.SelectedValue+"'";
            if (ddl_status.SelectedValue == "pending")
            {
                _Qry += " and 0!=(select count(status) from erp_batchschedule b where (b.status ='pending' or b.status ='repending') and b.studentid=a.studentid and  b.software_id=a.software_id )";
            }
            if (ddl_status.SelectedValue == "completed")
            {
                _Qry += " and 0=(select count(status) from erp_batchschedule b where (b.status ='pending' or b.status ='repending') and b.studentid=a.studentid and  b.software_id=a.software_id )";
            }
            
              
                DataTable dt = new DataTable();
                dt = MVC.DataAccess.ExecuteDataTable(_Qry);

                DataTable status = new DataTable();

                _Qry = "select studentid,status,moduleid,software_id from erp_batchschedule a where centrecode='" + Session["SA_centre_code"] + "' and software_id='"+ddl_module.SelectedValue+"'";

                if (ddl_status.SelectedValue == "pending")
                {
                    _Qry += " and 0!=(select count(status) from erp_batchschedule b where (b.status ='pending' or b.status ='repending') and b.studentid=a.studentid and  b.software_id=a.software_id )";
                }
                if (ddl_status.SelectedValue == "completed")
                {
                    _Qry += " and 0=(select count(status) from erp_batchschedule b where (b.status ='pending' or b.status ='repending') and b.studentid=a.studentid and  b.software_id=a.software_id )";
                }
            

                DataTable dttts = new DataTable();
                dttts = MVC.DataAccess.ExecuteDataTable(_Qry);




                status.Columns.Add(new DataColumn("studentid", System.Type.GetType("System.String")));
                status.Columns.Add(new DataColumn("enq_personal_name", System.Type.GetType("System.String")));
                status.Columns.Add(new DataColumn("program", System.Type.GetType("System.String")));
                status.Columns.Add(new DataColumn("status1", System.Type.GetType("System.String")));
                status.Columns.Add(new DataColumn("moduleid", System.Type.GetType("System.String")));
                status.Columns.Add(new DataColumn("software_id", System.Type.GetType("System.String")));
                DataRow dr = status.NewRow();


                string[] args = new string[4];

                args[0] = "studentid";
                args[1] = "enq_personal_name";
                args[2] = "moduleid";
                args[3] = "software_id";

                DataTable dt2 = new DataTable();
                dt2 = dt.DefaultView.ToTable(true, args);


                foreach (DataRow drs in dt2.Rows)
                {
                   

                        dr = status.NewRow();
                        dr["studentid"] = drs["studentid"];
                        dr["enq_personal_name"] = drs["enq_personal_name"];
                        dr["program"] = getcourse(dt, "studentid='" + drs["studentid"] + "' and software_id='" + drs["software_id"] + "'  ");
                        dr["moduleid"] = drs["moduleid"];
                        dr["software_id"] = drs["software_id"];
                        dr["status1"] = getstatus(dttts, "studentid='" + drs["studentid"] + "' and software_id='" + drs["software_id"] + "' ");
                        status.Rows.Add(dr);
                 
                    

                }

                lbl_count.Text = dt2.Rows.Count.ToString();
            GridView1.DataSource = status;
            GridView1.DataBind();


        }
    }



    string getstatus(DataTable dtexp, string expression)
    {
        string res1 = "";
        // string res1 = "";
        string res = "<span style='color:green; font-weight:bold;'>Completed</span>";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach (DataRow val in dr)
            {
                if(res1=="")
                {
                     res1 =  val["status"].ToString();
                }
                else
                {

                res1 = res1 + "," + val["status"].ToString();
                }
               
            }
            //Response.Write(res.ToString());

            string value = res1;
            
            string[] split = value.Split(',');
            for (int i = 0; i < split.Length; i++)
            {

                if (split[i].ToString() == "pending" || split[i].ToString() == "Pending" || split[i].ToString() == "Repending" || split[i].ToString() == "repending")
                {
                    res = "<span style='color:blue; font-weight:bold;'>Inprogress</span>";
                }
                
          
            }

           


        }

        return res.ToString();
    }




    string getcourse(DataTable dtexp, string expression)
    {
        string res = "";
        // string res1 = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach (DataRow val in dr)
            {
                if (res == "")
                {
                    res = val["program"].ToString();
                }
                else
                {

                    res = res + "," + val["program"].ToString();
                }

            }



        }

        return res.ToString();
    }




    private void fillsoft()
    {
        
        _Qry = @"select sub.software,count(distinct studentid) as Totstudent from erp_batchschedule bat  inner join 
Submodule_details_new as sub on 
sub.software_id=bat.software_id
where  bat.moduleid='" + ddl_module.SelectedValue + "' and centrecode='" + Session["SA_centre_code"] + "' ";

        if (ddl_status.SelectedValue == "pending")
        {
            _Qry += " and 0!=(select count(status) from erp_batchschedule a where (a.status ='pending' or a.status ='repending') and studentid=bat.studentid and  moduleid=bat.moduleid )";
        }
        if (ddl_status.SelectedValue == "completed")
        {
            _Qry += " and 0=(select count(status) from erp_batchschedule a where (a.status ='pending' or a.status ='repending') and studentid=bat.studentid and  moduleid=bat.moduleid )";
        }
        
        _Qry+="group by sub.software";
        DataTable dt1 = new DataTable();
        dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        GridView2.DataSource = dt1;
        GridView2.DataBind();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Module")
        {
            lbl_module.Text = "Module Name";
            displaycourseonload();
            count.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = false;
        }
        else
        {
            lbl_module.Text = "Software Name";
            ddl_module.Items.Clear();
            displaysoftwareonload();
            count.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrid();

    }
}
