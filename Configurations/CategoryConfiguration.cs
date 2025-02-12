using FenecApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FenecApi.Configurations;
/// <summary>
/// Configuration settings for the Category entity.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			   .IsRequired()
			   .HasMaxLength(100);

		// One-to-Many relationship with Products
		builder.HasMany(c => c.Products)
			   .WithOne(p => p.Category)
			   .HasForeignKey(p => p.CategoryId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
