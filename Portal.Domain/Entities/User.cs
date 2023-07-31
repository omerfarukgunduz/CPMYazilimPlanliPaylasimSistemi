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
        
        
        
        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; } //bir kullanıcının birden fazla sosyal medya hesab giriş girdisi olabilir olabilir. (accestoken,vb)
        public ICollection<SocialMediaAccountType> SocialMediaAccountsType { get; set; } //Bir kullanıcının birden fazla hesap türü olabilir (twitter,linkdin,vb.)
        public ICollection<Employee> Employees { get; set; } //Bir kullanıcının birden fazla çalışanı olabilir.
    }
}
