using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence.Repositories
{
    public class SocialMediaAccountTypeReadRepository : ReadRepository<SocialMediaAccountType>, ISocialMediaAccountTypeReadRepository
    {
        public SocialMediaAccountTypeReadRepository(PortalDbContext context) : base(context)
        {
        }
    }
}
