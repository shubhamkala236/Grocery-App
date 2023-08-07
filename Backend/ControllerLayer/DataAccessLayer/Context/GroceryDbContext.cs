using Microsoft.EntityFrameworkCore;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options):base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            byte[] passwordHash, passwordKey;
            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"));
            }

            modelBuilder.Entity<User>().HasData(
                //admin data
                new User
                {
                    UserId=-1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "8098767811",
                    isAdmin = true,
                    Password = passwordHash,
                    PasswordKey = passwordKey
                }

                );
        }

        //password hash for admin seeding 

    }
}
