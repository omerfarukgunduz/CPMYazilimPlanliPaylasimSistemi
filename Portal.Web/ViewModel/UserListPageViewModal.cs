using Portal.Domain.Entities;

namespace Portal.Web.ViewModel
{
	public class UserListPageViewModal
	{
		public List<User>? User { get; set; }
		public User? SingleUser { get; set; }
	}
}
