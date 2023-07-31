using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure
{
    public class UserInMemory 
    {
        public string UserName { get; set; }
       public string Password { get; set; }
    }
}
