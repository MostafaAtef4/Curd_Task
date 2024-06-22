using Tasknew.Models;

namespace Tasknew.Services
{
    public interface IMenuItemService
    {
        Task<MenuItem> CreateMenuItem(MenuItem item);
        Task<int> DeleteMenuItem(int id);
        Task<List<MenuItem>> GetMenuItem();
        Task<MenuItem> GetMenuItemById(int id);
        Task<MenuItem> UpdateMenuItem(int id, MenuItem item);
    }
}
