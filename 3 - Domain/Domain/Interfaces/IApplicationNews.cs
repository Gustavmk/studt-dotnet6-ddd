using Domain.Interfaces.Generic;
using Entities.Entities;

namespace Domain.Interfaces
{
    public interface IApplicationNews : IGeneric<News>
    {
        Task AddNews(News news);
        Task UpdateNews(News news);
        Task<List<News>> ListActiveNews();
        
    }
}

