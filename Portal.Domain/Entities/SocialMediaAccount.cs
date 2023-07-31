using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class SocialMediaAccount : BaseEntity
    {
        
        public string accesToken { get; set; }
        public string consumerKey { get; set; }

        //public User User { get; set; }
        //public SocialMediaAccountType SocialMediaAccountType { get; set; }

        public ICollection<Post> Posts { get; set; }
        

    }
}
