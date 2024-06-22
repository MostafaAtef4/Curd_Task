using Microsoft.EntityFrameworkCore;
using Tasknew.Context;
using Tasknew.Models;

namespace Tasknew.Services
{
    public class FeedBackService :IFeedBackService
    {
        private readonly AppDbContext _context;
        public FeedBackService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateFeedBack(FeedBack feedBack)
        {
            _context.FeedBacks.Add(feedBack);
            var created = await _context.SaveChangesAsync();

            return feedBack.Id;


        }

        public async Task<int> DeleteFeedBack(int id)
        {

            if (_context.FeedBacks == null)
            {
                return 500;
            }
            var feedBack = await _context.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                throw new Exception("feedBack Not Exist");
            }
            _context.FeedBacks.Remove(feedBack);

            await _context.SaveChangesAsync();
            return 200;
        }

        public async Task<List<FeedBack>> GetFeedBack()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        public async Task<FeedBack> GetFeedBackById(int id)
        {
            if (_context.FeedBacks == null)
            {
                throw new Exception("Not Found");

            }
            var feedBack = await _context.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                throw new Exception("Item Not Exsit ");
            }
            return feedBack;


        }

        public async Task<FeedBack> UpdateFeedBack(int id, FeedBack feedBack)
        {
            if (id != feedBack.Id)
            {
                throw new Exception(" Not Found");

            }
            _context.Entry(feedBack).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!FeedBackAvaillabe(id))
                {
                    throw new Exception(" Not Exist");
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
            return feedBack;

        }
        private bool FeedBackAvaillabe(int id)
        {
            return (_context.FeedBacks?.Any(x => x.Id == id)).GetValueOrDefault();
        }
    }
}
