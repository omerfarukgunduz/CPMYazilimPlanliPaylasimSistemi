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
        public string Token { get; set; }
        
        
    }
}
