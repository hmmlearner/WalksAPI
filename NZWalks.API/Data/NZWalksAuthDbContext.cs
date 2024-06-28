using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : DbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> dbContextOptions):base(dbContextOptions) 
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerRoleId = "14a71d4b-6694-4812-b16b-6acceb51351e";
            var writerRoleId = "e9bf6b50-d319-4250-8116-5614cd27f0a5";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name= "Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
                modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
            
        
    }
}
