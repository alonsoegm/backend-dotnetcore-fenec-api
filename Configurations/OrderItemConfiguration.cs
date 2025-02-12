using FenecApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FenecApi.Configurations;
/// <summary>
/// Configuration settings for the OrderItem entity.
/// </summary>
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.HasKey(oi => oi.Id);

		builder.Property(oi => oi.Quantity)
			   .IsRequired();

		// Foreign key relation with Order
		builder.HasOne(oi => oi.Order)
			   .WithMany(o => o.OrderItems)
			   .HasForeignKey(oi => oi.OrderId)
			   .OnDelete(DeleteBehavior.Cascade);

		// Foreign key relation with Product
		builder.HasOne(oi => oi.Product)
			   .WithMany()
			   .HasForeignKey(oi => oi.ProductId)
			   .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletion of products
	}
}
