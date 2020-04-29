using Microsoft.EntityFrameworkCore;
using SeP.Service.DataContext.Contracts;

namespace SeP.Service.DataContext
{
	public class Context : DbContext
	{
		public DbSet<User> Users { get; set; }

		public Context() : base()
		{
			// Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-5160TTM;Database=SeP;Trusted_Connection=True;");

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(x => x.Id)
				.ValueGeneratedOnAdd();
		}
	}
}
