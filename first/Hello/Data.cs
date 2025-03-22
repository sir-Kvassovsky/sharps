using Microsoft.EntityFrameworkCore;

namespace Hello
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  // Таблица пользователей

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Замените параметры на свои реальные данные подключения к PostgreSQL
            options.UseNpgsql("Host=localhost;Port=5432;Database=sharps;Username=postgres;Password=14141");
        }
    }
}
