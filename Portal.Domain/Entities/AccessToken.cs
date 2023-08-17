using Portal.Domain.Entities.Common;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class AccessToken :BaseEntity
    {
        public string? ApiTuru { get; set; }
        public string? Token { get; set; }
        public string? TokenTitle { get; set; }

        
        
    }
}
