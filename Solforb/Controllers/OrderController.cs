using Microsoft.AspNetCore.Mvc;
using Solforb.Models;
using Solforb.DataAccess.Repository.IRepository;
using Solforb.Utilitu;

namespace Solforb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Order obj)
        {
            if (ModelState.IsValid)
            {
                Order order = _orderRepository.FirstOfDefault(u => u.Id == obj.Id, isTracking: false);
                if (order == null)
                {
                    Order orderNumber = _orderRepository.FirstOfDefault(u => u.Number == obj.Number 
                                                                             && u.ProviderId == obj.ProviderId, isTracking: false);
                    if (orderNumber == null)
                    {
                        _orderRepository.Add(obj); 
                    }
                    else
                    {
                        ViewBag.Error = WC.ErrorOrderNumber;
                        return View(order);
                    }
                }
                else
                {
                    _orderRepository.Update(obj);
                }
                _orderRepository.Save();
            }

            return RedirectToAction("index", "Home");
        }


        public ActionResult Upsert(int? id)
        {
            if (id != null)
            {
                Order order = _orderRepository.FirstOfDefault(u => u.Id == id);
                return View(order);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order orderItem = _orderRepository.Find(id);
            _orderRepository.Remove(orderItem);
            _orderRepository.Save();
            return RedirectToAction("index", "Home");
        }

    }
}