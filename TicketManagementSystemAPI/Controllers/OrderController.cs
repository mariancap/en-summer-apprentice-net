﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Json;
using TicketManagementSystemAPI.Exceptions;
using TicketManagementSystemAPI.Models;
using TicketManagementSystemAPI.Models.DTO;
using TicketManagementSystemAPI.Repositories;

namespace TicketManagementSystemAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;

        public OrderController(IOrderRepository OrderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
        {
            _mapper = mapper;
            _orderRepository = OrderRepository;
            _ticketCategoryRepository= ticketCategoryRepository;
        }
        [HttpGet]
        public ActionResult<List<OrderDTO>> GetAll()
        {

            var orders = _orderRepository.GetAll();
            var dtoOrders = new List<OrderDTO>();

            foreach (var @order in orders)
            {

                var orderDTO = new OrderDTO()
                {
                    orderID=@order.OrderId,
                    customer_id=@order.CustomerId,
                    ticket_category_id=@order.TicketCategoryId,
                    ordered_at=@order.OrderedAt,
                    totalPrice=@order.TotalPrice,
                };
                dtoOrders.Add(orderDTO);
            }

            return Ok(dtoOrders);


        }

        [HttpGet]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var @order =await _orderRepository.GetById(id);

            //var dtoOrder = new OrderDTO()
            //{
            //    orderID=@order.OrderId, 
            //    customer_id=@order.CustomerId,
            //    ticket_category_id=@order.TicketCategoryId,
            //    ordered_at=@order.OrderedAt,
            //    totalPrice=@order.TotalPrice,
                
            //};

            var dtoOrder=_mapper.Map<OrderDTO>(@order);


            return Ok(dtoOrder);

        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDTO>> Patch(OrderPatchDTO orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.orderID);
            var ticketcategoryEntity = await _ticketCategoryRepository.GetById(orderPatch.ticket_category_id);

            orderEntity.TotalPrice = orderPatch.number_of_tickets * ticketcategoryEntity.Price;

      
            
            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);

            var orderResponse = _mapper.Map<OrderDTO>(orderEntity);

            return new ContentResult()
            {
                Content = JsonSerializer.Serialize(orderResponse),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };


                 
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            

            _orderRepository.delete(orderEntity);
            return NoContent();
        }
    }
}
