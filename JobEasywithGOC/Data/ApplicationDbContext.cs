using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JobEasyWithGOC.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companys { get; set; }
    }
}
