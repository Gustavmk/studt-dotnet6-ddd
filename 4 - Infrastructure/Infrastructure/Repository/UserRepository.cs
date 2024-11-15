using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configs;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericsRepository<ApplicationUser>, IUser
    {
        private readonly DbContextOptions <Context> _optionsBuilder;
            
        public UserRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();

        }
        
        public async Task<bool> AddUser(string email, string password, int age, string phoneNumber)
        {
            try
            {
                using (var data = new Context(_optionsBuilder))
                {
                    await data.ApplicationUsers.AddAsync(
                        new ApplicationUser
                        {
                            Email = email,
                            PasswordHash = password,
                            BirthDate = age,
                            PhoneNumber = phoneNumber

                        });
                    
                    await data.SaveChangesAsync();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;

            }

            return true;

        }
    }
}

