using Microsoft.EntityFrameworkCore;

namespace DB
{

 public class QuizContext: DbContext
 {

    public QuizContext(DbContextOptions<QuizContext> options) : base(options)
    {

    }

    public DbSet<Questions> Questions {get; set;}
    public DbSet<Result> Result {get; set;}
    public DbSet<Users> Users {get; set;}

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {

      modelBuilder.Entity<Questions>().HasKey(q => q.QuestionsId);
      modelBuilder.Entity<Result>().HasKey(r => r.ResultId); 
      modelBuilder.Entity<Users>().HasKey(u => u.UserId); 
      
      modelBuilder.Entity<Result>()
            .HasOne(r => r.Users)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.UserId);
        
        base.OnModelCreating(modelBuilder);
   }

 }
}