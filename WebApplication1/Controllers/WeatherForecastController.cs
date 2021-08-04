using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
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
        private Order _order;
        private OrderDTO _orderDTO;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();
            });
            _mapper = new Mapper(_mapperConfig);
            _order = new Order
            {
                Date = DateTime.Now,
                Id = 1,
                Name = "Hani",
                Price = 42,
                Items = new List<string>()
                {
                    "Siomai",
                    "Pizza"
                }
            };
            _orderDTO = new OrderDTO
            {
                Price = 16,
                Name = "John"
            };
        }

        [Route("GetOrder")]
        [HttpGet]
        public Order GetOrder()
        {
            return _order;
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
