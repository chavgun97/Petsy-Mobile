using PetSitterSrevice.ORM.Model;
using System.Data.Entity;

namespace PetSitterSrevice.ORM
{
    public class PetSitterDbContext : DbContext
    {
        public PetSitterDbContext() : base("CustomDBConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Bread> Breads { get; set; }

        public DbSet<TypeSitterModel> TypeSitterModels { get; set; }

    }

}