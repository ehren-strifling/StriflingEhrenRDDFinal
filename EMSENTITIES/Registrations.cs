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
    public class Registrations
    {
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
