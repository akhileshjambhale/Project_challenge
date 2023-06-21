using AKHILAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace AKHILAPP.Data
{
    public class AkhilAppDbcontext: DbContext
    {
        public AkhilAppDbcontext()
        {

        }
        public AkhilAppDbcontext(DbContextOptions options): base(options) 
        {

        }
        public DbSet<Category_Master> Category_Masters { get; set; }

        public DbSet<Product_Master> Product_Masters { get; set; }
    }
}
