using Solforb.DataAccess.Repository.IRepository;
using Solforb.Models;

namespace Solforb.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Order obj)
        {
            _db.Order!.Update(obj);
        }
    }
}
    