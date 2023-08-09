using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Entities.Common
{

    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

    }

}
