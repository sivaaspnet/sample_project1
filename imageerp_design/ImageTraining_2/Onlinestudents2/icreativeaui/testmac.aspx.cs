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
using System.Net.NetworkInformation;
using System.Net;

public partial class Onlinestudents2_testmac : System.Web.UI.Page
{
     
    
    protected void Page_Load(object sender, EventArgs e)
    {
        NetworkInterface[] theNetworkInterfaces;
        theNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        Response.Write(GetIP().ToString());
        //foreach (NetworkInterface currentinterface in theNetworkInterfaces)
        //{
        //    Response.Write("Mac address :" + currentinterface.GetPhysicalAddress().ToString() + "<br>");
        //    //Response.Write("Name : " + currentinterface.Name.ToString() + "<br>");
        //    //Response.Write("GetIPProperties : " + currentinterface.GetIPProperties().ToString() + "<br>");
        //    //Response.Write("GetIPv4Statistics : " + currentinterface.GetIPv4Statistics().ToString() + "<br>");
        //}
    }
     
private string GetIP()
{
string strHostName = "";
strHostName = System.Net.Dns.GetHostName();

IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

IPAddress[] addr = ipEntry.AddressList;

return addr[addr.Length-1].ToString();

}
}
