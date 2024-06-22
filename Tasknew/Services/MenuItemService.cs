using Microsoft.EntityFrameworkCore;
using Tasknew.Context;
using Tasknew.Models;

namespace Tasknew.Services
{
    public class MenuItemService:IMenuItemService
    {
        private readonly AppDbContext _context;

        public MenuItemService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<MenuItem> CreateMenuItem(MenuItem item)
        {
            
             _context.MenuItems.Add(item);
            
            
            var created = await _context.SaveChangesAsync();

            return item;

        }

        public async Task<int> DeleteMenuItem(int id)
        {
            if (_context.MenuItems == null)
            {
                return 500;
            }
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null)
            {
                throw new Exception("Item Not Exist");
            }
            _context.MenuItems.Remove(item);

            await _context.SaveChangesAsync();
            return 200;
        }

        public async Task<List<MenuItem>> GetMenuItem()
        {
            //if (_context.MenuItems == null)
            //{
            //    return NotFound();
            //}
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            if (_context.MenuItems == null)
            {
                throw new Exception("Not Found");

            }
            var items = await _context.MenuItems.FindAsync(id);
            if (items == null)
            {
                throw new Exception("Item Not Exsit ");
            }
            return items;
        }

        public async Task<MenuItem> UpdateMenuItem(int id, MenuItem item)
        {
            if (id != item.Id)
            {
                throw new Exception("Item Not Found");

            }
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ItemAvaillabe(id))
                {
                    throw new Exception("Item Not Exist");
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
            return item;
        }

        private bool ItemAvaillabe(int id)
        {
            return (_context.MenuItems?.Any(x => x.Id == id)).GetValueOrDefault();
        }
    }
}
