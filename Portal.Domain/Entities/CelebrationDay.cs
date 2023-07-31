using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class CelebrationDay :BaseEntity
    {
        public DateTime Date { get; set; }

        public ICollection<Employee> Employees { get; set; } //Bir tarihte birden fazla kişinin kutlaması yapılabilir
    }
}
