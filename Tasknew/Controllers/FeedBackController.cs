using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasknew.Models;
using Tasknew.Services;

namespace Tasknew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackService _feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }


        [HttpGet, Route("GetFeedBack")]
        public async Task<IActionResult> GetFeedBack()
        {
            return Ok(await _feedBackService.GetFeedBack());
        }

        [HttpGet(), Route("GetFeedBackById" + "/{id}")]
        public async Task<IActionResult> GetFeedBackById(int id)
        {
            return Ok(await _feedBackService.GetFeedBackById(id));
        }

        [HttpPost, Route("CreateFeedBack")]

        public async Task<IActionResult> CreateFeedBack(FeedBack feedBack)
        {
            return Ok(await _feedBackService.CreateFeedBack(feedBack));
        }



        [HttpPut(), Route("UpdateFeedBack" + "/{id}")]


        public async Task<IActionResult> UpdateFeedBack(int id, FeedBack feedBack)
        {
            return Ok(await _feedBackService.UpdateFeedBack(id, feedBack));
        }

        [HttpDelete(), Route("DeleteFeedBack" + "/{id}")]
        public async Task<IActionResult> DeleteFeedBack(int id)
        {
            return Ok(await _feedBackService.DeleteFeedBack(id));
        }
    }
}
