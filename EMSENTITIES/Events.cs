using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EMSENTITIES
{
    // <summary>
    /// Person stores the information about a person
    /// </summary>
    public class Events
    {
        public int EventID { get; set; }
        //public int OrganizerID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
