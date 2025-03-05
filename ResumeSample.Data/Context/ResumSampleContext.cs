using Microsoft.EntityFrameworkCore;
using ResumeSample.Domain.Models.Auth;

namespace ResumeSample.Data.Context
{
    public class ResumSampleContext:DbContext
    {
        public ResumSampleContext(DbContextOptions<ResumSampleContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
