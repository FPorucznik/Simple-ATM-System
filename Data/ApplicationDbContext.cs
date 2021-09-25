using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimpleATMSystem
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        //sample pins for default data
        List<string> defaultPins = new List<string>
        {
            PasswordHasher.HashPassword("1234"),
            PasswordHasher.HashPassword("1010")
        };
            
        string defaultPin = PasswordHasher.HashPassword("1234");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SimpleATMSystemDb;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding sample data
            modelBuilder.Entity<Account>()
                .HasData(
                    new Account { Id = 1, AccountNumber = 123456789, PinHash = defaultPins[0], FirstName = "John", LastName = "Smith", DateOfBirth = new DateTime(1990, 10, 21), Balance = 2340 },
                    new Account { Id = 2, AccountNumber = 111111111, PinHash = defaultPins[1], FirstName = "Mary", LastName = "Green", DateOfBirth = new DateTime(1993, 11, 18), Balance = 3120 }
                );
        }
    }
}
