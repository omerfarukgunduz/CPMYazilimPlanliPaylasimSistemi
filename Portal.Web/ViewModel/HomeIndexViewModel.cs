namespace Portal.Web.ViewModel
{
    public class HomeIndexViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
        public Guid? Id { get; set; }
        public bool AdminOrNot { get; set; }
    }
}
