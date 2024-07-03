using Microsoft.EntityFrameworkCore;

namespace AEDProject.Entities.Data
{
    public class AEDContext : DbContext
    {
        public AEDContext(DbContextOptions<AEDContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
