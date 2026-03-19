using Domain.Entities.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DoYouKnowIt.Infrastructure.Connections
{
    public class MyDbContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }


        static string connStr = "Server=.\\SQLExpress;Database=DoYouKnowItNew;Trusted_Connection=True; TrustServerCertificate=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
