using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure
{
    public class EventInMemory 
    {
        public string id { get; set; }
        public string eventname { get; set; }
        public string eventDescription { get; set; }
        public string eventLocation { get; set; } 
        public string className { get; set; }
        public DateTime startDate { get; set; } 
        public DateTime endDate { get; set; }
    }
}
