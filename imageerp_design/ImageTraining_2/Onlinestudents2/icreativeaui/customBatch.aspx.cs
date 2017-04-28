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
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

public partial class superadmin_createnewBatch : System.Web.UI.Page
{
    string _Qry, _Qry1, BatchCount, batch_code, centrcode, couname, couid, todate, holdate, qry111,os="";
    public string chk1 = "";
    string batchqry = "";
    string soft="";
    string module = "";
    string mainqry = "";
    int noofcls, weekday,endate;
    int yy = 0;
    string classdate = "";
    string classdatemwf = "";
    string classdatetts = "";
    DateTime stdate, lastday;
    string rr = "";
    string facid = "";
    string labtime = "";
    string labcode = "";
    string value = "";
    string confirmation = "<table class='common' border='1px' width=350><tr><th>Class date</th><th>Content</th></tr> ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SA_Centrerole"] == null || Session["SA_Centrerole"] == "")
        {
            Response.Redirect("Login.aspx");
        }
    
        if (!IsPostBack)
        {
            displaycourseonload();
            display_facultyddl();
            display_labddl();
            Button1.Visible = false;
            fillcoursedropdown();
            lblmsg1.Text = "";
            
            
        }
       
    }

    public static void showBox(string msg)
    {
        Page page = (Page)HttpContext.Current.Handler;
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "');</script>";
        page.Controls.Add(lbl);
    }
    private void display_facultyddl()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where Status='Enable' and centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddlfac.DataSource = dt;
        ddlfac.DataValueField = "faculty_id";
        ddlfac.DataTextField = "facultyname";
        ddlfac.DataBind();
        ddlfac.Items.Insert(0, new ListItem("Select", ""));
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    private void display_labddl()
    {
        _Qry = "select LabId,LabName  from online_students_labavail where centre_Code='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);       
        ddllab.DataSource = dt;
        ddllab.DataTextField = "LabName";
        ddllab.DataValueField = "LabId";
        ddllab.DataBind();
        ddllab.Items.Insert(0, new ListItem("Select", ""));
    }
    
    private void display_facultygrid()
    {
        _Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_Code='" + Session["SA_centre_code"] + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvfaculty.DataSource = dt;
        gvfaculty.DataBind();
        ddlfac.DataSource = dt;      
        //Repeater1.DataSource = dt;
        //Repeater1.DataBind();
    }
    private void display_labgrid()
    {
        _Qry = "select LabId,LabName,LabName+' ('+ systemcount+')' as labwithsys from erp_labdetails where centreCode='" + Session["SA_centre_code"] + "'";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        gvlab.DataSource = dt;
        gvlab.DataBind();       
    }
    private void display_faculty()
    {
        //_Qry = "select facultyname,faculty_id from onlinestudentsfacultydetails where centre_code='" + Session["SA_centre_code"] + "'";
       
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //ddl_facultyname.DataSource = dt;
        //ddl_facultyname.DataValueField = "faculty_id";
        //ddl_facultyname.DataTextField = "facultyname";
        //ddl_facultyname.DataBind();
        //ddl_facultyname.Items.Insert(0, new ListItem("Select", ""));
    }
    private void display_lab()
    {
        //_Qry = "select LabId,LabName from online_students_labavail where centre_code='" + Session["SA_centre_code"] + "'";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //ddl_labname.DataSource = dt;
        //ddl_labname.DataValueField = "LabId";
        //ddl_labname.DataTextField = "LabName";
        //ddl_labname.DataBind();
        //ddl_labname.Items.Insert(0, new ListItem("Select", ""));
    }

    private void fillgrid()
    {
        // _Qry = "select gen.student_id,per.enq_personal_name,gen.Track,cou.coursename,cou.program,enq.enq_personal_mobile from (adm_generalinfo gen inner join adm_personalparticulars per on per.student_id=gen.student_id) inner join img_enquiryform enq on gen.enq_number=enq.enq_number inner join img_coursedetails cou on gen.coursename=cou.course_id  where gen.coursename='"+ddl_coursename.SelectedValue+"' and gen.track='" + ddl_Track.SelectedValue + "' and gen.centre_code='" + Session["SA_centre_code"] + "'";
        //_Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=enq.enq_number where G.centre_code='" + Session["SA_centre_code"] + "'and SUB.software_id='" + ddl_coursename.SelectedValue + "' and G.track='" + ddl_Track.SelectedValue + "' GROUP by G.student_id";

        //_Qry = "Select Course_Code,C.Course_Id From OnlineStudent_Course c inner join module_details cs on ";
        //_Qry += " c.course_id=cs.course_id where Module_Id="+ddl_coursename.SelectedValue+"";

         
        _Qry = "Select module_id from module_details where Module_Id=" + ddl_coursename.SelectedValue + " ";

        //Response.Write(_Qry);
        //Response.End();

        SqlDataReader dr;
        dr = MVC.DataAccess.ExecuteReader(MVC.DataAccess.ConnectionString, _Qry);
        string Software_ID = "";
        if (dr.HasRows)
        {
            dr.Read();

            //_Qry = " select cs.Course_ID,c.course_Code from Onlinestudent_Coursesoftware as cs inner join OnlineStudent_Course as c on ";
            //_Qry += " cs.course_Id=c.Course_ID";
            //_Qry += " where module_id in(" + dr["module_id"] + ") group ";
            //_Qry += " by cs.course_ID,c.course_Code";


            _Qry = @"select cs.Course_id,img.program  as course_Code from Onlinestudent_Coursesoftware as cs inner join img_coursedetails as 
img on  cs.course_Id=img.Course_id where module_id in(" + dr["module_id"] + ")  group by cs.course_ID,img.program ";

            //Response.Write(_Qry);
            //Response.End();


            dr.Close();
        }

        //Response.Write(_Qry);
        //Response.End();
        //Response.Write("Test:"+_Qry);
        //Response.End();

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);

        string Course_Code = "";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Course_Code == "")
            {
                Course_Code = "'" + dt.Rows[i]["Course_Code"].ToString() + "'";
            }
            else
            {
                Course_Code += "," + "'" + dt.Rows[i]["Course_Code"].ToString() + "'";
            }
        }

        //Response.Write(Course_Code);
        //Response.End();

        if (Course_Code == "")
        {
            _Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB";
            _Qry += " inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id";
            _Qry += " =c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=";
            _Qry += " cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=";
            _Qry += " enq.enq_number where cou.Program='' And G.centre_code='" + Session["SA_centre_code"] + "' And G.track<>'Batched' ";
            if (txt_search.Text == "" || txt_search.Text == null)
            {

            }
            else
            {
                _Qry += " And (G.student_id like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txt_search.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%' or P.enq_personal_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(Regex.Replace(txt_search.Text, "^[ \t\r\n]+|[ \t\r\n]+$", "")) + "%') ";
            }
            _Qry = _Qry + " And (Select enq_enqstatus from img_enquiryform1 Where img_enquiryform1.enq_number=P.enq_number)<>'Dropped'";
            _Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";
        }
        else
        {
            _Qry = "select G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile from submodule_details SUB";
            _Qry += " inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id";
            _Qry += " =c.program  inner join img_coursedetails cou  on cou.course_id=c.program inner join adm_generalinfo G on G.coursename=";
            _Qry += " cou.course_id inner join adm_personalparticulars P on G.student_id=P.student_id inner join img_enquiryform enq on G.enq_number=";
            _Qry += " enq.enq_number where cou.Program in (" + Course_Code + ") And G.centre_code='" + Session["SA_centre_code"] + "' And G.track<>'Batched' ";
            if (txt_search.Text == "" || txt_search.Text == null)
            {

            }
            else
            {
                _Qry += " And (G.student_id like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%' or P.enq_personal_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%') ";
            }
            _Qry = _Qry + " And (Select enq_enqstatus from img_enquiryform1 Where img_enquiryform1.enq_number=P.enq_number)<>'Dropped'";
            _Qry += " GROUP by G.student_id,P.enq_personal_name,G.Track,cou.program,cou.course_id,enq.enq_personal_mobile order by Cou.Course_id";


            string qryCondition = "";
            if (txt_search.Text != "")
            {
                qryCondition = " And (G.student_id like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%'  or P.enq_personal_name like '%" + MVC.CommonFunction.ReplaceQuoteWithTild(txt_search.Text) + "%')";
            }

            //by siva
            _Qry = @"select distinct p.enq_personal_name,p.student_id,Enqf.enq_personal_mobile,
G.Track,cou.program,cou.course_id,mod.module_content from 
adm_personalparticulars as p inner join adm_generalinfo G on 
p.student_id=G.student_id and p.studentstatus='active'  INNER JOIN  
img_enquiryform1 Enq on enq.enq_number=g.enq_number  and 
enq.centre_code=g.centre_code INNER JOIN img_enquiryform enqf on 
enqf.enq_number=enq.enq_number  and enqf.centre_code=g.centre_code
inner join img_coursedetails cou on cou.course_id=g.coursename 
inner join Onlinestudent_Coursesoftware mod  on cou.course_id=mod.course_id  
inner join submodule_details_new sub on sub.moduleid=mod.module_id and sub.status='Active'
 and sub.software_id not in (select old.software_id from erp_oldbatchdetails old 
where  old.studentid=p.student_id and old.status='active')  and 
g.student_id not in  (select bs.studentid from erp_batchdetails bd inner join 
erp_batchschedule bs on bs.batchcode=bd.batchcode and bd.centrecode=bs.centrecode  and bd.status='Pending' and bs.batchstatus='active'  and bs.batchtiming='" + ddlbatch.SelectedValue + "' and bs.studentid=p.student_id and bs.centrecode='" + Session["SA_centre_code"] + "' and bs.classdate >=getdate())    and mod.module_id='" + ddl_coursename.SelectedValue + "' and p.centre_code='" + Session["SA_centre_code"] + "' and software_id in(" + os + ")";

           // Response.Write(_Qry);
            
             string id = txt_studentid.Text;
             string[] split = id.Split(',');

             for (int i = 0; i < split.Length; i++)
             {
                 if (value == "")
                 {
                     value = "'" + split[i].ToString().Trim() + "'";
                 }
                 else
                 {
                     value = value + "," + "'" + split[i].ToString().Trim() + "'";
                 }
             }


             if (txt_studentid.Text != "")
             {
                 _Qry += " and p.student_id in ("+value+")";
             }
             if (coursename_ddl.SelectedValue != "")
             {
                 _Qry += " and cou.course_id ='" + coursename_ddl.SelectedValue + "'";
             }


//            _Qry = @"select distinct p.enq_personal_name,p.student_id,Enqf.enq_personal_mobile,G.Track,cou.program,cou.course_id from adm_personalparticulars as p inner join adm_generalinfo G on p.student_id=G.student_id  INNER JOIN  img_enquiryform1 Enq on enq.enq_number=g.enq_number INNER JOIN img_enquiryform enqf on enqf.enq_number=enq.enq_number 
//inner join img_coursedetails cou on cou.course_id=g.coursename where  G.track<>'Batched' and G.centre_code='" + Session["SA_centre_code"] + "' and Enq.enq_enqstatus<>'Dropped' and G.coursename in (select course_id from img_coursedetails where program in (" + Course_Code + "))" + qryCondition + " order by Cou.Course_id";

        }

   // Response.Write(_Qry);
       // Response.End();
        DataTable dt12 = new DataTable();
        dt12 = MVC.DataAccess.ExecuteDataTable(_Qry);
        Gridvw.DataSource = dt12;
        Gridvw.DataBind();

        if (dt12.Rows.Count > 0)
        {
            tblBatch.Visible = true;
            tblstudent.Visible = true;
        }
        else
        {
            tblBatch.Visible = false;
            tblstudent.Visible = true;
            lblmsg1.Text = "No Students available";
            
        }

        
        tblfree.Visible = false;
        txt_studentid.Text = Session["SA_centre_code"].ToString();
    }

    private void fillcoursedropdown()
    {
        _Qry = "select a.Program,a.course_id from img_centre_coursefee_details b inner join img_coursedetails a on a.course_id=b.program where a.status='Active' and centre_code='" + Session["SA_centre_code"].ToString() + "' Group By a.coursename,a.course_id,b.Program,a.Program";

            //Response.Write(_Qry);
            //Response.End();
            DataTable dt = new DataTable();
            dt = MVC.DataAccess.ExecuteDataTable(_Qry);
            coursename_ddl.DataSource = dt;
            coursename_ddl.DataValueField = "course_id";
            coursename_ddl.DataTextField = "Program";
            coursename_ddl.DataBind();
            coursename_ddl.Items.Insert(0, new ListItem("Select", ""));
    

       
    }


    private void displaycourseonload()
    {
        //_Qry = "SELECT s.software_Id,s.software_name from submodule_details SUB inner join software_details s on SUB.software_id=s.software_Id inner join img_centre_coursefee_details c on SUB.course_id=c.program where c.centre_code='" + Session["SA_centre_code"] + "' and track='" + ddl_Track.SelectedValue + "' GROUP by SUB.software_Id ORDER by SUB.submodule_Id";
        _Qry = "SELECT a.Module_Id,Replace(a.Module_Content,'~','''') as Module_Content from Module_Details a inner join add_moduledetails b on a.module_id=b.module_id where b.mod_status='Active' ORDER by Module_Id";

        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        ddl_coursename.DataSource = dt;
        ddl_coursename.DataValueField = "Module_Id";
        ddl_coursename.DataTextField = "Module_Content";
        ddl_coursename.DataBind();
        ddl_coursename.Items.Insert(0, new ListItem("Select", ""));
    }
    
    protected void btn_submit_Click(object sender, EventArgs e)
     {        
         int count = 0;
         string studentid = "";
         string sdate;
         string submoduleid = "";
         string content = "";
         string softid = "";
         string values = "", slotdate="";
         string str = txt_stratdate.Text;
         string[] split = str.Split('-');

         sdate = split[2] + "-" + split[1] + "-" + split[0];          
         int yearr = System.DateTime.Now.Year;
         int Mmonth = System.DateTime.Now.Month;
         centrcode = Session["SA_centre_code"].ToString();
         string mon = "";
         if (Mmonth < 10)
         {
             mon = "0" + Mmonth.ToString();
         }
         else
         {
             mon = Mmonth.ToString();
         }

         int n;
         for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
         {
             if (CheckBoxList1.Items[n].Selected)
             {
                 if (os == "")
                 {
                     os = CheckBoxList1.Items[n].Value;
                 }
                 else
                 {
                     os = os + "," + CheckBoxList1.Items[n].Value;
                 }

             }
             //}
         }


        
         for (int i = 0; i < CheckBoxList2.Items.Count; i++)
         {
             if (CheckBoxList2.Items[i].Selected)
             {
                 values += CheckBoxList2.Items[i].Value + ",";
                 
             }
         }

         // Response.Write(chkcount);
         values = values.TrimEnd(',');
      
         slotdate = values.ToString();


         _Qry1 = "select convert(varchar,classdate,101) as classdate from [spcustomclassdate] ('" + sdate + "','" + slotdate + "','" + os + "','" + ddl_coursename.SelectedValue + "')";
        // Response.Write(_Qry1);
        
         DataTable dtclass = new DataTable();
         dtclass = MVC.DataAccess.ExecuteDataTable(_Qry1);
         for (int i = 0; i < dtclass.Rows.Count; i++)
         {
             if (classdate == "")
             {
                 classdate = "'" + dtclass.Rows[i]["classdate"].ToString() + "'";
             }
             else
             {
                 classdate = classdate + ",'" + dtclass.Rows[i]["classdate"].ToString() + "'";
             }
         }
         _Qry = @"select count(facultyid) from erp_batchschedule sce inner join 
        erp_batchcontentstatus sts on sts.batchcode=sce.batchcode where 
sce.batchtiming='" + ddlbatch.SelectedValue.ToString() + "'  and   facultyid='" + ddlfac.SelectedValue + "' and   sce.centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,sce.classdate),101)  in (" + classdate + ") and sts.status='Pending' and sce.batchstatus='active'";
       //Response.Write(_Qry+"<br>");
         count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
         if (count > 0)
         {
             fillfree();
           
             /// faculty does not exist
         }
         else
         {
            
             //_Qry = "select count(labid) from erp_batchschedule where batchtiming='" + ddlbatch.SelectedValue.ToString() + "' and labid='" + ddllab.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,classdate),101)  in (" + classdate + ")";
             ////Response.Write(_Qry + "<br>");
             //count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
             if(Convert.ToInt32(hdnfreesystem.Value)>0)
             {
                 _Qry = "select batchcode from erp_batchdetails where centrecode='" + Session["SA_centre_code"] + "' And (SELECT MONTH(Dateins))='" + System.DateTime.Now.Month + "' And (SELECT YEAR(Dateins))='" + System.DateTime.Now.Year + "' group by batchcode";
                 DataTable dtc = new DataTable();
                 dtc = MVC.DataAccess.ExecuteDataTable(_Qry);
                 int ccount = 0;
                 ccount = dtc.Rows.Count;
                 if (ccount > 0)
                 {
                     BatchCount = Convert.ToString(Convert.ToInt32(ccount) + 1);
                 }
                 else
                 {
                     BatchCount = "1";
                 }
                 batch_code = centrcode + " | " + mon + "/" + yearr + " | " + ddlbatch.SelectedValue + " | " + ddllab.SelectedItem.ToString().Trim() + " | " + BatchCount;
                 lblbatchcode.Text = batch_code.ToString();
                 string countval = " Select count(*) as noofclass from submodule_details_new where status='Active' and moduleid='"+ddl_coursename.SelectedValue+"' and  software_id in (" + os + ") ";
                 DataTable dtcountval = new DataTable();
                 dtcountval = MVC.DataAccess.ExecuteDataTable(countval);
                 string noofclass = dtcountval.Rows[0]["noofclass"].ToString();
                 batchqry += " INSERT INTO [erp_batchdetails] ([software_id],[batchCode],[moduleId],[NoOfClass],[centreCode],[slot],[batchTiming],[status],[dateins],[slotday]) VALUES ('" + os + "','" + batch_code + "','" + ddl_coursename.SelectedValue + "','" + noofclass + "','" + Session["SA_centre_code"].ToString() + "','custom','" + ddlbatch.SelectedValue + "','pending',getdate(),'" + slotdate + "') ";
                 //Response.Write(batchqry);
                 
                 string qry = " select Submodule_id,ModuleId,software_id,Module,Software,Content from submodule_details_new where status ='Active' and moduleid='"+ddl_coursename.SelectedValue+"' and software_id in (" + os + ") order by classOrder,submodule_id";
                 DataTable dtmodule = new DataTable();
                 dtmodule = MVC.DataAccess.ExecuteDataTable(qry);
                  
                 string dateofclss = classdate.Replace("'", "");
                 string[] splitdate = dateofclss.Split(','); 
                 
                 for (int j = 0; j < dtmodule.Rows.Count; j++)
                 {
                     DateTime moduledate = Convert.ToDateTime(splitdate[j].ToString());
                     submoduleid = dtmodule.Rows[j]["Submodule_id"].ToString();
                     content = dtmodule.Rows[j]["Content"].ToString();
                     softid = dtmodule.Rows[j]["software_id"].ToString();
                     batchqry += " INSERT INTO [erp_batchcontentstatus]([Batchcode],[software_id],[module_id],[subcontent_id],[scheduleDate],[classDate],[status],[dateins]) VALUES ('" + batch_code + "','" + softid + "','" + ddl_coursename.SelectedValue + "','" + submoduleid + "','" + moduledate + "','" + moduledate + "','pending',getdate() )";
                 }
                 //Response.Write(batchqry + "<br>"); 
                 // MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, batchqry);
                 int x = 0;
                 foreach (GridViewRow gvrow in Gridvw.Rows)
                 {
                     Label lblstudid = (Label)gvrow.Cells[0].FindControl("lbl_stdid");
                     CheckBox chkbox = (CheckBox)gvrow.Cells[0].FindControl("CheckBox1");
                     if (chkbox.Checked == true)
                     {
                         
                         studentid = lblstudid.Text;
                         string qry1 = " select distinct ModuleId,software_id from submodule_details_new  where status ='Active' and moduleid='" + ddl_coursename.SelectedValue + "' and software_id in (" + os + ") order by software_id";
                         DataTable dtmodule1 = new DataTable();
                         dtmodule1 = MVC.DataAccess.ExecuteDataTable(qry1);
                         for (int j = 0; j < dtmodule1.Rows.Count; j++)
                         {
                             softid = dtmodule1.Rows[j]["software_id"].ToString();
                             qry111 += " insert into erp_oldbatchdetails ([software_id],[studentid],[moduleid],[centre_code],[status],[softwarestatus])values('"+softid+"','" + studentid + "','" + ddl_coursename.SelectedValue + "','" + Session["SA_centre_code"].ToString() + "','active','pending')";
                         }
                         _Qry1 = " select convert(varchar,classdate,101) as classdate from [spcustomclassdate]('" + sdate + "','" + values + "','" + os + "','" + ddl_coursename.SelectedValue + "')";
                         DataTable dt = new DataTable();
                         dt = MVC.DataAccess.ExecuteDataTable(_Qry1);
                         //Response.Write(dt.Rows.Count);
                         //Response.End();
                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                             //string qry = "select Submodule_id,ModuleId,Module,Software,Content from submodule_details_new where moduleid='" + ddl_coursename.SelectedValue + "'";
                             //DataTable dtmodule = new DataTable();
                             //dtmodule1 = MVC.DataAccess.ExecuteDataTable(qry);
                             submoduleid = dtmodule.Rows[i]["Submodule_id"].ToString();
                             content =dtmodule.Rows[i]["Content"].ToString();
                             softid = dtmodule.Rows[i]["software_id"].ToString();
                             module = dtmodule.Rows[i]["moduleid"].ToString();
                             DateTime clsdate = Convert.ToDateTime(dt.Rows[i]["classdate"]);
                             mainqry += " INSERT INTO [erp_batchschedule] ([moduleid],[software_id],[studentId],[facultyId],[labId],[classDate],[batchCode],[batchTiming] ,[subContentId],[centrecode],[status],[dateins]) VALUES ('"+module+"','"+softid+"','" + studentid + "','" + ddlfac.SelectedValue + "','" + ddllab.SelectedValue + "',convert(varchar,'" + clsdate + "',101),'" + batch_code + "','" + ddlbatch.SelectedValue + "' ," + submoduleid + ",'" + Session["SA_centre_code"].ToString() + "','Pending',getdate())";
                             mainqry += " update adm_generalinfo set Track='Batched' where student_id='" + studentid + "' and centre_code='" + Session["SA_centre_code"] + "'";
                           //  mainqry += " Update onlinestudentsfacultydetails set [" + ddlbatch.SelectedValue + "]='" + ddlslot.SelectedValue.ToString() + "'," + ddlslot.SelectedValue + "='" + ddlbatch.SelectedValue + "' where Faculty_Id=" + ddlfac.SelectedValue + "  and centre_code='" + Session["SA_centre_code"] + "' ";
                            // mainqry += " Update online_students_labavail set [" + ddlbatch.SelectedValue + "]='" + ddlslot.SelectedValue.ToString() + "' where labid=" + ddllab.SelectedValue + " and centre_code='" + Session["SA_centre_code"] + "' ";
                           
                             if (x == 0)
                                 confirmation += "<tr><td> " + clsdate.ToString("dd/MM/yyyy") + "</td><td>" + content + "</td></tr>";

                         }
                         x += 1;
                     }

                 }
                 soft1();

                 string slotdatename = slotdate;
                 slotdatename = slotdatename.Replace("2", "M");
                 slotdatename = slotdatename.Replace("3", "T");
                 slotdatename = slotdatename.Replace("4", "W");
                 slotdatename = slotdatename.Replace("5", "TH");
                 slotdatename = slotdatename.Replace("6", "F");
                 slotdatename = slotdatename.Replace("7", "S");

                 lblsoftware.Text = chk1;
                 lblfac.Text = ddlfac.SelectedItem.Text;
                 lbllab.Text = ddllab.SelectedItem.Text;
                 lblslot.Text = slotdatename.ToString();
                 lblbatch.Text = ddlbatch.SelectedItem.Text;
                 lblstartdate.Text = txt_stratdate.Text;
                 lblenddate.Text = txt_enddate.Text;
                 lblmodule_name.Text = ddl_coursename.SelectedItem.Text;
                 confirmation += "</table>";
                 //Response.Write(confirmation.ToString());

                 //Response.Write(_Qry + "<br>");
                 //Response.End();
                 // MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, mainqry);
                 // Label1.Text = "Batch created successfully";
                 //  fillgrid();
                 getdetails.Visible = false;
                 tblstudent.Visible = false;
                 tblBatch.Visible = false;
                 tblconform.Visible = true;
                // literalconform.Text = confirmation.ToString();
                 lblbatchqry.Text = batchqry.ToString();
                 lblmainqry.Text = mainqry.ToString();
                 lbldeactive.Text = qry111.ToString();
             }
             else
             {
                 fillfree();
                 //Response.Write("sesesesese");
                 /// lab does not exists
             }
      }
 
}   


    private void fillfree()
    {
        tblfree.Visible = true;
        tblBatch.Visible = false;
        string values = "", valuesmwf = "", valuestts = "";

        string sdatetest = "";
        string strtest = txt_stratdate.Text;
        string[] splittest = strtest.Split('-');
        sdatetest = splittest[2] + "-" + splittest[1] + "-" + splittest[0];

        int chkcount = 0;
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
                values += CheckBoxList2.Items[i].Value + ",";


                if (Convert.ToInt32(CheckBoxList2.Items[i].Value) == 2 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 4 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 6)
                {
                    valuesmwf += CheckBoxList2.Items[i].Value + ",";
                }
                if (Convert.ToInt32(CheckBoxList2.Items[i].Value) == 3 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 5 || Convert.ToInt32(CheckBoxList2.Items[i].Value) == 7)
                {
                    valuestts = CheckBoxList2.Items[i].Value + ",";
                }



                chkcount += 1;
            }
        }


        values = values.TrimEnd(',');


        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spclassdate]('" + sdatetest + "','MWF','" + os + "','" + ddl_coursename.SelectedValue + "')";
        // Response.Write(_Qry1);

        DataTable dtclassmwf = new DataTable();
        dtclassmwf = MVC.DataAccess.ExecuteDataTable(_Qry1);
        for (int i = 0; i < dtclassmwf.Rows.Count; i++)
        {
            if (classdatemwf == "")
            {
                classdatemwf = "'" + dtclassmwf.Rows[i]["classdate"].ToString() + "'";
            }
            else
            {
                classdatemwf = classdatemwf + ",'" + dtclassmwf.Rows[i]["classdate"].ToString() + "'";
            }
        }

       // classdatemwf = classdatemwf.TrimEnd(',');
        _Qry1 = "select convert(varchar,classdate,101) as classdate from [spclassdate]('" + sdatetest + "','TTS','" + os + "','" + ddl_coursename.SelectedValue + "')";
        // Response.Write(_Qry1);

        DataTable dtclasstts = new DataTable();
        dtclasstts = MVC.DataAccess.ExecuteDataTable(_Qry1);
        for (int i = 0; i < dtclasstts.Rows.Count; i++)
        {
            if (classdatetts == "")
            {
                classdatetts = "'" + dtclasstts.Rows[i]["classdate"].ToString() + "'";
            }
            else
            {
                classdatetts = classdatetts + ",'" + dtclasstts.Rows[i]["classdate"].ToString() + "'";
            }
        }



        _Qry1 = " select batchtiming,max(ss)  as batched,max(facultyId) as facultyId,convert(varchar,classdate,101) as classdate from (select   convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(facultyid) as ss,facultyId from erp_batchSchedule sce where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdatemwf +"," +classdatetts+")  and centrecode='" + Session["SA_centre_code"].ToString() + "' and sce.batchstatus='active' group by classdate,batchtiming,facultyid) as ss group by batchtiming,facultyId,convert(varchar,classdate,101)";
        DataTable dtfac = new DataTable();
        dtfac = MVC.DataAccess.ExecuteDataTable(_Qry1);
        _Qry = " select faculty_id,ft.day,batchtime,facultyname from onlinestudentsfacultydetails fac inner join [erp_facultytimedetails] ft on ft.facultyid=fac.faculty_id  where  fac.centre_code='" + Session["SA_centre_code"].ToString() + "' and status='Enable'";
        DataTable dtfacname = new DataTable();
        dtfacname = MVC.DataAccess.ExecuteDataTable(_Qry);
        DataTable freefaculty = new DataTable();

        freefaculty.Columns.Add(new DataColumn("facultyname1", System.Type.GetType("System.String")));
        // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("sevenmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("ninemwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("elevenmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("onepmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("threepmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("fivepmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("sevenpmmwf", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("seventts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("ninetts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("eleventts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("onepmtts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("threepmtts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("fivepmtts", System.Type.GetType("System.String")));
        freefaculty.Columns.Add(new DataColumn("sevenpmtts", System.Type.GetType("System.String")));
        DataRow drfac = freefaculty.NewRow();

        DataTable dtf = new DataTable();
        // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
        string[] arg = new string[2];

        arg[0] = "faculty_id";
        arg[1] = "facultyname";
        dtf = dtfacname.DefaultView.ToTable(true, arg);
        foreach (DataRow drs in dtf.Rows)
        {
            string slotdate = "";

          
           
            valuesmwf = valuesmwf.TrimEnd(',');
            valuestts = valuestts.TrimEnd(',');
            HiddenField2.Value = values.ToString();
     
            slotdate = HiddenField2.Value;


            if (valuesmwf.ToString() == "")
            {
                valuesmwf = "0";
            }
            if (valuestts.ToString() == "")
            {
                valuestts = "0";
            }


            //Response.Write(valuesmwf);
            //Response.End();

            //Response.Write(valuestts);
      
            //else if (ddlslot.SelectedValue == "Daily")
            //{
            //    slotdate = "2,3,4,5,6,7";
            //}
            drfac = freefaculty.NewRow();
            drfac["facultyname1"] = drs["facultyname"];
            // dr["classdate1"] = "";
             drfac["sevenmwf"]="-";
             drfac["seventts"] = "-";
            string mwfstring = "";
            string ttsstring = "";
            string res;
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='7AMto9AM'") > 0)
            {
                res=getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM' and classdate in (" + classdatemwf + ")");
                if(res!="")
                {
                    mwfstring="MWF:"+res+"/";
                    drfac["sevenmwf"] = res; 
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='7AMto9AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7AMto9AM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["seventts"] = res;
                }               
            }
            //drfac["seven1"] = mwfstring + ttsstring;

            mwfstring = "";
            ttsstring = "";
            drfac["ninemwf"] = "-";
            drfac["ninetts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='9AMto11AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["ninemwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='9AMto11AM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='9AMto11AM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["ninetts"] = res;
                }               
            }
            //drfac["nine1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["elevenmwf"] = "-";
            drfac["eleventts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='11AMto1PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["elevenmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='11AMto1PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='11AMto1PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["eleventts"] = res;
                }                
            }
            //drfac["eleven1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["onepmmwf"] = "-";
            drfac["onepmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='1PMto3PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["onepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='1PMto3PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='1PMto3PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["onepmtts"] = res;
                }                
            }
            //drfac["onepm1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["threepmmwf"] = "-";
            drfac["threepmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='3PMto5PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["threepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='3PMto5PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='3PMto5PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["threepmtts"] = res;
                }               
            }
            //drfac["threepm1"] = mwfstring + ttsstring;

            mwfstring = "";
            ttsstring = "";
            drfac["fivepmmwf"] = "-";
            drfac["fivepmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='5PMto7PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    mwfstring = "MWF:" + res + "/";
                    drfac["fivepmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='5PMto7PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='5PMto7PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["fivepmtts"] = res;
                }                
            }
           // drfac["fivepm1"] = mwfstring + ttsstring;
            mwfstring = "";
            ttsstring = "";
            drfac["sevenpmmwf"] = "-";
            drfac["sevenpmtts"] = "-";
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuesmwf + ") and batchtime='7PMto9PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatemwf + ")");
                if (res != "")
                {
                    ttsstring = "MWF:" + res ;
                    drfac["sevenpmmwf"] = res;
                }
            }
            if (getfreeclassdetails(dtfacname, " faculty_id='" + drs["faculty_id"].ToString() + "' and day in (" + valuestts + ") and batchtime='7PMto9PM'") > 0)
            {
                res = getfreefaculty(dtfac, " facultyid='" + drs["faculty_id"].ToString() + "' and batchtiming='7PMto9PM' and classdate in (" + classdatetts + ")");
                if (res != "")
                {
                    ttsstring = "TTS:" + res;
                    drfac["sevenpmtts"] = res;

                }                
            }
            //drfac["sevenpm1"] = mwfstring + ttsstring;
 
            freefaculty.Rows.Add(drfac);
        }
        rpfac.DataSource = freefaculty;
        rpfac.DataBind();
        //gvfaculty.DataSource = freefaculty;
        //gvfaculty.DataBind();
     //   _Qry = "select batch.labid,max(lab.labname) as labname,batch.classdate,count(batch.batchtiming) as batchedsystem,system,batch.batchtiming from erp_batchschedule batch inner join online_students_labavail lab on lab.labid=batch.labid and lab.centre_code=batch.centrecode and  centrecode='" + Session["SA_centre_code"].ToString() + "' where  (convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + "))  group by classdate,batch.labid,batch.batchtiming,system ";

       // _Qry = "select batchtiming,max(ss)  as batchedsystem,labid from (select  classdate,batchtiming,count(labId) as ss,labId from erp_batchSchedule where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ") and centrecode='" + Session["SA_centre_code"].ToString() + "' group by classdate,batchtiming,labId) as ss group by batchtiming,labid";
        _Qry = "select convert(varchar(10),dateadd(d,0,classdate),101) as classdate,batchtiming,count(labId) as batchedlab,labId from erp_batchSchedule  sce where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdatemwf +  ") and centrecode='" + Session["SA_centre_code"].ToString() + "' and sce.batchstatus='active' group by batchtiming,labId,convert(varchar(10),dateadd(d,0,classdate),101)";
       // Response.Write(_Qry+"<br>");
        DataTable dtlab = new DataTable();
        dtlab = MVC.DataAccess.ExecuteDataTable(_Qry);
        _Qry1 = " select labid,labname,system from online_students_labavail where centre_code='" + Session["SA_centre_code"].ToString() + "'";
       // Response.Write(_Qry1);
        DataTable dtlabcount = new DataTable();
        dtlabcount = MVC.DataAccess.ExecuteDataTable(_Qry1);
            
        DataTable freelab = new DataTable();

            freelab.Columns.Add(new DataColumn("labname1", System.Type.GetType("System.String")));
           // freelab.Columns.Add(new DataColumn("classdate1", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("ninemwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("elevenmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("onepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("threepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("fivepmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenpmmwf", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("seventts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("ninetts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("eleventts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("onepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("threepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("fivepmtts", System.Type.GetType("System.String")));
            freelab.Columns.Add(new DataColumn("sevenpmtts", System.Type.GetType("System.String")));

            DataRow dr = freelab.NewRow();
           
            DataTable dt2 = new DataTable();
           // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] args=new string[3];
           
            args[0] = "labid";
            args[1] = "labname";
            args[2] = "system";

            dt2 = dtlabcount.DefaultView.ToTable(true, args);
            foreach (DataRow drs in dt2.Rows)
            {
                //string datecls = drs["classdate"].ToString();
                //string[] split = datecls.Split(',');
                //for (int i = 0; i < split.Length; i++)
                //{
                    dr = freelab.NewRow();
                    dr["labname1"] = drs["labname"];
                   // dr["classdate1"] = "";
                    dr["sevenmwf"] =  getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ") and batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
                    dr["seventts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ") and batchtiming='7AMto9AM'", Convert.ToInt32(drs["system"]));
                    dr["ninemwf"] = getfreebatchedsystem(dtlab, "labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='9AMto11AM'", Convert.ToInt32(drs["system"]));
                    dr["ninetts"] = getfreebatchedsystem(dtlab, "labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='9AMto11AM'", Convert.ToInt32(drs["system"]));
                    dr["elevenmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='11AMto1PM'", Convert.ToInt32(drs["system"]));
                    dr["eleventts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='11AMto1PM'", Convert.ToInt32(drs["system"]));
                    dr["onepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='1PMto3PM'", Convert.ToInt32(drs["system"]));
                    dr["onepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='1PMto3PM'", Convert.ToInt32(drs["system"]));
                    dr["threepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='3PMto5PM'", Convert.ToInt32(drs["system"]));
                    dr["threepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='3PMto5PM'", Convert.ToInt32(drs["system"]));
                    dr["fivepmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='5PMto7PM'", Convert.ToInt32(drs["system"]));
                    dr["fivepmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='5PMto7PM'", Convert.ToInt32(drs["system"]));
                    dr["sevenpmmwf"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatemwf + ")  and batchtiming='7PMto9PM'", Convert.ToInt32(drs["system"]));
                    dr["sevenpmtts"] = getfreebatchedsystem(dtlab, " labid='" + drs["labid"].ToString() + "' and classdate in (" + classdatetts + ")  and batchtiming='7PMto9PM'", Convert.ToInt32(drs["system"])); // and batchtiming='" + drs["batchtiming"].ToString() + "'
                    freelab.Rows.Add(dr);
               // }
            }
            rplab.DataSource = freelab;
            rplab.DataBind();
            //gvlab.DataSource = freelab;
           // gvlab.DataBind();

            string dateclass = classdate;           
            string sdate = txt_stratdate.Text;
            string[] split = sdate.Split('-');
            sdate = split[2] + "-" + split[1] + "-" + split[0];
            _Qry1 = "select convert(varchar,classdate,101) as classdate from [spcustomclassdate]('" + sdate + "','" + values + "','" + os + "','" + ddl_coursename.SelectedValue + "')";
            // Response.Write(_Qry1);
            DataTable dtclass = new DataTable();
            dtclass = MVC.DataAccess.ExecuteDataTable(_Qry1);            
            string qry = " select Submodule_id,ModuleId,software_id,Module,Software,Content from submodule_details_new where status='Active' and moduleid='"+ddl_coursename.SelectedValue+"' and software_id in (" + os + ") order by classOrder,submodule_id";
            DataTable dtmodule = new DataTable();
            dtmodule = MVC.DataAccess.ExecuteDataTable(qry);

            DataTable dtcontent = new DataTable();
            dtcontent.Columns.Add(new DataColumn("Classdate", System.Type.GetType("System.String")));
            dtcontent.Columns.Add(new DataColumn("Content", System.Type.GetType("System.String")));
            DataRow drfree = dtcontent.NewRow();
            for (int i = 0; i < dtmodule.Rows.Count; i++)
            {
                drfree = dtcontent.NewRow();
                drfree["Classdate"] = dtclass.Rows[i]["classdate"].ToString();
                drfree["Content"] = dtmodule.Rows[i]["Content"].ToString();
                dtcontent.Rows.Add(drfree);
            }
            _Qry = "select  convert(varchar(10),dateadd(d,0,classdate),101) as classdate,facultyid,ba.labid,batchtiming,subcontentid,system from erp_batchschedule ba inner join  online_students_labavail lab on lab.Labid=ba.labid and lab.centre_code=ba.centrecode where (facultyid='" + ddlfac.SelectedValue + "' or ba.labid='" + ddllab.SelectedValue + "') and batchtiming='" + ddlbatch.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ")";
           // Response.Write(_Qry);
            DataTable dtdetails = new DataTable();
            dtdetails = MVC.DataAccess.ExecuteDataTable(_Qry);

            DataTable dtfullcontent = new DataTable();
            dtfullcontent.Columns.Add(new DataColumn("Classdate", System.Type.GetType("System.String")));
            dtfullcontent.Columns.Add(new DataColumn("Content", System.Type.GetType("System.String")));
            dtfullcontent.Columns.Add(new DataColumn("Faculty", System.Type.GetType("System.String")));
            dtfullcontent.Columns.Add(new DataColumn("Lab", System.Type.GetType("System.String")));
            DataRow drfreecontent = dtfullcontent.NewRow();
            DataTable dt3 = new DataTable();
           // dt2 = dtamt.DefaultView.ToTable(true, "studentid");
            string[] args1=new string[2];
           
            args1[0] = "classdate";
            args1[1] = "Content";


            dt3 = dtcontent.DefaultView.ToTable(true, args1);
            foreach (DataRow drs in dt3.Rows)
            {
                drfreecontent = dtfullcontent.NewRow();
                drfreecontent["Classdate"] = drs["classdate"].ToString();
                drfreecontent["Content"] = drs["content"].ToString();
                drfreecontent["Faculty"] = getfreedetails(dtdetails, " classdate='" + drs["classdate"].ToString() + "'", "facultyid");
                drfreecontent["Lab"] = getfreelabcount(dtdetails, " classdate='" + drs["classdate"].ToString() + "'", "labid");
                dtfullcontent.Rows.Add(drfreecontent);
            }
            lblbatch_time.Text = ddlbatch.SelectedItem.Text;
            //lbl_slotdetail.Text = ddlslot.SelectedItem.Text;
            lblfac_name.Text = ddlfac.SelectedItem.Text;
            lbllab_name.Text = ddllab.SelectedItem.Text;
           lblst_date.Text = txt_stratdate.Text;
            lblen_date.Text = txt_enddate.Text;
            gvclass.DataSource = dtfullcontent;
            gvclass.DataBind();
    }

    

    string getfreelabcount(DataTable dtexp, string expression, string column)
    {
        string res = "free";
        int count = 0;
        string labid = "";
        int system = 0;
        int freesys = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                labid = (val[column].ToString());
                system = Convert.ToInt32(val["system"]);
                count += 1;
            }
        }
        freesys = system - count;
        if (count > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'> " + count + " Batched </span> / <span style='color:green; font-weight:bold;'> " + freesys + " Free </span>";
        }
        else
        {
            res = "<span style='color:green; font-weight:bold;'>  Free </span>";
        }
       
        return res.ToString();
    }


    string getfreedetails(DataTable dtexp, string expression,string column)
    {
        string res = "<span style='color:green; font-weight:bold;'> Free </span>";
        int count = 0;
        string facultyid = "";
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                facultyid = (val[column].ToString());
                count += 1;
            }
        }
        if (count>0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>  Batched </span>";
        }
        return res.ToString();
    }

    string getfreefaculty(DataTable dtexp, string expression)
    {
        string res = "<span style='color:green; font-weight:bold;'>Free</span>";
        int batched = 0;
        DataRow[] dr = new DataRow[100];

        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            foreach (DataRow val in dr)
            {
                batched  = Convert.ToInt32(val["batched"]);              
            }
        }
        if (batched > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>Batched</span>";
        }
        return res.ToString();
    }

    int getfreeclassdetails(DataTable dtexp, string expression)
    {
        int count = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
           count += 1;
        }
        return count;
    }

    string getfreebatchedsystem(DataTable dtexp, string expression,int column)
    {
        string res = "";
        int batchedsystem = 0;
        int totalsystem = column;
        int freesystem = 0;
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {             
            foreach (DataRow val in dr)
            {
                batchedsystem = Convert.ToInt32(val["batchedlab"]);
                freesystem = totalsystem - batchedsystem;
            }
                       
        }
        if (batchedsystem > 0)
        {
            res = "<span style='color:#ff0000; font-weight:bold;'>" + batchedsystem + " Batched </span>/<span style='color:green; font-weight:bold;'>" + freesystem + " free </span>";
        }
        else
        {
            res = "<span style='color:green; font-weight:bold;'>" + totalsystem + " Free </span>";
        }
        return res.ToString();
    }



    string getCount1(DataTable dtexp, string expression, string column)
    {
        string res = "";
        string emp = ""; 
        DataRow[] dr = new DataRow[100];
        dr = dtexp.Select(expression);
        if (dr.Length > 0)
        {
            //res = dr.Length.ToString();
            foreach (DataRow val in dr)
            {                 
                res = res+","+ (val[column].ToString());
            }

            string value = res;
            string[] split = value.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].ToString() == "batched")
                {
                    res = "Batched";
                }                 
            }
        }

        if (res != "batched")
        {
            res = "Free";
        }
        return res.ToString();
    }

    protected void Gridvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridvw.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enterbatchcode.aspx");
    }
  

    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Write(HiddenField2.Value.ToString());
        string values = "";
        _Qry = "select count(*) from  submodule_details_new where status='Active' and moduleid='" + ddl_coursename.SelectedValue + "' ";
        int countmod = 0;
        countmod = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (countmod > 0)
        {
            string slotdate = "";
            lblmsg1.Text = "";
          
            int chkcount = 0;
            for (int i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                if (CheckBoxList2.Items[i].Selected)
                {
                    values += CheckBoxList2.Items[i].Value + ",";
                    chkcount += 1;
                }
                
            }

             // Response.Write(slotdate);
            values = values.TrimEnd(',');
            HiddenField2.Value = values.ToString();
            slotdate = values.ToString();
            
            int batchedsystem = 0;
            int totalsystem = 0;
            int freesystem = 0;
            string sdate = "";
            string str = txt_stratdate.Text;
            string[] split = str.Split('-');
            sdate = split[2] + "-" + split[1] + "-" + split[0];
            //
            
            int n;
            for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
            {
                if (CheckBoxList1.Items[n].Selected)
                {
                    if (os == "")
                    {
                        os = CheckBoxList1.Items[n].Value;
                    }
                    else
                    {
                        os = os + "," + CheckBoxList1.Items[n].Value;
                    }

                }
                //}
            }



            //
            _Qry1 = "select convert(varchar,classdate,101) as classdate from [spcustomclassdate]('" + sdate + "','"+values+"','" + os + "' ,'" + ddl_coursename.SelectedValue + "')";
            //Response.Write(_Qry1);
          // Response.End();
            DataTable dtclass = new DataTable();
            dtclass = MVC.DataAccess.ExecuteDataTable(_Qry1);
            if (dtclass.Rows.Count>0)
            {
                for (int i = 0; i < dtclass.Rows.Count; i++)
                {
                    if (classdate == "")
                    {
                        classdate = "'" + dtclass.Rows[i]["classdate"].ToString() + "'";
                    }
                    else
                    {
                        classdate = classdate + ",'" + dtclass.Rows[i]["classdate"].ToString() + "'";
                    }
                    txt_enddate.Text = dtclass.Rows[i]["classdate"].ToString();
                    string[] spenddate = txt_enddate.Text.Split('/');
                    txt_enddate.Text = spenddate[1] + "/" + spenddate[0] + "/" + spenddate[2];
                }
            }
            else
            {
                classdate="''";
            }
                _Qry = "select system from online_students_labavail where centre_code='" + Session["SA_centre_code"].ToString() + "' and labid='" + ddllab.SelectedValue + "'";
                DataTable dtsys = new DataTable();
                dtsys = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dtsys.Rows.Count > 0)
                {
                    totalsystem = Convert.ToInt32(dtsys.Rows[0]["system"]);
                }
                _Qry = "select batchtiming,max(ss)  as batchedsystem,max(labId) as labid from (select  classdate,batchtiming,count(labId) as ss,labId from erp_batchSchedule sce where   convert(varchar(10),dateadd(d,0,classdate),101) in (" + classdate + ") and labid='" + ddllab.SelectedValue + "' and centrecode='" + Session["SA_centre_code"].ToString() + "'   and batchtiming='" + ddlbatch.SelectedValue + "' and sce.batchstatus='active'  group by classdate,batchtiming,labId) as ss group by batchtiming";
                DataTable dtbatch = new DataTable();
                dtbatch = MVC.DataAccess.ExecuteDataTable(_Qry);
                if (dtbatch.Rows.Count > 0)
                {
                    batchedsystem = Convert.ToInt32(dtbatch.Rows[0]["batchedsystem"]);
                }
                else
                {
                    //showBox("Lab Is Not Free..!");
                    //lblmsg1.Text = "Please assign contents to the selected module";
                }
                freesystem = totalsystem - batchedsystem;
                hdnfreesystem.Value = freesystem.ToString();
                //hdnfreesystem.Value = "2";
                _Qry = "select count(batchtime) from erp_facultytimedetails where facultyid='" + ddlfac.SelectedValue + "' and batchtime='" + ddlbatch.SelectedValue.ToString() + "' and day in (" + slotdate + ")";
             //   Response.Write(_Qry+"<br>");
                //Response.End();
                int count = 0;
                count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                if (count==chkcount)
                {


                    _Qry = "select count(facultyid) from erp_batchschedule sce inner join erp_batchcontentstatus sts on sts.batchcode=sce.batchcode where sce.batchtiming='" + ddlbatch.SelectedValue.ToString() + "' and facultyid='" + ddlfac.SelectedValue + "' and sce.centrecode='" + Session["SA_centre_code"].ToString() + "' and convert(varchar(10),dateadd(d,0,sce.classdate),101)  in (" + classdate + ") and sts.status='Pending' and sce.batchstatus='active' ";
                    //Response.Write(_Qry);
                    count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
                    if (count > 0)
                    {
                        fillfree();
                        showBox("Faculty Is Not Free..!");
                        /// faculty does not exist
                    }
                    else
                    {
                        if (Convert.ToInt32(hdnfreesystem.Value) > 0)
                        {

                            fillgrid();
                        }
                        else
                        {
                            fillfree();
                            showBox("Lab Is Not Free..!");
                        }

                    }
                }
                else
                {
                    fillfree();
                    showBox("Faculty  Is Not Free...!");

                }
          
            //tblBatch.Visible = true;
            Label1.Text = "";
        }
        else
        {
            lblmsg1.Text = "Please assign contents to the selected module";
            tblBatch.Visible = false;
        }
    }
     

     
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("createNewBatch.aspx");
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("createNewBatch.aspx");
    }


    protected void btnconform_Click(object sender, EventArgs e)
    {
        _Qry = "select count(*) from erp_batchdetails where batchcode='" + lblbatchcode.Text.Trim() + "' and status='pending'";
        int count = 0;
        count = MVC.DataAccess.ExecuteScalar(MVC.DataAccess.ConnectionString, _Qry);
        if (count > 0)
        {
            lblmsg1.Text = "Batch already created";
        }
        else
        {
            //Response.Write(lblmainqry.Text);
            //Response.Write(lblbatchqry.Text);
            
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, lblmainqry.Text);
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, lblbatchqry.Text);
            MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, lbldeactive.Text);
                lblbatchqry.Text = "";
                lblmainqry.Text = "";
                lblmsg1.Text = "Batch created successfully";
  
        }
            getdetails.Visible = true;
            tblstudent.Visible = false;
            tblconform.Visible = false; 

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("createNewBatch.aspx");
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        fillgrid();
        tblBatch.Visible = true;
        lblmsg1.Text = "";
    }
    protected void ddl_coursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsoft();
       
    }
    private void fillsoft()
    {

        _Qry = "select distinct a.Software,a.Software_id from Submodule_details_new a inner join Onlinestudent_Software b on b.software_id=a.software_id where b.status='Enable' and a.status='active' and ModuleId='" + ddl_coursename.SelectedValue + "' ";
        DataTable dt = new DataTable();
        dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        if (dt.Rows.Count > 0)
        {
            CheckBoxList1.Items.Clear();
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = "Software";
            CheckBoxList1.DataValueField = "Software_id";
            CheckBoxList1.DataBind();
        }
        
      
        //_Qry = "select software_id from module_details where module_id='"+ddl_coursename.SelectedValue+"'";
        //DataTable dt = new DataTable();
        //dt = MVC.DataAccess.ExecuteDataTable(_Qry);
        //if(dt.Rows.Count>0)
        //{
            
        //CheckBoxList1.Items.Clear();
        // soft = dt.Rows[0]["software_id"].ToString();
        // _Qry = "select software_id,software_name from Onlinestudent_Software where software_id in (select data as dat from SplitString('" + soft + "',','))";
        // DataTable dt1 = new DataTable();
        // dt1 = MVC.DataAccess.ExecuteDataTable(_Qry);
        // CheckBoxList1.DataSource = dt1;
        // CheckBoxList1.DataTextField = "software_name";
        // CheckBoxList1.DataValueField = "software_id";
        // CheckBoxList1.DataBind();

         foreach (ListItem li in CheckBoxList1.Items)
         {
             if (CheckBoxList1.Items.Count == 1)
             {
                 li.Selected = true;
             }
             else if (CheckBoxList1.Items.Count == 0)
             {
                 lblmsg1.Text = "Select atleast one software";
                 

             }
         }    

         //CheckBoxList1.Items.Insert(0, new ListItem("Select All", ""));

        
     

    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    public void soft1()
    {
        int n;
        for (n = 0; n <= CheckBoxList1.Items.Count - 1; n++)
        {
            if (CheckBoxList1.Items[n].Selected)
            {

                if (chk1 == "")
                {
                    chk1 = CheckBoxList1.Items[n].Text;
                }
                else
                {
                    chk1 = chk1 + "," + CheckBoxList1.Items[n].Text;
                }

            }

            //}
        }

    }
    protected void gvclass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string values = "";
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
                values += CheckBoxList2.Items[i].Value + ",";
               
            }

        }

        // Response.Write(slotdate);
        values = values.TrimEnd(',');
        HiddenField2.Value = values.ToString();

    }
}

