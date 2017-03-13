using System;
using System.Diagnostics;
using System.ServiceProcess;
using BdayListGenerator;
using System.Net.Mail;
using System.Timers;
using BdayForm;

namespace BirthDayWindowsService
{
    public partial class BirthDayWindowService : ServiceBase
    {
        public Timer timer = null;
        public BirthDayWindowService()
        {
            Library.WriteErrorLog(DateTime.Now.ToString()+" : Service Instance Created");
            try
            {
                InitializeComponent();
                timer = new Timer();
                this.timer.Interval = 3000;
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Tick);
                timer.Enabled = true;
                timer.Start();
            }
            catch(Exception ex)
            {
                EventLog.WriteEntry(DateTime.Now.ToString() + " : " + ex);
                Library.WriteErrorLog(DateTime.Now.ToString() + " : "+ex);
            }
            
        }

        protected override void OnStart(string[] args)
        {
            Library.WriteErrorLog(DateTime.Now.ToString() + " : Service Started");
            try
            {
                EventLog.WriteEntry(DateTime.Now.ToString() + " : Timer Started");
                   Library.WriteErrorLog(DateTime.Now.ToString() + " : Timer Started");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DateTime.Now.ToString() + " : " + ex);
                   Library.WriteErrorLog(DateTime.Now.ToString() + " : " + ex);
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry(DateTime.Now.ToString() + " : Service Stopped");
            Library.WriteErrorLog(DateTime.Now.ToString() + " : Service Stopped");
            timer.Stop();
            timer.Dispose();
        }
       
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                EventLog.WriteEntry(DateTime.Now.ToString() + " : Timer tick started");
                Library.WriteErrorLog(DateTime.Now.ToString() + " : Timer tick started");
                MailService ms = new MailService();
                EventLog.WriteEntry(DateTime.Now.ToString() + " : Sent Mail");
                Library.WriteErrorLog(DateTime.Now.ToString() + " : Sent Mail");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DateTime.Now.ToString() + " : " + ex.InnerException.ToString());
                Library.WriteErrorLog(DateTime.Now.ToString() + " : " + ex.InnerException.ToString());
                throw ex;
            }
            timer.Start();
        }
    }
}
