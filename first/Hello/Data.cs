using System;
using Microsoft.EntityFrameworkCore;

namespace Hello
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=sharps;Username=postgres;Password=14141")
            .LogTo(Console.WriteLine);    // View SQL queries
}
    }
}
