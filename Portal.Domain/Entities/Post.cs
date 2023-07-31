using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    
    public class Post : BaseEntity
    {
        
        public string Text { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public Byte[] ImageBytes { get; set; }

        //public SocialMediaAccount SocialMediaAccount { get; set; }

       
    }
}
