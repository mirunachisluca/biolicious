using API.DTOs;
using AutoMapper;
using Core.Entities.Order;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        [ActionName(nameof(GetOrder))]
        public async Task<ActionResult<OrderToReturnDTO>> GetOrder(int id)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            var order = await _orderService.GetByIdAsync(id, email);

            if (order == null) return NotFound();

            return Ok(_mapper.Map<OrderToReturnDTO>(order));
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDTO>>> GetOrdersForUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            var orders = await _orderService.GetOrdersForCustomerAsync(email);

            if (orders == null) return NoContent();

            return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDTO>>(orders));
        }

        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTO>> CreateOrder(OrderDTO orderDTO)
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var address = _mapper.Map<Address>(orderDTO.ShippingAddress);

            var order = await _orderService.CreateOrderAsync(userEmail, orderDTO.DeliveryMethodId, orderDTO.ShoppingCartId, address);

            if (order == null) return BadRequest();

            var orderToReturn = _mapper.Map<OrderToReturnDTO>(order);

            return CreatedAtAction(nameof(GetOrder), new { id = orderToReturn.Id }, orderToReturn);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();
            
            return Ok(deliveryMethods);
        }
    }
}
