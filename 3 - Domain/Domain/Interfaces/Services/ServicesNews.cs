using Domain.Interfaces.ServiceInterfaces;
using Entities.Entities;

namespace Domain.Interfaces.Services
{
        
    public class ServicesNews : IServiceNews
    {
        private readonly INews _INews;
        
        public ServicesNews(INews INews)
        {
            _INews = INews;
        }
        
        public async Task AddNews(News news)
        {
            var validateTittle = news.ValidatePropertyString(news.NewsTitle, "Tittle");
            
            var validateInformation = news.ValidatePropertyString(news.NewsInformation, "Information");
            
            if (validateTittle && validateInformation)
            {
                news.NewsDatetimeInsert = DateTime.Now;
                news.NewsTimeLastChanged = DateTime.Now;
                news.NewsActive = true;
                
                await _INews.Add(news);
                
            }
            else
            {
                throw new Exception("Invalid news creation");
            }
            
        }

        public async Task UpdateNews(News news)
        {
            var validateTittle = news.ValidatePropertyString(news.NewsTitle, "Tittle");
            var validateInformation = news.ValidatePropertyString(news.NewsInformation, "Information");
            
            if (validateTittle && validateInformation)
            {
                news.NewsDatetimeInsert = DateTime.Now;
                news.NewsTimeLastChanged = DateTime.Now;
                news.NewsActive = true;
                
                await _INews.Update(news);
                
            }
            else
            {
                throw new Exception("Invalid news update");
            }
        }

        public async Task<List<News>> ListActiveNews()
        {
            return await _INews.ListNews(n=> n.NewsActive == true);
        }
    }
}