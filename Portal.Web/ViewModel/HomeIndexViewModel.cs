using Portal.Domain.Entities;

namespace Portal.Web.ViewModel
{
    public class HomeIndexViewModel 
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
        

        public int Role { get; set; }

    }
}
