using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasknew.Context;
using Tasknew.Models;

namespace Tasknew.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateOrder(OrderDto order)
        {
            var totalAmount = order.OrderItems.Sum(x => x.Price * x.Quantity);
            var OrderMap = _mapper.Map<Order>(order);
            OrderMap.TotalAmount = totalAmount;
            _context.Orders.Add(OrderMap);
            try
            {
                  await _context.SaveChangesAsync();

            }
            catch (Exception er)
            {

                throw;
            }
            return 200;

        }

        public async Task<List<OrderDto>> GetOrders()
        {
            
            {
                var orders = await _context.Orders
                                           .Include(o => o.OrderItems)
                                           .ThenInclude(oi => oi.MenuItem)
                                           .ToListAsync();

                var orderDTOs = orders.Select(o => new OrderDto
                {
                    Id = o.Id,
                    CustomerName = o.CustomerName,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        Id = oi.Id,
                        Quantity = oi.Quantity,
                        Price = oi.Price,
                        MenuItemId = oi.MenuItemId,
                        MenuItemName = oi.MenuItem.Name 
                    }).ToList()
                }).ToList();

                return orderDTOs;

               
            }
        }


        public async Task<OrderDto> GetOrderById(int id)
        {
            

            var order = await _context.Orders
                                         .Include(o => o.OrderItems)
                                         .ThenInclude(oi => oi.MenuItem)
                                         .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new Exception("Not Found");
            }

            var orderDTO = new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    Quantity = oi.Quantity,
                    Price = oi.Price,
                    MenuItemId = oi.MenuItemId,
                    MenuItemName = oi.MenuItem.Name 
                }).ToList()
            };

            return orderDTO;
        }


        public async Task<int> DeleteOrder(int id)
        {
            var order = await _context.Orders
                                         .Include(o => o.OrderItems)
                                         .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new Exception("Order Not Found");
            }
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
            return 200;
        }

        public async Task<OrderDto> UpdateOrder(int id, OrderDto order)
        {

          var OrderMap=  _mapper.Map<Order>(order);
            var existingOrder = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
                 throw new Exception(" Not Found ");

           

            try
            {
                existingOrder.CustomerName = OrderMap.CustomerName;
                existingOrder.OrderDate = OrderMap.OrderDate;

               
                _context.OrderItems.RemoveRange(existingOrder.OrderItems);

                
                existingOrder.OrderItems = OrderMap.OrderItems;
                existingOrder.TotalAmount = OrderMap.OrderItems.Sum(oi => oi.Price * oi.Quantity);

                await _context.SaveChangesAsync();


                return _mapper.Map<OrderDto>(existingOrder);
            }
            catch (Exception)
            {
            
                throw;

            }

        }

    }

}
