using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace ProductsApplication
{
    public class Product_DBContext:DbContext
    {
		private StreamWriter _logStream = null;

		public Product_DBContext()
		 : base()
		{
		}

		//public Product_DBContext(DbContextOptions<Product_DBContext> options)
		// : base(options)
		//{
		//}

		//public virtual DbSet<Product> Product { get; set; }
	

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(App.Configuration.ConnectionString);

  //          if (App.Configuration.IsDbQueryTraceEnabled && App.Configuration.DbQueryTraceDestination.ToLower() == "textfile")
  //          {
  //              if (!Directory.Exists(App.Configuration.TextLogDirectory))
  //              {
  //                  Directory.CreateDirectory(App.Configuration.TextLogDirectory);
  //              }

  //              _logStream = new StreamWriter(App.Configuration.TextLogDirectory + Path.DirectorySeparatorChar + "DbQueries.txt", append: true);
  //              optionsBuilder.LogTo(_logStream.WriteLine, new[] { DbLoggerCategory.Query.Name });
  //              optionsBuilder.EnableSensitiveDataLogging();
  //              optionsBuilder.EnableDetailedErrors();
  //          }
  //      }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);

		//	modelBuilder
		//		.AddProductConfiguration()				
		//	;
		//}
		//public override void Dispose()
		//{
		//	base.Dispose();
		//	if (_logStream != null)
		//	{
		//		_logStream.Dispose();
		//	}
		//}

		//public override async ValueTask DisposeAsync()
		//{
		//	await base.DisposeAsync();
		//	if (_logStream != null)
		//	{
		//		await _logStream.DisposeAsync();
		//	}
		//}


	}


}