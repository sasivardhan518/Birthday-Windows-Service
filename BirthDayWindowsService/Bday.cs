using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InRhythm.DataAccess;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using BdayListGenerator;
using BdayForm;

namespace BirthDayWindowsService
{
    public class Bday
    {
        public Bday()
        {
            string str = BdayReminder.str;
            Form1 form = new Form1();
        }
    }
}
