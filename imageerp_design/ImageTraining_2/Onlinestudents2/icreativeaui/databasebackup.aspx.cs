using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class databasebackup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MVC.DataAccess.ExecuteNonQuery(MVC.DataAccess.ConnectionString, "backup database imageerpnew to disk='F:\\DbBackup\\imageerp_backup" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".bak'");
    }
}