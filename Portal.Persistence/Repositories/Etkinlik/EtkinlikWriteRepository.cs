using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;

namespace Portal.Persistence.Repositories
{
    public class EtkinlikWriteRepository : WriteRepository<Etkinlik>, IEtkinlikWriteRepository
    {
        public EtkinlikWriteRepository(PortalDbContext context) : base(context)
        {
        }
    }
}
