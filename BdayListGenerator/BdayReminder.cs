using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InRhythm.DataAccess;
using System.Data.SqlClient;
using System.Drawing;

namespace BdayListGenerator
{
    public static class BdayReminder
    {
        public static IList<string> bdayList;
        public static IList<string> bdayMailList;
        public static string str = null;
        public static string mailIdOfBdayPerson = null;
        
        static BdayReminder()
        {
            InRhythm.DataAccess.Database db = new Database();
            db.SetInstanceConnectionString(@"Data Source = IRSDSK207\sqlexpress2014; Initial Catalog = BDayDB; Integrated Security = True");
            DataTable ds = db.Execute("select * from BDTable where DATEPART(mm,BirthDay)=DATEPART(mm,GETDATE()) and DATEPART(dd,BirthDay)=DATEPART(dd,GETDATE())").Tables[0];
            bdayList = (from r in ds.AsEnumerable() select r["wishName"].ToString()).ToList();
            bdayMailList= (from r in ds.AsEnumerable() select r["MailId"].ToString()).ToList();
            str = bdayList.Count > 0 ? bdayList.First() : null;
            mailIdOfBdayPerson = bdayMailList.Count > 0 ? bdayMailList.First() : null;
        }
        
    }
}
