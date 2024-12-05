using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DB
{

 public class QuizContext: IdentityDbContext<AplicationUser>
 {
  public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }

        public DbSet<GroupQuestions> GroupQuestions { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Result> Result { get; set;}
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {

      base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<AplicationUser>()
        .HasIndex(u => u.Email)
        .IsUnique();
      modelBuilder.Entity<GroupQuestions>().HasKey(g => g.GroupQuestionId);
      modelBuilder.Entity<Questions>().HasKey(q => q.QuestionsId);
      modelBuilder.Entity<Result>().HasKey(r => r.ResultId);
      
      modelBuilder.Entity<Questions>()
            .HasOne(q => q.GroupQuestions)
            .WithMany(g => g.Questions)
            .HasForeignKey(q => q.GroupQuestionId); 

      modelBuilder.Entity<Result>()
            .HasOne(r => r.Users)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.UserId);       
   }
 }
}