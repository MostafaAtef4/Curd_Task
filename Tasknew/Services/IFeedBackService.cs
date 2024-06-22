using Tasknew.Models;

namespace Tasknew.Services
{
    public interface IFeedBackService
    {
        Task<int> CreateFeedBack(FeedBack feedBack);
        Task<int> DeleteFeedBack(int id);
        Task<List<FeedBack>> GetFeedBack();
        Task<FeedBack> GetFeedBackById(int id);
        Task<FeedBack> UpdateFeedBack(int id, FeedBack feedBack);

    }
}
