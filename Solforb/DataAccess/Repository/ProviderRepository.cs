using Solforb.DataAccess.Repository.IRepository;
using Solforb.Models;

namespace Solforb.DataAccess.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        private readonly ApplicationDbContext _db;

        public ProviderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

    }
}
    