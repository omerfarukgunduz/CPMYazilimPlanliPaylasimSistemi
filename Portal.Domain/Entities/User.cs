using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class User : BaseEntity
    {

        // Arayüz giriş bilgileri
        public string UserName { get; set; }
        public string Password { get; set; }



    }
}
