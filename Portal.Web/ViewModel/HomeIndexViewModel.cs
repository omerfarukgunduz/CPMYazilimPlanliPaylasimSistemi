using Portal.Domain.Entities;

namespace Portal.Web.ViewModel
{
    public class HomeIndexViewModel :User
    {

        public bool HasError { get; set; }
        public string? Error { get; set; }
        public bool AdminOrNot { get; set; }
        public DateTime? LoginDate { get; set; }
    }
}
