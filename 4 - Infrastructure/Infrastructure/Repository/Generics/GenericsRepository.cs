using System.Runtime.InteropServices;
using Domain.Interfaces.Generic;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace Infrastructure.Repository.Generics
{

    public class GenericsRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        
        private readonly DbContextOptions<Context> _optionsBuilder;
        
        public GenericsRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Add(T Object)
        {
            using (var data = new Context(_optionsBuilder))
            {
               await data.Set<T>().AddAsync(Object);
               await data.SaveChangesAsync();
            }
        }

        public async Task Update(T Object)
        {
            using (var data = new Context(_optionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Object)
        {
            using (var data = new Context(_optionsBuilder))
            {
                data.Set<T>().Remove(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync(); //AsNoTracking evita que traga toda configuração do EF
            }
        }
        
        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // reference https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }
    
}