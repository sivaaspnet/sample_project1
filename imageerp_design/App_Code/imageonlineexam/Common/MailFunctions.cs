using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Mail;

namespace MVC1
  {
      public class MailFunctions
      {
          public static void SendMail(string MailFrom, string MailTo, string MailSubject, string MailBody)
          {
              MailMessage objMail = new MailMessage();
              objMail.From = MailFrom;
              objMail.To = MailTo;
             // objMail.Cc = System.Configuration.ConfigurationManager.AppSettings["CSV_CCmail"];
              //objMail.Bcc = "maildata909@gmail.com";
              objMail.BodyFormat = MailFormat.Html;
              objMail.Priority = MailPriority.High;
              objMail.Subject = MailSubject;
              objMail.Body = MailBody;
              objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
              objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", SMTP_USER_NAME);
              objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", SMTP_PASSWORD);
              SmtpMail.SmtpServer = SMTP_SERVER;
              SmtpMail.Send(objMail);

          }

          public static string SMTP_SERVER = System.Configuration.ConfigurationManager.AppSettings["SMTP_SERVER"];
          public static string SMTP_USER_NAME = System.Configuration.ConfigurationManager.AppSettings["SMTP_USER_NAME"];
          public static string SMTP_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["SMTP_PASSWORD"];



     }
 }



