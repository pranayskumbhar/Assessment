
using Assessment_18_07_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment_18_07_2024.Data
{
    public class KalbhairavDbContext : DbContext
    {
        public KalbhairavDbContext(DbContextOptions<KalbhairavDbContext> options) : base(options)
        {
                
        }


        public virtual DbSet<Student> Students { get; set; }
    }
}
