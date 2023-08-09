using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities.Common;

namespace Portal.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

    }
}
