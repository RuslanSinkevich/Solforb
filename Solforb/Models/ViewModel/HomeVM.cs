namespace Solforb.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Order>? Order { get; set; }
        public IEnumerable<Provider>? Provider { get; set; }
    }
}
