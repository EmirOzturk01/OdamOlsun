using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OdamOlsun.Entities.Models.Concrete; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OdamOlsun.Entities.DbContexts
{

    namespace OdamOlsun.Entities.DbContexts
    {
        public class AppDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Ilan> Ilanlar { get; set; }
            public DbSet<Resim> Resims { get; set; }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }

            private readonly IConfiguration _configuration;

            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {

            }
            public AppDbContext()
            {

            }
            // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            // {
            //    //var connectionString = _configuration.GetConnectionString("DefaultConnection");
            //         optionsBuilder.UseMySql("Server=127.0.0.1;Database=OdamOlsun;Uid=root;Pwd=123password321");

            // }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                var connectionString = "Server=127.0.0.1;Database=OdamOlsunDeneme;Uid=root;Pwd=123password321";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
            }
        }
    }

}