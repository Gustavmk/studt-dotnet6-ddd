using System.Linq.Expressions;

namespace Application.Interfaces.Generics
{
    public interface IGenericApplication<T> where T : class
    {
        Task Add(T Object);
        Task Update(T Object);
        Task Delete(T Object);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
    }
}

