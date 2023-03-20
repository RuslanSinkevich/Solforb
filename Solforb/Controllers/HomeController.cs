using Microsoft.AspNetCore.Mvc;using Solforb.Controllers;
using Solforb.DataAccess.Repository.IRepository;
using Solforb.Models.ViewModel;

namespace Solforb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProviderRepository _providerRepository;

        public HomeController( IOrderRepository orderRepository, IProviderRepository providerRepository)
        {
            _orderRepository = orderRepository;
            _providerRepository = providerRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            HomeVM homeVm = new HomeVM()
            {
                Order = _orderRepository.GetAll(includeProperties: "Provider").Take(20),
                Provider = _providerRepository.GetAll()
            };
            return View(homeVm);
        }

        [HttpPost]
        public IActionResult Index(FilterOrderVM filterVm)
        {
            var dateStart = filterVm.DateStart;
            var dateEnd = filterVm.DateEnd;
            var provider = filterVm.Provider;
            var number = filterVm.Number;

            HomeVM homeVm = new HomeVM()
            {
                Order = _orderRepository.GetAll(u => (dateStart == null || u.Date >= dateStart)
                                                      && (dateEnd == null || u.Date <= dateEnd)
                                                      && (provider == 0 || u.ProviderId == provider)
                                                      && (number == null || u.Number == number)
                    , includeProperties: "Provider"),
                Provider = _providerRepository.GetAll()
            };
            return View(homeVm);
        }



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
