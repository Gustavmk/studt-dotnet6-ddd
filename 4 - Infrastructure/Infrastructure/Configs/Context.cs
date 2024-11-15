using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configs
{

    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        
        public DbSet<News> News { get; set; }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        // metodo override - identifica se está configurado a connection string com o database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
            
        }

        // já existente no DbContext, customização para alterar tabela AspNetUsers. Impotante na hora da migration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            
            base.OnModelCreating(builder);
        }
        
        public string GetConnectionString()
        {
            string strConn =  "Data Source=mssql;Initial Catalog=NewsDB;Integrated Security=True; User ID=sa; Password=Password123";
            return strConn;
        }
        
    }
}