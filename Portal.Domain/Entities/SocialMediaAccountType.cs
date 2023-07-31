using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class SocialMediaAccountType : BaseEntity
    {
        
        public string AccountType { get; set; }
        
        //public User User { get; set; }
        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}
