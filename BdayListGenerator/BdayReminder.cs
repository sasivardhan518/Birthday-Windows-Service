using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
            SqlConnection myConn = new SqlConnection(@"Data Source = IRSDSK207\sqlexpress2014; Initial Catalog = BDayDB; Integrated Security = True");
            SqlCommand myCommand = new SqlCommand("select * from BDTable where DATEPART(mm,BirthDay)=DATEPART(mm,GETDATE()) and DATEPART(dd,BirthDay)=DATEPART(dd,GETDATE())", myConn);
            DataTable ds = new DataTable();
            try
            {
                myConn.Open();
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                da.Fill(ds);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            bdayList = (from r in ds.AsEnumerable() select r["wishName"].ToString()).ToList();
            bdayMailList= (from r in ds.AsEnumerable() select r["MailId"].ToString()).ToList();
            str = bdayList.Count > 0 ? bdayList.First() : null;
            mailIdOfBdayPerson = bdayMailList.Count > 0 ? bdayMailList.First() : null;
        }
        
    }
}
