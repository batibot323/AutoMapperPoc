using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MapperConfiguration _mapperConfig;
        private readonly Mapper _mapper;
        private readonly IOrdersService _ordersService;
        private Order _order;
        private OrderDTO _orderDTO;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOrdersService ordersService)
        {
            _ordersService = ordersService;
            _logger = logger;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.ReplaceMemberName("Price", "Presyo");
            });
            _mapper = new Mapper(_mapperConfig);
            _order = new Order
            {
                DateTayo = DateTime.Now,
                Id = 1,
                NameBabyBoi = "Hani",
                PriceAwitSakit = 42,
                ItemsInMyBag = new List<string>()
                {
                    "Siomai",
                    "Pizza"
                }
            };
            _orderDTO = new OrderDTO
            {
                PresyoAwitSakit = 16,
                Name = "John"
            };
        }

        [Route("GetOrder")]
        [HttpGet]
        public Order GetOrder()
        {
            return _order;
        }

        [Route("GetOrderFromService")]
        [HttpGet]
        public Order GetOrderFromService()
        {
            return _ordersService.GetOrder();
        }

        [Route("GetOrderDTO")]
        [HttpGet]
        public OrderDTO GetOrderDTO()
        {
            return _orderDTO;
        }

        [Route("TransformOrder")]
        [HttpGet]
        public OrderDTO TransformOrder()
        {
            return _mapper.Map<OrderDTO>(_order);
        }

        [Route("TransformOrderDTO")]
        [HttpGet]
        public Order TransformOrderDTO()
        {
            return _mapper.Map<Order>(_orderDTO);
        }
    }
}
