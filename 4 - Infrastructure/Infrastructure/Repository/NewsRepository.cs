using System.Linq.Expressions;
using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configs;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class NewsRepository : GenericsRepository<News>, INews
    {
        private readonly DbContextOptions <Context> _optionsBuilder;
            
        public NewsRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();

        }
        
        public async Task<List<News>> ListNews(Expression<Func<News, bool>> exNews)
        {
            using (var database = new Context(_optionsBuilder))
            {
                return await database.News.Where(exNews).AsNoTracking().ToListAsync();
            }
        }
    }
}
