using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Entities.Common
{

    public class BaseEntity
    {
        [Key]
        public Guid? Id { get; set; }
        public DateTime? CreatedDate { get; set; }


    }

}
