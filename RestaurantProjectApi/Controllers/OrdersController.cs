using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.BusinessLayer.Abstract;
using RestaurantProject.DtoLayer.OrderDto;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var value = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetWithOrderDetails().OrderByDescending(x => x.OrderDate));
            return Ok(value);
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            _orderService.TAdd(new Order()
            {
                Description = createOrderDto.Description,
                OrderDate = createOrderDto.OrderDate,
                TotalPrice = createOrderDto.TotalPrice,
                AppUserId = createOrderDto.AppUserId,
                MenuTableID = createOrderDto.MenuTableID
            });
            return Ok("Sipariş Bilgisi Eklendi");
        }


    }
}
