
using Microsoft.EntityFrameworkCore;
using Tasknew.Context;
using Tasknew.Models;

namespace Tasknew.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly AppDbContext _context;

        public AnalyticsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<decimal> GetTotalByDate(DateTime startDate, DateTime endDate)
        {
            var totalSales = await _context.Orders
                                       .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                                       .SumAsync(o => o.TotalAmount);
            return totalSales;
        }

        public async Task<IEnumerable<TopSellingMenuItemDto>> GetTopSellingMenuItems()
        {
             var TopSelling = await _context.OrderItems
                .GroupBy(oi => new { oi.MenuItemId, oi.MenuItem.Name })
                .Select(g => new TopSellingMenuItemDto
                {
                    MenuItemId = g.Key.MenuItemId,
                    MenuItemName = g.Key.Name,
                    QuantitySold = g.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(dto => dto.QuantitySold)
                .ToListAsync();

            return TopSelling;
        }
        }
}
