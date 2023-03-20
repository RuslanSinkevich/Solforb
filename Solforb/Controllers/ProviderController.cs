using Microsoft.AspNetCore.Mvc;
using Solforb.Models;
using Solforb.DataAccess.Repository.IRepository;

namespace Solforb.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderController(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Provider> provider = _providerRepository.GetAll();

            return View(provider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Provider obj)
        {
            if (ModelState.IsValid)
            {
                _providerRepository.Add(obj);
                _providerRepository.Save();
                return RedirectToAction("index");
            }

            return View(obj);
        }

        [HttpGet]
        public  IActionResult Del(int? id)
        {
            Provider obj = _providerRepository.Find(id.GetValueOrDefault());
            if (obj != null)
            {
                _providerRepository.Remove(obj);
                _providerRepository.Save();
            }

            return  RedirectToAction("index");
            //return View(obj);
        }

        [HttpGet]
        public ActionResult GetProviderList()
        {
            return Json(new { data = _providerRepository.GetAll() });
        }
    }
}