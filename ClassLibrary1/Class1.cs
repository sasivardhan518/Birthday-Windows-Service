using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClassLibrary1
{
    public class Class1
    {
        public System.Diagnostics.EventLog eventLog1 = new System.Diagnostics.EventLog();
        public Class1()
        {
           
            // create an event source, specifying the name of a log that
            // does not currently exist to create a new, custom log
            if (!System.Diagnostics.EventLog.SourceExists("AService"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AService", "Application");
            }
            // configure the event log instance to use this source name
            eventLog1.Source = "AService";
            eventLog1.Log = "Application";
            
        }
        public void WriteLog(string message)
        {
            eventLog1.WriteEntry(message);
        }
    }
}
