using Sumsub.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Sumsub.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ReviewResult> ReviewResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public ApplicationDbContext() : base()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().HasKey(Applicant => Applicant.Id);
            modelBuilder.Entity<ReviewResult>().HasKey(ReviewResult => ReviewResult.Id);

            modelBuilder.Entity<Applicant>()
                .HasOne(a => a.ReviewResult);
        }
    }
}