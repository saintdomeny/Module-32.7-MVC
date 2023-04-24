using Microsoft.EntityFrameworkCore;
using Module_32._7_MVC.Models.Db;

namespace Module_32._7_MVC.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }

        /// Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; }
        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
        }*/
    }
}
