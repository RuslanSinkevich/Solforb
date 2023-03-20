using Solforb.Models;

namespace Solforb.DataAccess.Repository.IRepository
{
    public interface IItemsOrRepository : IRepository<OrderItem>
    {
        void Update(OrderItem orderItem);
    }
}
