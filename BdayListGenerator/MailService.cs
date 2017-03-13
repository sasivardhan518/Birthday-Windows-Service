using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Collections.Generic;


namespace BdayListGenerator
{
    public class MailService
    {
        public static Dictionary<string, bool> todayStatus = new Dictionary<string, bool>();
        public MailService()
        {
            var mailIds=MailIds.mailIds;
            Library.WriteErrorLog(DateTime.Now.ToString() + " : Timer tick started");
            if (BdayReminder.bdayList.Count>0)
            {
                if (todayStatus == null || !todayStatus.ContainsKey(DateTime.Now.ToLongDateString()))
                {
                    todayStatus.Add(DateTime.Now.ToLongDateString(), false);
                }
                if (!todayStatus[DateTime.Now.ToLongDateString()])
                {
                    foreach (var bdayName in BdayReminder.bdayList)
                    {


                        WishImageGenerator wig = new WishImageGenerator(AppDomain.CurrentDomain.BaseDirectory + @"\\BirthDayWishImages\\", bdayName);
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("zimbra.inrhythm-inc.com");
                        System.Net.Mail.Attachment attachment;
                        mail.From = new MailAddress("Batch2k15@inrhythm-inc.com");
                        mail.To.Add(BdayReminder.mailIdOfBdayPerson);
                        foreach (var mailId in mailIds)
                        {
                            mail.CC.Add(mailId);
                        }
                        mail.Subject = "Happy BirthDay " + bdayName;
                        mail.IsBodyHtml = true;
                        string htmlBody;
                        string imagePath = AppDomain.CurrentDomain.BaseDirectory + @"BirthDayWishImages\" + bdayName.Replace(" ", "") + ".jpg";
                        //string imagePath = @"D:\\BirthDayWishImages\\" + BdayReminder.str + ".jpg";
                        htmlBody = "<html><body><img src = " + imagePath + "></body></html> ";
                        mail.Body = htmlBody;
                        attachment = new System.Net.Mail.Attachment(imagePath);
                        mail.Attachments.Add(attachment);
                        SmtpServer.Port = 25;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("shashi.dadi", "Sasi1992");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);
                        Library.WriteErrorLog(DateTime.Now.ToString() + " : Sent Mail");
                        
                    }
                    todayStatus[DateTime.Now.ToLongDateString()] = true;
                }
                
            }
        }

    }
}

