using CodeShopWarehouse.Business;
using CodeShopWarehouse.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeShopWarehouse.Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ordersService.GetUnprocessedOrders());
        }   
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_ordersService.GetById(id));
        }   
        [HttpPost]
        public IActionResult Create(Order data)
        {
            return Ok(_ordersService.CreateOrder(data));
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order data)
        {
            return Ok(_ordersService.ProcessOrder(data));
        }
    }
}