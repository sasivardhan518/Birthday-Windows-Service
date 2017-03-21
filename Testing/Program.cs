using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BdayListGenerator;
using System.Drawing;
using System.Net.Mail;
using ClassLibrary1;
using System.Timers;

namespace Testing
{
    class Program
    {
        public static Class1 evtlog = new Class1();
        public Timer timer = null;
        static void Main(string[] args)
        {
            try
            {
                Library.WriteErrorLog(DateTime.Now.ToString() + " : Timer tick started");
                MailService ms = new MailService();
                MailService ms1 = new MailService();
                Library.WriteErrorLog(DateTime.Now.ToString() + " : Sent Mail");
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(DateTime.Now.ToString() + " : " + ex.InnerException.ToString());
                throw ex;
            }
        }
        
    }
}
