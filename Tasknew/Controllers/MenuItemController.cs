using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasknew.Models;
using Tasknew.Services;

namespace Tasknew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet, Route("GetMenuItem")]
        public async Task<IActionResult> GetMenuItem()
        {
            return Ok(await _menuItemService.GetMenuItem());
        }

        [HttpGet(), Route("GetMenuItemById" + "/{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            return Ok(await _menuItemService.GetMenuItemById(id));
        }

        [HttpPost, Route("CreateMenuItem")]

        public async Task<IActionResult> CreateMenuItem(MenuItem item)
        {
            return Ok(await _menuItemService.CreateMenuItem(item));
        }



        [HttpPut]
        [Route("UpdateMenuItem")]

        public async Task<IActionResult> UpdateMenuItem(int id, MenuItem item)
        {
            return Ok(await _menuItemService.UpdateMenuItem(id, item));
        }

        [HttpDelete(), Route("DeleteMenuItem" + "/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            return Ok(await _menuItemService.DeleteMenuItem(id));
        }

    }
}
