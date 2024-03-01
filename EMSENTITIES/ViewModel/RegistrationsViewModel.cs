using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSENTITIES.ViewModel
{
    public class RegistrationsViewModel
    {
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public DateTime DateRegistered { get; set; }

        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonEmailAddress { get; set; }
    }
}
