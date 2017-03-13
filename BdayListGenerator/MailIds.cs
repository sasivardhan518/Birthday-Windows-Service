using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InRhythm.DataAccess;
using System.Data;

namespace BdayListGenerator
{
    public static class MailIds
    {
        public static List<string> mailIds { get; set; }
        static MailIds()
        {
            InRhythm.DataAccess.Database db = new Database();
            db.SetInstanceConnectionString(@"Data Source = IRSDSK207\sqlexpress2014; Initial Catalog = BDayDB; Integrated Security = True");
            DataTable ds = db.Execute("select MailId from BDTable").Tables[0];
            mailIds = (from r in ds.AsEnumerable() select r["MailId"].ToString()).ToList();
        }
    }
}
