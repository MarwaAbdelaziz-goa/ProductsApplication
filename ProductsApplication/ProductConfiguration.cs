using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApplication
{
	internal static class ProductConfiguration
	{
		//public static ModelBuilder AddProductConfiguration(this ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Product>(entity =>
		//	{
		//		entity.ToTable("Product");

		//		// PRIMARY KEY
		//		entity.HasKey(e => e.Id)
		//			.HasName("PK_Product");

		//		// COLUMNS
		//		entity.Property(e => e.Id)
		//			.HasColumnName(@"Id")
		//			.HasColumnType("int")
		//			.IsRequired()
		//			.ValueGeneratedOnAdd();

		//		entity.Property(e => e.Name)
		//			.HasColumnName(@"Name")
		//			.HasColumnType("nvarchar")
		//			.IsRequired()
		//			.IsUnicode(false)
		//			.HasMaxLength(70);

		//		entity.Property(e => e.Category)
		//			.HasColumnName(@"Category")
		//			.HasColumnType("nvarchar")
		//			.IsRequired()
		//			.IsUnicode(false)
		//			.HasMaxLength(80);

		//		entity.Property(e => e.Price)
		//			.HasColumnName(@"Price")
		//			.HasColumnType("float")
		//			.IsRequired();
									
		//		entity.Property(e => e.LastUpdateDateTimeStamp)
		//			.HasColumnName(@"LastUpdateDateTimeStamp")
		//			.HasColumnType("datetime2")
		//			.IsRequired();


		//	});

		//	return modelBuilder;
		//}
	}
}
