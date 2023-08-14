namespace Portal.Web.ViewModel
{
	public class EtkinlikEkleViewModel
	{
		public string? title { get; set; }
		public string? description { get; set; }
		public DateTime start { get; set; }
		public DateTime? end { get; set; }
		public IFormFile image { get; set; }
		public bool whatsapp { get; set; }
		public bool linkedin { get; set; }
	}
}
