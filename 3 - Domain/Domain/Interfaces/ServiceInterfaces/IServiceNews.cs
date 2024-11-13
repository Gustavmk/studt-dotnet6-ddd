using Entities.Entities;

namespace Domain.Interfaces.ServiceInterfaces
{

    public interface IServiceNews
    {
        Task AddNews(News news);
        Task UpdateNews(News news);
        Task<List<News>> ListActiveNews();
        
    }
}