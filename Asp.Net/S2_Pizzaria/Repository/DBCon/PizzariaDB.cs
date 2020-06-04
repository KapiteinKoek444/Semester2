using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Repository.Users;

namespace Repository.DBCon
{
	public class PizzariaDB : DbContext
	{
		public PizzariaDB() : base("dbi433786")
		{
			Database.SetInitializer<PizzariaDB>(null);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public DbSet<User> Users { get; set; }
	}
}
