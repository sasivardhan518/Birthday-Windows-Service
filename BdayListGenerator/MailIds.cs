using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BdayListGenerator
{
    public static class MailIds
    {
        public static List<string> mailIds { get; set; }
        static MailIds()
        {
            SqlConnection myConn = new SqlConnection(@"Data Source = IRSDSK207\sqlexpress2014; Initial Catalog = BDayDB; Integrated Security = True");
            SqlCommand myCommand = new SqlCommand("select MailId from BDTable", myConn);
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
            mailIds = (from r in ds.AsEnumerable() select r["MailId"].ToString()).ToList();
        }
    }
}
