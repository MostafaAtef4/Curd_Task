using Tasknew.Models;

namespace Tasknew.Services
{
    public interface IAnalyticsService
    {
        Task<decimal> GetTotalByDate(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TopSellingMenuItemDto>> GetTopSellingMenuItems();
    }
}
