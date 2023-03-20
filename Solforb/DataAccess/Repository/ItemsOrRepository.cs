using Solforb.DataAccess.Repository.IRepository;
using Solforb.Models;

namespace Solforb.DataAccess.Repository
{
    public class ItemsOrRepository : Repository<OrderItem>, IItemsOrRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemsOrRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(OrderItem orderItem)
        {

            _db.OrderItem!.Update(orderItem);
        }
    }
}
    