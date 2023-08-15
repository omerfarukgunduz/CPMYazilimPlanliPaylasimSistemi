using Portal.Domain.Entities.Common;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Role :BaseEntity
    {
        public string Admin { set; get; } = "Admin";
        public string Kullanici { set; get; } = "Kullanıcı";
        
    }
}
