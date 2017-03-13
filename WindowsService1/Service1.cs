using BdayListGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        public void startService()
        {
            timer1.Start();
        }
        protected override void OnStart(string[] args)
        {
            timer1.Start();
            
        }

        protected override void OnStop()
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string str = BdayReminder.str;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("zimbra.inrhythm-inc.com");
                System.Net.Mail.Attachment attachment;
                mail.From = new MailAddress("shashi.dadi@inrhythm-inc.com");
                mail.To.Add("shashi.dadi@inrhythm-inc.com");
                mail.Subject = "Test Mail";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "<html><body><h1> See the Picture Below </h1><img src = 'c:\\users\\shashi.dadi\\documents\\visual studio 2015\\Projects\\WindowsFormsApplication1\\WindowsFormsApplication1\\images\\Emoji Orte-01 (Copy).png'><p>" + str + "</p><h2> The same image is also sent as attachment.</h2></body></html> ";
                mail.Body = htmlBody;
                attachment = new System.Net.Mail.Attachment("c:\\users\\shashi.dadi\\documents\\visual studio 2015\\Projects\\WindowsFormsApplication1\\WindowsFormsApplication1\\images\\Emoji Orte-01 (Copy).png");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("shashi.dadi", "Sasi@1992");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
