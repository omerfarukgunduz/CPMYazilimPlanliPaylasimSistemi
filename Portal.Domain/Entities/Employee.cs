using Portal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Employee : BaseEntity
    {


        public string Name { get; set; } //isim
        public string Surname { get; set; } //Soyisim
        public string? Gender { get; set; } //cinsiyet
        public string? EmploymentDepartment { get; set; } //çalışan departmanı
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Address { get; set; }
        public string? MaritalStatus { get; set; } //medeni hali

        //public User User { get; set; }
        public ICollection<CelebrationDay> CelebrationDays { get; set; } //Bir kişinin birden fazla özel günü olabilir
        
    }
}
 