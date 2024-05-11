using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyWebPoject.Data
{
    public class ApplicationContext1 : IdentityDbContext
    {
        //public DbSet<RegisterUser> AspNetUsers { get; set; }

        
        public ApplicationContext1(DbContextOptions<ApplicationContext1> options)
            : base(options)
        {
           //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Указываем, что IdentityUserLogin имеет первичный ключ
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });

            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { 
            //        Id = "8af10569-b018-4fe7-a380-7d6a14c70b74",
            //        Name = "admin",
            //        NormalizedName = "ADMIN"
            //    });
            //modelBuilder.Entity<RegisterUser>().HasData(
            //    //new RegisterUser { Email = "NoName@gmail.com", Password}
            //   //new Employee { Id = 1, Name = "Bob", PhotoPath = "photo4.png" },
            //   //new Employee { Id = 2, Name = "Admin v2", PhotoPath = "NewIcon.png" },
            //   //new Employee { Id = 3, Name = "Drake", PhotoPath = "photo3.png" },
            //   //new Employee { Id = 1111, Name = "Admin", PhotoPath = "photo1.png" }
            //);
        }

    }
}
