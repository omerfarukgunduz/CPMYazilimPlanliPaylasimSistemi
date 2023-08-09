using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Etkinlik : BaseEntity
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public byte[]? image { get; set; }
        public bool whatsapp { get; set; }
        public bool linkedin { get; set; }
    }
}
