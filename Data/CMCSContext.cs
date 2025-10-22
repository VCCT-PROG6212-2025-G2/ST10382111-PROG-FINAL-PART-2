using Microsoft.EntityFrameworkCore;
using CMCS.Models;

namespace CMCS.Data
{
    public class CMCSContext : DbContext
    {
        public CMCSContext(DbContextOptions<CMCSContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }
    }
}
