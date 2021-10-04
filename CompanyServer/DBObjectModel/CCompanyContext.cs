using Microsoft.EntityFrameworkCore;

namespace CompanyServer.DBObjectModel
{
	/// <summary>
	/// Summary description for CCompanyContext
	/// </summary>
	public class CCompanyContext : DbContext
	{
		public DbSet<CCompany> Companies { get; set; }
		public DbSet<CEmployee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CEmployee>()
				.HasOne<CCompany>(e => e.Company)
				.WithMany(c => c.Employees)
				.HasForeignKey(e => e.CompanyId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseInMemoryDatabase("database");
        }
    }
}