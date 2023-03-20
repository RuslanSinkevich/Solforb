using Microsoft.AspNetCore.Mvc;
using Solforb.Models;
using Solforb.DataAccess.Repository.IRepository;
using Solforb.Models.ViewModel;
using Solforb.Utilitu;

namespace Solforb.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsOrRepository _itemsOrRepository;
        private readonly IOrderRepository _orderRepository;


        public ItemsController(IItemsOrRepository itemsOrRepository, IOrderRepository orderRepository)
        {
            _itemsOrRepository = itemsOrRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index(int id)
        {
            ViewBag.OrderId = id;
            Order order = _orderRepository.FirstOfDefault(u => u.Id == id);
            ViewBag.Number = order.Number!;
            IEnumerable<OrderItem> orderItem = _itemsOrRepository.GetAll(u => u.OrderId == id);

            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Index(FilterItemVM filterVm)
        {
            var orderId = filterVm.OrderId;
            var name = filterVm.Name;
            var quantity = filterVm.Unit;

            ViewBag.OrderId = orderId;
            Order order = _orderRepository.FirstOfDefault(u => u.Id == orderId);
            ViewBag.Number = order.Number!;
            IEnumerable<OrderItem> orderItem = _itemsOrRepository.GetAll(u => u.OrderId == orderId
                                                                              && (name == null || u.Name == name)
                                                                              && (quantity == null ||
                                                                                  u.Unit == quantity));
            return View(orderItem);
        }

        public IActionResult Upsert(int? orderId, int? itemId)
        {
            ViewBag.OrderId = orderId!;
            Order order = _orderRepository.FirstOfDefault(u => u.Id == orderId);
            ViewBag.Number = order.Number!;
            if (itemId != null)
            {
                OrderItem orderItems = _itemsOrRepository.FirstOfDefault(u => u.Id == itemId);
                return View(orderItems);
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                ViewBag.OrderId = orderItem.OrderId!;
                OrderItem orderI = _itemsOrRepository.FirstOfDefault(u => u.Id == orderItem.Id, isTracking: false);
                if (orderI == null)
                {
                    Order order = _orderRepository.FirstOfDefault(u => u.Id == orderItem!.OrderId 
                                                                       && u.Number == orderItem!.Name);
                    if (order == null)
                    {
                        _itemsOrRepository.Add(orderItem);
                    }
                    else
                    {
                        ViewBag.Error = WC.ErrorItemName;
                        return View(orderI);
                    }
                }
                else
                {
                    _itemsOrRepository.Update(orderItem);
                }

                _itemsOrRepository.Save();
            }

            return RedirectToAction("Index", new { id = orderItem.OrderId });
        }

        [HttpGet]
        public IActionResult Delete(int? orderId, int? itemId)
        {
            ViewBag.OrderId = orderId!;
            Order order = _orderRepository.FirstOfDefault(u => u.Id == orderId);
            ViewBag.Number = order.Number!;
            OrderItem orderItem = _itemsOrRepository.Find(itemId.GetValueOrDefault());
            _itemsOrRepository.Remove(orderItem);
            _itemsOrRepository.Save();
            return RedirectToAction("Index", new { id = orderId });
        }

        [HttpGet]
        public ActionResult GetUnitList()
        {
            var item = _itemsOrRepository.GetAll().GroupBy(u=>u.Unit).Select(u=>u.Key);
            return Json(new { data = item });
        }
    }
}