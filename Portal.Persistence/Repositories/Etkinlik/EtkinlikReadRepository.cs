using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class EtkinlikReadRepository : ReadRepository<Etkinlik>, IEtkinlikReadRepository
    {
        public EtkinlikReadRepository(PortalDbContext context) : base(context)
        {
        }
    }
}
