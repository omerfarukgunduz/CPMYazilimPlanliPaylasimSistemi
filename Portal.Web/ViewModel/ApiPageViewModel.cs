using Portal.Domain.Entities;

namespace Portal.Web.ViewModel
{
    public class ApiPageViewModel
    {
        public List<AccessToken>? Token { get; set; }
        public AccessToken? SingleToken { get; set; }
    }
}
