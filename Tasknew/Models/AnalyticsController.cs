using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasknew.Services;

namespace Tasknew.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService) {
            _analyticsService = analyticsService;
        }

        [HttpGet(),Route("Sales")]
        public async Task<ActionResult> GetTotalByDate(DateTime startDate, DateTime endDate)
        {
            return Ok(await _analyticsService.GetTotalByDate(startDate, endDate));
        }

        [HttpGet("top-selling")]
        public async Task<IActionResult> GetTopSellingMenuItems()
        {
            return Ok(await _analyticsService.GetTopSellingMenuItems());
        }
    }
}
