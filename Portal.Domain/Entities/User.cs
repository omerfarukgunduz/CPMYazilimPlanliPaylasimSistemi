using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class User : BaseEntity
    {

        // Arayüz giriş bilgileri
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }

    }
}
