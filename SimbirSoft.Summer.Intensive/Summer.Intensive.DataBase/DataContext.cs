using Microsoft.EntityFrameworkCore;
using Summer.Intensive.DataBase.Models;

namespace Summer.Intensive.DataBase
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        /// <summary>
        /// Конфигурация моделей с помощью FluentApi
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Создание первичный ключей
            modelBuilder.Entity<Page>()
                .HasKey(x => x.Id);

            // Добавление свойств сущности человек
            modelBuilder.Entity<Page>()
                .Property(p => p.Url)
                .IsRequired();
        }

    }
}
