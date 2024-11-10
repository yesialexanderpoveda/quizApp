using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DB
{

 public class QuizContext: IdentityDbContext<AplicationUser>
 {
  public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Result> Result { get; set;}
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Questions>().HasKey(q => q.QuestionsId);
      modelBuilder.Entity<Result>().HasKey(r => r.ResultId);

      modelBuilder.Entity<Result>()
            .HasOne(r => r.Users)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.UserId);  
   }
 }
}