using Portal.Domain.Entities;

namespace Portal.Web.ViewModel
{
	public class UserVievModel 
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public Guid Id { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string? UpdatedBy { get; set; }
	}
}
