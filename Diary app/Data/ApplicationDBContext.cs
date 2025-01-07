using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) 
        {
                
        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
                {
                    Id = 1,
                    Title = "First Entry",
                    Content = "This is the content of the first entry",
                    Created = new DateTime(2024, 12, 28, 19, 28, 3)
                },
                new DiaryEntry
                {
                    Id = 2,
                    Title = "Second Entry",
                    Content = "This is the content of the second entry",
                    Created = new DateTime(2024, 12, 28, 19, 28, 3)
                }
            );


        }
    }
}
