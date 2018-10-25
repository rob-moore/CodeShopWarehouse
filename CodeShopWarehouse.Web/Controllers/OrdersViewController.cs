using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Entities;
using CodeShopWarehouse.Web.Models;
using CodeShopWarehouse.Business;

namespace CodeShopWarehouse.Web1.Controllers
{
    public class OrdersViewController : Controller
    {
        IOrdersService _service;

        public OrdersViewController(IOrdersService service)
        {
            _service = service;
        }

        // GET: OrdersView
        public IActionResult Index()
        {
            return View(_service.GetUnprocessedOrders());
        }

        // GET: OrdersView/Details/5
        public IActionResult Details(int id)
        {
            var order = _service.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View((Order) order);
        }

        // GET: OrdersView/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost([FromForm] Order order)
        {
            _service.CreateOrder(order);
            return Redirect("Index");
        }
        
        [HttpPost]
        public IActionResult ProcessOrder([FromForm]int id)
        {
            
            var o = _service.GetById(id);
            _service.ProcessOrder(o);
            return RedirectToAction("Index", id);
        }
    }
}
