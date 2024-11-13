using System.Linq.Expressions;
using Domain.Interfaces.Generic;
using Entities.Entities;

namespace Domain.Interfaces;

public interface INews : IGeneric<News>
{
    Task<List<News>> ListNews(Expression<Func<News, bool>> exNews);
}